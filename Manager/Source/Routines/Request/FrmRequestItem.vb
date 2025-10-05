Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmRequestItem
    Private _RequestForm As FrmRequest
    Private _Request As Request
    Private _RequestItem As RequestItem
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
    Public Sub New(Request As Request, RequestItem As RequestItem, RequestForm As FrmRequest)
        InitializeComponent()
        _Request = Request
        _RequestItem = RequestItem
        _RequestForm = RequestForm
        _User = Locator.GetInstance(Of Session).User
        Height = 235
        LoadForm()
        DgvNavigator.DataGridView = _RequestForm.DgvItem
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_RequestItem.IsSaved, _RequestForm.DgvItem.SelectedRows(0).Cells("Order").Value, 0)
        LblStatusValue.Text = EnumHelper.GetEnumDescription(_RequestItem.Status)
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
        If Not _RequestItem.IsSaved Then
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
            _RequestItem = _Request.Items.Single(Function(x) x.Guid = _RequestForm.DgvItem.SelectedRows(0).Cells("Guid").Value)
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
        Using Form As New FrmLog(Routine.RequestItem, _RequestItem.ID)
            Form.ShowDialog()
        End Using
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
        If Not QbxItem.IsFreezed Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = QbxItem.Text.Trim.ToUnaccented()
            QbxItem.QueryEnabled = True
        End If
        TxtLostReason.Text = TxtLostReason.Text.ToUnaccented()
        If IsValidFields() Then
            If _RequestItem.IsSaved Then
                If (QbxItem.IsFreezed AndAlso _RequestItem.Product.ID <> QbxItem.FreezedPrimaryKey) OrElse (Not QbxItem.IsFreezed And _RequestItem.ItemName <> QbxItem.Text) Then
                    If HasDuplicatedItem() Then Return False
                End If
                _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).Status = EnumHelper.GetEnumValue(Of RequestStatus)(LblStatusValue.Text)
                If QbxItem.IsFreezed Then
                    _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).ItemName = String.Empty
                    _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                Else
                    _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).ItemName = QbxItem.Text
                    _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).Product = New Product
                End If
                _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).Taked = DbxTaked.Text
                _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).Returned = DbxReturned.Text
                _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).Applied = DbxApplied.Text
                _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).Lossed = DbxLossed.Text
                _Request.Items.Single(Function(x) x.Guid = _RequestItem.Guid).LossReason = TxtLostReason.Text
            Else
                _RequestItem = New RequestItem()
                _RequestItem.Status = EnumHelper.GetEnumValue(Of RequestStatus)(LblStatusValue.Text)
                If QbxItem.IsFreezed Then
                    _RequestItem.ItemName = String.Empty
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
                If HasDuplicatedItem() Then Return False
                _RequestItem.SetIsSaved(True)
                _Request.Items.Add(_RequestItem)
            End If
            _RequestForm.DgvItem.Fill(_Request.Items)
            _RequestForm.DgvItemLayout.Load()
            BtnSave.Enabled = False
            If Not _RequestItem.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _RequestForm.DgvItem.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _RequestItem.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _RequestForm.DgvItem.SelectedRows(0).Cells("Order").Value
            _RequestForm.EprValidation.Clear()
            _RequestForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Function HasDuplicatedItem() As Boolean
        Dim TargetItems As List(Of RequestItem)
        TargetItems = _Request.Items.Where(Function(x)
                                               If QbxItem.IsFreezed Then
                                                   Return x.Product.ID.Equals(QbxItem.FreezedPrimaryKey)
                                               Else
                                                   Return x.ItemName.Equals(QbxItem.Text)
                                               End If
                                               Return False
                                           End Function).ToList
        If TargetItems IsNot Nothing AndAlso TargetItems.Count > 0 Then
            If CMessageBox.Show("Esse item já foi incluido na requisição, deseja incluir novamente?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.No Then
                Return True
            End If
        End If
        Return False
    End Function
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxItem_Enter(sender As Object, e As EventArgs) Handles QbxItem.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxItem.IsFreezed And _User.CanWrite(Routine.Product)
        BtnNew.Visible = _User.CanWrite(Routine.Product)
        BtnFilter.Visible = _User.CanAccess(Routine.Product)
    End Sub
    Private Sub QbxItem_Leave(sender As Object, e As EventArgs) Handles QbxItem.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxItem_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxItem.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxItem.IsFreezed And _User.CanWrite(Routine.Product)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Product As Product
        Product = New Product
        Using Form As New FrmProduct(Product)
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Product.ID > 0 Then
            QbxItem.Freeze(Product.ID)
        End If
        QbxItem.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Using Form As New FrmProduct(New Product().Load(QbxItem.FreezedPrimaryKey, True))
            Form.ShowDialog()
        End Using
        QbxItem.Freeze(QbxItem.FreezedPrimaryKey)
        QbxItem.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New ProductQueriedBoxFilter(), QbxItem) With {.Text = "Filtro de Produtos"}
            Form.ShowDialog()
        End Using
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
                _RequestItem = _Request.Items.Single(Function(x) x.Guid = _RequestForm.DgvItem.SelectedRows(0).Cells("Guid").Value)
                _Request.Items.Remove(_RequestItem)
                _RequestForm.DgvItem.Fill(_Request.Items)
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
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Concluded)
        ElseIf DbxPending.DecimalValue < DbxTaked.DecimalValue Then
            DbxPending.BackColor = Color.Wheat
            DbxPending.ForeColor = Color.Chocolate
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Partial)
        Else
            DbxPending.BackColor = Color.LightCoral
            DbxPending.ForeColor = Color.DarkRed
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Pending)
        End If
        EprValidation.Clear()
    End Sub
    Private Sub LblStatusValue_TextChanged(sender As Object, e As EventArgs) Handles LblStatusValue.TextChanged
        If LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Pending) Then
            LblStatusValue.ForeColor = Color.DarkRed
        ElseIf LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Partial) Then
            LblStatusValue.ForeColor = Color.Chocolate
        Else
            LblStatusValue.ForeColor = Color.DarkGreen
        End If
    End Sub
End Class