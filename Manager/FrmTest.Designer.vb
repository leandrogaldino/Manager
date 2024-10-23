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
        Me.UcEvaluationSourceItem1 = New Manager.UcEvaluationSourceItem()
        Me.SuspendLayout()
        '
        'UcEvaluationSourceItem1
        '
        Me.UcEvaluationSourceItem1.Item1 = "1500"
        Me.UcEvaluationSourceItem1.Item2 = "1550"
        Me.UcEvaluationSourceItem1.Location = New System.Drawing.Point(194, 128)
        Me.UcEvaluationSourceItem1.Margin = New System.Windows.Forms.Padding(0)
        Me.UcEvaluationSourceItem1.Name = "UcEvaluationSourceItem1"
        Me.UcEvaluationSourceItem1.Size = New System.Drawing.Size(450, 48)
        Me.UcEvaluationSourceItem1.TabIndex = 0
        Me.UcEvaluationSourceItem1.Title = "Filtro de ar"
        '
        'FrmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 616)
        Me.Controls.Add(Me.UcEvaluationSourceItem1)
        Me.Name = "FrmTest"
        Me.Text = "Test"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcEvaluationSourceItem1 As UcEvaluationSourceItem
End Class
