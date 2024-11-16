<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvaluationRejectReason
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblReason = New System.Windows.Forms.Label()
        Me.TxtReason = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 44)
        Me.Panel1.TabIndex = 2
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(254, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(153, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'LblReason
        '
        Me.LblReason.AutoSize = True
        Me.LblReason.Location = New System.Drawing.Point(9, 9)
        Me.LblReason.Name = "LblReason"
        Me.LblReason.Size = New System.Drawing.Size(135, 17)
        Me.LblReason.TabIndex = 0
        Me.LblReason.Text = "Motivo da Rejeição"
        '
        'TxtReason
        '
        Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReason.Location = New System.Drawing.Point(12, 29)
        Me.TxtReason.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtReason.MaxLength = 100
        Me.TxtReason.Multiline = True
        Me.TxtReason.Name = "TxtReason"
        Me.TxtReason.Size = New System.Drawing.Size(334, 115)
        Me.TxtReason.TabIndex = 1
        '
        'FrmEvaluationRejectReason
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(358, 197)
        Me.Controls.Add(Me.TxtReason)
        Me.Controls.Add(Me.LblReason)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluationRejectReason"
        Me.ShowIcon = False
        Me.Text = "Rejeitar Avaliação"
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TxtReason As TextBox
    Friend WithEvents LblReason As Label
End Class
