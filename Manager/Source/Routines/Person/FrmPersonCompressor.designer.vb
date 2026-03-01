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
        Dim Condition3 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Parameter3 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
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
        Me.TmrQueriedBoxCompressor = New System.Windows.Forms.Timer(Me.components)
        Me.TxtSector = New System.Windows.Forms.TextBox()
        Me.TxtPatrimony = New System.Windows.Forms.TextBox()
        Me.TxtSerialNumber = New System.Windows.Forms.TextBox()
        Me.TcPersonCompressor = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.FlpUnit = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterUnit = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewUnit = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewUnit = New ControlLibrary.NoFocusCueButton()
        Me.FlpInterface = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFiltrerInterface = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewInterface = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewInterface = New ControlLibrary.NoFocusCueButton()
        Me.QbxUnit = New ControlLibrary.QueriedBox()
        Me.QbxInterface = New ControlLibrary.QueriedBox()
        Me.CbxControlled = New ControlLibrary.CentralizedComboBox()
        Me.DbxUnitCapacity = New ControlLibrary.DecimalBox()
        Me.FlpCompressor = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterCompressor = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCompressor = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewCompressor = New ControlLibrary.NoFocusCueButton()
        Me.LblControlled = New System.Windows.Forms.Label()
        Me.LblUnitCapacity = New System.Windows.Forms.Label()
        Me.LblUnit = New System.Windows.Forms.Label()
        Me.LblInterface = New System.Windows.Forms.Label()
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
        Me.TmrQueriedBoxInterface = New System.Windows.Forms.Timer(Me.components)
        Me.TmrQueriedBoxUnit = New System.Windows.Forms.Timer(Me.components)
        Me.TsMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TsData.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcPersonCompressor.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.FlpUnit.SuspendLayout()
        Me.FlpInterface.SuspendLayout()
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
        Me.BtnClose.Location = New System.Drawing.Point(307, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(206, 7)
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
        Me.TsMain.Size = New System.Drawing.Size(414, 25)
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
        Me.Panel1.Size = New System.Drawing.Size(414, 44)
        Me.Panel1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(268, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Setor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(137, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 17)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Patrimônio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 96)
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
        Me.TsData.Size = New System.Drawing.Size(414, 25)
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
        Condition3.FieldName = "statusid"
        Condition3.Operator = "="
        Condition3.TableNameOrAlias = "compressor"
        Condition3.Value = "@statusid"
        Me.QbxCompressor.Conditions.Add(Condition3)
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
        Parameter3.ParameterName = "@statusid"
        Parameter3.ParameterValue = "0"
        Me.QbxCompressor.Parameters.Add(Parameter3)
        Me.QbxCompressor.Prefix = Nothing
        Me.QbxCompressor.Size = New System.Drawing.Size(283, 23)
        Me.QbxCompressor.Suffix = Nothing
        Me.QbxCompressor.TabIndex = 1
        '
        'TmrQueriedBoxCompressor
        '
        Me.TmrQueriedBoxCompressor.Enabled = True
        Me.TmrQueriedBoxCompressor.Interval = 300
        '
        'TxtSector
        '
        Me.TxtSector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSector.Location = New System.Drawing.Point(271, 114)
        Me.TxtSector.MaxLength = 50
        Me.TxtSector.Name = "TxtSector"
        Me.TxtSector.Size = New System.Drawing.Size(127, 23)
        Me.TxtSector.TabIndex = 10
        '
        'TxtPatrimony
        '
        Me.TxtPatrimony.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPatrimony.Location = New System.Drawing.Point(140, 114)
        Me.TxtPatrimony.MaxLength = 50
        Me.TxtPatrimony.Name = "TxtPatrimony"
        Me.TxtPatrimony.Size = New System.Drawing.Size(125, 23)
        Me.TxtPatrimony.TabIndex = 8
        Me.TxtPatrimony.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerialNumber
        '
        Me.TxtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerialNumber.Location = New System.Drawing.Point(9, 114)
        Me.TxtSerialNumber.MaxLength = 50
        Me.TxtSerialNumber.Name = "TxtSerialNumber"
        Me.TxtSerialNumber.Size = New System.Drawing.Size(125, 23)
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
        Me.TcPersonCompressor.Size = New System.Drawing.Size(414, 177)
        Me.TcPersonCompressor.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.FlpUnit)
        Me.TabMain.Controls.Add(Me.FlpInterface)
        Me.TabMain.Controls.Add(Me.QbxUnit)
        Me.TabMain.Controls.Add(Me.QbxInterface)
        Me.TabMain.Controls.Add(Me.CbxControlled)
        Me.TabMain.Controls.Add(Me.DbxUnitCapacity)
        Me.TabMain.Controls.Add(Me.FlpCompressor)
        Me.TabMain.Controls.Add(Me.LblControlled)
        Me.TabMain.Controls.Add(Me.LblCompressor)
        Me.TabMain.Controls.Add(Me.Label3)
        Me.TabMain.Controls.Add(Me.LblUnitCapacity)
        Me.TabMain.Controls.Add(Me.Label8)
        Me.TabMain.Controls.Add(Me.QbxCompressor)
        Me.TabMain.Controls.Add(Me.LblUnit)
        Me.TabMain.Controls.Add(Me.TxtSerialNumber)
        Me.TabMain.Controls.Add(Me.LblInterface)
        Me.TabMain.Controls.Add(Me.Label1)
        Me.TabMain.Controls.Add(Me.TxtSector)
        Me.TabMain.Controls.Add(Me.TxtPatrimony)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(406, 147)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'FlpUnit
        '
        Me.FlpUnit.Controls.Add(Me.BtnFilterUnit)
        Me.FlpUnit.Controls.Add(Me.BtnViewUnit)
        Me.FlpUnit.Controls.Add(Me.BtnNewUnit)
        Me.FlpUnit.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpUnit.Location = New System.Drawing.Point(222, 49)
        Me.FlpUnit.Name = "FlpUnit"
        Me.FlpUnit.Size = New System.Drawing.Size(69, 21)
        Me.FlpUnit.TabIndex = 14
        '
        'BtnFilterUnit
        '
        Me.BtnFilterUnit.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterUnit.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterUnit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterUnit.FlatAppearance.BorderSize = 0
        Me.BtnFilterUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterUnit.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterUnit.Name = "BtnFilterUnit"
        Me.BtnFilterUnit.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterUnit.TabIndex = 2
        Me.BtnFilterUnit.TabStop = False
        Me.BtnFilterUnit.TooltipText = ""
        Me.BtnFilterUnit.UseVisualStyleBackColor = False
        Me.BtnFilterUnit.Visible = False
        '
        'BtnViewUnit
        '
        Me.BtnViewUnit.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewUnit.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewUnit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewUnit.FlatAppearance.BorderSize = 0
        Me.BtnViewUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewUnit.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewUnit.Name = "BtnViewUnit"
        Me.BtnViewUnit.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewUnit.TabIndex = 0
        Me.BtnViewUnit.TabStop = False
        Me.BtnViewUnit.TooltipText = ""
        Me.BtnViewUnit.UseVisualStyleBackColor = False
        Me.BtnViewUnit.Visible = False
        '
        'BtnNewUnit
        '
        Me.BtnNewUnit.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewUnit.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewUnit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewUnit.FlatAppearance.BorderSize = 0
        Me.BtnNewUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewUnit.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewUnit.Name = "BtnNewUnit"
        Me.BtnNewUnit.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewUnit.TabIndex = 1
        Me.BtnNewUnit.TabStop = False
        Me.BtnNewUnit.TooltipText = ""
        Me.BtnNewUnit.UseVisualStyleBackColor = False
        Me.BtnNewUnit.Visible = False
        '
        'FlpInterface
        '
        Me.FlpInterface.Controls.Add(Me.BtnFiltrerInterface)
        Me.FlpInterface.Controls.Add(Me.BtnViewInterface)
        Me.FlpInterface.Controls.Add(Me.BtnNewInterface)
        Me.FlpInterface.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpInterface.Location = New System.Drawing.Point(76, 49)
        Me.FlpInterface.Name = "FlpInterface"
        Me.FlpInterface.Size = New System.Drawing.Size(69, 21)
        Me.FlpInterface.TabIndex = 14
        '
        'BtnFiltrerInterface
        '
        Me.BtnFiltrerInterface.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltrerInterface.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFiltrerInterface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFiltrerInterface.FlatAppearance.BorderSize = 0
        Me.BtnFiltrerInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiltrerInterface.Location = New System.Drawing.Point(49, 3)
        Me.BtnFiltrerInterface.Name = "BtnFiltrerInterface"
        Me.BtnFiltrerInterface.Size = New System.Drawing.Size(17, 17)
        Me.BtnFiltrerInterface.TabIndex = 2
        Me.BtnFiltrerInterface.TabStop = False
        Me.BtnFiltrerInterface.TooltipText = ""
        Me.BtnFiltrerInterface.UseVisualStyleBackColor = False
        Me.BtnFiltrerInterface.Visible = False
        '
        'BtnViewInterface
        '
        Me.BtnViewInterface.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewInterface.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewInterface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewInterface.FlatAppearance.BorderSize = 0
        Me.BtnViewInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewInterface.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewInterface.Name = "BtnViewInterface"
        Me.BtnViewInterface.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewInterface.TabIndex = 0
        Me.BtnViewInterface.TabStop = False
        Me.BtnViewInterface.TooltipText = ""
        Me.BtnViewInterface.UseVisualStyleBackColor = False
        Me.BtnViewInterface.Visible = False
        '
        'BtnNewInterface
        '
        Me.BtnNewInterface.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewInterface.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewInterface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewInterface.FlatAppearance.BorderSize = 0
        Me.BtnNewInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewInterface.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewInterface.Name = "BtnNewInterface"
        Me.BtnNewInterface.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewInterface.TabIndex = 1
        Me.BtnNewInterface.TabStop = False
        Me.BtnNewInterface.TooltipText = ""
        Me.BtnNewInterface.UseVisualStyleBackColor = False
        Me.BtnNewInterface.Visible = False
        '
        'QbxUnit
        '
        Me.QbxUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxUnit.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "compressorunit"
        Condition1.Value = "@statusid"
        Me.QbxUnit.Conditions.Add(Condition1)
        Me.QbxUnit.DebugOnTextChanged = False
        Me.QbxUnit.DisplayFieldAlias = "Nome"
        Me.QbxUnit.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxUnit.DisplayFieldName = "Name"
        Me.QbxUnit.DisplayMainFieldName = "id"
        Me.QbxUnit.DisplayTableAlias = ""
        Me.QbxUnit.DisplayTableName = ""
        Me.QbxUnit.Distinct = False
        Me.QbxUnit.DropDownAutoStretchRight = False
        Me.QbxUnit.DropDownStretchRight = 182
        Me.QbxUnit.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxUnit.IfNull = Nothing
        Me.QbxUnit.Location = New System.Drawing.Point(152, 70)
        Me.QbxUnit.MainReturnFieldName = "id"
        Me.QbxUnit.MainTableAlias = Nothing
        Me.QbxUnit.MainTableName = "compressorunit"
        Me.QbxUnit.Name = "QbxUnit"
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Me.QbxUnit.Parameters.Add(Parameter1)
        Me.QbxUnit.Prefix = Nothing
        Me.QbxUnit.Size = New System.Drawing.Size(140, 23)
        Me.QbxUnit.Suffix = Nothing
        Me.QbxUnit.TabIndex = 13
        '
        'QbxInterface
        '
        Me.QbxInterface.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxInterface.CharactersToQuery = 1
        Condition2.FieldName = "statusid"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "compressorinterface"
        Condition2.Value = "@statusid"
        Me.QbxInterface.Conditions.Add(Condition2)
        Me.QbxInterface.DebugOnTextChanged = False
        Me.QbxInterface.DisplayFieldAlias = "Nome"
        Me.QbxInterface.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxInterface.DisplayFieldName = "name"
        Me.QbxInterface.DisplayMainFieldName = "id"
        Me.QbxInterface.DisplayTableAlias = ""
        Me.QbxInterface.DisplayTableName = ""
        Me.QbxInterface.Distinct = False
        Me.QbxInterface.DropDownAutoStretchRight = False
        Me.QbxInterface.DropDownStretchRight = 182
        Me.QbxInterface.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxInterface.IfNull = Nothing
        Me.QbxInterface.Location = New System.Drawing.Point(6, 70)
        Me.QbxInterface.MainReturnFieldName = "id"
        Me.QbxInterface.MainTableAlias = Nothing
        Me.QbxInterface.MainTableName = "compressorinterface"
        Me.QbxInterface.Name = "QbxInterface"
        Parameter2.ParameterName = "@statusid"
        Parameter2.ParameterValue = "0"
        Me.QbxInterface.Parameters.Add(Parameter2)
        Me.QbxInterface.Prefix = Nothing
        Me.QbxInterface.Size = New System.Drawing.Size(140, 23)
        Me.QbxInterface.Suffix = Nothing
        Me.QbxInterface.TabIndex = 13
        '
        'CbxControlled
        '
        Me.CbxControlled.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxControlled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxControlled.FormattingEnabled = True
        Me.CbxControlled.Location = New System.Drawing.Point(298, 24)
        Me.CbxControlled.Name = "CbxControlled"
        Me.CbxControlled.Size = New System.Drawing.Size(100, 24)
        Me.CbxControlled.TabIndex = 4
        '
        'DbxUnitCapacity
        '
        Me.DbxUnitCapacity.DecimalOnly = True
        Me.DbxUnitCapacity.DecimalPlaces = 0
        Me.DbxUnitCapacity.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxUnitCapacity.Location = New System.Drawing.Point(298, 70)
        Me.DbxUnitCapacity.Name = "DbxUnitCapacity"
        Me.DbxUnitCapacity.Size = New System.Drawing.Size(100, 23)
        Me.DbxUnitCapacity.TabIndex = 12
        Me.DbxUnitCapacity.Text = "0"
        Me.DbxUnitCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FlpCompressor
        '
        Me.FlpCompressor.Controls.Add(Me.BtnFilterCompressor)
        Me.FlpCompressor.Controls.Add(Me.BtnViewCompressor)
        Me.FlpCompressor.Controls.Add(Me.BtnNewCompressor)
        Me.FlpCompressor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCompressor.Location = New System.Drawing.Point(222, 3)
        Me.FlpCompressor.Name = "FlpCompressor"
        Me.FlpCompressor.Size = New System.Drawing.Size(69, 21)
        Me.FlpCompressor.TabIndex = 2
        '
        'BtnFilterCompressor
        '
        Me.BtnFilterCompressor.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterCompressor.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterCompressor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterCompressor.FlatAppearance.BorderSize = 0
        Me.BtnFilterCompressor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterCompressor.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterCompressor.Name = "BtnFilterCompressor"
        Me.BtnFilterCompressor.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterCompressor.TabIndex = 2
        Me.BtnFilterCompressor.TabStop = False
        Me.BtnFilterCompressor.TooltipText = ""
        Me.BtnFilterCompressor.UseVisualStyleBackColor = False
        Me.BtnFilterCompressor.Visible = False
        '
        'BtnViewCompressor
        '
        Me.BtnViewCompressor.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewCompressor.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewCompressor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewCompressor.FlatAppearance.BorderSize = 0
        Me.BtnViewCompressor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewCompressor.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewCompressor.Name = "BtnViewCompressor"
        Me.BtnViewCompressor.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewCompressor.TabIndex = 1
        Me.BtnViewCompressor.TabStop = False
        Me.BtnViewCompressor.TooltipText = ""
        Me.BtnViewCompressor.UseVisualStyleBackColor = False
        Me.BtnViewCompressor.Visible = False
        '
        'BtnNewCompressor
        '
        Me.BtnNewCompressor.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewCompressor.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewCompressor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewCompressor.FlatAppearance.BorderSize = 0
        Me.BtnNewCompressor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewCompressor.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewCompressor.Name = "BtnNewCompressor"
        Me.BtnNewCompressor.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewCompressor.TabIndex = 0
        Me.BtnNewCompressor.TabStop = False
        Me.BtnNewCompressor.TooltipText = ""
        Me.BtnNewCompressor.UseVisualStyleBackColor = False
        Me.BtnNewCompressor.Visible = False
        '
        'LblControlled
        '
        Me.LblControlled.AutoSize = True
        Me.LblControlled.Location = New System.Drawing.Point(295, 4)
        Me.LblControlled.Name = "LblControlled"
        Me.LblControlled.Size = New System.Drawing.Size(84, 17)
        Me.LblControlled.TabIndex = 3
        Me.LblControlled.Text = "Controlado"
        '
        'LblUnitCapacity
        '
        Me.LblUnitCapacity.AutoSize = True
        Me.LblUnitCapacity.Location = New System.Drawing.Point(295, 50)
        Me.LblUnitCapacity.Name = "LblUnitCapacity"
        Me.LblUnitCapacity.Size = New System.Drawing.Size(74, 17)
        Me.LblUnitCapacity.TabIndex = 11
        Me.LblUnitCapacity.Text = "Cap. Und."
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Location = New System.Drawing.Point(152, 50)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(62, 17)
        Me.LblUnit.TabIndex = 5
        Me.LblUnit.Text = "Unidade"
        '
        'LblInterface
        '
        Me.LblInterface.AutoSize = True
        Me.LblInterface.Location = New System.Drawing.Point(6, 50)
        Me.LblInterface.Name = "LblInterface"
        Me.LblInterface.Size = New System.Drawing.Size(65, 17)
        Me.LblInterface.TabIndex = 5
        Me.LblInterface.Text = "Interface"
        '
        'TabMaintenance
        '
        Me.TabMaintenance.Controls.Add(Me.TcMaintenance)
        Me.TabMaintenance.Location = New System.Drawing.Point(4, 22)
        Me.TabMaintenance.Name = "TabMaintenance"
        Me.TabMaintenance.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMaintenance.Size = New System.Drawing.Size(406, 151)
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
        Me.TcMaintenance.Size = New System.Drawing.Size(400, 145)
        Me.TcMaintenance.TabIndex = 0
        '
        'TabWorkedHourSellable
        '
        Me.TabWorkedHourSellable.Controls.Add(Me.DgvWorkedHourSellable)
        Me.TabWorkedHourSellable.Controls.Add(Me.TsWorkedHourSellable)
        Me.TabWorkedHourSellable.Location = New System.Drawing.Point(4, 26)
        Me.TabWorkedHourSellable.Name = "TabWorkedHourSellable"
        Me.TabWorkedHourSellable.Padding = New System.Windows.Forms.Padding(3)
        Me.TabWorkedHourSellable.Size = New System.Drawing.Size(392, 115)
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
        Me.DgvWorkedHourSellable.Size = New System.Drawing.Size(386, 84)
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
        Me.TsWorkedHourSellable.Size = New System.Drawing.Size(386, 25)
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
        Me.TabElapsedDaySellable.Size = New System.Drawing.Size(392, 119)
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
        Me.DgvElapsedDaySellable.Size = New System.Drawing.Size(386, 88)
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
        Me.TsElapsedDaySellable.Size = New System.Drawing.Size(386, 25)
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
        Me.TabNote.Size = New System.Drawing.Size(406, 151)
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
        Me.TxtNote.Size = New System.Drawing.Size(400, 145)
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
        'TmrQueriedBoxInterface
        '
        Me.TmrQueriedBoxInterface.Enabled = True
        Me.TmrQueriedBoxInterface.Interval = 300
        '
        'TmrQueriedBoxUnit
        '
        Me.TmrQueriedBoxUnit.Enabled = True
        Me.TmrQueriedBoxUnit.Interval = 300
        '
        'FrmPersonCompressor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(414, 271)
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
        Me.FlpUnit.ResumeLayout(False)
        Me.FlpInterface.ResumeLayout(False)
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
    Friend WithEvents TmrQueriedBoxCompressor As Timer
    Friend WithEvents BtnNewCompressor As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCompressor As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterCompressor As ControlLibrary.NoFocusCueButton
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
    Friend WithEvents LblInterface As Label
    Friend WithEvents QbxInterface As ControlLibrary.QueriedBox
    Friend WithEvents FlpUnit As FlowLayoutPanel
    Friend WithEvents BtnFilterUnit As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewUnit As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNewUnit As ControlLibrary.NoFocusCueButton
    Friend WithEvents FlpInterface As FlowLayoutPanel
    Friend WithEvents BtnFiltrerInterface As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewInterface As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNewInterface As ControlLibrary.NoFocusCueButton
    Friend WithEvents QbxUnit As ControlLibrary.QueriedBox
    Friend WithEvents LblUnit As Label
    Friend WithEvents TmrQueriedBoxInterface As Timer
    Friend WithEvents TmrQueriedBoxUnit As Timer
End Class
