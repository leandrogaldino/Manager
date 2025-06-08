<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPriceTable
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
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TabSellable = New System.Windows.Forms.TabPage()
        Me.DgvPriceTableSellable = New System.Windows.Forms.DataGridView()
        Me.TsComplement = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludePriceTableSellable = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditPriceTableSellable = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePriceTableSellable = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterPriceTableSellable = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterPriceTableSellable = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnIncludeCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCode = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterDescription = New System.Windows.Forms.ToolStripTextBox()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TcPriceTable = New System.Windows.Forms.TabControl()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.DgvPriceTableItemLayout = New Manager.DataGridViewLayout()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSellable.SuspendLayout()
        CType(Me.DgvPriceTableSellable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsComplement.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TcPriceTable.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsNavigation.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(277, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(176, 7)
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
        Me.BtnInclude.Text = "Incluir Tabela de Preços"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Tabela de Preços"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Tabela de Preços"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Tabela de Preços Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Tabela de Preços"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Tabela de Preços"
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.White
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 142)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(384, 44)
        Me.PnButtons.TabIndex = 3
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
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
        'TabSellable
        '
        Me.TabSellable.Controls.Add(Me.DgvPriceTableSellable)
        Me.TabSellable.Controls.Add(Me.TsComplement)
        Me.TabSellable.Location = New System.Drawing.Point(4, 26)
        Me.TabSellable.Name = "TabSellable"
        Me.TabSellable.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSellable.Size = New System.Drawing.Size(376, 62)
        Me.TabSellable.TabIndex = 7
        Me.TabSellable.Text = "Produtos/Serviços"
        Me.TabSellable.UseVisualStyleBackColor = True
        '
        'DgvPriceTableSellable
        '
        Me.DgvPriceTableSellable.AllowUserToAddRows = False
        Me.DgvPriceTableSellable.AllowUserToDeleteRows = False
        Me.DgvPriceTableSellable.AllowUserToOrderColumns = True
        Me.DgvPriceTableSellable.AllowUserToResizeRows = False
        Me.DgvPriceTableSellable.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPriceTableSellable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPriceTableSellable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPriceTableSellable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPriceTableSellable.Location = New System.Drawing.Point(3, 28)
        Me.DgvPriceTableSellable.MultiSelect = False
        Me.DgvPriceTableSellable.Name = "DgvPriceTableSellable"
        Me.DgvPriceTableSellable.ReadOnly = True
        Me.DgvPriceTableSellable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPriceTableSellable.RowHeadersVisible = False
        Me.DgvPriceTableSellable.RowTemplate.Height = 26
        Me.DgvPriceTableSellable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPriceTableSellable.Size = New System.Drawing.Size(370, 31)
        Me.DgvPriceTableSellable.TabIndex = 1
        '
        'TsComplement
        '
        Me.TsComplement.BackColor = System.Drawing.Color.Transparent
        Me.TsComplement.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsComplement.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsComplement.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludePriceTableSellable, Me.BtnEditPriceTableSellable, Me.BtnDeletePriceTableSellable, Me.LblFilterPriceTableSellable, Me.TxtFilterPriceTableSellable})
        Me.TsComplement.Location = New System.Drawing.Point(3, 3)
        Me.TsComplement.Name = "TsComplement"
        Me.TsComplement.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsComplement.Size = New System.Drawing.Size(370, 25)
        Me.TsComplement.TabIndex = 0
        Me.TsComplement.Text = "ToolStrip2"
        '
        'BtnIncludePriceTableSellable
        '
        Me.BtnIncludePriceTableSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludePriceTableSellable.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludePriceTableSellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludePriceTableSellable.Name = "BtnIncludePriceTableSellable"
        Me.BtnIncludePriceTableSellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludePriceTableSellable.Text = "Incluir Produto/Serviço"
        '
        'BtnEditPriceTableSellable
        '
        Me.BtnEditPriceTableSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditPriceTableSellable.Enabled = False
        Me.BtnEditPriceTableSellable.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditPriceTableSellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditPriceTableSellable.Name = "BtnEditPriceTableSellable"
        Me.BtnEditPriceTableSellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditPriceTableSellable.Text = "Editar Produto/Serviço"
        Me.BtnEditPriceTableSellable.ToolTipText = "Editar"
        '
        'BtnDeletePriceTableSellable
        '
        Me.BtnDeletePriceTableSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeletePriceTableSellable.Enabled = False
        Me.BtnDeletePriceTableSellable.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeletePriceTableSellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeletePriceTableSellable.Name = "BtnDeletePriceTableSellable"
        Me.BtnDeletePriceTableSellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeletePriceTableSellable.Text = "Excluir Produto/Serviço"
        '
        'LblFilterPriceTableSellable
        '
        Me.LblFilterPriceTableSellable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LblFilterPriceTableSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblFilterPriceTableSellable.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.LblFilterPriceTableSellable.Name = "LblFilterPriceTableSellable"
        Me.LblFilterPriceTableSellable.Size = New System.Drawing.Size(46, 25)
        Me.LblFilterPriceTableSellable.Text = "Filtrar:"
        '
        'TxtFilterPriceTableSellable
        '
        Me.TxtFilterPriceTableSellable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterPriceTableSellable.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterPriceTableSellable.Name = "TxtFilterPriceTableSellable"
        Me.TxtFilterPriceTableSellable.Size = New System.Drawing.Size(200, 25)
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
        Me.TabMain.Controls.Add(Me.TxtName)
        Me.TabMain.Controls.Add(Me.LblName)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(376, 62)
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
        Me.TxtName.Size = New System.Drawing.Size(359, 23)
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
        'TcPriceTable
        '
        Me.TcPriceTable.Controls.Add(Me.TabMain)
        Me.TcPriceTable.Controls.Add(Me.TabSellable)
        Me.TcPriceTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcPriceTable.Location = New System.Drawing.Point(0, 50)
        Me.TcPriceTable.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcPriceTable.Multiline = True
        Me.TcPriceTable.Name = "TcPriceTable"
        Me.TcPriceTable.SelectedIndex = 0
        Me.TcPriceTable.Size = New System.Drawing.Size(384, 92)
        Me.TcPriceTable.TabIndex = 2
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
        Me.TsNavigation.Size = New System.Drawing.Size(384, 25)
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
        Me.TsTitle.Size = New System.Drawing.Size(384, 25)
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
        'DgvPriceTableItemLayout
        '
        Me.DgvPriceTableItemLayout.DataGridView = Me.DgvPriceTableSellable
        Me.DgvPriceTableItemLayout.Routine = Manager.Routine.PriceTableItem
        '
        'FrmPriceTable
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(384, 186)
        Me.Controls.Add(Me.TcPriceTable)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPriceTable"
        Me.ShowIcon = False
        Me.Text = "Tabela de Preços"
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSellable.ResumeLayout(False)
        Me.TabSellable.PerformLayout()
        CType(Me.DgvPriceTableSellable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsComplement.ResumeLayout(False)
        Me.TsComplement.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.TcPriceTable.ResumeLayout(False)
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
    Friend WithEvents TcPriceTable As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents TabSellable As TabPage
    Friend WithEvents DgvPriceTableSellable As DataGridView
    Friend WithEvents BtnIncludeCode As ToolStripButton
    Friend WithEvents BtnEditCode As ToolStripButton
    Friend WithEvents BtnDeleteCode As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TxtFilterDescription As ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents DgvPriceTableItemLayout As DataGridViewLayout
    Friend WithEvents TsComplement As ToolStrip
    Friend WithEvents BtnIncludePriceTableSellable As ToolStripButton
    Friend WithEvents BtnEditPriceTableSellable As ToolStripButton
    Friend WithEvents BtnDeletePriceTableSellable As ToolStripButton
    Friend WithEvents LblFilterPriceTableSellable As ToolStripLabel
    Friend WithEvents TxtFilterPriceTableSellable As ToolStripTextBox
End Class
