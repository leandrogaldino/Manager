<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcEvaluationSoldLost
    Inherits System.Windows.Forms.UserControl

    'O UserControl substitui o descarte para limpar a lista de componentes.
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
        Me.CbxSold = New System.Windows.Forms.CheckBox()
        Me.CbxLost = New System.Windows.Forms.CheckBox()
        Me.CbxNA = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbxSold
        '
        Me.CbxSold.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxSold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxSold.FlatAppearance.BorderSize = 0
        Me.CbxSold.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.CbxSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxSold.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxSold.Location = New System.Drawing.Point(0, 0)
        Me.CbxSold.Margin = New System.Windows.Forms.Padding(0)
        Me.CbxSold.Name = "CbxSold"
        Me.CbxSold.Size = New System.Drawing.Size(79, 50)
        Me.CbxSold.TabIndex = 0
        Me.CbxSold.Text = "Vendido"
        Me.CbxSold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxSold.UseVisualStyleBackColor = True
        '
        'CbxLost
        '
        Me.CbxLost.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxLost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxLost.FlatAppearance.BorderSize = 0
        Me.CbxLost.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.CbxLost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxLost.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxLost.Location = New System.Drawing.Point(79, 0)
        Me.CbxLost.Margin = New System.Windows.Forms.Padding(0)
        Me.CbxLost.Name = "CbxLost"
        Me.CbxLost.Size = New System.Drawing.Size(81, 50)
        Me.CbxLost.TabIndex = 0
        Me.CbxLost.Text = "Perdido"
        Me.CbxLost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxLost.UseVisualStyleBackColor = True
        '
        'CbxNA
        '
        Me.CbxNA.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxNA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxNA.FlatAppearance.BorderSize = 0
        Me.CbxNA.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.CbxNA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxNA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxNA.Location = New System.Drawing.Point(160, 0)
        Me.CbxNA.Margin = New System.Windows.Forms.Padding(0)
        Me.CbxNA.Name = "CbxNA"
        Me.CbxNA.Size = New System.Drawing.Size(80, 50)
        Me.CbxNA.TabIndex = 1
        Me.CbxNA.Text = "N/A"
        Me.CbxNA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxNA.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CbxSold, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CbxNA, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CbxLost, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(240, 50)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'UcEvaluationSoldLost
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UcEvaluationSoldLost"
        Me.Size = New System.Drawing.Size(240, 50)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents CbxSold As CheckBox
    Private WithEvents CbxLost As CheckBox
    Private WithEvents CbxNA As CheckBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
