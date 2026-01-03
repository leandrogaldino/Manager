<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBackup
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
        Me.PnButtons = New System.Windows.Forms.Panel()
        Me.BtnTestAndOK = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnBackupDays = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtBackupLocation = New System.Windows.Forms.TextBox()
        Me.BtnBackupLocation = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CbxIgnoreNext = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LblBackupKeep = New System.Windows.Forms.Label()
        Me.DbxBackupKeep = New CoreSuite.Controls.DecimalBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LblBackupTime = New System.Windows.Forms.Label()
        Me.TxtBackupTime = New System.Windows.Forms.MaskedTextBox()
        Me.PnButtons.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnButtons
        '
        Me.PnButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnButtons.Controls.Add(Me.BtnTestAndOK)
        Me.PnButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnButtons.Location = New System.Drawing.Point(0, 245)
        Me.PnButtons.Name = "PnButtons"
        Me.PnButtons.Size = New System.Drawing.Size(475, 36)
        Me.PnButtons.TabIndex = 5
        '
        'BtnTestAndOK
        '
        Me.BtnTestAndOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTestAndOK.Enabled = False
        Me.BtnTestAndOK.Location = New System.Drawing.Point(368, 3)
        Me.BtnTestAndOK.Name = "BtnTestAndOK"
        Me.BtnTestAndOK.Size = New System.Drawing.Size(95, 30)
        Me.BtnTestAndOK.TabIndex = 0
        Me.BtnTestAndOK.Text = "OK"
        Me.BtnTestAndOK.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnBackupDays)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(12, 19)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(450, 31)
        Me.Panel3.TabIndex = 38
        '
        'BtnBackupDays
        '
        Me.BtnBackupDays.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBackupDays.Location = New System.Drawing.Point(241, 3)
        Me.BtnBackupDays.Name = "BtnBackupDays"
        Me.BtnBackupDays.Size = New System.Drawing.Size(203, 23)
        Me.BtnBackupDays.TabIndex = 29
        Me.BtnBackupDays.Text = "Seg, Ter, Qua, Qui, Sex, Sáb, Dom"
        Me.BtnBackupDays.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(4, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 29)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Dias de backup"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TxtBackupLocation)
        Me.Panel2.Controls.Add(Me.BtnBackupLocation)
        Me.Panel2.Location = New System.Drawing.Point(12, 195)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(450, 31)
        Me.Panel2.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Location = New System.Drawing.Point(4, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 29)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Local"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBackupLocation
        '
        Me.TxtBackupLocation.Location = New System.Drawing.Point(84, 3)
        Me.TxtBackupLocation.Name = "TxtBackupLocation"
        Me.TxtBackupLocation.ReadOnly = True
        Me.TxtBackupLocation.Size = New System.Drawing.Size(327, 23)
        Me.TxtBackupLocation.TabIndex = 1
        '
        'BtnBackupLocation
        '
        Me.BtnBackupLocation.Location = New System.Drawing.Point(417, 3)
        Me.BtnBackupLocation.Name = "BtnBackupLocation"
        Me.BtnBackupLocation.Size = New System.Drawing.Size(28, 23)
        Me.BtnBackupLocation.TabIndex = 2
        Me.BtnBackupLocation.Text = "..."
        Me.BtnBackupLocation.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CbxIgnoreNext)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 151)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(450, 31)
        Me.Panel1.TabIndex = 36
        '
        'CbxIgnoreNext
        '
        Me.CbxIgnoreNext.Appearance = System.Windows.Forms.Appearance.Button
        Me.CbxIgnoreNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbxIgnoreNext.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxIgnoreNext.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CbxIgnoreNext.Location = New System.Drawing.Point(241, 3)
        Me.CbxIgnoreNext.Name = "CbxIgnoreNext"
        Me.CbxIgnoreNext.Size = New System.Drawing.Size(204, 23)
        Me.CbxIgnoreNext.TabIndex = 3
        Me.CbxIgnoreNext.Text = "Não"
        Me.CbxIgnoreNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CbxIgnoreNext.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(4, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 29)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ignorar próximo backup"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.LblBackupKeep)
        Me.Panel6.Controls.Add(Me.DbxBackupKeep)
        Me.Panel6.Location = New System.Drawing.Point(12, 107)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel6.Size = New System.Drawing.Size(450, 31)
        Me.Panel6.TabIndex = 35
        '
        'LblBackupKeep
        '
        Me.LblBackupKeep.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblBackupKeep.Location = New System.Drawing.Point(4, 0)
        Me.LblBackupKeep.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBackupKeep.Name = "LblBackupKeep"
        Me.LblBackupKeep.Size = New System.Drawing.Size(230, 29)
        Me.LblBackupKeep.TabIndex = 0
        Me.LblBackupKeep.Text = "Qtd. mantida"
        Me.LblBackupKeep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DbxBackupKeep
        '
        Me.DbxBackupKeep.DecimalOnly = True
        Me.DbxBackupKeep.DecimalPlaces = 0
        Me.DbxBackupKeep.IncludeThousandSeparator = Microsoft.VisualBasic.TriState.[True]
        Me.DbxBackupKeep.Location = New System.Drawing.Point(241, 3)
        Me.DbxBackupKeep.Name = "DbxBackupKeep"
        Me.DbxBackupKeep.Size = New System.Drawing.Size(204, 23)
        Me.DbxBackupKeep.TabIndex = 1
        Me.DbxBackupKeep.Text = "0"
        Me.DbxBackupKeep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.LblBackupTime)
        Me.Panel5.Controls.Add(Me.TxtBackupTime)
        Me.Panel5.Location = New System.Drawing.Point(12, 63)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Panel5.Size = New System.Drawing.Size(450, 31)
        Me.Panel5.TabIndex = 34
        '
        'LblBackupTime
        '
        Me.LblBackupTime.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblBackupTime.Location = New System.Drawing.Point(4, 0)
        Me.LblBackupTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBackupTime.Name = "LblBackupTime"
        Me.LblBackupTime.Size = New System.Drawing.Size(230, 29)
        Me.LblBackupTime.TabIndex = 0
        Me.LblBackupTime.Text = "Horário"
        Me.LblBackupTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBackupTime
        '
        Me.TxtBackupTime.Location = New System.Drawing.Point(241, 3)
        Me.TxtBackupTime.Mask = "00:00:00"
        Me.TxtBackupTime.Name = "TxtBackupTime"
        Me.TxtBackupTime.Size = New System.Drawing.Size(204, 23)
        Me.TxtBackupTime.TabIndex = 1
        Me.TxtBackupTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtBackupTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.TxtBackupTime.ValidatingType = GetType(Date)
        '
        'FrmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(475, 281)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.PnButtons)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBackup"
        Me.Text = "Backup"
        Me.PnButtons.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnButtons As Panel
    Friend WithEvents BtnTestAndOK As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnBackupDays As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtBackupLocation As TextBox
    Friend WithEvents BtnBackupLocation As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CbxIgnoreNext As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents LblBackupKeep As Label
    Friend WithEvents DbxBackupKeep As CoreSuite.Controls.DecimalBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblBackupTime As Label
    Friend WithEvents TxtBackupTime As MaskedTextBox
End Class
