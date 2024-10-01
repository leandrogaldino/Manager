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
        Me.LblEvaluationDaysToAlertVisit = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysToAlertVisit = New ControlLibrary.DecimalBox()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.LblEvaluationDaysToAlertMaintenance = New System.Windows.Forms.Label()
        Me.DbxEvaluationDaysToAlertMaintenance = New ControlLibrary.DecimalBox()
        Me.PnButtons.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel26.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 104)
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
        Me.Panel26.Controls.Add(Me.LblEvaluationDaysToAlertVisit)
        Me.Panel26.Controls.Add(Me.DbxEvaluationDaysToAlertVisit)
        Me.Panel26.Location = New System.Drawing.Point(12, 63)
        Me.Panel26.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel26.Size = New System.Drawing.Size(450, 31)
        Me.Panel26.TabIndex = 10
        '
        'LblEvaluationDaysToAlertVisit
        '
        Me.LblEvaluationDaysToAlertVisit.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationDaysToAlertVisit.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationDaysToAlertVisit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationDaysToAlertVisit.Name = "LblEvaluationDaysToAlertVisit"
        Me.LblEvaluationDaysToAlertVisit.Size = New System.Drawing.Size(154, 29)
        Me.LblEvaluationDaysToAlertVisit.TabIndex = 0
        Me.LblEvaluationDaysToAlertVisit.Text = "Dias para alertar visita"
        Me.LblEvaluationDaysToAlertVisit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationDaysToAlertVisit
        '
        Me.DbxEvaluationDaysToAlertVisit.DecimalOnly = True
        Me.DbxEvaluationDaysToAlertVisit.DecimalPlaces = 0
        Me.DbxEvaluationDaysToAlertVisit.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationDaysToAlertVisit.Location = New System.Drawing.Point(241, 3)
        Me.DbxEvaluationDaysToAlertVisit.Name = "DbxEvaluationDaysToAlertVisit"
        Me.DbxEvaluationDaysToAlertVisit.Size = New System.Drawing.Size(204, 23)
        Me.DbxEvaluationDaysToAlertVisit.TabIndex = 1
        Me.DbxEvaluationDaysToAlertVisit.Text = "0"
        Me.DbxEvaluationDaysToAlertVisit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.White
        Me.Panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel23.Controls.Add(Me.LblEvaluationDaysToAlertMaintenance)
        Me.Panel23.Controls.Add(Me.DbxEvaluationDaysToAlertMaintenance)
        Me.Panel23.Location = New System.Drawing.Point(12, 19)
        Me.Panel23.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel23.Size = New System.Drawing.Size(450, 31)
        Me.Panel23.TabIndex = 9
        '
        'LblEvaluationDaysToAlertMaintenance
        '
        Me.LblEvaluationDaysToAlertMaintenance.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblEvaluationDaysToAlertMaintenance.Location = New System.Drawing.Point(4, 0)
        Me.LblEvaluationDaysToAlertMaintenance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEvaluationDaysToAlertMaintenance.Name = "LblEvaluationDaysToAlertMaintenance"
        Me.LblEvaluationDaysToAlertMaintenance.Size = New System.Drawing.Size(206, 29)
        Me.LblEvaluationDaysToAlertMaintenance.TabIndex = 0
        Me.LblEvaluationDaysToAlertMaintenance.Text = "Dias para alertar manutenção"
        Me.LblEvaluationDaysToAlertMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxEvaluationDaysToAlertMaintenance
        '
        Me.DbxEvaluationDaysToAlertMaintenance.DecimalOnly = True
        Me.DbxEvaluationDaysToAlertMaintenance.DecimalPlaces = 0
        Me.DbxEvaluationDaysToAlertMaintenance.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxEvaluationDaysToAlertMaintenance.Location = New System.Drawing.Point(241, 3)
        Me.DbxEvaluationDaysToAlertMaintenance.Name = "DbxEvaluationDaysToAlertMaintenance"
        Me.DbxEvaluationDaysToAlertMaintenance.Size = New System.Drawing.Size(204, 23)
        Me.DbxEvaluationDaysToAlertMaintenance.TabIndex = 1
        Me.DbxEvaluationDaysToAlertMaintenance.Text = "0"
        Me.DbxEvaluationDaysToAlertMaintenance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmEvaluationSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(474, 148)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents Panel26 As Panel
    Friend WithEvents LblEvaluationDaysToAlertVisit As Label
    Friend WithEvents DbxEvaluationDaysToAlertVisit As ControlLibrary.DecimalBox
    Friend WithEvents Panel23 As Panel
    Friend WithEvents LblEvaluationDaysToAlertMaintenance As Label
    Friend WithEvents DbxEvaluationDaysToAlertMaintenance As ControlLibrary.DecimalBox
End Class
