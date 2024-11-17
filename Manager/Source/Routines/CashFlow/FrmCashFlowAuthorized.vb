Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmCashFlowAuthorized
    Private _CashFlowForm As FrmCashFlow
    Private _CashFlow As CashFlow
    Private _CashFlowAuthorized As CashFlowAuthorized
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
    Public Sub New(CashFlow As CashFlow, CashFlowAuthorized As CashFlowAuthorized, CashFlowForm As FrmCashFlow)
        InitializeComponent()
        _CashFlow = CashFlow
        _CashFlowAuthorized = CashFlowAuthorized
        _CashFlowForm = CashFlowForm
        LoadForm()
        DgvNavigator.DataGridView = _CashFlowForm.DgvAuthorized
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
        If _CashFlowForm.DgvAuthorized.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _CashFlowAuthorized = _CashFlow.Authorizeds.Single(Function(x) x.Guid = _CashFlowForm.DgvAuthorized.SelectedRows(0).Cells("Guid").Value)
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
        Dim Frm As New FrmLog(Routine.CashFlowAuthorized, _CashFlowAuthorized.ID)
        Frm.ShowDialog()
    End Sub

    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles QbxAuthorized.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_CashFlowAuthorized.IsSaved, _CashFlowForm.DgvAuthorized.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _CashFlowAuthorized.Creation
        QbxAuthorized.Unfreeze()
        QbxAuthorized.Freeze(_CashFlowAuthorized.Authorized.ID)
        If Not _CashFlowAuthorized.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        QbxAuthorized.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(QbxAuthorized.Text) Then
            EprValidation.SetError(LblAuthorized, "Campo Obrigatório.")
            EprValidation.SetIconAlignment(LblAuthorized, ErrorIconAlignment.MiddleRight)
            QbxAuthorized.Select()
            Return False
        ElseIf Not QbxAuthorized.IsFreezed Then
            EprValidation.SetError(LblAuthorized, "Rota não encontrada.")
            EprValidation.SetIconAlignment(LblAuthorized, ErrorIconAlignment.MiddleRight)
            QbxAuthorized.Select()
            Return False
        ElseIf _CashFlow.Authorizeds.Any(Function(x) x.Authorized.ID = QbxAuthorized.FreezedPrimaryKey) Then
            EprValidation.SetError(LblAuthorized, "Esse usuário já está nesse fluxo de caixa.")
            EprValidation.SetIconAlignment(LblAuthorized, ErrorIconAlignment.MiddleRight)
            QbxAuthorized.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If _CashFlowAuthorized.IsSaved Then
                _CashFlow.Authorizeds.Single(Function(x) x.Guid = _CashFlowAuthorized.Guid).Authorized = New Person().Load(QbxAuthorized.FreezedPrimaryKey, False)
            Else
                _CashFlowAuthorized = New CashFlowAuthorized With {
                    .Authorized = New Person().Load(QbxAuthorized.FreezedPrimaryKey, False)
                }
                _CashFlowAuthorized.SetIsSaved(True)
                _CashFlow.Authorizeds.Add(_CashFlowAuthorized)
            End If
            _CashFlowForm.DgvAuthorized.Fill(_CashFlow.Authorizeds)
            BtnSave.Enabled = False
            If Not _CashFlowAuthorized.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _CashFlowForm.DgvAuthorized.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _CashFlowAuthorized.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _CashFlowForm.DgvAuthorized.SelectedRows(0).Cells("Order").Value
            _CashFlowForm.EprValidation.Clear()
            _CashFlowForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _CashFlowAuthorized = New CashFlowAuthorized()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CashFlowForm.DgvAuthorized.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _CashFlowAuthorized = _CashFlow.Authorizeds.Single(Function(x) x.Guid = _CashFlowForm.DgvAuthorized.SelectedRows(0).Cells("Guid").Value)
                _CashFlow.Authorizeds.Remove(_CashFlowAuthorized)
                _CashFlowForm.DgvAuthorized.Fill(_CashFlow.Authorizeds)
                _Deleting = True
                Dispose()
                _CashFlowForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class