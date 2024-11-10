<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcBiStatePrivilegeItem
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TlpContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.PnPrivilege = New System.Windows.Forms.Panel()
        Me.LblPrivilege = New System.Windows.Forms.Label()
        Me.PnGrant = New System.Windows.Forms.Panel()
        Me.CbxGrant = New System.Windows.Forms.CheckBox()
        Me.CbxTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TlpContainer.SuspendLayout()
        Me.PnPrivilege.SuspendLayout()
        Me.PnGrant.SuspendLayout()
        Me.SuspendLayout()
        '
        'TlpContainer
        '
        Me.TlpContainer.ColumnCount = 2
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636!))
        Me.TlpContainer.Controls.Add(Me.PnPrivilege, 0, 0)
        Me.TlpContainer.Controls.Add(Me.PnGrant, 1, 0)
        Me.TlpContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TlpContainer.Location = New System.Drawing.Point(0, 0)
        Me.TlpContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.TlpContainer.Name = "TlpContainer"
        Me.TlpContainer.RowCount = 1
        Me.TlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpContainer.Size = New System.Drawing.Size(470, 30)
        Me.TlpContainer.TabIndex = 2
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
        Me.PnPrivilege.Size = New System.Drawing.Size(381, 30)
        Me.PnPrivilege.TabIndex = 11
        '
        'LblPrivilege
        '
        Me.LblPrivilege.BackColor = System.Drawing.Color.White
        Me.LblPrivilege.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblPrivilege.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrivilege.Location = New System.Drawing.Point(1, 0)
        Me.LblPrivilege.Name = "LblPrivilege"
        Me.LblPrivilege.Size = New System.Drawing.Size(379, 29)
        Me.LblPrivilege.TabIndex = 1
        Me.LblPrivilege.Text = "Privilege"
        Me.LblPrivilege.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnGrant
        '
        Me.PnGrant.BackColor = System.Drawing.Color.Gray
        Me.PnGrant.Controls.Add(Me.CbxGrant)
        Me.PnGrant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnGrant.Location = New System.Drawing.Point(381, 0)
        Me.PnGrant.Margin = New System.Windows.Forms.Padding(0)
        Me.PnGrant.Name = "PnGrant"
        Me.PnGrant.Padding = New System.Windows.Forms.Padding(0, 0, 1, 1)
        Me.PnGrant.Size = New System.Drawing.Size(89, 30)
        Me.PnGrant.TabIndex = 12
        '
        'CbxGrant
        '
        Me.CbxGrant.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxGrant.BackColor = System.Drawing.Color.White
        Me.CbxGrant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxGrant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxGrant.FlatAppearance.BorderSize = 0
        Me.CbxGrant.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.CbxGrant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.CbxGrant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.CbxGrant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxGrant.Image = Global.Manager.My.Resources.Resources.Reject
        Me.CbxGrant.Location = New System.Drawing.Point(0, 0)
        Me.CbxGrant.Margin = New System.Windows.Forms.Padding(0)
        Me.CbxGrant.Name = "CbxGrant"
        Me.CbxGrant.Size = New System.Drawing.Size(88, 29)
        Me.CbxGrant.TabIndex = 11
        Me.CbxGrant.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CbxGrant.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CbxTip.SetToolTip(Me.CbxGrant, "Conceder")
        Me.CbxGrant.UseVisualStyleBackColor = False
        '
        'UcBiStatePrivilegeItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TlpContainer)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UcBiStatePrivilegeItem"
        Me.Size = New System.Drawing.Size(470, 30)
        Me.TlpContainer.ResumeLayout(False)
        Me.PnPrivilege.ResumeLayout(False)
        Me.PnGrant.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents TlpContainer As TableLayoutPanel
    Private WithEvents PnPrivilege As Panel
    Private WithEvents LblPrivilege As Label
    Private WithEvents PnGrant As Panel
    Private WithEvents CbxGrant As CheckBox
    Friend WithEvents CbxTip As ToolTip

End Class
