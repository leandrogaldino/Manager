<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompanies
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompanies))
        Me.FlpPrivilege = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.RegisterCompany = New System.Windows.Forms.ToolStripButton()
        Me.EditCompany = New System.Windows.Forms.ToolStripButton()
        Me.DisableCompany = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlpPrivilege
        '
        Me.FlpPrivilege.AutoScroll = True
        Me.FlpPrivilege.Location = New System.Drawing.Point(11, 28)
        Me.FlpPrivilege.Name = "FlpPrivilege"
        Me.FlpPrivilege.Size = New System.Drawing.Size(530, 363)
        Me.FlpPrivilege.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegisterCompany, Me.EditCompany, Me.DisableCompany})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(553, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'RegisterCompany
        '
        Me.RegisterCompany.Image = CType(resources.GetObject("RegisterCompany.Image"), System.Drawing.Image)
        Me.RegisterCompany.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RegisterCompany.Name = "RegisterCompany"
        Me.RegisterCompany.Size = New System.Drawing.Size(73, 22)
        Me.RegisterCompany.Text = "Registrar"
        '
        'EditCompany
        '
        Me.EditCompany.Image = CType(resources.GetObject("EditCompany.Image"), System.Drawing.Image)
        Me.EditCompany.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditCompany.Name = "EditCompany"
        Me.EditCompany.Size = New System.Drawing.Size(57, 22)
        Me.EditCompany.Text = "Editar"
        '
        'DisableCompany
        '
        Me.DisableCompany.Image = CType(resources.GetObject("DisableCompany.Image"), System.Drawing.Image)
        Me.DisableCompany.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DisableCompany.Name = "DisableCompany"
        Me.DisableCompany.Size = New System.Drawing.Size(75, 22)
        Me.DisableCompany.Text = "Desativar"
        '
        'FrmCompanies
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(553, 401)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.FlpPrivilege)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompanies"
        Me.ShowIcon = False
        Me.Text = "Empresas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlpPrivilege As FlowLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents RegisterCompany As ToolStripButton
    Friend WithEvents EditCompany As ToolStripButton
    Friend WithEvents DisableCompany As ToolStripButton
End Class
