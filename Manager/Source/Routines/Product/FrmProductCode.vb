Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmProductCode
    Private _ProductForm As FrmProduct
    Private _Product As Product
    Private _ProductCode As ProductCode
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
    Public Sub New(Product As Product, ProductCode As ProductCode, ProductForm As FrmProduct)
        InitializeComponent()
        _Product = Product
        _ProductCode = ProductCode
        _ProductForm = ProductForm
        LoadForm()
        DgvNavigator.DataGridView = _ProductForm.DgvCode
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.CanAccess(Routine.Log)
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
        If _ProductForm.DgvCode.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ProductCode = _Product.Codes.Single(Function(x) x.Order = _ProductForm.DgvCode.SelectedRows(0).Cells("Order").Value)
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
        _ProductCode = New ProductCode()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ProductForm.DgvCode.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ProductCode = _Product.Codes.Single(Function(x) x.Order = _ProductForm.DgvCode.SelectedRows(0).Cells("Order").Value)
                _Product.Codes.Remove(_ProductCode)
                _Product.Codes.FillDataGridView(_ProductForm.DgvCode)
                _ProductForm.DgvCodeLayout.Load()
                _Deleting = True
                Dispose()
                _ProductForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.ProductCode, _ProductCode.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles CbxName.SelectedIndexChanged,
                                                                              TxtCode.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _ProductCode.Order
        LblCreationValue.Text = _ProductCode.Creation
        CbxName.Text = _ProductCode.Name
        TxtCode.Text = _ProductCode.Code
        If _ProductCode.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        CbxName.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If Not _ProductCode.IsSaved And _Product.Codes.Any(Function(x) x.Name = CbxName.Text) Then
            EprValidation.SetError(LblName, "Esse código já foi cadastrado.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            CbxName.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtCode.Text) Then
            EprValidation.SetError(LblCode, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCode, ErrorIconAlignment.MiddleRight)
            TxtCode.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        CbxName.Text = CbxName.Text
        TxtCode.Text = RemoveAccents(TxtCode.Text.Trim)
        If IsValidFields() Then
            If _ProductCode.IsSaved Then
                _Product.Codes.Single(Function(x) x.Order = _ProductCode.Order).Name = CbxName.Text
                _Product.Codes.Single(Function(x) x.Order = _ProductCode.Order).Code = TxtCode.Text
            Else
                _ProductCode = New ProductCode()
                _ProductCode.Name = CbxName.Text
                _ProductCode.Code = TxtCode.Text
                _ProductCode.IsSaved = True
                _Product.Codes.Add(_ProductCode)
            End If
            _Product.Codes.FillDataGridView(_ProductForm.DgvCode)
            LblOrderValue.Text = _ProductCode.Order
            _ProductForm.DgvCodeLayout.Load()
            BtnSave.Enabled = False
            If _ProductCode.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _ProductForm.DgvCode.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _ProductCode.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _ProductForm.EprValidation.Clear()
            _ProductForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
End Class