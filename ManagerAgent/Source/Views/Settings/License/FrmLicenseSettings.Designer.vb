<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLicenseSettings
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
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.TxtCredentials = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel17.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.PnButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.White
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.TxtCredentials)
        Me.Panel17.Controls.Add(Me.Label11)
        Me.Panel17.Location = New System.Drawing.Point(12, 59)
        Me.Panel17.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel17.Size = New System.Drawing.Size(450, 155)
        Me.Panel17.TabIndex = 7
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
        Me.Panel21.Controls.Add(Me.TxtName)
        Me.Panel21.Controls.Add(Me.Label13)
        Me.Panel21.Location = New System.Drawing.Point(12, 19)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel21.Size = New System.Drawing.Size(450, 31)
        Me.Panel21.TabIndex = 6
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(131, 3)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(314, 23)
        Me.TxtName.TabIndex = 1
        Me.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 227)
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
        'FrmLicenseSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 271)
        Me.Controls.Add(Me.PnButtons)
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.Panel21)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmLicenseSettings"
        Me.ShowIcon = False
        Me.Text = "Licença"
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.PnButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel17 As Panel
    Friend WithEvents TxtCredentials As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
End Class
