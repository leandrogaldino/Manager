Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmServiceComplement
    Private _ServiceForm As FrmService
    Private _Service As Service
    Private _ServiceComplement As ServiceComplement
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
    Public Sub New(Service As Service, ServiceComplement As ServiceComplement, ServiceForm As FrmService)
        InitializeComponent()
        _Service = Service
        _ServiceComplement = ServiceComplement
        _ServiceForm = ServiceForm
        LoadForm()
        DgvNavigator.DataGridView = _ServiceForm.DgvComplement
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
        If _ServiceForm.DgvComplement.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ServiceComplement = _Service.Complements.Single(Function(x) x.Guid = _ServiceForm.DgvComplement.SelectedRows(0).Cells("Guid").Value)
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
        _ServiceComplement = New ServiceComplement()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ServiceForm.DgvComplement.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ServiceComplement = _Service.Complements.Single(Function(x) x.Guid = _ServiceForm.DgvComplement.SelectedRows(0).Cells("Guid").Value)
                _Service.Complements.Remove(_ServiceComplement)
                _ServiceForm.DgvComplement.Fill(_Service.Complements)
                _ServiceForm.DgvComplementnLayout.Load()
                _Deleting = True
                Dispose()
                _ServiceForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.ServiceComplement, _ServiceComplement.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtComplement.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_ServiceComplement.IsSaved, _ServiceForm.DgvComplement.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _ServiceComplement.Creation
        TxtComplement.Text = _ServiceComplement.Complement
        If Not _ServiceComplement.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        TxtComplement.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtComplement.Text) Then
            EprValidation.SetError(LblComplement, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblComplement, ErrorIconAlignment.MiddleRight)
            TxtComplement.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtComplement.Text = TxtComplement.Text.Trim.ToUnaccented()
        If IsValidFields() Then
            If _ServiceComplement.IsSaved Then
                _Service.Complements.Single(Function(x) x.Guid = _ServiceComplement.Guid).Complement = TxtComplement.Text
            Else
                _ServiceComplement = New ServiceComplement With {
                    .Complement = TxtComplement.Text
                }
                _ServiceComplement.SetIsSaved(True)
                _Service.Complements.Add(_ServiceComplement)
            End If
            _ServiceForm.DgvComplement.Fill(_Service.Complements)
            _ServiceForm.DgvComplementnLayout.Load()
            BtnSave.Enabled = False
            If Not _ServiceComplement.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _ServiceForm.DgvComplement.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _ServiceComplement.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _ServiceForm.DgvComplement.SelectedRows(0).Cells("Order").Value
            _ServiceForm.EprValidation.Clear()
            _ServiceForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
End Class