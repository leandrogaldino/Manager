<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcEvaluationType
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
        Me.RbtExecution = New System.Windows.Forms.RadioButton()
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
        Me.RbtGathering.TabStop = True
        Me.RbtGathering.Text = "Levantamento"
        Me.RbtGathering.UseVisualStyleBackColor = True
        '
        'RbtExecution
        '
        Me.RbtExecution.AutoSize = True
        Me.RbtExecution.Location = New System.Drawing.Point(151, 3)
        Me.RbtExecution.Name = "RbtExecution"
        Me.RbtExecution.Padding = New System.Windows.Forms.Padding(10)
        Me.RbtExecution.Size = New System.Drawing.Size(109, 41)
        Me.RbtExecution.TabIndex = 0
        Me.RbtExecution.TabStop = True
        Me.RbtExecution.Text = "Execução"
        Me.RbtExecution.UseVisualStyleBackColor = True
        '
        'UcEvaluationType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.RbtExecution)
        Me.Controls.Add(Me.RbtGathering)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcEvaluationType"
        Me.Size = New System.Drawing.Size(264, 47)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents RbtGathering As RadioButton
    Private WithEvents RbtExecution As RadioButton
End Class
