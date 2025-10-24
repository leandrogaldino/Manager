<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCashItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCashItem))
        Me.TsMain = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.LblDescription = New System.Windows.Forms.Label()
        Me.LblDocumentNumber = New System.Windows.Forms.Label()
        Me.LblDocumentDate = New System.Windows.Forms.Label()
        Me.LblValue = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DgvResponsible = New System.Windows.Forms.DataGridView()
        Me.TsResponsibles = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCashItemResponsible = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCashItemResponsible = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCashItemResponsible = New System.Windows.Forms.ToolStripButton()
        Me.TxtDocumentNumber = New System.Windows.Forms.TextBox()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.DbxValue = New ControlLibrary.DecimalBox()
        Me.DbxDocumentDate = New ControlLibrary.DateBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.RbIncome = New System.Windows.Forms.RadioButton()
        Me.RbExpense = New System.Windows.Forms.RadioButton()
        Me.CbxCategory = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvlResponsible = New Manager.DataGridViewLayout()
        Me.TsMain.SuspendLayout()
        Me.TsData.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DgvResponsible, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsResponsibles.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TsMain
        '
        Me.TsMain.AutoSize = False
        Me.TsMain.BackColor = System.Drawing.Color.White
        Me.TsMain.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog})
        Me.TsMain.Location = New System.Drawing.Point(0, 0)
        Me.TsMain.Name = "TsMain"
        Me.TsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMain.Size = New System.Drawing.Size(353, 25)
        Me.TsMain.TabIndex = 0
        Me.TsMain.Text = "ToolStrip2"
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Lançamento"
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
        Me.BtnDelete.Text = "Excluir Lançamento"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Lançamento"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Lançamento Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Lançamento"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Lançamento"
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
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(353, 25)
        Me.TsData.TabIndex = 1
        Me.TsData.Text = "ToolStrip1"
        '
        'LblOrder
        '
        Me.LblOrder.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrder.Name = "LblOrder"
        Me.LblOrder.Size = New System.Drawing.Size(56, 22)
        Me.LblOrder.Text = "Ordem:"
        '
        'LblOrderValue
        '
        Me.LblOrderValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblOrderValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblOrderValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblOrderValue.Name = "LblOrderValue"
        Me.LblOrderValue.Size = New System.Drawing.Size(40, 22)
        Me.LblOrderValue.Text = "        "
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 431)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(353, 44)
        Me.Panel1.TabIndex = 4
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(145, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Incluir"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(246, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Location = New System.Drawing.Point(3, 19)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(72, 17)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Descrição"
        '
        'LblDocumentNumber
        '
        Me.LblDocumentNumber.AutoSize = True
        Me.LblDocumentNumber.Location = New System.Drawing.Point(3, 65)
        Me.LblDocumentNumber.Name = "LblDocumentNumber"
        Me.LblDocumentNumber.Size = New System.Drawing.Size(58, 17)
        Me.LblDocumentNumber.TabIndex = 2
        Me.LblDocumentNumber.Text = "Nº Doc."
        '
        'LblDocumentDate
        '
        Me.LblDocumentDate.AutoSize = True
        Me.LblDocumentDate.Location = New System.Drawing.Point(115, 65)
        Me.LblDocumentDate.Name = "LblDocumentDate"
        Me.LblDocumentDate.Size = New System.Drawing.Size(76, 17)
        Me.LblDocumentDate.TabIndex = 4
        Me.LblDocumentDate.Text = "Data Doc."
        '
        'LblValue
        '
        Me.LblValue.AutoSize = True
        Me.LblValue.Location = New System.Drawing.Point(215, 65)
        Me.LblValue.Name = "LblValue"
        Me.LblValue.Size = New System.Drawing.Size(42, 17)
        Me.LblValue.TabIndex = 6
        Me.LblValue.Text = "Valor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.TxtDocumentNumber)
        Me.GroupBox1.Controls.Add(Me.TxtDescription)
        Me.GroupBox1.Controls.Add(Me.DbxValue)
        Me.GroupBox1.Controls.Add(Me.DbxDocumentDate)
        Me.GroupBox1.Controls.Add(Me.LblValue)
        Me.GroupBox1.Controls.Add(Me.LblDocumentDate)
        Me.GroupBox1.Controls.Add(Me.LblDocumentNumber)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LblDescription)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 296)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lançamento"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DgvResponsible)
        Me.Panel2.Controls.Add(Me.TsResponsibles)
        Me.Panel2.Location = New System.Drawing.Point(6, 131)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 159)
        Me.Panel2.TabIndex = 13
        '
        'DgvResponsible
        '
        Me.DgvResponsible.AllowUserToAddRows = False
        Me.DgvResponsible.AllowUserToDeleteRows = False
        Me.DgvResponsible.AllowUserToOrderColumns = True
        Me.DgvResponsible.AllowUserToResizeRows = False
        Me.DgvResponsible.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvResponsible.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvResponsible.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvResponsible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResponsible.ColumnHeadersVisible = False
        Me.DgvResponsible.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvResponsible.Location = New System.Drawing.Point(0, 25)
        Me.DgvResponsible.MultiSelect = False
        Me.DgvResponsible.Name = "DgvResponsible"
        Me.DgvResponsible.ReadOnly = True
        Me.DgvResponsible.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvResponsible.RowHeadersVisible = False
        Me.DgvResponsible.RowTemplate.Height = 26
        Me.DgvResponsible.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvResponsible.Size = New System.Drawing.Size(316, 132)
        Me.DgvResponsible.TabIndex = 1
        '
        'TsResponsibles
        '
        Me.TsResponsibles.BackColor = System.Drawing.Color.White
        Me.TsResponsibles.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsResponsibles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsResponsibles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCashItemResponsible, Me.BtnEditCashItemResponsible, Me.BtnDeleteCashItemResponsible})
        Me.TsResponsibles.Location = New System.Drawing.Point(0, 0)
        Me.TsResponsibles.Name = "TsResponsibles"
        Me.TsResponsibles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsResponsibles.Size = New System.Drawing.Size(316, 25)
        Me.TsResponsibles.TabIndex = 0
        Me.TsResponsibles.Text = "ToolStrip2"
        '
        'BtnIncludeCashItemResponsible
        '
        Me.BtnIncludeCashItemResponsible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeCashItemResponsible.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeCashItemResponsible.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeCashItemResponsible.Name = "BtnIncludeCashItemResponsible"
        Me.BtnIncludeCashItemResponsible.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeCashItemResponsible.Text = "Incluir Responsável"
        Me.BtnIncludeCashItemResponsible.ToolTipText = "Incluir Responsável"
        '
        'BtnEditCashItemResponsible
        '
        Me.BtnEditCashItemResponsible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditCashItemResponsible.Enabled = False
        Me.BtnEditCashItemResponsible.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditCashItemResponsible.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditCashItemResponsible.Name = "BtnEditCashItemResponsible"
        Me.BtnEditCashItemResponsible.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditCashItemResponsible.Text = "Editar Responsável"
        Me.BtnEditCashItemResponsible.ToolTipText = "Editar Responsável"
        '
        'BtnDeleteCashItemResponsible
        '
        Me.BtnDeleteCashItemResponsible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteCashItemResponsible.Enabled = False
        Me.BtnDeleteCashItemResponsible.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteCashItemResponsible.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteCashItemResponsible.Name = "BtnDeleteCashItemResponsible"
        Me.BtnDeleteCashItemResponsible.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteCashItemResponsible.Text = "Excluir Responsável"
        Me.BtnDeleteCashItemResponsible.ToolTipText = "Excluir Responsável"
        '
        'TxtDocumentNumber
        '
        Me.TxtDocumentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocumentNumber.Location = New System.Drawing.Point(6, 85)
        Me.TxtDocumentNumber.MaxLength = 30
        Me.TxtDocumentNumber.Name = "TxtDocumentNumber"
        Me.TxtDocumentNumber.Size = New System.Drawing.Size(106, 23)
        Me.TxtDocumentNumber.TabIndex = 3
        '
        'TxtDescription
        '
        Me.TxtDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TxtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescription.Location = New System.Drawing.Point(6, 39)
        Me.TxtDescription.MaxLength = 255
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(318, 23)
        Me.TxtDescription.TabIndex = 1
        '
        'DbxValue
        '
        Me.DbxValue.DecimalOnly = True
        Me.DbxValue.DecimalPlaces = 2
        Me.DbxValue.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxValue.Location = New System.Drawing.Point(224, 85)
        Me.DbxValue.MaxLength = 13
        Me.DbxValue.Name = "DbxValue"
        Me.DbxValue.Size = New System.Drawing.Size(100, 23)
        Me.DbxValue.TabIndex = 7
        Me.DbxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DbxDocumentDate
        '
        Me.DbxDocumentDate.ButtonImage = CType(resources.GetObject("DbxDocumentDate.ButtonImage"), System.Drawing.Image)
        Me.DbxDocumentDate.Date = Nothing
        Me.DbxDocumentDate.Location = New System.Drawing.Point(118, 85)
        Me.DbxDocumentDate.MinimumSize = New System.Drawing.Size(100, 0)
        Me.DbxDocumentDate.Name = "DbxDocumentDate"
        Me.DbxDocumentDate.Size = New System.Drawing.Size(100, 23)
        Me.DbxDocumentDate.TabIndex = 5
        Me.DbxDocumentDate.Text = "  /  /"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Responsáveis"
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'RbIncome
        '
        Me.RbIncome.AutoSize = True
        Me.RbIncome.Location = New System.Drawing.Point(92, 33)
        Me.RbIncome.Name = "RbIncome"
        Me.RbIncome.Size = New System.Drawing.Size(75, 21)
        Me.RbIncome.TabIndex = 1
        Me.RbIncome.Text = "Receita"
        Me.RbIncome.UseVisualStyleBackColor = True
        '
        'RbExpense
        '
        Me.RbExpense.AutoSize = True
        Me.RbExpense.Checked = True
        Me.RbExpense.Location = New System.Drawing.Point(6, 33)
        Me.RbExpense.Name = "RbExpense"
        Me.RbExpense.Size = New System.Drawing.Size(80, 21)
        Me.RbExpense.TabIndex = 0
        Me.RbExpense.TabStop = True
        Me.RbExpense.Text = "Despesa"
        Me.RbExpense.UseVisualStyleBackColor = True
        '
        'CbxCategory
        '
        Me.CbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCategory.FormattingEnabled = True
        Me.CbxCategory.Location = New System.Drawing.Point(173, 33)
        Me.CbxCategory.Name = "CbxCategory"
        Me.CbxCategory.Size = New System.Drawing.Size(151, 25)
        Me.CbxCategory.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbExpense)
        Me.GroupBox2.Controls.Add(Me.CbxCategory)
        Me.GroupBox2.Controls.Add(Me.RbIncome)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 68)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Identificação"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(170, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Categoria"
        '
        'DgvlResponsible
        '
        Me.DgvlResponsible.DataGridView = Me.DgvResponsible
        Me.DgvlResponsible.Routine = Manager.Routine.CashItemResponsible
        '
        'FrmCashItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(353, 475)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.TsMain)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCashItem"
        Me.ShowIcon = False
        Me.Text = "Lançamento do Caixa"
        Me.TsMain.ResumeLayout(False)
        Me.TsMain.PerformLayout()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DgvResponsible, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsResponsibles.ResumeLayout(False)
        Me.TsResponsibles.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TsMain As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents LblDescription As Label
    Friend WithEvents LblDocumentNumber As Label
    Friend WithEvents LblDocumentDate As Label
    Friend WithEvents LblValue As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DbxValue As ControlLibrary.DecimalBox
    Friend WithEvents DbxDocumentDate As ControlLibrary.DateBox
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents TxtDescription As TextBox
    Friend WithEvents TxtDocumentNumber As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DgvResponsible As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TsResponsibles As ToolStrip
    Friend WithEvents BtnIncludeCashItemResponsible As ToolStripButton
    Friend WithEvents BtnDeleteCashItemResponsible As ToolStripButton
    Friend WithEvents BtnEditCashItemResponsible As ToolStripButton
    Friend WithEvents RbIncome As RadioButton
    Friend WithEvents RbExpense As RadioButton
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents DgvlResponsible As DataGridViewLayout
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CbxCategory As ComboBox
    Friend WithEvents Label1 As Label
End Class
