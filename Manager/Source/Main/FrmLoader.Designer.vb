<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLoader
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
        Me.AnimatedBox = New CoreSuite.Controls.AnimatedBox()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AnimatedBox
        '
        Me.AnimatedBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimatedBox.Location = New System.Drawing.Point(0, 0)
        Me.AnimatedBox.Name = "AnimatedBox"
        Me.AnimatedBox.ScaleMode = CoreSuite.Controls.AnimationScaleMode.Centrer
        Me.AnimatedBox.Size = New System.Drawing.Size(353, 139)
        Me.AnimatedBox.TabIndex = 0
        '
        'LblMessage
        '
        Me.LblMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblMessage.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.Location = New System.Drawing.Point(0, 139)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(353, 52)
        Me.LblMessage.TabIndex = 1
        Me.LblMessage.Text = "Mensagem"
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmLoader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(353, 191)
        Me.Controls.Add(Me.AnimatedBox)
        Me.Controls.Add(Me.LblMessage)
        Me.Name = "FrmLoader"
        Me.Text = "FrmLoader"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AnimatedBox As CoreSuite.Controls.AnimatedBox
    Friend WithEvents LblMessage As Label
End Class
