<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompany
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompany))
        Me.SfdLogo = New System.Windows.Forms.SaveFileDialog()
        Me.OfdLogo = New System.Windows.Forms.OpenFileDialog()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
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
        Me.FlpProduct = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnIncludeLogo = New CoreSuite.Controls.NoFocusCueButton()
        Me.BtnDeleteLogo = New CoreSuite.Controls.NoFocusCueButton()
        Me.TxtCityDocument = New System.Windows.Forms.TextBox()
        Me.TxtStateDocument = New System.Windows.Forms.TextBox()
        Me.TxtDocument = New System.Windows.Forms.TextBox()
        Me.TxtShortName = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblCityDocument = New System.Windows.Forms.Label()
        Me.LblStateDocument = New System.Windows.Forms.Label()
        Me.LblDocument = New System.Windows.Forms.Label()
        Me.LblShortName = New System.Windows.Forms.Label()
        Me.LblLogo = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PvLogo = New CoreSuite.Controls.PictureViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.EpValidator = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnButtons.SuspendLayout()
        Me.FlpProduct.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        CType(Me.EpValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 527)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(607, 45)
        Me.PnButtons.TabIndex = 25
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(386, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(100, 30)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(492, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(100, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(299, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Site Oficial"
        '
        'LblLinkedin
        '
        Me.LblLinkedin.AutoSize = True
        Me.LblLinkedin.Location = New System.Drawing.Point(6, 184)
        Me.LblLinkedin.Name = "LblLinkedin"
        Me.LblLinkedin.Size = New System.Drawing.Size(60, 17)
        Me.LblLinkedin.TabIndex = 23
        Me.LblLinkedin.Text = "Linkedin"
        '
        'LblInstagram
        '
        Me.LblInstagram.AutoSize = True
        Me.LblInstagram.Location = New System.Drawing.Point(299, 129)
        Me.LblInstagram.Name = "LblInstagram"
        Me.LblInstagram.Size = New System.Drawing.Size(73, 17)
        Me.LblInstagram.TabIndex = 24
        Me.LblInstagram.Text = "Instagram"
        '
        'TxtSite
        '
        Me.TxtSite.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtSite.Location = New System.Drawing.Point(302, 204)
        Me.TxtSite.Name = "TxtSite"
        Me.TxtSite.Size = New System.Drawing.Size(275, 23)
        Me.TxtSite.TabIndex = 21
        '
        'TxtLinkedin
        '
        Me.TxtLinkedin.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtLinkedin.Location = New System.Drawing.Point(9, 204)
        Me.TxtLinkedin.Name = "TxtLinkedin"
        Me.TxtLinkedin.Size = New System.Drawing.Size(275, 23)
        Me.TxtLinkedin.TabIndex = 20
        '
        'LblFacebook
        '
        Me.LblFacebook.AutoSize = True
        Me.LblFacebook.Location = New System.Drawing.Point(6, 129)
        Me.LblFacebook.Name = "LblFacebook"
        Me.LblFacebook.Size = New System.Drawing.Size(73, 17)
        Me.LblFacebook.TabIndex = 25
        Me.LblFacebook.Text = "Facebook"
        '
        'TxtInstagram
        '
        Me.TxtInstagram.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtInstagram.Location = New System.Drawing.Point(302, 149)
        Me.TxtInstagram.Name = "TxtInstagram"
        Me.TxtInstagram.Size = New System.Drawing.Size(275, 23)
        Me.TxtInstagram.TabIndex = 19
        '
        'TxtFacebook
        '
        Me.TxtFacebook.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtFacebook.Location = New System.Drawing.Point(9, 149)
        Me.TxtFacebook.Name = "TxtFacebook"
        Me.TxtFacebook.Size = New System.Drawing.Size(275, 23)
        Me.TxtFacebook.TabIndex = 18
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(6, 74)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(47, 17)
        Me.LblEmail.TabIndex = 26
        Me.LblEmail.Text = "E-mail"
        '
        'TxtEmail
        '
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtEmail.Location = New System.Drawing.Point(9, 94)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(568, 23)
        Me.TxtEmail.TabIndex = 17
        '
        'TxtCellPhone
        '
        Me.TxtCellPhone.Location = New System.Drawing.Point(389, 39)
        Me.TxtCellPhone.Name = "TxtCellPhone"
        Me.TxtCellPhone.Size = New System.Drawing.Size(188, 23)
        Me.TxtCellPhone.TabIndex = 16
        '
        'LblCellPhone
        '
        Me.LblCellPhone.AutoSize = True
        Me.LblCellPhone.Location = New System.Drawing.Point(386, 19)
        Me.LblCellPhone.Name = "LblCellPhone"
        Me.LblCellPhone.Size = New System.Drawing.Size(54, 17)
        Me.LblCellPhone.TabIndex = 27
        Me.LblCellPhone.Text = "Celular"
        '
        'TxtPhone2
        '
        Me.TxtPhone2.Location = New System.Drawing.Point(199, 39)
        Me.TxtPhone2.Name = "TxtPhone2"
        Me.TxtPhone2.Size = New System.Drawing.Size(180, 23)
        Me.TxtPhone2.TabIndex = 15
        '
        'LblPhone2
        '
        Me.LblPhone2.AutoSize = True
        Me.LblPhone2.Location = New System.Drawing.Point(196, 19)
        Me.LblPhone2.Name = "LblPhone2"
        Me.LblPhone2.Size = New System.Drawing.Size(72, 17)
        Me.LblPhone2.TabIndex = 28
        Me.LblPhone2.Text = "Telefone 2"
        '
        'TxtPhone1
        '
        Me.TxtPhone1.Location = New System.Drawing.Point(9, 39)
        Me.TxtPhone1.Name = "TxtPhone1"
        Me.TxtPhone1.Size = New System.Drawing.Size(180, 23)
        Me.TxtPhone1.TabIndex = 14
        '
        'LblPhone1
        '
        Me.LblPhone1.AutoSize = True
        Me.LblPhone1.Location = New System.Drawing.Point(6, 19)
        Me.LblPhone1.Name = "LblPhone1"
        Me.LblPhone1.Size = New System.Drawing.Size(72, 17)
        Me.LblPhone1.TabIndex = 29
        Me.LblPhone1.Text = "Telefone 1"
        '
        'CbxState
        '
        Me.CbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxState.Items.AddRange(New Object() {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"})
        Me.CbxState.Location = New System.Drawing.Point(389, 94)
        Me.CbxState.Name = "CbxState"
        Me.CbxState.Size = New System.Drawing.Size(65, 25)
        Me.CbxState.TabIndex = 12
        '
        'LblState
        '
        Me.LblState.AutoSize = True
        Me.LblState.Location = New System.Drawing.Point(386, 74)
        Me.LblState.Name = "LblState"
        Me.LblState.Size = New System.Drawing.Size(22, 17)
        Me.LblState.TabIndex = 31
        Me.LblState.Text = "UF"
        '
        'LblZipCode
        '
        Me.LblZipCode.AutoSize = True
        Me.LblZipCode.Location = New System.Drawing.Point(6, 19)
        Me.LblZipCode.Name = "LblZipCode"
        Me.LblZipCode.Size = New System.Drawing.Size(34, 17)
        Me.LblZipCode.TabIndex = 36
        Me.LblZipCode.Text = "CEP"
        '
        'LblComplement
        '
        Me.LblComplement.AutoSize = True
        Me.LblComplement.Location = New System.Drawing.Point(461, 74)
        Me.LblComplement.Name = "LblComplement"
        Me.LblComplement.Size = New System.Drawing.Size(104, 17)
        Me.LblComplement.TabIndex = 30
        Me.LblComplement.Text = "Complemento"
        '
        'TxtZipCode
        '
        Me.TxtZipCode.Location = New System.Drawing.Point(9, 39)
        Me.TxtZipCode.Name = "TxtZipCode"
        Me.TxtZipCode.Size = New System.Drawing.Size(90, 23)
        Me.TxtZipCode.TabIndex = 7
        '
        'TxtNumber
        '
        Me.TxtNumber.Location = New System.Drawing.Point(519, 39)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(58, 23)
        Me.TxtNumber.TabIndex = 9
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Location = New System.Drawing.Point(196, 74)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(57, 17)
        Me.LblCity.TabIndex = 32
        Me.LblCity.Text = "Cidade"
        '
        'LblDistrict
        '
        Me.LblDistrict.AutoSize = True
        Me.LblDistrict.Location = New System.Drawing.Point(6, 74)
        Me.LblDistrict.Name = "LblDistrict"
        Me.LblDistrict.Size = New System.Drawing.Size(44, 17)
        Me.LblDistrict.TabIndex = 33
        Me.LblDistrict.Text = "Bairro"
        '
        'TxtCity
        '
        Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCity.Location = New System.Drawing.Point(199, 94)
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(180, 23)
        Me.TxtCity.TabIndex = 11
        '
        'TxtDistrict
        '
        Me.TxtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDistrict.Location = New System.Drawing.Point(9, 94)
        Me.TxtDistrict.Name = "TxtDistrict"
        Me.TxtDistrict.Size = New System.Drawing.Size(180, 23)
        Me.TxtDistrict.TabIndex = 10
        '
        'LblNumber
        '
        Me.LblNumber.AutoSize = True
        Me.LblNumber.Location = New System.Drawing.Point(516, 19)
        Me.LblNumber.Name = "LblNumber"
        Me.LblNumber.Size = New System.Drawing.Size(23, 17)
        Me.LblNumber.TabIndex = 34
        Me.LblNumber.Text = "Nº"
        '
        'TxtComplement
        '
        Me.TxtComplement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplement.Location = New System.Drawing.Point(464, 94)
        Me.TxtComplement.Name = "TxtComplement"
        Me.TxtComplement.Size = New System.Drawing.Size(113, 23)
        Me.TxtComplement.TabIndex = 13
        '
        'LblStreet
        '
        Me.LblStreet.AutoSize = True
        Me.LblStreet.Location = New System.Drawing.Point(106, 19)
        Me.LblStreet.Name = "LblStreet"
        Me.LblStreet.Size = New System.Drawing.Size(84, 17)
        Me.LblStreet.TabIndex = 35
        Me.LblStreet.Text = "Logradouro"
        '
        'TxtStreet
        '
        Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStreet.Location = New System.Drawing.Point(109, 39)
        Me.TxtStreet.Name = "TxtStreet"
        Me.TxtStreet.Size = New System.Drawing.Size(400, 23)
        Me.TxtStreet.TabIndex = 8
        '
        'FlpProduct
        '
        Me.FlpProduct.Controls.Add(Me.BtnIncludeLogo)
        Me.FlpProduct.Controls.Add(Me.BtnDeleteLogo)
        Me.FlpProduct.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpProduct.Location = New System.Drawing.Point(100, 16)
        Me.FlpProduct.Name = "FlpProduct"
        Me.FlpProduct.Size = New System.Drawing.Size(50, 22)
        Me.FlpProduct.TabIndex = 0
        '
        'BtnIncludeLogo
        '
        Me.BtnIncludeLogo.BackgroundImage = Global.ManagerAgent.My.Resources.Resources.ImageInclude
        Me.BtnIncludeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnIncludeLogo.FlatAppearance.BorderSize = 0
        Me.BtnIncludeLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnIncludeLogo.Location = New System.Drawing.Point(30, 3)
        Me.BtnIncludeLogo.Name = "BtnIncludeLogo"
        Me.BtnIncludeLogo.Size = New System.Drawing.Size(17, 17)
        Me.BtnIncludeLogo.TabIndex = 0
        Me.BtnIncludeLogo.TooltipText = "Selecionar Logo"
        '
        'BtnDeleteLogo
        '
        Me.BtnDeleteLogo.BackgroundImage = Global.ManagerAgent.My.Resources.Resources.ImageDelete
        Me.BtnDeleteLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDeleteLogo.FlatAppearance.BorderSize = 0
        Me.BtnDeleteLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDeleteLogo.Location = New System.Drawing.Point(7, 3)
        Me.BtnDeleteLogo.Name = "BtnDeleteLogo"
        Me.BtnDeleteLogo.Size = New System.Drawing.Size(17, 17)
        Me.BtnDeleteLogo.TabIndex = 1
        Me.BtnDeleteLogo.TooltipText = "Deletar Logo"
        '
        'TxtCityDocument
        '
        Me.TxtCityDocument.Location = New System.Drawing.Point(442, 94)
        Me.TxtCityDocument.Name = "TxtCityDocument"
        Me.TxtCityDocument.Size = New System.Drawing.Size(135, 23)
        Me.TxtCityDocument.TabIndex = 6
        '
        'TxtStateDocument
        '
        Me.TxtStateDocument.Location = New System.Drawing.Point(302, 94)
        Me.TxtStateDocument.Name = "TxtStateDocument"
        Me.TxtStateDocument.Size = New System.Drawing.Size(130, 23)
        Me.TxtStateDocument.TabIndex = 5
        '
        'TxtDocument
        '
        Me.TxtDocument.Location = New System.Drawing.Point(157, 94)
        Me.TxtDocument.Name = "TxtDocument"
        Me.TxtDocument.Size = New System.Drawing.Size(135, 23)
        Me.TxtDocument.TabIndex = 4
        '
        'TxtShortName
        '
        Me.TxtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtShortName.Location = New System.Drawing.Point(442, 39)
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(135, 23)
        Me.TxtShortName.TabIndex = 3
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(157, 39)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(275, 23)
        Me.TxtName.TabIndex = 2
        '
        'LblCityDocument
        '
        Me.LblCityDocument.AutoSize = True
        Me.LblCityDocument.Location = New System.Drawing.Point(439, 74)
        Me.LblCityDocument.Name = "LblCityDocument"
        Me.LblCityDocument.Size = New System.Drawing.Size(102, 17)
        Me.LblCityDocument.TabIndex = 37
        Me.LblCityDocument.Text = "Insc. Municipal"
        '
        'LblStateDocument
        '
        Me.LblStateDocument.AutoSize = True
        Me.LblStateDocument.Location = New System.Drawing.Point(299, 74)
        Me.LblStateDocument.Name = "LblStateDocument"
        Me.LblStateDocument.Size = New System.Drawing.Size(95, 17)
        Me.LblStateDocument.TabIndex = 38
        Me.LblStateDocument.Text = "Insc. Estadual"
        '
        'LblDocument
        '
        Me.LblDocument.AutoSize = True
        Me.LblDocument.Location = New System.Drawing.Point(154, 74)
        Me.LblDocument.Name = "LblDocument"
        Me.LblDocument.Size = New System.Drawing.Size(43, 17)
        Me.LblDocument.TabIndex = 39
        Me.LblDocument.Text = "CNPJ"
        '
        'LblShortName
        '
        Me.LblShortName.AutoSize = True
        Me.LblShortName.Location = New System.Drawing.Point(439, 19)
        Me.LblShortName.Name = "LblShortName"
        Me.LblShortName.Size = New System.Drawing.Size(62, 17)
        Me.LblShortName.TabIndex = 40
        Me.LblShortName.Text = "Fantasia"
        '
        'LblLogo
        '
        Me.LblLogo.AutoSize = True
        Me.LblLogo.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LblLogo.Location = New System.Drawing.Point(6, 19)
        Me.LblLogo.Name = "LblLogo"
        Me.LblLogo.Size = New System.Drawing.Size(41, 17)
        Me.LblLogo.TabIndex = 42
        Me.LblLogo.Text = "Logo"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(154, 19)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(91, 17)
        Me.LblName.TabIndex = 41
        Me.LblName.Text = "Razão Social"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PvLogo)
        Me.GroupBox2.Controls.Add(Me.LblLogo)
        Me.GroupBox2.Controls.Add(Me.FlpProduct)
        Me.GroupBox2.Controls.Add(Me.LblName)
        Me.GroupBox2.Controls.Add(Me.TxtName)
        Me.GroupBox2.Controls.Add(Me.LblShortName)
        Me.GroupBox2.Controls.Add(Me.TxtShortName)
        Me.GroupBox2.Controls.Add(Me.LblDocument)
        Me.GroupBox2.Controls.Add(Me.TxtDocument)
        Me.GroupBox2.Controls.Add(Me.LblStateDocument)
        Me.GroupBox2.Controls.Add(Me.TxtStateDocument)
        Me.GroupBox2.Controls.Add(Me.LblCityDocument)
        Me.GroupBox2.Controls.Add(Me.TxtCityDocument)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(584, 125)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Identificação"
        '
        'PvLogo
        '
        Me.PvLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PvLogo.ControlBarBackColor = System.Drawing.Color.White
        Me.PvLogo.CounterBarBackColor = System.Drawing.Color.White
        Me.PvLogo.CounterMask = "{0}/{1}"
        Me.PvLogo.FirstButtonImage = CType(resources.GetObject("PvLogo.FirstButtonImage"), System.Drawing.Image)
        Me.PvLogo.IncludeButtonImage = CType(resources.GetObject("PvLogo.IncludeButtonImage"), System.Drawing.Image)
        Me.PvLogo.LastButtonImage = CType(resources.GetObject("PvLogo.LastButtonImage"), System.Drawing.Image)
        Me.PvLogo.Location = New System.Drawing.Point(6, 39)
        Me.PvLogo.MaximumPictures = 1
        Me.PvLogo.Name = "PvLogo"
        Me.PvLogo.NextButtonImage = CType(resources.GetObject("PvLogo.NextButtonImage"), System.Drawing.Image)
        Me.PvLogo.Padding = New System.Windows.Forms.Padding(1)
        Me.PvLogo.PreviousButtonImage = CType(resources.GetObject("PvLogo.PreviousButtonImage"), System.Drawing.Image)
        Me.PvLogo.RemoveButtonImage = CType(resources.GetObject("PvLogo.RemoveButtonImage"), System.Drawing.Image)
        Me.PvLogo.SaveButtonImage = CType(resources.GetObject("PvLogo.SaveButtonImage"), System.Drawing.Image)
        Me.PvLogo.ShowControlBar = False
        Me.PvLogo.ShowCounterBar = False
        Me.PvLogo.Size = New System.Drawing.Size(145, 80)
        Me.PvLogo.TabIndex = 43
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblZipCode)
        Me.GroupBox1.Controls.Add(Me.TxtZipCode)
        Me.GroupBox1.Controls.Add(Me.LblStreet)
        Me.GroupBox1.Controls.Add(Me.TxtStreet)
        Me.GroupBox1.Controls.Add(Me.LblNumber)
        Me.GroupBox1.Controls.Add(Me.TxtNumber)
        Me.GroupBox1.Controls.Add(Me.LblDistrict)
        Me.GroupBox1.Controls.Add(Me.TxtDistrict)
        Me.GroupBox1.Controls.Add(Me.LblCity)
        Me.GroupBox1.Controls.Add(Me.TxtCity)
        Me.GroupBox1.Controls.Add(Me.LblState)
        Me.GroupBox1.Controls.Add(Me.CbxState)
        Me.GroupBox1.Controls.Add(Me.LblComplement)
        Me.GroupBox1.Controls.Add(Me.TxtComplement)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 159)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(584, 124)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Endereço"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LblPhone1)
        Me.GroupBox3.Controls.Add(Me.TxtPhone1)
        Me.GroupBox3.Controls.Add(Me.LblPhone2)
        Me.GroupBox3.Controls.Add(Me.TxtSite)
        Me.GroupBox3.Controls.Add(Me.TxtPhone2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.LblCellPhone)
        Me.GroupBox3.Controls.Add(Me.TxtLinkedin)
        Me.GroupBox3.Controls.Add(Me.TxtCellPhone)
        Me.GroupBox3.Controls.Add(Me.LblLinkedin)
        Me.GroupBox3.Controls.Add(Me.LblEmail)
        Me.GroupBox3.Controls.Add(Me.TxtInstagram)
        Me.GroupBox3.Controls.Add(Me.TxtEmail)
        Me.GroupBox3.Controls.Add(Me.LblInstagram)
        Me.GroupBox3.Controls.Add(Me.LblFacebook)
        Me.GroupBox3.Controls.Add(Me.TxtFacebook)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 289)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(584, 234)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Contato"
        '
        'TsTitle
        '
        Me.TsTitle.AutoSize = False
        Me.TsTitle.BackColor = System.Drawing.Color.White
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.BtnStatusValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 0)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(607, 25)
        Me.TsTitle.TabIndex = 47
        Me.TsTitle.Text = "ToolStrip1"
        '
        'LblID
        '
        Me.LblID.BackColor = System.Drawing.Color.White
        Me.LblID.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblID.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
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
        'EpValidator
        '
        Me.EpValidator.ContainerControl = Me
        '
        'FrmCompany
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(607, 572)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompany"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresa"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnButtons.ResumeLayout(False)
        Me.FlpProduct.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        CType(Me.EpValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    ' Definições Friend WithEvents (mantidas conforme original)
    Friend WithEvents SfdLogo As SaveFileDialog
    Friend WithEvents OfdLogo As OpenFileDialog
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnSave As Button
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
    Friend WithEvents FlpProduct As FlowLayoutPanel
    Friend WithEvents BtnIncludeLogo As CoreSuite.Controls.NoFocusCueButton
    Friend WithEvents BtnDeleteLogo As CoreSuite.Controls.NoFocusCueButton
    Friend WithEvents TxtCityDocument As TextBox
    Friend WithEvents TxtStateDocument As TextBox
    Friend WithEvents TxtDocument As TextBox
    Friend WithEvents TxtShortName As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblCityDocument As Label
    Friend WithEvents LblStateDocument As Label
    Friend WithEvents LblDocument As Label
    Friend WithEvents LblShortName As Label
    Friend WithEvents LblLogo As Label
    Friend WithEvents LblName As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PvLogo As CoreSuite.Controls.PictureViewer
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents EpValidator As ErrorProvider
    Friend WithEvents BtnClose As Button
End Class