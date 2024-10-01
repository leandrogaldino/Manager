<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.TsBotMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.LblCompany = New System.Windows.Forms.ToolStripLabel()
        Me.LblUser = New System.Windows.Forms.ToolStripLabel()
        Me.BtnUser = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEmailModel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEmailSign = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEmailSent = New System.Windows.Forms.ToolStripMenuItem()
        Me.LblVersion = New System.Windows.Forms.ToolStripLabel()
        Me.TcWindows = New System.Windows.Forms.TabControl()
        Me.TabRoutine = New System.Windows.Forms.TabPage()
        Me.TsRoutine = New System.Windows.Forms.ToolStrip()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.TcMenu = New System.Windows.Forms.TabControl()
        Me.TimerAccess = New System.Windows.Forms.Timer(Me.components)
        Me.TsBotMenu.SuspendLayout()
        Me.TabRoutine.SuspendLayout()
        Me.TsRoutine.SuspendLayout()
        Me.TcMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TsBotMenu
        '
        Me.TsBotMenu.BackColor = System.Drawing.Color.Gainsboro
        Me.TsBotMenu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TsBotMenu.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsBotMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsBotMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TsBotMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.LblCompany, Me.LblUser, Me.BtnUser, Me.LblVersion})
        Me.TsBotMenu.Location = New System.Drawing.Point(0, 463)
        Me.TsBotMenu.Name = "TsBotMenu"
        Me.TsBotMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsBotMenu.Size = New System.Drawing.Size(990, 25)
        Me.TsBotMenu.TabIndex = 2
        Me.TsBotMenu.Text = "     "
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripLabel1.Text = "EMPRESA:"
        Me.ToolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'LblCompany
        '
        Me.LblCompany.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCompany.ForeColor = System.Drawing.Color.Black
        Me.LblCompany.Name = "LblCompany"
        Me.LblCompany.Size = New System.Drawing.Size(74, 22)
        Me.LblCompany.Text = "@Empresa"
        Me.LblCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'LblUser
        '
        Me.LblUser.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUser.ForeColor = System.Drawing.Color.Black
        Me.LblUser.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(67, 22)
        Me.LblUser.Text = "USUÁRIO:"
        Me.LblUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'BtnUser
        '
        Me.BtnUser.AutoToolTip = False
        Me.BtnUser.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnChangePassword, Me.BtnEmail})
        Me.BtnUser.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUser.ForeColor = System.Drawing.Color.Black
        Me.BtnUser.Name = "BtnUser"
        Me.BtnUser.Size = New System.Drawing.Size(78, 22)
        Me.BtnUser.Text = "@Usuário"
        Me.BtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'BtnChangePassword
        '
        Me.BtnChangePassword.Image = Global.Manager.My.Resources.Resources.ResetPassword
        Me.BtnChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnChangePassword.Name = "BtnChangePassword"
        Me.BtnChangePassword.Size = New System.Drawing.Size(161, 22)
        Me.BtnChangePassword.Text = "Alterar Senha"
        '
        'BtnEmail
        '
        Me.BtnEmail.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnEmailModel, Me.BtnEmailSign, Me.BtnEmailSent})
        Me.BtnEmail.Image = Global.Manager.My.Resources.Resources.EmailModel
        Me.BtnEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnEmail.Name = "BtnEmail"
        Me.BtnEmail.Size = New System.Drawing.Size(161, 22)
        Me.BtnEmail.Text = "E-Mail"
        '
        'BtnEmailModel
        '
        Me.BtnEmailModel.Image = CType(resources.GetObject("BtnEmailModel.Image"), System.Drawing.Image)
        Me.BtnEmailModel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnEmailModel.Name = "BtnEmailModel"
        Me.BtnEmailModel.Size = New System.Drawing.Size(146, 22)
        Me.BtnEmailModel.Text = "Modelos"
        '
        'BtnEmailSign
        '
        Me.BtnEmailSign.Image = CType(resources.GetObject("BtnEmailSign.Image"), System.Drawing.Image)
        Me.BtnEmailSign.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnEmailSign.Name = "BtnEmailSign"
        Me.BtnEmailSign.Size = New System.Drawing.Size(146, 22)
        Me.BtnEmailSign.Text = "Assinaturas"
        '
        'BtnEmailSent
        '
        Me.BtnEmailSent.Image = Global.Manager.My.Resources.Resources.EmailSent
        Me.BtnEmailSent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnEmailSent.Name = "BtnEmailSent"
        Me.BtnEmailSent.Size = New System.Drawing.Size(146, 22)
        Me.BtnEmailSent.Text = "Enviados"
        '
        'LblVersion
        '
        Me.LblVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblVersion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.LblVersion.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(24, 22)
        Me.LblVersion.Text = "x.x"
        Me.LblVersion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TcWindows
        '
        Me.TcWindows.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TcWindows.Location = New System.Drawing.Point(0, 102)
        Me.TcWindows.Name = "TcWindows"
        Me.TcWindows.SelectedIndex = 0
        Me.TcWindows.Size = New System.Drawing.Size(990, 361)
        Me.TcWindows.TabIndex = 13
        '
        'TabRoutine
        '
        Me.TabRoutine.Controls.Add(Me.TsRoutine)
        Me.TabRoutine.Location = New System.Drawing.Point(4, 26)
        Me.TabRoutine.Name = "TabRoutine"
        Me.TabRoutine.Padding = New System.Windows.Forms.Padding(3)
        Me.TabRoutine.Size = New System.Drawing.Size(982, 62)
        Me.TabRoutine.TabIndex = 0
        Me.TabRoutine.Text = "Rotinas"
        Me.TabRoutine.UseVisualStyleBackColor = True
        '
        'TsRoutine
        '
        Me.TsRoutine.BackColor = System.Drawing.Color.White
        Me.TsRoutine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TsRoutine.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsRoutine.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TsRoutine.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TsRoutine.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExit})
        Me.TsRoutine.Location = New System.Drawing.Point(3, 3)
        Me.TsRoutine.Name = "TsRoutine"
        Me.TsRoutine.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TsRoutine.Size = New System.Drawing.Size(976, 58)
        Me.TsRoutine.TabIndex = 6
        Me.TsRoutine.Text = "ToolStrip1"
        '
        'BtnExit
        '
        Me.BtnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnExit.AutoSize = False
        Me.BtnExit.AutoToolTip = False
        Me.BtnExit.Image = Global.Manager.My.Resources.Resources.Logoff
        Me.BtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(40, 55)
        Me.BtnExit.Text = "Sair"
        Me.BtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnExit.ToolTipText = "Sair do Sistema"
        '
        'TcMenu
        '
        Me.TcMenu.Controls.Add(Me.TabRoutine)
        Me.TcMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.TcMenu.Location = New System.Drawing.Point(0, 10)
        Me.TcMenu.Name = "TcMenu"
        Me.TcMenu.SelectedIndex = 0
        Me.TcMenu.Size = New System.Drawing.Size(990, 92)
        Me.TcMenu.TabIndex = 10
        '
        'TimerAccess
        '
        Me.TimerAccess.Enabled = True
        Me.TimerAccess.Interval = 10000
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(990, 488)
        Me.Controls.Add(Me.TcWindows)
        Me.Controls.Add(Me.TcMenu)
        Me.Controls.Add(Me.TsBotMenu)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmMain"
        Me.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.Text = "Gerenciador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TsBotMenu.ResumeLayout(False)
        Me.TsBotMenu.PerformLayout()
        Me.TabRoutine.ResumeLayout(False)
        Me.TabRoutine.PerformLayout()
        Me.TsRoutine.ResumeLayout(False)
        Me.TsRoutine.PerformLayout()
        Me.TcMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TsBotMenu As ToolStrip
    Friend WithEvents TcWindows As TabControl
    Friend WithEvents LblUser As ToolStripLabel
    Friend WithEvents BtnUser As ToolStripDropDownButton
    Friend WithEvents BtnChangePassword As ToolStripMenuItem
    Friend WithEvents TabRoutine As TabPage
    Friend WithEvents TcMenu As TabControl
    Friend WithEvents TsRoutine As ToolStrip
    Friend WithEvents BtnExit As ToolStripButton
    Friend WithEvents TimerAccess As Timer
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents LblCompany As ToolStripLabel
    Friend WithEvents BtnEmail As ToolStripMenuItem
    Friend WithEvents BtnEmailModel As ToolStripMenuItem
    Friend WithEvents BtnEmailSign As ToolStripMenuItem
    Friend WithEvents BtnEmailSent As ToolStripMenuItem
    Friend WithEvents LblVersion As ToolStripLabel
End Class
