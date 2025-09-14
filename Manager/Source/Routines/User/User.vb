Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um usuário.
''' </summary>
Public Class User
    Inherits ParentModel
    Private _UserID As Long
    Private _PersonID As Long
    Private _Password As String
    Private _RequestPassword As Boolean
    Private _Shadow As User
    Public ReadOnly Property RequestPassword As Boolean
        Get
            Return _RequestPassword
        End Get
    End Property
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Username As String = String.Empty
    Public ReadOnly Property Password As String
        Get
            Return _Password
        End Get
    End Property
    Public Property Person As New Lazy(Of Person)(Function() New Person().Load(_PersonID, False))
    Public Property Note As String
    Public Property Privileges As New List(Of UserPrivilege)
    Public Property Emails As New List(Of UserEmail)
    Public Shadows User As New Lazy(Of User)(Function() New User().Load(_UserID, False))
    Public Sub New()
        SetRoutine(Routine.User)
        _UserID = If(Locator.GetInstance(Of Session).User IsNot Nothing, Locator.GetInstance(Of Session).User.ID, 0)
        _Password = Locator.GetInstance(Of Session).Setting.General.User.DefaultPassword
    End Sub
    Public Function CanAccess(Routine As Routine) As Boolean
        Return Privileges.Any(Function(x) x.PrivilegedRoutine.Equals(Routine) And x.Level.Equals(PrivilegeLevel.Access))
    End Function
    Public Function CanWrite(Routine As Routine) As Boolean
        Return Privileges.Any(Function(x) x.PrivilegedRoutine.Equals(Routine) And x.Level.Equals(PrivilegeLevel.Write))
    End Function

    Public Function CanDelete(Routine As Routine) As Boolean
        Return Privileges.Any(Function(x) x.PrivilegedRoutine.Equals(Routine) And x.Level.Equals(PrivilegeLevel.Delete))
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
                _RequestPassword = True
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
                _RequestPassword = False
            End Using
        End Using
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        _UserID = 0
        Status = SimpleStatus.Active
        Username = Nothing
        _Password = Nothing
        Person = New Lazy(Of Person)(Function() New Person().Load(_PersonID, False))
        Privileges = New List(Of UserPrivilege)
        Emails = New List(Of UserEmail)
        _RequestPassword = False
        User = New Lazy(Of User)(Function() New User().Load(_UserID, False))
        If LockInfo.IsLocked Then Unlock()
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
                            SetID(TableResult.Rows(0).Item("id"))
                            SetCreation(TableResult.Rows(0).Item("creation"))
                            SetIsSaved(True)
                            _UserID = ID
                            _PersonID = TableResult.Rows(0).Item("personid")
                            _Password = TableResult.Rows(0).Item("password").ToString
                            _RequestPassword = CBool(TableResult.Rows(0).Item("requestnewpassword"))
                            Status = TableResult.Rows(0).Item("statusid")
                            Username = TableResult.Rows(0).Item("username").ToString
                            Note = TableResult.Rows(0).Item("note").ToString
                            Privileges = GetUserPrivileges(Tra)
                            Emails = GetEmails(Tra)
                            LockInfo = GetLockInfo(Tra)
                            If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                        Else
                            Throw New Exception("Registro não encontrado.")
                        End If
                    End Using
                End Using
                Tra.Commit()
            End Using
        End Using
        _Shadow = Clone()
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Emails.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Privileges.ForEach(Sub(p) p.UpdateUser(Con, Tra))
                Emails.ForEach(Sub(e) e.UpdateUser(Con, Tra))
                Using Cmd As New MySqlCommand(My.Resources.UserDelete, Con, Tra)
                    Cmd.Parameters.AddWithValue("@id", ID)
                    Cmd.ExecuteNonQuery()
                    Clear()
                End Using
                Tra.Commit()
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
                    SetID(Cmd.LastInsertedId)
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
                        Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                        Cmd.ExecuteNonQuery()
                        Email.SetID(Cmd.LastInsertedId)
                    End Using
                Next Email
                For Each Privilege As UserPrivilege In Privileges
                    Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeInsert, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@granteduserid", ID)
                        Cmd.Parameters.AddWithValue("@creation", Privilege.Creation)
                        Cmd.Parameters.AddWithValue("@routineid", CInt(Privilege.PrivilegedRoutine))
                        Cmd.Parameters.AddWithValue("@routinename", Privilege.RoutineName)
                        Cmd.Parameters.AddWithValue("@privilegelevelid", CInt(Privilege.Level))
                        Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                        Cmd.ExecuteNonQuery()
                        Privilege.SetID(Cmd.LastInsertedId)
                    End Using
                Next Privilege
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
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
                For Each Email As UserEmail In _Shadow.Emails
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
                            Email.SetID(Cmd.LastInsertedId)
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
                For Each Privilege As UserPrivilege In _Shadow.Privileges
                    If Not Privileges.Any(Function(x) x.ID = Privilege.ID And x.ID > 0) Then
                        Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeDelete, Con)
                            Cmd.Parameters.AddWithValue("@id", Privilege.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Privilege
                For Each Privilege As UserPrivilege In Privileges
                    If Privilege.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeInsert, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@granteduserid", ID)
                            Cmd.Parameters.AddWithValue("@creation", Privilege.Creation)
                            Cmd.Parameters.AddWithValue("@id", Privilege.ID)
                            Cmd.Parameters.AddWithValue("@routineid", CInt(Privilege.PrivilegedRoutine))
                            Cmd.Parameters.AddWithValue("@routinename", Privilege.RoutineName)
                            Cmd.Parameters.AddWithValue("@privilegelevelid", CInt(Privilege.Level))
                            Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                            Cmd.ExecuteNonQuery()
                            Privilege.SetID(Cmd.LastInsertedId)
                        End Using
                    End If
                Next Privilege
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetEmails(Transaction As MySqlTransaction) As List(Of UserEmail)
        Dim TableResult As DataTable
        Dim Emails As List(Of UserEmail)
        Dim Email As UserEmail
        Using CmdEmail As New MySqlCommand(My.Resources.UserEmailSelect, Transaction.Connection)
            CmdEmail.Transaction = Transaction
            CmdEmail.Parameters.AddWithValue("@ofuserid", ID)
            Using Adp As New MySqlDataAdapter(CmdEmail)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Emails = New List(Of UserEmail)
                For Each Row As DataRow In TableResult.Rows
                    Email = New UserEmail With {
                        .IsMainEmail = Convert.ToBoolean(Row.Item("ismainemail")),
                        .SmtpServer = Convert.ToString(Row.Item("host")),
                        .Port = Convert.ToInt32(Row.Item("port")),
                        .Email = Convert.ToString(Row.Item("email")),
                        .EnableSSL = Convert.ToBoolean(Row.Item("enablessl")),
                        .Password = Convert.ToString(Row.Item("password"))
                    }
                    Email.SetIsSaved(True)
                    Email.SetID(Row.Item("id"))
                    Email.SetCreation(Row.Item("creation"))
                    Emails.Add(Email)
                Next Row
            End Using
        End Using
        Return Emails
    End Function
    Private Function GetUserPrivileges(Transaction As MySqlTransaction) As List(Of UserPrivilege)
        Dim Privilege As UserPrivilege
        Dim Privileges As List(Of UserPrivilege)
        Dim TableResult As DataTable
        Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@granteduserid", ID)
            Using Adp As New MySqlDataAdapter(Cmd)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Privileges = New List(Of UserPrivilege)
                For Each Row As DataRow In TableResult.Rows
                    Privilege = New UserPrivilege With {
                        .PrivilegedRoutine = Convert.ToInt32(Row.Item("routineid")),
                        .Level = Convert.ToInt32(Row.Item("privilegelevelid"))
                    }
                    Privilege.SetIsSaved(True)
                    Privilege.SetID(Row.Item("id"))
                    Privilege.SetCreation(Row.Item("creation"))
                    Privileges.Add(Privilege)
                Next Row
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
