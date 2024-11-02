﻿Imports ControlLibrary
Imports ManagerCore
Imports System.Collections.ObjectModel
Imports System.Threading

'TODO: Fazer o ViewModel da Main
Public Class FrmMain
    Private _IsWorking As Boolean
    Private _EventService As EventService
    Private _StackTaskService As TaskStackService
    Private _AppService As AppService
    Private _SessionModel As SessionModel
    Private _TaskRunning As Boolean
    Private _BlockingTasks As Boolean
    Private _LicenseService As LicenseService
    Private _StateWarnings As ObservableCollection(Of String)
    Private _HasManagerCloudPending As Boolean
    Private _HasDatabasePending As Boolean
    Private _LastLoginRequest As Date
    Public Sub New()
        InitializeComponent()
        _LicenseService = Locator.GetInstance(Of LicenseService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        _EventService = Locator.GetInstance(Of EventService)
        _StackTaskService = Locator.GetInstance(Of TaskStackService)
        _AppService = Locator.GetInstance(Of AppService)
        _StateWarnings = New ObservableCollection(Of String)
        Utility.EnableControlDoubleBuffer(DgvEvents, True)
        TsTitle.Renderer = New CustomToolstripRender()
    End Sub


    Private Async Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        AddHandler _StackTaskService.TaskProgress.ProgressChanged, AddressOf OnTaskProgressChanged
        AddHandler _StackTaskService.TaskWillRun, AddressOf OnTaskWillRun
        AddHandler _StackTaskService.TaskRunned, AddressOf OnTaskRunned
        AddHandler _StackTaskService.TaskListChanged, AddressOf OnTaskWillRun
        AddHandler _StateWarnings.CollectionChanged, AddressOf OnStatePendingsChanged
        Await ValidateState()
        FillDgvTasks()
        If Not _HasDatabasePending Then DgvEvents.DataSource = Await _EventService.Read()

    End Sub


    Private Sub OnStatePendingsChanged(sender As Object, e As EventArgs)
        DgvWarnings.Rows.Clear()
        DgvWarnings.Columns.Clear()
        DgvWarnings.Columns.Add("Item", "Item")
        DgvWarnings.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        For Each Pending In _StateWarnings
            Dim RowIndex As Integer = DgvWarnings.Rows.Add(Pending)
        Next Pending
        If _StateWarnings.Count = 0 Then
            ScTaskWarning.Panel2Collapsed = True
            BtnAgentState.Checked = True
        Else
            ScTaskWarning.Panel2Collapsed = False
            BtnAgentState.Checked = False
        End If
    End Sub


    Private Async Sub OnTaskRunned(sender As Object, Task As TaskBase)

        Invoke(Sub()
                   LblProgress.Visible = False
                   TpbProgress.Visible = False
                   LblProgress.Text = String.Empty
                   TpbProgress.Value = 0
                   BtnCleanEventLog.Enabled = True
                   OnTask()
               End Sub)


        Await _EventService.Save(DgvEvents.DataSource)



    End Sub
    Private Sub OnTaskWillRun(sender As Object, Task As TaskBase)
        Invoke(Sub()
                   Task.CancelRun = _StateWarnings.Count > 0
                   BtnCleanEventLog.Enabled = False
                   OnTask()
               End Sub)
    End Sub

    Private Sub OnTask()
        FillDgvTasks()
        BtnExecuteBackup.Enabled = _StackTaskService.GetTaskStack().Any(Function(x) x.Name = TaskName.BackupManual And Not x.IsRunning) And _StateWarnings.Count = 0
        BtnRestoreBackup.Enabled = _StackTaskService.GetTaskStack().Any(Function(x) x.Name = TaskName.BackupManual And Not x.IsRunning) And _StateWarnings.Count = 0
        BtnClean.Enabled = _StackTaskService.GetTaskStack().Any(Function(x) x.Name = TaskName.CleanManual And Not x.IsRunning) And _StateWarnings.Count = 0
        BtnRelease.Enabled = _StackTaskService.GetTaskStack().Any(Function(x) x.Name = TaskName.ReleaseManual And Not x.IsRunning) And _StateWarnings.Count = 0
        BtnCloudSync.Enabled = _StackTaskService.GetTaskStack().Any(Function(x) x.Name = TaskName.CloudSyncManual And Not x.IsRunning) And _StateWarnings.Count = 0
    End Sub

    Private Sub OnTaskProgressChanged(sender As Object, Response As AsyncResponseModel)
        LblProgress.Visible = True
        TpbProgress.Visible = True
        LblProgress.Text = Response.Text
        TpbProgress.Value = If(Response.Percent >= 0, Response.Percent, TpbProgress.Value)
        If Response IsNot Nothing AndAlso Response.Event IsNot Nothing Then
            _EventService.Write(Response.Event, DgvEvents.DataSource)
        End If
    End Sub

    Private Function RequestLogin(Optional Force As Boolean = False) As Boolean
        Dim Minutes As Long = DateDiff(DateInterval.Minute, _LastLoginRequest, Now)
        Dim ShowFormLogin As Boolean
        If Force Then
            ShowFormLogin = True
        Else
            If _SessionModel.ManagerLicenseResult IsNot Nothing Then
                If Minutes >= 5 Then
                    ShowFormLogin = True
                Else
                    Return True
                End If
            Else
                Return True
            End If
        End If
        If ShowFormLogin Then
            Using Frm As New FrmLogin()
                If Frm.ShowDialog = DialogResult.OK Then
                    If Not _HasManagerCloudPending Then _LastLoginRequest = Now
                    Return True
                Else
                    Return False
                End If
            End Using
        End If
        Return False
    End Function
    Private Sub FillDgvTasks()
        Dim Row As DataGridViewRow
        DgvTasks.Rows.Clear()
        DgvTasks.Columns.Clear()
        DgvTasks.Columns.Add("Item", "Item")
        DgvTasks.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvTasks.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim Tasks As List(Of TaskBase) = _StackTaskService.GetTaskStack().ToList()
        Tasks = Tasks.Where(Function(x) x.NextRun <> Nothing).OrderBy(Function(Task) Task.NextRun).ToList()
        For Each Task In Tasks
            Dim RowIndex As Integer = DgvTasks.Rows.Add(Utility.GetEnumDescription(Task.Name))
            DgvTasks.Rows(RowIndex).DefaultCellStyle.BackColor = Color.Gray
            DgvTasks.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.White
            DgvTasks.Rows(RowIndex).DefaultCellStyle.Font = New Font(DgvTasks.Font, FontStyle.Bold)
            If Task.IsRunning Then
                Row = New DataGridViewRow()
                Row.CreateCells(DgvTasks)
                Row.Cells(0).Value = "Executando"
                Row.Visible = True
                Row.DefaultCellStyle.BackColor = Color.LightGreen
                DgvTasks.Rows.Add(Row)
            Else
                If (Task.IsManual And Task.IsRunNeeded) Or Task.CancelRun Then
                    Row = New DataGridViewRow()
                    Row.CreateCells(DgvTasks)
                    Row.Cells(0).Value = "Aguardando"
                    Row.Visible = True
                    Row.DefaultCellStyle.BackColor = Color.LightBlue
                    DgvTasks.Rows.Add(Row)
                Else
                    Row = New DataGridViewRow()
                    Row.CreateCells(DgvTasks)
                    Row.Cells(0).Value = $"{Task.NextRun:dd/MM/yyyy HH:mm:ss}"
                    Row.Visible = True
                    Row.DefaultCellStyle.BackColor = Color.Gainsboro
                    DgvTasks.Rows.Add(Row)
                End If
            End If
        Next Task
    End Sub
    Private Async Function ValidateState() As Task
        Dim ManagerCloudPending As List(Of String) = Await _AppService.ValidateManagerCloudDB()
        Dim CustomerCloudPending As List(Of String) = Await _AppService.ValidateCustomerCloudDB()
        Dim ManagerDatabasePending As List(Of String) = Await _AppService.ValidateLocalDB()
        Dim CustomerStoragePending As List(Of String) = Await _AppService.ValidateStorage()
        Dim BackupPending As List(Of String) = _AppService.ValidateBackup()

        If ManagerDatabasePending.Count = 0 Then
            _HasDatabasePending = False
        Else
            _HasDatabasePending = True
        End If

        If ManagerCloudPending.Count = 0 Then
            _SessionModel.ManagerLicenseResult = Await _LicenseService.GetOnlineLicense()
            _HasManagerCloudPending = False
        Else
            _HasManagerCloudPending = True
            _SessionModel.ManagerLicenseResult = New LicenseResultModel With {.Success = False, .Flag = LicenseMessages.InaccessibleDestination}
        End If
        _StateWarnings.Clear()
        If Not _SessionModel.ManagerLicenseResult.Success Then
            _StateWarnings.Add($"{Constants.SubItemSymbol} {Utility.GetEnumDescription(_SessionModel.ManagerLicenseResult.Flag)}")
        End If
        ManagerCloudPending.ForEach(Sub(x) _StateWarnings.Add($"{Constants.SubItemSymbol} {x}"))
        ManagerDatabasePending.ForEach(Sub(x) _StateWarnings.Add($"{Constants.SubItemSymbol} {x}"))
        BackupPending.ForEach(Sub(x) _StateWarnings.Add($"{Constants.SubItemSymbol} {x}"))
        CustomerCloudPending.ForEach(Sub(x) _StateWarnings.Add($"{Constants.SubItemSymbol} {x}"))
        CustomerStoragePending.ForEach(Sub(x) _StateWarnings.Add($"{Constants.SubItemSymbol} {x}"))
        BtnSettings.Enabled = True
        BtnSettingsLicense.Enabled = True
        BtnSettingsBackup.Enabled = _SessionModel.ManagerLicenseResult.Success
        BtnSettingsDatabase.Enabled = _SessionModel.ManagerLicenseResult.Success
        BtnSettingsRegister.Enabled = _SessionModel.ManagerLicenseResult.Success
        BtnSettingsGeneral.Enabled = _SessionModel.ManagerLicenseResult.Success
        BtnSettingsCloud.Enabled = _SessionModel.ManagerLicenseResult.Success
        BtnSettingsSupport.Enabled = _SessionModel.ManagerLicenseResult.Success
        BtnSettingsChangePassword.Enabled = _SessionModel.ManagerLicenseResult.Success
        BtnSettingsChangeKey.Enabled = ManagerCloudPending.Count = 0
        If _StateWarnings.Count > 0 Then
            BtnAgentState.Enabled = False
            BtnBackup.Enabled = False
            BtnClean.Enabled = False
            BtnRelease.Enabled = False
            BtnCloudSync.Enabled = False
            BtnCleanEventLog.Enabled = False
        Else
            BtnAgentState.Enabled = True
            BtnBackup.Enabled = True
            BtnClean.Enabled = True
            BtnRelease.Enabled = True
            BtnCloudSync.Enabled = True
            BtnCleanEventLog.Enabled = True
        End If
        FillDgvTasks()
    End Function
    Private Sub CloseApplication()
        _SessionModel.ForceAgentExit = True
        Application.Exit()
    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        If RequestLogin(True) Then
            NotifyIcon.Visible = False
            Show()
        End If
    End Sub
    Private Sub BtnOpenBackupFolder_Click(sender As Object, e As EventArgs) Handles BtnOpenBackupFolder.Click
        Process.Start(_SessionModel.ManagerSetting.Backup.Location)
    End Sub
    Private Sub BtnAgentState_CheckedChanged(sender As Object, e As EventArgs) Handles BtnAgentState.CheckedChanged
        If BtnAgentState.Checked Then
            _StackTaskService.Start()
            BtnAgentState.Image = My.Resources.Execute
            BtnAgentState.Text = "Em Execução"
            _SessionModel.IsAgentPaused = False
        Else
            _StackTaskService.Stop()
            BtnAgentState.Image = My.Resources.Pause
            BtnAgentState.Text = "Em Pausa"
            _SessionModel.IsAgentPaused = True
        End If
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        If RequestLogin(True) Then
            CloseApplication()
        End If
    End Sub
    Private Async Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim RunningTask As TaskBase = _StackTaskService.GetTaskStack().FirstOrDefault(Function(x) x.IsRunning)
        If RunningTask Is Nothing Then
            If Not _SessionModel.ForceAgentExit Then
                e.Cancel = True
                NotifyIcon.Visible = True
                Hide()
            Else
                Await _EventService.Save(DgvEvents.DataSource)
            End If
        Else
            CMessageBox.Show("Uma tarefa está sendo processada, aguarde a conclusão para fechar.", CMessageBoxType.Information)
            e.Cancel = True
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvEvents_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvEvents.CellFormatting
        If e.ColumnIndex = DgvEvents.Columns("time").Index Then
            Dim cellValue As EventTypes = DgvEvents.Rows(e.RowIndex).Cells("eventtype").Value
            If cellValue = EventTypes.Child Then
                DgvEvents.Rows(e.RowIndex).Cells(4).Style.Padding = New Padding(20, 0, 0, 0)
                DgvEvents.Rows(e.RowIndex).Cells(4).Style.Font = New Font(DgvEvents.DefaultCellStyle.Font, FontStyle.Regular)
                DgvEvents.Rows(e.RowIndex).Cells(3).Style.Font = New Font(DgvEvents.DefaultCellStyle.Font, FontStyle.Regular)
            Else
                DgvEvents.Rows(e.RowIndex).Cells(4).Style.Padding = New Padding(0, 0, 0, 0)
                DgvEvents.Rows(e.RowIndex).Cells(4).Style.Font = New Font(DgvEvents.DefaultCellStyle.Font, FontStyle.Bold)
                DgvEvents.Rows(e.RowIndex).Cells(3).Style.Font = New Font(DgvEvents.DefaultCellStyle.Font, FontStyle.Bold)
            End If
        End If
    End Sub
    Private Sub DgvEvents_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvEvents.DataSourceChanged
        If DgvEvents.DataSource IsNot Nothing AndAlso DgvEvents.Columns.Count = 7 Then
            DgvEvents.Columns("id").Visible = False
            DgvEvents.Columns("parentid").Visible = False
            DgvEvents.Columns("eventtype").Visible = False
            DgvEvents.Columns("issaved").Visible = False
            DgvEvents.Columns("tempid").Visible = False
            DgvEvents.Columns("time").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvEvents.Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridViewNavigator.EnsureVisibleRow(DgvEvents, 0)
        End If

    End Sub
    Private Sub DgvTasks_SelectionChanged(sender As Object, e As EventArgs) Handles DgvTasks.SelectionChanged
        DgvTasks.ClearSelection()
    End Sub
    Private Sub DgvWarnings_SelectionChanged(sender As Object, e As EventArgs) Handles DgvWarnings.SelectionChanged
        DgvWarnings.ClearSelection()
    End Sub
    Private Sub BtnChangePassword_Click(sender As Object, e As EventArgs)
        If RequestLogin() Then
            Using Frm As New FrmChangePassword
                Frm.ShowDialog()
            End Using
        End If
    End Sub
    Private Async Sub BtnSettingsLicense_Click(sender As Object, e As EventArgs) Handles BtnSettingsLicense.Click
        Using Frm As New FrmLicenseSettings()
            If Not _HasManagerCloudPending Then
                If RequestLogin() Then
                    Frm.ShowDialog()
                End If
            Else
                Frm.ShowDialog()
            End If
            Await ValidateState()
        End Using
    End Sub
    Private Async Sub BtnSettingsDatabase_Click(sender As Object, e As EventArgs) Handles BtnSettingsDatabase.Click
        If RequestLogin() Then
            Using Frm As New FrmDatabaseSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub
    Private Async Sub BtnSettingsBackup_Click(sender As Object, e As EventArgs) Handles BtnSettingsBackup.Click
        If RequestLogin() Then
            Using Frm As New FrmBackupSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub
    Private Async Sub BtnSettingsCloudStorage_Click(sender As Object, e As EventArgs) Handles BtnSettingsCloudStorage.Click
        If RequestLogin() Then
            Using Frm As New FrmCloudStorageSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub
    Private Async Sub BtnSettingsCloudDatabase_Click(sender As Object, e As EventArgs) Handles BtnSettingsCloudDatabase.Click
        If RequestLogin() Then
            Using Frm As New FrmCloudDatabaseSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub
    Private Async Sub BtnSettingsRegister_Click(sender As Object, e As EventArgs) Handles BtnSettingsRegister.Click
        If RequestLogin() Then
            Using Frm As New FrmRegisterSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub

    Private Async Sub BtnSettingsUser_Click(sender As Object, e As EventArgs) Handles BtnSettingsUser.Click
        If RequestLogin() Then
            Using Frm As New FrmUserSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub

    Private Async Sub BtnSettingsRelease_Click(sender As Object, e As EventArgs) Handles BtnSettingsRelease.Click
        If RequestLogin() Then
            Using Frm As New FrmReleaseSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub
    Private Async Sub BtnSettingsClean_Click(sender As Object, e As EventArgs) Handles BtnSettingsClean.Click
        If RequestLogin() Then
            Using Frm As New FrmCleanSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub
    Private Async Sub BtnSettingsEvaluation_Click(sender As Object, e As EventArgs) Handles BtnSettingsEvaluation.Click
        If RequestLogin() Then
            Using Frm As New FrmEvaluationSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub

    Private Async Sub BtnSettingsSupport_Click(sender As Object, e As EventArgs) Handles BtnSettingsSupport.Click
        If RequestLogin() Then
            Using Frm As New FrmSuportSettings()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub

    Private Async Sub BtnSettingsChangePassword_Click(sender As Object, e As EventArgs) Handles BtnSettingsChangePassword.Click
        If RequestLogin() Then
            Using Frm As New FrmChangePassword()
                Frm.ShowDialog()
                Await ValidateState()
            End Using
        End If
    End Sub

    Private Async Sub BtnSettingsChangeKey_Click(sender As Object, e As EventArgs) Handles BtnSettingsChangeKey.Click
        Dim LicenseResult = Locator.GetInstance(Of SessionModel).ManagerLicenseResult
        Using Frm As New FrmLicenseKey()
            If Not _HasManagerCloudPending AndAlso LicenseResult.Flag = LicenseMessages.MissingProductKey Then
                Frm.ShowDialog()
            Else
                If RequestLogin() Then
                    Frm.ShowDialog()
                End If
            End If
            Await ValidateState()
        End Using
    End Sub

    Private Sub BtnRelease_Click(sender As Object, e As EventArgs) Handles BtnRelease.Click
        BtnRelease.Enabled = False
        Dim Task = Locator.GetInstance(Of TaskBase)(TaskName.ReleaseManual)
        Task.NextRun = Now
        Task.IsRunNeeded = True
        FillDgvTasks()
    End Sub

    Private Sub BtnClean_Click(sender As Object, e As EventArgs) Handles BtnClean.Click
        BtnClean.Enabled = False
        Dim Task = Locator.GetInstance(Of TaskBase)(TaskName.CleanManual)
        Task.NextRun = Now
        Task.IsRunNeeded = True
        FillDgvTasks()
    End Sub

    Private Sub BtnExecuteBackup_Click(sender As Object, e As EventArgs) Handles BtnExecuteBackup.Click
        BtnExecuteBackup.Enabled = False
        BtnRestoreBackup.Enabled = False
        Dim Task = Locator.GetInstance(Of TaskBase)(TaskName.BackupManual)
        Task.NextRun = Now
        Task.IsRunNeeded = True
        FillDgvTasks()
    End Sub

    Private Sub BtnCloudSync_Click(sender As Object, e As EventArgs) Handles BtnCloudSync.Click
        BtnCloudSync.Enabled = False
        Dim Task = Locator.GetInstance(Of TaskBase)(TaskName.CloudSyncManual)
        Task.NextRun = Now
        Task.IsRunNeeded = True
        FillDgvTasks()
    End Sub

    Private Sub BtnRestoreBackup_Click(sender As Object, e As EventArgs) Handles BtnRestoreBackup.Click
        _StackTaskService.Stop()
        BtnExecuteBackup.Enabled = False
        BtnRestoreBackup.Enabled = False
        Dim Tasks = _StackTaskService.GetTaskStack()
        Using Frm As New FrmRestoreBackup()
            If Frm.ShowDialog() = DialogResult.OK Then
                Dim Task = Locator.GetInstance(Of TaskBase)(TaskName.BackupRestore)
                Task.NextRun = Now
                Task.IsRunNeeded = True
            Else
                BtnExecuteBackup.Enabled = True
                BtnRestoreBackup.Enabled = True
            End If
        End Using
        _StackTaskService.Start()
        FillDgvTasks()
    End Sub

    Private Async Sub BtnCleanEventLog_Click(sender As Object, e As EventArgs) Handles BtnCleanEventLog.Click
        If CMessageBox.Show("Todos os eventos serão apagados permanentemente. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim Database = Locator.GetInstance(Of LocalDB)
            Await Database.ExecuteDelete("agentevent")
            DgvEvents.DataSource = Await _EventService.Read()
        End If
    End Sub
End Class
