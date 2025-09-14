<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvaluationSettings
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.LblEvaluationDaysBeforeVisitAlert = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysBeforeVisitAlert = New ControlLibrary.DecimalBox()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.LblEvaluationDaysBeforeMaintenanceAlert = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysBeforeMaintenanceAlert = New ControlLibrary.DecimalBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblEvaluationMonthsBeforeRecordDeletion = New System.Windows.Forms.Label()
        Me.DbxEvaluationMonthsBeforeRecordDeletion = New ControlLibrary.DecimalBox()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel26.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.PnButtons.TabIndex = 8
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(370, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 2
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
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.Color.White
        Me.Panel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel26.Controls.Add(Me.LblEvaluationDaysBeforeVisitAlert)
        Me.Panel26.Controls.Add(Me.DbxEvaluationDaysBeforeVisitAlert)
        Me.Panel26.Location = New System.Drawing.Point(12, 63)
        Me.Panel26.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel26.Size = New System.Drawing.Size(450, 31)
        Me.Panel26.TabIndex = 10
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
        Me.Panel23.Location = New System.Drawing.Point(12, 19)
        Me.Panel23.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel23.Size = New System.Drawing.Size(450, 31)
        Me.Panel23.TabIndex = 9
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblEvaluationMonthsBeforeRecordDeletion)
        Me.Panel1.Controls.Add(Me.DbxEvaluationMonthsBeforeRecordDeletion)
        Me.Panel1.Location = New System.Drawing.Point(12, 107)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(450, 31)
        Me.Panel1.TabIndex = 10
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
        'FrmEvaluationSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 191)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel26)
        Me.Controls.Add(Me.Panel23)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEvaluationSettings"
        Me.ShowIcon = False
        Me.Text = "Avaliação"
        Me.PnButtons.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents Panel26 As Panel
    Friend WithEvents LblEvaluationDaysBeforeVisitAlert As Label
    Friend WithEvents DbxEvaluationDaysBeforeVisitAlert As ControlLibrary.DecimalBox
    Friend WithEvents Panel23 As Panel
    Friend WithEvents LblEvaluationDaysBeforeMaintenanceAlert As Label
    Friend WithEvents DbxEvaluationDaysBeforeMaintenanceAlert As ControlLibrary.DecimalBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblEvaluationMonthsBeforeRecordDeletion As Label
    Friend WithEvents DbxEvaluationMonthsBeforeRecordDeletion As ControlLibrary.DecimalBox
End Class
