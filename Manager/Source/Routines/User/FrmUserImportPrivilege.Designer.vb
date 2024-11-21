<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUserImportPrivilege
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
        Me.components = New System.ComponentModel.Container()
        Dim Condition1 As ControlLibrary.QueriedBox.Condition = New ControlLibrary.QueriedBox.Condition()
        Dim Parameter1 As ControlLibrary.QueriedBox.Parameter = New ControlLibrary.QueriedBox.Parameter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.QbxPreset = New ControlLibrary.QueriedBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TmrQueriedBox = New System.Windows.Forms.Timer(Me.components)
        Me.FlpPrivilegePreset = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnFilter = New ControlLibrary.NoFocusCueButton()
        Me.BtnView = New ControlLibrary.NoFocusCueButton()
        Me.BtnNew = New ControlLibrary.NoFocusCueButton()
        Me.Panel1.SuspendLayout()
        Me.FlpPrivilegePreset.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.BtnImport)
        Me.Panel1.Controls.Add(Me.BtnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 44)
        Me.Panel1.TabIndex = 3
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Enabled = False
        Me.BtnImport.Location = New System.Drawing.Point(100, 7)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(95, 30)
        Me.BtnImport.TabIndex = 0
        Me.BtnImport.Text = "Importar"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(201, 7)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 30)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Fechar"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'QbxPreset
        '
        Me.QbxPreset.CharactersToQuery = 1
        Condition1.FieldName = "statusid"
        Condition1.Operator = "="
        Condition1.TableNameOrAlias = "privilegepreset"
        Condition1.Value = "@statusid"
        Me.QbxPreset.Conditions.Add(Condition1)
        Me.QbxPreset.DebugOnTextChanged = False
        Me.QbxPreset.DisplayFieldAlias = "Nome"
        Me.QbxPreset.DisplayFieldName = "name"
        Me.QbxPreset.DisplayMainFieldName = "id"
        Me.QbxPreset.DisplayTableAlias = Nothing
        Me.QbxPreset.DisplayTableName = "privilegepreset"
        Me.QbxPreset.Distinct = False
        Me.QbxPreset.DropDownAutoStretchRight = False
        Me.QbxPreset.GridHeaderBackColor = System.Drawing.SystemColors.Window
        Me.QbxPreset.IfNull = Nothing
        Me.QbxPreset.Location = New System.Drawing.Point(12, 29)
        Me.QbxPreset.MainReturnFieldName = "id"
        Me.QbxPreset.MainTableAlias = Nothing
        Me.QbxPreset.MainTableName = "privilegepreset"
        Me.QbxPreset.Name = "QbxPreset"
        Parameter1.ParameterName = "@statusid"
        Parameter1.ParameterValue = "0"
        Me.QbxPreset.Parameters.Add(Parameter1)
        Me.QbxPreset.Prefix = Nothing
        Me.QbxPreset.Size = New System.Drawing.Size(290, 23)
        Me.QbxPreset.Suffix = Nothing
        Me.QbxPreset.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Predefinição"
        '
        'TmrQueriedBox
        '
        Me.TmrQueriedBox.Enabled = True
        Me.TmrQueriedBox.Interval = 300
        '
        'FlpPrivilegePreset
        '
        Me.FlpPrivilegePreset.Controls.Add(Me.BtnFilter)
        Me.FlpPrivilegePreset.Controls.Add(Me.BtnView)
        Me.FlpPrivilegePreset.Controls.Add(Me.BtnNew)
        Me.FlpPrivilegePreset.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlpPrivilegePreset.Location = New System.Drawing.Point(233, 8)
        Me.FlpPrivilegePreset.Name = "FlpPrivilegePreset"
        Me.FlpPrivilegePreset.Size = New System.Drawing.Size(69, 21)
        Me.FlpPrivilegePreset.TabIndex = 2
        '
        'BtnFilter
        '
        Me.BtnFilter.BackColor = System.Drawing.Color.Transparent
        Me.BtnFilter.BackgroundImage = Global.Manager.My.Resources.Resources.Magnifier
        Me.BtnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnFilter.FlatAppearance.BorderSize = 0
        Me.BtnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFilter.Location = New System.Drawing.Point(49, 3)
        Me.BtnFilter.Name = "BtnFilter"
        Me.BtnFilter.Size = New System.Drawing.Size(17, 17)
        Me.BtnFilter.TabIndex = 2
        Me.BtnFilter.TabStop = False
        Me.BtnFilter.TooltipText = ""
        Me.BtnFilter.UseVisualStyleBackColor = False
        Me.BtnFilter.Visible = False
        '
        'BtnView
        '
        Me.BtnView.BackColor = System.Drawing.Color.Transparent
        Me.BtnView.BackgroundImage = Global.Manager.My.Resources.Resources.View
        Me.BtnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnView.FlatAppearance.BorderSize = 0
        Me.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnView.Location = New System.Drawing.Point(26, 3)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(17, 17)
        Me.BtnView.TabIndex = 0
        Me.BtnView.TabStop = False
        Me.BtnView.TooltipText = ""
        Me.BtnView.UseVisualStyleBackColor = False
        Me.BtnView.Visible = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.Transparent
        Me.BtnNew.BackgroundImage = Global.Manager.My.Resources.Resources.IncludeSmall
        Me.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNew.Location = New System.Drawing.Point(3, 3)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(17, 17)
        Me.BtnNew.TabIndex = 1
        Me.BtnNew.TabStop = False
        Me.BtnNew.TooltipText = ""
        Me.BtnNew.UseVisualStyleBackColor = False
        Me.BtnNew.Visible = False
        '
        'FrmUserImportPrivilege
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(308, 105)
        Me.Controls.Add(Me.FlpPrivilegePreset)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.QbxPreset)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUserImportPrivilege"
        Me.ShowIcon = False
        Me.Text = "Importar Predefinição de Permissão"
        Me.Panel1.ResumeLayout(False)
        Me.FlpPrivilegePreset.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnImport As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents QbxPreset As ControlLibrary.QueriedBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnNew As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnView As ControlLibrary.NoFocusCueButton
    Friend WithEvents BtnFilter As ControlLibrary.NoFocusCueButton
    Friend WithEvents TmrQueriedBox As Timer
    Friend WithEvents FlpPrivilegePreset As FlowLayoutPanel
End Class
