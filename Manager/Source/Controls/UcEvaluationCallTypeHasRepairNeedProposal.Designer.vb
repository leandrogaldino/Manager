<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcEvaluationCallTypeHasRepairNeedProposal
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
        Me.PnVisitType = New System.Windows.Forms.Panel()
        Me.CbxVisitType = New ControlLibrary.CentralizedComboBox()
        Me.LblCallType = New System.Windows.Forms.Label()
        Me.PnHasRepair = New System.Windows.Forms.Panel()
        Me.CbxHasRepair = New ControlLibrary.CentralizedComboBox()
        Me.LblHasRepair = New System.Windows.Forms.Label()
        Me.PnNeedProposal = New System.Windows.Forms.Panel()
        Me.CbxNeedProposal = New ControlLibrary.CentralizedComboBox()
        Me.LblNeedProposal = New System.Windows.Forms.Label()
        Me.PnVisitType.SuspendLayout()
        Me.PnHasRepair.SuspendLayout()
        Me.PnNeedProposal.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnVisitType
        '
        Me.PnVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnVisitType.Controls.Add(Me.CbxVisitType)
        Me.PnVisitType.Controls.Add(Me.LblCallType)
        Me.PnVisitType.Location = New System.Drawing.Point(3, 3)
        Me.PnVisitType.Name = "PnVisitType"
        Me.PnVisitType.Size = New System.Drawing.Size(374, 39)
        Me.PnVisitType.TabIndex = 0
        '
        'CbxVisitType
        '
        Me.CbxVisitType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxVisitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxVisitType.FormattingEnabled = True
        Me.CbxVisitType.Location = New System.Drawing.Point(222, 6)
        Me.CbxVisitType.Margin = New System.Windows.Forms.Padding(8)
        Me.CbxVisitType.Name = "CbxVisitType"
        Me.CbxVisitType.Size = New System.Drawing.Size(143, 24)
        Me.CbxVisitType.TabIndex = 2
        '
        'LblCallType
        '
        Me.LblCallType.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblCallType.Location = New System.Drawing.Point(0, 0)
        Me.LblCallType.Name = "LblCallType"
        Me.LblCallType.Size = New System.Drawing.Size(211, 37)
        Me.LblCallType.TabIndex = 1
        Me.LblCallType.Text = "Tipo de Visita:"
        Me.LblCallType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnHasRepair
        '
        Me.PnHasRepair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnHasRepair.Controls.Add(Me.CbxHasRepair)
        Me.PnHasRepair.Controls.Add(Me.LblHasRepair)
        Me.PnHasRepair.Location = New System.Drawing.Point(3, 48)
        Me.PnHasRepair.Name = "PnHasRepair"
        Me.PnHasRepair.Size = New System.Drawing.Size(374, 39)
        Me.PnHasRepair.TabIndex = 3
        '
        'CbxHasRepair
        '
        Me.CbxHasRepair.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxHasRepair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxHasRepair.FormattingEnabled = True
        Me.CbxHasRepair.Location = New System.Drawing.Point(221, 7)
        Me.CbxHasRepair.Margin = New System.Windows.Forms.Padding(8)
        Me.CbxHasRepair.Name = "CbxHasRepair"
        Me.CbxHasRepair.Size = New System.Drawing.Size(143, 24)
        Me.CbxHasRepair.TabIndex = 2
        '
        'LblHasRepair
        '
        Me.LblHasRepair.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblHasRepair.Location = New System.Drawing.Point(0, 0)
        Me.LblHasRepair.Name = "LblHasRepair"
        Me.LblHasRepair.Size = New System.Drawing.Size(211, 37)
        Me.LblHasRepair.TabIndex = 0
        Me.LblHasRepair.Text = "Houve Reparo:"
        Me.LblHasRepair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnNeedProposal
        '
        Me.PnNeedProposal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnNeedProposal.Controls.Add(Me.CbxNeedProposal)
        Me.PnNeedProposal.Controls.Add(Me.LblNeedProposal)
        Me.PnNeedProposal.Location = New System.Drawing.Point(3, 93)
        Me.PnNeedProposal.Name = "PnNeedProposal"
        Me.PnNeedProposal.Size = New System.Drawing.Size(374, 39)
        Me.PnNeedProposal.TabIndex = 6
        '
        'CbxNeedProposal
        '
        Me.CbxNeedProposal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxNeedProposal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxNeedProposal.FormattingEnabled = True
        Me.CbxNeedProposal.Location = New System.Drawing.Point(221, 7)
        Me.CbxNeedProposal.Margin = New System.Windows.Forms.Padding(8)
        Me.CbxNeedProposal.Name = "CbxNeedProposal"
        Me.CbxNeedProposal.Size = New System.Drawing.Size(143, 24)
        Me.CbxNeedProposal.TabIndex = 2
        '
        'LblNeedProposal
        '
        Me.LblNeedProposal.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblNeedProposal.Location = New System.Drawing.Point(0, 0)
        Me.LblNeedProposal.Name = "LblNeedProposal"
        Me.LblNeedProposal.Size = New System.Drawing.Size(211, 37)
        Me.LblNeedProposal.TabIndex = 0
        Me.LblNeedProposal.Text = "Proposta Necessária:"
        Me.LblNeedProposal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UcEvaluationCallTypeHasRepairNeedProposal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PnNeedProposal)
        Me.Controls.Add(Me.PnHasRepair)
        Me.Controls.Add(Me.PnVisitType)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcEvaluationCallTypeHasRepairNeedProposal"
        Me.Size = New System.Drawing.Size(380, 138)
        Me.PnVisitType.ResumeLayout(False)
        Me.PnHasRepair.ResumeLayout(False)
        Me.PnNeedProposal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents PnVisitType As Panel
    Private WithEvents LblCallType As Label
    Private WithEvents PnHasRepair As Panel
    Private WithEvents LblHasRepair As Label
    Private WithEvents PnNeedProposal As Panel
    Private WithEvents LblNeedProposal As Label
    Private WithEvents CbxVisitType As ControlLibrary.CentralizedComboBox
    Private WithEvents CbxHasRepair As ControlLibrary.CentralizedComboBox
    Private WithEvents CbxNeedProposal As ControlLibrary.CentralizedComboBox
End Class
