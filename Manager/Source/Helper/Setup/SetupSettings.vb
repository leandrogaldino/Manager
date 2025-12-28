Imports ControlLibrary
Imports ManagerCore

Public Class SetupSettings
    Public Shared Sub Setup()
        Locator.GetInstance(Of Session)().Setting = Locator.GetInstance(Of CompanyService)().Load
    End Sub
End Class
