Imports ControlLibrary
Imports ManagerCore
Public Class FrmMain
    Private _User As User
    Public Sub New()
        InitializeComponent()
        _User = Locator.GetInstance(Of Session).User
        LblCompany.Text = Locator.GetInstance(Of Session).Setting.Company.ShortName
        LblVersion.Text = Locator.GetInstance(Of Session).ManagerVersion
        BtnUser.Text = _User.Username
        BtnEmail.Visible = _User.CanAccess(Routine.EmailModel) Or _User.CanAccess(Routine.EmailSignature) Or _User.CanAccess(Routine.EmailSent)
        BtnEmailModel.Visible = _User.CanAccess(Routine.EmailModel)
        BtnEmailSign.Visible = _User.CanAccess(Routine.EmailSignature)
        BtnEmailSent.Visible = _User.CanAccess(Routine.EmailSent)
        CreateEvaluationButton()
        CreateRequestButton()
        CreateCashButton()
        CreateCrmButton()
        CreateFirstSeparator()
        CreatePersonButton()
        CreateProductButton()
        CreateUserButton()
    End Sub
    Private Sub CreateFirstSeparator()
        If (_User.CanAccess(Routine.Evaluation) Or _User.CanAccess(Routine.Request) Or _User.CanAccess(Routine.Cash) And
            (_User.CanAccess(Routine.Person) Or _User.CanAccess(Routine.Product) Or _User.CanAccess(Routine.User))) Then
            TsRoutine.Items.Add(New ToolStripSeparator With {.Margin = New Padding(0, 0, 5, 0)})
        End If
    End Sub
    Private Sub CreateCrmButton()
        If _User.CanAccess(Routine.Crm) Then
            TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripButton("CRM", "CRM", My.Resources.CRM, AddressOf CrmClick))
        End If
    End Sub
    Private Sub CreateEvaluationButton()
        If _User.CanAccess(Routine.Evaluation) Then
            If _User.CanAccess(Routine.EvaluationManagement) Or _User.CanAccess(Routine.EvaluationManagementPanel) Or _User.CanAccess(Routine.VisitSchedule) Then
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripSplitButton("Avaliação", "Cadastro de Avaliações de Compressor", My.Resources.Evaluation, AddressOf EvaluationClick))
                If _User.CanAccess(Routine.EvaluationManagement) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Avaliação").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Gerenciamento", "Gerenciamento", My.Resources.EvaluationManagement, AddressOf EvaluationManagementClick))
                End If
                If _User.CanAccess(Routine.EvaluationManagementPanel) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Avaliação").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Painel", "Painel", My.Resources.Chart, AddressOf EvaluationManagementPanelClick))
                End If
                If _User.CanAccess(Routine.VisitSchedule) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Avaliação").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Agenda de Visita", "Agenda de Visita", My.Resources.VisitSchedule, AddressOf VisitScheduleClick))
                End If
            Else
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripButton("Avaliação", "Cadastro de Avaliações de Compressor", My.Resources.Evaluation, AddressOf EvaluationClick))
            End If
        End If
    End Sub
    Private Sub CreateRequestButton()
        If _User.CanAccess(Routine.Request) Then
            If _User.CanAccess(Routine.RequestPendingItemsReport) Then
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripSplitButton("Requisição", "Requisição de Peças", My.Resources.Request, AddressOf RequestClick))
                If _User.CanAccess(Routine.RequestPendingItemsReport) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Requisição").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Relatório", Nothing, My.Resources.Report, Nothing, True))
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Requisição").DropDownItems.OfType(Of ToolStripMenuItem).Single(Function(y) y.Text = "Relatório").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Peças Pendentes", Nothing, Nothing, AddressOf RequestPendingPartClick))
                End If
            Else
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripButton("Requisição", "Requisição de Peças", My.Resources.Request, AddressOf RequestClick))
            End If
        End If
    End Sub
    Private Sub CreateCashButton()
        If _User.CanAccess(Routine.Cash) Then
            If _User.CanAccess(Routine.CashExpensesPerResponsibleReport) Or _User.CanAccess(Routine.CashFlow) Then
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripSplitButton("Caixa", "Fechamento de Caixa", My.Resources.Cash, AddressOf CashClick))
                If _User.CanAccess(Routine.CashFlow) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Caixa").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Fluxo de Caixa", "Cadastro de Fluxo de Caixa", My.Resources.CashFlow, AddressOf CashFlowClick))
                End If
                If _User.CanAccess(Routine.CashExpensesPerResponsibleReport) Or _User.CanAccess(Routine.CashFlow) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Caixa").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Relatório", Nothing, My.Resources.Report, Nothing, True))
                End If
                If _User.CanAccess(Routine.CashExpensesPerResponsibleReport) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Caixa").DropDownItems.OfType(Of ToolStripMenuItem).Single(Function(y) y.Text = "Relatório").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Despesas Por Responsável", Nothing, Nothing, AddressOf CashExpensesPerResponsibleClick))
                End If
                If _User.CanAccess(Routine.CashSheetReport) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Caixa").DropDownItems.OfType(Of ToolStripMenuItem).Single(Function(y) y.Text = "Relatório").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Folhas de Caixa", Nothing, Nothing, AddressOf CashSheetClick))
                End If
            Else
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripButton("Caixa", "Fechamento de Caixa", My.Resources.Cash, AddressOf CashClick))
            End If
        End If
    End Sub
    Private Sub CreatePersonButton()
        If _User.CanAccess(Routine.Person) Then
            If _User.CanAccess(Routine.Compressor) Or
                _User.CanAccess(Routine.City) Or
                _User.CanAccess(Routine.Route) Or
                _User.CanAccess(Routine.PersonRegistrationFormReport) Or
                _User.CanAccess(Routine.PersonMaintenancePlanReport) Then
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripSplitButton("Pessoa", "Cadastro de Pessoas", My.Resources.Person, AddressOf PersonClick))
                If _User.CanAccess(Routine.Compressor) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Pessoa").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Compressor", "Cadastro de Compressores", My.Resources.Compressor, AddressOf CompressorClick))
                End If
                If _User.CanAccess(Routine.City) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Pessoa").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Cidade", "Cadastro de Cidades", My.Resources.City, AddressOf CityClick))
                End If
                If _User.CanAccess(Routine.Route) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Pessoa").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Rota", "Cadastro de Rotas", My.Resources.Route, AddressOf RouteClick))
                End If
                If _User.CanAccess(Routine.PersonRegistrationFormReport) Or _User.CanAccess(Routine.PersonMaintenancePlanReport) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Pessoa").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Relatório", Nothing, My.Resources.Report, Nothing, True))
                    If _User.CanAccess(Routine.PersonRegistrationFormReport) Then
                        TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Pessoa").DropDownItems.OfType(Of ToolStripMenuItem).Single(Function(y) y.Text = "Relatório").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Ficha Cadastral", Nothing, Nothing, AddressOf PersonRegistrationFormClick))
                    End If
                    If _User.CanAccess(Routine.PersonMaintenancePlanReport) Then
                        TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Pessoa").DropDownItems.OfType(Of ToolStripMenuItem).Single(Function(y) y.Text = "Relatório").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Plano de Manutenção", Nothing, Nothing, AddressOf PersonMaintenancePlanClick))
                    End If
                End If
            Else
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripButton("Pessoa", "Cadastro de Pessoas", My.Resources.Person, AddressOf PersonClick))
            End If
        End If
    End Sub
    Private Sub CreateProductButton()
        If _User.CanAccess(Routine.Product) Then
            If _User.CanAccess(Routine.ProductFamily) Or
                _User.CanAccess(Routine.ProductGroup) Or
                _User.CanAccess(Routine.ProductUnit) Or
                _User.CanAccess(Routine.Service) Then
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripSplitButton("Produto", "Cadastro de Produtos", My.Resources.Product, AddressOf ProductClick))
                If _User.CanAccess(Routine.ProductFamily) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Produto").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Família de Produto", "Cadastro de Famílias de Produto", My.Resources.ProductFamily, AddressOf ProductFamilyClick))
                End If
                If _User.CanAccess(Routine.ProductGroup) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Produto").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Grupo de Produto", "Cadastro de Grupos de Produto", My.Resources.ProductGroup, AddressOf ProductGroupClick))
                End If
                If _User.CanAccess(Routine.ProductUnit) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Produto").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Unidade de Medida", "Cadastro de Unidades de Medida de Produto", My.Resources.ProductUnit, AddressOf ProductUnitClick))
                End If
                If _User.CanAccess(Routine.Service) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Produto").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Serviço", "Cadastro de Serviços Prestados", My.Resources.Service, AddressOf ServiceClick))
                End If
            Else
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripButton("Produto", "Cadastro de Produtos", My.Resources.Product, AddressOf ProductClick))
            End If
        End If
    End Sub
    Private Sub CreateUserButton()
        If _User.CanAccess(Routine.User) Then
            If _User.CanAccess(Routine.PrivilegePreset) Then
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripSplitButton("Usuário", "Cadastro de Usuários", My.Resources.User, AddressOf UserClick))
                If _User.CanAccess(Routine.PrivilegePreset) Then
                    TsRoutine.Items.OfType(Of ToolStripSplitButton).Single(Function(x) x.Text = "Usuário").DropDownItems.Add(ToolStripItemFactory.GetToolStripMenuItem("Predefinição de Permissões", "Cadastro de Predefinições de Permissões do Usuário", My.Resources.UserPrivilegePreset, AddressOf PrivilegePresetClick))
                End If
            Else
                TsRoutine.Items.Add(ToolStripItemFactory.GetToolStripButton("Usuário", "Cadastro de Usuários", My.Resources.User, AddressOf UserClick))
            End If
        End If
    End Sub
    Private Sub CrmClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Crm)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmCrms, EnumHelper.GetEnumDescription(Routine.Crm))
        Else
            SelectTab(Routine.Crm)
        End If
    End Sub
    Private Sub PersonClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Person)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmPersons, EnumHelper.GetEnumDescription(Routine.Person))
        Else
            SelectTab(Routine.Person)
        End If
    End Sub
    Private Sub PersonRegistrationFormClick()
        Using FormRegistration As New FrmPersonRegistrationForm()
            FormRegistration.ShowDialog()
        End Using
    End Sub
    Private Sub PersonMaintenancePlanClick()
        Using FormMaintenance As New FrmPersonMaintenancePlan()
            FormMaintenance.ShowDialog()
        End Using
    End Sub
    Private Sub CompressorClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Compressor)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmCompressors, EnumHelper.GetEnumDescription(Routine.Compressor))
        Else
            SelectTab(Routine.Compressor)
        End If
    End Sub
    Private Sub RouteClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Route)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmRoutes, EnumHelper.GetEnumDescription(Routine.Route))
        Else
            SelectTab(Routine.Route)
        End If
    End Sub
    Private Sub CityClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.City)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmCities, EnumHelper.GetEnumDescription(Routine.City))
        Else
            SelectTab(Routine.City)
        End If
    End Sub
    Private Sub ProductUnitClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.ProductUnit)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmProductUnits, EnumHelper.GetEnumDescription(Routine.ProductUnit))
        Else
            SelectTab(Routine.ProductUnit)
        End If
    End Sub
    Private Sub ServiceClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Service)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmServices, EnumHelper.GetEnumDescription(Routine.Service))
        Else
            SelectTab(Routine.Service)
        End If
    End Sub
    Private Sub ProductFamilyClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.ProductFamily)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmProductFamilies, EnumHelper.GetEnumDescription(Routine.ProductFamily))
        Else
            SelectTab(Routine.ProductFamily)
        End If
    End Sub
    Private Sub ProductGroupClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.ProductGroup)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmProductGroups, EnumHelper.GetEnumDescription(Routine.ProductGroup))
        Else
            SelectTab(Routine.ProductGroup)
        End If
    End Sub
    Private Sub ProductClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Product)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmProducts, EnumHelper.GetEnumDescription(Routine.Product))
        Else
            SelectTab(Routine.Product)
        End If
    End Sub
    Private Sub UserClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.User)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmUsers, EnumHelper.GetEnumDescription(Routine.User))
        Else
            SelectTab(Routine.User)
        End If
    End Sub
    Private Sub PrivilegePresetClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.PrivilegePreset)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmPrivilegePresets, EnumHelper.GetEnumDescription(Routine.PrivilegePreset))
        Else
            SelectTab(Routine.PrivilegePreset)
        End If
    End Sub
    Private Sub EmailModelClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.EmailModel)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmEmailModels, EnumHelper.GetEnumDescription(Routine.EmailModel))
        Else
            SelectTab(Routine.EmailModel)
        End If
    End Sub
    Private Sub EvaluationClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Evaluation)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmEvaluations, EnumHelper.GetEnumDescription(Routine.Evaluation))
        Else
            SelectTab(Routine.Evaluation)
        End If
    End Sub

    Private Sub EvaluationManagementPanelClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.EvaluationManagementPanel)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmEvaluationManagementPanel, EnumHelper.GetEnumDescription(Routine.EvaluationManagementPanel))
        Else
            SelectTab(Routine.EvaluationManagementPanel)
        End If
    End Sub
    Private Sub EvaluationManagementClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.EvaluationManagement)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmEvaluationManagement, EnumHelper.GetEnumDescription(Routine.EvaluationManagement))
        Else
            SelectTab(Routine.EvaluationManagement)
        End If
    End Sub

    Private Sub VisitScheduleClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.VisitSchedule)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmVisitSchedules, EnumHelper.GetEnumDescription(Routine.VisitSchedule))
        Else
            SelectTab(Routine.VisitSchedule)
        End If
    End Sub

    Private Sub RequestClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.Request)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmRequests, EnumHelper.GetEnumDescription(Routine.Request))
        Else
            SelectTab(Routine.Request)
        End If
    End Sub
    Private Sub RequestPendingPartClick()
        Using FormPending As New FrmRequestPendingItems()
            FormPending.ShowDialog()
        End Using
    End Sub
    Private Sub CashClick()
        Dim ShiftPressed As Boolean = Control.ModifierKeys = Keys.Shift
        Dim TabText As String
        Dim CashFlows As List(Of CashFlow)
        CashFlows = CashFlow.GetCashFlows().Where(Function(x) x.Authorizeds.Any(Function(y) y.Authorized.ID = Locator.GetInstance(Of Session).User.Person.Value.ID)).ToList
        If CashFlows.Count = 0 Then
            CMessageBox.Show("Não há fluxo de caixa autorizado para seu usuário.", CMessageBoxType.Information)
        ElseIf CashFlows.Count = 1 Then
            TabText = EnumHelper.GetEnumDescription(Routine.Cash) & " - " & CashFlows(0).Name
            If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = TabText) Or ShiftPressed Then
                OpenTab(New FrmCashes(CashFlows(0)), TabText)
            Else
                SelectTab(TabText)
            End If
        Else
            Using Form As New FrmChoseCashFlow(CashFlows)
                If Form.ShowDialog = DialogResult.OK Then
                    TabText = EnumHelper.GetEnumDescription(Routine.Cash) & " - " & CashFlows.FirstOrDefault(Function(x) x.ID = Form.DgvCashFlow.SelectedRows(0).Cells("ID").Value).Name
                    If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = TabText) Or ShiftPressed Then
                        OpenTab(New FrmCashes(CashFlows.FirstOrDefault(Function(x) x.ID = Form.DgvCashFlow.SelectedRows(0).Cells("ID").Value)), TabText)
                    Else
                        SelectTab(TabText)
                    End If
                End If
            End Using
        End If
    End Sub
    Private Sub CashFlowClick()
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.CashFlow)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmCashFlows, EnumHelper.GetEnumDescription(Routine.CashFlow))
        Else
            SelectTab(Routine.CashFlow)
        End If
    End Sub
    Private Sub CashExpensesPerResponsibleClick()
        Using FormResponsible As New FrmCashExpensesPerResponsible()
            FormResponsible.ShowDialog()
        End Using
    End Sub
    Private Sub CashSheetClick()
        Using FormSheet As New FrmCashSheet()
            FormSheet.ShowDialog()
        End Using
    End Sub
    Public Sub OpenTab(Form As Form, TabText As String)
        Dim Page As TabPage
        Form.TopMost = False
        Form.TopLevel = False
        Form.Location = New Point(0, 0)
        Form.Height = Height - 196
        Form.Width = Width - 24
        Page = New TabPage With {
            .Text = TabText,
            .AutoScroll = True
        }
        Page.Controls.Add(Form)
        TcWindows.Controls.Add(Page)
        TcWindows.SelectTab(TcWindows.TabCount - 1)
        Form.Show()
    End Sub
    Public Sub SelectTab(Routine As Routine)
        Dim FirstIndex As Integer
        Dim SelectedIndex As Integer
        Dim NextIndex As Integer
        Dim LastIndex As Integer
        If TcWindows.TabPages.Cast(Of TabPage).Count(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine)) = 1 Then
            TcWindows.SelectedTab = TcWindows.TabPages.Cast(Of TabPage).First(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine))
        Else
            SelectedIndex = TcWindows.SelectedTab.TabIndex
            FirstIndex = TcWindows.TabPages.Cast(Of TabPage).First(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine)).TabIndex
            LastIndex = TcWindows.TabPages.Cast(Of TabPage).Last(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine)).TabIndex
            If SelectedIndex < LastIndex Then
                NextIndex = TcWindows.TabPages.Cast(Of TabPage).First(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine) And x.TabIndex > SelectedIndex).TabIndex
            Else
                NextIndex = FirstIndex
            End If
            If TcWindows.SelectedIndex < LastIndex Then
                TcWindows.SelectedIndex = NextIndex
            Else
                TcWindows.SelectedIndex = FirstIndex
            End If
        End If
    End Sub
    Public Sub SelectTab(TabText As String)
        Dim FirstIndex As Integer
        Dim SelectedIndex As Integer
        Dim NextIndex As Integer
        Dim LastIndex As Integer
        If TcWindows.TabPages.Cast(Of TabPage).Count(Function(x) x.Text = TabText) = 1 Then
            TcWindows.SelectedTab = TcWindows.TabPages.Cast(Of TabPage).First(Function(x) x.Text = TabText)
        Else
            SelectedIndex = TcWindows.SelectedTab.TabIndex
            FirstIndex = TcWindows.TabPages.Cast(Of TabPage).First(Function(x) x.Text = TabText).TabIndex
            LastIndex = TcWindows.TabPages.Cast(Of TabPage).Last(Function(x) x.Text = TabText).TabIndex
            If SelectedIndex < LastIndex Then
                NextIndex = TcWindows.TabPages.Cast(Of TabPage).First(Function(x) x.Text = TabText And x.TabIndex > SelectedIndex).TabIndex
            Else
                NextIndex = FirstIndex
            End If
            If TcWindows.SelectedIndex < LastIndex Then
                TcWindows.SelectedIndex = NextIndex
            Else
                TcWindows.SelectedIndex = FirstIndex
            End If
        End If
    End Sub
    Private Sub BtnUser_MouseEnter(sender As Object, e As EventArgs) Handles BtnUser.MouseEnter
        Cursor = Cursors.Hand
    End Sub
    Private Sub BtnUser_MouseLeave(sender As Object, e As EventArgs) Handles BtnUser.MouseLeave
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnChangePassword_Click(sender As Object, e As EventArgs) Handles BtnChangePassword.Click
        Dim FormChangePassword As FrmUserChangePassword
        FormChangePassword = New FrmUserChangePassword(Locator.GetInstance(Of Session).User)
        FormChangePassword.ShowDialog()
    End Sub
    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If CMessageBox.Show("Realmente deseja fechar o sistema?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) <> DialogResult.Yes Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub FrmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        If TcWindows.TabPages.Count > 0 Then
            If CMessageBox.Show("Todas as janelas serão fechadas, deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dispose()
                FrmLogin.TxtUsername.Text = Nothing
                FrmLogin.TxtPassword.Text = Nothing
                FrmLogin.TxtUsername.Select()
                FrmLogin.Show()
            End If
        Else
            Dispose()
            FrmLogin.TxtUsername.Text = Nothing
            FrmLogin.TxtPassword.Text = Nothing
            FrmLogin.TxtUsername.Select()
            FrmLogin.Show()
        End If
    End Sub
    <DebuggerStepThrough>
    Private Async Sub TimerAccess_Tick(sender As Object, e As EventArgs) Handles TimerAccess.Tick
        If Now.Hour >= 22 Then
            Try
                Locator.GetInstance(Of Session).LicenseResult = Await Task.Run(Function() Locator.GetInstance(Of LicenseService).GetLocalLicense())
                If Not Locator.GetInstance(Of Session).LicenseResult.Success Then
                    TimerAccess.Stop()
                    CMessageBox.Show(EnumHelper.GetEnumDescription(Locator.GetInstance(Of Session).LicenseResult.Flag), CMessageBoxType.Warning)
                    CloseMe()
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO MA002", "Ocorreu um erro ao validar a chave do sistema.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                CloseMe()
            End Try
        End If
    End Sub
    Private Sub CloseMe()
        Locator.GetInstance(Of Session).AutoCloseApp = True
        Dispose()
        FrmLogin.TxtUsername.Text = Nothing
        FrmLogin.TxtPassword.Text = Nothing
        FrmLogin.TxtUsername.Select()
        FrmLogin.Show()
    End Sub
    Private Sub BtnEmailModel_Click(sender As Object, e As EventArgs) Handles BtnEmailModel.Click
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.EmailModel)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmEmailModels, EnumHelper.GetEnumDescription(Routine.EmailModel))
        Else
            SelectTab(Routine.EmailModel)
        End If
    End Sub
    Private Sub BtnEmailSent_Click(sender As Object, e As EventArgs) Handles BtnEmailSent.Click
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.EmailSent)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmEmailsSent, EnumHelper.GetEnumDescription(Routine.EmailSent))
        Else
            SelectTab(Routine.EmailSent)
        End If
    End Sub
    Private Sub BtnEmailSign_Click(sender As Object, e As EventArgs) Handles BtnEmailSign.Click
        If Not TcWindows.TabPages.Cast(Of TabPage).Any(Function(x) x.Text = EnumHelper.GetEnumDescription(Routine.EmailSignature)) Or Control.ModifierKeys = Keys.Shift Then
            OpenTab(New FrmEmailSignatures, EnumHelper.GetEnumDescription(Routine.EmailSignature))
        Else
            SelectTab(Routine.EmailSignature)
        End If
    End Sub
End Class

