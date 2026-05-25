<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEvaluationTreatment
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
        Me.components = New System.ComponentModel.Container()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.LvPictures = New System.Windows.Forms.ListView()
        Me.LblPicture = New System.Windows.Forms.Label()
        Me.CbxCode = New CoreSuite.Controls.CentralizedComboBox()
        Me.LblCode = New System.Windows.Forms.Label()
        Me.CbxAll = New System.Windows.Forms.CheckBox()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(170, 7)
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
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnGenerate)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 325)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(277, 44)
        Me.Panel1.TabIndex = 1
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Location = New System.Drawing.Point(69, 7)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(95, 30)
        Me.BtnGenerate.TabIndex = 0
        Me.BtnGenerate.Text = "Gerar"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'LvPictures
        '
        Me.LvPictures.HideSelection = False
        Me.LvPictures.Location = New System.Drawing.Point(15, 76)
        Me.LvPictures.Name = "LvPictures"
        Me.LvPictures.Size = New System.Drawing.Size(246, 241)
        Me.LvPictures.TabIndex = 4
        Me.LvPictures.UseCompatibleStateImageBehavior = False
        '
        'LblPicture
        '
        Me.LblPicture.AutoSize = True
        Me.LblPicture.Location = New System.Drawing.Point(12, 56)
        Me.LblPicture.Name = "LblPicture"
        Me.LblPicture.Size = New System.Drawing.Size(166, 17)
        Me.LblPicture.TabIndex = 6
        Me.LblPicture.Text = "Incluir Fotos no Relatório"
        '
        'CbxCode
        '
        Me.CbxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCode.FormattingEnabled = True
        Me.CbxCode.Items.AddRange(New Object() {"ID", "Fornecedor"})
        Me.CbxCode.Location = New System.Drawing.Point(15, 29)
        Me.CbxCode.Name = "CbxCode"
        Me.CbxCode.Size = New System.Drawing.Size(246, 24)
        Me.CbxCode.TabIndex = 7
        '
        'LblCode
        '
        Me.LblCode.AutoSize = True
        Me.LblCode.Location = New System.Drawing.Point(12, 9)
        Me.LblCode.Name = "LblCode"
        Me.LblCode.Size = New System.Drawing.Size(114, 17)
        Me.LblCode.TabIndex = 6
        Me.LblCode.Text = "Código Produto"
        '
        'CbxAll
        '
        Me.CbxAll.AutoSize = True
        Me.CbxAll.Location = New System.Drawing.Point(245, 59)
        Me.CbxAll.Name = "CbxAll"
        Me.CbxAll.Size = New System.Drawing.Size(15, 14)
        Me.CbxAll.TabIndex = 8
        Me.CbxAll.UseVisualStyleBackColor = True
        '
        'FrmEvaluationTreatment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(277, 369)
        Me.Controls.Add(Me.CbxAll)
        Me.Controls.Add(Me.CbxCode)
        Me.Controls.Add(Me.LblCode)
        Me.Controls.Add(Me.LblPicture)
        Me.Controls.Add(Me.LvPictures)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluationTreatment"
        Me.ShowIcon = False
        Me.Text = "Relatório de Atendimento"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents BtnClose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents LvPictures As ListView
    Friend WithEvents LblPicture As Label
    Friend WithEvents CbxCode As CoreSuite.Controls.CentralizedComboBox
    Friend WithEvents LblCode As Label
    Friend WithEvents CbxAll As CheckBox
End Class
