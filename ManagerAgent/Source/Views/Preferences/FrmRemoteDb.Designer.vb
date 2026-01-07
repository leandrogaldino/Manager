<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRemoteDb
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TxtApiKey = New System.Windows.Forms.TextBox()
        Me.LblApiKey = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtProjectID = New System.Windows.Forms.TextBox()
        Me.LblProjectID = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtBucketName = New System.Windows.Forms.TextBox()
        Me.LblBucketName = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.LblUsername = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.LblPassword = New System.Windows.Forms.Label()
        Me.PnButtons.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 238)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(475, 36)
        Me.PnButtons.TabIndex = 5
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(368, 3)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.White
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.TxtApiKey)
        Me.Panel21.Controls.Add(Me.LblApiKey)
        Me.Panel21.Location = New System.Drawing.Point(12, 19)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel21.Size = New System.Drawing.Size(450, 31)
        Me.Panel21.TabIndex = 0
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtProjectID)
        Me.Panel1.Controls.Add(Me.LblProjectID)
        Me.Panel1.Location = New System.Drawing.Point(12, 63)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(450, 31)
        Me.Panel1.TabIndex = 1
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtBucketName)
        Me.Panel2.Controls.Add(Me.LblBucketName)
        Me.Panel2.Location = New System.Drawing.Point(12, 107)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(450, 31)
        Me.Panel2.TabIndex = 2
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TxtUsername)
        Me.Panel3.Controls.Add(Me.LblUsername)
        Me.Panel3.Location = New System.Drawing.Point(12, 151)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(450, 31)
        Me.Panel3.TabIndex = 3
        '
        'TxtUsername
        '
        Me.TxtUsername.Location = New System.Drawing.Point(131, 3)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(314, 23)
        Me.TxtUsername.TabIndex = 1
        Me.TxtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblUsername
        '
        Me.LblUsername.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblUsername.Location = New System.Drawing.Point(4, 0)
        Me.LblUsername.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblUsername.Name = "LblUsername"
        Me.LblUsername.Size = New System.Drawing.Size(120, 29)
        Me.LblUsername.TabIndex = 0
        Me.LblUsername.Text = "Usuário"
        Me.LblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TxtPassword)
        Me.Panel4.Controls.Add(Me.LblPassword)
        Me.Panel4.Location = New System.Drawing.Point(12, 195)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(450, 31)
        Me.Panel4.TabIndex = 4
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(131, 3)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(314, 23)
        Me.TxtPassword.TabIndex = 1
        Me.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPassword
        '
        Me.LblPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblPassword.Location = New System.Drawing.Point(4, 0)
        Me.LblPassword.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblPassword.Name = "LblPassword"
        Me.LblPassword.Size = New System.Drawing.Size(120, 29)
        Me.LblPassword.TabIndex = 0
        Me.LblPassword.Text = "Senha"
        Me.LblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmRemoteDb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(475, 274)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel21)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRemoteDb"
        Me.Text = "Banco de Dados Remoto"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TxtApiKey As TextBox
    Friend WithEvents LblApiKey As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtProjectID As TextBox
    Friend WithEvents LblProjectID As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtBucketName As TextBox
    Friend WithEvents LblBucketName As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents LblUsername As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents LblPassword As Label
End Class
