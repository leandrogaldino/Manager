Imports ControlLibrary

Public Class FrmChangePassword
    Private _PasswordService As PasswordService
    Public Sub New()
        InitializeComponent()
        _PasswordService = Locator.GetInstance(Of PasswordService)
    End Sub
    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        Dim Result As Boolean = ManagerCore.Util.AsyncLock(Function() _PasswordService.ChangePassword(TxtUsername.Text, TxtOldPassword.Text, TxtNewPassword.Text, TxtNewPassword2.Text))
        Cursor = Cursors.Default
        If Result Then DialogResult = DialogResult.OK
    End Sub
    Private Sub TxtNewPassword2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNewPassword2.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnConfirm.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class