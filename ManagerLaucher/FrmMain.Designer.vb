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
        Me.PnContent = New System.Windows.Forms.Panel()
        Me.UcSplash = New ManagerLaucher.UcSplash()
        Me.TimerRun = New System.Windows.Forms.Timer(Me.components)
        Me.BtnClose = New ManagerLaucher.CustomButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RbtType = New System.Windows.Forms.RadioButton()
        Me.RbtChose = New System.Windows.Forms.RadioButton()
        Me.PnContent.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnContent
        '
        Me.PnContent.Controls.Add(Me.UcSplash)
        Me.PnContent.Location = New System.Drawing.Point(0, 150)
        Me.PnContent.Name = "PnContent"
        Me.PnContent.Size = New System.Drawing.Size(400, 99)
        Me.PnContent.TabIndex = 5
        '
        'UcSplash
        '
        Me.UcSplash.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.UcSplash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSplash.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSplash.Location = New System.Drawing.Point(0, 0)
        Me.UcSplash.Margin = New System.Windows.Forms.Padding(4)
        Me.UcSplash.Name = "UcSplash"
        Me.UcSplash.Size = New System.Drawing.Size(400, 99)
        Me.UcSplash.TabIndex = 0
        '
        'TimerRun
        '
        Me.TimerRun.Enabled = True
        Me.TimerRun.Interval = 2000
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnClose.FlatAppearance.BorderSize = 0
        Me.BtnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.BtnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(371, -1)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(2, 3, 10, 20)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(29, 26)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "X"
        Me.BtnClose.TooltipText = ""
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ManagerLaucher.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(3, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(394, 102)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'RbtType
        '
        Me.RbtType.AutoSize = True
        Me.RbtType.Checked = True
        Me.RbtType.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtType.ForeColor = System.Drawing.Color.White
        Me.RbtType.Location = New System.Drawing.Point(12, 3)
        Me.RbtType.Name = "RbtType"
        Me.RbtType.Size = New System.Drawing.Size(74, 24)
        Me.RbtType.TabIndex = 9
        Me.RbtType.TabStop = True
        Me.RbtType.Text = "Digitar"
        Me.RbtType.UseVisualStyleBackColor = True
        Me.RbtType.Visible = False
        '
        'RbtChose
        '
        Me.RbtChose.AutoSize = True
        Me.RbtChose.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtChose.ForeColor = System.Drawing.Color.White
        Me.RbtChose.Location = New System.Drawing.Point(92, 3)
        Me.RbtChose.Name = "RbtChose"
        Me.RbtChose.Size = New System.Drawing.Size(88, 24)
        Me.RbtChose.TabIndex = 8
        Me.RbtChose.Text = "Escolher"
        Me.RbtChose.UseVisualStyleBackColor = True
        Me.RbtChose.Visible = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(400, 250)
        Me.Controls.Add(Me.RbtType)
        Me.Controls.Add(Me.RbtChose)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.PnContent)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.PnContent.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PnContent As Panel
    Friend WithEvents BtnClose As CustomButton
    Friend WithEvents TimerRun As Timer
    Friend WithEvents UcSplash As UcSplash
    Friend WithEvents RbtType As RadioButton
    Friend WithEvents RbtChose As RadioButton
End Class
