<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCashFlow
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
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.PnAuthorized = New System.Windows.Forms.Panel()
        Me.DgvAuthorized = New System.Windows.Forms.DataGridView()
        Me.TsAuthorized = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeAuthorized = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditAuthorized = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteAuthorized = New System.Windows.Forms.ToolStripButton()
        Me.LblAuthorized = New System.Windows.Forms.Label()
        Me.DgvAuthorizedLayout = New Manager.DataGridViewLayout()
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnAuthorized.SuspendLayout()
        CType(Me.DgvAuthorized, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsAuthorized.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 287)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 44)
        Me.Panel1.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(254, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(153, 7)
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
        Me.TsTitle.Size = New System.Drawing.Size(358, 25)
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
        Me.TsNavigation.Size = New System.Drawing.Size(358, 25)
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
        Me.BtnInclude.Text = "Incluir Rota"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Rota"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Rota"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Rota Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Rota"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Rota"
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
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(15, 70)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtName.MaxLength = 100
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(329, 23)
        Me.TxtName.TabIndex = 3
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
        'PnAuthorized
        '
        Me.PnAuthorized.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnAuthorized.Controls.Add(Me.DgvAuthorized)
        Me.PnAuthorized.Controls.Add(Me.TsAuthorized)
        Me.PnAuthorized.Location = New System.Drawing.Point(15, 119)
        Me.PnAuthorized.Name = "PnAuthorized"
        Me.PnAuthorized.Size = New System.Drawing.Size(329, 159)
        Me.PnAuthorized.TabIndex = 15
        '
        'DgvAuthorized
        '
        Me.DgvAuthorized.AllowUserToAddRows = False
        Me.DgvAuthorized.AllowUserToDeleteRows = False
        Me.DgvAuthorized.AllowUserToOrderColumns = True
        Me.DgvAuthorized.AllowUserToResizeRows = False
        Me.DgvAuthorized.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvAuthorized.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvAuthorized.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAuthorized.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAuthorized.ColumnHeadersVisible = False
        Me.DgvAuthorized.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAuthorized.Location = New System.Drawing.Point(0, 25)
        Me.DgvAuthorized.MultiSelect = False
        Me.DgvAuthorized.Name = "DgvAuthorized"
        Me.DgvAuthorized.ReadOnly = True
        Me.DgvAuthorized.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvAuthorized.RowHeadersVisible = False
        Me.DgvAuthorized.RowTemplate.Height = 26
        Me.DgvAuthorized.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAuthorized.Size = New System.Drawing.Size(327, 132)
        Me.DgvAuthorized.TabIndex = 1
        '
        'TsAuthorized
        '
        Me.TsAuthorized.BackColor = System.Drawing.Color.White
        Me.TsAuthorized.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsAuthorized.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsAuthorized.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeAuthorized, Me.BtnEditAuthorized, Me.BtnDeleteAuthorized})
        Me.TsAuthorized.Location = New System.Drawing.Point(0, 0)
        Me.TsAuthorized.Name = "TsAuthorized"
        Me.TsAuthorized.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsAuthorized.Size = New System.Drawing.Size(327, 25)
        Me.TsAuthorized.TabIndex = 0
        Me.TsAuthorized.Text = "ToolStrip2"
        '
        'BtnIncludeAuthorized
        '
        Me.BtnIncludeAuthorized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeAuthorized.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeAuthorized.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeAuthorized.Name = "BtnIncludeAuthorized"
        Me.BtnIncludeAuthorized.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeAuthorized.Text = "Incluir Autorizado"
        Me.BtnIncludeAuthorized.ToolTipText = "Incluir Responsável"
        '
        'BtnEditAuthorized
        '
        Me.BtnEditAuthorized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditAuthorized.Enabled = False
        Me.BtnEditAuthorized.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditAuthorized.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditAuthorized.Name = "BtnEditAuthorized"
        Me.BtnEditAuthorized.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditAuthorized.Text = "Editar Autorizado"
        Me.BtnEditAuthorized.ToolTipText = "Editar Responsável"
        '
        'BtnDeleteAuthorized
        '
        Me.BtnDeleteAuthorized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteAuthorized.Enabled = False
        Me.BtnDeleteAuthorized.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteAuthorized.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteAuthorized.Name = "BtnDeleteAuthorized"
        Me.BtnDeleteAuthorized.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteAuthorized.Text = "Excluir Autorizado"
        Me.BtnDeleteAuthorized.ToolTipText = "Excluir Responsável"
        '
        'LblAuthorized
        '
        Me.LblAuthorized.AutoSize = True
        Me.LblAuthorized.Location = New System.Drawing.Point(12, 99)
        Me.LblAuthorized.Name = "LblAuthorized"
        Me.LblAuthorized.Size = New System.Drawing.Size(139, 17)
        Me.LblAuthorized.TabIndex = 14
        Me.LblAuthorized.Text = "Usuários Autorizados"
        '
        'DgvAuthorizedLayout
        '
        Me.DgvAuthorizedLayout.DataGridView = Me.DgvAuthorized
        Me.DgvAuthorizedLayout.Routine = Manager.Routine.CashFlowAuthorized
        '
        'FrmCashFlow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(358, 331)
        Me.Controls.Add(Me.PnAuthorized)
        Me.Controls.Add(Me.LblAuthorized)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCashFlow"
        Me.ShowIcon = False
        Me.Text = "Fluxo de Caixa"
        Me.Panel1.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnAuthorized.ResumeLayout(False)
        Me.PnAuthorized.PerformLayout()
        CType(Me.DgvAuthorized, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsAuthorized.ResumeLayout(False)
        Me.TsAuthorized.PerformLayout()
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
    Friend WithEvents PnAuthorized As Panel
    Friend WithEvents DgvAuthorized As DataGridView
    Friend WithEvents TsAuthorized As ToolStrip
    Friend WithEvents BtnIncludeAuthorized As ToolStripButton
    Friend WithEvents BtnEditAuthorized As ToolStripButton
    Friend WithEvents BtnDeleteAuthorized As ToolStripButton
    Friend WithEvents LblAuthorized As Label
    Friend WithEvents DgvAuthorizedLayout As DataGridViewLayout
End Class
