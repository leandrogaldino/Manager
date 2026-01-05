<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLicenseKey
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtKeyPartA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKeyPartB = New System.Windows.Forms.TextBox()
        Me.TxtKeyPartC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtKeyPartD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtKeyPartE = New System.Windows.Forms.TextBox()
        Me.PnButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 58)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(528, 36)
        Me.PnButtons.TabIndex = 10
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(421, 3)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Informe uma chave"
        '
        'TxtKeyPartA
        '
        Me.TxtKeyPartA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKeyPartA.Location = New System.Drawing.Point(15, 29)
        Me.TxtKeyPartA.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.TxtKeyPartA.MaxLength = 5
        Me.TxtKeyPartA.Name = "TxtKeyPartA"
        Me.TxtKeyPartA.Size = New System.Drawing.Size(87, 23)
        Me.TxtKeyPartA.TabIndex = 1
        Me.TxtKeyPartA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(102, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(205, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtKeyPartB
        '
        Me.TxtKeyPartB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKeyPartB.Location = New System.Drawing.Point(118, 29)
        Me.TxtKeyPartB.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TxtKeyPartB.MaxLength = 5
        Me.TxtKeyPartB.Name = "TxtKeyPartB"
        Me.TxtKeyPartB.Size = New System.Drawing.Size(87, 23)
        Me.TxtKeyPartB.TabIndex = 3
        Me.TxtKeyPartB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtKeyPartC
        '
        Me.TxtKeyPartC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKeyPartC.Location = New System.Drawing.Point(221, 29)
        Me.TxtKeyPartC.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TxtKeyPartC.MaxLength = 5
        Me.TxtKeyPartC.Name = "TxtKeyPartC"
        Me.TxtKeyPartC.Size = New System.Drawing.Size(87, 23)
        Me.TxtKeyPartC.TabIndex = 5
        Me.TxtKeyPartC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(308, 29)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtKeyPartD
        '
        Me.TxtKeyPartD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKeyPartD.Location = New System.Drawing.Point(324, 29)
        Me.TxtKeyPartD.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TxtKeyPartD.MaxLength = 5
        Me.TxtKeyPartD.Name = "TxtKeyPartD"
        Me.TxtKeyPartD.Size = New System.Drawing.Size(87, 23)
        Me.TxtKeyPartD.TabIndex = 7
        Me.TxtKeyPartD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(411, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtKeyPartE
        '
        Me.TxtKeyPartE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKeyPartE.Location = New System.Drawing.Point(427, 29)
        Me.TxtKeyPartE.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.TxtKeyPartE.MaxLength = 5
        Me.TxtKeyPartE.Name = "TxtKeyPartE"
        Me.TxtKeyPartE.Size = New System.Drawing.Size(87, 23)
        Me.TxtKeyPartE.TabIndex = 9
        Me.TxtKeyPartE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmLicenseKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(528, 94)
        Me.Controls.Add(Me.TxtKeyPartE)
        Me.Controls.Add(Me.TxtKeyPartD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtKeyPartC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtKeyPartB)
        Me.Controls.Add(Me.TxtKeyPartA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLicenseKey"
        Me.Text = "Chave do Gerenciador"
        Me.PnButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtKeyPartA As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtKeyPartB As TextBox
    Friend WithEvents TxtKeyPartC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtKeyPartD As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtKeyPartE As TextBox
End Class
