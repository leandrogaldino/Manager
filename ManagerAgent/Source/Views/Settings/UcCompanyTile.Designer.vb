<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcCompanyTile
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
        Me.LblCompanyName = New System.Windows.Forms.Label()
        Me.LblCompanyDocument = New System.Windows.Forms.Label()
        Me.LblCompanyLocation = New System.Windows.Forms.Label()
        Me.PbxLogo = New System.Windows.Forms.PictureBox()
        CType(Me.PbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblCompanyName
        '
        Me.LblCompanyName.AutoSize = True
        Me.LblCompanyName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCompanyName.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCompanyName.Location = New System.Drawing.Point(157, 11)
        Me.LblCompanyName.Name = "LblCompanyName"
        Me.LblCompanyName.Size = New System.Drawing.Size(127, 18)
        Me.LblCompanyName.TabIndex = 1
        Me.LblCompanyName.Text = "CompanyName"
        '
        'LblCompanyDocument
        '
        Me.LblCompanyDocument.AutoSize = True
        Me.LblCompanyDocument.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCompanyDocument.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCompanyDocument.Location = New System.Drawing.Point(157, 34)
        Me.LblCompanyDocument.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblCompanyDocument.Name = "LblCompanyDocument"
        Me.LblCompanyDocument.Size = New System.Drawing.Size(142, 17)
        Me.LblCompanyDocument.TabIndex = 1
        Me.LblCompanyDocument.Text = "CompanyDocument"
        '
        'LblCompanyLocation
        '
        Me.LblCompanyLocation.AutoSize = True
        Me.LblCompanyLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCompanyLocation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCompanyLocation.Location = New System.Drawing.Point(157, 56)
        Me.LblCompanyLocation.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblCompanyLocation.Name = "LblCompanyLocation"
        Me.LblCompanyLocation.Size = New System.Drawing.Size(130, 17)
        Me.LblCompanyLocation.TabIndex = 1
        Me.LblCompanyLocation.Text = "CompanyLocation"
        '
        'PbxLogo
        '
        Me.PbxLogo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PbxLogo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxLogo.Location = New System.Drawing.Point(7, 7)
        Me.PbxLogo.Margin = New System.Windows.Forms.Padding(7)
        Me.PbxLogo.Name = "PbxLogo"
        Me.PbxLogo.Size = New System.Drawing.Size(140, 70)
        Me.PbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxLogo.TabIndex = 2
        Me.PbxLogo.TabStop = False
        '
        'UcCompanyTile
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PbxLogo)
        Me.Controls.Add(Me.LblCompanyLocation)
        Me.Controls.Add(Me.LblCompanyDocument)
        Me.Controls.Add(Me.LblCompanyName)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UcCompanyTile"
        Me.Size = New System.Drawing.Size(498, 85)
        CType(Me.PbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents LblCompanyName As Label
    Private WithEvents LblCompanyDocument As Label
    Private WithEvents LblCompanyLocation As Label
    Friend WithEvents PbxLogo As PictureBox
End Class
