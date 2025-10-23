﻿Imports System.Transactions
Imports ManagerCore
Imports ManagerCore.LocalDB
Public Class TaskRelease
    Inherits TaskBase
    Private _DatabaseService As LocalDB
    Private _SettingsService As SettingService
    Private _SessionModel As SessionModel
    Public Sub New(DatabaseService As LocalDB, SettingsService As SettingService, SessionModel As SessionModel)
        _DatabaseService = DatabaseService
        _SettingsService = SettingsService
        _SessionModel = SessionModel
    End Sub

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return _SessionModel.ManagerSetting.General.Release.ReleaseBlockedRegisterInterval
        End Get
    End Property

    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return _SessionModel.ManagerSetting.LastExecution.Release
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
        Args = New Dictionary(Of String, Object) From {{"@min", _SessionModel.ManagerSetting.General.Release.ReleaseBlockedRegisterInterval}}
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
            {"@min", _SessionModel.ManagerSetting.General.Release.ReleaseBlockedRegisterInterval}
        }
        Await _DatabaseService.ExecuteDeleteAsync("lockedregistry", Where, Args)
        Await Task.Delay(Constants.WaitForJob)
    End Function
    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Registry As RegistryModel
        Dim InitialMessagePosted As Boolean
        Dim Response As New AsyncResponseModel
        Try
            Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                Await Task.Delay(Constants.WaitForStart)
                Dim BloquedList As List(Of RegistryModel) = Await GetBloquedList()
                If BloquedList IsNot Nothing Then
                    Response.Text = "Desbloqueador de registros iniciado"
                    Response.Event.SetInitialEvent("Desbloqueador de registros iniciado")
                    If Progress IsNot Nothing Then Progress.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    InitialMessagePosted = True
                    For Each Registry In BloquedList
                        Await UnlockRegistry(Registry)
                        Response.Text = $"Desbloqueado: Rotina {Registry.RoutineID}, Registro {Registry.RegistryID}, Usuário {Registry.UserID} ({BloquedList.IndexOf(Registry) + 1} de {BloquedList.Count})"
                        Response.Percent = (BloquedList.IndexOf(Registry) + 1) / BloquedList.Count * 100
                        Response.Event.AddChildEvent($"Desbloqueado: Rotina {Registry.RoutineID}, Registro {Registry.RegistryID}, Usuário {Registry.UserID}")
                        If Progress IsNot Nothing Then Progress.Report(Response)
                        Await Task.Delay(Constants.WaitForJob)
                    Next Registry
                    Response.Percent = 0
                    If Progress IsNot Nothing Then Progress.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    Response.Text = "Desbloqueador de registros finalizado"
                    Response.Event.SetFinalEvent("Desbloqueador de registros finalizado")
                    If Progress IsNot Nothing Then Progress.Report(Response)
                    Await Task.Delay(Constants.WaitForFinish)
                End If
                If Not IsManual Then _SessionModel.ManagerSetting.LastExecution.Release = Now
                If Not IsManual Then _SettingsService.Save(_SessionModel.ManagerSetting)
                Scope.Complete()
            End Using
        Catch ex As Exception
            If Not InitialMessagePosted Then
                Response.Text = "Desbloqueador de registros iniciado"
                Response.Event.SetInitialEvent("Desbloqueador de registros iniciado")
                Response.Percent = 0
                If Progress IsNot Nothing Then Progress.Report(Response)
            End If
            Response.Text = $"Ocorreu um erro ao desbloquear os registros - {ex.Message}"
            Response.Event.AddChildEvent($"Ocorreu um erro ao desbloquear os registros - {ex.Message}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Response.Text = "Desbloqueador de registros finalizado"
            Response.Event.SetFinalEvent("Desbloqueador de registros finalizado")
            If Progress IsNot Nothing Then Progress.Report(Response)
        End Try
    End Function
End Class
