<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvaluationPart
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.LblItem = New System.Windows.Forms.Label()
        Me.LblCapacity = New System.Windows.Forms.Label()
        Me.DbxCapacity = New ControlLibrary.DecimalBox()
        Me.CbxSold = New System.Windows.Forms.CheckBox()
        Me.CbxLost = New System.Windows.Forms.CheckBox()
        Me.TxtItem = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 82)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(378, 44)
        Me.Panel1.TabIndex = 6
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(271, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(172, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Alterar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'LblItem
        '
        Me.LblItem.AutoSize = True
        Me.LblItem.Location = New System.Drawing.Point(12, 9)
        Me.LblItem.Name = "LblItem"
        Me.LblItem.Size = New System.Drawing.Size(37, 17)
        Me.LblItem.TabIndex = 0
        Me.LblItem.Text = "Item"
        '
        'LblCapacity
        '
        Me.LblCapacity.AutoSize = True
        Me.LblCapacity.Location = New System.Drawing.Point(276, 9)
        Me.LblCapacity.Name = "LblCapacity"
        Me.LblCapacity.Size = New System.Drawing.Size(79, 17)
        Me.LblCapacity.TabIndex = 2
        Me.LblCapacity.Text = "Cap. Atual"
        '
        'DbxCapacity
        '
        Me.DbxCapacity.DecimalOnly = True
        Me.DbxCapacity.DecimalPlaces = 0
        Me.DbxCapacity.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxCapacity.Location = New System.Drawing.Point(279, 29)
        Me.DbxCapacity.Name = "DbxCapacity"
        Me.DbxCapacity.Size = New System.Drawing.Size(85, 23)
        Me.DbxCapacity.TabIndex = 3
        Me.DbxCapacity.Text = "0"
        Me.DbxCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CbxSold
        '
        Me.CbxSold.AutoSize = True
        Me.CbxSold.Location = New System.Drawing.Point(12, 58)
        Me.CbxSold.Name = "CbxSold"
        Me.CbxSold.Size = New System.Drawing.Size(82, 21)
        Me.CbxSold.TabIndex = 4
        Me.CbxSold.Text = "Vendido"
        Me.CbxSold.UseVisualStyleBackColor = True
        '
        'CbxLost
        '
        Me.CbxLost.AutoSize = True
        Me.CbxLost.Location = New System.Drawing.Point(100, 58)
        Me.CbxLost.Name = "CbxLost"
        Me.CbxLost.Size = New System.Drawing.Size(77, 21)
        Me.CbxLost.TabIndex = 5
        Me.CbxLost.Text = "Perdido"
        Me.CbxLost.UseVisualStyleBackColor = True
        '
        'TxtItem
        '
        Me.TxtItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtItem.Location = New System.Drawing.Point(12, 29)
        Me.TxtItem.Name = "TxtItem"
        Me.TxtItem.ReadOnly = True
        Me.TxtItem.Size = New System.Drawing.Size(261, 23)
        Me.TxtItem.TabIndex = 1
        Me.TxtItem.TabStop = False
        '
        'FrmEvaluationPart
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(378, 126)
        Me.Controls.Add(Me.TxtItem)
        Me.Controls.Add(Me.CbxLost)
        Me.Controls.Add(Me.CbxSold)
        Me.Controls.Add(Me.DbxCapacity)
        Me.Controls.Add(Me.LblCapacity)
        Me.Controls.Add(Me.LblItem)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluationPart"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item da Avaliação"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblItem As Label
    Friend WithEvents DbxCapacity As ControlLibrary.DecimalBox
    Friend WithEvents LblCapacity As Label
    Friend WithEvents CbxSold As CheckBox
    Friend WithEvents CbxLost As CheckBox
    Friend WithEvents TxtItem As TextBox
End Class
