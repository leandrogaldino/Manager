<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmailImportContact
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
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.FlpGroup = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.QbxPerson = New ControlLibrary.QueriedBox()
        Me.LblPerson = New System.Windows.Forms.Label()
        Me.DgvEmail = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlpGroup.SuspendLayout()
        CType(Me.DgvEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 305)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 44)
        Me.Panel1.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(480, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Enabled = False
        Me.BtnImport.Location = New System.Drawing.Point(379, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Nothing
        Me.DgvNavigator.LastButton = Nothing
        Me.DgvNavigator.NextButton = Nothing
        Me.DgvNavigator.PreviousButton = Nothing
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'FlpGroup
        '
        Me.FlpGroup.Controls.Add(Me.BtnFilter)
        Me.FlpGroup.Controls.Add(Me.BtnView)
        Me.FlpGroup.Controls.Add(Me.BtnNew)
        Me.FlpGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpGroup.Location = New System.Drawing.Point(503, 8)
        Me.FlpGroup.Name = "FlpGroup"
        Me.FlpGroup.Size = New System.Drawing.Size(69, 21)
        Me.FlpGroup.TabIndex = 2
        '
        'BtnFilter
        '
        Me.BtnFilter.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilter.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilter.FlatAppearance.BorderSize = 0
        Me.BtnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilter.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilter.Name = "BtnFilter"
        Me.BtnFilter.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilter.TabIndex = 2
        Me.BtnFilter.TabStop = False
        Me.BtnFilter.TooltipText = ""
        Me.BtnFilter.UseVisualStyleBackColor = False
        Me.BtnFilter.Visible = False
        '
        'BtnView
        '
        Me.BtnView.BackColor = System.Drawing.Color.Transparent
        Me.BtnView.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnView.FlatAppearance.BorderSize = 0
        Me.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnView.Location = New System.Drawing.Point(26, 3)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(17, 17)
        Me.BtnView.TabIndex = 1
        Me.BtnView.TabStop = False
        Me.BtnView.TooltipText = ""
        Me.BtnView.UseVisualStyleBackColor = False
        Me.BtnView.Visible = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnNew.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Location = New System.Drawing.Point(3, 3)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(17, 17)
        Me.BtnNew.TabIndex = 0
        Me.BtnNew.TabStop = False
        Me.BtnNew.TooltipText = ""
        Me.BtnNew.UseVisualStyleBackColor = False
        Me.BtnNew.Visible = False
        '
        'QbxPerson
        '
        Me.QbxPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxPerson.CharactersToQuery = 1
        Me.QbxPerson.DisplayFieldAlias = "Nome"
        Me.QbxPerson.DisplayFieldName = "name"
        Me.QbxPerson.DisplayMainFieldName = "id"
        Me.QbxPerson.DisplayTableAlias = Nothing
        Me.QbxPerson.DisplayTableName = "person"
        Me.QbxPerson.Distinct = False
        Me.QbxPerson.DropDownAutoStretchRight = False
        Me.QbxPerson.DropDownStretchDown = 220
        Me.QbxPerson.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxPerson.IfNull = Nothing
        Me.QbxPerson.Location = New System.Drawing.Point(15, 29)
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
        Me.QbxPerson.Size = New System.Drawing.Size(557, 23)
        Me.QbxPerson.Suffix = Nothing
        Me.QbxPerson.TabIndex = 1
        '
        'LblPerson
        '
        Me.LblPerson.AutoSize = True
        Me.LblPerson.Location = New System.Drawing.Point(12, 9)
        Me.LblPerson.Name = "LblPerson"
        Me.LblPerson.Size = New System.Drawing.Size(52, 17)
        Me.LblPerson.TabIndex = 0
        Me.LblPerson.Text = "Pessoa"
        '
        'DgvEmail
        '
        Me.DgvEmail.AllowUserToAddRows = False
        Me.DgvEmail.AllowUserToDeleteRows = False
        Me.DgvEmail.AllowUserToOrderColumns = True
        Me.DgvEmail.AllowUserToResizeRows = False
        Me.DgvEmail.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvEmail.Location = New System.Drawing.Point(15, 58)
        Me.DgvEmail.MultiSelect = False
        Me.DgvEmail.Name = "DgvEmail"
        Me.DgvEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvEmail.RowHeadersVisible = False
        Me.DgvEmail.RowTemplate.Height = 26
        Me.DgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEmail.Size = New System.Drawing.Size(557, 237)
        Me.DgvEmail.TabIndex = 3
        '
        'FrmEmailImportContact
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 349)
        Me.Controls.Add(Me.DgvEmail)
        Me.Controls.Add(Me.FlpGroup)
        Me.Controls.Add(Me.QbxPerson)
        Me.Controls.Add(Me.LblPerson)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmailImportContact"
        Me.ShowIcon = False
        Me.Text = "Importar E-Mail"
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlpGroup.ResumeLayout(False)
        CType(Me.DgvEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents FlpGroup As FlowLayoutPanel
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents QbxPerson As ControlLibrary.QueriedBox
    Friend WithEvents LblPerson As Label
    Friend WithEvents DgvEmail As DataGridView
End Class
