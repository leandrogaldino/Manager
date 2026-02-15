<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCustomerLinkToken
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
        Me.PnLeft = New System.Windows.Forms.Panel()
        Me.LblDescription = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TxtLinkToken = New System.Windows.Forms.TextBox()
        Me.LblLinkToken = New System.Windows.Forms.Label()
        Me.BtnSave = New CoreSuite.Controls.NoFocusCueButton()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.PnLeft.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.PnButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnLeft
        '
        Me.PnLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.PnLeft.Controls.Add(Me.LblDescription)
        Me.PnLeft.Controls.Add(Me.LblTitle)
        Me.PnLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnLeft.Location = New System.Drawing.Point(0, 0)
        Me.PnLeft.Name = "PnLeft"
        Me.PnLeft.Size = New System.Drawing.Size(165, 225)
        Me.PnLeft.TabIndex = 10
        '
        'LblDescription
        '
        Me.LblDescription.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblDescription.Location = New System.Drawing.Point(0, 41)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Padding = New System.Windows.Forms.Padding(5, 15, 5, 15)
        Me.LblDescription.Size = New System.Drawing.Size(165, 184)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Informe aqui o token que faz a ligação do cliente com a base de dados de licencia" &
    "mento."
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(165, 41)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Link Token"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.White
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.TxtLinkToken)
        Me.Panel21.Controls.Add(Me.LblLinkToken)
        Me.Panel21.Location = New System.Drawing.Point(171, 10)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel21.Size = New System.Drawing.Size(450, 209)
        Me.Panel21.TabIndex = 11
        '
        'TxtLinkToken
        '
        Me.TxtLinkToken.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.TxtLinkToken.Location = New System.Drawing.Point(131, 3)
        Me.TxtLinkToken.Multiline = True
        Me.TxtLinkToken.Name = "TxtLinkToken"
        Me.TxtLinkToken.Size = New System.Drawing.Size(314, 201)
        Me.TxtLinkToken.TabIndex = 1
        '
        'LblLinkToken
        '
        Me.LblLinkToken.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblLinkToken.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LblLinkToken.Location = New System.Drawing.Point(4, 0)
        Me.LblLinkToken.Margin = New System.Windows.Forms.Padding(4, 0, 15, 0)
        Me.LblLinkToken.Name = "LblLinkToken"
        Me.LblLinkToken.Size = New System.Drawing.Size(120, 207)
        Me.LblLinkToken.TabIndex = 0
        Me.LblLinkToken.Text = "Link Token"
        Me.LblLinkToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnSave.Location = New System.Drawing.Point(527, 9)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 32)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Validar"
        Me.BtnSave.TooltipText = ""
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 225)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(629, 48)
        Me.PnButtons.TabIndex = 16
        '
        'FrmCustomerLinkToken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(629, 273)
        Me.Controls.Add(Me.PnLeft)
        Me.Controls.Add(Me.PnButtons)
        Me.Controls.Add(Me.Panel21)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCustomerLinkToken"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Link Token do Cliente"
        Me.PnLeft.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.PnButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnLeft As Panel
    Friend WithEvents LblDescription As Label
    Friend WithEvents LblTitle As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TxtLinkToken As TextBox
    Friend WithEvents LblLinkToken As Label
    Friend WithEvents BtnSave As CoreSuite.Controls.NoFocusCueButton
    Friend WithEvents PnButtons As Panel
End Class
