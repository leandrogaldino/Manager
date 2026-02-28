<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPersonCompressor
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
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPersonCompressor))
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsMain = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.BtnImport = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCompressor = New System.Windows.Forms.Label()
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.QbxCompressor = New ControlLibrary.QueriedBox()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.TxtSector = New System.Windows.Forms.TextBox()
        Me.TxtPatrimony = New System.Windows.Forms.TextBox()
        Me.TxtSerialNumber = New System.Windows.Forms.TextBox()
        Me.TcPersonCompressor = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.CbxControlled = New ControlLibrary.CentralizedComboBox()
        Me.DbxUnitCapacity = New ControlLibrary.DecimalBox()
        Me.FlpCompressor = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.LblControlled = New System.Windows.Forms.Label()
        Me.LblUnitCapacity = New System.Windows.Forms.Label()
        Me.TabMaintenance = New System.Windows.Forms.TabPage()
        Me.TcMaintenance = New System.Windows.Forms.TabControl()
        Me.TabWorkedHourSellable = New System.Windows.Forms.TabPage()
        Me.DgvWorkedHourSellable = New System.Windows.Forms.DataGridView()
        Me.TsWorkedHourSellable = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeWorkedHourSellable = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditWorkedHourSellable = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteWorkedHourSellable = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterWorkedHourSellable = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterWorkedHourSellable = New System.Windows.Forms.ToolStripTextBox()
        Me.TabElapsedDaySellable = New System.Windows.Forms.TabPage()
        Me.DgvElapsedDaySellable = New System.Windows.Forms.DataGridView()
        Me.TsElapsedDaySellable = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeElapsedDaySellable = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditElapsedDaySellable = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteElapsedDaySellable = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterElapsedDaySellable = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterElapsedDaySellable = New System.Windows.Forms.ToolStripTextBox()
        Me.TabNote = New System.Windows.Forms.TabPage()
        Me.TxtNote = New System.Windows.Forms.RichTextBox()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DgvlWorkedHourSellable = New Manager.DataGridViewLayout()
        Me.DgvlElapsedDaySellable = New Manager.DataGridViewLayout()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TsMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TsData.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcPersonCompressor.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.FlpCompressor.SuspendLayout()
        Me.TabMaintenance.SuspendLayout()
        Me.TcMaintenance.SuspendLayout()
        Me.TabWorkedHourSellable.SuspendLayout()
        CType(Me.DgvWorkedHourSellable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsWorkedHourSellable.SuspendLayout()
        Me.TabElapsedDaySellable.SuspendLayout()
        CType(Me.DgvElapsedDaySellable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsElapsedDaySellable.SuspendLayout()
        Me.TabNote.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(232, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(131, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Incluir"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsMain
        '
        Me.TsMain.AutoSize = False
        Me.TsMain.BackColor = System.Drawing.Color.White
        Me.TsMain.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog, Me.BtnImport})
        Me.TsMain.Location = New System.Drawing.Point(0, 0)
        Me.TsMain.Name = "TsMain"
        Me.TsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMain.Size = New System.Drawing.Size(339, 25)
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
        Me.BtnInclude.Text = "Incluir Compressor"
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
        Me.BtnDelete.Text = "Excluir Compressor"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Compressor"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Compressor Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Compressor"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Compressor"
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
        'BtnImport
        '
        Me.BtnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnImport.Image = Global.Manager.My.Resources.Resources.ImportSmall
        Me.BtnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(23, 22)
        Me.BtnImport.Text = "Importar Itens do Compressor"
        Me.BtnImport.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 227)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(339, 44)
        Me.Panel1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Setor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(112, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 17)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Patrimônio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nº de Série"
        '
        'LblCompressor
        '
        Me.LblCompressor.AutoSize = True
        Me.LblCompressor.Location = New System.Drawing.Point(6, 4)
        Me.LblCompressor.Name = "LblCompressor"
        Me.LblCompressor.Size = New System.Drawing.Size(85, 17)
        Me.LblCompressor.TabIndex = 0
        Me.LblCompressor.Text = "Compressor"
        '
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(339, 25)
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
        'QbxCompressor
        '
        Me.QbxCompressor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCompressor.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "compressor"
        Condition1.Value = "@statusid"
        Me.QbxCompressor.Conditions.Add(Condition1)
        Me.QbxCompressor.DebugOnTextChanged = False
        Me.QbxCompressor.DisplayFieldAlias = "NOME"
        Me.QbxCompressor.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxCompressor.DisplayFieldName = "name"
        Me.QbxCompressor.DisplayMainFieldName = "id"
        Me.QbxCompressor.DisplayTableAlias = Nothing
        Me.QbxCompressor.DisplayTableName = "compressor"
        Me.QbxCompressor.Distinct = False
        Me.QbxCompressor.DropDownAutoStretchRight = False
        Me.QbxCompressor.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCompressor.IfNull = Nothing
        Me.QbxCompressor.Location = New System.Drawing.Point(9, 24)
        Me.QbxCompressor.MainReturnFieldName = "id"
        Me.QbxCompressor.MainTableAlias = Nothing
        Me.QbxCompressor.MainTableName = "compressor"
        Me.QbxCompressor.Name = "QbxCompressor"
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Me.QbxCompressor.Parameters.Add(Parameter1)
        Me.QbxCompressor.Prefix = Nothing
        Me.QbxCompressor.Size = New System.Drawing.Size(206, 23)
        Me.QbxCompressor.Suffix = Nothing
        Me.QbxCompressor.TabIndex = 1
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'TxtSector
        '
        Me.TxtSector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSector.Location = New System.Drawing.Point(221, 112)
        Me.TxtSector.MaxLength = 50
        Me.TxtSector.Name = "TxtSector"
        Me.TxtSector.Size = New System.Drawing.Size(100, 23)
        Me.TxtSector.TabIndex = 10
        '
        'TxtPatrimony
        '
        Me.TxtPatrimony.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPatrimony.Location = New System.Drawing.Point(115, 112)
        Me.TxtPatrimony.MaxLength = 50
        Me.TxtPatrimony.Name = "TxtPatrimony"
        Me.TxtPatrimony.Size = New System.Drawing.Size(100, 23)
        Me.TxtPatrimony.TabIndex = 8
        Me.TxtPatrimony.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerialNumber
        '
        Me.TxtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerialNumber.Location = New System.Drawing.Point(9, 112)
        Me.TxtSerialNumber.MaxLength = 50
        Me.TxtSerialNumber.Name = "TxtSerialNumber"
        Me.TxtSerialNumber.Size = New System.Drawing.Size(100, 23)
        Me.TxtSerialNumber.TabIndex = 6
        Me.TxtSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TcPersonCompressor
        '
        Me.TcPersonCompressor.Controls.Add(Me.TabMain)
        Me.TcPersonCompressor.Controls.Add(Me.TabMaintenance)
        Me.TcPersonCompressor.Controls.Add(Me.TabNote)
        Me.TcPersonCompressor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcPersonCompressor.Location = New System.Drawing.Point(0, 50)
        Me.TcPersonCompressor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcPersonCompressor.Multiline = True
        Me.TcPersonCompressor.Name = "TcPersonCompressor"
        Me.TcPersonCompressor.SelectedIndex = 0
        Me.TcPersonCompressor.Size = New System.Drawing.Size(339, 177)
        Me.TcPersonCompressor.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.CbxControlled)
        Me.TabMain.Controls.Add(Me.DbxUnitCapacity)
        Me.TabMain.Controls.Add(Me.FlpCompressor)
        Me.TabMain.Controls.Add(Me.LblControlled)
        Me.TabMain.Controls.Add(Me.LblCompressor)
        Me.TabMain.Controls.Add(Me.Label3)
        Me.TabMain.Controls.Add(Me.LblUnitCapacity)
        Me.TabMain.Controls.Add(Me.Label8)
        Me.TabMain.Controls.Add(Me.QbxCompressor)
        Me.TabMain.Controls.Add(Me.TextBox2)
        Me.TabMain.Controls.Add(Me.TextBox1)
        Me.TabMain.Controls.Add(Me.TxtSerialNumber)
        Me.TabMain.Controls.Add(Me.Label4)
        Me.TabMain.Controls.Add(Me.Label2)
        Me.TabMain.Controls.Add(Me.Label1)
        Me.TabMain.Controls.Add(Me.TxtSector)
        Me.TabMain.Controls.Add(Me.TxtPatrimony)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(331, 147)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'CbxControlled
        '
        Me.CbxControlled.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxControlled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxControlled.FormattingEnabled = True
        Me.CbxControlled.Location = New System.Drawing.Point(221, 23)
        Me.CbxControlled.Name = "CbxControlled"
        Me.CbxControlled.Size = New System.Drawing.Size(100, 24)
        Me.CbxControlled.TabIndex = 4
        '
        'DbxUnitCapacity
        '
        Me.DbxUnitCapacity.DecimalOnly = True
        Me.DbxUnitCapacity.DecimalPlaces = 0
        Me.DbxUnitCapacity.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxUnitCapacity.Location = New System.Drawing.Point(221, 68)
        Me.DbxUnitCapacity.Name = "DbxUnitCapacity"
        Me.DbxUnitCapacity.Size = New System.Drawing.Size(100, 23)
        Me.DbxUnitCapacity.TabIndex = 12
        Me.DbxUnitCapacity.Text = "0"
        Me.DbxUnitCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FlpCompressor
        '
        Me.FlpCompressor.Controls.Add(Me.BtnFilter)
        Me.FlpCompressor.Controls.Add(Me.BtnView)
        Me.FlpCompressor.Controls.Add(Me.BtnNew)
        Me.FlpCompressor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCompressor.Location = New System.Drawing.Point(145, 3)
        Me.FlpCompressor.Name = "FlpCompressor"
        Me.FlpCompressor.Size = New System.Drawing.Size(69, 21)
        Me.FlpCompressor.TabIndex = 2
        '
        'BtnFilter
        '
        Me.BtnFilter.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilter.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilter.FlatAppearance.BorderSize = 0
        Me.BtnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilter.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilter.Name = "BtnFilter"
        Me.BtnFilter.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilter.TabIndex = 2
        Me.BtnFilter.TabStop = False
        Me.BtnFilter.TooltipText = ""
        Me.BtnFilter.UseVisualStyleBackColor = False
        Me.BtnFilter.Visible = False
        '
        'BtnView
        '
        Me.BtnView.BackColor = System.Drawing.Color.Transparent
        Me.BtnView.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnView.FlatAppearance.BorderSize = 0
        Me.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnView.Location = New System.Drawing.Point(26, 3)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(17, 17)
        Me.BtnView.TabIndex = 1
        Me.BtnView.TabStop = False
        Me.BtnView.TooltipText = ""
        Me.BtnView.UseVisualStyleBackColor = False
        Me.BtnView.Visible = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnNew.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Location = New System.Drawing.Point(3, 3)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(17, 17)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.TabStop = False
        Me.BtnNew.TooltipText = ""
        Me.BtnNew.UseVisualStyleBackColor = False
        Me.BtnNew.Visible = False
        '
        'LblControlled
        '
        Me.LblControlled.AutoSize = True
        Me.LblControlled.Location = New System.Drawing.Point(218, 3)
        Me.LblControlled.Name = "LblControlled"
        Me.LblControlled.Size = New System.Drawing.Size(84, 17)
        Me.LblControlled.TabIndex = 3
        Me.LblControlled.Text = "Controlado"
        '
        'LblUnitCapacity
        '
        Me.LblUnitCapacity.AutoSize = True
        Me.LblUnitCapacity.Location = New System.Drawing.Point(218, 48)
        Me.LblUnitCapacity.Name = "LblUnitCapacity"
        Me.LblUnitCapacity.Size = New System.Drawing.Size(74, 17)
        Me.LblUnitCapacity.TabIndex = 11
        Me.LblUnitCapacity.Text = "Cap. Und."
        '
        'TabMaintenance
        '
        Me.TabMaintenance.Controls.Add(Me.TcMaintenance)
        Me.TabMaintenance.Location = New System.Drawing.Point(4, 22)
        Me.TabMaintenance.Name = "TabMaintenance"
        Me.TabMaintenance.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMaintenance.Size = New System.Drawing.Size(451, 106)
        Me.TabMaintenance.TabIndex = 8
        Me.TabMaintenance.Text = "Manutenção"
        Me.TabMaintenance.UseVisualStyleBackColor = True
        '
        'TcMaintenance
        '
        Me.TcMaintenance.Controls.Add(Me.TabWorkedHourSellable)
        Me.TcMaintenance.Controls.Add(Me.TabElapsedDaySellable)
        Me.TcMaintenance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcMaintenance.Location = New System.Drawing.Point(3, 3)
        Me.TcMaintenance.Name = "TcMaintenance"
        Me.TcMaintenance.SelectedIndex = 0
        Me.TcMaintenance.Size = New System.Drawing.Size(445, 100)
        Me.TcMaintenance.TabIndex = 0
        '
        'TabWorkedHourSellable
        '
        Me.TabWorkedHourSellable.Controls.Add(Me.DgvWorkedHourSellable)
        Me.TabWorkedHourSellable.Controls.Add(Me.TsWorkedHourSellable)
        Me.TabWorkedHourSellable.Location = New System.Drawing.Point(4, 26)
        Me.TabWorkedHourSellable.Name = "TabWorkedHourSellable"
        Me.TabWorkedHourSellable.Padding = New System.Windows.Forms.Padding(3)
        Me.TabWorkedHourSellable.Size = New System.Drawing.Size(437, 70)
        Me.TabWorkedHourSellable.TabIndex = 6
        Me.TabWorkedHourSellable.Text = "Hora Trabalhada"
        Me.TabWorkedHourSellable.UseVisualStyleBackColor = True
        '
        'DgvWorkedHourSellable
        '
        Me.DgvWorkedHourSellable.AllowUserToAddRows = False
        Me.DgvWorkedHourSellable.AllowUserToDeleteRows = False
        Me.DgvWorkedHourSellable.AllowUserToOrderColumns = True
        Me.DgvWorkedHourSellable.AllowUserToResizeRows = False
        Me.DgvWorkedHourSellable.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvWorkedHourSellable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvWorkedHourSellable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvWorkedHourSellable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvWorkedHourSellable.Location = New System.Drawing.Point(3, 28)
        Me.DgvWorkedHourSellable.MultiSelect = False
        Me.DgvWorkedHourSellable.Name = "DgvWorkedHourSellable"
        Me.DgvWorkedHourSellable.ReadOnly = True
        Me.DgvWorkedHourSellable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvWorkedHourSellable.RowHeadersVisible = False
        Me.DgvWorkedHourSellable.RowTemplate.Height = 26
        Me.DgvWorkedHourSellable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvWorkedHourSellable.Size = New System.Drawing.Size(431, 39)
        Me.DgvWorkedHourSellable.TabIndex = 4
        '
        'TsWorkedHourSellable
        '
        Me.TsWorkedHourSellable.BackColor = System.Drawing.Color.Transparent
        Me.TsWorkedHourSellable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsWorkedHourSellable.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsWorkedHourSellable.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeWorkedHourSellable, Me.BtnEditWorkedHourSellable, Me.BtnDeleteWorkedHourSellable, Me.LblFilterWorkedHourSellable, Me.TxtFilterWorkedHourSellable})
        Me.TsWorkedHourSellable.Location = New System.Drawing.Point(3, 3)
        Me.TsWorkedHourSellable.Name = "TsWorkedHourSellable"
        Me.TsWorkedHourSellable.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsWorkedHourSellable.Size = New System.Drawing.Size(431, 25)
        Me.TsWorkedHourSellable.TabIndex = 2
        Me.TsWorkedHourSellable.Text = "ToolStrip2"
        '
        'BtnIncludeWorkedHourSellable
        '
        Me.BtnIncludeWorkedHourSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeWorkedHourSellable.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeWorkedHourSellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeWorkedHourSellable.Name = "BtnIncludeWorkedHourSellable"
        Me.BtnIncludeWorkedHourSellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeWorkedHourSellable.Text = "Incluir Produto/Serviço"
        '
        'BtnEditWorkedHourSellable
        '
        Me.BtnEditWorkedHourSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditWorkedHourSellable.Image = CType(resources.GetObject("BtnEditWorkedHourSellable.Image"), System.Drawing.Image)
        Me.BtnEditWorkedHourSellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditWorkedHourSellable.Name = "BtnEditWorkedHourSellable"
        Me.BtnEditWorkedHourSellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditWorkedHourSellable.Text = "Editar Produto/Serviço"
        Me.BtnEditWorkedHourSellable.ToolTipText = "Editar"
        '
        'BtnDeleteWorkedHourSellable
        '
        Me.BtnDeleteWorkedHourSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteWorkedHourSellable.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteWorkedHourSellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteWorkedHourSellable.Name = "BtnDeleteWorkedHourSellable"
        Me.BtnDeleteWorkedHourSellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteWorkedHourSellable.Text = "Excluir Produto/Serviço"
        '
        'LblFilterWorkedHourSellable
        '
        Me.LblFilterWorkedHourSellable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LblFilterWorkedHourSellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblFilterWorkedHourSellable.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.LblFilterWorkedHourSellable.Name = "LblFilterWorkedHourSellable"
        Me.LblFilterWorkedHourSellable.Size = New System.Drawing.Size(46, 25)
        Me.LblFilterWorkedHourSellable.Text = "Filtrar:"
        '
        'TxtFilterWorkedHourSellable
        '
        Me.TxtFilterWorkedHourSellable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterWorkedHourSellable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilterWorkedHourSellable.Name = "TxtFilterWorkedHourSellable"
        Me.TxtFilterWorkedHourSellable.Size = New System.Drawing.Size(200, 25)
        '
        'TabElapsedDaySellable
        '
        Me.TabElapsedDaySellable.Controls.Add(Me.DgvElapsedDaySellable)
        Me.TabElapsedDaySellable.Controls.Add(Me.TsElapsedDaySellable)
        Me.TabElapsedDaySellable.Location = New System.Drawing.Point(4, 22)
        Me.TabElapsedDaySellable.Name = "TabElapsedDaySellable"
        Me.TabElapsedDaySellable.Padding = New System.Windows.Forms.Padding(3)
        Me.TabElapsedDaySellable.Size = New System.Drawing.Size(437, 74)
        Me.TabElapsedDaySellable.TabIndex = 7
        Me.TabElapsedDaySellable.Text = "Dia Corrido"
        Me.TabElapsedDaySellable.UseVisualStyleBackColor = True
        '
        'DgvElapsedDaySellable
        '
        Me.DgvElapsedDaySellable.AllowUserToAddRows = False
        Me.DgvElapsedDaySellable.AllowUserToDeleteRows = False
        Me.DgvElapsedDaySellable.AllowUserToOrderColumns = True
        Me.DgvElapsedDaySellable.AllowUserToResizeRows = False
        Me.DgvElapsedDaySellable.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvElapsedDaySellable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvElapsedDaySellable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvElapsedDaySellable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvElapsedDaySellable.Location = New System.Drawing.Point(3, 28)
        Me.DgvElapsedDaySellable.MultiSelect = False
        Me.DgvElapsedDaySellable.Name = "DgvElapsedDaySellable"
        Me.DgvElapsedDaySellable.ReadOnly = True
        Me.DgvElapsedDaySellable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvElapsedDaySellable.RowHeadersVisible = False
        Me.DgvElapsedDaySellable.RowTemplate.Height = 26
        Me.DgvElapsedDaySellable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvElapsedDaySellable.Size = New System.Drawing.Size(431, 43)
        Me.DgvElapsedDaySellable.TabIndex = 5
        '
        'TsElapsedDaySellable
        '
        Me.TsElapsedDaySellable.BackColor = System.Drawing.Color.Transparent
        Me.TsElapsedDaySellable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsElapsedDaySellable.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsElapsedDaySellable.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeElapsedDaySellable, Me.BtnEditElapsedDaySellable, Me.BtnDeleteElapsedDaySellable, Me.LblFilterElapsedDaySellable, Me.TxtFilterElapsedDaySellable})
        Me.TsElapsedDaySellable.Location = New System.Drawing.Point(3, 3)
        Me.TsElapsedDaySellable.Name = "TsElapsedDaySellable"
        Me.TsElapsedDaySellable.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsElapsedDaySellable.Size = New System.Drawing.Size(431, 25)
        Me.TsElapsedDaySellable.TabIndex = 4
        Me.TsElapsedDaySellable.Text = "ToolStrip2"
        '
        'BtnIncludeElapsedDaySellable
        '
        Me.BtnIncludeElapsedDaySellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeElapsedDaySellable.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeElapsedDaySellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeElapsedDaySellable.Name = "BtnIncludeElapsedDaySellable"
        Me.BtnIncludeElapsedDaySellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeElapsedDaySellable.Text = "Incluir  Produto/Serviço"
        '
        'BtnEditElapsedDaySellable
        '
        Me.BtnEditElapsedDaySellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditElapsedDaySellable.Image = CType(resources.GetObject("BtnEditElapsedDaySellable.Image"), System.Drawing.Image)
        Me.BtnEditElapsedDaySellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditElapsedDaySellable.Name = "BtnEditElapsedDaySellable"
        Me.BtnEditElapsedDaySellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditElapsedDaySellable.Text = "Editar  Produto/Serviço"
        Me.BtnEditElapsedDaySellable.ToolTipText = "Editar"
        '
        'BtnDeleteElapsedDaySellable
        '
        Me.BtnDeleteElapsedDaySellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteElapsedDaySellable.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteElapsedDaySellable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteElapsedDaySellable.Name = "BtnDeleteElapsedDaySellable"
        Me.BtnDeleteElapsedDaySellable.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteElapsedDaySellable.Text = "Excluir  Produto/Serviço"
        '
        'LblFilterElapsedDaySellable
        '
        Me.LblFilterElapsedDaySellable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LblFilterElapsedDaySellable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblFilterElapsedDaySellable.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.LblFilterElapsedDaySellable.Name = "LblFilterElapsedDaySellable"
        Me.LblFilterElapsedDaySellable.Size = New System.Drawing.Size(46, 25)
        Me.LblFilterElapsedDaySellable.Text = "Filtrar:"
        '
        'TxtFilterElapsedDaySellable
        '
        Me.TxtFilterElapsedDaySellable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterElapsedDaySellable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilterElapsedDaySellable.Name = "TxtFilterElapsedDaySellable"
        Me.TxtFilterElapsedDaySellable.Size = New System.Drawing.Size(200, 25)
        '
        'TabNote
        '
        Me.TabNote.Controls.Add(Me.TxtNote)
        Me.TabNote.Location = New System.Drawing.Point(4, 22)
        Me.TabNote.Name = "TabNote"
        Me.TabNote.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNote.Size = New System.Drawing.Size(451, 106)
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
        Me.TxtNote.Size = New System.Drawing.Size(445, 100)
        Me.TxtNote.TabIndex = 0
        Me.TxtNote.Text = ""
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(769, 251)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(192, 70)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DgvlWorkedHourSellable
        '
        Me.DgvlWorkedHourSellable.DataGridView = Me.DgvWorkedHourSellable
        Me.DgvlWorkedHourSellable.Routine = Manager.Routine.PersonCompressorSellable
        '
        'DgvlElapsedDaySellable
        '
        Me.DgvlElapsedDaySellable.DataGridView = Me.DgvElapsedDaySellable
        Me.DgvlElapsedDaySellable.Routine = Manager.Routine.PersonCompressorSellable
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Unidade"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(115, 68)
        Me.TextBox1.MaxLength = 50
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 23)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Interface"
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Location = New System.Drawing.Point(9, 68)
        Me.TextBox2.MaxLength = 50
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 23)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmPersonCompressor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(339, 271)
        Me.Controls.Add(Me.TcPersonCompressor)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.TsMain)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonCompressor"
        Me.ShowIcon = False
        Me.Text = "Compressor da Pessoa"
        Me.TsMain.ResumeLayout(False)
        Me.TsMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TcPersonCompressor.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.FlpCompressor.ResumeLayout(False)
        Me.TabMaintenance.ResumeLayout(False)
        Me.TcMaintenance.ResumeLayout(False)
        Me.TabWorkedHourSellable.ResumeLayout(False)
        Me.TabWorkedHourSellable.PerformLayout()
        CType(Me.DgvWorkedHourSellable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsWorkedHourSellable.ResumeLayout(False)
        Me.TsWorkedHourSellable.PerformLayout()
        Me.TabElapsedDaySellable.ResumeLayout(False)
        Me.TabElapsedDaySellable.PerformLayout()
        CType(Me.DgvElapsedDaySellable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsElapsedDaySellable.ResumeLayout(False)
        Me.TsElapsedDaySellable.PerformLayout()
        Me.TabNote.ResumeLayout(False)
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsMain As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtSerialNumber As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblCompressor As Label
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents TxtPatrimony As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents TxtSector As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents QbxCompressor As ControlLibrary.QueriedBox
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents TcPersonCompressor As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TabWorkedHourSellable As TabPage
    Friend WithEvents TsWorkedHourSellable As ToolStrip
    Friend WithEvents BtnIncludeWorkedHourSellable As ToolStripButton
    Friend WithEvents BtnEditWorkedHourSellable As ToolStripButton
    Friend WithEvents BtnDeleteWorkedHourSellable As ToolStripButton
    Friend WithEvents LblFilterWorkedHourSellable As ToolStripLabel
    Friend WithEvents TxtFilterWorkedHourSellable As ToolStripTextBox
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents TabElapsedDaySellable As TabPage
    Friend WithEvents TsElapsedDaySellable As ToolStrip
    Friend WithEvents BtnIncludeElapsedDaySellable As ToolStripButton
    Friend WithEvents BtnEditElapsedDaySellable As ToolStripButton
    Friend WithEvents BtnDeleteElapsedDaySellable As ToolStripButton
    Friend WithEvents LblFilterElapsedDaySellable As ToolStripLabel
    Friend WithEvents TxtFilterElapsedDaySellable As ToolStripTextBox
    Friend WithEvents DgvlWorkedHourSellable As DataGridViewLayout
    Friend WithEvents DgvlElapsedDaySellable As DataGridViewLayout
    Friend WithEvents DgvWorkedHourSellable As DataGridView
    Friend WithEvents FlpCompressor As FlowLayoutPanel
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents TabMaintenance As TabPage
    Friend WithEvents TcMaintenance As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DgvElapsedDaySellable As DataGridView
    Friend WithEvents BtnImport As ToolStripButton
    Friend WithEvents LblUnitCapacity As Label
    Friend WithEvents DbxUnitCapacity As ControlLibrary.DecimalBox
    Friend WithEvents CbxControlled As ControlLibrary.CentralizedComboBox
    Friend WithEvents LblControlled As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
End Class
