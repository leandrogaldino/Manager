<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComission
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
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Condition3 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition4 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField3 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField4 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter3 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter4 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Condition5 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition6 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField5 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField6 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter5 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter6 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComission))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
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
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.TcRequest = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NoFocusCueButton4 = New Manager.NoFocusCueButton()
        Me.NoFocusCueButton5 = New Manager.NoFocusCueButton()
        Me.NoFocusCueButton6 = New Manager.NoFocusCueButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NoFocusCueButton1 = New Manager.NoFocusCueButton()
        Me.NoFocusCueButton2 = New Manager.NoFocusCueButton()
        Me.NoFocusCueButton3 = New Manager.NoFocusCueButton()
        Me.FlpTechnician = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterTechnician = New Manager.NoFocusCueButton()
        Me.BtnNewTechnician = New Manager.NoFocusCueButton()
        Me.BtnViewTechnician = New Manager.NoFocusCueButton()
        Me.DbxHorimeter = New ControlLibrary.DecimalBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCustomer = New System.Windows.Forms.Label()
        Me.QueriedBox2 = New ControlLibrary.QueriedBox()
        Me.QueriedBox1 = New ControlLibrary.QueriedBox()
        Me.QbxCustomer = New ControlLibrary.QueriedBox()
        Me.LblEvaluationDate = New System.Windows.Forms.Label()
        Me.DbxEvaluationDate = New ControlLibrary.DateBox()
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
        Me.TsDocument = New System.Windows.Forms.ToolStrip()
        Me.BtnAttachPDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnSavePDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrintPDF = New System.Windows.Forms.ToolStripButton()
        Me.BtnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.BtnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.LblDocumentPage = New System.Windows.Forms.ToolStripLabel()
        Me.TsValue = New System.Windows.Forms.ToolStrip()
        Me.LblExpense = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel17 = New System.Windows.Forms.ToolStripLabel()
        Me.LblRefund = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel15 = New System.Windows.Forms.ToolStripLabel()
        Me.LblPrevious = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel13 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcRequest.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlpTechnician.SuspendLayout()
        Me.TabItems.SuspendLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsItem.SuspendLayout()
        Me.TabNote.SuspendLayout()
        Me.TabDocument.SuspendLayout()
        Me.TsDocument.SuspendLayout()
        Me.TsValue.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 326)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 44)
        Me.Panel1.TabIndex = 7
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(273, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(172, 7)
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
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreationDate, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(380, 25)
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
        'BtnStatusValue
        '
        Me.BtnStatusValue.AutoToolTip = False
        Me.BtnStatusValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnStatusValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnStatusValue.Name = "BtnStatusValue"
        Me.BtnStatusValue.Size = New System.Drawing.Size(44, 22)
        Me.BtnStatusValue.Text = "        "
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
        Me.TsNavigation.Size = New System.Drawing.Size(380, 25)
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
        Me.BtnInclude.Text = "Incluir Comissão"
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
        Me.BtnDelete.Text = "Excluir Comissão"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Comissão"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Comissão Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Comissão"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Comissão"
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
        'DgvNavigator
        '
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
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
        Me.TcRequest.Size = New System.Drawing.Size(380, 251)
        Me.TcRequest.TabIndex = 8
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.GroupBox1)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(372, 221)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox1.Controls.Add(Me.FlpTechnician)
        Me.GroupBox1.Controls.Add(Me.DbxHorimeter)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblCustomer)
        Me.GroupBox1.Controls.Add(Me.QueriedBox2)
        Me.GroupBox1.Controls.Add(Me.QueriedBox1)
        Me.GroupBox1.Controls.Add(Me.QbxCustomer)
        Me.GroupBox1.Controls.Add(Me.LblEvaluationDate)
        Me.GroupBox1.Controls.Add(Me.DbxEvaluationDate)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(359, 207)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Identificação"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.NoFocusCueButton4)
        Me.FlowLayoutPanel2.Controls.Add(Me.NoFocusCueButton5)
        Me.FlowLayoutPanel2.Controls.Add(Me.NoFocusCueButton6)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(283, 155)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(69, 21)
        Me.FlowLayoutPanel2.TabIndex = 31
        '
        'NoFocusCueButton4
        '
        Me.NoFocusCueButton4.BackColor = System.Drawing.Color.Transparent
        Me.NoFocusCueButton4.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.NoFocusCueButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NoFocusCueButton4.FlatAppearance.BorderSize = 0
        Me.NoFocusCueButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NoFocusCueButton4.Location = New System.Drawing.Point(49, 3)
        Me.NoFocusCueButton4.Name = "NoFocusCueButton4"
        Me.NoFocusCueButton4.Size = New System.Drawing.Size(17, 17)
        Me.NoFocusCueButton4.TabIndex = 2
        Me.NoFocusCueButton4.TabStop = False
        Me.NoFocusCueButton4.TooltipText = ""
        Me.NoFocusCueButton4.UseVisualStyleBackColor = False
        Me.NoFocusCueButton4.Visible = False
        '
        'NoFocusCueButton5
        '
        Me.NoFocusCueButton5.BackColor = System.Drawing.Color.Transparent
        Me.NoFocusCueButton5.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.NoFocusCueButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NoFocusCueButton5.FlatAppearance.BorderSize = 0
        Me.NoFocusCueButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NoFocusCueButton5.Location = New System.Drawing.Point(26, 3)
        Me.NoFocusCueButton5.Name = "NoFocusCueButton5"
        Me.NoFocusCueButton5.Size = New System.Drawing.Size(17, 17)
        Me.NoFocusCueButton5.TabIndex = 1
        Me.NoFocusCueButton5.TabStop = False
        Me.NoFocusCueButton5.TooltipText = ""
        Me.NoFocusCueButton5.UseVisualStyleBackColor = False
        Me.NoFocusCueButton5.Visible = False
        '
        'NoFocusCueButton6
        '
        Me.NoFocusCueButton6.BackColor = System.Drawing.Color.Transparent
        Me.NoFocusCueButton6.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.NoFocusCueButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NoFocusCueButton6.FlatAppearance.BorderSize = 0
        Me.NoFocusCueButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NoFocusCueButton6.Location = New System.Drawing.Point(3, 3)
        Me.NoFocusCueButton6.Name = "NoFocusCueButton6"
        Me.NoFocusCueButton6.Size = New System.Drawing.Size(17, 17)
        Me.NoFocusCueButton6.TabIndex = 0
        Me.NoFocusCueButton6.TabStop = False
        Me.NoFocusCueButton6.TooltipText = ""
        Me.NoFocusCueButton6.UseVisualStyleBackColor = False
        Me.NoFocusCueButton6.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.NoFocusCueButton1)
        Me.FlowLayoutPanel1.Controls.Add(Me.NoFocusCueButton2)
        Me.FlowLayoutPanel1.Controls.Add(Me.NoFocusCueButton3)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(284, 109)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(69, 21)
        Me.FlowLayoutPanel1.TabIndex = 31
        '
        'NoFocusCueButton1
        '
        Me.NoFocusCueButton1.BackColor = System.Drawing.Color.Transparent
        Me.NoFocusCueButton1.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.NoFocusCueButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NoFocusCueButton1.FlatAppearance.BorderSize = 0
        Me.NoFocusCueButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NoFocusCueButton1.Location = New System.Drawing.Point(49, 3)
        Me.NoFocusCueButton1.Name = "NoFocusCueButton1"
        Me.NoFocusCueButton1.Size = New System.Drawing.Size(17, 17)
        Me.NoFocusCueButton1.TabIndex = 2
        Me.NoFocusCueButton1.TabStop = False
        Me.NoFocusCueButton1.TooltipText = ""
        Me.NoFocusCueButton1.UseVisualStyleBackColor = False
        Me.NoFocusCueButton1.Visible = False
        '
        'NoFocusCueButton2
        '
        Me.NoFocusCueButton2.BackColor = System.Drawing.Color.Transparent
        Me.NoFocusCueButton2.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.NoFocusCueButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NoFocusCueButton2.FlatAppearance.BorderSize = 0
        Me.NoFocusCueButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NoFocusCueButton2.Location = New System.Drawing.Point(26, 3)
        Me.NoFocusCueButton2.Name = "NoFocusCueButton2"
        Me.NoFocusCueButton2.Size = New System.Drawing.Size(17, 17)
        Me.NoFocusCueButton2.TabIndex = 1
        Me.NoFocusCueButton2.TabStop = False
        Me.NoFocusCueButton2.TooltipText = ""
        Me.NoFocusCueButton2.UseVisualStyleBackColor = False
        Me.NoFocusCueButton2.Visible = False
        '
        'NoFocusCueButton3
        '
        Me.NoFocusCueButton3.BackColor = System.Drawing.Color.Transparent
        Me.NoFocusCueButton3.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.NoFocusCueButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NoFocusCueButton3.FlatAppearance.BorderSize = 0
        Me.NoFocusCueButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NoFocusCueButton3.Location = New System.Drawing.Point(3, 3)
        Me.NoFocusCueButton3.Name = "NoFocusCueButton3"
        Me.NoFocusCueButton3.Size = New System.Drawing.Size(17, 17)
        Me.NoFocusCueButton3.TabIndex = 0
        Me.NoFocusCueButton3.TabStop = False
        Me.NoFocusCueButton3.TooltipText = ""
        Me.NoFocusCueButton3.UseVisualStyleBackColor = False
        Me.NoFocusCueButton3.Visible = False
        '
        'FlpTechnician
        '
        Me.FlpTechnician.Controls.Add(Me.BtnFilterTechnician)
        Me.FlpTechnician.Controls.Add(Me.BtnNewTechnician)
        Me.FlpTechnician.Controls.Add(Me.BtnViewTechnician)
        Me.FlpTechnician.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpTechnician.Location = New System.Drawing.Point(283, 63)
        Me.FlpTechnician.Name = "FlpTechnician"
        Me.FlpTechnician.Size = New System.Drawing.Size(69, 21)
        Me.FlpTechnician.TabIndex = 31
        '
        'BtnFilterTechnician
        '
        Me.BtnFilterTechnician.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterTechnician.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterTechnician.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterTechnician.FlatAppearance.BorderSize = 0
        Me.BtnFilterTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterTechnician.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterTechnician.Name = "BtnFilterTechnician"
        Me.BtnFilterTechnician.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterTechnician.TabIndex = 2
        Me.BtnFilterTechnician.TabStop = False
        Me.BtnFilterTechnician.TooltipText = ""
        Me.BtnFilterTechnician.UseVisualStyleBackColor = False
        Me.BtnFilterTechnician.Visible = False
        '
        'BtnNewTechnician
        '
        Me.BtnNewTechnician.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewTechnician.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewTechnician.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewTechnician.FlatAppearance.BorderSize = 0
        Me.BtnNewTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewTechnician.Location = New System.Drawing.Point(26, 3)
        Me.BtnNewTechnician.Name = "BtnNewTechnician"
        Me.BtnNewTechnician.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewTechnician.TabIndex = 1
        Me.BtnNewTechnician.TabStop = False
        Me.BtnNewTechnician.TooltipText = ""
        Me.BtnNewTechnician.UseVisualStyleBackColor = False
        Me.BtnNewTechnician.Visible = False
        '
        'BtnViewTechnician
        '
        Me.BtnViewTechnician.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewTechnician.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewTechnician.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewTechnician.FlatAppearance.BorderSize = 0
        Me.BtnViewTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewTechnician.Location = New System.Drawing.Point(3, 3)
        Me.BtnViewTechnician.Name = "BtnViewTechnician"
        Me.BtnViewTechnician.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewTechnician.TabIndex = 0
        Me.BtnViewTechnician.TabStop = False
        Me.BtnViewTechnician.TooltipText = ""
        Me.BtnViewTechnician.UseVisualStyleBackColor = False
        Me.BtnViewTechnician.Visible = False
        '
        'DbxHorimeter
        '
        Me.DbxHorimeter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DbxHorimeter.DecimalOnly = True
        Me.DbxHorimeter.DecimalPlaces = 2
        Me.DbxHorimeter.Location = New System.Drawing.Point(240, 39)
        Me.DbxHorimeter.Name = "DbxHorimeter"
        Me.DbxHorimeter.ReadOnly = True
        Me.DbxHorimeter.Size = New System.Drawing.Size(113, 23)
        Me.DbxHorimeter.TabIndex = 30
        Me.DbxHorimeter.Text = "0,00"
        Me.DbxHorimeter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(237, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 17)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Valor do Pedido"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(124, 39)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(110, 23)
        Me.TextBox1.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(121, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Nº Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Vendedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Representada"
        '
        'LblCustomer
        '
        Me.LblCustomer.AutoSize = True
        Me.LblCustomer.Location = New System.Drawing.Point(6, 65)
        Me.LblCustomer.Name = "LblCustomer"
        Me.LblCustomer.Size = New System.Drawing.Size(101, 17)
        Me.LblCustomer.TabIndex = 27
        Me.LblCustomer.Text = "Representante"
        '
        'QueriedBox2
        '
        Me.QueriedBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@statusid"
        Condition2.FieldName = "iscustomer"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@iscustomer"
        Me.QueriedBox2.Conditions.Add(Condition1)
        Me.QueriedBox2.Conditions.Add(Condition2)
        Me.QueriedBox2.DisplayFieldAlias = "Nome"
        Me.QueriedBox2.DisplayFieldName = "name"
        Me.QueriedBox2.DisplayMainFieldName = "id"
        Me.QueriedBox2.DisplayTableAlias = Nothing
        Me.QueriedBox2.DisplayTableName = "person"
        Me.QueriedBox2.Distinct = False
        Me.QueriedBox2.DropDownAutoStretchRight = False
        Me.QueriedBox2.DropDownStretchRight = 263
        Me.QueriedBox2.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QueriedBox2.IfNull = Nothing
        Me.QueriedBox2.Location = New System.Drawing.Point(9, 176)
        Me.QueriedBox2.MainReturnFieldName = "id"
        Me.QueriedBox2.MainTableAlias = Nothing
        Me.QueriedBox2.MainTableName = "person"
        Me.QueriedBox2.Name = "QueriedBox2"
        OtherField1.DisplayFieldAlias = "Nome Curto"
        OtherField1.DisplayFieldName = "shortname"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "person"
        OtherField1.Freeze = False
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        OtherField2.DisplayFieldAlias = "CPF/CNPJ"
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        Me.QueriedBox2.OtherFields.Add(OtherField1)
        Me.QueriedBox2.OtherFields.Add(OtherField2)
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Parameter2.ParameterName = "@iscustomer"
        Parameter2.ParameterValue = "1"
        Me.QueriedBox2.Parameters.Add(Parameter1)
        Me.QueriedBox2.Parameters.Add(Parameter2)
        Me.QueriedBox2.Prefix = Nothing
        Me.QueriedBox2.Size = New System.Drawing.Size(344, 23)
        Me.QueriedBox2.Suffix = Nothing
        Me.QueriedBox2.TabIndex = 28
        '
        'QueriedBox1
        '
        Me.QueriedBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Condition3.FieldName = "statusid"
        Condition3.Operator = "="
        Condition3.TableNameOrAlias = "person"
        Condition3.Value = "@statusid"
        Condition4.FieldName = "iscustomer"
        Condition4.Operator = "="
        Condition4.TableNameOrAlias = "person"
        Condition4.Value = "@iscustomer"
        Me.QueriedBox1.Conditions.Add(Condition3)
        Me.QueriedBox1.Conditions.Add(Condition4)
        Me.QueriedBox1.DisplayFieldAlias = "Nome"
        Me.QueriedBox1.DisplayFieldName = "name"
        Me.QueriedBox1.DisplayMainFieldName = "id"
        Me.QueriedBox1.DisplayTableAlias = Nothing
        Me.QueriedBox1.DisplayTableName = "person"
        Me.QueriedBox1.Distinct = False
        Me.QueriedBox1.DropDownAutoStretchRight = False
        Me.QueriedBox1.DropDownStretchRight = 263
        Me.QueriedBox1.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QueriedBox1.IfNull = Nothing
        Me.QueriedBox1.Location = New System.Drawing.Point(9, 130)
        Me.QueriedBox1.MainReturnFieldName = "id"
        Me.QueriedBox1.MainTableAlias = Nothing
        Me.QueriedBox1.MainTableName = "person"
        Me.QueriedBox1.Name = "QueriedBox1"
        OtherField3.DisplayFieldAlias = "Nome Curto"
        OtherField3.DisplayFieldName = "shortname"
        OtherField3.DisplayMainFieldName = "id"
        OtherField3.DisplayTableAlias = Nothing
        OtherField3.DisplayTableName = "person"
        OtherField3.Freeze = False
        OtherField3.IfNull = Nothing
        OtherField3.Prefix = Nothing
        OtherField3.Suffix = Nothing
        OtherField4.DisplayFieldAlias = "CPF/CNPJ"
        OtherField4.DisplayFieldName = "document"
        OtherField4.DisplayMainFieldName = "id"
        OtherField4.DisplayTableAlias = Nothing
        OtherField4.DisplayTableName = "person"
        OtherField4.Freeze = False
        OtherField4.IfNull = Nothing
        OtherField4.Prefix = Nothing
        OtherField4.Suffix = Nothing
        Me.QueriedBox1.OtherFields.Add(OtherField3)
        Me.QueriedBox1.OtherFields.Add(OtherField4)
        Parameter3.ParameterName = "@statusid"
        Parameter3.ParameterValue = "0"
        Parameter4.ParameterName = "@iscustomer"
        Parameter4.ParameterValue = "1"
        Me.QueriedBox1.Parameters.Add(Parameter3)
        Me.QueriedBox1.Parameters.Add(Parameter4)
        Me.QueriedBox1.Prefix = Nothing
        Me.QueriedBox1.Size = New System.Drawing.Size(344, 23)
        Me.QueriedBox1.Suffix = Nothing
        Me.QueriedBox1.TabIndex = 28
        '
        'QbxCustomer
        '
        Me.QbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Condition5.FieldName = "statusid"
        Condition5.Operator = "="
        Condition5.TableNameOrAlias = "person"
        Condition5.Value = "@statusid"
        Condition6.FieldName = "iscustomer"
        Condition6.Operator = "="
        Condition6.TableNameOrAlias = "person"
        Condition6.Value = "@iscustomer"
        Me.QbxCustomer.Conditions.Add(Condition5)
        Me.QbxCustomer.Conditions.Add(Condition6)
        Me.QbxCustomer.DisplayFieldAlias = "Nome"
        Me.QbxCustomer.DisplayFieldName = "name"
        Me.QbxCustomer.DisplayMainFieldName = "id"
        Me.QbxCustomer.DisplayTableAlias = Nothing
        Me.QbxCustomer.DisplayTableName = "person"
        Me.QbxCustomer.Distinct = False
        Me.QbxCustomer.DropDownAutoStretchRight = False
        Me.QbxCustomer.DropDownStretchRight = 263
        Me.QbxCustomer.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCustomer.IfNull = Nothing
        Me.QbxCustomer.Location = New System.Drawing.Point(9, 84)
        Me.QbxCustomer.MainReturnFieldName = "id"
        Me.QbxCustomer.MainTableAlias = Nothing
        Me.QbxCustomer.MainTableName = "person"
        Me.QbxCustomer.Name = "QbxCustomer"
        OtherField5.DisplayFieldAlias = "Nome Curto"
        OtherField5.DisplayFieldName = "shortname"
        OtherField5.DisplayMainFieldName = "id"
        OtherField5.DisplayTableAlias = Nothing
        OtherField5.DisplayTableName = "person"
        OtherField5.Freeze = False
        OtherField5.IfNull = Nothing
        OtherField5.Prefix = Nothing
        OtherField5.Suffix = Nothing
        OtherField6.DisplayFieldAlias = "CPF/CNPJ"
        OtherField6.DisplayFieldName = "document"
        OtherField6.DisplayMainFieldName = "id"
        OtherField6.DisplayTableAlias = Nothing
        OtherField6.DisplayTableName = "person"
        OtherField6.Freeze = False
        OtherField6.IfNull = Nothing
        OtherField6.Prefix = Nothing
        OtherField6.Suffix = Nothing
        Me.QbxCustomer.OtherFields.Add(OtherField5)
        Me.QbxCustomer.OtherFields.Add(OtherField6)
        Parameter5.ParameterName = "@statusid"
        Parameter5.ParameterValue = "0"
        Parameter6.ParameterName = "@iscustomer"
        Parameter6.ParameterValue = "1"
        Me.QbxCustomer.Parameters.Add(Parameter5)
        Me.QbxCustomer.Parameters.Add(Parameter6)
        Me.QbxCustomer.Prefix = Nothing
        Me.QbxCustomer.Size = New System.Drawing.Size(344, 23)
        Me.QbxCustomer.Suffix = Nothing
        Me.QbxCustomer.TabIndex = 28
        '
        'LblEvaluationDate
        '
        Me.LblEvaluationDate.AutoSize = True
        Me.LblEvaluationDate.Location = New System.Drawing.Point(6, 19)
        Me.LblEvaluationDate.Name = "LblEvaluationDate"
        Me.LblEvaluationDate.Size = New System.Drawing.Size(74, 17)
        Me.LblEvaluationDate.TabIndex = 18
        Me.LblEvaluationDate.Text = "Dt. Venda"
        '
        'DbxEvaluationDate
        '
        Me.DbxEvaluationDate.ButtonImage = CType(resources.GetObject("DbxEvaluationDate.ButtonImage"), System.Drawing.Image)
        Me.DbxEvaluationDate.Location = New System.Drawing.Point(9, 39)
        Me.DbxEvaluationDate.Name = "DbxEvaluationDate"
        Me.DbxEvaluationDate.Size = New System.Drawing.Size(109, 23)
        Me.DbxEvaluationDate.TabIndex = 19
        '
        'TabItems
        '
        Me.TabItems.Controls.Add(Me.DgvItem)
        Me.TabItems.Controls.Add(Me.TsItem)
        Me.TabItems.Location = New System.Drawing.Point(4, 26)
        Me.TabItems.Name = "TabItems"
        Me.TabItems.Padding = New System.Windows.Forms.Padding(3)
        Me.TabItems.Size = New System.Drawing.Size(372, 221)
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
        Me.DgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvItem.Size = New System.Drawing.Size(366, 190)
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
        Me.TsItem.Size = New System.Drawing.Size(366, 25)
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
        Me.TabNote.Size = New System.Drawing.Size(372, 225)
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
        Me.TxtNote.Size = New System.Drawing.Size(366, 219)
        Me.TxtNote.TabIndex = 0
        Me.TxtNote.Text = ""
        '
        'TabDocument
        '
        Me.TabDocument.Controls.Add(Me.TsDocument)
        Me.TabDocument.Location = New System.Drawing.Point(4, 22)
        Me.TabDocument.Name = "TabDocument"
        Me.TabDocument.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDocument.Size = New System.Drawing.Size(372, 225)
        Me.TabDocument.TabIndex = 7
        Me.TabDocument.Text = "Documento"
        Me.TabDocument.UseVisualStyleBackColor = True
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
        Me.TsDocument.Size = New System.Drawing.Size(366, 25)
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
        Me.BtnSavePDF.Image = Global.Manager.My.Resources.Resources.Save
        Me.BtnSavePDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSavePDF.Name = "BtnSavePDF"
        Me.BtnSavePDF.Size = New System.Drawing.Size(23, 22)
        Me.BtnSavePDF.Text = "Salvar  Documento"
        '
        'BtnPrintPDF
        '
        Me.BtnPrintPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrintPDF.Image = Global.Manager.My.Resources.Resources.Print
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
        'TsValue
        '
        Me.TsValue.AutoSize = False
        Me.TsValue.BackColor = System.Drawing.Color.White
        Me.TsValue.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TsValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsValue.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsValue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblExpense, Me.ToolStripLabel17, Me.LblRefund, Me.ToolStripLabel15, Me.LblPrevious, Me.ToolStripLabel13})
        Me.TsValue.Location = New System.Drawing.Point(0, 301)
        Me.TsValue.Name = "TsValue"
        Me.TsValue.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsValue.Size = New System.Drawing.Size(380, 25)
        Me.TsValue.TabIndex = 9
        '
        'LblExpense
        '
        Me.LblExpense.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblExpense.BackColor = System.Drawing.Color.White
        Me.LblExpense.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExpense.Name = "LblExpense"
        Me.LblExpense.Size = New System.Drawing.Size(33, 22)
        Me.LblExpense.Text = "0,00"
        '
        'ToolStripLabel17
        '
        Me.ToolStripLabel17.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel17.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.ToolStripLabel17.Name = "ToolStripLabel17"
        Me.ToolStripLabel17.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripLabel17.Text = "À Pagar:"
        '
        'LblRefund
        '
        Me.LblRefund.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblRefund.BackColor = System.Drawing.Color.White
        Me.LblRefund.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefund.Name = "LblRefund"
        Me.LblRefund.Size = New System.Drawing.Size(33, 22)
        Me.LblRefund.Text = "0,00"
        '
        'ToolStripLabel15
        '
        Me.ToolStripLabel15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel15.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.ToolStripLabel15.Name = "ToolStripLabel15"
        Me.ToolStripLabel15.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripLabel15.Text = "Pago:"
        '
        'LblPrevious
        '
        Me.LblPrevious.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblPrevious.BackColor = System.Drawing.Color.White
        Me.LblPrevious.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrevious.Margin = New System.Windows.Forms.Padding(0, 1, 1, 2)
        Me.LblPrevious.Name = "LblPrevious"
        Me.LblPrevious.Size = New System.Drawing.Size(33, 22)
        Me.LblPrevious.Text = "0,00"
        '
        'ToolStripLabel13
        '
        Me.ToolStripLabel13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel13.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.ToolStripLabel13.Name = "ToolStripLabel13"
        Me.ToolStripLabel13.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel13.Text = "Comissão:"
        '
        'FrmComission
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(380, 370)
        Me.Controls.Add(Me.TcRequest)
        Me.Controls.Add(Me.TsValue)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmComission"
        Me.ShowIcon = False
        Me.Text = "Comissão"
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
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlpTechnician.ResumeLayout(False)
        Me.TabItems.ResumeLayout(False)
        Me.TabItems.PerformLayout()
        CType(Me.DgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsItem.ResumeLayout(False)
        Me.TsItem.PerformLayout()
        Me.TabNote.ResumeLayout(False)
        Me.TabDocument.ResumeLayout(False)
        Me.TsDocument.ResumeLayout(False)
        Me.TsDocument.PerformLayout()
        Me.TsValue.ResumeLayout(False)
        Me.TsValue.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
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
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents TcRequest As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabItems As TabPage
    Friend WithEvents DgvItem As DataGridView
    Friend WithEvents TsItem As ToolStrip
    Friend WithEvents BtnIncludeItem As ToolStripButton
    Friend WithEvents BtnEditItem As ToolStripButton
    Friend WithEvents BtnDeleteItem As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents TxtFilterItem As ToolStripTextBox
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents TabDocument As TabPage
    Friend WithEvents TsDocument As ToolStrip
    Friend WithEvents BtnAttachPDF As ToolStripButton
    Friend WithEvents BtnDeletePDF As ToolStripButton
    Friend WithEvents BtnSavePDF As ToolStripButton
    Friend WithEvents BtnPrintPDF As ToolStripButton
    Friend WithEvents BtnZoomIn As ToolStripButton
    Friend WithEvents BtnZoomOut As ToolStripButton
    Friend WithEvents LblDocumentPage As ToolStripLabel
    Friend WithEvents LblEvaluationDate As Label
    Friend WithEvents DbxEvaluationDate As ControlLibrary.DateBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblCustomer As Label
    Friend WithEvents QueriedBox2 As ControlLibrary.QueriedBox
    Friend WithEvents QueriedBox1 As ControlLibrary.QueriedBox
    Friend WithEvents QbxCustomer As ControlLibrary.QueriedBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TsValue As ToolStrip
    Friend WithEvents LblExpense As ToolStripLabel
    Friend WithEvents ToolStripLabel17 As ToolStripLabel
    Friend WithEvents LblRefund As ToolStripLabel
    Friend WithEvents ToolStripLabel15 As ToolStripLabel
    Friend WithEvents LblPrevious As ToolStripLabel
    Friend WithEvents ToolStripLabel13 As ToolStripLabel
    Friend WithEvents DbxHorimeter As ControlLibrary.DecimalBox
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents NoFocusCueButton4 As NoFocusCueButton
    Friend WithEvents NoFocusCueButton5 As NoFocusCueButton
    Friend WithEvents NoFocusCueButton6 As NoFocusCueButton
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents NoFocusCueButton1 As NoFocusCueButton
    Friend WithEvents NoFocusCueButton2 As NoFocusCueButton
    Friend WithEvents NoFocusCueButton3 As NoFocusCueButton
    Friend WithEvents FlpTechnician As FlowLayoutPanel
    Friend WithEvents BtnFilterTechnician As NoFocusCueButton
    Friend WithEvents BtnNewTechnician As NoFocusCueButton
    Friend WithEvents BtnViewTechnician As NoFocusCueButton
End Class
