Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmEvaluationReplacedPart
    Private _EvaluationForm As FrmEvaluation
    Private _Evaluation As Evaluation
    Private _ReplacedPart As EvaluationReplacedPart
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
        _ReplacedPart = ReplacedPart
        _EvaluationForm = EvaluationForm
        _User = Locator.GetInstance(Of Session).User
        Height = 235
        LoadForm()
        DgvNavigator.DataGridView = _EvaluationForm.DgvReplacedPart
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_ReplacedPart.IsSaved, _EvaluationForm.DgvReplacedPart.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _ReplacedPart.Creation
        QbxItem.Unfreeze()
        QbxItem.Freeze(_ReplacedPart.ProductID)
        DbxQuantity.Text = _ReplacedPart.Quantity
        If Not _ReplacedPart.IsSaved Then
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
        If _EvaluationForm.DgvReplacedPart.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ReplacedPart = _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _EvaluationForm.DgvReplacedPart.SelectedRows(0).Cells("Guid").Value)
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
        Dim Frm As New FrmLog(Routine.EvaluationReplacedPart, _ReplacedPart.ID)
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
        ElseIf Not QbxItem.IsFreezed Then
            EprValidation.SetError(LblItem, "Produto não encontrado.")
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
        TargetItems = _Evaluation.ReplacedParts.Where(Function(x) Not x.ProductID.Equals(_ReplacedPart.ProductID) AndAlso x.ProductID.Equals(QbxItem.FreezedPrimaryKey)).ToList()
        If TargetItems.Count > 0 Then
            CMessageBox.Show("Essa peça já foi incluida na avaliação.", CMessageBoxType.Information)
            QbxItem.Freeze(_ReplacedPart.ProductID)
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
            If _ReplacedPart.IsSaved Then
                _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedPart.Guid).ProductID = QbxItem.FreezedPrimaryKey
                _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedPart.Guid).Product = New Lazy(Of Product)(Function() New Product().Load(QbxItem.FreezedPrimaryKey, False))
                _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedPart.Guid).ProductCode = QbxItem.GetRawFreezedValueOf("productprovidercode", "code").ToString
                _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedPart.Guid).ProductName = QbxItem.GetRawFreezedValueOf("product", "name").ToString
                _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _ReplacedPart.Guid).Quantity = DbxQuantity.DecimalValue
            Else
                _ReplacedPart = New EvaluationReplacedPart With {
                    .ProductID = QbxItem.FreezedPrimaryKey,
                    .Product = New Lazy(Of Product)(Function() New Product().Load(QbxItem.FreezedPrimaryKey, False)),
                    .ProductCode = QbxItem.GetRawFreezedValueOf("productprovidercode", "code").ToString,
                    .ProductName = QbxItem.GetRawFreezedValueOf("product", "name").ToString,
                    .Quantity = DbxQuantity.DecimalValue
                }
                _ReplacedPart.SetIsSaved(True)
                _Evaluation.ReplacedParts.Add(_ReplacedPart)
            End If
            _EvaluationForm.DgvReplacedPart.Fill(_Evaluation.ReplacedParts)
            _EvaluationForm.DgvReplacedPartLayout.Load()
            BtnSave.Enabled = False
            If Not _ReplacedPart.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _EvaluationForm.DgvReplacedPart.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _ReplacedPart.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _EvaluationForm.DgvReplacedPart.SelectedRows(0).Cells("Order").Value
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
        _ReplacedPart = New EvaluationReplacedPart()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _EvaluationForm.DgvReplacedPart.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ReplacedPart = _Evaluation.ReplacedParts.Single(Function(x) x.Guid = _EvaluationForm.DgvReplacedPart.SelectedRows(0).Cells("Guid").Value)
                _Evaluation.ReplacedParts.Remove(_ReplacedPart)
                _EvaluationForm.DgvReplacedPart.Fill(_Evaluation.ReplacedParts)
                _EvaluationForm.DgvReplacedPartLayout.Load()
                _Deleting = True
                Dispose()
                _EvaluationForm.BtnSave.Enabled = True
            End If
        End If
    End Sub

End Class