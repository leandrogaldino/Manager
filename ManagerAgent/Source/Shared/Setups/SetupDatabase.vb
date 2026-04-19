Imports System.Drawing.Text
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports ManagerCore

Public Class SetupDatabase
    Private Const Suffix As String = "@nexor.com"
    Public Shared Sub SetupLocal()
        Dim LocalDbCredentialsService As LocalDbCredentialsService = Locator.GetInstance(Of LocalDbCredentialsService)
        Dim LocalDbCredentials As LocalDbCredentialsModel = LocalDbCredentialsService.Load()
        Dim LocalDb As MySqlService = Locator.GetInstance(Of MySqlService)
        If LocalDbCredentials IsNot Nothing Then
            LocalDb.Initialize(LocalDbCredentials.Server, LocalDbCredentials.Name, LocalDbCredentials.Username, LocalDbCredentials.Password)
        End If
    End Sub

    Public Shared Async Function SetupSystem() As Task
        Dim RemoteSystemDbCredentialsService As RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
        Dim RemoteSystemDbCredentials As RemoteDbCredentialsModel = RemoteSystemDbCredentialsService.Load(RemoteDatabaseType.System)
        Dim RemoteSystemDb As FirebaseService = Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.System)
        If RemoteSystemDbCredentials IsNot Nothing Then
            RemoteSystemDb.Initialize(RemoteSystemDbCredentials.ApiKey, RemoteSystemDbCredentials.ProjectID, RemoteSystemDbCredentials.BucketName)
            If Not String.IsNullOrEmpty(RemoteSystemDbCredentials.RefreshToken) Then
                Await RemoteSystemDb.Auth.RefreshSessionAsync(RemoteSystemDbCredentials.RefreshToken)
            Else
                Await RemoteSystemDb.Auth.LoginAsync($"{RemoteSystemDbCredentials.Username}{Suffix}", RemoteSystemDbCredentials.Password)
            End If
        End If
    End Function
    Public Shared Async Function SetupCustomer() As Task
        Dim RemoteCustomerDbCredentialsService As RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
        Dim RemoteCustomerDbCredentials As RemoteDbCredentialsModel = RemoteCustomerDbCredentialsService.Load(RemoteDatabaseType.Customer)
        Dim RemoteCustomerDb As FirebaseService = Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.Customer)
        If RemoteCustomerDbCredentials IsNot Nothing Then
            RemoteCustomerDb.Initialize(RemoteCustomerDbCredentials.ApiKey, RemoteCustomerDbCredentials.ProjectID, RemoteCustomerDbCredentials.BucketName)
            If Not String.IsNullOrEmpty(RemoteCustomerDbCredentials.RefreshToken) Then
                Await RemoteCustomerDb.Auth.RefreshSessionAsync(RemoteCustomerDbCredentials.RefreshToken)
            Else
                Await RemoteCustomerDb.Auth.LoginAsync($"{RemoteCustomerDbCredentials.Username}{Suffix}", RemoteCustomerDbCredentials.Password)
            End If
        End If
    End Function
End Class
