Imports ManagerCore
Imports ControlLibrary
Imports System.Threading
Public Class SetupLocator
    Public Shared Sub Setup()
        Locator.RegisterSingleton(New SemaphoreSlim(1, 1))
        Locator.RegisterSingleton(New CryptoKeyService())
        Locator.RegisterSingleton(New SessionModel())
        Locator.RegisterSingleton(New CompanyService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New CompanyService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(Of LocalDB)(New MySqlService())
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), CloudDatabaseType.Customer)
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), CloudDatabaseType.License)
        Locator.RegisterSingleton(Of Storage)(New StorageService())
        Locator.RegisterSingleton(New LicenseService(Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.License), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New LicenseService(Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.License), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New EventService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New PasswordService(Locator.GetInstance(Of LicenseService), Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New TaskStackService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New LicenseCloudService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New AppService(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.License), Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer), Locator.GetInstance(Of Storage), Locator.GetInstance(Of LicenseCloudService)))
    End Sub
End Class
