Imports ControlLibrary
Imports ManagerCore

Public Class SetupSettings
    Public Shared Sub Setup()
        Locator.GetInstance(Of Session)().Setting = Locator.GetInstance(Of SettingService)().GetSettings
    End Sub
End Class
