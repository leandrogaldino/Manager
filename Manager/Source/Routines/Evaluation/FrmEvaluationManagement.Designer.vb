﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvaluationManagement
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.TsMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.BtnFilter = New System.Windows.Forms.ToolStripButton()
        Me.BtnDetails = New System.Windows.Forms.ToolStripButton()
        Me.BtnClose = New System.Windows.Forms.ToolStripButton()
        Me.BtnExport = New System.Windows.Forms.ToolStripButton()
        Me.SsInformation = New System.Windows.Forms.StatusStrip()
        Me.LblInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PgFilter = New System.Windows.Forms.PropertyGrid()
        Me.TsFilterTop = New System.Windows.Forms.ToolStrip()
        Me.BtnCloseFilter = New System.Windows.Forms.ToolStripButton()
        Me.LblFilter = New System.Windows.Forms.ToolStripLabel()
        Me.TsFilterBot = New System.Windows.Forms.ToolStrip()
        Me.BtnClean = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.DgvPartWorkedHour = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvPartElapsedDay = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblUnit = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TsDetails = New System.Windows.Forms.ToolStrip()
        Me.BtnCloseDetails = New System.Windows.Forms.ToolStripButton()
        Me.LblView = New System.Windows.Forms.ToolStripLabel()
        Me.DgvData = New System.Windows.Forms.DataGridView()
        Me.TmrLoadDetails = New System.Windows.Forms.Timer(Me.components)
        Me.DgvEvaluationManagementLayout = New Manager.DataGridViewLayout()
        Me.CmsAutoEvaluation = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnAutoEvaluation = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnVisitSchedule = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsMenu.SuspendLayout()
        Me.SsInformation.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TsFilterTop.SuspendLayout()
        Me.TsFilterBot.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TsDetails.SuspendLayout()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsAutoEvaluation.SuspendLayout()
        Me.SuspendLayout()
        '
        'TsMenu
        '
        Me.TsMenu.BackColor = System.Drawing.Color.White
        Me.TsMenu.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnRefresh, Me.BtnFilter, Me.BtnDetails, Me.BtnClose, Me.BtnExport})
        Me.TsMenu.Location = New System.Drawing.Point(0, 0)
        Me.TsMenu.Name = "TsMenu"
        Me.TsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMenu.Size = New System.Drawing.Size(1089, 39)
        Me.TsMenu.TabIndex = 0
        '
        'BtnRefresh
        '
        Me.BtnRefresh.AutoToolTip = False
        Me.BtnRefresh.Image = Global.Manager.My.Resources.Resources.Refresh
        Me.BtnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(100, 36)
        Me.BtnRefresh.Text = "Atualizar"
        '
        'BtnFilter
        '
        Me.BtnFilter.AutoToolTip = False
        Me.BtnFilter.BackColor = System.Drawing.Color.White
        Me.BtnFilter.CheckOnClick = True
        Me.BtnFilter.Image = Global.Manager.My.Resources.Resources.Filter
        Me.BtnFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFilter.Name = "BtnFilter"
        Me.BtnFilter.Size = New System.Drawing.Size(74, 36)
        Me.BtnFilter.Text = "Filtro"
        '
        'BtnDetails
        '
        Me.BtnDetails.AutoToolTip = False
        Me.BtnDetails.CheckOnClick = True
        Me.BtnDetails.Image = Global.Manager.My.Resources.Resources.Detail
        Me.BtnDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnDetails.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDetails.Name = "BtnDetails"
        Me.BtnDetails.Size = New System.Drawing.Size(100, 36)
        Me.BtnDetails.Text = "Detalhes"
        '
        'BtnClose
        '
        Me.BtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnClose.AutoToolTip = False
        Me.BtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnClose.Image = Global.Manager.My.Resources.Resources.Close
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(36, 36)
        Me.BtnClose.Text = "Fechar"
        '
        'BtnExport
        '
        Me.BtnExport.AutoToolTip = False
        Me.BtnExport.Image = Global.Manager.My.Resources.Resources.Export
        Me.BtnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(97, 36)
        Me.BtnExport.Text = "Exportar"
        '
        'SsInformation
        '
        Me.SsInformation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SsInformation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblInfo, Me.LblStatus, Me.LblCounter})
        Me.SsInformation.Location = New System.Drawing.Point(0, 478)
        Me.SsInformation.Name = "SsInformation"
        Me.SsInformation.Size = New System.Drawing.Size(1089, 22)
        Me.SsInformation.SizingGrip = False
        Me.SsInformation.Stretch = False
        Me.SsInformation.TabIndex = 2
        Me.SsInformation.Text = "StatusStrip1"
        '
        'LblInfo
        '
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Size = New System.Drawing.Size(0, 17)
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(36, 17)
        Me.LblStatus.Text = "       "
        '
        'LblCounter
        '
        Me.LblCounter.Name = "LblCounter"
        Me.LblCounter.Size = New System.Drawing.Size(1038, 17)
        Me.LblCounter.Spring = True
        Me.LblCounter.Text = "       "
        Me.LblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.PgFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TsFilterTop)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TsFilterBot)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1089, 439)
        Me.SplitContainer1.SplitterDistance = 261
        Me.SplitContainer1.TabIndex = 3
        '
        'PgFilter
        '
        Me.PgFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PgFilter.HelpVisible = False
        Me.PgFilter.Location = New System.Drawing.Point(0, 25)
        Me.PgFilter.Name = "PgFilter"
        Me.PgFilter.PropertySort = System.Windows.Forms.PropertySort.NoSort
        Me.PgFilter.Size = New System.Drawing.Size(259, 387)
        Me.PgFilter.TabIndex = 1
        Me.PgFilter.ToolbarVisible = False
        '
        'TsFilterTop
        '
        Me.TsFilterTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsFilterTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCloseFilter, Me.LblFilter})
        Me.TsFilterTop.Location = New System.Drawing.Point(0, 0)
        Me.TsFilterTop.Name = "TsFilterTop"
        Me.TsFilterTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsFilterTop.Size = New System.Drawing.Size(259, 25)
        Me.TsFilterTop.TabIndex = 0
        Me.TsFilterTop.Text = "ToolStrip1"
        '
        'BtnCloseFilter
        '
        Me.BtnCloseFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnCloseFilter.AutoToolTip = False
        Me.BtnCloseFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCloseFilter.Image = Global.Manager.My.Resources.Resources.Close
        Me.BtnCloseFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCloseFilter.Name = "BtnCloseFilter"
        Me.BtnCloseFilter.Size = New System.Drawing.Size(23, 22)
        Me.BtnCloseFilter.Text = "Fechar"
        '
        'LblFilter
        '
        Me.LblFilter.BackColor = System.Drawing.SystemColors.Control
        Me.LblFilter.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(122, 22)
        Me.LblFilter.Text = "Parâmetros do Filtro"
        '
        'TsFilterBot
        '
        Me.TsFilterBot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TsFilterBot.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsFilterBot.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnClean})
        Me.TsFilterBot.Location = New System.Drawing.Point(0, 412)
        Me.TsFilterBot.Name = "TsFilterBot"
        Me.TsFilterBot.Size = New System.Drawing.Size(259, 25)
        Me.TsFilterBot.TabIndex = 2
        Me.TsFilterBot.Text = "ToolStrip1"
        '
        'BtnClean
        '
        Me.BtnClean.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnClean.AutoToolTip = False
        Me.BtnClean.Image = Global.Manager.My.Resources.Resources.Clean
        Me.BtnClean.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClean.Name = "BtnClean"
        Me.BtnClean.Size = New System.Drawing.Size(64, 22)
        Me.BtnClean.Text = "Limpar"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TsDetails)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DgvData)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer2.Size = New System.Drawing.Size(824, 439)
        Me.SplitContainer2.SplitterDistance = 272
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 76)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.DgvPartWorkedHour)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.DgvPartElapsedDay)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer3.Size = New System.Drawing.Size(270, 361)
        Me.SplitContainer3.SplitterDistance = 180
        Me.SplitContainer3.TabIndex = 2
        '
        'DgvPartWorkedHour
        '
        Me.DgvPartWorkedHour.AllowUserToAddRows = False
        Me.DgvPartWorkedHour.AllowUserToDeleteRows = False
        Me.DgvPartWorkedHour.AllowUserToOrderColumns = True
        Me.DgvPartWorkedHour.AllowUserToResizeRows = False
        Me.DgvPartWorkedHour.BackgroundColor = System.Drawing.Color.White
        Me.DgvPartWorkedHour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvPartWorkedHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartWorkedHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartWorkedHour.Location = New System.Drawing.Point(0, 26)
        Me.DgvPartWorkedHour.MultiSelect = False
        Me.DgvPartWorkedHour.Name = "DgvPartWorkedHour"
        Me.DgvPartWorkedHour.ReadOnly = True
        Me.DgvPartWorkedHour.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartWorkedHour.RowHeadersVisible = False
        Me.DgvPartWorkedHour.RowTemplate.Height = 26
        Me.DgvPartWorkedHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartWorkedHour.Size = New System.Drawing.Size(270, 154)
        Me.DgvPartWorkedHour.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 26)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Controla Hora Trabalhada"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DgvPartElapsedDay
        '
        Me.DgvPartElapsedDay.AllowUserToAddRows = False
        Me.DgvPartElapsedDay.AllowUserToDeleteRows = False
        Me.DgvPartElapsedDay.AllowUserToOrderColumns = True
        Me.DgvPartElapsedDay.AllowUserToResizeRows = False
        Me.DgvPartElapsedDay.BackgroundColor = System.Drawing.Color.White
        Me.DgvPartElapsedDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvPartElapsedDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartElapsedDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartElapsedDay.Location = New System.Drawing.Point(0, 26)
        Me.DgvPartElapsedDay.MultiSelect = False
        Me.DgvPartElapsedDay.Name = "DgvPartElapsedDay"
        Me.DgvPartElapsedDay.ReadOnly = True
        Me.DgvPartElapsedDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartElapsedDay.RowHeadersVisible = False
        Me.DgvPartElapsedDay.RowTemplate.Height = 26
        Me.DgvPartElapsedDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartElapsedDay.Size = New System.Drawing.Size(270, 151)
        Me.DgvPartElapsedDay.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(270, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Controla Dia Corrido"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblUnit)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(270, 51)
        Me.Panel1.TabIndex = 3
        '
        'LblUnit
        '
        Me.LblUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblUnit.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnit.ForeColor = System.Drawing.Color.Green
        Me.LblUnit.Location = New System.Drawing.Point(0, 26)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(270, 25)
        Me.LblUnit.TabIndex = 3
        Me.LblUnit.Text = "01/01/2023"
        Me.LblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(270, 26)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Unidade Compressora"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TsDetails
        '
        Me.TsDetails.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsDetails.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCloseDetails, Me.LblView})
        Me.TsDetails.Location = New System.Drawing.Point(0, 0)
        Me.TsDetails.Name = "TsDetails"
        Me.TsDetails.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsDetails.Size = New System.Drawing.Size(270, 25)
        Me.TsDetails.TabIndex = 0
        Me.TsDetails.Text = "ToolStrip2"
        '
        'BtnCloseDetails
        '
        Me.BtnCloseDetails.AutoToolTip = False
        Me.BtnCloseDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCloseDetails.Image = Global.Manager.My.Resources.Resources.Close
        Me.BtnCloseDetails.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCloseDetails.Name = "BtnCloseDetails"
        Me.BtnCloseDetails.Size = New System.Drawing.Size(23, 22)
        Me.BtnCloseDetails.Text = "Fechar"
        '
        'LblView
        '
        Me.LblView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblView.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblView.Name = "LblView"
        Me.LblView.Size = New System.Drawing.Size(149, 22)
        Me.LblView.Text = "Detalhes do Compressor"
        '
        'DgvData
        '
        Me.DgvData.AllowUserToAddRows = False
        Me.DgvData.AllowUserToDeleteRows = False
        Me.DgvData.AllowUserToOrderColumns = True
        Me.DgvData.AllowUserToResizeRows = False
        Me.DgvData.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvData.Location = New System.Drawing.Point(0, 0)
        Me.DgvData.MultiSelect = False
        Me.DgvData.Name = "DgvData"
        Me.DgvData.ReadOnly = True
        Me.DgvData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvData.RowHeadersVisible = False
        Me.DgvData.RowTemplate.Height = 26
        Me.DgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvData.Size = New System.Drawing.Size(546, 437)
        Me.DgvData.TabIndex = 0
        '
        'TmrLoadDetails
        '
        Me.TmrLoadDetails.Interval = 1
        '
        'DgvEvaluationManagementLayout
        '
        Me.DgvEvaluationManagementLayout.DataGridView = Me.DgvData
        Me.DgvEvaluationManagementLayout.Routine = Manager.Routine.EvaluationManagement
        '
        'CmsAutoEvaluation
        '
        Me.CmsAutoEvaluation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnAutoEvaluation, Me.BtnVisitSchedule})
        Me.CmsAutoEvaluation.Name = "CmsApproval"
        Me.CmsAutoEvaluation.Size = New System.Drawing.Size(207, 70)
        '
        'BtnAutoEvaluation
        '
        Me.BtnAutoEvaluation.Name = "BtnAutoEvaluation"
        Me.BtnAutoEvaluation.Size = New System.Drawing.Size(206, 22)
        Me.BtnAutoEvaluation.Text = "Lançamento Automático"
        '
        'BtnVisitSchedule
        '
        Me.BtnVisitSchedule.Name = "BtnVisitSchedule"
        Me.BtnVisitSchedule.Size = New System.Drawing.Size(206, 22)
        Me.BtnVisitSchedule.Text = "Agendar Visita"
        '
        'FrmEvaluationManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1089, 500)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TsMenu)
        Me.Controls.Add(Me.SsInformation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmEvaluationManagement"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TsMenu.ResumeLayout(False)
        Me.TsMenu.PerformLayout()
        Me.SsInformation.ResumeLayout(False)
        Me.SsInformation.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TsFilterTop.ResumeLayout(False)
        Me.TsFilterTop.PerformLayout()
        Me.TsFilterBot.ResumeLayout(False)
        Me.TsFilterBot.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TsDetails.ResumeLayout(False)
        Me.TsDetails.PerformLayout()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsAutoEvaluation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TsMenu As ToolStrip
    Friend WithEvents BtnRefresh As ToolStripButton
    Friend WithEvents BtnClose As ToolStripButton
    Friend WithEvents BtnFilter As ToolStripButton
    Friend WithEvents SsInformation As StatusStrip
    Friend WithEvents LblInfo As ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PgFilter As PropertyGrid
    Friend WithEvents TsFilterTop As ToolStrip
    Friend WithEvents BtnCloseFilter As ToolStripButton
    Friend WithEvents LblFilter As ToolStripLabel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents TsDetails As ToolStrip
    Friend WithEvents BtnCloseDetails As ToolStripButton
    Friend WithEvents LblView As ToolStripLabel
    Friend WithEvents DgvData As DataGridView
    Friend WithEvents TsFilterBot As ToolStrip
    Friend WithEvents FffffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnClean As ToolStripButton
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents TmrLoadDetails As Timer
    Friend WithEvents LblCounter As ToolStripStatusLabel
    Friend WithEvents BtnDetails As ToolStripButton
    Friend WithEvents DgvEvaluationManagementLayout As DataGridViewLayout
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents DgvPartWorkedHour As DataGridView
    Friend WithEvents DgvPartElapsedDay As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnExport As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblUnit As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CmsAutoEvaluation As ContextMenuStrip
    Friend WithEvents BtnAutoEvaluation As ToolStripMenuItem
    Friend WithEvents BtnVisitSchedule As ToolStripMenuItem
End Class