<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CmsNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.DgvEvents = New System.Windows.Forms.DataGridView()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.BtnAgentState = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnBackup = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnOpenBackupFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnExecuteBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnRestoreBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnClean = New System.Windows.Forms.ToolStripButton()
        Me.BtnRelease = New System.Windows.Forms.ToolStripButton()
        Me.BtnCloudSync = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCompanies = New System.Windows.Forms.ToolStripButton()
        Me.BtnSettings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnLicense = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnLicenseCredentials = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnChangeLicenseKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.BancoDeDadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnLocalDbCredentials = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnRemoteDbCredentials = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnBackupConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSupport = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnParameters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnCleanEventLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.TpbProgress = New CoreSuite.Controls.ColoredProgressBar()
        Me.LblProgress = New System.Windows.Forms.Label()
        Me.ScTaskEvent = New System.Windows.Forms.SplitContainer()
        Me.ScTaskWarning = New System.Windows.Forms.SplitContainer()
        Me.DgvTasks = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgvWarnings = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewContentCopy = New CoreSuite.Controls.DataGridViewClipboart()
        Me.CmsNotifyIcon.SuspendLayout()
        CType(Me.DgvEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsTitle.SuspendLayout()
        CType(Me.ScTaskEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScTaskEvent.Panel1.SuspendLayout()
        Me.ScTaskEvent.Panel2.SuspendLayout()
        Me.ScTaskEvent.SuspendLayout()
        CType(Me.ScTaskWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScTaskWarning.Panel1.SuspendLayout()
        Me.ScTaskWarning.Panel2.SuspendLayout()
        Me.ScTaskWarning.SuspendLayout()
        CType(Me.DgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvWarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.CmsNotifyIcon
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "Gerenciador - Agente"
        '
        'CmsNotifyIcon
        '
        Me.CmsNotifyIcon.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmsNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnClose})
        Me.CmsNotifyIcon.Name = "CmsNotifyIcon"
        Me.CmsNotifyIcon.Size = New System.Drawing.Size(120, 26)
        '
        'BtnClose
        '
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(119, 22)
        Me.BtnClose.Text = "Fechar"
        '
        'DgvEvents
        '
        Me.DgvEvents.AllowUserToAddRows = False
        Me.DgvEvents.AllowUserToDeleteRows = False
        Me.DgvEvents.AllowUserToResizeColumns = False
        Me.DgvEvents.AllowUserToResizeRows = False
        Me.DgvEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvEvents.BackgroundColor = System.Drawing.Color.White
        Me.DgvEvents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvEvents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvEvents.ColumnHeadersVisible = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvEvents.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgvEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvEvents.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DgvEvents.Location = New System.Drawing.Point(0, 28)
        Me.DgvEvents.Name = "DgvEvents"
        Me.DgvEvents.ReadOnly = True
        Me.DgvEvents.RowHeadersVisible = False
        Me.DgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEvents.Size = New System.Drawing.Size(727, 338)
        Me.DgvEvents.TabIndex = 17
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitle.ForeColor = System.Drawing.Color.White
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(727, 28)
        Me.LblTitle.TabIndex = 16
        Me.LblTitle.Text = "Eventos"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TsTitle
        '
        Me.TsTitle.BackColor = System.Drawing.Color.Transparent
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnAgentState, Me.ToolStripSeparator1, Me.BtnBackup, Me.BtnClean, Me.BtnRelease, Me.BtnCloudSync, Me.ToolStripSeparator4, Me.BtnCompanies, Me.BtnSettings})
        Me.TsTitle.Location = New System.Drawing.Point(0, 0)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.Size = New System.Drawing.Size(894, 63)
        Me.TsTitle.TabIndex = 18
        Me.TsTitle.Text = "ToolStrip"
        '
        'BtnAgentState
        '
        Me.BtnAgentState.AutoSize = False
        Me.BtnAgentState.CheckOnClick = True
        Me.BtnAgentState.Enabled = False
        Me.BtnAgentState.Image = Global.ManagerAgent.My.Resources.Resources.Pause
        Me.BtnAgentState.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnAgentState.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAgentState.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnAgentState.Name = "BtnAgentState"
        Me.BtnAgentState.Size = New System.Drawing.Size(150, 53)
        Me.BtnAgentState.Text = "Em Pausa"
        Me.BtnAgentState.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAgentState.ToolTipText = "Controla as funções automáticas do sistema"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 63)
        '
        'BtnBackup
        '
        Me.BtnBackup.AutoSize = False
        Me.BtnBackup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnOpenBackupFolder, Me.BtnExecuteBackup, Me.BtnRestoreBackup})
        Me.BtnBackup.Enabled = False
        Me.BtnBackup.Image = Global.ManagerAgent.My.Resources.Resources.Backup
        Me.BtnBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnBackup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBackup.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnBackup.Name = "BtnBackup"
        Me.BtnBackup.Size = New System.Drawing.Size(100, 53)
        Me.BtnBackup.Text = "Backup"
        Me.BtnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnBackup.ToolTipText = "Restaurar ou cria um backup"
        '
        'BtnOpenBackupFolder
        '
        Me.BtnOpenBackupFolder.Name = "BtnOpenBackupFolder"
        Me.BtnOpenBackupFolder.Size = New System.Drawing.Size(145, 22)
        Me.BtnOpenBackupFolder.Text = "Abrir Pasta"
        '
        'BtnExecuteBackup
        '
        Me.BtnExecuteBackup.Name = "BtnExecuteBackup"
        Me.BtnExecuteBackup.Size = New System.Drawing.Size(145, 22)
        Me.BtnExecuteBackup.Text = "Executar"
        '
        'BtnRestoreBackup
        '
        Me.BtnRestoreBackup.Name = "BtnRestoreBackup"
        Me.BtnRestoreBackup.Size = New System.Drawing.Size(145, 22)
        Me.BtnRestoreBackup.Text = "Restaurar"
        '
        'BtnClean
        '
        Me.BtnClean.AutoSize = False
        Me.BtnClean.Enabled = False
        Me.BtnClean.Image = Global.ManagerAgent.My.Resources.Resources.Garbage
        Me.BtnClean.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnClean.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClean.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnClean.Name = "BtnClean"
        Me.BtnClean.Size = New System.Drawing.Size(100, 53)
        Me.BtnClean.Text = "Limpar"
        Me.BtnClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnClean.ToolTipText = "Exclui arquivos que não são necessários pelo sistema"
        '
        'BtnRelease
        '
        Me.BtnRelease.AutoSize = False
        Me.BtnRelease.Enabled = False
        Me.BtnRelease.Image = Global.ManagerAgent.My.Resources.Resources.Release
        Me.BtnRelease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnRelease.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRelease.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnRelease.Name = "BtnRelease"
        Me.BtnRelease.Size = New System.Drawing.Size(100, 53)
        Me.BtnRelease.Text = "Desbloquear"
        Me.BtnRelease.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnRelease.ToolTipText = "Desbloqueia registros que foram bloqueados por usuários mas que não estão mais se" &
    "ndo utilizados"
        '
        'BtnCloudSync
        '
        Me.BtnCloudSync.AutoSize = False
        Me.BtnCloudSync.Enabled = False
        Me.BtnCloudSync.Image = Global.ManagerAgent.My.Resources.Resources.Cloud
        Me.BtnCloudSync.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnCloudSync.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCloudSync.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCloudSync.Name = "BtnCloudSync"
        Me.BtnCloudSync.Size = New System.Drawing.Size(100, 53)
        Me.BtnCloudSync.Text = "Sincronizar"
        Me.BtnCloudSync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCloudSync.ToolTipText = "Sincroniza os dados do banco de dados local, com o banco de dados na núvem"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 63)
        '
        'BtnCompanies
        '
        Me.BtnCompanies.AutoSize = False
        Me.BtnCompanies.Enabled = False
        Me.BtnCompanies.Image = Global.ManagerAgent.My.Resources.Resources.Cloud
        Me.BtnCompanies.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnCompanies.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCompanies.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCompanies.Name = "BtnCompanies"
        Me.BtnCompanies.Size = New System.Drawing.Size(120, 53)
        Me.BtnCompanies.Text = "Empresas"
        Me.BtnCompanies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCompanies.ToolTipText = "Sincroniza os dados do banco de dados local, com o banco de dados na núvem"
        '
        'BtnSettings
        '
        Me.BtnSettings.AutoSize = False
        Me.BtnSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnLicense, Me.BancoDeDadosToolStripMenuItem, Me.BtnBackupConfig, Me.BtnSupport, Me.BtnParameters, Me.ToolStripSeparator2, Me.BtnChangePassword, Me.BtnCleanEventLog})
        Me.BtnSettings.Enabled = False
        Me.BtnSettings.Image = Global.ManagerAgent.My.Resources.Resources.Settings
        Me.BtnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSettings.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSettings.Name = "BtnSettings"
        Me.BtnSettings.Size = New System.Drawing.Size(120, 53)
        Me.BtnSettings.Text = "Configurações"
        Me.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnLicense
        '
        Me.BtnLicense.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnLicenseCredentials, Me.BtnChangeLicenseKey})
        Me.BtnLicense.Name = "BtnLicense"
        Me.BtnLicense.Size = New System.Drawing.Size(223, 22)
        Me.BtnLicense.Text = "Licença"
        '
        'BtnLicenseCredentials
        '
        Me.BtnLicenseCredentials.Name = "BtnLicenseCredentials"
        Me.BtnLicenseCredentials.Size = New System.Drawing.Size(180, 22)
        Me.BtnLicenseCredentials.Text = "Credenciais"
        '
        'BtnChangeLicenseKey
        '
        Me.BtnChangeLicenseKey.Name = "BtnChangeLicenseKey"
        Me.BtnChangeLicenseKey.Size = New System.Drawing.Size(180, 22)
        Me.BtnChangeLicenseKey.Text = "Alterar Chave"
        '
        'BancoDeDadosToolStripMenuItem
        '
        Me.BancoDeDadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnLocalDbCredentials, Me.BtnRemoteDbCredentials})
        Me.BancoDeDadosToolStripMenuItem.Name = "BancoDeDadosToolStripMenuItem"
        Me.BancoDeDadosToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.BancoDeDadosToolStripMenuItem.Text = "Banco de Dados"
        '
        'BtnLocalDbCredentials
        '
        Me.BtnLocalDbCredentials.Name = "BtnLocalDbCredentials"
        Me.BtnLocalDbCredentials.Size = New System.Drawing.Size(208, 22)
        Me.BtnLocalDbCredentials.Text = "Credenciais Local"
        '
        'BtnRemoteDbCredentials
        '
        Me.BtnRemoteDbCredentials.Name = "BtnRemoteDbCredentials"
        Me.BtnRemoteDbCredentials.Size = New System.Drawing.Size(208, 22)
        Me.BtnRemoteDbCredentials.Text = "Credenciais Remoto"
        '
        'BtnBackupConfig
        '
        Me.BtnBackupConfig.Name = "BtnBackupConfig"
        Me.BtnBackupConfig.Size = New System.Drawing.Size(223, 22)
        Me.BtnBackupConfig.Text = "Backup"
        '
        'BtnSupport
        '
        Me.BtnSupport.Name = "BtnSupport"
        Me.BtnSupport.Size = New System.Drawing.Size(223, 22)
        Me.BtnSupport.Text = "Suporte"
        '
        'BtnParameters
        '
        Me.BtnParameters.Name = "BtnParameters"
        Me.BtnParameters.Size = New System.Drawing.Size(223, 22)
        Me.BtnParameters.Text = "Parâmetros"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(220, 6)
        '
        'BtnChangePassword
        '
        Me.BtnChangePassword.Name = "BtnChangePassword"
        Me.BtnChangePassword.Size = New System.Drawing.Size(223, 22)
        Me.BtnChangePassword.Text = "Alterar Senha"
        '
        'BtnCleanEventLog
        '
        Me.BtnCleanEventLog.Name = "BtnCleanEventLog"
        Me.BtnCleanEventLog.Size = New System.Drawing.Size(223, 22)
        Me.BtnCleanEventLog.Text = "Limpar Log de Eventos"
        '
        'TpbProgress
        '
        Me.TpbProgress.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TpbProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TpbProgress.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TpbProgress.ForeColor = System.Drawing.Color.White
        Me.TpbProgress.Location = New System.Drawing.Point(0, 459)
        Me.TpbProgress.Maximum = 100
        Me.TpbProgress.Minimum = 0
        Me.TpbProgress.Name = "TpbProgress"
        Me.TpbProgress.ProgressBottomColor = System.Drawing.Color.White
        Me.TpbProgress.ProgressTopColor = System.Drawing.Color.White
        Me.TpbProgress.Size = New System.Drawing.Size(894, 2)
        Me.TpbProgress.TabIndex = 19
        Me.TpbProgress.Value = 0
        Me.TpbProgress.Visible = False
        '
        'LblProgress
        '
        Me.LblProgress.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblProgress.ForeColor = System.Drawing.Color.White
        Me.LblProgress.Location = New System.Drawing.Point(0, 431)
        Me.LblProgress.Name = "LblProgress"
        Me.LblProgress.Size = New System.Drawing.Size(894, 28)
        Me.LblProgress.TabIndex = 20
        Me.LblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblProgress.Visible = False
        '
        'ScTaskEvent
        '
        Me.ScTaskEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ScTaskEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScTaskEvent.Location = New System.Drawing.Point(0, 63)
        Me.ScTaskEvent.Name = "ScTaskEvent"
        '
        'ScTaskEvent.Panel1
        '
        Me.ScTaskEvent.Panel1.Controls.Add(Me.ScTaskWarning)
        '
        'ScTaskEvent.Panel2
        '
        Me.ScTaskEvent.Panel2.Controls.Add(Me.DgvEvents)
        Me.ScTaskEvent.Panel2.Controls.Add(Me.LblTitle)
        Me.ScTaskEvent.Size = New System.Drawing.Size(894, 368)
        Me.ScTaskEvent.SplitterDistance = 161
        Me.ScTaskEvent.TabIndex = 21
        '
        'ScTaskWarning
        '
        Me.ScTaskWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ScTaskWarning.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScTaskWarning.Location = New System.Drawing.Point(0, 0)
        Me.ScTaskWarning.Name = "ScTaskWarning"
        Me.ScTaskWarning.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'ScTaskWarning.Panel1
        '
        Me.ScTaskWarning.Panel1.Controls.Add(Me.DgvTasks)
        Me.ScTaskWarning.Panel1.Controls.Add(Me.Label2)
        '
        'ScTaskWarning.Panel2
        '
        Me.ScTaskWarning.Panel2.Controls.Add(Me.DgvWarnings)
        Me.ScTaskWarning.Panel2.Controls.Add(Me.Label1)
        Me.ScTaskWarning.Panel2Collapsed = True
        Me.ScTaskWarning.Size = New System.Drawing.Size(161, 368)
        Me.ScTaskWarning.SplitterDistance = 100
        Me.ScTaskWarning.TabIndex = 23
        '
        'DgvTasks
        '
        Me.DgvTasks.AllowUserToAddRows = False
        Me.DgvTasks.AllowUserToDeleteRows = False
        Me.DgvTasks.AllowUserToResizeColumns = False
        Me.DgvTasks.AllowUserToResizeRows = False
        Me.DgvTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvTasks.BackgroundColor = System.Drawing.Color.White
        Me.DgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTasks.ColumnHeadersVisible = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTasks.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgvTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTasks.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DgvTasks.Location = New System.Drawing.Point(0, 28)
        Me.DgvTasks.Name = "DgvTasks"
        Me.DgvTasks.ReadOnly = True
        Me.DgvTasks.RowHeadersVisible = False
        Me.DgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTasks.Size = New System.Drawing.Size(159, 338)
        Me.DgvTasks.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 28)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Tarefas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DgvWarnings
        '
        Me.DgvWarnings.AllowUserToAddRows = False
        Me.DgvWarnings.AllowUserToDeleteRows = False
        Me.DgvWarnings.AllowUserToResizeColumns = False
        Me.DgvWarnings.AllowUserToResizeRows = False
        Me.DgvWarnings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvWarnings.BackgroundColor = System.Drawing.Color.White
        Me.DgvWarnings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvWarnings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvWarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvWarnings.ColumnHeadersVisible = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvWarnings.DefaultCellStyle = DataGridViewCellStyle9
        Me.DgvWarnings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvWarnings.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DgvWarnings.Location = New System.Drawing.Point(0, 28)
        Me.DgvWarnings.Name = "DgvWarnings"
        Me.DgvWarnings.ReadOnly = True
        Me.DgvWarnings.RowHeadersVisible = False
        Me.DgvWarnings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvWarnings.Size = New System.Drawing.Size(148, 16)
        Me.DgvWarnings.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 28)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Avisos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewContentCopy
        '
        Me.DataGridViewContentCopy.DataGridView = Me.DgvEvents
        Me.DataGridViewContentCopy.IncludeHeaderTextInCellCopy = False
        Me.DataGridViewContentCopy.IncludeHeaderTextInRowCopy = True
        Me.DataGridViewContentCopy.ShowImages = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(894, 461)
        Me.Controls.Add(Me.ScTaskEvent)
        Me.Controls.Add(Me.LblProgress)
        Me.Controls.Add(Me.TpbProgress)
        Me.Controls.Add(Me.TsTitle)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMain"
        Me.ShowIcon = False
        Me.Text = "Agente Gerenciador"
        Me.CmsNotifyIcon.ResumeLayout(False)
        CType(Me.DgvEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.ScTaskEvent.Panel1.ResumeLayout(False)
        Me.ScTaskEvent.Panel2.ResumeLayout(False)
        CType(Me.ScTaskEvent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScTaskEvent.ResumeLayout(False)
        Me.ScTaskWarning.Panel1.ResumeLayout(False)
        Me.ScTaskWarning.Panel2.ResumeLayout(False)
        CType(Me.ScTaskWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScTaskWarning.ResumeLayout(False)
        CType(Me.DgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvWarnings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NotifyIcon As NotifyIcon
    Friend WithEvents DgvEvents As DataGridView
    Friend WithEvents LblTitle As Label
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents BtnAgentState As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CmsNotifyIcon As ContextMenuStrip
    Friend WithEvents BtnClose As ToolStripMenuItem
    Friend WithEvents BtnBackup As ToolStripDropDownButton
    Friend WithEvents BtnOpenBackupFolder As ToolStripMenuItem
    Friend WithEvents BtnExecuteBackup As ToolStripMenuItem
    Friend WithEvents BtnRestoreBackup As ToolStripMenuItem
    Friend WithEvents TpbProgress As CoreSuite.Controls.ColoredProgressBar
    Friend WithEvents BtnClean As ToolStripButton
    Friend WithEvents LblProgress As Label
    Friend WithEvents ScTaskEvent As SplitContainer
    Friend WithEvents BtnSettings As ToolStripDropDownButton
    Friend WithEvents BtnLicense As ToolStripMenuItem
    Friend WithEvents BtnChangePassword As ToolStripMenuItem
    Friend WithEvents BtnCloudSync As ToolStripButton
    Friend WithEvents BtnRelease As ToolStripButton
    Friend WithEvents ScTaskWarning As SplitContainer
    Friend WithEvents DgvTasks As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents DgvWarnings As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnCleanEventLog As ToolStripMenuItem
    Friend WithEvents DataGridViewContentCopy As CoreSuite.Controls.DataGridViewClipboart
    Friend WithEvents BtnCompanies As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BtnChangeLicenseKey As ToolStripMenuItem
    Friend WithEvents BtnLicenseCredentials As ToolStripMenuItem
    Friend WithEvents BtnSupport As ToolStripMenuItem
    Friend WithEvents BtnBackupConfig As ToolStripMenuItem
    Friend WithEvents BtnParameters As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BancoDeDadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnLocalDbCredentials As ToolStripMenuItem
    Friend WithEvents BtnRemoteDbCredentials As ToolStripMenuItem
End Class
