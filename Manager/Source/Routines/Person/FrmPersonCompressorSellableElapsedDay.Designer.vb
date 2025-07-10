<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPersonCompressorSellableElapsedDay
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
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblQuantity = New System.Windows.Forms.Label()
        Me.DbxQuantity = New ControlLibrary.DecimalBox()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.CbxSellableBind = New System.Windows.Forms.ToolStripComboBox()
        Me.LblCapacity = New System.Windows.Forms.Label()
        Me.DbxCapacity = New ControlLibrary.DecimalBox()
        Me.FlpSellable = New System.Windows.Forms.FlowLayoutPanel()
        Me.QbxSellable = New ControlLibrary.QueriedBox()
        Me.RbtService = New System.Windows.Forms.RadioButton()
        Me.RbtProduct = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsData.SuspendLayout()
        Me.FlpSellable.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 109)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(574, 44)
        Me.Panel1.TabIndex = 11
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(467, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(368, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Alterar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsNavigation
        '
        Me.TsNavigation.AutoSize = False
        Me.TsNavigation.BackColor = System.Drawing.Color.White
        Me.TsNavigation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(574, 25)
        Me.TsNavigation.TabIndex = 0
        Me.TsNavigation.Text = "ToolStrip2"
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Produto/Serviço"
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
        Me.BtnDelete.Text = "Excluir Produto/Serviço"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Produto/Serviço"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Produto/Serviço Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Produto/Serviço"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Produto/Serviço"
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
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'LblQuantity
        '
        Me.LblQuantity.AutoSize = True
        Me.LblQuantity.Location = New System.Drawing.Point(383, 55)
        Me.LblQuantity.Name = "LblQuantity"
        Me.LblQuantity.Size = New System.Drawing.Size(37, 17)
        Me.LblQuantity.TabIndex = 7
        Me.LblQuantity.Text = "Qtd."
        '
        'DbxQuantity
        '
        Me.DbxQuantity.DecimalOnly = True
        Me.DbxQuantity.DecimalPlaces = 2
        Me.DbxQuantity.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxQuantity.Location = New System.Drawing.Point(386, 75)
        Me.DbxQuantity.Name = "DbxQuantity"
        Me.DbxQuantity.Size = New System.Drawing.Size(85, 23)
        Me.DbxQuantity.TabIndex = 8
        Me.DbxQuantity.Text = "0,00"
        Me.DbxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
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
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.TabStop = False
        Me.BtnNew.TooltipText = ""
        Me.BtnNew.UseVisualStyleBackColor = False
        Me.BtnNew.Visible = False
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
        Me.BtnView.TabIndex = 0
        Me.BtnView.TabStop = False
        Me.BtnView.TooltipText = ""
        Me.BtnView.UseVisualStyleBackColor = False
        Me.BtnView.Visible = False
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
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreation, Me.LblCreationValue, Me.ToolStripLabel1, Me.CbxSellableBind})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(574, 25)
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
        'LblStatus
        '
        Me.LblStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(49, 22)
        Me.LblStatus.Text = "Status:"
        '
        'BtnStatusValue
        '
        Me.BtnStatusValue.AutoToolTip = False
        Me.BtnStatusValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnStatusValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.BtnStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnStatusValue.Name = "BtnStatusValue"
        Me.BtnStatusValue.Size = New System.Drawing.Size(44, 22)
        Me.BtnStatusValue.Text = "        "
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel1.Text = "Vínculo:"
        '
        'CbxSellableBind
        '
        Me.CbxSellableBind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxSellableBind.Name = "CbxSellableBind"
        Me.CbxSellableBind.Size = New System.Drawing.Size(160, 25)
        '
        'LblCapacity
        '
        Me.LblCapacity.AutoSize = True
        Me.LblCapacity.Location = New System.Drawing.Point(474, 55)
        Me.LblCapacity.Name = "LblCapacity"
        Me.LblCapacity.Size = New System.Drawing.Size(76, 17)
        Me.LblCapacity.TabIndex = 9
        Me.LblCapacity.Text = "Cap. (Dia)"
        '
        'DbxCapacity
        '
        Me.DbxCapacity.DecimalOnly = True
        Me.DbxCapacity.DecimalPlaces = 0
        Me.DbxCapacity.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxCapacity.Location = New System.Drawing.Point(477, 75)
        Me.DbxCapacity.Name = "DbxCapacity"
        Me.DbxCapacity.Size = New System.Drawing.Size(85, 23)
        Me.DbxCapacity.TabIndex = 10
        Me.DbxCapacity.Text = "0"
        Me.DbxCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FlpSellable
        '
        Me.FlpSellable.Controls.Add(Me.BtnFilter)
        Me.FlpSellable.Controls.Add(Me.BtnView)
        Me.FlpSellable.Controls.Add(Me.BtnNew)
        Me.FlpSellable.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpSellable.Location = New System.Drawing.Point(311, 54)
        Me.FlpSellable.Name = "FlpSellable"
        Me.FlpSellable.Size = New System.Drawing.Size(69, 21)
        Me.FlpSellable.TabIndex = 6
        '
        'QbxSellable
        '
        Me.QbxSellable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxSellable.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "product"
        Condition1.Value = "@statusid"
        Me.QbxSellable.Conditions.Add(Condition1)
        Me.QbxSellable.DebugOnTextChanged = False
        Me.QbxSellable.DisplayFieldAlias = "Código"
        Me.QbxSellable.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxSellable.DisplayFieldName = "code"
        Me.QbxSellable.DisplayMainFieldName = "id"
        Me.QbxSellable.DisplayTableAlias = ""
        Me.QbxSellable.DisplayTableName = "productprovidercode"
        Me.QbxSellable.Distinct = False
        Me.QbxSellable.DropDownAutoStretchRight = False
        Me.QbxSellable.DropDownStretchRight = 182
        Me.QbxSellable.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxSellable.IfNull = Nothing
        Me.QbxSellable.Location = New System.Drawing.Point(12, 75)
        Me.QbxSellable.MainReturnFieldName = "id"
        Me.QbxSellable.MainTableAlias = Nothing
        Me.QbxSellable.MainTableName = "product"
        Me.QbxSellable.Name = "QbxSellable"
        OtherField1.DisplayFieldAlias = "Produto"
        OtherField1.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField1.DisplayFieldName = "name"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = ""
        OtherField1.DisplayTableName = "product"
        OtherField1.Freeze = True
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        Me.QbxSellable.OtherFields.Add(OtherField1)
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Parameter2.ParameterName = "@ismainprovider"
        Parameter2.ParameterValue = "1"
        Me.QbxSellable.Parameters.Add(Parameter1)
        Me.QbxSellable.Parameters.Add(Parameter2)
        Me.QbxSellable.Prefix = Nothing
        Condition2.FieldName = "ismainprovider"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "productprovidercode"
        Condition2.Value = "@ismainprovider"
        Relation1.Conditions.Add(Condition2)
        Relation1.Operator = "="
        Relation1.RelateFieldName = "productid"
        Relation1.RelateTableAlias = Nothing
        Relation1.RelateTableName = "productprovidercode"
        Relation1.RelationType = "LEFT"
        Relation1.WithFieldName = "id"
        Relation1.WithTableAlias = Nothing
        Relation1.WithTableName = "product"
        Me.QbxSellable.Relations.Add(Relation1)
        Me.QbxSellable.Size = New System.Drawing.Size(368, 23)
        Me.QbxSellable.Suffix = " - "
        Me.QbxSellable.TabIndex = 4
        '
        'RbtService
        '
        Me.RbtService.AutoSize = True
        Me.RbtService.Location = New System.Drawing.Point(96, 48)
        Me.RbtService.Name = "RbtService"
        Me.RbtService.Size = New System.Drawing.Size(72, 21)
        Me.RbtService.TabIndex = 13
        Me.RbtService.Text = "Serviço"
        Me.RbtService.UseVisualStyleBackColor = True
        '
        'RbtProduct
        '
        Me.RbtProduct.AutoSize = True
        Me.RbtProduct.Checked = True
        Me.RbtProduct.Location = New System.Drawing.Point(12, 48)
        Me.RbtProduct.Name = "RbtProduct"
        Me.RbtProduct.Size = New System.Drawing.Size(78, 21)
        Me.RbtProduct.TabIndex = 12
        Me.RbtProduct.TabStop = True
        Me.RbtProduct.Text = "Produto"
        Me.RbtProduct.UseVisualStyleBackColor = True
        '
        'FrmPersonCompressorSellableElapsedDay
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 153)
        Me.Controls.Add(Me.RbtService)
        Me.Controls.Add(Me.RbtProduct)
        Me.Controls.Add(Me.FlpSellable)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.DbxCapacity)
        Me.Controls.Add(Me.QbxSellable)
        Me.Controls.Add(Me.LblCapacity)
        Me.Controls.Add(Me.DbxQuantity)
        Me.Controls.Add(Me.LblQuantity)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonCompressorSellableElapsedDay"
        Me.ShowIcon = False
        Me.Text = "Peça do Compressor (Dia Corrido)"
        Me.Panel1.ResumeLayout(False)
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.FlpSellable.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DbxQuantity As ControlLibrary.DecimalBox
    Friend WithEvents LblQuantity As Label
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents DbxCapacity As ControlLibrary.DecimalBox
    Friend WithEvents LblCapacity As Label
    Friend WithEvents FlpSellable As FlowLayoutPanel
    Friend WithEvents QbxSellable As ControlLibrary.QueriedBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents CbxSellableBind As ToolStripComboBox
    Friend WithEvents RbtService As RadioButton
    Friend WithEvents RbtProduct As RadioButton
End Class
