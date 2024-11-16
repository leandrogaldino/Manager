Imports ControlLibrary

Public Class FrmEvaluationTechnician
    Private _EvaluationForm As FrmEvaluation
    Private _Evaluation As Evaluation
    Private _EvaluationTechnician As EvaluationTechnician
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
    Public Sub New(Evaluation As Evaluation, EvaluationTechnician As EvaluationTechnician, EvaluationForm As FrmEvaluation)
        InitializeComponent()
        _Evaluation = Evaluation
        _EvaluationTechnician = EvaluationTechnician
        _EvaluationForm = EvaluationForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _EvaluationForm.DgvTechnician
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
        If _EvaluationForm.DgvTechnician.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _EvaluationTechnician = _Evaluation.Technicians.Single(Function(x) x.Order = _EvaluationForm.DgvTechnician.SelectedRows(0).Cells("Order").Value)
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
        Dim Frm As New FrmLog(Routine.EvaluationTechnician, _EvaluationTechnician.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles QbxTechnician.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _EvaluationTechnician.Order
        LblCreationValue.Text = _EvaluationTechnician.Creation
        QbxTechnician.Unfreeze()
        QbxTechnician.Freeze(_EvaluationTechnician.Technician.ID)
        If _EvaluationTechnician.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        QbxTechnician.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(QbxTechnician.Text) Then
            EprValidation.SetError(LblTechnician, "Campo Obrigatório.")
            EprValidation.SetIconAlignment(LblTechnician, ErrorIconAlignment.MiddleRight)
            QbxTechnician.Select()
            Return False
        ElseIf Not QbxTechnician.IsFreezed Then
            EprValidation.SetError(LblTechnician, "Técnico não encontrado.")
            EprValidation.SetIconAlignment(LblTechnician, ErrorIconAlignment.MiddleRight)
            QbxTechnician.Select()
            Return False
        ElseIf _Evaluation.Technicians.Any(Function(x) x.Technician.ID = QbxTechnician.FreezedPrimaryKey) Then
            EprValidation.SetError(LblTechnician, "Esse técnico já está nessa avaliação.")
            EprValidation.SetIconAlignment(LblTechnician, ErrorIconAlignment.MiddleRight)
            QbxTechnician.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If _EvaluationTechnician.IsSaved Then
                _Evaluation.Technicians.Single(Function(x) x.Order = _EvaluationTechnician.Order).Technician = New Person().Load(QbxTechnician.FreezedPrimaryKey, False)
            Else
                _EvaluationTechnician = New EvaluationTechnician()
                _EvaluationTechnician.Technician = New Person().Load(QbxTechnician.FreezedPrimaryKey, False)
                _EvaluationTechnician.IsSaved = True
                _Evaluation.Technicians.Add(_EvaluationTechnician)
            End If
            _EvaluationForm.FillDataGridViewTechnician()
            LblOrderValue.Text = _EvaluationTechnician.Order
            BtnSave.Enabled = False
            If _EvaluationTechnician.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _EvaluationForm.DgvTechnician.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _EvaluationTechnician.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _EvaluationForm.EprValidation.Clear()
            _EvaluationForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnViewTechnician.Visible = False
        BtnNewTechnician.Visible = False
        BtnFilterTechnician.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxTechnician_Enter(sender As Object, e As EventArgs)
        TmrQueriedBox.Stop()
        BtnViewTechnician.Visible = QbxTechnician.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNewTechnician.Visible = _User.CanWrite(Routine.Person)
        BtnFilterTechnician.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxTechnician_Leave(sender As Object, e As EventArgs)
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxTechnician_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs)
        If Not _Loading Then BtnViewTechnician.Visible = QbxTechnician.IsFreezed And _User.CanWrite(Routine.Person)
    End Sub
    Private Sub BtnNewTechnician_Click(sender As Object, e As EventArgs)
        Dim Technician As Person
        Dim Form As FrmPerson
        Technician = New Person
        Technician.IsTechnician = True
        Form = New FrmPerson(Technician)
        Form.CbxIsTechnician.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Technician.ID > 0 Then
            QbxTechnician.Freeze(Technician.ID)
        End If
        QbxTechnician.Select()
    End Sub
    Private Sub BtnViewTechnician_Click(sender As Object, e As EventArgs)
        Dim Form As New FrmPerson(New Person().Load(QbxTechnician.FreezedPrimaryKey, True))
        Form.CbxIsTechnician.Enabled = False
        Form.ShowDialog()
        QbxTechnician.Freeze(QbxTechnician.FreezedPrimaryKey)
        QbxTechnician.Select()
    End Sub
    Private Sub BtnFilterTechnician_Click(sender As Object, e As EventArgs)
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonTechnicianQueriedBoxFilter(), QbxTechnician)
        FilterForm.Text = "Filtro de Técnicos"
        FilterForm.ShowDialog()
        QbxTechnician.Select()
    End Sub




    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _EvaluationTechnician = New EvaluationTechnician()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _EvaluationForm.DgvTechnician.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _EvaluationTechnician = _Evaluation.Technicians.Single(Function(x) x.Order = _EvaluationForm.DgvTechnician.SelectedRows(0).Cells("Order").Value)
                _EvaluationForm.FillDataGridViewTechnician()
                _Evaluation.Technicians.FillDataGridView(_EvaluationForm.DgvTechnician)
                _Deleting = True
                Dispose()
                _EvaluationForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class