Imports ControlLibrary
Public Class FrmUserImportPrivilege
    Private _LoggedUser As User
    Public Sub New()
        InitializeComponent()
        _LoggedUser = Locator.GetInstance(Of Session).User
    End Sub

    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxPreset_Enter(sender As Object, e As EventArgs) Handles QbxPreset.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxPreset.IsFreezed And _LoggedUser.CanWrite(Routine.PrivilegePreset)
        BtnNew.Visible = _LoggedUser.CanWrite(Routine.PrivilegePreset)
        BtnFilter.Visible = _LoggedUser.CanAccess(Routine.PrivilegePreset)
    End Sub
    Private Sub QbxPreset_Leave(sender As Object, e As EventArgs) Handles QbxPreset.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxPreset_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPreset.FreezedPrimaryKeyChanged
        BtnView.Visible = QbxPreset.IsFreezed And _LoggedUser.CanWrite(Routine.PrivilegePreset)
        BtnImport.Enabled = QbxPreset.IsFreezed
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Preset As PrivilegePreset
        Preset = New PrivilegePreset
        Using Form As New FrmPrivilegePreset(Preset)
            Form.ShowDialog()
        End Using
        If Preset.ID > 0 Then
            QbxPreset.Freeze(Preset.ID)
        End If
        QbxPreset.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Using Form As New FrmPrivilegePreset(New PrivilegePreset().Load(QbxPreset.FreezedPrimaryKey, True))
            Form.ShowDialog()
        End Using
        QbxPreset.Freeze(QbxPreset.FreezedPrimaryKey)
        QbxPreset.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New PrivilegePresetQueriedBoxFilter(), QbxPreset) With {.Text = "Filtro de Predefinição de Permissões"}
            Form.ShowDialog()
        End Using
        QbxPreset.Select()
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        DialogResult = DialogResult.OK
    End Sub
End Class