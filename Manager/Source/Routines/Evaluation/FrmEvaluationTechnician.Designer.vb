<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvaluationTechnician
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
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim OtherField1 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim OtherField2 As ControlLibrary.QueriedBox.OtherField = New ControlLibrary.QueriedBox.OtherField()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
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
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.FlpTechnician = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilterTechnician = New ControlLibrary.NoFocusCueButton()
        Me.BtnViewTechnician = New ControlLibrary.NoFocusCueButton()
        Me.BtnNewTechnician = New ControlLibrary.NoFocusCueButton()
        Me.QbxTechnician = New ControlLibrary.QueriedBox()
        Me.LblTechnician = New System.Windows.Forms.Label()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsData.SuspendLayout()
        Me.FlpTechnician.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 107)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(384, 44)
        Me.Panel1.TabIndex = 9
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(277, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(178, 7)
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
        Me.TsNavigation.Size = New System.Drawing.Size(384, 25)
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
        Me.BtnInclude.Text = "Incluir Peça"
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
        Me.BtnDelete.Text = "Excluir Peça"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Peça"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Peça Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Peça"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Peça"
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
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
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
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(384, 25)
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
        'FlpTechnician
        '
        Me.FlpTechnician.Controls.Add(Me.BtnFilterTechnician)
        Me.FlpTechnician.Controls.Add(Me.BtnViewTechnician)
        Me.FlpTechnician.Controls.Add(Me.BtnNewTechnician)
        Me.FlpTechnician.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpTechnician.Location = New System.Drawing.Point(303, 47)
        Me.FlpTechnician.Name = "FlpTechnician"
        Me.FlpTechnician.Size = New System.Drawing.Size(69, 21)
        Me.FlpTechnician.TabIndex = 15
        '
        'BtnFilterTechnician
        '
        Me.BtnFilterTechnician.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilterTechnician.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilterTechnician.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilterTechnician.FlatAppearance.BorderSize = 0
        Me.BtnFilterTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilterTechnician.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilterTechnician.Name = "BtnFilterTechnician"
        Me.BtnFilterTechnician.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilterTechnician.TabIndex = 2
        Me.BtnFilterTechnician.TabStop = False
        Me.BtnFilterTechnician.TooltipText = ""
        Me.BtnFilterTechnician.UseVisualStyleBackColor = False
        Me.BtnFilterTechnician.Visible = False
        '
        'BtnViewTechnician
        '
        Me.BtnViewTechnician.BackColor = System.Drawing.Color.Transparent
        Me.BtnViewTechnician.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnViewTechnician.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnViewTechnician.FlatAppearance.BorderSize = 0
        Me.BtnViewTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewTechnician.Location = New System.Drawing.Point(26, 3)
        Me.BtnViewTechnician.Name = "BtnViewTechnician"
        Me.BtnViewTechnician.Size = New System.Drawing.Size(17, 17)
        Me.BtnViewTechnician.TabIndex = 1
        Me.BtnViewTechnician.TabStop = False
        Me.BtnViewTechnician.TooltipText = ""
        Me.BtnViewTechnician.UseVisualStyleBackColor = False
        Me.BtnViewTechnician.Visible = False
        '
        'BtnNewTechnician
        '
        Me.BtnNewTechnician.BackColor = System.Drawing.Color.Transparent
        Me.BtnNewTechnician.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNewTechnician.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNewTechnician.FlatAppearance.BorderSize = 0
        Me.BtnNewTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNewTechnician.Location = New System.Drawing.Point(3, 3)
        Me.BtnNewTechnician.Name = "BtnNewTechnician"
        Me.BtnNewTechnician.Size = New System.Drawing.Size(17, 17)
        Me.BtnNewTechnician.TabIndex = 0
        Me.BtnNewTechnician.TabStop = False
        Me.BtnNewTechnician.TooltipText = ""
        Me.BtnNewTechnician.UseVisualStyleBackColor = False
        Me.BtnNewTechnician.Visible = False
        '
        'QbxTechnician
        '
        Me.QbxTechnician.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxTechnician.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@statusid"
        Condition2.FieldName = "istechnician"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@istechnician"
        Me.QbxTechnician.Conditions.Add(Condition1)
        Me.QbxTechnician.Conditions.Add(Condition2)
        Me.QbxTechnician.DisplayFieldAlias = "Nome"
        Me.QbxTechnician.DisplayFieldName = "name"
        Me.QbxTechnician.DisplayMainFieldName = "id"
        Me.QbxTechnician.DisplayTableAlias = Nothing
        Me.QbxTechnician.DisplayTableName = "person"
        Me.QbxTechnician.Distinct = False
        Me.QbxTechnician.DropDownAutoStretchRight = False
        Me.QbxTechnician.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxTechnician.IfNull = Nothing
        Me.QbxTechnician.Location = New System.Drawing.Point(15, 68)
        Me.QbxTechnician.MainReturnFieldName = "id"
        Me.QbxTechnician.MainTableAlias = Nothing
        Me.QbxTechnician.MainTableName = "person"
        Me.QbxTechnician.Name = "QbxTechnician"
        OtherField1.DisplayFieldAlias = "Nome Curto"
        OtherField1.DisplayFieldName = "shortname"
        OtherField1.DisplayMainFieldName = "id"
        OtherField1.DisplayTableAlias = Nothing
        OtherField1.DisplayTableName = "person"
        OtherField1.Freeze = False
        OtherField1.IfNull = Nothing
        OtherField1.Prefix = Nothing
        OtherField1.Suffix = Nothing
        OtherField2.DisplayFieldAlias = "CPF/CNPJ"
        OtherField2.DisplayFieldName = "document"
        OtherField2.DisplayMainFieldName = "id"
        OtherField2.DisplayTableAlias = Nothing
        OtherField2.DisplayTableName = "person"
        OtherField2.Freeze = False
        OtherField2.IfNull = Nothing
        OtherField2.Prefix = Nothing
        OtherField2.Suffix = Nothing
        Me.QbxTechnician.OtherFields.Add(OtherField1)
        Me.QbxTechnician.OtherFields.Add(OtherField2)
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Parameter2.ParameterName = "@istechnician"
        Parameter2.ParameterValue = "1"
        Me.QbxTechnician.Parameters.Add(Parameter1)
        Me.QbxTechnician.Parameters.Add(Parameter2)
        Me.QbxTechnician.Prefix = Nothing
        Me.QbxTechnician.Size = New System.Drawing.Size(357, 23)
        Me.QbxTechnician.Suffix = Nothing
        Me.QbxTechnician.TabIndex = 14
        '
        'LblTechnician
        '
        Me.LblTechnician.AutoSize = True
        Me.LblTechnician.Location = New System.Drawing.Point(12, 50)
        Me.LblTechnician.Name = "LblTechnician"
        Me.LblTechnician.Size = New System.Drawing.Size(57, 17)
        Me.LblTechnician.TabIndex = 13
        Me.LblTechnician.Text = "Técnico"
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
        'FrmEvaluationTechnician
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(384, 151)
        Me.Controls.Add(Me.FlpTechnician)
        Me.Controls.Add(Me.QbxTechnician)
        Me.Controls.Add(Me.LblTechnician)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluationTechnician"
        Me.ShowIcon = False
        Me.Text = "Técnico"
        Me.Panel1.ResumeLayout(False)
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.FlpTechnician.ResumeLayout(False)
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
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents FlpTechnician As FlowLayoutPanel
    Friend WithEvents BtnFilterTechnician As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnViewTechnician As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnNewTechnician As ControlLibrary.NoFocusCueButton
    Friend WithEvents QbxTechnician As ControlLibrary.QueriedBox
    Friend WithEvents LblTechnician As Label
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
End Class
