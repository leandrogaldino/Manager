<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProducts
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
        Me.TsMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
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
        Me.TcDetail = New System.Windows.Forms.TabControl()
        Me.TpgProviderCode = New System.Windows.Forms.TabPage()
        Me.DgvProviderCode = New System.Windows.Forms.DataGridView()
        Me.TpgCode = New System.Windows.Forms.TabPage()
        Me.DgvCode = New System.Windows.Forms.DataGridView()
        Me.TabPrice = New System.Windows.Forms.TabPage()
        Me.DgvPrice = New System.Windows.Forms.DataGridView()
        Me.TabIndicator = New System.Windows.Forms.TabPage()
        Me.DgvIndicator = New System.Windows.Forms.DataGridView()
        Me.TsDetails = New System.Windows.Forms.ToolStrip()
        Me.BtnCloseDetails = New System.Windows.Forms.ToolStripButton()
        Me.LblView = New System.Windows.Forms.ToolStripLabel()
        Me.DgvData = New System.Windows.Forms.DataGridView()
        Me.TmrLoadDetails = New System.Windows.Forms.Timer(Me.components)
        Me.BtnDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DgvProductLayout = New Manager.DataGridViewLayout()
        Me.DgvCcData = New ControlLibrary.DataGridViewContentCopy()
        Me.DgvCcPrividerCode = New ControlLibrary.DataGridViewContentCopy()
        Me.DgvCcCode = New ControlLibrary.DataGridViewContentCopy()
        Me.DgvCcIndicator = New ControlLibrary.DataGridViewContentCopy()
        Me.DgvCcPrice = New ControlLibrary.DataGridViewContentCopy()
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
        Me.TcDetail.SuspendLayout()
        Me.TpgProviderCode.SuspendLayout()
        CType(Me.DgvProviderCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpgCode.SuspendLayout()
        CType(Me.DgvCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPrice.SuspendLayout()
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabIndicator.SuspendLayout()
        CType(Me.DgvIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsDetails.SuspendLayout()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TsMenu
        '
        Me.TsMenu.BackColor = System.Drawing.Color.White
        Me.TsMenu.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnEdit, Me.BtnDelete, Me.BtnRefresh, Me.BtnFilter, Me.BtnDetails, Me.BtnClose, Me.BtnExport})
        Me.TsMenu.Location = New System.Drawing.Point(0, 0)
        Me.TsMenu.Name = "TsMenu"
        Me.TsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMenu.Size = New System.Drawing.Size(1089, 39)
        Me.TsMenu.TabIndex = 0
        '
        'BtnInclude
        '
        Me.BtnInclude.AutoToolTip = False
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.Include
        Me.BtnInclude.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(81, 36)
        Me.BtnInclude.Text = "Incluir"
        '
        'BtnEdit
        '
        Me.BtnEdit.AutoToolTip = False
        Me.BtnEdit.Enabled = False
        Me.BtnEdit.Image = Global.Manager.My.Resources.Resources.Edit
        Me.BtnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(81, 36)
        Me.BtnEdit.Text = "Editar"
        '
        'BtnDelete
        '
        Me.BtnDelete.AutoToolTip = False
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.Delete
        Me.BtnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(83, 36)
        Me.BtnDelete.Text = "Excluir"
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.TcDetail)
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
        'TcDetail
        '
        Me.TcDetail.Controls.Add(Me.TpgProviderCode)
        Me.TcDetail.Controls.Add(Me.TpgCode)
        Me.TcDetail.Controls.Add(Me.TabPrice)
        Me.TcDetail.Controls.Add(Me.TabIndicator)
        Me.TcDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcDetail.Location = New System.Drawing.Point(0, 25)
        Me.TcDetail.Name = "TcDetail"
        Me.TcDetail.SelectedIndex = 0
        Me.TcDetail.Size = New System.Drawing.Size(270, 412)
        Me.TcDetail.TabIndex = 1
        '
        'TpgProviderCode
        '
        Me.TpgProviderCode.Controls.Add(Me.DgvProviderCode)
        Me.TpgProviderCode.Location = New System.Drawing.Point(4, 26)
        Me.TpgProviderCode.Name = "TpgProviderCode"
        Me.TpgProviderCode.Padding = New System.Windows.Forms.Padding(3)
        Me.TpgProviderCode.Size = New System.Drawing.Size(262, 382)
        Me.TpgProviderCode.TabIndex = 0
        Me.TpgProviderCode.Text = "Códigos de Fornecedor"
        Me.TpgProviderCode.UseVisualStyleBackColor = True
        '
        'DgvProviderCode
        '
        Me.DgvProviderCode.AllowUserToAddRows = False
        Me.DgvProviderCode.AllowUserToDeleteRows = False
        Me.DgvProviderCode.AllowUserToResizeColumns = False
        Me.DgvProviderCode.AllowUserToResizeRows = False
        Me.DgvProviderCode.BackgroundColor = System.Drawing.Color.White
        Me.DgvProviderCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvProviderCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProviderCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProviderCode.Location = New System.Drawing.Point(3, 3)
        Me.DgvProviderCode.MultiSelect = False
        Me.DgvProviderCode.Name = "DgvProviderCode"
        Me.DgvProviderCode.ReadOnly = True
        Me.DgvProviderCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvProviderCode.RowHeadersVisible = False
        Me.DgvProviderCode.RowTemplate.Height = 26
        Me.DgvProviderCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProviderCode.Size = New System.Drawing.Size(256, 376)
        Me.DgvProviderCode.TabIndex = 0
        '
        'TpgCode
        '
        Me.TpgCode.Controls.Add(Me.DgvCode)
        Me.TpgCode.Location = New System.Drawing.Point(4, 22)
        Me.TpgCode.Name = "TpgCode"
        Me.TpgCode.Padding = New System.Windows.Forms.Padding(3)
        Me.TpgCode.Size = New System.Drawing.Size(261, 384)
        Me.TpgCode.TabIndex = 1
        Me.TpgCode.Text = "Códigos de Produto"
        Me.TpgCode.UseVisualStyleBackColor = True
        '
        'DgvCode
        '
        Me.DgvCode.AllowUserToAddRows = False
        Me.DgvCode.AllowUserToDeleteRows = False
        Me.DgvCode.AllowUserToResizeColumns = False
        Me.DgvCode.AllowUserToResizeRows = False
        Me.DgvCode.BackgroundColor = System.Drawing.Color.White
        Me.DgvCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCode.Location = New System.Drawing.Point(3, 3)
        Me.DgvCode.MultiSelect = False
        Me.DgvCode.Name = "DgvCode"
        Me.DgvCode.ReadOnly = True
        Me.DgvCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvCode.RowHeadersVisible = False
        Me.DgvCode.RowTemplate.Height = 26
        Me.DgvCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCode.Size = New System.Drawing.Size(255, 378)
        Me.DgvCode.TabIndex = 1
        '
        'TabPrice
        '
        Me.TabPrice.Controls.Add(Me.DgvPrice)
        Me.TabPrice.Location = New System.Drawing.Point(4, 22)
        Me.TabPrice.Name = "TabPrice"
        Me.TabPrice.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPrice.Size = New System.Drawing.Size(261, 384)
        Me.TabPrice.TabIndex = 2
        Me.TabPrice.Text = "Preços"
        Me.TabPrice.UseVisualStyleBackColor = True
        '
        'DgvPrice
        '
        Me.DgvPrice.AllowUserToAddRows = False
        Me.DgvPrice.AllowUserToDeleteRows = False
        Me.DgvPrice.AllowUserToResizeColumns = False
        Me.DgvPrice.AllowUserToResizeRows = False
        Me.DgvPrice.BackgroundColor = System.Drawing.Color.White
        Me.DgvPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPrice.Location = New System.Drawing.Point(3, 3)
        Me.DgvPrice.MultiSelect = False
        Me.DgvPrice.Name = "DgvPrice"
        Me.DgvPrice.ReadOnly = True
        Me.DgvPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPrice.RowHeadersVisible = False
        Me.DgvPrice.RowTemplate.Height = 26
        Me.DgvPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPrice.Size = New System.Drawing.Size(255, 378)
        Me.DgvPrice.TabIndex = 1
        '
        'TabIndicator
        '
        Me.TabIndicator.Controls.Add(Me.DgvIndicator)
        Me.TabIndicator.Location = New System.Drawing.Point(4, 22)
        Me.TabIndicator.Name = "TabIndicator"
        Me.TabIndicator.Padding = New System.Windows.Forms.Padding(3)
        Me.TabIndicator.Size = New System.Drawing.Size(261, 384)
        Me.TabIndicator.TabIndex = 3
        Me.TabIndicator.Text = "Indicadores"
        Me.TabIndicator.UseVisualStyleBackColor = True
        '
        'DgvIndicator
        '
        Me.DgvIndicator.AllowUserToAddRows = False
        Me.DgvIndicator.AllowUserToDeleteRows = False
        Me.DgvIndicator.AllowUserToResizeColumns = False
        Me.DgvIndicator.AllowUserToResizeRows = False
        Me.DgvIndicator.BackgroundColor = System.Drawing.Color.White
        Me.DgvIndicator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvIndicator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvIndicator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvIndicator.Location = New System.Drawing.Point(3, 3)
        Me.DgvIndicator.MultiSelect = False
        Me.DgvIndicator.Name = "DgvIndicator"
        Me.DgvIndicator.ReadOnly = True
        Me.DgvIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvIndicator.RowHeadersVisible = False
        Me.DgvIndicator.RowTemplate.Height = 26
        Me.DgvIndicator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvIndicator.Size = New System.Drawing.Size(255, 378)
        Me.DgvIndicator.TabIndex = 1
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
        Me.LblView.Size = New System.Drawing.Size(57, 22)
        Me.LblView.Text = "Detalhes"
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
        '
        'BtnDuplicate
        '
        Me.BtnDuplicate.Name = "BtnDuplicate"
        Me.BtnDuplicate.Size = New System.Drawing.Size(118, 22)
        Me.BtnDuplicate.Text = "Duplicar"
        '
        'CmsMenu
        '
        Me.CmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnDuplicate})
        Me.CmsMenu.Name = "CmsMenu"
        Me.CmsMenu.Size = New System.Drawing.Size(119, 26)
        '
        'DgvProductLayout
        '
        Me.DgvProductLayout.DataGridView = Me.DgvData
        Me.DgvProductLayout.Routine = Manager.Routine.Product
        '
        'DgvCcData
        '
        Me.DgvCcData.ContextMenuStrip = Me.CmsMenu
        Me.DgvCcData.DataGridView = Me.DgvData
        Me.DgvCcData.IncludeHeaderTextInCellCopy = False
        Me.DgvCcData.IncludeHeaderTextInRowCopy = True
        '
        'DgvCcPrividerCode
        '
        Me.DgvCcPrividerCode.DataGridView = Me.DgvProviderCode
        Me.DgvCcPrividerCode.IncludeHeaderTextInCellCopy = False
        Me.DgvCcPrividerCode.IncludeHeaderTextInRowCopy = True
        '
        'DgvCcCode
        '
        Me.DgvCcCode.DataGridView = Me.DgvCode
        Me.DgvCcCode.IncludeHeaderTextInCellCopy = False
        Me.DgvCcCode.IncludeHeaderTextInRowCopy = True
        '
        'DgvCcIndicator
        '
        Me.DgvCcIndicator.DataGridView = Me.DgvIndicator
        Me.DgvCcIndicator.IncludeHeaderTextInCellCopy = False
        Me.DgvCcIndicator.IncludeHeaderTextInRowCopy = True
        '
        'DgvCcPrice
        '
        Me.DgvCcPrice.DataGridView = Me.DgvPrice
        Me.DgvCcPrice.IncludeHeaderTextInCellCopy = False
        Me.DgvCcPrice.IncludeHeaderTextInRowCopy = True
        '
        'FrmProducts
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
        Me.Name = "FrmProducts"
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
        Me.TcDetail.ResumeLayout(False)
        Me.TpgProviderCode.ResumeLayout(False)
        CType(Me.DgvProviderCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpgCode.ResumeLayout(False)
        CType(Me.DgvCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPrice.ResumeLayout(False)
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabIndicator.ResumeLayout(False)
        CType(Me.DgvIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsDetails.ResumeLayout(False)
        Me.TsDetails.PerformLayout()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TsMenu As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnEdit As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
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
    Friend WithEvents TcDetail As TabControl
    Friend WithEvents TpgProviderCode As TabPage
    Friend WithEvents TpgCode As TabPage
    Friend WithEvents DgvProductLayout As DataGridViewLayout
    Friend WithEvents DgvProviderCode As DataGridView
    Friend WithEvents DgvCode As DataGridView
    Friend WithEvents BtnExport As ToolStripButton
    Friend WithEvents TabPrice As TabPage
    Friend WithEvents DgvPrice As DataGridView
    Friend WithEvents TabIndicator As TabPage
    Friend WithEvents DgvIndicator As DataGridView
    Friend WithEvents BtnDuplicate As ToolStripMenuItem
    Friend WithEvents CmsMenu As ContextMenuStrip
    Friend WithEvents DgvCcData As ControlLibrary.DataGridViewContentCopy
    Friend WithEvents DgvCcPrividerCode As ControlLibrary.DataGridViewContentCopy
    Friend WithEvents DgvCcCode As ControlLibrary.DataGridViewContentCopy
    Friend WithEvents DgvCcIndicator As ControlLibrary.DataGridViewContentCopy
    Friend WithEvents DgvCcPrice As ControlLibrary.DataGridViewContentCopy
End Class
