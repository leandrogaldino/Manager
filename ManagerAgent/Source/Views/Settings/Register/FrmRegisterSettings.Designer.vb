<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegisterSettings
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.FlpProduct = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnIncludeLogo = New ControlLibrary.NoFocusCueButton()
        Me.BtnDeleteLogo = New ControlLibrary.NoFocusCueButton()
        Me.TxtCityDocument = New System.Windows.Forms.TextBox()
        Me.TxtStateDocument = New System.Windows.Forms.TextBox()
        Me.TxtDocument = New System.Windows.Forms.TextBox()
        Me.TxtShortName = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.PbxLogo = New System.Windows.Forms.PictureBox()
        Me.LblCityDocument = New System.Windows.Forms.Label()
        Me.LblStateDocument = New System.Windows.Forms.Label()
        Me.LblDocument = New System.Windows.Forms.Label()
        Me.LblShortname = New System.Windows.Forms.Label()
        Me.LblLogo = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.CbxState = New System.Windows.Forms.ComboBox()
        Me.LblState = New System.Windows.Forms.Label()
        Me.LblZipCode = New System.Windows.Forms.Label()
        Me.LblComplement = New System.Windows.Forms.Label()
        Me.TxtZipCode = New System.Windows.Forms.TextBox()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.LblCity = New System.Windows.Forms.Label()
        Me.LblDistrict = New System.Windows.Forms.Label()
        Me.TxtCity = New System.Windows.Forms.TextBox()
        Me.TxtDistrict = New System.Windows.Forms.TextBox()
        Me.LblNumber = New System.Windows.Forms.Label()
        Me.TxtComplement = New System.Windows.Forms.TextBox()
        Me.LblStreet = New System.Windows.Forms.Label()
        Me.TxtStreet = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblLinkedin = New System.Windows.Forms.Label()
        Me.LblInstagram = New System.Windows.Forms.Label()
        Me.TxtSite = New System.Windows.Forms.TextBox()
        Me.TxtLinkedin = New System.Windows.Forms.TextBox()
        Me.LblFacebook = New System.Windows.Forms.Label()
        Me.TxtInstagram = New System.Windows.Forms.TextBox()
        Me.TxtFacebook = New System.Windows.Forms.TextBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtCellPhone = New System.Windows.Forms.TextBox()
        Me.LblCellPhone = New System.Windows.Forms.Label()
        Me.TxtPhone2 = New System.Windows.Forms.TextBox()
        Me.LblPhone2 = New System.Windows.Forms.Label()
        Me.TxtPhone1 = New System.Windows.Forms.TextBox()
        Me.LblPhone1 = New System.Windows.Forms.Label()
        Me.SfdLogo = New System.Windows.Forms.SaveFileDialog()
        Me.OfdLogo = New System.Windows.Forms.OpenFileDialog()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PnButtons.SuspendLayout()
        Me.FlpProduct.SuspendLayout()
        CType(Me.PbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 477)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(595, 44)
        Me.PnButtons.TabIndex = 8
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(491, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(390, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'FlpProduct
        '
        Me.FlpProduct.Controls.Add(Me.BtnIncludeLogo)
        Me.FlpProduct.Controls.Add(Me.BtnDeleteLogo)
        Me.FlpProduct.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpProduct.Location = New System.Drawing.Point(103, 8)
        Me.FlpProduct.Name = "FlpProduct"
        Me.FlpProduct.Size = New System.Drawing.Size(50, 21)
        Me.FlpProduct.TabIndex = 13
        '
        'BtnIncludeLogo
        '
        Me.BtnIncludeLogo.BackColor = System.Drawing.Color.Transparent
        Me.BtnIncludeLogo.BackgroundImage = Global.ManagerAgent.My.Resources.Resources.ImageInclude
        Me.BtnIncludeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnIncludeLogo.FlatAppearance.BorderSize = 0
        Me.BtnIncludeLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnIncludeLogo.Location = New System.Drawing.Point(30, 3)
        Me.BtnIncludeLogo.Name = "BtnIncludeLogo"
        Me.BtnIncludeLogo.Size = New System.Drawing.Size(17, 17)
        Me.BtnIncludeLogo.TabIndex = 0
        Me.BtnIncludeLogo.TooltipText = "Selecionar Logo"
        Me.BtnIncludeLogo.UseVisualStyleBackColor = False
        '
        'BtnDeleteLogo
        '
        Me.BtnDeleteLogo.BackColor = System.Drawing.Color.Transparent
        Me.BtnDeleteLogo.BackgroundImage = Global.ManagerAgent.My.Resources.Resources.ImageDelete
        Me.BtnDeleteLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDeleteLogo.FlatAppearance.BorderSize = 0
        Me.BtnDeleteLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDeleteLogo.Location = New System.Drawing.Point(7, 3)
        Me.BtnDeleteLogo.Name = "BtnDeleteLogo"
        Me.BtnDeleteLogo.Size = New System.Drawing.Size(17, 17)
        Me.BtnDeleteLogo.TabIndex = 1
        Me.BtnDeleteLogo.TooltipText = "Deletar Logo"
        Me.BtnDeleteLogo.UseVisualStyleBackColor = False
        '
        'TxtCityDocument
        '
        Me.TxtCityDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCityDocument.Location = New System.Drawing.Point(440, 75)
        Me.TxtCityDocument.MaxLength = 20
        Me.TxtCityDocument.Name = "TxtCityDocument"
        Me.TxtCityDocument.Size = New System.Drawing.Size(143, 23)
        Me.TxtCityDocument.TabIndex = 24
        Me.TxtCityDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtStateDocument
        '
        Me.TxtStateDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStateDocument.Location = New System.Drawing.Point(298, 75)
        Me.TxtStateDocument.MaxLength = 20
        Me.TxtStateDocument.Name = "TxtStateDocument"
        Me.TxtStateDocument.Size = New System.Drawing.Size(136, 23)
        Me.TxtStateDocument.TabIndex = 22
        Me.TxtStateDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtDocument
        '
        Me.TxtDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocument.Location = New System.Drawing.Point(159, 75)
        Me.TxtDocument.MaxLength = 18
        Me.TxtDocument.Name = "TxtDocument"
        Me.TxtDocument.Size = New System.Drawing.Size(136, 23)
        Me.TxtDocument.TabIndex = 20
        Me.TxtDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtShortName
        '
        Me.TxtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtShortName.Location = New System.Drawing.Point(443, 29)
        Me.TxtShortName.MaxLength = 50
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(140, 23)
        Me.TxtShortName.TabIndex = 18
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(159, 29)
        Me.TxtName.MaxLength = 255
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(278, 23)
        Me.TxtName.TabIndex = 16
        '
        'PbxLogo
        '
        Me.PbxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PbxLogo.Location = New System.Drawing.Point(15, 29)
        Me.PbxLogo.Name = "PbxLogo"
        Me.PbxLogo.Size = New System.Drawing.Size(138, 69)
        Me.PbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxLogo.TabIndex = 14
        Me.PbxLogo.TabStop = False
        '
        'LblCityDocument
        '
        Me.LblCityDocument.AutoSize = True
        Me.LblCityDocument.Location = New System.Drawing.Point(437, 58)
        Me.LblCityDocument.Name = "LblCityDocument"
        Me.LblCityDocument.Size = New System.Drawing.Size(102, 17)
        Me.LblCityDocument.TabIndex = 23
        Me.LblCityDocument.Text = "Insc. Municipal"
        '
        'LblStateDocument
        '
        Me.LblStateDocument.AutoSize = True
        Me.LblStateDocument.Location = New System.Drawing.Point(295, 58)
        Me.LblStateDocument.Name = "LblStateDocument"
        Me.LblStateDocument.Size = New System.Drawing.Size(95, 17)
        Me.LblStateDocument.TabIndex = 21
        Me.LblStateDocument.Text = "Insc. Estadual"
        '
        'LblDocument
        '
        Me.LblDocument.AutoSize = True
        Me.LblDocument.Location = New System.Drawing.Point(156, 58)
        Me.LblDocument.Name = "LblDocument"
        Me.LblDocument.Size = New System.Drawing.Size(43, 17)
        Me.LblDocument.TabIndex = 19
        Me.LblDocument.Text = "CNPJ"
        '
        'LblShortname
        '
        Me.LblShortname.AutoSize = True
        Me.LblShortname.Location = New System.Drawing.Point(443, 12)
        Me.LblShortname.Name = "LblShortname"
        Me.LblShortname.Size = New System.Drawing.Size(62, 17)
        Me.LblShortname.TabIndex = 17
        Me.LblShortname.Text = "Fantasia"
        '
        'LblLogo
        '
        Me.LblLogo.AutoSize = True
        Me.LblLogo.Location = New System.Drawing.Point(12, 9)
        Me.LblLogo.Name = "LblLogo"
        Me.LblLogo.Size = New System.Drawing.Size(41, 17)
        Me.LblLogo.TabIndex = 12
        Me.LblLogo.Text = "Logo"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(156, 12)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(91, 17)
        Me.LblName.TabIndex = 15
        Me.LblName.Text = "Razão Social"
        '
        'CbxState
        '
        Me.CbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxState.FormattingEnabled = True
        Me.CbxState.Items.AddRange(New Object() {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"})
        Me.CbxState.Location = New System.Drawing.Point(504, 167)
        Me.CbxState.Name = "CbxState"
        Me.CbxState.Size = New System.Drawing.Size(79, 25)
        Me.CbxState.TabIndex = 38
        '
        'LblState
        '
        Me.LblState.AutoSize = True
        Me.LblState.Location = New System.Drawing.Point(501, 147)
        Me.LblState.Name = "LblState"
        Me.LblState.Size = New System.Drawing.Size(22, 17)
        Me.LblState.TabIndex = 37
        Me.LblState.Text = "UF"
        '
        'LblZipCode
        '
        Me.LblZipCode.AutoSize = True
        Me.LblZipCode.Location = New System.Drawing.Point(12, 101)
        Me.LblZipCode.Name = "LblZipCode"
        Me.LblZipCode.Size = New System.Drawing.Size(36, 17)
        Me.LblZipCode.TabIndex = 25
        Me.LblZipCode.Text = "Cep"
        '
        'LblComplement
        '
        Me.LblComplement.AutoSize = True
        Me.LblComplement.Location = New System.Drawing.Point(313, 101)
        Me.LblComplement.Name = "LblComplement"
        Me.LblComplement.Size = New System.Drawing.Size(104, 17)
        Me.LblComplement.TabIndex = 31
        Me.LblComplement.Text = "Complemento"
        '
        'TxtZipCode
        '
        Me.TxtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZipCode.Location = New System.Drawing.Point(15, 121)
        Me.TxtZipCode.MaxLength = 10
        Me.TxtZipCode.Name = "TxtZipCode"
        Me.TxtZipCode.Size = New System.Drawing.Size(70, 23)
        Me.TxtZipCode.TabIndex = 26
        Me.TxtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNumber
        '
        Me.TxtNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumber.Location = New System.Drawing.Point(253, 121)
        Me.TxtNumber.MaxLength = 10
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(57, 23)
        Me.TxtNumber.TabIndex = 30
        Me.TxtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Location = New System.Drawing.Point(257, 147)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(57, 17)
        Me.LblCity.TabIndex = 35
        Me.LblCity.Text = "Cidade"
        '
        'LblDistrict
        '
        Me.LblDistrict.AutoSize = True
        Me.LblDistrict.Location = New System.Drawing.Point(12, 147)
        Me.LblDistrict.Name = "LblDistrict"
        Me.LblDistrict.Size = New System.Drawing.Size(44, 17)
        Me.LblDistrict.TabIndex = 33
        Me.LblDistrict.Text = "Bairro"
        '
        'TxtCity
        '
        Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCity.Location = New System.Drawing.Point(260, 167)
        Me.TxtCity.MaxLength = 50
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(239, 23)
        Me.TxtCity.TabIndex = 36
        '
        'TxtDistrict
        '
        Me.TxtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDistrict.Location = New System.Drawing.Point(15, 167)
        Me.TxtDistrict.MaxLength = 255
        Me.TxtDistrict.Name = "TxtDistrict"
        Me.TxtDistrict.Size = New System.Drawing.Size(239, 23)
        Me.TxtDistrict.TabIndex = 34
        '
        'LblNumber
        '
        Me.LblNumber.AutoSize = True
        Me.LblNumber.Location = New System.Drawing.Point(255, 101)
        Me.LblNumber.Name = "LblNumber"
        Me.LblNumber.Size = New System.Drawing.Size(23, 17)
        Me.LblNumber.TabIndex = 29
        Me.LblNumber.Text = "Nº"
        '
        'TxtComplement
        '
        Me.TxtComplement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplement.Location = New System.Drawing.Point(316, 121)
        Me.TxtComplement.MaxLength = 255
        Me.TxtComplement.Name = "TxtComplement"
        Me.TxtComplement.Size = New System.Drawing.Size(267, 23)
        Me.TxtComplement.TabIndex = 32
        '
        'LblStreet
        '
        Me.LblStreet.AutoSize = True
        Me.LblStreet.Location = New System.Drawing.Point(93, 101)
        Me.LblStreet.Name = "LblStreet"
        Me.LblStreet.Size = New System.Drawing.Size(33, 17)
        Me.LblStreet.TabIndex = 27
        Me.LblStreet.Text = "Rua"
        '
        'TxtStreet
        '
        Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStreet.Location = New System.Drawing.Point(91, 121)
        Me.TxtStreet.MaxLength = 255
        Me.TxtStreet.Name = "TxtStreet"
        Me.TxtStreet.Size = New System.Drawing.Size(156, 23)
        Me.TxtStreet.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 424)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Site"
        '
        'LblLinkedin
        '
        Me.LblLinkedin.AutoSize = True
        Me.LblLinkedin.Location = New System.Drawing.Point(13, 377)
        Me.LblLinkedin.Name = "LblLinkedin"
        Me.LblLinkedin.Size = New System.Drawing.Size(60, 17)
        Me.LblLinkedin.TabIndex = 51
        Me.LblLinkedin.Text = "Linkedin"
        '
        'LblInstagram
        '
        Me.LblInstagram.AutoSize = True
        Me.LblInstagram.Location = New System.Drawing.Point(13, 331)
        Me.LblInstagram.Name = "LblInstagram"
        Me.LblInstagram.Size = New System.Drawing.Size(73, 17)
        Me.LblInstagram.TabIndex = 49
        Me.LblInstagram.Text = "Instagram"
        '
        'TxtSite
        '
        Me.TxtSite.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtSite.Location = New System.Drawing.Point(16, 444)
        Me.TxtSite.MaxLength = 100
        Me.TxtSite.Name = "TxtSite"
        Me.TxtSite.Size = New System.Drawing.Size(567, 23)
        Me.TxtSite.TabIndex = 54
        '
        'TxtLinkedin
        '
        Me.TxtLinkedin.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtLinkedin.Location = New System.Drawing.Point(16, 397)
        Me.TxtLinkedin.MaxLength = 100
        Me.TxtLinkedin.Name = "TxtLinkedin"
        Me.TxtLinkedin.Size = New System.Drawing.Size(567, 23)
        Me.TxtLinkedin.TabIndex = 52
        '
        'LblFacebook
        '
        Me.LblFacebook.AutoSize = True
        Me.LblFacebook.Location = New System.Drawing.Point(13, 285)
        Me.LblFacebook.Name = "LblFacebook"
        Me.LblFacebook.Size = New System.Drawing.Size(73, 17)
        Me.LblFacebook.TabIndex = 47
        Me.LblFacebook.Text = "Facebook"
        '
        'TxtInstagram
        '
        Me.TxtInstagram.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtInstagram.Location = New System.Drawing.Point(16, 351)
        Me.TxtInstagram.MaxLength = 100
        Me.TxtInstagram.Name = "TxtInstagram"
        Me.TxtInstagram.Size = New System.Drawing.Size(567, 23)
        Me.TxtInstagram.TabIndex = 50
        '
        'TxtFacebook
        '
        Me.TxtFacebook.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtFacebook.Location = New System.Drawing.Point(16, 305)
        Me.TxtFacebook.MaxLength = 100
        Me.TxtFacebook.Name = "TxtFacebook"
        Me.TxtFacebook.Size = New System.Drawing.Size(567, 23)
        Me.TxtFacebook.TabIndex = 48
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(13, 239)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(45, 17)
        Me.LblEmail.TabIndex = 45
        Me.LblEmail.Text = "E-Mail"
        '
        'TxtEmail
        '
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtEmail.Location = New System.Drawing.Point(16, 259)
        Me.TxtEmail.MaxLength = 100
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(567, 23)
        Me.TxtEmail.TabIndex = 46
        '
        'TxtCellPhone
        '
        Me.TxtCellPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCellPhone.Location = New System.Drawing.Point(398, 213)
        Me.TxtCellPhone.MaxLength = 16
        Me.TxtCellPhone.Name = "TxtCellPhone"
        Me.TxtCellPhone.Size = New System.Drawing.Size(185, 23)
        Me.TxtCellPhone.TabIndex = 44
        '
        'LblCellPhone
        '
        Me.LblCellPhone.AutoSize = True
        Me.LblCellPhone.Location = New System.Drawing.Point(395, 193)
        Me.LblCellPhone.Name = "LblCellPhone"
        Me.LblCellPhone.Size = New System.Drawing.Size(54, 17)
        Me.LblCellPhone.TabIndex = 43
        Me.LblCellPhone.Text = "Celular"
        '
        'TxtPhone2
        '
        Me.TxtPhone2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPhone2.Location = New System.Drawing.Point(207, 213)
        Me.TxtPhone2.MaxLength = 16
        Me.TxtPhone2.Name = "TxtPhone2"
        Me.TxtPhone2.Size = New System.Drawing.Size(185, 23)
        Me.TxtPhone2.TabIndex = 42
        '
        'LblPhone2
        '
        Me.LblPhone2.AutoSize = True
        Me.LblPhone2.Location = New System.Drawing.Point(204, 193)
        Me.LblPhone2.Name = "LblPhone2"
        Me.LblPhone2.Size = New System.Drawing.Size(72, 17)
        Me.LblPhone2.TabIndex = 41
        Me.LblPhone2.Text = "Telefone 2"
        '
        'TxtPhone1
        '
        Me.TxtPhone1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPhone1.Location = New System.Drawing.Point(16, 213)
        Me.TxtPhone1.MaxLength = 16
        Me.TxtPhone1.Name = "TxtPhone1"
        Me.TxtPhone1.Size = New System.Drawing.Size(185, 23)
        Me.TxtPhone1.TabIndex = 40
        '
        'LblPhone1
        '
        Me.LblPhone1.AutoSize = True
        Me.LblPhone1.Location = New System.Drawing.Point(13, 193)
        Me.LblPhone1.Name = "LblPhone1"
        Me.LblPhone1.Size = New System.Drawing.Size(72, 17)
        Me.LblPhone1.TabIndex = 39
        Me.LblPhone1.Text = "Telefone 1"
        '
        'SfdLogo
        '
        Me.SfdLogo.Title = "Salvar Logo"
        '
        'OfdLogo
        '
        Me.OfdLogo.Filter = "Imagens (BMP/JPG/PNG)|*.bmp;*.jpg;*.png"
        Me.OfdLogo.Title = "Escolha uma imagem"
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'FrmRegisterSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(595, 521)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblLinkedin)
        Me.Controls.Add(Me.LblInstagram)
        Me.Controls.Add(Me.TxtSite)
        Me.Controls.Add(Me.TxtLinkedin)
        Me.Controls.Add(Me.LblFacebook)
        Me.Controls.Add(Me.TxtInstagram)
        Me.Controls.Add(Me.TxtFacebook)
        Me.Controls.Add(Me.LblEmail)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.TxtCellPhone)
        Me.Controls.Add(Me.LblCellPhone)
        Me.Controls.Add(Me.TxtPhone2)
        Me.Controls.Add(Me.LblPhone2)
        Me.Controls.Add(Me.TxtPhone1)
        Me.Controls.Add(Me.LblPhone1)
        Me.Controls.Add(Me.CbxState)
        Me.Controls.Add(Me.LblState)
        Me.Controls.Add(Me.LblZipCode)
        Me.Controls.Add(Me.LblComplement)
        Me.Controls.Add(Me.TxtZipCode)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.LblDistrict)
        Me.Controls.Add(Me.TxtCity)
        Me.Controls.Add(Me.TxtDistrict)
        Me.Controls.Add(Me.LblNumber)
        Me.Controls.Add(Me.TxtComplement)
        Me.Controls.Add(Me.LblStreet)
        Me.Controls.Add(Me.TxtStreet)
        Me.Controls.Add(Me.FlpProduct)
        Me.Controls.Add(Me.TxtCityDocument)
        Me.Controls.Add(Me.TxtStateDocument)
        Me.Controls.Add(Me.TxtDocument)
        Me.Controls.Add(Me.TxtShortName)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.PbxLogo)
        Me.Controls.Add(Me.LblCityDocument)
        Me.Controls.Add(Me.LblStateDocument)
        Me.Controls.Add(Me.LblDocument)
        Me.Controls.Add(Me.LblShortname)
        Me.Controls.Add(Me.LblLogo)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRegisterSettings"
        Me.ShowIcon = False
        Me.Text = "Cadastro"
        Me.PnButtons.ResumeLayout(False)
        Me.FlpProduct.ResumeLayout(False)
        CType(Me.PbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents FlpProduct As FlowLayoutPanel
    Friend WithEvents BtnIncludeLogo As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnDeleteLogo As ControlLibrary.NoFocusCueButton
    Friend WithEvents TxtCityDocument As TextBox
    Friend WithEvents TxtStateDocument As TextBox
    Friend WithEvents TxtDocument As TextBox
    Friend WithEvents TxtShortName As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents PbxLogo As PictureBox
    Friend WithEvents LblCityDocument As Label
    Friend WithEvents LblStateDocument As Label
    Friend WithEvents LblDocument As Label
    Friend WithEvents LblShortname As Label
    Friend WithEvents LblLogo As Label
    Friend WithEvents LblName As Label
    Friend WithEvents CbxState As ComboBox
    Friend WithEvents LblState As Label
    Friend WithEvents LblZipCode As Label
    Friend WithEvents LblComplement As Label
    Friend WithEvents TxtZipCode As TextBox
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents LblCity As Label
    Friend WithEvents LblDistrict As Label
    Friend WithEvents TxtCity As TextBox
    Friend WithEvents TxtDistrict As TextBox
    Friend WithEvents LblNumber As Label
    Friend WithEvents TxtComplement As TextBox
    Friend WithEvents LblStreet As Label
    Friend WithEvents TxtStreet As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblLinkedin As Label
    Friend WithEvents LblInstagram As Label
    Friend WithEvents TxtSite As TextBox
    Friend WithEvents TxtLinkedin As TextBox
    Friend WithEvents LblFacebook As Label
    Friend WithEvents TxtInstagram As TextBox
    Friend WithEvents TxtFacebook As TextBox
    Friend WithEvents LblEmail As Label
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents TxtCellPhone As TextBox
    Friend WithEvents LblCellPhone As Label
    Friend WithEvents TxtPhone2 As TextBox
    Friend WithEvents LblPhone2 As Label
    Friend WithEvents TxtPhone1 As TextBox
    Friend WithEvents LblPhone1 As Label
    Friend WithEvents SfdLogo As SaveFileDialog
    Friend WithEvents OfdLogo As OpenFileDialog
    Friend WithEvents EprValidation As ErrorProvider
End Class
