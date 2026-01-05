Imports ManagerCore
Imports CoreSuite.Controls
Imports CoreSuite.Services
Imports CoreSuite.Infrastructure
Public Class SetupApp
    Public Shared Sub SetupCMessageBox()
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.ShowEmailErrorButton = True
        CMessageBox.SmtpMailServer = New Net.Mail.SmtpClient() With {
            .Host = Session.Preferences.Support.SMTPServer,
            .Port = Session.Preferences.Support.Port,
            .EnableSsl = Session.Preferences.Support.EnableSSL,
            .DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network,
            .UseDefaultCredentials = False,
            .Credentials = New Net.NetworkCredential(
                Session.Preferences.Support.Email,
                Session.Preferences.Support.Password
            )
        }
    End Sub
    Public Shared Sub SetupData()
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Dim RemoteDbCredentialsService As RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
        Dim LocalDbCredentialsService As LocalDbCredentialsService = Locator.GetInstance(Of LocalDbCredentialsService)
        Dim LocalDb As MySqlService = Locator.GetInstance(Of MySqlService)
        Dim RemoteSystemDb As FirebaseService = Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.System)
        Dim RemoteCustomerDb As FirebaseService = Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.Customer)

        Dim SystemRemoteDbCredentials As RemoteDbCredentialsModel = RemoteDbCredentialsService.Load(RemoteDatabaseType.System)
        Dim CustomerRemoteDbCredentials As RemoteDbCredentialsModel = RemoteDbCredentialsService.Load(RemoteDatabaseType.Customer)
        Dim LocalDbCredentials As LocalDbCredentialsModel = LocalDbCredentialsService.Load()

        LocalDb.Initialize(LocalDbCredentials.Server, LocalDbCredentials.Name, LocalDbCredentials.Username, LocalDbCredentials.Password)
        RemoteCustomerDb.Initialize(CustomerRemoteDbCredentials.ApiKey, CustomerRemoteDbCredentials.ProjectID, CustomerRemoteDbCredentials.BucketName)
        RemoteSystemDb.Initialize(SystemRemoteDbCredentials.ApiKey, SystemRemoteDbCredentials.ProjectID, SystemRemoteDbCredentials.BucketName)
    End Sub
End Class
