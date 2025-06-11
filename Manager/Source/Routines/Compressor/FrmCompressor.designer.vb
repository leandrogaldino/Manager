<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompressor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompressor))
        Dim Condition3 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition4 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField5 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField6 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField7 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField8 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter3 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter4 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation4 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation5 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation6 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
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
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblManufacturer = New System.Windows.Forms.Label()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.TcCompressor = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.QbxManufacturer = New ControlLibrary.QueriedBox()
        Me.FlpManufacturer = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TabMaintenance = New System.Windows.Forms.TabPage()
        Me.TcMaintenance = New System.Windows.Forms.TabControl()
        Me.TabWorkedHour = New System.Windows.Forms.TabPage()
        Me.DgvCompressorSellableWorkedHour = New System.Windows.Forms.DataGridView()
        Me.TsMaintenanceHour = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeSellableWorkedHour = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditSellableWorkedHour = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteSellableWorkedHour = New System.Windows.Forms.ToolStripButton()
        Me.LblFilterSellableWorkedHour = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterPartWorkedHour = New System.Windows.Forms.ToolStripTextBox()
        Me.TabPassedDay = New System.Windows.Forms.TabPage()
        Me.DgvCompressorSellableElapsedDay = New System.Windows.Forms.DataGridView()
        Me.TsMaintenanceDay = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludePartElapsedDay = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditPartElapsedDay = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletePartElapsedDay = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterElapsedDay = New System.Windows.Forms.ToolStripTextBox()
        Me.DgvCompressorSellableWorkedHourLayout = New Manager.DataGridViewLayout()
        Me.DgvCompressorSellableElapsedDayLayout = New Manager.DataGridViewLayout()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PnButtons.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcCompressor.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.FlpManufacturer.SuspendLayout()
        Me.TabMaintenance.SuspendLayout()
        Me.TcMaintenance.SuspendLayout()
        Me.TabWorkedHour.SuspendLayout()
        CType(Me.DgvCompressorSellableWorkedHour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsMaintenanceHour.SuspendLayout()
        Me.TabPassedDay.SuspendLayout()
        CType(Me.DgvCompressorSellableElapsedDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsMaintenanceDay.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 187)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(354, 44)
        Me.PnButtons.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(247, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(146, 7)
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
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreationDate, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(354, 25)
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
        Me.BtnStatusValue.Image = CType(resources.GetObject("BtnStatusValue.Image"), System.Drawing.Image)
        Me.BtnStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnStatusValue.Name = "BtnStatusValue"
        Me.BtnStatusValue.Size = New System.Drawing.Size(44, 22)
        Me.BtnStatusValue.Text = "        "
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
        Me.TsNavigation.Size = New System.Drawing.Size(354, 25)
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
        Me.BtnInclude.Text = "Incluir Compressor"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
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
        'LblManufacturer
        '
        Me.LblManufacturer.AutoSize = True
        Me.LblManufacturer.Location = New System.Drawing.Point(6, 53)
        Me.LblManufacturer.Name = "LblManufacturer"
        Me.LblManufacturer.Size = New System.Drawing.Size(77, 17)
        Me.LblManufacturer.TabIndex = 2
        Me.LblManufacturer.Text = "Fabricante"
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'TcCompressor
        '
        Me.TcCompressor.Controls.Add(Me.TabMain)
        Me.TcCompressor.Controls.Add(Me.TabMaintenance)
        Me.TcCompressor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcCompressor.Location = New System.Drawing.Point(0, 50)
        Me.TcCompressor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcCompressor.Multiline = True
        Me.TcCompressor.Name = "TcCompressor"
        Me.TcCompressor.SelectedIndex = 0
        Me.TcCompressor.Size = New System.Drawing.Size(354, 137)
        Me.TcCompressor.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.QbxManufacturer)
        Me.TabMain.Controls.Add(Me.FlpManufacturer)
        Me.TabMain.Controls.Add(Me.LblName)
        Me.TabMain.Controls.Add(Me.LblManufacturer)
        Me.TabMain.Controls.Add(Me.TxtName)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(346, 107)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'QbxManufacturer
        '
        Me.QbxManufacturer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxManufacturer.CharactersToQuery = 1
        Condition3.FieldName = "isprovider"
        Condition3.Operator = "="
        Condition3.TableNameOrAlias = "person"
        Condition3.Value = "@isprovider"
        Condition4.FieldName = "statusid"
        Condition4.Operator = "="
        Condition4.TableNameOrAlias = "person"
        Condition4.Value = "@statusid"
        Me.QbxManufacturer.Conditions.Add(Condition3)
        Me.QbxManufacturer.Conditions.Add(Condition4)
        Me.QbxManufacturer.DebugOnTextChanged = False
        Me.QbxManufacturer.DisplayFieldAlias = "Nome Curto"
        Me.QbxManufacturer.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxManufacturer.DisplayFieldName = "shortname"
        Me.QbxManufacturer.DisplayMainFieldName = "id"
        Me.QbxManufacturer.DisplayTableAlias = Nothing
        Me.QbxManufacturer.DisplayTableName = "person"
        Me.QbxManufacturer.Distinct = True
        Me.QbxManufacturer.DropDownAutoStretchRight = False
        Me.QbxManufacturer.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxManufacturer.IfNull = Nothing
        Me.QbxManufacturer.Location = New System.Drawing.Point(9, 73)
        Me.QbxManufacturer.MainReturnFieldName = "id"
        Me.QbxManufacturer.MainTableAlias = Nothing
        Me.QbxManufacturer.MainTableName = "person"
        Me.QbxManufacturer.Name = "QbxManufacturer"
        OtherField5.DisplayFieldAlias = "Nome"
        OtherField5.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField5.DisplayFieldName = "name"
        OtherField5.DisplayMainFieldName = "id"
        OtherField5.DisplayTableAlias = Nothing
        OtherField5.DisplayTableName = "person"
        OtherField5.Freeze = False
        OtherField5.IfNull = Nothing
        OtherField5.Prefix = Nothing
        OtherField5.Suffix = Nothing
        OtherField6.DisplayFieldAlias = "CNPJ/CPF"
        OtherField6.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField6.DisplayFieldName = "document"
        OtherField6.DisplayMainFieldName = "id"
        OtherField6.DisplayTableAlias = Nothing
        OtherField6.DisplayTableName = "person"
        OtherField6.Freeze = False
        OtherField6.IfNull = Nothing
        OtherField6.Prefix = Nothing
        OtherField6.Suffix = Nothing
        OtherField7.DisplayFieldAlias = "Cidade"
        OtherField7.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField7.DisplayFieldName = "name"
        OtherField7.DisplayMainFieldName = "id"
        OtherField7.DisplayTableAlias = Nothing
        OtherField7.DisplayTableName = "city"
        OtherField7.Freeze = False
        OtherField7.IfNull = Nothing
        OtherField7.Prefix = Nothing
        OtherField7.Suffix = Nothing
        OtherField8.DisplayFieldAlias = "Estado"
        OtherField8.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField8.DisplayFieldName = "name"
        OtherField8.DisplayMainFieldName = "id"
        OtherField8.DisplayTableAlias = Nothing
        OtherField8.DisplayTableName = "state"
        OtherField8.Freeze = False
        OtherField8.IfNull = Nothing
        OtherField8.Prefix = Nothing
        OtherField8.Suffix = Nothing
        Me.QbxManufacturer.OtherFields.Add(OtherField5)
        Me.QbxManufacturer.OtherFields.Add(OtherField6)
        Me.QbxManufacturer.OtherFields.Add(OtherField7)
        Me.QbxManufacturer.OtherFields.Add(OtherField8)
        Parameter3.ParameterName = "@isprovider"
        Parameter3.ParameterValue = "1"
        Parameter4.ParameterName = "@statusid"
        Parameter4.ParameterValue = "0"
        Me.QbxManufacturer.Parameters.Add(Parameter3)
        Me.QbxManufacturer.Parameters.Add(Parameter4)
        Me.QbxManufacturer.Prefix = Nothing
        Relation4.Operator = "="
        Relation4.RelateFieldName = "personid"
        Relation4.RelateTableAlias = Nothing
        Relation4.RelateTableName = "personaddress"
        Relation4.RelationType = "LEFT"
        Relation4.WithFieldName = "id"
        Relation4.WithTableAlias = Nothing
        Relation4.WithTableName = "person"
        Relation5.Operator = "="
        Relation5.RelateFieldName = "id"
        Relation5.RelateTableAlias = Nothing
        Relation5.RelateTableName = "city"
        Relation5.RelationType = "LEFT"
        Relation5.WithFieldName = "cityid"
        Relation5.WithTableAlias = Nothing
        Relation5.WithTableName = "personaddress"
        Relation6.Operator = "="
        Relation6.RelateFieldName = "id"
        Relation6.RelateTableAlias = Nothing
        Relation6.RelateTableName = "state"
        Relation6.RelationType = "LEFT"
        Relation6.WithFieldName = "stateid"
        Relation6.WithTableAlias = Nothing
        Relation6.WithTableName = "city"
        Me.QbxManufacturer.Relations.Add(Relation4)
        Me.QbxManufacturer.Relations.Add(Relation5)
        Me.QbxManufacturer.Relations.Add(Relation6)
        Me.QbxManufacturer.Size = New System.Drawing.Size(331, 23)
        Me.QbxManufacturer.Suffix = Nothing
        Me.QbxManufacturer.TabIndex = 3
        '
        'FlpManufacturer
        '
        Me.FlpManufacturer.Controls.Add(Me.BtnFilter)
        Me.FlpManufacturer.Controls.Add(Me.BtnView)
        Me.FlpManufacturer.Controls.Add(Me.BtnNew)
        Me.FlpManufacturer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpManufacturer.Location = New System.Drawing.Point(270, 52)
        Me.FlpManufacturer.Name = "FlpManufacturer"
        Me.FlpManufacturer.Size = New System.Drawing.Size(69, 21)
        Me.FlpManufacturer.TabIndex = 4
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
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(9, 24)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtName.MaxLength = 100
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(331, 23)
        Me.TxtName.TabIndex = 1
        '
        'TabMaintenance
        '
        Me.TabMaintenance.Controls.Add(Me.TcMaintenance)
        Me.TabMaintenance.Location = New System.Drawing.Point(4, 26)
        Me.TabMaintenance.Name = "TabMaintenance"
        Me.TabMaintenance.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMaintenance.Size = New System.Drawing.Size(346, 107)
        Me.TabMaintenance.TabIndex = 9
        Me.TabMaintenance.Text = "Manutenção"
        Me.TabMaintenance.UseVisualStyleBackColor = True
        '
        'TcMaintenance
        '
        Me.TcMaintenance.Controls.Add(Me.TabWorkedHour)
        Me.TcMaintenance.Controls.Add(Me.TabPassedDay)
        Me.TcMaintenance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcMaintenance.Location = New System.Drawing.Point(3, 3)
        Me.TcMaintenance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcMaintenance.Multiline = True
        Me.TcMaintenance.Name = "TcMaintenance"
        Me.TcMaintenance.SelectedIndex = 0
        Me.TcMaintenance.Size = New System.Drawing.Size(340, 101)
        Me.TcMaintenance.TabIndex = 3
        '
        'TabWorkedHour
        '
        Me.TabWorkedHour.Controls.Add(Me.DgvCompressorSellableWorkedHour)
        Me.TabWorkedHour.Controls.Add(Me.TsMaintenanceHour)
        Me.TabWorkedHour.Location = New System.Drawing.Point(4, 26)
        Me.TabWorkedHour.Name = "TabWorkedHour"
        Me.TabWorkedHour.Padding = New System.Windows.Forms.Padding(3)
        Me.TabWorkedHour.Size = New System.Drawing.Size(332, 71)
        Me.TabWorkedHour.TabIndex = 7
        Me.TabWorkedHour.Text = "Hora Trabalhada"
        Me.TabWorkedHour.UseVisualStyleBackColor = True
        '
        'DgvCompressorSellableWorkedHour
        '
        Me.DgvCompressorSellableWorkedHour.AllowUserToAddRows = False
        Me.DgvCompressorSellableWorkedHour.AllowUserToDeleteRows = False
        Me.DgvCompressorSellableWorkedHour.AllowUserToOrderColumns = True
        Me.DgvCompressorSellableWorkedHour.AllowUserToResizeRows = False
        Me.DgvCompressorSellableWorkedHour.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvCompressorSellableWorkedHour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCompressorSellableWorkedHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCompressorSellableWorkedHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCompressorSellableWorkedHour.Location = New System.Drawing.Point(3, 28)
        Me.DgvCompressorSellableWorkedHour.MultiSelect = False
        Me.DgvCompressorSellableWorkedHour.Name = "DgvCompressorSellableWorkedHour"
        Me.DgvCompressorSellableWorkedHour.ReadOnly = True
        Me.DgvCompressorSellableWorkedHour.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvCompressorSellableWorkedHour.RowHeadersVisible = False
        Me.DgvCompressorSellableWorkedHour.RowTemplate.Height = 26
        Me.DgvCompressorSellableWorkedHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCompressorSellableWorkedHour.Size = New System.Drawing.Size(326, 40)
        Me.DgvCompressorSellableWorkedHour.TabIndex = 7
        '
        'TsMaintenanceHour
        '
        Me.TsMaintenanceHour.BackColor = System.Drawing.Color.Transparent
        Me.TsMaintenanceHour.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMaintenanceHour.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMaintenanceHour.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeSellableWorkedHour, Me.BtnEditSellableWorkedHour, Me.BtnDeleteSellableWorkedHour, Me.LblFilterSellableWorkedHour, Me.TxtFilterPartWorkedHour})
        Me.TsMaintenanceHour.Location = New System.Drawing.Point(3, 3)
        Me.TsMaintenanceHour.Name = "TsMaintenanceHour"
        Me.TsMaintenanceHour.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMaintenanceHour.Size = New System.Drawing.Size(326, 25)
        Me.TsMaintenanceHour.TabIndex = 8
        Me.TsMaintenanceHour.Text = "ToolStrip2"
        '
        'BtnIncludeSellableWorkedHour
        '
        Me.BtnIncludeSellableWorkedHour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeSellableWorkedHour.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeSellableWorkedHour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeSellableWorkedHour.Name = "BtnIncludeSellableWorkedHour"
        Me.BtnIncludeSellableWorkedHour.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeSellableWorkedHour.Text = "Incluir Peça/Serviço"
        '
        'BtnEditSellableWorkedHour
        '
        Me.BtnEditSellableWorkedHour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditSellableWorkedHour.Enabled = False
        Me.BtnEditSellableWorkedHour.Image = CType(resources.GetObject("BtnEditSellableWorkedHour.Image"), System.Drawing.Image)
        Me.BtnEditSellableWorkedHour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditSellableWorkedHour.Name = "BtnEditSellableWorkedHour"
        Me.BtnEditSellableWorkedHour.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditSellableWorkedHour.Text = "Editar Peça/Serviço"
        Me.BtnEditSellableWorkedHour.ToolTipText = "Editar"
        '
        'BtnDeleteSellableWorkedHour
        '
        Me.BtnDeleteSellableWorkedHour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteSellableWorkedHour.Enabled = False
        Me.BtnDeleteSellableWorkedHour.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteSellableWorkedHour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteSellableWorkedHour.Name = "BtnDeleteSellableWorkedHour"
        Me.BtnDeleteSellableWorkedHour.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteSellableWorkedHour.Text = "Excluir Peça/Serviço"
        '
        'LblFilterSellableWorkedHour
        '
        Me.LblFilterSellableWorkedHour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LblFilterSellableWorkedHour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblFilterSellableWorkedHour.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.LblFilterSellableWorkedHour.Name = "LblFilterSellableWorkedHour"
        Me.LblFilterSellableWorkedHour.Size = New System.Drawing.Size(46, 25)
        Me.LblFilterSellableWorkedHour.Text = "Filtrar:"
        '
        'TxtFilterPartWorkedHour
        '
        Me.TxtFilterPartWorkedHour.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterPartWorkedHour.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterPartWorkedHour.Name = "TxtFilterPartWorkedHour"
        Me.TxtFilterPartWorkedHour.Size = New System.Drawing.Size(200, 23)
        '
        'TabPassedDay
        '
        Me.TabPassedDay.Controls.Add(Me.DgvCompressorSellableElapsedDay)
        Me.TabPassedDay.Controls.Add(Me.TsMaintenanceDay)
        Me.TabPassedDay.Location = New System.Drawing.Point(4, 26)
        Me.TabPassedDay.Name = "TabPassedDay"
        Me.TabPassedDay.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPassedDay.Size = New System.Drawing.Size(332, 71)
        Me.TabPassedDay.TabIndex = 8
        Me.TabPassedDay.Text = "Dia Corrido"
        Me.TabPassedDay.UseVisualStyleBackColor = True
        '
        'DgvCompressorSellableElapsedDay
        '
        Me.DgvCompressorSellableElapsedDay.AllowUserToAddRows = False
        Me.DgvCompressorSellableElapsedDay.AllowUserToDeleteRows = False
        Me.DgvCompressorSellableElapsedDay.AllowUserToOrderColumns = True
        Me.DgvCompressorSellableElapsedDay.AllowUserToResizeRows = False
        Me.DgvCompressorSellableElapsedDay.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvCompressorSellableElapsedDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCompressorSellableElapsedDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCompressorSellableElapsedDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCompressorSellableElapsedDay.Location = New System.Drawing.Point(3, 28)
        Me.DgvCompressorSellableElapsedDay.MultiSelect = False
        Me.DgvCompressorSellableElapsedDay.Name = "DgvCompressorSellableElapsedDay"
        Me.DgvCompressorSellableElapsedDay.ReadOnly = True
        Me.DgvCompressorSellableElapsedDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvCompressorSellableElapsedDay.RowHeadersVisible = False
        Me.DgvCompressorSellableElapsedDay.RowTemplate.Height = 26
        Me.DgvCompressorSellableElapsedDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCompressorSellableElapsedDay.Size = New System.Drawing.Size(326, 40)
        Me.DgvCompressorSellableElapsedDay.TabIndex = 11
        '
        'TsMaintenanceDay
        '
        Me.TsMaintenanceDay.BackColor = System.Drawing.Color.Transparent
        Me.TsMaintenanceDay.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMaintenanceDay.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMaintenanceDay.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludePartElapsedDay, Me.BtnEditPartElapsedDay, Me.BtnDeletePartElapsedDay, Me.ToolStripLabel4, Me.TxtFilterElapsedDay})
        Me.TsMaintenanceDay.Location = New System.Drawing.Point(3, 3)
        Me.TsMaintenanceDay.Name = "TsMaintenanceDay"
        Me.TsMaintenanceDay.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMaintenanceDay.Size = New System.Drawing.Size(326, 25)
        Me.TsMaintenanceDay.TabIndex = 10
        Me.TsMaintenanceDay.Text = "ToolStrip2"
        '
        'BtnIncludePartElapsedDay
        '
        Me.BtnIncludePartElapsedDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludePartElapsedDay.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludePartElapsedDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludePartElapsedDay.Name = "BtnIncludePartElapsedDay"
        Me.BtnIncludePartElapsedDay.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludePartElapsedDay.Text = "Incluir Peça/Serviço"
        '
        'BtnEditPartElapsedDay
        '
        Me.BtnEditPartElapsedDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditPartElapsedDay.Enabled = False
        Me.BtnEditPartElapsedDay.Image = CType(resources.GetObject("BtnEditPartElapsedDay.Image"), System.Drawing.Image)
        Me.BtnEditPartElapsedDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditPartElapsedDay.Name = "BtnEditPartElapsedDay"
        Me.BtnEditPartElapsedDay.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditPartElapsedDay.Text = "Editar Peça/Serviço"
        Me.BtnEditPartElapsedDay.ToolTipText = "Editar"
        '
        'BtnDeletePartElapsedDay
        '
        Me.BtnDeletePartElapsedDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeletePartElapsedDay.Enabled = False
        Me.BtnDeletePartElapsedDay.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeletePartElapsedDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeletePartElapsedDay.Name = "BtnDeletePartElapsedDay"
        Me.BtnDeletePartElapsedDay.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeletePartElapsedDay.Text = "Excluir Peça/Serviço"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel4.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(46, 25)
        Me.ToolStripLabel4.Text = "Filtrar:"
        '
        'TxtFilterElapsedDay
        '
        Me.TxtFilterElapsedDay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterElapsedDay.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterElapsedDay.Name = "TxtFilterElapsedDay"
        Me.TxtFilterElapsedDay.Size = New System.Drawing.Size(200, 23)
        '
        'DgvCompressorSellableWorkedHourLayout
        '
        Me.DgvCompressorSellableWorkedHourLayout.DataGridView = Me.DgvCompressorSellableWorkedHour
        Me.DgvCompressorSellableWorkedHourLayout.Routine = Manager.Routine.CompressorSellableWorkedHour
        '
        'DgvCompressorSellableElapsedDayLayout
        '
        Me.DgvCompressorSellableElapsedDayLayout.DataGridView = Me.DgvCompressorSellableElapsedDay
        Me.DgvCompressorSellableElapsedDayLayout.Routine = Manager.Routine.CompressorSellableElapsedDay
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'FrmCompressor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(354, 231)
        Me.Controls.Add(Me.TcCompressor)
        Me.Controls.Add(Me.PnButtons)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmCompressor"
        Me.ShowIcon = false
        Me.Text = "Compressor"
        Me.PnButtons.ResumeLayout(false)
        Me.TsTitle.ResumeLayout(false)
        Me.TsTitle.PerformLayout
        Me.TsNavigation.ResumeLayout(false)
        Me.TsNavigation.PerformLayout
        CType(Me.EprValidation,System.ComponentModel.ISupportInitialize).EndInit
        Me.TcCompressor.ResumeLayout(false)
        Me.TabMain.ResumeLayout(false)
        Me.TabMain.PerformLayout
        Me.FlpManufacturer.ResumeLayout(false)
        Me.TabMaintenance.ResumeLayout(false)
        Me.TcMaintenance.ResumeLayout(false)
        Me.TabWorkedHour.ResumeLayout(false)
        Me.TabWorkedHour.PerformLayout
        CType(Me.DgvCompressorSellableWorkedHour,System.ComponentModel.ISupportInitialize).EndInit
        Me.TsMaintenanceHour.ResumeLayout(false)
        Me.TsMaintenanceHour.PerformLayout
        Me.TabPassedDay.ResumeLayout(false)
        Me.TabPassedDay.PerformLayout
        CType(Me.DgvCompressorSellableElapsedDay,System.ComponentModel.ISupportInitialize).EndInit
        Me.TsMaintenanceDay.ResumeLayout(false)
        Me.TsMaintenanceDay.PerformLayout
        CType(Me.EprInformation,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents LblCreationDate As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents LblManufacturer As Label
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents TcCompressor As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents DgvCompressorSellableWorkedHourLayout As DataGridViewLayout
    Friend WithEvents PnButtons As Panel
    Friend WithEvents DgvCompressorSellableElapsedDayLayout As DataGridViewLayout
    Friend WithEvents FlpManufacturer As FlowLayoutPanel
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents TabMaintenance As TabPage
    Friend WithEvents TcMaintenance As TabControl
    Friend WithEvents TabWorkedHour As TabPage
    Friend WithEvents DgvCompressorSellableWorkedHour As DataGridView
    Friend WithEvents TsMaintenanceHour As ToolStrip
    Friend WithEvents BtnIncludeSellableWorkedHour As ToolStripButton
    Friend WithEvents BtnEditSellableWorkedHour As ToolStripButton
    Friend WithEvents BtnDeleteSellableWorkedHour As ToolStripButton
    Friend WithEvents LblFilterSellableWorkedHour As ToolStripLabel
    Friend WithEvents TxtFilterPartWorkedHour As ToolStripTextBox
    Friend WithEvents TabPassedDay As TabPage
    Friend WithEvents DgvCompressorSellableElapsedDay As DataGridView
    Friend WithEvents TsMaintenanceDay As ToolStrip
    Friend WithEvents BtnIncludePartElapsedDay As ToolStripButton
    Friend WithEvents BtnEditPartElapsedDay As ToolStripButton
    Friend WithEvents BtnDeletePartElapsedDay As ToolStripButton
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents TxtFilterElapsedDay As ToolStripTextBox
    Friend WithEvents QbxManufacturer As ControlLibrary.QueriedBox
End Class
