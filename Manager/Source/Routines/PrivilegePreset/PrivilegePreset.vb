Imports ControlLibrary
Imports MySql.Data.MySqlClient

Public Class PrivilegePreset
    Inherits ParentModel
    Private _Shadow As PrivilegePreset
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
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As PrivilegePreset
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Dim Table As New DataTable()
                Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Adapter As New MySqlDataAdapter(Cmd)
                        Adapter.Fill(Table)
                    End Using
                End Using
                If Table.Rows.Count > 0 Then
                    Dim row As DataRow = Table.Rows(0)
                    SetID(Convert.ToInt64(row("id")))
                    SetCreation(Convert.ToDateTime(row("creation")))
                    SetIsSaved(True)
                    Status = Convert.ToInt32(row("statusid"))
                    Name = Convert.ToString(row("name"))
                    Privileges = GetPrivileges(Tra)
                    LockInfo = GetLockInfo(Tra)
                    If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                Else
                    Throw New Exception("Registro não encontrado.")
                End If
                Tra.Commit()
            End Using
        End Using
        _Shadow = Clone()
        Return Me
    End Function
    Public Sub Delete()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Privileges.ForEach(Sub(p) p.UpdateUser(Con, Tra))
                Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetDelete, Con)
                    Cmd.Parameters.AddWithValue("@id", ID)
                    Cmd.ExecuteNonQuery()
                    Clear()
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        _Shadow = Clone()
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
                        Cmd.Parameters.AddWithValue("@routinename", Privilege.RoutineName)
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
                For Each Privilege As UserPrivilege In _Shadow.Privileges
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
                            Cmd.Parameters.AddWithValue("@routinename", Privilege.RoutineName)
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
        Dim Privileges As New List(Of UserPrivilege)
        Dim Table As New DataTable()
        Using Cmd As New MySqlCommand(My.Resources.PrivilegePresetPrivilegeSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@privilegepresetid", ID)
            Using Adapter As New MySqlDataAdapter(Cmd)
                Adapter.Fill(Table)
            End Using
        End Using
        For Each row As DataRow In Table.Rows
            Dim Privilege As New UserPrivilege With {
                .PrivilegedRoutine = Convert.ToInt32(row("routineid")),
                .Level = Convert.ToInt32(row("privilegelevelid"))
            }
            Privilege.SetIsSaved(True)
            Privilege.SetID(Convert.ToInt32(row("id")))
            Privilege.SetCreation(Convert.ToDateTime(row("creation")))
            Privileges.Add(Privilege)
        Next

        Return Privileges
    End Function

    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
