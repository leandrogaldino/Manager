<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReleaseSettings
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
        Me.components = New System.ComponentModel.Container()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.LblReleaseRegister = New System.Windows.Forms.Label()
        Me.TbrReleaseRegister = New System.Windows.Forms.TrackBar()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel25.SuspendLayout()
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 92)
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
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.White
        Me.Panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel25.Controls.Add(Me.LblReleaseRegister)
        Me.Panel25.Controls.Add(Me.TbrReleaseRegister)
        Me.Panel25.Location = New System.Drawing.Point(12, 19)
        Me.Panel25.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel25.Size = New System.Drawing.Size(450, 62)
        Me.Panel25.TabIndex = 11
        '
        'LblReleaseRegister
        '
        Me.LblReleaseRegister.Location = New System.Drawing.Point(1, 1)
        Me.LblReleaseRegister.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblReleaseRegister.Name = "LblReleaseRegister"
        Me.LblReleaseRegister.Size = New System.Drawing.Size(414, 26)
        Me.LblReleaseRegister.TabIndex = 3
        Me.LblReleaseRegister.Text = "Liberar registros não atualizados a mais de 2 minutos"
        Me.LblReleaseRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrReleaseRegister
        '
        Me.TbrReleaseRegister.AutoSize = False
        Me.TbrReleaseRegister.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrReleaseRegister.Location = New System.Drawing.Point(4, 29)
        Me.TbrReleaseRegister.Maximum = 60
        Me.TbrReleaseRegister.Minimum = 2
        Me.TbrReleaseRegister.Name = "TbrReleaseRegister"
        Me.TbrReleaseRegister.Size = New System.Drawing.Size(444, 31)
        Me.TbrReleaseRegister.TabIndex = 2
        Me.TbrReleaseRegister.Value = 2
        '
        'FrmReleaseSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 136)
        Me.Controls.Add(Me.Panel25)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmReleaseSettings"
        Me.ShowIcon = False
        Me.Text = "Liberação de Registros"
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel25.ResumeLayout(False)
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents Panel25 As Panel
    Friend WithEvents LblReleaseRegister As Label
    Friend WithEvents TbrReleaseRegister As TrackBar
End Class
