<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPersonAddressGetZipCode
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
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.LblCity = New System.Windows.Forms.Label()
        Me.LblZipCode = New System.Windows.Forms.Label()
        Me.TxtAddressName = New System.Windows.Forms.TextBox()
        Me.TxtZipCode = New System.Windows.Forms.TextBox()
        Me.LblAddressName = New System.Windows.Forms.Label()
        Me.LblDistrict = New System.Windows.Forms.Label()
        Me.TxtDistrict = New System.Windows.Forms.TextBox()
        Me.LblStreet = New System.Windows.Forms.Label()
        Me.TxtStreet = New System.Windows.Forms.TextBox()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TmrQueriedBoxCity = New System.Windows.Forms.Timer(Me.components)
        Me.BtnNewCity = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCity = New ControlLibrary.NoFocusCueButton()
        Me.BtnFilterCity = New ControlLibrary.NoFocusCueButton()
        Me.FlpCity = New System.Windows.Forms.FlowLayoutPanel()
        Me.QbxCity = New ControlLibrary.QueriedBox()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlpCity.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 44)
        Me.Panel1.TabIndex = 11
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(410, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(511, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Location = New System.Drawing.Point(278, 109)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(57, 17)
        Me.LblCity.TabIndex = 8
        Me.LblCity.Text = "Cidade"
        '
        'LblZipCode
        '
        Me.LblZipCode.AutoSize = True
        Me.LblZipCode.Location = New System.Drawing.Point(12, 63)
        Me.LblZipCode.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblZipCode.Name = "LblZipCode"
        Me.LblZipCode.Size = New System.Drawing.Size(36, 17)
        Me.LblZipCode.TabIndex = 2
        Me.LblZipCode.Text = "Cep"
        '
        'TxtAddressName
        '
        Me.TxtAddressName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddressName.Location = New System.Drawing.Point(14, 29)
        Me.TxtAddressName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtAddressName.MaxLength = 100
        Me.TxtAddressName.Name = "TxtAddressName"
        Me.TxtAddressName.Size = New System.Drawing.Size(593, 23)
        Me.TxtAddressName.TabIndex = 1
        '
        'TxtZipCode
        '
        Me.TxtZipCode.BackColor = System.Drawing.SystemColors.Window
        Me.TxtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZipCode.Location = New System.Drawing.Point(15, 83)
        Me.TxtZipCode.MaxLength = 10
        Me.TxtZipCode.Name = "TxtZipCode"
        Me.TxtZipCode.ReadOnly = True
        Me.TxtZipCode.Size = New System.Drawing.Size(73, 23)
        Me.TxtZipCode.TabIndex = 3
        Me.TxtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblAddressName
        '
        Me.LblAddressName.AutoSize = True
        Me.LblAddressName.Location = New System.Drawing.Point(12, 9)
        Me.LblAddressName.Name = "LblAddressName"
        Me.LblAddressName.Size = New System.Drawing.Size(48, 17)
        Me.LblAddressName.TabIndex = 0
        Me.LblAddressName.Text = "Nome"
        '
        'LblDistrict
        '
        Me.LblDistrict.AutoSize = True
        Me.LblDistrict.Location = New System.Drawing.Point(12, 109)
        Me.LblDistrict.Name = "LblDistrict"
        Me.LblDistrict.Size = New System.Drawing.Size(44, 17)
        Me.LblDistrict.TabIndex = 6
        Me.LblDistrict.Text = "Bairro"
        '
        'TxtDistrict
        '
        Me.TxtDistrict.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDistrict.Location = New System.Drawing.Point(15, 129)
        Me.TxtDistrict.MaxLength = 255
        Me.TxtDistrict.Name = "TxtDistrict"
        Me.TxtDistrict.Size = New System.Drawing.Size(260, 23)
        Me.TxtDistrict.TabIndex = 7
        '
        'LblStreet
        '
        Me.LblStreet.AutoSize = True
        Me.LblStreet.Location = New System.Drawing.Point(91, 63)
        Me.LblStreet.Name = "LblStreet"
        Me.LblStreet.Size = New System.Drawing.Size(33, 17)
        Me.LblStreet.TabIndex = 4
        Me.LblStreet.Text = "Rua"
        '
        'TxtStreet
        '
        Me.TxtStreet.BackColor = System.Drawing.SystemColors.Window
        Me.TxtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStreet.Location = New System.Drawing.Point(94, 83)
        Me.TxtStreet.MaxLength = 255
        Me.TxtStreet.Name = "TxtStreet"
        Me.TxtStreet.Size = New System.Drawing.Size(513, 23)
        Me.TxtStreet.TabIndex = 5
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TmrQueriedBoxCity
        '
        Me.TmrQueriedBoxCity.Enabled = True
        Me.TmrQueriedBoxCity.Interval = 300
        '
        'BtnNewCity
        '
        Me.BtnNewCity.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewCity.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewCity.FlatAppearance.BorderSize = 0
        Me.BtnNewCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewCity.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewCity.Name = "BtnNewCity"
        Me.BtnNewCity.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewCity.TabIndex = 0
        Me.BtnNewCity.TabStop = False
        Me.BtnNewCity.TooltipText = ""
        Me.BtnNewCity.UseVisualStyleBackColor = False
        Me.BtnNewCity.Visible = False
        '
        'BtnViewCity
        '
        Me.BtnViewCity.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewCity.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewCity.FlatAppearance.BorderSize = 0
        Me.BtnViewCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewCity.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewCity.Name = "BtnViewCity"
        Me.BtnViewCity.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewCity.TabIndex = 1
        Me.BtnViewCity.TabStop = False
        Me.BtnViewCity.TooltipText = ""
        Me.BtnViewCity.UseVisualStyleBackColor = False
        Me.BtnViewCity.Visible = False
        '
        'BtnFilterCity
        '
        Me.BtnFilterCity.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterCity.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterCity.FlatAppearance.BorderSize = 0
        Me.BtnFilterCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterCity.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterCity.Name = "BtnFilterCity"
        Me.BtnFilterCity.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterCity.TabIndex = 2
        Me.BtnFilterCity.TabStop = False
        Me.BtnFilterCity.TooltipText = ""
        Me.BtnFilterCity.UseVisualStyleBackColor = False
        Me.BtnFilterCity.Visible = False
        '
        'FlpCity
        '
        Me.FlpCity.Controls.Add(Me.BtnFilterCity)
        Me.FlpCity.Controls.Add(Me.BtnViewCity)
        Me.FlpCity.Controls.Add(Me.BtnNewCity)
        Me.FlpCity.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCity.Location = New System.Drawing.Point(538, 108)
        Me.FlpCity.Name = "FlpCity"
        Me.FlpCity.Size = New System.Drawing.Size(69, 21)
        Me.FlpCity.TabIndex = 10
        '
        'QbxCity
        '
        Me.QbxCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCity.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "city"
        Condition1.Value = "@statusid"
        Me.QbxCity.Conditions.Add(Condition1)
        Me.QbxCity.DisplayFieldAlias = "Nome"
        Me.QbxCity.DisplayFieldName = "name"
        Me.QbxCity.DisplayMainFieldName = "id"
        Me.QbxCity.DisplayTableAlias = Nothing
        Me.QbxCity.DisplayTableName = "city"
        Me.QbxCity.Distinct = False
        Me.QbxCity.DropDownAutoStretchRight = False
        Me.QbxCity.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCity.IfNull = Nothing
        Me.QbxCity.Location = New System.Drawing.Point(281, 129)
        Me.QbxCity.MainReturnFieldName = "id"
        Me.QbxCity.MainTableAlias = Nothing
        Me.QbxCity.MainTableName = "city"
        Me.QbxCity.Name = "QbxCity"
        OtherField1.DisplayFieldAlias = "UF"
        OtherField1.DisplayFieldName = "shortname"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "state"
        OtherField1.Freeze = True
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = "-"
        OtherField1.Suffix = ""
        Me.QbxCity.OtherFields.Add(OtherField1)
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Me.QbxCity.Parameters.Add(Parameter1)
        Me.QbxCity.Prefix = Nothing
        Relation1.Operator = "="
        Relation1.RelateFieldName = "id"
        Relation1.RelateTableAlias = "state"
        Relation1.RelateTableName = "state"
        Relation1.RelationType = "INNER"
        Relation1.WithFieldName = "stateid"
        Relation1.WithTableAlias = "city"
        Relation1.WithTableName = "city"
        Me.QbxCity.Relations.Add(Relation1)
        Me.QbxCity.Size = New System.Drawing.Size(326, 23)
        Me.QbxCity.Suffix = Nothing
        Me.QbxCity.TabIndex = 9
        '
        'FrmPersonAddressGetZipCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(618, 206)
        Me.Controls.Add(Me.QbxCity)
        Me.Controls.Add(Me.FlpCity)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblAddressName)
        Me.Controls.Add(Me.TxtStreet)
        Me.Controls.Add(Me.LblStreet)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.TxtDistrict)
        Me.Controls.Add(Me.LblDistrict)
        Me.Controls.Add(Me.LblZipCode)
        Me.Controls.Add(Me.TxtZipCode)
        Me.Controls.Add(Me.TxtAddressName)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonAddressGetZipCode"
        Me.ShowIcon = False
        Me.Text = "Consulta de CEP"
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlpCity.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImport As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents LblZipCode As Label
    Friend WithEvents TxtZipCode As TextBox
    Friend WithEvents LblDistrict As Label
    Friend WithEvents TxtDistrict As TextBox
    Friend WithEvents LblStreet As Label
    Friend WithEvents TxtStreet As TextBox
    Friend WithEvents LblAddressName As Label
    Friend WithEvents TxtAddressName As TextBox
    Friend WithEvents BtnNewCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilterCity As ControlLibrary.NoFocusCueButton
    Friend WithEvents LblCity As Label
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TmrQueriedBoxCity As Timer
    Friend WithEvents FlpCity As FlowLayoutPanel
    Friend WithEvents QbxCity As ControlLibrary.QueriedBox
End Class
