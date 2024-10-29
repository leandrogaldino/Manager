<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcEvaluationPhotos
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PnContainer = New System.Windows.Forms.Panel()
        Me.PbxPhoto = New System.Windows.Forms.PictureBox()
        Me.TlpControls = New System.Windows.Forms.TableLayoutPanel()
        Me.BtnLast = New ControlLibrary.NoFocusCueButton()
        Me.BtnNext = New ControlLibrary.NoFocusCueButton()
        Me.BtnSave = New ControlLibrary.NoFocusCueButton()
        Me.BtnDelete = New ControlLibrary.NoFocusCueButton()
        Me.BtnInclude = New ControlLibrary.NoFocusCueButton()
        Me.BtnPrevious = New ControlLibrary.NoFocusCueButton()
        Me.BtnFirst = New ControlLibrary.NoFocusCueButton()
        Me.LblPhotoCount = New System.Windows.Forms.Label()
        Me.PnContainer.SuspendLayout()
        CType(Me.PbxPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TlpControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnContainer
        '
        Me.PnContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnContainer.Controls.Add(Me.PbxPhoto)
        Me.PnContainer.Controls.Add(Me.TlpControls)
        Me.PnContainer.Controls.Add(Me.LblPhotoCount)
        Me.PnContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnContainer.Location = New System.Drawing.Point(0, 0)
        Me.PnContainer.Name = "PnContainer"
        Me.PnContainer.Size = New System.Drawing.Size(250, 250)
        Me.PnContainer.TabIndex = 15
        '
        'PbxPhoto
        '
        Me.PbxPhoto.BackColor = System.Drawing.Color.White
        Me.PbxPhoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PbxPhoto.Location = New System.Drawing.Point(0, 28)
        Me.PbxPhoto.Name = "PbxPhoto"
        Me.PbxPhoto.Size = New System.Drawing.Size(248, 197)
        Me.PbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxPhoto.TabIndex = 11
        Me.PbxPhoto.TabStop = False
        '
        'TlpControls
        '
        Me.TlpControls.BackColor = System.Drawing.Color.White
        Me.TlpControls.ColumnCount = 9
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TlpControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TlpControls.Controls.Add(Me.BtnLast, 7, 0)
        Me.TlpControls.Controls.Add(Me.BtnNext, 6, 0)
        Me.TlpControls.Controls.Add(Me.BtnSave, 5, 0)
        Me.TlpControls.Controls.Add(Me.BtnDelete, 4, 0)
        Me.TlpControls.Controls.Add(Me.BtnInclude, 3, 0)
        Me.TlpControls.Controls.Add(Me.BtnPrevious, 2, 0)
        Me.TlpControls.Controls.Add(Me.BtnFirst, 1, 0)
        Me.TlpControls.Dock = System.Windows.Forms.DockStyle.Top
        Me.TlpControls.Location = New System.Drawing.Point(0, 0)
        Me.TlpControls.Name = "TlpControls"
        Me.TlpControls.RowCount = 1
        Me.TlpControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpControls.Size = New System.Drawing.Size(248, 28)
        Me.TlpControls.TabIndex = 13
        '
        'BtnLast
        '
        Me.BtnLast.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnLast.BackColor = System.Drawing.Color.Transparent
        Me.BtnLast.BackgroundImage = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnLast.FlatAppearance.BorderSize = 0
        Me.BtnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLast.Location = New System.Drawing.Point(205, 5)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(17, 17)
        Me.BtnLast.TabIndex = 14
        Me.BtnLast.TooltipText = "Última Imagem"
        Me.BtnLast.UseVisualStyleBackColor = False
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnNext.BackColor = System.Drawing.Color.Transparent
        Me.BtnNext.BackgroundImage = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNext.FlatAppearance.BorderSize = 0
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.Location = New System.Drawing.Point(175, 5)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(17, 17)
        Me.BtnNext.TabIndex = 14
        Me.BtnNext.TooltipText = "Próxima Imagem"
        Me.BtnNext.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = Global.Manager.My.Resources.Resources.ImageSave
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Location = New System.Drawing.Point(145, 5)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(17, 17)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.TooltipText = "Salvar Imagem"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnDelete.BackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.BackgroundImage = Global.Manager.My.Resources.Resources.ImageDelete
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Location = New System.Drawing.Point(115, 5)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(17, 17)
        Me.BtnDelete.TabIndex = 1
        Me.BtnDelete.TooltipText = "Excluir Imagem"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnInclude
        '
        Me.BtnInclude.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnInclude.BackColor = System.Drawing.Color.Transparent
        Me.BtnInclude.BackgroundImage = Global.Manager.My.Resources.Resources.ImageInclude
        Me.BtnInclude.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnInclude.FlatAppearance.BorderSize = 0
        Me.BtnInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnInclude.Location = New System.Drawing.Point(85, 5)
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(17, 17)
        Me.BtnInclude.TabIndex = 0
        Me.BtnInclude.TooltipText = "Incluir Imagem"
        Me.BtnInclude.UseVisualStyleBackColor = False
        '
        'BtnPrevious
        '
        Me.BtnPrevious.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnPrevious.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrevious.BackgroundImage = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnPrevious.FlatAppearance.BorderSize = 0
        Me.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrevious.Location = New System.Drawing.Point(55, 5)
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(17, 17)
        Me.BtnPrevious.TabIndex = 14
        Me.BtnPrevious.TooltipText = "Imagem Anterior"
        Me.BtnPrevious.UseVisualStyleBackColor = False
        '
        'BtnFirst
        '
        Me.BtnFirst.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnFirst.BackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.BackgroundImage = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFirst.FlatAppearance.BorderSize = 0
        Me.BtnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFirst.Location = New System.Drawing.Point(25, 5)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(17, 17)
        Me.BtnFirst.TabIndex = 14
        Me.BtnFirst.TooltipText = "Primeira Imagem"
        Me.BtnFirst.UseVisualStyleBackColor = False
        '
        'LblPhotoCount
        '
        Me.LblPhotoCount.BackColor = System.Drawing.Color.White
        Me.LblPhotoCount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblPhotoCount.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPhotoCount.Location = New System.Drawing.Point(0, 225)
        Me.LblPhotoCount.Name = "LblPhotoCount"
        Me.LblPhotoCount.Size = New System.Drawing.Size(248, 23)
        Me.LblPhotoCount.TabIndex = 14
        Me.LblPhotoCount.Text = "Foto 1 de 3"
        Me.LblPhotoCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcEvaluationPhotos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PnContainer)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(250, 250)
        Me.Name = "UcEvaluationPhotos"
        Me.Size = New System.Drawing.Size(250, 250)
        Me.PnContainer.ResumeLayout(False)
        CType(Me.PbxPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TlpControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents PnContainer As Panel
    Private WithEvents PbxPhoto As PictureBox
    Private WithEvents TlpControls As TableLayoutPanel
    Private WithEvents BtnLast As ControlLibrary.NoFocusCueButton
    Private WithEvents BtnNext As ControlLibrary.NoFocusCueButton
    Private WithEvents BtnSave As ControlLibrary.NoFocusCueButton
    Private WithEvents BtnDelete As ControlLibrary.NoFocusCueButton
    Private WithEvents BtnInclude As ControlLibrary.NoFocusCueButton
    Private WithEvents BtnPrevious As ControlLibrary.NoFocusCueButton
    Private WithEvents BtnFirst As ControlLibrary.NoFocusCueButton
    Private WithEvents LblPhotoCount As Label
End Class
