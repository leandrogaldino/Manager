Imports ControlLibrary

Public Class SetupTasks
    Public Shared Sub Setup()
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
