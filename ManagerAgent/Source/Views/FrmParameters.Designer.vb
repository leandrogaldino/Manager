<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParameters
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnTestAndOK = New System.Windows.Forms.Button()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.TxtUserDefaultPassword = New System.Windows.Forms.TextBox()
        Me.LblUserDefaultPassword = New System.Windows.Forms.Label()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.LblReleaseRegister = New System.Windows.Forms.Label()
        Me.TbrReleaseRegister = New System.Windows.Forms.TrackBar()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.LblEvaluationMonthsBeforeRecordDeletion = New System.Windows.Forms.Label()
        Me.DbxEvaluationMonthsBeforeRecordDeletion = New CoreSuite.Controls.DecimalBox()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.LblEvaluationDaysBeforeVisitAlert = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysBeforeVisitAlert = New CoreSuite.Controls.DecimalBox()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.LblEvaluationDaysBeforeMaintenanceAlert = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysBeforeMaintenanceAlert = New CoreSuite.Controls.DecimalBox()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.LblInterval = New System.Windows.Forms.Label()
        Me.TbrInterval = New System.Windows.Forms.TrackBar()
        Me.PnButtons.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.TbrInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnTestAndOK)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 345)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(475, 36)
        Me.PnButtons.TabIndex = 5
        '
        'BtnTestAndOK
        '
        Me.BtnTestAndOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTestAndOK.Enabled = False
        Me.BtnTestAndOK.Location = New System.Drawing.Point(368, 3)
        Me.BtnTestAndOK.Name = "BtnTestAndOK"
        Me.BtnTestAndOK.Size = New System.Drawing.Size(95, 30)
        Me.BtnTestAndOK.TabIndex = 0
        Me.BtnTestAndOK.Text = "OK"
        Me.BtnTestAndOK.UseVisualStyleBackColor = True
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel19.Controls.Add(Me.TxtUserDefaultPassword)
        Me.Panel19.Controls.Add(Me.LblUserDefaultPassword)
        Me.Panel19.Location = New System.Drawing.Point(12, 296)
        Me.Panel19.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel19.Size = New System.Drawing.Size(450, 31)
        Me.Panel19.TabIndex = 24
        '
        'TxtUserDefaultPassword
        '
        Me.TxtUserDefaultPassword.Location = New System.Drawing.Point(274, 3)
        Me.TxtUserDefaultPassword.Name = "TxtUserDefaultPassword"
        Me.TxtUserDefaultPassword.Size = New System.Drawing.Size(171, 23)
        Me.TxtUserDefaultPassword.TabIndex = 1
        Me.TxtUserDefaultPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblUserDefaultPassword
        '
        Me.LblUserDefaultPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblUserDefaultPassword.Location = New System.Drawing.Point(4, 0)
        Me.LblUserDefaultPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUserDefaultPassword.Name = "LblUserDefaultPassword"
        Me.LblUserDefaultPassword.Size = New System.Drawing.Size(120, 29)
        Me.LblUserDefaultPassword.TabIndex = 0
        Me.LblUserDefaultPassword.Text = "Senha padrão"
        Me.LblUserDefaultPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.White
        Me.Panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel25.Controls.Add(Me.LblReleaseRegister)
        Me.Panel25.Controls.Add(Me.TbrReleaseRegister)
        Me.Panel25.Location = New System.Drawing.Point(12, 222)
        Me.Panel25.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel25.Size = New System.Drawing.Size(450, 62)
        Me.Panel25.TabIndex = 23
        '
        'LblReleaseRegister
        '
        Me.LblReleaseRegister.Location = New System.Drawing.Point(1, 1)
        Me.LblReleaseRegister.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblReleaseRegister.Name = "LblReleaseRegister"
        Me.LblReleaseRegister.Size = New System.Drawing.Size(414, 26)
        Me.LblReleaseRegister.TabIndex = 3
        Me.LblReleaseRegister.Text = "Liberar registros não atualizados a mais de 2 minutos"
        Me.LblReleaseRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrReleaseRegister
        '
        Me.TbrReleaseRegister.AutoSize = False
        Me.TbrReleaseRegister.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrReleaseRegister.Location = New System.Drawing.Point(4, 29)
        Me.TbrReleaseRegister.Maximum = 60
        Me.TbrReleaseRegister.Minimum = 2
        Me.TbrReleaseRegister.Name = "TbrReleaseRegister"
        Me.TbrReleaseRegister.Size = New System.Drawing.Size(444, 31)
        Me.TbrReleaseRegister.TabIndex = 2
        Me.TbrReleaseRegister.Value = 2
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.LblEvaluationMonthsBeforeRecordDeletion)
        Me.Panel7.Controls.Add(Me.DbxEvaluationMonthsBeforeRecordDeletion)
        Me.Panel7.Location = New System.Drawing.Point(12, 182)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel7.Size = New System.Drawing.Size(450, 31)
        Me.Panel7.TabIndex = 22
        '
        'LblEvaluationMonthsBeforeRecordDeletion
        '
        Me.LblEvaluationMonthsBeforeRecordDeletion.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationMonthsBeforeRecordDeletion.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationMonthsBeforeRecordDeletion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationMonthsBeforeRecordDeletion.Name = "LblEvaluationMonthsBeforeRecordDeletion"
        Me.LblEvaluationMonthsBeforeRecordDeletion.Size = New System.Drawing.Size(213, 29)
        Me.LblEvaluationMonthsBeforeRecordDeletion.TabIndex = 0
        Me.LblEvaluationMonthsBeforeRecordDeletion.Text = "Meses de retenção dos registros"
        Me.LblEvaluationMonthsBeforeRecordDeletion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationMonthsBeforeRecordDeletion
        '
        Me.DbxEvaluationMonthsBeforeRecordDeletion.DecimalOnly = True
        Me.DbxEvaluationMonthsBeforeRecordDeletion.DecimalPlaces = 0
        Me.DbxEvaluationMonthsBeforeRecordDeletion.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Location = New System.Drawing.Point(274, 3)
        Me.DbxEvaluationMonthsBeforeRecordDeletion.MaxLength = 3
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Name = "DbxEvaluationMonthsBeforeRecordDeletion"
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Size = New System.Drawing.Size(171, 23)
        Me.DbxEvaluationMonthsBeforeRecordDeletion.TabIndex = 1
        Me.DbxEvaluationMonthsBeforeRecordDeletion.Text = "0"
        Me.DbxEvaluationMonthsBeforeRecordDeletion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.Color.White
        Me.Panel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel26.Controls.Add(Me.LblEvaluationDaysBeforeVisitAlert)
        Me.Panel26.Controls.Add(Me.DbxEvaluationDaysBeforeVisitAlert)
        Me.Panel26.Location = New System.Drawing.Point(12, 138)
        Me.Panel26.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel26.Size = New System.Drawing.Size(450, 31)
        Me.Panel26.TabIndex = 21
        '
        'LblEvaluationDaysBeforeVisitAlert
        '
        Me.LblEvaluationDaysBeforeVisitAlert.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationDaysBeforeVisitAlert.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationDaysBeforeVisitAlert.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationDaysBeforeVisitAlert.Name = "LblEvaluationDaysBeforeVisitAlert"
        Me.LblEvaluationDaysBeforeVisitAlert.Size = New System.Drawing.Size(157, 29)
        Me.LblEvaluationDaysBeforeVisitAlert.TabIndex = 0
        Me.LblEvaluationDaysBeforeVisitAlert.Text = "Dias para alertar visita"
        Me.LblEvaluationDaysBeforeVisitAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationDaysBeforeVisitAlert
        '
        Me.DbxEvaluationDaysBeforeVisitAlert.DecimalOnly = True
        Me.DbxEvaluationDaysBeforeVisitAlert.DecimalPlaces = 0
        Me.DbxEvaluationDaysBeforeVisitAlert.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationDaysBeforeVisitAlert.Location = New System.Drawing.Point(274, 3)
        Me.DbxEvaluationDaysBeforeVisitAlert.MaxLength = 3
        Me.DbxEvaluationDaysBeforeVisitAlert.Name = "DbxEvaluationDaysBeforeVisitAlert"
        Me.DbxEvaluationDaysBeforeVisitAlert.Size = New System.Drawing.Size(171, 23)
        Me.DbxEvaluationDaysBeforeVisitAlert.TabIndex = 1
        Me.DbxEvaluationDaysBeforeVisitAlert.Text = "0"
        Me.DbxEvaluationDaysBeforeVisitAlert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.White
        Me.Panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel23.Controls.Add(Me.LblEvaluationDaysBeforeMaintenanceAlert)
        Me.Panel23.Controls.Add(Me.DbxEvaluationDaysBeforeMaintenanceAlert)
        Me.Panel23.Location = New System.Drawing.Point(12, 94)
        Me.Panel23.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel23.Size = New System.Drawing.Size(450, 31)
        Me.Panel23.TabIndex = 20
        '
        'LblEvaluationDaysBeforeMaintenanceAlert
        '
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Name = "LblEvaluationDaysBeforeMaintenanceAlert"
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Size = New System.Drawing.Size(207, 29)
        Me.LblEvaluationDaysBeforeMaintenanceAlert.TabIndex = 0
        Me.LblEvaluationDaysBeforeMaintenanceAlert.Text = "Dias para alertar manutenção"
        Me.LblEvaluationDaysBeforeMaintenanceAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationDaysBeforeMaintenanceAlert
        '
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.DecimalOnly = True
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.DecimalPlaces = 0
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Location = New System.Drawing.Point(274, 3)
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.MaxLength = 3
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Name = "DbxEvaluationDaysBeforeMaintenanceAlert"
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Size = New System.Drawing.Size(171, 23)
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.TabIndex = 1
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.Text = "0"
        Me.DbxEvaluationDaysBeforeMaintenanceAlert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.White
        Me.Panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel24.Controls.Add(Me.LblInterval)
        Me.Panel24.Controls.Add(Me.TbrInterval)
        Me.Panel24.Location = New System.Drawing.Point(12, 19)
        Me.Panel24.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel24.Size = New System.Drawing.Size(450, 62)
        Me.Panel24.TabIndex = 19
        '
        'LblInterval
        '
        Me.LblInterval.Location = New System.Drawing.Point(1, -1)
        Me.LblInterval.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblInterval.Name = "LblInterval"
        Me.LblInterval.Size = New System.Drawing.Size(414, 26)
        Me.LblInterval.TabIndex = 3
        Me.LblInterval.Text = "Executar a limpeza a cada 1 dia"
        Me.LblInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrInterval
        '
        Me.TbrInterval.AutoSize = False
        Me.TbrInterval.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrInterval.Location = New System.Drawing.Point(4, 29)
        Me.TbrInterval.Maximum = 60
        Me.TbrInterval.Minimum = 1
        Me.TbrInterval.Name = "TbrInterval"
        Me.TbrInterval.Size = New System.Drawing.Size(444, 31)
        Me.TbrInterval.TabIndex = 2
        Me.TbrInterval.Value = 2
        '
        'FrmParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(475, 381)
        Me.Controls.Add(Me.Panel19)
        Me.Controls.Add(Me.Panel25)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel26)
        Me.Controls.Add(Me.Panel23)
        Me.Controls.Add(Me.Panel24)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParameters"
        Me.Text = "Parâmetros"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.Panel25.ResumeLayout(False)
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.Panel24.ResumeLayout(False)
        CType(Me.TbrInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnTestAndOK As Button
    Friend WithEvents Panel19 As Panel
    Friend WithEvents TxtUserDefaultPassword As TextBox
    Friend WithEvents LblUserDefaultPassword As Label
    Friend WithEvents Panel25 As Panel
    Friend WithEvents LblReleaseRegister As Label
    Friend WithEvents TbrReleaseRegister As TrackBar
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LblEvaluationMonthsBeforeRecordDeletion As Label
    Friend WithEvents DbxEvaluationMonthsBeforeRecordDeletion As CoreSuite.Controls.DecimalBox
    Friend WithEvents Panel26 As Panel
    Friend WithEvents LblEvaluationDaysBeforeVisitAlert As Label
    Friend WithEvents DbxEvaluationDaysBeforeVisitAlert As CoreSuite.Controls.DecimalBox
    Friend WithEvents Panel23 As Panel
    Friend WithEvents LblEvaluationDaysBeforeMaintenanceAlert As Label
    Friend WithEvents DbxEvaluationDaysBeforeMaintenanceAlert As CoreSuite.Controls.DecimalBox
    Friend WithEvents Panel24 As Panel
    Friend WithEvents LblInterval As Label
    Friend WithEvents TbrInterval As TrackBar
End Class
