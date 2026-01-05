Imports ManagerCore
Imports CoreSuite.Infrastructure
Public Class SetupSession
    Public Shared Sub Setup()
        Dim LicenseService As LicenseService = Locator.GetInstance(Of LicenseService)
        Dim PreferencesService As PreferencesService = Locator.GetInstance(Of PreferencesService)
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Session.ManagerLicenseResult = LicenseService.GetLocalLicense()
        Dim CompanyService As CompanyService = Locator.GetInstance(Of CompanyService)
        Session.Companies = ManagerCore.Util.AsyncLock(Function() CompanyService.LoadAllAsync())
        Session.Preferences = ManagerCore.Util.AsyncLock(Function() PreferencesService.LoadAsync())
    End Sub
End Class
