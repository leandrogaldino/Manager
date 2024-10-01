Imports ControlLibrary
Imports ControlLibrary.Utility
Imports MySql.Data.MySqlClient
Public Class FrmUserPrivilegePreset
    Private _UserPrivilegePreset As UserPrivilegePreset
    Private _UserPrivilegePresetsForm As FrmUserPrivilegePresets
    Private _UserPrivilegePresetsGrid As DataGridView
    Private _Filter As UserPrivilegePresetFilter
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
    Public Sub New(UserPrivilegePreset As UserPrivilegePreset, UserPrivilegePresetsForm As FrmUserPrivilegePresets)
        _UserPrivilegePreset = UserPrivilegePreset
        _UserPrivilegePresetsForm = UserPrivilegePresetsForm
        _UserPrivilegePresetsGrid = _UserPrivilegePresetsForm.DgvData
        _Filter = CType(_UserPrivilegePresetsForm.PgFilter.SelectedObject, UserPrivilegePresetFilter)
        InitializeComponent()
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(UserPrivilegePreset As UserPrivilegePreset)
        _UserPrivilegePreset = UserPrivilegePreset
        InitializeComponent()
        Height -= TsNavigation.Height
        LblName.Top -= TsNavigation.Height
        TxtName.Top -= TsNavigation.Height
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        LoadData()
        LoadForm()
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _UserPrivilegePresetsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralLogAccess
    End Sub
    Private Sub LoadData()
        User.FillTreeViewNodes(TvwPrivilege)
        _Loading = True
        LblIDValue.Text = _UserPrivilegePreset.ID
        BtnStatusValue.Text = GetEnumDescription(_UserPrivilegePreset.Status)
        LblCreationValue.Text = _UserPrivilegePreset.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _UserPrivilegePreset.Name
        BtnDelete.Enabled = _UserPrivilegePreset.ID > 0 And Locator.GetInstance(Of Session).User.Privilege.UserPrivilegePresetDelete
        TvwPrivilege.Nodes.Find("PersonAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.PersonAccess
        TvwPrivilege.Nodes.Find("PersonWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.PersonWrite
        TvwPrivilege.Nodes.Find("PersonDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.PersonDelete
        TvwPrivilege.Nodes.Find("PersonChangeDocument", True)(0).Checked = _UserPrivilegePreset.Privilege.PersonChangeDocument
        TvwPrivilege.Nodes.Find("PersonRegistration", True)(0).Checked = _UserPrivilegePreset.Privilege.PersonRegistration
        TvwPrivilege.Nodes.Find("PersonMaintenancePlan", True)(0).Checked = _UserPrivilegePreset.Privilege.PersonMaintenancePlan
        TvwPrivilege.Nodes.Find("CityAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.CityAccess
        TvwPrivilege.Nodes.Find("CityWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.CityWrite
        TvwPrivilege.Nodes.Find("CityDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.CityDelete
        TvwPrivilege.Nodes.Find("CompressorAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.CompressorAccess
        TvwPrivilege.Nodes.Find("CompressorWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.CompressorWrite
        TvwPrivilege.Nodes.Find("CompressorDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.CompressorDelete
        TvwPrivilege.Nodes.Find("RouteAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.RouteAccess
        TvwPrivilege.Nodes.Find("RouteWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.RouteWrite
        TvwPrivilege.Nodes.Find("RouteDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.RouteDelete
        TvwPrivilege.Nodes.Find("CrmAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmAccess
        TvwPrivilege.Nodes.Find("CrmWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmWrite
        TvwPrivilege.Nodes.Find("CrmDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmDelete
        TvwPrivilege.Nodes.Find("CrmTreatmentDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmTreatmentDelete
        TvwPrivilege.Nodes.Find("CrmTreatmentEdit", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmTreatmentEdit
        TvwPrivilege.Nodes.Find("CrmChangeCustomer", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmChangeCustomer
        TvwPrivilege.Nodes.Find("CrmChangeResponsible", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmChangeResponsible
        TvwPrivilege.Nodes.Find("CrmChangeSubject", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmChangeSubject
        TvwPrivilege.Nodes.Find("CrmChangeToPendingStatus", True)(0).Checked = _UserPrivilegePreset.Privilege.CrmChangeToPendingStatus
        TvwPrivilege.Nodes.Find("ProductAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductAccess
        TvwPrivilege.Nodes.Find("ProductWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductWrite
        TvwPrivilege.Nodes.Find("ProductDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductDelete
        TvwPrivilege.Nodes.Find("ProductFamilyAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductFamilyAccess
        TvwPrivilege.Nodes.Find("ProductFamilyWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductFamilyWrite
        TvwPrivilege.Nodes.Find("ProductFamilyDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductFamilyDelete
        TvwPrivilege.Nodes.Find("ProductGroupAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductGroupAccess
        TvwPrivilege.Nodes.Find("ProductGroupWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductGroupWrite
        TvwPrivilege.Nodes.Find("ProductGroupDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductGroupDelete
        TvwPrivilege.Nodes.Find("ProductPriceTableAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductPriceTableAccess
        TvwPrivilege.Nodes.Find("ProductPriceTableWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductPriceTableWrite
        TvwPrivilege.Nodes.Find("ProductPriceTableDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductPriceTableDelete
        TvwPrivilege.Nodes.Find("ProductUnitAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductUnitAccess
        TvwPrivilege.Nodes.Find("ProductUnitWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductUnitWrite
        TvwPrivilege.Nodes.Find("ProductUnitDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.ProductUnitDelete
        TvwPrivilege.Nodes.Find("EvaluationAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.EvaluationAccess
        TvwPrivilege.Nodes.Find("EvaluationWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.EvaluationWrite
        TvwPrivilege.Nodes.Find("EvaluationDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.EvaluationDelete
        TvwPrivilege.Nodes.Find("EvaluationManagementAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.EvaluationManagementAccess
        TvwPrivilege.Nodes.Find("EvaluationManagementPanelAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.EvaluationManagementPanelAccess
        TvwPrivilege.Nodes.Find("EvaluationApproveOrReject", True)(0).Checked = _UserPrivilegePreset.Privilege.EvaluationApproveOrReject
        TvwPrivilege.Nodes.Find("CashAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.CashAccess
        TvwPrivilege.Nodes.Find("CashWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.CashWrite
        TvwPrivilege.Nodes.Find("CashDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.CashDelete
        TvwPrivilege.Nodes.Find("CashFlowAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.CashFlowAccess
        TvwPrivilege.Nodes.Find("CashFlowWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.CashFlowWrite
        TvwPrivilege.Nodes.Find("CashFlowDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.CashFlowDelete
        TvwPrivilege.Nodes.Find("CashExpensesPerResponsible", True)(0).Checked = _UserPrivilegePreset.Privilege.CashExpensesPerResponsible
        TvwPrivilege.Nodes.Find("CashReopen", True)(0).Checked = _UserPrivilegePreset.Privilege.CashReopen
        TvwPrivilege.Nodes.Find("RequestAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.RequestAccess
        TvwPrivilege.Nodes.Find("RequestWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.RequestWrite
        TvwPrivilege.Nodes.Find("RequestDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.RequestDelete
        TvwPrivilege.Nodes.Find("RequestPendingItems", True)(0).Checked = _UserPrivilegePreset.Privilege.RequestPendingItems
        TvwPrivilege.Nodes.Find("RequestSheet", True)(0).Checked = _UserPrivilegePreset.Privilege.RequestSheet
        TvwPrivilege.Nodes.Find("UserAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.UserAccess
        TvwPrivilege.Nodes.Find("UserWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.UserWrite
        TvwPrivilege.Nodes.Find("UserDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.UserDelete
        TvwPrivilege.Nodes.Find("UserResetPassword", True)(0).Checked = _UserPrivilegePreset.Privilege.UserResetPassword
        TvwPrivilege.Nodes.Find("UserPrivilegePresetAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.UserPrivilegePresetAccess
        TvwPrivilege.Nodes.Find("UserPrivilegePresetWrite", True)(0).Checked = _UserPrivilegePreset.Privilege.UserPrivilegePresetWrite
        TvwPrivilege.Nodes.Find("UserPrivilegePresetDelete", True)(0).Checked = _UserPrivilegePreset.Privilege.UserPrivilegePresetDelete
        TvwPrivilege.Nodes.Find("SeveralExportGrid", True)(0).Checked = _UserPrivilegePreset.Privilege.SeveralExportGrid
        TvwPrivilege.Nodes.Find("SeveralLogAccess", True)(0).Checked = _UserPrivilegePreset.Privilege.SeveralLogAccess
        Text = "Predefinição de Permissões"
        If _UserPrivilegePreset.LockInfo.IsLocked And Not _UserPrivilegePreset.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _UserPrivilegePreset.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_UserPrivilegePreset.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtName.Select()
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
            _UserPrivilegePreset.Load(_UserPrivilegePresetsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO UP001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If BtnSave.Enabled Then
                    If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        If Not Save() Then e.Cancel = True
                    End If
                End If
            End If
            _Deleting = False
        End If
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _UserPrivilegePreset = New UserPrivilegePreset
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _UserPrivilegePreset.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _UserPrivilegePreset.LockInfo.IsLocked Or (_UserPrivilegePreset.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _UserPrivilegePreset.LockInfo.SessionToken) Then
                        _UserPrivilegePreset.Delete()
                        If _UserPrivilegePresetsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _UserPrivilegePresetsForm.DgvUserPrivilegePresetLayout.Load()
                            _UserPrivilegePresetsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_UserPrivilegePreset.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                CMessageBox.Show("ERRO UP002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.UserPrivilegePreset, _UserPrivilegePreset.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive)
            If _UserPrivilegePreset.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
            If _UserPrivilegePreset.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TxtName.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = RemoveAccents(TxtName.Text.Trim)
        If _UserPrivilegePreset.LockInfo.IsLocked And _UserPrivilegePreset.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_UserPrivilegePreset.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                Try
                    _UserPrivilegePreset.Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _UserPrivilegePreset.Name = TxtName.Text
                    _UserPrivilegePreset.Privilege.PersonAccess = TvwPrivilege.Nodes.Find("PersonAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.PersonWrite = TvwPrivilege.Nodes.Find("PersonWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.PersonDelete = TvwPrivilege.Nodes.Find("PersonDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.PersonChangeDocument = TvwPrivilege.Nodes.Find("personchangedocument", True)(0).Checked
                    _UserPrivilegePreset.Privilege.PersonRegistration = TvwPrivilege.Nodes.Find("PersonRegistration", True)(0).Checked
                    _UserPrivilegePreset.Privilege.PersonMaintenancePlan = TvwPrivilege.Nodes.Find("PersonMaintenancePlan", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CityAccess = TvwPrivilege.Nodes.Find("CityAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CityWrite = TvwPrivilege.Nodes.Find("CityWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CityDelete = TvwPrivilege.Nodes.Find("CityDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CompressorAccess = TvwPrivilege.Nodes.Find("CompressorAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CompressorWrite = TvwPrivilege.Nodes.Find("CompressorWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CompressorDelete = TvwPrivilege.Nodes.Find("CompressorDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RouteAccess = TvwPrivilege.Nodes.Find("RouteAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RouteWrite = TvwPrivilege.Nodes.Find("RouteWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RouteDelete = TvwPrivilege.Nodes.Find("RouteDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmAccess = TvwPrivilege.Nodes.Find("CrmAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmWrite = TvwPrivilege.Nodes.Find("CrmWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmDelete = TvwPrivilege.Nodes.Find("CrmDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmTreatmentDelete = TvwPrivilege.Nodes.Find("CrmTreatmentDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmTreatmentEdit = TvwPrivilege.Nodes.Find("CrmTreatmentEdit", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmChangeCustomer = TvwPrivilege.Nodes.Find("CrmChangeCustomer", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmChangeResponsible = TvwPrivilege.Nodes.Find("CrmChangeResponsible", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmChangeSubject = TvwPrivilege.Nodes.Find("CrmChangeSubject", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CrmChangeToPendingStatus = TvwPrivilege.Nodes.Find("CrmChangeToPendingStatus", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductAccess = TvwPrivilege.Nodes.Find("ProductAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductWrite = TvwPrivilege.Nodes.Find("ProductWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductDelete = TvwPrivilege.Nodes.Find("ProductDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductFamilyAccess = TvwPrivilege.Nodes.Find("ProductFamilyAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductFamilyWrite = TvwPrivilege.Nodes.Find("ProductFamilyWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductFamilyDelete = TvwPrivilege.Nodes.Find("ProductFamilyDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductGroupAccess = TvwPrivilege.Nodes.Find("ProductGroupAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductGroupWrite = TvwPrivilege.Nodes.Find("ProductGroupWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductGroupDelete = TvwPrivilege.Nodes.Find("ProductGroupDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductPriceTableAccess = TvwPrivilege.Nodes.Find("ProductPriceTableAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductPriceTableWrite = TvwPrivilege.Nodes.Find("ProductPriceTableWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductPriceTableDelete = TvwPrivilege.Nodes.Find("ProductPriceTableDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductUnitAccess = TvwPrivilege.Nodes.Find("ProductUnitAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductUnitWrite = TvwPrivilege.Nodes.Find("ProductUnitWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.ProductUnitDelete = TvwPrivilege.Nodes.Find("ProductUnitDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.EvaluationAccess = TvwPrivilege.Nodes.Find("EvaluationAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.EvaluationWrite = TvwPrivilege.Nodes.Find("EvaluationWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.EvaluationDelete = TvwPrivilege.Nodes.Find("EvaluationDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.EvaluationManagementAccess = TvwPrivilege.Nodes.Find("EvaluationManagementAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.EvaluationManagementPanelAccess = TvwPrivilege.Nodes.Find("EvaluationManagementPanelAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.EvaluationApproveOrReject = TvwPrivilege.Nodes.Find("EvaluationApproveOrReject", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashAccess = TvwPrivilege.Nodes.Find("CashAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashWrite = TvwPrivilege.Nodes.Find("CashWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashDelete = TvwPrivilege.Nodes.Find("CashDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashFlowAccess = TvwPrivilege.Nodes.Find("CashFlowAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashFlowWrite = TvwPrivilege.Nodes.Find("CashFlowWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashFlowDelete = TvwPrivilege.Nodes.Find("CashFlowDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashExpensesPerResponsible = TvwPrivilege.Nodes.Find("CashExpensesPerResponsible", True)(0).Checked
                    _UserPrivilegePreset.Privilege.CashReopen = TvwPrivilege.Nodes.Find("CashReopen", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RequestAccess = TvwPrivilege.Nodes.Find("RequestAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RequestWrite = TvwPrivilege.Nodes.Find("RequestWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RequestDelete = TvwPrivilege.Nodes.Find("RequestDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RequestPendingItems = TvwPrivilege.Nodes.Find("RequestPendingItems", True)(0).Checked
                    _UserPrivilegePreset.Privilege.RequestSheet = TvwPrivilege.Nodes.Find("RequestSheet", True)(0).Checked
                    _UserPrivilegePreset.Privilege.UserAccess = TvwPrivilege.Nodes.Find("UserAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.UserWrite = TvwPrivilege.Nodes.Find("UserWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.UserDelete = TvwPrivilege.Nodes.Find("UserDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.UserResetPassword = TvwPrivilege.Nodes.Find("UserResetPassword", True)(0).Checked
                    _UserPrivilegePreset.Privilege.UserPrivilegePresetAccess = TvwPrivilege.Nodes.Find("UserPrivilegePresetAccess", True)(0).Checked
                    _UserPrivilegePreset.Privilege.UserPrivilegePresetWrite = TvwPrivilege.Nodes.Find("UserPrivilegePresetWrite", True)(0).Checked
                    _UserPrivilegePreset.Privilege.UserPrivilegePresetDelete = TvwPrivilege.Nodes.Find("UserPrivilegePresetDelete", True)(0).Checked
                    _UserPrivilegePreset.Privilege.SeveralExportGrid = TvwPrivilege.Nodes.Find("SeveralExportGrid", True)(0).Checked
                    _UserPrivilegePreset.Privilege.SeveralLogAccess = TvwPrivilege.Nodes.Find("SeveralLogAccess", True)(0).Checked
                    _UserPrivilegePreset.SaveChanges()
                    _UserPrivilegePreset.Lock()
                    LblIDValue.Text = _UserPrivilegePreset.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = Locator.GetInstance(Of Session).User.Privilege.UserPrivilegePresetDelete
                    If _UserPrivilegePresetsForm IsNot Nothing Then
                        _Filter.Filter()
                        _UserPrivilegePresetsForm.DgvUserPrivilegePresetLayout.Load()
                        Row = _UserPrivilegePresetsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma predefinição cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO UP003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Return False
                End Try
            Else
                Return False
            End If
        End If
    End Function
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
    Private Sub FrmUserPrivilegePreset_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _UserPrivilegePreset.Unlock()
    End Sub
End Class