<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRequest))
        Dim MessageBoxSettings1 As Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings = New Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings()
        Dim PdfViewerPrinterSettings1 As Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings = New Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings()
        Dim TextSearchSettings1 As Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings = New Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatusValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationDate = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.BtnRequestSheet = New System.Windows.Forms.ToolStripButton()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TcRequest = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblDestination = New System.Windows.Forms.Label()
        Me.LblResponsible = New System.Windows.Forms.Label()
        Me.TxtDestination = New System.Windows.Forms.TextBox()
        Me.TxtResponsible = New System.Windows.Forms.TextBox()
        Me.TabItems = New System.Windows.Forms.TabPage()
        Me.DgvItem = New System.Windows.Forms.DataGridView()
        Me.TsItem = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeItem = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditItem = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterItem = New System.Windows.Forms.ToolStripTextBox()
        Me.TabNote = New System.Windows.Forms.TabPage()
        Me.TxtNote = New System.Windows.Forms.RichTextBox()
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
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.NudHourPerDay = New System.Windows.Forms.NumericUpDown()
        Me.OfdDocument = New System.Windows.Forms.OpenFileDialog()
        Me.SfdDocument = New System.Windows.Forms.SaveFileDialog()
        Me.TmrDocumentPage = New System.Windows.Forms.Timer(Me.components)
        Me.DgvItemLayout = New Manager.DataGridViewLayout()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcRequest.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabItems.SuspendLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsItem.SuspendLayout()
        Me.TabNote.SuspendLayout()
        Me.TabDocument.SuspendLayout()
        Me.TsDocument.SuspendLayout()
        CType(Me.NudHourPerDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 165)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(544, 44)
        Me.Panel1.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(437, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(336, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsTitle
        '
        Me.TsTitle.AutoSize = False
        Me.TsTitle.BackColor = System.Drawing.Color.White
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.LblStatusValue, Me.LblCreationDate, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(544, 25)
        Me.TsTitle.TabIndex = 1
        Me.TsTitle.Text = "ToolStrip1"
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
        Me.LblStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblStatusValue.Name = "LblStatusValue"
        Me.LblStatusValue.Size = New System.Drawing.Size(32, 22)
        Me.LblStatusValue.Text = "      "
        '
        'LblCreationDate
        '
        Me.LblCreationDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreationDate.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.LblCreationDate.Name = "LblCreationDate"
        Me.LblCreationDate.Size = New System.Drawing.Size(64, 22)
        Me.LblCreationDate.Text = "Criação:"
        '
        'LblCreationValue
        '
        Me.LblCreationValue.BackColor = System.Drawing.Color.White
        Me.LblCreationValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreationValue.Name = "LblCreationValue"
        Me.LblCreationValue.Size = New System.Drawing.Size(32, 22)
        Me.LblCreationValue.Text = "      "
        '
        'TsNavigation
        '
        Me.TsNavigation.AutoSize = False
        Me.TsNavigation.BackColor = System.Drawing.Color.White
        Me.TsNavigation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog, Me.BtnRequestSheet})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(544, 25)
        Me.TsNavigation.TabIndex = 0
        Me.TsNavigation.Text = "ToolStrip2"
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Requisição"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Requisição"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Requisição"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Requisição Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Requisição"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Requisição"
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
        'BtnRequestSheet
        '
        Me.BtnRequestSheet.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnRequestSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRequestSheet.Image = Global.Manager.My.Resources.Resources.ReportSmall
        Me.BtnRequestSheet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRequestSheet.Name = "BtnRequestSheet"
        Me.BtnRequestSheet.Size = New System.Drawing.Size(23, 22)
        Me.BtnRequestSheet.Text = "Gerar Relatório"
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TcRequest
        '
        Me.TcRequest.Controls.Add(Me.TabMain)
        Me.TcRequest.Controls.Add(Me.TabItems)
        Me.TcRequest.Controls.Add(Me.TabNote)
        Me.TcRequest.Controls.Add(Me.TabDocument)
        Me.TcRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcRequest.Location = New System.Drawing.Point(0, 50)
        Me.TcRequest.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcRequest.Multiline = True
        Me.TcRequest.Name = "TcRequest"
        Me.TcRequest.SelectedIndex = 0
        Me.TcRequest.Size = New System.Drawing.Size(544, 115)
        Me.TcRequest.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.GroupBox1)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(536, 85)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblDestination)
        Me.GroupBox1.Controls.Add(Me.LblResponsible)
        Me.GroupBox1.Controls.Add(Me.TxtDestination)
        Me.GroupBox1.Controls.Add(Me.TxtResponsible)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(523, 68)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Identificação"
        '
        'LblDestination
        '
        Me.LblDestination.AutoSize = True
        Me.LblDestination.Location = New System.Drawing.Point(6, 19)
        Me.LblDestination.Name = "LblDestination"
        Me.LblDestination.Size = New System.Drawing.Size(56, 17)
        Me.LblDestination.TabIndex = 0
        Me.LblDestination.Text = "Destino"
        '
        'LblResponsible
        '
        Me.LblResponsible.AutoSize = True
        Me.LblResponsible.Location = New System.Drawing.Point(312, 19)
        Me.LblResponsible.Name = "LblResponsible"
        Me.LblResponsible.Size = New System.Drawing.Size(88, 17)
        Me.LblResponsible.TabIndex = 2
        Me.LblResponsible.Text = "Responsável"
        '
        'TxtDestination
        '
        Me.TxtDestination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDestination.Location = New System.Drawing.Point(9, 39)
        Me.TxtDestination.Name = "TxtDestination"
        Me.TxtDestination.Size = New System.Drawing.Size(300, 23)
        Me.TxtDestination.TabIndex = 1
        '
        'TxtResponsible
        '
        Me.TxtResponsible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtResponsible.Location = New System.Drawing.Point(315, 39)
        Me.TxtResponsible.Name = "TxtResponsible"
        Me.TxtResponsible.Size = New System.Drawing.Size(202, 23)
        Me.TxtResponsible.TabIndex = 3
        '
        'TabItems
        '
        Me.TabItems.Controls.Add(Me.DgvItem)
        Me.TabItems.Controls.Add(Me.TsItem)
        Me.TabItems.Location = New System.Drawing.Point(4, 26)
        Me.TabItems.Name = "TabItems"
        Me.TabItems.Padding = New System.Windows.Forms.Padding(3)
        Me.TabItems.Size = New System.Drawing.Size(536, 85)
        Me.TabItems.TabIndex = 8
        Me.TabItems.Text = "Itens"
        Me.TabItems.UseVisualStyleBackColor = True
        '
        'DgvItem
        '
        Me.DgvItem.AllowUserToAddRows = False
        Me.DgvItem.AllowUserToDeleteRows = False
        Me.DgvItem.AllowUserToOrderColumns = True
        Me.DgvItem.AllowUserToResizeRows = False
        Me.DgvItem.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvItem.Location = New System.Drawing.Point(3, 28)
        Me.DgvItem.MultiSelect = False
        Me.DgvItem.Name = "DgvItem"
        Me.DgvItem.ReadOnly = True
        Me.DgvItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvItem.RowHeadersVisible = False
        Me.DgvItem.RowTemplate.Height = 26
        Me.DgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvItem.Size = New System.Drawing.Size(530, 54)
        Me.DgvItem.TabIndex = 1
        '
        'TsItem
        '
        Me.TsItem.BackColor = System.Drawing.Color.Transparent
        Me.TsItem.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsItem.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeItem, Me.BtnEditItem, Me.BtnDeleteItem, Me.ToolStripLabel3, Me.TxtFilterItem})
        Me.TsItem.Location = New System.Drawing.Point(3, 3)
        Me.TsItem.Name = "TsItem"
        Me.TsItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsItem.Size = New System.Drawing.Size(530, 25)
        Me.TsItem.TabIndex = 0
        Me.TsItem.Text = "ToolStrip2"
        '
        'BtnIncludeItem
        '
        Me.BtnIncludeItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeItem.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeItem.Name = "BtnIncludeItem"
        Me.BtnIncludeItem.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeItem.Text = "Incluir Item"
        '
        'BtnEditItem
        '
        Me.BtnEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditItem.Image = CType(resources.GetObject("BtnEditItem.Image"), System.Drawing.Image)
        Me.BtnEditItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditItem.Name = "BtnEditItem"
        Me.BtnEditItem.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditItem.Text = "Editar Item"
        Me.BtnEditItem.ToolTipText = "Editar"
        '
        'BtnDeleteItem
        '
        Me.BtnDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteItem.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteItem.Name = "BtnDeleteItem"
        Me.BtnDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteItem.Text = "Excluir Item"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(46, 25)
        Me.ToolStripLabel3.Text = "Filtrar:"
        '
        'TxtFilterItem
        '
        Me.TxtFilterItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterItem.Name = "TxtFilterItem"
        Me.TxtFilterItem.Size = New System.Drawing.Size(200, 25)
        '
        'TabNote
        '
        Me.TabNote.Controls.Add(Me.TxtNote)
        Me.TabNote.Location = New System.Drawing.Point(4, 22)
        Me.TabNote.Name = "TabNote"
        Me.TabNote.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNote.Size = New System.Drawing.Size(536, 89)
        Me.TabNote.TabIndex = 5
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
        Me.TxtNote.Size = New System.Drawing.Size(530, 83)
        Me.TxtNote.TabIndex = 0
        Me.TxtNote.Text = ""
        '
        'TabDocument
        '
        Me.TabDocument.Controls.Add(Me.PdfDocumentViewer)
        Me.TabDocument.Controls.Add(Me.TsDocument)
        Me.TabDocument.Location = New System.Drawing.Point(4, 22)
        Me.TabDocument.Name = "TabDocument"
        Me.TabDocument.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDocument.Size = New System.Drawing.Size(536, 89)
        Me.TabDocument.TabIndex = 7
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
        Me.PdfDocumentViewer.Size = New System.Drawing.Size(530, 58)
        Me.PdfDocumentViewer.SpaceBetweenPages = 8
        Me.PdfDocumentViewer.TabIndex = 1
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
        Me.TsDocument.Size = New System.Drawing.Size(530, 25)
        Me.TsDocument.TabIndex = 0
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
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'NudHourPerDay
        '
        Me.NudHourPerDay.DecimalPlaces = 2
        Me.NudHourPerDay.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NudHourPerDay.Location = New System.Drawing.Point(487, 131)
        Me.NudHourPerDay.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.NudHourPerDay.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NudHourPerDay.Name = "NudHourPerDay"
        Me.NudHourPerDay.Size = New System.Drawing.Size(82, 20)
        Me.NudHourPerDay.TabIndex = 15
        Me.NudHourPerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudHourPerDay.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'OfdDocument
        '
        Me.OfdDocument.Filter = "Documento (PDF)|*.pdf;"
        Me.OfdDocument.Title = "Escolha um documento"
        '
        'SfdDocument
        '
        Me.SfdDocument.Title = "Salvar Imagem"
        '
        'TmrDocumentPage
        '
        Me.TmrDocumentPage.Enabled = True
        '
        'DgvItemLayout
        '
        Me.DgvItemLayout.DataGridView = Me.DgvItem
        Me.DgvItemLayout.Routine = Manager.Routine.RequestItem
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'FrmRequest
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(544, 209)
        Me.Controls.Add(Me.TcRequest)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRequest"
        Me.ShowIcon = False
        Me.Text = "Requisição"
        Me.Panel1.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TcRequest.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabItems.ResumeLayout(False)
        Me.TabItems.PerformLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsItem.ResumeLayout(False)
        Me.TsItem.PerformLayout()
        Me.TabNote.ResumeLayout(False)
        Me.TabDocument.ResumeLayout(False)
        Me.TsDocument.ResumeLayout(False)
        Me.TsDocument.PerformLayout()
        CType(Me.NudHourPerDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents LblCreationDate As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents TcRequest As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents NudHourPerDay As NumericUpDown
    Friend WithEvents TabDocument As TabPage
    Friend WithEvents TsDocument As ToolStrip
    Friend WithEvents BtnAttachPDF As ToolStripButton
    Friend WithEvents BtnDeletePDF As ToolStripButton
    Friend WithEvents BtnSavePDF As ToolStripButton
    Friend WithEvents BtnPrintPDF As ToolStripButton
    Friend WithEvents BtnZoomIn As ToolStripButton
    Friend WithEvents BtnZoomOut As ToolStripButton
    Friend WithEvents OfdDocument As OpenFileDialog
    Friend WithEvents SfdDocument As SaveFileDialog
    Friend WithEvents LblDocumentPage As ToolStripLabel
    Friend WithEvents TmrDocumentPage As Timer
    Friend WithEvents LblResponsible As Label
    Friend WithEvents TxtResponsible As TextBox
    Friend WithEvents LblDestination As Label
    Friend WithEvents TxtDestination As TextBox
    Friend WithEvents TabItems As TabPage
    Friend WithEvents DgvItem As DataGridView
    Friend WithEvents TsItem As ToolStrip
    Friend WithEvents BtnIncludeItem As ToolStripButton
    Friend WithEvents BtnEditItem As ToolStripButton
    Friend WithEvents BtnDeleteItem As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents TxtFilterItem As ToolStripTextBox
    Friend WithEvents DgvItemLayout As DataGridViewLayout
    Friend WithEvents LblStatusValue As ToolStripLabel
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents BtnRequestSheet As ToolStripButton
    Friend WithEvents PdfDocumentViewer As Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView
End Class
