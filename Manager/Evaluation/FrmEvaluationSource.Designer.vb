<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEvaluationSource
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnAccept = New System.Windows.Forms.Button()
        Me.LblCompressor = New System.Windows.Forms.Label()
        Me.FlpContainer = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Controls.Add(Me.BtnAccept)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 253)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(494, 44)
        Me.Panel1.TabIndex = 4
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(387, 7)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(95, 30)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancelar"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnAccept
        '
        Me.BtnAccept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAccept.Enabled = False
        Me.BtnAccept.Location = New System.Drawing.Point(286, 7)
        Me.BtnAccept.Name = "BtnAccept"
        Me.BtnAccept.Size = New System.Drawing.Size(95, 30)
        Me.BtnAccept.TabIndex = 1
        Me.BtnAccept.Text = "Aceitar"
        Me.BtnAccept.UseVisualStyleBackColor = True
        '
        'LblCompressor
        '
        Me.LblCompressor.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblCompressor.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblCompressor.ForeColor = System.Drawing.Color.White
        Me.LblCompressor.Location = New System.Drawing.Point(0, 0)
        Me.LblCompressor.Name = "LblCompressor"
        Me.LblCompressor.Size = New System.Drawing.Size(494, 26)
        Me.LblCompressor.TabIndex = 5
        Me.LblCompressor.Text = "Escolha qual leitura você quer considerar"
        Me.LblCompressor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlpContainer
        '
        Me.FlpContainer.AutoScroll = True
        Me.FlpContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlpContainer.Location = New System.Drawing.Point(12, 29)
        Me.FlpContainer.Name = "FlpContainer"
        Me.FlpContainer.Size = New System.Drawing.Size(470, 216)
        Me.FlpContainer.TabIndex = 6
        '
        'FrmEvaluationSource
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(494, 297)
        Me.Controls.Add(Me.FlpContainer)
        Me.Controls.Add(Me.LblCompressor)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvaluationSource"
        Me.ShowIcon = False
        Me.Text = "Leitura da Avaliação"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnAccept As Button
    Friend WithEvents LblCompressor As Label
    Friend WithEvents FlpContainer As FlowLayoutPanel
End Class
