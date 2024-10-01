<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSuportSettings
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.TxtSupportSMTPServer = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.TxtSupportEmail = New System.Windows.Forms.TextBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DbxSupportPort = New ControlLibrary.DecimalBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.CbxEnableSSL = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel18.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 191)
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
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
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
        Me.Panel18.TabIndex = 11
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
        Me.Panel16.Controls.Add(Me.LblEmail)
        Me.Panel16.Location = New System.Drawing.Point(12, 63)
        Me.Panel16.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel16.Size = New System.Drawing.Size(450, 31)
        Me.Panel16.TabIndex = 10
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
        'LblEmail
        '
        Me.LblEmail.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEmail.Location = New System.Drawing.Point(4, 0)
        Me.LblEmail.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(120, 29)
        Me.LblEmail.TabIndex = 0
        Me.LblEmail.Text = "E-Mail"
        Me.LblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Panel13.TabIndex = 12
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
        Me.Panel12.TabIndex = 9
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
        'FrmSuportSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 235)
        Me.Controls.Add(Me.Panel18)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSuportSettings"
        Me.ShowIcon = False
        Me.Text = "Suporte"
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents Panel18 As Panel
    Friend WithEvents TxtSupportSMTPServer As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents TxtSupportEmail As TextBox
    Friend WithEvents LblEmail As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents DbxSupportPort As ControlLibrary.DecimalBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents CbxEnableSSL As CheckBox
End Class
