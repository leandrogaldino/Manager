Imports System.ComponentModel
Imports ControlLibrary
Imports ManagerCore
Imports ManagerCore.LocalDB
Imports ManagerCore.RemoteDB

Public Class TaskCloudSync
    Inherits TaskBase
    Private ReadOnly _LocalDB As LocalDB
    Private ReadOnly _RemoteDB As RemoteDB
    Private ReadOnly _SettingsService As SettingService
    Private ReadOnly _SessionModel As SessionModel
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
            Return _SessionModel.ManagerSetting.LastExecution.CloudSync
        End Get
    End Property
    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property
    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim Exception As Exception = Nothing
        Dim Response As New AsyncResponseModel
        Await Task.Delay(Constants.WaitForStart)
        Try
            Await FetchSchedulesFromCloudToLocal(Response, Progress)
            Await SyncFromLocalToCloud(Response, Progress)
            If Response.Event.IsInitialized Then
                Await Task.Delay(Constants.WaitForFinish)
                Response.Text = $"Sincronização com a núvem - Concluída"
                Response.Event.SetFinalEvent($"Sincronização com a núvem concluída")
                If Progress IsNot Nothing Then Progress.Report(Response)
            End If
            _SessionModel.ManagerSetting.LastExecution.CloudSync = Now.ToString("yyyy-MM-dd HH:mm:ss")
            _SettingsService.Save(_SessionModel.ManagerSetting)
        Catch ex As Exception
            Exception = ex
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
    Private Async Function SyncFromLocalToCloud(Response As AsyncResponseModel, Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim PerformedOperations As Long
        Dim LastSyncTime As Date = _SessionModel.ManagerSetting.LastExecution.CloudSync
        Dim ContinueSync As Boolean = True
        Do While ContinueSync
            ContinueSync = False
            Dim StartTime As Date = Now
            Dim Result As QueryResult = Await _LocalDB.ExecuteSelectAsync(
                "log",
                New List(Of String) From {"id", "routineid", "registryid", "fieldname", "oldvalue", "newvalue", "changedate"},
                "changedate > @changedate AND routineid IN (@person, @compressor, @personcompressor, @personcompressorsellable, @product, @productprovidercode, @service, @visitschedule, @evaluation)",
                New Dictionary(Of String, Object) From {
                    {"@changedate", LastSyncTime},
                    {"@person", 2},
                    {"@compressor", 12},
                    {"@personcompressor", 203},
                    {"@personcompressorsellable", 204},
                    {"@product", 6},
                    {"@productprovidercode", 601},
                    {"@service", 23},
                    {"@visitschedule", 22},
                    {"@evaluation", 13}
                },
                "id ASC"
            )
            Dim TotalChanges As Long = Result.Data.Count
            If TotalChanges > 0 Then
                If Not Response.Event.IsInitialized Then
                    Response.Text = $"Sincronização com a núvem {If(Not IsManual, "automática", "manual")} - Iniciando"
                    Response.Event.SetInitialEvent(Response.Text)
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                End If
                Response.Text = $"Sincronização com a núvem - Enviando dados ({Response.Percent}%)"
                Response.Event.AddChildEvent("Enviando dados")
                Progress?.Report(Response)
                Await Task.Delay(Constants.WaitForJob)
                PerformedOperations = 0
                For Each Change In Result.Data
                    Select Case Change("routineid")
                        Case 12
                            Await FetchCompressor(Change)
                        Case 13
                            Await FetchEvaluation(Change)
                        Case 2
                            Await FetchPerson(Change)
                        Case 203
                            Await FetchPersonCompressor(Change)
                        Case 204
                            Await FetchPersonCompressorCoalescents(Change)
                        Case 6
                            Await FetchProduct(Change)
                        Case 601
                            Await FetchProductProviderCode(Change)
                        Case 23
                            Await FetchService(Change)
                        Case 22
                            Await FetchVisitSchedule(Change)
                    End Select
                    PerformedOperations += 1
                    Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                    Response.Text = $"Sincronização com a núvem - Enviando dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                Next Change
                Dim NewResult As QueryResult = Await _LocalDB.ExecuteSelectAsync(
                    "log",
                    New List(Of String) From {"id"},
                    "changedate > @starttime",
                    New Dictionary(Of String, Object) From {{"@starttime", StartTime}}
                )
                If NewResult.Data.Count > 0 Then
                    Response.Percent = 0
                    Response.Text = "Sincronização com a núvem - Registros remanescentes encontrados"
                    Response.Event.AddChildEvent("Registros remanescentes encontrados")
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    ContinueSync = True
                    LastSyncTime = StartTime
                    Dim NewSyncLimit As Date = Now
                End If
            End If
        Loop
    End Function
    Private Async Function FetchSchedulesFromCloudToLocal(Response As AsyncResponseModel, Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim PerformedOperations As Integer
        Dim TotalChanges As Integer
        Dim LastSyncLimit As Date = _SessionModel.ManagerSetting.LastExecution.CloudSync
        Dim ContinueSync As Boolean = True
        Do While ContinueSync
            ContinueSync = False
            Dim StartTime As Long = DateTimeHelper.MillisecondsFromDate(Now)
            Dim RemoteResult As List(Of Dictionary(Of String, Object)) = Await _RemoteDB.ExecuteGet("visitschedules", New List(Of Condition) From {New WhereGreaterThanCondition("lastupdate", DateTimeHelper.MillisecondsFromDate(LastSyncLimit)), New WhereNotEqualToCondition("performeddate", Nothing)})
            TotalChanges = RemoteResult.Count
            If TotalChanges > 0 Then
                If Not Response.Event.IsInitialized Then
                    Response.Text = $"Sincronização com a núvem {If(Not IsManual, "automática", "manual")} - Iniciando"
                    Response.Event.SetInitialEvent(Response.Text)
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                End If
                Response.Text = "Sincronização com a núvem - Recebendo agendamentos"
                Response.Event.AddChildEvent("Recebendo agendamentos")
                Progress?.Report(Response)
                Await Task.Delay(Constants.WaitForJob)
                PerformedOperations = 0
                For Each Schedule In RemoteResult
                    Await _LocalDB.ExecuteUpdateAsync("visitschedule",
                    New Dictionary(Of String, String) From {
                        {"statusid", "@statusid"},
                        {"performeddate", "@performeddate"},
                        {"lastupdate", "@lastupdate"},
                        {"id", "@id"}
                    },
                    "id = @id",
                    New Dictionary(Of String, Object) From {
                        {"@statusid", 1},
                        {"@performeddate", DateTimeHelper.DateFromMilliseconds(Schedule("performeddate"))},
                        {"@lastupdate", DateTimeHelper.DateFromMilliseconds(Schedule("lastupdate"))},
                        {"@id", Schedule("id")}
                    })
                    PerformedOperations += 1
                    Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                    Response.Text = $"Sincronização com a núvem - Recebendo agendamentos - ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                Next
                Dim NewRecords As List(Of Dictionary(Of String, Object)) = Await _RemoteDB.ExecuteGet("visitschedules", New List(Of Condition) From {New WhereGreaterThanCondition("lastupdate", StartTime)})
                If NewRecords.Count > 0 Then
                    Response.Percent = 0
                    Response.Text = "Sincronização com a núvem - Registros remanescentes encontrados"
                    Response.Event.AddChildEvent("Registros remanescentes encontrados")
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    ContinueSync = True
                    LastSyncLimit = DateTimeHelper.DateFromMilliseconds(StartTime)
                End If
            End If
        Loop
    End Function
    Private Async Function FetchVisitSchedule(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("visitschedule",
                                                 New List(Of String) From {"id", "creation creationdate", "statusid", "scheduleddate", "IFNULL(performeddate, '') performeddate", "calltypeid", "customerid", "personcompressorid compressorid", "technicianid", "instructions"},
                                                 "id = @id",
                                                 New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                 Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ScheduleData As Dictionary(Of String, Object)
            ScheduleData = Result.Data(0)
            ScheduleData("creationdate") = DateTimeHelper.MillisecondsFromDate(ScheduleData(("creationdate")))
            ScheduleData("scheduleddate") = DateTimeHelper.MillisecondsFromDate(ScheduleData(("scheduleddate")))
            ScheduleData("performeddate") = Nothing
            ScheduleData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            ScheduleData("visible") = If(ScheduleData("statusid") = 0, 1, 0)
            ScheduleData.Remove("statusid")
            Await _RemoteDB.ExecutePut("visitschedules", ScheduleData, ScheduleData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("visitschedules",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function

    Private Async Function FetchEvaluation(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("evaluation",
                                                 New List(Of String) From {"id", "sourceid", "cloudid", "visitscheduleid"},
                                                 "id = @id",
                                                 New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                 Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim EvaluationData As Dictionary(Of String, Object)
            EvaluationData = Result.Data(0)
            If EvaluationData("sourceid") = 1 Then
                Await _RemoteDB.ExecuteUpdate("evaluations", New Dictionary(Of String, Object) From {{"info.importedid", EvaluationData("id")}}, New List(Of Condition) From {New WhereEqualToCondition("id", EvaluationData("cloudid"))})
                Await _LocalDB.ExecuteUpdateAsync("visitschedule", New Dictionary(Of String, String) From {{"evaluationid", "@evaluationid"}}, "id = @id", New Dictionary(Of String, Object) From {{"@evaluationid", EvaluationData("id")}, {"@id", EvaluationData("visitscheduleid")}})
            End If
        End If
    End Function
    Private Async Function FetchCompressor(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("compressor",
                                                  New List(Of String) From {"id", "name", "statusid"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CompressorData As Dictionary(Of String, Object)
            CompressorData = Result.Data(0)
            CompressorData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            CompressorData("visible") = If(CompressorData("statusid") = 0, 1, 0)
            CompressorData.Remove("statusid")
            Await _RemoteDB.ExecutePut("compressors", CompressorData, CompressorData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("compressors",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchPersonCompressorCoalescents(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("personcompressorsellable",
                                                  New List(Of String) From {"id", "personcompressorid", "productid", "statusid", "sellablebindid"},
                                                  "id = @id AND controltypeid = @controltypeid",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}, {"@controltypeid", 1}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CoalescentData As Dictionary(Of String, Object)
            CoalescentData = Result.Data(0)
            CoalescentData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            Dim SellableBindID = Convert.ToInt32(CoalescentData("sellablebindid"))
            If SellableBindID <> 5 Then CoalescentData("statusid") = 1
            CoalescentData("visible") = If(CoalescentData("statusid") = 0, 1, 0)
            CoalescentData.Remove("statusid")
            CoalescentData.Remove("sellablebindid")
            Await _RemoteDB.ExecutePut("personcompressorcoalescents", CoalescentData, CoalescentData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("personcompressorcoalescents",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchPersonCompressor(Change As Dictionary(Of String, Object)) As Task

        Dim Result = Await _LocalDB.ExecuteSelectAsync("personcompressor",
                                                 New List(Of String) From {"id", "statusid", "personid", "compressorid", "serialnumber", "patrimony", "sector"},
                                                 "id = @id",
                                                 New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                 Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
                Dim PersonCompressorData As Dictionary(Of String, Object)
                PersonCompressorData = Result.Data(0)
                PersonCompressorData("serialnumber") = If(PersonCompressorData("serialnumber") Is DBNull.Value, String.Empty, PersonCompressorData("serialnumber"))
                PersonCompressorData("patrimony") = If(PersonCompressorData("patrimony") Is DBNull.Value, String.Empty, PersonCompressorData("patrimony"))
                PersonCompressorData("sector") = If(PersonCompressorData("sector") Is DBNull.Value, String.Empty, PersonCompressorData("sector"))
            PersonCompressorData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            PersonCompressorData("visible") = If(PersonCompressorData("statusid") = 0, 1, 0)
            PersonCompressorData.Remove("statusid")
            Await _RemoteDB.ExecutePut("personcompressors", PersonCompressorData, PersonCompressorData("id"))
        End If
            If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("personcompressors",
                                              New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                              New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If


    End Function
    Private Async Function FetchPerson(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("person",
                                                  New List(Of String) From {"id", "statusid", "document", "shortname", "iscustomer", "istechnician"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim PersonData As Dictionary(Of String, Object) = Result.Data(0)
            Dim IsCustomer = Convert.ToBoolean(PersonData("iscustomer"))
            Dim IsTechnician = Convert.ToBoolean(PersonData("istechnician"))
            If PersonData("statusid") = 0 And (IsCustomer Or IsTechnician) Then
                PersonData("visible") = 1
            Else
                PersonData("visible") = 0
            End If
            PersonData.Remove("statusid")
            PersonData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            Await _RemoteDB.ExecutePut("persons", PersonData, PersonData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("persons",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchProduct(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("product",
                                                  New List(Of String) From {"id", "statusid", "name"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ProductData As Dictionary(Of String, Object)
            ProductData = Result.Data(0)
            ProductData("visible") = If(ProductData("statusid") = 0, 1, 0)
            ProductData.Remove("statusid")
            ProductData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            Await _RemoteDB.ExecutePut("products", ProductData, ProductData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("products",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchProductProviderCode(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("productprovidercode",
                                                  New List(Of String) From {"id", "productid", "code", "ismainprovider ismain"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CodeData As Dictionary(Of String, Object)
            CodeData = Result.Data(0)
            CodeData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            CodeData("visible") = 1
            Await _RemoteDB.ExecutePut("productcodes", CodeData, CodeData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("productcodes",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchService(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelectAsync("service",
                                                  New List(Of String) From {"id", "statusid", "name"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ServiceData As Dictionary(Of String, Object)
            ServiceData = Result.Data(0)
            ServiceData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Now)
            ServiceData("visible") = If(ServiceData("statusid") = 0, 1, 0)
            ServiceData.Remove("statusid")
            Await _RemoteDB.ExecutePut("services", ServiceData, ServiceData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("services",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Now)}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
End Class
