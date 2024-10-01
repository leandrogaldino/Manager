<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmailImportEmailModel
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TmrModel = New System.Windows.Forms.Timer(Me.components)
        Me.FlpGroup = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterModel = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewModel = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewModel = New ControlLibrary.NoFocusCueButton()
        Me.LblEmailModel = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.WebMailPreview = New System.Windows.Forms.WebBrowser()
        Me.QbxEmailModel = New ControlLibrary.QueriedBox()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlpGroup.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 393)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 44)
        Me.Panel1.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(480, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Enabled = False
        Me.BtnImport.Location = New System.Drawing.Point(379, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Nothing
        Me.DgvNavigator.LastButton = Nothing
        Me.DgvNavigator.NextButton = Nothing
        Me.DgvNavigator.PreviousButton = Nothing
        '
        'TmrModel
        '
        Me.TmrModel.Enabled = True
        Me.TmrModel.Interval = 300
        '
        'FlpGroup
        '
        Me.FlpGroup.Controls.Add(Me.BtnFilterModel)
        Me.FlpGroup.Controls.Add(Me.BtnViewModel)
        Me.FlpGroup.Controls.Add(Me.BtnNewModel)
        Me.FlpGroup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpGroup.Location = New System.Drawing.Point(503, 8)
        Me.FlpGroup.Name = "FlpGroup"
        Me.FlpGroup.Size = New System.Drawing.Size(69, 21)
        Me.FlpGroup.TabIndex = 2
        '
        'BtnFilterModel
        '
        Me.BtnFilterModel.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterModel.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterModel.FlatAppearance.BorderSize = 0
        Me.BtnFilterModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterModel.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterModel.Name = "BtnFilterModel"
        Me.BtnFilterModel.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterModel.TabIndex = 2
        Me.BtnFilterModel.TabStop = False
        Me.BtnFilterModel.TooltipText = ""
        Me.BtnFilterModel.UseVisualStyleBackColor = False
        '
        'BtnViewModel
        '
        Me.BtnViewModel.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewModel.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewModel.FlatAppearance.BorderSize = 0
        Me.BtnViewModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewModel.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewModel.Name = "BtnViewModel"
        Me.BtnViewModel.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewModel.TabIndex = 1
        Me.BtnViewModel.TabStop = False
        Me.BtnViewModel.TooltipText = ""
        Me.BtnViewModel.UseVisualStyleBackColor = False
        Me.BtnViewModel.Visible = False
        '
        'BtnNewModel
        '
        Me.BtnNewModel.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewModel.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewModel.FlatAppearance.BorderSize = 0
        Me.BtnNewModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewModel.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewModel.Name = "BtnNewModel"
        Me.BtnNewModel.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewModel.TabIndex = 0
        Me.BtnNewModel.TabStop = False
        Me.BtnNewModel.TooltipText = ""
        Me.BtnNewModel.UseVisualStyleBackColor = False
        '
        'LblEmailModel
        '
        Me.LblEmailModel.AutoSize = True
        Me.LblEmailModel.Location = New System.Drawing.Point(12, 9)
        Me.LblEmailModel.Name = "LblEmailModel"
        Me.LblEmailModel.Size = New System.Drawing.Size(57, 17)
        Me.LblEmailModel.TabIndex = 0
        Me.LblEmailModel.Text = "Modelo"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.WebMailPreview)
        Me.Panel2.Location = New System.Drawing.Point(16, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel2.Size = New System.Drawing.Size(556, 329)
        Me.Panel2.TabIndex = 0
        '
        'WebMailPreview
        '
        Me.WebMailPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebMailPreview.Location = New System.Drawing.Point(1, 1)
        Me.WebMailPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebMailPreview.Name = "WebMailPreview"
        Me.WebMailPreview.Size = New System.Drawing.Size(554, 327)
        Me.WebMailPreview.TabIndex = 0
        Me.WebMailPreview.TabStop = False
        '
        'QbxEmailModel
        '
        Me.QbxEmailModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxEmailModel.CharactersToQuery = 1
        Me.QbxEmailModel.DisplayFieldAlias = "NOME"
        Me.QbxEmailModel.DisplayFieldName = "name"
        Me.QbxEmailModel.DisplayMainFieldName = "id"
        Me.QbxEmailModel.DisplayTableAlias = Nothing
        Me.QbxEmailModel.DisplayTableName = "emailmodel"
        Me.QbxEmailModel.Distinct = False
        Me.QbxEmailModel.DropDownAutoStretchRight = False
        Me.QbxEmailModel.DropDownStretchDown = 220
        Me.QbxEmailModel.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxEmailModel.IfNull = Nothing
        Me.QbxEmailModel.Location = New System.Drawing.Point(15, 29)
        Me.QbxEmailModel.MainReturnFieldName = "id"
        Me.QbxEmailModel.MainTableAlias = Nothing
        Me.QbxEmailModel.MainTableName = "emailmodel"
        Me.QbxEmailModel.Name = "QbxEmailModel"
        Me.QbxEmailModel.Prefix = Nothing
        Me.QbxEmailModel.ShowStartOnFreeze = True
        Me.QbxEmailModel.Size = New System.Drawing.Size(557, 23)
        Me.QbxEmailModel.Suffix = Nothing
        Me.QbxEmailModel.TabIndex = 1
        '
        'FrmEmailImportEmailModel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 437)
        Me.Controls.Add(Me.QbxEmailModel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.FlpGroup)
        Me.Controls.Add(Me.LblEmailModel)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmailImportEmailModel"
        Me.ShowIcon = False
        Me.Text = "Importar Modelo"
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlpGroup.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents TmrModel As Timer
    Friend WithEvents FlpGroup As FlowLayoutPanel
    Friend WithEvents BtnFilterModel As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNewModel As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewModel As ControlLibrary.NoFocusCueButton
    Friend WithEvents LblEmailModel As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents WebMailPreview As WebBrowser
    Friend WithEvents QbxEmailModel As ControlLibrary.QueriedBox
End Class
