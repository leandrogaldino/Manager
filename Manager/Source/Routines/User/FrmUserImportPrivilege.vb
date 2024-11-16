Imports ControlLibrary
Imports Manager.Util
Public Class FrmUserImportPrivilege
    'Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
    '    BtnView.Visible = False
    '    BtnNew.Visible = False
    '    BtnFilter.Visible = False
    '    TmrQueriedBox.Stop()
    'End Sub
    'Private Sub QbxPreset_Enter(sender As Object, e As EventArgs) Handles QbxPreset.Enter
    '    TmrQueriedBox.Stop()
    '    BtnView.Visible = QbxPreset.IsFreezed And Locator.GetInstance(Of Session).User.Privileges.UserPrivilegePresetWrite
    '    BtnNew.Visible = Locator.GetInstance(Of Session).User.Privileges.UserPrivilegePresetWrite
    '    BtnFilter.Visible = Locator.GetInstance(Of Session).User.Privileges.UserPrivilegePresetAccess
    'End Sub
    'Private Sub QbxPreset_Leave(sender As Object, e As EventArgs) Handles QbxPreset.Leave
    '    TmrQueriedBox.Stop()
    '    TmrQueriedBox.Start()
    'End Sub
    'Private Sub QbxPreset_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPreset.FreezedPrimaryKeyChanged
    '    BtnView.Visible = QbxPreset.IsFreezed And Locator.GetInstance(Of Session).User.Privileges.UserPrivilegePresetWrite
    '    BtnImport.Enabled = QbxPreset.IsFreezed
    'End Sub
    'Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
    '    Dim Preset As UserPrivilegePreset
    '    Dim Form As FrmUserPrivilegePreset
    '    Preset = New UserPrivilegePreset
    '    Form = New FrmUserPrivilegePreset(Preset)
    '    Form.ShowDialog()
    '    If Preset.ID > 0 Then
    '        QbxPreset.Freeze(Preset.ID)
    '    End If
    '    QbxPreset.Select()
    'End Sub
    'Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
    '    Dim Form As New FrmUserPrivilegePreset(New UserPrivilegePreset().Load(QbxPreset.FreezedPrimaryKey, True))
    '    Form.ShowDialog()
    '    QbxPreset.Freeze(QbxPreset.FreezedPrimaryKey)
    '    QbxPreset.Select()
    'End Sub
    'Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
    '    Dim FilterForm As FrmFilter
    '    FilterForm = New FrmFilter(New UserPrivilegePresetQueriedBoxFilter(), QbxPreset)
    '    FilterForm.Text = "Filtro de Predefinição de Permissões"
    '    FilterForm.ShowDialog()
    '    QbxPreset.Select()
    'End Sub
    'Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
    '    DialogResult = DialogResult.OK
    'End Sub
End Class