<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEvaluationManagementPanel
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TsMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.BtnClose = New System.Windows.Forms.ToolStripButton()
        Me.BtnExport = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnExportPanelImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnExportGrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnContainer = New System.Windows.Forms.Panel()
        Me.Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PnChartOptions = New System.Windows.Forms.Panel()
        Me.CbxMonth = New ControlLibrary.CentralizedComboBox()
        Me.CbxYear = New ControlLibrary.CentralizedComboBox()
        Me.CbxInformation = New ControlLibrary.CentralizedComboBox()
        Me.LblInformation = New System.Windows.Forms.Label()
        Me.LblMonth = New System.Windows.Forms.Label()
        Me.LblYear = New System.Windows.Forms.Label()
        Me.TlpCards = New System.Windows.Forms.TableLayoutPanel()
        Me.PnNeverVisited = New System.Windows.Forms.Panel()
        Me.LblNeverVisitedValue = New System.Windows.Forms.Label()
        Me.LblNeverVisited = New System.Windows.Forms.Label()
        Me.PnToOverdue = New System.Windows.Forms.Panel()
        Me.LblToOverdueValue = New System.Windows.Forms.Label()
        Me.LblToOverdue = New System.Windows.Forms.Label()
        Me.PnInDay = New System.Windows.Forms.Panel()
        Me.LblInDayValue = New System.Windows.Forms.Label()
        Me.LblInDay = New System.Windows.Forms.Label()
        Me.PnOverdue = New System.Windows.Forms.Panel()
        Me.LblOverdueValue = New System.Windows.Forms.Label()
        Me.LblOverdue = New System.Windows.Forms.Label()
        Me.PnTotal = New System.Windows.Forms.Panel()
        Me.LblTotalValue = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.PnToVisit = New System.Windows.Forms.Panel()
        Me.LblToVisitValue = New System.Windows.Forms.Label()
        Me.LblToVisit = New System.Windows.Forms.Label()
        Me.PnOverdueUnit = New System.Windows.Forms.Panel()
        Me.LblOverdueUnitValue = New System.Windows.Forms.Label()
        Me.LblOverdueUnit = New System.Windows.Forms.Label()
        Me.CcoInDay = New ControlLibrary.ControlContainer()
        Me.CcoToOverdue = New ControlLibrary.ControlContainer()
        Me.CcoOverdue = New ControlLibrary.ControlContainer()
        Me.CcoNoVisited = New ControlLibrary.ControlContainer()
        Me.CcoTotal = New ControlLibrary.ControlContainer()
        Me.CcoToVisit = New ControlLibrary.ControlContainer()
        Me.Tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.CcoOverdueUnit = New ControlLibrary.ControlContainer()
        Me.TsMenu.SuspendLayout()
        Me.PnContainer.SuspendLayout()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnChartOptions.SuspendLayout()
        Me.TlpCards.SuspendLayout()
        Me.PnNeverVisited.SuspendLayout()
        Me.PnToOverdue.SuspendLayout()
        Me.PnInDay.SuspendLayout()
        Me.PnOverdue.SuspendLayout()
        Me.PnTotal.SuspendLayout()
        Me.PnToVisit.SuspendLayout()
        Me.PnOverdueUnit.SuspendLayout()
        Me.SuspendLayout()
        '
        'TsMenu
        '
        Me.TsMenu.BackColor = System.Drawing.Color.White
        Me.TsMenu.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnRefresh, Me.BtnClose, Me.BtnExport})
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
        Me.BtnExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExportPanelImage, Me.BtnExportGrid})
        Me.BtnExport.Image = Global.Manager.My.Resources.Resources.Export
        Me.BtnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(106, 36)
        Me.BtnExport.Text = "Exportar"
        '
        'BtnExportPanelImage
        '
        Me.BtnExportPanelImage.Name = "BtnExportPanelImage"
        Me.BtnExportPanelImage.Size = New System.Drawing.Size(196, 22)
        Me.BtnExportPanelImage.Text = "Imagem do Painel"
        '
        'BtnExportGrid
        '
        Me.BtnExportGrid.Name = "BtnExportGrid"
        Me.BtnExportGrid.Size = New System.Drawing.Size(196, 22)
        Me.BtnExportGrid.Text = "Grades"
        '
        'PnContainer
        '
        Me.PnContainer.Controls.Add(Me.Chart)
        Me.PnContainer.Controls.Add(Me.PnChartOptions)
        Me.PnContainer.Controls.Add(Me.TlpCards)
        Me.PnContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnContainer.Location = New System.Drawing.Point(0, 39)
        Me.PnContainer.Name = "PnContainer"
        Me.PnContainer.Size = New System.Drawing.Size(1089, 522)
        Me.PnContainer.TabIndex = 1
        '
        'Chart
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart.ChartAreas.Add(ChartArea3)
        Me.Chart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend3.Name = "Legend1"
        Me.Chart.Legends.Add(Legend3)
        Me.Chart.Location = New System.Drawing.Point(0, 207)
        Me.Chart.Name = "Chart"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart.Series.Add(Series3)
        Me.Chart.Size = New System.Drawing.Size(1089, 315)
        Me.Chart.TabIndex = 8
        Me.Chart.Text = "Chart1"
        '
        'PnChartOptions
        '
        Me.PnChartOptions.BackColor = System.Drawing.Color.White
        Me.PnChartOptions.Controls.Add(Me.CbxMonth)
        Me.PnChartOptions.Controls.Add(Me.CbxYear)
        Me.PnChartOptions.Controls.Add(Me.CbxInformation)
        Me.PnChartOptions.Controls.Add(Me.LblInformation)
        Me.PnChartOptions.Controls.Add(Me.LblMonth)
        Me.PnChartOptions.Controls.Add(Me.LblYear)
        Me.PnChartOptions.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnChartOptions.Location = New System.Drawing.Point(0, 161)
        Me.PnChartOptions.Name = "PnChartOptions"
        Me.PnChartOptions.Size = New System.Drawing.Size(1089, 46)
        Me.PnChartOptions.TabIndex = 7
        '
        'CbxMonth
        '
        Me.CbxMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxMonth.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.CbxMonth.FormattingEnabled = True
        Me.CbxMonth.Location = New System.Drawing.Point(825, 6)
        Me.CbxMonth.Name = "CbxMonth"
        Me.CbxMonth.Size = New System.Drawing.Size(156, 32)
        Me.CbxMonth.TabIndex = 0
        '
        'CbxYear
        '
        Me.CbxYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxYear.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.CbxYear.FormattingEnabled = True
        Me.CbxYear.Location = New System.Drawing.Point(584, 6)
        Me.CbxYear.Name = "CbxYear"
        Me.CbxYear.Size = New System.Drawing.Size(156, 32)
        Me.CbxYear.TabIndex = 0
        '
        'CbxInformation
        '
        Me.CbxInformation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxInformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxInformation.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxInformation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.CbxInformation.Location = New System.Drawing.Point(183, 6)
        Me.CbxInformation.Name = "CbxInformation"
        Me.CbxInformation.Size = New System.Drawing.Size(316, 32)
        Me.CbxInformation.TabIndex = 0
        '
        'LblInformation
        '
        Me.LblInformation.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInformation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblInformation.Location = New System.Drawing.Point(12, 3)
        Me.LblInformation.Name = "LblInformation"
        Me.LblInformation.Size = New System.Drawing.Size(165, 39)
        Me.LblInformation.TabIndex = 0
        Me.LblInformation.Text = "INFORMAÇÃO:"
        Me.LblInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMonth
        '
        Me.LblMonth.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblMonth.Location = New System.Drawing.Point(746, 3)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(73, 39)
        Me.LblMonth.TabIndex = 0
        Me.LblMonth.Text = "Mês:"
        Me.LblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblYear
        '
        Me.LblYear.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblYear.Location = New System.Drawing.Point(505, 3)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(73, 39)
        Me.LblYear.TabIndex = 0
        Me.LblYear.Text = "ANO:"
        Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TlpCards
        '
        Me.TlpCards.ColumnCount = 7
        Me.TlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28!))
        Me.TlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28!))
        Me.TlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28!))
        Me.TlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28!))
        Me.TlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28!))
        Me.TlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28!))
        Me.TlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.32!))
        Me.TlpCards.Controls.Add(Me.PnNeverVisited, 4, 0)
        Me.TlpCards.Controls.Add(Me.PnToOverdue, 1, 0)
        Me.TlpCards.Controls.Add(Me.PnInDay, 0, 0)
        Me.TlpCards.Controls.Add(Me.PnOverdue, 2, 0)
        Me.TlpCards.Controls.Add(Me.PnTotal, 6, 0)
        Me.TlpCards.Controls.Add(Me.PnToVisit, 5, 0)
        Me.TlpCards.Controls.Add(Me.PnOverdueUnit, 3, 0)
        Me.TlpCards.Dock = System.Windows.Forms.DockStyle.Top
        Me.TlpCards.Location = New System.Drawing.Point(0, 0)
        Me.TlpCards.Name = "TlpCards"
        Me.TlpCards.RowCount = 1
        Me.TlpCards.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpCards.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TlpCards.Size = New System.Drawing.Size(1089, 161)
        Me.TlpCards.TabIndex = 0
        '
        'PnNeverVisited
        '
        Me.PnNeverVisited.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnNeverVisited.Controls.Add(Me.LblNeverVisitedValue)
        Me.PnNeverVisited.Controls.Add(Me.LblNeverVisited)
        Me.PnNeverVisited.Location = New System.Drawing.Point(623, 10)
        Me.PnNeverVisited.Name = "PnNeverVisited"
        Me.PnNeverVisited.Size = New System.Drawing.Size(149, 141)
        Me.PnNeverVisited.TabIndex = 3
        '
        'LblNeverVisitedValue
        '
        Me.LblNeverVisitedValue.BackColor = System.Drawing.Color.White
        Me.LblNeverVisitedValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblNeverVisitedValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblNeverVisitedValue.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNeverVisitedValue.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblNeverVisitedValue.Location = New System.Drawing.Point(0, 33)
        Me.LblNeverVisitedValue.Name = "LblNeverVisitedValue"
        Me.LblNeverVisitedValue.Size = New System.Drawing.Size(149, 108)
        Me.LblNeverVisitedValue.TabIndex = 1
        Me.LblNeverVisitedValue.Text = "-"
        Me.LblNeverVisitedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblNeverVisited
        '
        Me.LblNeverVisited.BackColor = System.Drawing.Color.SteelBlue
        Me.LblNeverVisited.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblNeverVisited.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNeverVisited.ForeColor = System.Drawing.Color.White
        Me.LblNeverVisited.Location = New System.Drawing.Point(0, 0)
        Me.LblNeverVisited.Name = "LblNeverVisited"
        Me.LblNeverVisited.Size = New System.Drawing.Size(149, 33)
        Me.LblNeverVisited.TabIndex = 0
        Me.LblNeverVisited.Text = "NUNCA VISITADO"
        Me.LblNeverVisited.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnToOverdue
        '
        Me.PnToOverdue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnToOverdue.Controls.Add(Me.LblToOverdueValue)
        Me.PnToOverdue.Controls.Add(Me.LblToOverdue)
        Me.PnToOverdue.Location = New System.Drawing.Point(158, 10)
        Me.PnToOverdue.Name = "PnToOverdue"
        Me.PnToOverdue.Size = New System.Drawing.Size(149, 141)
        Me.PnToOverdue.TabIndex = 1
        '
        'LblToOverdueValue
        '
        Me.LblToOverdueValue.BackColor = System.Drawing.Color.White
        Me.LblToOverdueValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblToOverdueValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblToOverdueValue.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToOverdueValue.ForeColor = System.Drawing.Color.Goldenrod
        Me.LblToOverdueValue.Location = New System.Drawing.Point(0, 33)
        Me.LblToOverdueValue.Name = "LblToOverdueValue"
        Me.LblToOverdueValue.Size = New System.Drawing.Size(149, 108)
        Me.LblToOverdueValue.TabIndex = 1
        Me.LblToOverdueValue.Text = "-"
        Me.LblToOverdueValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblToOverdue
        '
        Me.LblToOverdue.BackColor = System.Drawing.Color.Goldenrod
        Me.LblToOverdue.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblToOverdue.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToOverdue.ForeColor = System.Drawing.Color.White
        Me.LblToOverdue.Location = New System.Drawing.Point(0, 0)
        Me.LblToOverdue.Name = "LblToOverdue"
        Me.LblToOverdue.Size = New System.Drawing.Size(149, 33)
        Me.LblToOverdue.TabIndex = 0
        Me.LblToOverdue.Text = "A VENCER"
        Me.LblToOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnInDay
        '
        Me.PnInDay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnInDay.Controls.Add(Me.LblInDayValue)
        Me.PnInDay.Controls.Add(Me.LblInDay)
        Me.PnInDay.Location = New System.Drawing.Point(3, 10)
        Me.PnInDay.Name = "PnInDay"
        Me.PnInDay.Size = New System.Drawing.Size(149, 141)
        Me.PnInDay.TabIndex = 0
        '
        'LblInDayValue
        '
        Me.LblInDayValue.BackColor = System.Drawing.Color.White
        Me.LblInDayValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblInDayValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblInDayValue.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInDayValue.ForeColor = System.Drawing.Color.ForestGreen
        Me.LblInDayValue.Location = New System.Drawing.Point(0, 33)
        Me.LblInDayValue.Name = "LblInDayValue"
        Me.LblInDayValue.Size = New System.Drawing.Size(149, 108)
        Me.LblInDayValue.TabIndex = 1
        Me.LblInDayValue.Text = "-"
        Me.LblInDayValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblInDay
        '
        Me.LblInDay.BackColor = System.Drawing.Color.ForestGreen
        Me.LblInDay.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblInDay.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInDay.ForeColor = System.Drawing.Color.White
        Me.LblInDay.Location = New System.Drawing.Point(0, 0)
        Me.LblInDay.Name = "LblInDay"
        Me.LblInDay.Size = New System.Drawing.Size(149, 33)
        Me.LblInDay.TabIndex = 0
        Me.LblInDay.Text = "EM DIA"
        Me.LblInDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnOverdue
        '
        Me.PnOverdue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnOverdue.Controls.Add(Me.LblOverdueValue)
        Me.PnOverdue.Controls.Add(Me.LblOverdue)
        Me.PnOverdue.Location = New System.Drawing.Point(313, 10)
        Me.PnOverdue.Name = "PnOverdue"
        Me.PnOverdue.Size = New System.Drawing.Size(149, 141)
        Me.PnOverdue.TabIndex = 2
        '
        'LblOverdueValue
        '
        Me.LblOverdueValue.BackColor = System.Drawing.Color.White
        Me.LblOverdueValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblOverdueValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblOverdueValue.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOverdueValue.ForeColor = System.Drawing.Color.Firebrick
        Me.LblOverdueValue.Location = New System.Drawing.Point(0, 33)
        Me.LblOverdueValue.Name = "LblOverdueValue"
        Me.LblOverdueValue.Size = New System.Drawing.Size(149, 108)
        Me.LblOverdueValue.TabIndex = 1
        Me.LblOverdueValue.Text = "-"
        Me.LblOverdueValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblOverdue
        '
        Me.LblOverdue.BackColor = System.Drawing.Color.Firebrick
        Me.LblOverdue.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblOverdue.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOverdue.ForeColor = System.Drawing.Color.White
        Me.LblOverdue.Location = New System.Drawing.Point(0, 0)
        Me.LblOverdue.Name = "LblOverdue"
        Me.LblOverdue.Size = New System.Drawing.Size(149, 33)
        Me.LblOverdue.TabIndex = 0
        Me.LblOverdue.Text = "VENCIDO"
        Me.LblOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnTotal
        '
        Me.PnTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnTotal.Controls.Add(Me.LblTotalValue)
        Me.PnTotal.Controls.Add(Me.LblTotal)
        Me.PnTotal.Location = New System.Drawing.Point(935, 10)
        Me.PnTotal.Name = "PnTotal"
        Me.PnTotal.Size = New System.Drawing.Size(149, 141)
        Me.PnTotal.TabIndex = 4
        '
        'LblTotalValue
        '
        Me.LblTotalValue.BackColor = System.Drawing.Color.White
        Me.LblTotalValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblTotalValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTotalValue.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalValue.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblTotalValue.Location = New System.Drawing.Point(0, 33)
        Me.LblTotalValue.Name = "LblTotalValue"
        Me.LblTotalValue.Size = New System.Drawing.Size(149, 108)
        Me.LblTotalValue.TabIndex = 1
        Me.LblTotalValue.Text = "-"
        Me.LblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.SteelBlue
        Me.LblTotal.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTotal.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.White
        Me.LblTotal.Location = New System.Drawing.Point(0, 0)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(149, 33)
        Me.LblTotal.TabIndex = 0
        Me.LblTotal.Text = "TOTAL"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnToVisit
        '
        Me.PnToVisit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnToVisit.Controls.Add(Me.LblToVisitValue)
        Me.PnToVisit.Controls.Add(Me.LblToVisit)
        Me.PnToVisit.Location = New System.Drawing.Point(778, 10)
        Me.PnToVisit.Name = "PnToVisit"
        Me.PnToVisit.Size = New System.Drawing.Size(149, 141)
        Me.PnToVisit.TabIndex = 4
        '
        'LblToVisitValue
        '
        Me.LblToVisitValue.BackColor = System.Drawing.Color.White
        Me.LblToVisitValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblToVisitValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblToVisitValue.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToVisitValue.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblToVisitValue.Location = New System.Drawing.Point(0, 33)
        Me.LblToVisitValue.Name = "LblToVisitValue"
        Me.LblToVisitValue.Size = New System.Drawing.Size(149, 108)
        Me.LblToVisitValue.TabIndex = 1
        Me.LblToVisitValue.Text = "-"
        Me.LblToVisitValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblToVisit
        '
        Me.LblToVisit.BackColor = System.Drawing.Color.SteelBlue
        Me.LblToVisit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblToVisit.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold)
        Me.LblToVisit.ForeColor = System.Drawing.Color.White
        Me.LblToVisit.Location = New System.Drawing.Point(0, 0)
        Me.LblToVisit.Name = "LblToVisit"
        Me.LblToVisit.Size = New System.Drawing.Size(149, 33)
        Me.LblToVisit.TabIndex = 0
        Me.LblToVisit.Text = "A VISITAR"
        Me.LblToVisit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnOverdueUnit
        '
        Me.PnOverdueUnit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnOverdueUnit.Controls.Add(Me.LblOverdueUnitValue)
        Me.PnOverdueUnit.Controls.Add(Me.LblOverdueUnit)
        Me.PnOverdueUnit.Location = New System.Drawing.Point(468, 10)
        Me.PnOverdueUnit.Name = "PnOverdueUnit"
        Me.PnOverdueUnit.Size = New System.Drawing.Size(149, 141)
        Me.PnOverdueUnit.TabIndex = 3
        '
        'LblOverdueUnitValue
        '
        Me.LblOverdueUnitValue.BackColor = System.Drawing.Color.White
        Me.LblOverdueUnitValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblOverdueUnitValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblOverdueUnitValue.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOverdueUnitValue.ForeColor = System.Drawing.Color.Firebrick
        Me.LblOverdueUnitValue.Location = New System.Drawing.Point(0, 33)
        Me.LblOverdueUnitValue.Name = "LblOverdueUnitValue"
        Me.LblOverdueUnitValue.Size = New System.Drawing.Size(149, 108)
        Me.LblOverdueUnitValue.TabIndex = 1
        Me.LblOverdueUnitValue.Text = "-"
        Me.LblOverdueUnitValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblOverdueUnit
        '
        Me.LblOverdueUnit.BackColor = System.Drawing.Color.Firebrick
        Me.LblOverdueUnit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblOverdueUnit.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOverdueUnit.ForeColor = System.Drawing.Color.White
        Me.LblOverdueUnit.Location = New System.Drawing.Point(0, 0)
        Me.LblOverdueUnit.Name = "LblOverdueUnit"
        Me.LblOverdueUnit.Size = New System.Drawing.Size(149, 33)
        Me.LblOverdueUnit.TabIndex = 0
        Me.LblOverdueUnit.Text = "UND. VENCIDA"
        Me.LblOverdueUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CcoInDay
        '
        Me.CcoInDay.DropDownBorderColor = System.Drawing.Color.ForestGreen
        Me.CcoInDay.DropDownControl = Nothing
        Me.CcoInDay.DropDownEnabled = True
        Me.CcoInDay.HostControl = Nothing
        '
        'CcoToOverdue
        '
        Me.CcoToOverdue.DropDownBorderColor = System.Drawing.Color.Goldenrod
        Me.CcoToOverdue.DropDownControl = Nothing
        Me.CcoToOverdue.DropDownEnabled = True
        Me.CcoToOverdue.HostControl = Nothing
        '
        'CcoOverdue
        '
        Me.CcoOverdue.DropDownBorderColor = System.Drawing.Color.Firebrick
        Me.CcoOverdue.DropDownControl = Nothing
        Me.CcoOverdue.DropDownEnabled = True
        Me.CcoOverdue.HostControl = Nothing
        '
        'CcoNoVisited
        '
        Me.CcoNoVisited.DropDownBorderColor = System.Drawing.Color.SteelBlue
        Me.CcoNoVisited.DropDownControl = Nothing
        Me.CcoNoVisited.DropDownEnabled = True
        Me.CcoNoVisited.HostControl = Nothing
        '
        'CcoTotal
        '
        Me.CcoTotal.DropDownBorderColor = System.Drawing.Color.SteelBlue
        Me.CcoTotal.DropDownControl = Nothing
        Me.CcoTotal.DropDownEnabled = True
        Me.CcoTotal.HostControl = Nothing
        '
        'CcoToVisit
        '
        Me.CcoToVisit.DropDownBorderColor = System.Drawing.Color.SteelBlue
        Me.CcoToVisit.DropDownControl = Nothing
        Me.CcoToVisit.DropDownEnabled = True
        Me.CcoToVisit.HostControl = Nothing
        '
        'CcoOverdueUnit
        '
        Me.CcoOverdueUnit.DropDownBorderColor = System.Drawing.Color.Firebrick
        Me.CcoOverdueUnit.DropDownControl = Nothing
        Me.CcoOverdueUnit.DropDownEnabled = True
        Me.CcoOverdueUnit.HostControl = Nothing
        '
        'FrmEvaluationManagementPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1089, 561)
        Me.Controls.Add(Me.PnContainer)
        Me.Controls.Add(Me.TsMenu)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmEvaluationManagementPanel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TsMenu.ResumeLayout(False)
        Me.TsMenu.PerformLayout()
        Me.PnContainer.ResumeLayout(False)
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnChartOptions.ResumeLayout(False)
        Me.TlpCards.ResumeLayout(False)
        Me.PnNeverVisited.ResumeLayout(False)
        Me.PnToOverdue.ResumeLayout(False)
        Me.PnInDay.ResumeLayout(False)
        Me.PnOverdue.ResumeLayout(False)
        Me.PnTotal.ResumeLayout(False)
        Me.PnToVisit.ResumeLayout(False)
        Me.PnOverdueUnit.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TsMenu As ToolStrip
    Friend WithEvents BtnRefresh As ToolStripButton
    Friend WithEvents BtnClose As ToolStripButton
    Friend WithEvents FffffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnExport As ToolStripDropDownButton
    Friend WithEvents PnContainer As Panel
    Friend WithEvents CbxYear As ControlLibrary.CentralizedComboBox
    Friend WithEvents LblYear As Label
    Friend WithEvents TlpCards As TableLayoutPanel
    Friend WithEvents PnNeverVisited As Panel
    Friend WithEvents LblNeverVisitedValue As Label
    Friend WithEvents LblNeverVisited As Label
    Friend WithEvents PnInDay As Panel
    Friend WithEvents LblInDayValue As Label
    Friend WithEvents LblInDay As Label
    Friend WithEvents PnToOverdue As Panel
    Friend WithEvents LblToOverdueValue As Label
    Friend WithEvents LblToOverdue As Label
    Friend WithEvents PnOverdue As Panel
    Friend WithEvents LblOverdueValue As Label
    Friend WithEvents LblOverdue As Label
    Friend WithEvents PnTotal As Panel
    Friend WithEvents LblTotalValue As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents CcoInDay As ControlLibrary.ControlContainer
    Friend WithEvents CcoToOverdue As ControlLibrary.ControlContainer
    Friend WithEvents CcoOverdue As ControlLibrary.ControlContainer
    Friend WithEvents CcoNoVisited As ControlLibrary.ControlContainer
    Friend WithEvents CcoTotal As ControlLibrary.ControlContainer
    Friend WithEvents PnToVisit As Panel
    Friend WithEvents LblToVisitValue As Label
    Friend WithEvents LblToVisit As Label
    Friend WithEvents CcoToVisit As ControlLibrary.ControlContainer
    Friend WithEvents Tip As ToolTip
    Friend WithEvents BtnExportPanelImage As ToolStripMenuItem
    Friend WithEvents BtnExportGrid As ToolStripMenuItem
    Friend WithEvents PnChartOptions As Panel
    Friend WithEvents CbxInformation As ControlLibrary.CentralizedComboBox
    Friend WithEvents LblInformation As Label
    Friend WithEvents CbxMonth As ControlLibrary.CentralizedComboBox
    Friend WithEvents LblMonth As Label
    Friend WithEvents PnOverdueUnit As Panel
    Friend WithEvents LblOverdueUnitValue As Label
    Friend WithEvents LblOverdueUnit As Label
    Friend WithEvents Chart As DataVisualization.Charting.Chart
    Friend WithEvents CcoOverdueUnit As ControlLibrary.ControlContainer
End Class
