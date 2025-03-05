<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcEvaluationNeedProposal
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
        Me.RbtYes = New System.Windows.Forms.RadioButton()
        Me.RbtNo = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'RbtYes
        '
        Me.RbtYes.AutoSize = True
        Me.RbtYes.Location = New System.Drawing.Point(3, 3)
        Me.RbtYes.Name = "RbtYes"
        Me.RbtYes.Padding = New System.Windows.Forms.Padding(10)
        Me.RbtYes.Size = New System.Drawing.Size(68, 41)
        Me.RbtYes.TabIndex = 0
        Me.RbtYes.TabStop = True
        Me.RbtYes.Text = "Sim"
        Me.RbtYes.UseVisualStyleBackColor = True
        '
        'RbtNo
        '
        Me.RbtNo.AutoSize = True
        Me.RbtNo.Location = New System.Drawing.Point(77, 3)
        Me.RbtNo.Name = "RbtNo"
        Me.RbtNo.Padding = New System.Windows.Forms.Padding(10)
        Me.RbtNo.Size = New System.Drawing.Size(74, 41)
        Me.RbtNo.TabIndex = 0
        Me.RbtNo.TabStop = True
        Me.RbtNo.Text = "Não"
        Me.RbtNo.UseVisualStyleBackColor = True
        '
        'EvaluationNeedProposal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.RbtNo)
        Me.Controls.Add(Me.RbtYes)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "EvaluationNeedProposal"
        Me.Size = New System.Drawing.Size(157, 47)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents RbtYes As RadioButton
    Private WithEvents RbtNo As RadioButton

End Class
