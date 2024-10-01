<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCashSheet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCashSheet))
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblFlow = New System.Windows.Forms.Label()
        Me.CbxFlow = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DbxFinalDate = New ControlLibrary.DateBox()
        Me.LblFinalDate = New System.Windows.Forms.Label()
        Me.CbxShowDocumentNumber = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DbxInitialDate = New ControlLibrary.DateBox()
        Me.LblInitialDate = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(172, 7)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.CbxShowDocumentNumber)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 155)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.LblFlow)
        Me.Panel4.Controls.Add(Me.CbxFlow)
        Me.Panel4.Location = New System.Drawing.Point(6, 29)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(246, 31)
        Me.Panel4.TabIndex = 0
        '
        'LblFlow
        '
        Me.LblFlow.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblFlow.Location = New System.Drawing.Point(4, 0)
        Me.LblFlow.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LblFlow.Name = "LblFlow"
        Me.LblFlow.Size = New System.Drawing.Size(41, 29)
        Me.LblFlow.TabIndex = 0
        Me.LblFlow.Text = "Fluxo"
        Me.LblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbxFlow
        '
        Me.CbxFlow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFlow.FormattingEnabled = True
        Me.CbxFlow.Location = New System.Drawing.Point(53, 2)
        Me.CbxFlow.Margin = New System.Windows.Forms.Padding(4)
        Me.CbxFlow.MaxDropDownItems = 3
        Me.CbxFlow.Name = "CbxFlow"
        Me.CbxFlow.Size = New System.Drawing.Size(187, 25)
        Me.CbxFlow.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.DbxFinalDate)
        Me.Panel3.Controls.Add(Me.LblFinalDate)
        Me.Panel3.Location = New System.Drawing.Point(6, 117)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(246, 31)
        Me.Panel3.TabIndex = 2
        '
        'DbxFinalDate
        '
        Me.DbxFinalDate.ButtonImage = CType(resources.GetObject("DbxFinalDate.ButtonImage"), System.Drawing.Image)
        Me.DbxFinalDate.Location = New System.Drawing.Point(140, 3)
        Me.DbxFinalDate.Name = "DbxFinalDate"
        Me.DbxFinalDate.Size = New System.Drawing.Size(100, 23)
        Me.DbxFinalDate.TabIndex = 1
        '
        'LblFinalDate
        '
        Me.LblFinalDate.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblFinalDate.Location = New System.Drawing.Point(4, 0)
        Me.LblFinalDate.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LblFinalDate.Name = "LblFinalDate"
        Me.LblFinalDate.Size = New System.Drawing.Size(75, 29)
        Me.LblFinalDate.TabIndex = 0
        Me.LblFinalDate.Text = "Data Final"
        Me.LblFinalDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbxShowDocumentNumber
        '
        Me.CbxShowDocumentNumber.AutoSize = True
        Me.CbxShowDocumentNumber.Checked = True
        Me.CbxShowDocumentNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowDocumentNumber.Location = New System.Drawing.Point(6, 252)
        Me.CbxShowDocumentNumber.Name = "CbxShowDocumentNumber"
        Me.CbxShowDocumentNumber.Size = New System.Drawing.Size(197, 21)
        Me.CbxShowDocumentNumber.TabIndex = 9
        Me.CbxShowDocumentNumber.Text = "Mostrar Nº do Documento"
        Me.CbxShowDocumentNumber.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DbxInitialDate)
        Me.Panel2.Controls.Add(Me.LblInitialDate)
        Me.Panel2.Location = New System.Drawing.Point(6, 73)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(246, 31)
        Me.Panel2.TabIndex = 1
        '
        'DbxInitialDate
        '
        Me.DbxInitialDate.ButtonImage = CType(resources.GetObject("DbxInitialDate.ButtonImage"), System.Drawing.Image)
        Me.DbxInitialDate.Location = New System.Drawing.Point(141, 3)
        Me.DbxInitialDate.Name = "DbxInitialDate"
        Me.DbxInitialDate.Size = New System.Drawing.Size(100, 23)
        Me.DbxInitialDate.TabIndex = 1
        '
        'LblInitialDate
        '
        Me.LblInitialDate.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblInitialDate.Location = New System.Drawing.Point(4, 0)
        Me.LblInitialDate.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LblInitialDate.Name = "LblInitialDate"
        Me.LblInitialDate.Size = New System.Drawing.Size(82, 29)
        Me.LblInitialDate.TabIndex = 0
        Me.LblInitialDate.Text = "Data Inicial"
        Me.LblInitialDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnGenerate)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 172)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(279, 44)
        Me.Panel1.TabIndex = 1
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Enabled = False
        Me.BtnGenerate.Location = New System.Drawing.Point(71, 7)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(95, 30)
        Me.BtnGenerate.TabIndex = 0
        Me.BtnGenerate.Text = "Gerar"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'FrmCashSheet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(279, 216)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCashSheet"
        Me.ShowIcon = False
        Me.Text = "Caixa - Despesa Por Responsável"
        Me.TopMost = True
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents BtnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CbxShowDocumentNumber As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LblFlow As Label
    Friend WithEvents CbxFlow As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblFinalDate As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblInitialDate As Label
    Friend WithEvents DbxFinalDate As ControlLibrary.DateBox
    Friend WithEvents DbxInitialDate As ControlLibrary.DateBox
End Class
