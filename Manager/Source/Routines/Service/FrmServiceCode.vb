Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmServiceCode
    Private _ServiceForm As FrmService
    Private _Service As Service
    Private _ServiceCode As ServiceCode
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
    Public Sub New(Service As Service, ServiceCode As ServiceCode, ServiceForm As FrmService)
        InitializeComponent()
        _Service = Service
        _ServiceCode = ServiceCode
        _ServiceForm = ServiceForm
        LoadForm()
        DgvNavigator.DataGridView = _ServiceForm.DgvCode
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
        If _ServiceForm.DgvCode.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ServiceCode = _Service.Codes.Single(Function(x) x.Guid = _ServiceForm.DgvCode.SelectedRows(0).Cells("Guid").Value)
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
        _ServiceCode = New ServiceCode()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ServiceForm.DgvCode.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ServiceCode = _Service.Codes.Single(Function(x) x.Guid = _ServiceForm.DgvCode.SelectedRows(0).Cells("Guid").Value)
                _Service.Codes.Remove(_ServiceCode)
                _ServiceForm.DgvCode.Fill(_Service.Codes)
                _ServiceForm.DgvlCode.Load()
                _Deleting = True
                Dispose()
                _ServiceForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.ServiceCode, _ServiceCode.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles CbxName.SelectedIndexChanged, TxtCode.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_ServiceCode.IsSaved, _ServiceForm.DgvCode.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _ServiceCode.Creation
        CbxName.Text = _ServiceCode.Name
        TxtCode.Text = _ServiceCode.Code
        If Not _ServiceCode.IsSaved Then
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
        If Not _ServiceCode.IsSaved And _Service.Codes.Any(Function(x) x.Name = CbxName.Text) Then
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
        TxtCode.Text = TxtCode.Text.Trim.ToUnaccented()
        If IsValidFields() Then
            If _ServiceCode.IsSaved Then
                _Service.Codes.Single(Function(x) x.Guid = _ServiceCode.Guid).Name = CbxName.Text
                _Service.Codes.Single(Function(x) x.Guid = _ServiceCode.Guid).Code = TxtCode.Text
            Else
                _ServiceCode = New ServiceCode With {
                    .Name = CbxName.Text,
                    .Code = TxtCode.Text
                }
                _ServiceCode.SetIsSaved(True)
                _Service.Codes.Add(_ServiceCode)
            End If
            _ServiceForm.DgvCode.Fill(_Service.Codes)
            _ServiceForm.DgvlCode.Load()
            BtnSave.Enabled = False
            If Not _ServiceCode.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _ServiceForm.DgvCode.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _ServiceCode.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _ServiceForm.DgvCode.SelectedRows(0).Cells("Order").Value
            _ServiceForm.EprValidation.Clear()
            _ServiceForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
End Class