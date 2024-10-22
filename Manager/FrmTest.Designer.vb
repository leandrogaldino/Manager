<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTest
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
        Me.UcEvaluationSourceTile1 = New Manager.UcEvaluationSourceTile()
        Me.SuspendLayout()
        '
        'UcEvaluationSourceTile1
        '
        Me.UcEvaluationSourceTile1.IsHeader = True
        Me.UcEvaluationSourceTile1.IsLost = True
        Me.UcEvaluationSourceTile1.Item1 = "1500"
        Me.UcEvaluationSourceTile1.Item2 = "1550"
        Me.UcEvaluationSourceTile1.Location = New System.Drawing.Point(251, 210)
        Me.UcEvaluationSourceTile1.Margin = New System.Windows.Forms.Padding(0)
        Me.UcEvaluationSourceTile1.Name = "UcEvaluationSourceTile1"
        Me.UcEvaluationSourceTile1.Size = New System.Drawing.Size(450, 48)
        Me.UcEvaluationSourceTile1.TabIndex = 0
        Me.UcEvaluationSourceTile1.Title = "Filtro de ar"
        '
        'FrmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 616)
        Me.Controls.Add(Me.UcEvaluationSourceTile1)
        Me.Name = "FrmTest"
        Me.Text = "Test"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcEvaluationSourceTile1 As UcEvaluationSourceTile
End Class
