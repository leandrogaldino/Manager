Imports ControlLibrary
Imports ManagerCore

Public Class FrmUserChangePassword
    Private _User As User
    Public Sub New(User As User)
        InitializeComponent()
        _User = User
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtOldPassword.TextChanged,
                                                                          TxtNewPassword.TextChanged,
                                                                          TxtNewPassword2.TextChanged
        If Not String.IsNullOrWhiteSpace(TxtOldPassword.Text) And Not String.IsNullOrWhiteSpace(TxtNewPassword.Text) And Not String.IsNullOrWhiteSpace(TxtNewPassword2.Text) Then
            BtnChangePassword.Enabled = True
        Else
            BtnChangePassword.Enabled = False
        End If
        EprValidation.Clear()
    End Sub
    Private Sub BtnChangePassword_Click(sender As Object, e As EventArgs) Handles BtnChangePassword.Click
        If Cryptography.Encrypt(TxtOldPassword.Text, Locator.GetInstance(Of CryptoKeyService).ReadCryptoKey()) = _User.Password Then
            If TxtNewPassword.Text = TxtNewPassword2.Text Then
                Try
                    Cursor = Cursors.WaitCursor
                    _User.ChangePassword(TxtNewPassword.Text)
                    CMessageBox.Show("Sua senha foi alterada com sucesso!", CMessageBoxType.Done)
                    Dispose()
                Catch ex As Exception
                    CMessageBox.Show("ERRO US006", "Ocorreu um erro ao alterar a senha.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                EprValidation.SetError(LblNewPassword, "Senha diferente da confirmação.")
                EprValidation.SetIconAlignment(LblNewPassword, ErrorIconAlignment.MiddleRight)
                TxtNewPassword.Select()
            End If
        Else
            EprValidation.SetError(LblOldPassword, "Senha incorreta.")
            EprValidation.SetIconAlignment(LblOldPassword, ErrorIconAlignment.MiddleRight)
            TxtOldPassword.Select()
        End If
    End Sub
    Private Sub TxtNewPassword2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNewPassword2.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnChangePassword.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class