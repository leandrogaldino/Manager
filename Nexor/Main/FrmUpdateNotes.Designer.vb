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
        TvVersions = New TreeView()
        LblTitle = New Label()
        TxtUpdates = New TextBox()
        SuspendLayout()
        ' 
        ' TvVersions
        ' 
        TvVersions.BackColor = Color.WhiteSmoke
        TvVersions.BorderStyle = BorderStyle.None
        TvVersions.Dock = DockStyle.Left
        TvVersions.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TvVersions.FullRowSelect = True
        TvVersions.HideSelection = False
        TvVersions.ItemHeight = 24
        TvVersions.Location = New Point(0, 29)
        TvVersions.Margin = New Padding(4)
        TvVersions.Name = "TvVersions"
        TvVersions.ShowRootLines = False
        TvVersions.Size = New Size(95, 351)
        TvVersions.TabIndex = 0
        ' 
        ' LblTitle
        ' 
        LblTitle.BackColor = Color.WhiteSmoke
        LblTitle.Dock = DockStyle.Top
        LblTitle.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblTitle.Location = New Point(0, 0)
        LblTitle.Margin = New Padding(4, 0, 4, 0)
        LblTitle.Name = "LblTitle"
        LblTitle.Size = New Size(466, 29)
        LblTitle.TabIndex = 1
        LblTitle.Text = "Notas da Versão x.x"
        LblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TxtUpdates
        ' 
        TxtUpdates.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TxtUpdates.Location = New Point(100, 32)
        TxtUpdates.Margin = New Padding(1)
        TxtUpdates.Multiline = True
        TxtUpdates.Name = "TxtUpdates"
        TxtUpdates.ReadOnly = True
        TxtUpdates.ScrollBars = ScrollBars.Vertical
        TxtUpdates.Size = New Size(354, 336)
        TxtUpdates.TabIndex = 2
        ' 
        ' FrmUpdateNotes
        ' 
        AutoScaleDimensions = New SizeF(8F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(466, 380)
        Controls.Add(TxtUpdates)
        Controls.Add(TvVersions)
        Controls.Add(LblTitle)
        Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmUpdateNotes"
        ShowIcon = False
        ShowInTaskbar = False
        Text = "Nexor"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents TvVersions As TreeView
    Friend WithEvents LblTitle As Label
    Friend WithEvents TxtUpdates As TextBox
End Class
