<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLicenseCredentials
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.TxtCredentials = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PnCredential = New System.Windows.Forms.Panel()
        Me.PbxLoading = New System.Windows.Forms.PictureBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.PnButtons.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.PnCredential.SuspendLayout()
        CType(Me.PbxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnOK)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 255)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(475, 36)
        Me.PnButtons.TabIndex = 10
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Enabled = False
        Me.BtnOK.Location = New System.Drawing.Point(368, 3)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(95, 30)
        Me.BtnOK.TabIndex = 0
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
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
        Me.Panel17.TabIndex = 12
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
        Me.Panel21.TabIndex = 11
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
        'PnCredential
        '
        Me.PnCredential.Controls.Add(Me.PbxLoading)
        Me.PnCredential.Controls.Add(Me.LblStatus)
        Me.PnCredential.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnCredential.Location = New System.Drawing.Point(0, 223)
        Me.PnCredential.Margin = New System.Windows.Forms.Padding(0)
        Me.PnCredential.Name = "PnCredential"
        Me.PnCredential.Size = New System.Drawing.Size(475, 32)
        Me.PnCredential.TabIndex = 13
        '
        'PbxLoading
        '
        Me.PbxLoading.Image = Global.ManagerAgent.My.Resources.Resources.LoadingKey
        Me.PbxLoading.Location = New System.Drawing.Point(12, 5)
        Me.PbxLoading.Name = "PbxLoading"
        Me.PbxLoading.Size = New System.Drawing.Size(22, 22)
        Me.PbxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxLoading.TabIndex = 15
        Me.PbxLoading.TabStop = False
        '
        'LblStatus
        '
        Me.LblStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Location = New System.Drawing.Point(43, 5)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(419, 24)
        Me.LblStatus.TabIndex = 12
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmLicenseCredentials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(475, 291)
        Me.Controls.Add(Me.PnCredential)
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.Panel21)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLicenseCredentials"
        Me.Text = "Credenciais da Licença"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.PnCredential.ResumeLayout(False)
        CType(Me.PbxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnOK As Button
    Friend WithEvents Panel17 As Panel
    Friend WithEvents TxtCredentials As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PnCredential As Panel
    Friend WithEvents LblStatus As Label
    Friend WithEvents PbxLoading As PictureBox
End Class
