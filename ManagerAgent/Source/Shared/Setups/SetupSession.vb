Imports ManagerCore
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Public Class SetupSession
    Public Shared Sub Setup()
        Dim LicenseService As LicenseService = Locator.GetInstance(Of LicenseService)
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Session.ManagerLicenseResult = ManagerCore.Util.AsyncLock(Function() LicenseService.GetLocalLicense())
        Dim LocalDb As MySqlService = Locator.GetInstance(Of MySqlService)
        If LocalDb.Client IsNot Nothing Then
            Dim PreferencesService As PreferencesService = Locator.GetInstance(Of PreferencesService)
            Session.Preferences = ManagerCore.Util.AsyncLock(Function() PreferencesService.LoadAsync())
            Dim CompanyService As CompanyService = Locator.GetInstance(Of CompanyService)
            Session.Companies = ManagerCore.Util.AsyncLock(Function() CompanyService.LoadAllAsync())
        End If
    End Sub
End Class
