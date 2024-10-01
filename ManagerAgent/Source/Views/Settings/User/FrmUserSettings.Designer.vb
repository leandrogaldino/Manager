<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserSettings
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
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.TxtUserDefaultPassword = New System.Windows.Forms.TextBox()
        Me.LblUserDefaultPassword = New System.Windows.Forms.Label()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PnButtons.SuspendLayout()
        Me.Panel19.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 52)
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
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel19.Controls.Add(Me.TxtUserDefaultPassword)
        Me.Panel19.Controls.Add(Me.LblUserDefaultPassword)
        Me.Panel19.Location = New System.Drawing.Point(12, 10)
        Me.Panel19.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel19.Size = New System.Drawing.Size(450, 31)
        Me.Panel19.TabIndex = 9
        '
        'TxtUserDefaultPassword
        '
        Me.TxtUserDefaultPassword.Location = New System.Drawing.Point(131, 3)
        Me.TxtUserDefaultPassword.Name = "TxtUserDefaultPassword"
        Me.TxtUserDefaultPassword.Size = New System.Drawing.Size(314, 23)
        Me.TxtUserDefaultPassword.TabIndex = 1
        Me.TxtUserDefaultPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblUserDefaultPassword
        '
        Me.LblUserDefaultPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblUserDefaultPassword.Location = New System.Drawing.Point(4, 0)
        Me.LblUserDefaultPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUserDefaultPassword.Name = "LblUserDefaultPassword"
        Me.LblUserDefaultPassword.Size = New System.Drawing.Size(120, 29)
        Me.LblUserDefaultPassword.TabIndex = 0
        Me.LblUserDefaultPassword.Text = "Senha padrão"
        Me.LblUserDefaultPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'FrmUserSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 96)
        Me.Controls.Add(Me.Panel19)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmUserSettings"
        Me.ShowIcon = False
        Me.Text = "Usuário"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel19 As Panel
    Friend WithEvents TxtUserDefaultPassword As TextBox
    Friend WithEvents LblUserDefaultPassword As Label
    Friend WithEvents EprValidation As ErrorProvider
End Class
