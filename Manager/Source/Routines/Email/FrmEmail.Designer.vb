<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmail))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.BtnView = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtTo = New System.Windows.Forms.TextBox()
        Me.LblTo = New System.Windows.Forms.Label()
        Me.TxtCc = New System.Windows.Forms.TextBox()
        Me.LblCc = New System.Windows.Forms.Label()
        Me.TxtBcc = New System.Windows.Forms.TextBox()
        Me.LblBcc = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnImportBcc = New ControlLibrary.NoFocusCueButton()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnImportCc = New ControlLibrary.NoFocusCueButton()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnImportTo = New ControlLibrary.NoFocusCueButton()
        Me.TmrTo = New System.Windows.Forms.Timer(Me.components)
        Me.TmrCc = New System.Windows.Forms.Timer(Me.components)
        Me.TmrBcc = New System.Windows.Forms.Timer(Me.components)
        Me.LblFrom = New System.Windows.Forms.Label()
        Me.QbxFrom = New ControlLibrary.QueriedBox()
        Me.LblSubject = New System.Windows.Forms.Label()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.LblSignature = New System.Windows.Forms.Label()
        Me.LblBody = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtBody = New Manager.RichTextBoxSingleSelection()
        Me.TsBody = New System.Windows.Forms.ToolStrip()
        Me.TxtFont = New System.Windows.Forms.ToolStripLabel()
        Me.BtnColor = New System.Windows.Forms.ToolStripButton()
        Me.BtnLeft = New System.Windows.Forms.ToolStripButton()
        Me.BtnCenter = New System.Windows.Forms.ToolStripButton()
        Me.BtnRight = New System.Windows.Forms.ToolStripButton()
        Me.FdFont = New System.Windows.Forms.FontDialog()
        Me.CdColor = New System.Windows.Forms.ColorDialog()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.CbxSignature = New System.Windows.Forms.ComboBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TsBody.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Controls.Add(Me.BtnView)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSend)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 417)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 44)
        Me.Panel1.TabIndex = 4
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(74, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 5
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'BtnView
        '
        Me.BtnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnView.Location = New System.Drawing.Point(175, 7)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(95, 30)
        Me.BtnView.TabIndex = 6
        Me.BtnView.Text = "Visualizar"
        Me.BtnView.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Location = New System.Drawing.Point(377, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Location = New System.Drawing.Point(276, 7)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(95, 30)
        Me.BtnSend.TabIndex = 7
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TxtTo
        '
        Me.TxtTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtTo.Location = New System.Drawing.Point(6, 22)
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.Size = New System.Drawing.Size(221, 23)
        Me.TxtTo.TabIndex = 2
        '
        'LblTo
        '
        Me.LblTo.AutoSize = True
        Me.LblTo.Location = New System.Drawing.Point(3, 1)
        Me.LblTo.Name = "LblTo"
        Me.LblTo.Size = New System.Drawing.Size(38, 17)
        Me.LblTo.TabIndex = 0
        Me.LblTo.Text = "Para"
        '
        'TxtCc
        '
        Me.TxtCc.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCc.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtCc.Location = New System.Drawing.Point(3, 23)
        Me.TxtCc.Name = "TxtCc"
        Me.TxtCc.Size = New System.Drawing.Size(224, 23)
        Me.TxtCc.TabIndex = 2
        '
        'LblCc
        '
        Me.LblCc.AutoSize = True
        Me.LblCc.Location = New System.Drawing.Point(3, 1)
        Me.LblCc.Name = "LblCc"
        Me.LblCc.Size = New System.Drawing.Size(49, 17)
        Me.LblCc.TabIndex = 0
        Me.LblCc.Text = "Cópia"
        '
        'TxtBcc
        '
        Me.TxtBcc.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtBcc.Location = New System.Drawing.Point(6, 23)
        Me.TxtBcc.Name = "TxtBcc"
        Me.TxtBcc.Size = New System.Drawing.Size(221, 23)
        Me.TxtBcc.TabIndex = 2
        '
        'LblBcc
        '
        Me.LblBcc.AutoSize = True
        Me.LblBcc.Location = New System.Drawing.Point(3, 1)
        Me.LblBcc.Name = "LblBcc"
        Me.LblBcc.Size = New System.Drawing.Size(97, 17)
        Me.LblBcc.TabIndex = 0
        Me.LblBcc.Text = "Cópia Oculta"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel1.Controls.Add(Me.BtnImportBcc)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(199, 1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(27, 21)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'BtnImportBcc
        '
        Me.BtnImportBcc.BackColor = System.Drawing.Color.Transparent
        Me.BtnImportBcc.BackgroundImage = Global.Manager.My.Resources.Resources.ImportSmall
        Me.BtnImportBcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnImportBcc.FlatAppearance.BorderSize = 0
        Me.BtnImportBcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImportBcc.Location = New System.Drawing.Point(7, 3)
        Me.BtnImportBcc.Name = "BtnImportBcc"
        Me.BtnImportBcc.Size = New System.Drawing.Size(17, 17)
        Me.BtnImportBcc.TabIndex = 0
        Me.BtnImportBcc.TabStop = False
        Me.BtnImportBcc.TooltipText = ""
        Me.BtnImportBcc.UseVisualStyleBackColor = False
        Me.BtnImportBcc.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel2.Controls.Add(Me.BtnImportCc)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(199, 1)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(27, 21)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'BtnImportCc
        '
        Me.BtnImportCc.BackColor = System.Drawing.Color.Transparent
        Me.BtnImportCc.BackgroundImage = Global.Manager.My.Resources.Resources.ImportSmall
        Me.BtnImportCc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnImportCc.FlatAppearance.BorderSize = 0
        Me.BtnImportCc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImportCc.Location = New System.Drawing.Point(7, 3)
        Me.BtnImportCc.Name = "BtnImportCc"
        Me.BtnImportCc.Size = New System.Drawing.Size(17, 17)
        Me.BtnImportCc.TabIndex = 0
        Me.BtnImportCc.TabStop = False
        Me.BtnImportCc.TooltipText = ""
        Me.BtnImportCc.UseVisualStyleBackColor = False
        Me.BtnImportCc.Visible = False
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel3.Controls.Add(Me.BtnImportTo)
        Me.FlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(199, 1)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(27, 21)
        Me.FlowLayoutPanel3.TabIndex = 1
        '
        'BtnImportTo
        '
        Me.BtnImportTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportTo.BackColor = System.Drawing.Color.Transparent
        Me.BtnImportTo.BackgroundImage = Global.Manager.My.Resources.Resources.ImportSmall
        Me.BtnImportTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnImportTo.FlatAppearance.BorderSize = 0
        Me.BtnImportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImportTo.Location = New System.Drawing.Point(7, 3)
        Me.BtnImportTo.Name = "BtnImportTo"
        Me.BtnImportTo.Size = New System.Drawing.Size(17, 17)
        Me.BtnImportTo.TabIndex = 0
        Me.BtnImportTo.TabStop = False
        Me.BtnImportTo.TooltipText = ""
        Me.BtnImportTo.UseVisualStyleBackColor = False
        Me.BtnImportTo.Visible = False
        '
        'TmrTo
        '
        Me.TmrTo.Enabled = True
        Me.TmrTo.Interval = 300
        '
        'TmrCc
        '
        Me.TmrCc.Enabled = True
        Me.TmrCc.Interval = 300
        '
        'TmrBcc
        '
        Me.TmrBcc.Enabled = True
        Me.TmrBcc.Interval = 300
        '
        'LblFrom
        '
        Me.LblFrom.AutoSize = True
        Me.LblFrom.Location = New System.Drawing.Point(3, 1)
        Me.LblFrom.Name = "LblFrom"
        Me.LblFrom.Size = New System.Drawing.Size(26, 17)
        Me.LblFrom.TabIndex = 0
        Me.LblFrom.Text = "De"
        '
        'QbxFrom
        '
        Me.QbxFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QbxFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.QbxFrom.CharactersToQuery = 1
        Me.QbxFrom.DebugOnTextChanged = False
        Me.QbxFrom.DisplayFieldAlias = "E-MAIL"
        Me.QbxFrom.DisplayFieldName = "email"
        Me.QbxFrom.DisplayMainFieldName = "id"
        Me.QbxFrom.DisplayTableAlias = Nothing
        Me.QbxFrom.DisplayTableName = "useremail"
        Me.QbxFrom.Distinct = False
        Me.QbxFrom.DropDownAutoStretchRight = False
        Me.QbxFrom.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxFrom.IfNull = Nothing
        Me.QbxFrom.Location = New System.Drawing.Point(6, 22)
        Me.QbxFrom.MainReturnFieldName = "id"
        Me.QbxFrom.MainTableAlias = Nothing
        Me.QbxFrom.MainTableName = "useremail"
        Me.QbxFrom.Name = "QbxFrom"
        Me.QbxFrom.Prefix = Nothing
        Me.QbxFrom.ShowStartOnFreeze = True
        Me.QbxFrom.Size = New System.Drawing.Size(221, 23)
        Me.QbxFrom.Suffix = Nothing
        Me.QbxFrom.TabIndex = 1
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Location = New System.Drawing.Point(3, 1)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(57, 17)
        Me.LblSubject.TabIndex = 0
        Me.LblSubject.Text = "Assunto"
        '
        'TxtSubject
        '
        Me.TxtSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubject.Location = New System.Drawing.Point(3, 24)
        Me.TxtSubject.MaxLength = 255
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(224, 23)
        Me.TxtSubject.TabIndex = 1
        '
        'LblSignature
        '
        Me.LblSignature.AutoSize = True
        Me.LblSignature.Location = New System.Drawing.Point(3, 1)
        Me.LblSignature.Name = "LblSignature"
        Me.LblSignature.Size = New System.Drawing.Size(73, 17)
        Me.LblSignature.TabIndex = 0
        Me.LblSignature.Text = "Assinatura"
        '
        'LblBody
        '
        Me.LblBody.AutoSize = True
        Me.LblBody.Location = New System.Drawing.Point(12, 185)
        Me.LblBody.Name = "LblBody"
        Me.LblBody.Size = New System.Drawing.Size(113, 17)
        Me.LblBody.TabIndex = 1
        Me.LblBody.Text = "Corpo do E-Mail"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TxtBody)
        Me.Panel2.Controls.Add(Me.TsBody)
        Me.Panel2.Location = New System.Drawing.Point(13, 205)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(459, 206)
        Me.Panel2.TabIndex = 22
        '
        'TxtBody
        '
        Me.TxtBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBody.AutoWordSelection = True
        Me.TxtBody.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBody.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBody.Location = New System.Drawing.Point(5, 34)
        Me.TxtBody.Margin = New System.Windows.Forms.Padding(5)
        Me.TxtBody.Name = "TxtBody"
        Me.TxtBody.Size = New System.Drawing.Size(447, 165)
        Me.TxtBody.TabIndex = 3
        Me.TxtBody.Text = ""
        Me.TxtBody.WordWrap = False
        '
        'TsBody
        '
        Me.TsBody.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TsBody.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsBody.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsBody.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TxtFont, Me.BtnColor, Me.BtnLeft, Me.BtnCenter, Me.BtnRight})
        Me.TsBody.Location = New System.Drawing.Point(0, 0)
        Me.TsBody.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.TsBody.Name = "TsBody"
        Me.TsBody.Size = New System.Drawing.Size(457, 29)
        Me.TsBody.TabIndex = 1
        Me.TsBody.Text = "ToolStrip1"
        '
        'TxtFont
        '
        Me.TxtFont.Margin = New System.Windows.Forms.Padding(5, 0, 1, 0)
        Me.TxtFont.Name = "TxtFont"
        Me.TxtFont.Size = New System.Drawing.Size(34, 29)
        Me.TxtFont.Text = "Font"
        Me.TxtFont.ToolTipText = "Fonte"
        '
        'BtnColor
        '
        Me.BtnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnColor.Image = CType(resources.GetObject("BtnColor.Image"), System.Drawing.Image)
        Me.BtnColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnColor.Margin = New System.Windows.Forms.Padding(0, 1, 20, 2)
        Me.BtnColor.Name = "BtnColor"
        Me.BtnColor.Size = New System.Drawing.Size(23, 26)
        Me.BtnColor.Text = "ToolStripButton5"
        Me.BtnColor.ToolTipText = "Cor da fonte"
        '
        'BtnLeft
        '
        Me.BtnLeft.AutoSize = False
        Me.BtnLeft.CheckOnClick = True
        Me.BtnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLeft.Image = CType(resources.GetObject("BtnLeft.Image"), System.Drawing.Image)
        Me.BtnLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLeft.Name = "BtnLeft"
        Me.BtnLeft.Size = New System.Drawing.Size(26, 26)
        Me.BtnLeft.Text = "ToolStripButton6"
        Me.BtnLeft.ToolTipText = "Alinhar à esquerda"
        '
        'BtnCenter
        '
        Me.BtnCenter.CheckOnClick = True
        Me.BtnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCenter.Image = CType(resources.GetObject("BtnCenter.Image"), System.Drawing.Image)
        Me.BtnCenter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCenter.Name = "BtnCenter"
        Me.BtnCenter.Size = New System.Drawing.Size(23, 26)
        Me.BtnCenter.Text = "ToolStripButton7"
        Me.BtnCenter.ToolTipText = "Alinhar ao centro"
        '
        'BtnRight
        '
        Me.BtnRight.CheckOnClick = True
        Me.BtnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRight.Image = CType(resources.GetObject("BtnRight.Image"), System.Drawing.Image)
        Me.BtnRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRight.Name = "BtnRight"
        Me.BtnRight.Size = New System.Drawing.Size(23, 26)
        Me.BtnRight.Text = "Alinhar a direita"
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 12)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.4!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(472, 170)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.Controls.Add(Me.LblSignature)
        Me.Panel8.Controls.Add(Me.CbxSignature)
        Me.Panel8.Location = New System.Drawing.Point(239, 116)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(230, 50)
        Me.Panel8.TabIndex = 5
        '
        'CbxSignature
        '
        Me.CbxSignature.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxSignature.FormattingEnabled = True
        Me.CbxSignature.Location = New System.Drawing.Point(6, 22)
        Me.CbxSignature.Name = "CbxSignature"
        Me.CbxSignature.Size = New System.Drawing.Size(221, 25)
        Me.CbxSignature.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.Controls.Add(Me.LblSubject)
        Me.Panel7.Controls.Add(Me.TxtSubject)
        Me.Panel7.Location = New System.Drawing.Point(3, 116)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(230, 50)
        Me.Panel7.TabIndex = 4
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.TxtBcc)
        Me.Panel6.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel6.Controls.Add(Me.LblBcc)
        Me.Panel6.Location = New System.Drawing.Point(239, 59)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(230, 50)
        Me.Panel6.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.Controls.Add(Me.LblCc)
        Me.Panel5.Controls.Add(Me.TxtCc)
        Me.Panel5.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel5.Location = New System.Drawing.Point(3, 59)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(230, 50)
        Me.Panel5.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.LblTo)
        Me.Panel4.Controls.Add(Me.TxtTo)
        Me.Panel4.Controls.Add(Me.FlowLayoutPanel3)
        Me.Panel4.Location = New System.Drawing.Point(239, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(230, 50)
        Me.Panel4.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.LblFrom)
        Me.Panel3.Controls.Add(Me.QbxFrom)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(230, 50)
        Me.Panel3.TabIndex = 0
        '
        'FrmEmail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(484, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LblBody)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(500, 500)
        Me.Name = "FrmEmail"
        Me.ShowIcon = False
        Me.Text = "E-mail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TsBody.ResumeLayout(False)
        Me.TsBody.PerformLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSend As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TxtTo As TextBox
    Friend WithEvents LblBcc As Label
    Friend WithEvents LblCc As Label
    Friend WithEvents TxtBcc As TextBox
    Friend WithEvents LblTo As Label
    Friend WithEvents TxtCc As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents BtnImportTo As ControlLibrary.NoFocusCueButton
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents BtnImportCc As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnImportBcc As ControlLibrary.NoFocusCueButton
    Friend WithEvents TmrTo As Timer
    Friend WithEvents TmrCc As Timer
    Friend WithEvents TmrBcc As Timer
    Friend WithEvents QbxFrom As ControlLibrary.QueriedBox
    Friend WithEvents LblFrom As Label
    Friend WithEvents LblSubject As Label
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents LblSignature As Label
    Friend WithEvents LblBody As Label
    Friend WithEvents BtnView As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtBody As RichTextBoxSingleSelection
    Friend WithEvents TsBody As ToolStrip
    Friend WithEvents BtnColor As ToolStripButton
    Friend WithEvents BtnLeft As ToolStripButton
    Friend WithEvents BtnCenter As ToolStripButton
    Friend WithEvents BtnRight As ToolStripButton
    Friend WithEvents FdFont As FontDialog
    Friend WithEvents CdColor As ColorDialog
    Friend WithEvents TxtFont As ToolStripLabel
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents BtnImport As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CbxSignature As ComboBox
End Class
