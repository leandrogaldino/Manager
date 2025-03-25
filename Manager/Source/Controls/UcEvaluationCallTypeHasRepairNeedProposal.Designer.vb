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
        Me.CbxCallType = New ControlLibrary.CentralizedComboBox()
        Me.LblCallType = New System.Windows.Forms.Label()
        Me.PnHasRepair = New System.Windows.Forms.Panel()
        Me.CbxHasRepairYes = New System.Windows.Forms.CheckBox()
        Me.CbxHasRepairNo = New System.Windows.Forms.CheckBox()
        Me.LblHasRepair = New System.Windows.Forms.Label()
        Me.PnNeedProposal = New System.Windows.Forms.Panel()
        Me.CbxNeedProposalYes = New System.Windows.Forms.CheckBox()
        Me.CbxNeedProposalNo = New System.Windows.Forms.CheckBox()
        Me.LblNeedProposal = New System.Windows.Forms.Label()
        Me.PnVisitType.SuspendLayout()
        Me.PnHasRepair.SuspendLayout()
        Me.PnNeedProposal.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnVisitType
        '
        Me.PnVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnVisitType.Controls.Add(Me.CbxCallType)
        Me.PnVisitType.Controls.Add(Me.LblCallType)
        Me.PnVisitType.Location = New System.Drawing.Point(3, 3)
        Me.PnVisitType.Name = "PnVisitType"
        Me.PnVisitType.Size = New System.Drawing.Size(374, 39)
        Me.PnVisitType.TabIndex = 0
        '
        'CbxCallType
        '
        Me.CbxCallType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxCallType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCallType.FormattingEnabled = True
        Me.CbxCallType.Location = New System.Drawing.Point(222, 6)
        Me.CbxCallType.Margin = New System.Windows.Forms.Padding(8)
        Me.CbxCallType.Name = "CbxCallType"
        Me.CbxCallType.Size = New System.Drawing.Size(143, 24)
        Me.CbxCallType.TabIndex = 1
        '
        'LblCallType
        '
        Me.LblCallType.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblCallType.Location = New System.Drawing.Point(0, 0)
        Me.LblCallType.Name = "LblCallType"
        Me.LblCallType.Size = New System.Drawing.Size(211, 37)
        Me.LblCallType.TabIndex = 0
        Me.LblCallType.Text = "Tipo de Visita:"
        Me.LblCallType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnHasRepair
        '
        Me.PnHasRepair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnHasRepair.Controls.Add(Me.CbxHasRepairYes)
        Me.PnHasRepair.Controls.Add(Me.CbxHasRepairNo)
        Me.PnHasRepair.Controls.Add(Me.LblHasRepair)
        Me.PnHasRepair.Location = New System.Drawing.Point(3, 48)
        Me.PnHasRepair.Name = "PnHasRepair"
        Me.PnHasRepair.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.PnHasRepair.Size = New System.Drawing.Size(374, 39)
        Me.PnHasRepair.TabIndex = 1
        '
        'CbxHasRepairYes
        '
        Me.CbxHasRepairYes.Dock = System.Windows.Forms.DockStyle.Right
        Me.CbxHasRepairYes.Location = New System.Drawing.Point(264, 0)
        Me.CbxHasRepairYes.Name = "CbxHasRepairYes"
        Me.CbxHasRepairYes.Size = New System.Drawing.Size(49, 37)
        Me.CbxHasRepairYes.TabIndex = 1
        Me.CbxHasRepairYes.Tag = "HasRepairYes"
        Me.CbxHasRepairYes.Text = "Sim"
        Me.CbxHasRepairYes.UseVisualStyleBackColor = True
        '
        'CbxHasRepairNo
        '
        Me.CbxHasRepairNo.Dock = System.Windows.Forms.DockStyle.Right
        Me.CbxHasRepairNo.Location = New System.Drawing.Point(313, 0)
        Me.CbxHasRepairNo.Name = "CbxHasRepairNo"
        Me.CbxHasRepairNo.Size = New System.Drawing.Size(55, 37)
        Me.CbxHasRepairNo.TabIndex = 2
        Me.CbxHasRepairNo.Tag = "HasRepairNo"
        Me.CbxHasRepairNo.Text = "Não"
        Me.CbxHasRepairNo.UseVisualStyleBackColor = True
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
        Me.PnNeedProposal.Controls.Add(Me.CbxNeedProposalYes)
        Me.PnNeedProposal.Controls.Add(Me.CbxNeedProposalNo)
        Me.PnNeedProposal.Controls.Add(Me.LblNeedProposal)
        Me.PnNeedProposal.Location = New System.Drawing.Point(3, 93)
        Me.PnNeedProposal.Name = "PnNeedProposal"
        Me.PnNeedProposal.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.PnNeedProposal.Size = New System.Drawing.Size(374, 39)
        Me.PnNeedProposal.TabIndex = 2
        '
        'CbxNeedProposalYes
        '
        Me.CbxNeedProposalYes.Dock = System.Windows.Forms.DockStyle.Right
        Me.CbxNeedProposalYes.Location = New System.Drawing.Point(264, 0)
        Me.CbxNeedProposalYes.Name = "CbxNeedProposalYes"
        Me.CbxNeedProposalYes.Size = New System.Drawing.Size(49, 37)
        Me.CbxNeedProposalYes.TabIndex = 1
        Me.CbxNeedProposalYes.Tag = "NeedProposalYes"
        Me.CbxNeedProposalYes.Text = "Sim"
        Me.CbxNeedProposalYes.UseVisualStyleBackColor = True
        '
        'CbxNeedProposalNo
        '
        Me.CbxNeedProposalNo.Dock = System.Windows.Forms.DockStyle.Right
        Me.CbxNeedProposalNo.Location = New System.Drawing.Point(313, 0)
        Me.CbxNeedProposalNo.Name = "CbxNeedProposalNo"
        Me.CbxNeedProposalNo.Size = New System.Drawing.Size(55, 37)
        Me.CbxNeedProposalNo.TabIndex = 2
        Me.CbxNeedProposalNo.Tag = "NeedProposalNo"
        Me.CbxNeedProposalNo.Text = "Não"
        Me.CbxNeedProposalNo.UseVisualStyleBackColor = True
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
    Private WithEvents CbxCallType As ControlLibrary.CentralizedComboBox
    Friend WithEvents CbxHasRepairYes As CheckBox
    Friend WithEvents CbxHasRepairNo As CheckBox
    Friend WithEvents CbxNeedProposalYes As CheckBox
    Friend WithEvents CbxNeedProposalNo As CheckBox
End Class
