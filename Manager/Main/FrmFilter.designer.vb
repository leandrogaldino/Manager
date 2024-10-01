<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFilter
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
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PgFilter = New System.Windows.Forms.PropertyGrid()
        Me.TsFilterTop = New System.Windows.Forms.ToolStrip()
        Me.LblFilter = New System.Windows.Forms.ToolStripLabel()
        Me.TsFilterBot = New System.Windows.Forms.ToolStrip()
        Me.BtnClean = New System.Windows.Forms.ToolStripButton()
        Me.DgvData = New System.Windows.Forms.DataGridView()
        Me.LblInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SsInformation = New System.Windows.Forms.StatusStrip()
        Me.LblCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TsFilterTop.SuspendLayout()
        Me.TsFilterBot.SuspendLayout()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SsInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(648, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Enabled = False
        Me.BtnImport.Location = New System.Drawing.Point(547, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 3
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 436)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 44)
        Me.Panel1.TabIndex = 7
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.PgFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TsFilterTop)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TsFilterBot)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgvData)
        Me.SplitContainer1.Size = New System.Drawing.Size(755, 414)
        Me.SplitContainer1.SplitterDistance = 181
        Me.SplitContainer1.TabIndex = 8
        '
        'PgFilter
        '
        Me.PgFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PgFilter.HelpVisible = False
        Me.PgFilter.Location = New System.Drawing.Point(0, 25)
        Me.PgFilter.Name = "PgFilter"
        Me.PgFilter.PropertySort = System.Windows.Forms.PropertySort.NoSort
        Me.PgFilter.Size = New System.Drawing.Size(179, 362)
        Me.PgFilter.TabIndex = 0
        Me.PgFilter.ToolbarVisible = False
        '
        'TsFilterTop
        '
        Me.TsFilterTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsFilterTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblFilter})
        Me.TsFilterTop.Location = New System.Drawing.Point(0, 0)
        Me.TsFilterTop.Name = "TsFilterTop"
        Me.TsFilterTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsFilterTop.Size = New System.Drawing.Size(179, 25)
        Me.TsFilterTop.TabIndex = 1
        Me.TsFilterTop.Text = "ToolStrip1"
        '
        'LblFilter
        '
        Me.LblFilter.BackColor = System.Drawing.SystemColors.Control
        Me.LblFilter.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(122, 22)
        Me.LblFilter.Text = "Parâmetros do Filtro"
        '
        'TsFilterBot
        '
        Me.TsFilterBot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TsFilterBot.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsFilterBot.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnClean})
        Me.TsFilterBot.Location = New System.Drawing.Point(0, 387)
        Me.TsFilterBot.Name = "TsFilterBot"
        Me.TsFilterBot.Size = New System.Drawing.Size(179, 25)
        Me.TsFilterBot.TabIndex = 2
        Me.TsFilterBot.Text = "ToolStrip1"
        '
        'BtnClean
        '
        Me.BtnClean.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnClean.Image = Global.Manager.My.Resources.Resources.Clean
        Me.BtnClean.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClean.Name = "BtnClean"
        Me.BtnClean.Size = New System.Drawing.Size(64, 22)
        Me.BtnClean.Text = "Limpar"
        '
        'DgvData
        '
        Me.DgvData.AllowUserToAddRows = False
        Me.DgvData.AllowUserToDeleteRows = False
        Me.DgvData.AllowUserToOrderColumns = True
        Me.DgvData.AllowUserToResizeRows = False
        Me.DgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgvData.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvData.Location = New System.Drawing.Point(0, 0)
        Me.DgvData.MultiSelect = False
        Me.DgvData.Name = "DgvData"
        Me.DgvData.ReadOnly = True
        Me.DgvData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvData.RowHeadersVisible = False
        Me.DgvData.RowTemplate.Height = 26
        Me.DgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvData.Size = New System.Drawing.Size(568, 412)
        Me.DgvData.TabIndex = 4
        '
        'LblInfo
        '
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Size = New System.Drawing.Size(0, 17)
        '
        'SsInformation
        '
        Me.SsInformation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SsInformation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblInfo, Me.LblCounter})
        Me.SsInformation.Location = New System.Drawing.Point(0, 414)
        Me.SsInformation.Name = "SsInformation"
        Me.SsInformation.Size = New System.Drawing.Size(755, 22)
        Me.SsInformation.SizingGrip = False
        Me.SsInformation.Stretch = False
        Me.SsInformation.TabIndex = 9
        Me.SsInformation.Text = "StatusStrip1"
        '
        'LblCounter
        '
        Me.LblCounter.BackColor = System.Drawing.Color.Transparent
        Me.LblCounter.Name = "LblCounter"
        Me.LblCounter.Size = New System.Drawing.Size(740, 17)
        Me.LblCounter.Spring = True
        Me.LblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(755, 480)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.SsInformation)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "FrmFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Filtro"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TsFilterTop.ResumeLayout(False)
        Me.TsFilterTop.PerformLayout()
        Me.TsFilterBot.ResumeLayout(False)
        Me.TsFilterBot.PerformLayout()
        CType(Me.DgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SsInformation.ResumeLayout(False)
        Me.SsInformation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PgFilter As PropertyGrid
    Friend WithEvents TsFilterTop As ToolStrip
    Friend WithEvents LblFilter As ToolStripLabel
    Friend WithEvents TsFilterBot As ToolStrip
    Friend WithEvents BtnClean As ToolStripButton
    Friend WithEvents DgvData As DataGridView
    Friend WithEvents LblInfo As ToolStripStatusLabel
    Friend WithEvents SsInformation As StatusStrip
    Friend WithEvents LblCounter As ToolStripStatusLabel
End Class
