Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um grupo de produtos.
''' </summary>
Public Class ProductGroup
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Sub New()
        SetRoutine(Routine.ProductGroup)
    End Sub
    Public Sub Clear()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As ProductGroup
        Dim TableResult As DataTable
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductGroupSelect As New MySqlCommand(My.Resources.ProductGroupSelect, Con)
                    CmdProductGroupSelect.Transaction = Tra
                    CmdProductGroupSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdProductGroupSelect)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                        Unlock(Tra)
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        Unlock(Tra)
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        SetIsSaved(True)
                        Status = TableResult.Rows(0).Item("statusid")
                        Name = TableResult.Rows(0).Item("name").ToString
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Public Function Load(Identity As Long, Transaction As MySqlTransaction, LockMe As Boolean) As ProductGroup
        Dim TableResult As DataTable
        Using CmdProductGroupSelect As New MySqlCommand(My.Resources.ProductGroupSelect, Transaction.Connection)
            CmdProductGroupSelect.Transaction = Transaction
            CmdProductGroupSelect.Parameters.AddWithValue("@id", Identity)
            Using Adp As New MySqlDataAdapter(CmdProductGroupSelect)
                TableResult = New DataTable
                Adp.Fill(TableResult)
            End Using
            If TableResult.Rows.Count = 0 Then
                Clear()
            ElseIf TableResult.Rows.Count = 1 Then
                Clear()
                SetID(TableResult.Rows(0).Item("id"))
                SetCreation(TableResult.Rows(0).Item("creation"))
                SetIsSaved(True)
                Status = TableResult.Rows(0).Item("statusid")
                Name = TableResult.Rows(0).Item("name").ToString
                LockInfo = GetLockInfo(Transaction)
                If LockMe And Not LockInfo.IsLocked Then Lock(Transaction)
            Else
                Throw New Exception("Registro não encontrado.")
            End If
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
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Using CmdProductGroupDelete As New MySqlCommand(My.Resources.ProductGroupDelete, Con, Tra)
                    CmdProductGroupDelete.Parameters.AddWithValue("@id", ID)
                    CmdProductGroupDelete.ExecuteNonQuery()
                    Clear()
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductGroupInsert As New MySqlCommand(My.Resources.ProductGroupInsert, Con)
                    CmdProductGroupInsert.Transaction = Tra
                    CmdProductGroupInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdProductGroupInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProductGroupInsert.Parameters.AddWithValue("@name", Name)
                    CmdProductGroupInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdProductGroupInsert.ExecuteNonQuery()
                    SetID(CmdProductGroupInsert.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductGroupUpdate As New MySqlCommand(My.Resources.ProductGroupUpdate, Con)
                CmdProductGroupUpdate.Parameters.AddWithValue("@id", ID)
                CmdProductGroupUpdate.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdProductGroupUpdate.Parameters.AddWithValue("@name", Name)
                CmdProductGroupUpdate.Parameters.AddWithValue("@userid", User.ID)
                CmdProductGroupUpdate.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
