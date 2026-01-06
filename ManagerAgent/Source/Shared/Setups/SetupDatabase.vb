Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports ManagerCore

Public Class SetupDatabase
    Public Shared Async Function Setup() As Task
        Dim LocalDbCredentialsService As LocalDbCredentialsService = Locator.GetInstance(Of LocalDbCredentialsService)
        Dim RemoteSystemDbCredentialsService As RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
        Dim RemoteCustomerDbCredentialsService As RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)

        Dim LocalDbCredentials As LocalDbCredentialsModel = LocalDbCredentialsService.Load()
        Dim RemoteSystemDbCredentials As RemoteDbCredentialsModel = RemoteSystemDbCredentialsService.Load(RemoteDatabaseType.System)
        Dim RemoteCustomerDbCredentials As RemoteDbCredentialsModel = RemoteCustomerDbCredentialsService.Load(RemoteDatabaseType.Customer)

        Dim LocalDb As MySqlService = Locator.GetInstance(Of MySqlService)
        Dim RemoteSystemDb As FirebaseService = Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.System)
        Dim RemoteCustomerDb As FirebaseService = Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.Customer)

        If LocalDbCredentials IsNot Nothing Then
            LocalDb.Initialize(LocalDbCredentials.Server, LocalDbCredentials.Name, LocalDbCredentials.Username, LocalDbCredentials.Password)
        End If

        If RemoteSystemDbCredentials IsNot Nothing Then
            RemoteSystemDb.Initialize(RemoteSystemDbCredentials.ApiKey, RemoteSystemDbCredentials.ProjectID, RemoteSystemDbCredentials.BucketName)
            If Not String.IsNullOrEmpty(RemoteSystemDbCredentials.RefreshToken) Then
                Await RemoteSystemDb.Auth.RefreshSessionAsync(RemoteSystemDbCredentials.RefreshToken)
            Else
                Await RemoteSystemDb.Auth.LoginAsync(RemoteSystemDbCredentials.Username, RemoteSystemDbCredentials.Password)
            End If
        End If


        If RemoteCustomerDbCredentials IsNot Nothing Then
            RemoteCustomerDb.Initialize(RemoteCustomerDbCredentials.ApiKey, RemoteCustomerDbCredentials.ProjectID, RemoteCustomerDbCredentials.BucketName)
            If Not String.IsNullOrEmpty(RemoteCustomerDbCredentials.RefreshToken) Then
                Await RemoteCustomerDb.Auth.RefreshSessionAsync(RemoteCustomerDbCredentials.RefreshToken)
            Else
                Await RemoteCustomerDb.Auth.LoginAsync(RemoteCustomerDbCredentials.Username, RemoteCustomerDbCredentials.Password)
            End If
        End If
    End Function
End Class
