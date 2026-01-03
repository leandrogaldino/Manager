Imports System.Transactions
Imports ManagerCore
Imports CoreSuite.Services
Public Class TaskRelease
    Inherits TaskBase
    Private ReadOnly _LocalDb As MySqlService
    Private ReadOnly _PreferencesService As PreferencesService
    Public Sub New(Preferences As PreferencesModel, PreferencesService As PreferencesService, LocalDb As MySqlService)
        MyBase.New(Preferences)
        _LocalDb = LocalDb
        _PreferencesService = PreferencesService
    End Sub

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return Preferences.Parameters.Release.ReleaseBlockedRegisterInterval
        End Get
    End Property

    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return Preferences.LastExecution.Release
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
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("lockedregistry", New MySqlSelectOptions() With {
            .Columns = {"session", "locktime", "routineid", "registryid", "userid"}.ToList(),
            .Where = "NOW() > DATE_ADD(lockedregistry.locktime, INTERVAL @min MINUTE);",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@min", Preferences.Parameters.Release.ReleaseBlockedRegisterInterval}}
        })
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
            {"@min", Preferences.Parameters.Release.ReleaseBlockedRegisterInterval}
        }
        Await _LocalDb.Request.ExecuteDeleteAsync("lockedregistry", Where, Args)
        Await Task.Delay(Constants.WaitForJob)
    End Function
    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Registry As RegistryModel
        Dim InitialMessagePosted As Boolean
        Dim Response As New AsyncResponseModel
        Dim Exception As Exception = Nothing
        Try
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
            If Not IsManual Then Preferences.LastExecution.Release = Now
            If Not IsManual Then _PreferencesService.Save(Preferences)
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
