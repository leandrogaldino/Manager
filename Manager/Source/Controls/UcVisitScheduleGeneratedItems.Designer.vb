<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcVisitScheduleGeneratedItems
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcVisitScheduleGeneratedItems))
        Me.BtnEvaluation = New System.Windows.Forms.Button()
        Me.BtnSchedule = New System.Windows.Forms.Button()
        Me.TtDescription = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BtnEvaluation
        '
        Me.BtnEvaluation.BackgroundImage = Global.Manager.My.Resources.Resources.Evaluation
        Me.BtnEvaluation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnEvaluation.Location = New System.Drawing.Point(3, 3)
        Me.BtnEvaluation.Name = "BtnEvaluation"
        Me.BtnEvaluation.Size = New System.Drawing.Size(117, 88)
        Me.BtnEvaluation.TabIndex = 0
        Me.BtnEvaluation.Text = "Avaliação"
        Me.BtnEvaluation.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TtDescription.SetToolTip(Me.BtnEvaluation, "Quando uma avaliação gerada pelo técnico é importada para o sistema, você pode vi" &
        "sualizá-la diretamente no agendamento de visita que a originou.")
        Me.BtnEvaluation.UseVisualStyleBackColor = True
        '
        'BtnSchedule
        '
        Me.BtnSchedule.BackgroundImage = Global.Manager.My.Resources.Resources.VisitSchedule
        Me.BtnSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSchedule.Location = New System.Drawing.Point(126, 3)
        Me.BtnSchedule.Name = "BtnSchedule"
        Me.BtnSchedule.Size = New System.Drawing.Size(117, 88)
        Me.BtnSchedule.TabIndex = 0
        Me.BtnSchedule.Text = "Sobrescrito"
        Me.BtnSchedule.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TtDescription.SetToolTip(Me.BtnSchedule, resources.GetString("BtnSchedule.ToolTip"))
        Me.BtnSchedule.UseVisualStyleBackColor = True
        '
        'UcVisitScheduleGeneratedItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.BtnSchedule)
        Me.Controls.Add(Me.BtnEvaluation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcVisitScheduleGeneratedItems"
        Me.Size = New System.Drawing.Size(247, 94)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TtDescription As ToolTip
    Private WithEvents BtnEvaluation As Button
    Private WithEvents BtnSchedule As Button
End Class
