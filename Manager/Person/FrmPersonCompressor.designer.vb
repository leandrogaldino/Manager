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
        Me.DbxUnitCapacity = New ControlLibrary.DecimalBox()
        Me.FlpCompressor = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.LblUnitCapacity = New System.Windows.Forms.Label()
        Me.TabMaintenance = New System.Windows.Forms.TabPage()
        Me.TcMaintenance = New System.Windows.Forms.TabControl()
        Me.TabPartWorkedHour = New System.Windows.Forms.TabPage()
        Me.DgvPartWorkedHour = New System.Windows.Forms.DataGridView()
        Me.TsPartWorkedHour = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCompressorPartWorkedHour = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCompressorPartWorkedHour = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteCompressorPartWorkedHour = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterPartWorkedHour = New System.Windows.Forms.ToolStripTextBox()
        Me.TabPartElapsedDay = New System.Windows.Forms.TabPage()
        Me.DgvPartElapsedDay = New System.Windows.Forms.DataGridView()
        Me.TsPartElapsedDay = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludePartElapsedDay = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditPartElapsedDay = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePartElapsedDay = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterPartElapsedDay = New System.Windows.Forms.ToolStripTextBox()
        Me.TabNote = New System.Windows.Forms.TabPage()
        Me.TxtNote = New System.Windows.Forms.RichTextBox()
        Me.DgvPartWorkedHourLayout = New Manager.DataGridViewLayout()
        Me.DgvPartElapsedDayLayout = New Manager.DataGridViewLayout()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TsMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TsData.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcPersonCompressor.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.FlpCompressor.SuspendLayout()
        Me.TabMaintenance.SuspendLayout()
        Me.TcMaintenance.SuspendLayout()
        Me.TabPartWorkedHour.SuspendLayout()
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsPartWorkedHour.SuspendLayout()
        Me.TabPartElapsedDay.SuspendLayout()
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsPartElapsedDay.SuspendLayout()
        Me.TabNote.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(352, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(251, 7)
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
        Me.TsMain.Size = New System.Drawing.Size(459, 25)
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
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 182)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(459, 44)
        Me.Panel1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Setor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(92, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 17)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Patrimônio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 3
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
        Me.TsData.Size = New System.Drawing.Size(459, 25)
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
        Me.QbxCompressor.Size = New System.Drawing.Size(433, 23)
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
        Me.TxtSector.Location = New System.Drawing.Point(181, 70)
        Me.TxtSector.MaxLength = 50
        Me.TxtSector.Name = "TxtSector"
        Me.TxtSector.Size = New System.Drawing.Size(170, 23)
        Me.TxtSector.TabIndex = 8
        '
        'TxtPatrimony
        '
        Me.TxtPatrimony.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPatrimony.Location = New System.Drawing.Point(95, 70)
        Me.TxtPatrimony.MaxLength = 50
        Me.TxtPatrimony.Name = "TxtPatrimony"
        Me.TxtPatrimony.Size = New System.Drawing.Size(80, 23)
        Me.TxtPatrimony.TabIndex = 6
        Me.TxtPatrimony.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerialNumber
        '
        Me.TxtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerialNumber.Location = New System.Drawing.Point(9, 70)
        Me.TxtSerialNumber.MaxLength = 50
        Me.TxtSerialNumber.Name = "TxtSerialNumber"
        Me.TxtSerialNumber.Size = New System.Drawing.Size(80, 23)
        Me.TxtSerialNumber.TabIndex = 4
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
        Me.TcPersonCompressor.Size = New System.Drawing.Size(459, 132)
        Me.TcPersonCompressor.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.DbxUnitCapacity)
        Me.TabMain.Controls.Add(Me.FlpCompressor)
        Me.TabMain.Controls.Add(Me.LblCompressor)
        Me.TabMain.Controls.Add(Me.Label3)
        Me.TabMain.Controls.Add(Me.LblUnitCapacity)
        Me.TabMain.Controls.Add(Me.Label8)
        Me.TabMain.Controls.Add(Me.QbxCompressor)
        Me.TabMain.Controls.Add(Me.TxtSerialNumber)
        Me.TabMain.Controls.Add(Me.Label1)
        Me.TabMain.Controls.Add(Me.TxtSector)
        Me.TabMain.Controls.Add(Me.TxtPatrimony)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(451, 102)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'DbxUnitCapacity
        '
        Me.DbxUnitCapacity.DecimalOnly = True
        Me.DbxUnitCapacity.DecimalPlaces = 0
        Me.DbxUnitCapacity.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxUnitCapacity.Location = New System.Drawing.Point(357, 70)
        Me.DbxUnitCapacity.Name = "DbxUnitCapacity"
        Me.DbxUnitCapacity.Size = New System.Drawing.Size(85, 23)
        Me.DbxUnitCapacity.TabIndex = 9
        Me.DbxUnitCapacity.Text = "0"
        Me.DbxUnitCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FlpCompressor
        '
        Me.FlpCompressor.Controls.Add(Me.BtnFilter)
        Me.FlpCompressor.Controls.Add(Me.BtnView)
        Me.FlpCompressor.Controls.Add(Me.BtnNew)
        Me.FlpCompressor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCompressor.Location = New System.Drawing.Point(373, 3)
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
        Me.BtnNew.TabIndex = 3
        Me.BtnNew.TabStop = False
        Me.BtnNew.TooltipText = ""
        Me.BtnNew.UseVisualStyleBackColor = False
        Me.BtnNew.Visible = False
        '
        'LblUnitCapacity
        '
        Me.LblUnitCapacity.AutoSize = True
        Me.LblUnitCapacity.Location = New System.Drawing.Point(354, 50)
        Me.LblUnitCapacity.Name = "LblUnitCapacity"
        Me.LblUnitCapacity.Size = New System.Drawing.Size(74, 17)
        Me.LblUnitCapacity.TabIndex = 5
        Me.LblUnitCapacity.Text = "Cap. Und."
        '
        'TabMaintenance
        '
        Me.TabMaintenance.Controls.Add(Me.TcMaintenance)
        Me.TabMaintenance.Location = New System.Drawing.Point(4, 26)
        Me.TabMaintenance.Name = "TabMaintenance"
        Me.TabMaintenance.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMaintenance.Size = New System.Drawing.Size(451, 102)
        Me.TabMaintenance.TabIndex = 8
        Me.TabMaintenance.Text = "Manutenção"
        Me.TabMaintenance.UseVisualStyleBackColor = True
        '
        'TcMaintenance
        '
        Me.TcMaintenance.Controls.Add(Me.TabPartWorkedHour)
        Me.TcMaintenance.Controls.Add(Me.TabPartElapsedDay)
        Me.TcMaintenance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcMaintenance.Location = New System.Drawing.Point(3, 3)
        Me.TcMaintenance.Name = "TcMaintenance"
        Me.TcMaintenance.SelectedIndex = 0
        Me.TcMaintenance.Size = New System.Drawing.Size(445, 96)
        Me.TcMaintenance.TabIndex = 0
        '
        'TabPartWorkedHour
        '
        Me.TabPartWorkedHour.Controls.Add(Me.DgvPartWorkedHour)
        Me.TabPartWorkedHour.Controls.Add(Me.TsPartWorkedHour)
        Me.TabPartWorkedHour.Location = New System.Drawing.Point(4, 26)
        Me.TabPartWorkedHour.Name = "TabPartWorkedHour"
        Me.TabPartWorkedHour.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPartWorkedHour.Size = New System.Drawing.Size(437, 66)
        Me.TabPartWorkedHour.TabIndex = 6
        Me.TabPartWorkedHour.Text = "Hora Trabalhada"
        Me.TabPartWorkedHour.UseVisualStyleBackColor = True
        '
        'DgvPartWorkedHour
        '
        Me.DgvPartWorkedHour.AllowUserToAddRows = False
        Me.DgvPartWorkedHour.AllowUserToDeleteRows = False
        Me.DgvPartWorkedHour.AllowUserToOrderColumns = True
        Me.DgvPartWorkedHour.AllowUserToResizeRows = False
        Me.DgvPartWorkedHour.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPartWorkedHour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPartWorkedHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartWorkedHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartWorkedHour.Location = New System.Drawing.Point(3, 28)
        Me.DgvPartWorkedHour.MultiSelect = False
        Me.DgvPartWorkedHour.Name = "DgvPartWorkedHour"
        Me.DgvPartWorkedHour.ReadOnly = True
        Me.DgvPartWorkedHour.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartWorkedHour.RowHeadersVisible = False
        Me.DgvPartWorkedHour.RowTemplate.Height = 26
        Me.DgvPartWorkedHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartWorkedHour.Size = New System.Drawing.Size(431, 35)
        Me.DgvPartWorkedHour.TabIndex = 4
        '
        'TsPartWorkedHour
        '
        Me.TsPartWorkedHour.BackColor = System.Drawing.Color.Transparent
        Me.TsPartWorkedHour.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsPartWorkedHour.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsPartWorkedHour.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCompressorPartWorkedHour, Me.BtnEditCompressorPartWorkedHour, Me.BtnDeleteCompressorPartWorkedHour, Me.ToolStripLabel3, Me.TxtFilterPartWorkedHour})
        Me.TsPartWorkedHour.Location = New System.Drawing.Point(3, 3)
        Me.TsPartWorkedHour.Name = "TsPartWorkedHour"
        Me.TsPartWorkedHour.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsPartWorkedHour.Size = New System.Drawing.Size(431, 25)
        Me.TsPartWorkedHour.TabIndex = 2
        Me.TsPartWorkedHour.Text = "ToolStrip2"
        '
        'BtnIncludeCompressorPartWorkedHour
        '
        Me.BtnIncludeCompressorPartWorkedHour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeCompressorPartWorkedHour.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeCompressorPartWorkedHour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeCompressorPartWorkedHour.Name = "BtnIncludeCompressorPartWorkedHour"
        Me.BtnIncludeCompressorPartWorkedHour.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeCompressorPartWorkedHour.Text = "Incluir Item"
        '
        'BtnEditCompressorPartWorkedHour
        '
        Me.BtnEditCompressorPartWorkedHour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditCompressorPartWorkedHour.Image = CType(resources.GetObject("BtnEditCompressorPartWorkedHour.Image"), System.Drawing.Image)
        Me.BtnEditCompressorPartWorkedHour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditCompressorPartWorkedHour.Name = "BtnEditCompressorPartWorkedHour"
        Me.BtnEditCompressorPartWorkedHour.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditCompressorPartWorkedHour.Text = "Editar Item"
        Me.BtnEditCompressorPartWorkedHour.ToolTipText = "Editar"
        '
        'BtnDeleteCompressorPartWorkedHour
        '
        Me.BtnDeleteCompressorPartWorkedHour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteCompressorPartWorkedHour.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteCompressorPartWorkedHour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteCompressorPartWorkedHour.Name = "BtnDeleteCompressorPartWorkedHour"
        Me.BtnDeleteCompressorPartWorkedHour.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteCompressorPartWorkedHour.Text = "Excluir Item"
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
        'TxtFilterPartWorkedHour
        '
        Me.TxtFilterPartWorkedHour.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterPartWorkedHour.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilterPartWorkedHour.Name = "TxtFilterPartWorkedHour"
        Me.TxtFilterPartWorkedHour.Size = New System.Drawing.Size(200, 25)
        '
        'TabPartElapsedDay
        '
        Me.TabPartElapsedDay.Controls.Add(Me.DgvPartElapsedDay)
        Me.TabPartElapsedDay.Controls.Add(Me.TsPartElapsedDay)
        Me.TabPartElapsedDay.Location = New System.Drawing.Point(4, 22)
        Me.TabPartElapsedDay.Name = "TabPartElapsedDay"
        Me.TabPartElapsedDay.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPartElapsedDay.Size = New System.Drawing.Size(437, 70)
        Me.TabPartElapsedDay.TabIndex = 7
        Me.TabPartElapsedDay.Text = "Dia Corrido"
        Me.TabPartElapsedDay.UseVisualStyleBackColor = True
        '
        'DgvPartElapsedDay
        '
        Me.DgvPartElapsedDay.AllowUserToAddRows = False
        Me.DgvPartElapsedDay.AllowUserToDeleteRows = False
        Me.DgvPartElapsedDay.AllowUserToOrderColumns = True
        Me.DgvPartElapsedDay.AllowUserToResizeRows = False
        Me.DgvPartElapsedDay.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPartElapsedDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPartElapsedDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartElapsedDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartElapsedDay.Location = New System.Drawing.Point(3, 28)
        Me.DgvPartElapsedDay.MultiSelect = False
        Me.DgvPartElapsedDay.Name = "DgvPartElapsedDay"
        Me.DgvPartElapsedDay.ReadOnly = True
        Me.DgvPartElapsedDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartElapsedDay.RowHeadersVisible = False
        Me.DgvPartElapsedDay.RowTemplate.Height = 26
        Me.DgvPartElapsedDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartElapsedDay.Size = New System.Drawing.Size(431, 39)
        Me.DgvPartElapsedDay.TabIndex = 5
        '
        'TsPartElapsedDay
        '
        Me.TsPartElapsedDay.BackColor = System.Drawing.Color.Transparent
        Me.TsPartElapsedDay.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsPartElapsedDay.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsPartElapsedDay.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludePartElapsedDay, Me.BtnEditPartElapsedDay, Me.BtnDeletePartElapsedDay, Me.ToolStripLabel1, Me.TxtFilterPartElapsedDay})
        Me.TsPartElapsedDay.Location = New System.Drawing.Point(3, 3)
        Me.TsPartElapsedDay.Name = "TsPartElapsedDay"
        Me.TsPartElapsedDay.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsPartElapsedDay.Size = New System.Drawing.Size(431, 25)
        Me.TsPartElapsedDay.TabIndex = 4
        Me.TsPartElapsedDay.Text = "ToolStrip2"
        '
        'BtnIncludePartElapsedDay
        '
        Me.BtnIncludePartElapsedDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludePartElapsedDay.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludePartElapsedDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludePartElapsedDay.Name = "BtnIncludePartElapsedDay"
        Me.BtnIncludePartElapsedDay.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludePartElapsedDay.Text = "Incluir Item"
        '
        'BtnEditPartElapsedDay
        '
        Me.BtnEditPartElapsedDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditPartElapsedDay.Image = CType(resources.GetObject("BtnEditPartElapsedDay.Image"), System.Drawing.Image)
        Me.BtnEditPartElapsedDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditPartElapsedDay.Name = "BtnEditPartElapsedDay"
        Me.BtnEditPartElapsedDay.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditPartElapsedDay.Text = "Editar Item"
        Me.BtnEditPartElapsedDay.ToolTipText = "Editar"
        '
        'BtnDeletePartElapsedDay
        '
        Me.BtnDeletePartElapsedDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeletePartElapsedDay.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeletePartElapsedDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeletePartElapsedDay.Name = "BtnDeletePartElapsedDay"
        Me.BtnDeletePartElapsedDay.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeletePartElapsedDay.Text = "Excluir Item"
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
        'TxtFilterPartElapsedDay
        '
        Me.TxtFilterPartElapsedDay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterPartElapsedDay.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilterPartElapsedDay.Name = "TxtFilterPartElapsedDay"
        Me.TxtFilterPartElapsedDay.Size = New System.Drawing.Size(200, 25)
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
        'DgvPartWorkedHourLayout
        '
        Me.DgvPartWorkedHourLayout.DataGridView = Me.DgvPartWorkedHour
        Me.DgvPartWorkedHourLayout.Routine = Routine.PersonCompressorPartWorkedHour
        '
        'DgvPartElapsedDayLayout
        '
        Me.DgvPartElapsedDayLayout.DataGridView = Me.DgvPartElapsedDay
        Me.DgvPartElapsedDayLayout.Routine = Routine.PersonCompressorPartElapsedDay
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
        'FrmPersonCompressor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(459, 226)
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
        Me.TabPartWorkedHour.ResumeLayout(False)
        Me.TabPartWorkedHour.PerformLayout()
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsPartWorkedHour.ResumeLayout(False)
        Me.TsPartWorkedHour.PerformLayout()
        Me.TabPartElapsedDay.ResumeLayout(False)
        Me.TabPartElapsedDay.PerformLayout()
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsPartElapsedDay.ResumeLayout(False)
        Me.TsPartElapsedDay.PerformLayout()
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
    Friend WithEvents TabPartWorkedHour As TabPage
    Friend WithEvents TsPartWorkedHour As ToolStrip
    Friend WithEvents BtnIncludeCompressorPartWorkedHour As ToolStripButton
    Friend WithEvents BtnEditCompressorPartWorkedHour As ToolStripButton
    Friend WithEvents BtnDeleteCompressorPartWorkedHour As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents TxtFilterPartWorkedHour As ToolStripTextBox
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents TabPartElapsedDay As TabPage
    Friend WithEvents TsPartElapsedDay As ToolStrip
    Friend WithEvents BtnIncludePartElapsedDay As ToolStripButton
    Friend WithEvents BtnEditPartElapsedDay As ToolStripButton
    Friend WithEvents BtnDeletePartElapsedDay As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TxtFilterPartElapsedDay As ToolStripTextBox
    Friend WithEvents DgvPartWorkedHourLayout As DataGridViewLayout
    Friend WithEvents DgvPartElapsedDayLayout As DataGridViewLayout
    Friend WithEvents DgvPartWorkedHour As DataGridView
    Friend WithEvents FlpCompressor As FlowLayoutPanel
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents TabMaintenance As TabPage
    Friend WithEvents TcMaintenance As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DgvPartElapsedDay As DataGridView
    Friend WithEvents BtnImport As ToolStripButton
    Friend WithEvents LblUnitCapacity As Label
    Friend WithEvents DbxUnitCapacity As ControlLibrary.DecimalBox
End Class
