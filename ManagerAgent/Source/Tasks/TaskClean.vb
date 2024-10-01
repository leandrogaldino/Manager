Imports System.IO
Imports ControlLibrary
Imports ManagerCore
Imports ManagerCore.LocalDB

Public Class TaskClean
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
            Return TaskName.Clean
        End Get
    End Property

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return _SessionModel.ManagerSetting.General.Clean.Interval * (24 * 60)
        End Get
    End Property

    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return _SessionModel.ManagerSetting.LastExecution.Clean
        End Get
    End Property

    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Response As New AsyncResponseModel

        Dim IddleFiles As New List(Of String)

        Dim Files As New List(Of FileInfo)
        Dim Directories As New List(Of DirectoryInfo)


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

            Response.Text = "Limpeza - Iniciando"
            Response.Event.SetInitialEvent("Limpeza - Iniciando")
            Progress?.Report(Response)


            EvaluationDocumentDir = New DirectoryInfo(ApplicationPaths.EvaluationDocumentDirectory)
            EmailSignatureDir = New DirectoryInfo(ApplicationPaths.EmailSignatureDirectory)
            RequestDocumentDir = New DirectoryInfo(ApplicationPaths.RequestDocumentDirectory)
            ProductPictureDir = New DirectoryInfo(ApplicationPaths.ProductPictureDirectory)
            CashDocumentDir = New DirectoryInfo(ApplicationPaths.CashDocumentDirectory)

            FileCount = EvaluationDocumentDir.GetFiles().Count() + EmailSignatureDir.GetDirectories().Count() + RequestDocumentDir.GetFiles().Count() + ProductPictureDir.GetFiles().Count() + CashDocumentDir.GetFiles().Count()
            CurrentRow = 0





            Await Task.Delay(Constants.WaitForStart)


            Response.Text = "Limpeza - Recuperando os endereços dos arquivos"
            Response.Event.AddChildEvent("Recuperando os endereços dos arquivos")
            Progress?.Report(Response)


            Dim EvaluationResult As QueryResult = Await _DatabaseService.ExecuteSelect("evaluation", {"id", "documentname"}.ToList, "documentname IS NOT NULL")
            Response.Percent = 20
            Response.Text = $"Limpeza - Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)





            Dim RequestResult As QueryResult = Await _DatabaseService.ExecuteSelect("request", {"id", "documentname"}.ToList, "documentname IS NOT NULL")
            Response.Percent = 40
            Response.Text = $"Limpeza - Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            Dim ProductResult As QueryResult = Await _DatabaseService.ExecuteSelect("productpicture", {"id", "picturename"}.ToList, "picturename IS NOT NULL")
            Response.Percent = 60
            Response.Text = $"Limpeza - Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)


            Dim EmailResult As QueryResult = Await _DatabaseService.ExecuteSelect("emailsignature", {"id", "directoryname"}.ToList, "directoryname IS NOT NULL")
            Response.Percent = 80
            Response.Text = $"Limpeza - Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)

            Dim CashResult As QueryResult = Await _DatabaseService.ExecuteSelect("cash", {"id", "documentname"}.ToList, "documentname IS NOT NULL")
            Response.Percent = 100
            Response.Text = $"Limpeza - Recuperando os endereços dos arquivos {(Response.Percent)}%"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)







            Response.Percent = 0
            Response.Text = "Limpeza - Verificando a existência dos arquivos referenciados no banco de dados"
            Response.Event.AddChildEvent("Verificando a existência dos arquivos referenciados no banco de dados")
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)




            AllRows = EvaluationResult.Data.Count + RequestResult.Data.Count + ProductResult.Data.Count + EmailResult.Data.Count + CashResult.Data.Count
            If FileCount > 0 Then


                Files = EvaluationDocumentDir.GetFiles.ToList
                For Each Entry In EvaluationResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(Entry("documentname").ToString) Then
                        If Not Files.Any(Function(x) x.Name = Entry("documentname").ToString) Then
                            Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Response.Event.AddChildEvent($"O arquivo {Entry("documentname")} da avaliação de ID {Entry("id")} não foi encontrado")
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next Entry


                Files = RequestDocumentDir.GetFiles.ToList
                For Each Entry In RequestResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(Entry("filename").ToString) Then
                        If Not Files.Any(Function(x) x.Name = Entry("filename").ToString) Then
                            Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Response.Event.AddChildEvent($"O arquivo {Entry("filename")} da avaliação de ID {Entry("id")} não foi encontrado")
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next Entry



                Files = ProductPictureDir.GetFiles.ToList
                For Each Entry As Dictionary(Of String, Object) In ProductResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(Entry("picturename").ToString) Then
                        If Not Files.Any(Function(x) x.Name = Entry("picturename").ToString) Then
                            Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Response.Event.AddChildEvent($"O arquivo {Entry("picturename")} da avaliação de ID {Entry("id")} não foi encontrado")
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next Entry





                Directories = EmailSignatureDir.GetDirectories.ToList
                For Each Entry In EmailResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(Entry("directoryname").ToString) Then
                        If Not Directories.Any(Function(x) x.Name = Entry("directoryname").ToString) Then
                            Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Response.Event.AddChildEvent($"A pasta {Entry("directoryname")} da assinatura de e-mail de ID {Entry("id")} não foi encontrada")
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next Entry


                Files = CashDocumentDir.GetFiles.ToList
                For Each Entry In CashResult.Data
                    CurrentRow += 1
                    Response.Percent = CurrentRow / AllRows * 100
                    Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    If Not String.IsNullOrEmpty(Entry("documentname").ToString) Then
                        If Not Files.Any(Function(x) x.Name = Entry("documentname").ToString) Then
                            Response.Text = $"Limpeza - Verificando a existência dos arquivos referenciados no banco de dados ({Response.Percent}%)"
                            Response.Event.AddChildEvent($"O arquivo {Entry("documentname")} da avaliação de ID {Entry("id")} não foi encontrado")
                            Progress?.Report(Response)
                            Await Task.Delay(Constants.WaitForLoop)
                        End If
                    End If
                Next Entry
            End If

            Await Task.Delay(Constants.WaitForJob)




            Response.Percent = 0
            Response.Text = "Limpeza - Verificando arquivos em disco não referenciados no banco de dados"
            Response.Event.AddChildEvent("Verificando arquivos em disco não referenciados no banco de dados")
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)



            CurrentRow = 0
            FileManager = New FileManager()
            For Each EvaluationFile As FileInfo In EvaluationDocumentDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not EvaluationResult.Data.Any(Function(x) x("documentname").ToString = EvaluationFile.Name) Then
                    Await FileManager.DeleteFilesAsync({EvaluationFile}.ToList)
                    Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Response.Event.AddChildEvent($"O arquivo {EvaluationFile.Name} foi excluído da pasta de documentos de avaliações pois não pertencia a nenhuma avaliação.")
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next EvaluationFile


            For Each RequestFile As FileInfo In RequestDocumentDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not RequestResult.Data.Any(Function(x) x("filename").ToString = RequestFile.Name) Then
                    Await FileManager.DeleteFilesAsync({RequestFile}.ToList)
                    Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Response.Event.AddChildEvent($"O arquivo {RequestFile.Name} foi excluído da pasta de documentos de requisições pois não pertencia a nenhuma requisição.")
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next RequestFile


            For Each ProductPicture As FileInfo In ProductPictureDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not ProductResult.Data.Any(Function(x) x("picturename").ToString = ProductPicture.Name) Then
                    Await FileManager.DeleteFilesAsync({ProductPicture}.ToList)
                    Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Response.Event.AddChildEvent($"O arquivo {ProductPicture.Name} foi excluído da pasta de fotos dos produtos pois não pertencia a nenhuma foto de produto.")
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next ProductPicture

            For Each EmailFile As FileInfo In EmailSignatureDir.GetFiles()
                Await FileManager.DeleteFilesAsync({EmailFile}.ToList)
                Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Response.Event.AddChildEvent($"O arquivo {EmailFile.Name} foi excluído da pasta de assinaturas de e-mail pois não pertencia a nenhuma assinatura de e-mail.")
                Progress?.Report(Response)
                Await Task.Delay(Constants.WaitForLoop)
            Next EmailFile



            For Each EmailDir As DirectoryInfo In EmailSignatureDir.GetDirectories()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not EmailResult.Data.Any(Function(x) x("directoryname").ToString = EmailDir.Name) Then
                    Await FileManager.DeleteDirectoriesAsync(New List(Of FileManager.DeleteDirectoryInfo) From {New FileManager.DeleteDirectoryInfo(EmailDir, True)})
                    Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Response.Event.AddChildEvent($"A pasta {EmailDir.Name} foi excluída da pasta de assinaturas de e-mail pois não pertencia a nenhuma assinatura de e-mail.")
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next EmailDir



            For Each CashFile As FileInfo In CashDocumentDir.GetFiles()
                CurrentRow += 1
                Response.Percent = CurrentRow / FileCount * 100
                Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                Progress?.Report(Response)
                If Not CashResult.Data.Any(Function(x) x("documentname").ToString = CashFile.Name) Then
                    Await FileManager.DeleteFilesAsync({CashFile}.ToList)
                    Response.Text = $"Limpeza - Verificando arquivos em disco não referenciados no banco de dados ({Response.Percent}%)"
                    Response.Event.AddChildEvent($"O arquivo {CashFile.Name} foi excluído da pasta de documentos do caixa pois não pertencia a nenhum caixa.")
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                End If
            Next CashFile

            Await Task.Delay(Constants.WaitForJob)


            Response.Text = "Limpeza - Excluindo arquivos temporários"
            Response.Event.AddChildEvent("Excluindo arquivos temporários")
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            AddHandler FileManager.DeleteDirectoriesProgressChanged,
                Sub(IOSender, IOEventArgs)
                    Response.Text = $"Limpeza - Excluindo arquivos temporários ({IOEventArgs.PercentCompleted}%)"
                    Progress?.Report(Response)
                End Sub
            TempDirectories = New List(Of FileManager.DeleteDirectoryInfo) From {
                New FileManager.DeleteDirectoryInfo With {.DeleteRoot = False, .Directory = New DirectoryInfo(ApplicationPaths.AgentTempDirectory)}
            }
            Await FileManager.DeleteDirectoriesAsync(TempDirectories)
            Await Task.Delay(Constants.WaitForJob)



            Response.Text = "Limpeza - Finalizado"
            Response.Event.SetFinalEvent("Limpeza - Finalizado")
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        Catch ex As Exception

            Exception = ex

        Finally

            If Not IsManual Then _SessionModel.ManagerSetting.LastExecution.Clean = Now
            If Not IsManual Then _SettingsService.Save(_SessionModel.ManagerSetting)


        End Try

        If Exception IsNot Nothing Then
            Response.Percent = 0
            Response.Text = $"Ocorreu um erro ao executar o coletor - {Exception.Message}"
            Response.Event.AddChildEvent($"Ocorreu um erro ao executar o coletor - {Exception.Message}")
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = "Limpeza - Finalizado"
            Response.Event.SetFinalEvent("Limpeza - Finalizado")
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)

        End If







    End Function
End Class
