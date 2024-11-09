Imports System.Reflection
Imports System.Web.ModelBinding
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um usuário.
''' </summary>
Public Class User
    Inherits ModelBase
    Private _IsSaved As Boolean
    Private _UserID As Long = If(Locator.GetInstance(Of Session).User IsNot Nothing, Locator.GetInstance(Of Session).User.ID, 0)
    Private _PersonID As Long
    Private _Password As String = Locator.GetInstance(Of Session).Setting.General.User.DefaultPassword
    Public ReadOnly RequestPassword As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Username As String = String.Empty
    Public ReadOnly Property Password As String
        Get
            Return _Password
        End Get
    End Property
    Public Property Person As New Lazy(Of Person)(Function() New Person().Load(_PersonID, False))
    Public Property Note As String
    Public Property Privileges As New UserPrivilege
    Public Property Emails As New OrdenedList(Of UserEmail)
    Public Shadows User As New Lazy(Of User)(Function() New User().Load(_UserID, False))
    Public Sub New()
        _Routine = Routine.User
    End Sub



    Public Function CanAccess(Routine As Routine) As Boolean
        Return Privileges.RoutinePrivileges.Any(Function(x) x.Routine.Equals(Routine) And x.Level.Equals(PrivilegeLevel.Access))
    End Function
    Public Function CanWrite(Routine As Routine) As Boolean
        Return Privileges.RoutinePrivileges.Any(Function(x) x.Routine.Equals(Routine) And x.Level.Equals(PrivilegeLevel.Write))
    End Function

    Public Function CanDelete(Routine As Routine) As Boolean
        Return Privileges.RoutinePrivileges.Any(Function(x) x.Routine.Equals(Routine) And x.Level.Equals(PrivilegeLevel.Delete))
    End Function

    Public Function CanUse(SubRoutine As SingleOptionPrivileges) As Boolean
        Return Privileges.SubRoutinePrivileges.Any(Function(x) x.SubRoutine.Equals(SubRoutine) And x.Level.Equals(PrivilegeLevel.Access))
    End Function




    Public Sub ResetPassword()
        Dim Session = Locator.GetInstance(Of Session)
        Dim CryptoKey = Locator.GetInstance(Of CryptoKeyService)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.UserChangePassword, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@password", Cryptography.Encrypt(Session.Setting.General.User.DefaultPassword, CryptoKey.ReadCryptoKey()))
                Cmd.Parameters.AddWithValue("@requestnewpassword", True)
                Cmd.ExecuteNonQuery()
                Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, True)
            End Using
        End Using
    End Sub
    Public Sub ChangePassword(NewPassword As String)
        Dim Session = Locator.GetInstance(Of Session)
        Dim CryptoKey = Locator.GetInstance(Of CryptoKeyService)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.UserChangePassword, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@password", Cryptography.Encrypt(NewPassword, CryptoKey.ReadCryptoKey()))
                Cmd.Parameters.AddWithValue("@requestnewpassword", False)
                Cmd.ExecuteNonQuery()
                Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, False)
            End Using
        End Using
    End Sub
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _UserID = 0
        Status = SimpleStatus.Active
        Username = Nothing
        _Password = Nothing
        Person = New Lazy(Of Person)(Function() New Person().Load(_PersonID, False))
        Privileges = New OrdenedList(Of Privilege)
        Emails = New OrdenedList(Of UserEmail)
        Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, False)
        User = New Lazy(Of User)(Function() New User().Load(_UserID, False))
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As User
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.UserSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                        If TableResult.Rows.Count = 0 Then
                            Clear()
                        ElseIf TableResult.Rows.Count = 1 Then
                            Clear()
                            _ID = TableResult.Rows(0).Item("id")
                            _UserID = _ID
                            _PersonID = TableResult.Rows(0).Item("personid")
                            _Creation = TableResult.Rows(0).Item("creation")
                            Status = TableResult.Rows(0).Item("statusid")
                            Username = TableResult.Rows(0).Item("username").ToString
                            _Password = TableResult.Rows(0).Item("password").ToString
                            Note = TableResult.Rows(0).Item("note").ToString
                            Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, CBool(TableResult.Rows(0).Item("requestnewpassword")))
                            Privileges = GetUserPrivileges(Tra)
                            Emails = GetEmails(Tra)
                            LockInfo = GetLockInfo(Tra)
                            If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                            _IsSaved = True
                        Else
                            Throw New Exception("Registro não encontrado.")
                        End If
                    End Using
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not _IsSaved Then
            Insert()
        Else
            Update()
        End If
        _IsSaved = True
        Emails.ToList().ForEach(Sub(x) x.IsSaved = True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.UserDelete, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Dim CryptoKey = Locator.GetInstance(Of CryptoKeyService)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.UserInsert, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", DBNull.Value)
                    Cmd.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                    Cmd.Parameters.AddWithValue("@username", Username)
                    Cmd.Parameters.AddWithValue("@password", Cryptography.Encrypt(Password, CryptoKey.ReadCryptoKey()))
                    Cmd.Parameters.AddWithValue("@personid", If(Person.Value.ID = 0, DBNull.Value, Person.Value.ID))
                    Cmd.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    Cmd.Parameters.AddWithValue("@requestnewpassword", True)
                    Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                    Cmd.ExecuteNonQuery()
                    _ID = Cmd.LastInsertedId
                End Using
                For Each Email As UserEmail In Emails
                    Using Cmd As New MySqlCommand(My.Resources.UserEmailInsert, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@ofuserid", ID)
                        Cmd.Parameters.AddWithValue("@ismainemail", Email.IsMainEmail)
                        Cmd.Parameters.AddWithValue("@creation", Email.Creation)
                        Cmd.Parameters.AddWithValue("@host", If(String.IsNullOrEmpty(Email.SmtpServer), DBNull.Value, Email.SmtpServer))
                        Cmd.Parameters.AddWithValue("@port", Email.Port)
                        Cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Email.Email), DBNull.Value, Email.Email))
                        Cmd.Parameters.AddWithValue("@password", If(String.IsNullOrEmpty(Email.Password), DBNull.Value, Email.Password))
                        Cmd.Parameters.AddWithValue("@enablessl", Email.EnableSSL)
                        Cmd.Parameters.AddWithValue("@ofuserid", ID)
                        Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                        Cmd.ExecuteNonQuery()
                        Email.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(Email, Cmd.LastInsertedId)
                    End Using
                Next Email

                For Each Privilege As Privilege In Privileges
                    Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeInsert, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@granteduserid", ID)
                        Cmd.Parameters.AddWithValue("@creation", Privilege.Creation)
                        Cmd.Parameters.AddWithValue("@routineid", CInt(Privilege.Routine))
                        Cmd.Parameters.AddWithValue("@privilegeid", CInt(Privilege.Level))
                        Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                        Cmd.ExecuteNonQuery()
                        Privilege.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(Privilege, Cmd.LastInsertedId)
                    End Using
                Next Privilege
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        'Dim Shadow As User = New User().Load(ID, False)
        Dim Shadow As User = New User().Load(ID, False)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.UserUpdate, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", ID)
                    Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                    Cmd.Parameters.AddWithValue("@username", Username)
                    Cmd.Parameters.AddWithValue("@personid", If(Person.Value.ID = 0, DBNull.Value, Person.Value.ID))
                    Cmd.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                    Cmd.ExecuteNonQuery()
                End Using
                For Each Email As UserEmail In Shadow.Emails
                    If Not Emails.Any(Function(x) x.ID = Email.ID And x.ID > 0) Then
                        Using Cmd As New MySqlCommand(My.Resources.UserEmailDelete, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@id", Email.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Email
                For Each Email As UserEmail In Emails
                    If Email.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.UserEmailInsert, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@ofuserid", ID)
                            Cmd.Parameters.AddWithValue("@ismainemail", Email.IsMainEmail)
                            Cmd.Parameters.AddWithValue("@creation", Email.Creation)
                            Cmd.Parameters.AddWithValue("@id", Email.ID)
                            Cmd.Parameters.AddWithValue("@host", If(String.IsNullOrEmpty(Email.SmtpServer), DBNull.Value, Email.SmtpServer))
                            Cmd.Parameters.AddWithValue("@port", Email.Port)
                            Cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Email.Email), DBNull.Value, Email.Email))
                            Cmd.Parameters.AddWithValue("@password", If(String.IsNullOrEmpty(Email.Password), DBNull.Value, Email.Password))
                            Cmd.Parameters.AddWithValue("@enablessl", Email.EnableSSL)
                            Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                            Cmd.ExecuteNonQuery()
                            Email.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Email, Cmd.LastInsertedId)
                        End Using
                    Else
                        Using Cmd As New MySqlCommand(My.Resources.UserEmailUpdate, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@id", Email.ID)
                            Cmd.Parameters.AddWithValue("@ismainemail", Email.IsMainEmail)
                            Cmd.Parameters.AddWithValue("@host", If(String.IsNullOrEmpty(Email.SmtpServer), DBNull.Value, Email.SmtpServer))
                            Cmd.Parameters.AddWithValue("@port", Email.Port)
                            Cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Email.Email), DBNull.Value, Email.Email))
                            Cmd.Parameters.AddWithValue("@password", If(String.IsNullOrEmpty(Email.Password), DBNull.Value, Email.Password))
                            Cmd.Parameters.AddWithValue("@enablessl", Email.EnableSSL)
                            Cmd.Parameters.AddWithValue("@userid", Email.User.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Email



                For Each Privilege As Privilege In Shadow.Privileges
                    If Not Privileges.Any(Function(x) x.ID = Privilege.ID And x.ID > 0) Then
                        Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeDelete, Con)
                            Cmd.Parameters.AddWithValue("@id", Privilege.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Privilege
                For Each Privilege As Privilege In Privileges
                    If Privilege.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeInsert, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@granteduserid", ID)
                            Cmd.Parameters.AddWithValue("@creation", Privilege.Creation)
                            Cmd.Parameters.AddWithValue("@id", Privilege.ID)
                            Cmd.Parameters.AddWithValue("@routineid", CInt(Privilege.Routine))
                            Cmd.Parameters.AddWithValue("@privilegeid", CInt(Privilege.Level))
                            Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                            Cmd.ExecuteNonQuery()
                            Privilege.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Privilege, Cmd.LastInsertedId)
                        End Using
                    End If
                Next Privilege




                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetEmails(Transaction As MySqlTransaction) As OrdenedList(Of UserEmail)
        Dim TableResult As DataTable
        Dim Emails As OrdenedList(Of UserEmail)
        Dim Email As UserEmail
        Using CmdEmail As New MySqlCommand(My.Resources.UserEmailSelect, Transaction.Connection)
            CmdEmail.Transaction = Transaction
            CmdEmail.Parameters.AddWithValue("@ofuserid", ID)
            Using Adp As New MySqlDataAdapter(CmdEmail)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Emails = New OrdenedList(Of UserEmail)
                For Each Row As DataRow In TableResult.Rows
                    Email = New UserEmail
                    Email.IsMainEmail = Row.Item("ismainemail")
                    Email.SmtpServer = Row.Item("host").ToString
                    Email.Port = Row.Item("port")
                    Email.Email = Row.Item("email").ToString
                    Email.EnableSSL = Row.Item("enablessl").ToString
                    Email.Password = Row.Item("password").ToString
                    Email.IsSaved = True
                    Email.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Email, Row.Item("id"))
                    Email.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Email, Row.Item("creation"))
                    Emails.Add(Email)
                Next Row
            End Using
        End Using
        Return Emails
    End Function

    Private Function GetUserPrivileges(Transaction As MySqlTransaction) As OrdenedList(Of Privilege)
        Dim Privilege As Privilege
        Dim Privileges As New OrdenedList(Of Privilege)
        Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@granteduserid", ID)
            Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                While Reader.Read()
                    Privilege = New Privilege With {
                        .IsSaved = True,
                        .Routine = Reader.GetInt32("routineid"),
                        .Level = Reader.GetInt32("privilegeid")
                    }
                    Privilege.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Privilege, Reader.GetInt32("id"))
                    Privilege.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Privilege, Reader.GetDateTime("creation"))
                    Privileges.Add(Privilege)
                End While
            End Using
        End Using
        Return Privileges
    End Function

    Public Shared Function HasPerson(PersonID As Long) As Boolean
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.UserHasPersonSelect, Con)
                Cmd.Parameters.AddWithValue("@personid", PersonID)
                Con.Open()
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Shared Function GetUsersPersonSortName() As List(Of String)
        Dim Session = Locator.GetInstance(Of Session)
        Dim Username As String
        Dim Usernames As New List(Of String)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.UserPersonShortNameSelect, Con)
                Con.Open()
                Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                    While Reader.Read
                        Username = Reader.GetString("shortname").ToString
                        Usernames.Add(Username)
                    End While
                End Using
            End Using
        End Using
        Return Usernames
    End Function
    Public Overrides Function ToString() As String
        Return If(Username, String.Empty)
    End Function
End Class
