Imports ManagerCore
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports System.Threading
Public Class SetupLocator
    Public Shared Sub Setup()
        Locator.RegisterSingleton(New SemaphoreSlim(1, 1))
        Locator.RegisterSingleton(New CryptoKeyService())
        Locator.RegisterSingleton(New SessionModel())
        Locator.RegisterSingleton(New MySqlService())
        Locator.RegisterSingleton(New FirebaseService(), RemoteDatabaseType.Customer)
        Locator.RegisterSingleton(New FirebaseService(), RemoteDatabaseType.System)
        Locator.RegisterSingleton(New CompanyService(Locator.GetInstance(Of MySqlService)))
        Locator.RegisterSingleton(New CompanyService(Locator.GetInstance(Of MySqlService)))
        Locator.RegisterSingleton(New LicenseService(Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.System), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New EventService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New PasswordService(Locator.GetInstance(Of LicenseService), Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New TaskStackService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New RemoteDbCredentialsService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New LocalDbCredentialsService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New AppService(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of LocalDbCredentialsService), Locator.GetInstance(Of RemoteDbCredentialsService)))
        Locator.RegisterSingleton(New PreferencesService(Locator.GetInstance(Of MySqlService)))
    End Sub
End Class
