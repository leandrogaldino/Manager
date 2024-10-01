<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdateNotes
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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
        Me.TvVersions = New System.Windows.Forms.TreeView()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.TxtUpdates = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TvVersions
        '
        Me.TvVersions.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TvVersions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TvVersions.Dock = System.Windows.Forms.DockStyle.Left
        Me.TvVersions.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TvVersions.FullRowSelect = True
        Me.TvVersions.HideSelection = False
        Me.TvVersions.ItemHeight = 24
        Me.TvVersions.Location = New System.Drawing.Point(0, 29)
        Me.TvVersions.Margin = New System.Windows.Forms.Padding(4)
        Me.TvVersions.Name = "TvVersions"
        Me.TvVersions.ShowRootLines = False
        Me.TvVersions.Size = New System.Drawing.Size(51, 351)
        Me.TvVersions.TabIndex = 0
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitle.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(466, 29)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.Text = "Notas da Versão x.x"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtUpdates
        '
        Me.TxtUpdates.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUpdates.Location = New System.Drawing.Point(58, 32)
        Me.TxtUpdates.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtUpdates.Multiline = True
        Me.TxtUpdates.Name = "TxtUpdates"
        Me.TxtUpdates.ReadOnly = True
        Me.TxtUpdates.Size = New System.Drawing.Size(396, 336)
        Me.TxtUpdates.TabIndex = 2
        '
        'FrmUpdateInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(466, 380)
        Me.Controls.Add(Me.TxtUpdates)
        Me.Controls.Add(Me.TvVersions)
        Me.Controls.Add(Me.LblTitle)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUpdateInfo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Gerenciador"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TvVersions As TreeView
    Friend WithEvents LblTitle As Label
    Friend WithEvents TxtUpdates As TextBox
End Class
