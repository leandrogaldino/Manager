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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CmsNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.DgvEvents = New System.Windows.Forms.DataGridView()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.BtnAgentState = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSettings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnSettingsBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsRegister = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsEvaluation = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsRelease = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsClean = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsLicense = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsCloud = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsCloudStorage = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsCloudDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsSupport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSettingsChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSettingsChangeKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCleanEventLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnBackup = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnOpenBackupFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnExecuteBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnRestoreBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnClean = New System.Windows.Forms.ToolStripButton()
        Me.BtnRelease = New System.Windows.Forms.ToolStripButton()
        Me.BtnCloudSync = New System.Windows.Forms.ToolStripButton()
        Me.TpbProgress = New ControlLibrary.TextedProgressBar()
        Me.LblProgress = New System.Windows.Forms.Label()
        Me.ScTaskEvent = New System.Windows.Forms.SplitContainer()
        Me.ScTaskWarning = New System.Windows.Forms.SplitContainer()
        Me.DgvTasks = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgvWarnings = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvEvents.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvEvents.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DgvEvents.Location = New System.Drawing.Point(0, 28)
        Me.DgvEvents.Name = "DgvEvents"
        Me.DgvEvents.ReadOnly = True
        Me.DgvEvents.RowHeadersVisible = False
        Me.DgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEvents.Size = New System.Drawing.Size(771, 538)
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
        Me.LblTitle.Size = New System.Drawing.Size(771, 28)
        Me.LblTitle.TabIndex = 16
        Me.LblTitle.Text = "Eventos"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TsTitle
        '
        Me.TsTitle.BackColor = System.Drawing.Color.Transparent
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnAgentState, Me.ToolStripSeparator1, Me.BtnSettings, Me.BtnBackup, Me.BtnClean, Me.BtnRelease, Me.BtnCloudSync})
        Me.TsTitle.Location = New System.Drawing.Point(0, 0)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.Size = New System.Drawing.Size(984, 63)
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
        'BtnSettings
        '
        Me.BtnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnSettings.AutoSize = False
        Me.BtnSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSettingsBackup, Me.BtnSettingsDatabase, Me.BtnSettingsRegister, Me.BtnSettingsGeneral, Me.BtnSettingsLicense, Me.BtnSettingsCloud, Me.BtnSettingsSupport, Me.ToolStripSeparator2, Me.BtnSettingsChangePassword, Me.BtnSettingsChangeKey, Me.ToolStripSeparator3, Me.BtnCleanEventLog})
        Me.BtnSettings.Enabled = False
        Me.BtnSettings.Image = Global.ManagerAgent.My.Resources.Resources.Settings
        Me.BtnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSettings.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSettings.Name = "BtnSettings"
        Me.BtnSettings.Size = New System.Drawing.Size(150, 53)
        Me.BtnSettings.Text = "Configurações"
        Me.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnSettingsBackup
        '
        Me.BtnSettingsBackup.Name = "BtnSettingsBackup"
        Me.BtnSettingsBackup.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsBackup.Text = "Backup"
        '
        'BtnSettingsDatabase
        '
        Me.BtnSettingsDatabase.Name = "BtnSettingsDatabase"
        Me.BtnSettingsDatabase.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsDatabase.Text = "Banco de Dados"
        '
        'BtnSettingsRegister
        '
        Me.BtnSettingsRegister.Name = "BtnSettingsRegister"
        Me.BtnSettingsRegister.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsRegister.Text = "Cadastro"
        '
        'BtnSettingsGeneral
        '
        Me.BtnSettingsGeneral.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSettingsUser, Me.BtnSettingsEvaluation, Me.BtnSettingsRelease, Me.BtnSettingsClean})
        Me.BtnSettingsGeneral.Name = "BtnSettingsGeneral"
        Me.BtnSettingsGeneral.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsGeneral.Text = "Geral"
        '
        'BtnSettingsUser
        '
        Me.BtnSettingsUser.Name = "BtnSettingsUser"
        Me.BtnSettingsUser.Size = New System.Drawing.Size(222, 22)
        Me.BtnSettingsUser.Text = "Rotina de Usuário"
        '
        'BtnSettingsEvaluation
        '
        Me.BtnSettingsEvaluation.Name = "BtnSettingsEvaluation"
        Me.BtnSettingsEvaluation.Size = New System.Drawing.Size(222, 22)
        Me.BtnSettingsEvaluation.Text = "Rotina de Avaliação"
        '
        'BtnSettingsRelease
        '
        Me.BtnSettingsRelease.Name = "BtnSettingsRelease"
        Me.BtnSettingsRelease.Size = New System.Drawing.Size(222, 22)
        Me.BtnSettingsRelease.Text = "Liberação de Registros"
        '
        'BtnSettingsClean
        '
        Me.BtnSettingsClean.Name = "BtnSettingsClean"
        Me.BtnSettingsClean.Size = New System.Drawing.Size(222, 22)
        Me.BtnSettingsClean.Text = "Limpeza do sistema"
        '
        'BtnSettingsLicense
        '
        Me.BtnSettingsLicense.Name = "BtnSettingsLicense"
        Me.BtnSettingsLicense.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsLicense.Text = "Licença"
        '
        'BtnSettingsCloud
        '
        Me.BtnSettingsCloud.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSettingsCloudStorage, Me.BtnSettingsCloudDatabase})
        Me.BtnSettingsCloud.Name = "BtnSettingsCloud"
        Me.BtnSettingsCloud.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsCloud.Text = "Núvem"
        '
        'BtnSettingsCloudStorage
        '
        Me.BtnSettingsCloudStorage.Name = "BtnSettingsCloudStorage"
        Me.BtnSettingsCloudStorage.Size = New System.Drawing.Size(185, 22)
        Me.BtnSettingsCloudStorage.Text = "Armazenamento"
        '
        'BtnSettingsCloudDatabase
        '
        Me.BtnSettingsCloudDatabase.Name = "BtnSettingsCloudDatabase"
        Me.BtnSettingsCloudDatabase.Size = New System.Drawing.Size(185, 22)
        Me.BtnSettingsCloudDatabase.Text = "Banco de Dados"
        '
        'BtnSettingsSupport
        '
        Me.BtnSettingsSupport.Name = "BtnSettingsSupport"
        Me.BtnSettingsSupport.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsSupport.Text = "Suporte"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(220, 6)
        '
        'BtnSettingsChangePassword
        '
        Me.BtnSettingsChangePassword.Name = "BtnSettingsChangePassword"
        Me.BtnSettingsChangePassword.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsChangePassword.Text = "Alterar Senha"
        '
        'BtnSettingsChangeKey
        '
        Me.BtnSettingsChangeKey.Name = "BtnSettingsChangeKey"
        Me.BtnSettingsChangeKey.Size = New System.Drawing.Size(223, 22)
        Me.BtnSettingsChangeKey.Text = "Alterar Chave"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(220, 6)
        '
        'BtnCleanEventLog
        '
        Me.BtnCleanEventLog.Name = "BtnCleanEventLog"
        Me.BtnCleanEventLog.Size = New System.Drawing.Size(223, 22)
        Me.BtnCleanEventLog.Text = "Limpar Log de Eventos"
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
        Me.BtnBackup.Size = New System.Drawing.Size(150, 53)
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
        Me.BtnClean.Size = New System.Drawing.Size(150, 53)
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
        Me.BtnRelease.Size = New System.Drawing.Size(150, 53)
        Me.BtnRelease.Text = "Desbloquear Registros"
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
        Me.BtnCloudSync.Size = New System.Drawing.Size(150, 53)
        Me.BtnCloudSync.Text = "Sincronizar Núvem"
        Me.BtnCloudSync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCloudSync.ToolTipText = "Sincroniza os dados do banco de dados local, com o banco de dados na núvem"
        '
        'TpbProgress
        '
        Me.TpbProgress.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TpbProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TpbProgress.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TpbProgress.ForeColor = System.Drawing.Color.White
        Me.TpbProgress.Location = New System.Drawing.Point(0, 659)
        Me.TpbProgress.Maximum = 100
        Me.TpbProgress.Minimum = 0
        Me.TpbProgress.Name = "TpbProgress"
        Me.TpbProgress.ProgressBottomColor = System.Drawing.Color.White
        Me.TpbProgress.ProgressTopColor = System.Drawing.Color.White
        Me.TpbProgress.Size = New System.Drawing.Size(984, 2)
        Me.TpbProgress.TabIndex = 19
        Me.TpbProgress.Value = 0
        Me.TpbProgress.Visible = False
        '
        'LblProgress
        '
        Me.LblProgress.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblProgress.ForeColor = System.Drawing.Color.White
        Me.LblProgress.Location = New System.Drawing.Point(0, 631)
        Me.LblProgress.Name = "LblProgress"
        Me.LblProgress.Size = New System.Drawing.Size(984, 28)
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
        Me.ScTaskEvent.Size = New System.Drawing.Size(984, 568)
        Me.ScTaskEvent.SplitterDistance = 207
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
        Me.ScTaskWarning.Size = New System.Drawing.Size(207, 568)
        Me.ScTaskWarning.SplitterDistance = 250
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTasks.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTasks.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DgvTasks.Location = New System.Drawing.Point(0, 28)
        Me.DgvTasks.Name = "DgvTasks"
        Me.DgvTasks.ReadOnly = True
        Me.DgvTasks.RowHeadersVisible = False
        Me.DgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTasks.Size = New System.Drawing.Size(205, 538)
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
        Me.Label2.Size = New System.Drawing.Size(205, 28)
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvWarnings.DefaultCellStyle = DataGridViewCellStyle3
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
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.ScTaskEvent)
        Me.Controls.Add(Me.LblProgress)
        Me.Controls.Add(Me.TpbProgress)
        Me.Controls.Add(Me.TsTitle)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "Gerenciador"
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
    Friend WithEvents TpbProgress As ControlLibrary.TextedProgressBar
    Friend WithEvents BtnClean As ToolStripButton
    Friend WithEvents LblProgress As Label
    Friend WithEvents ScTaskEvent As SplitContainer
    Friend WithEvents BtnSettings As ToolStripDropDownButton
    Friend WithEvents BtnSettingsRegister As ToolStripMenuItem
    Friend WithEvents BtnSettingsDatabase As ToolStripMenuItem
    Friend WithEvents BtnSettingsCloud As ToolStripMenuItem
    Friend WithEvents BtnSettingsBackup As ToolStripMenuItem
    Friend WithEvents BtnSettingsSupport As ToolStripMenuItem
    Friend WithEvents BtnSettingsGeneral As ToolStripMenuItem
    Friend WithEvents BtnSettingsCloudStorage As ToolStripMenuItem
    Friend WithEvents BtnSettingsCloudDatabase As ToolStripMenuItem
    Friend WithEvents BtnSettingsUser As ToolStripMenuItem
    Friend WithEvents BtnSettingsEvaluation As ToolStripMenuItem
    Friend WithEvents BtnSettingsRelease As ToolStripMenuItem
    Friend WithEvents BtnSettingsLicense As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BtnSettingsChangePassword As ToolStripMenuItem
    Friend WithEvents BtnCloudSync As ToolStripButton
    Friend WithEvents BtnRelease As ToolStripButton
    Friend WithEvents BtnSettingsChangeKey As ToolStripMenuItem
    Friend WithEvents ScTaskWarning As SplitContainer
    Friend WithEvents DgvTasks As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents DgvWarnings As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnSettingsClean As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BtnCleanEventLog As ToolStripMenuItem
End Class
