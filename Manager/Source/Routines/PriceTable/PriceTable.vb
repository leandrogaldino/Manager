Imports ControlLibrary
Imports MySql.Data.MySqlClient
Public Class PriceTable
    Inherits ParentModel
    Private _Shadow As PriceTable
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Sellables As New List(Of PriceTableSellable)
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
        Sellables = New List(Of PriceTableSellable)
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
                        Sellables = GetSellables(Tra)
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
        Sellables.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Sellables.ForEach(Sub(s) s.UpdateUser(Con, Tra))
                Using CmdService As New MySqlCommand(My.Resources.PriceTableDelete, Con, Tra)
                    CmdService.Parameters.AddWithValue("@id", ID)
                    CmdService.ExecuteNonQuery()
                End Using
                Tra.Commit()
            End Using
        End Using
        Clear()
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdService As New MySqlCommand(My.Resources.PriceTableInsert, Con, Tra)
                    CmdService.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdService.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdService.Parameters.AddWithValue("@name", Name)
                    CmdService.Parameters.AddWithValue("@userid", User.ID)
                    CmdService.ExecuteNonQuery()
                    SetID(CmdService.LastInsertedId)
                End Using
                For Each Sellable As PriceTableSellable In Sellables
                    Using CmdSellable As New MySqlCommand(My.Resources.PriceTableItemInsert, Con, Tra)
                        CmdSellable.Parameters.AddWithValue("@pricetableid", ID)
                        CmdSellable.Parameters.AddWithValue("@creation", Sellable.Creation)
                        CmdSellable.Parameters.AddWithValue("@productid", If(Sellable.SellableType = SellableType.Product, Sellable.SellableID, DBNull.Value))
                        CmdSellable.Parameters.AddWithValue("@serviceid", If(Sellable.SellableType = SellableType.Service, Sellable.SellableID, DBNull.Value))
                        CmdSellable.Parameters.AddWithValue("@price", Sellable.Price)
                        CmdSellable.Parameters.AddWithValue("@userid", Sellable.User.ID)
                        CmdSellable.ExecuteNonQuery()
                        Sellable.SetID(CmdSellable.LastInsertedId)
                    End Using
                Next Sellable
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdService As New MySqlCommand(My.Resources.PriceTableUpdate, Con, Tra)
                    CmdService.Parameters.AddWithValue("@id", ID)
                    CmdService.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdService.Parameters.AddWithValue("@name", Name)
                    CmdService.Parameters.AddWithValue("@userid", User.ID)
                    CmdService.ExecuteNonQuery()
                End Using
                For Each Sellable As PriceTableSellable In _Shadow.Sellables
                    If Not Sellables.Any(Function(x) x.ID = Sellable.ID And x.ID > 0) Then
                        Using CmdSellable As New MySqlCommand(My.Resources.PriceTableItemDelete, Con, Tra)
                            CmdSellable.Parameters.AddWithValue("@id", Sellable.ID)
                            CmdSellable.ExecuteNonQuery()
                        End Using
                    End If
                Next Sellable
                For Each Sellable As PriceTableSellable In Sellables.Where(Function(x) x.Sellable.IsValueCreated)
                    If Sellable.ID = 0 Then
                        Using CmdSellable As New MySqlCommand(My.Resources.PriceTableItemInsert, Con, Tra)
                            CmdSellable.Parameters.AddWithValue("@pricetableid", ID)
                            CmdSellable.Parameters.AddWithValue("@creation", Sellable.Creation)
                            CmdSellable.Parameters.AddWithValue("@productid", If(Sellable.SellableType = SellableType.Product, Sellable.SellableID, DBNull.Value))
                            CmdSellable.Parameters.AddWithValue("@serviceid", If(Sellable.SellableType = SellableType.Service, Sellable.SellableID, DBNull.Value))
                            CmdSellable.Parameters.AddWithValue("@price", Sellable.Price)
                            CmdSellable.Parameters.AddWithValue("@userid", Sellable.User.ID)
                            CmdSellable.ExecuteNonQuery()
                            Sellable.SetID(CmdSellable.LastInsertedId)
                        End Using
                    Else
                        Using CmdSellable As New MySqlCommand(My.Resources.PriceTableItemUpdate, Con, Tra)
                            CmdSellable.Parameters.AddWithValue("@id", Sellable.ID)
                            CmdSellable.Parameters.AddWithValue("@productid", If(Sellable.SellableType = SellableType.Product, Sellable.SellableID, DBNull.Value))
                            CmdSellable.Parameters.AddWithValue("@serviceid", If(Sellable.SellableType = SellableType.Service, Sellable.SellableID, DBNull.Value))
                            CmdSellable.Parameters.AddWithValue("@price", Sellable.Price)
                            CmdSellable.Parameters.AddWithValue("@userid", Sellable.User.ID)
                            CmdSellable.ExecuteNonQuery()
                        End Using
                    End If
                Next Sellable
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetSellables(Transaction As MySqlTransaction) As List(Of PriceTableSellable)
        Dim TableResult As DataTable
        Dim Sellables As List(Of PriceTableSellable)
        Dim Sellable As PriceTableSellable
        Using CmdSellable As New MySqlCommand(My.Resources.PriceTableItemSelect, Transaction.Connection, Transaction)
            CmdSellable.Parameters.AddWithValue("@pricetableid", ID)
            Using Adp As New MySqlDataAdapter(CmdSellable)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Sellables = New List(Of PriceTableSellable)
                For Each Row As DataRow In TableResult.Rows
                    Sellable = New PriceTableSellable With {
                        .SellableID = If(Row.Item("productid") IsNot DBNull.Value, Row.Item("productid"), Row.Item("serviceid")),
                        .Code = Row.Item("code"),
                        .Name = Row.Item("name"),
                        .Price = Row.Item("price"),
                        .Sellable = New Lazy(Of Sellable)(Function()
                                                              If Row.Item("productid") IsNot DBNull.Value Then
                                                                  Return New Product().Load(Row.Item("productid"), False)
                                                              Else
                                                                  Return New Service().Load(Row.Item("serviceid"), False)
                                                              End If
                                                          End Function)
                    }
                    Sellable.SetIsSaved(True)
                    Sellable.SetID(Row.Item("id"))
                    Sellable.SetCreation(Row.Item("creation"))
                    Sellables.Add(Sellable)
                Next Row
            End Using
        End Using
        Return Sellables
    End Function
    Public Shared Sub FillISellablesDataGridView(PriceTableID As Long, Dgv As DataGridView)
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
    Public Shared Function GetPriceTableName(PriceTableID As Long) As String
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.PriceTableGetPriceTableName, Con)
                Cmd.Parameters.AddWithValue("@pricetableid", PriceTableID)
                Return Cmd.ExecuteScalar()
            End Using
        End Using
    End Function
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New PriceTable With {
            .Name = Name,
            .Status = Status,
            .Sellables = Sellables.Select(Function(x) CType(x.Clone(), PriceTableSellable)).ToList()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function

End Class
