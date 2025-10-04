<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCloudSynchronization
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LblCloudLastSyncID = New System.Windows.Forms.Label()
        Me.DbxCloudLastSyncID = New ControlLibrary.DecimalBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DbxCloudOperationCount = New ControlLibrary.DecimalBox()
        Me.LblCloudOperationCount = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.NudCloudMaxOperation = New System.Windows.Forms.NumericUpDown()
        Me.LblCloudMaxOperation = New System.Windows.Forms.Label()
        Me.PnButtons.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.NudCloudMaxOperation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 147)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(474, 44)
        Me.PnButtons.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(370, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(269, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.LblCloudLastSyncID)
        Me.Panel6.Controls.Add(Me.DbxCloudLastSyncID)
        Me.Panel6.Location = New System.Drawing.Point(12, 107)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel6.Size = New System.Drawing.Size(450, 31)
        Me.Panel6.TabIndex = 2
        '
        'LblCloudLastSyncID
        '
        Me.LblCloudLastSyncID.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblCloudLastSyncID.Location = New System.Drawing.Point(4, 0)
        Me.LblCloudLastSyncID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCloudLastSyncID.Name = "LblCloudLastSyncID"
        Me.LblCloudLastSyncID.Size = New System.Drawing.Size(190, 29)
        Me.LblCloudLastSyncID.TabIndex = 0
        Me.LblCloudLastSyncID.Text = "Último ID sincronizado (Log)"
        Me.LblCloudLastSyncID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxCloudLastSyncID
        '
        Me.DbxCloudLastSyncID.DecimalOnly = True
        Me.DbxCloudLastSyncID.DecimalPlaces = 0
        Me.DbxCloudLastSyncID.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxCloudLastSyncID.Location = New System.Drawing.Point(229, 3)
        Me.DbxCloudLastSyncID.Name = "DbxCloudLastSyncID"
        Me.DbxCloudLastSyncID.ReadOnly = True
        Me.DbxCloudLastSyncID.Size = New System.Drawing.Size(216, 23)
        Me.DbxCloudLastSyncID.TabIndex = 1
        Me.DbxCloudLastSyncID.Text = "0"
        Me.DbxCloudLastSyncID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.DbxCloudOperationCount)
        Me.Panel5.Controls.Add(Me.LblCloudOperationCount)
        Me.Panel5.Location = New System.Drawing.Point(12, 63)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel5.Size = New System.Drawing.Size(450, 31)
        Me.Panel5.TabIndex = 1
        '
        'DbxCloudOperationCount
        '
        Me.DbxCloudOperationCount.DecimalOnly = True
        Me.DbxCloudOperationCount.DecimalPlaces = 0
        Me.DbxCloudOperationCount.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxCloudOperationCount.Location = New System.Drawing.Point(229, 3)
        Me.DbxCloudOperationCount.Name = "DbxCloudOperationCount"
        Me.DbxCloudOperationCount.ReadOnly = True
        Me.DbxCloudOperationCount.Size = New System.Drawing.Size(216, 23)
        Me.DbxCloudOperationCount.TabIndex = 1
        Me.DbxCloudOperationCount.Text = "0"
        Me.DbxCloudOperationCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblCloudOperationCount
        '
        Me.LblCloudOperationCount.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblCloudOperationCount.Location = New System.Drawing.Point(4, 0)
        Me.LblCloudOperationCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCloudOperationCount.Name = "LblCloudOperationCount"
        Me.LblCloudOperationCount.Size = New System.Drawing.Size(190, 29)
        Me.LblCloudOperationCount.TabIndex = 0
        Me.LblCloudOperationCount.Text = "Sincronizados hoje"
        Me.LblCloudOperationCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.NudCloudMaxOperation)
        Me.Panel3.Controls.Add(Me.LblCloudMaxOperation)
        Me.Panel3.Location = New System.Drawing.Point(12, 19)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(450, 31)
        Me.Panel3.TabIndex = 0
        '
        'NudCloudMaxOperation
        '
        Me.NudCloudMaxOperation.Location = New System.Drawing.Point(229, 3)
        Me.NudCloudMaxOperation.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.NudCloudMaxOperation.Name = "NudCloudMaxOperation"
        Me.NudCloudMaxOperation.Size = New System.Drawing.Size(216, 23)
        Me.NudCloudMaxOperation.TabIndex = 2
        Me.NudCloudMaxOperation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudCloudMaxOperation.Value = New Decimal(New Integer() {10000, 0, 0, 0})
        '
        'LblCloudMaxOperation
        '
        Me.LblCloudMaxOperation.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblCloudMaxOperation.Location = New System.Drawing.Point(4, 0)
        Me.LblCloudMaxOperation.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LblCloudMaxOperation.Name = "LblCloudMaxOperation"
        Me.LblCloudMaxOperation.Size = New System.Drawing.Size(190, 29)
        Me.LblCloudMaxOperation.TabIndex = 0
        Me.LblCloudMaxOperation.Text = "Sincronizações por dia"
        Me.LblCloudMaxOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCloudSynchronization
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 191)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCloudSynchronization"
        Me.ShowIcon = False
        Me.Text = "Sincronização"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.NudCloudMaxOperation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents LblCloudLastSyncID As Label
    Friend WithEvents DbxCloudLastSyncID As ControlLibrary.DecimalBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblCloudOperationCount As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblCloudMaxOperation As Label
    Friend WithEvents DbxCloudOperationCount As ControlLibrary.DecimalBox
    Friend WithEvents NudCloudMaxOperation As NumericUpDown
End Class
