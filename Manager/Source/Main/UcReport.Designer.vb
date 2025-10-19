<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcReport
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcReport))
        Dim MessageBoxSettings2 As Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings = New Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings()
        Dim PdfViewerPrinterSettings2 As Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings = New Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings()
        Dim TextSearchSettings2 As Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings = New Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings()
        Me.TsMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.BtnEmail = New System.Windows.Forms.ToolStripButton()
        Me.BtnClose = New System.Windows.Forms.ToolStripButton()
        Me.BtnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.BtnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtCurrentPage = New System.Windows.Forms.ToolStripTextBox()
        Me.LblDocumentPage = New System.Windows.Forms.ToolStripLabel()
        Me.PdfDocumentViewer = New Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView()
        Me.SfdDocument = New System.Windows.Forms.SaveFileDialog()
        Me.TsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TsMenu
        '
        Me.TsMenu.BackColor = System.Drawing.Color.White
        Me.TsMenu.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSave, Me.BtnPrint, Me.BtnEmail, Me.BtnClose, Me.BtnZoomIn, Me.BtnZoomOut, Me.ToolStripLabel1, Me.TxtCurrentPage, Me.LblDocumentPage})
        Me.TsMenu.Location = New System.Drawing.Point(0, 0)
        Me.TsMenu.Name = "TsMenu"
        Me.TsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMenu.Size = New System.Drawing.Size(1000, 39)
        Me.TsMenu.TabIndex = 1
        '
        'BtnSave
        '
        Me.BtnSave.AutoToolTip = False
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(83, 36)
        Me.BtnSave.Text = "Salvar"
        '
        'BtnPrint
        '
        Me.BtnPrint.AutoToolTip = False
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(96, 36)
        Me.BtnPrint.Text = "Imprimir"
        '
        'BtnEmail
        '
        Me.BtnEmail.AutoToolTip = False
        Me.BtnEmail.Image = CType(resources.GetObject("BtnEmail.Image"), System.Drawing.Image)
        Me.BtnEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEmail.Name = "BtnEmail"
        Me.BtnEmail.Size = New System.Drawing.Size(124, 36)
        Me.BtnEmail.Text = "Enviar E-Mail"
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
        'BtnZoomIn
        '
        Me.BtnZoomIn.AutoToolTip = False
        Me.BtnZoomIn.Image = CType(resources.GetObject("BtnZoomIn.Image"), System.Drawing.Image)
        Me.BtnZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnZoomIn.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.BtnZoomIn.Name = "BtnZoomIn"
        Me.BtnZoomIn.Size = New System.Drawing.Size(113, 36)
        Me.BtnZoomIn.Text = "Mais Zoom"
        '
        'BtnZoomOut
        '
        Me.BtnZoomOut.AutoToolTip = False
        Me.BtnZoomOut.Image = CType(resources.GetObject("BtnZoomOut.Image"), System.Drawing.Image)
        Me.BtnZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnZoomOut.Name = "BtnZoomOut"
        Me.BtnZoomOut.Size = New System.Drawing.Size(126, 36)
        Me.BtnZoomOut.Text = "Menos Zoom"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(54, 36)
        Me.ToolStripLabel1.Text = "Página"
        '
        'TxtCurrentPage
        '
        Me.TxtCurrentPage.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrentPage.Name = "TxtCurrentPage"
        Me.TxtCurrentPage.Size = New System.Drawing.Size(60, 39)
        Me.TxtCurrentPage.Text = "1"
        Me.TxtCurrentPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblDocumentPage
        '
        Me.LblDocumentPage.Name = "LblDocumentPage"
        Me.LblDocumentPage.Size = New System.Drawing.Size(38, 36)
        Me.LblDocumentPage.Text = "de #"
        '
        'PdfDocumentViewer
        '
        Me.PdfDocumentViewer.AutoScroll = True
        Me.PdfDocumentViewer.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.PdfDocumentViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PdfDocumentViewer.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool
        Me.PdfDocumentViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PdfDocumentViewer.EnableContextMenu = True
        Me.PdfDocumentViewer.HorizontalScrollOffset = 0
        Me.PdfDocumentViewer.IsTextSearchEnabled = True
        Me.PdfDocumentViewer.IsTextSelectionEnabled = True
        Me.PdfDocumentViewer.Location = New System.Drawing.Point(0, 39)
        MessageBoxSettings2.EnableNotification = True
        Me.PdfDocumentViewer.MessageBoxSettings = MessageBoxSettings2
        Me.PdfDocumentViewer.MinimumZoomPercentage = 50
        Me.PdfDocumentViewer.Name = "PdfDocumentViewer"
        Me.PdfDocumentViewer.PageBorderThickness = 1
        PdfViewerPrinterSettings2.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.[Auto]
        PdfViewerPrinterSettings2.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize
        PdfViewerPrinterSettings2.PrintLocation = CType(resources.GetObject("PdfViewerPrinterSettings2.PrintLocation"), System.Drawing.PointF)
        PdfViewerPrinterSettings2.ShowPrintStatusDialog = True
        Me.PdfDocumentViewer.PrinterSettings = PdfViewerPrinterSettings2
        Me.PdfDocumentViewer.ReferencePath = Nothing
        Me.PdfDocumentViewer.ScrollDisplacementValue = 0
        Me.PdfDocumentViewer.ShowHorizontalScrollBar = True
        Me.PdfDocumentViewer.ShowVerticalScrollBar = True
        Me.PdfDocumentViewer.Size = New System.Drawing.Size(1000, 561)
        Me.PdfDocumentViewer.SpaceBetweenPages = 8
        Me.PdfDocumentViewer.TabIndex = 5
        TextSearchSettings2.CurrentInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(64, Byte), Integer))
        TextSearchSettings2.HighlightAllInstance = True
        TextSearchSettings2.OtherInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PdfDocumentViewer.TextSearchSettings = TextSearchSettings2
        Me.PdfDocumentViewer.ThemeName = "Default"
        Me.PdfDocumentViewer.VerticalScrollOffset = 0
        Me.PdfDocumentViewer.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.[Default]
        Me.PdfDocumentViewer.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.[Default]
        '
        'UcReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PdfDocumentViewer)
        Me.Controls.Add(Me.TsMenu)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcReport"
        Me.Size = New System.Drawing.Size(1000, 600)
        Me.TsMenu.ResumeLayout(False)
        Me.TsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TsMenu As ToolStrip
    Friend WithEvents BtnSave As ToolStripButton
    Friend WithEvents BtnPrint As ToolStripButton
    Friend WithEvents BtnEmail As ToolStripButton
    Friend WithEvents BtnClose As ToolStripButton
    Friend WithEvents BtnZoomIn As ToolStripButton
    Friend WithEvents BtnZoomOut As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TxtCurrentPage As ToolStripTextBox
    Friend WithEvents LblDocumentPage As ToolStripLabel
    Friend WithEvents PdfDocumentViewer As Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView
    Friend WithEvents SfdDocument As SaveFileDialog
End Class
