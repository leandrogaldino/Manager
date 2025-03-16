Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma unidade de medida de um produto.
''' </summary>
Public Class ProductUnit
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property ShortName As String
    Public Sub New()
        SetRoutine(Routine.ProductUnit)
    End Sub
    Public Sub Clear()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        ShortName = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As ProductUnit
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductUnitSelect As New MySqlCommand(My.Resources.ProductUnitSelect, Con)
                    CmdProductUnitSelect.Transaction = Tra
                    CmdProductUnitSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdProductUnitSelect)
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
                        ShortName = TableResult.Rows(0).Item("shortname").ToString
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
    Public Function Load(Identity As Long, Transaction As MySqlTransaction, LockMe As Boolean) As ProductUnit
        Dim TableResult As DataTable
        Using CmdProductUnitSelect As New MySqlCommand(My.Resources.ProductUnitSelect, Transaction.Connection)
            CmdProductUnitSelect.Transaction = Transaction
            CmdProductUnitSelect.Parameters.AddWithValue("@id", Identity)
            Using Adp As New MySqlDataAdapter(CmdProductUnitSelect)
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
                ShortName = TableResult.Rows(0).Item("shortname").ToString
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
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductUnitDelete As New MySqlCommand(My.Resources.ProductUnitDelete, Con)
                CmdProductUnitDelete.Parameters.AddWithValue("@id", ID)
                CmdProductUnitDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductUnitInsert As New MySqlCommand(My.Resources.ProductUnitInsert, Con)
                    CmdProductUnitInsert.Transaction = Tra
                    CmdProductUnitInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdProductUnitInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProductUnitInsert.Parameters.AddWithValue("@name", Name)
                    CmdProductUnitInsert.Parameters.AddWithValue("@shortname", ShortName)
                    CmdProductUnitInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdProductUnitInsert.ExecuteNonQuery()
                    SetID(CmdProductUnitInsert.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductUnitUpdate As New MySqlCommand(My.Resources.ProductUnitUpdate, Con)
                CmdProductUnitUpdate.Parameters.AddWithValue("@id", ID)
                CmdProductUnitUpdate.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdProductUnitUpdate.Parameters.AddWithValue("@name", Name)
                CmdProductUnitUpdate.Parameters.AddWithValue("@shortname", ShortName)
                CmdProductUnitUpdate.Parameters.AddWithValue("@userid", User.ID)
                CmdProductUnitUpdate.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return ShortName
    End Function
End Class
