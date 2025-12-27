<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEvent
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
        Me.SfdLogo = New System.Windows.Forms.SaveFileDialog()
        Me.OfdLogo = New System.Windows.Forms.OpenFileDialog()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtEvent = New System.Windows.Forms.TextBox()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 317)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(684, 44)
        Me.PnButtons.TabIndex = 8
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(580, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'SfdLogo
        '
        Me.SfdLogo.Title = "Salvar Logo"
        '
        'OfdLogo
        '
        Me.OfdLogo.Filter = "Imagens (BMP/JPG/PNG)|*.bmp;*.jpg;*.png"
        Me.OfdLogo.Title = "Escolha uma imagem"
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TxtEvent
        '
        Me.TxtEvent.BackColor = System.Drawing.Color.White
        Me.TxtEvent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEvent.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEvent.Location = New System.Drawing.Point(12, 12)
        Me.TxtEvent.Multiline = True
        Me.TxtEvent.Name = "TxtEvent"
        Me.TxtEvent.ReadOnly = True
        Me.TxtEvent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtEvent.Size = New System.Drawing.Size(660, 299)
        Me.TxtEvent.TabIndex = 9
        '
        'FrmEvent
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 361)
        Me.Controls.Add(Me.TxtEvent)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEvent"
        Me.ShowIcon = False
        Me.Text = "Evento"
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents SfdLogo As SaveFileDialog
    Friend WithEvents OfdLogo As OpenFileDialog
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TxtEvent As TextBox
End Class
