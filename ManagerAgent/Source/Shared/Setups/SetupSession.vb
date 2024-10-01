Imports ControlLibrary
Imports ManagerCore

Public Class SetupSession
    Public Shared Sub Setup()
        Locator.GetInstance(Of SessionModel).ManagerSetting = Locator.GetInstance(Of SettingService).GetSettings()
    End Sub
End Class
