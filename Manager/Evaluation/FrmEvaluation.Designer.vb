<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEvaluation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEvaluation))
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition3 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField3 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField4 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter3 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation2 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation3 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Condition4 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField5 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField6 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField7 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter4 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation4 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim MessageBoxSettings1 As Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings = New Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings()
        Dim PdfViewerPrinterSettings1 As Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings = New Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings()
        Dim TextSearchSettings1 As Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings = New Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnCalculate = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatusValue = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnApprove = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnReject = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDisapprove = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TmrTechnician = New System.Windows.Forms.Timer(Me.components)
        Me.TcEvaluation = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DgvTechnician = New System.Windows.Forms.DataGridView()
        Me.TsTechnician = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeTechnician = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditTechnician = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteTechnician = New System.Windows.Forms.ToolStripButton()
        Me.GbxPartElapsedDay = New System.Windows.Forms.GroupBox()
        Me.DgvPartElapsedDay = New System.Windows.Forms.DataGridView()
        Me.GbxPartWorkedHour = New System.Windows.Forms.GroupBox()
        Me.DgvPartWorkedHour = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.QbxCustomer = New ControlLibrary.QueriedBox()
        Me.TxtEvaluationNumber = New System.Windows.Forms.TextBox()
        Me.RbtExecution = New System.Windows.Forms.RadioButton()
        Me.RbtGathering = New System.Windows.Forms.RadioButton()
        Me.LblEndTime = New System.Windows.Forms.Label()
        Me.LblStartTime = New System.Windows.Forms.Label()
        Me.TxtEndTime = New System.Windows.Forms.MaskedTextBox()
        Me.TxtStartTime = New System.Windows.Forms.MaskedTextBox()
        Me.CbxManualAverageWorkLoad = New System.Windows.Forms.CheckBox()
        Me.FlpCustomer = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterCustomer = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCustomer = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewCustomer = New ControlLibrary.NoFocusCueButton()
        Me.DbxAverageWorkLoad = New ControlLibrary.DecimalBox()
        Me.DbxHorimeter = New ControlLibrary.DecimalBox()
        Me.LblEvaluationDate = New System.Windows.Forms.Label()
        Me.LblCustomer = New System.Windows.Forms.Label()
        Me.LblAverageWorkLoad = New System.Windows.Forms.Label()
        Me.LblEvaluationNumber = New System.Windows.Forms.Label()
        Me.LblResponsible = New System.Windows.Forms.Label()
        Me.TxtResponsible = New System.Windows.Forms.TextBox()
        Me.DbxEvaluationDate = New ControlLibrary.DateBox()
        Me.LblHorimeter = New System.Windows.Forms.Label()
        Me.LblCompressor = New System.Windows.Forms.Label()
        Me.QbxCompressor = New ControlLibrary.QueriedBox()
        Me.TabTechnicalAdvice = New System.Windows.Forms.TabPage()
        Me.TxtTechnicalAdvice = New System.Windows.Forms.RichTextBox()
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
        Me.TmrCustomer = New System.Windows.Forms.Timer(Me.components)
        Me.TmrCompressor = New System.Windows.Forms.Timer(Me.components)
        Me.OfdDocument = New System.Windows.Forms.OpenFileDialog()
        Me.SfdDocument = New System.Windows.Forms.SaveFileDialog()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabPhoto = New System.Windows.Forms.TabPage()
        Me.TabSignature = New System.Windows.Forms.TabPage()
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcEvaluation.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvTechnician, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsTechnician.SuspendLayout()
        Me.GbxPartElapsedDay.SuspendLayout()
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxPartWorkedHour.SuspendLayout()
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.FlpCustomer.SuspendLayout()
        Me.TabTechnicalAdvice.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.BtnCalculate)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 467)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1040, 44)
        Me.Panel1.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(933, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCalculate
        '
        Me.BtnCalculate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCalculate.Location = New System.Drawing.Point(12, 7)
        Me.BtnCalculate.Name = "BtnCalculate"
        Me.BtnCalculate.Size = New System.Drawing.Size(109, 30)
        Me.BtnCalculate.TabIndex = 0
        Me.BtnCalculate.Text = "Calcular"
        Me.BtnCalculate.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(832, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsTitle
        '
        Me.TsTitle.AutoSize = False
        Me.TsTitle.BackColor = System.Drawing.Color.White
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.LblStatusValue, Me.BtnStatusValue, Me.LblCreationDate, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(1040, 25)
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
        Me.LblStatusValue.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LblStatusValue.Image = CType(resources.GetObject("LblStatusValue.Image"), System.Drawing.Image)
        Me.LblStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblStatusValue.Name = "LblStatusValue"
        Me.LblStatusValue.Size = New System.Drawing.Size(40, 22)
        Me.LblStatusValue.Text = "        "
        '
        'BtnStatusValue
        '
        Me.BtnStatusValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnStatusValue.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnApprove, Me.BtnReject, Me.BtnDisapprove})
        Me.BtnStatusValue.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnStatusValue.Image = CType(resources.GetObject("BtnStatusValue.Image"), System.Drawing.Image)
        Me.BtnStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnStatusValue.Name = "BtnStatusValue"
        Me.BtnStatusValue.Size = New System.Drawing.Size(53, 22)
        Me.BtnStatusValue.Text = "        "
        '
        'BtnApprove
        '
        Me.BtnApprove.Image = Global.Manager.My.Resources.Resources.Approve
        Me.BtnApprove.Name = "BtnApprove"
        Me.BtnApprove.Size = New System.Drawing.Size(151, 22)
        Me.BtnApprove.Text = "Aprovar"
        '
        'BtnReject
        '
        Me.BtnReject.Image = Global.Manager.My.Resources.Resources.Reject
        Me.BtnReject.Name = "BtnReject"
        Me.BtnReject.Size = New System.Drawing.Size(151, 22)
        Me.BtnReject.Text = "Rejeitar"
        '
        'BtnDisapprove
        '
        Me.BtnDisapprove.Image = Global.Manager.My.Resources.Resources.Disapprove
        Me.BtnDisapprove.Name = "BtnDisapprove"
        Me.BtnDisapprove.Size = New System.Drawing.Size(151, 22)
        Me.BtnDisapprove.Text = "Desaprovar"
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
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(1040, 25)
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
        Me.BtnInclude.Text = "Incluir Avaliação"
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
        Me.BtnDelete.Text = "Excluir Avaliação"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Avaliação"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Avaliação Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Avaliação"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Avaliação"
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
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TmrTechnician
        '
        Me.TmrTechnician.Enabled = True
        Me.TmrTechnician.Interval = 300
        '
        'TcEvaluation
        '
        Me.TcEvaluation.Controls.Add(Me.TabMain)
        Me.TcEvaluation.Controls.Add(Me.TabTechnicalAdvice)
        Me.TcEvaluation.Controls.Add(Me.TabDocument)
        Me.TcEvaluation.Controls.Add(Me.TabPhoto)
        Me.TcEvaluation.Controls.Add(Me.TabSignature)
        Me.TcEvaluation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcEvaluation.Location = New System.Drawing.Point(0, 50)
        Me.TcEvaluation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcEvaluation.Multiline = True
        Me.TcEvaluation.Name = "TcEvaluation"
        Me.TcEvaluation.SelectedIndex = 0
        Me.TcEvaluation.Size = New System.Drawing.Size(1040, 417)
        Me.TcEvaluation.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.BackColor = System.Drawing.Color.White
        Me.TabMain.Controls.Add(Me.GroupBox2)
        Me.TabMain.Controls.Add(Me.GbxPartElapsedDay)
        Me.TabMain.Controls.Add(Me.GbxPartWorkedHour)
        Me.TabMain.Controls.Add(Me.GroupBox1)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(1032, 387)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Leitura"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvTechnician)
        Me.GroupBox2.Controls.Add(Me.TsTechnician)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 259)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(395, 120)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Técnicos"
        '
        'DgvTechnician
        '
        Me.DgvTechnician.AllowUserToAddRows = False
        Me.DgvTechnician.AllowUserToDeleteRows = False
        Me.DgvTechnician.AllowUserToResizeColumns = False
        Me.DgvTechnician.AllowUserToResizeRows = False
        Me.DgvTechnician.BackgroundColor = System.Drawing.Color.White
        Me.DgvTechnician.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvTechnician.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTechnician.ColumnHeadersVisible = False
        Me.DgvTechnician.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTechnician.GridColor = System.Drawing.Color.Gainsboro
        Me.DgvTechnician.Location = New System.Drawing.Point(3, 44)
        Me.DgvTechnician.MultiSelect = False
        Me.DgvTechnician.Name = "DgvTechnician"
        Me.DgvTechnician.ReadOnly = True
        Me.DgvTechnician.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvTechnician.RowHeadersVisible = False
        Me.DgvTechnician.RowTemplate.Height = 26
        Me.DgvTechnician.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvTechnician.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTechnician.Size = New System.Drawing.Size(389, 73)
        Me.DgvTechnician.TabIndex = 0
        Me.DgvTechnician.TabStop = False
        '
        'TsTechnician
        '
        Me.TsTechnician.AutoSize = False
        Me.TsTechnician.BackColor = System.Drawing.Color.White
        Me.TsTechnician.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTechnician.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTechnician.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeTechnician, Me.BtnEditTechnician, Me.BtnDeleteTechnician})
        Me.TsTechnician.Location = New System.Drawing.Point(3, 19)
        Me.TsTechnician.Name = "TsTechnician"
        Me.TsTechnician.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTechnician.Size = New System.Drawing.Size(389, 25)
        Me.TsTechnician.TabIndex = 1
        Me.TsTechnician.Text = "ToolStrip2"
        '
        'BtnIncludeTechnician
        '
        Me.BtnIncludeTechnician.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeTechnician.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeTechnician.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeTechnician.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnIncludeTechnician.Name = "BtnIncludeTechnician"
        Me.BtnIncludeTechnician.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeTechnician.Text = "Incluir Avaliação"
        Me.BtnIncludeTechnician.ToolTipText = "Incluir Técnico"
        '
        'BtnEditTechnician
        '
        Me.BtnEditTechnician.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditTechnician.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditTechnician.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditTechnician.Name = "BtnEditTechnician"
        Me.BtnEditTechnician.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditTechnician.Text = "Editar Rota"
        Me.BtnEditTechnician.ToolTipText = "Editar Técnico"
        '
        'BtnDeleteTechnician
        '
        Me.BtnDeleteTechnician.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteTechnician.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteTechnician.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteTechnician.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDeleteTechnician.Name = "BtnDeleteTechnician"
        Me.BtnDeleteTechnician.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteTechnician.Text = "Excluir Avaliação"
        Me.BtnDeleteTechnician.ToolTipText = "Excluir Técnico"
        '
        'GbxPartElapsedDay
        '
        Me.GbxPartElapsedDay.Controls.Add(Me.DgvPartElapsedDay)
        Me.GbxPartElapsedDay.Location = New System.Drawing.Point(410, 259)
        Me.GbxPartElapsedDay.Name = "GbxPartElapsedDay"
        Me.GbxPartElapsedDay.Size = New System.Drawing.Size(608, 120)
        Me.GbxPartElapsedDay.TabIndex = 2
        Me.GbxPartElapsedDay.TabStop = False
        Me.GbxPartElapsedDay.Text = "Controla Por Dia Corrido"
        '
        'DgvPartElapsedDay
        '
        Me.DgvPartElapsedDay.AllowUserToAddRows = False
        Me.DgvPartElapsedDay.AllowUserToDeleteRows = False
        Me.DgvPartElapsedDay.AllowUserToResizeColumns = False
        Me.DgvPartElapsedDay.AllowUserToResizeRows = False
        Me.DgvPartElapsedDay.BackgroundColor = System.Drawing.Color.White
        Me.DgvPartElapsedDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPartElapsedDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartElapsedDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartElapsedDay.GridColor = System.Drawing.Color.Gainsboro
        Me.DgvPartElapsedDay.Location = New System.Drawing.Point(3, 19)
        Me.DgvPartElapsedDay.MultiSelect = False
        Me.DgvPartElapsedDay.Name = "DgvPartElapsedDay"
        Me.DgvPartElapsedDay.ReadOnly = True
        Me.DgvPartElapsedDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartElapsedDay.RowHeadersVisible = False
        Me.DgvPartElapsedDay.RowTemplate.Height = 26
        Me.DgvPartElapsedDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartElapsedDay.Size = New System.Drawing.Size(602, 98)
        Me.DgvPartElapsedDay.TabIndex = 0
        Me.DgvPartElapsedDay.TabStop = False
        '
        'GbxPartWorkedHour
        '
        Me.GbxPartWorkedHour.Controls.Add(Me.DgvPartWorkedHour)
        Me.GbxPartWorkedHour.Location = New System.Drawing.Point(410, 7)
        Me.GbxPartWorkedHour.Name = "GbxPartWorkedHour"
        Me.GbxPartWorkedHour.Size = New System.Drawing.Size(610, 249)
        Me.GbxPartWorkedHour.TabIndex = 1
        Me.GbxPartWorkedHour.TabStop = False
        Me.GbxPartWorkedHour.Text = "Controla Por Hora Trabalhada"
        '
        'DgvPartWorkedHour
        '
        Me.DgvPartWorkedHour.AllowUserToAddRows = False
        Me.DgvPartWorkedHour.AllowUserToDeleteRows = False
        Me.DgvPartWorkedHour.AllowUserToResizeColumns = False
        Me.DgvPartWorkedHour.AllowUserToResizeRows = False
        Me.DgvPartWorkedHour.BackgroundColor = System.Drawing.Color.White
        Me.DgvPartWorkedHour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPartWorkedHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartWorkedHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartWorkedHour.GridColor = System.Drawing.Color.Gainsboro
        Me.DgvPartWorkedHour.Location = New System.Drawing.Point(3, 19)
        Me.DgvPartWorkedHour.MultiSelect = False
        Me.DgvPartWorkedHour.Name = "DgvPartWorkedHour"
        Me.DgvPartWorkedHour.ReadOnly = True
        Me.DgvPartWorkedHour.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartWorkedHour.RowHeadersVisible = False
        Me.DgvPartWorkedHour.RowTemplate.Height = 26
        Me.DgvPartWorkedHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartWorkedHour.Size = New System.Drawing.Size(604, 227)
        Me.DgvPartWorkedHour.TabIndex = 0
        Me.DgvPartWorkedHour.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.QbxCustomer)
        Me.GroupBox1.Controls.Add(Me.TxtEvaluationNumber)
        Me.GroupBox1.Controls.Add(Me.RbtExecution)
        Me.GroupBox1.Controls.Add(Me.RbtGathering)
        Me.GroupBox1.Controls.Add(Me.LblEndTime)
        Me.GroupBox1.Controls.Add(Me.LblStartTime)
        Me.GroupBox1.Controls.Add(Me.TxtEndTime)
        Me.GroupBox1.Controls.Add(Me.TxtStartTime)
        Me.GroupBox1.Controls.Add(Me.CbxManualAverageWorkLoad)
        Me.GroupBox1.Controls.Add(Me.FlpCustomer)
        Me.GroupBox1.Controls.Add(Me.DbxAverageWorkLoad)
        Me.GroupBox1.Controls.Add(Me.DbxHorimeter)
        Me.GroupBox1.Controls.Add(Me.LblEvaluationDate)
        Me.GroupBox1.Controls.Add(Me.LblCustomer)
        Me.GroupBox1.Controls.Add(Me.LblAverageWorkLoad)
        Me.GroupBox1.Controls.Add(Me.LblEvaluationNumber)
        Me.GroupBox1.Controls.Add(Me.LblResponsible)
        Me.GroupBox1.Controls.Add(Me.TxtResponsible)
        Me.GroupBox1.Controls.Add(Me.DbxEvaluationDate)
        Me.GroupBox1.Controls.Add(Me.LblHorimeter)
        Me.GroupBox1.Controls.Add(Me.LblCompressor)
        Me.GroupBox1.Controls.Add(Me.QbxCompressor)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 3, 6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(395, 249)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Identificação"
        '
        'QbxCustomer
        '
        Me.QbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCustomer.CharactersToQuery = 1
        Condition1.FieldName = "iscustomer"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@iscustomer"
        Condition2.FieldName = "statusid"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@statusid"
        Condition3.FieldName = "controlmaintenance"
        Condition3.Operator = "="
        Condition3.TableNameOrAlias = "person"
        Condition3.Value = "@controlmaintenance"
        Me.QbxCustomer.Conditions.Add(Condition1)
        Me.QbxCustomer.Conditions.Add(Condition2)
        Me.QbxCustomer.Conditions.Add(Condition3)
        Me.QbxCustomer.DebugOnTextChanged = False
        Me.QbxCustomer.DisplayFieldAlias = "Nome Curto"
        Me.QbxCustomer.DisplayFieldName = "shortname"
        Me.QbxCustomer.DisplayMainFieldName = "id"
        Me.QbxCustomer.DisplayTableAlias = Nothing
        Me.QbxCustomer.DisplayTableName = "person"
        Me.QbxCustomer.Distinct = True
        Me.QbxCustomer.DropDownAutoStretchRight = False
        Me.QbxCustomer.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCustomer.IfNull = Nothing
        Me.QbxCustomer.Location = New System.Drawing.Point(6, 123)
        Me.QbxCustomer.MainReturnFieldName = "id"
        Me.QbxCustomer.MainTableAlias = Nothing
        Me.QbxCustomer.MainTableName = "person"
        Me.QbxCustomer.Name = "QbxCustomer"
        OtherField1.DisplayFieldAlias = "Nome"
        OtherField1.DisplayFieldName = "name"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "person"
        OtherField1.Freeze = False
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        OtherField2.DisplayFieldAlias = "CNPJ/CPF"
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        OtherField3.DisplayFieldAlias = "Cidade"
        OtherField3.DisplayFieldName = "name"
        OtherField3.DisplayMainFieldName = "id"
        OtherField3.DisplayTableAlias = Nothing
        OtherField3.DisplayTableName = "city"
        OtherField3.Freeze = False
        OtherField3.IfNull = Nothing
        OtherField3.Prefix = Nothing
        OtherField3.Suffix = Nothing
        OtherField4.DisplayFieldAlias = "Estado"
        OtherField4.DisplayFieldName = "name"
        OtherField4.DisplayMainFieldName = "id"
        OtherField4.DisplayTableAlias = Nothing
        OtherField4.DisplayTableName = "state"
        OtherField4.Freeze = False
        OtherField4.IfNull = Nothing
        OtherField4.Prefix = Nothing
        OtherField4.Suffix = Nothing
        Me.QbxCustomer.OtherFields.Add(OtherField1)
        Me.QbxCustomer.OtherFields.Add(OtherField2)
        Me.QbxCustomer.OtherFields.Add(OtherField3)
        Me.QbxCustomer.OtherFields.Add(OtherField4)
        Parameter1.ParameterName = "@iscustomer"
        Parameter1.ParameterValue = "1"
        Parameter2.ParameterName = "@statusid"
        Parameter2.ParameterValue = "0"
        Parameter3.ParameterName = "@controlmaintenance"
        Parameter3.ParameterValue = "1"
        Me.QbxCustomer.Parameters.Add(Parameter1)
        Me.QbxCustomer.Parameters.Add(Parameter2)
        Me.QbxCustomer.Parameters.Add(Parameter3)
        Me.QbxCustomer.Prefix = Nothing
        Relation1.Operator = "="
        Relation1.RelateFieldName = "personid"
        Relation1.RelateTableAlias = Nothing
        Relation1.RelateTableName = "personaddress"
        Relation1.RelationType = "LEFT"
        Relation1.WithFieldName = "id"
        Relation1.WithTableAlias = Nothing
        Relation1.WithTableName = "person"
        Relation2.Operator = "="
        Relation2.RelateFieldName = "id"
        Relation2.RelateTableAlias = Nothing
        Relation2.RelateTableName = "city"
        Relation2.RelationType = "LEFT"
        Relation2.WithFieldName = "cityid"
        Relation2.WithTableAlias = Nothing
        Relation2.WithTableName = "personaddress"
        Relation3.Operator = "="
        Relation3.RelateFieldName = "id"
        Relation3.RelateTableAlias = Nothing
        Relation3.RelateTableName = "state"
        Relation3.RelationType = "LEFT"
        Relation3.WithFieldName = "stateid"
        Relation3.WithTableAlias = Nothing
        Relation3.WithTableName = "city"
        Me.QbxCustomer.Relations.Add(Relation1)
        Me.QbxCustomer.Relations.Add(Relation2)
        Me.QbxCustomer.Relations.Add(Relation3)
        Me.QbxCustomer.Size = New System.Drawing.Size(382, 23)
        Me.QbxCustomer.Suffix = Nothing
        Me.QbxCustomer.TabIndex = 14
        '
        'TxtEvaluationNumber
        '
        Me.TxtEvaluationNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEvaluationNumber.Location = New System.Drawing.Point(6, 77)
        Me.TxtEvaluationNumber.MaxLength = 10
        Me.TxtEvaluationNumber.Name = "TxtEvaluationNumber"
        Me.TxtEvaluationNumber.Size = New System.Drawing.Size(105, 23)
        Me.TxtEvaluationNumber.TabIndex = 3
        Me.TxtEvaluationNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RbtExecution
        '
        Me.RbtExecution.AutoSize = True
        Me.RbtExecution.Location = New System.Drawing.Point(134, 21)
        Me.RbtExecution.Name = "RbtExecution"
        Me.RbtExecution.Size = New System.Drawing.Size(89, 21)
        Me.RbtExecution.TabIndex = 1
        Me.RbtExecution.TabStop = True
        Me.RbtExecution.Text = "Execução"
        Me.RbtExecution.UseVisualStyleBackColor = True
        '
        'RbtGathering
        '
        Me.RbtGathering.AutoSize = True
        Me.RbtGathering.Checked = True
        Me.RbtGathering.Location = New System.Drawing.Point(6, 22)
        Me.RbtGathering.Name = "RbtGathering"
        Me.RbtGathering.Size = New System.Drawing.Size(122, 21)
        Me.RbtGathering.TabIndex = 0
        Me.RbtGathering.TabStop = True
        Me.RbtGathering.Text = "Levantamento"
        Me.RbtGathering.UseVisualStyleBackColor = True
        '
        'LblEndTime
        '
        Me.LblEndTime.AutoSize = True
        Me.LblEndTime.Location = New System.Drawing.Point(310, 57)
        Me.LblEndTime.Name = "LblEndTime"
        Me.LblEndTime.Size = New System.Drawing.Size(30, 17)
        Me.LblEndTime.TabIndex = 8
        Me.LblEndTime.Text = "Fim"
        '
        'LblStartTime
        '
        Me.LblStartTime.AutoSize = True
        Me.LblStartTime.Location = New System.Drawing.Point(229, 57)
        Me.LblStartTime.Name = "LblStartTime"
        Me.LblStartTime.Size = New System.Drawing.Size(42, 17)
        Me.LblStartTime.TabIndex = 6
        Me.LblStartTime.Text = "Inicio"
        '
        'TxtEndTime
        '
        Me.TxtEndTime.Location = New System.Drawing.Point(313, 77)
        Me.TxtEndTime.Mask = "00:00"
        Me.TxtEndTime.Name = "TxtEndTime"
        Me.TxtEndTime.Size = New System.Drawing.Size(75, 23)
        Me.TxtEndTime.TabIndex = 9
        Me.TxtEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtEndTime.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.TxtEndTime.ValidatingType = GetType(Date)
        '
        'TxtStartTime
        '
        Me.TxtStartTime.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt
        Me.TxtStartTime.Location = New System.Drawing.Point(232, 77)
        Me.TxtStartTime.Mask = "00:00"
        Me.TxtStartTime.Name = "TxtStartTime"
        Me.TxtStartTime.Size = New System.Drawing.Size(75, 23)
        Me.TxtStartTime.TabIndex = 7
        Me.TxtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtStartTime.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.TxtStartTime.ValidatingType = GetType(Date)
        '
        'CbxManualAverageWorkLoad
        '
        Me.CbxManualAverageWorkLoad.AutoSize = True
        Me.CbxManualAverageWorkLoad.Location = New System.Drawing.Point(373, 198)
        Me.CbxManualAverageWorkLoad.Name = "CbxManualAverageWorkLoad"
        Me.CbxManualAverageWorkLoad.Size = New System.Drawing.Size(15, 14)
        Me.CbxManualAverageWorkLoad.TabIndex = 23
        Me.CbxManualAverageWorkLoad.UseVisualStyleBackColor = True
        '
        'FlpCustomer
        '
        Me.FlpCustomer.Controls.Add(Me.BtnFilterCustomer)
        Me.FlpCustomer.Controls.Add(Me.BtnViewCustomer)
        Me.FlpCustomer.Controls.Add(Me.BtnNewCustomer)
        Me.FlpCustomer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCustomer.Location = New System.Drawing.Point(319, 102)
        Me.FlpCustomer.Name = "FlpCustomer"
        Me.FlpCustomer.Size = New System.Drawing.Size(69, 21)
        Me.FlpCustomer.TabIndex = 15
        '
        'BtnFilterCustomer
        '
        Me.BtnFilterCustomer.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterCustomer.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterCustomer.FlatAppearance.BorderSize = 0
        Me.BtnFilterCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterCustomer.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterCustomer.Name = "BtnFilterCustomer"
        Me.BtnFilterCustomer.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterCustomer.TabIndex = 2
        Me.BtnFilterCustomer.TabStop = False
        Me.BtnFilterCustomer.TooltipText = ""
        Me.BtnFilterCustomer.UseVisualStyleBackColor = False
        Me.BtnFilterCustomer.Visible = False
        '
        'BtnViewCustomer
        '
        Me.BtnViewCustomer.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewCustomer.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewCustomer.FlatAppearance.BorderSize = 0
        Me.BtnViewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewCustomer.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewCustomer.Name = "BtnViewCustomer"
        Me.BtnViewCustomer.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewCustomer.TabIndex = 1
        Me.BtnViewCustomer.TabStop = False
        Me.BtnViewCustomer.TooltipText = ""
        Me.BtnViewCustomer.UseVisualStyleBackColor = False
        Me.BtnViewCustomer.Visible = False
        '
        'BtnNewCustomer
        '
        Me.BtnNewCustomer.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewCustomer.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewCustomer.FlatAppearance.BorderSize = 0
        Me.BtnNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewCustomer.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewCustomer.Name = "BtnNewCustomer"
        Me.BtnNewCustomer.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewCustomer.TabIndex = 0
        Me.BtnNewCustomer.TabStop = False
        Me.BtnNewCustomer.TooltipText = ""
        Me.BtnNewCustomer.UseVisualStyleBackColor = False
        Me.BtnNewCustomer.Visible = False
        '
        'DbxAverageWorkLoad
        '
        Me.DbxAverageWorkLoad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DbxAverageWorkLoad.DecimalOnly = True
        Me.DbxAverageWorkLoad.DecimalPlaces = 2
        Me.DbxAverageWorkLoad.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxAverageWorkLoad.Location = New System.Drawing.Point(306, 215)
        Me.DbxAverageWorkLoad.Name = "DbxAverageWorkLoad"
        Me.DbxAverageWorkLoad.ReadOnly = True
        Me.DbxAverageWorkLoad.Size = New System.Drawing.Size(82, 23)
        Me.DbxAverageWorkLoad.TabIndex = 24
        Me.DbxAverageWorkLoad.Text = "0,00"
        Me.DbxAverageWorkLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DbxHorimeter
        '
        Me.DbxHorimeter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DbxHorimeter.DecimalOnly = True
        Me.DbxHorimeter.DecimalPlaces = 0
        Me.DbxHorimeter.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxHorimeter.Location = New System.Drawing.Point(200, 215)
        Me.DbxHorimeter.Name = "DbxHorimeter"
        Me.DbxHorimeter.Size = New System.Drawing.Size(100, 23)
        Me.DbxHorimeter.TabIndex = 21
        Me.DbxHorimeter.Text = "0"
        Me.DbxHorimeter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblEvaluationDate
        '
        Me.LblEvaluationDate.AutoSize = True
        Me.LblEvaluationDate.Location = New System.Drawing.Point(114, 57)
        Me.LblEvaluationDate.Name = "LblEvaluationDate"
        Me.LblEvaluationDate.Size = New System.Drawing.Size(98, 17)
        Me.LblEvaluationDate.TabIndex = 4
        Me.LblEvaluationDate.Text = "Dt. Avaliação"
        '
        'LblCustomer
        '
        Me.LblCustomer.AutoSize = True
        Me.LblCustomer.Location = New System.Drawing.Point(3, 103)
        Me.LblCustomer.Name = "LblCustomer"
        Me.LblCustomer.Size = New System.Drawing.Size(54, 17)
        Me.LblCustomer.TabIndex = 13
        Me.LblCustomer.Text = "Cliente"
        '
        'LblAverageWorkLoad
        '
        Me.LblAverageWorkLoad.AutoSize = True
        Me.LblAverageWorkLoad.Location = New System.Drawing.Point(303, 195)
        Me.LblAverageWorkLoad.Name = "LblAverageWorkLoad"
        Me.LblAverageWorkLoad.Size = New System.Drawing.Size(35, 17)
        Me.LblAverageWorkLoad.TabIndex = 22
        Me.LblAverageWorkLoad.Text = "CMT"
        Me.Tip.SetToolTip(Me.LblAverageWorkLoad, "Carga Média de Trabalho")
        '
        'LblEvaluationNumber
        '
        Me.LblEvaluationNumber.AutoSize = True
        Me.LblEvaluationNumber.Location = New System.Drawing.Point(6, 57)
        Me.LblEvaluationNumber.Name = "LblEvaluationNumber"
        Me.LblEvaluationNumber.Size = New System.Drawing.Size(94, 17)
        Me.LblEvaluationNumber.TabIndex = 2
        Me.LblEvaluationNumber.Text = "Nº Avaliação"
        '
        'LblResponsible
        '
        Me.LblResponsible.AutoSize = True
        Me.LblResponsible.Location = New System.Drawing.Point(6, 195)
        Me.LblResponsible.Name = "LblResponsible"
        Me.LblResponsible.Size = New System.Drawing.Size(88, 17)
        Me.LblResponsible.TabIndex = 18
        Me.LblResponsible.Text = "Responsável"
        '
        'TxtResponsible
        '
        Me.TxtResponsible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtResponsible.Location = New System.Drawing.Point(6, 215)
        Me.TxtResponsible.Name = "TxtResponsible"
        Me.TxtResponsible.Size = New System.Drawing.Size(188, 23)
        Me.TxtResponsible.TabIndex = 19
        '
        'DbxEvaluationDate
        '
        Me.DbxEvaluationDate.ButtonImage = CType(resources.GetObject("DbxEvaluationDate.ButtonImage"), System.Drawing.Image)
        Me.DbxEvaluationDate.Location = New System.Drawing.Point(117, 77)
        Me.DbxEvaluationDate.Name = "DbxEvaluationDate"
        Me.DbxEvaluationDate.Size = New System.Drawing.Size(109, 23)
        Me.DbxEvaluationDate.TabIndex = 5
        '
        'LblHorimeter
        '
        Me.LblHorimeter.AutoSize = True
        Me.LblHorimeter.Location = New System.Drawing.Point(197, 195)
        Me.LblHorimeter.Name = "LblHorimeter"
        Me.LblHorimeter.Size = New System.Drawing.Size(72, 17)
        Me.LblHorimeter.TabIndex = 20
        Me.LblHorimeter.Text = "Horímetro"
        '
        'LblCompressor
        '
        Me.LblCompressor.AutoSize = True
        Me.LblCompressor.Location = New System.Drawing.Point(6, 149)
        Me.LblCompressor.Name = "LblCompressor"
        Me.LblCompressor.Size = New System.Drawing.Size(85, 17)
        Me.LblCompressor.TabIndex = 16
        Me.LblCompressor.Text = "Compressor"
        '
        'QbxCompressor
        '
        Me.QbxCompressor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCompressor.CharactersToQuery = 1
        Condition4.FieldName = "statusid"
        Condition4.Operator = "="
        Condition4.TableNameOrAlias = "personcompressor"
        Condition4.Value = "@statusid"
        Me.QbxCompressor.Conditions.Add(Condition4)
        Me.QbxCompressor.DebugOnTextChanged = False
        Me.QbxCompressor.DisplayFieldAlias = "Compressor"
        Me.QbxCompressor.DisplayFieldName = "name"
        Me.QbxCompressor.DisplayMainFieldName = "id"
        Me.QbxCompressor.DisplayTableAlias = Nothing
        Me.QbxCompressor.DisplayTableName = "compressor"
        Me.QbxCompressor.Distinct = False
        Me.QbxCompressor.DropDownAutoStretchRight = False
        Me.QbxCompressor.Enabled = False
        Me.QbxCompressor.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCompressor.IfNull = Nothing
        Me.QbxCompressor.Location = New System.Drawing.Point(6, 169)
        Me.QbxCompressor.MainReturnFieldName = "id"
        Me.QbxCompressor.MainTableAlias = Nothing
        Me.QbxCompressor.MainTableName = "personcompressor"
        Me.QbxCompressor.Name = "QbxCompressor"
        OtherField5.DisplayFieldAlias = "Nº de Série"
        OtherField5.DisplayFieldName = "serialnumber"
        OtherField5.DisplayMainFieldName = "id"
        OtherField5.DisplayTableAlias = Nothing
        OtherField5.DisplayTableName = "personcompressor"
        OtherField5.Freeze = True
        OtherField5.IfNull = Nothing
        OtherField5.Prefix = " NS: "
        OtherField5.Suffix = Nothing
        OtherField6.DisplayFieldAlias = "Patrimônio"
        OtherField6.DisplayFieldName = "patrimony"
        OtherField6.DisplayMainFieldName = "id"
        OtherField6.DisplayTableAlias = Nothing
        OtherField6.DisplayTableName = "personcompressor"
        OtherField6.Freeze = True
        OtherField6.IfNull = Nothing
        OtherField6.Prefix = " PAT: "
        OtherField6.Suffix = Nothing
        OtherField7.DisplayFieldAlias = "Setor"
        OtherField7.DisplayFieldName = "sector"
        OtherField7.DisplayMainFieldName = "id"
        OtherField7.DisplayTableAlias = Nothing
        OtherField7.DisplayTableName = "personcompressor"
        OtherField7.Freeze = True
        OtherField7.IfNull = Nothing
        OtherField7.Prefix = " SETOR: "
        OtherField7.Suffix = Nothing
        Me.QbxCompressor.OtherFields.Add(OtherField5)
        Me.QbxCompressor.OtherFields.Add(OtherField6)
        Me.QbxCompressor.OtherFields.Add(OtherField7)
        Parameter4.ParameterName = "@statusid"
        Parameter4.ParameterValue = "0"
        Me.QbxCompressor.Parameters.Add(Parameter4)
        Me.QbxCompressor.Prefix = Nothing
        Relation4.Operator = "="
        Relation4.RelateFieldName = "id"
        Relation4.RelateTableAlias = Nothing
        Relation4.RelateTableName = "compressor"
        Relation4.RelationType = "INNER"
        Relation4.WithFieldName = "compressorid"
        Relation4.WithTableAlias = Nothing
        Relation4.WithTableName = "personcompressor"
        Me.QbxCompressor.Relations.Add(Relation4)
        Me.QbxCompressor.Size = New System.Drawing.Size(382, 23)
        Me.QbxCompressor.Suffix = Nothing
        Me.QbxCompressor.TabIndex = 17
        '
        'TabTechnicalAdvice
        '
        Me.TabTechnicalAdvice.Controls.Add(Me.TxtTechnicalAdvice)
        Me.TabTechnicalAdvice.Location = New System.Drawing.Point(4, 26)
        Me.TabTechnicalAdvice.Name = "TabTechnicalAdvice"
        Me.TabTechnicalAdvice.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTechnicalAdvice.Size = New System.Drawing.Size(1032, 387)
        Me.TabTechnicalAdvice.TabIndex = 6
        Me.TabTechnicalAdvice.Text = "Parecer Técnico"
        Me.TabTechnicalAdvice.UseVisualStyleBackColor = True
        '
        'TxtTechnicalAdvice
        '
        Me.TxtTechnicalAdvice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTechnicalAdvice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTechnicalAdvice.Location = New System.Drawing.Point(3, 3)
        Me.TxtTechnicalAdvice.MaxLength = 1000000
        Me.TxtTechnicalAdvice.Name = "TxtTechnicalAdvice"
        Me.TxtTechnicalAdvice.Size = New System.Drawing.Size(1026, 381)
        Me.TxtTechnicalAdvice.TabIndex = 1
        Me.TxtTechnicalAdvice.Text = ""
        '
        'TabDocument
        '
        Me.TabDocument.AutoScroll = True
        Me.TabDocument.Controls.Add(Me.PdfDocumentViewer)
        Me.TabDocument.Controls.Add(Me.TsDocument)
        Me.TabDocument.Location = New System.Drawing.Point(4, 26)
        Me.TabDocument.Name = "TabDocument"
        Me.TabDocument.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDocument.Size = New System.Drawing.Size(1032, 387)
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
        Me.PdfDocumentViewer.Size = New System.Drawing.Size(1026, 356)
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
        Me.TsDocument.Size = New System.Drawing.Size(1026, 25)
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
        'TmrCustomer
        '
        Me.TmrCustomer.Enabled = True
        Me.TmrCustomer.Interval = 300
        '
        'TmrCompressor
        '
        Me.TmrCompressor.Enabled = True
        Me.TmrCompressor.Interval = 300
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
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'TabPhoto
        '
        Me.TabPhoto.Location = New System.Drawing.Point(4, 26)
        Me.TabPhoto.Name = "TabPhoto"
        Me.TabPhoto.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPhoto.Size = New System.Drawing.Size(1032, 387)
        Me.TabPhoto.TabIndex = 8
        Me.TabPhoto.Text = "Fotos"
        Me.TabPhoto.UseVisualStyleBackColor = True
        '
        'TabSignature
        '
        Me.TabSignature.Location = New System.Drawing.Point(4, 26)
        Me.TabSignature.Name = "TabSignature"
        Me.TabSignature.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSignature.Size = New System.Drawing.Size(1032, 387)
        Me.TabSignature.TabIndex = 9
        Me.TabSignature.Text = "Assinatura"
        Me.TabSignature.UseVisualStyleBackColor = True
        '
        'FrmEvaluation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1040, 511)
        Me.Controls.Add(Me.TcEvaluation)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluation"
        Me.ShowIcon = False
        Me.Text = "Avaliação de Compressor"
        Me.Panel1.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TcEvaluation.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvTechnician, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsTechnician.ResumeLayout(False)
        Me.TsTechnician.PerformLayout()
        Me.GbxPartElapsedDay.ResumeLayout(False)
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxPartWorkedHour.ResumeLayout(False)
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FlpCustomer.ResumeLayout(False)
        Me.TabTechnicalAdvice.ResumeLayout(False)
        Me.TabDocument.ResumeLayout(False)
        Me.TsDocument.ResumeLayout(False)
        Me.TsDocument.PerformLayout()
        CType(Me.NudHourPerDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents TmrTechnician As Timer
    Friend WithEvents TcEvaluation As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents DbxEvaluationDate As ControlLibrary.DateBox
    Friend WithEvents QbxCompressor As ControlLibrary.QueriedBox
    Friend WithEvents LblCompressor As Label
    Friend WithEvents LblResponsible As Label
    Friend WithEvents LblEvaluationNumber As Label
    Friend WithEvents LblEvaluationDate As Label
    Friend WithEvents LblCustomer As Label
    Friend WithEvents TabTechnicalAdvice As TabPage
    Friend WithEvents LblAverageWorkLoad As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DbxHorimeter As ControlLibrary.DecimalBox
    Friend WithEvents LblHorimeter As Label
    Friend WithEvents TxtTechnicalAdvice As RichTextBox
    Friend WithEvents TxtResponsible As TextBox
    Friend WithEvents NudHourPerDay As NumericUpDown
    Friend WithEvents BtnNewCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents TmrCustomer As Timer
    Friend WithEvents TmrCompressor As Timer
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
    Friend WithEvents FlpCustomer As FlowLayoutPanel
    Friend WithEvents PdfDocumentViewer As Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView
    Friend WithEvents DbxAverageWorkLoad As ControlLibrary.DecimalBox
    Friend WithEvents CbxManualAverageWorkLoad As CheckBox
    Friend WithEvents BtnStatusValue As ToolStripDropDownButton
    Friend WithEvents BtnApprove As ToolStripMenuItem
    Friend WithEvents BtnReject As ToolStripMenuItem
    Friend WithEvents LblStatusValue As ToolStripLabel
    Friend WithEvents LblEndTime As Label
    Friend WithEvents LblStartTime As Label
    Friend WithEvents TxtEndTime As MaskedTextBox
    Friend WithEvents TxtStartTime As MaskedTextBox
    Friend WithEvents RbtExecution As RadioButton
    Friend WithEvents RbtGathering As RadioButton
    Friend WithEvents GbxPartElapsedDay As GroupBox
    Friend WithEvents DgvPartElapsedDay As DataGridView
    Friend WithEvents GbxPartWorkedHour As GroupBox
    Friend WithEvents DgvPartWorkedHour As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCalculate As Button
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents BtnDisapprove As ToolStripMenuItem
    Friend WithEvents TxtEvaluationNumber As TextBox
    Friend WithEvents QbxCustomer As ControlLibrary.QueriedBox
    Friend WithEvents Tip As ToolTip
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DgvTechnician As DataGridView
    Friend WithEvents TsTechnician As ToolStrip
    Friend WithEvents BtnIncludeTechnician As ToolStripButton
    Friend WithEvents BtnDeleteTechnician As ToolStripButton
    Friend WithEvents BtnEditTechnician As ToolStripButton
    Friend WithEvents TabPhoto As TabPage
    Friend WithEvents TabSignature As TabPage
End Class
