<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigurationWizard
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
        Me.PnDescription = New System.Windows.Forms.Panel()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.LblDescription = New System.Windows.Forms.Label()
        Me.PnPage = New System.Windows.Forms.Panel()
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnSave = New System.Windows.Forms.Button()
         Me.PnDescription.SuspendLayout()
        Me.PnPage.SuspendLayout()
        Me.PnButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnDescription
        '
        Me.PnDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.PnDescription.Controls.Add(Me.LblDescription)
        Me.PnDescription.Controls.Add(Me.LblTitle)
        Me.PnDescription.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnDescription.Location = New System.Drawing.Point(0, 0)
        Me.PnDescription.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnDescription.Name = "PnDescription"
        Me.PnDescription.Size = New System.Drawing.Size(179, 296)
        Me.PnDescription.TabIndex = 0
        '
        'LblTitle
        '
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.ForeColor = System.Drawing.Color.White
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(179, 30)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Label1"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblDescription
        '
        Me.LblDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblDescription.ForeColor = System.Drawing.Color.White
        Me.LblDescription.Location = New System.Drawing.Point(0, 30)
        Me.LblDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Padding = New System.Windows.Forms.Padding(15)
        Me.LblDescription.Size = New System.Drawing.Size(179, 266)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Description"
        '
        'PnPage
        '
        Me.PnPage.BackColor = System.Drawing.Color.White
        Me.PnPage.Controls.Add(Me.PnButtons)
        Me.PnPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnPage.Location = New System.Drawing.Point(179, 0)
        Me.PnPage.Name = "PnPage"
        Me.PnPage.Size = New System.Drawing.Size(474, 296)
        Me.PnPage.TabIndex = 1
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.PnButtons.Controls.Add(Me.BtnSave)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 243)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(474, 53)
        Me.PnButtons.TabIndex = 6
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(367, 11)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Salvar"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'FrmConfigurationWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 296)
        Me.Controls.Add(Me.PnPage)
        Me.Controls.Add(Me.PnDescription)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmConfigurationWizard"
        Me.Text = "FrmConfigurationWizard"
        Me.PnDescription.ResumeLayout(False)
        Me.PnPage.ResumeLayout(False)
        Me.PnButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnDescription As Panel
    Friend WithEvents LblDescription As Label
    Friend WithEvents LblTitle As Label
    Friend WithEvents PnPage As Panel
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnSave As Button
End Class
