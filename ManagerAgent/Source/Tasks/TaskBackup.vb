Imports System.IO
Imports ControlLibrary
Imports ManagerCore

Public Class TaskBackup
    Inherits TaskBase
    Private ReadOnly _DatabaseService As LocalDB
    Private ReadOnly _SettingsService As CompanyService
    Private ReadOnly _SessionModel As SessionModel
    Public Sub New(DatabaseService As LocalDB, SettingsService As CompanyService, SessionModel As SessionModel)
        _DatabaseService = DatabaseService
        _SettingsService = SettingsService
        _SessionModel = SessionModel
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
                Dim BackupTime As TimeSpan = _SessionModel.ManagerSetting.Backup.Time
                Dim LastBackup As Date = _SessionModel.ManagerSetting.LastExecution.Backup
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
            Return _SessionModel.ManagerSetting.LastExecution.Backup
        End Get
    End Property

    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property

    Private Function GetBackupDays() As Boolean()
        Dim Sunday As Boolean = _SessionModel.ManagerSetting.Backup.Sunday
        Dim Monday As Boolean = _SessionModel.ManagerSetting.Backup.Monday
        Dim Tuesday As Boolean = _SessionModel.ManagerSetting.Backup.Tuesday
        Dim Wednesday As Boolean = _SessionModel.ManagerSetting.Backup.Wednesday
        Dim Thursday As Boolean = _SessionModel.ManagerSetting.Backup.Thursday
        Dim Friday As Boolean = _SessionModel.ManagerSetting.Backup.Friday
        Dim Saturday As Boolean = _SessionModel.ManagerSetting.Backup.Saturday
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
            Await _DatabaseService.ExecuteBackupAsync(Path.Combine(TempDatabaseDirectory, "Database.sql"), IntProgress)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            FileName = $"Backup {DateTimeHelper.Now:dd-MM-yyyy HH.mm.ss}.bkp"
            BackupDir = New DirectoryInfo(_SessionModel.ManagerSetting.Backup.Location)
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
            Await FileMerge.MergeAsync(Path.Combine(BackupDir.FullName, FileName), TargetList, _SessionModel.ManagerPassword, IntProgress)
            Await FileManager.DeleteDirectoriesAsync(New List(Of FileManager.DeleteDirectoryInfo) From {New FileManager.DeleteDirectoryInfo(New DirectoryInfo(TempDatabaseDirectory), True)})
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            If Progress IsNot Nothing Then Progress.Report(Response)
            BackupDir = New DirectoryInfo(_SessionModel.ManagerSetting.Backup.Location)
            Files = Util.GetBackupFiles()
            If Files.Count > 0 Then
                AddHandler FileManager.DeleteFilesProgressChanged, Sub(IOSender, IOEventArgs)
                                                                       Response.Percent = IOEventArgs.PercentCompleted
                                                                       Response.Text = $"Backup: Excluindo backups obsoletos ({IOEventArgs.PercentCompleted}%)"
                                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                                   End Sub
                Files = Files.Take(Files.Count - _SessionModel.ManagerSetting.Backup.Keep).ToList
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
            If Not IsManual Then _SessionModel.ManagerSetting.Backup.IgnoreNext = False
            If Not IsManual Then _SessionModel.ManagerSetting.LastExecution.Backup = Now
            If Not IsManual Then _SettingsService.Save(_SessionModel.ManagerSetting)
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
