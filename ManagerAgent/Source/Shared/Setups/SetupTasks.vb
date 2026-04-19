Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports ManagerCore
Public Class SetupTasks
    Public Shared Sub Setup()
        Locator.RegisterSingleton(Of TaskBase)(New TaskBackup(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService), Locator.GetInstance(Of CryptoKeyService)), TaskName.Backup)
        Locator.RegisterSingleton(Of TaskBase)(New TaskBackupManual(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService), Locator.GetInstance(Of CryptoKeyService)), TaskName.BackupManual)
        Locator.RegisterSingleton(Of TaskBase)(New TaskRestoreBackup(Locator.GetInstance(Of MySqlService), Locator.GetInstance(Of CryptoKeyService)), TaskName.BackupRestore)
        Locator.RegisterSingleton(Of TaskBase)(New TaskClean(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService)), TaskName.Clean)
        Locator.RegisterSingleton(Of TaskBase)(New TaskCleanManual(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService)), TaskName.CleanManual)
        Locator.RegisterSingleton(Of TaskBase)(New TaskCloudSync(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService), Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.Customer)), TaskName.CloudSync)
        Locator.RegisterSingleton(Of TaskBase)(New TaskCloudSyncManual(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService), Locator.GetInstance(Of FirebaseService)(RemoteDatabaseType.Customer)), TaskName.CloudSyncManual)
        Locator.RegisterSingleton(Of TaskBase)(New TaskRelease(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService)), TaskName.Release)
        Locator.RegisterSingleton(Of TaskBase)(New TaskReleaseManual(Locator.GetInstance(Of SessionModel), Locator.GetInstance(Of PreferencesService), Locator.GetInstance(Of MySqlService)), TaskName.ReleaseManual)
        Dim Stack = Locator.GetInstance(Of TaskStackService)
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.Backup))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.BackupManual))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.BackupRestore))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.Clean))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.CleanManual))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.CloudSync))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.CloudSyncManual))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.Release))
        Stack.AddTask(Locator.GetInstance(Of TaskBase)(TaskName.ReleaseManual))
    End Sub
End Class
