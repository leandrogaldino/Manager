<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPersonCompressorImport
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
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DgvPartWorkedHour = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvPartElapsedDay = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(777, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnImport.Location = New System.Drawing.Point(676, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 517)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(884, 44)
        Me.Panel1.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvPartWorkedHour)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgvPartElapsedDay)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Size = New System.Drawing.Size(884, 517)
        Me.SplitContainer1.SplitterDistance = 254
        Me.SplitContainer1.TabIndex = 34
        '
        'DgvPartWorkedHour
        '
        Me.DgvPartWorkedHour.AllowUserToAddRows = False
        Me.DgvPartWorkedHour.AllowUserToDeleteRows = False
        Me.DgvPartWorkedHour.AllowUserToOrderColumns = True
        Me.DgvPartWorkedHour.AllowUserToResizeRows = False
        Me.DgvPartWorkedHour.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPartWorkedHour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPartWorkedHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartWorkedHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartWorkedHour.Location = New System.Drawing.Point(0, 26)
        Me.DgvPartWorkedHour.MultiSelect = False
        Me.DgvPartWorkedHour.Name = "DgvPartWorkedHour"
        Me.DgvPartWorkedHour.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartWorkedHour.RowHeadersVisible = False
        Me.DgvPartWorkedHour.RowTemplate.Height = 26
        Me.DgvPartWorkedHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartWorkedHour.Size = New System.Drawing.Size(884, 228)
        Me.DgvPartWorkedHour.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(884, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Por Hora Trabalhada"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DgvPartElapsedDay
        '
        Me.DgvPartElapsedDay.AllowUserToAddRows = False
        Me.DgvPartElapsedDay.AllowUserToDeleteRows = False
        Me.DgvPartElapsedDay.AllowUserToOrderColumns = True
        Me.DgvPartElapsedDay.AllowUserToResizeRows = False
        Me.DgvPartElapsedDay.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPartElapsedDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPartElapsedDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPartElapsedDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPartElapsedDay.Location = New System.Drawing.Point(0, 26)
        Me.DgvPartElapsedDay.MultiSelect = False
        Me.DgvPartElapsedDay.Name = "DgvPartElapsedDay"
        Me.DgvPartElapsedDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvPartElapsedDay.RowHeadersVisible = False
        Me.DgvPartElapsedDay.RowTemplate.Height = 26
        Me.DgvPartElapsedDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPartElapsedDay.Size = New System.Drawing.Size(884, 233)
        Me.DgvPartElapsedDay.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(884, 26)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Por Dia Corrido"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmPersonCompressorImport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPersonCompressorImport"
        Me.ShowIcon = False
        Me.Text = "Importar"
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvPartWorkedHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPartElapsedDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DgvPartWorkedHour As DataGridView
    Friend WithEvents DgvPartElapsedDay As DataGridView
End Class
