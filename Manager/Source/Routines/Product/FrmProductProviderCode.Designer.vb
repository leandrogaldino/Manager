<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProductProviderCode
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
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField3 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField4 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation2 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation3 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsMain = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.QbxProvider = New ControlLibrary.QueriedBox()
        Me.LblProvider = New System.Windows.Forms.Label()
        Me.LblCode = New System.Windows.Forms.Label()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.TxtCode = New System.Windows.Forms.TextBox()
        Me.FlpProvider = New System.Windows.Forms.FlowLayoutPanel()
        Me.CbxIsMainProvider = New ControlLibrary.ToolStripCheckBox()
        Me.TsMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsData.SuspendLayout()
        Me.FlpProvider.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(418, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(317, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsMain
        '
        Me.TsMain.AutoSize = False
        Me.TsMain.BackColor = System.Drawing.Color.White
        Me.TsMain.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog, Me.ToolStripButton1})
        Me.TsMain.Location = New System.Drawing.Point(0, 0)
        Me.TsMain.Name = "TsMain"
        Me.TsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMain.Size = New System.Drawing.Size(525, 25)
        Me.TsMain.TabIndex = 0
        Me.TsMain.Text = "ToolStrip2"
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Código de Fornecedor"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Código de Fornecedor"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Código de Fornecedor"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Código de Fornecedor Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Código de Fornecedor"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Código de Fornecedor"
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 107)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(525, 44)
        Me.Panel1.TabIndex = 7
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblCreation, Me.LblCreationValue, Me.CbxIsMainProvider})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(525, 25)
        Me.TsData.TabIndex = 1
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
        'QbxProvider
        '
        Me.QbxProvider.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxProvider.CharactersToQuery = 1
        Condition1.FieldName = "isprovider"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@isprovider"
        Condition2.FieldName = "statusid"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@statusid"
        Me.QbxProvider.Conditions.Add(Condition1)
        Me.QbxProvider.Conditions.Add(Condition2)
        Me.QbxProvider.DebugOnTextChanged = False
        Me.QbxProvider.DisplayFieldAlias = "Nome Curto"
        Me.QbxProvider.DisplayFieldName = "shortname"
        Me.QbxProvider.DisplayMainFieldName = "id"
        Me.QbxProvider.DisplayTableAlias = Nothing
        Me.QbxProvider.DisplayTableName = "person"
        Me.QbxProvider.Distinct = True
        Me.QbxProvider.DropDownAutoStretchRight = False
        Me.QbxProvider.DropDownStretchLeft = 163
        Me.QbxProvider.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxProvider.IfNull = Nothing
        Me.QbxProvider.Location = New System.Drawing.Point(175, 75)
        Me.QbxProvider.MainReturnFieldName = "id"
        Me.QbxProvider.MainTableAlias = Nothing
        Me.QbxProvider.MainTableName = "person"
        Me.QbxProvider.Name = "QbxProvider"
        OtherField1.DisplayFieldAlias = "Nome"
        OtherField1.DisplayFieldName = "name"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "person"
        OtherField1.Freeze = False
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        OtherField2.DisplayFieldAlias = "CNPJ/CPF"
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        OtherField3.DisplayFieldAlias = "Cidade"
        OtherField3.DisplayFieldName = "name"
        OtherField3.DisplayMainFieldName = "id"
        OtherField3.DisplayTableAlias = Nothing
        OtherField3.DisplayTableName = "city"
        OtherField3.Freeze = False
        OtherField3.IfNull = Nothing
        OtherField3.Prefix = Nothing
        OtherField3.Suffix = Nothing
        OtherField4.DisplayFieldAlias = "Estado"
        OtherField4.DisplayFieldName = "name"
        OtherField4.DisplayMainFieldName = "id"
        OtherField4.DisplayTableAlias = Nothing
        OtherField4.DisplayTableName = "state"
        OtherField4.Freeze = False
        OtherField4.IfNull = Nothing
        OtherField4.Prefix = Nothing
        OtherField4.Suffix = Nothing
        Me.QbxProvider.OtherFields.Add(OtherField1)
        Me.QbxProvider.OtherFields.Add(OtherField2)
        Me.QbxProvider.OtherFields.Add(OtherField3)
        Me.QbxProvider.OtherFields.Add(OtherField4)
        Parameter1.ParameterName = "@isprovider"
        Parameter1.ParameterValue = "1"
        Parameter2.ParameterName = "@statusid"
        Parameter2.ParameterValue = "0"
        Me.QbxProvider.Parameters.Add(Parameter1)
        Me.QbxProvider.Parameters.Add(Parameter2)
        Me.QbxProvider.Prefix = Nothing
        Relation1.Operator = "="
        Relation1.RelateFieldName = "personid"
        Relation1.RelateTableAlias = Nothing
        Relation1.RelateTableName = "personaddress"
        Relation1.RelationType = "LEFT"
        Relation1.WithFieldName = "id"
        Relation1.WithTableAlias = Nothing
        Relation1.WithTableName = "person"
        Relation2.Operator = "="
        Relation2.RelateFieldName = "id"
        Relation2.RelateTableAlias = Nothing
        Relation2.RelateTableName = "city"
        Relation2.RelationType = "LEFT"
        Relation2.WithFieldName = "cityid"
        Relation2.WithTableAlias = Nothing
        Relation2.WithTableName = "personaddress"
        Relation3.Operator = "="
        Relation3.RelateFieldName = "id"
        Relation3.RelateTableAlias = Nothing
        Relation3.RelateTableName = "state"
        Relation3.RelationType = "LEFT"
        Relation3.WithFieldName = "stateid"
        Relation3.WithTableAlias = Nothing
        Relation3.WithTableName = "city"
        Me.QbxProvider.Relations.Add(Relation1)
        Me.QbxProvider.Relations.Add(Relation2)
        Me.QbxProvider.Relations.Add(Relation3)
        Me.QbxProvider.Size = New System.Drawing.Size(341, 23)
        Me.QbxProvider.Suffix = Nothing
        Me.QbxProvider.TabIndex = 5
        '
        'LblProvider
        '
        Me.LblProvider.AutoSize = True
        Me.LblProvider.Location = New System.Drawing.Point(172, 55)
        Me.LblProvider.Name = "LblProvider"
        Me.LblProvider.Size = New System.Drawing.Size(81, 17)
        Me.LblProvider.TabIndex = 4
        Me.LblProvider.Text = "Fornecedor"
        '
        'LblCode
        '
        Me.LblCode.AutoSize = True
        Me.LblCode.Location = New System.Drawing.Point(9, 55)
        Me.LblCode.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblCode.Name = "LblCode"
        Me.LblCode.Size = New System.Drawing.Size(58, 17)
        Me.LblCode.TabIndex = 2
        Me.LblCode.Text = "Código"
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
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
        'TxtCode
        '
        Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCode.Location = New System.Drawing.Point(12, 75)
        Me.TxtCode.MaxLength = 20
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(157, 23)
        Me.TxtCode.TabIndex = 3
        Me.TxtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FlpProvider
        '
        Me.FlpProvider.Controls.Add(Me.BtnFilter)
        Me.FlpProvider.Controls.Add(Me.BtnView)
        Me.FlpProvider.Controls.Add(Me.BtnNew)
        Me.FlpProvider.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpProvider.Location = New System.Drawing.Point(447, 54)
        Me.FlpProvider.Name = "FlpProvider"
        Me.FlpProvider.Size = New System.Drawing.Size(69, 21)
        Me.FlpProvider.TabIndex = 6
        '
        'CbxIsMainProvider
        '
        Me.CbxIsMainProvider.Checked = False
        Me.CbxIsMainProvider.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.CbxIsMainProvider.Name = "CbxIsMainProvider"
        Me.CbxIsMainProvider.Size = New System.Drawing.Size(159, 22)
        Me.CbxIsMainProvider.Text = "Fornecedor Principal"
        '
        'FrmProductProviderCode
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(525, 151)
        Me.Controls.Add(Me.FlpProvider)
        Me.Controls.Add(Me.QbxProvider)
        Me.Controls.Add(Me.LblProvider)
        Me.Controls.Add(Me.LblCode)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.TsMain)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductProviderCode"
        Me.ShowIcon = False
        Me.Text = "Código de Fornecedor"
        Me.TsMain.ResumeLayout(False)
        Me.TsMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.FlpProvider.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsMain As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents QbxProvider As ControlLibrary.QueriedBox
    Friend WithEvents LblProvider As Label
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents LblCode As Label
    Friend WithEvents TxtCode As TextBox
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents FlpProvider As FlowLayoutPanel
    Friend WithEvents CbxIsMainProvider As ControlLibrary.ToolStripCheckBox
End Class
