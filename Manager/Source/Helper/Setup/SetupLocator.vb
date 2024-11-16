Imports ControlLibrary
Imports ManagerCore

Public Class SetupLocator
    Public Shared Sub Setup()
        Locator.RegisterSingleton(New CryptoKeyService)
        Locator.RegisterSingleton(New SettingService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New Session())
        Locator.RegisterSingleton(Of LocalDB)(New MySqlService)
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), CloudDatabaseType.Customer)
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), CloudDatabaseType.Manager)
        Locator.RegisterSingleton(Of Storage)(New StorageService())
        Locator.RegisterSingleton(New LicenseService(Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Manager), Locator.GetInstance(Of CryptoKeyService)))
    End Sub
End Class
