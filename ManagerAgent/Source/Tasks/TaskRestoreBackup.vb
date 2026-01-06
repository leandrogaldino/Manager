Imports System.IO
Imports CoreSuite.Services
Imports CoreSuite.Services.FileManager
Imports ManagerCore

Public Class TaskRestoreBackup
    Inherits TaskBase
    Private ReadOnly _LocalDb As MySqlService
    Private ReadOnly _CryptoKeyService As CryptoKeyService
    Public Sub New(LocalDb As MySqlService, CryptoKeyService As CryptoKeyService)
        MyBase.New()
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
        Dim IntProgress As Progress(Of Integer)
        Dim Exception As Exception = Nothing
        Dim TargetDirectory As String = ApplicationPaths.FilesDirectory
        Dim BackupLocation As String = BackupFile.FilePath
        Dim Filename As String = New FileInfo(BackupLocation).Name.Replace(".bkp", Nothing).Replace("-", "/").Replace(".", ":")
        Try
            Response.Text = $"Restaurar Backup: Iniciando - {Filename}"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForStart)
            Response.Text = "Restaurar Backup: Removendo a versão atual"
            Progress?.Report(Response)
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Restaurar Backup: Removendo a versão atual ({Percent}%)"
                                                       Progress?.Report(Response)
                                                   End Sub)
            Await DeleteDirectoriesAsync({
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.ProductPictureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationPictureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationSignatureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.RequestDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.EmailSignatureDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.CashDocumentDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.DataDirectory), True),
                New DeleteDirectoryInfo(New DirectoryInfo(ApplicationPaths.LogoDirectory), True)
            }.ToList(), IntProgress)

            Response.Percent = 0
            Response.Text = "Restaurar Backup: Validando diretórios"
            If Not Directory.Exists(ApplicationPaths.ProductPictureDirectory) Then Directory.CreateDirectory(ApplicationPaths.ProductPictureDirectory)
            Response.Percent = 12
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            If Not Directory.Exists(ApplicationPaths.EvaluationDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.EvaluationDocumentDirectory)
            Response.Percent = 25
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            If Not Directory.Exists(ApplicationPaths.EvaluationPictureDirectory) Then Directory.CreateDirectory(ApplicationPaths.EvaluationPictureDirectory)
            Response.Percent = 37
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            If Not Directory.Exists(ApplicationPaths.RequestDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.RequestDocumentDirectory)

            Response.Percent = 50
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            If Not Directory.Exists(ApplicationPaths.EmailSignatureDirectory) Then Directory.CreateDirectory(ApplicationPaths.EmailSignatureDirectory)
            Response.Percent = 62
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            If Not Directory.Exists(ApplicationPaths.CashDocumentDirectory) Then Directory.CreateDirectory(ApplicationPaths.CashDocumentDirectory)
            Response.Percent = 75
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            If Not Directory.Exists(ApplicationPaths.DataDirectory) Then Directory.CreateDirectory(ApplicationPaths.DataDirectory)
            Response.Percent = 87
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            If Not Directory.Exists(ApplicationPaths.DataDirectory) Then Directory.CreateDirectory(ApplicationPaths.LogoDirectory)
            Response.Percent = 100
            Response.Text = $"Restaurar Backup: Validando diretórios ({Response.Percent}%)"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)




            Response.Percent = 0
            Response.Text = "Restaurar Backup: Processando os dados"
            Progress?.Report(Response)
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Restaurar Backup: Processando os dados ({Percent}%)"
                                                       Progress?.Report(Response)
                                                   End Sub)
            Await FileMerger.UnMergeAsync(BackupLocation, TargetDirectory, _CryptoKeyService.ReadCryptoKey, IntProgress)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Restaurar Backup: Processando o banco de dados"
            Progress?.Report(Response)
            Await _LocalDb.Request.ExecuteProcedureAsync("DropAllTables")
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Restaurar Backup: Processando o banco de dados ({Percent}%)"
                                                       Progress?.Report(Response)
                                                   End Sub)

            DatabaseDirectory = Path.Combine(ApplicationPaths.FilesDirectory, "Database")
            Await _LocalDb.Maintenance.ExecuteRestoreAsync(Path.Combine(DatabaseDirectory, "Database.sql"), IntProgress)
            Await DeleteDirectoriesAsync(New List(Of DeleteDirectoryInfo) From {New DeleteDirectoryInfo(New DirectoryInfo(DatabaseDirectory), True)})
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = $"Restaurar Backup: Concluído - {Filename}"
            Progress?.Report(Response)
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
