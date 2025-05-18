Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmEvaluationReplacedPart
    Private _EvaluationForm As FrmEvaluation
    Private _Evaluation As Evaluation
    Private _ReplacedItem As EvaluationReplacedPart
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
    Public Sub New(Evaluation As Evaluation, ReplacedPart As EvaluationReplacedPart, EvaluationForm As FrmEvaluation)
        InitializeComponent()
        _Evaluation = Evaluation
        _ReplacedItem = ReplacedPart
        _EvaluationForm = EvaluationForm
        _User = Locator.GetInstance(Of Session).User
        Height = 235
        LoadForm()
        DgvNavigator.DataGridView = _EvaluationForm.DgvPart
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_ReplacedItem.IsSaved, _EvaluationForm.DgvPart.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _ReplacedItem.Creation
        QbxItem.Unfreeze()
        If _ReplacedItem.ItemName = Nothing And _ReplacedItem.Product.ID > 0 Then
            QbxItem.Freeze(_ReplacedItem.Product.ID)
        ElseIf _ReplacedItem.ItemName <> Nothing And _ReplacedItem.Product.ID >= 0 Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = _ReplacedItem.ItemName
            QbxItem.QueryEnabled = True
        End If
        DbxQuantity.Text = _ReplacedItem.Quantity
        If Not _ReplacedItem.IsSaved Then
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
        If _EvaluationForm.DgvPart.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ReplacedItem = _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _EvaluationForm.DgvPart.SelectedRows(0).Cells("Guid").Value)
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
        Dim Frm As New FrmLog(Routine.RequestItem, _ReplacedItem.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub QbxItem_TextChanged(sender As Object, e As EventArgs) Handles QbxItem.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Dbx_TextChanged(sender As Object, e As EventArgs) Handles DbxQuantity.TextChanged
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
        ElseIf DbxQuantity.DecimalValue <= 0 Then
            EprValidation.SetError(LblTaked, "A quantidade retirada deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblTaked, ErrorIconAlignment.MiddleRight)
            DbxQuantity.Select()
            Return False

        End If
        Return True
    End Function
    Private Function HasDuplicatedItem() As Boolean
        Dim TargetItems As List(Of EvaluationReplacedPart)
        TargetItems = _Evaluation.ReplacedParts.Where(Function(x) Not x.Product.ID.Equals(_ReplacedItem.Product.ID) AndAlso x.Product.ID.Equals(QbxItem.FreezedPrimaryKey)).ToList()
        If TargetItems.Count > 0 Then
            CMessageBox.Show("Essa peça já foi incluida na avaliação.", CMessageBoxType.Information)
            QbxItem.Freeze(_ReplacedItem.Product.ID)
            DbxQuantity.Text = 0
            QbxItem.Select()
            Return True
        End If
        Return False
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If Not QbxItem.IsFreezed Then
            QbxItem.QueryEnabled = False
            QbxItem.Text = QbxItem.Text.Trim.ToUnaccented()
            QbxItem.QueryEnabled = True
        End If
        If IsValidFields() Then
            If HasDuplicatedItem() Then Return False
            If _ReplacedItem.IsSaved Then
                If QbxItem.IsFreezed Then
                    _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedItem.Guid).ItemName = Nothing
                    _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedItem.Guid).Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                Else
                    _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedItem.Guid).ItemName = QbxItem.Text
                    _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedItem.Guid).Product = New Product
                End If
                _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedItem.Guid).Quantity = DbxQuantity.Text
            Else
                _ReplacedItem = New EvaluationReplacedPart()
                If QbxItem.IsFreezed Then
                    _ReplacedItem.ItemName = Nothing
                    _ReplacedItem.Product = New Product().Load(QbxItem.FreezedPrimaryKey, False)
                Else
                    _ReplacedItem.ItemName = QbxItem.Text
                    _ReplacedItem.Product = New Product
                End If
                _ReplacedItem.Quantity = DbxQuantity.Text
                _ReplacedItem.SetIsSaved(True)
                _Evaluation.ReplacedParts.Add(_ReplacedItem)
            End If
            _EvaluationForm.DgvPart.Fill(_Evaluation.ReplacedParts)
            ' _EvaluationForm.DgvReplacedItemsLayout.Load()
            BtnSave.Enabled = False
            If Not _ReplacedItem.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _EvaluationForm.DgvPart.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _ReplacedItem.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _EvaluationForm.DgvPart.SelectedRows(0).Cells("Order").Value
            _EvaluationForm.EprValidation.Clear()
            _EvaluationForm.BtnSave.Enabled = True
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
        _ReplacedItem = New EvaluationReplacedPart()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _EvaluationForm.DgvPart.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ReplacedItem = _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _EvaluationForm.DgvPart.SelectedRows(0).Cells("Guid").Value)
                _Evaluation.ReplacedParts.Remove(_ReplacedItem)
                _EvaluationForm.DgvPart.Fill(_Evaluation.ReplacedParts)
                '_EvaluationForm.DgvReplacedItemsLayout.Load()
                _Deleting = True
                Dispose()
                _EvaluationForm.BtnSave.Enabled = True
            End If
        End If
    End Sub

End Class