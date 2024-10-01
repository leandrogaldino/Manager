<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserChangePassword
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtOldPassword = New System.Windows.Forms.TextBox()
        Me.LblOldPassword = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtNewPassword = New System.Windows.Forms.TextBox()
        Me.LblNewPassword = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtNewPassword2 = New System.Windows.Forms.TextBox()
        Me.LblNewPassword2 = New System.Windows.Forms.Label()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnChangePassword = New ControlLibrary.NoFocusCueButton()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.TxtOldPassword)
        Me.Panel2.Location = New System.Drawing.Point(15, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(161, 30)
        Me.Panel2.TabIndex = 1
        '
        'TxtOldPassword
        '
        Me.TxtOldPassword.BackColor = System.Drawing.Color.White
        Me.TxtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOldPassword.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TxtOldPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtOldPassword.Location = New System.Drawing.Point(5, 5)
        Me.TxtOldPassword.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TxtOldPassword.Name = "TxtOldPassword"
        Me.TxtOldPassword.Size = New System.Drawing.Size(151, 19)
        Me.TxtOldPassword.TabIndex = 0
        Me.TxtOldPassword.UseSystemPasswordChar = True
        '
        'LblOldPassword
        '
        Me.LblOldPassword.AutoSize = True
        Me.LblOldPassword.ForeColor = System.Drawing.Color.White
        Me.LblOldPassword.Location = New System.Drawing.Point(12, 21)
        Me.LblOldPassword.Margin = New System.Windows.Forms.Padding(3, 12, 3, 0)
        Me.LblOldPassword.Name = "LblOldPassword"
        Me.LblOldPassword.Size = New System.Drawing.Size(148, 17)
        Me.LblOldPassword.TabIndex = 0
        Me.LblOldPassword.Text = "Digite a senha antiga"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TxtNewPassword)
        Me.Panel1.Location = New System.Drawing.Point(15, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(161, 30)
        Me.Panel1.TabIndex = 3
        '
        'TxtNewPassword
        '
        Me.TxtNewPassword.BackColor = System.Drawing.Color.White
        Me.TxtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNewPassword.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TxtNewPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtNewPassword.Location = New System.Drawing.Point(5, 5)
        Me.TxtNewPassword.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TxtNewPassword.Name = "TxtNewPassword"
        Me.TxtNewPassword.Size = New System.Drawing.Size(151, 19)
        Me.TxtNewPassword.TabIndex = 0
        Me.TxtNewPassword.UseSystemPasswordChar = True
        '
        'LblNewPassword
        '
        Me.LblNewPassword.AutoSize = True
        Me.LblNewPassword.ForeColor = System.Drawing.Color.White
        Me.LblNewPassword.Location = New System.Drawing.Point(12, 84)
        Me.LblNewPassword.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.LblNewPassword.Name = "LblNewPassword"
        Me.LblNewPassword.Size = New System.Drawing.Size(139, 17)
        Me.LblNewPassword.TabIndex = 2
        Me.LblNewPassword.Text = "Digite a nova senha"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.TxtNewPassword2)
        Me.Panel3.Location = New System.Drawing.Point(15, 161)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(161, 30)
        Me.Panel3.TabIndex = 5
        '
        'TxtNewPassword2
        '
        Me.TxtNewPassword2.BackColor = System.Drawing.Color.White
        Me.TxtNewPassword2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNewPassword2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TxtNewPassword2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtNewPassword2.Location = New System.Drawing.Point(5, 5)
        Me.TxtNewPassword2.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TxtNewPassword2.Name = "TxtNewPassword2"
        Me.TxtNewPassword2.Size = New System.Drawing.Size(151, 19)
        Me.TxtNewPassword2.TabIndex = 0
        Me.TxtNewPassword2.UseSystemPasswordChar = True
        '
        'LblNewPassword2
        '
        Me.LblNewPassword2.AutoSize = True
        Me.LblNewPassword2.ForeColor = System.Drawing.Color.White
        Me.LblNewPassword2.Location = New System.Drawing.Point(12, 141)
        Me.LblNewPassword2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.LblNewPassword2.Name = "LblNewPassword2"
        Me.LblNewPassword2.Size = New System.Drawing.Size(161, 17)
        Me.LblNewPassword2.TabIndex = 4
        Me.LblNewPassword2.Text = "Confirme a nova senha"
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'BtnChangePassword
        '
        Me.BtnChangePassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnChangePassword.Enabled = False
        Me.BtnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.BtnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChangePassword.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChangePassword.ForeColor = System.Drawing.Color.White
        Me.BtnChangePassword.Location = New System.Drawing.Point(15, 208)
        Me.BtnChangePassword.Name = "BtnChangePassword"
        Me.BtnChangePassword.Size = New System.Drawing.Size(161, 35)
        Me.BtnChangePassword.TabIndex = 6
        Me.BtnChangePassword.Text = "Alterar Senha"
        Me.BtnChangePassword.TooltipText = ""
        Me.BtnChangePassword.UseVisualStyleBackColor = False
        '
        'FrmUserChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(188, 258)
        Me.Controls.Add(Me.LblNewPassword2)
        Me.Controls.Add(Me.LblNewPassword)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.LblOldPassword)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnChangePassword)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUserChangePassword"
        Me.ShowIcon = False
        Me.Text = "Alteração de Senha"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnChangePassword As ControlLibrary.NoFocusCueButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtOldPassword As TextBox
    Friend WithEvents LblOldPassword As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtNewPassword As TextBox
    Friend WithEvents LblNewPassword As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TxtNewPassword2 As TextBox
    Friend WithEvents LblNewPassword2 As Label
    Friend WithEvents EprValidation As ErrorProvider
End Class
