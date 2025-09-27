Imports ControlLibrary
Imports ControlLibrary.Extensions

Public Class FrmCashItemResponsible
    Private _CashItemForm As FrmCashItem
    Private _CashItem As CashItem
    Private _CashItemResponsible As CashItemResponsible
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
    Public Sub New(CashItem As CashItem, CashItemResponsible As CashItemResponsible, CashItemForm As FrmCashItem)
        InitializeComponent()
        _CashItem = CashItem
        _CashItemResponsible = CashItemResponsible
        _CashItemForm = CashItemForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _CashItemForm.DgvResponsibles
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
        If _CashItemForm.DgvResponsibles.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _CashItemResponsible = _CashItem.Responsibles.Single(Function(x) x.Guid = _CashItemForm.DgvResponsibles.SelectedRows(0).Cells("Guid").Value)
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
        _CashItemResponsible = New CashItemResponsible()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CashItemForm.DgvResponsibles.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _CashItemResponsible = _CashItem.Responsibles.Single(Function(x) x.Guid = _CashItemForm.DgvResponsibles.SelectedRows(0).Cells("Guid").Value)
                _CashItem.Responsibles.Remove(_CashItemResponsible)
                _CashItemForm.DgvResponsibles.Fill(_CashItem.Responsibles)
                _CashItemForm.DgvResponsiblesLayout.Load()
                _Deleting = True
                Dispose()
                _CashItemForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Frm As New FrmLog(Routine.CashItemResponsible, _CashItemResponsible.ID)
            Frm.ShowDialog()
        End Using
    End Sub
    Private Sub QbxResponsible_TextChanged(sender As Object, e As EventArgs) Handles QbxResponsible.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_CashItemForm.DgvResponsibles.SelectedRows.Count = 1, _CashItemForm.DgvResponsibles.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _CashItemResponsible.Creation
        QbxResponsible.Unfreeze()
        QbxResponsible.Freeze(_CashItemResponsible.Responsible.ID)
        If Not _CashItemResponsible.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        QbxResponsible.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxResponsible.Text) Then
            EprValidation.SetError(LblResponsible, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblResponsible, ErrorIconAlignment.MiddleRight)
            QbxResponsible.Select()
            Return False
        ElseIf Not QbxResponsible.IsFreezed Then
            EprValidation.SetError(LblResponsible, "Pessoa responsável não encontrada.")
            EprValidation.SetIconAlignment(LblResponsible, ErrorIconAlignment.MiddleRight)
            QbxResponsible.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(QbxResponsible.Text) AndAlso _CashItem.Responsibles.SingleOrDefault(Function(x) x.Responsible.ID = QbxResponsible.FreezedPrimaryKey) IsNot Nothing AndAlso Not _CashItemResponsible.Equals(_CashItem.Responsibles.SingleOrDefault(Function(x) x.Responsible.ID = QbxResponsible.FreezedPrimaryKey)) Then
            EprValidation.SetError(LblResponsible, "Essa pessoa já é responsável neste lançameto.")
            EprValidation.SetIconAlignment(LblResponsible, ErrorIconAlignment.MiddleRight)
            QbxResponsible.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If _CashItemResponsible.IsSaved Then
                _CashItem.Responsibles.Single(Function(x) x.Guid = _CashItemResponsible.Guid).Responsible = New Person().Load(QbxResponsible.FreezedPrimaryKey, False)
            Else
                _CashItemResponsible = New CashItemResponsible With {
                    .Responsible = New Person().Load(QbxResponsible.FreezedPrimaryKey, False)
                }
                _CashItemResponsible.SetIsSaved(True)
                _CashItem.Responsibles.Add(_CashItemResponsible)
            End If
            _CashItemForm.DgvResponsibles.Fill(_CashItem.Responsibles)
            _CashItemForm.DgvResponsiblesLayout.Load()
            QbxResponsible.Select()
            BtnSave.Enabled = False
            If Not _CashItemResponsible.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _CashItemForm.DgvResponsibles.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _CashItemResponsible.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _CashItemForm.DgvResponsibles.SelectedRows(0).Cells("Order").Value
            _CashItemForm.EprValidation.Clear()
            _CashItemForm.BtnSave.Enabled = True
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
    Private Sub QbxResponsible_Enter(sender As Object, e As EventArgs) Handles QbxResponsible.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxResponsible.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNew.Visible = _User.CanWrite(Routine.Person)
        BtnFilter.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxResponsible_Leave(sender As Object, e As EventArgs) Handles QbxResponsible.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxResponsible_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxResponsible.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxResponsible.IsFreezed And _User.CanWrite(Routine.Person)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Responsible As Person
        Responsible = New Person
        Responsible.IsEmployee = True
        Using Form As New FrmPerson(Responsible)
            Form.CbxIsEmployee.Enabled = False
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Responsible.ID > 0 Then
            QbxResponsible.Freeze(Responsible.ID)
        End If
        QbxResponsible.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Using Form As New FrmPerson(New Person().Load(QbxResponsible.FreezedPrimaryKey, True))
            Form.CbxIsEmployee.Enabled = False
            Form.ShowDialog()
        End Using
        QbxResponsible.Freeze(QbxResponsible.FreezedPrimaryKey)
        QbxResponsible.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New PersonEmployeeQueriedBoxFilter(), QbxResponsible) With {.Text = "Filtro de Funcionários"}
            Form.ShowDialog()
        End Using
        QbxResponsible.Select()
    End Sub
End Class