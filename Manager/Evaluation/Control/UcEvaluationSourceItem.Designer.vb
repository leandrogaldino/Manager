<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcEvaluationSourceItem
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
        Me.PnItem1 = New System.Windows.Forms.Panel()
        Me.CbxItem1 = New System.Windows.Forms.CheckBox()
        Me.PnTitle = New System.Windows.Forms.Panel()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnItem2 = New System.Windows.Forms.Panel()
        Me.CbxItem2 = New System.Windows.Forms.CheckBox()
        Me.TlpContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.PnSoldLost = New System.Windows.Forms.Panel()
        Me.CcSoldLost = New ControlLibrary.ControlContainer()
        Me.BtnSoldLost = New System.Windows.Forms.Button()
        Me.PnItem1.SuspendLayout()
        Me.PnTitle.SuspendLayout()
        Me.PnItem2.SuspendLayout()
        Me.TlpContainer.SuspendLayout()
        Me.PnSoldLost.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnItem1
        '
        Me.PnItem1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnItem1.Controls.Add(Me.CbxItem1)
        Me.PnItem1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnItem1.Location = New System.Drawing.Point(270, 0)
        Me.PnItem1.Margin = New System.Windows.Forms.Padding(0)
        Me.PnItem1.Name = "PnItem1"
        Me.PnItem1.Padding = New System.Windows.Forms.Padding(0, 1, 1, 1)
        Me.PnItem1.Size = New System.Drawing.Size(90, 26)
        Me.PnItem1.TabIndex = 1
        '
        'CbxItem1
        '
        Me.CbxItem1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxItem1.AutoSize = True
        Me.CbxItem1.BackColor = System.Drawing.Color.White
        Me.CbxItem1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxItem1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxItem1.FlatAppearance.BorderSize = 0
        Me.CbxItem1.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.CbxItem1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxItem1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CbxItem1.Location = New System.Drawing.Point(0, 1)
        Me.CbxItem1.Name = "CbxItem1"
        Me.CbxItem1.Size = New System.Drawing.Size(89, 24)
        Me.CbxItem1.TabIndex = 2
        Me.CbxItem1.Text = "1500"
        Me.CbxItem1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CbxItem1.UseVisualStyleBackColor = False
        '
        'PnTitle
        '
        Me.PnTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnTitle.Controls.Add(Me.LblTitle)
        Me.PnTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnTitle.Location = New System.Drawing.Point(0, 0)
        Me.PnTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.PnTitle.Name = "PnTitle"
        Me.PnTitle.Padding = New System.Windows.Forms.Padding(1)
        Me.TlpContainer.SetRowSpan(Me.PnTitle, 2)
        Me.PnTitle.Size = New System.Drawing.Size(270, 48)
        Me.PnTitle.TabIndex = 1
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.White
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(1, 1)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(268, 46)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.Text = "Filtro de ar"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnItem2
        '
        Me.PnItem2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnItem2.Controls.Add(Me.CbxItem2)
        Me.PnItem2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnItem2.Location = New System.Drawing.Point(360, 0)
        Me.PnItem2.Margin = New System.Windows.Forms.Padding(0)
        Me.PnItem2.Name = "PnItem2"
        Me.PnItem2.Padding = New System.Windows.Forms.Padding(0, 1, 1, 1)
        Me.PnItem2.Size = New System.Drawing.Size(90, 26)
        Me.PnItem2.TabIndex = 1
        '
        'CbxItem2
        '
        Me.CbxItem2.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxItem2.AutoSize = True
        Me.CbxItem2.BackColor = System.Drawing.Color.White
        Me.CbxItem2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxItem2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbxItem2.FlatAppearance.BorderSize = 0
        Me.CbxItem2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke
        Me.CbxItem2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxItem2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxItem2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CbxItem2.Location = New System.Drawing.Point(0, 1)
        Me.CbxItem2.Name = "CbxItem2"
        Me.CbxItem2.Size = New System.Drawing.Size(89, 24)
        Me.CbxItem2.TabIndex = 2
        Me.CbxItem2.Text = "1550"
        Me.CbxItem2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CbxItem2.UseVisualStyleBackColor = False
        '
        'TlpContainer
        '
        Me.TlpContainer.ColumnCount = 3
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpContainer.Controls.Add(Me.PnSoldLost, 0, 1)
        Me.TlpContainer.Controls.Add(Me.PnItem2, 2, 0)
        Me.TlpContainer.Controls.Add(Me.PnTitle, 0, 0)
        Me.TlpContainer.Controls.Add(Me.PnItem1, 1, 0)
        Me.TlpContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TlpContainer.Location = New System.Drawing.Point(0, 0)
        Me.TlpContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.TlpContainer.Name = "TlpContainer"
        Me.TlpContainer.RowCount = 2
        Me.TlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.TlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TlpContainer.Size = New System.Drawing.Size(450, 48)
        Me.TlpContainer.TabIndex = 1
        '
        'PnSoldLost
        '
        Me.PnSoldLost.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TlpContainer.SetColumnSpan(Me.PnSoldLost, 2)
        Me.PnSoldLost.Controls.Add(Me.BtnSoldLost)
        Me.PnSoldLost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnSoldLost.Location = New System.Drawing.Point(270, 26)
        Me.PnSoldLost.Margin = New System.Windows.Forms.Padding(0)
        Me.PnSoldLost.Name = "PnSoldLost"
        Me.PnSoldLost.Padding = New System.Windows.Forms.Padding(0, 0, 1, 1)
        Me.PnSoldLost.Size = New System.Drawing.Size(180, 22)
        Me.PnSoldLost.TabIndex = 2
        '
        'CcSoldLost
        '
        Me.CcSoldLost.DropDownBorderColor = System.Drawing.SystemColors.HotTrack
        Me.CcSoldLost.DropDownControl = Nothing
        Me.CcSoldLost.DropDownEnabled = True
        Me.CcSoldLost.HostControl = Me.BtnSoldLost
        '
        'BtnSoldLost
        '
        Me.BtnSoldLost.BackColor = System.Drawing.Color.White
        Me.BtnSoldLost.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSoldLost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnSoldLost.FlatAppearance.BorderSize = 0
        Me.BtnSoldLost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSoldLost.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSoldLost.Location = New System.Drawing.Point(0, 0)
        Me.BtnSoldLost.Name = "BtnSoldLost"
        Me.BtnSoldLost.Size = New System.Drawing.Size(179, 21)
        Me.BtnSoldLost.TabIndex = 0
        Me.BtnSoldLost.Text = "Troca?"
        Me.BtnSoldLost.UseVisualStyleBackColor = False
        '
        'UcEvaluationSourceItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TlpContainer)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UcEvaluationSourceItem"
        Me.Size = New System.Drawing.Size(450, 48)
        Me.PnItem1.ResumeLayout(False)
        Me.PnItem1.PerformLayout()
        Me.PnTitle.ResumeLayout(False)
        Me.PnItem2.ResumeLayout(False)
        Me.PnItem2.PerformLayout()
        Me.TlpContainer.ResumeLayout(False)
        Me.PnSoldLost.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents PnItem1 As Panel
    Private WithEvents CbxItem1 As CheckBox
    Private WithEvents PnTitle As Panel
    Private WithEvents LblTitle As Label
    Private WithEvents PnItem2 As Panel
    Private WithEvents CbxItem2 As CheckBox
    Private WithEvents TlpContainer As TableLayoutPanel
    Private WithEvents PnSoldLost As Panel
    Friend WithEvents CcSoldLost As ControlLibrary.ControlContainer
    Friend WithEvents BtnSoldLost As Button
End Class
