<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSupport
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
        Me.BtnTestAndOK = New System.Windows.Forms.Button()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.TxtSupportSMTPServer = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.TxtSupportEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DbxSupportPort = New CoreSuite.Controls.DecimalBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.CbxEnableSSL = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PnButtons.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnTestAndOK)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 202)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(475, 36)
        Me.PnButtons.TabIndex = 5
        '
        'BtnTestAndOK
        '
        Me.BtnTestAndOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTestAndOK.Enabled = False
        Me.BtnTestAndOK.Location = New System.Drawing.Point(368, 3)
        Me.BtnTestAndOK.Name = "BtnTestAndOK"
        Me.BtnTestAndOK.Size = New System.Drawing.Size(95, 30)
        Me.BtnTestAndOK.TabIndex = 0
        Me.BtnTestAndOK.Text = "OK"
        Me.BtnTestAndOK.UseVisualStyleBackColor = True
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.White
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.TxtSupportSMTPServer)
        Me.Panel18.Controls.Add(Me.Label19)
        Me.Panel18.Location = New System.Drawing.Point(12, 107)
        Me.Panel18.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel18.Size = New System.Drawing.Size(450, 31)
        Me.Panel18.TabIndex = 19
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
        Me.Panel16.Location = New System.Drawing.Point(12, 63)
        Me.Panel16.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel16.Size = New System.Drawing.Size(450, 31)
        Me.Panel16.TabIndex = 18
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
        Me.Panel13.Location = New System.Drawing.Point(12, 151)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel13.Size = New System.Drawing.Size(450, 31)
        Me.Panel13.TabIndex = 20
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
        Me.Panel12.Location = New System.Drawing.Point(12, 19)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel12.Size = New System.Drawing.Size(450, 31)
        Me.Panel12.TabIndex = 17
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
        'FrmSupport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(475, 238)
        Me.Controls.Add(Me.Panel18)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSupport"
        Me.Text = "Suporte"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnTestAndOK As Button
    Friend WithEvents Panel18 As Panel
    Friend WithEvents TxtSupportSMTPServer As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents TxtSupportEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents DbxSupportPort As CoreSuite.Controls.DecimalBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents CbxEnableSSL As CheckBox
    Friend WithEvents Label12 As Label
End Class
