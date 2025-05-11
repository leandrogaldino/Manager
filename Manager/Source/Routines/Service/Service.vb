Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um serviço.
''' </summary>
Public Class Service
    Inherits SellableModel
    Private _Shadow As Service
    Public Property Complements As New List(Of ServiceComplement)
    Public Property ServiceCode As String

    Public Sub New()
        SetRoutine(Routine.Product)
        Prices = New Lazy(Of List(Of SellablePrice))(Function() GetPrices())
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Name = Nothing
        Complements = New List(Of ServiceComplement)
        ServiceCode = Nothing
        Prices = New Lazy(Of List(Of SellablePrice))(Function() GetPrices())
        Note = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Service
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdService As New MySqlCommand(My.Resources.ServiceSelect, Con)
                    CmdService.Transaction = Tra
                    CmdService.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdService)
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
                        Complements = GetComplements(Tra)
                        ServiceCode = TableResult.Rows(0).Item("servicecode").ToString
                        Note = TableResult.Rows(0).Item("note").ToString
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
        Complements.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        Prices.Value.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdService As New MySqlCommand(My.Resources.ServiceDelete, Con)
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
                Using CmdService As New MySqlCommand(My.Resources.ServiceInsert, Con)
                    CmdService.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdService.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdService.Parameters.AddWithValue("@name", Name)
                    CmdService.Parameters.AddWithValue("@servicecode", ServiceCode)
                    CmdService.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdService.Parameters.AddWithValue("@userid", User.ID)
                    CmdService.ExecuteNonQuery()
                    SetID(CmdService.LastInsertedId)
                End Using
                For Each Complement As ServiceComplement In Complements
                    Using CmdComplement As New MySqlCommand(My.Resources.ServiceComplementInsert, Con)
                        CmdComplement.Parameters.AddWithValue("@serviceid", ID)
                        CmdComplement.Parameters.AddWithValue("@creation", Complement.Creation)
                        CmdComplement.Parameters.AddWithValue("@complement", Complement.Complement)
                        CmdComplement.Parameters.AddWithValue("@userid", Complement.User.ID)
                        CmdComplement.ExecuteNonQuery()
                        Complement.SetID(CmdComplement.LastInsertedId)
                    End Using
                Next Complement
                For Each Price As SellablePrice In Prices.Value
                    Using CmdSellablePrice As New MySqlCommand(My.Resources.SellablePriceInsert, Con)
                        CmdSellablePrice.Parameters.AddWithValue("@productid", DBNull.Value)
                        CmdSellablePrice.Parameters.AddWithValue("@serviceid", ID)
                        CmdSellablePrice.Parameters.AddWithValue("@creation", Price.Creation)
                        CmdSellablePrice.Parameters.AddWithValue("@sellablepricetableid", Price.PriceTable.ID)
                        CmdSellablePrice.Parameters.AddWithValue("@price", Price.Price)
                        CmdSellablePrice.Parameters.AddWithValue("@userid", Price.User.ID)
                        CmdSellablePrice.ExecuteNonQuery()
                        Price.SetID(CmdSellablePrice.LastInsertedId)
                    End Using
                Next Price
            End Using
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdService As New MySqlCommand(My.Resources.ServiceUpdate, Con)
                    CmdService.Parameters.AddWithValue("@id", ID)
                    CmdService.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdService.Parameters.AddWithValue("@name", Name)
                    CmdService.Parameters.AddWithValue("@servicecode", ServiceCode)
                    CmdService.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdService.Parameters.AddWithValue("@userid", User.ID)
                    CmdService.ExecuteNonQuery()
                End Using
                For Each Complement As ServiceComplement In _Shadow.Complements
                    If Not Complements.Any(Function(x) x.ID = Complement.ID And x.ID > 0) Then
                        Using CmdComplement As New MySqlCommand(My.Resources.ServiceComplementDelete, Con)
                            CmdComplement.Parameters.AddWithValue("@id", Complement.ID)
                            CmdComplement.ExecuteNonQuery()
                        End Using
                    End If
                Next Complement
                For Each Complement As ServiceComplement In Complements
                    If Complement.ID = 0 Then
                        Using CmdComplement As New MySqlCommand(My.Resources.ServiceComplementInsert, Con)
                            CmdComplement.Parameters.AddWithValue("@serviceid", ID)
                            CmdComplement.Parameters.AddWithValue("@creation", Complement.Creation)
                            CmdComplement.Parameters.AddWithValue("@complement", Complement.Complement)
                            CmdComplement.Parameters.AddWithValue("@userid", Complement.User.ID)
                            CmdComplement.ExecuteNonQuery()
                            Complement.SetID(CmdComplement.LastInsertedId)
                        End Using
                    Else
                        Using CmdServiceComplement As New MySqlCommand(My.Resources.ServiceComplementUpdate, Con)
                            CmdServiceComplement.Parameters.AddWithValue("@id", Complement.ID)
                            CmdServiceComplement.Parameters.AddWithValue("@complement", Complement.Complement)
                            CmdServiceComplement.Parameters.AddWithValue("@userid", Complement.User.ID)
                            CmdServiceComplement.ExecuteNonQuery()
                        End Using
                    End If
                Next Complement
                For Each Price As SellablePrice In _Shadow.Prices.Value
                    If Not Prices.Value.Any(Function(x) x.ID = Price.ID And x.ID > 0) Then
                        Using CmdPrice As New MySqlCommand(My.Resources.SellablePriceDelete, Con)
                            CmdPrice.Parameters.AddWithValue("@id", Price.ID)
                            CmdPrice.ExecuteNonQuery()
                        End Using
                    End If
                Next Price
                For Each Price As SellablePrice In Prices.Value
                    If Price.ID = 0 Then
                        Using CmdPrice As New MySqlCommand(My.Resources.SellablePriceInsert, Con)
                            CmdPrice.Parameters.AddWithValue("@productid", DBNull.Value)
                            CmdPrice.Parameters.AddWithValue("@serviceid", ID)
                            CmdPrice.Parameters.AddWithValue("@creation", Price.Creation)
                            CmdPrice.Parameters.AddWithValue("@sellablepricetableid", Price.PriceTable.ID)
                            CmdPrice.Parameters.AddWithValue("@price", Price.Price)
                            CmdPrice.Parameters.AddWithValue("@userid", Price.User.ID)
                            CmdPrice.ExecuteNonQuery()
                            Price.SetID(CmdPrice.LastInsertedId)
                        End Using
                    Else
                        Using CmdPrice As New MySqlCommand(My.Resources.SellablePriceUpdate, Con)
                            CmdPrice.Parameters.AddWithValue("@id", Price.ID)
                            CmdPrice.Parameters.AddWithValue("@sellablepricetableid", Price.PriceTable.ID)
                            CmdPrice.Parameters.AddWithValue("@price", Price.Price)
                            CmdPrice.Parameters.AddWithValue("@userid", Price.User.ID)
                            CmdPrice.ExecuteNonQuery()
                        End Using
                    End If
                Next Price
            End Using
            Transaction.Complete()
        End Using
    End Sub

    Private Function GetComplements(Transaction As MySqlTransaction) As List(Of ServiceComplement)
        Dim TableResult As DataTable
        Dim Complements As List(Of ServiceComplement)
        Dim Complement As ServiceComplement
        Using CmdComplement As New MySqlCommand(My.Resources.ServiceComplementSelect, Transaction.Connection)
            CmdComplement.Transaction = Transaction
            CmdComplement.Parameters.AddWithValue("@serviceid", ID)
            Using Adp As New MySqlDataAdapter(CmdComplement)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Complements = New List(Of ServiceComplement)
                For Each Row As DataRow In TableResult.Rows
                    Complement = New ServiceComplement
                    Complement.Complement = Row.Item("complement").ToString
                    Complement.SetIsSaved(True)
                    Complement.SetID(Row.Item("id"))
                    Complement.SetCreation(Row.Item("creation"))
                    Complements.Add(Complement)
                Next Row
            End Using
        End Using
        Return Complements
    End Function
    Private Function GetPrices() As List(Of SellablePrice)
        Dim TableResult As DataTable
        Dim ProductPrices As List(Of SellablePrice)
        Dim ProductPrice As SellablePrice
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPrice As New MySqlCommand(My.Resources.SellablePriceSelect, Con)
                CmdPrice.Parameters.AddWithValue("@serviceid", ID)
                CmdPrice.Parameters.AddWithValue("@productid", DBNull.Value)
                Using Adp As New MySqlDataAdapter(CmdPrice)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                    ProductPrices = New List(Of SellablePrice)
                    For Each Row As DataRow In TableResult.Rows
                        ProductPrice = New SellablePrice With {
                            .PriceTable = New SellablePriceTable().Load(Row.Item("sellablepricetableid"), False),
                            .Price = Row.Item("price")
                        }
                        ProductPrice.SetIsSaved(True)
                        ProductPrice.SetID(Row.Item("id"))
                        ProductPrice.SetCreation(Row.Item("creation"))
                        ProductPrices.Add(ProductPrice)
                    Next Row
                End Using
            End Using
        End Using
        Return ProductPrices
    End Function
    Public Shared Sub FillComplementDataGridView(ServiceID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.ServiceComplementDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@serviceid", ServiceID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End Using
            End Using
        End Using
    End Sub

    Public Shared Sub FillPriceDataGridView(ServiceID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.SellablePriceDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@productid", DBNull.Value)
                Cmd.Parameters.AddWithValue("@serviceid", ServiceID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Using
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class