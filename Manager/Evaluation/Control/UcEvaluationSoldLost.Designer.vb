<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcEvaluationSoldLost
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
        Me.CbxSold = New System.Windows.Forms.CheckBox()
        Me.CbxLost = New System.Windows.Forms.CheckBox()
        Me.CbxNA = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CbxSold
        '
        Me.CbxSold.AutoSize = True
        Me.CbxSold.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxSold.Location = New System.Drawing.Point(3, 16)
        Me.CbxSold.Name = "CbxSold"
        Me.CbxSold.Size = New System.Drawing.Size(72, 20)
        Me.CbxSold.TabIndex = 0
        Me.CbxSold.Text = "Vendido"
        Me.CbxSold.UseVisualStyleBackColor = True
        '
        'CbxLost
        '
        Me.CbxLost.AutoSize = True
        Me.CbxLost.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxLost.Location = New System.Drawing.Point(91, 16)
        Me.CbxLost.Name = "CbxLost"
        Me.CbxLost.Size = New System.Drawing.Size(68, 20)
        Me.CbxLost.TabIndex = 0
        Me.CbxLost.Text = "Perdido"
        Me.CbxLost.UseVisualStyleBackColor = True
        '
        'CbxNA
        '
        Me.CbxNA.AutoSize = True
        Me.CbxNA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxNA.Location = New System.Drawing.Point(174, 16)
        Me.CbxNA.Name = "CbxNA"
        Me.CbxNA.Size = New System.Drawing.Size(46, 20)
        Me.CbxNA.TabIndex = 1
        Me.CbxNA.Text = "N/A"
        Me.CbxNA.UseVisualStyleBackColor = True
        '
        'UcEvaluationSoldLost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CbxNA)
        Me.Controls.Add(Me.CbxLost)
        Me.Controls.Add(Me.CbxSold)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcEvaluationSoldLost"
        Me.Size = New System.Drawing.Size(229, 50)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents CbxSold As CheckBox
    Private WithEvents CbxLost As CheckBox
    Private WithEvents CbxNA As CheckBox
End Class
