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
        Me.PbxLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PbxUser = New System.Windows.Forms.PictureBox()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PbxPassword = New System.Windows.Forms.PictureBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.BtnLogin = New ControlLibrary.NoFocusCueButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.LinkLabel()
        CType(Me.PbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PbxUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PbxPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PbxLogo
        '
        Me.PbxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PbxLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PbxLogo.Image = Global.Manager.My.Resources.Resources.Logo
        Me.PbxLogo.Location = New System.Drawing.Point(1, 10)
        Me.PbxLogo.Name = "PbxLogo"
        Me.PbxLogo.Size = New System.Drawing.Size(276, 132)
        Me.PbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxLogo.TabIndex = 8
        Me.PbxLogo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PbxUser)
        Me.Panel1.Controls.Add(Me.TxtUsername)
        Me.Panel1.Location = New System.Drawing.Point(3, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 32)
        Me.Panel1.TabIndex = 0
        '
        'PbxUser
        '
        Me.PbxUser.BackColor = System.Drawing.Color.Transparent
        Me.PbxUser.Image = Global.Manager.My.Resources.Resources.LoginUser
        Me.PbxUser.Location = New System.Drawing.Point(3, 4)
        Me.PbxUser.Name = "PbxUser"
        Me.PbxUser.Size = New System.Drawing.Size(24, 24)
        Me.PbxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PbxUser.TabIndex = 13
        Me.PbxUser.TabStop = False
        '
        'TxtUsername
        '
        Me.TxtUsername.BackColor = System.Drawing.Color.White
        Me.TxtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUsername.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtUsername.Location = New System.Drawing.Point(31, 6)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(222, 20)
        Me.TxtUsername.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.PbxPassword)
        Me.Panel2.Controls.Add(Me.TxtPassword)
        Me.Panel2.Location = New System.Drawing.Point(3, 68)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(260, 32)
        Me.Panel2.TabIndex = 1
        '
        'PbxPassword
        '
        Me.PbxPassword.BackColor = System.Drawing.Color.Transparent
        Me.PbxPassword.Image = Global.Manager.My.Resources.Resources.LoginPassword
        Me.PbxPassword.Location = New System.Drawing.Point(3, 4)
        Me.PbxPassword.Name = "PbxPassword"
        Me.PbxPassword.Size = New System.Drawing.Size(24, 24)
        Me.PbxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PbxPassword.TabIndex = 13
        Me.PbxPassword.TabStop = False
        '
        'TxtPassword
        '
        Me.TxtPassword.BackColor = System.Drawing.Color.White
        Me.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPassword.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtPassword.Location = New System.Drawing.Point(31, 6)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(222, 20)
        Me.TxtPassword.TabIndex = 0
        Me.TxtPassword.UseSystemPasswordChar = True
        '
        'BtnLogin
        '
        Me.BtnLogin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogin.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.BtnLogin.ForeColor = System.Drawing.Color.White
        Me.BtnLogin.Location = New System.Drawing.Point(3, 125)
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(260, 33)
        Me.BtnLogin.TabIndex = 3
        Me.BtnLogin.Text = "Entrar"
        Me.BtnLogin.TooltipText = ""
        Me.BtnLogin.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.PbxLogo)
        Me.Panel3.Location = New System.Drawing.Point(19, 19)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(10)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(1, 10, 1, 1)
        Me.Panel3.Size = New System.Drawing.Size(278, 391)
        Me.Panel3.TabIndex = 10
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnLogin, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 210)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(267, 171)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 65)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "GERENCIADOR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblVersion
        '
        Me.LblVersion.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.LblVersion.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.LblVersion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblVersion.LinkColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.LblVersion.Location = New System.Drawing.Point(0, 412)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(319, 16)
        Me.LblVersion.TabIndex = 11
        Me.LblVersion.Text = "Versão: x.x"
        Me.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(319, 428)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.Panel3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PbxUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PbxPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PbxLogo As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents BtnLogin As ControlLibrary.NoFocusCueButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents PbxUser As PictureBox
    Friend WithEvents PbxPassword As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents LblVersion As LinkLabel
End Class
