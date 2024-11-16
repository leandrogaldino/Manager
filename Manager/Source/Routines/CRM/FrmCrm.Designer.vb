<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCrm))
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition3 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter3 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblPerson = New System.Windows.Forms.Label()
        Me.TsTreatment = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeTreatment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterTreatment = New System.Windows.Forms.ToolStripTextBox()
        Me.PnTreatment = New System.Windows.Forms.Panel()
        Me.WebTreatments = New System.Windows.Forms.WebBrowser()
        Me.LblResponsible = New System.Windows.Forms.Label()
        Me.LblSubject = New System.Windows.Forms.Label()
        Me.LblTreatment = New System.Windows.Forms.Label()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatusValue = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnPending = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnFinish = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnLost = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.FlpCustomer = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterCustomer = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCustomer = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewCustomer = New ControlLibrary.NoFocusCueButton()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.TmrQueriedBoxCustomer = New System.Windows.Forms.Timer(Me.components)
        Me.QbxResponsible = New ControlLibrary.QueriedBox()
        Me.QbxCustomer = New ControlLibrary.QueriedBox()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TmrLoadHtml = New System.Windows.Forms.Timer(Me.components)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TsTreatment.SuspendLayout()
        Me.PnTreatment.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        Me.FlpCustomer.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(369, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(470, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 657)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(574, 44)
        Me.Panel1.TabIndex = 11
        '
        'LblPerson
        '
        Me.LblPerson.AutoSize = True
        Me.LblPerson.Location = New System.Drawing.Point(9, 50)
        Me.LblPerson.Name = "LblPerson"
        Me.LblPerson.Size = New System.Drawing.Size(54, 17)
        Me.LblPerson.TabIndex = 2
        Me.LblPerson.Text = "Cliente"
        '
        'TsTreatment
        '
        Me.TsTreatment.AutoSize = False
        Me.TsTreatment.BackColor = System.Drawing.Color.Transparent
        Me.TsTreatment.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTreatment.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTreatment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeTreatment, Me.ToolStripLabel2, Me.TxtFilterTreatment})
        Me.TsTreatment.Location = New System.Drawing.Point(0, 0)
        Me.TsTreatment.Name = "TsTreatment"
        Me.TsTreatment.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTreatment.Size = New System.Drawing.Size(548, 30)
        Me.TsTreatment.TabIndex = 0
        Me.TsTreatment.Text = "ToolStrip2"
        '
        'BtnIncludeTreatment
        '
        Me.BtnIncludeTreatment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeTreatment.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeTreatment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeTreatment.Name = "BtnIncludeTreatment"
        Me.BtnIncludeTreatment.Size = New System.Drawing.Size(23, 27)
        Me.BtnIncludeTreatment.Text = "Incluir Atendimento"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(80, 0, 0, 0)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(46, 30)
        Me.ToolStripLabel2.Text = "Filtrar:"
        '
        'TxtFilterTreatment
        '
        Me.TxtFilterTreatment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterTreatment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterTreatment.Name = "TxtFilterTreatment"
        Me.TxtFilterTreatment.Size = New System.Drawing.Size(250, 30)
        '
        'PnTreatment
        '
        Me.PnTreatment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnTreatment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnTreatment.Controls.Add(Me.WebTreatments)
        Me.PnTreatment.Controls.Add(Me.TsTreatment)
        Me.PnTreatment.Location = New System.Drawing.Point(12, 208)
        Me.PnTreatment.Name = "PnTreatment"
        Me.PnTreatment.Size = New System.Drawing.Size(550, 443)
        Me.PnTreatment.TabIndex = 22
        '
        'WebTreatments
        '
        Me.WebTreatments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebTreatments.IsWebBrowserContextMenuEnabled = False
        Me.WebTreatments.Location = New System.Drawing.Point(0, 30)
        Me.WebTreatments.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebTreatments.Name = "WebTreatments"
        Me.WebTreatments.ScriptErrorsSuppressed = True
        Me.WebTreatments.Size = New System.Drawing.Size(548, 411)
        Me.WebTreatments.TabIndex = 1
        '
        'LblResponsible
        '
        Me.LblResponsible.AutoSize = True
        Me.LblResponsible.Location = New System.Drawing.Point(9, 96)
        Me.LblResponsible.Name = "LblResponsible"
        Me.LblResponsible.Size = New System.Drawing.Size(88, 17)
        Me.LblResponsible.TabIndex = 5
        Me.LblResponsible.Text = "Responsável"
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Location = New System.Drawing.Point(9, 142)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(57, 17)
        Me.LblSubject.TabIndex = 8
        Me.LblSubject.Text = "Assunto"
        '
        'LblTreatment
        '
        Me.LblTreatment.AutoSize = True
        Me.LblTreatment.Location = New System.Drawing.Point(9, 188)
        Me.LblTreatment.Name = "LblTreatment"
        Me.LblTreatment.Size = New System.Drawing.Size(169, 17)
        Me.LblTreatment.TabIndex = 10
        Me.LblTreatment.Text = "Registro de Atendimento"
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
        Me.TsTitle.Size = New System.Drawing.Size(574, 25)
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
        Me.LblStatusValue.Image = CType(resources.GetObject("LblStatusValue.Image"), System.Drawing.Image)
        Me.LblStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblStatusValue.Name = "LblStatusValue"
        Me.LblStatusValue.Size = New System.Drawing.Size(40, 22)
        Me.LblStatusValue.Text = "        "
        '
        'BtnStatusValue
        '
        Me.BtnStatusValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnStatusValue.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPending, Me.BtnFinish, Me.BtnLost})
        Me.BtnStatusValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnStatusValue.Image = CType(resources.GetObject("BtnStatusValue.Image"), System.Drawing.Image)
        Me.BtnStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnStatusValue.Name = "BtnStatusValue"
        Me.BtnStatusValue.Size = New System.Drawing.Size(53, 22)
        Me.BtnStatusValue.Text = "        "
        '
        'BtnPending
        '
        Me.BtnPending.Image = Global.Manager.My.Resources.Resources.Pending
        Me.BtnPending.Name = "BtnPending"
        Me.BtnPending.Size = New System.Drawing.Size(140, 22)
        Me.BtnPending.Text = "Pendente"
        '
        'BtnFinish
        '
        Me.BtnFinish.Image = Global.Manager.My.Resources.Resources.Approve
        Me.BtnFinish.Name = "BtnFinish"
        Me.BtnFinish.Size = New System.Drawing.Size(140, 22)
        Me.BtnFinish.Text = "Realizado"
        '
        'BtnLost
        '
        Me.BtnLost.Image = Global.Manager.My.Resources.Resources.Reject
        Me.BtnLost.Name = "BtnLost"
        Me.BtnLost.Size = New System.Drawing.Size(140, 22)
        Me.BtnLost.Text = "Perdido"
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
        Me.TsNavigation.Size = New System.Drawing.Size(574, 25)
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
        Me.BtnInclude.Text = "Incluir CRM"
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
        Me.BtnDelete.Text = "Excluir CRM"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro CRM"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "CRM Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo CRM"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último CRM"
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
        'FlpCustomer
        '
        Me.FlpCustomer.Controls.Add(Me.BtnFilterCustomer)
        Me.FlpCustomer.Controls.Add(Me.BtnViewCustomer)
        Me.FlpCustomer.Controls.Add(Me.BtnNewCustomer)
        Me.FlpCustomer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCustomer.Location = New System.Drawing.Point(480, 49)
        Me.FlpCustomer.Name = "FlpCustomer"
        Me.FlpCustomer.Size = New System.Drawing.Size(69, 21)
        Me.FlpCustomer.TabIndex = 4
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
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'TxtSubject
        '
        Me.TxtSubject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSubject.Location = New System.Drawing.Point(12, 162)
        Me.TxtSubject.MaxLength = 100
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(537, 23)
        Me.TxtSubject.TabIndex = 9
        '
        'TmrQueriedBoxCustomer
        '
        Me.TmrQueriedBoxCustomer.Enabled = True
        Me.TmrQueriedBoxCustomer.Interval = 300
        '
        'QbxResponsible
        '
        Me.QbxResponsible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxResponsible.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "user"
        Condition1.Value = "@statusid"
        Me.QbxResponsible.Conditions.Add(Condition1)
        Me.QbxResponsible.DebugOnTextChanged = False
        Me.QbxResponsible.DisplayFieldAlias = "Nome Curto"
        Me.QbxResponsible.DisplayFieldName = "shortname"
        Me.QbxResponsible.DisplayMainFieldName = "id"
        Me.QbxResponsible.DisplayTableAlias = Nothing
        Me.QbxResponsible.DisplayTableName = "person"
        Me.QbxResponsible.Distinct = False
        Me.QbxResponsible.DropDownAutoStretchRight = False
        Me.QbxResponsible.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxResponsible.IfNull = Nothing
        Me.QbxResponsible.Location = New System.Drawing.Point(12, 116)
        Me.QbxResponsible.MainReturnFieldName = "id"
        Me.QbxResponsible.MainTableAlias = Nothing
        Me.QbxResponsible.MainTableName = "person"
        Me.QbxResponsible.Name = "QbxResponsible"
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Me.QbxResponsible.Parameters.Add(Parameter1)
        Me.QbxResponsible.Prefix = Nothing
        Relation1.Operator = "="
        Relation1.RelateFieldName = "personid"
        Relation1.RelateTableAlias = ""
        Relation1.RelateTableName = "user"
        Relation1.RelationType = "INNER"
        Relation1.WithFieldName = "id"
        Relation1.WithTableAlias = ""
        Relation1.WithTableName = "person"
        Me.QbxResponsible.Relations.Add(Relation1)
        Me.QbxResponsible.Size = New System.Drawing.Size(537, 23)
        Me.QbxResponsible.Suffix = Nothing
        Me.QbxResponsible.TabIndex = 6
        '
        'QbxCustomer
        '
        Me.QbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCustomer.CharactersToQuery = 1
        Condition2.FieldName = "statusid"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@statusid"
        Condition3.FieldName = "iscustomer"
        Condition3.Operator = "="
        Condition3.TableNameOrAlias = "person"
        Condition3.Value = "@iscustomer"
        Me.QbxCustomer.Conditions.Add(Condition2)
        Me.QbxCustomer.Conditions.Add(Condition3)
        Me.QbxCustomer.DebugOnTextChanged = False
        Me.QbxCustomer.DisplayFieldAlias = "Nome Curto"
        Me.QbxCustomer.DisplayFieldName = "shortname"
        Me.QbxCustomer.DisplayMainFieldName = "id"
        Me.QbxCustomer.DisplayTableAlias = Nothing
        Me.QbxCustomer.DisplayTableName = "person"
        Me.QbxCustomer.Distinct = False
        Me.QbxCustomer.DropDownAutoStretchRight = False
        Me.QbxCustomer.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCustomer.IfNull = Nothing
        Me.QbxCustomer.Location = New System.Drawing.Point(12, 70)
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
        OtherField2.DisplayFieldAlias = "CPF/CNPJ"
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        Me.QbxCustomer.OtherFields.Add(OtherField1)
        Me.QbxCustomer.OtherFields.Add(OtherField2)
        Parameter2.ParameterName = "@statusid"
        Parameter2.ParameterValue = "0"
        Parameter3.ParameterName = "@iscustomer"
        Parameter3.ParameterValue = "1"
        Me.QbxCustomer.Parameters.Add(Parameter2)
        Me.QbxCustomer.Parameters.Add(Parameter3)
        Me.QbxCustomer.Prefix = Nothing
        Me.QbxCustomer.Size = New System.Drawing.Size(537, 23)
        Me.QbxCustomer.Suffix = Nothing
        Me.QbxCustomer.TabIndex = 3
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Nothing
        Me.DgvNavigator.LastButton = Nothing
        Me.DgvNavigator.NextButton = Nothing
        Me.DgvNavigator.PreviousButton = Nothing
        '
        'TmrLoadHtml
        '
        Me.TmrLoadHtml.Enabled = True
        Me.TmrLoadHtml.Interval = 300
        '
        'FrmCrm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 701)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.FlpCustomer)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.QbxResponsible)
        Me.Controls.Add(Me.QbxCustomer)
        Me.Controls.Add(Me.LblTreatment)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.LblResponsible)
        Me.Controls.Add(Me.LblPerson)
        Me.Controls.Add(Me.PnTreatment)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCrm"
        Me.ShowIcon = False
        Me.Text = "CRM"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TsTreatment.ResumeLayout(False)
        Me.TsTreatment.PerformLayout()
        Me.PnTreatment.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        Me.FlpCustomer.ResumeLayout(False)
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents QbxResponsible As ControlLibrary.QueriedBox
    Friend WithEvents QbxCustomer As ControlLibrary.QueriedBox
    Friend WithEvents LblTreatment As Label
    Friend WithEvents LblSubject As Label
    Friend WithEvents LblResponsible As Label
    Friend WithEvents LblPerson As Label
    Friend WithEvents PnTreatment As Panel
    Friend WithEvents TsTreatment As ToolStrip
    Friend WithEvents BtnIncludeTreatment As ToolStripButton
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents LblCreationDate As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents FlpCustomer As FlowLayoutPanel
    Friend WithEvents BtnFilterCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNewCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents TmrQueriedBoxCustomer As Timer
    Friend WithEvents BtnStatusValue As ToolStripDropDownButton
    Friend WithEvents BtnFinish As ToolStripMenuItem
    Friend WithEvents BtnLost As ToolStripMenuItem
    Friend WithEvents LblStatusValue As ToolStripLabel
    Friend WithEvents WebTreatments As WebBrowser
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TxtFilterTreatment As ToolStripTextBox
    Friend WithEvents TmrLoadHtml As Timer
    Friend WithEvents BtnPending As ToolStripMenuItem
    Friend WithEvents BtnDelete As ToolStripButton
End Class
