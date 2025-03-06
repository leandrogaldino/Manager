<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcCallType
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RbtGathering = New System.Windows.Forms.RadioButton()
        Me.RbtPreventive = New System.Windows.Forms.RadioButton()
        Me.RbtCalled = New System.Windows.Forms.RadioButton()
        Me.RbtContract = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'RbtGathering
        '
        Me.RbtGathering.AutoSize = True
        Me.RbtGathering.Location = New System.Drawing.Point(3, 3)
        Me.RbtGathering.Name = "RbtGathering"
        Me.RbtGathering.Padding = New System.Windows.Forms.Padding(10)
        Me.RbtGathering.Size = New System.Drawing.Size(142, 41)
        Me.RbtGathering.TabIndex = 0
        Me.RbtGathering.Text = "Levantamento"
        Me.RbtGathering.UseVisualStyleBackColor = True
        '
        'RbtPreventive
        '
        Me.RbtPreventive.AutoSize = True
        Me.RbtPreventive.Location = New System.Drawing.Point(151, 3)
        Me.RbtPreventive.Name = "RbtPreventive"
        Me.RbtPreventive.Padding = New System.Windows.Forms.Padding(10)
        Me.RbtPreventive.Size = New System.Drawing.Size(115, 41)
        Me.RbtPreventive.TabIndex = 0
        Me.RbtPreventive.Text = "Preventiva"
        Me.RbtPreventive.UseVisualStyleBackColor = True
        '
        'RbtCalled
        '
        Me.RbtCalled.AutoSize = True
        Me.RbtCalled.Location = New System.Drawing.Point(3, 50)
        Me.RbtCalled.Name = "RbtCalled"
        Me.RbtCalled.Padding = New System.Windows.Forms.Padding(10)
        Me.RbtCalled.Size = New System.Drawing.Size(114, 41)
        Me.RbtCalled.TabIndex = 0
        Me.RbtCalled.Text = "Chamado"
        Me.RbtCalled.UseVisualStyleBackColor = True
        '
        'RbtContract
        '
        Me.RbtContract.AutoSize = True
        Me.RbtContract.Location = New System.Drawing.Point(151, 50)
        Me.RbtContract.Name = "RbtContract"
        Me.RbtContract.Padding = New System.Windows.Forms.Padding(10)
        Me.RbtContract.Size = New System.Drawing.Size(106, 41)
        Me.RbtContract.TabIndex = 0
        Me.RbtContract.Text = "Contrato"
        Me.RbtContract.UseVisualStyleBackColor = True
        '
        'UcCallType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.RbtContract)
        Me.Controls.Add(Me.RbtCalled)
        Me.Controls.Add(Me.RbtPreventive)
        Me.Controls.Add(Me.RbtGathering)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcCallType"
        Me.Size = New System.Drawing.Size(270, 96)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents RbtGathering As RadioButton
    Private WithEvents RbtPreventive As RadioButton
    Private WithEvents RbtCalled As RadioButton
    Private WithEvents RbtContract As RadioButton
End Class
