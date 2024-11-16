<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPersonAddress
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
        Dim OtherField5 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter3 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation4 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField3 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField4 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation2 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation3 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
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
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.PnButton = New System.Windows.Forms.Panel()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.CbxIsMainAddress = New ControlLibrary.ToolStripCheckBox()
        Me.QbxCity = New ControlLibrary.QueriedBox()
        Me.CbxContributionType = New System.Windows.Forms.ComboBox()
        Me.LblZipCode = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblStateDocument = New System.Windows.Forms.Label()
        Me.LblCarrier = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblCity = New System.Windows.Forms.Label()
        Me.LblDistrict = New System.Windows.Forms.Label()
        Me.LblNumber = New System.Windows.Forms.Label()
        Me.LblStreet = New System.Windows.Forms.Label()
        Me.LblContributionType = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TmrQueriedBoxCity = New System.Windows.Forms.Timer(Me.components)
        Me.TmrQueriedBoxCarrier = New System.Windows.Forms.Timer(Me.components)
        Me.TxtZipCode = New System.Windows.Forms.TextBox()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.TxtCityDocument = New System.Windows.Forms.TextBox()
        Me.TxtStateDocument = New System.Windows.Forms.TextBox()
        Me.TxtDistrict = New System.Windows.Forms.TextBox()
        Me.TxtComplement = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtStreet = New System.Windows.Forms.TextBox()
        Me.FlpCity = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterCity = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCity = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewCity = New ControlLibrary.NoFocusCueButton()
        Me.FlpCarrier = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterCarrier = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCarrier = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewCarrier = New ControlLibrary.NoFocusCueButton()
        Me.BtnZipCode = New ControlLibrary.NoFocusCueButton()
        Me.QbxCarrier = New ControlLibrary.QueriedBox()
        Me.TsMain.SuspendLayout()
        Me.PnButton.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsData.SuspendLayout()
        Me.FlpCity.SuspendLayout()
        Me.FlpCarrier.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(637, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(536, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsMain
        '
        Me.TsMain.AutoSize = False
        Me.TsMain.BackColor = System.Drawing.Color.White
        Me.TsMain.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog, Me.ToolStripButton1})
        Me.TsMain.Location = New System.Drawing.Point(0, 0)
        Me.TsMain.Name = "TsMain"
        Me.TsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMain.Size = New System.Drawing.Size(744, 25)
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
        Me.BtnInclude.Text = "Incluir Endereço"
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
        Me.BtnDelete.Text = "Excluir Endereço"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Endereço"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Endereço Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Endereço"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Endereço"
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'PnButton
        '
        Me.PnButton.BackColor = System.Drawing.Color.White
        Me.PnButton.Controls.Add(Me.BtnSave)
        Me.PnButton.Controls.Add(Me.BtnClose)
        Me.PnButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButton.Location = New System.Drawing.Point(0, 247)
        Me.PnButton.Name = "PnButton"
        Me.PnButton.Size = New System.Drawing.Size(744, 44)
        Me.PnButton.TabIndex = 28
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
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreation, Me.LblCreationValue, Me.CbxIsMainAddress})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(744, 25)
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
        'CbxIsMainAddress
        '
        Me.CbxIsMainAddress.Checked = False
        Me.CbxIsMainAddress.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.CbxIsMainAddress.Name = "CbxIsMainAddress"
        Me.CbxIsMainAddress.Size = New System.Drawing.Size(147, 22)
        Me.CbxIsMainAddress.Text = "Endereço Principal"
        '
        'QbxCity
        '
        Me.QbxCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCity.CharactersToQuery = 1
        Condition3.FieldName = "statusid"
        Condition3.Operator = "="
        Condition3.TableNameOrAlias = "city"
        Condition3.Value = "@statusid"
        Me.QbxCity.Conditions.Add(Condition3)
        Me.QbxCity.DebugOnTextChanged = False
        Me.QbxCity.DisplayFieldAlias = "Nome"
        Me.QbxCity.DisplayFieldName = "name"
        Me.QbxCity.DisplayMainFieldName = "id"
        Me.QbxCity.DisplayTableAlias = Nothing
        Me.QbxCity.DisplayTableName = "city"
        Me.QbxCity.Distinct = False
        Me.QbxCity.DropDownAutoStretchRight = False
        Me.QbxCity.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCity.IfNull = Nothing
        Me.QbxCity.Location = New System.Drawing.Point(365, 167)
        Me.QbxCity.MainReturnFieldName = "id"
        Me.QbxCity.MainTableAlias = Nothing
        Me.QbxCity.MainTableName = "city"
        Me.QbxCity.Name = "QbxCity"
        OtherField5.DisplayFieldAlias = "UF"
        OtherField5.DisplayFieldName = "shortname"
        OtherField5.DisplayMainFieldName = "id"
        OtherField5.DisplayTableAlias = Nothing
        OtherField5.DisplayTableName = "state"
        OtherField5.Freeze = True
        OtherField5.IfNull = Nothing
        OtherField5.Prefix = "-"
        OtherField5.Suffix = ""
        Me.QbxCity.OtherFields.Add(OtherField5)
        Parameter3.ParameterName = "@statusid"
        Parameter3.ParameterValue = "0"
        Me.QbxCity.Parameters.Add(Parameter3)
        Me.QbxCity.Prefix = Nothing
        Relation4.Operator = "="
        Relation4.RelateFieldName = "id"
        Relation4.RelateTableAlias = "state"
        Relation4.RelateTableName = "state"
        Relation4.RelationType = "INNER"
        Relation4.WithFieldName = "stateid"
        Relation4.WithTableAlias = "city"
        Relation4.WithTableName = "city"
        Me.QbxCity.Relations.Add(Relation4)
        Me.QbxCity.Size = New System.Drawing.Size(367, 23)
        Me.QbxCity.Suffix = Nothing
        Me.QbxCity.TabIndex = 17
        '
        'CbxContributionType
        '
        Me.CbxContributionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxContributionType.FormattingEnabled = True
        Me.CbxContributionType.Location = New System.Drawing.Point(269, 213)
        Me.CbxContributionType.Name = "CbxContributionType"
        Me.CbxContributionType.Size = New System.Drawing.Size(153, 25)
        Me.CbxContributionType.TabIndex = 24
        '
        'LblZipCode
        '
        Me.LblZipCode.AutoSize = True
        Me.LblZipCode.Location = New System.Drawing.Point(12, 101)
        Me.LblZipCode.Name = "LblZipCode"
        Me.LblZipCode.Size = New System.Drawing.Size(36, 17)
        Me.LblZipCode.TabIndex = 5
        Me.LblZipCode.Text = "Cep"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(420, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Complemento"
        '
        'LblStateDocument
        '
        Me.LblStateDocument.AutoSize = True
        Me.LblStateDocument.Location = New System.Drawing.Point(14, 193)
        Me.LblStateDocument.Name = "LblStateDocument"
        Me.LblStateDocument.Size = New System.Drawing.Size(95, 17)
        Me.LblStateDocument.TabIndex = 19
        Me.LblStateDocument.Text = "Insc. Estadual"
        '
        'LblCarrier
        '
        Me.LblCarrier.AutoSize = True
        Me.LblCarrier.Location = New System.Drawing.Point(425, 193)
        Me.LblCarrier.Name = "LblCarrier"
        Me.LblCarrier.Size = New System.Drawing.Size(106, 17)
        Me.LblCarrier.TabIndex = 25
        Me.LblCarrier.Text = "Transportadora"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(140, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 17)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Insc. Municipal"
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Location = New System.Drawing.Point(362, 147)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(57, 17)
        Me.LblCity.TabIndex = 16
        Me.LblCity.Text = "Cidade"
        '
        'LblDistrict
        '
        Me.LblDistrict.AutoSize = True
        Me.LblDistrict.Location = New System.Drawing.Point(12, 147)
        Me.LblDistrict.Name = "LblDistrict"
        Me.LblDistrict.Size = New System.Drawing.Size(44, 17)
        Me.LblDistrict.TabIndex = 14
        Me.LblDistrict.Text = "Bairro"
        '
        'LblNumber
        '
        Me.LblNumber.AutoSize = True
        Me.LblNumber.Location = New System.Drawing.Point(357, 101)
        Me.LblNumber.Name = "LblNumber"
        Me.LblNumber.Size = New System.Drawing.Size(23, 17)
        Me.LblNumber.TabIndex = 10
        Me.LblNumber.Text = "Nº"
        '
        'LblStreet
        '
        Me.LblStreet.AutoSize = True
        Me.LblStreet.Location = New System.Drawing.Point(88, 101)
        Me.LblStreet.Name = "LblStreet"
        Me.LblStreet.Size = New System.Drawing.Size(33, 17)
        Me.LblStreet.TabIndex = 8
        Me.LblStreet.Text = "Rua"
        '
        'LblContributionType
        '
        Me.LblContributionType.AutoSize = True
        Me.LblContributionType.Location = New System.Drawing.Point(266, 196)
        Me.LblContributionType.Name = "LblContributionType"
        Me.LblContributionType.Size = New System.Drawing.Size(129, 17)
        Me.LblContributionType.TabIndex = 23
        Me.LblContributionType.Text = "Contribuição ICMS"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(12, 55)
        Me.LblName.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "Nome"
        '
        'TmrQueriedBoxCity
        '
        Me.TmrQueriedBoxCity.Enabled = True
        Me.TmrQueriedBoxCity.Interval = 300
        '
        'TmrQueriedBoxCarrier
        '
        Me.TmrQueriedBoxCarrier.Enabled = True
        Me.TmrQueriedBoxCarrier.Interval = 300
        '
        'TxtZipCode
        '
        Me.TxtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZipCode.Location = New System.Drawing.Point(15, 121)
        Me.TxtZipCode.MaxLength = 10
        Me.TxtZipCode.Name = "TxtZipCode"
        Me.TxtZipCode.Size = New System.Drawing.Size(70, 23)
        Me.TxtZipCode.TabIndex = 6
        Me.TxtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNumber
        '
        Me.TxtNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumber.Location = New System.Drawing.Point(360, 121)
        Me.TxtNumber.MaxLength = 10
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(57, 23)
        Me.TxtNumber.TabIndex = 11
        Me.TxtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCityDocument
        '
        Me.TxtCityDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCityDocument.Location = New System.Drawing.Point(143, 213)
        Me.TxtCityDocument.MaxLength = 20
        Me.TxtCityDocument.Name = "TxtCityDocument"
        Me.TxtCityDocument.Size = New System.Drawing.Size(120, 23)
        Me.TxtCityDocument.TabIndex = 22
        '
        'TxtStateDocument
        '
        Me.TxtStateDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStateDocument.Location = New System.Drawing.Point(17, 213)
        Me.TxtStateDocument.MaxLength = 20
        Me.TxtStateDocument.Name = "TxtStateDocument"
        Me.TxtStateDocument.Size = New System.Drawing.Size(120, 23)
        Me.TxtStateDocument.TabIndex = 20
        '
        'TxtDistrict
        '
        Me.TxtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDistrict.Location = New System.Drawing.Point(15, 167)
        Me.TxtDistrict.MaxLength = 255
        Me.TxtDistrict.Name = "TxtDistrict"
        Me.TxtDistrict.Size = New System.Drawing.Size(344, 23)
        Me.TxtDistrict.TabIndex = 15
        '
        'TxtComplement
        '
        Me.TxtComplement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplement.Location = New System.Drawing.Point(423, 121)
        Me.TxtComplement.MaxLength = 255
        Me.TxtComplement.Name = "TxtComplement"
        Me.TxtComplement.Size = New System.Drawing.Size(309, 23)
        Me.TxtComplement.TabIndex = 13
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(15, 75)
        Me.TxtName.MaxLength = 100
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(717, 23)
        Me.TxtName.TabIndex = 3
        '
        'TxtStreet
        '
        Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStreet.Location = New System.Drawing.Point(91, 121)
        Me.TxtStreet.MaxLength = 255
        Me.TxtStreet.Name = "TxtStreet"
        Me.TxtStreet.Size = New System.Drawing.Size(263, 23)
        Me.TxtStreet.TabIndex = 9
        '
        'FlpCity
        '
        Me.FlpCity.Controls.Add(Me.BtnFilterCity)
        Me.FlpCity.Controls.Add(Me.BtnViewCity)
        Me.FlpCity.Controls.Add(Me.BtnNewCity)
        Me.FlpCity.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCity.Location = New System.Drawing.Point(662, 146)
        Me.FlpCity.Name = "FlpCity"
        Me.FlpCity.Size = New System.Drawing.Size(69, 21)
        Me.FlpCity.TabIndex = 18
        '
        'BtnFilterCity
        '
        Me.BtnFilterCity.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterCity.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterCity.FlatAppearance.BorderSize = 0
        Me.BtnFilterCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterCity.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterCity.Name = "BtnFilterCity"
        Me.BtnFilterCity.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterCity.TabIndex = 2
        Me.BtnFilterCity.TabStop = False
        Me.BtnFilterCity.TooltipText = ""
        Me.BtnFilterCity.UseVisualStyleBackColor = False
        Me.BtnFilterCity.Visible = False
        '
        'BtnViewCity
        '
        Me.BtnViewCity.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewCity.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewCity.FlatAppearance.BorderSize = 0
        Me.BtnViewCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewCity.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewCity.Name = "BtnViewCity"
        Me.BtnViewCity.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewCity.TabIndex = 1
        Me.BtnViewCity.TabStop = False
        Me.BtnViewCity.TooltipText = ""
        Me.BtnViewCity.UseVisualStyleBackColor = False
        Me.BtnViewCity.Visible = False
        '
        'BtnNewCity
        '
        Me.BtnNewCity.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewCity.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewCity.FlatAppearance.BorderSize = 0
        Me.BtnNewCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewCity.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewCity.Name = "BtnNewCity"
        Me.BtnNewCity.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewCity.TabIndex = 0
        Me.BtnNewCity.TabStop = False
        Me.BtnNewCity.TooltipText = ""
        Me.BtnNewCity.UseVisualStyleBackColor = False
        Me.BtnNewCity.Visible = False
        '
        'FlpCarrier
        '
        Me.FlpCarrier.Controls.Add(Me.BtnFilterCarrier)
        Me.FlpCarrier.Controls.Add(Me.BtnViewCarrier)
        Me.FlpCarrier.Controls.Add(Me.BtnNewCarrier)
        Me.FlpCarrier.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCarrier.Location = New System.Drawing.Point(662, 192)
        Me.FlpCarrier.Name = "FlpCarrier"
        Me.FlpCarrier.Size = New System.Drawing.Size(69, 21)
        Me.FlpCarrier.TabIndex = 27
        '
        'BtnFilterCarrier
        '
        Me.BtnFilterCarrier.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterCarrier.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterCarrier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterCarrier.FlatAppearance.BorderSize = 0
        Me.BtnFilterCarrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterCarrier.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterCarrier.Name = "BtnFilterCarrier"
        Me.BtnFilterCarrier.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterCarrier.TabIndex = 2
        Me.BtnFilterCarrier.TabStop = False
        Me.BtnFilterCarrier.TooltipText = ""
        Me.BtnFilterCarrier.UseVisualStyleBackColor = False
        Me.BtnFilterCarrier.Visible = False
        '
        'BtnViewCarrier
        '
        Me.BtnViewCarrier.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewCarrier.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewCarrier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewCarrier.FlatAppearance.BorderSize = 0
        Me.BtnViewCarrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewCarrier.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewCarrier.Name = "BtnViewCarrier"
        Me.BtnViewCarrier.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewCarrier.TabIndex = 1
        Me.BtnViewCarrier.TabStop = False
        Me.BtnViewCarrier.TooltipText = ""
        Me.BtnViewCarrier.UseVisualStyleBackColor = False
        Me.BtnViewCarrier.Visible = False
        '
        'BtnNewCarrier
        '
        Me.BtnNewCarrier.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewCarrier.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewCarrier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewCarrier.FlatAppearance.BorderSize = 0
        Me.BtnNewCarrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewCarrier.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewCarrier.Name = "BtnNewCarrier"
        Me.BtnNewCarrier.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewCarrier.TabIndex = 0
        Me.BtnNewCarrier.TabStop = False
        Me.BtnNewCarrier.TooltipText = ""
        Me.BtnNewCarrier.UseVisualStyleBackColor = False
        Me.BtnNewCarrier.Visible = False
        '
        'BtnZipCode
        '
        Me.BtnZipCode.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnZipCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnZipCode.Enabled = False
        Me.BtnZipCode.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnZipCode.FlatAppearance.BorderSize = 0
        Me.BtnZipCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnZipCode.Location = New System.Drawing.Point(62, 98)
        Me.BtnZipCode.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.BtnZipCode.Name = "BtnZipCode"
        Me.BtnZipCode.Size = New System.Drawing.Size(23, 23)
        Me.BtnZipCode.TabIndex = 7
        Me.BtnZipCode.TooltipText = ""
        Me.BtnZipCode.UseVisualStyleBackColor = True
        '
        'QbxCarrier
        '
        Me.QbxCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCarrier.CharactersToQuery = 1
        Condition1.FieldName = "iscarrier"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@iscarrier"
        Condition2.FieldName = "statusid"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@statusid"
        Me.QbxCarrier.Conditions.Add(Condition1)
        Me.QbxCarrier.Conditions.Add(Condition2)
        Me.QbxCarrier.DebugOnTextChanged = False
        Me.QbxCarrier.DisplayFieldAlias = "Nome Curto"
        Me.QbxCarrier.DisplayFieldName = "shortname"
        Me.QbxCarrier.DisplayMainFieldName = "id"
        Me.QbxCarrier.DisplayTableAlias = Nothing
        Me.QbxCarrier.DisplayTableName = "person"
        Me.QbxCarrier.Distinct = True
        Me.QbxCarrier.DropDownAutoStretchRight = False
        Me.QbxCarrier.DropDownStretchLeft = 411
        Me.QbxCarrier.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCarrier.IfNull = Nothing
        Me.QbxCarrier.Location = New System.Drawing.Point(428, 213)
        Me.QbxCarrier.MainReturnFieldName = "id"
        Me.QbxCarrier.MainTableAlias = Nothing
        Me.QbxCarrier.MainTableName = "person"
        Me.QbxCarrier.Name = "QbxCarrier"
        OtherField1.DisplayFieldAlias = "Nome"
        OtherField1.DisplayFieldName = "name"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "person"
        OtherField1.Freeze = False
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        OtherField2.DisplayFieldAlias = "CNPJ/CPF"
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        OtherField3.DisplayFieldAlias = "Cidade"
        OtherField3.DisplayFieldName = "name"
        OtherField3.DisplayMainFieldName = "id"
        OtherField3.DisplayTableAlias = Nothing
        OtherField3.DisplayTableName = "city"
        OtherField3.Freeze = False
        OtherField3.IfNull = Nothing
        OtherField3.Prefix = Nothing
        OtherField3.Suffix = Nothing
        OtherField4.DisplayFieldAlias = "Estado"
        OtherField4.DisplayFieldName = "name"
        OtherField4.DisplayMainFieldName = "id"
        OtherField4.DisplayTableAlias = Nothing
        OtherField4.DisplayTableName = "state"
        OtherField4.Freeze = False
        OtherField4.IfNull = Nothing
        OtherField4.Prefix = Nothing
        OtherField4.Suffix = Nothing
        Me.QbxCarrier.OtherFields.Add(OtherField1)
        Me.QbxCarrier.OtherFields.Add(OtherField2)
        Me.QbxCarrier.OtherFields.Add(OtherField3)
        Me.QbxCarrier.OtherFields.Add(OtherField4)
        Parameter1.ParameterName = "@iscarrier"
        Parameter1.ParameterValue = "1"
        Parameter2.ParameterName = "@statusid"
        Parameter2.ParameterValue = "0"
        Me.QbxCarrier.Parameters.Add(Parameter1)
        Me.QbxCarrier.Parameters.Add(Parameter2)
        Me.QbxCarrier.Prefix = Nothing
        Relation1.Operator = "="
        Relation1.RelateFieldName = "personid"
        Relation1.RelateTableAlias = Nothing
        Relation1.RelateTableName = "personaddress"
        Relation1.RelationType = "LEFT"
        Relation1.WithFieldName = "id"
        Relation1.WithTableAlias = Nothing
        Relation1.WithTableName = "person"
        Relation2.Operator = "="
        Relation2.RelateFieldName = "id"
        Relation2.RelateTableAlias = Nothing
        Relation2.RelateTableName = "city"
        Relation2.RelationType = "LEFT"
        Relation2.WithFieldName = "cityid"
        Relation2.WithTableAlias = Nothing
        Relation2.WithTableName = "personaddress"
        Relation3.Operator = "="
        Relation3.RelateFieldName = "id"
        Relation3.RelateTableAlias = Nothing
        Relation3.RelateTableName = "state"
        Relation3.RelationType = "LEFT"
        Relation3.WithFieldName = "stateid"
        Relation3.WithTableAlias = Nothing
        Relation3.WithTableName = "city"
        Me.QbxCarrier.Relations.Add(Relation1)
        Me.QbxCarrier.Relations.Add(Relation2)
        Me.QbxCarrier.Relations.Add(Relation3)
        Me.QbxCarrier.Size = New System.Drawing.Size(304, 23)
        Me.QbxCarrier.Suffix = Nothing
        Me.QbxCarrier.TabIndex = 26
        '
        'FrmPersonAddress
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(744, 291)
        Me.Controls.Add(Me.QbxCarrier)
        Me.Controls.Add(Me.FlpCarrier)
        Me.Controls.Add(Me.FlpCity)
        Me.Controls.Add(Me.BtnZipCode)
        Me.Controls.Add(Me.QbxCity)
        Me.Controls.Add(Me.CbxContributionType)
        Me.Controls.Add(Me.LblZipCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtZipCode)
        Me.Controls.Add(Me.LblStateDocument)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.LblCarrier)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.TxtCityDocument)
        Me.Controls.Add(Me.LblDistrict)
        Me.Controls.Add(Me.TxtStateDocument)
        Me.Controls.Add(Me.TxtDistrict)
        Me.Controls.Add(Me.LblNumber)
        Me.Controls.Add(Me.TxtComplement)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.LblStreet)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtStreet)
        Me.Controls.Add(Me.LblContributionType)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.TsMain)
        Me.Controls.Add(Me.PnButton)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonAddress"
        Me.ShowIcon = False
        Me.Text = "Endereço"
        Me.TsMain.ResumeLayout(False)
        Me.TsMain.PerformLayout()
        Me.PnButton.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.FlpCity.ResumeLayout(False)
        Me.FlpCarrier.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents PnButton As Panel
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents QbxCity As ControlLibrary.QueriedBox
    Friend WithEvents CbxContributionType As ComboBox
    Friend WithEvents LblZipCode As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtZipCode As TextBox
    Friend WithEvents LblStateDocument As Label
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents LblCarrier As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblCity As Label
    Friend WithEvents TxtCityDocument As TextBox
    Friend WithEvents LblDistrict As Label
    Friend WithEvents TxtStateDocument As TextBox
    Friend WithEvents TxtDistrict As TextBox
    Friend WithEvents LblNumber As Label
    Friend WithEvents TxtComplement As TextBox
    Friend WithEvents LblStreet As Label
    Friend WithEvents TxtStreet As TextBox
    Friend WithEvents LblContributionType As Label
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents LblName As Label
    Friend WithEvents TxtName As TextBox
    Friend WithEvents TmrQueriedBoxCity As Timer
    Friend WithEvents BtnNewCarrier As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCarrier As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterCarrier As ControlLibrary.NoFocusCueButton
    Friend WithEvents TmrQueriedBoxCarrier As Timer
    Friend WithEvents BtnZipCode As ControlLibrary.NoFocusCueButton
    Friend WithEvents FlpCity As FlowLayoutPanel
    Friend WithEvents BtnNewCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents FlpCarrier As FlowLayoutPanel
    Friend WithEvents QbxCarrier As ControlLibrary.QueriedBox
    Friend WithEvents CbxIsMainAddress As ControlLibrary.ToolStripCheckBox
End Class
