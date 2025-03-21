﻿Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmCompressorPartElapsedDay
    Private _CompressorForm As FrmCompressor
    Private _Compressor As Compressor
    Private _PartElapsedDay As CompressorPart
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
    Public Sub New(Compressor As Compressor, PartElapsedDay As CompressorPart, CompressorForm As FrmCompressor)
        InitializeComponent()
        _Compressor = Compressor
        _PartElapsedDay = PartElapsedDay
        _CompressorForm = CompressorForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _CompressorForm.DgvCompressorPartElapsedDay
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
        If _CompressorForm.DgvCompressorPartElapsedDay.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _PartElapsedDay = _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _CompressorForm.DgvCompressorPartElapsedDay.SelectedRows(0).Cells("Guid").Value)
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
        Dim Frm As New FrmLog(Routine.CompressorPartElapsedDay, _PartElapsedDay.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _PartElapsedDay.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _PartElapsedDay.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles QbxItem.TextChanged,
                                                                         DbxQuantity.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_PartElapsedDay.IsSaved, _CompressorForm.DgvCompressorPartElapsedDay.SelectedRows(0).Cells("Order").Value, 0)
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_PartElapsedDay.Status)
        LblCreationValue.Text = _PartElapsedDay.Creation
        QbxItem.Unfreeze()
        If _PartElapsedDay.ItemName = Nothing And _PartElapsedDay.Product.ID > 0 Then
            QbxItem.Freeze(_PartElapsedDay.Product.ID)
        ElseIf _PartElapsedDay.ItemName <> Nothing And _PartElapsedDay.Product.ID >= 0 Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = _PartElapsedDay.ItemName
            QbxItem.QueryEnabled = True
        End If
        DbxQuantity.Text = _PartElapsedDay.Quantity
        If Not _PartElapsedDay.IsSaved Then
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
    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(QbxItem.Text) Then
            EprValidation.SetError(LblItem, "Campo Obrigatório.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf QbxItem.IsFreezed AndAlso _Compressor.PartsElapsedDay.Value.SingleOrDefault(Function(x) x.Product.ID = QbxItem.FreezedPrimaryKey) IsNot Nothing AndAlso
            Not _PartElapsedDay.Equals(_Compressor.PartsElapsedDay.Value.SingleOrDefault(Function(x) x.Product.ID = QbxItem.FreezedPrimaryKey)) Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf QbxItem.IsFreezed AndAlso _Compressor.PartsWorkedHour.Value.SingleOrDefault(Function(x) x.Product.ID = QbxItem.FreezedPrimaryKey) IsNot Nothing Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf Not QbxItem.IsFreezed AndAlso _Compressor.PartsElapsedDay.Value.SingleOrDefault(Function(x) x.ItemName = QbxItem.Text) IsNot Nothing AndAlso
            Not _PartElapsedDay.Equals(_Compressor.PartsElapsedDay.Value.SingleOrDefault(Function(x) x.Product.ID = QbxItem.FreezedPrimaryKey)) Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf Not QbxItem.IsFreezed AndAlso _Compressor.PartsWorkedHour.Value.SingleOrDefault(Function(x) x.ItemName = QbxItem.Text) IsNot Nothing Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf DbxQuantity.DecimalValue <= 0 Then
            EprValidation.SetError(LblQuantity, "A quantidade deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblQuantity, ErrorIconAlignment.MiddleRight)
            DbxQuantity.Select()
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
        If IsValidFields() Then
            If _PartElapsedDay.IsSaved Then
                _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _PartElapsedDay.Guid).Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                If QbxItem.IsFreezed Then
                    _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _PartElapsedDay.Guid).ItemName = Nothing
                    _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _PartElapsedDay.Guid).Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                Else
                    _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _PartElapsedDay.Guid).ItemName = QbxItem.Text
                    _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _PartElapsedDay.Guid).Product = New Product
                End If
                _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _PartElapsedDay.Guid).Quantity = DbxQuantity.Text
            Else
                _PartElapsedDay = New CompressorPart(CompressorPartType.ElapsedDay)
                _PartElapsedDay.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                If QbxItem.IsFreezed Then
                    _PartElapsedDay.ItemName = Nothing
                    _PartElapsedDay.Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                Else
                    _PartElapsedDay.ItemName = QbxItem.Text
                    _PartElapsedDay.Product = New Product
                End If
                _PartElapsedDay.Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                _PartElapsedDay.Quantity = DbxQuantity.Text
                _PartElapsedDay.SetIsSaved(True)
                _Compressor.PartsElapsedDay.Value.Add(_PartElapsedDay)
            End If
            _CompressorForm.DgvCompressorPartElapsedDay.Fill(_Compressor.PartsElapsedDay.Value)
            _CompressorForm.DgvCompressorPartElapsedDayLayout.Load()
            BtnSave.Enabled = False
            If Not _PartElapsedDay.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _CompressorForm.DgvCompressorPartElapsedDay.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _PartElapsedDay.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _CompressorForm.DgvCompressorPartElapsedDay.SelectedRows(0).Cells("Order").Value
            _CompressorForm.EprValidation.Clear()
            _CompressorForm.BtnSave.Enabled = True
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
        _PartElapsedDay = New CompressorPart(CompressorPartType.ElapsedDay)
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CompressorForm.DgvCompressorPartElapsedDay.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _PartElapsedDay = _Compressor.PartsElapsedDay.Value.Single(Function(x) x.Guid = _CompressorForm.DgvCompressorPartElapsedDay.SelectedRows(0).Cells("Guid").Value)
                _Compressor.PartsElapsedDay.Value.Remove(_PartElapsedDay)
                _CompressorForm.DgvCompressorPartElapsedDay.Fill(_Compressor.PartsElapsedDay.Value)
                _CompressorForm.DgvCompressorPartElapsedDayLayout.Load()
                _Deleting = True
                Dispose()
                _CompressorForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class