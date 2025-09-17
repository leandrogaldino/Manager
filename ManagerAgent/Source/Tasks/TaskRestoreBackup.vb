Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.FileManager
Imports ManagerCore

Public Class TaskRestoreBackup
    Inherits TaskBase
    Private ReadOnly _DatabaseService As LocalDB
<<<<<<< Updated upstream

    Public Sub New(DatabaseService As LocalDB)
        _DatabaseService = DatabaseService

=======
    Private ReadOnly _SessionModel As SessionModel
    Public Sub New(DatabaseService As LocalDB, SessionModel As SessionModel)
        _DatabaseService = DatabaseService
        _SessionModel = SessionModel
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        Dim RestoreDirectory As String
=======
>>>>>>> Stashed changes
        Dim Directories As New List(Of DeleteDirectoryInfo)
        Dim FileManager As FileManager
        Dim IntProgress As Progress(Of Integer)
        Dim Exception As Exception = Nothing
        Dim DatabaseDirectory As String
        BackupLocation = BackupFile.FilePath
        Dim Filename As String = New FileInfo(BackupLocation).Name.Replace(".bkp", Nothing).Replace("-", "/").Replace(".", ":")
        Try
            Response.Text = $"Restaurando Backup: Iniciando - {Filename}"
            Response.Event.SetInitialEvent($"Restaurando Backup: Iniciando - {Filename}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForStart)
<<<<<<< Updated upstream



            Response.Text = "Restaurando Backup: Extraindo arquivos"
            Response.Event.AddChildEvent("Extraindo arquivos")
            If Progress IsNot Nothing Then Progress.Report(Response)



            IntProgress = New Progress(Of Integer)

            AddHandler IntProgress.ProgressChanged, Sub(sender As Object, Percent As Integer)
                                                        Response.Percent = Percent
                                                        Response.Text = $"Restaurando Backup: Descompactando arquivos ({Percent}%)"
                                                        If Progress IsNot Nothing Then Progress.Report(Response)
                                                    End Sub






            Await Task.Delay(Constants.WaitForJob)
=======
>>>>>>> Stashed changes
            Response.Percent = 0
            Response.Text = "Restaurando Backup: Excluindo arquivos da versão atual"
            Response.Event.AddChildEvent("Excluindo arquivos da versão atual")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Directories.AddRange({
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.ProductPictureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationPictureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationSignatureDirectory), True),
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
            If Not Directory.Exists(ApplicationPaths.ProductPictureDirectory) Then Directory.CreateDirectory(ApplicationPaths.ProductPictureDirectory)
            If Not Directory.Exists(ApplicationPaths.EvaluationDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.EvaluationDocumentDirectory)
            If Not Directory.Exists(ApplicationPaths.EvaluationPictureDirectory) Then Directory.CreateDirectory(ApplicationPaths.EvaluationPictureDirectory)
            If Not Directory.Exists(ApplicationPaths.EvaluationSignatureDirectory) Then Directory.CreateDirectory(ApplicationPaths.EvaluationSignatureDirectory)
            If Not Directory.Exists(ApplicationPaths.RequestDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.RequestDocumentDirectory)
            If Not Directory.Exists(ApplicationPaths.EmailSignatureDirectory) Then Directory.CreateDirectory(ApplicationPaths.EmailSignatureDirectory)
            If Not Directory.Exists(ApplicationPaths.CashDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.CashDocumentDirectory)
            If Not Directory.Exists(ApplicationPaths.HelpersDirectory) Then Directory.CreateDirectory(ApplicationPaths.HelpersDirectory)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Restaurando Backup: Processando os dados"
            Response.Event.AddChildEvent("Processando os dados")
            If Progress IsNot Nothing Then Progress.Report(Response)
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Restaurando Backup: Processando os dados ({Percent}%)"
                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                   End Sub)
            Await FileMerge.UnMergeAsync(BackupLocation, ApplicationPaths.FilesDirectory, _SessionModel.ZipPassword, IntProgress)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Restaurando Backup: Restaurando o banco de dados"
            Response.Event.AddChildEvent("Restaurando o banco de dados")
            If Progress IsNot Nothing Then Progress.Report(Response)
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Restaurando Backup: Restaurando o banco de dados ({Percent}%)"
                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                   End Sub)
            DatabaseDirectory = Path.Combine(ApplicationPaths.FilesDirectory, "Database")
            Await _DatabaseService.ExecuteRestoreAsync(Path.Combine(DatabaseDirectory, "Database.sql"), IntProgress)
            Await FileManager.DeleteDirectoriesAsync(New List(Of DeleteDirectoryInfo) From {
                New DeleteDirectoryInfo(New DirectoryInfo(DatabaseDirectory), True)
            })
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
            Response.Text = $"Restaurando Backup: Concluído - {Filename}"
            Response.Event.SetFinalEvent($"Restaurando Backup: Concluído - {Filename}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function
End Class
