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
        Me.FlpPrivilege = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnIncludeCompany = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditCompany = New System.Windows.Forms.ToolStripButton()
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnIncludeCompany, Me.BtnEditCompany})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(553, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnIncludeCompany
        '
        Me.BtnIncludeCompany.Image = Global.ManagerAgent.My.Resources.Resources.Include
        Me.BtnIncludeCompany.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIncludeCompany.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.BtnIncludeCompany.Name = "BtnIncludeCompany"
        Me.BtnIncludeCompany.Size = New System.Drawing.Size(60, 22)
        Me.BtnIncludeCompany.Text = "Incluir"
        '
        'BtnEditCompany
        '
        Me.BtnEditCompany.Image = Global.ManagerAgent.My.Resources.Resources.Edit
        Me.BtnEditCompany.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditCompany.Name = "BtnEditCompany"
        Me.BtnEditCompany.Size = New System.Drawing.Size(57, 22)
        Me.BtnEditCompany.Text = "Editar"
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
    Friend WithEvents BtnIncludeCompany As ToolStripButton
    Friend WithEvents BtnEditCompany As ToolStripButton
End Class
