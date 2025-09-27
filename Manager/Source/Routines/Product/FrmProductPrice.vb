Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmProductPrice
    Private _ProductForm As FrmProduct
    Private _Product As Product
    Private _ProductPrice As ProductPrice
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _User As User
    <DebuggerStepThrough>
    Protected Overrides Sub DefWndProc(ByRef m As Message)
        Const _MouseButtonDown As Long = &HA1
        Const _MouseButtonUp As Long = &HA0
        Const _CloseButton As Long = 20
        If CLng(m.Msg) = _MouseButtonDown And Not m.WParam = _CloseButton Then
            If Opacity <> 0.5 Then Opacity = 0.5
        ElseIf CLng(m.Msg) = _MouseButtonUp Then
            If Opacity <> 1.0 Then Opacity = 1.0
        End If
        MyBase.DefWndProc(m)
    End Sub
    Public Sub New(Product As Product, ProductPrice As ProductPrice, ProductForm As FrmProduct)
        InitializeComponent()
        _Product = Product
        _ProductPrice = ProductPrice
        _ProductForm = ProductForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _ProductForm.DgvPrice
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_ProductPrice.IsSaved, _ProductForm.DgvPrice.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _ProductPrice.Creation
        QbxPriceTable.Unfreeze()
        QbxPriceTable.Freeze(_ProductPrice.PriceTableID)
        DbxPrice.Text = _ProductPrice.Price
        If Not _ProductPrice.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        QbxPriceTable.Select()
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then
                    DgvNavigator.CancelNextMove = True
                End If
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        If _ProductForm.DgvPrice.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ProductPrice = _Product.Prices.Single(Function(x) x.Guid = _ProductForm.DgvPrice.SelectedRows(0).Cells("Guid").Value)
            LoadForm()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _Deleting AndAlso BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then e.Cancel = True
            End If
        End If
        _Deleting = False
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Insert And e.Control Then
            If BtnInclude.Enabled Then BtnInclude.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Delete And e.Control Then
            If BtnDelete.Enabled Then BtnDelete.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.PriceTableSellable, _ProductPrice.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub QbxPriceTable_TextChanged(sender As Object, e As EventArgs) Handles QbxPriceTable.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub DbxPrice_TextChanged(sender As Object, e As EventArgs) Handles DbxPrice.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxPriceTable.Text) Then
            EprValidation.SetError(LblPriceTable, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblPriceTable, ErrorIconAlignment.MiddleRight)
            QbxPriceTable.Select()
            Return False
        ElseIf Not QbxPriceTable.IsFreezed Then
            EprValidation.SetError(LblPriceTable, "Tabela de preços não encontrado.")
            EprValidation.SetIconAlignment(LblPriceTable, ErrorIconAlignment.MiddleRight)
            QbxPriceTable.Select()
            Return False
        ElseIf DbxPrice.DecimalValue < 0 Then
            EprValidation.SetError(LblPrice, "O Preço não pode ser negativo.")
            EprValidation.SetIconAlignment(LblPrice, ErrorIconAlignment.MiddleRight)
            DbxPrice.Select()
            Return False
        End If
        Return True
    End Function

    Private Function HasDuplicatedItem() As Boolean
        Dim TargetItems As List(Of ProductPrice)
        TargetItems = _Product.Prices.Where(Function(x) Not x.PriceTableID.Equals(_ProductPrice.PriceTableID) AndAlso x.PriceTableID.Equals(QbxPriceTable.FreezedPrimaryKey)).ToList()
        If TargetItems.Count > 0 Then
            CMessageBox.Show("Esse produto já foi incluido na tabela.", CMessageBoxType.Information)
            QbxPriceTable.Freeze(_ProductPrice.PriceTableID)
            DbxPrice.Text = 0
            QbxPriceTable.Select()
            Return True
        End If
        Return False
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If HasDuplicatedItem() Then Return False
            If _ProductPrice.IsSaved Then
                _Product.Prices.Single(Function(x) x.Guid = _ProductPrice.Guid).Price = DbxPrice.DecimalValue
                _Product.Prices.Single(Function(x) x.Guid = _ProductPrice.Guid).PriceTable = New Lazy(Of PriceTable)(Function() New PriceTable().Load(QbxPriceTable.FreezedPrimaryKey, False))
                _Product.Prices.Single(Function(x) x.Guid = _ProductPrice.Guid).PriceTableID = QbxPriceTable.FreezedPrimaryKey
                _Product.Prices.Single(Function(x) x.Guid = _ProductPrice.Guid).PriceTableName = PriceTable.GetPriceTableName(QbxPriceTable.FreezedPrimaryKey)
            Else
                _ProductPrice = New ProductPrice With {
                    .Price = DbxPrice.DecimalValue,
                    .PriceTable = New Lazy(Of PriceTable)(Function() New PriceTable().Load(QbxPriceTable.FreezedPrimaryKey, False)),
                    .PriceTableID = QbxPriceTable.FreezedPrimaryKey,
                    .PriceTableName = PriceTable.GetPriceTableName(QbxPriceTable.FreezedPrimaryKey)
                }
                _ProductPrice.SetIsSaved(True)
                _Product.Prices.Add(_ProductPrice)
            End If
            _ProductForm.DgvPrice.Fill(_Product.Prices)
            _ProductForm.DgvPriceLayout.Load()
            BtnSave.Enabled = False
            If Not _ProductPrice.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _ProductForm.DgvPrice.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _ProductPrice.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _ProductForm.DgvPrice.SelectedRows(0).Cells("Order").Value
            _ProductForm.EprValidation.Clear()
            _ProductForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxPriceTable_Enter(sender As Object, e As EventArgs) Handles QbxPriceTable.Enter
        TmrQueriedBox.Stop()
        BtnFilter.Visible = _User.CanAccess(Routine.PriceTable)
    End Sub
    Private Sub QbxPriceTable_Leave(sender As Object, e As EventArgs) Handles QbxPriceTable.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New PriceTableQueriedBoxFilter(), QbxPriceTable) With {.Text = "Filtro de Tabela de Preços"}
            Form.ShowDialog()
        End Using
        QbxPriceTable.Select()
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _ProductPrice = New ProductPrice()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ProductForm.DgvPrice.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ProductPrice = _Product.Prices.Single(Function(x) x.Guid = _ProductForm.DgvPrice.SelectedRows(0).Cells("Guid").Value)
                _Product.Prices.Remove(_ProductPrice)
                _ProductForm.DgvPrice.Fill(_Product.Prices)
                _ProductForm.DgvPriceLayout.Load()
                _Deleting = True
                Dispose()
                _ProductForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class