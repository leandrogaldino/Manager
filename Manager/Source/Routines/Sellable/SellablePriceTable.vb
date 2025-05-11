Imports ControlLibrary
Imports DocumentFormat.OpenXml.Spreadsheet
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma tabela de preços.
''' </summary>
Public Class SellablePriceTable
    Inherits ParentModel
    Private _Shadow As SellablePriceTable
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property SellablePrices As New List(Of SellablePrice)
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
        SellablePrices = New List(Of SellablePrice)
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As SellablePriceTable
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdSellablePriceTableSelect As New MySqlCommand(My.Resources.SellablePriceTableSelect, Con)
                    CmdSellablePriceTableSelect.Transaction = Tra
                    CmdSellablePriceTableSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdSellablePriceTableSelect)
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
                        SellablePrices = GetSellables(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        _Shadow = Clone()
        Return Me
    End Function


    Private Function GetSellables(Transaction As MySqlTransaction) As List(Of SellablePrice)
        Dim TableResult As DataTable
        Dim Prices As List(Of SellablePrice)
        Dim Price As SellablePrice
        Using CmdSellable As New MySqlCommand(My.Resources.SellablePriceByPriceTableSelect, Transaction.Connection)
            CmdSellable.Parameters.AddWithValue("@sellablepricetableid", ID)
            Using Adp As New MySqlDataAdapter(CmdSellable)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Prices = New List(Of SellablePrice)
                For Each Row As DataRow In TableResult.Rows
                    If (Row.Item("productid")) IsNot DBNull.Value Then
                        Price = New SellablePrice With {
                            .Product = New Product().Load(Row.Item("productid"), False),
                            .Service = Nothing,
                            .Price = Row.Item("price"),
                            .PriceTable = Me
                        }
                        Price.SetIsSaved(True)
                        Price.SetID(Row.Item("id"))
                        Price.SetCreation(Row.Item("creation"))
                        Prices.Add(Price)
                    End If
                    If (Row.Item("serviceid")) IsNot DBNull.Value Then
                        Price = New SellablePrice With {
                            .Service = New Service().Load(Row.Item("serviceid"), False),
                            .Product = Nothing,
                            .Price = Row.Item("price"),
                            .PriceTable = Me
                        }
                        Price.SetIsSaved(True)
                        Price.SetID(Row.Item("id"))
                        Price.SetCreation(Row.Item("creation"))
                        Prices.Add(Price)
                    End If
                Next Row
            End Using
        End Using
        Return Prices
    End Function

    Public Shared Sub FillSellablesDataGridView(SellablePriceTableID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.SellablePriceTableDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@sellablepricetableid", SellablePriceTableID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Using
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
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdSellablePriceTableDelete As New MySqlCommand(My.Resources.SellablePriceTableDelete, Con)
                CmdSellablePriceTableDelete.Parameters.AddWithValue("@id", ID)
                CmdSellablePriceTableDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdSellablePriceTableInsert As New MySqlCommand(My.Resources.SellablePriceTableInsert, Con)
                    CmdSellablePriceTableInsert.Transaction = Tra
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@name", Name)
                    CmdSellablePriceTableInsert.Parameters.AddWithValue("@userid", User.ID)
                    CmdSellablePriceTableInsert.ExecuteNonQuery()
                    SetID(CmdSellablePriceTableInsert.LastInsertedId)
                End Using





                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdSellablePriceTableUpdate As New MySqlCommand(My.Resources.SellablePriceTableUpdate, Con)
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@id", ID)
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@name", Name)
                CmdSellablePriceTableUpdate.Parameters.AddWithValue("@userid", User.ID)
                CmdSellablePriceTableUpdate.ExecuteNonQuery()
            End Using







        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
