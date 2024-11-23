<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcTristatePrivilegeItem
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Me.TlpContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.PnDelete = New System.Windows.Forms.Panel()
        Me.CbxDelete = New System.Windows.Forms.CheckBox()
        Me.PnWrite = New System.Windows.Forms.Panel()
        Me.CbxWrite = New System.Windows.Forms.CheckBox()
        Me.PnPrivilege = New System.Windows.Forms.Panel()
        Me.LblPrivilege = New System.Windows.Forms.Label()
        Me.PnAccess = New System.Windows.Forms.Panel()
        Me.CbxAccess = New System.Windows.Forms.CheckBox()
        Me.CbxTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TlpContainer.SuspendLayout()
        Me.PnDelete.SuspendLayout()
        Me.PnWrite.SuspendLayout()
        Me.PnPrivilege.SuspendLayout()
        Me.PnAccess.SuspendLayout()
        Me.SuspendLayout()
        '
        'TlpContainer
        '
        Me.TlpContainer.ColumnCount = 4
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636!))
        Me.TlpContainer.Controls.Add(Me.PnDelete, 3, 0)
        Me.TlpContainer.Controls.Add(Me.PnWrite, 2, 0)
        Me.TlpContainer.Controls.Add(Me.PnPrivilege, 0, 0)
        Me.TlpContainer.Controls.Add(Me.PnAccess, 1, 0)
        Me.TlpContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TlpContainer.Location = New System.Drawing.Point(0, 0)
        Me.TlpContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.TlpContainer.Name = "TlpContainer"
        Me.TlpContainer.RowCount = 1
        Me.TlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpContainer.Size = New System.Drawing.Size(470, 30)
        Me.TlpContainer.TabIndex = 2
        '
        'PnDelete
        '
        Me.PnDelete.BackColor = System.Drawing.Color.Gray
        Me.PnDelete.Controls.Add(Me.CbxDelete)
        Me.PnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnDelete.Location = New System.Drawing.Point(405, 0)
        Me.PnDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.PnDelete.Name = "PnDelete"
        Me.PnDelete.Padding = New System.Windows.Forms.Padding(0, 0, 1, 1)
        Me.PnDelete.Size = New System.Drawing.Size(65, 30)
        Me.PnDelete.TabIndex = 14
        '
        'CbxDelete
        '
        Me.CbxDelete.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxDelete.BackColor = System.Drawing.Color.White
        Me.CbxDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxDelete.FlatAppearance.BorderSize = 0
        Me.CbxDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.CbxDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.CbxDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.CbxDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxDelete.Image = Global.Manager.My.Resources.Resources.Reject
        Me.CbxDelete.Location = New System.Drawing.Point(0, 0)
        Me.CbxDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.CbxDelete.Name = "CbxDelete"
        Me.CbxDelete.Size = New System.Drawing.Size(64, 29)
        Me.CbxDelete.TabIndex = 11
        Me.CbxDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CbxDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CbxTip.SetToolTip(Me.CbxDelete, "Deletar")
        Me.CbxDelete.UseVisualStyleBackColor = False
        '
        'PnWrite
        '
        Me.PnWrite.BackColor = System.Drawing.Color.Gray
        Me.PnWrite.Controls.Add(Me.CbxWrite)
        Me.PnWrite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnWrite.Location = New System.Drawing.Point(341, 0)
        Me.PnWrite.Margin = New System.Windows.Forms.Padding(0)
        Me.PnWrite.Name = "PnWrite"
        Me.PnWrite.Padding = New System.Windows.Forms.Padding(0, 0, 1, 1)
        Me.PnWrite.Size = New System.Drawing.Size(64, 30)
        Me.PnWrite.TabIndex = 13
        '
        'CbxWrite
        '
        Me.CbxWrite.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxWrite.BackColor = System.Drawing.Color.White
        Me.CbxWrite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxWrite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxWrite.FlatAppearance.BorderSize = 0
        Me.CbxWrite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.CbxWrite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.CbxWrite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.CbxWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxWrite.Image = Global.Manager.My.Resources.Resources.Reject
        Me.CbxWrite.Location = New System.Drawing.Point(0, 0)
        Me.CbxWrite.Margin = New System.Windows.Forms.Padding(0)
        Me.CbxWrite.Name = "CbxWrite"
        Me.CbxWrite.Size = New System.Drawing.Size(63, 29)
        Me.CbxWrite.TabIndex = 11
        Me.CbxWrite.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CbxWrite.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CbxTip.SetToolTip(Me.CbxWrite, "Escrever")
        Me.CbxWrite.UseVisualStyleBackColor = False
        '
        'PnPrivilege
        '
        Me.PnPrivilege.BackColor = System.Drawing.Color.Gray
        Me.PnPrivilege.Controls.Add(Me.LblPrivilege)
        Me.PnPrivilege.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnPrivilege.Location = New System.Drawing.Point(0, 0)
        Me.PnPrivilege.Margin = New System.Windows.Forms.Padding(0)
        Me.PnPrivilege.Name = "PnPrivilege"
        Me.PnPrivilege.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.PnPrivilege.Size = New System.Drawing.Size(277, 30)
        Me.PnPrivilege.TabIndex = 11
        '
        'LblPrivilege
        '
        Me.LblPrivilege.BackColor = System.Drawing.Color.White
        Me.LblPrivilege.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblPrivilege.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrivilege.Location = New System.Drawing.Point(1, 0)
        Me.LblPrivilege.Name = "LblPrivilege"
        Me.LblPrivilege.Size = New System.Drawing.Size(275, 29)
        Me.LblPrivilege.TabIndex = 1
        Me.LblPrivilege.Text = "Privilege"
        Me.LblPrivilege.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnAccess
        '
        Me.PnAccess.BackColor = System.Drawing.Color.Gray
        Me.PnAccess.Controls.Add(Me.CbxAccess)
        Me.PnAccess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnAccess.Location = New System.Drawing.Point(277, 0)
        Me.PnAccess.Margin = New System.Windows.Forms.Padding(0)
        Me.PnAccess.Name = "PnAccess"
        Me.PnAccess.Padding = New System.Windows.Forms.Padding(0, 0, 1, 1)
        Me.PnAccess.Size = New System.Drawing.Size(64, 30)
        Me.PnAccess.TabIndex = 12
        '
        'CbxAccess
        '
        Me.CbxAccess.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxAccess.BackColor = System.Drawing.Color.White
        Me.CbxAccess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxAccess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxAccess.FlatAppearance.BorderSize = 0
        Me.CbxAccess.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.CbxAccess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.CbxAccess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.CbxAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxAccess.Image = Global.Manager.My.Resources.Resources.Reject
        Me.CbxAccess.Location = New System.Drawing.Point(0, 0)
        Me.CbxAccess.Margin = New System.Windows.Forms.Padding(0)
        Me.CbxAccess.Name = "CbxAccess"
        Me.CbxAccess.Size = New System.Drawing.Size(63, 29)
        Me.CbxAccess.TabIndex = 11
        Me.CbxAccess.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CbxAccess.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CbxTip.SetToolTip(Me.CbxAccess, "Acessar")
        Me.CbxAccess.UseVisualStyleBackColor = False
        '
        'UcTristatePrivilegeItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TlpContainer)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UcTristatePrivilegeItem"
        Me.Size = New System.Drawing.Size(470, 30)
        Me.TlpContainer.ResumeLayout(False)
        Me.PnDelete.ResumeLayout(False)
        Me.PnWrite.ResumeLayout(False)
        Me.PnPrivilege.ResumeLayout(False)
        Me.PnAccess.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents TlpContainer As TableLayoutPanel
    Private WithEvents PnDelete As Panel
    Private WithEvents CbxDelete As CheckBox
    Private WithEvents PnWrite As Panel
    Private WithEvents CbxWrite As CheckBox
    Private WithEvents PnPrivilege As Panel
    Private WithEvents LblPrivilege As Label
    Private WithEvents PnAccess As Panel
    Private WithEvents CbxAccess As CheckBox
    Friend WithEvents CbxTip As ToolTip
End Class
