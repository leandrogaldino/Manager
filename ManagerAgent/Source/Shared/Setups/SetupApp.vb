Imports ControlLibrary
Imports FirebaseController
Imports ManagerCore
Imports MySqlController
Public Class SetupApp
    Public Shared Sub SetupCMessageBox()
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.ShowEmailErrorButton = False
    End Sub
    Public Shared Sub SetupData()
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Dim LicenseCloudService As LicenseCredentialsService = Locator.GetInstance(Of LicenseCredentialsService)
        Dim LicenseCloudModel As LicenseCredentialsModel = LicenseCloudService.Load()
        If LicenseCloudModel IsNot Nothing Then
            Locator.GetInstance(Of FirebaseService)(CloudDatabaseType.License).Initialize(LicenseCloudModel.ApiKey, LicenseCloudModel.ProjectID, LicenseCloudModel.BucketName)
        End If
        For Each Company In Session.Companies
            Locator.GetInstance(Of MySqlService)().Initialize(Company.Database.Server, Company.Database.Name, Company.Database.Username, Company.Database.Password)
            Locator.GetInstance(Of FirebaseService)(CloudDatabaseType.Customer).Initialize(Company.Cloud.ApiKey, Company.Cloud.ProjectID, Company.Cloud.BucketName)
        Next Company
    End Sub
End Class
