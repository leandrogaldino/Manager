Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.FileManager
Imports ManagerCore

Public Class TaskBackup
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
        Dim TempBackupDirectory As String
        Dim FileName As String
        Dim BackupDir As DirectoryInfo
        Dim Files As New List(Of FileInfo)
        Dim FileManager As FileManager
        Dim FileManagerCopyInfo As List(Of CopyDirectoryInfo)
        Dim Exception As Exception = Nothing
        Try
            Response.Text = $"Criando Backup {If(Not IsManual, "Automático", "Manual")}: Iniciando"
            Response.Event.SetInitialEvent($"Backup {If(Not IsManual, "Automático", "Manual")}: Iniciando")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForStart)
            If Not Directory.Exists(ApplicationPaths.AgentTempDirectory) Then Directory.CreateDirectory(ApplicationPaths.AgentTempDirectory)
            FileName = "Backup " & Now.ToString("dd-MM-yyyy HH.mm.ss")
            TempBackupDirectory = Path.Combine(ApplicationPaths.AgentTempDirectory, FileName)
            If Not Directory.Exists(TempBackupDirectory) Then Directory.CreateDirectory(TempBackupDirectory)
            FileManager = New FileManager()
            FileManagerCopyInfo = New List(Of CopyDirectoryInfo) From {
                New CopyDirectoryInfo(New DirectoryInfo(ApplicationPaths.ProductPictureDirectory), New DirectoryInfo(Path.Combine(TempBackupDirectory, BackupDirectories.ProductPicture.ToString))),
                New CopyDirectoryInfo(New DirectoryInfo(ApplicationPaths.EvaluationDocumentDirectory), New DirectoryInfo(Path.Combine(TempBackupDirectory, BackupDirectories.EvaluationDocument.ToString))),
                New CopyDirectoryInfo(New DirectoryInfo(ApplicationPaths.RequestDocumentDirectory), New DirectoryInfo(Path.Combine(TempBackupDirectory, BackupDirectories.RequestDocument.ToString))),
                New CopyDirectoryInfo(New DirectoryInfo(ApplicationPaths.EmailSignatureDirectory), New DirectoryInfo(Path.Combine(TempBackupDirectory, BackupDirectories.EmailSignature.ToString))),
                New CopyDirectoryInfo(New DirectoryInfo(ApplicationPaths.CashDocumentDirectory), New DirectoryInfo(Path.Combine(TempBackupDirectory, BackupDirectories.CashDocument.ToString))),
                New CopyDirectoryInfo(New DirectoryInfo(ApplicationPaths.HelpersDirectory), New DirectoryInfo(Path.Combine(TempBackupDirectory, BackupDirectories.Helpers.ToString)))
            }
            Response.Text = "Criando arquivos temporários"
            Response.Event.AddChildEvent($"Criando Backup: Criando arquivos temporários")
            If Progress IsNot Nothing Then Progress.Report(Response)
            FileManager = New FileManager

            AddHandler FileManager.CopyDirectoryProgressChanged, Sub(IOSender, IOEventArgs)
                                                                     Response.Percent = IOEventArgs.PercentCompleted
                                                                     Response.Text = $"Criando Backup: Criando arquivos temporários ({IOEventArgs.PercentCompleted}%)"
                                                                     If Progress IsNot Nothing Then Progress.Report(Response)
                                                                 End Sub


            Await FileManager.CopyDirectoriesAsync(FileManagerCopyInfo)

            Await Task.Delay(Constants.WaitForJob)



            Response.Text = $"Criando Backup: Copiando o banco de dados"
            Response.Event.AddChildEvent($"Copiando o banco de dados")

            If Progress IsNot Nothing Then Progress.Report(Response)

            IntProgress = New Progress(Of Integer)

            AddHandler IntProgress.ProgressChanged, Sub(sender As Object, Percent As Integer)
                                                        Response.Percent = Percent
                                                        Response.Text = $"Criando Backup: Copiando o banco de dados ({Percent}%)"
                                                        If Progress IsNot Nothing Then Progress.Report(Response)
                                                    End Sub

            Await _DatabaseService.ExecuteBackup(Path.Combine(TempBackupDirectory, "Database.sql"), IntProgress)

            Await Task.Delay(Constants.WaitForJob)

            Response.Percent = 0
            Response.Text = "Criando Backup: Compactando arquivos"
            Response.Event.AddChildEvent("Compactando arquivos")
            If Progress IsNot Nothing Then Progress.Report(Response)

            Dim Compression As CompressionService = Locator.GetInstance(Of ICompression)


            IntProgress = New Progress(Of Integer)

            AddHandler IntProgress.ProgressChanged, Sub(sender As Object, Percent As Integer)
                                                        Response.Percent = Percent
                                                        Response.Text = $"Criando Backup: Compactando arquivos ({Percent}%)"
                                                        If Progress IsNot Nothing Then Progress.Report(Response)
                                                    End Sub

            Await Compression.Compress(TempBackupDirectory, $"{TempBackupDirectory}.bkp", _SessionModel.ZipPassword, IntProgress)

            Await Task.Delay(Constants.WaitForJob)



            Response.Text = "Criando Backup: Copiando o backup para a pasta definitiva"
            Response.Event.AddChildEvent("Copiando o backup para a pasta definitiva")
            Response.Percent = 0

            If Progress IsNot Nothing Then Progress.Report(Response)



            If Not Directory.Exists(_SessionModel.ManagerSetting.Backup.Location) Then Directory.CreateDirectory(_SessionModel.ManagerSetting.Backup.Location)



            FileManager = New FileManager
            AddHandler FileManager.CopyFileProgressChanged, Sub(IOSender, IOEventArgs)
                                                                Response.Percent = IOEventArgs.PercentCompleted
                                                                Response.Text = $"Criando Backup: Copiando o backup para a pasta definitiva ({IOEventArgs.PercentCompleted}%)"
                                                                If Progress IsNot Nothing Then Progress.Report(Response)
                                                            End Sub



            Await FileManager.CopyFileAsync(New FileInfo($"{TempBackupDirectory}.bkp"), New FileInfo(Path.Combine(_SessionModel.ManagerSetting.Backup.Location, $"{FileName}.bkp")))


            Await Task.Delay(Constants.WaitForJob)


            Response.Percent = 0
            Response.Text = "Criando Backup: Excluindo arquivos temporários"
            Response.Event.AddChildEvent("Excluindo arquivos temporários")
            If Progress IsNot Nothing Then Progress.Report(Response)


            FileManager = New FileManager
            AddHandler FileManager.DeleteDirectoriesProgressChanged, Sub(IOSender, IOEventArgs)
                                                                         Response.Percent = IOEventArgs.PercentCompleted
                                                                         Response.Text = $"Criando Backup: Excluindo arquivos temporários ({IOEventArgs.PercentCompleted}%)"
                                                                         If Progress IsNot Nothing Then Progress.Report(Response)
                                                                     End Sub

            Await FileManager.DeleteDirectoriesAsync(New List(Of DeleteDirectoryInfo) From {New DeleteDirectoryInfo With {.Directory = New DirectoryInfo(TempBackupDirectory)}})

            Await FileManager.DeleteFilesAsync({New FileInfo($"{TempBackupDirectory}.bkp")}.ToList)


            Await Task.Delay(Constants.WaitForJob)


            Response.Percent = 0
            Response.Text = "Criando Backup: Excluindo backups obsoletos"
            Response.Event.AddChildEvent("Excluindo backups obsoletos")
            If Progress IsNot Nothing Then Progress.Report(Response)

            BackupDir = New DirectoryInfo(_SessionModel.ManagerSetting.Backup.Location)
            Files = Util.GetBackupFiles()




            If Files.Count > 0 Then

                AddHandler FileManager.DeleteFilesProgressChanged, Sub(IOSender, IOEventArgs)
                                                                       Response.Percent = IOEventArgs.PercentCompleted
                                                                       Response.Text = $"Criando Backup: Excluindo backups obsoletos ({IOEventArgs.PercentCompleted}%)"
                                                                       If Progress IsNot Nothing Then Progress.Report(Response)
                                                                   End Sub
                Files = Files.Take(Files.Count - _SessionModel.ManagerSetting.Backup.Keep).ToList


                Await FileManager.DeleteFilesAsync(Files)


            End If
            Await Task.Delay(Constants.WaitForJob)


            Response.Percent = 0
            Response.Text = $"Criando Backup: Backup {If(Not IsManual, "automático", "manual")} concluído"
            Response.Event.SetFinalEvent($"Backup {If(Not IsManual, "automático", "manual")} concluído")
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
            Response.Text = $"Criando Backup: Ocorreu um erro executar o backup - {Exception.Message}"
            Response.Event.AddChildEvent($"Ocorreu um erro executar o backup - {Exception.Message}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = $"Criando Backup: Backup {If(Not IsManual, "automático", "manual")} concluído"
            Response.Event.SetFinalEvent($"Backup {If(Not IsManual, "automático", "manual")} concluído")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If

    End Function

End Class
