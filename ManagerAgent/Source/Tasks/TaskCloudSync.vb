Imports ManagerCore
Imports CoreSuite.Services
Imports CoreSuite.Helpers
Public Class TaskCloudSync
    Inherits TaskBase
    Private ReadOnly _LocalDb As MySqlService
    Private ReadOnly _RemoteDb As FirebaseService
    Private ReadOnly _PreferencesService As PreferencesService
    Public Sub New(Preferences As PreferencesModel, PreferencesService As PreferencesService, LocalDb As MySqlService, RemoteDb As FirebaseService)
        MyBase.New(Preferences)
        _LocalDb = LocalDb
        _RemoteDb = RemoteDb
        _PreferencesService = PreferencesService
    End Sub
    Public Overrides ReadOnly Property Name As TaskName
        Get
            Return TaskName.CloudSync
        End Get
    End Property
    Public Overrides ReadOnly Property RunIntervalMinutes As Integer
        Get
            Return Preferences.Parameters.Sync.Interval
        End Get
    End Property
    Public Overrides ReadOnly Property LastRun As Date
        Get
            Return Preferences.LastExecution.CloudSync
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
        Dim SyncedFromCloud As Boolean
        Dim SyncedToCloud As Boolean
        Dim HasSynced As Boolean
        Await Task.Delay(Constants.WaitForStart)
        Dim HasInternet = Await InternetHelper.IsInternetAvailableAsync()
        If Not HasInternet Then Return
        Try
            SyncedFromCloud = Await FetchSchedulesFromCloudToLocal(Response, Progress)
            SyncedToCloud = Await SyncFromLocalToCloud(Response, Progress)
            HasSynced = SyncedFromCloud OrElse SyncedToCloud
            Preferences.LastExecution.CloudSync = Now.ToString("yyyy-MM-dd HH:mm:ss")
            Await _PreferencesService.SaveAsync(Preferences)
            If _Started Then
                Response.Text = "Sincronização: Concluído"
                Response.Percent = 0
                Response.Event.EndTime = DateTime.Now
                If HasSynced Then Response.Event.ReadyToPost = True
                Response.Event.Description = $"Sincronização{If(Not IsManual, String.Empty, " Manual")}"
                Progress?.Report(Response)
            End If
            Await Task.Delay(Constants.WaitForFinish)
        Catch ex As Exception
            Exception = ex
        End Try
        If Exception IsNot Nothing Then
            Await Task.Delay(Constants.WaitForJob)
            Response.Percent = 0
            Response.Text = $"Sincronização: [ERRO] = {Exception.Message}"
            Response.Event.EndTime = DateTime.Now
            Response.Event.Description = $"Sincronização{If(Not IsManual, String.Empty, " Manual")}"
            Response.Event.Status = TaskStatus.Error
            Response.Event.ExceptionMessage = $"{Exception.Message}{vbNewLine}{Exception.StackTrace}"
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForJob)
            Response.Text = $"Sincronização: Concluído"
            Response.Event.ReadyToPost = True
            Progress?.Report(Response)
            Await Task.Delay(Constants.WaitForFinish)
        End If
    End Function
    Private Async Function SyncFromLocalToCloud(Response As AsyncResponseModel, Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task(Of Boolean)
        Dim PerformedOperations As Long
        Dim LastSyncTime As Date = Preferences.LastExecution.CloudSync
        Dim ContinueSync As Boolean = True
        Dim HasSynced As Boolean
        Do While ContinueSync
            ContinueSync = False
            Dim StartTime As Date = Now
            Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync(
                "log", New MysqlSelectOptions() With {
                .Columns = {"id", "routineid", "registryid", "fieldname", "oldvalue", "newvalue", "changedate"}.ToList,
                .Where = "changedate > @changedate AND routineid IN (@person, @compressor, @personcompressor, @personcompressorsellable, @product, @productprovidercode, @service, @visitschedule, @evaluation)",
                .QueryArgs = New Dictionary(Of String, Object) From {
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
                .OrderBy = "id ASC"
            })
            Dim TotalChanges As Long = Result.Data.Count
            If TotalChanges > 0 Then
                If Not _Started Then
                    HasSynced = True
                    Response.Percent = 0
                    Response.Text = $"Sincronização: Iniciando"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                End If
                Response.Text = $"Sincronização: Enviando dados ({Response.Percent}%)"
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
                    Response.Text = $"Sincronização: Enviando dados ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                Next Change
                Dim NewResult As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync(
                    "log", New MysqlSelectOptions() With {
                    .Columns = {"id"}.ToList(),
                    .Where = "changedate > @starttime",
                    .QueryArgs = New Dictionary(Of String, Object) From {{"@starttime", StartTime}}
                })
                If NewResult.Data.Count > 0 Then
                    Response.Percent = 0
                    Response.Text = "Sincronização: Registros remanescentes encontrados"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    ContinueSync = True
                    LastSyncTime = StartTime
                    Dim NewSyncLimit As Date = Now
                End If
            End If
        Loop
        Return HasSynced
    End Function
    Private _Started As Boolean
    Private Async Function FetchSchedulesFromCloudToLocal(Response As AsyncResponseModel, Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task(Of Boolean)
        Dim PerformedOperations As Integer
        Dim TotalChanges As Integer
        Dim LastSyncLimit As Date = Preferences.LastExecution.CloudSync
        Dim ContinueSync As Boolean = True
        Dim HasSynced As Boolean
        Do While ContinueSync
            ContinueSync = False
            Dim StartTime As Long = DateTimeHelper.MillisecondsFromDate(Now)
            Dim RemoteResult As List(Of Dictionary(Of String, Object)) = Await _RemoteDb.Firestore.QueryCompositeAsync("visitschedules", {
                New FirestoreFilter("lastupdate", FirestoreOperator.GreaterThan, DateTimeHelper.MillisecondsFromDate(LastSyncLimit)),
                New FirestoreFilter("performeddate", FirestoreOperator.NotEqual, Nothing)
            }.ToList())
            TotalChanges = RemoteResult.Count
            If TotalChanges > 0 Then
                _Started = True
                HasSynced = True
                Response.Percent = 0
                Response.Text = $"Sincronização: Iniciando"
                Progress?.Report(Response)
                Await Task.Delay(Constants.WaitForJob)
                Response.Text = "Sincronização: Recebendo agendamentos"
                Progress?.Report(Response)
                Await Task.Delay(Constants.WaitForJob)
                PerformedOperations = 0
                For Each Schedule In RemoteResult
                    Await _LocalDb.Request.ExecuteUpdateAsync("visitschedule",
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
                    Response.Text = $"Sincronização: Recebendo agendamentos - ({Response.Percent}%)"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                Next
                Dim NewRecords As List(Of Dictionary(Of String, Object)) = Await _RemoteDb.Firestore.QueryCompositeAsync("visitschedules", {
                    New FirestoreFilter("lastupdate", FirestoreOperator.GreaterThan, StartTime)
                }.ToList())
                If NewRecords.Count > 0 Then
                    Response.Percent = 0
                    Response.Text = "Sincronização: Registros remanescentes encontrados"
                    Progress?.Report(Response)
                    Await Task.Delay(Constants.WaitForJob)
                    ContinueSync = True
                    LastSyncLimit = DateTimeHelper.DateFromMilliseconds(StartTime)
                End If
            End If
        Loop
        Return HasSynced
    End Function
    Private Async Function FetchVisitSchedule(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDb.Request.ExecuteSelectAsync("visitschedule", New MysqlSelectOptions() With {
            .Columns = {"id", "creation creationdate", "statusid", "scheduleddate", "performeddate", "calltypeid", "customerid", "personcompressorid compressorid", "technicianid", "instructions"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ScheduleData As Dictionary(Of String, Object)
            ScheduleData = Result.Data(0)
            ScheduleData("creationdate") = DateTimeHelper.MillisecondsFromDate(ScheduleData(("creationdate")))
            ScheduleData("scheduleddate") = DateTimeHelper.MillisecondsFromDate(ScheduleData(("scheduleddate")))
            ScheduleData("performeddate") = If(ScheduleData("performeddate") Is DBNull.Value, Nothing, DateTimeHelper.MillisecondsFromDate(ScheduleData("performeddate")))
            ScheduleData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            ScheduleData("visible") = If(ScheduleData("statusid") = 0, 1, 0)
            ScheduleData.Remove("statusid")
            Await _RemoteDb.Firestore.SaveDocumentAsync("visitschedules",
                                                        ScheduleData("id"),
                                                        ScheduleData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("visitschedules",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function

    Private Async Function FetchEvaluation(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("evaluation", New MysqlSelectOptions() With {
            .Columns = {"id", "sourceid", "cloudid", "visitscheduleid"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim EvaluationData As Dictionary(Of String, Object)
            EvaluationData = Result.Data(0)
            If EvaluationData("sourceid") = 2 Then
                Await _RemoteDb.Firestore.SaveDocumentAsync("evaluations",
                                                            EvaluationData("cloudid"),
                                                            New Dictionary(Of String, Object) From {{"info.importedid", EvaluationData("id")}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
                Await _LocalDb.Request.ExecuteUpdateAsync("visitschedule", New Dictionary(Of String, String) From {{"evaluationid", "@evaluationid"}}, "id = @id", New Dictionary(Of String, Object) From {{"@evaluationid", EvaluationData("id")}, {"@id", EvaluationData("visitscheduleid")}})
            End If
        End If
    End Function
    Private Async Function FetchCompressor(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("compressor", New MysqlSelectOptions() With {
            .Columns = {"id", "name", "statusid"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CompressorData As Dictionary(Of String, Object)
            CompressorData = Result.Data(0)
            CompressorData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            CompressorData("visible") = If(CompressorData("statusid") = 0, 1, 0)
            CompressorData.Remove("statusid")
            Await _RemoteDb.Firestore.SaveDocumentAsync("compressors",
                                                        CompressorData("id"),
                                                        CompressorData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("compressors",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function
    Private Async Function FetchPersonCompressorCoalescents(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("personcompressorsellable", New MysqlSelectOptions() With {
            .Columns = {"id", "personcompressorid", "productid", "statusid", "sellablebindid"}.ToList(),
            .Where = "id = @id AND controltypeid = @controltypeid",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}, {"@controltypeid", 1}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CoalescentData As Dictionary(Of String, Object)
            CoalescentData = Result.Data(0)
            CoalescentData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            Dim SellableBindID = Convert.ToInt32(CoalescentData("sellablebindid"))
            If SellableBindID <> 5 Then CoalescentData("statusid") = 1
            CoalescentData("visible") = If(CoalescentData("statusid") = 0, 1, 0)
            CoalescentData.Remove("statusid")
            CoalescentData.Remove("sellablebindid")
            Await _RemoteDb.Firestore.SaveDocumentAsync("personcompressorcoalescents", CoalescentData("id"), CoalescentData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("personcompressorcoalescents",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function
    Private Async Function FetchPersonCompressor(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("personcompressor", New MysqlSelectOptions() With {
            .Columns = {"id", "statusid", "personid", "compressorid", "serialnumber", "patrimony", "sector"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim PersonCompressorData As Dictionary(Of String, Object)
            PersonCompressorData = Result.Data(0)
            PersonCompressorData("serialnumber") = If(PersonCompressorData("serialnumber") Is DBNull.Value, String.Empty, PersonCompressorData("serialnumber"))
            PersonCompressorData("patrimony") = If(PersonCompressorData("patrimony") Is DBNull.Value, String.Empty, PersonCompressorData("patrimony"))
            PersonCompressorData("sector") = If(PersonCompressorData("sector") Is DBNull.Value, String.Empty, PersonCompressorData("sector"))
            PersonCompressorData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            PersonCompressorData("visible") = If(PersonCompressorData("statusid") = 0, 1, 0)
            PersonCompressorData.Remove("statusid")
            Await _RemoteDb.Firestore.SaveDocumentAsync("personcompressors", PersonCompressorData("id"), PersonCompressorData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("personcompressors",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function
    Private Async Function FetchPerson(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("person", New MysqlSelectOptions() With {
            .Columns = {"id", "statusid", "document", "shortname", "iscustomer", "istechnician"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
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
            PersonData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            Await _RemoteDb.Firestore.SaveDocumentAsync("persons", PersonData("id"), PersonData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("persons",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function
    Private Async Function FetchProduct(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("product", New MysqlSelectOptions() With {
            .Columns = {"id", "statusid", "name"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ProductData As Dictionary(Of String, Object)
            ProductData = Result.Data(0)
            ProductData("visible") = If(ProductData("statusid") = 0, 1, 0)
            ProductData.Remove("statusid")
            ProductData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            Await _RemoteDb.Firestore.SaveDocumentAsync("products", ProductData("id"), ProductData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("products",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function
    Private Async Function FetchProductProviderCode(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("productprovidercode", New MysqlSelectOptions() With {
            .Columns = {"id", "productid", "code", "ismainprovider ismain"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CodeData As Dictionary(Of String, Object)
            CodeData = Result.Data(0)
            CodeData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            CodeData("visible") = 1
            Await _RemoteDb.Firestore.SaveDocumentAsync("productcodes", CodeData("id"), CodeData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("productcodes",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function
    Private Async Function FetchService(Change As Dictionary(Of String, Object)) As Task
        Dim Result As MySqlResponse = Await _LocalDb.Request.ExecuteSelectAsync("service", New MysqlSelectOptions() With {
            .Columns = {"id", "statusid", "name"}.ToList(),
            .Where = "id = @id",
            .QueryArgs = New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
            .Limit = 1
        })
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ServiceData As Dictionary(Of String, Object)
            ServiceData = Result.Data(0)
            ServiceData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
            ServiceData("visible") = If(ServiceData("statusid") = 0, 1, 0)
            ServiceData.Remove("statusid")
            Await _RemoteDb.Firestore.SaveDocumentAsync("services", ServiceData("id"), ServiceData)
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDb.Firestore.SaveDocumentAsync("services",
                                                        Change("registryid"),
                                                        New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)}})
        End If
    End Function
End Class
