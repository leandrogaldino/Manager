<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcTriStatePrivilegeTitle
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
        Me.TlpContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.PnDelete = New System.Windows.Forms.Panel()
        Me.LblDelete = New System.Windows.Forms.Label()
        Me.PnWrite = New System.Windows.Forms.Panel()
        Me.LblWrite = New System.Windows.Forms.Label()
        Me.PnPrivilege = New System.Windows.Forms.Panel()
        Me.LblPrivilege = New System.Windows.Forms.Label()
        Me.PnAccess = New System.Windows.Forms.Panel()
        Me.LblAccess = New System.Windows.Forms.Label()
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
        Me.PnDelete.Controls.Add(Me.LblDelete)
        Me.PnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnDelete.Location = New System.Drawing.Point(405, 0)
        Me.PnDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.PnDelete.Name = "PnDelete"
        Me.PnDelete.Padding = New System.Windows.Forms.Padding(0, 1, 1, 1)
        Me.PnDelete.Size = New System.Drawing.Size(65, 30)
        Me.PnDelete.TabIndex = 14
        '
        'LblDelete
        '
        Me.LblDelete.BackColor = System.Drawing.Color.Silver
        Me.LblDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblDelete.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDelete.Location = New System.Drawing.Point(0, 1)
        Me.LblDelete.Name = "LblDelete"
        Me.LblDelete.Size = New System.Drawing.Size(64, 28)
        Me.LblDelete.TabIndex = 2
        Me.LblDelete.Text = "Deletar"
        Me.LblDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnWrite
        '
        Me.PnWrite.BackColor = System.Drawing.Color.Gray
        Me.PnWrite.Controls.Add(Me.LblWrite)
        Me.PnWrite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnWrite.Location = New System.Drawing.Point(341, 0)
        Me.PnWrite.Margin = New System.Windows.Forms.Padding(0)
        Me.PnWrite.Name = "PnWrite"
        Me.PnWrite.Padding = New System.Windows.Forms.Padding(0, 1, 1, 1)
        Me.PnWrite.Size = New System.Drawing.Size(64, 30)
        Me.PnWrite.TabIndex = 13
        '
        'LblWrite
        '
        Me.LblWrite.BackColor = System.Drawing.Color.Silver
        Me.LblWrite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblWrite.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWrite.Location = New System.Drawing.Point(0, 1)
        Me.LblWrite.Name = "LblWrite"
        Me.LblWrite.Size = New System.Drawing.Size(63, 28)
        Me.LblWrite.TabIndex = 2
        Me.LblWrite.Text = "Escrever"
        Me.LblWrite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnPrivilege
        '
        Me.PnPrivilege.BackColor = System.Drawing.Color.Gray
        Me.PnPrivilege.Controls.Add(Me.LblPrivilege)
        Me.PnPrivilege.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnPrivilege.Location = New System.Drawing.Point(0, 0)
        Me.PnPrivilege.Margin = New System.Windows.Forms.Padding(0)
        Me.PnPrivilege.Name = "PnPrivilege"
        Me.PnPrivilege.Padding = New System.Windows.Forms.Padding(1)
        Me.PnPrivilege.Size = New System.Drawing.Size(277, 30)
        Me.PnPrivilege.TabIndex = 11
        '
        'LblPrivilege
        '
        Me.LblPrivilege.BackColor = System.Drawing.Color.Silver
        Me.LblPrivilege.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblPrivilege.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrivilege.Location = New System.Drawing.Point(1, 1)
        Me.LblPrivilege.Name = "LblPrivilege"
        Me.LblPrivilege.Size = New System.Drawing.Size(275, 28)
        Me.LblPrivilege.TabIndex = 1
        Me.LblPrivilege.Text = "Permissão"
        Me.LblPrivilege.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnAccess
        '
        Me.PnAccess.BackColor = System.Drawing.Color.Gray
        Me.PnAccess.Controls.Add(Me.LblAccess)
        Me.PnAccess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnAccess.Location = New System.Drawing.Point(277, 0)
        Me.PnAccess.Margin = New System.Windows.Forms.Padding(0)
        Me.PnAccess.Name = "PnAccess"
        Me.PnAccess.Padding = New System.Windows.Forms.Padding(0, 1, 1, 1)
        Me.PnAccess.Size = New System.Drawing.Size(64, 30)
        Me.PnAccess.TabIndex = 12
        '
        'LblAccess
        '
        Me.LblAccess.BackColor = System.Drawing.Color.Silver
        Me.LblAccess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblAccess.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAccess.Location = New System.Drawing.Point(0, 1)
        Me.LblAccess.Name = "LblAccess"
        Me.LblAccess.Size = New System.Drawing.Size(63, 28)
        Me.LblAccess.TabIndex = 2
        Me.LblAccess.Text = "Acessar"
        Me.LblAccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcTriStatePrivilegeTitle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TlpContainer)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UcTriStatePrivilegeTitle"
        Me.Size = New System.Drawing.Size(470, 30)
        Me.TlpContainer.ResumeLayout(False)
        Me.PnDelete.ResumeLayout(False)
        Me.PnWrite.ResumeLayout(False)
        Me.PnPrivilege.ResumeLayout(False)
        Me.PnAccess.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents LblDelete As Label
    Private WithEvents LblWrite As Label
    Private WithEvents LblPrivilege As Label
    Private WithEvents LblAccess As Label
    Private WithEvents PnDelete As Panel
    Private WithEvents PnAccess As Panel
    Private WithEvents PnWrite As Panel
    Private WithEvents TlpContainer As TableLayoutPanel
    Private WithEvents PnPrivilege As Panel
End Class
