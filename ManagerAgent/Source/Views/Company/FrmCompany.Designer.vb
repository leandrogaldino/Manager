<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompany
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
        Me.SfdLogo = New System.Windows.Forms.SaveFileDialog()
        Me.OfdLogo = New System.Windows.Forms.OpenFileDialog()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureViewer = New CoreSuite.Controls.PictureViewer()
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
        Me.LblShortname = New System.Windows.Forms.Label()
        Me.LblLogo = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtDatabaseServer = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtDatabaseName = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDatabasePassword = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtDatabaseUsername = New System.Windows.Forms.TextBox()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.TxtBucketName = New System.Windows.Forms.TextBox()
        Me.LblBucketName = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.TxtProjectID = New System.Windows.Forms.TextBox()
        Me.LblProjectID = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TxtApiKey = New System.Windows.Forms.TextBox()
        Me.LblApiKey = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.LblSyncInterval = New System.Windows.Forms.Label()
        Me.TbrSyncInterval = New System.Windows.Forms.TrackBar()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnTestAndOK = New System.Windows.Forms.Button()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.FlpProduct.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.TbrSyncInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnButtons.SuspendLayout()
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(594, 500)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PictureViewer)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.LblLinkedin)
        Me.TabPage1.Controls.Add(Me.LblInstagram)
        Me.TabPage1.Controls.Add(Me.TxtSite)
        Me.TabPage1.Controls.Add(Me.TxtLinkedin)
        Me.TabPage1.Controls.Add(Me.LblFacebook)
        Me.TabPage1.Controls.Add(Me.TxtInstagram)
        Me.TabPage1.Controls.Add(Me.TxtFacebook)
        Me.TabPage1.Controls.Add(Me.LblEmail)
        Me.TabPage1.Controls.Add(Me.TxtEmail)
        Me.TabPage1.Controls.Add(Me.TxtCellPhone)
        Me.TabPage1.Controls.Add(Me.LblCellPhone)
        Me.TabPage1.Controls.Add(Me.TxtPhone2)
        Me.TabPage1.Controls.Add(Me.LblPhone2)
        Me.TabPage1.Controls.Add(Me.TxtPhone1)
        Me.TabPage1.Controls.Add(Me.LblPhone1)
        Me.TabPage1.Controls.Add(Me.CbxState)
        Me.TabPage1.Controls.Add(Me.LblState)
        Me.TabPage1.Controls.Add(Me.LblZipCode)
        Me.TabPage1.Controls.Add(Me.LblComplement)
        Me.TabPage1.Controls.Add(Me.TxtZipCode)
        Me.TabPage1.Controls.Add(Me.TxtNumber)
        Me.TabPage1.Controls.Add(Me.LblCity)
        Me.TabPage1.Controls.Add(Me.LblDistrict)
        Me.TabPage1.Controls.Add(Me.TxtCity)
        Me.TabPage1.Controls.Add(Me.TxtDistrict)
        Me.TabPage1.Controls.Add(Me.LblNumber)
        Me.TabPage1.Controls.Add(Me.TxtComplement)
        Me.TabPage1.Controls.Add(Me.LblStreet)
        Me.TabPage1.Controls.Add(Me.TxtStreet)
        Me.TabPage1.Controls.Add(Me.FlpProduct)
        Me.TabPage1.Controls.Add(Me.TxtCityDocument)
        Me.TabPage1.Controls.Add(Me.TxtStateDocument)
        Me.TabPage1.Controls.Add(Me.TxtDocument)
        Me.TabPage1.Controls.Add(Me.TxtShortName)
        Me.TabPage1.Controls.Add(Me.TxtName)
        Me.TabPage1.Controls.Add(Me.LblCityDocument)
        Me.TabPage1.Controls.Add(Me.LblStateDocument)
        Me.TabPage1.Controls.Add(Me.LblDocument)
        Me.TabPage1.Controls.Add(Me.LblShortname)
        Me.TabPage1.Controls.Add(Me.LblLogo)
        Me.TabPage1.Controls.Add(Me.LblName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(586, 470)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cadastro"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PictureViewer
        '
        Me.PictureViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureViewer.ControlBarBackColor = System.Drawing.Color.White
        Me.PictureViewer.CounterBarBackColor = System.Drawing.Color.White
        Me.PictureViewer.CounterMask = "{0}/{1}"
        Me.PictureViewer.FirstButtonImage = Nothing
        Me.PictureViewer.IncludeButtonImage = Nothing
        Me.PictureViewer.LastButtonImage = Nothing
        Me.PictureViewer.Location = New System.Drawing.Point(6, 23)
        Me.PictureViewer.MaximumPictures = Nothing
        Me.PictureViewer.Name = "PictureViewer"
        Me.PictureViewer.NextButtonImage = Nothing
        Me.PictureViewer.Padding = New System.Windows.Forms.Padding(1)
        Me.PictureViewer.PreviousButtonImage = Nothing
        Me.PictureViewer.RemoveButtonImage = Nothing
        Me.PictureViewer.SaveButtonImage = Nothing
        Me.PictureViewer.ShowControlBar = False
        Me.PictureViewer.ShowCounterBar = False
        Me.PictureViewer.Size = New System.Drawing.Size(141, 69)
        Me.PictureViewer.TabIndex = 98
        Me.PictureViewer.TempDirectory = "C:\Users\leand\AppData\Local\Temp\"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 418)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Site"
        '
        'LblLinkedin
        '
        Me.LblLinkedin.AutoSize = True
        Me.LblLinkedin.Location = New System.Drawing.Point(7, 371)
        Me.LblLinkedin.Name = "LblLinkedin"
        Me.LblLinkedin.Size = New System.Drawing.Size(60, 17)
        Me.LblLinkedin.TabIndex = 94
        Me.LblLinkedin.Text = "Linkedin"
        '
        'LblInstagram
        '
        Me.LblInstagram.AutoSize = True
        Me.LblInstagram.Location = New System.Drawing.Point(7, 325)
        Me.LblInstagram.Name = "LblInstagram"
        Me.LblInstagram.Size = New System.Drawing.Size(73, 17)
        Me.LblInstagram.TabIndex = 92
        Me.LblInstagram.Text = "Instagram"
        '
        'TxtSite
        '
        Me.TxtSite.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtSite.Location = New System.Drawing.Point(10, 438)
        Me.TxtSite.MaxLength = 100
        Me.TxtSite.Name = "TxtSite"
        Me.TxtSite.Size = New System.Drawing.Size(567, 23)
        Me.TxtSite.TabIndex = 97
        '
        'TxtLinkedin
        '
        Me.TxtLinkedin.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtLinkedin.Location = New System.Drawing.Point(10, 391)
        Me.TxtLinkedin.MaxLength = 100
        Me.TxtLinkedin.Name = "TxtLinkedin"
        Me.TxtLinkedin.Size = New System.Drawing.Size(567, 23)
        Me.TxtLinkedin.TabIndex = 95
        '
        'LblFacebook
        '
        Me.LblFacebook.AutoSize = True
        Me.LblFacebook.Location = New System.Drawing.Point(7, 279)
        Me.LblFacebook.Name = "LblFacebook"
        Me.LblFacebook.Size = New System.Drawing.Size(73, 17)
        Me.LblFacebook.TabIndex = 90
        Me.LblFacebook.Text = "Facebook"
        '
        'TxtInstagram
        '
        Me.TxtInstagram.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtInstagram.Location = New System.Drawing.Point(10, 345)
        Me.TxtInstagram.MaxLength = 100
        Me.TxtInstagram.Name = "TxtInstagram"
        Me.TxtInstagram.Size = New System.Drawing.Size(567, 23)
        Me.TxtInstagram.TabIndex = 93
        '
        'TxtFacebook
        '
        Me.TxtFacebook.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtFacebook.Location = New System.Drawing.Point(10, 299)
        Me.TxtFacebook.MaxLength = 100
        Me.TxtFacebook.Name = "TxtFacebook"
        Me.TxtFacebook.Size = New System.Drawing.Size(567, 23)
        Me.TxtFacebook.TabIndex = 91
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(7, 233)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(45, 17)
        Me.LblEmail.TabIndex = 88
        Me.LblEmail.Text = "E-Mail"
        '
        'TxtEmail
        '
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtEmail.Location = New System.Drawing.Point(10, 253)
        Me.TxtEmail.MaxLength = 100
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(567, 23)
        Me.TxtEmail.TabIndex = 89
        '
        'TxtCellPhone
        '
        Me.TxtCellPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCellPhone.Location = New System.Drawing.Point(392, 207)
        Me.TxtCellPhone.MaxLength = 16
        Me.TxtCellPhone.Name = "TxtCellPhone"
        Me.TxtCellPhone.Size = New System.Drawing.Size(185, 23)
        Me.TxtCellPhone.TabIndex = 87
        '
        'LblCellPhone
        '
        Me.LblCellPhone.AutoSize = True
        Me.LblCellPhone.Location = New System.Drawing.Point(389, 187)
        Me.LblCellPhone.Name = "LblCellPhone"
        Me.LblCellPhone.Size = New System.Drawing.Size(54, 17)
        Me.LblCellPhone.TabIndex = 86
        Me.LblCellPhone.Text = "Celular"
        '
        'TxtPhone2
        '
        Me.TxtPhone2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPhone2.Location = New System.Drawing.Point(201, 207)
        Me.TxtPhone2.MaxLength = 16
        Me.TxtPhone2.Name = "TxtPhone2"
        Me.TxtPhone2.Size = New System.Drawing.Size(185, 23)
        Me.TxtPhone2.TabIndex = 85
        '
        'LblPhone2
        '
        Me.LblPhone2.AutoSize = True
        Me.LblPhone2.Location = New System.Drawing.Point(198, 187)
        Me.LblPhone2.Name = "LblPhone2"
        Me.LblPhone2.Size = New System.Drawing.Size(72, 17)
        Me.LblPhone2.TabIndex = 84
        Me.LblPhone2.Text = "Telefone 2"
        '
        'TxtPhone1
        '
        Me.TxtPhone1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPhone1.Location = New System.Drawing.Point(10, 207)
        Me.TxtPhone1.MaxLength = 16
        Me.TxtPhone1.Name = "TxtPhone1"
        Me.TxtPhone1.Size = New System.Drawing.Size(185, 23)
        Me.TxtPhone1.TabIndex = 83
        '
        'LblPhone1
        '
        Me.LblPhone1.AutoSize = True
        Me.LblPhone1.Location = New System.Drawing.Point(7, 187)
        Me.LblPhone1.Name = "LblPhone1"
        Me.LblPhone1.Size = New System.Drawing.Size(72, 17)
        Me.LblPhone1.TabIndex = 82
        Me.LblPhone1.Text = "Telefone 1"
        '
        'CbxState
        '
        Me.CbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxState.FormattingEnabled = True
        Me.CbxState.Items.AddRange(New Object() {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"})
        Me.CbxState.Location = New System.Drawing.Point(498, 161)
        Me.CbxState.Name = "CbxState"
        Me.CbxState.Size = New System.Drawing.Size(79, 25)
        Me.CbxState.TabIndex = 81
        '
        'LblState
        '
        Me.LblState.AutoSize = True
        Me.LblState.Location = New System.Drawing.Point(495, 141)
        Me.LblState.Name = "LblState"
        Me.LblState.Size = New System.Drawing.Size(22, 17)
        Me.LblState.TabIndex = 80
        Me.LblState.Text = "UF"
        '
        'LblZipCode
        '
        Me.LblZipCode.AutoSize = True
        Me.LblZipCode.Location = New System.Drawing.Point(6, 95)
        Me.LblZipCode.Name = "LblZipCode"
        Me.LblZipCode.Size = New System.Drawing.Size(36, 17)
        Me.LblZipCode.TabIndex = 68
        Me.LblZipCode.Text = "Cep"
        '
        'LblComplement
        '
        Me.LblComplement.AutoSize = True
        Me.LblComplement.Location = New System.Drawing.Point(307, 95)
        Me.LblComplement.Name = "LblComplement"
        Me.LblComplement.Size = New System.Drawing.Size(104, 17)
        Me.LblComplement.TabIndex = 74
        Me.LblComplement.Text = "Complemento"
        '
        'TxtZipCode
        '
        Me.TxtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZipCode.Location = New System.Drawing.Point(9, 115)
        Me.TxtZipCode.MaxLength = 10
        Me.TxtZipCode.Name = "TxtZipCode"
        Me.TxtZipCode.Size = New System.Drawing.Size(70, 23)
        Me.TxtZipCode.TabIndex = 69
        Me.TxtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNumber
        '
        Me.TxtNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumber.Location = New System.Drawing.Point(247, 115)
        Me.TxtNumber.MaxLength = 10
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(57, 23)
        Me.TxtNumber.TabIndex = 73
        Me.TxtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Location = New System.Drawing.Point(251, 141)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(57, 17)
        Me.LblCity.TabIndex = 78
        Me.LblCity.Text = "Cidade"
        '
        'LblDistrict
        '
        Me.LblDistrict.AutoSize = True
        Me.LblDistrict.Location = New System.Drawing.Point(6, 141)
        Me.LblDistrict.Name = "LblDistrict"
        Me.LblDistrict.Size = New System.Drawing.Size(44, 17)
        Me.LblDistrict.TabIndex = 76
        Me.LblDistrict.Text = "Bairro"
        '
        'TxtCity
        '
        Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCity.Location = New System.Drawing.Point(254, 161)
        Me.TxtCity.MaxLength = 50
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(239, 23)
        Me.TxtCity.TabIndex = 79
        '
        'TxtDistrict
        '
        Me.TxtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDistrict.Location = New System.Drawing.Point(9, 161)
        Me.TxtDistrict.MaxLength = 255
        Me.TxtDistrict.Name = "TxtDistrict"
        Me.TxtDistrict.Size = New System.Drawing.Size(239, 23)
        Me.TxtDistrict.TabIndex = 77
        '
        'LblNumber
        '
        Me.LblNumber.AutoSize = True
        Me.LblNumber.Location = New System.Drawing.Point(249, 95)
        Me.LblNumber.Name = "LblNumber"
        Me.LblNumber.Size = New System.Drawing.Size(23, 17)
        Me.LblNumber.TabIndex = 72
        Me.LblNumber.Text = "Nº"
        '
        'TxtComplement
        '
        Me.TxtComplement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplement.Location = New System.Drawing.Point(310, 115)
        Me.TxtComplement.MaxLength = 255
        Me.TxtComplement.Name = "TxtComplement"
        Me.TxtComplement.Size = New System.Drawing.Size(267, 23)
        Me.TxtComplement.TabIndex = 75
        '
        'LblStreet
        '
        Me.LblStreet.AutoSize = True
        Me.LblStreet.Location = New System.Drawing.Point(87, 95)
        Me.LblStreet.Name = "LblStreet"
        Me.LblStreet.Size = New System.Drawing.Size(33, 17)
        Me.LblStreet.TabIndex = 70
        Me.LblStreet.Text = "Rua"
        '
        'TxtStreet
        '
        Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStreet.Location = New System.Drawing.Point(85, 115)
        Me.TxtStreet.MaxLength = 255
        Me.TxtStreet.Name = "TxtStreet"
        Me.TxtStreet.Size = New System.Drawing.Size(156, 23)
        Me.TxtStreet.TabIndex = 71
        '
        'FlpProduct
        '
        Me.FlpProduct.Controls.Add(Me.BtnIncludeLogo)
        Me.FlpProduct.Controls.Add(Me.BtnDeleteLogo)
        Me.FlpProduct.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpProduct.Location = New System.Drawing.Point(97, 2)
        Me.FlpProduct.Name = "FlpProduct"
        Me.FlpProduct.Size = New System.Drawing.Size(50, 21)
        Me.FlpProduct.TabIndex = 57
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
        Me.TxtCityDocument.Location = New System.Drawing.Point(434, 69)
        Me.TxtCityDocument.MaxLength = 20
        Me.TxtCityDocument.Name = "TxtCityDocument"
        Me.TxtCityDocument.Size = New System.Drawing.Size(143, 23)
        Me.TxtCityDocument.TabIndex = 67
        Me.TxtCityDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtStateDocument
        '
        Me.TxtStateDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStateDocument.Location = New System.Drawing.Point(292, 69)
        Me.TxtStateDocument.MaxLength = 20
        Me.TxtStateDocument.Name = "TxtStateDocument"
        Me.TxtStateDocument.Size = New System.Drawing.Size(136, 23)
        Me.TxtStateDocument.TabIndex = 65
        Me.TxtStateDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtDocument
        '
        Me.TxtDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocument.Location = New System.Drawing.Point(153, 69)
        Me.TxtDocument.MaxLength = 18
        Me.TxtDocument.Name = "TxtDocument"
        Me.TxtDocument.Size = New System.Drawing.Size(136, 23)
        Me.TxtDocument.TabIndex = 63
        Me.TxtDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtShortName
        '
        Me.TxtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtShortName.Location = New System.Drawing.Point(437, 23)
        Me.TxtShortName.MaxLength = 50
        Me.TxtShortName.Name = "TxtShortName"
        Me.TxtShortName.Size = New System.Drawing.Size(140, 23)
        Me.TxtShortName.TabIndex = 61
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(153, 23)
        Me.TxtName.MaxLength = 255
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(278, 23)
        Me.TxtName.TabIndex = 59
        '
        'LblCityDocument
        '
        Me.LblCityDocument.AutoSize = True
        Me.LblCityDocument.Location = New System.Drawing.Point(431, 52)
        Me.LblCityDocument.Name = "LblCityDocument"
        Me.LblCityDocument.Size = New System.Drawing.Size(102, 17)
        Me.LblCityDocument.TabIndex = 66
        Me.LblCityDocument.Text = "Insc. Municipal"
        '
        'LblStateDocument
        '
        Me.LblStateDocument.AutoSize = True
        Me.LblStateDocument.Location = New System.Drawing.Point(289, 52)
        Me.LblStateDocument.Name = "LblStateDocument"
        Me.LblStateDocument.Size = New System.Drawing.Size(95, 17)
        Me.LblStateDocument.TabIndex = 64
        Me.LblStateDocument.Text = "Insc. Estadual"
        '
        'LblDocument
        '
        Me.LblDocument.AutoSize = True
        Me.LblDocument.Location = New System.Drawing.Point(150, 52)
        Me.LblDocument.Name = "LblDocument"
        Me.LblDocument.Size = New System.Drawing.Size(43, 17)
        Me.LblDocument.TabIndex = 62
        Me.LblDocument.Text = "CNPJ"
        '
        'LblShortname
        '
        Me.LblShortname.AutoSize = True
        Me.LblShortname.Location = New System.Drawing.Point(437, 6)
        Me.LblShortname.Name = "LblShortname"
        Me.LblShortname.Size = New System.Drawing.Size(62, 17)
        Me.LblShortname.TabIndex = 60
        Me.LblShortname.Text = "Fantasia"
        '
        'LblLogo
        '
        Me.LblLogo.AutoSize = True
        Me.LblLogo.Location = New System.Drawing.Point(6, 3)
        Me.LblLogo.Name = "LblLogo"
        Me.LblLogo.Size = New System.Drawing.Size(41, 17)
        Me.LblLogo.TabIndex = 56
        Me.LblLogo.Text = "Logo"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(150, 6)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(91, 17)
        Me.LblName.TabIndex = 58
        Me.LblName.Text = "Razão Social"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel11)
        Me.TabPage3.Controls.Add(Me.Panel10)
        Me.TabPage3.Controls.Add(Me.Panel9)
        Me.TabPage3.Controls.Add(Me.Panel4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(586, 470)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Banco de Dados Local"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.Label17)
        Me.Panel11.Controls.Add(Me.TxtDatabaseServer)
        Me.Panel11.Location = New System.Drawing.Point(8, 10)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel11.Size = New System.Drawing.Size(450, 31)
        Me.Panel11.TabIndex = 20
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label17.Location = New System.Drawing.Point(4, 0)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 29)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Servidor"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDatabaseServer
        '
        Me.TxtDatabaseServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtDatabaseServer.Location = New System.Drawing.Point(131, 3)
        Me.TxtDatabaseServer.Name = "TxtDatabaseServer"
        Me.TxtDatabaseServer.Size = New System.Drawing.Size(314, 23)
        Me.TxtDatabaseServer.TabIndex = 1
        Me.TxtDatabaseServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.White
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.Label8)
        Me.Panel10.Controls.Add(Me.TxtDatabaseName)
        Me.Panel10.Location = New System.Drawing.Point(8, 54)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel10.Size = New System.Drawing.Size(450, 31)
        Me.Panel10.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Location = New System.Drawing.Point(4, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 29)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Banco de Dados"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDatabaseName
        '
        Me.TxtDatabaseName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtDatabaseName.Location = New System.Drawing.Point(131, 3)
        Me.TxtDatabaseName.Name = "TxtDatabaseName"
        Me.TxtDatabaseName.Size = New System.Drawing.Size(314, 23)
        Me.TxtDatabaseName.TabIndex = 1
        Me.TxtDatabaseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Label7)
        Me.Panel9.Controls.Add(Me.TxtDatabasePassword)
        Me.Panel9.Location = New System.Drawing.Point(8, 142)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel9.Size = New System.Drawing.Size(450, 31)
        Me.Panel9.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Location = New System.Drawing.Point(4, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 29)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Senha"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDatabasePassword
        '
        Me.TxtDatabasePassword.Location = New System.Drawing.Point(131, 3)
        Me.TxtDatabasePassword.Name = "TxtDatabasePassword"
        Me.TxtDatabasePassword.Size = New System.Drawing.Size(314, 23)
        Me.TxtDatabasePassword.TabIndex = 1
        Me.TxtDatabasePassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtDatabasePassword.UseSystemPasswordChar = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.TxtDatabaseUsername)
        Me.Panel4.Location = New System.Drawing.Point(8, 98)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(450, 31)
        Me.Panel4.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Location = New System.Drawing.Point(4, 0)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 29)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Usuário"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDatabaseUsername
        '
        Me.TxtDatabaseUsername.Location = New System.Drawing.Point(131, 3)
        Me.TxtDatabaseUsername.Name = "TxtDatabaseUsername"
        Me.TxtDatabaseUsername.Size = New System.Drawing.Size(314, 23)
        Me.TxtDatabaseUsername.TabIndex = 1
        Me.TxtDatabaseUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Panel14)
        Me.TabPage7.Controls.Add(Me.Panel15)
        Me.TabPage7.Controls.Add(Me.Panel21)
        Me.TabPage7.Controls.Add(Me.Panel8)
        Me.TabPage7.Location = New System.Drawing.Point(4, 26)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(586, 470)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Banco de Dados Remoto"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.White
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.TxtBucketName)
        Me.Panel14.Controls.Add(Me.LblBucketName)
        Me.Panel14.Location = New System.Drawing.Point(8, 98)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel14.Size = New System.Drawing.Size(450, 31)
        Me.Panel14.TabIndex = 17
        '
        'TxtBucketName
        '
        Me.TxtBucketName.Location = New System.Drawing.Point(131, 3)
        Me.TxtBucketName.Name = "TxtBucketName"
        Me.TxtBucketName.Size = New System.Drawing.Size(314, 23)
        Me.TxtBucketName.TabIndex = 1
        Me.TxtBucketName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblBucketName
        '
        Me.LblBucketName.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblBucketName.Location = New System.Drawing.Point(4, 0)
        Me.LblBucketName.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblBucketName.Name = "LblBucketName"
        Me.LblBucketName.Size = New System.Drawing.Size(120, 29)
        Me.LblBucketName.TabIndex = 0
        Me.LblBucketName.Text = "Nome do Bucket"
        Me.LblBucketName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.White
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.TxtProjectID)
        Me.Panel15.Controls.Add(Me.LblProjectID)
        Me.Panel15.Location = New System.Drawing.Point(8, 54)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel15.Size = New System.Drawing.Size(450, 31)
        Me.Panel15.TabIndex = 18
        '
        'TxtProjectID
        '
        Me.TxtProjectID.Location = New System.Drawing.Point(131, 3)
        Me.TxtProjectID.Name = "TxtProjectID"
        Me.TxtProjectID.Size = New System.Drawing.Size(314, 23)
        Me.TxtProjectID.TabIndex = 1
        Me.TxtProjectID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblProjectID
        '
        Me.LblProjectID.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblProjectID.Location = New System.Drawing.Point(4, 0)
        Me.LblProjectID.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblProjectID.Name = "LblProjectID"
        Me.LblProjectID.Size = New System.Drawing.Size(120, 29)
        Me.LblProjectID.TabIndex = 0
        Me.LblProjectID.Text = "ID do Projeto"
        Me.LblProjectID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.White
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.TxtApiKey)
        Me.Panel21.Controls.Add(Me.LblApiKey)
        Me.Panel21.Location = New System.Drawing.Point(8, 10)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel21.Size = New System.Drawing.Size(450, 31)
        Me.Panel21.TabIndex = 19
        '
        'TxtApiKey
        '
        Me.TxtApiKey.Location = New System.Drawing.Point(131, 3)
        Me.TxtApiKey.Name = "TxtApiKey"
        Me.TxtApiKey.Size = New System.Drawing.Size(314, 23)
        Me.TxtApiKey.TabIndex = 1
        Me.TxtApiKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblApiKey
        '
        Me.LblApiKey.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblApiKey.Location = New System.Drawing.Point(4, 0)
        Me.LblApiKey.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblApiKey.Name = "LblApiKey"
        Me.LblApiKey.Size = New System.Drawing.Size(120, 29)
        Me.LblApiKey.TabIndex = 0
        Me.LblApiKey.Text = "API Key"
        Me.LblApiKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.LblSyncInterval)
        Me.Panel8.Controls.Add(Me.TbrSyncInterval)
        Me.Panel8.Location = New System.Drawing.Point(8, 138)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel8.Size = New System.Drawing.Size(450, 62)
        Me.Panel8.TabIndex = 16
        '
        'LblSyncInterval
        '
        Me.LblSyncInterval.Location = New System.Drawing.Point(1, -1)
        Me.LblSyncInterval.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSyncInterval.Name = "LblSyncInterval"
        Me.LblSyncInterval.Size = New System.Drawing.Size(414, 26)
        Me.LblSyncInterval.TabIndex = 3
        Me.LblSyncInterval.Text = "Sincronizar com a núvem a cada 1 minuto"
        Me.LblSyncInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrSyncInterval
        '
        Me.TbrSyncInterval.AutoSize = False
        Me.TbrSyncInterval.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrSyncInterval.Location = New System.Drawing.Point(4, 29)
        Me.TbrSyncInterval.Maximum = 60
        Me.TbrSyncInterval.Minimum = 1
        Me.TbrSyncInterval.Name = "TbrSyncInterval"
        Me.TbrSyncInterval.Size = New System.Drawing.Size(444, 31)
        Me.TbrSyncInterval.TabIndex = 2
        Me.TbrSyncInterval.Value = 1
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnTestAndOK)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 500)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(594, 36)
        Me.PnButtons.TabIndex = 10
        '
        'BtnTestAndOK
        '
        Me.BtnTestAndOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTestAndOK.Enabled = False
        Me.BtnTestAndOK.Location = New System.Drawing.Point(487, 3)
        Me.BtnTestAndOK.Name = "BtnTestAndOK"
        Me.BtnTestAndOK.Size = New System.Drawing.Size(95, 30)
        Me.BtnTestAndOK.TabIndex = 0
        Me.BtnTestAndOK.Text = "Testar"
        Me.BtnTestAndOK.UseVisualStyleBackColor = True
        '
        'FrmCompany
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(594, 536)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompany"
        Me.ShowIcon = False
        Me.Text = "Cadastro"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.FlpProduct.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        CType(Me.TbrSyncInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SfdLogo As SaveFileDialog
    Friend WithEvents OfdLogo As OpenFileDialog
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents PictureViewer As CoreSuite.Controls.PictureViewer
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
    Friend WithEvents LblShortname As Label
    Friend WithEvents LblLogo As Label
    Friend WithEvents LblName As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents TxtDatabaseServer As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtDatabaseName As TextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtDatabasePassword As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtDatabaseUsername As TextBox
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LblSyncInterval As Label
    Friend WithEvents TbrSyncInterval As TrackBar
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TxtBucketName As TextBox
    Friend WithEvents LblBucketName As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents TxtProjectID As TextBox
    Friend WithEvents LblProjectID As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TxtApiKey As TextBox
    Friend WithEvents LblApiKey As Label
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnTestAndOK As Button
End Class
