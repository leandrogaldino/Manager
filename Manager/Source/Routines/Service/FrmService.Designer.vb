<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmService
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
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabNote = New System.Windows.Forms.TabPage()
        Me.TxtNote = New System.Windows.Forms.RichTextBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TabComplement = New System.Windows.Forms.TabPage()
        Me.DgvComplement = New System.Windows.Forms.DataGridView()
        Me.TsComplement = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeComplement = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditComplement = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteComplement = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterComplement = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterComplement = New System.Windows.Forms.ToolStripTextBox()
        Me.TxtFilterDescription = New System.Windows.Forms.ToolStripTextBox()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TcService = New System.Windows.Forms.TabControl()
        Me.TabCode = New System.Windows.Forms.TabPage()
        Me.DgvCode = New System.Windows.Forms.DataGridView()
        Me.TsCode = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCode = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterCode = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterCode = New System.Windows.Forms.ToolStripTextBox()
        Me.TabPrice = New System.Windows.Forms.TabPage()
        Me.DgvPrice = New System.Windows.Forms.DataGridView()
        Me.TsPrice = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludePrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditPrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePrice = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterPrice = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterPrice = New System.Windows.Forms.ToolStripTextBox()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.DgvComplementLayout = New Manager.DataGridViewLayout()
        Me.DgvPriceLayout = New Manager.DataGridViewLayout()
        Me.DgvCodeLayout = New Manager.DataGridViewLayout()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNote.SuspendLayout()
        Me.TabComplement.SuspendLayout()
        CType(Me.DgvComplement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsComplement.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TcService.SuspendLayout()
        Me.TabCode.SuspendLayout()
        CType(Me.DgvCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsCode.SuspendLayout()
        Me.TabPrice.SuspendLayout()
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsPrice.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsNavigation.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(337, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(236, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
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
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Serviço"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Serviço"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Serviço"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Serviço Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Serviço"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Serviço"
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.White
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 142)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(444, 44)
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
        Me.TabNote.Size = New System.Drawing.Size(436, 66)
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
        Me.TxtNote.Size = New System.Drawing.Size(430, 60)
        Me.TxtNote.TabIndex = 0
        Me.TxtNote.Text = ""
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
        'TabComplement
        '
        Me.TabComplement.Controls.Add(Me.DgvComplement)
        Me.TabComplement.Controls.Add(Me.TsComplement)
        Me.TabComplement.Location = New System.Drawing.Point(4, 22)
        Me.TabComplement.Name = "TabComplement"
        Me.TabComplement.Padding = New System.Windows.Forms.Padding(3)
        Me.TabComplement.Size = New System.Drawing.Size(436, 66)
        Me.TabComplement.TabIndex = 7
        Me.TabComplement.Text = "Complementos"
        Me.TabComplement.UseVisualStyleBackColor = True
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
        Me.DgvComplement.Size = New System.Drawing.Size(430, 35)
        Me.DgvComplement.TabIndex = 1
        '
        'TsComplement
        '
        Me.TsComplement.BackColor = System.Drawing.Color.Transparent
        Me.TsComplement.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsComplement.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsComplement.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeComplement, Me.BtnEditComplement, Me.BtnDeleteComplement, Me.LblFilterComplement, Me.TxtFilterComplement})
        Me.TsComplement.Location = New System.Drawing.Point(3, 3)
        Me.TsComplement.Name = "TsComplement"
        Me.TsComplement.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsComplement.Size = New System.Drawing.Size(430, 25)
        Me.TsComplement.TabIndex = 0
        Me.TsComplement.Text = "ToolStrip2"
        '
        'BtnIncludeComplement
        '
        Me.BtnIncludeComplement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeComplement.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeComplement.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeComplement.Name = "BtnIncludeComplement"
        Me.BtnIncludeComplement.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeComplement.Text = "Incluir Complemento"
        '
        'BtnEditComplement
        '
        Me.BtnEditComplement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditComplement.Enabled = False
        Me.BtnEditComplement.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditComplement.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditComplement.Name = "BtnEditComplement"
        Me.BtnEditComplement.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditComplement.Text = "Editar Complemento"
        Me.BtnEditComplement.ToolTipText = "Editar"
        '
        'BtnDeleteComplement
        '
        Me.BtnDeleteComplement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteComplement.Enabled = False
        Me.BtnDeleteComplement.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteComplement.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteComplement.Name = "BtnDeleteComplement"
        Me.BtnDeleteComplement.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteComplement.Text = "Excluir Complemento"
        '
        'LblFilterComplement
        '
        Me.LblFilterComplement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LblFilterComplement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblFilterComplement.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.LblFilterComplement.Name = "LblFilterComplement"
        Me.LblFilterComplement.Size = New System.Drawing.Size(46, 25)
        Me.LblFilterComplement.Text = "Filtrar:"
        '
        'TxtFilterComplement
        '
        Me.TxtFilterComplement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterComplement.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterComplement.Name = "TxtFilterComplement"
        Me.TxtFilterComplement.Size = New System.Drawing.Size(200, 25)
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
        Me.TabMain.Controls.Add(Me.TxtName)
        Me.TabMain.Controls.Add(Me.LblName)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(436, 62)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(11, 24)
        Me.TxtName.MaxLength = 255
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(412, 23)
        Me.TxtName.TabIndex = 1
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(8, 4)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Nome"
        '
        'TcService
        '
        Me.TcService.Controls.Add(Me.TabMain)
        Me.TcService.Controls.Add(Me.TabCode)
        Me.TcService.Controls.Add(Me.TabPrice)
        Me.TcService.Controls.Add(Me.TabComplement)
        Me.TcService.Controls.Add(Me.TabNote)
        Me.TcService.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcService.Location = New System.Drawing.Point(0, 50)
        Me.TcService.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcService.Multiline = True
        Me.TcService.Name = "TcService"
        Me.TcService.SelectedIndex = 0
        Me.TcService.Size = New System.Drawing.Size(444, 92)
        Me.TcService.TabIndex = 2
        '
        'TabCode
        '
        Me.TabCode.Controls.Add(Me.DgvCode)
        Me.TabCode.Controls.Add(Me.TsCode)
        Me.TabCode.Location = New System.Drawing.Point(4, 22)
        Me.TabCode.Name = "TabCode"
        Me.TabCode.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCode.Size = New System.Drawing.Size(436, 66)
        Me.TabCode.TabIndex = 9
        Me.TabCode.Text = "Códigos"
        Me.TabCode.UseVisualStyleBackColor = True
        '
        'DgvCode
        '
        Me.DgvCode.AllowUserToAddRows = False
        Me.DgvCode.AllowUserToDeleteRows = False
        Me.DgvCode.AllowUserToOrderColumns = True
        Me.DgvCode.AllowUserToResizeRows = False
        Me.DgvCode.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCode.Location = New System.Drawing.Point(3, 28)
        Me.DgvCode.MultiSelect = False
        Me.DgvCode.Name = "DgvCode"
        Me.DgvCode.ReadOnly = True
        Me.DgvCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvCode.RowHeadersVisible = False
        Me.DgvCode.RowTemplate.Height = 26
        Me.DgvCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCode.Size = New System.Drawing.Size(430, 35)
        Me.DgvCode.TabIndex = 4
        '
        'TsCode
        '
        Me.TsCode.BackColor = System.Drawing.Color.Transparent
        Me.TsCode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsCode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCode, Me.BtnEditCode, Me.BtnDeleteCode, Me.LblFilterCode, Me.TxtFilterCode})
        Me.TsCode.Location = New System.Drawing.Point(3, 3)
        Me.TsCode.Name = "TsCode"
        Me.TsCode.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsCode.Size = New System.Drawing.Size(430, 25)
        Me.TsCode.TabIndex = 3
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
        'LblFilterCode
        '
        Me.LblFilterCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LblFilterCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblFilterCode.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.LblFilterCode.Name = "LblFilterCode"
        Me.LblFilterCode.Size = New System.Drawing.Size(46, 25)
        Me.LblFilterCode.Text = "Filtrar:"
        '
        'TxtFilterCode
        '
        Me.TxtFilterCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterCode.Name = "TxtFilterCode"
        Me.TxtFilterCode.Size = New System.Drawing.Size(200, 25)
        '
        'TabPrice
        '
        Me.TabPrice.Controls.Add(Me.DgvPrice)
        Me.TabPrice.Controls.Add(Me.TsPrice)
        Me.TabPrice.Location = New System.Drawing.Point(4, 22)
        Me.TabPrice.Name = "TabPrice"
        Me.TabPrice.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPrice.Size = New System.Drawing.Size(436, 66)
        Me.TabPrice.TabIndex = 8
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
        Me.DgvPrice.Location = New System.Drawing.Point(3, 28)
        Me.DgvPrice.MultiSelect = False
        Me.DgvPrice.Name = "DgvPrice"
        Me.DgvPrice.ReadOnly = True
        Me.DgvPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPrice.RowHeadersVisible = False
        Me.DgvPrice.RowTemplate.Height = 26
        Me.DgvPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPrice.Size = New System.Drawing.Size(430, 35)
        Me.DgvPrice.TabIndex = 2
        '
        'TsPrice
        '
        Me.TsPrice.BackColor = System.Drawing.Color.Transparent
        Me.TsPrice.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsPrice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsPrice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludePrice, Me.BtnEditPrice, Me.BtnDeletePrice, Me.LblFilterPrice, Me.TxtFilterPrice})
        Me.TsPrice.Location = New System.Drawing.Point(3, 3)
        Me.TsPrice.Name = "TsPrice"
        Me.TsPrice.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsPrice.Size = New System.Drawing.Size(430, 25)
        Me.TsPrice.TabIndex = 1
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
        'LblFilterPrice
        '
        Me.LblFilterPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LblFilterPrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblFilterPrice.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.LblFilterPrice.Name = "LblFilterPrice"
        Me.LblFilterPrice.Size = New System.Drawing.Size(46, 25)
        Me.LblFilterPrice.Text = "Filtrar:"
        '
        'TxtFilterPrice
        '
        Me.TxtFilterPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterPrice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterPrice.Name = "TxtFilterPrice"
        Me.TxtFilterPrice.Size = New System.Drawing.Size(200, 25)
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
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
        Me.TsNavigation.Size = New System.Drawing.Size(444, 25)
        Me.TsNavigation.TabIndex = 0
        Me.TsNavigation.Text = "ToolStrip2"
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
        Me.TsTitle.Size = New System.Drawing.Size(444, 25)
        Me.TsTitle.TabIndex = 1
        Me.TsTitle.Text = "ToolStrip1"
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'DgvComplementLayout
        '
        Me.DgvComplementLayout.DataGridView = Me.DgvComplement
        Me.DgvComplementLayout.Routine = Manager.Routine.ServiceComplement
        '
        'DgvPriceLayout
        '
        Me.DgvPriceLayout.DataGridView = Me.DgvPrice
        Me.DgvPriceLayout.Routine = Manager.Routine.ServicePrice
        '
        'DgvCodeLayout
        '
        Me.DgvCodeLayout.DataGridView = Me.DgvCode
        Me.DgvCodeLayout.Routine = Manager.Routine.ServiceCode
        '
        'FrmService
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(444, 186)
        Me.Controls.Add(Me.TcService)
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
        Me.Text = "Serviço"
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNote.ResumeLayout(False)
        Me.TabComplement.ResumeLayout(False)
        Me.TabComplement.PerformLayout()
        CType(Me.DgvComplement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsComplement.ResumeLayout(False)
        Me.TsComplement.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.TcService.ResumeLayout(False)
        Me.TabCode.ResumeLayout(False)
        Me.TabCode.PerformLayout()
        CType(Me.DgvCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsCode.ResumeLayout(False)
        Me.TsCode.PerformLayout()
        Me.TabPrice.ResumeLayout(False)
        Me.TabPrice.PerformLayout()
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsPrice.ResumeLayout(False)
        Me.TsPrice.PerformLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents PnButtons As Panel
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TcService As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents TabComplement As TabPage
    Friend WithEvents DgvComplement As DataGridView
    Friend WithEvents TxtFilterDescription As ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents DgvComplementLayout As DataGridViewLayout
    Friend WithEvents TsComplement As ToolStrip
    Friend WithEvents BtnIncludeComplement As ToolStripButton
    Friend WithEvents BtnEditComplement As ToolStripButton
    Friend WithEvents BtnDeleteComplement As ToolStripButton
    Friend WithEvents LblFilterComplement As ToolStripLabel
    Friend WithEvents TxtFilterComplement As ToolStripTextBox
    Friend WithEvents TabPrice As TabPage
    Friend WithEvents DgvPrice As DataGridView
    Friend WithEvents TsPrice As ToolStrip
    Friend WithEvents BtnIncludePrice As ToolStripButton
    Friend WithEvents BtnEditPrice As ToolStripButton
    Friend WithEvents BtnDeletePrice As ToolStripButton
    Friend WithEvents LblFilterPrice As ToolStripLabel
    Friend WithEvents TxtFilterPrice As ToolStripTextBox
    Friend WithEvents DgvPriceLayout As DataGridViewLayout
    Friend WithEvents TabCode As TabPage
    Friend WithEvents DgvCode As DataGridView
    Friend WithEvents TsCode As ToolStrip
    Friend WithEvents BtnIncludeCode As ToolStripButton
    Friend WithEvents BtnEditCode As ToolStripButton
    Friend WithEvents BtnDeleteCode As ToolStripButton
    Friend WithEvents LblFilterCode As ToolStripLabel
    Friend WithEvents TxtFilterCode As ToolStripTextBox
    Friend WithEvents DgvCodeLayout As DataGridViewLayout
End Class
