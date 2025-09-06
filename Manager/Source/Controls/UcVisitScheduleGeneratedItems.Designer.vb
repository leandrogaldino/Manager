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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcVisitScheduleGeneratedItems))
        Me.BtnEvaluation = New System.Windows.Forms.Button()
        Me.BtnSchedule = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Separator1 = New ControlLibrary.Separator()
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
        Me.BtnEvaluation.UseVisualStyleBackColor = True
        '
        'BtnSchedule
        '
        Me.BtnSchedule.BackgroundImage = Global.Manager.My.Resources.Resources.VisitSchedule
        Me.BtnSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSchedule.Location = New System.Drawing.Point(3, 115)
        Me.BtnSchedule.Name = "BtnSchedule"
        Me.BtnSchedule.Size = New System.Drawing.Size(117, 88)
        Me.BtnSchedule.TabIndex = 0
        Me.BtnSchedule.Text = "Sobrescrito"
        Me.BtnSchedule.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSchedule.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(126, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 88)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Quando uma avaliação gerada pelo técnico é importada para o sistema, você pode vi" &
    "sualizá-la diretamente no agendamento de visita que a originou."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(320, 88)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Separator1
        '
        Me.Separator1.Location = New System.Drawing.Point(3, 94)
        Me.Separator1.Margin = New System.Windows.Forms.Padding(0)
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Size = New System.Drawing.Size(443, 18)
        Me.Separator1.TabIndex = 2
        Me.Separator1.Text = "Separator1"
        '
        'UcVisitScheduleGeneratedItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Separator1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnSchedule)
        Me.Controls.Add(Me.BtnEvaluation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcVisitScheduleGeneratedItems"
        Me.Size = New System.Drawing.Size(449, 206)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents BtnEvaluation As Button
    Private WithEvents BtnSchedule As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Separator1 As ControlLibrary.Separator
End Class
