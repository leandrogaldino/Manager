<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductPicture
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCaption = New System.Windows.Forms.Label()
        Me.PbxPicture = New System.Windows.Forms.PictureBox()
        Me.LblPicture = New System.Windows.Forms.Label()
        Me.OfdPicture = New System.Windows.Forms.OpenFileDialog()
        Me.SfdPicture = New System.Windows.Forms.SaveFileDialog()
        Me.TxtCaption = New System.Windows.Forms.TextBox()
        Me.FlpGroup = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnSavePicture = New ControlLibrary.NoFocusCueButton()
        Me.BtnDeletePicture = New ControlLibrary.NoFocusCueButton()
        Me.BtnIncludePicture = New ControlLibrary.NoFocusCueButton()
        Me.TsMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsData.SuspendLayout()
        CType(Me.PbxPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlpGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(121, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(20, 7)
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
        Me.TsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnInclude, Me.BtnDelete, Me.BtnFirst, Me.BtnPrevious, Me.BtnNext, Me.BtnLast, Me.BtnLog})
        Me.TsMain.Location = New System.Drawing.Point(0, 0)
        Me.TsMain.Name = "TsMain"
        Me.TsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsMain.Size = New System.Drawing.Size(228, 25)
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
        Me.BtnInclude.Text = "Incluir Foto"
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
        Me.BtnDelete.Text = "Excluir Foto"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Foto"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Foto Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Foto"
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
        Me.BtnLast.Text = "Última Foto"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 340)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 44)
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
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(228, 25)
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
        'LblCaption
        '
        Me.LblCaption.AutoSize = True
        Me.LblCaption.Location = New System.Drawing.Point(12, 283)
        Me.LblCaption.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblCaption.Name = "LblCaption"
        Me.LblCaption.Size = New System.Drawing.Size(65, 17)
        Me.LblCaption.TabIndex = 5
        Me.LblCaption.Text = "Legenda"
        '
        'PbxPicture
        '
        Me.PbxPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PbxPicture.Location = New System.Drawing.Point(15, 75)
        Me.PbxPicture.Name = "PbxPicture"
        Me.PbxPicture.Size = New System.Drawing.Size(200, 200)
        Me.PbxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxPicture.TabIndex = 7
        Me.PbxPicture.TabStop = False
        '
        'LblPicture
        '
        Me.LblPicture.AutoSize = True
        Me.LblPicture.Location = New System.Drawing.Point(12, 55)
        Me.LblPicture.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.LblPicture.Name = "LblPicture"
        Me.LblPicture.Size = New System.Drawing.Size(37, 17)
        Me.LblPicture.TabIndex = 2
        Me.LblPicture.Text = "Foto"
        '
        'OfdPicture
        '
        Me.OfdPicture.Title = "Escolha uma imagem"
        '
        'SfdPicture
        '
        Me.SfdPicture.Title = "Salvar Imagem"
        '
        'TxtCaption
        '
        Me.TxtCaption.AutoCompleteCustomSource.AddRange(New String() {"ANP", "EAN", "NCM"})
        Me.TxtCaption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TxtCaption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TxtCaption.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCaption.Location = New System.Drawing.Point(12, 303)
        Me.TxtCaption.MaxLength = 50
        Me.TxtCaption.Name = "TxtCaption"
        Me.TxtCaption.Size = New System.Drawing.Size(203, 23)
        Me.TxtCaption.TabIndex = 6
        '
        'FlpGroup
        '
        Me.FlpGroup.Controls.Add(Me.BtnSavePicture)
        Me.FlpGroup.Controls.Add(Me.BtnDeletePicture)
        Me.FlpGroup.Controls.Add(Me.BtnIncludePicture)
        Me.FlpGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpGroup.Location = New System.Drawing.Point(142, 54)
        Me.FlpGroup.Name = "FlpGroup"
        Me.FlpGroup.Size = New System.Drawing.Size(73, 21)
        Me.FlpGroup.TabIndex = 10
        '
        'BtnSavePicture
        '
        Me.BtnSavePicture.BackColor = System.Drawing.Color.Transparent
        Me.BtnSavePicture.BackgroundImage = Global.Manager.My.Resources.Resources.ImageSave
        Me.BtnSavePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSavePicture.FlatAppearance.BorderSize = 0
        Me.BtnSavePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSavePicture.Location = New System.Drawing.Point(53, 3)
        Me.BtnSavePicture.Name = "BtnSavePicture"
        Me.BtnSavePicture.Size = New System.Drawing.Size(17, 17)
        Me.BtnSavePicture.TabIndex = 2
        Me.BtnSavePicture.TooltipText = "Salvar Imagem"
        Me.BtnSavePicture.UseVisualStyleBackColor = False
        '
        'BtnDeletePicture
        '
        Me.BtnDeletePicture.BackColor = System.Drawing.Color.Transparent
        Me.BtnDeletePicture.BackgroundImage = Global.Manager.My.Resources.Resources.ImageDelete
        Me.BtnDeletePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDeletePicture.FlatAppearance.BorderSize = 0
        Me.BtnDeletePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDeletePicture.Location = New System.Drawing.Point(30, 3)
        Me.BtnDeletePicture.Name = "BtnDeletePicture"
        Me.BtnDeletePicture.Size = New System.Drawing.Size(17, 17)
        Me.BtnDeletePicture.TabIndex = 1
        Me.BtnDeletePicture.TooltipText = "Excluir Imagem"
        Me.BtnDeletePicture.UseVisualStyleBackColor = False
        '
        'BtnIncludePicture
        '
        Me.BtnIncludePicture.BackColor = System.Drawing.Color.Transparent
        Me.BtnIncludePicture.BackgroundImage = Global.Manager.My.Resources.Resources.ImageInclude
        Me.BtnIncludePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnIncludePicture.FlatAppearance.BorderSize = 0
        Me.BtnIncludePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnIncludePicture.Location = New System.Drawing.Point(7, 3)
        Me.BtnIncludePicture.Name = "BtnIncludePicture"
        Me.BtnIncludePicture.Size = New System.Drawing.Size(17, 17)
        Me.BtnIncludePicture.TabIndex = 0
        Me.BtnIncludePicture.TooltipText = "Incluir Imagem"
        Me.BtnIncludePicture.UseVisualStyleBackColor = False
        '
        'FrmProductPicture
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(228, 384)
        Me.Controls.Add(Me.FlpGroup)
        Me.Controls.Add(Me.PbxPicture)
        Me.Controls.Add(Me.LblPicture)
        Me.Controls.Add(Me.LblCaption)
        Me.Controls.Add(Me.TxtCaption)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.TsMain)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductPicture"
        Me.ShowIcon = False
        Me.Text = "Imagem de Produto"
        Me.TsMain.ResumeLayout(False)
        Me.TsMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        CType(Me.PbxPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlpGroup.ResumeLayout(False)
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
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents LblCaption As Label
    Friend WithEvents TxtCaption As TextBox
    Friend WithEvents PbxPicture As PictureBox
    Friend WithEvents LblPicture As Label
    Friend WithEvents OfdPicture As OpenFileDialog
    Friend WithEvents SfdPicture As SaveFileDialog
    Friend WithEvents FlpGroup As FlowLayoutPanel
    Friend WithEvents BtnSavePicture As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnDeletePicture As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnIncludePicture As ControlLibrary.NoFocusCueButton
End Class
