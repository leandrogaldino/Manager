﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcEvaluationSourceTile
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
        Me.PnItem2 = New System.Windows.Forms.Panel()
        Me.CbxItem2 = New System.Windows.Forms.CheckBox()
        Me.PnTitle = New System.Windows.Forms.Panel()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnItem1 = New System.Windows.Forms.Panel()
        Me.CbxItem1 = New System.Windows.Forms.CheckBox()
        Me.TlpContainer.SuspendLayout()
        Me.PnItem2.SuspendLayout()
        Me.PnTitle.SuspendLayout()
        Me.PnItem1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TlpContainer
        '
        Me.TlpContainer.ColumnCount = 3
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpContainer.Controls.Add(Me.PnItem2, 2, 0)
        Me.TlpContainer.Controls.Add(Me.PnTitle, 0, 0)
        Me.TlpContainer.Controls.Add(Me.PnItem1, 1, 0)
        Me.TlpContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TlpContainer.Location = New System.Drawing.Point(0, 0)
        Me.TlpContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.TlpContainer.Name = "TlpContainer"
        Me.TlpContainer.RowCount = 1
        Me.TlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpContainer.Size = New System.Drawing.Size(450, 30)
        Me.TlpContainer.TabIndex = 1
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
        Me.PnItem2.Size = New System.Drawing.Size(90, 30)
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
        Me.CbxItem2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.CbxItem2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxItem2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxItem2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CbxItem2.Location = New System.Drawing.Point(0, 1)
        Me.CbxItem2.Name = "CbxItem2"
        Me.CbxItem2.Size = New System.Drawing.Size(89, 28)
        Me.CbxItem2.TabIndex = 2
        Me.CbxItem2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CbxItem2.UseVisualStyleBackColor = False
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
        Me.PnTitle.Size = New System.Drawing.Size(270, 30)
        Me.PnTitle.TabIndex = 1
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.White
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTitle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(1, 1)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(268, 28)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PnItem1.Size = New System.Drawing.Size(90, 30)
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
        Me.CbxItem1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro
        Me.CbxItem1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxItem1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CbxItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CbxItem1.Location = New System.Drawing.Point(0, 1)
        Me.CbxItem1.Name = "CbxItem1"
        Me.CbxItem1.Size = New System.Drawing.Size(89, 28)
        Me.CbxItem1.TabIndex = 2
        Me.CbxItem1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CbxItem1.UseVisualStyleBackColor = False
        '
        'UcEvaluationSourceTile
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TlpContainer)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UcEvaluationSourceTile"
        Me.Size = New System.Drawing.Size(450, 30)
        Me.TlpContainer.ResumeLayout(False)
        Me.PnItem2.ResumeLayout(False)
        Me.PnItem2.PerformLayout()
        Me.PnTitle.ResumeLayout(False)
        Me.PnItem1.ResumeLayout(False)
        Me.PnItem1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents TlpContainer As TableLayoutPanel
    Private WithEvents PnItem2 As Panel
    Private WithEvents PnTitle As Panel
    Private WithEvents PnItem1 As Panel
    Private WithEvents CbxItem2 As CheckBox
    Private WithEvents LblTitle As Label
    Private WithEvents CbxItem1 As CheckBox
End Class
