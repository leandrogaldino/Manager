Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Public Class FrmCrm
    Private _Crm As Crm
    Private _CrmsForm As FrmCrms
    Private _CrmsGrid As DataGridView
    Private _Filter As CrmFilter
    Private _ClickedLinks As New List(Of HtmlElement)()
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(Crm As Crm, CrmsForm As FrmCrms)
        _Crm = Crm
        _CrmsForm = CrmsForm
        _CrmsGrid = _CrmsForm.DgvData
        _Filter = CType(_CrmsForm.PgFilter.SelectedObject, CrmFilter)
        _User = Locator.GetInstance(Of Session).User
        InitializeComponent()
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(Crm As Crm)
        _Crm = Crm
        InitializeComponent()
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        LblPerson.Top -= TsNavigation.Height
        QbxCustomer.Top -= TsNavigation.Height
        FlpCustomer.Top -= TsNavigation.Height
        LblResponsible.Top -= TsNavigation.Height
        QbxResponsible.Top -= TsNavigation.Height
        LblTreatment.Top -= TsNavigation.Height
        PnTreatment.Top -= TsNavigation.Height
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
        LblStatus.Visible = True
        LblStatusValue.Visible = True
        BtnStatusValue.Visible = False
    End Sub
    Private Sub FrmCrm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        WebTreatments.Navigate(_Crm.GetHtml)
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _CrmsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _Crm.ID
        If _Crm.ID > 0 Then
            If _Crm.Status <> CrmStatus.Pending Then
                If _User.CanAccess(Routine.CrmChangeStatusToPending) Then
                    BtnStatusValue.Visible = True
                    LblStatusValue.Visible = False
                Else
                    BtnStatusValue.Visible = False
                    LblStatusValue.Visible = True
                End If
            Else
                BtnPending.Visible = False
                BtnStatusValue.Visible = True
                LblStatusValue.Visible = False
            End If
        Else
            BtnStatusValue.Visible = True
            LblStatusValue.Visible = False
        End If
        LblStatusValue.Text = GetEnumDescription(_Crm.Status)
        BtnStatusValue.Text = GetEnumDescription(_Crm.Status)
        BtnPending.Visible = _Crm.Status <> CrmStatus.Pending And _User.CanAccess(Routine.CrmChangeStatusToPending)
        BtnFinish.Visible = _Crm.Status <> CrmStatus.Finished
        BtnLost.Visible = _Crm.Status <> CrmStatus.Lost
        BtnDelete.Enabled = _Crm.ID > 0 And _User.CanDelete(Routine.Crm)
        LblCreationValue.Text = _Crm.Creation.ToString("dd/MM/yyyy")
        QbxCustomer.Unfreeze()
        QbxCustomer.Freeze(_Crm.Customer.ID)
        QbxResponsible.Unfreeze()
        QbxResponsible.Freeze(_Crm.Responsible.ID)
        TxtSubject.Text = _Crm.Subject
        Text = "CRM"
        If _Crm.LockInfo.IsLocked And Not _Crm.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Crm.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_Crm.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        If _Crm.ID > 0 Then
            FlpCustomer.Visible = _User.CanAccess(Routine.CrmChangeCustomer)
            QbxCustomer.ReadOnly = Not _User.CanAccess(Routine.CrmChangeCustomer)
            QbxResponsible.ReadOnly = Not _User.CanAccess(Routine.CrmChangeResponsible)
            TxtSubject.ReadOnly = Not _User.CanAccess(Routine.CrmChangeSubject)
        Else
            FlpCustomer.Visible = True
            QbxCustomer.ReadOnly = False
            QbxResponsible.ReadOnly = False
            TxtSubject.ReadOnly = False
        End If
        QbxCustomer.Select()
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then DgvNavigator.CancelNextMove = True
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            _Crm.Load(_CrmsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO CR001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _Deleting AndAlso BtnSave.Enabled Then
            If BtnSave.Enabled Then
                If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not Save() Then e.Cancel = True
                End If
            End If
        End If
        _CrmsForm.WebTreatments.Navigate(_Crm.GetHtml())
        _Deleting = False
    End Sub
    Private Sub FrmCrm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Crm.Unlock()
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _Crm = New Crm
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Crm.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Crm.LockInfo.IsLocked Or (_Crm.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Crm.LockInfo.SessionToken) Then
                        _Crm.Delete()
                        If _CrmsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _CrmsForm.DgvCrmLayout.Load()
                            _CrmsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_Crm.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                CMessageBox.Show("ERRO CR002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.Crm, _Crm.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        If BtnStatusValue.Text = GetEnumDescription(CrmStatus.Pending) Then
            BtnStatusValue.ForeColor = Color.DarkBlue
            LblStatusValue.ForeColor = Color.DarkBlue
        ElseIf BtnStatusValue.Text = GetEnumDescription(CrmStatus.Finished) Then
            BtnStatusValue.ForeColor = Color.DarkGreen
            LblStatusValue.ForeColor = Color.DarkGreen
        ElseIf BtnStatusValue.Text = GetEnumDescription(CrmStatus.Lost) Then
            BtnStatusValue.ForeColor = Color.DarkRed
            LblStatusValue.ForeColor = Color.DarkRed
        End If
    End Sub
    Private Sub ChangeStatus(status As CrmStatus)
        Dim Row As DataGridViewRow
        If _Crm.ID > 0 Then
            If Not BtnSave.Enabled Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Crm.SetStatus(status)
                    BtnStatusValue.Text = GetEnumDescription(_Crm.Status)
                    LblStatusValue.Text = GetEnumDescription(_Crm.Status)
                    BtnPending.Visible = _Crm.Status <> CrmStatus.Pending And _User.CanAccess(Routine.CrmChangeStatusToPending)
                    BtnFinish.Visible = _Crm.Status <> CrmStatus.Finished
                    BtnLost.Visible = _Crm.Status <> CrmStatus.Lost
                    If _Crm.Status <> CrmStatus.Pending Then
                        If _User.CanAccess(Routine.CrmChangeStatusToPending) Then
                            BtnStatusValue.Visible = True
                            LblStatusValue.Visible = False
                        Else
                            BtnStatusValue.Visible = False
                            LblStatusValue.Visible = True
                        End If
                    Else
                        BtnStatusValue.Visible = True
                        LblStatusValue.Visible = False
                    End If
                    If _CrmsForm IsNot Nothing Then
                        _Filter.Filter()
                        _CrmsForm.DgvCrmLayout.Load()
                        Row = _CrmsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                Catch ex As Exception
                    CMessageBox.Show("ERRO CR003", "Ocorreu um erro ao alterar o status.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                CMessageBox.Show("O status não pôde ser alterado, pois há alterações que ainda não foram salvas, salve e tente novamente.", CMessageBoxType.Warning)
            End If
        Else
            CMessageBox.Show("O status não pôde ser alterado, pois esse registro ainda não foi salvo.", CMessageBoxType.Warning)
        End If
    End Sub
    Private Sub BtnFinish_Click(sender As Object, e As EventArgs) Handles BtnFinish.Click
        ChangeStatus(CrmStatus.Finished)
    End Sub
    Private Sub BtnLost_Click(sender As Object, e As EventArgs) Handles BtnLost.Click
        ChangeStatus(CrmStatus.Lost)
    End Sub
    Private Sub BtnPending_Click(sender As Object, e As EventArgs) Handles BtnPending.Click
        ChangeStatus(CrmStatus.Pending)
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtSubject.TextChanged, QbxResponsible.TextChanged, QbxCustomer.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
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
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxCustomer.Text) Then
            EprValidation.SetError(LblPerson, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblPerson, ErrorIconAlignment.MiddleRight)
            QbxCustomer.Select()
            Return False
        ElseIf Not QbxResponsible.IsFreezed Then
            EprValidation.SetError(LblResponsible, "Responsável não encontrado.")
            EprValidation.SetIconAlignment(LblResponsible, ErrorIconAlignment.MiddleRight)
            QbxResponsible.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtSubject.Text) Then
            EprValidation.SetError(LblSubject, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblSubject, ErrorIconAlignment.MiddleRight)
            TxtSubject.Select()
            Return False
        ElseIf _Crm.Treatments.Count = 0 Then
            EprValidation.SetError(TsTreatment, "Não é possível salvar um CRM sem atendimento.")
            EprValidation.SetIconAlignment(TsTreatment, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsTreatment, -365)
            BtnIncludeTreatment.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtSubject.Text = RemoveAccents(TxtSubject.Text.Trim)
        If _Crm.LockInfo.IsLocked And _Crm.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_Crm.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _Crm.Status = GetEnumValue(Of CrmStatus)(BtnStatusValue.Text)
                _Crm.Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
                _Crm.Responsible = New Person().Load(QbxResponsible.FreezedPrimaryKey, False)
                _Crm.Subject = TxtSubject.Text
                Try
                    Cursor = Cursors.WaitCursor
                    _Crm.SaveChanges()
                    _Crm.Lock()
                    LblIDValue.Text = _Crm.ID
                    WebTreatments.Navigate(_Crm.GetHtml(TxtFilterTreatment.Text))
                    BtnSave.Enabled = False
                    BtnDelete.Visible = _User.CanDelete(Routine.Crm)
                    If _CrmsForm IsNot Nothing Then
                        _Filter.Filter()
                        _CrmsForm.DgvCrmLayout.Load()
                        Row = _CrmsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    CMessageBox.Show("ERRO CR004", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub TmrQueriedBoxCustomer_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBoxCustomer.Tick
        BtnViewCustomer.Visible = False
        BtnNewCustomer.Visible = False
        BtnFilterCustomer.Visible = False
        TmrQueriedBoxCustomer.Stop()
    End Sub
    Private Sub QbxCustomer_Enter(sender As Object, e As EventArgs) Handles QbxCustomer.Enter
        TmrQueriedBoxCustomer.Stop()
        BtnViewCustomer.Visible = QbxCustomer.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNewCustomer.Visible = _User.CanWrite(Routine.Person)
        BtnFilterCustomer.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxCustomer_Leave(sender As Object, e As EventArgs) Handles QbxCustomer.Leave
        TmrQueriedBoxCustomer.Stop()
        TmrQueriedBoxCustomer.Start()
    End Sub
    Private Sub QbxCustomer_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCustomer.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewCustomer.Visible = QbxCustomer.IsFreezed And _User.CanWrite(Routine.Person)
    End Sub
    Private Sub BtnNewCustomer_Click(sender As Object, e As EventArgs) Handles BtnNewCustomer.Click
        Dim Person As Person
        Dim Form As FrmPerson
        Person = New Person
        Person.IsCustomer = True
        Form = New FrmPerson(Person)
        Form.CbxIsCustomer.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Person.ID > 0 Then
            QbxCustomer.Freeze(Person.ID)
        End If
        QbxCustomer.Select()
    End Sub
    Private Sub BtnViewCustomer_Click(sender As Object, e As EventArgs) Handles BtnViewCustomer.Click
        Dim Form As New FrmPerson(New Person().Load(QbxCustomer.FreezedPrimaryKey, True))
        Form.CbxIsCustomer.Enabled = False
        Form.ShowDialog()
        QbxCustomer.Freeze(QbxCustomer.FreezedPrimaryKey)
        QbxCustomer.Select()
    End Sub
    Private Sub BtnFilterCustomer_Click(sender As Object, e As EventArgs) Handles BtnFilterCustomer.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonCustomerQueriedBoxFilter(Nothing), QbxCustomer)
        FilterForm.Text = "Filtro de Pessoas"
        FilterForm.ShowDialog()
        QbxCustomer.Select()
    End Sub
    Private Sub QbxResponsible_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxResponsible.FreezedPrimaryKeyChanged
        Dim Responsible As Person
        Responsible = New Person().Load(QbxResponsible.FreezedPrimaryKey, False)
        If Responsible.ID > 0 Then _Crm.Responsible = Responsible
        For Each Treatment As CrmTreatment In _Crm.Treatments.Where(Function(x) x.ID = 0)
            Treatment.Responsible = Responsible
        Next Treatment
        If Not _Loading Then WebTreatments.Navigate(_Crm.GetHtml(TxtFilterTreatment.Text))
    End Sub
    Private Sub BtnIncludeTreatment_Click(sender As Object, e As EventArgs) Handles BtnIncludeTreatment.Click
        Dim Form As New FrmCrmTreatment(_Crm, New CrmTreatment(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub TxtFilterTreatment_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterTreatment.TextChanged
        WebTreatments.Navigate(_Crm.GetHtml(TxtFilterTreatment.Text))
    End Sub
    Private Sub WebTreatments_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebTreatments.DocumentCompleted
        For Each Link As HtmlElement In WebTreatments.Document.GetElementsByTagName("a")
            If Not _ClickedLinks.Contains(Link) Then
                AddHandler Link.Click, AddressOf LinkClickHandler
                _ClickedLinks.Add(Link)
            End If
        Next
    End Sub
    Private Sub LinkClickHandler(sender As Object, e As HtmlElementEventArgs)
        Dim Element As HtmlElement = CType(sender, HtmlElement)
        Dim Order As Integer = Element.GetAttribute("treatmentorder")
        Dim EventType As String = Element.GetAttribute("eventtype")
        Dim Form As FrmCrmTreatment
        Dim Treatment As CrmTreatment
        If EventType = "edit" Then
            Treatment = _Crm.Treatments.Single(Function(x) x.Order = Order)
            Form = New FrmCrmTreatment(_Crm, Treatment, Me)
            Form.ShowDialog()
        Else
            If CMessageBox.Show("Esse registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Treatment = _Crm.Treatments.Single(Function(x) x.Order = Order)
                _Crm.Treatments.Remove(Treatment)
                WebTreatments.Navigate(_Crm.GetHtml(TxtFilterTreatment.Text))
                BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class