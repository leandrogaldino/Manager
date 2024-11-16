<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCashItemResponsible
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
        Dim Condition2 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Dim Parameter2 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Me.TsMain = New System.Windows.Forms.ToolStrip()
        Me.BtnInclude = New System.Windows.Forms.ToolStripButton()
        Me.BtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.BtnLog = New System.Windows.Forms.ToolStripButton()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.LblResponsible = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TsData = New System.Windows.Forms.ToolStrip()
        Me.LblOrder = New System.Windows.Forms.ToolStripLabel()
        Me.LblOrderValue = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreation = New System.Windows.Forms.ToolStripLabel()
        Me.LblCreationValue = New System.Windows.Forms.ToolStripLabel()
        Me.QbxResponsible = New ControlLibrary.QueriedBox()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.FlpResponsible = New System.Windows.Forms.FlowLayoutPanel()
        Me.TsMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsData.SuspendLayout()
        Me.FlpResponsible.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TsMain.Size = New System.Drawing.Size(434, 25)
        Me.TsMain.TabIndex = 0
        Me.TsMain.Text = "ToolStrip2"
        '
        'BtnInclude
        '
        Me.BtnInclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInclude.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnInclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInclude.Name = "BtnInclude"
        Me.BtnInclude.Size = New System.Drawing.Size(23, 22)
        Me.BtnInclude.Text = "Incluir Responsável"
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
        Me.BtnDelete.Text = "Excluir Responsável"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeiro Responsável"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Responsável Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próximo Responsável"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Último Responsável"
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
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'LblResponsible
        '
        Me.LblResponsible.AutoSize = True
        Me.LblResponsible.Location = New System.Drawing.Point(12, 50)
        Me.LblResponsible.Name = "LblResponsible"
        Me.LblResponsible.Size = New System.Drawing.Size(88, 17)
        Me.LblResponsible.TabIndex = 2
        Me.LblResponsible.Text = "Responsável"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 102)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(434, 44)
        Me.Panel1.TabIndex = 5
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(226, 7)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Incluir"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(327, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
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
        Me.TsData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblOrder, Me.LblOrderValue, Me.LblCreation, Me.LblCreationValue})
        Me.TsData.Location = New System.Drawing.Point(0, 25)
        Me.TsData.Name = "TsData"
        Me.TsData.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsData.Size = New System.Drawing.Size(434, 25)
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
        'QbxResponsible
        '
        Me.QbxResponsible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QbxResponsible.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "person"
        Condition1.Value = "@statusid"
        Condition2.FieldName = "isemployee"
        Condition2.Operator = "="
        Condition2.TableNameOrAlias = "person"
        Condition2.Value = "@isemployee"
        Me.QbxResponsible.Conditions.Add(Condition1)
        Me.QbxResponsible.Conditions.Add(Condition2)
        Me.QbxResponsible.DisplayFieldAlias = "Nome"
        Me.QbxResponsible.DisplayFieldName = "name"
        Me.QbxResponsible.DisplayMainFieldName = "id"
        Me.QbxResponsible.DisplayTableAlias = Nothing
        Me.QbxResponsible.DisplayTableName = "person"
        Me.QbxResponsible.Distinct = False
        Me.QbxResponsible.DropDownAutoStretchRight = False
        Me.QbxResponsible.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxResponsible.IfNull = Nothing
        Me.QbxResponsible.Location = New System.Drawing.Point(12, 70)
        Me.QbxResponsible.MainReturnFieldName = "id"
        Me.QbxResponsible.MainTableAlias = Nothing
        Me.QbxResponsible.MainTableName = "person"
        Me.QbxResponsible.Name = "QbxResponsible"
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Parameter2.ParameterName = "@isemployee"
        Parameter2.ParameterValue = "1"
        Me.QbxResponsible.Parameters.Add(Parameter1)
        Me.QbxResponsible.Parameters.Add(Parameter2)
        Me.QbxResponsible.Prefix = Nothing
        Me.QbxResponsible.Size = New System.Drawing.Size(410, 23)
        Me.QbxResponsible.Suffix = Nothing
        Me.QbxResponsible.TabIndex = 3
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
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
        'FlpResponsible
        '
        Me.FlpResponsible.Controls.Add(Me.BtnFilter)
        Me.FlpResponsible.Controls.Add(Me.BtnView)
        Me.FlpResponsible.Controls.Add(Me.BtnNew)
        Me.FlpResponsible.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpResponsible.Location = New System.Drawing.Point(353, 49)
        Me.FlpResponsible.Name = "FlpResponsible"
        Me.FlpResponsible.Size = New System.Drawing.Size(69, 21)
        Me.FlpResponsible.TabIndex = 4
        '
        'FrmCashItemResponsible
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(434, 146)
        Me.Controls.Add(Me.FlpResponsible)
        Me.Controls.Add(Me.QbxResponsible)
        Me.Controls.Add(Me.TsData)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblResponsible)
        Me.Controls.Add(Me.TsMain)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCashItemResponsible"
        Me.ShowIcon = False
        Me.Text = "Responsável"
        Me.TsMain.ResumeLayout(False)
        Me.TsMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsData.ResumeLayout(False)
        Me.TsData.PerformLayout()
        Me.FlpResponsible.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TsMain As ToolStrip
    Friend WithEvents BtnInclude As ToolStripButton
    Friend WithEvents BtnDelete As ToolStripButton
    Friend WithEvents BtnFirst As ToolStripButton
    Friend WithEvents BtnPrevious As ToolStripButton
    Friend WithEvents BtnNext As ToolStripButton
    Friend WithEvents BtnLast As ToolStripButton
    Friend WithEvents BtnLog As ToolStripButton
    Friend WithEvents DgvNavigator As ControlLibrary.DataGridViewNavigator
    Friend WithEvents LblResponsible As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents TsData As ToolStrip
    Friend WithEvents QbxResponsible As ControlLibrary.QueriedBox
    Friend WithEvents LblOrder As ToolStripLabel
    Friend WithEvents LblOrderValue As ToolStripLabel
    Friend WithEvents LblCreation As ToolStripLabel
    Friend WithEvents LblCreationValue As ToolStripLabel
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents FlpResponsible As FlowLayoutPanel
End Class
