<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrmTreatment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCrmTreatment))
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.DbxNextContact = New ControlLibrary.DateBox()
        Me.DbxContact = New ControlLibrary.DateBox()
        Me.LblNextContact = New System.Windows.Forms.Label()
        Me.LblContact = New System.Windows.Forms.Label()
        Me.CbxContactType = New System.Windows.Forms.ComboBox()
        Me.LblContactType = New System.Windows.Forms.Label()
        Me.TxtSummary = New System.Windows.Forms.TextBox()
        Me.LblSummary = New System.Windows.Forms.Label()
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        Me.TsData.SuspendLayout()
        Me.SuspendLayout()
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(295, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(396, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 307)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 44)
        Me.Panel1.TabIndex = 9
        '
        'TsNavigation
        '
        Me.TsNavigation.AutoSize = False
        Me.TsNavigation.BackColor = System.Drawing.Color.White
        Me.TsNavigation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnLog})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(500, 25)
        Me.TsNavigation.TabIndex = 0
        Me.TsNavigation.Text = "ToolStrip2"
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Atendimento"
        '
        'BtnLog
        '
        Me.BtnLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLog.Image = Global.Manager.My.Resources.Resources.Log
        Me.BtnLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(23, 22)
        Me.BtnLog.Text = "Histórico"
        '
        'DbxNextContact
        '
        Me.DbxNextContact.ButtonImage = CType(resources.GetObject("DbxNextContact.ButtonImage"), System.Drawing.Image)
        Me.DbxNextContact.Location = New System.Drawing.Point(137, 70)
        Me.DbxNextContact.Name = "DbxNextContact"
        Me.DbxNextContact.Size = New System.Drawing.Size(119, 23)
        Me.DbxNextContact.TabIndex = 4
        '
        'DbxContact
        '
        Me.DbxContact.ButtonImage = CType(resources.GetObject("DbxContact.ButtonImage"), System.Drawing.Image)
        Me.DbxContact.Location = New System.Drawing.Point(12, 70)
        Me.DbxContact.Name = "DbxContact"
        Me.DbxContact.Size = New System.Drawing.Size(119, 23)
        Me.DbxContact.TabIndex = 2
        '
        'LblNextContact
        '
        Me.LblNextContact.AutoSize = True
        Me.LblNextContact.Location = New System.Drawing.Point(137, 50)
        Me.LblNextContact.Name = "LblNextContact"
        Me.LblNextContact.Size = New System.Drawing.Size(99, 17)
        Me.LblNextContact.TabIndex = 3
        Me.LblNextContact.Text = "Próx. Contato"
        '
        'LblContact
        '
        Me.LblContact.AutoSize = True
        Me.LblContact.Location = New System.Drawing.Point(12, 50)
        Me.LblContact.Name = "LblContact"
        Me.LblContact.Size = New System.Drawing.Size(64, 17)
        Me.LblContact.TabIndex = 1
        Me.LblContact.Text = "Contato"
        '
        'CbxContactType
        '
        Me.CbxContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxContactType.FormattingEnabled = True
        Me.CbxContactType.Location = New System.Drawing.Point(262, 68)
        Me.CbxContactType.Name = "CbxContactType"
        Me.CbxContactType.Size = New System.Drawing.Size(226, 25)
        Me.CbxContactType.TabIndex = 6
        '
        'LblContactType
        '
        Me.LblContactType.AutoSize = True
        Me.LblContactType.Location = New System.Drawing.Point(259, 50)
        Me.LblContactType.Name = "LblContactType"
        Me.LblContactType.Size = New System.Drawing.Size(94, 17)
        Me.LblContactType.TabIndex = 5
        Me.LblContactType.Text = "Tipo Contato"
        '
        'TxtSummary
        '
        Me.TxtSummary.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSummary.Location = New System.Drawing.Point(12, 116)
        Me.TxtSummary.Multiline = True
        Me.TxtSummary.Name = "TxtSummary"
        Me.TxtSummary.Size = New System.Drawing.Size(476, 180)
        Me.TxtSummary.TabIndex = 8
        '
        'LblSummary
        '
        Me.LblSummary.AutoSize = True
        Me.LblSummary.Location = New System.Drawing.Point(12, 96)
        Me.LblSummary.Name = "LblSummary"
        Me.LblSummary.Size = New System.Drawing.Size(59, 17)
        Me.LblSummary.TabIndex = 7
        Me.LblSummary.Text = "Resumo"
        '
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(500, 25)
        Me.TsData.TabIndex = 10
        Me.TsData.Text = "ToolStrip1"
        '
        'LblOrder
        '
        Me.LblOrder.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrder.Name = "LblOrder"
        Me.LblOrder.Size = New System.Drawing.Size(56, 22)
        Me.LblOrder.Text = "Ordem:"
        '
        'LblOrderValue
        '
        Me.LblOrderValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblOrderValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblOrderValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblOrderValue.Name = "LblOrderValue"
        Me.LblOrderValue.Size = New System.Drawing.Size(40, 22)
        Me.LblOrderValue.Text = "        "
        '
        'LblCreation
        '
        Me.LblCreation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreation.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.LblCreation.Name = "LblCreation"
        Me.LblCreation.Size = New System.Drawing.Size(64, 22)
        Me.LblCreation.Text = "Criação:"
        '
        'LblCreationValue
        '
        Me.LblCreationValue.BackColor = System.Drawing.Color.White
        Me.LblCreationValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreationValue.Name = "LblCreationValue"
        Me.LblCreationValue.Size = New System.Drawing.Size(32, 22)
        Me.LblCreationValue.Text = "      "
        '
        'FrmCrmTreatment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 351)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.LblSummary)
        Me.Controls.Add(Me.TxtSummary)
        Me.Controls.Add(Me.CbxContactType)
        Me.Controls.Add(Me.DbxNextContact)
        Me.Controls.Add(Me.DbxContact)
        Me.Controls.Add(Me.LblContactType)
        Me.Controls.Add(Me.LblNextContact)
        Me.Controls.Add(Me.LblContact)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCrmTreatment"
        Me.ShowIcon = False
        Me.Text = "Atendimento"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents LblSummary As Label
    Friend WithEvents TxtSummary As TextBox
    Friend WithEvents CbxContactType As ComboBox
    Friend WithEvents DbxNextContact As ControlLibrary.DateBox
    Friend WithEvents DbxContact As ControlLibrary.DateBox
    Friend WithEvents LblContactType As Label
    Friend WithEvents LblNextContact As Label
    Friend WithEvents LblContact As Label
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
End Class
