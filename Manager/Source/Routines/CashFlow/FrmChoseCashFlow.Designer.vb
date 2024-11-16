<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChoseCashFlow
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnEnter = New System.Windows.Forms.Button()
        Me.DgvCashFlow = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvCashFlow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnBack)
        Me.Panel1.Controls.Add(Me.BtnEnter)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 217)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(384, 44)
        Me.Panel1.TabIndex = 6
        '
        'BtnBack
        '
        Me.BtnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnBack.Location = New System.Drawing.Point(280, 7)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(95, 30)
        Me.BtnBack.TabIndex = 1
        Me.BtnBack.Text = "Voltar"
        Me.BtnBack.UseVisualStyleBackColor = True
        '
        'BtnEnter
        '
        Me.BtnEnter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEnter.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnEnter.Location = New System.Drawing.Point(179, 7)
        Me.BtnEnter.Name = "BtnEnter"
        Me.BtnEnter.Size = New System.Drawing.Size(95, 30)
        Me.BtnEnter.TabIndex = 0
        Me.BtnEnter.Text = "Entrar"
        Me.BtnEnter.UseVisualStyleBackColor = True
        '
        'DgvCashFlow
        '
        Me.DgvCashFlow.AllowUserToAddRows = False
        Me.DgvCashFlow.AllowUserToDeleteRows = False
        Me.DgvCashFlow.AllowUserToResizeColumns = False
        Me.DgvCashFlow.AllowUserToResizeRows = False
        Me.DgvCashFlow.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DgvCashFlow.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCashFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCashFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCashFlow.Location = New System.Drawing.Point(0, 30)
        Me.DgvCashFlow.Name = "DgvCashFlow"
        Me.DgvCashFlow.ReadOnly = True
        Me.DgvCashFlow.RowHeadersVisible = False
        Me.DgvCashFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCashFlow.Size = New System.Drawing.Size(384, 187)
        Me.DgvCashFlow.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 30)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "ESCOLHA O FLUXO DE CAIXA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmChoseCashFlow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.Controls.Add(Me.DgvCashFlow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmChoseCashFlow"
        Me.ShowIcon = False
        Me.Text = "Fluxo de Caixa"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DgvCashFlow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnEnter As Button
    Friend WithEvents BtnBack As Button
    Friend WithEvents DgvCashFlow As DataGridView
    Friend WithEvents Label1 As Label
End Class
