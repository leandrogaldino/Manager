<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSellablePriceTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSellablePriceTable))
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
        Me.TcPriceTable = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.TabPartService = New System.Windows.Forms.TabPage()
        Me.DgvSellablePrice = New System.Windows.Forms.DataGridView()
        Me.TsSellablePrice = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeSellablePrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditSellablePrice = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeleteSellablePrice = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtFilterSellablePrice = New System.Windows.Forms.ToolStripTextBox()
        Me.DgvNavigator = New ControlLibrary.DataGridViewNavigator()
        Me.EprInformation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DgvSellablePriceLayout = New Manager.DataGridViewLayout()
        Me.Panel1.SuspendLayout()
        Me.TsTitle.SuspendLayout()
        Me.TsNavigation.SuspendLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TcPriceTable.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabPartService.SuspendLayout()
        CType(Me.DgvSellablePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TsSellablePrice.SuspendLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 132)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(349, 44)
        Me.Panel1.TabIndex = 4
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(242, 7)
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
        Me.BtnSave.Location = New System.Drawing.Point(141, 7)
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
        Me.TsTitle.Size = New System.Drawing.Size(349, 25)
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
        Me.TsNavigation.Size = New System.Drawing.Size(349, 25)
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
        Me.BtnInclude.Text = "Incluir Tabela de Preço"
        '
        'BtnDelete
        '
        Me.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelete.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.BtnDelete.Text = "Excluir Tabela de Preço"
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Enabled = False
        Me.BtnFirst.Image = Global.Manager.My.Resources.Resources.NavFirst
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.BtnFirst.Text = "Primeira Tabela de Preço"
        '
        'BtnPrevious
        '
        Me.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrevious.Enabled = False
        Me.BtnPrevious.Image = Global.Manager.My.Resources.Resources.NavPrevious
        Me.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrevious.Name = "BtnPrevious"
        Me.BtnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrevious.Text = "Tabela de Preço Anterior"
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Enabled = False
        Me.BtnNext.Image = Global.Manager.My.Resources.Resources.NavNext
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Próxima Tabela de Preço"
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Enabled = False
        Me.BtnLast.Image = Global.Manager.My.Resources.Resources.NavLast
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Última Tabela de Preço"
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
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(6, 24)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.TxtName.MaxLength = 100
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(329, 23)
        Me.TxtName.TabIndex = 3
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(3, 4)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(48, 17)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "Nome"
        '
        'TcPriceTable
        '
        Me.TcPriceTable.Controls.Add(Me.TabMain)
        Me.TcPriceTable.Controls.Add(Me.TabPartService)
        Me.TcPriceTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcPriceTable.Location = New System.Drawing.Point(0, 50)
        Me.TcPriceTable.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TcPriceTable.Multiline = True
        Me.TcPriceTable.Name = "TcPriceTable"
        Me.TcPriceTable.SelectedIndex = 0
        Me.TcPriceTable.Size = New System.Drawing.Size(349, 82)
        Me.TcPriceTable.TabIndex = 5
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.LblName)
        Me.TabMain.Controls.Add(Me.TxtName)
        Me.TabMain.Location = New System.Drawing.Point(4, 26)
        Me.TabMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabMain.Size = New System.Drawing.Size(341, 52)
        Me.TabMain.TabIndex = 0
        Me.TabMain.Text = "Identificação"
        Me.TabMain.UseVisualStyleBackColor = True
        '
        'TabPartService
        '
        Me.TabPartService.Controls.Add(Me.DgvSellablePrice)
        Me.TabPartService.Controls.Add(Me.TsSellablePrice)
        Me.TabPartService.Location = New System.Drawing.Point(4, 26)
        Me.TabPartService.Name = "TabPartService"
        Me.TabPartService.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPartService.Size = New System.Drawing.Size(341, 52)
        Me.TabPartService.TabIndex = 7
        Me.TabPartService.Text = "Peças & Serviços"
        Me.TabPartService.UseVisualStyleBackColor = True
        '
        'DgvSellablePrice
        '
        Me.DgvSellablePrice.AllowUserToAddRows = False
        Me.DgvSellablePrice.AllowUserToDeleteRows = False
        Me.DgvSellablePrice.AllowUserToOrderColumns = True
        Me.DgvSellablePrice.AllowUserToResizeRows = False
        Me.DgvSellablePrice.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvSellablePrice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvSellablePrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSellablePrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvSellablePrice.Location = New System.Drawing.Point(3, 28)
        Me.DgvSellablePrice.MultiSelect = False
        Me.DgvSellablePrice.Name = "DgvSellablePrice"
        Me.DgvSellablePrice.ReadOnly = True
        Me.DgvSellablePrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvSellablePrice.RowHeadersVisible = False
        Me.DgvSellablePrice.RowTemplate.Height = 26
        Me.DgvSellablePrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSellablePrice.Size = New System.Drawing.Size(335, 21)
        Me.DgvSellablePrice.TabIndex = 1
        '
        'TsSellablePrice
        '
        Me.TsSellablePrice.BackColor = System.Drawing.Color.Transparent
        Me.TsSellablePrice.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsSellablePrice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsSellablePrice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeSellablePrice, Me.BtnEditSellablePrice, Me.BtnDeleteSellablePrice, Me.ToolStripLabel9, Me.TxtFilterSellablePrice})
        Me.TsSellablePrice.Location = New System.Drawing.Point(3, 3)
        Me.TsSellablePrice.Name = "TsSellablePrice"
        Me.TsSellablePrice.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsSellablePrice.Size = New System.Drawing.Size(335, 25)
        Me.TsSellablePrice.TabIndex = 2
        Me.TsSellablePrice.Text = "ToolStrip2"
        '
        'BtnIncludeSellablePrice
        '
        Me.BtnIncludeSellablePrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIncludeSellablePrice.Image = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnIncludeSellablePrice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeSellablePrice.Name = "BtnIncludeSellablePrice"
        Me.BtnIncludeSellablePrice.Size = New System.Drawing.Size(23, 22)
        Me.BtnIncludeSellablePrice.Text = "Incluir Peça/Serviço"
        '
        'BtnEditSellablePrice
        '
        Me.BtnEditSellablePrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditSellablePrice.Enabled = False
        Me.BtnEditSellablePrice.Image = Global.Manager.My.Resources.Resources.EditSmall
        Me.BtnEditSellablePrice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditSellablePrice.Name = "BtnEditSellablePrice"
        Me.BtnEditSellablePrice.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditSellablePrice.Text = "Editar Peça/Serviço"
        Me.BtnEditSellablePrice.ToolTipText = "Editar"
        '
        'BtnDeleteSellablePrice
        '
        Me.BtnDeleteSellablePrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeleteSellablePrice.Enabled = False
        Me.BtnDeleteSellablePrice.Image = Global.Manager.My.Resources.Resources.DeleteSmall
        Me.BtnDeleteSellablePrice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeleteSellablePrice.Name = "BtnDeleteSellablePrice"
        Me.BtnDeleteSellablePrice.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeleteSellablePrice.Text = "Excluir Peça/Serviço"
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripLabel9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel9.Margin = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(46, 25)
        Me.ToolStripLabel9.Text = "Filtrar:"
        '
        'TxtFilterSellablePrice
        '
        Me.TxtFilterSellablePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilterSellablePrice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtFilterSellablePrice.Name = "TxtFilterSellablePrice"
        Me.TxtFilterSellablePrice.Size = New System.Drawing.Size(200, 23)
        '
        'DgvNavigator
        '
        Me.DgvNavigator.CancelNextMove = False
        Me.DgvNavigator.FirstButton = Me.BtnFirst
        Me.DgvNavigator.LastButton = Me.BtnLast
        Me.DgvNavigator.NextButton = Me.BtnNext
        Me.DgvNavigator.PreviousButton = Me.BtnPrevious
        '
        'EprInformation
        '
        Me.EprInformation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EprInformation.ContainerControl = Me
        Me.EprInformation.Icon = CType(resources.GetObject("EprInformation.Icon"), System.Drawing.Icon)
        '
        'DgvSellablePriceLayout
        '
        Me.DgvSellablePriceLayout.DataGridView = Me.DgvSellablePrice
        Me.DgvSellablePriceLayout.Routine = Manager.Routine.SellablePriceTableSellablePrice
        '
        'FrmSellablePriceTable
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(349, 176)
        Me.Controls.Add(Me.TcPriceTable)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TsTitle)
        Me.Controls.Add(Me.TsNavigation)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSellablePriceTable"
        Me.ShowIcon = False
        Me.Text = "Tabela de Preço"
        Me.Panel1.ResumeLayout(False)
        Me.TsTitle.ResumeLayout(False)
        Me.TsTitle.PerformLayout()
        Me.TsNavigation.ResumeLayout(False)
        Me.TsNavigation.PerformLayout()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TcPriceTable.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabMain.PerformLayout()
        Me.TabPartService.ResumeLayout(False)
        Me.TabPartService.PerformLayout()
        CType(Me.DgvSellablePrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TsSellablePrice.ResumeLayout(False)
        Me.TsSellablePrice.PerformLayout()
        CType(Me.EprInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents TcPriceTable As TabControl
    Friend WithEvents TabMain As TabPage
    Friend WithEvents TabPartService As TabPage
    Friend WithEvents DgvSellablePrice As DataGridView
    Friend WithEvents TsSellablePrice As ToolStrip
    Friend WithEvents BtnIncludeSellablePrice As ToolStripButton
    Friend WithEvents BtnEditSellablePrice As ToolStripButton
    Friend WithEvents BtnDeleteSellablePrice As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripLabel
    Friend WithEvents TxtFilterSellablePrice As ToolStripTextBox
    Friend WithEvents DgvSellablePriceLayout As DataGridViewLayout
    Friend WithEvents EprInformation As ErrorProvider
End Class
