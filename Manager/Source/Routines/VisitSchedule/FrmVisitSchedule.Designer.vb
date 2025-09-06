<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVisitSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisitSchedule))
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Condition3 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField3 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField4 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter3 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation1 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation2 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Relation3 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Dim Condition4 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField5 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField6 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField7 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter4 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Relation4 As ControlLibrary.QueriedBox.Relation = New ControlLibrary.QueriedBox.Relation()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatusValue = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.LblCreationDate = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtInstructions = New System.Windows.Forms.TextBox()
        Me.LblInstructions = New System.Windows.Forms.Label()
        Me.FlpCustomer = New System.Windows.Forms.FlowLayoutPanel()
        Me.LblCustomer = New System.Windows.Forms.Label()
        Me.LblCompressor = New System.Windows.Forms.Label()
        Me.TmrCustomer = New System.Windows.Forms.Timer(Me.components)
        Me.LblScheduledDate = New System.Windows.Forms.Label()
        Me.TxtPerformedTime = New System.Windows.Forms.MaskedTextBox()
        Me.TxtPerformedDate = New System.Windows.Forms.TextBox()
        Me.LblPerformedDate = New System.Windows.Forms.Label()
        Me.LblCallType = New System.Windows.Forms.Label()
        Me.LblGeneratedItems = New System.Windows.Forms.Label()
        Me.BtnGeneratedItems = New ControlLibrary.NoFocusCueButton()
        Me.CbxCallType = New ControlLibrary.CentralizedComboBox()
        Me.TbxScheduledTime = New ControlLibrary.TimeBox()
        Me.DbxScheduledDate = New ControlLibrary.DateBox()
        Me.QbxCustomer = New ControlLibrary.QueriedBox()
        Me.BtnFilterCustomer = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewCustomer = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewCustomer = New ControlLibrary.NoFocusCueButton()
        Me.QbxCompressor = New ControlLibrary.QueriedBox()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.CcoGeneratedItems = New ControlLibrary.ControlContainer()
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlpCustomer.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 315)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(639, 44)
        Me.Panel1.TabIndex = 16
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(517, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(416, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsTitle
        '
        Me.TsTitle.AutoSize = False
        Me.TsTitle.BackColor = System.Drawing.Color.White
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.LblStatusValue, Me.BtnStatusValue, Me.LblCreationDate, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(639, 25)
        Me.TsTitle.TabIndex = 1
        Me.TsTitle.Text = "ToolStrip1"
        '
        'LblID
        '
        Me.LblID.BackColor = System.Drawing.Color.White
        Me.LblID.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblID.Name = "LblID"
        Me.LblID.Size = New System.Drawing.Size(24, 22)
        Me.LblID.Text = "ID:"
        '
        'LblIDValue
        '
        Me.LblIDValue.BackColor = System.Drawing.Color.White
        Me.LblIDValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIDValue.Name = "LblIDValue"
        Me.LblIDValue.Size = New System.Drawing.Size(32, 22)
        Me.LblIDValue.Text = "      "
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
        Me.LblStatusValue.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LblStatusValue.Image = CType(resources.GetObject("LblStatusValue.Image"), System.Drawing.Image)
        Me.LblStatusValue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LblStatusValue.Name = "LblStatusValue"
        Me.LblStatusValue.Size = New System.Drawing.Size(40, 22)
        Me.LblStatusValue.Text = "        "
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
        'LblCreationDate
        '
        Me.LblCreationDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreationDate.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.LblCreationDate.Name = "LblCreationDate"
        Me.LblCreationDate.Size = New System.Drawing.Size(64, 22)
        Me.LblCreationDate.Text = "Criação:"
        '
        'LblCreationValue
        '
        Me.LblCreationValue.BackColor = System.Drawing.Color.White
        Me.LblCreationValue.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreationValue.Name = "LblCreationValue"
        Me.LblCreationValue.Size = New System.Drawing.Size(32, 22)
        Me.LblCreationValue.Text = "      "
        '
        'TsNavigation
        '
        Me.TsNavigation.AutoSize = False
        Me.TsNavigation.BackColor = System.Drawing.Color.White
        Me.TsNavigation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(639, 25)
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
        Me.BtnInclude.Text = "Incluir Agendamento de Visita"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Agendamento de Visita"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Agendamento de Visita"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Agendamento de Visita Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Agendamento de Visita"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Agendamento de Visita"
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TxtInstructions
        '
        Me.TxtInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInstructions.Location = New System.Drawing.Point(15, 170)
        Me.TxtInstructions.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtInstructions.MaxLength = 100
        Me.TxtInstructions.Multiline = True
        Me.TxtInstructions.Name = "TxtInstructions"
        Me.TxtInstructions.Size = New System.Drawing.Size(615, 136)
        Me.TxtInstructions.TabIndex = 15
        '
        'LblInstructions
        '
        Me.LblInstructions.AutoSize = True
        Me.LblInstructions.Location = New System.Drawing.Point(12, 150)
        Me.LblInstructions.Name = "LblInstructions"
        Me.LblInstructions.Size = New System.Drawing.Size(71, 17)
        Me.LblInstructions.TabIndex = 14
        Me.LblInstructions.Text = "Instruções"
        '
        'FlpCustomer
        '
        Me.FlpCustomer.Controls.Add(Me.BtnFilterCustomer)
        Me.FlpCustomer.Controls.Add(Me.BtnViewCustomer)
        Me.FlpCustomer.Controls.Add(Me.BtnNewCustomer)
        Me.FlpCustomer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpCustomer.Location = New System.Drawing.Point(262, 101)
        Me.FlpCustomer.Name = "FlpCustomer"
        Me.FlpCustomer.Size = New System.Drawing.Size(69, 21)
        Me.FlpCustomer.TabIndex = 11
        '
        'LblCustomer
        '
        Me.LblCustomer.AutoSize = True
        Me.LblCustomer.Location = New System.Drawing.Point(12, 102)
        Me.LblCustomer.Name = "LblCustomer"
        Me.LblCustomer.Size = New System.Drawing.Size(54, 17)
        Me.LblCustomer.TabIndex = 9
        Me.LblCustomer.Text = "Cliente"
        '
        'LblCompressor
        '
        Me.LblCompressor.AutoSize = True
        Me.LblCompressor.Location = New System.Drawing.Point(335, 104)
        Me.LblCompressor.Name = "LblCompressor"
        Me.LblCompressor.Size = New System.Drawing.Size(85, 17)
        Me.LblCompressor.TabIndex = 12
        Me.LblCompressor.Text = "Compressor"
        '
        'TmrCustomer
        '
        Me.TmrCustomer.Enabled = True
        Me.TmrCustomer.Interval = 300
        '
        'LblScheduledDate
        '
        Me.LblScheduledDate.AutoSize = True
        Me.LblScheduledDate.Location = New System.Drawing.Point(166, 50)
        Me.LblScheduledDate.Name = "LblScheduledDate"
        Me.LblScheduledDate.Size = New System.Drawing.Size(115, 17)
        Me.LblScheduledDate.TabIndex = 19
        Me.LblScheduledDate.Text = "Data Agendada"
        '
        'TxtPerformedTime
        '
        Me.TxtPerformedTime.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt
        Me.TxtPerformedTime.Location = New System.Drawing.Point(423, 70)
        Me.TxtPerformedTime.Name = "TxtPerformedTime"
        Me.TxtPerformedTime.ReadOnly = True
        Me.TxtPerformedTime.Size = New System.Drawing.Size(50, 23)
        Me.TxtPerformedTime.TabIndex = 21
        Me.TxtPerformedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtPerformedTime.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.TxtPerformedTime.ValidatingType = GetType(Date)
        '
        'TxtPerformedDate
        '
        Me.TxtPerformedDate.Location = New System.Drawing.Point(324, 70)
        Me.TxtPerformedDate.Name = "TxtPerformedDate"
        Me.TxtPerformedDate.ReadOnly = True
        Me.TxtPerformedDate.Size = New System.Drawing.Size(100, 23)
        Me.TxtPerformedDate.TabIndex = 20
        Me.TxtPerformedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPerformedDate
        '
        Me.LblPerformedDate.AutoSize = True
        Me.LblPerformedDate.Location = New System.Drawing.Point(321, 50)
        Me.LblPerformedDate.Name = "LblPerformedDate"
        Me.LblPerformedDate.Size = New System.Drawing.Size(109, 17)
        Me.LblPerformedDate.TabIndex = 19
        Me.LblPerformedDate.Text = "Data Realizada"
        '
        'LblCallType
        '
        Me.LblCallType.AutoSize = True
        Me.LblCallType.Location = New System.Drawing.Point(12, 50)
        Me.LblCallType.Name = "LblCallType"
        Me.LblCallType.Size = New System.Drawing.Size(93, 17)
        Me.LblCallType.TabIndex = 23
        Me.LblCallType.Text = "Tipo de Visita"
        '
        'LblGeneratedItems
        '
        Me.LblGeneratedItems.AutoSize = True
        Me.LblGeneratedItems.Location = New System.Drawing.Point(476, 50)
        Me.LblGeneratedItems.Name = "LblGeneratedItems"
        Me.LblGeneratedItems.Size = New System.Drawing.Size(151, 17)
        Me.LblGeneratedItems.TabIndex = 19
        Me.LblGeneratedItems.Text = "Avaliação/Sobrescrita"
        '
        'BtnGeneratedItems
        '
        Me.BtnGeneratedItems.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.BtnGeneratedItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGeneratedItems.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGeneratedItems.Location = New System.Drawing.Point(479, 70)
        Me.BtnGeneratedItems.Name = "BtnGeneratedItems"
        Me.BtnGeneratedItems.Size = New System.Drawing.Size(148, 23)
        Me.BtnGeneratedItems.TabIndex = 25
        Me.BtnGeneratedItems.Text = "Não | Não"
        Me.BtnGeneratedItems.TooltipText = ""
        Me.BtnGeneratedItems.UseVisualStyleBackColor = True
        '
        'CbxCallType
        '
        Me.CbxCallType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CbxCallType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCallType.FormattingEnabled = True
        Me.CbxCallType.Location = New System.Drawing.Point(15, 70)
        Me.CbxCallType.Margin = New System.Windows.Forms.Padding(8)
        Me.CbxCallType.Name = "CbxCallType"
        Me.CbxCallType.Size = New System.Drawing.Size(143, 24)
        Me.CbxCallType.TabIndex = 24
        '
        'TbxScheduledTime
        '
        Me.TbxScheduledTime.Location = New System.Drawing.Point(268, 70)
        Me.TbxScheduledTime.MinimumSize = New System.Drawing.Size(50, 0)
        Me.TbxScheduledTime.Name = "TbxScheduledTime"
        Me.TbxScheduledTime.ShowSecconds = False
        Me.TbxScheduledTime.Size = New System.Drawing.Size(50, 23)
        Me.TbxScheduledTime.TabIndex = 18
        Me.TbxScheduledTime.Text = "  :"
        Me.TbxScheduledTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TbxScheduledTime.Time = Nothing
        '
        'DbxScheduledDate
        '
        Me.DbxScheduledDate.ButtonImage = CType(resources.GetObject("DbxScheduledDate.ButtonImage"), System.Drawing.Image)
        Me.DbxScheduledDate.Date = New Date(1995, 8, 4, 0, 0, 0, 0)
        Me.DbxScheduledDate.Location = New System.Drawing.Point(169, 70)
        Me.DbxScheduledDate.MinimumSize = New System.Drawing.Size(100, 4)
        Me.DbxScheduledDate.Name = "DbxScheduledDate"
        Me.DbxScheduledDate.Size = New System.Drawing.Size(100, 23)
        Me.DbxScheduledDate.TabIndex = 17
        Me.DbxScheduledDate.Text = "04/08/1995"
        '
        'QbxCustomer
        '
        Me.QbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCustomer.CharactersToQuery = 1
        Condition1.FieldName = "iscustomer"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@iscustomer"
        Condition2.FieldName = "statusid"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@statusid"
        Condition3.FieldName = "controlmaintenance"
        Condition3.Operator = "="
        Condition3.TableNameOrAlias = "person"
        Condition3.Value = "@controlmaintenance"
        Me.QbxCustomer.Conditions.Add(Condition1)
        Me.QbxCustomer.Conditions.Add(Condition2)
        Me.QbxCustomer.Conditions.Add(Condition3)
        Me.QbxCustomer.DebugOnTextChanged = False
        Me.QbxCustomer.DisplayFieldAlias = "Nome Curto"
        Me.QbxCustomer.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxCustomer.DisplayFieldName = "shortname"
        Me.QbxCustomer.DisplayMainFieldName = "id"
        Me.QbxCustomer.DisplayTableAlias = Nothing
        Me.QbxCustomer.DisplayTableName = "person"
        Me.QbxCustomer.Distinct = True
        Me.QbxCustomer.DropDownAutoStretchRight = False
        Me.QbxCustomer.DropDownStretchDown = 150
        Me.QbxCustomer.DropDownStretchRight = 298
        Me.QbxCustomer.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCustomer.IfNull = Nothing
        Me.QbxCustomer.Location = New System.Drawing.Point(15, 122)
        Me.QbxCustomer.MainReturnFieldName = "id"
        Me.QbxCustomer.MainTableAlias = Nothing
        Me.QbxCustomer.MainTableName = "person"
        Me.QbxCustomer.Name = "QbxCustomer"
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
        OtherField2.DisplayFieldAlias = "CNPJ/CPF"
        OtherField2.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        OtherField3.DisplayFieldAlias = "Cidade"
        OtherField3.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField3.DisplayFieldName = "name"
        OtherField3.DisplayMainFieldName = "id"
        OtherField3.DisplayTableAlias = Nothing
        OtherField3.DisplayTableName = "city"
        OtherField3.Freeze = False
        OtherField3.IfNull = Nothing
        OtherField3.Prefix = Nothing
        OtherField3.Suffix = Nothing
        OtherField4.DisplayFieldAlias = "Estado"
        OtherField4.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField4.DisplayFieldName = "name"
        OtherField4.DisplayMainFieldName = "id"
        OtherField4.DisplayTableAlias = Nothing
        OtherField4.DisplayTableName = "state"
        OtherField4.Freeze = False
        OtherField4.IfNull = Nothing
        OtherField4.Prefix = Nothing
        OtherField4.Suffix = Nothing
        Me.QbxCustomer.OtherFields.Add(OtherField1)
        Me.QbxCustomer.OtherFields.Add(OtherField2)
        Me.QbxCustomer.OtherFields.Add(OtherField3)
        Me.QbxCustomer.OtherFields.Add(OtherField4)
        Parameter1.ParameterName = "@iscustomer"
        Parameter1.ParameterValue = "1"
        Parameter2.ParameterName = "@statusid"
        Parameter2.ParameterValue = "0"
        Parameter3.ParameterName = "@controlmaintenance"
        Parameter3.ParameterValue = "1"
        Me.QbxCustomer.Parameters.Add(Parameter1)
        Me.QbxCustomer.Parameters.Add(Parameter2)
        Me.QbxCustomer.Parameters.Add(Parameter3)
        Me.QbxCustomer.Prefix = Nothing
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
        Me.QbxCustomer.Relations.Add(Relation1)
        Me.QbxCustomer.Relations.Add(Relation2)
        Me.QbxCustomer.Relations.Add(Relation3)
        Me.QbxCustomer.Size = New System.Drawing.Size(317, 23)
        Me.QbxCustomer.Suffix = Nothing
        Me.QbxCustomer.TabIndex = 10
        '
        'BtnFilterCustomer
        '
        Me.BtnFilterCustomer.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterCustomer.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterCustomer.FlatAppearance.BorderSize = 0
        Me.BtnFilterCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterCustomer.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterCustomer.Name = "BtnFilterCustomer"
        Me.BtnFilterCustomer.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterCustomer.TabIndex = 2
        Me.BtnFilterCustomer.TabStop = False
        Me.BtnFilterCustomer.TooltipText = ""
        Me.BtnFilterCustomer.UseVisualStyleBackColor = False
        Me.BtnFilterCustomer.Visible = False
        '
        'BtnViewCustomer
        '
        Me.BtnViewCustomer.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewCustomer.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewCustomer.FlatAppearance.BorderSize = 0
        Me.BtnViewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewCustomer.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewCustomer.Name = "BtnViewCustomer"
        Me.BtnViewCustomer.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewCustomer.TabIndex = 1
        Me.BtnViewCustomer.TabStop = False
        Me.BtnViewCustomer.TooltipText = ""
        Me.BtnViewCustomer.UseVisualStyleBackColor = False
        Me.BtnViewCustomer.Visible = False
        '
        'BtnNewCustomer
        '
        Me.BtnNewCustomer.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewCustomer.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewCustomer.FlatAppearance.BorderSize = 0
        Me.BtnNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewCustomer.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewCustomer.Name = "BtnNewCustomer"
        Me.BtnNewCustomer.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewCustomer.TabIndex = 0
        Me.BtnNewCustomer.TabStop = False
        Me.BtnNewCustomer.TooltipText = ""
        Me.BtnNewCustomer.UseVisualStyleBackColor = False
        Me.BtnNewCustomer.Visible = False
        '
        'QbxCompressor
        '
        Me.QbxCompressor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxCompressor.CharactersToQuery = 1
        Condition4.FieldName = "statusid"
        Condition4.Operator = "="
        Condition4.TableNameOrAlias = "personcompressor"
        Condition4.Value = "@statusid"
        Me.QbxCompressor.Conditions.Add(Condition4)
        Me.QbxCompressor.DebugOnTextChanged = False
        Me.QbxCompressor.DisplayFieldAlias = "Compressor"
        Me.QbxCompressor.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        Me.QbxCompressor.DisplayFieldName = "name"
        Me.QbxCompressor.DisplayMainFieldName = "id"
        Me.QbxCompressor.DisplayTableAlias = Nothing
        Me.QbxCompressor.DisplayTableName = "compressor"
        Me.QbxCompressor.Distinct = False
        Me.QbxCompressor.DropDownAutoStretchRight = False
        Me.QbxCompressor.DropDownStretchDown = 150
        Me.QbxCompressor.DropDownStretchLeft = 299
        Me.QbxCompressor.Enabled = False
        Me.QbxCompressor.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxCompressor.IfNull = Nothing
        Me.QbxCompressor.Location = New System.Drawing.Point(338, 122)
        Me.QbxCompressor.MainReturnFieldName = "id"
        Me.QbxCompressor.MainTableAlias = Nothing
        Me.QbxCompressor.MainTableName = "personcompressor"
        Me.QbxCompressor.Name = "QbxCompressor"
        OtherField5.DisplayFieldAlias = "Nº de Série"
        OtherField5.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField5.DisplayFieldName = "serialnumber"
        OtherField5.DisplayMainFieldName = "id"
        OtherField5.DisplayTableAlias = Nothing
        OtherField5.DisplayTableName = "personcompressor"
        OtherField5.Freeze = True
        OtherField5.IfNull = Nothing
        OtherField5.Prefix = " NS: "
        OtherField5.Suffix = Nothing
        OtherField6.DisplayFieldAlias = "Patrimônio"
        OtherField6.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField6.DisplayFieldName = "patrimony"
        OtherField6.DisplayMainFieldName = "id"
        OtherField6.DisplayTableAlias = Nothing
        OtherField6.DisplayTableName = "personcompressor"
        OtherField6.Freeze = True
        OtherField6.IfNull = Nothing
        OtherField6.Prefix = " PAT: "
        OtherField6.Suffix = Nothing
        OtherField7.DisplayFieldAlias = "Setor"
        OtherField7.DisplayFieldAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet
        OtherField7.DisplayFieldName = "sector"
        OtherField7.DisplayMainFieldName = "id"
        OtherField7.DisplayTableAlias = Nothing
        OtherField7.DisplayTableName = "personcompressor"
        OtherField7.Freeze = True
        OtherField7.IfNull = Nothing
        OtherField7.Prefix = " SETOR: "
        OtherField7.Suffix = Nothing
        Me.QbxCompressor.OtherFields.Add(OtherField5)
        Me.QbxCompressor.OtherFields.Add(OtherField6)
        Me.QbxCompressor.OtherFields.Add(OtherField7)
        Parameter4.ParameterName = "@statusid"
        Parameter4.ParameterValue = "0"
        Me.QbxCompressor.Parameters.Add(Parameter4)
        Me.QbxCompressor.Prefix = Nothing
        Relation4.Operator = "="
        Relation4.RelateFieldName = "id"
        Relation4.RelateTableAlias = Nothing
        Relation4.RelateTableName = "compressor"
        Relation4.RelationType = "INNER"
        Relation4.WithFieldName = "compressorid"
        Relation4.WithTableAlias = Nothing
        Relation4.WithTableName = "personcompressor"
        Me.QbxCompressor.Relations.Add(Relation4)
        Me.QbxCompressor.Size = New System.Drawing.Size(292, 23)
        Me.QbxCompressor.Suffix = Nothing
        Me.QbxCompressor.TabIndex = 13
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'CcoGeneratedItems
        '
        Me.CcoGeneratedItems.DropDownBorderColor = System.Drawing.SystemColors.HotTrack
        Me.CcoGeneratedItems.DropDownControl = Nothing
        Me.CcoGeneratedItems.DropDownEnabled = True
        Me.CcoGeneratedItems.HostControl = Me.BtnGeneratedItems
        '
        'FrmVisitSchedule
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(639, 359)
        Me.Controls.Add(Me.BtnGeneratedItems)
        Me.Controls.Add(Me.CbxCallType)
        Me.Controls.Add(Me.LblCallType)
        Me.Controls.Add(Me.TxtPerformedTime)
        Me.Controls.Add(Me.TxtPerformedDate)
        Me.Controls.Add(Me.LblGeneratedItems)
        Me.Controls.Add(Me.LblPerformedDate)
        Me.Controls.Add(Me.LblScheduledDate)
        Me.Controls.Add(Me.TbxScheduledTime)
        Me.Controls.Add(Me.DbxScheduledDate)
        Me.Controls.Add(Me.QbxCustomer)
        Me.Controls.Add(Me.FlpCustomer)
        Me.Controls.Add(Me.LblCustomer)
        Me.Controls.Add(Me.LblCompressor)
        Me.Controls.Add(Me.QbxCompressor)
        Me.Controls.Add(Me.TxtInstructions)
        Me.Controls.Add(Me.LblInstructions)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVisitSchedule"
        Me.ShowIcon = False
        Me.Text = "Agenda de Visita"
        Me.Panel1.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlpCustomer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents LblCreationDate As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents TxtInstructions As TextBox
    Friend WithEvents LblInstructions As Label
    Friend WithEvents QbxCustomer As ControlLibrary.QueriedBox
    Friend WithEvents FlpCustomer As FlowLayoutPanel
    Friend WithEvents BtnFilterCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNewCustomer As ControlLibrary.NoFocusCueButton
    Friend WithEvents LblCustomer As Label
    Friend WithEvents LblCompressor As Label
    Friend WithEvents QbxCompressor As ControlLibrary.QueriedBox
    Friend WithEvents LblStatusValue As ToolStripLabel
    Friend WithEvents TmrCustomer As Timer
    Friend WithEvents TbxScheduledTime As ControlLibrary.TimeBox
    Friend WithEvents DbxScheduledDate As ControlLibrary.DateBox
    Friend WithEvents LblScheduledDate As Label
    Friend WithEvents TxtPerformedTime As MaskedTextBox
    Friend WithEvents TxtPerformedDate As TextBox
    Friend WithEvents LblPerformedDate As Label
    Private WithEvents CbxCallType As ControlLibrary.CentralizedComboBox
    Friend WithEvents LblCallType As Label
    Friend WithEvents BtnGeneratedItems As ControlLibrary.NoFocusCueButton
    Friend WithEvents LblGeneratedItems As Label
    Friend WithEvents CcoGeneratedItems As ControlLibrary.ControlContainer
End Class
