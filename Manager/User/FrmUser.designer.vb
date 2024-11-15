<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUser))
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BtnStatusValue = New System.Windows.Forms.ToolStripButton()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.TsNavigation = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.BtnRequestPassword = New System.Windows.Forms.ToolStripButton()
        Me.BtnImportPrivilege = New System.Windows.Forms.ToolStripButton()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.LblPerson = New System.Windows.Forms.Label()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.LblUsername = New System.Windows.Forms.Label()
        Me.TcUser = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.FlpManufacturer = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.QbxPerson = New ControlLibrary.QueriedBox()
        Me.TabPrivilege = New System.Windows.Forms.TabPage()
        Me.FlpPrivilege = New System.Windows.Forms.FlowLayoutPanel()
        Me.TlpFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.PnFilter = New System.Windows.Forms.Panel()
        Me.LblFilter = New System.Windows.Forms.Label()
        Me.TxtFilterPrivileges = New System.Windows.Forms.TextBox()
        Me.TabEmail = New System.Windows.Forms.TabPage()
        Me.DgvEmail = New System.Windows.Forms.DataGridView()
        Me.TsEmail = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeEmail = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditEmail = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteEmail = New System.Windows.Forms.ToolStripButton()
        Me.TxtFilterEmail = New System.Windows.Forms.ToolStripTextBox()
        Me.TabNote = New System.Windows.Forms.TabPage()
        Me.TxtNote = New System.Windows.Forms.RichTextBox()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.DgvEmailLayout = New Manager.DataGridViewLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnButtons.SuspendLayout()
        Me.TcUser.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.FlpManufacturer.SuspendLayout()
        Me.TabPrivilege.SuspendLayout()
        Me.TlpFilter.SuspendLayout()
        Me.PnFilter.SuspendLayout()
        Me.TabEmail.SuspendLayout()
        CType(Me.DgvEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsEmail.SuspendLayout()
        Me.TabNote.SuspendLayout()
        Me.SuspendLayout()
        '
        'TsTitle
        '
        Me.TsTitle.AutoSize = False
        Me.TsTitle.BackColor = System.Drawing.Color.White
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblStatus, Me.BtnStatusValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(459, 25)
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
        Me.BtnStatusValue.Image = CType(resources.GetObject("BtnStatusValue.Image"), System.Drawing.Image)
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
        'TsNavigation
        '
        Me.TsNavigation.AutoSize = False
        Me.TsNavigation.BackColor = System.Drawing.Color.White
        Me.TsNavigation.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsNavigation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsNavigation.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TsNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog, Me.BtnRequestPassword, Me.BtnImportPrivilege})
        Me.TsNavigation.Location = New System.Drawing.Point(0, 0)
        Me.TsNavigation.Name = "TsNavigation"
        Me.TsNavigation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsNavigation.Size = New System.Drawing.Size(459, 25)
        Me.TsNavigation.TabIndex = 0
        Me.TsNavigation.Text = "ToolStrip2"
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Margin = New System.Windows.Forms.Padding(1, 1, 0, 2)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Usuário"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Usuário"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Usuário"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Usuário Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Usuário"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Usuário"
        '
        'BtnLog
        '
        Me.BtnLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLog.Image = Global.Manager.My.Resources.Resources.Log
        Me.BtnLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(23, 22)
        Me.BtnLog.Text = "Histórico"
        '
        'BtnRequestPassword
        '
        Me.BtnRequestPassword.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnRequestPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRequestPassword.Image = Global.Manager.My.Resources.Resources.ResetPassword
        Me.BtnRequestPassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnRequestPassword.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRequestPassword.Name = "BtnRequestPassword"
        Me.BtnRequestPassword.Size = New System.Drawing.Size(23, 22)
        Me.BtnRequestPassword.Tag = ""
        Me.BtnRequestPassword.Text = "Resetar Senha"
        '
        'BtnImportPrivilege
        '
        Me.BtnImportPrivilege.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnImportPrivilege.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnImportPrivilege.Image = Global.Manager.My.Resources.Resources.ImportSmall
        Me.BtnImportPrivilege.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnImportPrivilege.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImportPrivilege.Name = "BtnImportPrivilege"
        Me.BtnImportPrivilege.Size = New System.Drawing.Size(23, 22)
        Me.BtnImportPrivilege.Text = "Importar Permissões Predefinidas"
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
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.White
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Controls.Add(Me.BtnClose)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 147)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(459, 44)
        Me.PnButtons.TabIndex = 3
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(248, 7)
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
        Me.BtnClose.Location = New System.Drawing.Point(349, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'LblPerson
        '
        Me.LblPerson.AutoSize = True
        Me.LblPerson.Location = New System.Drawing.Point(112, 13)
        Me.LblPerson.Name = "LblPerson"
        Me.LblPerson.Size = New System.Drawing.Size(122, 17)
        Me.LblPerson.TabIndex = 2
        Me.LblPerson.Text = "Pessoa Vinculada"
        '
        'TxtUsername
        '
        Me.TxtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUsername.Location = New System.Drawing.Point(9, 33)
        Me.TxtUsername.MaxLength = 20
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(100, 23)
        Me.TxtUsername.TabIndex = 1
        '
        'LblUsername
        '
        Me.LblUsername.AutoSize = True
        Me.LblUsername.Location = New System.Drawing.Point(6, 13)
        Me.LblUsername.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.LblUsername.Name = "LblUsername"
        Me.LblUsername.Size = New System.Drawing.Size(54, 17)
        Me.LblUsername.TabIndex = 0
        Me.LblUsername.Text = "Usuário"
        '
        'TcUser
        '
        Me.TcUser.Controls.Add(Me.TabMain)
        Me.TcUser.Controls.Add(Me.TabPrivilege)
        Me.TcUser.Controls.Add(Me.TabEmail)
        Me.TcUser.Controls.Add(Me.TabNote)
        Me.TcUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcUser.Location = New System.Drawing.Point(0, 50)
        Me.TcUser.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcUser.Multiline = True
        Me.TcUser.Name = "TcUser"
        Me.TcUser.SelectedIndex = 0
        Me.TcUser.Size = New System.Drawing.Size(459, 97)
        Me.TcUser.TabIndex = 2
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.FlpManufacturer)
        Me.TabMain.Controls.Add(Me.QbxPerson)
        Me.TabMain.Controls.Add(Me.LblUsername)
        Me.TabMain.Controls.Add(Me.TxtUsername)
        Me.TabMain.Controls.Add(Me.LblPerson)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMain.Size = New System.Drawing.Size(451, 67)
        Me.TabMain.TabIndex = 9
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'FlpManufacturer
        '
        Me.FlpManufacturer.Controls.Add(Me.BtnFilter)
        Me.FlpManufacturer.Controls.Add(Me.BtnView)
        Me.FlpManufacturer.Controls.Add(Me.BtnNew)
        Me.FlpManufacturer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpManufacturer.Location = New System.Drawing.Point(375, 12)
        Me.FlpManufacturer.Name = "FlpManufacturer"
        Me.FlpManufacturer.Size = New System.Drawing.Size(69, 21)
        Me.FlpManufacturer.TabIndex = 4
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
        Me.QbxPerson.DebugOnTextChanged = False
        Me.QbxPerson.DisplayFieldAlias = "Nome"
        Me.QbxPerson.DisplayFieldName = "name"
        Me.QbxPerson.DisplayMainFieldName = "id"
        Me.QbxPerson.DisplayTableAlias = Nothing
        Me.QbxPerson.DisplayTableName = "person"
        Me.QbxPerson.Distinct = False
        Me.QbxPerson.DropDownAutoStretchRight = False
        Me.QbxPerson.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxPerson.IfNull = Nothing
        Me.QbxPerson.Location = New System.Drawing.Point(115, 33)
        Me.QbxPerson.MainReturnFieldName = "id"
        Me.QbxPerson.MainTableAlias = Nothing
        Me.QbxPerson.MainTableName = "person"
        Me.QbxPerson.Name = "QbxPerson"
        Me.QbxPerson.Prefix = Nothing
        Me.QbxPerson.ShowStartOnFreeze = True
        Me.QbxPerson.Size = New System.Drawing.Size(329, 23)
        Me.QbxPerson.Suffix = Nothing
        Me.QbxPerson.TabIndex = 3
        '
        'TabPrivilege
        '
        Me.TabPrivilege.Controls.Add(Me.FlpPrivilege)
        Me.TabPrivilege.Controls.Add(Me.TlpFilter)
        Me.TabPrivilege.Location = New System.Drawing.Point(4, 26)
        Me.TabPrivilege.Name = "TabPrivilege"
        Me.TabPrivilege.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPrivilege.Size = New System.Drawing.Size(451, 67)
        Me.TabPrivilege.TabIndex = 8
        Me.TabPrivilege.Text = "Permissões"
        Me.TabPrivilege.UseVisualStyleBackColor = True
        '
        'FlpPrivilege
        '
        Me.FlpPrivilege.AutoScroll = True
        Me.FlpPrivilege.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlpPrivilege.Location = New System.Drawing.Point(3, 38)
        Me.FlpPrivilege.Name = "FlpPrivilege"
        Me.FlpPrivilege.Size = New System.Drawing.Size(445, 26)
        Me.FlpPrivilege.TabIndex = 0
        '
        'TlpFilter
        '
        Me.TlpFilter.ColumnCount = 1
        Me.TlpFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TlpFilter.Controls.Add(Me.PnFilter, 0, 0)
        Me.TlpFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.TlpFilter.Location = New System.Drawing.Point(3, 3)
        Me.TlpFilter.Name = "TlpFilter"
        Me.TlpFilter.RowCount = 1
        Me.TlpFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TlpFilter.Size = New System.Drawing.Size(445, 35)
        Me.TlpFilter.TabIndex = 1
        '
        'PnFilter
        '
        Me.PnFilter.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnFilter.Controls.Add(Me.LblFilter)
        Me.PnFilter.Controls.Add(Me.TxtFilterPrivileges)
        Me.PnFilter.Location = New System.Drawing.Point(69, 3)
        Me.PnFilter.Name = "PnFilter"
        Me.PnFilter.Size = New System.Drawing.Size(306, 29)
        Me.PnFilter.TabIndex = 0
        '
        'LblFilter
        '
        Me.LblFilter.AutoSize = True
        Me.LblFilter.Location = New System.Drawing.Point(3, 6)
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(42, 17)
        Me.LblFilter.TabIndex = 1
        Me.LblFilter.Text = "Filtrar"
        '
        'TxtFilterPrivileges
        '
        Me.TxtFilterPrivileges.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TxtFilterPrivileges.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterPrivileges.Location = New System.Drawing.Point(51, 3)
        Me.TxtFilterPrivileges.Name = "TxtFilterPrivileges"
        Me.TxtFilterPrivileges.Size = New System.Drawing.Size(252, 23)
        Me.TxtFilterPrivileges.TabIndex = 0
        '
        'TabEmail
        '
        Me.TabEmail.Controls.Add(Me.DgvEmail)
        Me.TabEmail.Controls.Add(Me.TsEmail)
        Me.TabEmail.Location = New System.Drawing.Point(4, 22)
        Me.TabEmail.Name = "TabEmail"
        Me.TabEmail.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEmail.Size = New System.Drawing.Size(451, 71)
        Me.TabEmail.TabIndex = 11
        Me.TabEmail.Text = "E-Mails"
        Me.TabEmail.UseVisualStyleBackColor = True
        '
        'DgvEmail
        '
        Me.DgvEmail.AllowUserToAddRows = False
        Me.DgvEmail.AllowUserToDeleteRows = False
        Me.DgvEmail.AllowUserToOrderColumns = True
        Me.DgvEmail.AllowUserToResizeRows = False
        Me.DgvEmail.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvEmail.Location = New System.Drawing.Point(3, 28)
        Me.DgvEmail.MultiSelect = False
        Me.DgvEmail.Name = "DgvEmail"
        Me.DgvEmail.ReadOnly = True
        Me.DgvEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvEmail.RowHeadersVisible = False
        Me.DgvEmail.RowTemplate.Height = 26
        Me.DgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEmail.Size = New System.Drawing.Size(445, 40)
        Me.DgvEmail.TabIndex = 3
        '
        'TsEmail
        '
        Me.TsEmail.BackColor = System.Drawing.Color.Transparent
        Me.TsEmail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsEmail.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsEmail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeEmail, Me.BtnEditEmail, Me.BtnDeleteEmail, Me.TxtFilterEmail})
        Me.TsEmail.Location = New System.Drawing.Point(3, 3)
        Me.TsEmail.Name = "TsEmail"
        Me.TsEmail.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsEmail.Size = New System.Drawing.Size(445, 25)
        Me.TsEmail.TabIndex = 2
        Me.TsEmail.Text = "ToolStrip2"
        '
        'BtnIncludeEmail
        '
        Me.BtnIncludeEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeEmail.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeEmail.Name = "BtnIncludeEmail"
        Me.BtnIncludeEmail.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeEmail.Text = "Incluir E-mail"
        '
        'BtnEditEmail
        '
        Me.BtnEditEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditEmail.Enabled = False
        Me.BtnEditEmail.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditEmail.Name = "BtnEditEmail"
        Me.BtnEditEmail.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditEmail.Text = "Editar E-Mail"
        Me.BtnEditEmail.ToolTipText = "Editar E-Mail"
        '
        'BtnDeleteEmail
        '
        Me.BtnDeleteEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteEmail.Enabled = False
        Me.BtnDeleteEmail.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteEmail.Name = "BtnDeleteEmail"
        Me.BtnDeleteEmail.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteEmail.Text = "Excluir E-Mail"
        '
        'TxtFilterEmail
        '
        Me.TxtFilterEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterEmail.Name = "TxtFilterEmail"
        Me.TxtFilterEmail.Size = New System.Drawing.Size(200, 25)
        '
        'TabNote
        '
        Me.TabNote.Controls.Add(Me.TxtNote)
        Me.TabNote.Location = New System.Drawing.Point(4, 22)
        Me.TabNote.Name = "TabNote"
        Me.TabNote.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNote.Size = New System.Drawing.Size(451, 71)
        Me.TabNote.TabIndex = 10
        Me.TabNote.Text = "Observação"
        Me.TabNote.UseVisualStyleBackColor = True
        '
        'TxtNote
        '
        Me.TxtNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtNote.Location = New System.Drawing.Point(3, 3)
        Me.TxtNote.MaxLength = 1000000
        Me.TxtNote.Name = "TxtNote"
        Me.TxtNote.Size = New System.Drawing.Size(445, 65)
        Me.TxtNote.TabIndex = 1
        Me.TxtNote.Text = ""
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'DgvEmailLayout
        '
        Me.DgvEmailLayout.DataGridView = Me.DgvEmail
        Me.DgvEmailLayout.Routine = Manager.Routine.UserEmail
        '
        'FrmUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(459, 191)
        Me.Controls.Add(Me.TcUser)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUser"
        Me.ShowIcon = False
        Me.Text = " Usuário"
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnButtons.ResumeLayout(False)
        Me.TcUser.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.FlpManufacturer.ResumeLayout(False)
        Me.TabPrivilege.ResumeLayout(False)
        Me.TlpFilter.ResumeLayout(False)
        Me.PnFilter.ResumeLayout(False)
        Me.PnFilter.PerformLayout()
        Me.TabEmail.ResumeLayout(False)
        Me.TabEmail.PerformLayout()
        CType(Me.DgvEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsEmail.ResumeLayout(False)
        Me.TsEmail.PerformLayout()
        Me.TabNote.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BtnStatusValue As ToolStripButton
    Friend WithEvents TsNavigation As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents BtnRequestPassword As ToolStripButton
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents LblPerson As Label
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents LblUsername As Label
    Friend WithEvents TcUser As TabControl
    Friend WithEvents TabPrivilege As TabPage
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TabNote As TabPage
    Friend WithEvents TxtNote As RichTextBox
    Friend WithEvents BtnImportPrivilege As ToolStripButton
    Friend WithEvents FlpManufacturer As FlowLayoutPanel
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents QbxPerson As ControlLibrary.QueriedBox
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents TabEmail As TabPage
    Friend WithEvents DgvEmail As DataGridView
    Friend WithEvents TsEmail As ToolStrip
    Friend WithEvents BtnIncludeEmail As ToolStripButton
    Friend WithEvents BtnEditEmail As ToolStripButton
    Friend WithEvents BtnDeleteEmail As ToolStripButton
    Friend WithEvents TxtFilterEmail As ToolStripTextBox
    Friend WithEvents DgvEmailLayout As DataGridViewLayout
    Friend WithEvents FlpPrivilege As FlowLayoutPanel
    Friend WithEvents TlpFilter As TableLayoutPanel
    Friend WithEvents PnFilter As Panel
    Friend WithEvents LblFilter As Label
    Friend WithEvents TxtFilterPrivileges As TextBox
End Class
