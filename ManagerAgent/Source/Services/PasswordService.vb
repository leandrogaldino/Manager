Imports ControlLibrary
Imports ManagerCore

Public Class PasswordService
    Private ReadOnly _LicenseService As LicenseService
    Private ReadOnly _Key As String
    Private _SessionModel As SessionModel

    Public Sub New(LicenseService As LicenseService, SessionModel As SessionModel, CryptoKeyService As CryptoKeyService)
        _LicenseService = LicenseService
        _SessionModel = SessionModel
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub

    Public Async Function ChangePassword(Username As String, OldPassword As String, NewPassword As String, ConfirmPassword As String) As Task(Of Boolean)
        Dim TempLicenseResult As LicenseResultModel = _LicenseService.GetLocalLicense()
        If Not TempLicenseResult.Success Then
            CMessageBox.Show(Utility.GetEnumDescription(TempLicenseResult.Flag), CMessageBoxType.Warning)
            Return False
        End If

        If Username <> TempLicenseResult.License.ManagerAgentUsername Then
            CMessageBox.Show("Usuário não encontrado. Verifique o nome de usuário.", CMessageBoxType.Warning)
            Return False
        End If

        If OldPassword <> Cryptography.Decrypt(TempLicenseResult.License.ManagerAgentPassword, _Key) Then
            CMessageBox.Show("Senha atual incorreta.", CMessageBoxType.Warning)
            Return False
        End If

        If NewPassword <> ConfirmPassword Then
            CMessageBox.Show("A nova senha e a confirmação não correspondem.", CMessageBoxType.Warning)
            Return False
        End If

        Try
            TempLicenseResult.License = Await _LicenseService.UpdateManagerAgentPassword(TempLicenseResult.License, Cryptography.Encrypt(NewPassword, _Key))
            _SessionModel.ManagerLicenseResult = TempLicenseResult.Clone()
            Await _LicenseService.SaveLocalLicense(_SessionModel.ManagerLicenseResult.License)
            CMessageBox.Show("Sua senha foi alterada com sucesso!", CMessageBoxType.Done)
            Return True
        Catch ex As Exception
            CMessageBox.Show("ERRO MA001", "Erro ao tentar alterar a senha.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Return False
        End Try
    End Function
End Class
