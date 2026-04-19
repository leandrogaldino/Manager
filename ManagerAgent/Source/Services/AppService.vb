Imports CoreSuite.Helpers
Imports CoreSuite.Infrastructure
Imports ManagerCore
Public Class AppService
    Private ReadOnly _Session As SessionModel
    Public Sub New(Session As SessionModel)
        _Session = Session
    End Sub
    Public Async Function ValidateLicense() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim LicenseService As LicenseService = Locator.GetInstance(Of LicenseService)
        Try
            Dim Token As String = LicenseService.GetLocalCustomerLinkToken
            _Session.ManagerLicenseResult = Await LicenseService.GetOnlineLicense(Token)
            If Not _Session.ManagerLicenseResult.Success Then
                Validations.Add(EnumHelper.GetEnumDescription(_Session.ManagerLicenseResult.Flag))
            End If
        Catch ex As Exception
            Validations.Add($"Erro ao consultar a licença: {ex.Message}")
        End Try
        Return Validations
    End Function
    Public Function ValidateBackup() As List(Of String)
        Dim Preferences As PreferencesModel = _Session.Preferences
        Dim Validations As New List(Of String)
        If Preferences Is Nothing OrElse String.IsNullOrEmpty(Preferences.Backup.Location) Then
            Validations.Add($"O diretório de backup não foi definido.")
        Else
            If Not IO.Directory.Exists(Preferences.Backup.Location) Then
                Validations.Add($"O direrório de backup não existe.")
            End If
        End If
        Return Validations
    End Function
End Class
