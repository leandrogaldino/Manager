Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.FileManager
Imports ManagerCore
Imports MySqlController

Public Class TaskRestoreBackup
    Inherits TaskBase
    Private ReadOnly _LocalDb As MySqlService
    Private ReadOnly _CryptoKeyService As CryptoKeyService
    Public Sub New(CompanyModel As CompanyModel, LocalDb As MySqlService, CryptoKeyService As CryptoKeyService)
        MyBase.New(CompanyModel)
        _LocalDb = LocalDb
        _CryptoKeyService = CryptoKeyService
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
        Dim DatabaseDirectory As String = String.Empty
        Dim FileManager As FileManager
        Dim IntProgress As Progress(Of Integer)
        Dim Exception As Exception = Nothing
        Dim TargetDirectory As String = ApplicationPaths.FilesDirectory
        Dim BackupLocation As String = BackupFile.FilePath
        Dim Filename As String = New FileInfo(BackupLocation).Name.Replace(".bkp", Nothing).Replace("-", "/").Replace(".", ":")
        Try
            Response.Text = $"Restaurar Backup: Iniciando - {Filename}"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForStart)
            Response.Text = "Restaurar Backup: Removendo a versão atual"
            If Progress IsNot Nothing Then Progress.Report(Response)
            FileManager = New FileManager
            AddHandler FileManager.DeleteDirectoriesProgressChanged, Sub(IOSender, IOEventArgs)
                                                                         Response.Percent = IOEventArgs.PercentCompleted
                                                                         Response.Text = $"Restaurar Backup: Removendo a versão atual ({IOEventArgs.PercentCompleted}%)"
                                                                         If Progress IsNot Nothing Then Progress.Report(Response)
                                                                     End Sub
            Await FileManager.DeleteDirectoriesAsync(New List(Of DeleteDirectoryInfo) From {
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.ProductPictureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationPictureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationSignatureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.RequestDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EmailSignatureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.CashDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.HelpersDirectory), True)
            })
            Response.Percent = 0
            Response.Text = "Restaurar Backup: Validando diretórios"
            If Not Directory.Exists(ApplicationPaths.ProductPictureDirectory) Then Directory.CreateDirectory(ApplicationPaths.ProductPictureDirectory)
            Response.Percent = 14
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Not Directory.Exists(ApplicationPaths.EvaluationDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.EvaluationDocumentDirectory)
            Response.Percent = 29
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Not Directory.Exists(ApplicationPaths.EvaluationPictureDirectory) Then Directory.CreateDirectory(ApplicationPaths.EvaluationPictureDirectory)
            Response.Percent = 43
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Not Directory.Exists(ApplicationPaths.RequestDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.RequestDocumentDirectory)
            Response.Percent = 58
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Not Directory.Exists(ApplicationPaths.EmailSignatureDirectory) Then Directory.CreateDirectory(ApplicationPaths.EmailSignatureDirectory)
            Response.Percent = 72
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Not Directory.Exists(ApplicationPaths.CashDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.CashDocumentDirectory)
            Response.Percent = 87
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Not Directory.Exists(ApplicationPaths.HelpersDirectory) Then Directory.CreateDirectory(ApplicationPaths.HelpersDirectory)
            Response.Percent = 100
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Restaurar Backup: Processando os dados"
            If Progress IsNot Nothing Then Progress.Report(Response)
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Restaurar Backup: Processando os dados ({Percent}%)"
                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                   End Sub)
            Await FileMerge.UnMergeAsync(BackupLocation, TargetDirectory, _CryptoKeyService.ReadCryptoKey, IntProgress)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Restaurar Backup: Processando o banco de dados"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await _LocalDb.Request.ExecuteProcedureAsync("DropAllTables")
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Restaurar Backup: Processando o banco de dados ({Percent}%)"
                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                   End Sub)

            DatabaseDirectory = Path.Combine(ApplicationPaths.FilesDirectory, "Database")
            Await _LocalDb.Maintenance.ExecuteRestoreAsync(Path.Combine(DatabaseDirectory, "Database.sql"), IntProgress)
            Await FileManager.DeleteDirectoriesAsync(New List(Of DeleteDirectoryInfo) From {New DeleteDirectoryInfo(New DirectoryInfo(DatabaseDirectory), True)})
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = $"Restaurar Backup: Concluído - {Filename}"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        Catch ex As Exception
            Exception = ex
        End Try
        If Exception IsNot Nothing Then
            Response.Percent = 0
            Response.Text = "Restaurar Backup: Erro na execução"
            Response.Percent = 0
            Response.Event.EndTime = DateTime.Now
            Response.Event.Description = "Restaurar Backup"
            Response.Event.Status = TaskStatus.Error
            Response.Event.ExceptionMessage = $"{Exception.Message}{vbNewLine}{Exception.StackTrace}"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = "Restaurar Backup: Concluído"
            Response.Event.ReadyToPost = True
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function
End Class
