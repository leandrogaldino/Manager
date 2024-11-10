<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTest
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.UcPrivilegeTitle1 = New Manager.UcTriStatePrivilegeTitle()
        Me.UcPrivilegeItem1 = New Manager.UcTristatePrivilegeItem()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.UcPrivilegeTitle1)
        Me.FlowLayoutPanel1.Controls.Add(Me.UcPrivilegeItem1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(38, 58)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(625, 183)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'UcPrivilegeTitle1
        '
        Me.UcPrivilegeTitle1.Location = New System.Drawing.Point(0, 0)
        Me.UcPrivilegeTitle1.Margin = New System.Windows.Forms.Padding(0)
        Me.UcPrivilegeTitle1.Name = "UcPrivilegeTitle1"
        Me.UcPrivilegeTitle1.Size = New System.Drawing.Size(470, 35)
        Me.UcPrivilegeTitle1.TabIndex = 0
        '
        'UcPrivilegeItem1
        '
        Me.UcPrivilegeItem1.CanAccess = False
        Me.UcPrivilegeItem1.CanDelete = False
        Me.UcPrivilegeItem1.CanWrite = False
        Me.UcPrivilegeItem1.Location = New System.Drawing.Point(0, 35)
        Me.UcPrivilegeItem1.Margin = New System.Windows.Forms.Padding(0)
        Me.UcPrivilegeItem1.Name = "UcPrivilegeItem1"
        Me.UcPrivilegeItem1.Size = New System.Drawing.Size(470, 45)
        Me.UcPrivilegeItem1.TabIndex = 1
        '
        'FrmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 320)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "FrmTest"
        Me.Text = "Test"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents UcPrivilegeTitle1 As UcTriStatePrivilegeTitle
    Friend WithEvents UcPrivilegeItem1 As UcTristatePrivilegeItem
End Class
