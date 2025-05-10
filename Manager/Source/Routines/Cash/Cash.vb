Imports System.IO
Imports ChinhDo.Transactions
Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ManagerCore
''' <summary>
''' Representa um fechamento de caixa.
''' </summary>
Public Class Cash
    Inherits ParentModel
    Private _Shadow As Cash
    Public Property Status As CashStatus = CashStatus.Opened
    Public Property CashFlow As New CashFlow
    Public Property Note As String
    Public Property Document As New FileManager(ApplicationPaths.CashDocumentDirectory)
    Public Property CashItems As New List(Of CashItem)
    Public Sub New()
        SetRoutine(Routine.Cash)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = CashStatus.Opened
        CashFlow = New CashFlow
        Note = Nothing
        Document = New FileManager(ApplicationPaths.CashDocumentDirectory())
        CashItems = New List(Of CashItem)
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Cash
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCash As New MySqlCommand(My.Resources.CashSelect, Con)
                    CmdCash.Transaction = Tra
                    CmdCash.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdCash)
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
                        CashFlow = New CashFlow().Load(TableResult.Rows(0).Item("cashflowid"), False)
                        Note = TableResult.Rows(0).Item("note").ToString
                        If TableResult.Rows(0).Item("documentname") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("documentname")) Then
                            Document.SetCurrentFile(Path.Combine(ApplicationPaths.CashDocumentDirectory, TableResult.Rows(0).Item("documentname").ToString), True)
                        End If
                        CashItems = GetCashItems(Tra)
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
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        CashItems.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        CashItems.ToList().ForEach(Sub(x) x.Responsibles.ToList().ForEach(Sub(y) y.SetIsSaved(True)))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Dim FileManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdRequest As New MySqlCommand(My.Resources.CashDelete, Con)
                    CmdRequest.Parameters.AddWithValue("@id", ID)
                    CmdRequest.ExecuteNonQuery()
                    If File.Exists(Document.OriginalFile) Then FileManager.Delete(Document.OriginalFile)
                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdCash As New MySqlCommand(My.Resources.CashInsert, Con)
                    CmdCash.Parameters.AddWithValue("@cashflowid", CashFlow.ID)
                    CmdCash.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdCash.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdCash.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdCash.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(Document.CurrentFile), DBNull.Value, Path.GetFileName(Document.CurrentFile)))
                    CmdCash.Parameters.AddWithValue("@userid", User.ID)
                    CmdCash.ExecuteNonQuery()
                    SetID(CmdCash.LastInsertedId)
                End Using
                For Each CashItem As CashItem In CashItems
                    Using CmdCashItem As New MySqlCommand(My.Resources.CashItemInsert, Con)
                        CmdCashItem.Parameters.AddWithValue("@cashid", ID)
                        CmdCashItem.Parameters.AddWithValue("@creation", CashItem.Creation)
                        CmdCashItem.Parameters.AddWithValue("@itemtypeid", CInt(CashItem.ItemType))
                        CmdCashItem.Parameters.AddWithValue("@itemcategoryid", CInt(CashItem.ItemCategory))
                        CmdCashItem.Parameters.AddWithValue("@description", CashItem.Description)
                        CmdCashItem.Parameters.AddWithValue("@documentdate", CashItem.DocumentDate)
                        CmdCashItem.Parameters.AddWithValue("@documentnumber", If(String.IsNullOrEmpty(CashItem.DocumentNumber), DBNull.Value, CashItem.DocumentNumber))
                        CmdCashItem.Parameters.AddWithValue("@value", CashItem.Value)
                        CmdCashItem.Parameters.AddWithValue("@userid", CashItem.User.ID)
                        CmdCashItem.ExecuteNonQuery()
                        CashItem.SetID(CmdCashItem.LastInsertedId)
                        For Each Responsible As CashItemResponsible In CashItem.Responsibles
                            Using CmdCashItemResponsible As New MySqlCommand(My.Resources.CashItemResponsibleInsert, Con)
                                CmdCashItemResponsible.Parameters.AddWithValue("@cashitemid", CashItem.ID)
                                CmdCashItemResponsible.Parameters.AddWithValue("@creation", Responsible.Creation)
                                CmdCashItemResponsible.Parameters.AddWithValue("@responsibleid", Responsible.Responsible.ID)
                                CmdCashItemResponsible.Parameters.AddWithValue("@userid", Responsible.User.ID)
                                CmdCashItemResponsible.ExecuteNonQuery()
                                Responsible.SetID(CmdCashItemResponsible.LastInsertedId)
                            End Using
                        Next Responsible
                    End Using
                Next CashItem
            End Using
            Document.Execute()
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim CashItem As CashItem
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdCash As New MySqlCommand(My.Resources.CashUpdate, Con)
                    CmdCash.Parameters.AddWithValue("@id", ID)
                    CmdCash.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdCash.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(Document.CurrentFile), DBNull.Value, Path.GetFileName(Document.CurrentFile)))
                    CmdCash.Parameters.AddWithValue("@userid", User.ID)
                    CmdCash.ExecuteNonQuery()
                End Using
                For Each ShadowCashItem As CashItem In _Shadow.CashItems
                    If Not CashItems.Any(Function(x) x.ID = ShadowCashItem.ID And x.ID > 0) Then
                        Using CmdCashItem As New MySqlCommand(My.Resources.CashItemDelete, Con)
                            CmdCashItem.Parameters.AddWithValue("@id", ShadowCashItem.ID)
                            CmdCashItem.ExecuteNonQuery()
                        End Using
                    End If
                    For Each ShadowCashItemResponsible As CashItemResponsible In ShadowCashItem.Responsibles
                        CashItem = CashItems.SingleOrDefault(Function(x) x.ID = ShadowCashItem.ID)
                        If CashItem IsNot Nothing AndAlso (Not CashItem.Responsibles.Any(Function(x) x.ID = ShadowCashItemResponsible.ID And x.ID > 0)) Then
                            Using CmdCashItemResponsible As New MySqlCommand(My.Resources.CashItemResponsibleDelete, Con)
                                CmdCashItemResponsible.Parameters.AddWithValue("@id", ShadowCashItemResponsible.ID)
                                CmdCashItemResponsible.ExecuteNonQuery()
                            End Using
                        End If
                    Next ShadowCashItemResponsible
                Next ShadowCashItem
                For Each Item As CashItem In CashItems
                    If Item.ID = 0 Then
                        Using CmdCashItem As New MySqlCommand(My.Resources.CashItemInsert, Con)
                            CmdCashItem.Parameters.AddWithValue("@cashid", ID)
                            CmdCashItem.Parameters.AddWithValue("@creation", Item.Creation)
                            CmdCashItem.Parameters.AddWithValue("@itemtypeid", CInt(Item.ItemType))
                            CmdCashItem.Parameters.AddWithValue("@itemcategoryid", CInt(Item.ItemCategory))
                            CmdCashItem.Parameters.AddWithValue("@description", Item.Description)
                            CmdCashItem.Parameters.AddWithValue("@documentdate", Item.DocumentDate)
                            CmdCashItem.Parameters.AddWithValue("@documentnumber", If(String.IsNullOrEmpty(Item.DocumentNumber), DBNull.Value, Item.DocumentNumber))
                            CmdCashItem.Parameters.AddWithValue("@value", Item.Value)
                            CmdCashItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdCashItem.ExecuteNonQuery()
                            Item.SetID(CmdCashItem.LastInsertedId)
                            For Each Responsible As CashItemResponsible In Item.Responsibles
                                Using CmdCashItemResponsible As New MySqlCommand(My.Resources.CashItemResponsibleInsert, Con)
                                    CmdCashItemResponsible.Parameters.AddWithValue("@cashitemid", Item.ID)
                                    CmdCashItemResponsible.Parameters.AddWithValue("@creation", Responsible.Creation)
                                    CmdCashItemResponsible.Parameters.AddWithValue("@responsibleid", Responsible.Responsible.ID)
                                    CmdCashItemResponsible.Parameters.AddWithValue("@userid", Responsible.User.ID)
                                    CmdCashItemResponsible.ExecuteNonQuery()
                                    Responsible.SetID(CmdCashItemResponsible.LastInsertedId)
                                End Using
                            Next Responsible
                        End Using
                    Else
                        Using CmdCashItem As New MySqlCommand(My.Resources.CashItemUpdate, Con)
                            CmdCashItem.Parameters.AddWithValue("@id", Item.ID)
                            CmdCashItem.Parameters.AddWithValue("@itemtypeid", CInt(Item.ItemType))
                            CmdCashItem.Parameters.AddWithValue("@itemcategoryid", CInt(Item.ItemCategory))
                            CmdCashItem.Parameters.AddWithValue("@description", Item.Description)
                            CmdCashItem.Parameters.AddWithValue("@documentdate", Item.DocumentDate)
                            CmdCashItem.Parameters.AddWithValue("@documentnumber", If(String.IsNullOrEmpty(Item.DocumentNumber), DBNull.Value, Item.DocumentNumber))
                            CmdCashItem.Parameters.AddWithValue("@value", Item.Value)
                            CmdCashItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdCashItem.ExecuteNonQuery()
                            For Each Responsible As CashItemResponsible In Item.Responsibles
                                If Responsible.ID = 0 Then
                                    Using CmdCashItemResponsible As New MySqlCommand(My.Resources.CashItemResponsibleInsert, Con)
                                        CmdCashItemResponsible.Parameters.AddWithValue("@cashitemid", Item.ID)
                                        CmdCashItemResponsible.Parameters.AddWithValue("@creation", Responsible.Creation)
                                        CmdCashItemResponsible.Parameters.AddWithValue("@responsibleid", Responsible.Responsible.ID)
                                        CmdCashItemResponsible.Parameters.AddWithValue("@userid", Responsible.User.ID)
                                        CmdCashItemResponsible.ExecuteNonQuery()
                                        Responsible.SetID(CmdCashItemResponsible.LastInsertedId)
                                    End Using
                                Else
                                    Using CmdCashItemResponsible As New MySqlCommand(My.Resources.CashItemResponsibleUpdate, Con)
                                        CmdCashItemResponsible.Parameters.AddWithValue("@id", Responsible.ID)
                                        CmdCashItemResponsible.Parameters.AddWithValue("@responsibleid", Responsible.Responsible.ID)
                                        CmdCashItemResponsible.Parameters.AddWithValue("@userid", Responsible.User.ID)
                                        CmdCashItemResponsible.ExecuteNonQuery()
                                    End Using
                                End If
                            Next Responsible
                        End Using
                    End If
                Next Item
            End Using
            Document.Execute()
            Transaction.Complete()
        End Using
    End Sub
    Public Function GetCashItems(Transaction As MySqlTransaction) As List(Of CashItem)
        Dim TableResult As DataTable
        Dim CashItems As List(Of CashItem)
        Dim CashItem As CashItem
        Using CmdCashItem As New MySqlCommand(My.Resources.CashItemSelect, Transaction.Connection)
            CmdCashItem.Transaction = Transaction
            CmdCashItem.Parameters.AddWithValue("@cashid", ID)
            Using Adp As New MySqlDataAdapter(CmdCashItem)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                CashItems = New List(Of CashItem)
                For Each Row As DataRow In TableResult.Rows
                    CashItem = New CashItem With {
                        .ItemType = Row.Item("itemtypeid"),
                        .ItemCategory = Row.Item("itemcategoryid"),
                        .Description = Row.Item("description").ToString,
                        .DocumentNumber = Row.Item("documentnumber").ToString,
                        .DocumentDate = Row.Item("documentdate"),
                        .Value = Row.Item("value")
                    }
                    CashItem.SetID(Row.Item("id"))
                    CashItem.SetCreation(Row.Item("creation"))
                    CashItem.SetIsSaved(True)
                    CashItem.Responsibles = GetResponsibles(Transaction, CashItem.ID)
                    CashItems.Add(CashItem)
                Next Row
            End Using
        End Using
        Return CashItems
    End Function
    Public Shared Function GetResponsibles(Transaction As MySqlTransaction, CashItemID As Long) As List(Of CashItemResponsible)
        Dim TableResult As DataTable
        Dim Responsibles As List(Of CashItemResponsible)
        Dim Responsible As CashItemResponsible
        Using CmdResponsibles As New MySqlCommand(My.Resources.CashItemResponsibleSelect, Transaction.Connection)
            CmdResponsibles.Transaction = Transaction
            CmdResponsibles.Parameters.AddWithValue("@cashitemid", CashItemID)
            Using Adp As New MySqlDataAdapter(CmdResponsibles)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Responsibles = New List(Of CashItemResponsible)
                For Each Row As DataRow In TableResult.Rows
                    Responsible = New CashItemResponsible With {
                        .Responsible = New Person().Load(Row.Item("responsibleid"), False)
                    }
                    Responsible.SetID(Row.Item("id"))
                    Responsible.SetCreation(Row.Item("creation"))
                    Responsible.SetIsSaved(True)
                    Responsibles.Add(Responsible)
                Next Row
            End Using
        End Using
        Return Responsibles
    End Function
    Public Function GetPreviousBalance() As Decimal
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPreviousBalance As New MySqlCommand(My.Resources.CashPreviousBalanceSelect, Con)
                CmdPreviousBalance.Parameters.AddWithValue("@id", ID)
                CmdPreviousBalance.Parameters.AddWithValue("@cashflowid", CashFlow.ID)
                Return CmdPreviousBalance.ExecuteScalar()
            End Using
        End Using
    End Function
    Public Function GetLastBalance() As Decimal
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdLastBalance As New MySqlCommand(My.Resources.CashLastBalanceSelect, Con)
                CmdLastBalance.Parameters.AddWithValue("@cashflowid", CashFlow.ID)
                Return CmdLastBalance.ExecuteScalar()
            End Using
        End Using
    End Function
    Public Shared Sub FillDataGridView(CashID As Long, Dgv As DataGridView)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.CashDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@cashid", CashID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).Width = 110
                    Dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).Width = 150
                    Dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).Width = 110
                    Dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(3).Width = 110
                    Dgv.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End Using
            End Using
        End Using
    End Sub
    Public Sub SetStatus(Status As CashStatus)
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.CashSetStatus, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                Cmd.ExecuteNonQuery()
                _Status = Status
            End Using
        End Using
    End Sub
    Public Shared Function CountCash(StatusFilter As List(Of CashStatus), Optional CashFlow As Long = 0, Optional IgnoreCash As Long = 0) As Long
        Dim Session = Locator.GetInstance(Of Session)
        Dim StatusIntList As New List(Of Integer)
        StatusFilter.ForEach(Sub(x) StatusIntList.Add(CInt(x)))
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.CashCount, Con)
                Cmd.Parameters.AddWithValue("@cashid", IgnoreCash)
                Cmd.Parameters.AddWithValue("@cashflowid", CashFlow)
                Cmd.Parameters.AddWithValue("@statusid", String.Join(",", StatusIntList))
                Con.Open()
                Return Cmd.ExecuteScalar()
            End Using
        End Using
    End Function
End Class
