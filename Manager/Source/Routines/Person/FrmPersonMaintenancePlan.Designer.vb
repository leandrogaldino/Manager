<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPersonMaintenancePlan
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
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPersonMaintenancePlan))
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.FlpPerson = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterPerson = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewPerson = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewPerson = New ControlLibrary.NoFocusCueButton()
        Me.QbxPerson = New ControlLibrary.QueriedBox()
        Me.LblInitialDate = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.DgvCompressor = New System.Windows.Forms.DataGridView()
        Me.LblCompressor = New System.Windows.Forms.Label()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CbxShowTechnicalAdvice = New System.Windows.Forms.CheckBox()
        Me.CbxShowMDHT = New System.Windows.Forms.CheckBox()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlpPerson.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvCompressor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(377, 7)
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
        'FlpPerson
        '
        Me.FlpPerson.Controls.Add(Me.BtnFilterPerson)
        Me.FlpPerson.Controls.Add(Me.BtnViewPerson)
        Me.FlpPerson.Controls.Add(Me.BtnNewPerson)
        Me.FlpPerson.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpPerson.Location = New System.Drawing.Point(403, 16)
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
        Me.QbxPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@statusid"
        Me.QbxPerson.Conditions.Add(Condition1)
        Me.QbxPerson.DebugOnTextChanged = False
        Me.QbxPerson.DisplayFieldAlias = "Nome Curto"
        Me.QbxPerson.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxPerson.DisplayFieldName = "shortname"
        Me.QbxPerson.DisplayMainFieldName = "id"
        Me.QbxPerson.DisplayTableAlias = Nothing
        Me.QbxPerson.DisplayTableName = "person"
        Me.QbxPerson.Distinct = False
        Me.QbxPerson.DropDownAutoStretchRight = False
        Me.QbxPerson.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxPerson.IfNull = Nothing
        Me.QbxPerson.Location = New System.Drawing.Point(12, 37)
        Me.QbxPerson.MainReturnFieldName = "id"
        Me.QbxPerson.MainTableAlias = Nothing
        Me.QbxPerson.MainTableName = "person"
        Me.QbxPerson.Name = "QbxPerson"
        OtherField1.DisplayFieldAlias = "Nome"
        OtherField1.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField1.DisplayFieldName = "name"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "person"
        OtherField1.Freeze = False
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        OtherField2.DisplayFieldAlias = "CPF/CNPJ"
        OtherField2.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
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
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Me.QbxPerson.Parameters.Add(Parameter1)
        Me.QbxPerson.Prefix = Nothing
        Me.QbxPerson.Size = New System.Drawing.Size(460, 23)
        Me.QbxPerson.Suffix = Nothing
        Me.QbxPerson.TabIndex = 1
        '
        'LblInitialDate
        '
        Me.LblInitialDate.AutoSize = True
        Me.LblInitialDate.Location = New System.Drawing.Point(12, 19)
        Me.LblInitialDate.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.LblInitialDate.Name = "LblInitialDate"
        Me.LblInitialDate.Size = New System.Drawing.Size(52, 17)
        Me.LblInitialDate.TabIndex = 0
        Me.LblInitialDate.Text = "Pessoa"
        Me.LblInitialDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnGenerate)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 44)
        Me.Panel1.TabIndex = 5
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Enabled = False
        Me.BtnGenerate.Location = New System.Drawing.Point(276, 7)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(95, 30)
        Me.BtnGenerate.TabIndex = 0
        Me.BtnGenerate.Text = "Gerar"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'DgvCompressor
        '
        Me.DgvCompressor.AllowUserToAddRows = False
        Me.DgvCompressor.AllowUserToDeleteRows = False
        Me.DgvCompressor.AllowUserToOrderColumns = True
        Me.DgvCompressor.AllowUserToResizeRows = False
        Me.DgvCompressor.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvCompressor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvCompressor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCompressor.Location = New System.Drawing.Point(12, 103)
        Me.DgvCompressor.MultiSelect = False
        Me.DgvCompressor.Name = "DgvCompressor"
        Me.DgvCompressor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvCompressor.RowHeadersVisible = False
        Me.DgvCompressor.RowTemplate.Height = 26
        Me.DgvCompressor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCompressor.Size = New System.Drawing.Size(460, 228)
        Me.DgvCompressor.TabIndex = 4
        '
        'LblCompressor
        '
        Me.LblCompressor.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblCompressor.ForeColor = System.Drawing.Color.White
        Me.LblCompressor.Location = New System.Drawing.Point(12, 77)
        Me.LblCompressor.Name = "LblCompressor"
        Me.LblCompressor.Size = New System.Drawing.Size(460, 26)
        Me.LblCompressor.TabIndex = 3
        Me.LblCompressor.Text = "Compressor"
        Me.LblCompressor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'CbxShowTechnicalAdvice
        '
        Me.CbxShowTechnicalAdvice.AutoSize = True
        Me.CbxShowTechnicalAdvice.Checked = True
        Me.CbxShowTechnicalAdvice.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbxShowTechnicalAdvice.Location = New System.Drawing.Point(15, 337)
        Me.CbxShowTechnicalAdvice.Name = "CbxShowTechnicalAdvice"
        Me.CbxShowTechnicalAdvice.Size = New System.Drawing.Size(319, 21)
        Me.CbxShowTechnicalAdvice.TabIndex = 6
        Me.CbxShowTechnicalAdvice.Text = "Mostrar parecer técnico da última avaliação"
        Me.CbxShowTechnicalAdvice.UseVisualStyleBackColor = True
        '
        'CbxShowMDHT
        '
        Me.CbxShowMDHT.AutoSize = True
        Me.CbxShowMDHT.Location = New System.Drawing.Point(15, 364)
        Me.CbxShowMDHT.Name = "CbxShowMDHT"
        Me.CbxShowMDHT.Size = New System.Drawing.Size(304, 21)
        Me.CbxShowMDHT.TabIndex = 6
        Me.CbxShowMDHT.Text = "Mostrar média diária de horas trabalhadas"
        Me.CbxShowMDHT.UseVisualStyleBackColor = True
        '
        'FrmPersonMaintenancePlan
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(484, 436)
        Me.Controls.Add(Me.CbxShowMDHT)
        Me.Controls.Add(Me.CbxShowTechnicalAdvice)
        Me.Controls.Add(Me.FlpPerson)
        Me.Controls.Add(Me.QbxPerson)
        Me.Controls.Add(Me.LblInitialDate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblCompressor)
        Me.Controls.Add(Me.DgvCompressor)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonMaintenancePlan"
        Me.ShowIcon = False
        Me.Text = "Pessoa - Plano de Manutenção"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlpPerson.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DgvCompressor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents BtnClose As Button
    Friend WithEvents LblInitialDate As Label
    Friend WithEvents QbxPerson As ControlLibrary.QueriedBox
    Friend WithEvents BtnNewPerson As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewPerson As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterPerson As ControlLibrary.NoFocusCueButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlpPerson As FlowLayoutPanel
    Friend WithEvents DgvCompressor As DataGridView
    Friend WithEvents LblCompressor As Label
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents CbxShowMDHT As CheckBox
    Friend WithEvents CbxShowTechnicalAdvice As CheckBox
End Class
