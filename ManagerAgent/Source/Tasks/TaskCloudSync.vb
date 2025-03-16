Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting
Imports System.Text
Imports ControlLibrary
Imports ControlLibrary.QueriedBox
Imports ManagerCore
Imports ManagerCore.LocalDB
Imports ManagerCore.RemoteDB

Public Class TaskCloudSync
    Inherits TaskBase

    Private _LocalDB As LocalDB
    Private _RemoteDB As RemoteDB
    Private _SettingsService As SettingService
    Private _SessionModel As SessionModel
    Public Sub New(LocalDB As LocalDB, RemoteDB As RemoteDB, SettingsService As SettingService, SessionModel As SessionModel)
        _LocalDB = LocalDB
        _RemoteDB = RemoteDB
        _SettingsService = SettingsService
        _SessionModel = SessionModel
    End Sub
    Public Overrides ReadOnly Property Name As TaskName
        Get
            Return TaskName.CloudSync
        End Get
    End Property

    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return _SessionModel.ManagerSetting.Cloud.CustomerDB.SyncInterval
        End Get
    End Property

    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return _SessionModel.ManagerSetting.LastExecution.CloudDataSync
        End Get
    End Property

    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim LastSyncID As Integer
        Dim Columns As List(Of String)
        Dim OrderBy As String
        Dim Where As String
        Dim Args As Dictionary(Of String, Object)
        Dim Result As QueryResult
        Dim LastSyncDateDictionary As Dictionary(Of String, Object)
        Dim LastSyncDate As Date
        Dim OperationCountDictionary As Dictionary(Of String, Object)
        Dim OperationCount As Integer
        Dim TotalChanges As Integer
        Dim PerformedOperations As Integer
        Dim Response As New AsyncResponseModel
        Dim Exception As Exception = Nothing
        Try
            'A PARTIR DAQUI SALVA DADOS DE VARIAS TABELAS NA NUVEM
            Await Task.Delay(Constants.WaitForStart)
            Await ConfigOperations()
            Columns = New List(Of String) From {"name", "value"}
            Where = "name LIKE @name"
            Args = New Dictionary(Of String, Object) From {{"@name", "Cloud%"}}
            Result = Await _LocalDB.ExecuteSelect("config", Columns, Where, Args)
            LastSyncDateDictionary = Result.Data.First(Function(x) x("name") = "CloudLastSyncDate")
            LastSyncDate = If(String.IsNullOrEmpty(LastSyncDateDictionary("value")), Nothing, LastSyncDateDictionary("value"))
            OperationCountDictionary = Result.Data.First(Function(x) x("name") = "CloudOperationCount")
            OperationCount = If(String.IsNullOrEmpty(OperationCountDictionary("value")), 0, OperationCountDictionary("value"))
            If (Date.Now - LastSyncDate).TotalHours >= 24 Then
                OperationCount = 0
            End If
            Dim MaxOperationDictionary As Dictionary(Of String, Object) = Result.Data.First(Function(x) x("name") = "CloudMaxOperation")
            Dim MaxOperation As Integer = If(String.IsNullOrEmpty(MaxOperationDictionary("value")), 0, MaxOperationDictionary("value"))
            Dim RemainingOperations As Integer = MaxOperation - OperationCount
            If RemainingOperations > 0 Then
                LastSyncID = Await GetLastSyncID()
                Columns = New List(Of String) From {"id", "routineid", "registryid", "fieldname", "oldvalue", "newvalue", "changedate"}
                OrderBy = "id ASC"
                Where = "id > @id AND routineid IN (@person, @personcompressor, @personcompressorpartelapsedday)"
                Args = New Dictionary(Of String, Object) From {{"@id", LastSyncID}, {"@person", 2}, {"@personcompressor", 203}, {"@personcompressorpartelapsedday", 205}}
                Result = Await _LocalDB.ExecuteSelect("log", Columns, Where, Args, OrderBy)
                TotalChanges = If(Result.Data.Count > RemainingOperations, RemainingOperations, Result.Data.Count)
                If TotalChanges > 0 Then
                    Response.Text = $"Sincronização com a núvem {If(Not IsManual, "automática", "manual")} - Iniciando"
                    Response.Event.SetInitialEvent($"Sincronização com a núvem {If(Not IsManual, "automático", "manual")} - Iniciando")
                    Progress?.Report(Response)
                    PerformedOperations = 0
                    Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                    Response.Text = $"Sincronização com a núvem - Enviando dados para a núvem {(Response.Percent)}%"
                    Response.Event.AddChildEvent("Enviando dados para a núvem")
                    For Each Change In Result.Data
                        Select Case Change("routineid")
                            Case 2 'Person
                                Await FetchPerson(Change)
                                PerformedOperations += 1
                            Case 203 'PersonCompressor
                                Await FetchPersonCompressor(Change)
                                PerformedOperations += 1
                            Case 205 'PersonCompressorPartElapsedDay
                                Await FetchPersonCompressorCoalescent(Change)
                                PerformedOperations += 1
                        End Select
                        LastSyncID = Change("id")
                        Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                        Response.Text = $"Sincronização com a núvem - Enviando dados para a núvem {(Response.Percent)}%"
                        Progress?.Report(Response)
                        Await Task.Delay(Constants.WaitForLoop)
                        If PerformedOperations >= RemainingOperations Then
                            Exit For
                        End If
                    Next Change
                    Await SaveCloudConfig(LastSyncID, PerformedOperations + OperationCount)
                End If
                Await Task.Delay(Constants.WaitForJob)


                'A PARTIR DAQUI SINCRONIZA OS DADOS DA TABELA VISIT SCHEDULE


                Columns = New List(Of String) From {"id", "creation", "statusid", "visitdate", "calltypeid", "customerid", "personcompressorid", "instructions", "lastupdate", "userid"}
                OrderBy = "id ASC"
                Where = "lastupdate > @lastupdate"
                Args = New Dictionary(Of String, Object) From {{"@lastupdate", _SessionModel.ManagerSetting.LastExecution.CloudVisitScheduleSync}}
                Result = Await _LocalDB.ExecuteSelect("visitschedule", Columns, Where, Args, OrderBy)
                Dim LocalResult As List(Of Dictionary(Of String, Object)) = Result.Data
                Dim Conditions As New List(Of RemoteDB.Condition) From {New WhereGreaterThanCondition("lastupdate", DateTimeHelper.MillisecondsFromDate(_SessionModel.ManagerSetting.LastExecution.CloudVisitScheduleSync))}
                Dim RemoteResult As List(Of Dictionary(Of String, Object)) = Await _RemoteDB.ExecuteGet("schedules", Conditions)
                Dim LocalIds As New HashSet(Of String)(LocalResult.Select(Function(item) item("id").ToString()))
                Dim CommonResult As List(Of Dictionary(Of String, Object)) = RemoteResult.Where(Function(item) LocalIds.Contains(item("id").ToString())).ToList()
                Dim CommonIds As New HashSet(Of String)(CommonResult.Select(Function(item) item("id").ToString()))
                Dim AllIds As List(Of String) = LocalResult.Select(Function(x) x("id").ToString).ToList()
                AllIds.AddRange(RemoteResult.Select(Function(x) x("id").ToString).ToList())
                AllIds = AllIds.Distinct().ToList()
                TotalChanges = AllIds.Count
                If LocalResult.Count + RemoteResult.Count + CommonResult.Count > 0 Then
                    If Not Response.Event.IsInitialized Then
                        Response.Text = $"Sincronização com a núvem {If(Not IsManual, "automática", "manual")} - Iniciando"
                        Response.Event.SetInitialEvent($"Sincronização com a núvem {If(Not IsManual, "automático", "manual")} - Iniciando")
                        Progress?.Report(Response)
                        Await Task.Delay(Constants.WaitForJob)
                    End If
                    Response.Text = $"Sincronização com a núvem - Sincronizando Agendamento de Visitas"
                    Response.Event.AddChildEvent($"Sincronizando Agendamento de Visitas")
                    If Progress IsNot Nothing Then Progress.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    PerformedOperations = 0
                    For Each Schedule In CommonResult
                        Dim Values As New Dictionary(Of String, String)
                        Values = New Dictionary(Of String, String) From {
                            {"statusid", "@statusid"},
                            {"visitdate", "@visitdate"},
                            {"lastupdate", "@lastupdate"},
                            {"id", "@id"}
                        }
                        Where = "id = @id"
                        Args = New Dictionary(Of String, Object) From {
                            {"@statusid", RemoteResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("statusid")},
                            {"@visitdate", DateTimeHelper.DateFromMilliseconds(RemoteResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("visitdate"))},
                            {"@lastupdate", DateTimeHelper.DateFromMilliseconds(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())},
                            {"@id", RemoteResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("id")}
                        }
                        Await _LocalDB.ExecuteUpdate("visitschedule", Values, Where, Args)
                        Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                        Response.Text = $"Sincronização com a núvem - Atualizando agendamentos - {(Response.Percent)}%"
                        Response.Event.AddChildEvent($"Atualizando agendamentos")
                        If Progress IsNot Nothing Then Progress.Report(Response)
                        Await Task.Delay(Constants.WaitForLoop)
                        PerformedOperations += 1
                    Next Schedule
                    LocalResult.RemoveAll(Function(item) item.ContainsKey("id") AndAlso CommonIds.Contains(item("id").ToString()))
                    RemoteResult.RemoveAll(Function(item) item.ContainsKey("id") AndAlso CommonIds.Contains(item("id").ToString()))
                    PerformedOperations = 0
                    For Each Schedule In RemoteResult
                        Dim Values As New Dictionary(Of String, String) From {
                            {"statusid", "@statusid"},
                            {"visitdate", "@visitdate"},
                            {"lastupdate", "@lastupdate"},
                            {"id", "@id"}
                        }
                        Where = "id = @id"
                        Args = New Dictionary(Of String, Object) From {
                            {"@statusid", If(Schedule("visible") = True, 0, 1)},
                            {"@visitdate", DateTimeHelper.DateFromMilliseconds(Schedule("visitdate"))},
                            {"@lastupdate", DateTimeHelper.DateFromMilliseconds(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())},
                            {"@id", Schedule("id")}
                        }
                        Await _LocalDB.ExecuteUpdate("visitschedule", Values, Where, Args)
                        PerformedOperations += 1
                        Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                        Response.Text = $"Sincronização com a núvem - Atualizando agendamentos - {(Response.Percent)}%"
                        Response.Event.AddChildEvent($"Atualizando agendamentos")
                        If Progress IsNot Nothing Then Progress.Report(Response)
                        Await Task.Delay(Constants.WaitForLoop)
                    Next Schedule
                    PerformedOperations = 0
                    For Each Schedule In LocalResult
                        Schedule.Remove("userid")
                        Schedule("visible") = If(Schedule("statusid") = 0, 1, 0)
                        Schedule.Remove("statusid")
                        Schedule("creationdate") = DateTimeHelper.MillisecondsFromDate(Schedule("creation"))
                        Schedule.Remove("creation")
                        Schedule.Remove("customerid")
                        Schedule("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
                        Schedule("visitdate") = DateTimeHelper.MillisecondsFromDate(Schedule("visitdate"))
                        Await _RemoteDB.ExecutePut("schedules", Schedule, Schedule("id"))
                        PerformedOperations += 1
                        Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                        Response.Text = $"Sincronização com a núvem - Enviando novos agendamentos para a núvem - {(Response.Percent)}%"
                        Response.Event.AddChildEvent($"Enviando novos agendamentos para a núvem")
                        If Progress IsNot Nothing Then Progress.Report(Response)
                        Await Task.Delay(Constants.WaitForLoop)
                    Next Schedule
                End If
            End If
            If Response.Event.IsInitialized Then
                Await Task.Delay(Constants.WaitForFinish)
                Response.Text = $"Sincronização com a núvem - Concluída"
                Response.Event.SetFinalEvent($"Sincronização com a núvem concluída")
                If Progress IsNot Nothing Then Progress.Report(Response)
            End If
        Catch ex As Exception
            Exception = ex
        Finally
            _SessionModel.ManagerSetting.LastExecution.CloudVisitScheduleSync = Now
            If Not IsManual Then _SessionModel.ManagerSetting.LastExecution.CloudDataSync = Now
            _SettingsService.Save(_SessionModel.ManagerSetting)
        End Try
        If Exception IsNot Nothing Then
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = $"Sincronização com a núvem - Ocorreu um erro executar a sincronização - {Exception.Message}"

            If Not Response.Event.IsInitialized Then Response.Event.SetInitialEvent($"Sincronização com a núvem {If(Not IsManual, "automático", "manual")} - Iniciando")

            Response.Event.AddChildEvent($"Ocorreu um erro executar a sincronização - {Exception.Message}")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = $"Sincronização com a núvem - Concluída"
            Response.Event.SetFinalEvent($"Sincronização com a núvem concluída")
            If Progress IsNot Nothing Then Progress.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function

    Private Async Function ConfigOperations() As Task
        Dim Result As QueryResult = Await _LocalDB.ExecuteSelect("config", {"value"}.ToList, "name = @name", New Dictionary(Of String, Object) From {{"@name", "CloudLastSyncDate"}})
        Dim LastSyncDate As Date = If(String.IsNullOrEmpty(Result.Data(0)("value")), Nothing, Result.Data(0)("value"))
        Dim Values As Dictionary(Of String, String)
        Dim Args As Dictionary(Of String, Object)
        Dim Where As String
        If (Now - LastSyncDate).TotalHours >= 24 Then
            Values = New Dictionary(Of String, String) From {{"value", "@value"}}
            Where = "name = @name"
            Args = New Dictionary(Of String, Object) From {{"@value", Now.ToString("yyyy-MM-dd HH:mm:ss")}, {"@name", "CloudLastSyncDate"}}
            Await _LocalDB.ExecuteUpdate("config", Values, Where, Args)
            Args = New Dictionary(Of String, Object) From {{"@value", 0}, {"@name", "CloudOperationCount"}}
            Await _LocalDB.ExecuteUpdate("config", Values, Where, Args)
        End If
    End Function

    Private Async Function GetLastSyncID() As Task(Of Integer)
        Dim Result As QueryResult = Await _LocalDB.ExecuteSelect("config", {"value"}.ToList, "name = @name", New Dictionary(Of String, Object) From {{"@name", "CloudLastSyncID"}})
        Dim LastSyncID As Integer = Result.Data(0)("value")
        Return LastSyncID
    End Function
    Private Async Function FetchPersonCompressorCoalescent(Change As Dictionary(Of String, Object)) As Task
        Dim Args As New Dictionary(Of String, Object) From {{"@id", Change("registryid")}, {"@parttypeid", 1}}
        Dim Result = Await _LocalDB.ExecuteRawQuery("SELECT pcp.id, pcp.personcompressorid, pcp.statusid, pcp.partbindid, IFNULL(pcp.itemname, p.name) coalescentname  FROM personcompressorpart pcp  LEFT JOIN product p ON pcp.productid = p.id WHERE pcp.parttypeid = @parttypeid AND pcp.id = @id LIMIT 1", Args)
        Dim CoalescentData As Dictionary(Of String, Object)
        Dim Conditions As List(Of RemoteDB.Condition)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            CoalescentData = Result.Data(0)
            CoalescentData("lastupdate") = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            Dim DocumentName As String = RemoveSpecialCharacters($"ID: {CoalescentData("id")} - {CoalescentData("coalescentname")}")
            Dim PartBindID = Convert.ToInt32(CoalescentData("partbindid"))
            If PartBindID <> 5 Then CoalescentData("statusid") = 1
            CoalescentData("visible") = If(CoalescentData("statusid") = 0, 1, 0)
            CoalescentData.Remove("statusid")
            CoalescentData.Remove("partbindid")
            Await _RemoteDB.ExecutePut("coalescents", CoalescentData, DocumentName)
        End If
        If Change("fieldname") = "Deleção" Then
            Conditions = New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("id", Change("registryid"))}
            Dim Updates = New Dictionary(Of String, Object) From {{"visible", 0}}
            Await _RemoteDB.ExecuteUpdate("coalescents", Updates, Conditions)
        End If
    End Function
    Private Async Function FetchPersonCompressor(Change As Dictionary(Of String, Object)) As Task
        Dim Args As New Dictionary(Of String, Object) From {{"@id", Change("registryid")}}
        Dim Result = Await _LocalDB.ExecuteRawQuery("SELECT pc.id, pc.statusid, pc.personid, pc.compressorid, c.name compressorname,  IFNULL(pc.serialnumber, '') serialnumber, IFNULL(pc.sector, '') sector  FROM personcompressor pc LEFT JOIN compressor c ON pc.compressorid = c.id WHERE pc.id = @id LIMIT 1", Args)
        Dim CompressorData As Dictionary(Of String, Object)
        Dim Conditions As List(Of RemoteDB.Condition)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            CompressorData = Result.Data(0)
            CompressorData("lastupdate") = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            CompressorData("visible") = If(CompressorData("statusid") = 0, 1, 0)
            CompressorData.Remove("statusid")
            Dim DocumentName As String = RemoveSpecialCharacters($"ID: {CompressorData("id")} - {CompressorData("compressorname")}")
            Await _RemoteDB.ExecutePut("compressors", CompressorData, DocumentName)
        End If
        If Change("fieldname") = "Deleção" Then
            Conditions = New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("id", Change("registryid"))}
            Dim Updates = New Dictionary(Of String, Object) From {{"visible", 0}}
            Await _RemoteDB.ExecuteUpdate("compressors", Updates, Conditions)
        End If
    End Function
    Private Async Function FetchPerson(Change As Dictionary(Of String, Object)) As Task
        Dim Columns As New List(Of String) From {"id", "statusid", "document", "shortname", "iscustomer", "istechnician"}
        Dim Where As String = "id = @id"
        Dim WhereArgs As New Dictionary(Of String, Object) From {{"@id", Change("registryid")}}
        Dim Result = Await _LocalDB.ExecuteSelect("person", Columns, Where, WhereArgs, Limit:=1)
        Dim PersonData As Dictionary(Of String, Object)
        Dim Conditions As List(Of RemoteDB.Condition)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            PersonData = Result.Data(0)
            Dim IsCustomer = Convert.ToBoolean(PersonData("iscustomer"))
            Dim IsTechnician = Convert.ToBoolean(PersonData("istechnician"))
            PersonData("visible") = If(PersonData("statusid") = 0, 1, 0)
            PersonData.Remove("statusid")
            PersonData("lastupdate") = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            Dim DocumentName As String = RemoveSpecialCharacters($"ID: {PersonData("id")} - {PersonData("shortname")}")
            Await _RemoteDB.ExecutePut("persons", PersonData, DocumentName)
        End If
        If Change("fieldname") = "Deleção" Then
            Conditions = New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("id", Change("registryid"))}
            Dim Updates = New Dictionary(Of String, Object) From {{"visible", 0}}
            Await _RemoteDB.ExecuteUpdate("persons", Updates, Conditions)
        End If
    End Function

    Private Function RemoveSpecialCharacters(input As String) As String
        Dim Result As New StringBuilder()
        For Each Ch As Char In input
            If Char.IsLetter(Ch) Or Char.IsNumber(Ch) Then
                Result.Append(Ch)
            Else
                Result.Append(" ")
            End If
        Next
        Return Result.ToString()
    End Function
    Private Async Function SaveCloudConfig(CloudLastSyncID As Integer, CloudOperationCount As Integer) As Task
        Dim Values As Dictionary(Of String, String)
        Dim Where As String
        Dim WhereArgs As Dictionary(Of String, Object)
        Values = New Dictionary(Of String, String) From {{"value", "@value"}}
        Where = "name = @name"
        WhereArgs = New Dictionary(Of String, Object) From {{"@value", CloudLastSyncID}, {"@name", "CloudLastSyncID"}}
        Await _LocalDB.ExecuteUpdate("config", Values, Where, WhereArgs)
        WhereArgs = New Dictionary(Of String, Object) From {{"@value", CloudOperationCount}, {"@name", "CloudOperationCount"}}
        Await _LocalDB.ExecuteUpdate("config", Values, Where, WhereArgs)
        WhereArgs = New Dictionary(Of String, Object) From {{"@value", Now.ToString("yyyy-MM-dd HH:MM:ss")}, {"@name", "CloudLastSyncDate"}}
        Await _LocalDB.ExecuteUpdate("config", Values, Where, WhereArgs)
    End Function

End Class
