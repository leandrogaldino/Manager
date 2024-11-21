<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCity))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
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
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblName = New System.Windows.Forms.Label()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.CbxStateName = New System.Windows.Forms.ComboBox()
        Me.LblState = New System.Windows.Forms.Label()
        Me.CbxStateShortName = New System.Windows.Forms.ComboBox()
        Me.LblUF = New System.Windows.Forms.Label()
        Me.LblBIGSCode = New System.Windows.Forms.Label()
        Me.TxtBIGSCode = New System.Windows.Forms.TextBox()
        Me.PnRoute = New System.Windows.Forms.Panel()
        Me.DgvRoute = New System.Windows.Forms.DataGridView()
        Me.TsRoute = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeRoute = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditRoute = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteRoute = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterRoute = New System.Windows.Forms.ToolStripTextBox()
        Me.LblRoute = New System.Windows.Forms.Label()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvlRouteLayout = New Manager.DataGridViewLayout()
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnRoute.SuspendLayout()
        CType(Me.DgvRoute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsRoute.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 379)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 44)
        Me.Panel1.TabIndex = 11
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(252, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(151, 7)
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
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreationDate, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(356, 25)
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
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(356, 25)
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
        Me.BtnInclude.Text = "Incluir Cidade"
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
        Me.BtnDelete.Text = "Excluir Cidade"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Cidade"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Cidade Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Cidade"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Cidade"
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
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(12, 50)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "Nome"
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(15, 70)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtName.MaxLength = 50
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(248, 23)
        Me.TxtName.TabIndex = 3
        '
        'CbxStateName
        '
        Me.CbxStateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxStateName.FormattingEnabled = True
        Me.CbxStateName.Items.AddRange(New Object() {"ACRE", "ALAGOAS", "AMAPA", "AMAZONAS", "BAHIA", "CEARA", "DISTRITO FEDERAL", "ESPIRITO SANTO", "GOIAS", "MARANHAO", "MATO GROSSO", "MATO GROSSO DO SUL", "MINAS GERAIS", "PARA", "PARAIBA", "PARANA", "PERNAMBUCO", "PIAUI", "RIO DE JANEIRO", "RIO GRANDE DO NORTE", "RIO GRANDE DO SUL", "RONDONIA", "RORAIMA", "SANTA CATARINA", "SAO PAULO", "SERGIPE", "TOCANTINS"})
        Me.CbxStateName.Location = New System.Drawing.Point(15, 119)
        Me.CbxStateName.Name = "CbxStateName"
        Me.CbxStateName.Size = New System.Drawing.Size(248, 25)
        Me.CbxStateName.TabIndex = 7
        '
        'LblState
        '
        Me.LblState.AutoSize = True
        Me.LblState.Location = New System.Drawing.Point(12, 99)
        Me.LblState.Name = "LblState"
        Me.LblState.Size = New System.Drawing.Size(52, 17)
        Me.LblState.TabIndex = 6
        Me.LblState.Text = "Estado"
        '
        'CbxStateShortName
        '
        Me.CbxStateShortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxStateShortName.FormattingEnabled = True
        Me.CbxStateShortName.Items.AddRange(New Object() {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"})
        Me.CbxStateShortName.Location = New System.Drawing.Point(269, 119)
        Me.CbxStateShortName.Name = "CbxStateShortName"
        Me.CbxStateShortName.Size = New System.Drawing.Size(75, 25)
        Me.CbxStateShortName.TabIndex = 9
        '
        'LblUF
        '
        Me.LblUF.AutoSize = True
        Me.LblUF.Location = New System.Drawing.Point(266, 99)
        Me.LblUF.Name = "LblUF"
        Me.LblUF.Size = New System.Drawing.Size(22, 17)
        Me.LblUF.TabIndex = 8
        Me.LblUF.Text = "UF"
        '
        'LblBIGSCode
        '
        Me.LblBIGSCode.AutoSize = True
        Me.LblBIGSCode.Location = New System.Drawing.Point(266, 50)
        Me.LblBIGSCode.Name = "LblBIGSCode"
        Me.LblBIGSCode.Size = New System.Drawing.Size(73, 17)
        Me.LblBIGSCode.TabIndex = 4
        Me.LblBIGSCode.Text = "Cod. IBGE"
        '
        'TxtBIGSCode
        '
        Me.TxtBIGSCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBIGSCode.Location = New System.Drawing.Point(269, 70)
        Me.TxtBIGSCode.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtBIGSCode.MaxLength = 7
        Me.TxtBIGSCode.Name = "TxtBIGSCode"
        Me.TxtBIGSCode.Size = New System.Drawing.Size(75, 23)
        Me.TxtBIGSCode.TabIndex = 5
        '
        'PnRoute
        '
        Me.PnRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnRoute.Controls.Add(Me.DgvRoute)
        Me.PnRoute.Controls.Add(Me.TsRoute)
        Me.PnRoute.Location = New System.Drawing.Point(15, 167)
        Me.PnRoute.Name = "PnRoute"
        Me.PnRoute.Size = New System.Drawing.Size(329, 206)
        Me.PnRoute.TabIndex = 9
        '
        'DgvRoute
        '
        Me.DgvRoute.AllowUserToAddRows = False
        Me.DgvRoute.AllowUserToDeleteRows = False
        Me.DgvRoute.AllowUserToOrderColumns = True
        Me.DgvRoute.AllowUserToResizeRows = False
        Me.DgvRoute.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvRoute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRoute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRoute.Location = New System.Drawing.Point(0, 25)
        Me.DgvRoute.MultiSelect = False
        Me.DgvRoute.Name = "DgvRoute"
        Me.DgvRoute.ReadOnly = True
        Me.DgvRoute.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvRoute.RowHeadersVisible = False
        Me.DgvRoute.RowTemplate.Height = 26
        Me.DgvRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRoute.Size = New System.Drawing.Size(327, 179)
        Me.DgvRoute.TabIndex = 1
        '
        'TsRoute
        '
        Me.TsRoute.BackColor = System.Drawing.Color.Transparent
        Me.TsRoute.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsRoute.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsRoute.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeRoute, Me.BtnEditRoute, Me.BtnDeleteRoute, Me.ToolStripLabel2, Me.TxtFilterRoute})
        Me.TsRoute.Location = New System.Drawing.Point(0, 0)
        Me.TsRoute.Name = "TsRoute"
        Me.TsRoute.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsRoute.Size = New System.Drawing.Size(327, 25)
        Me.TsRoute.TabIndex = 0
        Me.TsRoute.Text = "ToolStrip2"
        '
        'BtnIncludeRoute
        '
        Me.BtnIncludeRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeRoute.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeRoute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeRoute.Name = "BtnIncludeRoute"
        Me.BtnIncludeRoute.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeRoute.Text = "Incluir Rota"
        '
        'BtnEditRoute
        '
        Me.BtnEditRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditRoute.Enabled = False
        Me.BtnEditRoute.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditRoute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditRoute.Name = "BtnEditRoute"
        Me.BtnEditRoute.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditRoute.Text = "Editar Rota"
        Me.BtnEditRoute.ToolTipText = "Editar Rota"
        '
        'BtnDeleteRoute
        '
        Me.BtnDeleteRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteRoute.Enabled = False
        Me.BtnDeleteRoute.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteRoute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteRoute.Name = "BtnDeleteRoute"
        Me.BtnDeleteRoute.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteRoute.Text = "Excluir Rota"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(46, 25)
        Me.ToolStripLabel2.Text = "Filtrar:"
        '
        'TxtFilterRoute
        '
        Me.TxtFilterRoute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterRoute.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterRoute.Name = "TxtFilterRoute"
        Me.TxtFilterRoute.Size = New System.Drawing.Size(150, 25)
        '
        'LblRoute
        '
        Me.LblRoute.AutoSize = True
        Me.LblRoute.Location = New System.Drawing.Point(12, 147)
        Me.LblRoute.Name = "LblRoute"
        Me.LblRoute.Size = New System.Drawing.Size(44, 17)
        Me.LblRoute.TabIndex = 10
        Me.LblRoute.Text = "Rotas"
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'DgvlRouteLayout
        '
        Me.DgvlRouteLayout.DataGridView = Me.DgvRoute
        Me.DgvlRouteLayout.Routine = Manager.Routine.CityRoute
        '
        'FrmCity
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(356, 423)
        Me.Controls.Add(Me.CbxStateShortName)
        Me.Controls.Add(Me.CbxStateName)
        Me.Controls.Add(Me.TxtBIGSCode)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.LblUF)
        Me.Controls.Add(Me.LblBIGSCode)
        Me.Controls.Add(Me.LblRoute)
        Me.Controls.Add(Me.LblState)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.PnRoute)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCity"
        Me.ShowIcon = False
        Me.Text = "Cidade"
        Me.Panel1.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnRoute.ResumeLayout(False)
        Me.PnRoute.PerformLayout()
        CType(Me.DgvRoute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsRoute.ResumeLayout(False)
        Me.TsRoute.PerformLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents CbxStateShortName As ComboBox
    Friend WithEvents CbxStateName As ComboBox
    Friend WithEvents TxtBIGSCode As TextBox
    Friend WithEvents LblUF As Label
    Friend WithEvents LblBIGSCode As Label
    Friend WithEvents LblState As Label
    Friend WithEvents PnRoute As Panel
    Friend WithEvents LblRoute As Label
    Friend WithEvents TsRoute As ToolStrip
    Friend WithEvents BtnIncludeRoute As ToolStripButton
    Friend WithEvents BtnEditRoute As ToolStripButton
    Friend WithEvents BtnDeleteRoute As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TxtFilterRoute As ToolStripTextBox
    Friend WithEvents DgvRoute As DataGridView
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents DgvlRouteLayout As DataGridViewLayout
End Class
