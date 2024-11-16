<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvaluationManagementPanelExport
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
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.CbxInDay = New System.Windows.Forms.CheckBox()
        Me.CbxOverdue = New System.Windows.Forms.CheckBox()
        Me.CbxNeverVisited = New System.Windows.Forms.CheckBox()
        Me.CbxToOverdue = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CbxToVisit = New System.Windows.Forms.CheckBox()
        Me.CbxTotal = New System.Windows.Forms.CheckBox()
        Me.CbxUnitOverdue = New System.Windows.Forms.CheckBox()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(113, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnGenerate)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 234)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 44)
        Me.Panel1.TabIndex = 1
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Enabled = False
        Me.BtnGenerate.Location = New System.Drawing.Point(12, 7)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(95, 30)
        Me.BtnGenerate.TabIndex = 0
        Me.BtnGenerate.Text = "Gerar"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'CbxInDay
        '
        Me.CbxInDay.AutoSize = True
        Me.CbxInDay.Location = New System.Drawing.Point(9, 22)
        Me.CbxInDay.Name = "CbxInDay"
        Me.CbxInDay.Size = New System.Drawing.Size(73, 21)
        Me.CbxInDay.TabIndex = 0
        Me.CbxInDay.Text = "Em Dia"
        Me.CbxInDay.UseVisualStyleBackColor = True
        '
        'CbxOverdue
        '
        Me.CbxOverdue.AutoSize = True
        Me.CbxOverdue.Location = New System.Drawing.Point(9, 76)
        Me.CbxOverdue.Name = "CbxOverdue"
        Me.CbxOverdue.Size = New System.Drawing.Size(81, 21)
        Me.CbxOverdue.TabIndex = 2
        Me.CbxOverdue.Text = "Vencido"
        Me.CbxOverdue.UseVisualStyleBackColor = True
        '
        'CbxNeverVisited
        '
        Me.CbxNeverVisited.AutoSize = True
        Me.CbxNeverVisited.Location = New System.Drawing.Point(9, 130)
        Me.CbxNeverVisited.Name = "CbxNeverVisited"
        Me.CbxNeverVisited.Size = New System.Drawing.Size(126, 21)
        Me.CbxNeverVisited.TabIndex = 4
        Me.CbxNeverVisited.Text = "Nunca Visitado"
        Me.CbxNeverVisited.UseVisualStyleBackColor = True
        '
        'CbxToOverdue
        '
        Me.CbxToOverdue.AutoSize = True
        Me.CbxToOverdue.Location = New System.Drawing.Point(9, 49)
        Me.CbxToOverdue.Name = "CbxToOverdue"
        Me.CbxToOverdue.Size = New System.Drawing.Size(85, 21)
        Me.CbxToOverdue.TabIndex = 1
        Me.CbxToOverdue.Text = "A Vencer"
        Me.CbxToOverdue.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbxToOverdue)
        Me.GroupBox1.Controls.Add(Me.CbxToVisit)
        Me.GroupBox1.Controls.Add(Me.CbxUnitOverdue)
        Me.GroupBox1.Controls.Add(Me.CbxTotal)
        Me.GroupBox1.Controls.Add(Me.CbxNeverVisited)
        Me.GroupBox1.Controls.Add(Me.CbxOverdue)
        Me.GroupBox1.Controls.Add(Me.CbxInDay)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 211)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções"
        '
        'CbxToVisit
        '
        Me.CbxToVisit.AutoSize = True
        Me.CbxToVisit.Location = New System.Drawing.Point(9, 157)
        Me.CbxToVisit.Name = "CbxToVisit"
        Me.CbxToVisit.Size = New System.Drawing.Size(78, 21)
        Me.CbxToVisit.TabIndex = 3
        Me.CbxToVisit.Text = "A Visitar"
        Me.CbxToVisit.UseVisualStyleBackColor = True
        '
        'CbxTotal
        '
        Me.CbxTotal.AutoSize = True
        Me.CbxTotal.Location = New System.Drawing.Point(9, 184)
        Me.CbxTotal.Name = "CbxTotal"
        Me.CbxTotal.Size = New System.Drawing.Size(64, 21)
        Me.CbxTotal.TabIndex = 5
        Me.CbxTotal.Text = "Todos"
        Me.CbxTotal.UseVisualStyleBackColor = True
        '
        'CbxUnitOverdue
        '
        Me.CbxUnitOverdue.AutoSize = True
        Me.CbxUnitOverdue.Location = New System.Drawing.Point(9, 103)
        Me.CbxUnitOverdue.Name = "CbxUnitOverdue"
        Me.CbxUnitOverdue.Size = New System.Drawing.Size(149, 21)
        Me.CbxUnitOverdue.TabIndex = 5
        Me.CbxUnitOverdue.Text = "Unidades Vencidas"
        Me.CbxUnitOverdue.UseVisualStyleBackColor = True
        '
        'FrmEvaluationManagementPanelExport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(220, 278)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluationManagementPanelExport"
        Me.ShowIcon = False
        Me.Text = "Exportar Painel"
        Me.TopMost = True
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents BtnClose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CbxToOverdue As CheckBox
    Friend WithEvents CbxNeverVisited As CheckBox
    Friend WithEvents CbxOverdue As CheckBox
    Friend WithEvents CbxInDay As CheckBox
    Friend WithEvents CbxToVisit As CheckBox
    Friend WithEvents CbxTotal As CheckBox
    Friend WithEvents CbxUnitOverdue As CheckBox
End Class
