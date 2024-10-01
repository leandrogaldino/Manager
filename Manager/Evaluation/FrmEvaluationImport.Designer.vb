<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEvaluationImport
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
        Me.components = New System.ComponentModel.Container()
        Me.PnBottomBar = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.DgvEvaluations = New System.Windows.Forms.DataGridView()
        Me.SyncTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PnBottomBar.SuspendLayout()
        CType(Me.DgvEvaluations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnBottomBar
        '
        Me.PnBottomBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnBottomBar.Controls.Add(Me.BtnClose)
        Me.PnBottomBar.Controls.Add(Me.BtnImport)
        Me.PnBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnBottomBar.Location = New System.Drawing.Point(0, 317)
        Me.PnBottomBar.Name = "PnBottomBar"
        Me.PnBottomBar.Size = New System.Drawing.Size(784, 44)
        Me.PnBottomBar.TabIndex = 6
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(677, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(578, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'DgvEvaluations
        '
        Me.DgvEvaluations.AllowUserToAddRows = False
        Me.DgvEvaluations.AllowUserToDeleteRows = False
        Me.DgvEvaluations.AllowUserToOrderColumns = True
        Me.DgvEvaluations.AllowUserToResizeRows = False
        Me.DgvEvaluations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvEvaluations.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvEvaluations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvEvaluations.Location = New System.Drawing.Point(12, 12)
        Me.DgvEvaluations.MultiSelect = False
        Me.DgvEvaluations.Name = "DgvEvaluations"
        Me.DgvEvaluations.ReadOnly = True
        Me.DgvEvaluations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvEvaluations.RowHeadersVisible = False
        Me.DgvEvaluations.RowTemplate.Height = 26
        Me.DgvEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEvaluations.Size = New System.Drawing.Size(760, 299)
        Me.DgvEvaluations.TabIndex = 24
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
        'FrmEvaluationImport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.DgvEvaluations)
        Me.Controls.Add(Me.PnBottomBar)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluationImport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importar Avaliações"
        Me.PnBottomBar.ResumeLayout(False)
        CType(Me.DgvEvaluations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents PnBottomBar As Panel
    Friend WithEvents DgvEvaluations As DataGridView
    Friend WithEvents SyncTimer As Timer
    Friend WithEvents RefreshTimer As Timer
End Class
