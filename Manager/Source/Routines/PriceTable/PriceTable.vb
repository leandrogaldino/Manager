Imports ControlLibrary
Imports MySql.Data.MySqlClient

Public Class PriceTable
    Inherits ParentModel
    Private _Shadow As PriceTable
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Items As New List(Of PriceTableItem)
    Public Sub New()
        SetRoutine(Routine.PriceTable)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        Items = New List(Of PriceTableItem)
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As PriceTable
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdPriceTable As New MySqlCommand(My.Resources.PriceTableSelect, Con)
                    CmdPriceTable.Transaction = Tra
                    CmdPriceTable.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdPriceTable)
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
                        Items = GetItems(Tra)
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
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Items.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdService As New MySqlCommand(My.Resources.PriceTableDelete, Con)
                    CmdService.Parameters.AddWithValue("@id", ID)
                    CmdService.ExecuteNonQuery()
                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub
    Private Sub Insert()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdService As New MySqlCommand(My.Resources.PriceTableInsert, Con)
                    CmdService.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdService.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdService.Parameters.AddWithValue("@name", Name)
                    CmdService.Parameters.AddWithValue("@userid", User.ID)
                    CmdService.ExecuteNonQuery()
                    SetID(CmdService.LastInsertedId)
                End Using
                For Each Item As PriceTableItem In Items
                    Using CmdItem As New MySqlCommand(My.Resources.PriceTableItemInsert, Con)
                        CmdItem.Parameters.AddWithValue("@pricetableid", ID)
                        CmdItem.Parameters.AddWithValue("@creation", Item.Creation)
                        CmdItem.Parameters.AddWithValue("@productid", If(Item.SellableType = SellableType.Product, Item.SellableID, DBNull.Value))
                        CmdItem.Parameters.AddWithValue("@serviceid", If(Item.SellableType = SellableType.Service, Item.SellableID, DBNull.Value))
                        CmdItem.Parameters.AddWithValue("@price", Item.Price)
                        CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                        CmdItem.ExecuteNonQuery()
                        Item.SetID(CmdItem.LastInsertedId)
                    End Using
                Next Item
            End Using
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdService As New MySqlCommand(My.Resources.PriceTableUpdate, Con)
                    CmdService.Parameters.AddWithValue("@id", ID)
                    CmdService.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdService.Parameters.AddWithValue("@name", Name)
                    CmdService.Parameters.AddWithValue("@userid", User.ID)
                    CmdService.ExecuteNonQuery()
                End Using
                For Each Item As PriceTableItem In _Shadow.Items
                    If Not Items.Any(Function(x) x.ID = Item.ID And x.ID > 0) Then
                        Using CmdItem As New MySqlCommand(My.Resources.PriceTableItemDelete, Con)
                            CmdItem.Parameters.AddWithValue("@id", Item.ID)
                            CmdItem.ExecuteNonQuery()
                        End Using
                    End If
                Next Item
                For Each Item As PriceTableItem In Items
                    If Item.ID = 0 Then
                        Using CmdItem As New MySqlCommand(My.Resources.PriceTableItemInsert, Con)
                            CmdItem.Parameters.AddWithValue("@pricetableid", ID)
                            CmdItem.Parameters.AddWithValue("@creation", Item.Creation)
                            CmdItem.Parameters.AddWithValue("@productid", If(Item.SellableType = SellableType.Product, Item.SellableID, DBNull.Value))
                            CmdItem.Parameters.AddWithValue("@serviceid", If(Item.SellableType = SellableType.Service, Item.SellableID, DBNull.Value))
                            CmdItem.Parameters.AddWithValue("@price", Item.Price)
                            CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdItem.ExecuteNonQuery()
                            Item.SetID(CmdItem.LastInsertedId)
                        End Using
                    Else
                        Using CmdItem As New MySqlCommand(My.Resources.PriceTableItemUpdate, Con)
                            CmdItem.Parameters.AddWithValue("@id", Item.ID)
                            CmdItem.Parameters.AddWithValue("@productid", If(Item.SellableType = SellableType.Product, Item.SellableID, DBNull.Value))
                            CmdItem.Parameters.AddWithValue("@serviceid", If(Item.SellableType = SellableType.Service, Item.SellableID, DBNull.Value))
                            CmdItem.Parameters.AddWithValue("@price", Item.Price)
                            CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdItem.ExecuteNonQuery()
                        End Using
                    End If
                Next Item
            End Using
            Transaction.Complete()
        End Using
    End Sub

    Private Function GetItems(Transaction As MySqlTransaction) As List(Of PriceTableItem)
        Dim TableResult As DataTable
        Dim Items As List(Of PriceTableItem)
        Dim Item As PriceTableItem
        Using CmdComplement As New MySqlCommand(My.Resources.PriceTableItemSelect, Transaction.Connection)
            CmdComplement.Transaction = Transaction
            CmdComplement.Parameters.AddWithValue("@serviceid", ID)
            Using Adp As New MySqlDataAdapter(CmdComplement)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Items = New List(Of PriceTableItem)
                For Each Row As DataRow In TableResult.Rows
                    Item = New PriceTableItem With {
                        .Code = Row.Item("code"),
                        .Name = Row.Item("name"),
                        .SellableID = Row.Item("sellableid"),
                        .Price = Row.Item("price"),
                        .Sellable = New Lazy(Of SellableModel)(Function()
                                                                   If Row.Item("productid") Is DBNull.Value Then
                                                                       Return New Product().Load(Row.Item("productid").ToString, False)
                                                                   Else
                                                                       Return New Service().Load(Row.Item("serviceid").ToString, False)
                                                                   End If
                                                               End Function)
                    }
                    Item.SetIsSaved(True)
                    Item.SetID(Row.Item("id"))
                    Item.SetCreation(Row.Item("creation"))
                    Items.Add(Item)
                Next Row
            End Using
        End Using
        Return Items
    End Function

    Public Shared Sub FillItemsDataGridView(PriceTableID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.PriceTableItemDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@pricetableid", PriceTableID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End Using
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
