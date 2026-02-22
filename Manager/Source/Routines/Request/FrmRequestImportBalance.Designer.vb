<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRequestImportBalance
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PnBottomBar = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.DgvEvaluationProducts = New System.Windows.Forms.DataGridView()
        Me.SyncTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripCheckBox1 = New ControlLibrary.ToolStripCheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvRequestsProducts = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnBottomBar.SuspendLayout()
        CType(Me.DgvEvaluationProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvRequestsProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnBottomBar
        '
        Me.PnBottomBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnBottomBar.Controls.Add(Me.BtnClose)
        Me.PnBottomBar.Controls.Add(Me.BtnImport)
        Me.PnBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnBottomBar.Location = New System.Drawing.Point(0, 509)
        Me.PnBottomBar.Name = "PnBottomBar"
        Me.PnBottomBar.Size = New System.Drawing.Size(784, 52)
        Me.PnBottomBar.TabIndex = 6
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(677, 15)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Enabled = False
        Me.BtnImport.Location = New System.Drawing.Point(578, 15)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'DgvEvaluationProducts
        '
        Me.DgvEvaluationProducts.AllowUserToAddRows = False
        Me.DgvEvaluationProducts.AllowUserToDeleteRows = False
        Me.DgvEvaluationProducts.AllowUserToOrderColumns = True
        Me.DgvEvaluationProducts.AllowUserToResizeRows = False
        Me.DgvEvaluationProducts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvEvaluationProducts.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvEvaluationProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvEvaluationProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvEvaluationProducts.Enabled = False
        Me.DgvEvaluationProducts.Location = New System.Drawing.Point(15, 29)
        Me.DgvEvaluationProducts.MultiSelect = False
        Me.DgvEvaluationProducts.Name = "DgvEvaluationProducts"
        Me.DgvEvaluationProducts.ReadOnly = True
        Me.DgvEvaluationProducts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvEvaluationProducts.RowHeadersVisible = False
        Me.DgvEvaluationProducts.RowTemplate.Height = 26
        Me.DgvEvaluationProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEvaluationProducts.Size = New System.Drawing.Size(755, 226)
        Me.DgvEvaluationProducts.TabIndex = 24
        '
        'SyncTimer
        '
        Me.SyncTimer.Enabled = True
        Me.SyncTimer.Interval = 10000
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Enabled = True
        Me.RefreshTimer.Interval = 10000
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(87, 22)
        Me.ToolStripLabel1.Text = "ToolStripLabel1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'ToolStripCheckBox1
        '
        Me.ToolStripCheckBox1.Checked = False
        Me.ToolStripCheckBox1.Name = "ToolStripCheckBox1"
        Me.ToolStripCheckBox1.Size = New System.Drawing.Size(131, 22)
        Me.ToolStripCheckBox1.Text = "ToolStripCheckBox1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Produtos da Avaliação"
        '
        'DgvRequestsProducts
        '
        Me.DgvRequestsProducts.AllowUserToAddRows = False
        Me.DgvRequestsProducts.AllowUserToDeleteRows = False
        Me.DgvRequestsProducts.AllowUserToResizeColumns = False
        Me.DgvRequestsProducts.AllowUserToResizeRows = False
        Me.DgvRequestsProducts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvRequestsProducts.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvRequestsProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvRequestsProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRequestsProducts.Location = New System.Drawing.Point(12, 278)
        Me.DgvRequestsProducts.MultiSelect = False
        Me.DgvRequestsProducts.Name = "DgvRequestsProducts"
        Me.DgvRequestsProducts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvRequestsProducts.RowHeadersVisible = False
        Me.DgvRequestsProducts.RowTemplate.Height = 26
        Me.DgvRequestsProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRequestsProducts.Size = New System.Drawing.Size(755, 225)
        Me.DgvRequestsProducts.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 17)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Produtos Pendentes nas Requisições"
        '
        'FrmRequestImportBalance
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DgvRequestsProducts)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvEvaluationProducts)
        Me.Controls.Add(Me.PnBottomBar)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRequestImportBalance"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importar Produtos Avaliação x Requisição"
        Me.PnBottomBar.ResumeLayout(False)
        CType(Me.DgvEvaluationProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvRequestsProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents PnBottomBar As Panel
    Friend WithEvents DgvEvaluationProducts As DataGridView
    Friend WithEvents SyncTimer As Timer
    Friend WithEvents RefreshTimer As Timer
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents ToolStripCheckBox1 As ControlLibrary.ToolStripCheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DgvRequestsProducts As DataGridView
    Friend WithEvents Label2 As Label
End Class
