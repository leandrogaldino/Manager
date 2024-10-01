<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatabaseSettings
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
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtDatabaseServer = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtDatabaseName = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDatabasePassword = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtDatabaseUsername = New System.Windows.Forms.TextBox()
        Me.PnButtons.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 192)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(474, 44)
        Me.PnButtons.TabIndex = 8
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(370, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(269, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.Label17)
        Me.Panel11.Controls.Add(Me.TxtDatabaseServer)
        Me.Panel11.Location = New System.Drawing.Point(12, 19)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel11.Size = New System.Drawing.Size(450, 31)
        Me.Panel11.TabIndex = 16
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
        Me.Panel10.Location = New System.Drawing.Point(12, 63)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel10.Size = New System.Drawing.Size(450, 31)
        Me.Panel10.TabIndex = 17
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
        Me.Panel9.Location = New System.Drawing.Point(12, 151)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel9.Size = New System.Drawing.Size(450, 31)
        Me.Panel9.TabIndex = 19
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.TxtDatabaseUsername)
        Me.Panel3.Location = New System.Drawing.Point(12, 107)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(450, 31)
        Me.Panel3.TabIndex = 18
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
        'FrmDatabaseSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 236)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmDatabaseSettings"
        Me.ShowIcon = False
        Me.Text = "Licença"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents TxtDatabaseServer As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtDatabaseName As TextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtDatabasePassword As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtDatabaseUsername As TextBox
End Class
