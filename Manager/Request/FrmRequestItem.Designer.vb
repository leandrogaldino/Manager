<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRequestItem
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
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
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
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatusValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblItem = New System.Windows.Forms.Label()
        Me.LblTaked = New System.Windows.Forms.Label()
        Me.LblReturned = New System.Windows.Forms.Label()
        Me.LblApplied = New System.Windows.Forms.Label()
        Me.FlpProduct = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.LblPending = New System.Windows.Forms.Label()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.LblLossed = New System.Windows.Forms.Label()
        Me.TxtLostReason = New System.Windows.Forms.TextBox()
        Me.LblLossReason = New System.Windows.Forms.Label()
        Me.QbxItem = New ControlLibrary.QueriedBox()
        Me.DbxPending = New ControlLibrary.DecimalBox()
        Me.DbxLossed = New ControlLibrary.DecimalBox()
        Me.DbxApplied = New ControlLibrary.DecimalBox()
        Me.DbxReturned = New ControlLibrary.DecimalBox()
        Me.DbxTaked = New ControlLibrary.DecimalBox()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TsMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsData.SuspendLayout()
        Me.FlpProduct.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(461, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(360, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Incluir"
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
        Me.TsMain.Size = New System.Drawing.Size(568, 25)
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
        Me.BtnInclude.Text = "Incluir Item"
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
        Me.BtnDelete.Text = "Excluir Item"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Item"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Item Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Item"
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
        Me.BtnLast.Text = "Último Item"
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
        Me.Panel1.Location = New System.Drawing.Point(0, 227)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 44)
        Me.Panel1.TabIndex = 17
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TsData
        '
        Me.TsData.AutoSize = False
        Me.TsData.BackColor = System.Drawing.Color.White
        Me.TsData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblStatus, Me.LblStatusValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(568, 25)
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
        Me.LblOrderValue.Size = New System.Drawing.Size(32, 22)
        Me.LblOrderValue.Text = "      "
        '
        'LblStatus
        '
        Me.LblStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(49, 22)
        Me.LblStatus.Text = "Status:"
        '
        'LblStatusValue
        '
        Me.LblStatusValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblStatusValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.LblStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblStatusValue.Name = "LblStatusValue"
        Me.LblStatusValue.Size = New System.Drawing.Size(32, 22)
        Me.LblStatusValue.Text = "      "
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
        'LblItem
        '
        Me.LblItem.AutoSize = True
        Me.LblItem.Location = New System.Drawing.Point(9, 60)
        Me.LblItem.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.LblItem.Name = "LblItem"
        Me.LblItem.Size = New System.Drawing.Size(37, 17)
        Me.LblItem.TabIndex = 2
        Me.LblItem.Text = "Item"
        '
        'LblTaked
        '
        Me.LblTaked.AutoSize = True
        Me.LblTaked.Location = New System.Drawing.Point(9, 106)
        Me.LblTaked.Name = "LblTaked"
        Me.LblTaked.Size = New System.Drawing.Size(63, 17)
        Me.LblTaked.TabIndex = 5
        Me.LblTaked.Text = "Retirado"
        '
        'LblReturned
        '
        Me.LblReturned.AutoSize = True
        Me.LblReturned.Location = New System.Drawing.Point(119, 106)
        Me.LblReturned.Name = "LblReturned"
        Me.LblReturned.Size = New System.Drawing.Size(75, 17)
        Me.LblReturned.TabIndex = 7
        Me.LblReturned.Text = "Devolvido"
        '
        'LblApplied
        '
        Me.LblApplied.AutoSize = True
        Me.LblApplied.Location = New System.Drawing.Point(229, 106)
        Me.LblApplied.Name = "LblApplied"
        Me.LblApplied.Size = New System.Drawing.Size(67, 17)
        Me.LblApplied.TabIndex = 9
        Me.LblApplied.Text = "Aplicado"
        '
        'FlpProduct
        '
        Me.FlpProduct.Controls.Add(Me.BtnFilter)
        Me.FlpProduct.Controls.Add(Me.BtnView)
        Me.FlpProduct.Controls.Add(Me.BtnNew)
        Me.FlpProduct.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpProduct.Location = New System.Drawing.Point(487, 59)
        Me.FlpProduct.Name = "FlpProduct"
        Me.FlpProduct.Size = New System.Drawing.Size(69, 21)
        Me.FlpProduct.TabIndex = 4
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
        Me.BtnView.TabIndex = 0
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
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.TabStop = False
        Me.BtnNew.TooltipText = ""
        Me.BtnNew.UseVisualStyleBackColor = False
        Me.BtnNew.Visible = False
        '
        'LblPending
        '
        Me.LblPending.AutoSize = True
        Me.LblPending.Location = New System.Drawing.Point(452, 106)
        Me.LblPending.Name = "LblPending"
        Me.LblPending.Size = New System.Drawing.Size(68, 17)
        Me.LblPending.TabIndex = 13
        Me.LblPending.Text = "A Acertar"
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'LblLossed
        '
        Me.LblLossed.AutoSize = True
        Me.LblLossed.Location = New System.Drawing.Point(339, 106)
        Me.LblLossed.Name = "LblLossed"
        Me.LblLossed.Size = New System.Drawing.Size(58, 17)
        Me.LblLossed.TabIndex = 11
        Me.LblLossed.Text = "Perdido"
        '
        'TxtLostReason
        '
        Me.TxtLostReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLostReason.Location = New System.Drawing.Point(12, 177)
        Me.TxtLostReason.Multiline = True
        Me.TxtLostReason.Name = "TxtLostReason"
        Me.TxtLostReason.Size = New System.Drawing.Size(544, 40)
        Me.TxtLostReason.TabIndex = 16
        '
        'LblLossReason
        '
        Me.LblLossReason.AutoSize = True
        Me.LblLossReason.Location = New System.Drawing.Point(9, 157)
        Me.LblLossReason.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblLossReason.Name = "LblLossReason"
        Me.LblLossReason.Size = New System.Drawing.Size(117, 17)
        Me.LblLossReason.TabIndex = 15
        Me.LblLossReason.Text = "Motivo da Perda"
        '
        'QbxItem
        '
        Me.QbxItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxItem.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "product"
        Condition1.Value = "@statusid"
        Me.QbxItem.Conditions.Add(Condition1)
        Me.QbxItem.DebugOnTextChanged = True
        Me.QbxItem.DisplayFieldAlias = "Código"
        Me.QbxItem.DisplayFieldName = "code"
        Me.QbxItem.DisplayMainFieldName = "id"
        Me.QbxItem.DisplayTableAlias = ""
        Me.QbxItem.DisplayTableName = "productprovidercode"
        Me.QbxItem.Distinct = False
        Me.QbxItem.DropDownAutoStretchRight = False
        Me.QbxItem.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxItem.IfNull = Nothing
        Me.QbxItem.Location = New System.Drawing.Point(12, 80)
        Me.QbxItem.MainReturnFieldName = "id"
        Me.QbxItem.MainTableAlias = Nothing
        Me.QbxItem.MainTableName = "product"
        Me.QbxItem.Name = "QbxItem"
        OtherField1.DisplayFieldAlias = "Produto"
        OtherField1.DisplayFieldName = "name"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = ""
        OtherField1.DisplayTableName = "product"
        OtherField1.Freeze = True
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        Me.QbxItem.OtherFields.Add(OtherField1)
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Parameter2.ParameterName = "@ismainprovider"
        Parameter2.ParameterValue = "1"
        Me.QbxItem.Parameters.Add(Parameter1)
        Me.QbxItem.Parameters.Add(Parameter2)
        Me.QbxItem.Prefix = Nothing
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
        Me.QbxItem.Relations.Add(Relation1)
        Me.QbxItem.Size = New System.Drawing.Size(544, 23)
        Me.QbxItem.Suffix = " - "
        Me.QbxItem.TabIndex = 3
        '
        'DbxPending
        '
        Me.DbxPending.BackColor = System.Drawing.Color.White
        Me.DbxPending.DecimalOnly = True
        Me.DbxPending.DecimalPlaces = 2
        Me.DbxPending.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxPending.Location = New System.Drawing.Point(452, 126)
        Me.DbxPending.Name = "DbxPending"
        Me.DbxPending.ReadOnly = True
        Me.DbxPending.Size = New System.Drawing.Size(104, 23)
        Me.DbxPending.TabIndex = 14
        Me.DbxPending.TabStop = False
        Me.DbxPending.Text = "0,00"
        Me.DbxPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DbxLossed
        '
        Me.DbxLossed.DecimalOnly = True
        Me.DbxLossed.DecimalPlaces = 2
        Me.DbxLossed.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxLossed.Location = New System.Drawing.Point(342, 126)
        Me.DbxLossed.Name = "DbxLossed"
        Me.DbxLossed.Size = New System.Drawing.Size(104, 23)
        Me.DbxLossed.TabIndex = 12
        Me.DbxLossed.Text = "0,00"
        Me.DbxLossed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DbxApplied
        '
        Me.DbxApplied.DecimalOnly = True
        Me.DbxApplied.DecimalPlaces = 2
        Me.DbxApplied.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxApplied.Location = New System.Drawing.Point(232, 126)
        Me.DbxApplied.Name = "DbxApplied"
        Me.DbxApplied.Size = New System.Drawing.Size(104, 23)
        Me.DbxApplied.TabIndex = 10
        Me.DbxApplied.Text = "0,00"
        Me.DbxApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DbxReturned
        '
        Me.DbxReturned.DecimalOnly = True
        Me.DbxReturned.DecimalPlaces = 2
        Me.DbxReturned.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxReturned.Location = New System.Drawing.Point(122, 126)
        Me.DbxReturned.Name = "DbxReturned"
        Me.DbxReturned.Size = New System.Drawing.Size(104, 23)
        Me.DbxReturned.TabIndex = 8
        Me.DbxReturned.Text = "0,00"
        Me.DbxReturned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DbxTaked
        '
        Me.DbxTaked.DecimalOnly = True
        Me.DbxTaked.DecimalPlaces = 2
        Me.DbxTaked.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxTaked.Location = New System.Drawing.Point(12, 126)
        Me.DbxTaked.Name = "DbxTaked"
        Me.DbxTaked.Size = New System.Drawing.Size(104, 23)
        Me.DbxTaked.TabIndex = 6
        Me.DbxTaked.Text = "0,00"
        Me.DbxTaked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'FrmRequestItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(568, 271)
        Me.Controls.Add(Me.FlpProduct)
        Me.Controls.Add(Me.QbxItem)
        Me.Controls.Add(Me.LblPending)
        Me.Controls.Add(Me.LblLossed)
        Me.Controls.Add(Me.LblApplied)
        Me.Controls.Add(Me.LblReturned)
        Me.Controls.Add(Me.LblTaked)
        Me.Controls.Add(Me.DbxPending)
        Me.Controls.Add(Me.DbxLossed)
        Me.Controls.Add(Me.DbxApplied)
        Me.Controls.Add(Me.DbxReturned)
        Me.Controls.Add(Me.DbxTaked)
        Me.Controls.Add(Me.LblItem)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.TsMain)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtLostReason)
        Me.Controls.Add(Me.LblLossReason)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRequestItem"
        Me.ShowIcon = False
        Me.Text = "Item da Requisição"
        Me.TsMain.ResumeLayout(False)
        Me.TsMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.FlpProduct.ResumeLayout(False)
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
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents LblStatusValue As ToolStripLabel
    Friend WithEvents DbxReturned As ControlLibrary.DecimalBox
    Friend WithEvents DbxTaked As ControlLibrary.DecimalBox
    Friend WithEvents LblItem As Label
    Friend WithEvents LblApplied As Label
    Friend WithEvents LblReturned As Label
    Friend WithEvents LblTaked As Label
    Friend WithEvents DbxApplied As ControlLibrary.DecimalBox
    Friend WithEvents FlpProduct As FlowLayoutPanel
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents LblPending As Label
    Friend WithEvents DbxPending As ControlLibrary.DecimalBox
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents QbxItem As ControlLibrary.QueriedBox
    Friend WithEvents LblLossed As Label
    Friend WithEvents DbxLossed As ControlLibrary.DecimalBox
    Friend WithEvents TxtLostReason As TextBox
    Friend WithEvents LblLossReason As Label
End Class
