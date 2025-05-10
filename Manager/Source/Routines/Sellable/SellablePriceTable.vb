Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma tabela de preços.
''' </summary>
Public Class SellablePriceTable
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Sub New()
        SetRoutine(Routine.SellablePriceTable)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As SellablePriceTable
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductPriceTableSelect As New MySqlCommand(My.Resources.ProductPriceTableSelect, Con)
                    CmdProductPriceTableSelect.Transaction = Tra
                    CmdProductPriceTableSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdProductPriceTableSelect)
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
            Using CmdProductPriceTableDelete As New MySqlCommand(My.Resources.ProductPriceTableDelete, Con)
                CmdProductPriceTableDelete.Parameters.AddWithValue("@id", ID)
                CmdProductPriceTableDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdProductPriceTableInsert As New MySqlCommand(My.Resources.ProductPriceTableInsert, Con)
                    CmdProductPriceTableInsert.Transaction = Tra
                    CmdProductPriceTableInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdProductPriceTableInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdProductPriceTableInsert.Parameters.AddWithValue("@name", Name)
                    CmdProductPriceTableInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdProductPriceTableInsert.ExecuteNonQuery()
                    SetID(CmdProductPriceTableInsert.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdProductPriceTableUpdate As New MySqlCommand(My.Resources.ProductPriceTableUpdate, Con)
                CmdProductPriceTableUpdate.Parameters.AddWithValue("@id", ID)
                CmdProductPriceTableUpdate.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdProductPriceTableUpdate.Parameters.AddWithValue("@name", Name)
                CmdProductPriceTableUpdate.Parameters.AddWithValue("@userid", User.ID)
                CmdProductPriceTableUpdate.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
