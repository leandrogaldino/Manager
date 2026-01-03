Imports ManagerCore
Imports CoreSuite.Controls
Imports CoreSuite.Services
Imports CoreSuite.Infrastructure
Public Class SetupApp
    Public Shared Sub SetupCMessageBox()
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.ShowEmailErrorButton = False
    End Sub
    Public Shared Sub SetupData()
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Dim LicenseCloudService As LicenseCredentialsService = Locator.GetInstance(Of LicenseCredentialsService)
        Dim LicenseCloudModel As LicenseRemoteDatabaseModel = LicenseCloudService.Load()
        If LicenseCloudModel IsNot Nothing Then
            Locator.GetInstance(Of FirebaseService)(CloudDatabaseType.License).Initialize(LicenseCloudModel.ApiKey, LicenseCloudModel.ProjectID, LicenseCloudModel.BucketName)
        End If
        For Each Company In Session.Companies
            Locator.GetInstance(Of MySqlService)().Initialize(Company.LocalDatabase.Server, Company.LocalDatabase.Name, Company.LocalDatabase.Username, Company.LocalDatabase.Password)
            Locator.GetInstance(Of FirebaseService)(CloudDatabaseType.Customer).Initialize(Company.RemoteDatabase.ApiKey, Company.RemoteDatabase.ProjectID, Company.RemoteDatabase.BucketName)
        Next Company
    End Sub
End Class
