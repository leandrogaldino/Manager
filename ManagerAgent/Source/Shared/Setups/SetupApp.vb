Imports ControlLibrary
Imports ManagerCore
Public Class SetupApp
    Public Shared Sub SetupCMessageBox()
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.ShowEmailErrorButton = False
    End Sub
    Public Shared Sub SetupData()
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Dim LicenseCloudService As LicenseCloudService = Locator.GetInstance(Of LicenseCloudService)
        Dim LicenseCloudModel As LicenseCloudModel = LicenseCloudService.Load()
        For Each Company In Session.Companies
            Locator.GetInstance(Of LocalDB)().Initialize(Company.Database)
            Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.License).Initialize(LicenseCloudModel)
            Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer).Initialize(Company.Cloud)
            Locator.GetInstance(Of Storage)().Initialize(Company.Cloud)
        Next Company
    End Sub
End Class
