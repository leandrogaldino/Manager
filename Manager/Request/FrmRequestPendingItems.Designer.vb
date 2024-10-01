<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRequestPendingItems
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRequestPendingItems))
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.EprValidation = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CbxShowResponsible = New System.Windows.Forms.CheckBox()
        Me.DbxFinalDate = New ControlLibrary.DateBox()
        Me.DbxInitialDate = New ControlLibrary.DateBox()
        Me.LblFinalDate = New System.Windows.Forms.Label()
        Me.LblInitialDate = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.CbxShowDestination = New System.Windows.Forms.CheckBox()
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(181, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'EprValidation
        '
        Me.EprValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.EprValidation.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbxShowResponsible)
        Me.GroupBox1.Controls.Add(Me.DbxFinalDate)
        Me.GroupBox1.Controls.Add(Me.DbxInitialDate)
        Me.GroupBox1.Controls.Add(Me.LblFinalDate)
        Me.GroupBox1.Controls.Add(Me.LblInitialDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 132)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções"
        '
        'CbxShowResponsible
        '
        Me.CbxShowResponsible.AutoSize = True
        Me.CbxShowResponsible.Location = New System.Drawing.Point(9, 78)
        Me.CbxShowResponsible.Name = "CbxShowResponsible"
        Me.CbxShowResponsible.Size = New System.Drawing.Size(158, 21)
        Me.CbxShowResponsible.TabIndex = 4
        Me.CbxShowResponsible.Text = "Mostrar Responsável"
        Me.CbxShowResponsible.UseVisualStyleBackColor = True
        '
        'DbxFinalDate
        '
        Me.DbxFinalDate.ButtonImage = CType(resources.GetObject("DbxFinalDate.ButtonImage"), System.Drawing.Image)
        Me.DbxFinalDate.Location = New System.Drawing.Point(136, 49)
        Me.DbxFinalDate.Name = "DbxFinalDate"
        Me.DbxFinalDate.Size = New System.Drawing.Size(121, 23)
        Me.DbxFinalDate.TabIndex = 3
        '
        'DbxInitialDate
        '
        Me.DbxInitialDate.ButtonImage = CType(resources.GetObject("DbxInitialDate.ButtonImage"), System.Drawing.Image)
        Me.DbxInitialDate.Location = New System.Drawing.Point(9, 49)
        Me.DbxInitialDate.Name = "DbxInitialDate"
        Me.DbxInitialDate.Size = New System.Drawing.Size(121, 23)
        Me.DbxInitialDate.TabIndex = 1
        '
        'LblFinalDate
        '
        Me.LblFinalDate.AutoSize = True
        Me.LblFinalDate.Location = New System.Drawing.Point(133, 29)
        Me.LblFinalDate.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.LblFinalDate.Name = "LblFinalDate"
        Me.LblFinalDate.Size = New System.Drawing.Size(74, 17)
        Me.LblFinalDate.TabIndex = 2
        Me.LblFinalDate.Text = "Data Final"
        Me.LblFinalDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblInitialDate
        '
        Me.LblInitialDate.AutoSize = True
        Me.LblInitialDate.Location = New System.Drawing.Point(6, 29)
        Me.LblInitialDate.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.LblInitialDate.Name = "LblInitialDate"
        Me.LblInitialDate.Size = New System.Drawing.Size(82, 17)
        Me.LblInitialDate.TabIndex = 0
        Me.LblInitialDate.Text = "Data Inicial"
        Me.LblInitialDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnGenerate)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 156)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 44)
        Me.Panel1.TabIndex = 2
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Enabled = False
        Me.BtnGenerate.Location = New System.Drawing.Point(80, 7)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(95, 30)
        Me.BtnGenerate.TabIndex = 0
        Me.BtnGenerate.Text = "Gerar"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'CbxShowDestination
        '
        Me.CbxShowDestination.AutoSize = True
        Me.CbxShowDestination.Location = New System.Drawing.Point(21, 117)
        Me.CbxShowDestination.Name = "CbxShowDestination"
        Me.CbxShowDestination.Size = New System.Drawing.Size(126, 21)
        Me.CbxShowDestination.TabIndex = 1
        Me.CbxShowDestination.Text = "Mostrar Destino"
        Me.CbxShowDestination.UseVisualStyleBackColor = True
        '
        'FrmRequestPendingItems
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(288, 200)
        Me.Controls.Add(Me.CbxShowDestination)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRequestPendingItems"
        Me.ShowIcon = False
        Me.Text = "Requisição - Peças Pendentes"
        CType(Me.EprValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EprValidation As ErrorProvider
    Friend WithEvents BtnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DbxFinalDate As ControlLibrary.DateBox
    Friend WithEvents DbxInitialDate As ControlLibrary.DateBox
    Friend WithEvents LblFinalDate As Label
    Friend WithEvents LblInitialDate As Label
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents CbxShowDestination As CheckBox
    Friend WithEvents CbxShowResponsible As CheckBox
End Class
