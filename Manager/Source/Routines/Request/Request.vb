Imports System.IO
Imports ChinhDo.Transactions
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma requisição.
''' </summary>
Public Class Request
    Inherits ParentModel
    Private _Shadow As Request
    Public Property Status As RequestStatus = RequestStatus.Pending
    Public Property Destination As String
    Public Property Responsible As String
    Public Property Items As New List(Of RequestItem)
    Public Property Note As String
    Public Property Document As New FileManager(ApplicationPaths.RequestDocumentDirectory)
    Public Sub New()
        SetRoutine(Routine.Request)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = RequestStatus.Pending
        Destination = Nothing
        Responsible = Nothing
        Items = New List(Of RequestItem)
        Note = Nothing
        Document = New FileManager(ApplicationPaths.RequestDocumentDirectory)
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Request
        Dim TableResult As DataTable
        Dim Item As RequestItem
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdRequest As New MySqlCommand(My.Resources.RequestSelect, Con)
                    CmdRequest.Transaction = Tra
                    CmdRequest.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdRequest)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        Status = TableResult.Rows(0).Item("statusid")
                        Destination = TableResult.Rows(0).Item("destination")
                        Responsible = TableResult.Rows(0).Item("responsible").ToString
                        Note = TableResult.Rows(0).Item("note").ToString
                        If TableResult.Rows(0).Item("documentname") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("documentname")) Then
                            Document.SetCurrentFile(Path.Combine(ApplicationPaths.RequestDocumentDirectory, TableResult.Rows(0).Item("documentname").ToString), True)
                        End If
                        Using CmdItem As New MySqlCommand(My.Resources.RequestItemSelect, Con)
                            CmdItem.Transaction = Tra
                            CmdItem.Parameters.AddWithValue("@requestid", ID)
                            Using Adp As New MySqlDataAdapter(CmdItem)
                                TableResult = New DataTable
                                Adp.Fill(TableResult)
                                For Each Row As DataRow In TableResult.Rows
                                    Item = New RequestItem With {
                                        .Status = Row.Item("statusid"),
                                        .ItemName = Row.Item("itemname").ToString,
                                        .Product = New Product().Load(Row.Item("productid"), False),
                                        .Taked = Row.Item("taked"),
                                        .Returned = Row.Item("returned"),
                                        .Applied = Row.Item("applied"),
                                        .Lossed = Row.Item("lossed"),
                                        .LossReason = Row.Item("lossreason")
                                    }
                                    Item.SetIsSaved(True)
                                    Item.SetID(Row.Item("id"))
                                    Item.SetCreation(Row.Item("creation"))
                                    Items.Add(Item)
                                Next Row
                            End Using
                        End Using
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                        SetIsSaved(True)
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
    Public Sub Delete()
        Dim FileManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                UpdateUser(Con)
                Items.ForEach(Sub(i) i.UpdateUser(Con))
                Using CmdRequest As New MySqlCommand(My.Resources.RequestDelete, Con)
                    CmdRequest.Parameters.AddWithValue("@id", ID)
                    CmdRequest.ExecuteNonQuery()
                    If File.Exists(Document.OriginalFile) Then FileManager.Delete(Document.OriginalFile)
                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub
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
    Private Sub Insert()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdRequest As New MySqlCommand(My.Resources.RequestInsert, Con)
                    CmdRequest.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdRequest.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdRequest.Parameters.AddWithValue("@destination", Destination)
                    CmdRequest.Parameters.AddWithValue("@responsible", Responsible)
                    CmdRequest.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdRequest.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(Document.CurrentFile), DBNull.Value, Path.GetFileName(Document.CurrentFile)))
                    CmdRequest.Parameters.AddWithValue("@userid", User.ID)
                    CmdRequest.ExecuteNonQuery()
                    SetID(CmdRequest.LastInsertedId)
                End Using
                For Each Item As RequestItem In Items
                    Using CmdItem As New MySqlCommand(My.Resources.RequestItemInsert, Con)
                        CmdItem.Parameters.AddWithValue("@requestid", ID)
                        CmdItem.Parameters.AddWithValue("@creation", Item.Creation)
                        CmdItem.Parameters.AddWithValue("@statusid", CInt(Item.Status))
                        CmdItem.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(Item.ItemName), DBNull.Value, Item.ItemName))
                        CmdItem.Parameters.AddWithValue("@productid", If(Item.Product.ID = 0, DBNull.Value, Item.Product.ID))
                        CmdItem.Parameters.AddWithValue("@taked", Item.Taked)
                        CmdItem.Parameters.AddWithValue("@returned", Item.Returned)
                        CmdItem.Parameters.AddWithValue("@applied", Item.Applied)
                        CmdItem.Parameters.AddWithValue("@lossed", Item.Lossed)
                        CmdItem.Parameters.AddWithValue("@lossreason", Item.LossReason)
                        CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                        CmdItem.ExecuteNonQuery()
                        Item.SetID(CmdItem.LastInsertedId)
                    End Using
                Next Item
            End Using
            Document.Execute()
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdRequest As New MySqlCommand(My.Resources.RequestUpdate, Con)
                    CmdRequest.Parameters.AddWithValue("@id", ID)
                    CmdRequest.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdRequest.Parameters.AddWithValue("@destination", Destination)
                    CmdRequest.Parameters.AddWithValue("@responsible", Responsible)
                    CmdRequest.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdRequest.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(Document.CurrentFile), DBNull.Value, Path.GetFileName(Document.CurrentFile)))
                    CmdRequest.Parameters.AddWithValue("@userid", User.ID)
                    CmdRequest.ExecuteNonQuery()
                End Using
                For Each Item As RequestItem In _Shadow.Items
                    If Not Items.Any(Function(x) x.ID = Item.ID And x.ID > 0) Then
                        Using CmdItem As New MySqlCommand(My.Resources.RequestItemDelete, Con)
                            CmdItem.Parameters.AddWithValue("@id", Item.ID)
                            CmdItem.ExecuteNonQuery()
                        End Using
                    End If
                Next Item
                For Each Item As RequestItem In Items
                    If Item.ID = 0 Then
                        Using CmdItem As New MySqlCommand(My.Resources.RequestItemInsert, Con)
                            CmdItem.Parameters.AddWithValue("@requestid", ID)
                            CmdItem.Parameters.AddWithValue("@creation", Item.Creation)
                            CmdItem.Parameters.AddWithValue("@statusid", CInt(Item.Status))
                            CmdItem.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(Item.ItemName), DBNull.Value, Item.ItemName))
                            CmdItem.Parameters.AddWithValue("@productid", If(Item.Product.ID = 0, DBNull.Value, Item.Product.ID))
                            CmdItem.Parameters.AddWithValue("@taked", Item.Taked)
                            CmdItem.Parameters.AddWithValue("@returned", Item.Returned)
                            CmdItem.Parameters.AddWithValue("@applied", Item.Applied)
                            CmdItem.Parameters.AddWithValue("@lossed", Item.Lossed)
                            CmdItem.Parameters.AddWithValue("@lossreason", Item.LossReason)
                            CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdItem.ExecuteNonQuery()
                            Item.SetID(CmdItem.LastInsertedId)
                        End Using
                    Else
                        Using CmdItem As New MySqlCommand(My.Resources.RequestItemUpdate, Con)
                            CmdItem.Parameters.AddWithValue("@id", Item.ID)
                            CmdItem.Parameters.AddWithValue("@statusid", CInt(Item.Status))
                            CmdItem.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(Item.ItemName), DBNull.Value, Item.ItemName))
                            CmdItem.Parameters.AddWithValue("@productid", If(Item.Product.ID = 0, DBNull.Value, Item.Product.ID))
                            CmdItem.Parameters.AddWithValue("@taked", Item.Taked)
                            CmdItem.Parameters.AddWithValue("@returned", Item.Returned)
                            CmdItem.Parameters.AddWithValue("@applied", Item.Applied)
                            CmdItem.Parameters.AddWithValue("@lossed", Item.Lossed)
                            CmdItem.Parameters.AddWithValue("@lossreason", Item.LossReason)
                            CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdItem.ExecuteNonQuery()
                        End Using
                    End If
                Next Item
            End Using
            Document.Execute()
            Transaction.Complete()
        End Using
    End Sub
    Public Shared Sub FillDataGridView(RequestID As Long, Dgv As DataGridView)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.RequestDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@requestid", RequestID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).Width = 110
                    Dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).Width = 110
                    Dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).Width = 110
                    Dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End Using
            End Using
        End Using
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New Request With {
            .Destination = Destination,
            .Note = Note,
            .Status = Status,
            .Responsible = Responsible,
            .Document = Document.Clone(),
            .Items = Items.Select(Function(x) CType(x.Clone(), RequestItem)).ToList()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function

End Class
