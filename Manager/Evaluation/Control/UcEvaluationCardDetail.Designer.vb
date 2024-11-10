<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcEvaluationCardDetail
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
        Me.DgvCardDetail = New System.Windows.Forms.DataGridView()
        CType(Me.DgvCardDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvCardDetail
        '
        Me.DgvCardDetail.AllowUserToAddRows = False
        Me.DgvCardDetail.AllowUserToDeleteRows = False
        Me.DgvCardDetail.AllowUserToResizeColumns = False
        Me.DgvCardDetail.AllowUserToResizeRows = False
        Me.DgvCardDetail.BackgroundColor = System.Drawing.Color.White
        Me.DgvCardDetail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCardDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCardDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCardDetail.Location = New System.Drawing.Point(0, 0)
        Me.DgvCardDetail.MultiSelect = False
        Me.DgvCardDetail.Name = "DgvCardDetail"
        Me.DgvCardDetail.ReadOnly = True
        Me.DgvCardDetail.RowHeadersVisible = False
        Me.DgvCardDetail.RowTemplate.Height = 26
        Me.DgvCardDetail.Size = New System.Drawing.Size(1000, 493)
        Me.DgvCardDetail.TabIndex = 1
        '
        'UcEvaluationCardDetail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.DgvCardDetail)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcEvaluationCardDetail"
        Me.Size = New System.Drawing.Size(1000, 493)
        CType(Me.DgvCardDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvCardDetail As DataGridView
End Class
