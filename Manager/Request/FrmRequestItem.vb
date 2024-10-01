Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmRequestItem
    Private _RequestForm As FrmRequest
    Private _Request As Request
    Private _RequestItem As RequestItem
    Private _Deleting As Boolean
    Private _Loading As Boolean
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
    Public Sub New(Request As Request, RequestItem As RequestItem, RequestForm As FrmRequest)
        InitializeComponent()
        _Request = Request
        _RequestItem = RequestItem
        _RequestForm = RequestForm
        Height = 235
        LoadForm()
        DgvNavigator.DataGridView = _RequestForm.DgvItem
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralLogAccess
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _RequestItem.Order
        LblStatusValue.Text = GetEnumDescription(_RequestItem.Status)
        LblCreationValue.Text = _RequestItem.Creation
        QbxItem.Unfreeze()
        If _RequestItem.ItemName = Nothing And _RequestItem.Product.ID > 0 Then
            QbxItem.Freeze(_RequestItem.Product.ID)
        ElseIf _RequestItem.ItemName <> Nothing And _RequestItem.Product.ID >= 0 Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = _RequestItem.ItemName
            QbxItem.QueryEnabled = True
        End If
        DbxTaked.Text = _RequestItem.Taked
        DbxReturned.Text = _RequestItem.Returned
        DbxApplied.Text = _RequestItem.Applied
        DbxPending.Text = _RequestItem.Pending
        DbxLossed.Text = _RequestItem.Lossed
        TxtLostReason.Text = _RequestItem.LossReason
        If _RequestItem.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        QbxItem.Select()
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
        If _RequestForm.DgvItem.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _RequestItem = _Request.Items.Single(Function(x) x.Order = _RequestForm.DgvItem.SelectedRows(0).Cells("Order").Value)
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
        Dim Frm As New FrmLog(Routine.RequestItem, _RequestItem.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub QbxItem_TextChanged(sender As Object, e As EventArgs) Handles QbxItem.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Dbx_TextChanged(sender As Object, e As EventArgs) Handles DbxTaked.TextChanged,
                                                                          DbxReturned.TextChanged,
                                                                          DbxApplied.TextChanged,
                                                                          DbxLossed.TextChanged
        DbxPending.Text = DbxTaked.DecimalValue - DbxReturned.DecimalValue - DbxApplied.DecimalValue - DbxLossed.DecimalValue
        Height = If(DbxLossed.DecimalValue > 0, 310, 235)
        TxtLostReason.Text = If(DbxLossed.DecimalValue > 0, TxtLostReason.Text, Nothing)

        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxItem.Text) Then
            EprValidation.SetError(LblItem, "Campo obrigatório")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf DbxTaked.DecimalValue <= 0 Then
            EprValidation.SetError(LblTaked, "A quantidade retirada deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblTaked, ErrorIconAlignment.MiddleRight)
            DbxTaked.Select()
            Return False
        ElseIf DbxTaked.DecimalValue < (DbxReturned.DecimalValue + DbxApplied.DecimalValue + DbxLossed.DecimalValue) Then
            EprValidation.SetError(LblTaked, "A quantidade retirada não pode ser menor que a soma das outras quantidades.")
            EprValidation.SetIconAlignment(LblTaked, ErrorIconAlignment.MiddleRight)
            DbxTaked.Select()
            Return False
        ElseIf DbxReturned.DecimalValue < 0 Then
            EprValidation.SetError(LblReturned, "A quantidade devolvida não pode ser negativa.")
            EprValidation.SetIconAlignment(LblReturned, ErrorIconAlignment.MiddleRight)
            DbxReturned.Select()
            Return False
        ElseIf DbxReturned.DecimalValue > DbxTaked.DecimalValue Then
            EprValidation.SetError(LblReturned, "A quantidade devolvida não pode ser maior que a quantidade retirada.")
            EprValidation.SetIconAlignment(LblReturned, ErrorIconAlignment.MiddleRight)
            DbxReturned.Select()
            Return False
        ElseIf DbxApplied.DecimalValue < 0 Then
            EprValidation.SetError(LblApplied, "A quantidade aplicada não pode ser nagativa")
            EprValidation.SetIconAlignment(LblApplied, ErrorIconAlignment.MiddleRight)
            DbxApplied.Select()
            Return False
        ElseIf DbxApplied.DecimalValue > DbxTaked.DecimalValue Then
            EprValidation.SetError(LblApplied, "A quantidade aplicada não pode ser maior que a quantidade retirada.")
            EprValidation.SetIconAlignment(LblApplied, ErrorIconAlignment.MiddleRight)
            DbxApplied.Select()
            Return False
        ElseIf DbxLossed.DecimalValue < 0 Then
            EprValidation.SetError(LblLossed, "A quantidade perdida não pode ser nagativa")
            EprValidation.SetIconAlignment(LblLossed, ErrorIconAlignment.MiddleRight)
            DbxLossed.Select()
            Return False
        ElseIf DbxLossed.DecimalValue > DbxTaked.DecimalValue Then
            EprValidation.SetError(LblLossed, "A quantidade perdida não pode ser maior que a quantidade retirada.")
            EprValidation.SetIconAlignment(LblLossed, ErrorIconAlignment.MiddleRight)
            DbxLossed.Select()
            Return False
        ElseIf DbxLossed.DecimalValue > 0 And String.IsNullOrEmpty(TxtLostReason.Text) Then
            EprValidation.SetError(LblLossReason, "Informe o motivo da quantidade perdida.")
            EprValidation.SetIconAlignment(LblLossReason, ErrorIconAlignment.MiddleRight)
            TxtLostReason.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        Dim TargetItems As List(Of RequestItem)
        Dim Msg As String
        If Not QbxItem.IsFreezed Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = RemoveAccents(QbxItem.Text.Trim)
            QbxItem.QueryEnabled = True
        End If
        TxtLostReason.Text = RemoveAccents(TxtLostReason.Text)
        If IsValidFields() Then
            If _RequestItem.IsSaved Then
                _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).Status = GetEnumValue(Of RequestStatus)(LblStatusValue.Text)
                If QbxItem.IsFreezed Then
                    _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).ItemName = Nothing
                    _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                Else
                    _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).ItemName = QbxItem.Text
                    _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).Product = New Product
                End If
                _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).Taked = DbxTaked.Text
                _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).Returned = DbxReturned.Text
                _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).Applied = DbxApplied.Text
                _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).Lossed = DbxLossed.Text
                _Request.Items.Single(Function(x) x.Order = _RequestItem.Order).LossReason = TxtLostReason.Text
            Else
                _RequestItem = New RequestItem()
                _RequestItem.Status = GetEnumValue(Of RequestStatus)(LblStatusValue.Text)
                If QbxItem.IsFreezed Then
                    _RequestItem.ItemName = Nothing
                    _RequestItem.Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                Else
                    _RequestItem.ItemName = QbxItem.Text
                    _RequestItem.Product = New Product
                End If
                _RequestItem.Taked = DbxTaked.Text
                _RequestItem.Returned = DbxReturned.Text
                _RequestItem.Applied = DbxApplied.Text
                _RequestItem.Lossed = DbxLossed.Text
                _RequestItem.LossReason = TxtLostReason.Text
                TargetItems = _Request.Items.Where(Function(x) x.Equals(_RequestItem)).ToList
                If TargetItems IsNot Nothing AndAlso TargetItems.Count > 0 Then
                    If TargetItems.Count = 1 Then
                        Msg = $"Esse item já está na posição {TargetItems(0).Order} dessa requisição, deseja incluir novamente?"
                    Else
                        Msg = $"Esse item já está nas posições {String.Join(", ", TargetItems.Select(Function(x) x.Order))} dessa requisição, deseja incluir novamente?"
                    End If
                    If CMessageBox.Show(Msg, CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.No Then
                        Return False
                    End If
                End If
                _RequestItem.IsSaved = True
                _Request.Items.Add(_RequestItem)
            End If
            _Request.Items.FillDataGridView(_RequestForm.DgvItem)
            LblOrderValue.Text = _RequestItem.Order
            _RequestForm.DgvItemLayout.Load()
            BtnSave.Enabled = False
            If _RequestItem.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _RequestForm.DgvItem.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _RequestItem.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _RequestForm.EprValidation.Clear()
            _RequestForm.BtnSave.Enabled = True
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
    Private Sub QbxItem_Enter(sender As Object, e As EventArgs) Handles QbxItem.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxItem.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.ProductWrite
        BtnNew.Visible = Locator.GetInstance(Of Session).User.Privilege.ProductWrite
        BtnFilter.Visible = Locator.GetInstance(Of Session).User.Privilege.ProductAccess
    End Sub
    Private Sub QbxItem_Leave(sender As Object, e As EventArgs) Handles QbxItem.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxItem_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxItem.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxItem.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.ProductWrite
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Product As Product
        Dim Form As FrmProduct
        Product = New Product
        Form = New FrmProduct(Product)
        Form.ShowDialog()
        EprValidation.Clear()
        If Product.ID > 0 Then
            QbxItem.Freeze(Product.ID)
        End If
        QbxItem.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Form As New FrmProduct(New Product().Load(QbxItem.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxItem.Freeze(QbxItem.FreezedPrimaryKey)
        QbxItem.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New ProductQueriedBoxFilter(), QbxItem)
        FilterForm.Text = "Filtro de Produtos"
        FilterForm.ShowDialog()
        QbxItem.Select()
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _RequestItem = New RequestItem()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _RequestForm.DgvItem.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _RequestItem = _Request.Items.Single(Function(x) x.Order = _RequestForm.DgvItem.SelectedRows(0).Cells("Order").Value)
                _Request.Items.Remove(_RequestItem)
                _Request.Items.FillDataGridView(_RequestForm.DgvItem)
                _RequestForm.DgvItemLayout.Load()
                _Deleting = True
                Dispose()
                _RequestForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DbxPending_TextChanged(sender As Object, e As EventArgs) Handles DbxPending.TextChanged
        If DbxPending.DecimalValue = 0 Then
            DbxPending.BackColor = Color.LightGreen
            DbxPending.ForeColor = Color.DarkGreen
            LblStatusValue.Text = GetEnumDescription(RequestStatus.Concluded)
        ElseIf DbxPending.DecimalValue < DbxTaked.DecimalValue Then
            DbxPending.BackColor = Color.Wheat
            DbxPending.ForeColor = Color.Chocolate
            LblStatusValue.Text = GetEnumDescription(RequestStatus.Partial)
        Else
            DbxPending.BackColor = Color.LightCoral
            DbxPending.ForeColor = Color.DarkRed
            LblStatusValue.Text = GetEnumDescription(RequestStatus.Pending)
        End If
        EprValidation.Clear()
    End Sub
    Private Sub LblStatusValue_TextChanged(sender As Object, e As EventArgs) Handles LblStatusValue.TextChanged
        If LblStatusValue.Text = GetEnumDescription(RequestStatus.Pending) Then
            LblStatusValue.ForeColor = Color.DarkRed
        ElseIf LblStatusValue.Text = GetEnumDescription(RequestStatus.Partial) Then
            LblStatusValue.ForeColor = Color.Chocolate
        Else
            LblStatusValue.ForeColor = Color.DarkGreen
        End If
    End Sub
End Class