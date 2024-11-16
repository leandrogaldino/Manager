<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPersonRegistrationForm
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
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlpPerson = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterPerson = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewPerson = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewPerson = New ControlLibrary.NoFocusCueButton()
        Me.QbxPerson = New ControlLibrary.QueriedBox()
        Me.CbxShowContacts = New System.Windows.Forms.CheckBox()
        Me.CbxShowCompressors = New System.Windows.Forms.CheckBox()
        Me.CbxShowAddresses = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.FlpPerson.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(400, 7)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.FlpPerson)
        Me.GroupBox1.Controls.Add(Me.QbxPerson)
        Me.GroupBox1.Controls.Add(Me.CbxShowContacts)
        Me.GroupBox1.Controls.Add(Me.CbxShowCompressors)
        Me.GroupBox1.Controls.Add(Me.CbxShowAddresses)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(482, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pessoa"
        '
        'FlpPerson
        '
        Me.FlpPerson.Controls.Add(Me.BtnFilterPerson)
        Me.FlpPerson.Controls.Add(Me.BtnViewPerson)
        Me.FlpPerson.Controls.Add(Me.BtnNewPerson)
        Me.FlpPerson.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpPerson.Location = New System.Drawing.Point(407, 18)
        Me.FlpPerson.Name = "FlpPerson"
        Me.FlpPerson.Size = New System.Drawing.Size(69, 21)
        Me.FlpPerson.TabIndex = 2
        '
        'BtnFilterPerson
        '
        Me.BtnFilterPerson.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterPerson.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterPerson.FlatAppearance.BorderSize = 0
        Me.BtnFilterPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterPerson.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterPerson.Name = "BtnFilterPerson"
        Me.BtnFilterPerson.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterPerson.TabIndex = 2
        Me.BtnFilterPerson.TabStop = False
        Me.BtnFilterPerson.TooltipText = ""
        Me.BtnFilterPerson.UseVisualStyleBackColor = False
        Me.BtnFilterPerson.Visible = False
        '
        'BtnViewPerson
        '
        Me.BtnViewPerson.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewPerson.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewPerson.FlatAppearance.BorderSize = 0
        Me.BtnViewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewPerson.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewPerson.Name = "BtnViewPerson"
        Me.BtnViewPerson.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewPerson.TabIndex = 1
        Me.BtnViewPerson.TabStop = False
        Me.BtnViewPerson.TooltipText = ""
        Me.BtnViewPerson.UseVisualStyleBackColor = False
        Me.BtnViewPerson.Visible = False
        '
        'BtnNewPerson
        '
        Me.BtnNewPerson.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewPerson.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewPerson.FlatAppearance.BorderSize = 0
        Me.BtnNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewPerson.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewPerson.Name = "BtnNewPerson"
        Me.BtnNewPerson.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewPerson.TabIndex = 0
        Me.BtnNewPerson.TabStop = False
        Me.BtnNewPerson.TooltipText = ""
        Me.BtnNewPerson.UseVisualStyleBackColor = False
        Me.BtnNewPerson.Visible = False
        '
        'QbxPerson
        '
        Me.QbxPerson.DisplayFieldAlias = "Nome"
        Me.QbxPerson.DisplayFieldName = "name"
        Me.QbxPerson.DisplayMainFieldName = "id"
        Me.QbxPerson.DisplayTableAlias = Nothing
        Me.QbxPerson.DisplayTableName = "person"
        Me.QbxPerson.Distinct = False
        Me.QbxPerson.DropDownAutoStretchRight = False
        Me.QbxPerson.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxPerson.IfNull = Nothing
        Me.QbxPerson.Location = New System.Drawing.Point(9, 39)
        Me.QbxPerson.MainReturnFieldName = "id"
        Me.QbxPerson.MainTableAlias = Nothing
        Me.QbxPerson.MainTableName = "person"
        Me.QbxPerson.Name = "QbxPerson"
        OtherField1.DisplayFieldAlias = "Nome Curto"
        OtherField1.DisplayFieldName = "shortname"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "person"
        OtherField1.Freeze = False
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        OtherField2.DisplayFieldAlias = "CPF/CNPJ"
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        Me.QbxPerson.OtherFields.Add(OtherField1)
        Me.QbxPerson.OtherFields.Add(OtherField2)
        Me.QbxPerson.Prefix = Nothing
        Me.QbxPerson.Size = New System.Drawing.Size(467, 23)
        Me.QbxPerson.Suffix = Nothing
        Me.QbxPerson.TabIndex = 1
        '
        'CbxShowContacts
        '
        Me.CbxShowContacts.AutoSize = True
        Me.CbxShowContacts.Checked = True
        Me.CbxShowContacts.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowContacts.Location = New System.Drawing.Point(159, 68)
        Me.CbxShowContacts.Name = "CbxShowContacts"
        Me.CbxShowContacts.Size = New System.Drawing.Size(139, 21)
        Me.CbxShowContacts.TabIndex = 4
        Me.CbxShowContacts.Text = "Mostrar Contatos"
        Me.CbxShowContacts.UseVisualStyleBackColor = True
        '
        'CbxShowCompressors
        '
        Me.CbxShowCompressors.AutoSize = True
        Me.CbxShowCompressors.Location = New System.Drawing.Point(304, 68)
        Me.CbxShowCompressors.Name = "CbxShowCompressors"
        Me.CbxShowCompressors.Size = New System.Drawing.Size(168, 21)
        Me.CbxShowCompressors.TabIndex = 5
        Me.CbxShowCompressors.Text = "Mostrar Compressores"
        Me.CbxShowCompressors.UseVisualStyleBackColor = True
        '
        'CbxShowAddresses
        '
        Me.CbxShowAddresses.AutoSize = True
        Me.CbxShowAddresses.Checked = True
        Me.CbxShowAddresses.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowAddresses.Location = New System.Drawing.Point(9, 68)
        Me.CbxShowAddresses.Name = "CbxShowAddresses"
        Me.CbxShowAddresses.Size = New System.Drawing.Size(144, 21)
        Me.CbxShowAddresses.TabIndex = 3
        Me.CbxShowAddresses.Text = "Mostrar Endereços"
        Me.CbxShowAddresses.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnGenerate)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(507, 44)
        Me.Panel1.TabIndex = 1
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Enabled = False
        Me.BtnGenerate.Location = New System.Drawing.Point(299, 7)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(95, 30)
        Me.BtnGenerate.TabIndex = 0
        Me.BtnGenerate.Text = "Gerar"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'FrmPersonRegistrationForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(507, 161)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonRegistrationForm"
        Me.ShowIcon = False
        Me.Text = "Pessoa - Ficha Cadastral"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FlpPerson.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents BtnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CbxShowAddresses As CheckBox
    Friend WithEvents CbxShowContacts As CheckBox
    Friend WithEvents CbxShowCompressors As CheckBox
    Friend WithEvents QbxPerson As ControlLibrary.QueriedBox
    Friend WithEvents BtnNewPerson As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewPerson As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterPerson As ControlLibrary.NoFocusCueButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlpPerson As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnGenerate As Button
End Class
