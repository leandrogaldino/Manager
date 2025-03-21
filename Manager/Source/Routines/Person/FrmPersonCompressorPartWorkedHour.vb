﻿Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmPersonCompressorPartWorkedHour
    Private _PersonCompressorForm As FrmPersonCompressor
    Private _PersonCompressor As PersonCompressor
    Private _PartWorkedHour As PersonCompressorPart
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
    Public Sub New(PersonCompressor As PersonCompressor, PersonCompressorPart As PersonCompressorPart, PersonCompressorForm As FrmPersonCompressor)
        InitializeComponent()
        _PersonCompressor = PersonCompressor
        _PartWorkedHour = PersonCompressorPart
        _PersonCompressorForm = PersonCompressorForm
        _User = Locator.GetInstance(Of Session).User
        CbxPartBind.Items.AddRange(EnumHelper.GetEnumDescriptions(Of CompressorPartBindType).Where(Function(x) x <> "COALESCENTE").ToArray)
        LoadForm()
        DgvNavigator.DataGridView = _PersonCompressorForm.DgvPartWorkedHour
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_PartWorkedHour.IsSaved, _PersonCompressorForm.DgvPartWorkedHour.SelectedRows(0).Cells("Order").Value, 0)
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_PartWorkedHour.Status)
        LblCreationValue.Text = _PartWorkedHour.Creation
        CbxPartBind.Text = EnumHelper.GetEnumDescription(_PartWorkedHour.PartBind)
        QbxItem.Unfreeze()
        If _PartWorkedHour.ItemName = Nothing And _PartWorkedHour.Product.Value.ID > 0 Then
            QbxItem.Freeze(_PartWorkedHour.Product.Value.ID)
        ElseIf _PartWorkedHour.ItemName <> Nothing And _PartWorkedHour.Product.Value.ID >= 0 Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = _PartWorkedHour.ItemName
            QbxItem.QueryEnabled = True
        End If
        DbxQuantity.Text = _PartWorkedHour.Quantity
        DbxCapacity.Text = _PartWorkedHour.Capacity
        If Not _PartWorkedHour.IsSaved Then
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
        If _PersonCompressorForm.DgvPartWorkedHour.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _PartWorkedHour = _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PersonCompressorForm.DgvPartWorkedHour.SelectedRows(0).Cells("Guid").Value)
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
        Dim Frm As New FrmLog(Routine.PersonCompressorPartWorkedHour, _PartWorkedHour.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _PartWorkedHour.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _PartWorkedHour.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
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
        ElseIf QbxItem.IsFreezed AndAlso _PersonCompressor.PartsWorkedHour.SingleOrDefault(Function(x) x.Product.Value.ID = QbxItem.FreezedPrimaryKey) IsNot Nothing AndAlso
            Not _PartWorkedHour.Equals(_PersonCompressor.PartsWorkedHour.SingleOrDefault(Function(x) x.Product.Value.ID = QbxItem.FreezedPrimaryKey)) Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf QbxItem.IsFreezed AndAlso _PersonCompressor.PartsElapsedDay.SingleOrDefault(Function(x) x.Product.Value.ID = QbxItem.FreezedPrimaryKey) IsNot Nothing Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf Not QbxItem.IsFreezed AndAlso _PersonCompressor.PartsWorkedHour.SingleOrDefault(Function(x) x.ItemName = QbxItem.Text) IsNot Nothing AndAlso
            Not _PartWorkedHour.Equals(_PersonCompressor.PartsWorkedHour.SingleOrDefault(Function(x) x.ItemName = QbxItem.Text)) Then
            EprValidation.SetError(LblItem, "Um item com esse nome já foi adicionado para esse compressor.")
            EprValidation.SetIconAlignment(LblItem, ErrorIconAlignment.MiddleRight)
            QbxItem.Select()
            Return False
        ElseIf Not QbxItem.IsFreezed AndAlso _PersonCompressor.PartsElapsedDay.SingleOrDefault(Function(x) x.ItemName = QbxItem.Text) IsNot Nothing Then
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
            QbxItem.Text = QbxItem.Text.Trim.ToUnaccented()
            QbxItem.QueryEnabled = True
        End If
        If IsValidFields() Then
            If _PartWorkedHour.IsSaved Then
                _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).PartBind = EnumHelper.GetEnumValue(Of CompressorPartBindType)(CbxPartBind.Text)
                If QbxItem.IsFreezed Then
                    _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).ItemName = Nothing
                    _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).Product = New Lazy(Of Product)(Function() New Product().Load(QbxItem.FreezedPrimaryKey, False))
                Else
                    _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).ItemName = QbxItem.Text
                    _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).Product = New Lazy(Of Product)()
                End If
                _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).Quantity = DbxQuantity.Text
                _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PartWorkedHour.Guid).Capacity = DbxCapacity.Text
            Else
                _PartWorkedHour = New PersonCompressorPart(CompressorPartType.WorkedHour) With {
                    .Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text),
                    .PartBind = EnumHelper.GetEnumValue(Of CompressorPartBindType)(CbxPartBind.Text)
                }
                If QbxItem.IsFreezed Then
                    _PartWorkedHour.ItemName = Nothing
                    _PartWorkedHour.Product = New Lazy(Of Product)(Function() New Product().Load(QbxItem.FreezedPrimaryKey, False))
                Else
                    _PartWorkedHour.ItemName = QbxItem.Text
                    _PartWorkedHour.Product = New Lazy(Of Product)()
                End If
                _PartWorkedHour.Quantity = DbxQuantity.Text
                _PartWorkedHour.Capacity = DbxCapacity.Text
                _PartWorkedHour.SetIsSaved(True)
                _PersonCompressor.PartsWorkedHour.Add(_PartWorkedHour)
            End If
            _PersonCompressorForm.DgvPartWorkedHour.Fill(_PersonCompressor.PartsWorkedHour)
            _PersonCompressorForm.DgvPartWorkedHourLayout.Load()
            BtnSave.Enabled = False
            If Not _PartWorkedHour.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _PersonCompressorForm.DgvPartWorkedHour.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _PartWorkedHour.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _PersonCompressorForm.DgvPartWorkedHour.SelectedRows(0).Cells("Order").Value
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
        _PartWorkedHour = New PersonCompressorPart(CompressorPartType.WorkedHour)
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PersonCompressorForm.DgvPartWorkedHour.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _PartWorkedHour = _PersonCompressor.PartsWorkedHour.Single(Function(x) x.Guid = _PersonCompressorForm.DgvPartWorkedHour.SelectedRows(0).Cells("Guid").Value)
                _PersonCompressor.PartsWorkedHour.Remove(_PartWorkedHour)
                _PersonCompressorForm.DgvPartWorkedHour.Fill(_PersonCompressor.PartsWorkedHour)
                _PersonCompressorForm.DgvPartWorkedHourLayout.Load()
                _Deleting = True
                Dispose()
                _PersonCompressorForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class