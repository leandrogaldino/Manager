Imports ControlLibrary
Imports ControlLibrary.Utility
Imports MySql.Data.MySqlClient
Public Class FrmUser
    Private _User As User
    Private _UsersForm As FrmUsers
    Private _UsersGrid As DataGridView
    Private _Filter As UserFilter
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(User As User, UsersForm As FrmUsers)
        _User = User
        _UsersForm = UsersForm
        _UsersGrid = _UsersForm.DgvData
        _Filter = CType(_UsersForm.PgFilter.SelectedObject, UserFilter)
        InitializeComponent()
        LoadData()
        LoadForm()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvEmailLayout.Load()
    End Sub
    Private Sub LoadForm()
        Utility.EnableDataGridViewDoubleBuffer(DgvEmail, True)
        DgvNavigator.DataGridView = _UsersGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnRequestPassword.Visible = Locator.GetInstance(Of Session).User.Privilege.UserResetPassword
        BtnRequestPassword.ToolTipText = String.Format("Resetar Senha ({0})", Locator.GetInstance(Of Session).Setting.General.User.DefaultPassword)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralLogAccess
    End Sub
    Private Sub LoadData()
        _Loading = True
        User.FillTreeViewNodes(TvwPrivilege)
        LblIDValue.Text = _User.ID
        BtnStatusValue.Text = GetEnumDescription(_User.Status)
        LblCreationValue.Text = _User.Creation.ToString("dd/MM/yyyy")
        TxtUsername.Text = _User.Username
        QbxPerson.Unfreeze()
        QbxPerson.Freeze(_User.Person.Value.ID)
        TxtNote.Text = _User.Note
        TxtFilterEmail.Clear()
        If _User.Emails IsNot Nothing Then _User.Emails.FillDataGridView(DgvEmail)
        BtnDelete.Enabled = _User.ID > 0 And Locator.GetInstance(Of Session).User.Privilege.UserDelete
        TvwPrivilege.Nodes.Find("PersonAccess", True)(0).Checked = _User.Privilege.PersonAccess
        TvwPrivilege.Nodes.Find("PersonWrite", True)(0).Checked = _User.Privilege.PersonWrite
        TvwPrivilege.Nodes.Find("PersonDelete", True)(0).Checked = _User.Privilege.PersonDelete
        TvwPrivilege.Nodes.Find("PersonChangeDocument", True)(0).Checked = _User.Privilege.PersonChangeDocument
        TvwPrivilege.Nodes.Find("PersonRegistration", True)(0).Checked = _User.Privilege.PersonRegistration
        TvwPrivilege.Nodes.Find("PersonMaintenancePlan", True)(0).Checked = _User.Privilege.PersonMaintenancePlan
        TvwPrivilege.Nodes.Find("CityAccess", True)(0).Checked = _User.Privilege.CityAccess
        TvwPrivilege.Nodes.Find("CityWrite", True)(0).Checked = _User.Privilege.CityWrite
        TvwPrivilege.Nodes.Find("CityDelete", True)(0).Checked = _User.Privilege.CityDelete
        TvwPrivilege.Nodes.Find("CompressorAccess", True)(0).Checked = _User.Privilege.CompressorAccess
        TvwPrivilege.Nodes.Find("CompressorWrite", True)(0).Checked = _User.Privilege.CompressorWrite
        TvwPrivilege.Nodes.Find("CompressorDelete", True)(0).Checked = _User.Privilege.CompressorDelete
        TvwPrivilege.Nodes.Find("RouteAccess", True)(0).Checked = _User.Privilege.RouteAccess
        TvwPrivilege.Nodes.Find("RouteWrite", True)(0).Checked = _User.Privilege.RouteWrite
        TvwPrivilege.Nodes.Find("RouteDelete", True)(0).Checked = _User.Privilege.RouteDelete
        TvwPrivilege.Nodes.Find("CrmAccess", True)(0).Checked = _User.Privilege.CrmAccess
        TvwPrivilege.Nodes.Find("CrmWrite", True)(0).Checked = _User.Privilege.CrmWrite
        TvwPrivilege.Nodes.Find("CrmDelete", True)(0).Checked = _User.Privilege.CrmDelete
        TvwPrivilege.Nodes.Find("CrmTreatmentDelete", True)(0).Checked = _User.Privilege.CrmTreatmentDelete
        TvwPrivilege.Nodes.Find("CrmTreatmentEdit", True)(0).Checked = _User.Privilege.CrmTreatmentEdit
        TvwPrivilege.Nodes.Find("CrmChangeCustomer", True)(0).Checked = _User.Privilege.CrmChangeCustomer
        TvwPrivilege.Nodes.Find("CrmChangeResponsible", True)(0).Checked = _User.Privilege.CrmChangeResponsible
        TvwPrivilege.Nodes.Find("CrmChangeSubject", True)(0).Checked = _User.Privilege.CrmChangeSubject
        TvwPrivilege.Nodes.Find("CrmChangeToPendingStatus", True)(0).Checked = _User.Privilege.CrmChangeToPendingStatus
        TvwPrivilege.Nodes.Find("ProductAccess", True)(0).Checked = _User.Privilege.ProductAccess
        TvwPrivilege.Nodes.Find("ProductWrite", True)(0).Checked = _User.Privilege.ProductWrite
        TvwPrivilege.Nodes.Find("ProductDelete", True)(0).Checked = _User.Privilege.ProductDelete
        TvwPrivilege.Nodes.Find("ProductFamilyAccess", True)(0).Checked = _User.Privilege.ProductFamilyAccess
        TvwPrivilege.Nodes.Find("ProductFamilyWrite", True)(0).Checked = _User.Privilege.ProductFamilyWrite
        TvwPrivilege.Nodes.Find("ProductFamilyDelete", True)(0).Checked = _User.Privilege.ProductFamilyDelete
        TvwPrivilege.Nodes.Find("ProductGroupAccess", True)(0).Checked = _User.Privilege.ProductGroupAccess
        TvwPrivilege.Nodes.Find("ProductGroupWrite", True)(0).Checked = _User.Privilege.ProductGroupWrite
        TvwPrivilege.Nodes.Find("ProductGroupDelete", True)(0).Checked = _User.Privilege.ProductGroupDelete
        TvwPrivilege.Nodes.Find("ProductPriceTableAccess", True)(0).Checked = _User.Privilege.ProductPriceTableAccess
        TvwPrivilege.Nodes.Find("ProductPriceTableWrite", True)(0).Checked = _User.Privilege.ProductPriceTableWrite
        TvwPrivilege.Nodes.Find("ProductPriceTableDelete", True)(0).Checked = _User.Privilege.ProductPriceTableDelete
        TvwPrivilege.Nodes.Find("ProductUnitAccess", True)(0).Checked = _User.Privilege.ProductUnitAccess
        TvwPrivilege.Nodes.Find("ProductUnitWrite", True)(0).Checked = _User.Privilege.ProductUnitWrite
        TvwPrivilege.Nodes.Find("ProductUnitDelete", True)(0).Checked = _User.Privilege.ProductUnitDelete
        TvwPrivilege.Nodes.Find("EvaluationAccess", True)(0).Checked = _User.Privilege.EvaluationAccess
        TvwPrivilege.Nodes.Find("EvaluationWrite", True)(0).Checked = _User.Privilege.EvaluationWrite
        TvwPrivilege.Nodes.Find("EvaluationDelete", True)(0).Checked = _User.Privilege.EvaluationDelete
        TvwPrivilege.Nodes.Find("EvaluationManagementAccess", True)(0).Checked = _User.Privilege.EvaluationManagementAccess
        TvwPrivilege.Nodes.Find("EvaluationManagementPanelAccess", True)(0).Checked = _User.Privilege.EvaluationManagementPanelAccess
        TvwPrivilege.Nodes.Find("EvaluationApproveOrReject", True)(0).Checked = _User.Privilege.EvaluationApproveOrReject
        TvwPrivilege.Nodes.Find("CashAccess", True)(0).Checked = _User.Privilege.CashAccess
        TvwPrivilege.Nodes.Find("CashWrite", True)(0).Checked = _User.Privilege.CashWrite
        TvwPrivilege.Nodes.Find("CashDelete", True)(0).Checked = _User.Privilege.CashDelete
        TvwPrivilege.Nodes.Find("CashFlowAccess", True)(0).Checked = _User.Privilege.CashFlowAccess
        TvwPrivilege.Nodes.Find("CashFlowWrite", True)(0).Checked = _User.Privilege.CashFlowWrite
        TvwPrivilege.Nodes.Find("CashFlowDelete", True)(0).Checked = _User.Privilege.CashFlowDelete
        TvwPrivilege.Nodes.Find("CashExpensesPerResponsible", True)(0).Checked = _User.Privilege.CashExpensesPerResponsible
        TvwPrivilege.Nodes.Find("CashReopen", True)(0).Checked = _User.Privilege.CashReopen
        TvwPrivilege.Nodes.Find("RequestAccess", True)(0).Checked = _User.Privilege.RequestAccess
        TvwPrivilege.Nodes.Find("RequestWrite", True)(0).Checked = _User.Privilege.RequestWrite
        TvwPrivilege.Nodes.Find("RequestDelete", True)(0).Checked = _User.Privilege.RequestDelete
        TvwPrivilege.Nodes.Find("RequestPendingItems", True)(0).Checked = _User.Privilege.RequestPendingItems
        TvwPrivilege.Nodes.Find("RequestSheet", True)(0).Checked = _User.Privilege.RequestSheet
        TvwPrivilege.Nodes.Find("UserAccess", True)(0).Checked = _User.Privilege.UserAccess
        TvwPrivilege.Nodes.Find("UserWrite", True)(0).Checked = _User.Privilege.UserWrite
        TvwPrivilege.Nodes.Find("UserDelete", True)(0).Checked = _User.Privilege.UserDelete
        TvwPrivilege.Nodes.Find("UserResetPassword", True)(0).Checked = _User.Privilege.UserResetPassword
        TvwPrivilege.Nodes.Find("UserPrivilegePresetAccess", True)(0).Checked = _User.Privilege.UserPrivilegePresetAccess
        TvwPrivilege.Nodes.Find("UserPrivilegePresetWrite", True)(0).Checked = _User.Privilege.UserPrivilegePresetWrite
        TvwPrivilege.Nodes.Find("UserPrivilegePresetDelete", True)(0).Checked = _User.Privilege.UserPrivilegePresetDelete
        TvwPrivilege.Nodes.Find("SeveralExportGrid", True)(0).Checked = _User.Privilege.SeveralExportGrid
        TvwPrivilege.Nodes.Find("SeveralLogAccess", True)(0).Checked = _User.Privilege.SeveralLogAccess
        Text = "Usuário"
        If _User.LockInfo.IsLocked And Not _User.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _User.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_User.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtUsername.Select()
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then
                    DgvNavigator.CancelNextMove = True
                End If
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            _User.Load(_UsersGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO US001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
        If _UsersForm IsNot Nothing Then
            _User.Emails.FillDataGridView(DgvEmail)
        End If
        _Deleting = False
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _User = New User
        LoadData()
    End Sub
    Private Sub TcUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcUser.SelectedIndexChanged
        If TcUser.SelectedTab Is TabMain Then
            Size = New Size(478, 230)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
        ElseIf TcUser.SelectedTab Is TabPrivilege Then
            Size = New Size(330, 500)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _User.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _User.LockInfo.IsLocked Or (_User.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _User.LockInfo.SessionToken) Then
                        _User.Delete()
                        If _UsersGrid IsNot Nothing Then
                            _Filter.Filter()
                            _UsersForm.DgvUserLayout.Load()
                            _UsersGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_User.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO US002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.User, _User.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive)
            If _User.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
            If _User.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged,
                                                                         QbxPerson.TextChanged,
                                                                         TxtNote.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtNote_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TxtNote.LinkClicked
        Process.Start(e.LinkText)
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Insert And e.Control Then
            If BtnInclude.Enabled Then BtnInclude.PerformClick()
        ElseIf e.KeyCode = Keys.Delete And e.Control Then
            If BtnDelete.Enabled Then BtnDelete.PerformClick()
        ElseIf e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
        End If
    End Sub
    Private Sub TlpPrivileges_CellPaint(sender As Object, e As TableLayoutCellPaintEventArgs)
        e.Graphics.DrawRectangle(New Pen(Color.Gray), e.CellBounds)
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If _User.ID = Locator.GetInstance(Of Session).User.ID Then
            If CMessageBox.Show("Você está alterando seu próprio usuário, para que isso seja feito com segurança você será deslogado do sistema após a operação. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Save()
                FrmMain.Dispose()
                FrmLogin.Show()
            End If
        Else
            Save()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtUsername.Text) Then
            TcUser.SelectedTab = TabMain
            EprValidation.SetError(LblUsername, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblUsername, ErrorIconAlignment.MiddleRight)
            TxtUsername.Select()
            Return False
        ElseIf Not QbxPerson.IsFreezed Then
            TcUser.SelectedTab = TabMain
            EprValidation.SetError(LblPerson, "É obrigatório vincular uma pessoa.")
            EprValidation.SetIconAlignment(LblPerson, ErrorIconAlignment.MiddleRight)
            QbxPerson.Select()
            Return False
        ElseIf QbxPerson.IsFreezed And User.HasPerson(QbxPerson.FreezedPrimaryKey) And _User.ID = 0 Then
            TcUser.SelectedTab = TabMain
            EprValidation.SetError(LblPerson, "Essa pessoa já foi vinculada a um usuário.")
            EprValidation.SetIconAlignment(LblPerson, ErrorIconAlignment.MiddleRight)
            QbxPerson.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtUsername.Text = RemoveAccents(TxtUsername.Text.Trim)
        TxtNote.Text = RemoveAccents(TxtNote.Text.ToUpper)
        If _User.LockInfo.IsLocked And _User.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_User.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _User.Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _User.Username = TxtUsername.Text
                    _User.Person = New Lazy(Of Person)(Function() New Person().Load(QbxPerson.FreezedPrimaryKey, False))
                    _User.Note = TxtNote.Text
                    _User.Privilege.PersonAccess = TvwPrivilege.Nodes.Find("PersonAccess", True)(0).Checked
                    _User.Privilege.PersonWrite = TvwPrivilege.Nodes.Find("PersonWrite", True)(0).Checked
                    _User.Privilege.PersonDelete = TvwPrivilege.Nodes.Find("PersonDelete", True)(0).Checked
                    _User.Privilege.PersonChangeDocument = TvwPrivilege.Nodes.Find("PersonChangeDocument", True)(0).Checked
                    _User.Privilege.PersonRegistration = TvwPrivilege.Nodes.Find("PersonRegistration", True)(0).Checked
                    _User.Privilege.PersonMaintenancePlan = TvwPrivilege.Nodes.Find("PersonMaintenancePlan", True)(0).Checked
                    _User.Privilege.CityAccess = TvwPrivilege.Nodes.Find("CityAccess", True)(0).Checked
                    _User.Privilege.CityWrite = TvwPrivilege.Nodes.Find("CityWrite", True)(0).Checked
                    _User.Privilege.CityDelete = TvwPrivilege.Nodes.Find("CityDelete", True)(0).Checked
                    _User.Privilege.CompressorAccess = TvwPrivilege.Nodes.Find("CompressorAccess", True)(0).Checked
                    _User.Privilege.CompressorWrite = TvwPrivilege.Nodes.Find("CompressorWrite", True)(0).Checked
                    _User.Privilege.CompressorDelete = TvwPrivilege.Nodes.Find("CompressorDelete", True)(0).Checked
                    _User.Privilege.RouteAccess = TvwPrivilege.Nodes.Find("RouteAccess", True)(0).Checked
                    _User.Privilege.RouteWrite = TvwPrivilege.Nodes.Find("RouteWrite", True)(0).Checked
                    _User.Privilege.RouteDelete = TvwPrivilege.Nodes.Find("RouteDelete", True)(0).Checked
                    _User.Privilege.CrmAccess = TvwPrivilege.Nodes.Find("CrmAccess", True)(0).Checked
                    _User.Privilege.CrmWrite = TvwPrivilege.Nodes.Find("CrmWrite", True)(0).Checked
                    _User.Privilege.CrmDelete = TvwPrivilege.Nodes.Find("CrmDelete", True)(0).Checked
                    _User.Privilege.CrmTreatmentDelete = TvwPrivilege.Nodes.Find("CrmTreatmentDelete", True)(0).Checked
                    _User.Privilege.CrmTreatmentEdit = TvwPrivilege.Nodes.Find("CrmTreatmentEdit", True)(0).Checked
                    _User.Privilege.CrmChangeCustomer = TvwPrivilege.Nodes.Find("CrmChangeCustomer", True)(0).Checked
                    _User.Privilege.CrmChangeResponsible = TvwPrivilege.Nodes.Find("CrmChangeResponsible", True)(0).Checked
                    _User.Privilege.CrmChangeSubject = TvwPrivilege.Nodes.Find("CrmChangeSubject", True)(0).Checked
                    _User.Privilege.CrmChangeToPendingStatus = TvwPrivilege.Nodes.Find("CrmChangeToPendingStatus", True)(0).Checked
                    _User.Privilege.ProductAccess = TvwPrivilege.Nodes.Find("ProductAccess", True)(0).Checked
                    _User.Privilege.ProductWrite = TvwPrivilege.Nodes.Find("ProductWrite", True)(0).Checked
                    _User.Privilege.ProductDelete = TvwPrivilege.Nodes.Find("ProductDelete", True)(0).Checked
                    _User.Privilege.ProductFamilyAccess = TvwPrivilege.Nodes.Find("ProductFamilyAccess", True)(0).Checked
                    _User.Privilege.ProductFamilyWrite = TvwPrivilege.Nodes.Find("ProductFamilyWrite", True)(0).Checked
                    _User.Privilege.ProductFamilyDelete = TvwPrivilege.Nodes.Find("ProductFamilyDelete", True)(0).Checked
                    _User.Privilege.ProductGroupAccess = TvwPrivilege.Nodes.Find("ProductGroupAccess", True)(0).Checked
                    _User.Privilege.ProductGroupWrite = TvwPrivilege.Nodes.Find("ProductGroupWrite", True)(0).Checked
                    _User.Privilege.ProductGroupDelete = TvwPrivilege.Nodes.Find("ProductGroupDelete", True)(0).Checked
                    _User.Privilege.ProductPriceTableAccess = TvwPrivilege.Nodes.Find("ProductPriceTableAccess", True)(0).Checked
                    _User.Privilege.ProductPriceTableWrite = TvwPrivilege.Nodes.Find("ProductPriceTableWrite", True)(0).Checked
                    _User.Privilege.ProductPriceTableDelete = TvwPrivilege.Nodes.Find("ProductPriceTableDelete", True)(0).Checked
                    _User.Privilege.ProductUnitAccess = TvwPrivilege.Nodes.Find("ProductUnitAccess", True)(0).Checked
                    _User.Privilege.ProductUnitWrite = TvwPrivilege.Nodes.Find("ProductUnitWrite", True)(0).Checked
                    _User.Privilege.ProductUnitDelete = TvwPrivilege.Nodes.Find("ProductUnitDelete", True)(0).Checked
                    _User.Privilege.EvaluationAccess = TvwPrivilege.Nodes.Find("EvaluationAccess", True)(0).Checked
                    _User.Privilege.EvaluationWrite = TvwPrivilege.Nodes.Find("EvaluationWrite", True)(0).Checked
                    _User.Privilege.EvaluationDelete = TvwPrivilege.Nodes.Find("EvaluationDelete", True)(0).Checked
                    _User.Privilege.EvaluationManagementAccess = TvwPrivilege.Nodes.Find("EvaluationManagementAccess", True)(0).Checked
                    _User.Privilege.EvaluationManagementPanelAccess = TvwPrivilege.Nodes.Find("EvaluationManagementPanelAccess", True)(0).Checked
                    _User.Privilege.EvaluationApproveOrReject = TvwPrivilege.Nodes.Find("EvaluationApproveOrReject", True)(0).Checked
                    _User.Privilege.CashAccess = TvwPrivilege.Nodes.Find("CashAccess", True)(0).Checked
                    _User.Privilege.CashWrite = TvwPrivilege.Nodes.Find("CashWrite", True)(0).Checked
                    _User.Privilege.CashDelete = TvwPrivilege.Nodes.Find("CashDelete", True)(0).Checked
                    _User.Privilege.CashFlowAccess = TvwPrivilege.Nodes.Find("CashFlowAccess", True)(0).Checked
                    _User.Privilege.CashFlowWrite = TvwPrivilege.Nodes.Find("CashFlowWrite", True)(0).Checked
                    _User.Privilege.CashFlowDelete = TvwPrivilege.Nodes.Find("CashFlowDelete", True)(0).Checked
                    _User.Privilege.CashExpensesPerResponsible = TvwPrivilege.Nodes.Find("CashExpensesPerResponsible", True)(0).Checked
                    _User.Privilege.CashReopen = TvwPrivilege.Nodes.Find("CashReopen", True)(0).Checked
                    _User.Privilege.RequestAccess = TvwPrivilege.Nodes.Find("RequestAccess", True)(0).Checked
                    _User.Privilege.RequestWrite = TvwPrivilege.Nodes.Find("RequestWrite", True)(0).Checked
                    _User.Privilege.RequestDelete = TvwPrivilege.Nodes.Find("RequestDelete", True)(0).Checked
                    _User.Privilege.RequestPendingItems = TvwPrivilege.Nodes.Find("RequestPendingItems", True)(0).Checked
                    _User.Privilege.RequestSheet = TvwPrivilege.Nodes.Find("RequestSheet", True)(0).Checked
                    _User.Privilege.UserAccess = TvwPrivilege.Nodes.Find("UserAccess", True)(0).Checked
                    _User.Privilege.UserWrite = TvwPrivilege.Nodes.Find("UserWrite", True)(0).Checked
                    _User.Privilege.UserDelete = TvwPrivilege.Nodes.Find("UserDelete", True)(0).Checked
                    _User.Privilege.UserResetPassword = TvwPrivilege.Nodes.Find("UserResetPassword", True)(0).Checked
                    _User.Privilege.UserPrivilegePresetAccess = TvwPrivilege.Nodes.Find("UserPrivilegePresetAccess", True)(0).Checked
                    _User.Privilege.UserPrivilegePresetWrite = TvwPrivilege.Nodes.Find("UserPrivilegePresetWrite", True)(0).Checked
                    _User.Privilege.UserPrivilegePresetDelete = TvwPrivilege.Nodes.Find("UserPrivilegePresetDelete", True)(0).Checked
                    _User.Privilege.SeveralExportGrid = TvwPrivilege.Nodes.Find("SeveralExportGrid", True)(0).Checked
                    _User.Privilege.SeveralLogAccess = TvwPrivilege.Nodes.Find("SeveralLogAccess", True)(0).Checked
                    _User.SaveChanges()
                    _User.Lock()
                    LblIDValue.Text = _User.ID
                    _User.Emails.FillDataGridView(DgvEmail)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = Locator.GetInstance(Of Session).User.Privilege.UserDelete
                    If _UsersForm IsNot Nothing Then
                        _Filter.Filter()
                        _UsersForm.DgvUserLayout.Load()
                        Row = _UsersGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe um usuário cadastrado com esse nome de usuário.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO US003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub BtnRequestPassword_Click(sender As Object, e As EventArgs) Handles BtnRequestPassword.Click
        If CMessageBox.Show(String.Format("A senha desse usuário será redefinida para a senha padrão '{0}'. Deseja continuar?", Locator.GetInstance(Of Session).Setting.General.User.DefaultPassword), CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                _User.ResetPassword()
            Catch ex As Exception
                CMessageBox.Show("ERRO US004", "Ocorreu um erro redefinir a senha.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            End Try
        End If
    End Sub
    Private Sub TvwPrivilege_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TvwPrivilege.AfterSelect
        LblDescription.Text = e.Node.Tag.ToString
    End Sub
    Private Sub TvwPrivilege_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvwPrivilege.AfterCheck
        If e.Node.Parent IsNot Nothing Then
            If e.Node.Checked Then
                e.Node.Parent.Checked = True
            End If
        End If
        If e.Node.Checked = False Then
            For Each n As TreeNode In e.Node.Nodes
                n.Checked = False
            Next n
        End If
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnImportPrivilege_Click(sender As Object, e As EventArgs) Handles BtnImportPrivilege.Click
        Dim FormImport As FrmUserImportPrivilege
        Dim Preset As UserPrivilegePreset
        FormImport = New FrmUserImportPrivilege
        If FormImport.ShowDialog = DialogResult.OK Then
            If CMessageBox.Show("Importar uma predefinição fará com que todas as permissões fiquem idênticas a ela. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                TcUser.SelectedTab = TabPrivilege
                Preset = New UserPrivilegePreset().Load(FormImport.QbxPreset.FreezedPrimaryKey, False)
                TvwPrivilege.Nodes.Clear()
                User.FillTreeViewNodes(TvwPrivilege)
                TvwPrivilege.Nodes.Find("PersonAccess", True)(0).Checked = Preset.Privilege.PersonAccess
                TvwPrivilege.Nodes.Find("PersonWrite", True)(0).Checked = Preset.Privilege.PersonWrite
                TvwPrivilege.Nodes.Find("PersonDelete", True)(0).Checked = Preset.Privilege.PersonDelete
                TvwPrivilege.Nodes.Find("PersonChangeDocument", True)(0).Checked = Preset.Privilege.PersonChangeDocument
                TvwPrivilege.Nodes.Find("PersonRegistration", True)(0).Checked = Preset.Privilege.PersonRegistration
                TvwPrivilege.Nodes.Find("PersonMaintenancePlan", True)(0).Checked = Preset.Privilege.PersonMaintenancePlan
                TvwPrivilege.Nodes.Find("CityAccess", True)(0).Checked = Preset.Privilege.CityAccess
                TvwPrivilege.Nodes.Find("CityWrite", True)(0).Checked = Preset.Privilege.CityWrite
                TvwPrivilege.Nodes.Find("CityDelete", True)(0).Checked = Preset.Privilege.CityDelete
                TvwPrivilege.Nodes.Find("CompressorAccess", True)(0).Checked = Preset.Privilege.CompressorAccess
                TvwPrivilege.Nodes.Find("CompressorWrite", True)(0).Checked = Preset.Privilege.CompressorWrite
                TvwPrivilege.Nodes.Find("CompressorDelete", True)(0).Checked = Preset.Privilege.CompressorDelete
                TvwPrivilege.Nodes.Find("RouteAccess", True)(0).Checked = Preset.Privilege.RouteAccess
                TvwPrivilege.Nodes.Find("RouteWrite", True)(0).Checked = Preset.Privilege.RouteWrite
                TvwPrivilege.Nodes.Find("RouteDelete", True)(0).Checked = Preset.Privilege.RouteDelete
                TvwPrivilege.Nodes.Find("CrmAccess", True)(0).Checked = Preset.Privilege.CrmAccess
                TvwPrivilege.Nodes.Find("CrmWrite", True)(0).Checked = Preset.Privilege.CrmWrite
                TvwPrivilege.Nodes.Find("CrmDelete", True)(0).Checked = _User.Privilege.CrmDelete
                TvwPrivilege.Nodes.Find("CrmTreatmentDelete", True)(0).Checked = _User.Privilege.CrmTreatmentDelete
                TvwPrivilege.Nodes.Find("CrmTreatmentEdit", True)(0).Checked = _User.Privilege.CrmTreatmentEdit
                TvwPrivilege.Nodes.Find("CrmChangeCustomer", True)(0).Checked = _User.Privilege.CrmChangeCustomer
                TvwPrivilege.Nodes.Find("CrmChangeResponsible", True)(0).Checked = _User.Privilege.CrmChangeResponsible
                TvwPrivilege.Nodes.Find("CrmChangeSubject", True)(0).Checked = _User.Privilege.CrmChangeSubject
                TvwPrivilege.Nodes.Find("CrmChangeToPendingStatus", True)(0).Checked = _User.Privilege.CrmChangeToPendingStatus
                TvwPrivilege.Nodes.Find("ProductAccess", True)(0).Checked = Preset.Privilege.ProductAccess
                TvwPrivilege.Nodes.Find("ProductWrite", True)(0).Checked = Preset.Privilege.ProductWrite
                TvwPrivilege.Nodes.Find("ProductDelete", True)(0).Checked = Preset.Privilege.ProductDelete
                TvwPrivilege.Nodes.Find("ProductFamilyAccess", True)(0).Checked = Preset.Privilege.ProductFamilyAccess
                TvwPrivilege.Nodes.Find("ProductFamilyWrite", True)(0).Checked = Preset.Privilege.ProductFamilyWrite
                TvwPrivilege.Nodes.Find("ProductFamilyDelete", True)(0).Checked = Preset.Privilege.ProductFamilyDelete
                TvwPrivilege.Nodes.Find("ProductGroupAccess", True)(0).Checked = Preset.Privilege.ProductGroupAccess
                TvwPrivilege.Nodes.Find("ProductGroupWrite", True)(0).Checked = Preset.Privilege.ProductGroupWrite
                TvwPrivilege.Nodes.Find("ProductGroupDelete", True)(0).Checked = Preset.Privilege.ProductGroupDelete
                TvwPrivilege.Nodes.Find("ProductPriceTableAccess", True)(0).Checked = Preset.Privilege.ProductPriceTableAccess
                TvwPrivilege.Nodes.Find("ProductPriceTableWrite", True)(0).Checked = Preset.Privilege.ProductPriceTableWrite
                TvwPrivilege.Nodes.Find("ProductPriceTableDelete", True)(0).Checked = Preset.Privilege.ProductPriceTableDelete
                TvwPrivilege.Nodes.Find("ProductUnitAccess", True)(0).Checked = Preset.Privilege.ProductUnitAccess
                TvwPrivilege.Nodes.Find("ProductUnitWrite", True)(0).Checked = Preset.Privilege.ProductUnitWrite
                TvwPrivilege.Nodes.Find("ProductUnitDelete", True)(0).Checked = Preset.Privilege.ProductUnitDelete
                TvwPrivilege.Nodes.Find("EvaluationAccess", True)(0).Checked = Preset.Privilege.EvaluationAccess
                TvwPrivilege.Nodes.Find("EvaluationWrite", True)(0).Checked = Preset.Privilege.EvaluationWrite
                TvwPrivilege.Nodes.Find("EvaluationDelete", True)(0).Checked = Preset.Privilege.EvaluationDelete
                TvwPrivilege.Nodes.Find("EvaluationManagementAccess", True)(0).Checked = Preset.Privilege.EvaluationManagementAccess
                TvwPrivilege.Nodes.Find("EvaluationManagementPanelAccess", True)(0).Checked = Preset.Privilege.EvaluationManagementPanelAccess
                TvwPrivilege.Nodes.Find("EvaluationApproveOrReject", True)(0).Checked = Preset.Privilege.EvaluationApproveOrReject
                TvwPrivilege.Nodes.Find("CashAccess", True)(0).Checked = Preset.Privilege.CashAccess
                TvwPrivilege.Nodes.Find("CashWrite", True)(0).Checked = Preset.Privilege.CashWrite
                TvwPrivilege.Nodes.Find("CashDelete", True)(0).Checked = Preset.Privilege.CashDelete
                TvwPrivilege.Nodes.Find("CashFlowAccess", True)(0).Checked = Preset.Privilege.CashFlowAccess
                TvwPrivilege.Nodes.Find("CashFlowWrite", True)(0).Checked = Preset.Privilege.CashFlowWrite
                TvwPrivilege.Nodes.Find("CashFlowDelete", True)(0).Checked = Preset.Privilege.CashFlowDelete
                TvwPrivilege.Nodes.Find("CashExpensesPerResponsible", True)(0).Checked = Preset.Privilege.CashExpensesPerResponsible
                TvwPrivilege.Nodes.Find("CashReopen", True)(0).Checked = Preset.Privilege.CashReopen
                TvwPrivilege.Nodes.Find("RequestAccess", True)(0).Checked = Preset.Privilege.RequestAccess
                TvwPrivilege.Nodes.Find("RequestWrite", True)(0).Checked = Preset.Privilege.RequestWrite
                TvwPrivilege.Nodes.Find("RequestDelete", True)(0).Checked = Preset.Privilege.RequestDelete
                TvwPrivilege.Nodes.Find("RequestPendingItems", True)(0).Checked = Preset.Privilege.RequestPendingItems
                TvwPrivilege.Nodes.Find("RequestSheet", True)(0).Checked = Preset.Privilege.RequestSheet
                TvwPrivilege.Nodes.Find("UserAccess", True)(0).Checked = Preset.Privilege.UserAccess
                TvwPrivilege.Nodes.Find("UserWrite", True)(0).Checked = Preset.Privilege.UserWrite
                TvwPrivilege.Nodes.Find("UserDelete", True)(0).Checked = Preset.Privilege.UserDelete
                TvwPrivilege.Nodes.Find("UserResetPassword", True)(0).Checked = Preset.Privilege.UserResetPassword
                TvwPrivilege.Nodes.Find("UserPrivilegePresetAccess", True)(0).Checked = Preset.Privilege.UserPrivilegePresetAccess
                TvwPrivilege.Nodes.Find("UserPrivilegePresetWrite", True)(0).Checked = Preset.Privilege.UserPrivilegePresetWrite
                TvwPrivilege.Nodes.Find("UserPrivilegePresetDelete", True)(0).Checked = Preset.Privilege.UserPrivilegePresetDelete
                TvwPrivilege.Nodes.Find("SeveralExportGrid", True)(0).Checked = Preset.Privilege.SeveralExportGrid
                TvwPrivilege.Nodes.Find("SeveralLogAccess", True)(0).Checked = Preset.Privilege.SeveralLogAccess
            End If
        End If
        FormImport.Dispose()
    End Sub
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxPerson_Enter(sender As Object, e As EventArgs) Handles QbxPerson.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxPerson.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnNew.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnFilter.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonAccess
    End Sub
    Private Sub QbxPerson_Leave(sender As Object, e As EventArgs) Handles QbxPerson.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxPerson_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPerson.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxPerson.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.PersonWrite
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Person As Person
        Dim Form As FrmPerson
        Person = New Person
        Person.IsEmployee = True
        Form = New FrmPerson(Person)
        Form.CbxIsEmployee.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Person.ID > 0 Then
            QbxPerson.Freeze(Person.ID)
        End If
        QbxPerson.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Form As New FrmPerson(New Person().Load(QbxPerson.FreezedPrimaryKey, True))
        Form.CbxIsEmployee.Enabled = False
        Form.ShowDialog()
        QbxPerson.Freeze(QbxPerson.FreezedPrimaryKey)
        QbxPerson.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonEmployeeQueriedBoxFilter(), QbxPerson)
        FilterForm.Text = "Filtro de Funcionários"
        FilterForm.ShowDialog()
        QbxPerson.Select()
    End Sub


    Private Sub BtnIncludeEmail_Click(sender As Object, e As EventArgs) Handles BtnIncludeEmail.Click
        Dim Form As New FrmUserEmail(_User, New UserEmail, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditEmail_Click(sender As Object, e As EventArgs) Handles BtnEditEmail.Click
        Dim Form As FrmUserEmail
        Dim Email As UserEmail
        If DgvEmail.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            Email = _User.Emails.Single(Function(x) x.Order = DgvEmail.SelectedRows(0).Cells("Order").Value)
            Form = New FrmUserEmail(_User, Email, Me)
            Form.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub BtnDeleteEmail_Click(sender As Object, e As EventArgs) Handles BtnDeleteEmail.Click
        Dim Email As UserEmail
        If DgvEmail.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Email = _User.Emails.Single(Function(x) x.Order = DgvEmail.SelectedRows(0).Cells("Order").Value)
                _User.Emails.Remove(Email)
                _User.Emails.FillDataGridView(DgvEmail)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DgvEmail_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvEmail.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvEmail.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditEmail.PerformClick()
        End If
    End Sub

    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterEmail.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}

        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilter_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterEmail.TextChanged
        FilterEmail()
    End Sub
    Private Sub FilterEmail()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1}",
                                                 "Email LIKE '%@VALUE%'",
                                                 "SmtpServer LIKE '%@VALUE%'"
                                            )
        If DgvEmail.DataSource IsNot Nothing Then
            Table = DgvEmail.DataSource
            View = Table.DefaultView
            If TxtFilterEmail.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterEmail.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub FrmUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _User.Unlock()
    End Sub

    Private Sub DgvEmail_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvEmail.DataSourceChanged
        FilterEmail()
    End Sub
    Private Sub DgvEmail_SelectionChanged(sender As Object, e As EventArgs) Handles DgvEmail.SelectionChanged
        If DgvEmail.SelectedRows.Count = 0 Then
            BtnEditEmail.Enabled = False
            BtnDeleteEmail.Enabled = False
        Else
            BtnEditEmail.Enabled = True
            BtnDeleteEmail.Enabled = True
        End If
    End Sub
End Class