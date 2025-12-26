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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.SfdLogo = New System.Windows.Forms.SaveFileDialog()
        Me.OfdLogo = New System.Windows.Forms.OpenFileDialog()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureViewer = New ControlLibrary.PictureViewer()
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
        Me.BtnIncludeLogo = New ControlLibrary.NoFocusCueButton()
        Me.BtnDeleteLogo = New ControlLibrary.NoFocusCueButton()
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnBackupDays = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtBackupLocation = New System.Windows.Forms.TextBox()
        Me.BtnBackupLocation = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CbxIgnoreNext = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LblBackupKeep = New System.Windows.Forms.Label()
        Me.DbxBackupKeep = New ControlLibrary.DecimalBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LblBackupTime = New System.Windows.Forms.Label()
        Me.TxtBackupTime = New System.Windows.Forms.MaskedTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
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
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.TxtCredentials = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.LblInterval = New System.Windows.Forms.Label()
        Me.TbrInterval = New System.Windows.Forms.TrackBar()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.LblEvaluationMonthsBeforeRecordDeletion = New System.Windows.Forms.Label()
        Me.DbxEvaluationMonthsBeforeRecordDeletion = New ControlLibrary.DecimalBox()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.LblEvaluationDaysBeforeVisitAlert = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysBeforeVisitAlert = New ControlLibrary.DecimalBox()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.LblEvaluationDaysBeforeMaintenanceAlert = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysBeforeMaintenanceAlert = New ControlLibrary.DecimalBox()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.LblReleaseRegister = New System.Windows.Forms.Label()
        Me.TbrReleaseRegister = New System.Windows.Forms.TrackBar()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.TxtUserDefaultPassword = New System.Windows.Forms.TextBox()
        Me.LblUserDefaultPassword = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.TxtSupportSMTPServer = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.TxtSupportEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DbxSupportPort = New ControlLibrary.DecimalBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.CbxEnableSSL = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.LblSyncInterval = New System.Windows.Forms.Label()
        Me.TbrSyncInterval = New System.Windows.Forms.TrackBar()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.FlpProduct.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.TbrInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel19.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.TbrSyncInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 504)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(594, 44)
        Me.PnButtons.TabIndex = 8
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(490, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(389, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
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
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(594, 504)
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
        Me.TabPage1.Size = New System.Drawing.Size(586, 474)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cadastro"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Panel6)
        Me.TabPage2.Controls.Add(Me.Panel5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(586, 474)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Backup"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnBackupDays)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(8, 10)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(450, 31)
        Me.Panel3.TabIndex = 33
        '
        'BtnBackupDays
        '
        Me.BtnBackupDays.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBackupDays.Location = New System.Drawing.Point(241, 3)
        Me.BtnBackupDays.Name = "BtnBackupDays"
        Me.BtnBackupDays.Size = New System.Drawing.Size(203, 23)
        Me.BtnBackupDays.TabIndex = 29
        Me.BtnBackupDays.Text = "Seg, Ter, Qua, Qui, Sex, Sáb, Dom"
        Me.BtnBackupDays.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(4, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 29)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Dias de backup"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtBackupLocation)
        Me.Panel2.Controls.Add(Me.BtnBackupLocation)
        Me.Panel2.Location = New System.Drawing.Point(8, 186)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(450, 31)
        Me.Panel2.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Location = New System.Drawing.Point(4, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 29)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Local"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBackupLocation
        '
        Me.TxtBackupLocation.Location = New System.Drawing.Point(84, 3)
        Me.TxtBackupLocation.Name = "TxtBackupLocation"
        Me.TxtBackupLocation.ReadOnly = True
        Me.TxtBackupLocation.Size = New System.Drawing.Size(327, 23)
        Me.TxtBackupLocation.TabIndex = 1
        '
        'BtnBackupLocation
        '
        Me.BtnBackupLocation.Location = New System.Drawing.Point(417, 3)
        Me.BtnBackupLocation.Name = "BtnBackupLocation"
        Me.BtnBackupLocation.Size = New System.Drawing.Size(28, 23)
        Me.BtnBackupLocation.TabIndex = 2
        Me.BtnBackupLocation.Text = "..."
        Me.BtnBackupLocation.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CbxIgnoreNext)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(8, 142)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(450, 31)
        Me.Panel1.TabIndex = 31
        '
        'CbxIgnoreNext
        '
        Me.CbxIgnoreNext.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxIgnoreNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxIgnoreNext.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxIgnoreNext.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CbxIgnoreNext.Location = New System.Drawing.Point(241, 3)
        Me.CbxIgnoreNext.Name = "CbxIgnoreNext"
        Me.CbxIgnoreNext.Size = New System.Drawing.Size(204, 23)
        Me.CbxIgnoreNext.TabIndex = 3
        Me.CbxIgnoreNext.Text = "Não"
        Me.CbxIgnoreNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxIgnoreNext.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(4, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 29)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ignorar próximo backup"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.LblBackupKeep)
        Me.Panel6.Controls.Add(Me.DbxBackupKeep)
        Me.Panel6.Location = New System.Drawing.Point(8, 98)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel6.Size = New System.Drawing.Size(450, 31)
        Me.Panel6.TabIndex = 30
        '
        'LblBackupKeep
        '
        Me.LblBackupKeep.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblBackupKeep.Location = New System.Drawing.Point(4, 0)
        Me.LblBackupKeep.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBackupKeep.Name = "LblBackupKeep"
        Me.LblBackupKeep.Size = New System.Drawing.Size(230, 29)
        Me.LblBackupKeep.TabIndex = 0
        Me.LblBackupKeep.Text = "Qtd. mantida"
        Me.LblBackupKeep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxBackupKeep
        '
        Me.DbxBackupKeep.DecimalOnly = True
        Me.DbxBackupKeep.DecimalPlaces = 0
        Me.DbxBackupKeep.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxBackupKeep.Location = New System.Drawing.Point(241, 3)
        Me.DbxBackupKeep.Name = "DbxBackupKeep"
        Me.DbxBackupKeep.Size = New System.Drawing.Size(204, 23)
        Me.DbxBackupKeep.TabIndex = 1
        Me.DbxBackupKeep.Text = "0"
        Me.DbxBackupKeep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.LblBackupTime)
        Me.Panel5.Controls.Add(Me.TxtBackupTime)
        Me.Panel5.Location = New System.Drawing.Point(8, 54)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel5.Size = New System.Drawing.Size(450, 31)
        Me.Panel5.TabIndex = 29
        '
        'LblBackupTime
        '
        Me.LblBackupTime.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblBackupTime.Location = New System.Drawing.Point(4, 0)
        Me.LblBackupTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBackupTime.Name = "LblBackupTime"
        Me.LblBackupTime.Size = New System.Drawing.Size(230, 29)
        Me.LblBackupTime.TabIndex = 0
        Me.LblBackupTime.Text = "Horário"
        Me.LblBackupTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBackupTime
        '
        Me.TxtBackupTime.Location = New System.Drawing.Point(241, 3)
        Me.TxtBackupTime.Mask = "00:00:00"
        Me.TxtBackupTime.Name = "TxtBackupTime"
        Me.TxtBackupTime.Size = New System.Drawing.Size(204, 23)
        Me.TxtBackupTime.TabIndex = 1
        Me.TxtBackupTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtBackupTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.TxtBackupTime.ValidatingType = GetType(Date)
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel11)
        Me.TabPage3.Controls.Add(Me.Panel10)
        Me.TabPage3.Controls.Add(Me.Panel9)
        Me.TabPage3.Controls.Add(Me.Panel4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(586, 474)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Banco de Dados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Panel17)
        Me.TabPage4.Controls.Add(Me.Panel21)
        Me.TabPage4.Location = New System.Drawing.Point(4, 26)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(586, 474)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Licença"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Panel19)
        Me.TabPage5.Controls.Add(Me.Panel25)
        Me.TabPage5.Controls.Add(Me.Panel7)
        Me.TabPage5.Controls.Add(Me.Panel26)
        Me.TabPage5.Controls.Add(Me.Panel23)
        Me.TabPage5.Controls.Add(Me.Panel24)
        Me.TabPage5.Location = New System.Drawing.Point(4, 26)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(586, 474)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Configurações"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Panel18)
        Me.TabPage6.Controls.Add(Me.Panel16)
        Me.TabPage6.Controls.Add(Me.Panel13)
        Me.TabPage6.Controls.Add(Me.Panel12)
        Me.TabPage6.Location = New System.Drawing.Point(4, 26)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(586, 474)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Suporte"
        Me.TabPage6.UseVisualStyleBackColor = True
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
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.White
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.TxtCredentials)
        Me.Panel17.Controls.Add(Me.Label11)
        Me.Panel17.Location = New System.Drawing.Point(8, 50)
        Me.Panel17.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel17.Size = New System.Drawing.Size(450, 155)
        Me.Panel17.TabIndex = 9
        '
        'TxtCredentials
        '
        Me.TxtCredentials.Location = New System.Drawing.Point(131, 3)
        Me.TxtCredentials.Multiline = True
        Me.TxtCredentials.Name = "TxtCredentials"
        Me.TxtCredentials.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtCredentials.Size = New System.Drawing.Size(314, 147)
        Me.TxtCredentials.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Location = New System.Drawing.Point(4, 0)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 153)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Credenciais"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.White
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.TextBox1)
        Me.Panel21.Controls.Add(Me.Label13)
        Me.Panel21.Location = New System.Drawing.Point(8, 10)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel21.Size = New System.Drawing.Size(450, 31)
        Me.Panel21.TabIndex = 8
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(131, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(314, 23)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Location = New System.Drawing.Point(4, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 29)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Nome"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.White
        Me.Panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel24.Controls.Add(Me.LblInterval)
        Me.Panel24.Controls.Add(Me.TbrInterval)
        Me.Panel24.Location = New System.Drawing.Point(8, 10)
        Me.Panel24.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel24.Size = New System.Drawing.Size(450, 62)
        Me.Panel24.TabIndex = 13
        '
        'LblInterval
        '
        Me.LblInterval.Location = New System.Drawing.Point(1, -1)
        Me.LblInterval.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblInterval.Name = "LblInterval"
        Me.LblInterval.Size = New System.Drawing.Size(414, 26)
        Me.LblInterval.TabIndex = 3
        Me.LblInterval.Text = "Executar a limpeza a cada 1 dia"
        Me.LblInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrInterval
        '
        Me.TbrInterval.AutoSize = False
        Me.TbrInterval.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrInterval.Location = New System.Drawing.Point(4, 29)
        Me.TbrInterval.Maximum = 60
        Me.TbrInterval.Minimum = 1
        Me.TbrInterval.Name = "TbrInterval"
        Me.TbrInterval.Size = New System.Drawing.Size(444, 31)
        Me.TbrInterval.TabIndex = 2
        Me.TbrInterval.Value = 2
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.LblEvaluationMonthsBeforeRecordDeletion)
        Me.Panel7.Controls.Add(Me.DbxEvaluationMonthsBeforeRecordDeletion)
        Me.Panel7.Location = New System.Drawing.Point(8, 173)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel7.Size = New System.Drawing.Size(450, 31)
        Me.Panel7.TabIndex = 16
        '
        'LblEvaluationMonthsBeforeRecordDeletion
        '
        Me.LblEvaluationMonthsBeforeRecordDeletion.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationMonthsBeforeRecordDeletion.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationMonthsBeforeRecordDeletion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationMonthsBeforeRecordDeletion.Name = "LblEvaluationMonthsBeforeRecordDeletion"
        Me.LblEvaluationMonthsBeforeRecordDeletion.Size = New System.Drawing.Size(213, 29)
        Me.LblEvaluationMonthsBeforeRecordDeletion.TabIndex = 0
        Me.LblEvaluationMonthsBeforeRecordDeletion.Text = "Meses de retenção dos registros"
        Me.LblEvaluationMonthsBeforeRecordDeletion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationMonthsBeforeRecordDeletion
        '
        Me.DbxEvaluationMonthsBeforeRecordDeletion.DecimalOnly = True
        Me.DbxEvaluationMonthsBeforeRecordDeletion.DecimalPlaces = 0
        Me.DbxEvaluationMonthsBeforeRecordDeletion.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Location = New System.Drawing.Point(274, 3)
        Me.DbxEvaluationMonthsBeforeRecordDeletion.MaxLength = 3
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Name = "DbxEvaluationMonthsBeforeRecordDeletion"
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Size = New System.Drawing.Size(171, 23)
        Me.DbxEvaluationMonthsBeforeRecordDeletion.TabIndex = 1
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Text = "0"
        Me.DbxEvaluationMonthsBeforeRecordDeletion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.Color.White
        Me.Panel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel26.Controls.Add(Me.LblEvaluationDaysBeforeVisitAlert)
        Me.Panel26.Controls.Add(Me.DbxEvaluationDaysBeforeVisitAlert)
        Me.Panel26.Location = New System.Drawing.Point(8, 129)
        Me.Panel26.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel26.Size = New System.Drawing.Size(450, 31)
        Me.Panel26.TabIndex = 15
        '
        'LblEvaluationDaysBeforeVisitAlert
        '
        Me.LblEvaluationDaysBeforeVisitAlert.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationDaysBeforeVisitAlert.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationDaysBeforeVisitAlert.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationDaysBeforeVisitAlert.Name = "LblEvaluationDaysBeforeVisitAlert"
        Me.LblEvaluationDaysBeforeVisitAlert.Size = New System.Drawing.Size(157, 29)
        Me.LblEvaluationDaysBeforeVisitAlert.TabIndex = 0
        Me.LblEvaluationDaysBeforeVisitAlert.Text = "Dias para alertar visita"
        Me.LblEvaluationDaysBeforeVisitAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationDaysBeforeVisitAlert
        '
        Me.DbxEvaluationDaysBeforeVisitAlert.DecimalOnly = True
        Me.DbxEvaluationDaysBeforeVisitAlert.DecimalPlaces = 0
        Me.DbxEvaluationDaysBeforeVisitAlert.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationDaysBeforeVisitAlert.Location = New System.Drawing.Point(274, 3)
        Me.DbxEvaluationDaysBeforeVisitAlert.MaxLength = 3
        Me.DbxEvaluationDaysBeforeVisitAlert.Name = "DbxEvaluationDaysBeforeVisitAlert"
        Me.DbxEvaluationDaysBeforeVisitAlert.Size = New System.Drawing.Size(171, 23)
        Me.DbxEvaluationDaysBeforeVisitAlert.TabIndex = 1
        Me.DbxEvaluationDaysBeforeVisitAlert.Text = "0"
        Me.DbxEvaluationDaysBeforeVisitAlert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.White
        Me.Panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel23.Controls.Add(Me.LblEvaluationDaysBeforeMaintenanceAlert)
        Me.Panel23.Controls.Add(Me.DbxEvaluationDaysBeforeMaintenanceAlert)
        Me.Panel23.Location = New System.Drawing.Point(8, 85)
        Me.Panel23.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel23.Size = New System.Drawing.Size(450, 31)
        Me.Panel23.TabIndex = 14
        '
        'LblEvaluationDaysBeforeMaintenanceAlert
        '
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Name = "LblEvaluationDaysBeforeMaintenanceAlert"
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Size = New System.Drawing.Size(207, 29)
        Me.LblEvaluationDaysBeforeMaintenanceAlert.TabIndex = 0
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Text = "Dias para alertar manutenção"
        Me.LblEvaluationDaysBeforeMaintenanceAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationDaysBeforeMaintenanceAlert
        '
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.DecimalOnly = True
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.DecimalPlaces = 0
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Location = New System.Drawing.Point(274, 3)
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.MaxLength = 3
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Name = "DbxEvaluationDaysBeforeMaintenanceAlert"
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Size = New System.Drawing.Size(171, 23)
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.TabIndex = 1
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Text = "0"
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.White
        Me.Panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel25.Controls.Add(Me.LblReleaseRegister)
        Me.Panel25.Controls.Add(Me.TbrReleaseRegister)
        Me.Panel25.Location = New System.Drawing.Point(8, 213)
        Me.Panel25.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel25.Size = New System.Drawing.Size(450, 62)
        Me.Panel25.TabIndex = 17
        '
        'LblReleaseRegister
        '
        Me.LblReleaseRegister.Location = New System.Drawing.Point(1, 1)
        Me.LblReleaseRegister.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblReleaseRegister.Name = "LblReleaseRegister"
        Me.LblReleaseRegister.Size = New System.Drawing.Size(414, 26)
        Me.LblReleaseRegister.TabIndex = 3
        Me.LblReleaseRegister.Text = "Liberar registros não atualizados a mais de 2 minutos"
        Me.LblReleaseRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrReleaseRegister
        '
        Me.TbrReleaseRegister.AutoSize = False
        Me.TbrReleaseRegister.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrReleaseRegister.Location = New System.Drawing.Point(4, 29)
        Me.TbrReleaseRegister.Maximum = 60
        Me.TbrReleaseRegister.Minimum = 2
        Me.TbrReleaseRegister.Name = "TbrReleaseRegister"
        Me.TbrReleaseRegister.Size = New System.Drawing.Size(444, 31)
        Me.TbrReleaseRegister.TabIndex = 2
        Me.TbrReleaseRegister.Value = 2
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel19.Controls.Add(Me.TxtUserDefaultPassword)
        Me.Panel19.Controls.Add(Me.LblUserDefaultPassword)
        Me.Panel19.Location = New System.Drawing.Point(8, 287)
        Me.Panel19.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel19.Size = New System.Drawing.Size(450, 31)
        Me.Panel19.TabIndex = 18
        '
        'TxtUserDefaultPassword
        '
        Me.TxtUserDefaultPassword.Location = New System.Drawing.Point(274, 3)
        Me.TxtUserDefaultPassword.Name = "TxtUserDefaultPassword"
        Me.TxtUserDefaultPassword.Size = New System.Drawing.Size(171, 23)
        Me.TxtUserDefaultPassword.TabIndex = 1
        Me.TxtUserDefaultPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblUserDefaultPassword
        '
        Me.LblUserDefaultPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblUserDefaultPassword.Location = New System.Drawing.Point(4, 0)
        Me.LblUserDefaultPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUserDefaultPassword.Name = "LblUserDefaultPassword"
        Me.LblUserDefaultPassword.Size = New System.Drawing.Size(120, 29)
        Me.LblUserDefaultPassword.TabIndex = 0
        Me.LblUserDefaultPassword.Text = "Senha padrão"
        Me.LblUserDefaultPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.White
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.TxtSupportSMTPServer)
        Me.Panel18.Controls.Add(Me.Label19)
        Me.Panel18.Location = New System.Drawing.Point(8, 98)
        Me.Panel18.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel18.Size = New System.Drawing.Size(450, 31)
        Me.Panel18.TabIndex = 15
        '
        'TxtSupportSMTPServer
        '
        Me.TxtSupportSMTPServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtSupportSMTPServer.Location = New System.Drawing.Point(162, 3)
        Me.TxtSupportSMTPServer.Name = "TxtSupportSMTPServer"
        Me.TxtSupportSMTPServer.Size = New System.Drawing.Size(283, 23)
        Me.TxtSupportSMTPServer.TabIndex = 1
        Me.TxtSupportSMTPServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label19.Location = New System.Drawing.Point(4, 0)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 29)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Servidor SMTP"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.White
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.TxtSupportEmail)
        Me.Panel16.Controls.Add(Me.Label3)
        Me.Panel16.Location = New System.Drawing.Point(8, 54)
        Me.Panel16.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel16.Size = New System.Drawing.Size(450, 31)
        Me.Panel16.TabIndex = 14
        '
        'TxtSupportEmail
        '
        Me.TxtSupportEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtSupportEmail.Location = New System.Drawing.Point(162, 3)
        Me.TxtSupportEmail.Name = "TxtSupportEmail"
        Me.TxtSupportEmail.Size = New System.Drawing.Size(283, 23)
        Me.TxtSupportEmail.TabIndex = 1
        Me.TxtSupportEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(4, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "E-Mail"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.Label16)
        Me.Panel13.Controls.Add(Me.DbxSupportPort)
        Me.Panel13.Location = New System.Drawing.Point(8, 142)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel13.Size = New System.Drawing.Size(450, 31)
        Me.Panel13.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Location = New System.Drawing.Point(4, 0)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 29)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Porta"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxSupportPort
        '
        Me.DbxSupportPort.DecimalOnly = True
        Me.DbxSupportPort.DecimalPlaces = 0
        Me.DbxSupportPort.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxSupportPort.Location = New System.Drawing.Point(162, 3)
        Me.DbxSupportPort.Name = "DbxSupportPort"
        Me.DbxSupportPort.Size = New System.Drawing.Size(283, 23)
        Me.DbxSupportPort.TabIndex = 1
        Me.DbxSupportPort.Text = "0"
        Me.DbxSupportPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.White
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.CbxEnableSSL)
        Me.Panel12.Controls.Add(Me.Label12)
        Me.Panel12.Location = New System.Drawing.Point(8, 10)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel12.Size = New System.Drawing.Size(450, 31)
        Me.Panel12.TabIndex = 13
        '
        'CbxEnableSSL
        '
        Me.CbxEnableSSL.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxEnableSSL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxEnableSSL.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxEnableSSL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CbxEnableSSL.Location = New System.Drawing.Point(162, 3)
        Me.CbxEnableSSL.Name = "CbxEnableSSL"
        Me.CbxEnableSSL.Size = New System.Drawing.Size(283, 23)
        Me.CbxEnableSSL.TabIndex = 3
        Me.CbxEnableSSL.Text = "Não"
        Me.CbxEnableSSL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxEnableSSL.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label12.Location = New System.Drawing.Point(4, 0)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 29)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Habilita SSL"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Panel20)
        Me.TabPage7.Controls.Add(Me.Panel8)
        Me.TabPage7.Controls.Add(Me.Panel14)
        Me.TabPage7.Controls.Add(Me.Panel15)
        Me.TabPage7.Location = New System.Drawing.Point(4, 26)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(586, 474)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Núvem"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.LblSyncInterval)
        Me.Panel8.Controls.Add(Me.TbrSyncInterval)
        Me.Panel8.Location = New System.Drawing.Point(8, 262)
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
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.White
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.TextBox2)
        Me.Panel14.Controls.Add(Me.Label5)
        Me.Panel14.Location = New System.Drawing.Point(8, 94)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel14.Size = New System.Drawing.Size(450, 155)
        Me.Panel14.TabIndex = 15
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(131, 3)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox2.Size = New System.Drawing.Size(314, 147)
        Me.TextBox2.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Location = New System.Drawing.Point(4, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 153)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Credenciais"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.White
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.TextBox3)
        Me.Panel15.Controls.Add(Me.Label10)
        Me.Panel15.Location = New System.Drawing.Point(8, 10)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel15.Size = New System.Drawing.Size(450, 31)
        Me.Panel15.TabIndex = 14
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(131, 3)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(314, 23)
        Me.TextBox3.TabIndex = 1
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Location = New System.Drawing.Point(4, 0)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 29)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Nome"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.White
        Me.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel20.Controls.Add(Me.TextBox4)
        Me.Panel20.Controls.Add(Me.Label14)
        Me.Panel20.Location = New System.Drawing.Point(8, 50)
        Me.Panel20.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel20.Size = New System.Drawing.Size(450, 31)
        Me.Panel20.TabIndex = 17
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(131, 3)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(314, 23)
        Me.TextBox4.TabIndex = 1
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Location = New System.Drawing.Point(4, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 29)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Nome do Bucket"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCompany
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(594, 548)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCompany"
        Me.ShowIcon = False
        Me.Text = "Cadastro"
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.FlpProduct.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.Panel24.ResumeLayout(False)
        CType(Me.TbrInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.Panel25.ResumeLayout(False)
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.TbrSyncInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents SfdLogo As SaveFileDialog
    Friend WithEvents OfdLogo As OpenFileDialog
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents PictureViewer As ControlLibrary.PictureViewer
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
    Friend WithEvents BtnIncludeLogo As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnDeleteLogo As ControlLibrary.NoFocusCueButton
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
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnBackupDays As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtBackupLocation As TextBox
    Friend WithEvents BtnBackupLocation As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CbxIgnoreNext As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents LblBackupKeep As Label
    Friend WithEvents DbxBackupKeep As ControlLibrary.DecimalBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblBackupTime As Label
    Friend WithEvents TxtBackupTime As MaskedTextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
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
    Friend WithEvents Panel17 As Panel
    Friend WithEvents TxtCredentials As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel24 As Panel
    Friend WithEvents LblInterval As Label
    Friend WithEvents TbrInterval As TrackBar
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LblEvaluationMonthsBeforeRecordDeletion As Label
    Friend WithEvents DbxEvaluationMonthsBeforeRecordDeletion As ControlLibrary.DecimalBox
    Friend WithEvents Panel26 As Panel
    Friend WithEvents LblEvaluationDaysBeforeVisitAlert As Label
    Friend WithEvents DbxEvaluationDaysBeforeVisitAlert As ControlLibrary.DecimalBox
    Friend WithEvents Panel23 As Panel
    Friend WithEvents LblEvaluationDaysBeforeMaintenanceAlert As Label
    Friend WithEvents DbxEvaluationDaysBeforeMaintenanceAlert As ControlLibrary.DecimalBox
    Friend WithEvents Panel25 As Panel
    Friend WithEvents LblReleaseRegister As Label
    Friend WithEvents TbrReleaseRegister As TrackBar
    Friend WithEvents Panel19 As Panel
    Friend WithEvents TxtUserDefaultPassword As TextBox
    Friend WithEvents LblUserDefaultPassword As Label
    Friend WithEvents Panel18 As Panel
    Friend WithEvents TxtSupportSMTPServer As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents TxtSupportEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents DbxSupportPort As ControlLibrary.DecimalBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents CbxEnableSSL As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LblSyncInterval As Label
    Friend WithEvents TbrSyncInterval As TrackBar
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel20 As Panel
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label14 As Label
End Class
