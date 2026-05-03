Imports ControlLibrary
Imports ManagerCore

Public Class SetupLocator
    Public Shared Sub Setup()
        Locator.RegisterSingleton(New CryptoKeyService)
        Locator.RegisterSingleton(New CompanyService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New Session())
        Locator.RegisterSingleton(Of LocalDB)(New MySqlBackupService)
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), RemoteDatabaseType.Customer)
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), RemoteDatabaseType.Manager)
        Locator.RegisterSingleton(Of Storage)(New StorageService())
        Locator.RegisterSingleton(New LicenseService(Locator.GetInstance(Of RemoteDB)(RemoteDatabaseType.Manager), Locator.GetInstance(Of CryptoKeyService)))
    End Sub
End Class
