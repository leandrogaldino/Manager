<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRequestSheet
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
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CbxShowReturned = New System.Windows.Forms.CheckBox()
        Me.CbxShowPending = New System.Windows.Forms.CheckBox()
        Me.CbxShowLossed = New System.Windows.Forms.CheckBox()
        Me.CbxShowApplied = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.CbxShowCode = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbxShowCode)
        Me.GroupBox1.Controls.Add(Me.CbxShowReturned)
        Me.GroupBox1.Controls.Add(Me.CbxShowPending)
        Me.GroupBox1.Controls.Add(Me.CbxShowLossed)
        Me.GroupBox1.Controls.Add(Me.CbxShowApplied)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 156)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções"
        '
        'CbxShowReturned
        '
        Me.CbxShowReturned.AutoSize = True
        Me.CbxShowReturned.Checked = True
        Me.CbxShowReturned.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowReturned.Location = New System.Drawing.Point(6, 49)
        Me.CbxShowReturned.Name = "CbxShowReturned"
        Me.CbxShowReturned.Size = New System.Drawing.Size(145, 21)
        Me.CbxShowReturned.TabIndex = 0
        Me.CbxShowReturned.Text = "Mostrar Devolvido"
        Me.CbxShowReturned.UseVisualStyleBackColor = True
        '
        'CbxShowPending
        '
        Me.CbxShowPending.AutoSize = True
        Me.CbxShowPending.Checked = True
        Me.CbxShowPending.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowPending.Location = New System.Drawing.Point(6, 130)
        Me.CbxShowPending.Name = "CbxShowPending"
        Me.CbxShowPending.Size = New System.Drawing.Size(138, 21)
        Me.CbxShowPending.TabIndex = 2
        Me.CbxShowPending.Text = "Mostrar A Acertar"
        Me.CbxShowPending.UseVisualStyleBackColor = True
        '
        'CbxShowLossed
        '
        Me.CbxShowLossed.AutoSize = True
        Me.CbxShowLossed.Checked = True
        Me.CbxShowLossed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowLossed.Location = New System.Drawing.Point(6, 103)
        Me.CbxShowLossed.Name = "CbxShowLossed"
        Me.CbxShowLossed.Size = New System.Drawing.Size(128, 21)
        Me.CbxShowLossed.TabIndex = 2
        Me.CbxShowLossed.Text = "Mostrar Perdido"
        Me.CbxShowLossed.UseVisualStyleBackColor = True
        '
        'CbxShowApplied
        '
        Me.CbxShowApplied.AutoSize = True
        Me.CbxShowApplied.Checked = True
        Me.CbxShowApplied.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowApplied.Location = New System.Drawing.Point(6, 76)
        Me.CbxShowApplied.Name = "CbxShowApplied"
        Me.CbxShowApplied.Size = New System.Drawing.Size(137, 21)
        Me.CbxShowApplied.TabIndex = 1
        Me.CbxShowApplied.Text = "Mostrar Aplicado"
        Me.CbxShowApplied.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnGenerate)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 177)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 44)
        Me.Panel1.TabIndex = 1
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Location = New System.Drawing.Point(12, 7)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(95, 30)
        Me.BtnGenerate.TabIndex = 0
        Me.BtnGenerate.Text = "Gerar"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'CbxShowCode
        '
        Me.CbxShowCode.AutoSize = True
        Me.CbxShowCode.Checked = True
        Me.CbxShowCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowCode.Location = New System.Drawing.Point(6, 22)
        Me.CbxShowCode.Name = "CbxShowCode"
        Me.CbxShowCode.Size = New System.Drawing.Size(128, 21)
        Me.CbxShowCode.TabIndex = 0
        Me.CbxShowCode.Text = "Mostrar Código"
        Me.CbxShowCode.UseVisualStyleBackColor = True
        '
        'FrmRequestSheet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(220, 221)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRequestSheet"
        Me.ShowIcon = False
        Me.Text = "Folha de Requisição"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents CbxShowApplied As CheckBox
    Friend WithEvents CbxShowReturned As CheckBox
    Friend WithEvents CbxShowLossed As CheckBox
    Friend WithEvents CbxShowPending As CheckBox
    Friend WithEvents CbxShowCode As CheckBox
End Class
