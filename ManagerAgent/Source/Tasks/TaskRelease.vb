Imports System.Transactions
Imports ManagerCore
Imports ManagerCore.LocalDB
Public Class TaskRelease
    Inherits TaskBase
    Private ReadOnly _DatabaseService As LocalDB
    Private ReadOnly _CompanyService As CompanyService
    Public Sub New(CompanyModel As CompanyModel, DatabaseService As LocalDB, CompanyService As CompanyService)
        MyBase.New(CompanyModel)
        _DatabaseService = DatabaseService
        _CompanyService = CompanyService
    End Sub

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return Company.General.Release.ReleaseBlockedRegisterInterval
        End Get
    End Property

    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return Company.LastExecution.Release
        End Get
    End Property


    Public Overrides ReadOnly Property Name As TaskName
        Get
            Return TaskName.Release
        End Get
    End Property

    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property

    Private Async Function GetBloquedList() As Task(Of List(Of RegistryModel))
        Dim ReleasedList As List(Of RegistryModel) = Nothing
        Dim ReleasedRegistry As RegistryModel
        Dim Columns As List(Of String)
        Dim Where As String
        Dim Args As Dictionary(Of String, Object)
        Columns = New List(Of String) From {"session", "locktime", "routineid", "registryid", "userid"}
        Where = "NOW() > DATE_ADD(lockedregistry.locktime, INTERVAL @min MINUTE);"
        Args = New Dictionary(Of String, Object) From {{"@min", Company.General.Release.ReleaseBlockedRegisterInterval}}
        Dim Result As QueryResult = Await _DatabaseService.ExecuteSelectAsync("lockedregistry", Columns, Where, Args)
        If Result.HasData Then
            ReleasedList = New List(Of RegistryModel)
            For Each Item In Result.Data
                ReleasedRegistry = New RegistryModel() With {
                    .Session = Item("session"),
                    .LockTime = Item("locktime"),
                    .RoutineID = Item("routineid"),
                    .RegistryID = Item("registryid"),
                    .UserID = Item("userid")
                }
                ReleasedList.Add(ReleasedRegistry)
            Next
        End If
        Return ReleasedList
    End Function
    Private Async Function UnlockRegistry(Registry As RegistryModel) As Task
        Dim Where As String = "lockedregistry.session = @session AND lockedregistry.locktime = @locktime AND lockedregistry.routineid = @routineid AND lockedregistry.registryid = @registryid AND lockedregistry.userid = @userid;"
        Dim Args As New Dictionary(Of String, Object) From {
            {"@session", Registry.Session},
            {"@locktime", Registry.LockTime},
            {"@routineid", Registry.RoutineID},
            {"@registryid", Registry.RegistryID},
            {"@userid", Registry.UserID},
            {"@min", Company.General.Release.ReleaseBlockedRegisterInterval}
        }
        Await _DatabaseService.ExecuteDeleteAsync("lockedregistry", Where, Args)
        Await Task.Delay(Constants.WaitForJob)
    End Function
    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Registry As RegistryModel
        Dim InitialMessagePosted As Boolean
        Dim Response As New AsyncResponseModel
        Dim Exception As Exception = Nothing

        Try

            Convert.ToInt16("Keabdro")

            Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                Await Task.Delay(Constants.WaitForStart)
                Dim BloquedList As List(Of RegistryModel) = Await GetBloquedList()
                If BloquedList IsNot Nothing Then
                    Response.Text = "Desbloquear: Iniciando"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    InitialMessagePosted = True
                    For Each Registry In BloquedList
                        Await UnlockRegistry(Registry)
                        Dim Message As String = $"Desbloqueado: Rotina {Registry.RoutineID}, Registro {Registry.RegistryID}, Usuário {Registry.UserID} ({BloquedList.IndexOf(Registry) + 1} de {BloquedList.Count})"
                        Response.SetTextAndLog(Message)
                        Progress?.Report(Response)
                        Await Task.Delay(Constants.WaitForJob)
                    Next Registry


                    Response.Text = "Desbloquear: Concluído"
                    Response.Percent = 0
                    Response.Event.EndTime = DateTime.Now
                    Response.Event.ReadyToPost = True
                    Response.Event.Description = $"Desbloquear{If(Not IsManual, String.Empty, " Manual")}"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForFinish)
                End If
                Scope.Complete()
            End Using
        Catch ex As Exception
            Exception = ex
        Finally
            If Not IsManual Then Company.LastExecution.Release = Now
            If Not IsManual Then _CompanyService.Save(Company)
        End Try
        If Exception IsNot Nothing Then
            Response.Percent = 0
            Response.Text = "Desbloquear: Erro na execução"
            Response.Percent = 0
            Response.Event.EndTime = DateTime.Now
            Response.Event.Description = $"Desbloquear{If(Not IsManual, String.Empty, " Manual")}"
            Response.Event.Status = TaskStatus.Error
            Response.Event.ExceptionMessage = $"{Exception.Message}{vbNewLine}{Exception.StackTrace}"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = "Desbloquear: Concluído"
            Response.Event.ReadyToPost = True
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function
End Class
