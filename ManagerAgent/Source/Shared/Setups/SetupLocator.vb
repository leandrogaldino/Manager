Imports ManagerCore
Imports ControlLibrary
Imports System.Threading
Public Class SetupLocator
    Public Shared Sub Setup()
        Locator.RegisterSingleton(New SemaphoreSlim(1, 1))
        Locator.RegisterSingleton(New CryptoKeyService())
        Locator.RegisterSingleton(New SessionModel())
        Locator.RegisterSingleton(New SettingService(Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(Of LocalDB)(New MySqlService())
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), CloudDatabaseType.Customer)
        Locator.RegisterSingleton(Of RemoteDB)(New FirestoreService(), CloudDatabaseType.Manager)
        Locator.RegisterSingleton(Of Storage)(New StorageService())
        Locator.RegisterSingleton(New LicenseService(Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Manager), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(New EventService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New PasswordService(Locator.GetInstance(Of LicenseService), Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of CryptoKeyService)))
        Locator.RegisterSingleton(Of TaskBase)(New TaskBackup(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.Backup)
        Locator.RegisterSingleton(Of TaskBase)(New TaskBackupManual(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.BackupManual)
        Locator.RegisterSingleton(Of TaskBase)(New TaskRestoreBackup(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of SessionModel)), TaskName.BackupRestore)
        Locator.RegisterSingleton(Of TaskBase)(New TaskClean(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.Clean)
        Locator.RegisterSingleton(Of TaskBase)(New TaskCleanManual(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.CleanManual)
        Locator.RegisterSingleton(Of TaskBase)(New TaskCloudSync(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.CloudSync)
        Locator.RegisterSingleton(Of TaskBase)(New TaskCloudSyncManual(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.CloudSyncManual)
        Locator.RegisterSingleton(Of TaskBase)(New TaskRelease(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.Release)
        Locator.RegisterSingleton(Of TaskBase)(New TaskReleaseManual(Locator.GetInstance(Of LocalDB), Locator.GetInstance(Of SettingService), Locator.GetInstance(Of SessionModel)), TaskName.ReleaseManual)
        Locator.RegisterSingleton(New TaskStackService(Locator.GetInstance(Of SemaphoreSlim)))
        Locator.RegisterSingleton(New AppService(Locator.GetInstance(Of SettingService)))
    End Sub
End Class
