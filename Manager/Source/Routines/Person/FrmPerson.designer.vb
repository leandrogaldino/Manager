<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPerson
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPerson))
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabNote = New System.Windows.Forms.TabPage()
        Me.TxtNote = New System.Windows.Forms.RichTextBox()
        Me.TabCompressor = New System.Windows.Forms.TabPage()
        Me.DgvCompressor = New System.Windows.Forms.DataGridView()
        Me.TsCompressor = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCompressor = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCompressor = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCompressor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterCompressor = New System.Windows.Forms.ToolStripTextBox()
        Me.TabContact = New System.Windows.Forms.TabPage()
        Me.DgvContact = New System.Windows.Forms.DataGridView()
        Me.TsContact = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeContact = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditContact = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteContact = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterContact = New System.Windows.Forms.ToolStripTextBox()
        Me.TabAddress = New System.Windows.Forms.TabPage()
        Me.DgvAddress = New System.Windows.Forms.DataGridView()
        Me.TsAddress = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeAddress = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditAddress = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteAddress = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterAddress = New System.Windows.Forms.ToolStripTextBox()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.TxtShortName = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtDocument = New System.Windows.Forms.TextBox()
        Me.RbtIsNaturalEntity = New System.Windows.Forms.RadioButton()
        Me.LblShortName = New System.Windows.Forms.Label()
        Me.BtnDocument = New ControlLibrary.NoFocusCueButton()
        Me.CbxIsTechnician = New System.Windows.Forms.CheckBox()
        Me.CbxIsCarrier = New System.Windows.Forms.CheckBox()
        Me.RbtIsLegalEntity = New System.Windows.Forms.RadioButton()
        Me.CbxIsEmployee = New System.Windows.Forms.CheckBox()
        Me.CbxIsCustomer = New System.Windows.Forms.CheckBox()
        Me.LblDocument = New System.Windows.Forms.Label()
        Me.CbxIsProvider = New System.Windows.Forms.CheckBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TcPerson = New System.Windows.Forms.TabControl()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvCompressorLayout = New Manager.DataGridViewLayout()
        Me.DgvAddressLayout = New Manager.DataGridViewLayout()
        Me.DgvContactLayout = New Manager.DataGridViewLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNote.SuspendLayout()
        Me.TabCompressor.SuspendLayout()
        CType(Me.DgvCompressor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsCompressor.SuspendLayout()
        Me.TabContact.SuspendLayout()
        CType(Me.DgvContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsContact.SuspendLayout()
        Me.TabAddress.SuspendLayout()
        CType(Me.DgvAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsAddress.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TcPerson.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(530, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(429, 7)
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
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(637, 25)
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
        'LblCreation
        '
        Me.LblCreation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreation.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.LblCreation.Name = "LblCreation"
        Me.LblCreation.Size = New System.Drawing.Size(64, 22)
        Me.LblCreation.Text = "Criação:"
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
        Me.TsNavigation.Size = New System.Drawing.Size(637, 25)
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
        Me.BtnInclude.Text = "Incluir Pessoa"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Pessoa"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Pessoa"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Pessoa Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Pessoa"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Pessoa"
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
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.White
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 187)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(637, 44)
        Me.PnButtons.TabIndex = 3
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TabNote
        '
        Me.TabNote.Controls.Add(Me.TxtNote)
        Me.TabNote.Location = New System.Drawing.Point(4, 22)
        Me.TabNote.Name = "TabNote"
        Me.TabNote.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNote.Size = New System.Drawing.Size(629, 111)
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
        Me.TxtNote.Size = New System.Drawing.Size(623, 105)
        Me.TxtNote.TabIndex = 0
        Me.TxtNote.Text = ""
        '
        'TabCompressor
        '
        Me.TabCompressor.Controls.Add(Me.DgvCompressor)
        Me.TabCompressor.Controls.Add(Me.TsCompressor)
        Me.TabCompressor.Location = New System.Drawing.Point(4, 26)
        Me.TabCompressor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabCompressor.Name = "TabCompressor"
        Me.TabCompressor.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabCompressor.Size = New System.Drawing.Size(629, 107)
        Me.TabCompressor.TabIndex = 1
        Me.TabCompressor.Text = "Compressores"
        Me.TabCompressor.UseVisualStyleBackColor = True
        '
        'DgvCompressor
        '
        Me.DgvCompressor.AllowUserToAddRows = False
        Me.DgvCompressor.AllowUserToDeleteRows = False
        Me.DgvCompressor.AllowUserToOrderColumns = True
        Me.DgvCompressor.AllowUserToResizeRows = False
        Me.DgvCompressor.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvCompressor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCompressor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCompressor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCompressor.Location = New System.Drawing.Point(3, 29)
        Me.DgvCompressor.MultiSelect = False
        Me.DgvCompressor.Name = "DgvCompressor"
        Me.DgvCompressor.ReadOnly = True
        Me.DgvCompressor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvCompressor.RowHeadersVisible = False
        Me.DgvCompressor.RowTemplate.Height = 26
        Me.DgvCompressor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCompressor.Size = New System.Drawing.Size(623, 74)
        Me.DgvCompressor.TabIndex = 1
        '
        'TsCompressor
        '
        Me.TsCompressor.BackColor = System.Drawing.Color.Transparent
        Me.TsCompressor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsCompressor.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsCompressor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCompressor, Me.BtnEditCompressor, Me.BtnDeleteCompressor, Me.ToolStripLabel1, Me.TxtFilterCompressor})
        Me.TsCompressor.Location = New System.Drawing.Point(3, 4)
        Me.TsCompressor.Name = "TsCompressor"
        Me.TsCompressor.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsCompressor.Size = New System.Drawing.Size(623, 25)
        Me.TsCompressor.TabIndex = 0
        Me.TsCompressor.Text = "ToolStrip2"
        '
        'BtnIncludeCompressor
        '
        Me.BtnIncludeCompressor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeCompressor.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeCompressor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeCompressor.Name = "BtnIncludeCompressor"
        Me.BtnIncludeCompressor.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeCompressor.Text = "Incluir Compressor"
        '
        'BtnEditCompressor
        '
        Me.BtnEditCompressor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditCompressor.Enabled = False
        Me.BtnEditCompressor.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditCompressor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditCompressor.Name = "BtnEditCompressor"
        Me.BtnEditCompressor.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditCompressor.Text = "Editar Compressor"
        Me.BtnEditCompressor.ToolTipText = "Editar"
        '
        'BtnDeleteCompressor
        '
        Me.BtnDeleteCompressor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteCompressor.Enabled = False
        Me.BtnDeleteCompressor.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteCompressor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteCompressor.Name = "BtnDeleteCompressor"
        Me.BtnDeleteCompressor.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteCompressor.Text = "Excluir Compressor"
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
        'TxtFilterCompressor
        '
        Me.TxtFilterCompressor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterCompressor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterCompressor.Name = "TxtFilterCompressor"
        Me.TxtFilterCompressor.Size = New System.Drawing.Size(200, 25)
        '
        'TabContact
        '
        Me.TabContact.Controls.Add(Me.DgvContact)
        Me.TabContact.Controls.Add(Me.TsContact)
        Me.TabContact.Location = New System.Drawing.Point(4, 22)
        Me.TabContact.Name = "TabContact"
        Me.TabContact.Padding = New System.Windows.Forms.Padding(3)
        Me.TabContact.Size = New System.Drawing.Size(629, 111)
        Me.TabContact.TabIndex = 7
        Me.TabContact.Text = "Contatos"
        Me.TabContact.UseVisualStyleBackColor = True
        '
        'DgvContact
        '
        Me.DgvContact.AllowUserToAddRows = False
        Me.DgvContact.AllowUserToDeleteRows = False
        Me.DgvContact.AllowUserToOrderColumns = True
        Me.DgvContact.AllowUserToResizeRows = False
        Me.DgvContact.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvContact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvContact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvContact.Location = New System.Drawing.Point(3, 28)
        Me.DgvContact.MultiSelect = False
        Me.DgvContact.Name = "DgvContact"
        Me.DgvContact.ReadOnly = True
        Me.DgvContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvContact.RowHeadersVisible = False
        Me.DgvContact.RowTemplate.Height = 26
        Me.DgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvContact.Size = New System.Drawing.Size(623, 80)
        Me.DgvContact.TabIndex = 1
        '
        'TsContact
        '
        Me.TsContact.BackColor = System.Drawing.Color.Transparent
        Me.TsContact.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsContact.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsContact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeContact, Me.BtnEditContact, Me.BtnDeleteContact, Me.ToolStripLabel2, Me.TxtFilterContact})
        Me.TsContact.Location = New System.Drawing.Point(3, 3)
        Me.TsContact.Name = "TsContact"
        Me.TsContact.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsContact.Size = New System.Drawing.Size(623, 25)
        Me.TsContact.TabIndex = 0
        Me.TsContact.Text = "ToolStrip2"
        '
        'BtnIncludeContact
        '
        Me.BtnIncludeContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeContact.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeContact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeContact.Name = "BtnIncludeContact"
        Me.BtnIncludeContact.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeContact.Text = "Incluir Contato"
        '
        'BtnEditContact
        '
        Me.BtnEditContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditContact.Enabled = False
        Me.BtnEditContact.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditContact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditContact.Name = "BtnEditContact"
        Me.BtnEditContact.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditContact.Text = "Editar Contato"
        Me.BtnEditContact.ToolTipText = "Editar"
        '
        'BtnDeleteContact
        '
        Me.BtnDeleteContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteContact.Enabled = False
        Me.BtnDeleteContact.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteContact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteContact.Name = "BtnDeleteContact"
        Me.BtnDeleteContact.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteContact.Text = "Excluir Contato"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(46, 25)
        Me.ToolStripLabel2.Text = "Filtrar:"
        '
        'TxtFilterContact
        '
        Me.TxtFilterContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterContact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterContact.Name = "TxtFilterContact"
        Me.TxtFilterContact.Size = New System.Drawing.Size(200, 25)
        '
        'TabAddress
        '
        Me.TabAddress.Controls.Add(Me.DgvAddress)
        Me.TabAddress.Controls.Add(Me.TsAddress)
        Me.TabAddress.Location = New System.Drawing.Point(4, 22)
        Me.TabAddress.Name = "TabAddress"
        Me.TabAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAddress.Size = New System.Drawing.Size(629, 111)
        Me.TabAddress.TabIndex = 6
        Me.TabAddress.Text = "Endereços"
        Me.TabAddress.UseVisualStyleBackColor = True
        '
        'DgvAddress
        '
        Me.DgvAddress.AllowUserToAddRows = False
        Me.DgvAddress.AllowUserToDeleteRows = False
        Me.DgvAddress.AllowUserToOrderColumns = True
        Me.DgvAddress.AllowUserToResizeRows = False
        Me.DgvAddress.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAddress.Location = New System.Drawing.Point(3, 28)
        Me.DgvAddress.MultiSelect = False
        Me.DgvAddress.Name = "DgvAddress"
        Me.DgvAddress.ReadOnly = True
        Me.DgvAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvAddress.RowHeadersVisible = False
        Me.DgvAddress.RowTemplate.Height = 26
        Me.DgvAddress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAddress.Size = New System.Drawing.Size(623, 80)
        Me.DgvAddress.TabIndex = 3
        '
        'TsAddress
        '
        Me.TsAddress.BackColor = System.Drawing.Color.Transparent
        Me.TsAddress.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsAddress.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsAddress.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeAddress, Me.BtnEditAddress, Me.BtnDeleteAddress, Me.ToolStripLabel3, Me.TxtFilterAddress})
        Me.TsAddress.Location = New System.Drawing.Point(3, 3)
        Me.TsAddress.Name = "TsAddress"
        Me.TsAddress.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsAddress.Size = New System.Drawing.Size(623, 25)
        Me.TsAddress.TabIndex = 2
        Me.TsAddress.Text = "ToolStrip2"
        '
        'BtnIncludeAddress
        '
        Me.BtnIncludeAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeAddress.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeAddress.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeAddress.Name = "BtnIncludeAddress"
        Me.BtnIncludeAddress.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeAddress.Text = "Incluir Endereço"
        '
        'BtnEditAddress
        '
        Me.BtnEditAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditAddress.Enabled = False
        Me.BtnEditAddress.Image = CType(resources.GetObject("BtnEditAddress.Image"), System.Drawing.Image)
        Me.BtnEditAddress.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditAddress.Name = "BtnEditAddress"
        Me.BtnEditAddress.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditAddress.Text = "Editar Endereço"
        Me.BtnEditAddress.ToolTipText = "Editar"
        '
        'BtnDeleteAddress
        '
        Me.BtnDeleteAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteAddress.Enabled = False
        Me.BtnDeleteAddress.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteAddress.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteAddress.Name = "BtnDeleteAddress"
        Me.BtnDeleteAddress.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteAddress.Text = "Excluir Endereço"
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
        'TxtFilterAddress
        '
        Me.TxtFilterAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterAddress.Name = "TxtFilterAddress"
        Me.TxtFilterAddress.Size = New System.Drawing.Size(200, 25)
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TxtShortName)
        Me.TabMain.Controls.Add(Me.TxtName)
        Me.TabMain.Controls.Add(Me.TxtDocument)
        Me.TabMain.Controls.Add(Me.RbtIsNaturalEntity)
        Me.TabMain.Controls.Add(Me.LblShortName)
        Me.TabMain.Controls.Add(Me.BtnDocument)
        Me.TabMain.Controls.Add(Me.CbxIsTechnician)
        Me.TabMain.Controls.Add(Me.CbxIsCarrier)
        Me.TabMain.Controls.Add(Me.RbtIsLegalEntity)
        Me.TabMain.Controls.Add(Me.CbxIsEmployee)
        Me.TabMain.Controls.Add(Me.CbxIsCustomer)
        Me.TabMain.Controls.Add(Me.LblDocument)
        Me.TabMain.Controls.Add(Me.CbxIsProvider)
        Me.TabMain.Controls.Add(Me.LblName)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(629, 107)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'TxtShortName
        '
        Me.TxtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtShortName.Location = New System.Drawing.Point(454, 78)
        Me.TxtShortName.MaxLength = 50
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(169, 23)
        Me.TxtShortName.TabIndex = 14
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(148, 78)
        Me.TxtName.MaxLength = 255
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(300, 23)
        Me.TxtName.TabIndex = 12
        '
        'TxtDocument
        '
        Me.TxtDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocument.Location = New System.Drawing.Point(6, 78)
        Me.TxtDocument.Name = "TxtDocument"
        Me.TxtDocument.Size = New System.Drawing.Size(136, 23)
        Me.TxtDocument.TabIndex = 9
        Me.TxtDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RbtIsNaturalEntity
        '
        Me.RbtIsNaturalEntity.AutoSize = True
        Me.RbtIsNaturalEntity.Location = New System.Drawing.Point(6, 7)
        Me.RbtIsNaturalEntity.Name = "RbtIsNaturalEntity"
        Me.RbtIsNaturalEntity.Size = New System.Drawing.Size(108, 21)
        Me.RbtIsNaturalEntity.TabIndex = 0
        Me.RbtIsNaturalEntity.Text = "Pessoa Física"
        Me.RbtIsNaturalEntity.UseVisualStyleBackColor = True
        '
        'LblShortName
        '
        Me.LblShortName.AutoSize = True
        Me.LblShortName.Location = New System.Drawing.Point(451, 58)
        Me.LblShortName.Name = "LblShortName"
        Me.LblShortName.Size = New System.Drawing.Size(89, 17)
        Me.LblShortName.TabIndex = 13
        Me.LblShortName.Text = "Nome Curto"
        '
        'BtnDocument
        '
        Me.BtnDocument.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnDocument.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDocument.Enabled = False
        Me.BtnDocument.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnDocument.FlatAppearance.BorderSize = 0
        Me.BtnDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDocument.Location = New System.Drawing.Point(119, 55)
        Me.BtnDocument.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.BtnDocument.Name = "BtnDocument"
        Me.BtnDocument.Size = New System.Drawing.Size(23, 23)
        Me.BtnDocument.TabIndex = 10
        Me.BtnDocument.TooltipText = ""
        Me.BtnDocument.UseVisualStyleBackColor = True
        '
        'CbxIsTechnician
        '
        Me.CbxIsTechnician.AutoSize = True
        Me.CbxIsTechnician.Location = New System.Drawing.Point(299, 34)
        Me.CbxIsTechnician.Name = "CbxIsTechnician"
        Me.CbxIsTechnician.Size = New System.Drawing.Size(76, 21)
        Me.CbxIsTechnician.TabIndex = 6
        Me.CbxIsTechnician.Text = "Técnico"
        Me.CbxIsTechnician.UseVisualStyleBackColor = True
        '
        'CbxIsCarrier
        '
        Me.CbxIsCarrier.AutoSize = True
        Me.CbxIsCarrier.Location = New System.Drawing.Point(381, 34)
        Me.CbxIsCarrier.Name = "CbxIsCarrier"
        Me.CbxIsCarrier.Size = New System.Drawing.Size(125, 21)
        Me.CbxIsCarrier.TabIndex = 7
        Me.CbxIsCarrier.Text = "Transportadora"
        Me.CbxIsCarrier.UseVisualStyleBackColor = True
        '
        'RbtIsLegalEntity
        '
        Me.RbtIsLegalEntity.AutoSize = True
        Me.RbtIsLegalEntity.Checked = True
        Me.RbtIsLegalEntity.Location = New System.Drawing.Point(120, 7)
        Me.RbtIsLegalEntity.Name = "RbtIsLegalEntity"
        Me.RbtIsLegalEntity.Size = New System.Drawing.Size(124, 21)
        Me.RbtIsLegalEntity.TabIndex = 1
        Me.RbtIsLegalEntity.TabStop = True
        Me.RbtIsLegalEntity.Text = "Pessoa Jurídica"
        Me.RbtIsLegalEntity.UseVisualStyleBackColor = True
        '
        'CbxIsEmployee
        '
        Me.CbxIsEmployee.AutoSize = True
        Me.CbxIsEmployee.Location = New System.Drawing.Point(191, 34)
        Me.CbxIsEmployee.Name = "CbxIsEmployee"
        Me.CbxIsEmployee.Size = New System.Drawing.Size(102, 21)
        Me.CbxIsEmployee.TabIndex = 5
        Me.CbxIsEmployee.Text = "Funcionário"
        Me.CbxIsEmployee.UseVisualStyleBackColor = True
        '
        'CbxIsCustomer
        '
        Me.CbxIsCustomer.AutoSize = True
        Me.CbxIsCustomer.Location = New System.Drawing.Point(6, 34)
        Me.CbxIsCustomer.Name = "CbxIsCustomer"
        Me.CbxIsCustomer.Size = New System.Drawing.Size(73, 21)
        Me.CbxIsCustomer.TabIndex = 3
        Me.CbxIsCustomer.Text = "Cliente"
        Me.CbxIsCustomer.UseVisualStyleBackColor = True
        '
        'LblDocument
        '
        Me.LblDocument.AutoSize = True
        Me.LblDocument.Location = New System.Drawing.Point(3, 58)
        Me.LblDocument.Name = "LblDocument"
        Me.LblDocument.Size = New System.Drawing.Size(43, 17)
        Me.LblDocument.TabIndex = 8
        Me.LblDocument.Text = "CNPJ"
        '
        'CbxIsProvider
        '
        Me.CbxIsProvider.AutoSize = True
        Me.CbxIsProvider.Location = New System.Drawing.Point(85, 34)
        Me.CbxIsProvider.Name = "CbxIsProvider"
        Me.CbxIsProvider.Size = New System.Drawing.Size(100, 21)
        Me.CbxIsProvider.TabIndex = 4
        Me.CbxIsProvider.Text = "Fornecedor"
        Me.CbxIsProvider.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(145, 58)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 11
        Me.LblName.Text = "Nome"
        '
        'TcPerson
        '
        Me.TcPerson.Controls.Add(Me.TabMain)
        Me.TcPerson.Controls.Add(Me.TabAddress)
        Me.TcPerson.Controls.Add(Me.TabContact)
        Me.TcPerson.Controls.Add(Me.TabCompressor)
        Me.TcPerson.Controls.Add(Me.TabNote)
        Me.TcPerson.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcPerson.Location = New System.Drawing.Point(0, 50)
        Me.TcPerson.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcPerson.Multiline = True
        Me.TcPerson.Name = "TcPerson"
        Me.TcPerson.SelectedIndex = 0
        Me.TcPerson.Size = New System.Drawing.Size(637, 137)
        Me.TcPerson.TabIndex = 2
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
        'DgvCompressorLayout
        '
        Me.DgvCompressorLayout.DataGridView = Me.DgvCompressor
        Me.DgvCompressorLayout.Routine = Manager.Routine.PersonCompressor
        '
        'DgvAddressLayout
        '
        Me.DgvAddressLayout.DataGridView = Me.DgvAddress
        Me.DgvAddressLayout.Routine = Manager.Routine.PersonAddress
        '
        'DgvContactLayout
        '
        Me.DgvContactLayout.DataGridView = Me.DgvContact
        Me.DgvContactLayout.Routine = Manager.Routine.PersonContact
        '
        'FrmPerson
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(637, 231)
        Me.Controls.Add(Me.TcPerson)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPerson"
        Me.ShowIcon = False
        Me.Text = "Pessoa"
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNote.ResumeLayout(False)
        Me.TabCompressor.ResumeLayout(False)
        Me.TabCompressor.PerformLayout()
        CType(Me.DgvCompressor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsCompressor.ResumeLayout(False)
        Me.TsCompressor.PerformLayout()
        Me.TabContact.ResumeLayout(False)
        Me.TabContact.PerformLayout()
        CType(Me.DgvContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsContact.ResumeLayout(False)
        Me.TsContact.PerformLayout()
        Me.TabAddress.ResumeLayout(False)
        Me.TabAddress.PerformLayout()
        CType(Me.DgvAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsAddress.ResumeLayout(False)
        Me.TsAddress.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.TcPerson.ResumeLayout(False)
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents PnButtons As Panel
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents TcPerson As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TxtShortName As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents TxtDocument As TextBox
    Friend WithEvents RbtIsNaturalEntity As RadioButton
    Friend WithEvents LblShortName As Label
    Friend WithEvents BtnDocument As ControlLibrary.NoFocusCueButton
    Friend WithEvents CbxIsCarrier As CheckBox
    Friend WithEvents RbtIsLegalEntity As RadioButton
    Friend WithEvents CbxIsEmployee As CheckBox
    Friend WithEvents CbxIsCustomer As CheckBox
    Friend WithEvents LblDocument As Label
    Friend WithEvents CbxIsProvider As CheckBox
    Friend WithEvents LblName As Label
    Friend WithEvents TabAddress As TabPage
    Friend WithEvents TabContact As TabPage
    Friend WithEvents DgvContact As DataGridView
    Friend WithEvents TsContact As ToolStrip
    Friend WithEvents BtnIncludeContact As ToolStripButton
    Friend WithEvents BtnEditContact As ToolStripButton
    Friend WithEvents BtnDeleteContact As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TxtFilterContact As ToolStripTextBox
    Friend WithEvents TabCompressor As TabPage
    Friend WithEvents DgvCompressor As DataGridView
    Friend WithEvents TsCompressor As ToolStrip
    Friend WithEvents BtnIncludeCompressor As ToolStripButton
    Friend WithEvents BtnEditCompressor As ToolStripButton
    Friend WithEvents BtnDeleteCompressor As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TxtFilterCompressor As ToolStripTextBox
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents DgvCompressorLayout As DataGridViewLayout
    Friend WithEvents DgvAddress As DataGridView
    Friend WithEvents TsAddress As ToolStrip
    Friend WithEvents BtnIncludeAddress As ToolStripButton
    Friend WithEvents BtnEditAddress As ToolStripButton
    Friend WithEvents BtnDeleteAddress As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents TxtFilterAddress As ToolStripTextBox
    Friend WithEvents DgvAddressLayout As DataGridViewLayout
    Friend WithEvents DgvContactLayout As DataGridViewLayout
    Friend WithEvents CbxIsTechnician As CheckBox
    Friend WithEvents EprInformation As ErrorProvider
End Class
