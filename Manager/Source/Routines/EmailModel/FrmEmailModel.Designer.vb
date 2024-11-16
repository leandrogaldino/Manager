<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmailModel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmailModel))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnView = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.TsTitle = New System.Windows.Forms.ToolStrip()
        Me.LblID = New System.Windows.Forms.ToolStripLabel()
        Me.LblIDValue = New System.Windows.Forms.ToolStripLabel()
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
        Me.LblBody = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblSubject = New System.Windows.Forms.Label()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.PnBody = New System.Windows.Forms.Panel()
        Me.TsBody = New System.Windows.Forms.ToolStrip()
        Me.TxtFont = New System.Windows.Forms.ToolStripLabel()
        Me.BtnColor = New System.Windows.Forms.ToolStripButton()
        Me.BtnLeft = New System.Windows.Forms.ToolStripButton()
        Me.BtnCenter = New System.Windows.Forms.ToolStripButton()
        Me.BtnRight = New System.Windows.Forms.ToolStripButton()
        Me.FdFont = New System.Windows.Forms.FontDialog()
        Me.CdColor = New System.Windows.Forms.ColorDialog()
        Me.LblSignature = New System.Windows.Forms.Label()
        Me.CbxSignature = New System.Windows.Forms.ComboBox()
        Me.TxtBody = New Manager.RichTextBoxSingleSelection()
        Me.DgvItemLayout = New Manager.DataGridViewLayout()
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnBody.SuspendLayout()
        Me.TsBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnView)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 464)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(757, 44)
        Me.Panel1.TabIndex = 10
        '
        'BtnView
        '
        Me.BtnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnView.Location = New System.Drawing.Point(451, 7)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(95, 30)
        Me.BtnView.TabIndex = 0
        Me.BtnView.Text = "Visualizar"
        Me.BtnView.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(653, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(552, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TsTitle
        '
        Me.TsTitle.AutoSize = False
        Me.TsTitle.BackColor = System.Drawing.Color.White
        Me.TsTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblID, Me.LblIDValue, Me.LblCreationDate, Me.LblCreationValue})
        Me.TsTitle.Location = New System.Drawing.Point(0, 25)
        Me.TsTitle.Name = "TsTitle"
        Me.TsTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsTitle.Size = New System.Drawing.Size(757, 25)
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
        Me.TsNavigation.Size = New System.Drawing.Size(757, 25)
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
        Me.BtnInclude.Text = "Incluir Modelo de E-Mail"
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
        Me.BtnDelete.Text = "Excluir Modelo de E-Mail"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Modelo de E-Mail"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Modelo de E-Mail Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Modelo de E-Mail"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Modelo de E-Mail"
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
        'LblBody
        '
        Me.LblBody.AutoSize = True
        Me.LblBody.Location = New System.Drawing.Point(9, 96)
        Me.LblBody.Name = "LblBody"
        Me.LblBody.Size = New System.Drawing.Size(113, 17)
        Me.LblBody.TabIndex = 8
        Me.LblBody.Text = "Corpo do E-Mail"
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(12, 70)
        Me.TxtName.MaxLength = 50
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(188, 23)
        Me.TxtName.TabIndex = 3
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(12, 50)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(123, 17)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "Nome do Modelo"
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Location = New System.Drawing.Point(386, 50)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(120, 17)
        Me.LblSubject.TabIndex = 6
        Me.LblSubject.Text = "Assunto do E-Mail"
        '
        'TxtSubject
        '
        Me.TxtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubject.Location = New System.Drawing.Point(389, 70)
        Me.TxtSubject.MaxLength = 255
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(357, 23)
        Me.TxtSubject.TabIndex = 7
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'PnBody
        '
        Me.PnBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnBody.Controls.Add(Me.TxtBody)
        Me.PnBody.Controls.Add(Me.TsBody)
        Me.PnBody.Location = New System.Drawing.Point(12, 116)
        Me.PnBody.Name = "PnBody"
        Me.PnBody.Size = New System.Drawing.Size(733, 342)
        Me.PnBody.TabIndex = 9
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
        Me.TsBody.Size = New System.Drawing.Size(731, 29)
        Me.TsBody.TabIndex = 0
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
        'LblSignature
        '
        Me.LblSignature.AutoSize = True
        Me.LblSignature.Location = New System.Drawing.Point(203, 50)
        Me.LblSignature.Name = "LblSignature"
        Me.LblSignature.Size = New System.Drawing.Size(73, 17)
        Me.LblSignature.TabIndex = 4
        Me.LblSignature.Text = "Assinatura"
        '
        'CbxSignature
        '
        Me.CbxSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxSignature.FormattingEnabled = True
        Me.CbxSignature.Location = New System.Drawing.Point(206, 70)
        Me.CbxSignature.Name = "CbxSignature"
        Me.CbxSignature.Size = New System.Drawing.Size(177, 25)
        Me.CbxSignature.TabIndex = 5
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
        Me.TxtBody.Size = New System.Drawing.Size(721, 301)
        Me.TxtBody.TabIndex = 1
        Me.TxtBody.Text = ""
        Me.TxtBody.WordWrap = False
        '
        'DgvItemLayout
        '
        Me.DgvItemLayout.Routine = Routine.RequestItem
        '
        'FrmEmailModel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(757, 508)
        Me.Controls.Add(Me.CbxSignature)
        Me.Controls.Add(Me.PnBody)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.LblSignature)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.LblBody)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(430, 380)
        Me.Name = "FrmEmailModel"
        Me.ShowIcon = False
        Me.Text = "Modelo de Email"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnBody.ResumeLayout(False)
        Me.PnBody.PerformLayout()
        Me.TsBody.ResumeLayout(False)
        Me.TsBody.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents TsTitle As ToolStrip
    Friend WithEvents LblID As ToolStripLabel
    Friend WithEvents LblIDValue As ToolStripLabel
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
    Friend WithEvents LblBody As Label
    Friend WithEvents TxtName As TextBox
    Friend WithEvents LblName As Label
    Friend WithEvents LblSubject As Label
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvItemLayout As DataGridViewLayout
    Friend WithEvents EprInformation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents BtnView As Button
    Friend WithEvents PnBody As Panel
    Friend WithEvents TxtBody As RichTextBoxSingleSelection
    Friend WithEvents TsBody As ToolStrip
    Friend WithEvents TxtFont As ToolStripLabel
    Friend WithEvents BtnColor As ToolStripButton
    Friend WithEvents BtnLeft As ToolStripButton
    Friend WithEvents BtnCenter As ToolStripButton
    Friend WithEvents BtnRight As ToolStripButton
    Friend WithEvents FdFont As FontDialog
    Friend WithEvents CdColor As ColorDialog
    Friend WithEvents LblSignature As Label
    Friend WithEvents CbxSignature As ComboBox
End Class
