Imports System.IO
Imports ControlLibrary
Imports ManagerCore
Imports MySqlController
Imports Helpers

Public Class TaskBackup
    Inherits TaskBase
    Private ReadOnly _LocalDb As MySqlService
    Private ReadOnly _CompanyService As CompanyService
    Private ReadOnly _CryptoKeyService As CryptoKeyService
    Public Sub New(CompanyModel As CompanyModel, LocalDb As MySqlService, CompanyService As CompanyService, CryptoKeyService As CryptoKeyService)
        MyBase.New(CompanyModel)
        _LocalDb = LocalDb
        _CompanyService = CompanyService
        _CryptoKeyService = CryptoKeyService
    End Sub
    Public Overrides ReadOnly Property Name As TaskName
        Get
            Return TaskName.Backup
        End Get
    End Property

    Public Overrides Property NextRun As Date
        Get
            Dim BackupDays As Boolean() = GetBackupDays()
            If GetBackupDays.Where(Function(Day) Day).Count > 0 Then
                Dim BackupTime As TimeSpan = Company.Backup.Time
                Dim LastBackup As Date = Company.LastExecution.Backup
                Dim NextAvailableDay As Date = GetNextAvailableDay(LastBackup, BackupDays, BackupTime)
                If IsManual Then
                    Return MyBase.NextRun
                Else
                    Return NextAvailableDay
                End If
            End If

            Return Nothing
        End Get
        Set(value As Date)
            MyBase.NextRun = value
        End Set
    End Property

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides Property IsRunNeeded As Boolean
        Get
            If IsManual Then
                Return MyBase.IsRunNeeded
            Else
                If NextRun <> Nothing Then
                    Return NextRun <= Now
                Else
                    Return False
                End If

            End If
        End Get
        Set(value As Boolean)
            MyBase.IsRunNeeded = value
        End Set
    End Property
    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return Company.LastExecution.Backup
        End Get
    End Property

    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property

    Private Function GetBackupDays() As Boolean()
        Dim Sunday As Boolean = Company.Backup.Sunday
        Dim Monday As Boolean = Company.Backup.Monday
        Dim Tuesday As Boolean = Company.Backup.Tuesday
        Dim Wednesday As Boolean = Company.Backup.Wednesday
        Dim Thursday As Boolean = Company.Backup.Thursday
        Dim Friday As Boolean = Company.Backup.Friday
        Dim Saturday As Boolean = Company.Backup.Saturday
        Return {Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday}
    End Function

    Function GetNextAvailableDay(LastBackup As Date, WeekDays As Boolean(), BackupTime As TimeSpan) As Date
        Dim LastBackupWeekDay As Integer = LastBackup.DayOfWeek
        Dim LastBackupWithTime As New DateTime(LastBackup.Year, LastBackup.Month, LastBackup.Day, BackupTime.Hours, BackupTime.Minutes, BackupTime.Seconds)
        If WeekDays(LastBackupWeekDay) And LastBackupWithTime > LastBackup Then
            Return LastBackupWithTime
        End If
        For i As Integer = 0 To WeekDays.Length - 1
            Dim WeekDay As Integer = (LastBackup.DayOfWeek + i + 1) Mod 7
            If WeekDays(WeekDay) Then
                Dim NextAvailableDay = LastBackup.AddDays(i + 1).Date.Add(BackupTime)
                Return NextAvailableDay
            End If
        Next
        Return Nothing
    End Function
    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Response As New AsyncResponseModel
        Dim IntProgress As Progress(Of Integer)
        Dim FileName As String
        Dim BackupDir As DirectoryInfo
        Dim Exception As Exception = Nothing
        Dim Files As List(Of FileInfo)
        Dim FileManager As New FileManager
        Dim TempDatabaseDirectory As String
        Dim TargetList As List(Of String)
        Try
            Response.Text = $"Backup: Iniciando"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForStart)
            If Progress IsNot Nothing Then Progress.Report(Response)
            IntProgress = New Progress(Of Integer)(Sub(Percent As Integer)
                                                       Response.Percent = Percent
                                                       Response.Text = $"Backup: Processando banco de dados ({Percent}%)"
                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                   End Sub)
            TempDatabaseDirectory = Path.Combine(ApplicationPaths.AgentTempDirectory, "Database")
            If Not Directory.Exists(TempDatabaseDirectory) Then Directory.CreateDirectory(TempDatabaseDirectory)
            Await _LocalDb.Maintenance.ExecuteBackupAsync(Path.Combine(TempDatabaseDirectory, "Database.sql"), IntProgress)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            FileName = $"Backup {DateTimeHelper.Now:dd-MM-yyyy HH.mm.ss}.bkp"
            BackupDir = New DirectoryInfo(Company.Backup.Location)
            TargetList = New List(Of String) From {
                ApplicationPaths.CashDocumentDirectory,
                ApplicationPaths.EmailSignatureDirectory,
                ApplicationPaths.EvaluationDocumentDirectory,
                ApplicationPaths.EvaluationPictureDirectory,
                ApplicationPaths.EvaluationSignatureDirectory,
                ApplicationPaths.HelpersDirectory,
                ApplicationPaths.ProductPictureDirectory,
                ApplicationPaths.RequestDocumentDirectory,
                TempDatabaseDirectory
            }
            IntProgress = New Progress(Of Integer)(Sub(p)
                                                       Response.Percent = p
                                                       Response.Text = $"Backup: Processando arquivos ({p}%)"
                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                   End Sub)
            Await FileMerge.MergeAsync(Path.Combine(BackupDir.FullName, FileName), TargetList, _CryptoKeyService.ReadCryptoKey, IntProgress)
            Await FileManager.DeleteDirectoriesAsync(New List(Of FileManager.DeleteDirectoryInfo) From {New FileManager.DeleteDirectoryInfo(New DirectoryInfo(TempDatabaseDirectory), True)})
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            If Progress IsNot Nothing Then Progress.Report(Response)
            BackupDir = New DirectoryInfo(Company.Backup.Location)
            Files = Util.GetBackupFiles(Company)
            If Files.Count > 0 Then
                AddHandler FileManager.DeleteFilesProgressChanged, Sub(IOSender, IOEventArgs)
                                                                       Response.Percent = IOEventArgs.PercentCompleted
                                                                       Response.Text = $"Backup: Excluindo backups obsoletos ({IOEventArgs.PercentCompleted}%)"
                                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                                   End Sub
                Files = Files.Take(Files.Count - Company.Backup.Keep).ToList
                Await FileManager.DeleteFilesAsync(Files)
            End If
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = $"Backup: Concluído"
            Response.Event.EndTime = DateTime.Now
            Response.Event.ReadyToPost = True
            Response.Event.Description = $"Backup{If(Not IsManual, String.Empty, " Manual")}"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        Catch ex As Exception
            Exception = ex
        Finally
            If Not IsManual Then Company.Backup.IgnoreNext = False
            If Not IsManual Then Company.LastExecution.Backup = Now
            If Not IsManual Then _CompanyService.Save(Company)
        End Try
        If Exception IsNot Nothing Then
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Backup: Erro na execução"
            Response.Event.EndTime = DateTime.Now
            Response.Event.Description = $"Backup{If(Not IsManual, String.Empty, " Manual")}"
            Response.Event.Status = TaskStatus.Error
            Response.Event.ExceptionMessage = $"{Exception.Message}{vbNewLine}{Exception.StackTrace}"
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = $"Backup: Concluído"
            Response.Event.ReadyToPost = True
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function
End Class
