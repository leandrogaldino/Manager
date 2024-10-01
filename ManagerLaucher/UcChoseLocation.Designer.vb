<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcChoseLocation
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FbdAgentDir = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnAgentDir = New ManagerLaucher.CustomButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 99)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selecione o local de instalação do Agente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FbdAgentDir
        '
        Me.FbdAgentDir.ShowNewFolderButton = False
        '
        'BtnAgentDir
        '
        Me.BtnAgentDir.BackColor = System.Drawing.Color.Transparent
        Me.BtnAgentDir.BackgroundImage = Global.ManagerLaucher.My.Resources.Resources.OpenFolder
        Me.BtnAgentDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnAgentDir.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAgentDir.FlatAppearance.BorderSize = 0
        Me.BtnAgentDir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.BtnAgentDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnAgentDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgentDir.Location = New System.Drawing.Point(340, 0)
        Me.BtnAgentDir.Margin = New System.Windows.Forms.Padding(2, 3, 10, 20)
        Me.BtnAgentDir.Name = "BtnAgentDir"
        Me.BtnAgentDir.Size = New System.Drawing.Size(54, 99)
        Me.BtnAgentDir.TabIndex = 5
        Me.BtnAgentDir.TooltipText = ""
        Me.BtnAgentDir.UseVisualStyleBackColor = False
        '
        'UcChoseLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnAgentDir)
        Me.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UcChoseLocation"
        Me.Size = New System.Drawing.Size(394, 99)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnAgentDir As CustomButton
    Friend WithEvents Label1 As Label
    Friend WithEvents FbdAgentDir As FolderBrowserDialog
End Class
