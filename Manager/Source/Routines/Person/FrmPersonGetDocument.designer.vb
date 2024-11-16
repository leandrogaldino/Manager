<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPersonGetDocument
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
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GbxIdentity = New System.Windows.Forms.GroupBox()
        Me.TxtDocument = New System.Windows.Forms.TextBox()
        Me.TxtShortName = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblShortName = New System.Windows.Forms.Label()
        Me.LblDocument1 = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.CbxImportIdentity = New System.Windows.Forms.CheckBox()
        Me.GbxContact = New System.Windows.Forms.GroupBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtPhone = New System.Windows.Forms.TextBox()
        Me.TxtContactName = New System.Windows.Forms.TextBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblPhone = New System.Windows.Forms.Label()
        Me.LblContactName = New System.Windows.Forms.Label()
        Me.CbxImportContact = New System.Windows.Forms.CheckBox()
        Me.GbxAddress = New System.Windows.Forms.GroupBox()
        Me.QbxCity = New ControlLibrary.QueriedBox()
        Me.FlpCity = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterCity = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCity = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewCity = New ControlLibrary.NoFocusCueButton()
        Me.LblCity = New System.Windows.Forms.Label()
        Me.LblZipCode = New System.Windows.Forms.Label()
        Me.LblComplement = New System.Windows.Forms.Label()
        Me.TxtAddressName = New System.Windows.Forms.TextBox()
        Me.TxtZipCode = New System.Windows.Forms.TextBox()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.LblAddressName = New System.Windows.Forms.Label()
        Me.LblDistrict = New System.Windows.Forms.Label()
        Me.TxtDistrict = New System.Windows.Forms.TextBox()
        Me.LblNumber = New System.Windows.Forms.Label()
        Me.TxtComplement = New System.Windows.Forms.TextBox()
        Me.LblStreet = New System.Windows.Forms.Label()
        Me.TxtStreet = New System.Windows.Forms.TextBox()
        Me.CbxImportAddress = New System.Windows.Forms.CheckBox()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TmrQueriedBoxCity = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GbxIdentity.SuspendLayout()
        Me.GbxContact.SuspendLayout()
        Me.GbxAddress.SuspendLayout()
        Me.FlpCity.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 343)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 44)
        Me.Panel1.TabIndex = 6
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(423, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(524, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'GbxIdentity
        '
        Me.GbxIdentity.Controls.Add(Me.TxtDocument)
        Me.GbxIdentity.Controls.Add(Me.TxtShortName)
        Me.GbxIdentity.Controls.Add(Me.TxtName)
        Me.GbxIdentity.Controls.Add(Me.LblShortName)
        Me.GbxIdentity.Controls.Add(Me.LblDocument1)
        Me.GbxIdentity.Controls.Add(Me.LblName)
        Me.GbxIdentity.Location = New System.Drawing.Point(12, 12)
        Me.GbxIdentity.Name = "GbxIdentity"
        Me.GbxIdentity.Size = New System.Drawing.Size(607, 70)
        Me.GbxIdentity.TabIndex = 0
        Me.GbxIdentity.TabStop = False
        Me.GbxIdentity.Text = "Identificação"
        '
        'TxtDocument
        '
        Me.TxtDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocument.Location = New System.Drawing.Point(9, 39)
        Me.TxtDocument.Name = "TxtDocument"
        Me.TxtDocument.ReadOnly = True
        Me.TxtDocument.Size = New System.Drawing.Size(136, 23)
        Me.TxtDocument.TabIndex = 1
        '
        'TxtShortName
        '
        Me.TxtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtShortName.Location = New System.Drawing.Point(434, 39)
        Me.TxtShortName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtShortName.MaxLength = 50
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(167, 23)
        Me.TxtShortName.TabIndex = 5
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(151, 39)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtName.MaxLength = 255
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(277, 23)
        Me.TxtName.TabIndex = 3
        '
        'LblShortName
        '
        Me.LblShortName.AutoSize = True
        Me.LblShortName.Location = New System.Drawing.Point(430, 19)
        Me.LblShortName.Name = "LblShortName"
        Me.LblShortName.Size = New System.Drawing.Size(89, 17)
        Me.LblShortName.TabIndex = 4
        Me.LblShortName.Text = "Nome Curto"
        '
        'LblDocument1
        '
        Me.LblDocument1.AutoSize = True
        Me.LblDocument1.Location = New System.Drawing.Point(6, 19)
        Me.LblDocument1.Name = "LblDocument1"
        Me.LblDocument1.Size = New System.Drawing.Size(43, 17)
        Me.LblDocument1.TabIndex = 0
        Me.LblDocument1.Text = "CNPJ"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(149, 19)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "Nome"
        '
        'CbxImportIdentity
        '
        Me.CbxImportIdentity.AutoSize = True
        Me.CbxImportIdentity.Checked = True
        Me.CbxImportIdentity.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxImportIdentity.Location = New System.Drawing.Point(593, 14)
        Me.CbxImportIdentity.Name = "CbxImportIdentity"
        Me.CbxImportIdentity.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.CbxImportIdentity.Size = New System.Drawing.Size(20, 14)
        Me.CbxImportIdentity.TabIndex = 1
        Me.CbxImportIdentity.UseVisualStyleBackColor = True
        '
        'GbxContact
        '
        Me.GbxContact.Controls.Add(Me.TxtEmail)
        Me.GbxContact.Controls.Add(Me.TxtPhone)
        Me.GbxContact.Controls.Add(Me.TxtContactName)
        Me.GbxContact.Controls.Add(Me.LblEmail)
        Me.GbxContact.Controls.Add(Me.LblPhone)
        Me.GbxContact.Controls.Add(Me.LblContactName)
        Me.GbxContact.Enabled = False
        Me.GbxContact.Location = New System.Drawing.Point(12, 88)
        Me.GbxContact.Name = "GbxContact"
        Me.GbxContact.Size = New System.Drawing.Size(607, 70)
        Me.GbxContact.TabIndex = 2
        Me.GbxContact.TabStop = False
        Me.GbxContact.Text = "Contato"
        '
        'TxtEmail
        '
        Me.TxtEmail.BackColor = System.Drawing.SystemColors.Window
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtEmail.Location = New System.Drawing.Point(251, 39)
        Me.TxtEmail.MaxLength = 100
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(350, 23)
        Me.TxtEmail.TabIndex = 5
        '
        'TxtPhone
        '
        Me.TxtPhone.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPhone.Location = New System.Drawing.Point(135, 39)
        Me.TxtPhone.MaxLength = 16
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(110, 23)
        Me.TxtPhone.TabIndex = 3
        '
        'TxtContactName
        '
        Me.TxtContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContactName.Location = New System.Drawing.Point(8, 39)
        Me.TxtContactName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtContactName.MaxLength = 100
        Me.TxtContactName.Name = "TxtContactName"
        Me.TxtContactName.Size = New System.Drawing.Size(121, 23)
        Me.TxtContactName.TabIndex = 1
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(248, 19)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(43, 17)
        Me.LblEmail.TabIndex = 4
        Me.LblEmail.Text = "Email"
        '
        'LblPhone
        '
        Me.LblPhone.AutoSize = True
        Me.LblPhone.Location = New System.Drawing.Point(132, 19)
        Me.LblPhone.Name = "LblPhone"
        Me.LblPhone.Size = New System.Drawing.Size(61, 17)
        Me.LblPhone.TabIndex = 2
        Me.LblPhone.Text = "Telefone"
        '
        'LblContactName
        '
        Me.LblContactName.AutoSize = True
        Me.LblContactName.Location = New System.Drawing.Point(6, 19)
        Me.LblContactName.Name = "LblContactName"
        Me.LblContactName.Size = New System.Drawing.Size(48, 17)
        Me.LblContactName.TabIndex = 0
        Me.LblContactName.Text = "Nome"
        '
        'CbxImportContact
        '
        Me.CbxImportContact.AutoSize = True
        Me.CbxImportContact.Location = New System.Drawing.Point(593, 90)
        Me.CbxImportContact.Name = "CbxImportContact"
        Me.CbxImportContact.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.CbxImportContact.Size = New System.Drawing.Size(20, 14)
        Me.CbxImportContact.TabIndex = 3
        Me.CbxImportContact.UseVisualStyleBackColor = True
        '
        'GbxAddress
        '
        Me.GbxAddress.Controls.Add(Me.QbxCity)
        Me.GbxAddress.Controls.Add(Me.FlpCity)
        Me.GbxAddress.Controls.Add(Me.LblCity)
        Me.GbxAddress.Controls.Add(Me.LblZipCode)
        Me.GbxAddress.Controls.Add(Me.LblComplement)
        Me.GbxAddress.Controls.Add(Me.TxtAddressName)
        Me.GbxAddress.Controls.Add(Me.TxtZipCode)
        Me.GbxAddress.Controls.Add(Me.TxtNumber)
        Me.GbxAddress.Controls.Add(Me.LblAddressName)
        Me.GbxAddress.Controls.Add(Me.LblDistrict)
        Me.GbxAddress.Controls.Add(Me.TxtDistrict)
        Me.GbxAddress.Controls.Add(Me.LblNumber)
        Me.GbxAddress.Controls.Add(Me.TxtComplement)
        Me.GbxAddress.Controls.Add(Me.LblStreet)
        Me.GbxAddress.Controls.Add(Me.TxtStreet)
        Me.GbxAddress.Enabled = False
        Me.GbxAddress.Location = New System.Drawing.Point(12, 164)
        Me.GbxAddress.Name = "GbxAddress"
        Me.GbxAddress.Size = New System.Drawing.Size(607, 170)
        Me.GbxAddress.TabIndex = 4
        Me.GbxAddress.TabStop = False
        Me.GbxAddress.Text = "Endereço"
        '
        'QbxCity
        '
        Me.QbxCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCity.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "city"
        Condition1.Value = "@statusid"
        Me.QbxCity.Conditions.Add(Condition1)
        Me.QbxCity.DisplayFieldAlias = "Nome"
        Me.QbxCity.DisplayFieldName = "name"
        Me.QbxCity.DisplayMainFieldName = "id"
        Me.QbxCity.DisplayTableAlias = Nothing
        Me.QbxCity.DisplayTableName = "city"
        Me.QbxCity.Distinct = False
        Me.QbxCity.DropDownAutoStretchRight = False
        Me.QbxCity.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCity.IfNull = Nothing
        Me.QbxCity.Location = New System.Drawing.Point(275, 139)
        Me.QbxCity.MainReturnFieldName = "id"
        Me.QbxCity.MainTableAlias = Nothing
        Me.QbxCity.MainTableName = "city"
        Me.QbxCity.Name = "QbxCity"
        OtherField1.DisplayFieldAlias = "UF"
        OtherField1.DisplayFieldName = "shortname"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "state"
        OtherField1.Freeze = True
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = "-"
        OtherField1.Suffix = ""
        Me.QbxCity.OtherFields.Add(OtherField1)
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Me.QbxCity.Parameters.Add(Parameter1)
        Me.QbxCity.Prefix = Nothing
        Relation1.Operator = "="
        Relation1.RelateFieldName = "id"
        Relation1.RelateTableAlias = "state"
        Relation1.RelateTableName = "state"
        Relation1.RelationType = "INNER"
        Relation1.WithFieldName = "stateid"
        Relation1.WithTableAlias = "city"
        Relation1.WithTableName = "city"
        Me.QbxCity.Relations.Add(Relation1)
        Me.QbxCity.Size = New System.Drawing.Size(326, 23)
        Me.QbxCity.Suffix = Nothing
        Me.QbxCity.TabIndex = 13
        '
        'FlpCity
        '
        Me.FlpCity.Controls.Add(Me.BtnFilterCity)
        Me.FlpCity.Controls.Add(Me.BtnViewCity)
        Me.FlpCity.Controls.Add(Me.BtnNewCity)
        Me.FlpCity.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCity.Location = New System.Drawing.Point(531, 118)
        Me.FlpCity.Name = "FlpCity"
        Me.FlpCity.Size = New System.Drawing.Size(69, 21)
        Me.FlpCity.TabIndex = 14
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
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Location = New System.Drawing.Point(272, 119)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(57, 17)
        Me.LblCity.TabIndex = 12
        Me.LblCity.Text = "Cidade"
        '
        'LblZipCode
        '
        Me.LblZipCode.AutoSize = True
        Me.LblZipCode.Location = New System.Drawing.Point(6, 73)
        Me.LblZipCode.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblZipCode.Name = "LblZipCode"
        Me.LblZipCode.Size = New System.Drawing.Size(36, 17)
        Me.LblZipCode.TabIndex = 2
        Me.LblZipCode.Text = "Cep"
        '
        'LblComplement
        '
        Me.LblComplement.AutoSize = True
        Me.LblComplement.Location = New System.Drawing.Point(389, 73)
        Me.LblComplement.Name = "LblComplement"
        Me.LblComplement.Size = New System.Drawing.Size(104, 17)
        Me.LblComplement.TabIndex = 8
        Me.LblComplement.Text = "Complemento"
        '
        'TxtAddressName
        '
        Me.TxtAddressName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddressName.Location = New System.Drawing.Point(8, 39)
        Me.TxtAddressName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtAddressName.MaxLength = 100
        Me.TxtAddressName.Name = "TxtAddressName"
        Me.TxtAddressName.Size = New System.Drawing.Size(593, 23)
        Me.TxtAddressName.TabIndex = 1
        '
        'TxtZipCode
        '
        Me.TxtZipCode.BackColor = System.Drawing.SystemColors.Window
        Me.TxtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZipCode.Location = New System.Drawing.Point(9, 93)
        Me.TxtZipCode.MaxLength = 10
        Me.TxtZipCode.Name = "TxtZipCode"
        Me.TxtZipCode.Size = New System.Drawing.Size(73, 23)
        Me.TxtZipCode.TabIndex = 3
        Me.TxtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNumber
        '
        Me.TxtNumber.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumber.Location = New System.Drawing.Point(328, 93)
        Me.TxtNumber.MaxLength = 10
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(57, 23)
        Me.TxtNumber.TabIndex = 7
        Me.TxtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblAddressName
        '
        Me.LblAddressName.AutoSize = True
        Me.LblAddressName.Location = New System.Drawing.Point(6, 19)
        Me.LblAddressName.Name = "LblAddressName"
        Me.LblAddressName.Size = New System.Drawing.Size(48, 17)
        Me.LblAddressName.TabIndex = 0
        Me.LblAddressName.Text = "Nome"
        '
        'LblDistrict
        '
        Me.LblDistrict.AutoSize = True
        Me.LblDistrict.Location = New System.Drawing.Point(6, 119)
        Me.LblDistrict.Name = "LblDistrict"
        Me.LblDistrict.Size = New System.Drawing.Size(44, 17)
        Me.LblDistrict.TabIndex = 10
        Me.LblDistrict.Text = "Bairro"
        '
        'TxtDistrict
        '
        Me.TxtDistrict.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDistrict.Location = New System.Drawing.Point(9, 139)
        Me.TxtDistrict.MaxLength = 255
        Me.TxtDistrict.Name = "TxtDistrict"
        Me.TxtDistrict.Size = New System.Drawing.Size(260, 23)
        Me.TxtDistrict.TabIndex = 11
        '
        'LblNumber
        '
        Me.LblNumber.AutoSize = True
        Me.LblNumber.Location = New System.Drawing.Point(325, 73)
        Me.LblNumber.Name = "LblNumber"
        Me.LblNumber.Size = New System.Drawing.Size(23, 17)
        Me.LblNumber.TabIndex = 6
        Me.LblNumber.Text = "Nº"
        '
        'TxtComplement
        '
        Me.TxtComplement.BackColor = System.Drawing.SystemColors.Window
        Me.TxtComplement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplement.Location = New System.Drawing.Point(392, 93)
        Me.TxtComplement.MaxLength = 255
        Me.TxtComplement.Name = "TxtComplement"
        Me.TxtComplement.Size = New System.Drawing.Size(209, 23)
        Me.TxtComplement.TabIndex = 9
        '
        'LblStreet
        '
        Me.LblStreet.AutoSize = True
        Me.LblStreet.Location = New System.Drawing.Point(85, 73)
        Me.LblStreet.Name = "LblStreet"
        Me.LblStreet.Size = New System.Drawing.Size(33, 17)
        Me.LblStreet.TabIndex = 4
        Me.LblStreet.Text = "Rua"
        '
        'TxtStreet
        '
        Me.TxtStreet.BackColor = System.Drawing.SystemColors.Window
        Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStreet.Location = New System.Drawing.Point(88, 93)
        Me.TxtStreet.MaxLength = 255
        Me.TxtStreet.Name = "TxtStreet"
        Me.TxtStreet.Size = New System.Drawing.Size(234, 23)
        Me.TxtStreet.TabIndex = 5
        '
        'CbxImportAddress
        '
        Me.CbxImportAddress.AutoSize = True
        Me.CbxImportAddress.Location = New System.Drawing.Point(593, 166)
        Me.CbxImportAddress.Name = "CbxImportAddress"
        Me.CbxImportAddress.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.CbxImportAddress.Size = New System.Drawing.Size(20, 14)
        Me.CbxImportAddress.TabIndex = 5
        Me.CbxImportAddress.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TmrQueriedBoxCity
        '
        Me.TmrQueriedBoxCity.Enabled = True
        Me.TmrQueriedBoxCity.Interval = 300
        '
        'FrmPersonGetDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(631, 387)
        Me.Controls.Add(Me.CbxImportAddress)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GbxAddress)
        Me.Controls.Add(Me.CbxImportIdentity)
        Me.Controls.Add(Me.CbxImportContact)
        Me.Controls.Add(Me.GbxContact)
        Me.Controls.Add(Me.GbxIdentity)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonGetDocument"
        Me.ShowIcon = False
        Me.Text = "Consulta de CNPJ"
        Me.Panel1.ResumeLayout(False)
        Me.GbxIdentity.ResumeLayout(False)
        Me.GbxIdentity.PerformLayout()
        Me.GbxContact.ResumeLayout(False)
        Me.GbxContact.PerformLayout()
        Me.GbxAddress.ResumeLayout(False)
        Me.GbxAddress.PerformLayout()
        Me.FlpCity.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImport As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents GbxIdentity As GroupBox
    Friend WithEvents TxtDocument As TextBox
    Friend WithEvents TxtShortName As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblShortName As Label
    Friend WithEvents LblDocument1 As Label
    Friend WithEvents LblName As Label
    Friend WithEvents GbxContact As GroupBox
    Friend WithEvents TxtContactName As TextBox
    Friend WithEvents LblEmail As Label
    Friend WithEvents LblPhone As Label
    Friend WithEvents LblContactName As Label
    Friend WithEvents TxtPhone As TextBox
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents GbxAddress As GroupBox
    Friend WithEvents LblZipCode As Label
    Friend WithEvents LblComplement As Label
    Friend WithEvents TxtZipCode As TextBox
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents LblDistrict As Label
    Friend WithEvents TxtDistrict As TextBox
    Friend WithEvents LblNumber As Label
    Friend WithEvents TxtComplement As TextBox
    Friend WithEvents LblStreet As Label
    Friend WithEvents TxtStreet As TextBox
    Friend WithEvents CbxImportContact As CheckBox
    Friend WithEvents CbxImportAddress As CheckBox
    Friend WithEvents LblAddressName As Label
    Friend WithEvents TxtAddressName As TextBox
    Friend WithEvents CbxImportIdentity As CheckBox
    Friend WithEvents BtnNewCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents LblCity As Label
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TmrQueriedBoxCity As Timer
    Friend WithEvents FlpCity As FlowLayoutPanel
    Friend WithEvents QbxCity As ControlLibrary.QueriedBox
End Class
