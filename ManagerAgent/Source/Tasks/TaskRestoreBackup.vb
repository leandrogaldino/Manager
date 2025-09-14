Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.FileManager
Imports ManagerCore

Public Class TaskRestoreBackup
    Inherits TaskBase
    Private _DatabaseService As LocalDB
    Private _SettingsService As SettingService
    Private _SessionModel As SessionModel
    Public Sub New(DatabaseService As LocalDB, SettingsService As SettingService, SessionModel As SessionModel)
        _DatabaseService = DatabaseService
        _SettingsService = SettingsService
        _SessionModel = SessionModel
    End Sub
    Public Overrides ReadOnly Property Name As TaskName
        Get
            Return TaskName.BackupRestore
        End Get
    End Property

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return Nothing
        End Get
    End Property

    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property BackupFile As BackupFileModel

    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Response As New AsyncResponseModel
        Dim BackupLocation As String
        Dim RestoreDirectory As String

        Dim Directories As New List(Of DeleteDirectoryInfo)
        Dim FileManager As FileManager
        Dim FileManagerCopyInfo As List(Of CopyDirectoryInfo)
        Dim IntProgress As Progress(Of Integer)
        Dim Exception As Exception = Nothing
        RestoreDirectory = Path.Combine(ApplicationPaths.AgentTempDirectory, "Restore_" & Now.ToString("ddMMyyyyHHmmss"))
        BackupLocation = BackupFile.FilePath

        Dim Filename As String = New FileInfo(BackupLocation).Name.Replace(".bkp", Nothing).Replace("-", "/").Replace(".", ":")
        Try
            Response.Text = $"Restaurando Backup: Iniciando - {Filename}"
            Response.Event.SetInitialEvent($"Restaurando Backup: Iniciando - {Filename}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForStart)



            Response.Text = "Restaurando Backup: Extraindo arquivos"
            Response.Event.AddChildEvent("Extraindo arquivos")
            If Progress IsNot Nothing Then Progress.Report(Response)



            IntProgress = New Progress(Of Integer)

            AddHandler IntProgress.ProgressChanged, Sub(sender As Object, Percent As Integer)
                                                        Response.Percent = Percent
                                                        Response.Text = $"Restaurando Backup: Descompactando arquivos ({Percent}%)"
                                                        If Progress IsNot Nothing Then Progress.Report(Response)
                                                    End Sub


            Dim BackupComprerssion As CompressionService = Locator.GetInstance(Of ICompression)


            Await BackupComprerssion.Decompress(BackupLocation, RestoreDirectory, _SessionModel.ZipPassword, IntProgress)


            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Restaurando Backup: Excluindo arquivos da versão atual"
            Response.Event.AddChildEvent("Excluindo arquivos da versão atual")
            If Progress IsNot Nothing Then Progress.Report(Response)



            Directories.AddRange({
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.ProductPictureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.RequestDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EmailSignatureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.CashDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.HelpersDirectory), True)
            })


            FileManager = New FileManager
            AddHandler FileManager.DeleteDirectoriesProgressChanged, Sub(IOSender, IOEventArgs)
                                                                         Response.Percent = IOEventArgs.PercentCompleted
                                                                         Response.Text = $"Restaurando Backup: Excluindo arquivos da versão atual ({IOEventArgs.PercentCompleted}%)"
                                                                         If Progress IsNot Nothing Then Progress.Report(Response)
                                                                     End Sub
            Await FileManager.DeleteDirectoriesAsync(Directories)


            Dim Files As New List(Of FileInfo)


            Await Task.Delay(Constants.WaitForJob)

            Response.Percent = 0
            Response.Text = "Restaurando Backup: Copiando arquivos do backup"
            Response.Event.AddChildEvent("Copiando arquivos do backup")
            If Progress IsNot Nothing Then Progress.Report(Response)


            AddHandler FileManager.CopyDirectoryProgressChanged, Sub(IOSender, IOEventArgs)
                                                                     Response.Percent = IOEventArgs.PercentCompleted
                                                                     Response.Text = $"Restaurando Backup: Copiando arquivos do backup ({IOEventArgs.PercentCompleted}%)"
                                                                     If Progress IsNot Nothing Then Progress.Report(Response)
                                                                 End Sub



            FileManagerCopyInfo = New List(Of CopyDirectoryInfo)

            If Not Directory.Exists(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.ProductPicture.ToString)) Then Directory.CreateDirectory(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.ProductPicture.ToString))
            If Not Directory.Exists(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.EvaluationDocument.ToString)) Then Directory.CreateDirectory(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.EvaluationDocument.ToString))
            If Not Directory.Exists(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.RequestDocument.ToString)) Then Directory.CreateDirectory(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.RequestDocument.ToString))
            If Not Directory.Exists(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.EmailSignature.ToString)) Then Directory.CreateDirectory(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.EmailSignature.ToString))
            If Not Directory.Exists(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.CashDocument.ToString)) Then Directory.CreateDirectory(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.CashDocument.ToString))
            If Not Directory.Exists(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.Helpers.ToString)) Then Directory.CreateDirectory(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.Helpers.ToString))


            If Directory.Exists(Path.Combine(RestoreDirectory, BackupDirectories.ProductPicture.ToString)) Then FileManagerCopyInfo.Add(New CopyDirectoryInfo(New DirectoryInfo(Path.Combine(RestoreDirectory, BackupDirectories.ProductPicture.ToString)), New DirectoryInfo(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.ProductPicture.ToString))))
            If Directory.Exists(Path.Combine(RestoreDirectory, BackupDirectories.EvaluationDocument.ToString)) Then FileManagerCopyInfo.Add(New CopyDirectoryInfo(New DirectoryInfo(Path.Combine(RestoreDirectory, BackupDirectories.EvaluationDocument.ToString)), New DirectoryInfo(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.EvaluationDocument.ToString))))
            If Directory.Exists(Path.Combine(RestoreDirectory, BackupDirectories.RequestDocument.ToString)) Then FileManagerCopyInfo.Add(New CopyDirectoryInfo(New DirectoryInfo(Path.Combine(RestoreDirectory, BackupDirectories.RequestDocument.ToString)), New DirectoryInfo(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.RequestDocument.ToString))))
            If Directory.Exists(Path.Combine(RestoreDirectory, BackupDirectories.EmailSignature.ToString)) Then FileManagerCopyInfo.Add(New CopyDirectoryInfo(New DirectoryInfo(Path.Combine(RestoreDirectory, BackupDirectories.EmailSignature.ToString)), New DirectoryInfo(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.EmailSignature.ToString))))
            If Directory.Exists(Path.Combine(RestoreDirectory, BackupDirectories.CashDocument.ToString)) Then FileManagerCopyInfo.Add(New CopyDirectoryInfo(New DirectoryInfo(Path.Combine(RestoreDirectory, BackupDirectories.CashDocument.ToString)), New DirectoryInfo(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.CashDocument.ToString))))
            If Directory.Exists(Path.Combine(RestoreDirectory, BackupDirectories.Helpers.ToString)) Then FileManagerCopyInfo.Add(New CopyDirectoryInfo(New DirectoryInfo(Path.Combine(RestoreDirectory, BackupDirectories.Helpers.ToString)), New DirectoryInfo(Path.Combine(ApplicationPaths.FilesDirectory, BackupDirectories.Helpers.ToString))))
            Await FileManager.CopyDirectoriesAsync(FileManagerCopyInfo)


            Await Task.Delay(Constants.WaitForJob)



            Response.Percent = 0
            Response.Text = "Restaurando Backup: Restaurando o banco de dados"
            Response.Event.AddChildEvent("Restaurando o banco de dados")
            If Progress IsNot Nothing Then Progress.Report(Response)


            IntProgress = New Progress(Of Integer)

            AddHandler IntProgress.ProgressChanged, Sub(sender As Object, Percent As Integer)
                                                        Response.Percent = Percent
                                                        Response.Text = $"Restaurando Backup: Restaurando o banco de dados ({Percent}%)"
                                                        If Progress IsNot Nothing Then Progress.Report(Response)
                                                    End Sub

            Await _DatabaseService.ExecuteRestoreAsync(Path.Combine(RestoreDirectory, "Database", "Database.sql"), IntProgress)


            Await Task.Delay(Constants.WaitForJob)

            Response.Percent = 0
            Response.Text = "Restaurando Backup: Excluindo arquivos temporários"
            Response.Event.AddChildEvent("Excluindo arquivos temporários")
            If Progress IsNot Nothing Then Progress.Report(Response)


            FileManager = New FileManager
            AddHandler FileManager.DeleteDirectoriesProgressChanged, Sub(IOSender, IOEventArgs)
                                                                         Response.Percent = IOEventArgs.PercentCompleted
                                                                         Response.Text = $"Restaurando Backup: Excluindo arquivos temporários ({IOEventArgs.PercentCompleted}%)"
                                                                         If Progress IsNot Nothing Then Progress.Report(Response)
                                                                     End Sub





            Await FileManager.DeleteDirectoriesAsync(New List(Of DeleteDirectoryInfo) From {New DeleteDirectoryInfo(New DirectoryInfo(RestoreDirectory), True)})
            Await Task.Delay(Constants.WaitForJob)

            Response.Percent = 0
            Response.Text = $"Restaurando Backup: Concluído - {Filename}"
            Response.Event.SetFinalEvent($"Restaurando Backup: Concluído - {Filename}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)

        Catch ex As Exception
            Exception = ex

        End Try
        If Exception IsNot Nothing Then
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = $"Restaurando Backup: Ocorreu um erro ao restaurar o backup - {Filename} - {Exception.Message}"
            Response.Event.AddChildEvent($"Restaurando Backup: Ocorreu um erro ao restaurar o backup - {Filename} - {Exception.Message}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Directory.Exists(RestoreDirectory) Then Directory.Delete(RestoreDirectory, True)
            Response.Text = $"Restaurando Backup: Concluído - {Filename}"
            Response.Event.SetFinalEvent($"Restaurando Backup: Concluído - {Filename}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function
End Class
