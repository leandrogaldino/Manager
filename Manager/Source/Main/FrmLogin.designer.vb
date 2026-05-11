<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        PbxLogo = New PictureBox()
        Panel1 = New Panel()
        PbxUser = New PictureBox()
        TxtUsername = New TextBox()
        Panel2 = New Panel()
        PbxPassword = New PictureBox()
        TxtPassword = New TextBox()
        BtnLogin = New CoreSuite.Controls.NoFocusCueButton()
        Panel3 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label1 = New Label()
        LblVersion = New LinkLabel()
        CType(PbxLogo, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PbxUser, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PbxPassword, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PbxLogo
        ' 
        PbxLogo.BackColor = Color.Transparent
        PbxLogo.Dock = DockStyle.Top
        PbxLogo.Location = New Point(1, 10)
        PbxLogo.Name = "PbxLogo"
        PbxLogo.Size = New Size(276, 132)
        PbxLogo.SizeMode = PictureBoxSizeMode.Zoom
        PbxLogo.TabIndex = 8
        PbxLogo.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(PbxUser)
        Panel1.Controls.Add(TxtUsername)
        Panel1.Location = New Point(3, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(260, 32)
        Panel1.TabIndex = 0
        ' 
        ' PbxUser
        ' 
        PbxUser.BackColor = Color.Transparent
        PbxUser.Location = New Point(3, 4)
        PbxUser.Name = "PbxUser"
        PbxUser.Size = New Size(24, 24)
        PbxUser.SizeMode = PictureBoxSizeMode.CenterImage
        PbxUser.TabIndex = 13
        PbxUser.TabStop = False
        ' 
        ' TxtUsername
        ' 
        TxtUsername.BackColor = Color.White
        TxtUsername.BorderStyle = BorderStyle.None
        TxtUsername.CharacterCasing = CharacterCasing.Upper
        TxtUsername.Font = New Font("Century Gothic", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TxtUsername.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TxtUsername.Location = New Point(31, 6)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(222, 20)
        TxtUsername.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.None
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(PbxPassword)
        Panel2.Controls.Add(TxtPassword)
        Panel2.Location = New Point(3, 68)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(260, 32)
        Panel2.TabIndex = 1
        ' 
        ' PbxPassword
        ' 
        PbxPassword.BackColor = Color.Transparent
        PbxPassword.Location = New Point(3, 4)
        PbxPassword.Name = "PbxPassword"
        PbxPassword.Size = New Size(24, 24)
        PbxPassword.SizeMode = PictureBoxSizeMode.CenterImage
        PbxPassword.TabIndex = 13
        PbxPassword.TabStop = False
        ' 
        ' TxtPassword
        ' 
        TxtPassword.BackColor = Color.White
        TxtPassword.BorderStyle = BorderStyle.None
        TxtPassword.Font = New Font("Century Gothic", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TxtPassword.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TxtPassword.Location = New Point(31, 6)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.Size = New Size(222, 20)
        TxtPassword.TabIndex = 0
        TxtPassword.UseSystemPasswordChar = True
        ' 
        ' BtnLogin
        ' 
        BtnLogin.Anchor = AnchorStyles.None
        BtnLogin.BackColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        BtnLogin.FlatAppearance.BorderColor = Color.FromArgb(CByte(35), CByte(35), CByte(35))
        BtnLogin.FlatStyle = FlatStyle.Flat
        BtnLogin.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold)
        BtnLogin.ForeColor = Color.White
        BtnLogin.Location = New Point(3, 125)
        BtnLogin.Name = "BtnLogin"
        BtnLogin.Size = New Size(260, 33)
        BtnLogin.TabIndex = 3
        BtnLogin.Text = "Entrar"
        BtnLogin.TooltipText = ""
        BtnLogin.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(55), CByte(55), CByte(55))
        Panel3.Controls.Add(TableLayoutPanel1)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(PbxLogo)
        Panel3.Location = New Point(19, 19)
        Panel3.Margin = New Padding(10)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(1, 10, 1, 1)
        Panel3.Size = New Size(278, 391)
        Panel3.TabIndex = 10
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Controls.Add(Panel2, 0, 1)
        TableLayoutPanel1.Controls.Add(BtnLogin, 0, 2)
        TableLayoutPanel1.Location = New Point(5, 210)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.0F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 34.0F))
        TableLayoutPanel1.Size = New Size(267, 171)
        TableLayoutPanel1.TabIndex = 10
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Top
        Label1.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(1, 142)
        Label1.Name = "Label1"
        Label1.Size = New Size(276, 65)
        Label1.TabIndex = 9
        Label1.Text = "GERENCIADOR"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblVersion
        ' 
        LblVersion.ActiveLinkColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        LblVersion.DisabledLinkColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        LblVersion.Dock = DockStyle.Bottom
        LblVersion.LinkBehavior = LinkBehavior.NeverUnderline
        LblVersion.LinkColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        LblVersion.Location = New Point(0, 412)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(319, 16)
        LblVersion.TabIndex = 11
        LblVersion.TabStop = True
        LblVersion.Text = "Versão: x.x"
        LblVersion.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' FrmLogin
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 16.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(319, 428)
        Controls.Add(LblVersion)
        Controls.Add(Panel3)
        DoubleBuffered = True
        Font = New Font("Century Gothic", 8.25F)
        ForeColor = SystemColors.ControlText
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmLogin"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        CType(PbxLogo, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PbxUser, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PbxPassword, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Friend WithEvents PbxLogo As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents BtnLogin As CoreSuite.Controls.NoFocusCueButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents PbxUser As PictureBox
    Friend WithEvents PbxPassword As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents LblVersion As LinkLabel
End Class
