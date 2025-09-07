<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcEvaluationUnitTemperaturePressure
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblUnit = New System.Windows.Forms.Label()
        Me.TxtUnit = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblTemperature = New System.Windows.Forms.Label()
        Me.DbxTemperature = New ControlLibrary.DecimalBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblPressure = New System.Windows.Forms.Label()
        Me.DbxPressure = New ControlLibrary.DecimalBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblUnit)
        Me.Panel1.Controls.Add(Me.TxtUnit)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(374, 39)
        Me.Panel1.TabIndex = 0
        '
        'LblUnit
        '
        Me.LblUnit.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblUnit.Location = New System.Drawing.Point(0, 0)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(238, 37)
        Me.LblUnit.TabIndex = 1
        Me.LblUnit.Text = "Unidade Compressora:"
        Me.LblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtUnit
        '
        Me.TxtUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUnit.Location = New System.Drawing.Point(265, 7)
        Me.TxtUnit.Margin = New System.Windows.Forms.Padding(7)
        Me.TxtUnit.MaxLength = 10
        Me.TxtUnit.Name = "TxtUnit"
        Me.TxtUnit.Size = New System.Drawing.Size(100, 23)
        Me.TxtUnit.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LblTemperature)
        Me.Panel2.Controls.Add(Me.DbxTemperature)
        Me.Panel2.Location = New System.Drawing.Point(3, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(374, 39)
        Me.Panel2.TabIndex = 3
        '
        'LblTemperature
        '
        Me.LblTemperature.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblTemperature.Location = New System.Drawing.Point(0, 0)
        Me.LblTemperature.Name = "LblTemperature"
        Me.LblTemperature.Size = New System.Drawing.Size(238, 37)
        Me.LblTemperature.TabIndex = 0
        Me.LblTemperature.Text = "Temperatura (ºC):"
        Me.LblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxTemperature
        '
        Me.DbxTemperature.DecimalOnly = True
        Me.DbxTemperature.DecimalPlaces = 0
        Me.DbxTemperature.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxTemperature.Location = New System.Drawing.Point(265, 7)
        Me.DbxTemperature.Margin = New System.Windows.Forms.Padding(7)
        Me.DbxTemperature.MaxLength = 3
        Me.DbxTemperature.Name = "DbxTemperature"
        Me.DbxTemperature.Size = New System.Drawing.Size(100, 23)
        Me.DbxTemperature.TabIndex = 1
        Me.DbxTemperature.Text = "0"
        Me.DbxTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LblPressure)
        Me.Panel3.Controls.Add(Me.DbxPressure)
        Me.Panel3.Location = New System.Drawing.Point(3, 93)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(374, 39)
        Me.Panel3.TabIndex = 6
        '
        'LblPressure
        '
        Me.LblPressure.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblPressure.Location = New System.Drawing.Point(0, 0)
        Me.LblPressure.Name = "LblPressure"
        Me.LblPressure.Size = New System.Drawing.Size(238, 37)
        Me.LblPressure.TabIndex = 0
        Me.LblPressure.Text = "Pressão (BAR):"
        Me.LblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxPressure
        '
        Me.DbxPressure.DecimalOnly = True
        Me.DbxPressure.DecimalPlaces = 1
        Me.DbxPressure.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxPressure.Location = New System.Drawing.Point(265, 7)
        Me.DbxPressure.Margin = New System.Windows.Forms.Padding(7)
        Me.DbxPressure.MaxLength = 4
        Me.DbxPressure.Name = "DbxPressure"
        Me.DbxPressure.Size = New System.Drawing.Size(100, 23)
        Me.DbxPressure.TabIndex = 1
        Me.DbxPressure.Text = "0,0"
        Me.DbxPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UcEvaluationUnitTemperaturePressure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcEvaluationUnitTemperaturePressure"
        Me.Size = New System.Drawing.Size(380, 138)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents Panel1 As Panel
    Private WithEvents TxtUnit As TextBox
    Private WithEvents LblUnit As Label
    Private WithEvents Panel2 As Panel
    Private WithEvents LblTemperature As Label
    Private WithEvents DbxTemperature As ControlLibrary.DecimalBox
    Private WithEvents Panel3 As Panel
    Private WithEvents LblPressure As Label
    Private WithEvents DbxPressure As ControlLibrary.DecimalBox
End Class