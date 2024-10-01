<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.TcTool = New System.Windows.Forms.TabControl()
        Me.TabCrypto = New System.Windows.Forms.TabPage()
        Me.TsBar = New System.Windows.Forms.ToolStrip()
        Me.BtnOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtCryptoKey = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnSaveContent = New System.Windows.Forms.Button()
        Me.TxtFileContent = New System.Windows.Forms.TextBox()
        Me.TabKey = New System.Windows.Forms.TabPage()
        Me.BtnCopyKey = New ControlLibrary.NoFocusCueButton()
        Me.BtnGenerateKey = New System.Windows.Forms.Button()
        Me.TxtGeneratedKey = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OfdFile = New System.Windows.Forms.OpenFileDialog()
        Me.SfdFile = New System.Windows.Forms.SaveFileDialog()
        Me.TcTool.SuspendLayout()
        Me.TabCrypto.SuspendLayout()
        Me.TsBar.SuspendLayout()
        Me.TabKey.SuspendLayout()
        Me.SuspendLayout()
        '
        'TcTool
        '
        Me.TcTool.Controls.Add(Me.TabCrypto)
        Me.TcTool.Controls.Add(Me.TabKey)
        Me.TcTool.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcTool.Location = New System.Drawing.Point(0, 0)
        Me.TcTool.Margin = New System.Windows.Forms.Padding(4)
        Me.TcTool.Multiline = True
        Me.TcTool.Name = "TcTool"
        Me.TcTool.SelectedIndex = 0
        Me.TcTool.Size = New System.Drawing.Size(684, 461)
        Me.TcTool.TabIndex = 0
        '
        'TabCrypto
        '
        Me.TabCrypto.Controls.Add(Me.TsBar)
        Me.TabCrypto.Controls.Add(Me.BtnSaveContent)
        Me.TabCrypto.Controls.Add(Me.TxtFileContent)
        Me.TabCrypto.Location = New System.Drawing.Point(4, 26)
        Me.TabCrypto.Margin = New System.Windows.Forms.Padding(4)
        Me.TabCrypto.Name = "TabCrypto"
        Me.TabCrypto.Padding = New System.Windows.Forms.Padding(4)
        Me.TabCrypto.Size = New System.Drawing.Size(676, 431)
        Me.TabCrypto.TabIndex = 1
        Me.TabCrypto.Text = "Criptografia"
        Me.TabCrypto.UseVisualStyleBackColor = True
        '
        'TsBar
        '
        Me.TsBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnOpenFile, Me.ToolStripLabel1, Me.TxtCryptoKey})
        Me.TsBar.Location = New System.Drawing.Point(4, 4)
        Me.TsBar.Name = "TsBar"
        Me.TsBar.Size = New System.Drawing.Size(668, 25)
        Me.TsBar.TabIndex = 10
        Me.TsBar.Text = "ToolStrip1"
        '
        'BtnOpenFile
        '
        Me.BtnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnOpenFile.Image = CType(resources.GetObject("BtnOpenFile.Image"), System.Drawing.Image)
        Me.BtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnOpenFile.Name = "BtnOpenFile"
        Me.BtnOpenFile.Size = New System.Drawing.Size(82, 22)
        Me.BtnOpenFile.Text = "Abrir Arquivo"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(25, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripLabel1.Text = "CryptoKey:"
        '
        'TxtCryptoKey
        '
        Me.TxtCryptoKey.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtCryptoKey.Name = "TxtCryptoKey"
        Me.TxtCryptoKey.Size = New System.Drawing.Size(300, 25)
        '
        'BtnSaveContent
        '
        Me.BtnSaveContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveContent.Location = New System.Drawing.Point(7, 398)
        Me.BtnSaveContent.Name = "BtnSaveContent"
        Me.BtnSaveContent.Size = New System.Drawing.Size(661, 27)
        Me.BtnSaveContent.TabIndex = 7
        Me.BtnSaveContent.Text = "Salvar"
        Me.BtnSaveContent.UseVisualStyleBackColor = True
        '
        'TxtFileContent
        '
        Me.TxtFileContent.AllowDrop = True
        Me.TxtFileContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFileContent.Location = New System.Drawing.Point(7, 32)
        Me.TxtFileContent.Multiline = True
        Me.TxtFileContent.Name = "TxtFileContent"
        Me.TxtFileContent.Size = New System.Drawing.Size(661, 360)
        Me.TxtFileContent.TabIndex = 6
        Me.TxtFileContent.WordWrap = False
        '
        'TabKey
        '
        Me.TabKey.Controls.Add(Me.BtnCopyKey)
        Me.TabKey.Controls.Add(Me.BtnGenerateKey)
        Me.TabKey.Controls.Add(Me.TxtGeneratedKey)
        Me.TabKey.Controls.Add(Me.Label3)
        Me.TabKey.Location = New System.Drawing.Point(4, 26)
        Me.TabKey.Margin = New System.Windows.Forms.Padding(4)
        Me.TabKey.Name = "TabKey"
        Me.TabKey.Padding = New System.Windows.Forms.Padding(4)
        Me.TabKey.Size = New System.Drawing.Size(676, 431)
        Me.TabKey.TabIndex = 0
        Me.TabKey.Text = "Chave"
        Me.TabKey.UseVisualStyleBackColor = True
        '
        'BtnCopyKey
        '
        Me.BtnCopyKey.BackColor = System.Drawing.Color.Transparent
        Me.BtnCopyKey.BackgroundImage = Global.ManagerTools.My.Resources.Resources.Copy
        Me.BtnCopyKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnCopyKey.FlatAppearance.BorderSize = 0
        Me.BtnCopyKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCopyKey.Location = New System.Drawing.Point(357, 5)
        Me.BtnCopyKey.Name = "BtnCopyKey"
        Me.BtnCopyKey.Size = New System.Drawing.Size(17, 17)
        Me.BtnCopyKey.TabIndex = 11
        Me.BtnCopyKey.TabStop = False
        Me.BtnCopyKey.TooltipText = "Copiar Chave"
        Me.BtnCopyKey.UseVisualStyleBackColor = False
        Me.BtnCopyKey.Visible = False
        '
        'BtnGenerateKey
        '
        Me.BtnGenerateKey.Location = New System.Drawing.Point(11, 52)
        Me.BtnGenerateKey.Name = "BtnGenerateKey"
        Me.BtnGenerateKey.Size = New System.Drawing.Size(363, 29)
        Me.BtnGenerateKey.TabIndex = 4
        Me.BtnGenerateKey.Text = "Gerar"
        Me.BtnGenerateKey.UseVisualStyleBackColor = True
        '
        'TxtGeneratedKey
        '
        Me.TxtGeneratedKey.Location = New System.Drawing.Point(11, 23)
        Me.TxtGeneratedKey.Name = "TxtGeneratedKey"
        Me.TxtGeneratedKey.ReadOnly = True
        Me.TxtGeneratedKey.Size = New System.Drawing.Size(363, 23)
        Me.TxtGeneratedKey.TabIndex = 3
        Me.TxtGeneratedKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Chave"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 461)
        Me.Controls.Add(Me.TcTool)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ferramentas do Gerenciador"
        Me.TcTool.ResumeLayout(False)
        Me.TabCrypto.ResumeLayout(False)
        Me.TabCrypto.PerformLayout()
        Me.TsBar.ResumeLayout(False)
        Me.TsBar.PerformLayout()
        Me.TabKey.ResumeLayout(False)
        Me.TabKey.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TcTool As TabControl
    Friend WithEvents TabKey As TabPage
    Friend WithEvents TabCrypto As TabPage
    Friend WithEvents BtnGenerateKey As Button
    Friend WithEvents TxtGeneratedKey As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnSaveContent As Button
    Friend WithEvents TxtFileContent As TextBox
    Friend WithEvents BtnCopyKey As ControlLibrary.NoFocusCueButton
    Friend WithEvents OfdFile As OpenFileDialog
    Friend WithEvents SfdFile As SaveFileDialog
    Friend WithEvents TsBar As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TxtCryptoKey As ToolStripTextBox
    Friend WithEvents BtnOpenFile As ToolStripButton
End Class
