Imports ControlLibrary
Imports ManagerCore

Public Class SetupSession
    Public Shared Sub Setup()
        Dim LicenseService As LicenseService = Locator.GetInstance(Of LicenseService)
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Session.ManagerLicenseResult = LicenseService.GetLocalLicense()
        Dim CompanyService As CompanyService = Locator.GetInstance(Of CompanyService)
        Session.Companies = CompanyService.LoadAll()
    End Sub
End Class
