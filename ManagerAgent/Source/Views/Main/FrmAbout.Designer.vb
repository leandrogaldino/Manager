<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAbout
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
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.LblSection = New System.Windows.Forms.Label()
        Me.LblDocument = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblExpirationDate = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.Separator = New CoreSuite.Controls.Separator()
        Me.LblCloudBase = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.ForeColor = System.Drawing.Color.Gray
        Me.LblVersion.Location = New System.Drawing.Point(22, 55)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(85, 17)
        Me.LblVersion.TabIndex = 1
        Me.LblVersion.Text = "Versão 1.0.0"
        '
        'LblSection
        '
        Me.LblSection.AutoSize = True
        Me.LblSection.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblSection.Location = New System.Drawing.Point(20, 100)
        Me.LblSection.Name = "LblSection"
        Me.LblSection.Size = New System.Drawing.Size(186, 18)
        Me.LblSection.TabIndex = 3
        Me.LblSection.Text = "Informações de Registro"
        '
        'LblDocument
        '
        Me.LblDocument.AutoSize = True
        Me.LblDocument.Location = New System.Drawing.Point(25, 130)
        Me.LblDocument.Name = "LblDocument"
        Me.LblDocument.Size = New System.Drawing.Size(196, 17)
        Me.LblDocument.TabIndex = 4
        Me.LblDocument.Text = "Documento: 00.00.00/0000-00"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(25, 155)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(112, 17)
        Me.LblName.TabIndex = 5
        Me.LblName.Text = "Nome: Test Ltda"
        '
        'LblExpirationDate
        '
        Me.LblExpirationDate.AutoSize = True
        Me.LblExpirationDate.Location = New System.Drawing.Point(25, 180)
        Me.LblExpirationDate.Name = "LblExpirationDate"
        Me.LblExpirationDate.Size = New System.Drawing.Size(148, 17)
        Me.LblExpirationDate.TabIndex = 6
        Me.LblExpirationDate.Text = "Expiração: 01/01/2027"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Century Gothic", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitle.Location = New System.Drawing.Point(20, 20)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(233, 26)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Agente Gerenciador"
        '
        'Separator
        '
        Me.Separator.Location = New System.Drawing.Point(23, 77)
        Me.Separator.Margin = New System.Windows.Forms.Padding(0)
        Me.Separator.Name = "Separator"
        Me.Separator.Size = New System.Drawing.Size(426, 18)
        Me.Separator.TabIndex = 7
        Me.Separator.Text = "Separator1"
        '
        'LblCloudBase
        '
        Me.LblCloudBase.AutoSize = True
        Me.LblCloudBase.Location = New System.Drawing.Point(25, 205)
        Me.LblCloudBase.Name = "LblCloudBase"
        Me.LblCloudBase.Size = New System.Drawing.Size(198, 17)
        Me.LblCloudBase.TabIndex = 8
        Me.LblCloudBase.Text = "Base Cloud: manager-mobile"
        '
        'FrmAbout
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(475, 247)
        Me.Controls.Add(Me.LblCloudBase)
        Me.Controls.Add(Me.Separator)
        Me.Controls.Add(Me.LblTitle)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.LblSection)
        Me.Controls.Add(Me.LblDocument)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.LblExpirationDate)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAbout"
        Me.Text = "Sobre"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblVersion As Label
    Friend WithEvents LblSection As Label
    Friend WithEvents LblDocument As Label
    Friend WithEvents LblName As Label
    Friend WithEvents LblExpirationDate As Label
    Friend WithEvents LblTitle As Label
    Friend WithEvents Separator As CoreSuite.Controls.Separator
    Friend WithEvents LblCloudBase As Label
End Class
