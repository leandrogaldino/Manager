<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCash
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
        Dim MessageBoxSettings1 As Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings = New Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings()
        Dim PdfViewerPrinterSettings1 As Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings = New Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCash))
        Dim TextSearchSettings1 As Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings = New Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TcCash = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.DgvCashItem = New System.Windows.Forms.DataGridView()
        Me.TsCashItem = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCashItem = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCashItem = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCashItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.TabDocument = New System.Windows.Forms.TabPage()
        Me.PdfDocumentViewer = New Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView()
        Me.TsDocument = New System.Windows.Forms.ToolStrip()
        Me.BtnAttachPDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnSavePDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrintPDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.BtnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.LblDocumentPage = New System.Windows.Forms.ToolStripLabel()
        Me.TabNote = New System.Windows.Forms.TabPage()
        Me.TxtNote = New System.Windows.Forms.RichTextBox()
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatusValue = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnOpenCash = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnCloseCash = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblCreationDate = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationDateValue = New System.Windows.Forms.ToolStripLabel()
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.BtnCashSheet = New System.Windows.Forms.ToolStripButton()
        Me.TsValue = New System.Windows.Forms.ToolStrip()
        Me.LblCurrent = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel19 = New System.Windows.Forms.ToolStripLabel()
        Me.LblExpense = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel17 = New System.Windows.Forms.ToolStripLabel()
        Me.LblRefund = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel15 = New System.Windows.Forms.ToolStripLabel()
        Me.LblPrevious = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel13 = New System.Windows.Forms.ToolStripLabel()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SfdDocument = New System.Windows.Forms.SaveFileDialog()
        Me.OfdDocument = New System.Windows.Forms.OpenFileDialog()
        Me.DgvCashItemsLayout = New Manager.DataGridViewLayout()
        Me.Panel1.SuspendLayout()
        Me.TcCash.SuspendLayout()
        Me.TabMain.SuspendLayout()
        CType(Me.DgvCashItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsCashItem.SuspendLayout()
        Me.TabDocument.SuspendLayout()
        Me.TsDocument.SuspendLayout()
        Me.TabNote.SuspendLayout()
        Me.TsData.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        Me.TsValue.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 301)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(614, 44)
        Me.Panel1.TabIndex = 7
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(507, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(406, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TcCash
        '
        Me.TcCash.Controls.Add(Me.TabMain)
        Me.TcCash.Controls.Add(Me.TabDocument)
        Me.TcCash.Controls.Add(Me.TabNote)
        Me.TcCash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcCash.Location = New System.Drawing.Point(0, 50)
        Me.TcCash.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcCash.Multiline = True
        Me.TcCash.Name = "TcCash"
        Me.TcCash.SelectedIndex = 0
        Me.TcCash.Size = New System.Drawing.Size(614, 226)
        Me.TcCash.TabIndex = 6
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.DgvCashItem)
        Me.TabMain.Controls.Add(Me.TsCashItem)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(606, 196)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Lançamentos"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'DgvCashItem
        '
        Me.DgvCashItem.AllowUserToAddRows = False
        Me.DgvCashItem.AllowUserToDeleteRows = False
        Me.DgvCashItem.AllowUserToOrderColumns = True
        Me.DgvCashItem.AllowUserToResizeRows = False
        Me.DgvCashItem.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvCashItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCashItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCashItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCashItem.Location = New System.Drawing.Point(3, 29)
        Me.DgvCashItem.MultiSelect = False
        Me.DgvCashItem.Name = "DgvCashItem"
        Me.DgvCashItem.ReadOnly = True
        Me.DgvCashItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvCashItem.RowHeadersVisible = False
        Me.DgvCashItem.RowTemplate.Height = 26
        Me.DgvCashItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCashItem.Size = New System.Drawing.Size(600, 163)
        Me.DgvCashItem.TabIndex = 5
        '
        'TsCashItem
        '
        Me.TsCashItem.BackColor = System.Drawing.Color.White
        Me.TsCashItem.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsCashItem.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsCashItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCashItem, Me.BtnEditCashItem, Me.BtnDeleteCashItem, Me.ToolStripLabel1, Me.TxtFilter})
        Me.TsCashItem.Location = New System.Drawing.Point(3, 4)
        Me.TsCashItem.Name = "TsCashItem"
        Me.TsCashItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsCashItem.Size = New System.Drawing.Size(600, 25)
        Me.TsCashItem.TabIndex = 4
        '
        'BtnIncludeCashItem
        '
        Me.BtnIncludeCashItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeCashItem.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeCashItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeCashItem.Name = "BtnIncludeCashItem"
        Me.BtnIncludeCashItem.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeCashItem.Text = "Incluir Lançamento"
        '
        'BtnEditCashItem
        '
        Me.BtnEditCashItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditCashItem.Enabled = False
        Me.BtnEditCashItem.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditCashItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditCashItem.Name = "BtnEditCashItem"
        Me.BtnEditCashItem.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditCashItem.Text = "Editar Lançamento"
        Me.BtnEditCashItem.ToolTipText = "Editar"
        '
        'BtnDeleteCashItem
        '
        Me.BtnDeleteCashItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteCashItem.Enabled = False
        Me.BtnDeleteCashItem.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteCashItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteCashItem.Name = "BtnDeleteCashItem"
        Me.BtnDeleteCashItem.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteCashItem.Text = "Excluir Lançamento"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(46, 25)
        Me.ToolStripLabel1.Text = "Filtrar:"
        '
        'TxtFilter
        '
        Me.TxtFilter.AutoSize = False
        Me.TxtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtFilter.Name = "TxtFilter"
        Me.TxtFilter.Size = New System.Drawing.Size(200, 25)
        '
        'TabDocument
        '
        Me.TabDocument.Controls.Add(Me.PdfDocumentViewer)
        Me.TabDocument.Controls.Add(Me.TsDocument)
        Me.TabDocument.Location = New System.Drawing.Point(4, 26)
        Me.TabDocument.Name = "TabDocument"
        Me.TabDocument.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDocument.Size = New System.Drawing.Size(606, 196)
        Me.TabDocument.TabIndex = 2
        Me.TabDocument.Text = "Documento"
        Me.TabDocument.UseVisualStyleBackColor = True
        '
        'PdfDocumentViewer
        '
        Me.PdfDocumentViewer.AutoScroll = True
        Me.PdfDocumentViewer.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.PdfDocumentViewer.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool
        Me.PdfDocumentViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PdfDocumentViewer.EnableContextMenu = True
        Me.PdfDocumentViewer.HorizontalScrollOffset = 0
        Me.PdfDocumentViewer.IsTextSearchEnabled = True
        Me.PdfDocumentViewer.IsTextSelectionEnabled = True
        Me.PdfDocumentViewer.Location = New System.Drawing.Point(3, 28)
        MessageBoxSettings1.EnableNotification = True
        Me.PdfDocumentViewer.MessageBoxSettings = MessageBoxSettings1
        Me.PdfDocumentViewer.MinimumZoomPercentage = 50
        Me.PdfDocumentViewer.Name = "PdfDocumentViewer"
        Me.PdfDocumentViewer.PageBorderThickness = 1
        PdfViewerPrinterSettings1.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.[Auto]
        PdfViewerPrinterSettings1.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize
        PdfViewerPrinterSettings1.PrintLocation = CType(resources.GetObject("PdfViewerPrinterSettings1.PrintLocation"), System.Drawing.PointF)
        PdfViewerPrinterSettings1.ShowPrintStatusDialog = True
        Me.PdfDocumentViewer.PrinterSettings = PdfViewerPrinterSettings1
        Me.PdfDocumentViewer.ReferencePath = Nothing
        Me.PdfDocumentViewer.ScrollDisplacementValue = 0
        Me.PdfDocumentViewer.ShowHorizontalScrollBar = True
        Me.PdfDocumentViewer.ShowVerticalScrollBar = True
        Me.PdfDocumentViewer.Size = New System.Drawing.Size(600, 165)
        Me.PdfDocumentViewer.SpaceBetweenPages = 8
        Me.PdfDocumentViewer.TabIndex = 3
        TextSearchSettings1.CurrentInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(64, Byte), Integer))
        TextSearchSettings1.HighlightAllInstance = True
        TextSearchSettings1.OtherInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PdfDocumentViewer.TextSearchSettings = TextSearchSettings1
        Me.PdfDocumentViewer.ThemeName = "Default"
        Me.PdfDocumentViewer.VerticalScrollOffset = 0
        Me.PdfDocumentViewer.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.[Default]
        Me.PdfDocumentViewer.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.[Default]
        '
        'TsDocument
        '
        Me.TsDocument.AutoSize = False
        Me.TsDocument.BackColor = System.Drawing.Color.White
        Me.TsDocument.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsDocument.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsDocument.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnAttachPDF, Me.BtnDeletePDF, Me.BtnSavePDF, Me.BtnPrintPDF, Me.BtnZoomIn, Me.BtnZoomOut, Me.LblDocumentPage})
        Me.TsDocument.Location = New System.Drawing.Point(3, 3)
        Me.TsDocument.Name = "TsDocument"
        Me.TsDocument.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsDocument.Size = New System.Drawing.Size(600, 25)
        Me.TsDocument.TabIndex = 2
        Me.TsDocument.Text = "ToolStrip2"
        '
        'BtnAttachPDF
        '
        Me.BtnAttachPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAttachPDF.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnAttachPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAttachPDF.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnAttachPDF.Name = "BtnAttachPDF"
        Me.BtnAttachPDF.Size = New System.Drawing.Size(23, 22)
        Me.BtnAttachPDF.Text = "Anexar Documento"
        '
        'BtnDeletePDF
        '
        Me.BtnDeletePDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeletePDF.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeletePDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeletePDF.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDeletePDF.Name = "BtnDeletePDF"
        Me.BtnDeletePDF.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeletePDF.Text = "Excluir  Documento"
        '
        'BtnSavePDF
        '
        Me.BtnSavePDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSavePDF.Image = Global.Manager.My.Resources.Resources.SaveSmall
        Me.BtnSavePDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSavePDF.Name = "BtnSavePDF"
        Me.BtnSavePDF.Size = New System.Drawing.Size(23, 22)
        Me.BtnSavePDF.Text = "Salvar  Documento"
        '
        'BtnPrintPDF
        '
        Me.BtnPrintPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrintPDF.Image = Global.Manager.My.Resources.Resources.PrintSmall
        Me.BtnPrintPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrintPDF.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnPrintPDF.Name = "BtnPrintPDF"
        Me.BtnPrintPDF.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrintPDF.Text = "Imprimir  Documento"
        '
        'BtnZoomIn
        '
        Me.BtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnZoomIn.Image = Global.Manager.My.Resources.Resources.ZoomIn
        Me.BtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnZoomIn.Name = "BtnZoomIn"
        Me.BtnZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.BtnZoomIn.Text = "Mais Zoom"
        '
        'BtnZoomOut
        '
        Me.BtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnZoomOut.Image = Global.Manager.My.Resources.Resources.ZoomOut
        Me.BtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnZoomOut.Margin = New System.Windows.Forms.Padding(0, 1, 40, 2)
        Me.BtnZoomOut.Name = "BtnZoomOut"
        Me.BtnZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.BtnZoomOut.Text = "Menos Zoom"
        '
        'LblDocumentPage
        '
        Me.LblDocumentPage.Name = "LblDocumentPage"
        Me.LblDocumentPage.Size = New System.Drawing.Size(101, 22)
        Me.LblDocumentPage.Text = "Pagina # de #"
        '
        'TabNote
        '
        Me.TabNote.Controls.Add(Me.TxtNote)
        Me.TabNote.Location = New System.Drawing.Point(4, 26)
        Me.TabNote.Name = "TabNote"
        Me.TabNote.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNote.Size = New System.Drawing.Size(606, 196)
        Me.TabNote.TabIndex = 1
        Me.TabNote.Text = "Observação"
        Me.TabNote.UseVisualStyleBackColor = True
        '
        'TxtNote
        '
        Me.TxtNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtNote.Location = New System.Drawing.Point(3, 3)
        Me.TxtNote.MaxLength = 1000000
        Me.TxtNote.Name = "TxtNote"
        Me.TxtNote.Size = New System.Drawing.Size(600, 190)
        Me.TxtNote.TabIndex = 3
        Me.TxtNote.Text = ""
        '
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.LblStatusValue, Me.BtnStatusValue, Me.LblCreationDate, Me.LblCreationDateValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(614, 25)
        Me.TsData.TabIndex = 5
        '
        'LblID
        '
        Me.LblID.BackColor = System.Drawing.Color.White
        Me.LblID.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblID.Name = "LblID"
        Me.LblID.Size = New System.Drawing.Size(24, 22)
        Me.LblID.Text = "ID:"
        '
        'LblIDValue
        '
        Me.LblIDValue.BackColor = System.Drawing.Color.White
        Me.LblIDValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIDValue.Name = "LblIDValue"
        Me.LblIDValue.Size = New System.Drawing.Size(32, 22)
        Me.LblIDValue.Text = "      "
        '
        'LblStatus
        '
        Me.LblStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(49, 22)
        Me.LblStatus.Text = "Status:"
        '
        'LblStatusValue
        '
        Me.LblStatusValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblStatusValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblStatusValue.Image = CType(resources.GetObject("LblStatusValue.Image"), System.Drawing.Image)
        Me.LblStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblStatusValue.Name = "LblStatusValue"
        Me.LblStatusValue.Size = New System.Drawing.Size(40, 22)
        Me.LblStatusValue.Text = "        "
        '
        'BtnStatusValue
        '
        Me.BtnStatusValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnStatusValue.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnOpenCash, Me.BtnCloseCash})
        Me.BtnStatusValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnStatusValue.Image = CType(resources.GetObject("BtnStatusValue.Image"), System.Drawing.Image)
        Me.BtnStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnStatusValue.Name = "BtnStatusValue"
        Me.BtnStatusValue.Size = New System.Drawing.Size(53, 22)
        Me.BtnStatusValue.Text = "        "
        '
        'BtnOpenCash
        '
        Me.BtnOpenCash.Image = Global.Manager.My.Resources.Resources.OpenCash
        Me.BtnOpenCash.Name = "BtnOpenCash"
        Me.BtnOpenCash.Size = New System.Drawing.Size(161, 22)
        Me.BtnOpenCash.Text = "Abrir Caixa"
        '
        'BtnCloseCash
        '
        Me.BtnCloseCash.Image = Global.Manager.My.Resources.Resources.CloseCash
        Me.BtnCloseCash.Name = "BtnCloseCash"
        Me.BtnCloseCash.Size = New System.Drawing.Size(161, 22)
        Me.BtnCloseCash.Text = "Fechar Caixa"
        '
        'LblCreationDate
        '
        Me.LblCreationDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreationDate.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.LblCreationDate.Name = "LblCreationDate"
        Me.LblCreationDate.Size = New System.Drawing.Size(64, 22)
        Me.LblCreationDate.Text = "Criação:"
        '
        'LblCreationDateValue
        '
        Me.LblCreationDateValue.BackColor = System.Drawing.Color.White
        Me.LblCreationDateValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreationDateValue.Name = "LblCreationDateValue"
        Me.LblCreationDateValue.Size = New System.Drawing.Size(32, 22)
        Me.LblCreationDateValue.Text = "      "
        '
        'TsNavigation
        '
        Me.TsNavigation.AutoSize = False
        Me.TsNavigation.BackColor = System.Drawing.Color.White
        Me.TsNavigation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog, Me.BtnCashSheet})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(614, 25)
        Me.TsNavigation.TabIndex = 4
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Caixa"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Caixa"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Caixa"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Caixa Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Caixa"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Caixa"
        '
        'BtnLog
        '
        Me.BtnLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLog.Image = Global.Manager.My.Resources.Resources.Log
        Me.BtnLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(23, 22)
        Me.BtnLog.Text = "Histórico"
        '
        'BtnCashSheet
        '
        Me.BtnCashSheet.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnCashSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCashSheet.Image = Global.Manager.My.Resources.Resources.ReportSmall
        Me.BtnCashSheet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCashSheet.Name = "BtnCashSheet"
        Me.BtnCashSheet.Size = New System.Drawing.Size(23, 22)
        Me.BtnCashSheet.Text = "Gerar Relatório"
        '
        'TsValue
        '
        Me.TsValue.AutoSize = False
        Me.TsValue.BackColor = System.Drawing.Color.White
        Me.TsValue.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TsValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsValue.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsValue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblCurrent, Me.ToolStripLabel19, Me.LblExpense, Me.ToolStripLabel17, Me.LblRefund, Me.ToolStripLabel15, Me.LblPrevious, Me.ToolStripLabel13})
        Me.TsValue.Location = New System.Drawing.Point(0, 276)
        Me.TsValue.Name = "TsValue"
        Me.TsValue.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsValue.Size = New System.Drawing.Size(614, 25)
        Me.TsValue.TabIndex = 8
        '
        'LblCurrent
        '
        Me.LblCurrent.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblCurrent.BackColor = System.Drawing.Color.White
        Me.LblCurrent.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrent.Name = "LblCurrent"
        Me.LblCurrent.Size = New System.Drawing.Size(37, 22)
        Me.LblCurrent.Text = "0,00"
        '
        'ToolStripLabel19
        '
        Me.ToolStripLabel19.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel19.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel19.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripLabel19.Name = "ToolStripLabel19"
        Me.ToolStripLabel19.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripLabel19.Text = "Saldo Atual:"
        '
        'LblExpense
        '
        Me.LblExpense.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblExpense.BackColor = System.Drawing.Color.White
        Me.LblExpense.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.LblExpense.Name = "LblExpense"
        Me.LblExpense.Size = New System.Drawing.Size(37, 22)
        Me.LblExpense.Text = "0,00"
        '
        'ToolStripLabel17
        '
        Me.ToolStripLabel17.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel17.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel17.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.ToolStripLabel17.Name = "ToolStripLabel17"
        Me.ToolStripLabel17.Size = New System.Drawing.Size(81, 22)
        Me.ToolStripLabel17.Text = "Despesas:"
        '
        'LblRefund
        '
        Me.LblRefund.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblRefund.BackColor = System.Drawing.Color.White
        Me.LblRefund.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.LblRefund.Name = "LblRefund"
        Me.LblRefund.Size = New System.Drawing.Size(37, 22)
        Me.LblRefund.Text = "0,00"
        '
        'ToolStripLabel15
        '
        Me.ToolStripLabel15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel15.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel15.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.ToolStripLabel15.Name = "ToolStripLabel15"
        Me.ToolStripLabel15.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripLabel15.Text = "Reembolso:"
        '
        'LblPrevious
        '
        Me.LblPrevious.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblPrevious.BackColor = System.Drawing.Color.White
        Me.LblPrevious.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.LblPrevious.Margin = New System.Windows.Forms.Padding(0, 1, 1, 2)
        Me.LblPrevious.Name = "LblPrevious"
        Me.LblPrevious.Size = New System.Drawing.Size(37, 22)
        Me.LblPrevious.Text = "0,00"
        '
        'ToolStripLabel13
        '
        Me.ToolStripLabel13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel13.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel13.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.ToolStripLabel13.Name = "ToolStripLabel13"
        Me.ToolStripLabel13.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel13.Text = "Saldo Anterior:"
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'SfdDocument
        '
        Me.SfdDocument.Title = "Salvar Imagem"
        '
        'OfdDocument
        '
        Me.OfdDocument.Filter = "Documento (PDF)|*.pdf;"
        Me.OfdDocument.Title = "Escolha um documento"
        '
        'DgvCashItemsLayout
        '
        Me.DgvCashItemsLayout.DataGridView = Me.DgvCashItem
        Me.DgvCashItemsLayout.Routine = Manager.Routine.CashItem
        '
        'FrmCash
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(614, 345)
        Me.Controls.Add(Me.TcCash)
        Me.Controls.Add(Me.TsValue)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.KeyPreview = True
        Me.Name = "FrmCash"
        Me.ShowIcon = False
        Me.Text = "Caixa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.TcCash.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        CType(Me.DgvCashItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsCashItem.ResumeLayout(False)
        Me.TsCashItem.PerformLayout()
        Me.TabDocument.ResumeLayout(False)
        Me.TsDocument.ResumeLayout(False)
        Me.TsDocument.PerformLayout()
        Me.TabNote.ResumeLayout(False)
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        Me.TsValue.ResumeLayout(False)
        Me.TsValue.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TcCash As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblCreationDate As ToolStripLabel
    Friend WithEvents LblCreationDateValue As ToolStripLabel
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents TsValue As ToolStrip
    Friend WithEvents ToolStripLabel13 As ToolStripLabel
    Friend WithEvents LblPrevious As ToolStripLabel
    Friend WithEvents ToolStripLabel15 As ToolStripLabel
    Friend WithEvents LblRefund As ToolStripLabel
    Friend WithEvents ToolStripLabel17 As ToolStripLabel
    Friend WithEvents LblExpense As ToolStripLabel
    Friend WithEvents ToolStripLabel19 As ToolStripLabel
    Friend WithEvents LblCurrent As ToolStripLabel
    Friend WithEvents TsCashItem As ToolStrip
    Friend WithEvents BtnIncludeCashItem As ToolStripButton
    Friend WithEvents BtnEditCashItem As ToolStripButton
    Friend WithEvents BtnDeleteCashItem As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TxtFilter As ToolStripTextBox
    Friend WithEvents DgvCashItem As DataGridView
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents DgvCashItemsLayout As DataGridViewLayout
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents BtnCashSheet As ToolStripButton
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents LblStatusValue As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripDropDownButton
    Friend WithEvents BtnOpenCash As ToolStripMenuItem
    Friend WithEvents BtnCloseCash As ToolStripMenuItem
    Friend WithEvents TabDocument As TabPage
    Friend WithEvents PdfDocumentViewer As Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView
    Friend WithEvents TsDocument As ToolStrip
    Friend WithEvents BtnAttachPDF As ToolStripButton
    Friend WithEvents BtnDeletePDF As ToolStripButton
    Friend WithEvents BtnSavePDF As ToolStripButton
    Friend WithEvents BtnPrintPDF As ToolStripButton
    Friend WithEvents BtnZoomIn As ToolStripButton
    Friend WithEvents BtnZoomOut As ToolStripButton
    Friend WithEvents LblDocumentPage As ToolStripLabel
    Friend WithEvents SfdDocument As SaveFileDialog
    Friend WithEvents OfdDocument As OpenFileDialog
End Class
