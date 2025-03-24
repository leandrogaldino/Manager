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
        Me.LblHasRepair = New System.Windows.Forms.Label()
        Me.PnNeedProposal = New System.Windows.Forms.Panel()
        Me.LblNeedProposal = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
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
        Me.PnHasRepair.Controls.Add(Me.CheckBox1)
        Me.PnHasRepair.Controls.Add(Me.CheckBox2)
        Me.PnHasRepair.Controls.Add(Me.LblHasRepair)
        Me.PnHasRepair.Location = New System.Drawing.Point(3, 48)
        Me.PnHasRepair.Name = "PnHasRepair"
        Me.PnHasRepair.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.PnHasRepair.Size = New System.Drawing.Size(374, 39)
        Me.PnHasRepair.TabIndex = 3
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
        Me.PnNeedProposal.Controls.Add(Me.CheckBox3)
        Me.PnNeedProposal.Controls.Add(Me.CheckBox4)
        Me.PnNeedProposal.Controls.Add(Me.LblNeedProposal)
        Me.PnNeedProposal.Location = New System.Drawing.Point(3, 93)
        Me.PnNeedProposal.Name = "PnNeedProposal"
        Me.PnNeedProposal.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.PnNeedProposal.Size = New System.Drawing.Size(374, 39)
        Me.PnNeedProposal.TabIndex = 6
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
        'CheckBox4
        '
        Me.CheckBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBox4.Location = New System.Drawing.Point(313, 0)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(55, 37)
        Me.CheckBox4.TabIndex = 2
        Me.CheckBox4.Text = "Não"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBox3.Location = New System.Drawing.Point(264, 0)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(49, 37)
        Me.CheckBox3.TabIndex = 3
        Me.CheckBox3.Text = "Sim"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBox1.Location = New System.Drawing.Point(264, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(49, 37)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Sim"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckBox2.Location = New System.Drawing.Point(313, 0)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(55, 37)
        Me.CheckBox2.TabIndex = 4
        Me.CheckBox2.Text = "Não"
        Me.CheckBox2.UseVisualStyleBackColor = True
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
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
End Class
