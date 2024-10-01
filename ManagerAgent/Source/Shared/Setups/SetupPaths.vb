Imports ManagerCore
Public Class SetupPaths
    Public Shared Sub Setup()
        ApplicationPaths.AgentDirectory = Application.StartupPath()
        ApplicationPaths.Create()
    End Sub
End Class
