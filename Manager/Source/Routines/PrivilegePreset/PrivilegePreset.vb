Imports ControlLibrary
Imports MySql.Data.MySqlClient

Public Class PrivilegePreset
    Inherits ParentModel
    Private _User As User
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Privileges As New List(Of UserPrivilege)
    Public Sub New()
        SetRoutine(Routine.PrivilegePreset)
        _User = Locator.GetInstance(Of Session).User
    End Sub


    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        Privileges = New List(Of UserPrivilege)
        _User = Locator.GetInstance(Of Session).User

        'TODO: SE ESSA LINHA FOR REALMENTE NECESSARIA ELA DEVE CONSTAR NOS OUTROS MODELOS
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As PrivilegePreset
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        If Reader.HasRows Then
                            Reader.Read()
                            SetID(Reader.GetInt64("id"))
                            SetCreation(Reader.GetDateTime("creation"))
                            SetIsSaved(True)
                            Status = Reader.GetInt32("statusid")
                            Name = Reader.GetString("name")
                            Privileges = GetPrivileges(Tra)
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
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
    End Sub
    Public Sub Delete()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetDelete, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetInsert, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                    Cmd.Parameters.AddWithValue("@name", Name)
                    Cmd.Parameters.AddWithValue("@userid", User.ID)
                    Cmd.ExecuteNonQuery()
                    SetID(Cmd.LastInsertedId)
                End Using
                For Each Privilege As UserPrivilege In Privileges
                    Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetPrivilegeInsert, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@privilegepresetid", ID)
                        Cmd.Parameters.AddWithValue("@creation", Privilege.Creation)
                        Cmd.Parameters.AddWithValue("@routineid", CInt(Privilege.PrivilegedRoutine))
                        Cmd.Parameters.AddWithValue("@privilegelevelid", CInt(Privilege.Level))
                        Cmd.Parameters.AddWithValue("@userid", _User.ID)
                        Cmd.ExecuteNonQuery()
                        Privilege.SetID(Cmd.LastInsertedId)
                    End Using
                Next Privilege
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        'TODO: SE O CLONE DER CERTO, ALTERAR OS OUTROS PARA CLONE EM VEZ DE CARREGAR DO BANCO
        Dim Shadow As PrivilegePreset = Clone()

        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetUpdate, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", ID)
                    Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                    Cmd.Parameters.AddWithValue("@name", Name)
                    Cmd.Parameters.AddWithValue("@userid", User.ID)
                    Cmd.ExecuteNonQuery()
                End Using
                For Each Privilege As UserPrivilege In Shadow.Privileges
                    If Not Privileges.Any(Function(x) x.ID = Privilege.ID And x.ID > 0) Then
                        Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetPrivilegeDelete, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@id", Privilege.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Privilege
                For Each Privilege As UserPrivilege In Privileges
                    If Privilege.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetPrivilegeInsert, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@privilegepresetid", ID)
                            Cmd.Parameters.AddWithValue("@creation", Privilege.Creation)
                            Cmd.Parameters.AddWithValue("@id", Privilege.ID)
                            Cmd.Parameters.AddWithValue("@routineid", CInt(Privilege.PrivilegedRoutine))
                            Cmd.Parameters.AddWithValue("@privilegelevelid", CInt(Privilege.Level))
                            Cmd.Parameters.AddWithValue("@userid", _User.ID)
                            Cmd.ExecuteNonQuery()
                            Privilege.SetID(Cmd.LastInsertedId)
                        End Using
                    End If
                Next Privilege
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetPrivileges(Transaction As MySqlTransaction) As List(Of UserPrivilege)
        Dim Privilege As UserPrivilege
        Dim Privileges As New List(Of UserPrivilege)
        Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetPrivilegeSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@id", ID)
            Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                While Reader.Read()
                    Privilege = New UserPrivilege With {
                        .PrivilegedRoutine = Reader.GetInt32("routineid"),
                        .Level = Reader.GetInt32("privilegelevelid")
                    }
                    Privilege.SetIsSaved(True)
                    Privilege.SetID(Reader.GetInt32("id"))
                    Privilege.SetCreation(Reader.GetDateTime("creation"))
                    Privileges.Add(Privilege)
                End While
            End Using
        End Using
        Return Privileges
    End Function
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
