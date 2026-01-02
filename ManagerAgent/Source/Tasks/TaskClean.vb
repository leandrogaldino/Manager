Imports System.Data.Common
Imports System.IO
Imports System.Transactions
Imports ControlLibrary
Imports ManagerCore
Imports MySqlController
Public Class TaskClean
    Inherits TaskBase
    Private ReadOnly _LocalDb As MySqlService
    Private ReadOnly _CompanyService As CompanyService
    Public Sub New(CompanyModel As CompanyModel, LocalDb As MySqlService, CompanyService As CompanyService)
        MyBase.New(CompanyModel)
        _LocalDb = LocalDb
        _CompanyService = CompanyService
    End Sub
    Public Overrides ReadOnly Property Name As TaskName
        Get
            Return TaskName.Clean
        End Get
    End Property

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return Company.General.Clean.Interval * (24 * 60)
        End Get
    End Property

    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return Company.LastExecution.Clean
        End Get
    End Property

    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Response As New AsyncResponseModel
        Dim Month As Integer
        Dim MonthStr As String
        Dim IddleFiles As New List(Of String)
        Dim Files As New List(Of FileInfo)
        Dim Directories As New List(Of DirectoryInfo)
        Dim Result As MySqlResponse
        Dim ResultDate As Date
        Dim EvaluationDocumentDir As DirectoryInfo
        Dim EmailSignatureDir As DirectoryInfo
        Dim RequestDocumentDir As DirectoryInfo
        Dim ProductPictureDir As DirectoryInfo
        Dim CashDocumentDir As DirectoryInfo
        Dim FileCount As Long
        Dim CurrentRow As Long
        Dim AllRows As Long
        Dim FileManager As FileManager
        Dim TempDirectories As List(Of FileManager.DeleteDirectoryInfo)
        Dim Exception As Exception = Nothing
        Try
            Response.Text = "Limpeza: Iniciando"
            Progress?.Report(Response)
            EvaluationDocumentDir = New DirectoryInfo(ApplicationPaths.EvaluationDocumentDirectory)
            EmailSignatureDir = New DirectoryInfo(ApplicationPaths.EmailSignatureDirectory)
            RequestDocumentDir = New DirectoryInfo(ApplicationPaths.RequestDocumentDirectory)
            ProductPictureDir = New DirectoryInfo(ApplicationPaths.ProductPictureDirectory)
            CashDocumentDir = New DirectoryInfo(ApplicationPaths.CashDocumentDirectory)
            FileCount = EvaluationDocumentDir.GetFiles().Count() + EmailSignatureDir.GetDirectories().Count() + RequestDocumentDir.GetFiles().Count() + ProductPictureDir.GetFiles().Count() + CashDocumentDir.GetFiles().Count()
            Await Task.Delay(Constants.WaitForStart)
            Month = Company.General.Evaluation.MonthsBeforeRecordDeletion
            MonthStr = If(Month = 1, $"{Month} mês", $"{Month} meses")
            ResultDate = Today.AddMonths(-Month)
            Result = Await _LocalDb.Request.ExecuteSelectAsync("evaluation", New MysqlSelectOptions() With {
                .Columns = {"id", "evaluationdate", "customerid"}.ToList,
                .Where = "evaluationdate <= @evaluationdate",
                .QueryArgs = New Dictionary(Of String, Object) From {{"@evaluationdate", ResultDate.ToString("yyyy-MM-dd")}}
            })
            AllRows = Result.Data.Count
            Response.Text = $"Limpeza: Verificando se há avaliações antigas ({MonthStr})"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            Dim Connection As DbConnection = _LocalDb.Client.CreateDatabaseConnection()



            For Each Entry In Result.Data
                Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                    Dim AgentID As Long = (Await _LocalDb.Request.ExecuteSelectAsync("user", New MysqlSelectOptions() With {
                      .Columns = {"id"}.ToList,
                      .Where = "username = @username",
                      .QueryArgs = New Dictionary(Of String, Object) From {{"@username", "SISTEMA"}},
                      .Limit = 1
                    })).Data(0)("id")
                    Await _LocalDb.Request.ExecuteUpdateAsync("evaluation",
                                                              New Dictionary(Of String, String) From {{"userid", "@userid"}},
                                                              "id = @id",
                                                              New Dictionary(Of String, Object) From {{"@id", Entry("id")}, {"@userid", AgentID}},
                                                              Connection)
                    Await _LocalDb.Request.ExecuteUpdateAsync("evaluationcontrolledsellable",
                                                              New Dictionary(Of String, String) From {{"userid", "@userid"}},
                                                              "evaluationid = @evaluationid",
                                                              New Dictionary(Of String, Object) From {{"@evaluationid", Entry("id")}, {"@userid", AgentID}},
                                                              Connection)
                    Await _LocalDb.Request.ExecuteUpdateAsync("evaluationpicture",
                                                              New Dictionary(Of String, String) From {{"userid", "@userid"}},
                                                              "evaluationid = @evaluationid",
                                                              New Dictionary(Of String, Object) From {{"@evaluationid", Entry("id")}, {"@userid", AgentID}},
                                                              Connection)
                    Await _LocalDb.Request.ExecuteUpdateAsync("evaluationreplacedsellable",
                                                              New Dictionary(Of String, String) From {{"userid", "@userid"}},
                                                              "evaluationid = @evaluationid",
                                                              New Dictionary(Of String, Object) From {{"@evaluationid", Entry("id")}, {"@userid", AgentID}},
                                                              Connection)
                    Await _LocalDb.Request.ExecuteUpdateAsync("evaluationtechnician",
                                                              New Dictionary(Of String, String) From {{"userid", "@userid"}},
                                                              "evaluationid = @evaluationid",
                                                              New Dictionary(Of String, Object) From {{"@evaluationid", Entry("id")}, {"@userid", AgentID}},
                                                              Connection)
                    Await _LocalDb.Request.ExecuteDeleteAsync("evaluation",
                                                              "id = @id",
                                                              New Dictionary(Of String, Object) From {{"@id", Entry("id")}})
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza: Excluindo avaliações antigas ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                    Scope.Complete()
                    Connection.Dispose()
                End Using
            Next Entry
            CurrentRow = 0
            AllRows = 0
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = "Limpeza: Recuperando os endereços dos arquivos"
            Progress?.Report(Response)
            Dim EvaluationResult As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("evaluation", New MysqlSelectOptions() With {
                .Columns = {"id", "documentname"}.ToList,
                .Where = "documentname IS NOT NULL"
            })
            Response.Percent = 20
            Response.Text = $"Limpeza: Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Dim RequestResult As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("request", New MysqlSelectOptions() With {
                .Columns = {"id", "documentname"}.ToList,
                .Where = "documentname IS NOT NULL"
            })
            Response.Percent = 40
            Response.Text = $"Limpeza: Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Dim ProductResult As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("productpicture", New MysqlSelectOptions() With {
                .Columns = {"id", "picturename"}.ToList,
                .Where = "picturename IS NOT NULL"
            })
            Response.Percent = 60
            Response.Text = $"Limpeza: Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Dim EmailResult As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("emailsignature", New MysqlSelectOptions() With {
                .Columns = {"id", "directoryname"}.ToList,
                .Where = "directoryname IS NOT NULL"
            })
            Response.Percent = 80
            Response.Text = $"Limpeza: Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Dim CashResult As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("cash", New MysqlSelectOptions() With {
                .Columns = {"id", "documentname"}.ToList,
                .Where = "documentname IS NOT NULL"
            })
            Response.Percent = 100
            Response.Text = $"Limpeza: Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Limpeza: Verificando a existência dos arquivos referenciados no banco de dados"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            AllRows = EvaluationResult.Data.Count + RequestResult.Data.Count + ProductResult.Data.Count + EmailResult.Data.Count + CashResult.Data.Count
            If FileCount > 0 Then
                Files = EvaluationDocumentDir.GetFiles.ToList
                For Each EvaluationEntry In EvaluationResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(EvaluationEntry("documentname").ToString) Then
                        If Not Files.Any(Function(x) x.Name = EvaluationEntry("documentname").ToString) Then
                            Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next EvaluationEntry
                Files = RequestDocumentDir.GetFiles.ToList
                For Each RequestEntry In RequestResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(RequestEntry("documentname").ToString) Then
                        If Not Files.Any(Function(x) x.Name = RequestEntry("documentname").ToString) Then
                            Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next RequestEntry
                Files = ProductPictureDir.GetFiles.ToList
                For Each ProductEntry As Dictionary(Of String, Object) In ProductResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(ProductEntry("picturename").ToString) Then
                        If Not Files.Any(Function(x) x.Name = ProductEntry("picturename").ToString) Then
                            Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next ProductEntry
                Directories = EmailSignatureDir.GetDirectories.ToList
                For Each EmailEntry In EmailResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(EmailEntry("directoryname").ToString) Then
                        If Not Directories.Any(Function(x) x.Name = EmailEntry("directoryname").ToString) Then
                            Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next EmailEntry
                Files = CashDocumentDir.GetFiles.ToList
                For Each CashEntry In CashResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(CashEntry("documentname").ToString) Then
                        If Not Files.Any(Function(x) x.Name = CashEntry("documentname").ToString) Then
                            Response.Text = $"Limpeza: Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next CashEntry
            End If
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = "Limpeza: Verificando arquivos em disco não referenciados no banco de dados"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            CurrentRow = 0
            FileManager = New FileManager()
            For Each EvaluationFile As FileInfo In EvaluationDocumentDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not EvaluationResult.Data.Any(Function(x) x("documentname").ToString = EvaluationFile.Name) Then
                    Await FileManager.DeleteFilesAsync({EvaluationFile}.ToList)
                    Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next EvaluationFile
            For Each RequestFile As FileInfo In RequestDocumentDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not RequestResult.Data.Any(Function(x) x("documentname").ToString = RequestFile.Name) Then
                    Await FileManager.DeleteFilesAsync({RequestFile}.ToList)
                    Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next RequestFile
            For Each ProductPicture As FileInfo In ProductPictureDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not ProductResult.Data.Any(Function(x) x("picturename").ToString = ProductPicture.Name) Then
                    Await FileManager.DeleteFilesAsync({ProductPicture}.ToList)
                    Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next ProductPicture
            For Each EmailFile As FileInfo In EmailSignatureDir.GetFiles()
                Await FileManager.DeleteFilesAsync({EmailFile}.ToList)
                Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                Await Task.Delay(Constants.WaitForLoop)
            Next EmailFile
            For Each EmailDir As DirectoryInfo In EmailSignatureDir.GetDirectories()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not EmailResult.Data.Any(Function(x) x("directoryname").ToString = EmailDir.Name) Then
                    Await FileManager.DeleteDirectoriesAsync(New List(Of FileManager.DeleteDirectoryInfo) From {New FileManager.DeleteDirectoryInfo(EmailDir, True)})
                    Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next EmailDir
            For Each CashFile As FileInfo In CashDocumentDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not CashResult.Data.Any(Function(x) x("documentname").ToString = CashFile.Name) Then
                    Await FileManager.DeleteFilesAsync({CashFile}.ToList)
                    Response.Text = $"Limpeza: Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next CashFile
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = "Limpeza: Excluindo arquivos temporários"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            AddHandler FileManager.DeleteDirectoriesProgressChanged,
                Sub(IOSender, IOEventArgs)
                    Response.Text = $"Limpeza: Excluindo arquivos temporários ({IOEventArgs.PercentCompleted}%)"
                    Progress?.Report(Response)
                End Sub
            TempDirectories = New List(Of FileManager.DeleteDirectoryInfo) From {
                New FileManager.DeleteDirectoryInfo With {.DeleteRoot = False, .Directory = New DirectoryInfo(ApplicationPaths.AgentTempDirectory)}
            }
            Await FileManager.DeleteDirectoriesAsync(TempDirectories)
            Await Task.Delay(Constants.WaitForJob)

            Response.Text = "Limpeza: Concluído"
            Response.Percent = 0
            Response.Event.EndTime = DateTime.Now
            Response.Event.ReadyToPost = True
            Response.Event.Description = $"Limpeza{If(Not IsManual, String.Empty, " Manual")}"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        Catch ex As Exception
            Exception = ex
        Finally
            If Not IsManual Then Company.LastExecution.Clean = Now
            If Not IsManual Then _CompanyService.Save(Company)
        End Try
        If Exception IsNot Nothing Then
            Response.Percent = 0
            Response.Text = "Backup: Erro na execução"
            Response.Percent = 0
            Response.Event.EndTime = DateTime.Now
            Response.Event.Description = $"Limpeza{If(Not IsManual, String.Empty, " Manual")}"
            Response.Event.Status = TaskStatus.Error
            Response.Event.ExceptionMessage = $"{Exception.Message}{vbNewLine}{Exception.StackTrace}"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = "Limpeza: Concluído"
            Response.Event.ReadyToPost = True
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function
End Class
