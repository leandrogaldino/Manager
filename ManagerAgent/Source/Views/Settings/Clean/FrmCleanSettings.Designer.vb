<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCleanSettings
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
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.LblInterval = New System.Windows.Forms.Label()
        Me.TbrInterval = New System.Windows.Forms.TrackBar()
        Me.PnButtons.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.TbrInterval, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BtnClose.Location = New System.Drawing.Point(360, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(259, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.White
        Me.Panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel24.Controls.Add(Me.LblInterval)
        Me.Panel24.Controls.Add(Me.TbrInterval)
        Me.Panel24.Location = New System.Drawing.Point(12, 19)
        Me.Panel24.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel24.Size = New System.Drawing.Size(450, 62)
        Me.Panel24.TabIndex = 12
        '
        'LblInterval
        '
        Me.LblInterval.Location = New System.Drawing.Point(1, -1)
        Me.LblInterval.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblInterval.Name = "LblInterval"
        Me.LblInterval.Size = New System.Drawing.Size(414, 26)
        Me.LblInterval.TabIndex = 3
        Me.LblInterval.Text = "Executar a limpeza a cada 1 dia"
        Me.LblInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrInterval
        '
        Me.TbrInterval.AutoSize = False
        Me.TbrInterval.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrInterval.Location = New System.Drawing.Point(4, 29)
        Me.TbrInterval.Maximum = 60
        Me.TbrInterval.Minimum = 1
        Me.TbrInterval.Name = "TbrInterval"
        Me.TbrInterval.Size = New System.Drawing.Size(444, 31)
        Me.TbrInterval.TabIndex = 2
        Me.TbrInterval.Value = 2
        '
        'FrmCleanSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 136)
        Me.Controls.Add(Me.Panel24)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCleanSettings"
        Me.ShowIcon = False
        Me.Text = "Limpeza"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        CType(Me.TbrInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel24 As Panel
    Friend WithEvents LblInterval As Label
    Friend WithEvents TbrInterval As TrackBar
End Class
