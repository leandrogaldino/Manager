<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProduct
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
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProduct))
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
        Me.TabProductCode = New System.Windows.Forms.TabPage()
        Me.DgvCode = New System.Windows.Forms.DataGridView()
        Me.TsCode = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterCode = New System.Windows.Forms.ToolStripTextBox()
        Me.TabProductProviderCode = New System.Windows.Forms.TabPage()
        Me.DgvProviderCode = New System.Windows.Forms.DataGridView()
        Me.TsProviderCode = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeProviderCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditProviderCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteProviderCode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterProviderCode = New System.Windows.Forms.ToolStripTextBox()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.FlpGroup = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterGroup = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewGroup = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewGroup = New ControlLibrary.NoFocusCueButton()
        Me.FlpFamily = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterFamily = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewFamily = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewFamily = New ControlLibrary.NoFocusCueButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DbxNetWeight = New ControlLibrary.DecimalBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DbxGrossWeight = New ControlLibrary.DecimalBox()
        Me.LblGrossWeight = New System.Windows.Forms.Label()
        Me.DbxQtyMax = New ControlLibrary.DecimalBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DbxQtyMin = New ControlLibrary.DecimalBox()
        Me.LblQtyMin = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtSKU = New System.Windows.Forms.TextBox()
        Me.TxtDimensions = New System.Windows.Forms.TextBox()
        Me.TxtLocation = New System.Windows.Forms.TextBox()
        Me.QbxUnit = New ControlLibrary.QueriedBox()
        Me.QbxGroup = New ControlLibrary.QueriedBox()
        Me.QbxFamily = New ControlLibrary.QueriedBox()
        Me.LblUnit = New System.Windows.Forms.Label()
        Me.LblGroup = New System.Windows.Forms.Label()
        Me.TxtInternalName = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblFamily = New System.Windows.Forms.Label()
        Me.LblInternalName = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TcProduct = New System.Windows.Forms.TabControl()
        Me.TabPrice = New System.Windows.Forms.TabPage()
        Me.DgvPrice = New System.Windows.Forms.DataGridView()
        Me.TsPrice = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludePrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditPrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePrice = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterPrice = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterPrice = New System.Windows.Forms.ToolStripTextBox()
        Me.TabIndicator = New System.Windows.Forms.TabPage()
        Me.DgvIndicator = New System.Windows.Forms.DataGridView()
        Me.TabPicture = New System.Windows.Forms.TabPage()
        Me.PvPicture = New ControlLibrary.PictureViewer()
        Me.TmrQueriedBoxFamily = New System.Windows.Forms.Timer(Me.components)
        Me.TmrQueriedBoxGroup = New System.Windows.Forms.Timer(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvlProviderCode = New Manager.DataGridViewLayout()
        Me.DgvlCode = New Manager.DataGridViewLayout()
        Me.DgvlIndicator = New Manager.DataGridViewLayout()
        Me.DgvlPrice = New Manager.DataGridViewLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNote.SuspendLayout()
        Me.TabProductCode.SuspendLayout()
        CType(Me.DgvCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsCode.SuspendLayout()
        Me.TabProductProviderCode.SuspendLayout()
        CType(Me.DgvProviderCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsProviderCode.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.FlpGroup.SuspendLayout()
        Me.FlpFamily.SuspendLayout()
        Me.TcProduct.SuspendLayout()
        Me.TabPrice.SuspendLayout()
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsPrice.SuspendLayout()
        Me.TabIndicator.SuspendLayout()
        CType(Me.DgvIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPicture.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TsTitle.Size = New System.Drawing.Size(614, 25)
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
        Me.TsNavigation.Size = New System.Drawing.Size(614, 25)
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
        Me.PnButtons.Location = New System.Drawing.Point(0, 272)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(614, 44)
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
        Me.TabNote.Size = New System.Drawing.Size(606, 196)
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
        Me.TxtNote.Size = New System.Drawing.Size(600, 190)
        Me.TxtNote.TabIndex = 0
        Me.TxtNote.Text = ""
        '
        'TabProductCode
        '
        Me.TabProductCode.Controls.Add(Me.DgvCode)
        Me.TabProductCode.Controls.Add(Me.TsCode)
        Me.TabProductCode.Location = New System.Drawing.Point(4, 22)
        Me.TabProductCode.Name = "TabProductCode"
        Me.TabProductCode.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProductCode.Size = New System.Drawing.Size(606, 196)
        Me.TabProductCode.TabIndex = 7
        Me.TabProductCode.Text = "Cód. Produto"
        Me.TabProductCode.UseVisualStyleBackColor = True
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
        Me.DgvCode.Size = New System.Drawing.Size(600, 165)
        Me.DgvCode.TabIndex = 1
        '
        'TsCode
        '
        Me.TsCode.BackColor = System.Drawing.Color.Transparent
        Me.TsCode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsCode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCode, Me.BtnEditCode, Me.BtnDeleteCode, Me.ToolStripLabel2, Me.TxtFilterCode})
        Me.TsCode.Location = New System.Drawing.Point(3, 3)
        Me.TsCode.Name = "TsCode"
        Me.TsCode.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsCode.Size = New System.Drawing.Size(600, 25)
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
        'TxtFilterCode
        '
        Me.TxtFilterCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterCode.Name = "TxtFilterCode"
        Me.TxtFilterCode.Size = New System.Drawing.Size(200, 25)
        '
        'TabProductProviderCode
        '
        Me.TabProductProviderCode.Controls.Add(Me.DgvProviderCode)
        Me.TabProductProviderCode.Controls.Add(Me.TsProviderCode)
        Me.TabProductProviderCode.Location = New System.Drawing.Point(4, 22)
        Me.TabProductProviderCode.Name = "TabProductProviderCode"
        Me.TabProductProviderCode.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProductProviderCode.Size = New System.Drawing.Size(606, 196)
        Me.TabProductProviderCode.TabIndex = 6
        Me.TabProductProviderCode.Text = "Cód. Fornecedor"
        Me.TabProductProviderCode.UseVisualStyleBackColor = True
        '
        'DgvProviderCode
        '
        Me.DgvProviderCode.AllowUserToAddRows = False
        Me.DgvProviderCode.AllowUserToDeleteRows = False
        Me.DgvProviderCode.AllowUserToOrderColumns = True
        Me.DgvProviderCode.AllowUserToResizeRows = False
        Me.DgvProviderCode.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvProviderCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvProviderCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProviderCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProviderCode.Location = New System.Drawing.Point(3, 28)
        Me.DgvProviderCode.MultiSelect = False
        Me.DgvProviderCode.Name = "DgvProviderCode"
        Me.DgvProviderCode.ReadOnly = True
        Me.DgvProviderCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvProviderCode.RowHeadersVisible = False
        Me.DgvProviderCode.RowTemplate.Height = 26
        Me.DgvProviderCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProviderCode.Size = New System.Drawing.Size(600, 165)
        Me.DgvProviderCode.TabIndex = 1
        '
        'TsProviderCode
        '
        Me.TsProviderCode.BackColor = System.Drawing.Color.Transparent
        Me.TsProviderCode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsProviderCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsProviderCode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeProviderCode, Me.BtnEditProviderCode, Me.BtnDeleteProviderCode, Me.ToolStripLabel3, Me.TxtFilterProviderCode})
        Me.TsProviderCode.Location = New System.Drawing.Point(3, 3)
        Me.TsProviderCode.Name = "TsProviderCode"
        Me.TsProviderCode.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsProviderCode.Size = New System.Drawing.Size(600, 25)
        Me.TsProviderCode.TabIndex = 0
        Me.TsProviderCode.Text = "ToolStrip2"
        '
        'BtnIncludeProviderCode
        '
        Me.BtnIncludeProviderCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeProviderCode.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeProviderCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeProviderCode.Name = "BtnIncludeProviderCode"
        Me.BtnIncludeProviderCode.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeProviderCode.Text = "Incluir Código de Fornecedor"
        '
        'BtnEditProviderCode
        '
        Me.BtnEditProviderCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditProviderCode.Enabled = False
        Me.BtnEditProviderCode.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditProviderCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditProviderCode.Name = "BtnEditProviderCode"
        Me.BtnEditProviderCode.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditProviderCode.Text = "Editar Código de Fornecedor"
        Me.BtnEditProviderCode.ToolTipText = "Editar"
        '
        'BtnDeleteProviderCode
        '
        Me.BtnDeleteProviderCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteProviderCode.Enabled = False
        Me.BtnDeleteProviderCode.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteProviderCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteProviderCode.Name = "BtnDeleteProviderCode"
        Me.BtnDeleteProviderCode.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteProviderCode.Text = "Excluir Código de Fornecedor"
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
        'TxtFilterProviderCode
        '
        Me.TxtFilterProviderCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterProviderCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterProviderCode.Name = "TxtFilterProviderCode"
        Me.TxtFilterProviderCode.Size = New System.Drawing.Size(200, 25)
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.FlpGroup)
        Me.TabMain.Controls.Add(Me.FlpFamily)
        Me.TabMain.Controls.Add(Me.Label2)
        Me.TabMain.Controls.Add(Me.Label1)
        Me.TabMain.Controls.Add(Me.DbxNetWeight)
        Me.TabMain.Controls.Add(Me.Label9)
        Me.TabMain.Controls.Add(Me.DbxGrossWeight)
        Me.TabMain.Controls.Add(Me.LblGrossWeight)
        Me.TabMain.Controls.Add(Me.DbxQtyMax)
        Me.TabMain.Controls.Add(Me.Label7)
        Me.TabMain.Controls.Add(Me.DbxQtyMin)
        Me.TabMain.Controls.Add(Me.LblQtyMin)
        Me.TabMain.Controls.Add(Me.Label5)
        Me.TabMain.Controls.Add(Me.TxtSKU)
        Me.TabMain.Controls.Add(Me.TxtDimensions)
        Me.TabMain.Controls.Add(Me.TxtLocation)
        Me.TabMain.Controls.Add(Me.QbxUnit)
        Me.TabMain.Controls.Add(Me.QbxGroup)
        Me.TabMain.Controls.Add(Me.QbxFamily)
        Me.TabMain.Controls.Add(Me.LblUnit)
        Me.TabMain.Controls.Add(Me.LblGroup)
        Me.TabMain.Controls.Add(Me.TxtInternalName)
        Me.TabMain.Controls.Add(Me.TxtName)
        Me.TabMain.Controls.Add(Me.LblFamily)
        Me.TabMain.Controls.Add(Me.LblInternalName)
        Me.TabMain.Controls.Add(Me.LblName)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(606, 192)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'FlpGroup
        '
        Me.FlpGroup.Controls.Add(Me.BtnFilterGroup)
        Me.FlpGroup.Controls.Add(Me.BtnViewGroup)
        Me.FlpGroup.Controls.Add(Me.BtnNewGroup)
        Me.FlpGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpGroup.Location = New System.Drawing.Point(341, 95)
        Me.FlpGroup.Name = "FlpGroup"
        Me.FlpGroup.Size = New System.Drawing.Size(69, 21)
        Me.FlpGroup.TabIndex = 9
        '
        'BtnFilterGroup
        '
        Me.BtnFilterGroup.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterGroup.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterGroup.FlatAppearance.BorderSize = 0
        Me.BtnFilterGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterGroup.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterGroup.Name = "BtnFilterGroup"
        Me.BtnFilterGroup.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterGroup.TabIndex = 2
        Me.BtnFilterGroup.TabStop = False
        Me.BtnFilterGroup.TooltipText = ""
        Me.BtnFilterGroup.UseVisualStyleBackColor = False
        Me.BtnFilterGroup.Visible = False
        '
        'BtnViewGroup
        '
        Me.BtnViewGroup.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewGroup.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewGroup.FlatAppearance.BorderSize = 0
        Me.BtnViewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewGroup.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewGroup.Name = "BtnViewGroup"
        Me.BtnViewGroup.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewGroup.TabIndex = 1
        Me.BtnViewGroup.TabStop = False
        Me.BtnViewGroup.TooltipText = ""
        Me.BtnViewGroup.UseVisualStyleBackColor = False
        Me.BtnViewGroup.Visible = False
        '
        'BtnNewGroup
        '
        Me.BtnNewGroup.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewGroup.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewGroup.FlatAppearance.BorderSize = 0
        Me.BtnNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewGroup.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewGroup.Name = "BtnNewGroup"
        Me.BtnNewGroup.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewGroup.TabIndex = 0
        Me.BtnNewGroup.TabStop = False
        Me.BtnNewGroup.TooltipText = ""
        Me.BtnNewGroup.UseVisualStyleBackColor = False
        Me.BtnNewGroup.Visible = False
        '
        'FlpFamily
        '
        Me.FlpFamily.Controls.Add(Me.BtnFilterFamily)
        Me.FlpFamily.Controls.Add(Me.BtnViewFamily)
        Me.FlpFamily.Controls.Add(Me.BtnNewFamily)
        Me.FlpFamily.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpFamily.Location = New System.Drawing.Point(135, 95)
        Me.FlpFamily.Name = "FlpFamily"
        Me.FlpFamily.Size = New System.Drawing.Size(69, 21)
        Me.FlpFamily.TabIndex = 6
        '
        'BtnFilterFamily
        '
        Me.BtnFilterFamily.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterFamily.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterFamily.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterFamily.FlatAppearance.BorderSize = 0
        Me.BtnFilterFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterFamily.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterFamily.Name = "BtnFilterFamily"
        Me.BtnFilterFamily.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterFamily.TabIndex = 2
        Me.BtnFilterFamily.TabStop = False
        Me.BtnFilterFamily.TooltipText = ""
        Me.BtnFilterFamily.UseVisualStyleBackColor = False
        Me.BtnFilterFamily.Visible = False
        '
        'BtnViewFamily
        '
        Me.BtnViewFamily.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewFamily.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewFamily.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewFamily.FlatAppearance.BorderSize = 0
        Me.BtnViewFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewFamily.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewFamily.Name = "BtnViewFamily"
        Me.BtnViewFamily.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewFamily.TabIndex = 1
        Me.BtnViewFamily.TabStop = False
        Me.BtnViewFamily.TooltipText = ""
        Me.BtnViewFamily.UseVisualStyleBackColor = False
        Me.BtnViewFamily.Visible = False
        '
        'BtnNewFamily
        '
        Me.BtnNewFamily.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewFamily.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewFamily.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewFamily.FlatAppearance.BorderSize = 0
        Me.BtnNewFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewFamily.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewFamily.Name = "BtnNewFamily"
        Me.BtnNewFamily.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewFamily.TabIndex = 0
        Me.BtnNewFamily.TabStop = False
        Me.BtnNewFamily.TooltipText = ""
        Me.BtnNewFamily.UseVisualStyleBackColor = False
        Me.BtnNewFamily.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(500, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "SKU"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(367, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Dimensões"
        '
        'DbxNetWeight
        '
        Me.DbxNetWeight.DecimalOnly = True
        Me.DbxNetWeight.DecimalPlaces = 2
        Me.DbxNetWeight.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxNetWeight.Location = New System.Drawing.Point(279, 162)
        Me.DbxNetWeight.Name = "DbxNetWeight"
        Me.DbxNetWeight.Size = New System.Drawing.Size(85, 23)
        Me.DbxNetWeight.TabIndex = 21
        Me.DbxNetWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(276, 142)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 17)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Peso Líq."
        '
        'DbxGrossWeight
        '
        Me.DbxGrossWeight.DecimalOnly = True
        Me.DbxGrossWeight.DecimalPlaces = 2
        Me.DbxGrossWeight.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxGrossWeight.Location = New System.Drawing.Point(188, 162)
        Me.DbxGrossWeight.Name = "DbxGrossWeight"
        Me.DbxGrossWeight.Size = New System.Drawing.Size(85, 23)
        Me.DbxGrossWeight.TabIndex = 19
        Me.DbxGrossWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblGrossWeight
        '
        Me.LblGrossWeight.AutoSize = True
        Me.LblGrossWeight.Location = New System.Drawing.Point(185, 142)
        Me.LblGrossWeight.Name = "LblGrossWeight"
        Me.LblGrossWeight.Size = New System.Drawing.Size(75, 17)
        Me.LblGrossWeight.TabIndex = 18
        Me.LblGrossWeight.Text = "Peso Bruto"
        '
        'DbxQtyMax
        '
        Me.DbxQtyMax.DecimalOnly = True
        Me.DbxQtyMax.DecimalPlaces = 2
        Me.DbxQtyMax.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxQtyMax.Location = New System.Drawing.Point(97, 162)
        Me.DbxQtyMax.Name = "DbxQtyMax"
        Me.DbxQtyMax.Size = New System.Drawing.Size(85, 23)
        Me.DbxQtyMax.TabIndex = 17
        Me.DbxQtyMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(94, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Qtd. Max."
        '
        'DbxQtyMin
        '
        Me.DbxQtyMin.DecimalOnly = True
        Me.DbxQtyMin.DecimalPlaces = 2
        Me.DbxQtyMin.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxQtyMin.Location = New System.Drawing.Point(6, 162)
        Me.DbxQtyMin.Name = "DbxQtyMin"
        Me.DbxQtyMin.Size = New System.Drawing.Size(85, 23)
        Me.DbxQtyMin.TabIndex = 15
        Me.DbxQtyMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblQtyMin
        '
        Me.LblQtyMin.AutoSize = True
        Me.LblQtyMin.Location = New System.Drawing.Point(3, 142)
        Me.LblQtyMin.Name = "LblQtyMin"
        Me.LblQtyMin.Size = New System.Drawing.Size(67, 17)
        Me.LblQtyMin.TabIndex = 14
        Me.LblQtyMin.Text = "Qtd. Min."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(471, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Localização"
        '
        'TxtSKU
        '
        Me.TxtSKU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSKU.Location = New System.Drawing.Point(502, 162)
        Me.TxtSKU.MaxLength = 45
        Me.TxtSKU.Name = "TxtSKU"
        Me.TxtSKU.Size = New System.Drawing.Size(98, 23)
        Me.TxtSKU.TabIndex = 13
        '
        'TxtDimensions
        '
        Me.TxtDimensions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDimensions.Location = New System.Drawing.Point(370, 162)
        Me.TxtDimensions.MaxLength = 20
        Me.TxtDimensions.Name = "TxtDimensions"
        Me.TxtDimensions.Size = New System.Drawing.Size(126, 23)
        Me.TxtDimensions.TabIndex = 13
        '
        'TxtLocation
        '
        Me.TxtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLocation.Location = New System.Drawing.Point(474, 116)
        Me.TxtLocation.MaxLength = 20
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.Size = New System.Drawing.Size(126, 23)
        Me.TxtLocation.TabIndex = 13
        '
        'QbxUnit
        '
        Me.QbxUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxUnit.CharactersToQuery = 1
        Condition2.FieldName = "statusid"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "productunit"
        Condition2.Value = "@statusid"
        Me.QbxUnit.Conditions.Add(Condition2)
        Me.QbxUnit.DebugOnTextChanged = False
        Me.QbxUnit.DisplayFieldAlias = "Sigla"
        Me.QbxUnit.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxUnit.DisplayFieldName = "shortname"
        Me.QbxUnit.DisplayMainFieldName = "id"
        Me.QbxUnit.DisplayTableAlias = Nothing
        Me.QbxUnit.DisplayTableName = "productunit"
        Me.QbxUnit.Distinct = False
        Me.QbxUnit.DropDownAutoStretchRight = False
        Me.QbxUnit.DropDownStretchLeft = 120
        Me.QbxUnit.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxUnit.IfNull = Nothing
        Me.QbxUnit.Location = New System.Drawing.Point(418, 116)
        Me.QbxUnit.MainReturnFieldName = "id"
        Me.QbxUnit.MainTableAlias = Nothing
        Me.QbxUnit.MainTableName = "productunit"
        Me.QbxUnit.Name = "QbxUnit"
        OtherField2.DisplayFieldAlias = "Unidade"
        OtherField2.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField2.DisplayFieldName = "name"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "productunit"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        Me.QbxUnit.OtherFields.Add(OtherField2)
        Parameter2.ParameterName = "@statusid"
        Parameter2.ParameterValue = "0"
        Me.QbxUnit.Parameters.Add(Parameter2)
        Me.QbxUnit.Prefix = Nothing
        Me.QbxUnit.Size = New System.Drawing.Size(50, 23)
        Me.QbxUnit.Suffix = Nothing
        Me.QbxUnit.TabIndex = 11
        Me.QbxUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'QbxGroup
        '
        Me.QbxGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxGroup.CharactersToQuery = 1
        Me.QbxGroup.DebugOnTextChanged = False
        Me.QbxGroup.DisplayFieldAlias = "Grupo"
        Me.QbxGroup.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxGroup.DisplayFieldName = "name"
        Me.QbxGroup.DisplayMainFieldName = "id"
        Me.QbxGroup.DisplayTableAlias = ""
        Me.QbxGroup.DisplayTableName = "productgroup"
        Me.QbxGroup.Distinct = False
        Me.QbxGroup.DropDownAutoStretchRight = False
        Me.QbxGroup.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxGroup.IfNull = Nothing
        Me.QbxGroup.Location = New System.Drawing.Point(212, 116)
        Me.QbxGroup.MainReturnFieldName = "id"
        Me.QbxGroup.MainTableAlias = Nothing
        Me.QbxGroup.MainTableName = "productgroup"
        Me.QbxGroup.Name = "QbxGroup"
        Me.QbxGroup.Prefix = Nothing
        Me.QbxGroup.Size = New System.Drawing.Size(200, 23)
        Me.QbxGroup.Suffix = Nothing
        Me.QbxGroup.TabIndex = 8
        '
        'QbxFamily
        '
        Me.QbxFamily.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxFamily.CharactersToQuery = 1
        Me.QbxFamily.DebugOnTextChanged = False
        Me.QbxFamily.DisplayFieldAlias = "Nome"
        Me.QbxFamily.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxFamily.DisplayFieldName = "name"
        Me.QbxFamily.DisplayMainFieldName = "id"
        Me.QbxFamily.DisplayTableAlias = Nothing
        Me.QbxFamily.DisplayTableName = "productfamily"
        Me.QbxFamily.Distinct = False
        Me.QbxFamily.DropDownAutoStretchRight = False
        Me.QbxFamily.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxFamily.IfNull = Nothing
        Me.QbxFamily.Location = New System.Drawing.Point(6, 116)
        Me.QbxFamily.MainReturnFieldName = "id"
        Me.QbxFamily.MainTableAlias = Nothing
        Me.QbxFamily.MainTableName = "productfamily"
        Me.QbxFamily.Name = "QbxFamily"
        Me.QbxFamily.Prefix = Nothing
        Me.QbxFamily.Size = New System.Drawing.Size(200, 23)
        Me.QbxFamily.Suffix = Nothing
        Me.QbxFamily.TabIndex = 5
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Location = New System.Drawing.Point(415, 96)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(37, 17)
        Me.LblUnit.TabIndex = 10
        Me.LblUnit.Text = "Und."
        '
        'LblGroup
        '
        Me.LblGroup.AutoSize = True
        Me.LblGroup.Location = New System.Drawing.Point(209, 96)
        Me.LblGroup.Name = "LblGroup"
        Me.LblGroup.Size = New System.Drawing.Size(49, 17)
        Me.LblGroup.TabIndex = 7
        Me.LblGroup.Text = "Grupo"
        '
        'TxtInternalName
        '
        Me.TxtInternalName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInternalName.Location = New System.Drawing.Point(6, 70)
        Me.TxtInternalName.MaxLength = 255
        Me.TxtInternalName.Name = "TxtInternalName"
        Me.TxtInternalName.Size = New System.Drawing.Size(594, 23)
        Me.TxtInternalName.TabIndex = 3
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(6, 24)
        Me.TxtName.MaxLength = 255
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(594, 23)
        Me.TxtName.TabIndex = 1
        '
        'LblFamily
        '
        Me.LblFamily.AutoSize = True
        Me.LblFamily.Location = New System.Drawing.Point(3, 96)
        Me.LblFamily.Name = "LblFamily"
        Me.LblFamily.Size = New System.Drawing.Size(54, 17)
        Me.LblFamily.TabIndex = 4
        Me.LblFamily.Text = "Família"
        '
        'LblInternalName
        '
        Me.LblInternalName.AutoSize = True
        Me.LblInternalName.Location = New System.Drawing.Point(3, 50)
        Me.LblInternalName.Name = "LblInternalName"
        Me.LblInternalName.Size = New System.Drawing.Size(97, 17)
        Me.LblInternalName.TabIndex = 2
        Me.LblInternalName.Text = "Nome Interno"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(3, 4)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Nome"
        '
        'TcProduct
        '
        Me.TcProduct.Controls.Add(Me.TabMain)
        Me.TcProduct.Controls.Add(Me.TabProductProviderCode)
        Me.TcProduct.Controls.Add(Me.TabProductCode)
        Me.TcProduct.Controls.Add(Me.TabPrice)
        Me.TcProduct.Controls.Add(Me.TabIndicator)
        Me.TcProduct.Controls.Add(Me.TabPicture)
        Me.TcProduct.Controls.Add(Me.TabNote)
        Me.TcProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcProduct.Location = New System.Drawing.Point(0, 50)
        Me.TcProduct.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcProduct.Multiline = True
        Me.TcProduct.Name = "TcProduct"
        Me.TcProduct.SelectedIndex = 0
        Me.TcProduct.Size = New System.Drawing.Size(614, 222)
        Me.TcProduct.TabIndex = 2
        '
        'TabPrice
        '
        Me.TabPrice.Controls.Add(Me.DgvPrice)
        Me.TabPrice.Controls.Add(Me.TsPrice)
        Me.TabPrice.Location = New System.Drawing.Point(4, 22)
        Me.TabPrice.Name = "TabPrice"
        Me.TabPrice.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPrice.Size = New System.Drawing.Size(606, 196)
        Me.TabPrice.TabIndex = 10
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
        Me.DgvPrice.Size = New System.Drawing.Size(600, 165)
        Me.DgvPrice.TabIndex = 4
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
        Me.TsPrice.Size = New System.Drawing.Size(600, 25)
        Me.TsPrice.TabIndex = 3
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
        'TabIndicator
        '
        Me.TabIndicator.Controls.Add(Me.DgvIndicator)
        Me.TabIndicator.Location = New System.Drawing.Point(4, 22)
        Me.TabIndicator.Name = "TabIndicator"
        Me.TabIndicator.Size = New System.Drawing.Size(606, 196)
        Me.TabIndicator.TabIndex = 9
        Me.TabIndicator.Text = "Indicadores"
        Me.TabIndicator.UseVisualStyleBackColor = True
        '
        'DgvIndicator
        '
        Me.DgvIndicator.AllowUserToAddRows = False
        Me.DgvIndicator.AllowUserToDeleteRows = False
        Me.DgvIndicator.AllowUserToOrderColumns = True
        Me.DgvIndicator.AllowUserToResizeRows = False
        Me.DgvIndicator.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvIndicator.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvIndicator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvIndicator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvIndicator.Location = New System.Drawing.Point(0, 0)
        Me.DgvIndicator.MultiSelect = False
        Me.DgvIndicator.Name = "DgvIndicator"
        Me.DgvIndicator.ReadOnly = True
        Me.DgvIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvIndicator.RowHeadersVisible = False
        Me.DgvIndicator.RowTemplate.Height = 26
        Me.DgvIndicator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvIndicator.Size = New System.Drawing.Size(606, 196)
        Me.DgvIndicator.TabIndex = 4
        '
        'TabPicture
        '
        Me.TabPicture.Controls.Add(Me.PvPicture)
        Me.TabPicture.Location = New System.Drawing.Point(4, 22)
        Me.TabPicture.Name = "TabPicture"
        Me.TabPicture.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPicture.Size = New System.Drawing.Size(606, 196)
        Me.TabPicture.TabIndex = 8
        Me.TabPicture.Text = "Fotos"
        Me.TabPicture.UseVisualStyleBackColor = True
        '
        'PvPicture
        '
        Me.PvPicture.ControlBarBackColor = System.Drawing.Color.White
        Me.PvPicture.CounterBarBackColor = System.Drawing.Color.White
        Me.PvPicture.CounterMask = "Foto {0} de {1} - Max {2}"
        Me.PvPicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PvPicture.FirstButtonImage = CType(resources.GetObject("PvPicture.FirstButtonImage"), System.Drawing.Image)
        Me.PvPicture.IncludeButtonImage = CType(resources.GetObject("PvPicture.IncludeButtonImage"), System.Drawing.Image)
        Me.PvPicture.LastButtonImage = CType(resources.GetObject("PvPicture.LastButtonImage"), System.Drawing.Image)
        Me.PvPicture.Location = New System.Drawing.Point(3, 3)
        Me.PvPicture.MaximumPictures = 5
        Me.PvPicture.Name = "PvPicture"
        Me.PvPicture.NextButtonImage = CType(resources.GetObject("PvPicture.NextButtonImage"), System.Drawing.Image)
        Me.PvPicture.Padding = New System.Windows.Forms.Padding(1)
        Me.PvPicture.PreviousButtonImage = CType(resources.GetObject("PvPicture.PreviousButtonImage"), System.Drawing.Image)
        Me.PvPicture.RemoveButtonImage = CType(resources.GetObject("PvPicture.RemoveButtonImage"), System.Drawing.Image)
        Me.PvPicture.SaveButtonImage = CType(resources.GetObject("PvPicture.SaveButtonImage"), System.Drawing.Image)
        Me.PvPicture.ShowControlBar = False
        Me.PvPicture.ShowCounterBar = True
        Me.PvPicture.Size = New System.Drawing.Size(600, 190)
        Me.PvPicture.TabIndex = 0
        Me.PvPicture.TempDirectory = ""
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
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'DgvlProviderCode
        '
        Me.DgvlProviderCode.DataGridView = Me.DgvProviderCode
        Me.DgvlProviderCode.Routine = Manager.Routine.ProductProviderCode
        '
        'DgvlCode
        '
        Me.DgvlCode.DataGridView = Me.DgvCode
        Me.DgvlCode.Routine = Manager.Routine.ProductCode
        '
        'DgvlIndicator
        '
        Me.DgvlIndicator.DataGridView = Me.DgvIndicator
        Me.DgvlIndicator.Routine = Manager.Routine.ProductPriceIndicator
        '
        'DgvlPrice
        '
        Me.DgvlPrice.DataGridView = Me.DgvPrice
        Me.DgvlPrice.Routine = Manager.Routine.ProductPrice
        '
        'FrmProduct
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(614, 316)
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
        Me.Name = "FrmProduct"
        Me.ShowIcon = False
        Me.Text = "Produto"
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNote.ResumeLayout(False)
        Me.TabProductCode.ResumeLayout(False)
        Me.TabProductCode.PerformLayout()
        CType(Me.DgvCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsCode.ResumeLayout(False)
        Me.TsCode.PerformLayout()
        Me.TabProductProviderCode.ResumeLayout(False)
        Me.TabProductProviderCode.PerformLayout()
        CType(Me.DgvProviderCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsProviderCode.ResumeLayout(False)
        Me.TsProviderCode.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.FlpGroup.ResumeLayout(False)
        Me.FlpFamily.ResumeLayout(False)
        Me.TcProduct.ResumeLayout(False)
        Me.TabPrice.ResumeLayout(False)
        Me.TabPrice.PerformLayout()
        CType(Me.DgvPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsPrice.ResumeLayout(False)
        Me.TsPrice.PerformLayout()
        Me.TabIndicator.ResumeLayout(False)
        CType(Me.DgvIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPicture.ResumeLayout(False)
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
    Friend WithEvents TabProductProviderCode As TabPage
    Friend WithEvents TabProductCode As TabPage
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents DgvlProviderCode As DataGridViewLayout
    Friend WithEvents DgvProviderCode As DataGridView
    Friend WithEvents TsProviderCode As ToolStrip
    Friend WithEvents BtnIncludeProviderCode As ToolStripButton
    Friend WithEvents BtnEditProviderCode As ToolStripButton
    Friend WithEvents BtnDeleteProviderCode As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents TxtFilterProviderCode As ToolStripTextBox
    Friend WithEvents DgvlCode As DataGridViewLayout
    Friend WithEvents QbxFamily As ControlLibrary.QueriedBox
    Friend WithEvents LblGroup As Label
    Friend WithEvents LblFamily As Label
    Friend WithEvents TxtInternalName As TextBox
    Friend WithEvents LblInternalName As Label
    Friend WithEvents QbxUnit As ControlLibrary.QueriedBox
    Friend WithEvents LblUnit As Label
    Friend WithEvents DbxNetWeight As ControlLibrary.DecimalBox
    Friend WithEvents Label9 As Label
    Friend WithEvents DbxGrossWeight As ControlLibrary.DecimalBox
    Friend WithEvents LblGrossWeight As Label
    Friend WithEvents DbxQtyMax As ControlLibrary.DecimalBox
    Friend WithEvents Label7 As Label
    Friend WithEvents DbxQtyMin As ControlLibrary.DecimalBox
    Friend WithEvents LblQtyMin As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtLocation As TextBox
    Friend WithEvents BtnNewFamily As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNewGroup As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewFamily As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewGroup As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterFamily As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterGroup As ControlLibrary.NoFocusCueButton
    Friend WithEvents QbxGroup As ControlLibrary.QueriedBox
    Friend WithEvents TmrQueriedBoxFamily As Timer
    Friend WithEvents TmrQueriedBoxGroup As Timer
    Friend WithEvents TabPicture As TabPage
    Friend WithEvents FlpGroup As FlowLayoutPanel
    Friend WithEvents FlpFamily As FlowLayoutPanel
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents TabPrice As TabPage
    Friend WithEvents TabIndicator As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtDimensions As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtSKU As TextBox
    Friend WithEvents DgvIndicator As DataGridView
    Friend WithEvents DgvCode As DataGridView
    Friend WithEvents TsCode As ToolStrip
    Friend WithEvents BtnIncludeCode As ToolStripButton
    Friend WithEvents BtnEditCode As ToolStripButton
    Friend WithEvents BtnDeleteCode As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TxtFilterCode As ToolStripTextBox
    Friend WithEvents DgvPrice As DataGridView
    Friend WithEvents TsPrice As ToolStrip
    Friend WithEvents BtnIncludePrice As ToolStripButton
    Friend WithEvents BtnEditPrice As ToolStripButton
    Friend WithEvents BtnDeletePrice As ToolStripButton
    Friend WithEvents LblFilterPrice As ToolStripLabel
    Friend WithEvents TxtFilterPrice As ToolStripTextBox
    Friend WithEvents DgvlIndicator As DataGridViewLayout
    Friend WithEvents DgvlPrice As DataGridViewLayout
    Friend WithEvents PvPicture As ControlLibrary.PictureViewer
End Class
