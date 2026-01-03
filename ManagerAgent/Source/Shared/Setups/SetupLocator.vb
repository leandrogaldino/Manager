Imports ManagerCore
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports System.Threading
Public Class SetupLocator
    Public Shared Sub Setup()
        Locator.RegisterSingleton(New SemaphoreSlim(1, 1))
        Locator.RegisterSingleton(New CryptoKeyService())
        Locator.RegisterSingleton(New SessionModel())
        Locator.RegisterSingleton(New CompanyService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New CompanyService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New MySqlService())
        Locator.RegisterSingleton(New FirebaseService(), CloudDatabaseType.Customer)
        Locator.RegisterSingleton(New FirebaseService(), CloudDatabaseType.License)
        Locator.RegisterSingleton(New LicenseService(Locator.GetInstance(Of FirebaseService)(CloudDatabaseType.License), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New EventService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New PasswordService(Locator.GetInstance(Of LicenseService), Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New TaskStackService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New LicenseCredentialsService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New AppService(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of LicenseCredentialsService)))
        Locator.RegisterSingleton(New PreferencesService(Locator.GetInstance(Of CryptoKeyService)))
    End Sub
End Class
