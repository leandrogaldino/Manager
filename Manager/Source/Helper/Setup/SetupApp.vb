Imports System.IO
Imports ControlLibrary
Imports ManagerCore
Public Class SetupApp
    Public Shared Sub SetupIO()
        Dim AgentLocationFile As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", ".AgentLocation"))
        If Not File.Exists(AgentLocationFile) Then AgentLocationFile = Path.GetFullPath(Path.Combine(Application.StartupPath, ".AgentLocation"))
        If Not File.Exists(AgentLocationFile) Then Throw New FileNotFoundException("O arquivo de localização do Agent não foi encontrado.")
        Dim AgentLocation As String = File.ReadAllText(AgentLocationFile)
        ApplicationPaths.AgentDirectory = Path.GetFullPath(AgentLocation)
        If Directory.Exists(ApplicationPaths.AgentDirectory) = False Then
            Throw New DirectoryNotFoundException("O diretório do Agent não foi encontrado.")
        End If
        ApplicationPaths.Create()
        WipeTempDirectory()
        If Not File.Exists(Path.Combine(ApplicationPaths.HelpersDirectory, "MaintenancePlan.xml")) Then
            File.WriteAllText(Path.Combine(ApplicationPaths.HelpersDirectory, "MaintenancePlan.xml"), My.Resources.MaintenancePlan)
        End If
    End Sub
    Public Shared Sub SetupUserEnvironment()
        Dim Session = Locator.GetInstance(Of Session)
        Session.UserDirectoryLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Manager", Locator.GetInstance(Of Session).User.Username)
        DataGridViewLayout.XmlDirectory = Path.Combine(Session.UserDirectoryLocation, "GridLayout")
        DataGridViewLayout.CreateOrUpdateFiles()
    End Sub
    Public Shared Sub SetupDatabases()
        Dim Session As Session = Locator.GetInstance(Of Session)
        Locator.GetInstance(Of LocalDB)().Initialize(Session.Setting.Database)
        Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.System).Initialize(Session.Setting.Cloud.System)
        Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer).Initialize(Session.Setting.Cloud.Customer)
        Locator.GetInstance(Of Storage)().Initialize(Session.Setting.Cloud.Storage)
    End Sub
    Private Shared Sub WipeTempDirectory()
        Dim CurrentDirectory As DirectoryInfo
        If Process.GetProcessesByName("Manager").Length = 1 Then
            CurrentDirectory = New DirectoryInfo(ApplicationPaths.ManagerTempDirectory)
            If CurrentDirectory.Exists Then
                CurrentDirectory.GetFiles.ToList.ForEach(Sub(x) FileHelper.TryDeleteFile(x))
                CurrentDirectory.GetDirectories.ToList.ForEach(Sub(x) FileHelper.TryDeleteDirectory(x))
            End If
        End If
    End Sub
End Class
