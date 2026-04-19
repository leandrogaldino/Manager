<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLocalDbCredentials
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
        Me.PnLeft = New System.Windows.Forms.Panel()
        Me.LblDescription = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.LblPassword = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.LblUsername = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TxtServer = New System.Windows.Forms.TextBox()
        Me.LblServer = New System.Windows.Forms.Label()
        Me.BtnSave = New CoreSuite.Controls.NoFocusCueButton()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.PnLeft.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.PnButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnLeft
        '
        Me.PnLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.PnLeft.Controls.Add(Me.LblDescription)
        Me.PnLeft.Controls.Add(Me.LblTitle)
        Me.PnLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnLeft.Location = New System.Drawing.Point(0, 0)
        Me.PnLeft.Name = "PnLeft"
        Me.PnLeft.Size = New System.Drawing.Size(165, 183)
        Me.PnLeft.TabIndex = 10
        '
        'LblDescription
        '
        Me.LblDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblDescription.Location = New System.Drawing.Point(0, 41)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Padding = New System.Windows.Forms.Padding(5, 15, 5, 15)
        Me.LblDescription.Size = New System.Drawing.Size(165, 142)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Informe aqui as credenciais de acesso à base de dados local do sistema."
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(165, 41)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Base de Dados Local"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TxtPassword)
        Me.Panel4.Controls.Add(Me.LblPassword)
        Me.Panel4.Location = New System.Drawing.Point(171, 142)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(450, 31)
        Me.Panel4.TabIndex = 15
        '
        'TxtPassword
        '
        Me.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtPassword.Location = New System.Drawing.Point(131, 3)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(314, 23)
        Me.TxtPassword.TabIndex = 1
        Me.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPassword
        '
        Me.LblPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblPassword.Location = New System.Drawing.Point(4, 0)
        Me.LblPassword.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblPassword.Name = "LblPassword"
        Me.LblPassword.Size = New System.Drawing.Size(120, 29)
        Me.LblPassword.TabIndex = 0
        Me.LblPassword.Text = "Senha"
        Me.LblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtUsername)
        Me.Panel2.Controls.Add(Me.LblUsername)
        Me.Panel2.Location = New System.Drawing.Point(171, 98)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(450, 31)
        Me.Panel2.TabIndex = 13
        '
        'TxtUsername
        '
        Me.TxtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtUsername.Location = New System.Drawing.Point(131, 3)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(314, 23)
        Me.TxtUsername.TabIndex = 1
        Me.TxtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblUsername
        '
        Me.LblUsername.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblUsername.Location = New System.Drawing.Point(4, 0)
        Me.LblUsername.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblUsername.Name = "LblUsername"
        Me.LblUsername.Size = New System.Drawing.Size(120, 29)
        Me.LblUsername.TabIndex = 0
        Me.LblUsername.Text = "Usuário"
        Me.LblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtName)
        Me.Panel1.Controls.Add(Me.LblName)
        Me.Panel1.Location = New System.Drawing.Point(171, 54)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(450, 31)
        Me.Panel1.TabIndex = 12
        '
        'TxtName
        '
        Me.TxtName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtName.Location = New System.Drawing.Point(131, 3)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(314, 23)
        Me.TxtName.TabIndex = 1
        Me.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblName
        '
        Me.LblName.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblName.Location = New System.Drawing.Point(4, 0)
        Me.LblName.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(120, 29)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Nome"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.White
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.TxtServer)
        Me.Panel21.Controls.Add(Me.LblServer)
        Me.Panel21.Location = New System.Drawing.Point(171, 10)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel21.Size = New System.Drawing.Size(450, 31)
        Me.Panel21.TabIndex = 11
        '
        'TxtServer
        '
        Me.TxtServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtServer.Location = New System.Drawing.Point(131, 3)
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(314, 23)
        Me.TxtServer.TabIndex = 1
        Me.TxtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblServer
        '
        Me.LblServer.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblServer.Location = New System.Drawing.Point(4, 0)
        Me.LblServer.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblServer.Name = "LblServer"
        Me.LblServer.Size = New System.Drawing.Size(120, 29)
        Me.LblServer.TabIndex = 0
        Me.LblServer.Text = "Servidor"
        Me.LblServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnSave.Location = New System.Drawing.Point(527, 9)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 32)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Validar"
        Me.BtnSave.TooltipText = ""
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 183)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(629, 48)
        Me.PnButtons.TabIndex = 16
        '
        'FrmLocalDbCredentials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(629, 231)
        Me.Controls.Add(Me.PnLeft)
        Me.Controls.Add(Me.PnButtons)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel21)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLocalDbCredentials"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Credenciais da Base de Dados Local"
        Me.PnLeft.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.PnButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnLeft As Panel
    Friend WithEvents LblDescription As Label
    Friend WithEvents LblTitle As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents LblPassword As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents LblUsername As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TxtServer As TextBox
    Friend WithEvents LblServer As Label
    Friend WithEvents BtnSave As CoreSuite.Controls.NoFocusCueButton
    Friend WithEvents PnButtons As Panel
End Class
