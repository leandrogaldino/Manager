Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmPersonCompressorPartElapsedDay
    Private _PersonCompressorForm As FrmPersonCompressor
    Private _PersonCompressor As PersonCompressor
    Private _PartElapsedDay As PersonCompressorPart
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
    Public Sub New(PersonCompressor As PersonCompressor, PartElapsedDay As PersonCompressorPart, PersonCompressorForm As FrmPersonCompressor)
        InitializeComponent()
        _PersonCompressor = PersonCompressor
        _PartElapsedDay = PartElapsedDay
        _PersonCompressorForm = PersonCompressorForm
        CbxPartBind.Items.AddRange(Utility.GetEnumDescriptions(Of CompressorPartBindType).Where(Function(x) x = "COALESCENTE" Or x = "NENHUM").ToArray)
        LoadForm()
        DgvNavigator.DataGridView = _PersonCompressorForm.DgvPartElapsedDay
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.CanAccessLog)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _PartElapsedDay.Order
        BtnStatusValue.Text = GetEnumDescription(_PartElapsedDay.Status)
        LblCreationValue.Text = _PartElapsedDay.Creation
        CbxPartBind.Text = GetEnumDescription(_PartElapsedDay.PartBind)
        QbxItem.Unfreeze()
        If _PartElapsedDay.ItemName = Nothing And _PartElapsedDay.Product.Value.ID > 0 Then
            QbxItem.Freeze(_PartElapsedDay.Product.Value.ID)
        ElseIf _PartElapsedDay.ItemName <> Nothing And _PartElapsedDay.Product.value.ID >= 0 Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = _PartElapsedDay.ItemName
            QbxItem.QueryEnabled = True
        End If
        DbxQuantity.Text = _PartElapsedDay.Quantity
        DbxCapacity.Text = _PartElapsedDay.Capacity
        If _PartElapsedDay.Order = 0 Then
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
        If _PersonCompressorForm.DgvPartElapsedDay.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _PartElapsedDay = _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PersonCompressorForm.DgvPartElapsedDay.SelectedRows(0).Cells("Order").Value)
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
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.PersonCompressorPartElapsedDay, _PartElapsedDay.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive)
            If _PartElapsedDay.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
            If _PartElapsedDay.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub CbxPartBind_TextChanged(sender As Object, e As EventArgs) Handles CbxPartBind.SelectedIndexChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles DbxQuantity.TextChanged, DbxCapacity.TextChanged, QbxItem.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub

    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(QbxItem.Text) Then
            EprValidation.SetError(LblItem, "Campo Obrigatório.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf QbxItem.IsFreezed AndAlso _PersonCompressor.PartsElapsedDay.SingleOrDefault(Function(x) x.Product.Value.ID = QbxItem.FreezedPrimaryKey) IsNot Nothing AndAlso
            Not _PartElapsedDay.Equals(_PersonCompressor.PartsElapsedDay.SingleOrDefault(Function(x) x.Product.Value.ID = QbxItem.FreezedPrimaryKey)) Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf QbxItem.IsFreezed AndAlso _PersonCompressor.PartsWorkedHour.SingleOrDefault(Function(x) x.Product.Value.ID = QbxItem.FreezedPrimaryKey) IsNot Nothing Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf Not QbxItem.IsFreezed AndAlso _PersonCompressor.PartsElapsedDay.SingleOrDefault(Function(x) x.ItemName = QbxItem.Text) IsNot Nothing AndAlso
            Not _PartElapsedDay.Equals(_PersonCompressor.PartsElapsedDay.SingleOrDefault(Function(x) x.Product.Value.ID = QbxItem.FreezedPrimaryKey)) Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf Not QbxItem.IsFreezed AndAlso _PersonCompressor.PartsWorkedHour.SingleOrDefault(Function(x) x.ItemName = QbxItem.Text) IsNot Nothing Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf DbxQuantity.DecimalValue <= 0 Then
            EprValidation.SetError(LblQuantity, "A quantidade deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblQuantity, ErrorIconAlignment.MiddleRight)
            DbxQuantity.Select()
            Return False
        ElseIf DbxCapacity.DecimalValue <= 0 Then
            EprValidation.SetError(LblCapacity, "A capacidade deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblCapacity, ErrorIconAlignment.MiddleRight)
            DbxQuantity.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If Not QbxItem.IsFreezed Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = RemoveAccents(QbxItem.Text.Trim)
            QbxItem.QueryEnabled = True
        End If
        If IsValidFields() Then
            If _PartElapsedDay.IsSaved Then
                _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).PartBind = GetEnumValue(Of CompressorPartBindType)(CbxPartBind.Text)
                If QbxItem.IsFreezed Then
                    _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).ItemName = Nothing
                    _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).Product = New Lazy(Of Product)(Function() New Product().Load(QbxItem.FreezedPrimaryKey, False))
                Else
                    _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).ItemName = QbxItem.Text
                    _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).Product = New Lazy(Of Product)()
                End If
                _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).Quantity = DbxQuantity.Text
                _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PartElapsedDay.Order).Capacity = DbxCapacity.Text
            Else
                _PartElapsedDay = New PersonCompressorPart(CompressorPartType.ElapsedDay)
                _PartElapsedDay.Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _PartElapsedDay.PartBind = GetEnumValue(Of CompressorPartBindType)(CbxPartBind.Text)
                If QbxItem.IsFreezed Then
                    _PartElapsedDay.ItemName = Nothing
                    _PartElapsedDay.Product = New Lazy(Of Product)(Function() New Product().Load(QbxItem.FreezedPrimaryKey, False))
                Else
                    _PartElapsedDay.ItemName = QbxItem.Text
                    _PartElapsedDay.Product = New Lazy(Of Product)()
                End If
                _PartElapsedDay.Quantity = DbxQuantity.Text
                _PartElapsedDay.Capacity = DbxCapacity.Text
                _PartElapsedDay.IsSaved = True
                _PersonCompressor.PartsElapsedDay.Add(_PartElapsedDay)
            End If
            _PersonCompressor.PartsElapsedDay.FillDataGridView(_PersonCompressorForm.DgvPartElapsedDay)
            LblOrderValue.Text = _PartElapsedDay.Order
            _PersonCompressorForm.DgvPartElapsedDayLayout.Load()
            BtnSave.Enabled = False
            If _PartElapsedDay.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _PersonCompressorForm.DgvPartElapsedDay.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _PartElapsedDay.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _PersonCompressorForm.EprValidation.Clear()
            _PersonCompressorForm.BtnSave.Enabled = True
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
        _PartElapsedDay = New PersonCompressorPart(CompressorPartType.ElapsedDay)
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PersonCompressorForm.DgvPartElapsedDay.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _PartElapsedDay = _PersonCompressor.PartsElapsedDay.Single(Function(x) x.Order = _PersonCompressorForm.DgvPartElapsedDay.SelectedRows(0).Cells("Order").Value)
                _PersonCompressor.PartsElapsedDay.Remove(_PartElapsedDay)
                _PersonCompressor.PartsElapsedDay.FillDataGridView(_PersonCompressorForm.DgvPartElapsedDay)
                _PersonCompressorForm.DgvPartElapsedDayLayout.Load()
                _Deleting = True
                Dispose()
                _PersonCompressorForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class