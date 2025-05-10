<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmService
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
        Me.TabPrice = New System.Windows.Forms.TabPage()
        Me.DgvPrice = New System.Windows.Forms.DataGridView()
        Me.TsPrice = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludePrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditPrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePrice = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterPrice = New System.Windows.Forms.ToolStripTextBox()
        Me.TabDescription = New System.Windows.Forms.TabPage()
        Me.DgvComplement = New System.Windows.Forms.DataGridView()
        Me.TsCode = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterDescription = New System.Windows.Forms.ToolStripTextBox()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtServiceCode = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TcProduct = New System.Windows.Forms.TabControl()
        Me.TmrQueriedBoxFamily = New System.Windows.Forms.Timer(Me.components)
        Me.TmrQueriedBoxGroup = New System.Windows.Forms.Timer(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.DgvProviderCodeLayout = New Manager.DataGridViewLayout()
        Me.DgvCodeLayout = New Manager.DataGridViewLayout()
        Me.DgvPriceLayout = New Manager.DataGridViewLayout()
        Me.DgvPictureLayout = New Manager.DataGridViewLayout()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNote.SuspendLayout()
        Me.TabPrice.SuspendLayout()
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsPrice.SuspendLayout()
        Me.TabDescription.SuspendLayout()
        CType(Me.DgvComplement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsCode.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TcProduct.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(376, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(275, 7)
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
        Me.TsTitle.Size = New System.Drawing.Size(483, 25)
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
        Me.TsNavigation.Size = New System.Drawing.Size(483, 25)
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
        Me.BtnInclude.Text = "Incluir Produto"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Produto"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Produto"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Produto Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Produto"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Produto"
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
        Me.PnButtons.Location = New System.Drawing.Point(0, 139)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(483, 44)
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
        Me.TabNote.Size = New System.Drawing.Size(475, 63)
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
        Me.TxtNote.Size = New System.Drawing.Size(469, 57)
        Me.TxtNote.TabIndex = 0
        Me.TxtNote.Text = ""
        '
        'TabPrice
        '
        Me.TabPrice.Controls.Add(Me.DgvPrice)
        Me.TabPrice.Controls.Add(Me.TsPrice)
        Me.TabPrice.Location = New System.Drawing.Point(4, 22)
        Me.TabPrice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPrice.Name = "TabPrice"
        Me.TabPrice.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPrice.Size = New System.Drawing.Size(475, 63)
        Me.TabPrice.TabIndex = 1
        Me.TabPrice.Text = "Preços"
        Me.TabPrice.UseVisualStyleBackColor = True
        '
        'DgvPrice
        '
        Me.DgvPrice.AllowUserToAddRows = False
        Me.DgvPrice.AllowUserToDeleteRows = False
        Me.DgvPrice.AllowUserToOrderColumns = True
        Me.DgvPrice.AllowUserToResizeRows = False
        Me.DgvPrice.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPrice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPrice.Location = New System.Drawing.Point(3, 29)
        Me.DgvPrice.MultiSelect = False
        Me.DgvPrice.Name = "DgvPrice"
        Me.DgvPrice.ReadOnly = True
        Me.DgvPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPrice.RowHeadersVisible = False
        Me.DgvPrice.RowTemplate.Height = 26
        Me.DgvPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPrice.Size = New System.Drawing.Size(469, 30)
        Me.DgvPrice.TabIndex = 1
        '
        'TsPrice
        '
        Me.TsPrice.BackColor = System.Drawing.Color.Transparent
        Me.TsPrice.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsPrice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsPrice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludePrice, Me.BtnEditPrice, Me.BtnDeletePrice, Me.ToolStripLabel1, Me.TxtFilterPrice})
        Me.TsPrice.Location = New System.Drawing.Point(3, 4)
        Me.TsPrice.Name = "TsPrice"
        Me.TsPrice.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsPrice.Size = New System.Drawing.Size(469, 25)
        Me.TsPrice.TabIndex = 0
        Me.TsPrice.Text = "ToolStrip2"
        '
        'BtnIncludePrice
        '
        Me.BtnIncludePrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludePrice.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludePrice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludePrice.Name = "BtnIncludePrice"
        Me.BtnIncludePrice.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludePrice.Text = "Incluir Preço"
        '
        'BtnEditPrice
        '
        Me.BtnEditPrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditPrice.Enabled = False
        Me.BtnEditPrice.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditPrice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditPrice.Name = "BtnEditPrice"
        Me.BtnEditPrice.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditPrice.Text = "Editar Preço"
        Me.BtnEditPrice.ToolTipText = "Editar"
        '
        'BtnDeletePrice
        '
        Me.BtnDeletePrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeletePrice.Enabled = False
        Me.BtnDeletePrice.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeletePrice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeletePrice.Name = "BtnDeletePrice"
        Me.BtnDeletePrice.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeletePrice.Text = "Excluir Preço"
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
        'TxtFilterPrice
        '
        Me.TxtFilterPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterPrice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterPrice.Name = "TxtFilterPrice"
        Me.TxtFilterPrice.Size = New System.Drawing.Size(200, 25)
        '
        'TabDescription
        '
        Me.TabDescription.Controls.Add(Me.DgvComplement)
        Me.TabDescription.Controls.Add(Me.TsCode)
        Me.TabDescription.Location = New System.Drawing.Point(4, 26)
        Me.TabDescription.Name = "TabDescription"
        Me.TabDescription.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDescription.Size = New System.Drawing.Size(475, 59)
        Me.TabDescription.TabIndex = 7
        Me.TabDescription.Text = "Descrições"
        Me.TabDescription.UseVisualStyleBackColor = True
        '
        'DgvComplement
        '
        Me.DgvComplement.AllowUserToAddRows = False
        Me.DgvComplement.AllowUserToDeleteRows = False
        Me.DgvComplement.AllowUserToOrderColumns = True
        Me.DgvComplement.AllowUserToResizeRows = False
        Me.DgvComplement.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvComplement.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvComplement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvComplement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvComplement.Location = New System.Drawing.Point(3, 28)
        Me.DgvComplement.MultiSelect = False
        Me.DgvComplement.Name = "DgvComplement"
        Me.DgvComplement.ReadOnly = True
        Me.DgvComplement.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvComplement.RowHeadersVisible = False
        Me.DgvComplement.RowTemplate.Height = 26
        Me.DgvComplement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvComplement.Size = New System.Drawing.Size(469, 28)
        Me.DgvComplement.TabIndex = 1
        '
        'TsCode
        '
        Me.TsCode.BackColor = System.Drawing.Color.Transparent
        Me.TsCode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsCode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCode, Me.BtnEditCode, Me.BtnDeleteCode, Me.ToolStripLabel2, Me.TxtFilterDescription})
        Me.TsCode.Location = New System.Drawing.Point(3, 3)
        Me.TsCode.Name = "TsCode"
        Me.TsCode.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsCode.Size = New System.Drawing.Size(469, 25)
        Me.TsCode.TabIndex = 0
        Me.TsCode.Text = "ToolStrip2"
        '
        'BtnIncludeCode
        '
        Me.BtnIncludeCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeCode.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeCode.Name = "BtnIncludeCode"
        Me.BtnIncludeCode.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeCode.Text = "Incluir Código"
        '
        'BtnEditCode
        '
        Me.BtnEditCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditCode.Enabled = False
        Me.BtnEditCode.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditCode.Name = "BtnEditCode"
        Me.BtnEditCode.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditCode.Text = "Editar Código"
        Me.BtnEditCode.ToolTipText = "Editar"
        '
        'BtnDeleteCode
        '
        Me.BtnDeleteCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteCode.Enabled = False
        Me.BtnDeleteCode.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteCode.Name = "BtnDeleteCode"
        Me.BtnDeleteCode.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteCode.Text = "Excluir Código"
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
        'TxtFilterDescription
        '
        Me.TxtFilterDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterDescription.Name = "TxtFilterDescription"
        Me.TxtFilterDescription.Size = New System.Drawing.Size(200, 25)
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.Label5)
        Me.TabMain.Controls.Add(Me.TxtServiceCode)
        Me.TabMain.Controls.Add(Me.TxtName)
        Me.TabMain.Controls.Add(Me.LblName)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(475, 59)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(347, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Cod. Serviço"
        '
        'TxtServiceCode
        '
        Me.TxtServiceCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtServiceCode.Location = New System.Drawing.Point(350, 24)
        Me.TxtServiceCode.MaxLength = 20
        Me.TxtServiceCode.Name = "TxtServiceCode"
        Me.TxtServiceCode.Size = New System.Drawing.Size(119, 23)
        Me.TxtServiceCode.TabIndex = 13
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(9, 24)
        Me.TxtName.MaxLength = 255
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(335, 23)
        Me.TxtName.TabIndex = 1
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(6, 4)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Nome"
        '
        'TcProduct
        '
        Me.TcProduct.Controls.Add(Me.TabMain)
        Me.TcProduct.Controls.Add(Me.TabDescription)
        Me.TcProduct.Controls.Add(Me.TabPrice)
        Me.TcProduct.Controls.Add(Me.TabNote)
        Me.TcProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcProduct.Location = New System.Drawing.Point(0, 50)
        Me.TcProduct.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcProduct.Multiline = True
        Me.TcProduct.Name = "TcProduct"
        Me.TcProduct.SelectedIndex = 0
        Me.TcProduct.Size = New System.Drawing.Size(483, 89)
        Me.TcProduct.TabIndex = 2
        '
        'TmrQueriedBoxFamily
        '
        Me.TmrQueriedBoxFamily.Enabled = True
        Me.TmrQueriedBoxFamily.Interval = 300
        '
        'TmrQueriedBoxGroup
        '
        Me.TmrQueriedBoxGroup.Enabled = True
        Me.TmrQueriedBoxGroup.Interval = 300
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'DgvProviderCodeLayout
        '
        Me.DgvProviderCodeLayout.Routine = Manager.Routine.ProductProviderCode
        '
        'DgvCodeLayout
        '
        Me.DgvCodeLayout.DataGridView = Me.DgvComplement
        Me.DgvCodeLayout.Routine = Manager.Routine.ProductCode
        '
        'DgvPriceLayout
        '
        Me.DgvPriceLayout.DataGridView = Me.DgvPrice
        Me.DgvPriceLayout.Routine = Manager.Routine.SellablePrice
        '
        'DgvPictureLayout
        '
        Me.DgvPictureLayout.Routine = Manager.Routine.ProductPicture
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        '
        'FrmService
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(483, 183)
        Me.Controls.Add(Me.TcProduct)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmService"
        Me.ShowIcon = False
        Me.Text = "Produto"
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNote.ResumeLayout(False)
        Me.TabPrice.ResumeLayout(False)
        Me.TabPrice.PerformLayout()
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsPrice.ResumeLayout(False)
        Me.TsPrice.PerformLayout()
        Me.TabDescription.ResumeLayout(False)
        Me.TabDescription.PerformLayout()
        CType(Me.DgvComplement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsCode.ResumeLayout(False)
        Me.TsCode.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.TcProduct.ResumeLayout(False)
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
    Friend WithEvents TcProduct As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents TabDescription As TabPage
    Friend WithEvents DgvComplement As DataGridView
    Friend WithEvents TsCode As ToolStrip
    Friend WithEvents BtnIncludeCode As ToolStripButton
    Friend WithEvents BtnEditCode As ToolStripButton
    Friend WithEvents BtnDeleteCode As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TxtFilterDescription As ToolStripTextBox
    Friend WithEvents TabPrice As TabPage
    Friend WithEvents DgvPrice As DataGridView
    Friend WithEvents TsPrice As ToolStrip
    Friend WithEvents BtnIncludePrice As ToolStripButton
    Friend WithEvents BtnEditPrice As ToolStripButton
    Friend WithEvents BtnDeletePrice As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TxtFilterPrice As ToolStripTextBox
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents DgvProviderCodeLayout As DataGridViewLayout
    Friend WithEvents DgvCodeLayout As DataGridViewLayout
    Friend WithEvents DgvPriceLayout As DataGridViewLayout
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtServiceCode As TextBox
    Friend WithEvents TmrQueriedBoxFamily As Timer
    Friend WithEvents TmrQueriedBoxGroup As Timer
    Friend WithEvents DgvPictureLayout As DataGridViewLayout
    Friend WithEvents EprInformation As ErrorProvider
End Class
