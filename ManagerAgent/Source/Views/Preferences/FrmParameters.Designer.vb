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
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.TxtUserDefaultPassword = New System.Windows.Forms.TextBox()
        Me.LblUserDefaultPassword = New System.Windows.Forms.Label()
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
        Me.LblCleanInterval = New System.Windows.Forms.Label()
        Me.TbrCleanInterval = New System.Windows.Forms.TrackBar()
        Me.TcParameters = New System.Windows.Forms.TabControl()
        Me.TabEvaluation = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtFooterMaintenancePlan = New System.Windows.Forms.TextBox()
        Me.LblFooterMaintenancePlan = New System.Windows.Forms.Label()
        Me.TabUser = New System.Windows.Forms.TabPage()
        Me.TabRelease = New System.Windows.Forms.TabPage()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.LblReleaseRegister = New System.Windows.Forms.Label()
        Me.TbrReleaseRegister = New System.Windows.Forms.TrackBar()
        Me.TabClean = New System.Windows.Forms.TabPage()
        Me.PnButtons.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.TbrCleanInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcParameters.SuspendLayout()
        Me.TabEvaluation.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabUser.SuspendLayout()
        Me.TabRelease.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClean.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 304)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(469, 36)
        Me.PnButtons.TabIndex = 5
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(362, 3)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel19.Controls.Add(Me.TxtUserDefaultPassword)
        Me.Panel19.Controls.Add(Me.LblUserDefaultPassword)
        Me.Panel19.Location = New System.Drawing.Point(6, 13)
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
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.LblEvaluationMonthsBeforeRecordDeletion)
        Me.Panel7.Controls.Add(Me.DbxEvaluationMonthsBeforeRecordDeletion)
        Me.Panel7.Location = New System.Drawing.Point(6, 101)
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
        Me.Panel26.Location = New System.Drawing.Point(6, 57)
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
        Me.Panel23.Location = New System.Drawing.Point(6, 13)
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
        Me.Panel24.Controls.Add(Me.LblCleanInterval)
        Me.Panel24.Controls.Add(Me.TbrCleanInterval)
        Me.Panel24.Location = New System.Drawing.Point(6, 13)
        Me.Panel24.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel24.Size = New System.Drawing.Size(450, 62)
        Me.Panel24.TabIndex = 19
        '
        'LblCleanInterval
        '
        Me.LblCleanInterval.Location = New System.Drawing.Point(1, -1)
        Me.LblCleanInterval.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCleanInterval.Name = "LblCleanInterval"
        Me.LblCleanInterval.Size = New System.Drawing.Size(414, 26)
        Me.LblCleanInterval.TabIndex = 3
        Me.LblCleanInterval.Text = "Executar a limpeza a cada 30 dias"
        Me.LblCleanInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbrCleanInterval
        '
        Me.TbrCleanInterval.AutoSize = False
        Me.TbrCleanInterval.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TbrCleanInterval.Location = New System.Drawing.Point(4, 29)
        Me.TbrCleanInterval.Maximum = 60
        Me.TbrCleanInterval.Minimum = 1
        Me.TbrCleanInterval.Name = "TbrCleanInterval"
        Me.TbrCleanInterval.Size = New System.Drawing.Size(444, 31)
        Me.TbrCleanInterval.TabIndex = 2
        Me.TbrCleanInterval.Value = 30
        '
        'TcParameters
        '
        Me.TcParameters.Controls.Add(Me.TabEvaluation)
        Me.TcParameters.Controls.Add(Me.TabUser)
        Me.TcParameters.Controls.Add(Me.TabRelease)
        Me.TcParameters.Controls.Add(Me.TabClean)
        Me.TcParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcParameters.Location = New System.Drawing.Point(0, 0)
        Me.TcParameters.Name = "TcParameters"
        Me.TcParameters.SelectedIndex = 0
        Me.TcParameters.Size = New System.Drawing.Size(469, 304)
        Me.TcParameters.TabIndex = 25
        '
        'TabEvaluation
        '
        Me.TabEvaluation.Controls.Add(Me.Panel1)
        Me.TabEvaluation.Controls.Add(Me.Panel23)
        Me.TabEvaluation.Controls.Add(Me.Panel26)
        Me.TabEvaluation.Controls.Add(Me.Panel7)
        Me.TabEvaluation.Location = New System.Drawing.Point(4, 26)
        Me.TabEvaluation.Name = "TabEvaluation"
        Me.TabEvaluation.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEvaluation.Size = New System.Drawing.Size(461, 274)
        Me.TabEvaluation.TabIndex = 0
        Me.TabEvaluation.Text = "Avaliação"
        Me.TabEvaluation.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtFooterMaintenancePlan)
        Me.Panel1.Controls.Add(Me.LblFooterMaintenancePlan)
        Me.Panel1.Location = New System.Drawing.Point(6, 141)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(450, 125)
        Me.Panel1.TabIndex = 25
        '
        'TxtFooterMaintenancePlan
        '
        Me.TxtFooterMaintenancePlan.Location = New System.Drawing.Point(141, 3)
        Me.TxtFooterMaintenancePlan.Multiline = True
        Me.TxtFooterMaintenancePlan.Name = "TxtFooterMaintenancePlan"
        Me.TxtFooterMaintenancePlan.Size = New System.Drawing.Size(304, 117)
        Me.TxtFooterMaintenancePlan.TabIndex = 1
        '
        'LblFooterMaintenancePlan
        '
        Me.LblFooterMaintenancePlan.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblFooterMaintenancePlan.Location = New System.Drawing.Point(4, 0)
        Me.LblFooterMaintenancePlan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFooterMaintenancePlan.Name = "LblFooterMaintenancePlan"
        Me.LblFooterMaintenancePlan.Size = New System.Drawing.Size(130, 123)
        Me.LblFooterMaintenancePlan.TabIndex = 0
        Me.LblFooterMaintenancePlan.Text = "Rodapé do Plano de Manutenção"
        Me.LblFooterMaintenancePlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabUser
        '
        Me.TabUser.Controls.Add(Me.Panel19)
        Me.TabUser.Location = New System.Drawing.Point(4, 26)
        Me.TabUser.Name = "TabUser"
        Me.TabUser.Size = New System.Drawing.Size(461, 274)
        Me.TabUser.TabIndex = 2
        Me.TabUser.Text = "Usuário"
        Me.TabUser.UseVisualStyleBackColor = True
        '
        'TabRelease
        '
        Me.TabRelease.Controls.Add(Me.Panel25)
        Me.TabRelease.Location = New System.Drawing.Point(4, 26)
        Me.TabRelease.Name = "TabRelease"
        Me.TabRelease.Size = New System.Drawing.Size(461, 274)
        Me.TabRelease.TabIndex = 3
        Me.TabRelease.Text = "Liberação"
        Me.TabRelease.UseVisualStyleBackColor = True
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.White
        Me.Panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel25.Controls.Add(Me.LblReleaseRegister)
        Me.Panel25.Controls.Add(Me.TbrReleaseRegister)
        Me.Panel25.Location = New System.Drawing.Point(6, 13)
        Me.Panel25.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel25.Size = New System.Drawing.Size(450, 62)
        Me.Panel25.TabIndex = 24
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
        'TabClean
        '
        Me.TabClean.Controls.Add(Me.Panel24)
        Me.TabClean.Location = New System.Drawing.Point(4, 26)
        Me.TabClean.Name = "TabClean"
        Me.TabClean.Padding = New System.Windows.Forms.Padding(3)
        Me.TabClean.Size = New System.Drawing.Size(461, 274)
        Me.TabClean.TabIndex = 1
        Me.TabClean.Text = "Limpeza"
        Me.TabClean.UseVisualStyleBackColor = True
        '
        'FrmParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(469, 340)
        Me.Controls.Add(Me.TcParameters)
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
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.Panel24.ResumeLayout(False)
        CType(Me.TbrCleanInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TcParameters.ResumeLayout(False)
        Me.TabEvaluation.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabUser.ResumeLayout(False)
        Me.TabRelease.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        CType(Me.TbrReleaseRegister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabClean.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel19 As Panel
    Friend WithEvents TxtUserDefaultPassword As TextBox
    Friend WithEvents LblUserDefaultPassword As Label
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
    Friend WithEvents LblCleanInterval As Label
    Friend WithEvents TbrCleanInterval As TrackBar
    Friend WithEvents TcParameters As TabControl
    Friend WithEvents TabEvaluation As TabPage
    Friend WithEvents TabClean As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtFooterMaintenancePlan As TextBox
    Friend WithEvents LblFooterMaintenancePlan As Label
    Friend WithEvents TabUser As TabPage
    Friend WithEvents TabRelease As TabPage
    Friend WithEvents Panel25 As Panel
    Friend WithEvents LblReleaseRegister As Label
    Friend WithEvents TbrReleaseRegister As TrackBar
End Class
