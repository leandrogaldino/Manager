<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcChekUpdate
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
        Me.BwUpdate = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblProgress = New System.Windows.Forms.Label()
        Me.CpbUpdate = New ManagerLaucher.CustomProgressBar()
        Me.SuspendLayout()
        '
        'BwUpdate
        '
        Me.BwUpdate.WorkerReportsProgress = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(394, 35)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Atualizando o sistema, por favor aguarde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblProgress
        '
        Me.LblProgress.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.LblProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblProgress.ForeColor = System.Drawing.Color.White
        Me.LblProgress.Location = New System.Drawing.Point(0, 74)
        Me.LblProgress.Name = "LblProgress"
        Me.LblProgress.Size = New System.Drawing.Size(394, 20)
        Me.LblProgress.TabIndex = 23
        Me.LblProgress.Text = "0%"
        Me.LblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CpbUpdate
        '
        Me.CpbUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CpbUpdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CpbUpdate.Location = New System.Drawing.Point(0, 94)
        Me.CpbUpdate.Maximum = 100
        Me.CpbUpdate.Minimum = 0
        Me.CpbUpdate.Name = "CpbUpdate"
        Me.CpbUpdate.ProgressBottomColor = System.Drawing.Color.White
        Me.CpbUpdate.ProgressTopColor = System.Drawing.Color.White
        Me.CpbUpdate.Size = New System.Drawing.Size(394, 5)
        Me.CpbUpdate.TabIndex = 22
        Me.CpbUpdate.Value = 0
        '
        'UcChekUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Controls.Add(Me.LblProgress)
        Me.Controls.Add(Me.CpbUpdate)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UcChekUpdate"
        Me.Size = New System.Drawing.Size(394, 99)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BwUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents CpbUpdate As CustomProgressBar
    Friend WithEvents LblProgress As Label
End Class
