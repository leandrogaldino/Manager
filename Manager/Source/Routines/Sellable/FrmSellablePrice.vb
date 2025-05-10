Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmSellablePrice
    Private _ProductForm As FrmProduct
    Private _Sellable As SellableModel
    Private _SellablePrice As SellablePrice
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
    Public Sub New(Product As Product, ProductPrice As SellablePrice, ProductForm As FrmProduct)
        InitializeComponent()
        _Sellable = Product
        _SellablePrice = ProductPrice
        _ProductForm = ProductForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _ProductForm.DgvPrice
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
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
            _SellablePrice = _Sellable.Prices.Single(Function(x) x.Guid = _ProductForm.DgvPrice.SelectedRows(0).Cells("Guid").Value)
            LoadForm()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not PreSave() Then e.Cancel = True
                End If
            End If
            _Deleting = False
        End If
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _SellablePrice = New SellablePrice()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ProductForm.DgvPrice.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _SellablePrice = _Sellable.Prices.Single(Function(x) x.Guid = _ProductForm.DgvPrice.SelectedRows(0).Cells("Guid").Value)
                _Sellable.Prices.Remove(_SellablePrice)
                _ProductForm.DgvPrice.Fill(_Sellable.Prices)
                _ProductForm.DgvPriceLayout.Load()
                _Deleting = True
                Dispose()
                _ProductForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.SellablePrice, _SellablePrice.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles QbxPriceTable.TextChanged,
                                                                         DbxPrice.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_SellablePrice.IsSaved, _ProductForm.DgvPrice.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _SellablePrice.Creation
        QbxPriceTable.Unfreeze()
        QbxPriceTable.Freeze(_SellablePrice.PriceTable.ID)
        DbxPrice.Text = _SellablePrice.Price
        If Not _SellablePrice.IsSaved Then
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
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxPriceTable.Text) Then
            EprValidation.SetError(LblPriceTable, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblPriceTable, ErrorIconAlignment.MiddleRight)
            QbxPriceTable.Select()
            Return False
        ElseIf Not QbxPriceTable.IsFreezed Then
            EprValidation.SetError(LblPriceTable, "Tabela de preços não encontrada.")
            EprValidation.SetIconAlignment(LblPriceTable, ErrorIconAlignment.MiddleRight)
            QbxPriceTable.Select()
            Return False
        ElseIf Not _SellablePrice.IsSaved And _Sellable.Prices.Any(Function(x) x.PriceTable.ID = QbxPriceTable.FreezedPrimaryKey) Then
            EprValidation.SetError(LblPriceTable, "Este produto já possui um preço nessa tabela de preços.")
            EprValidation.SetIconAlignment(LblPriceTable, ErrorIconAlignment.MiddleRight)
            QbxPriceTable.Select()
            Return False
        ElseIf DbxPrice.DecimalValue < 0 Then
            EprValidation.SetError(LblPrice, "O valor não pode ser menor do que zero.")
            EprValidation.SetIconAlignment(LblPrice, ErrorIconAlignment.MiddleRight)
            DbxPrice.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If _SellablePrice.IsSaved Then
                _Sellable.Prices.Single(Function(x) x.Guid = _SellablePrice.Guid).PriceTable = New SellablePriceTable().Load(QbxPriceTable.FreezedPrimaryKey, False)
                _Sellable.Prices.Single(Function(x) x.Guid = _SellablePrice.Guid).Price = DbxPrice.DecimalValue
            Else
                _SellablePrice = New SellablePrice With {
                    .PriceTable = New SellablePriceTable().Load(QbxPriceTable.FreezedPrimaryKey, False),
                    .Price = DbxPrice.DecimalValue
                }
                _SellablePrice.SetIsSaved(True)
                _Sellable.Prices.Add(_SellablePrice)
            End If
            _ProductForm.DgvPrice.Fill(_Sellable.Prices)
            _ProductForm.DgvPriceLayout.Load()
            BtnSave.Enabled = False
            If Not _SellablePrice.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _ProductForm.DgvPrice.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _SellablePrice.Guid)
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
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxPriceTable_Enter(sender As Object, e As EventArgs) Handles QbxPriceTable.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxPriceTable.IsFreezed And _User.CanWrite(Routine.SellablePriceTable)
        BtnNew.Visible = _User.CanWrite(Routine.SellablePriceTable)
        BtnFilter.Visible = _User.CanAccess(Routine.SellablePriceTable)
    End Sub
    Private Sub QbxPriceTableLeave(sender As Object, e As EventArgs) Handles QbxPriceTable.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxPriceTable_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPriceTable.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxPriceTable.IsFreezed And _User.CanWrite(Routine.SellablePriceTable)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim PriceTable As SellablePriceTable
        Dim Form As FrmSellablePriceTable
        PriceTable = New SellablePriceTable
        Form = New FrmSellablePriceTable(PriceTable)
        Form.ShowDialog()
        EprValidation.Clear()
        If PriceTable.ID > 0 Then
            QbxPriceTable.Freeze(PriceTable.ID)
        End If
        QbxPriceTable.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Form As New FrmSellablePriceTable(New SellablePriceTable().Load(QbxPriceTable.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxPriceTable.Freeze(QbxPriceTable.FreezedPrimaryKey)
        QbxPriceTable.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New ProductPriceTableQueriedBoxFilter(), QbxPriceTable)
        FilterForm.Text = "Filtro de Tabela de Preço"
        FilterForm.ShowDialog()
        QbxPriceTable.Select()
    End Sub
End Class