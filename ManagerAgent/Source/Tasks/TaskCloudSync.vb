Imports System.Data.SqlTypes
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
            Return _SessionModel.ManagerSetting.LastExecution.Cloud
        End Get
    End Property
    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return False
        End Get
    End Property
    Public Overrides Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim OperationCount As Long
        Dim MaxOperation As Long
        Dim RemainingOperations As Long
        Dim Exception As Exception = Nothing
        Dim Response As New AsyncResponseModel
        Await Task.Delay(Constants.WaitForStart)
        Try
            If (Now - _SessionModel.ManagerSetting.LastExecution.CloudDataSended).TotalHours >= 24 Then
                _SessionModel.ManagerSetting.Cloud.Synchronization.CloudOperationCount = 0
                _SettingsService.Save(_SessionModel.ManagerSetting)
            End If

            OperationCount = _SessionModel.ManagerSetting.Cloud.Synchronization.CloudOperationCount
            MaxOperation = _SessionModel.ManagerSetting.Cloud.Synchronization.CloudMaxOperation
            RemainingOperations = MaxOperation - OperationCount
            RemainingOperations = Await SyncTables(OperationCount, RemainingOperations, Response, Progress)









            Await Task.Delay(Constants.WaitForJob)

            Await SyncSchedules(RemainingOperations, Response, Progress)
            If Response.Event.IsInitialized Then
                Await Task.Delay(Constants.WaitForFinish)
                Response.Text = $"Sincronização com a núvem - Concluída"
                Response.Event.SetFinalEvent($"Sincronização com a núvem concluída")
                If Progress IsNot Nothing Then Progress.Report(Response)
            End If
        Catch ex As Exception
            Exception = ex
        Finally
            _SessionModel.ManagerSetting.LastExecution.Cloud = Now.ToString("yyyy-MM-dd HH:mm:ss")
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
    Private Async Function SyncTables(OperationCount As Long, RemainingOperations As Long, Response As AsyncResponseModel, Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task(Of Long)
        Dim PerformedOperations As Long
        If RemainingOperations > 0 Then
            Dim LastSyncID As Long = _SessionModel.ManagerSetting.Cloud.Synchronization.CloudLastSyncID
            Dim Result As QueryResult = Await _LocalDB.ExecuteSelect("log",
                                                  New List(Of String) From {"id", "routineid", "registryid", "fieldname", "oldvalue", "newvalue", "changedate"},
                                                  "id > @id AND routineid IN (@person, @personcompressor, @personcompressorsellableelapsedday, @product, @productprovidercode, @service, @visitschedule)",
                                                  New Dictionary(Of String, Object) From {{"@id", LastSyncID}, {"@person", 2}, {"@personcompressor", 203}, {"@personcompressorsellableelapsedday", 205}, {"@product", 6}, {"@productprovidercode", 601}, {"@service", 23}, {"@visitschedule", 22}},
                                                  "id ASC")
            Dim TotalChanges As Long = If(Result.Data.Count > RemainingOperations, RemainingOperations, Result.Data.Count)
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
                        Case 12
                            Debug.Print("Fetching Compressor")
                            Await FetchCompressor(Change)
                            PerformedOperations += 1
                        Case 2 'Person
                            Debug.Print("Fetching Person")
                            Await FetchPerson(Change)
                            PerformedOperations += 1
                        Case 203 'PersonCompressor
                            Debug.Print("Fetching PersonCompressor")
                            Await FetchPersonCompressor(Change)
                            PerformedOperations += 1
                        Case 205 'PersonCompressorSellableElapsedDay
                            Debug.Print("Fetching Coalescent")
                            Await FetchPersonCompressorCoalescent(Change)
                            PerformedOperations += 1
                        Case 6 'Product'
                            Debug.Print("Fetching Product")
                            Await FetchProduct(Change)
                            PerformedOperations += 1
                        Case 601 'ProductProviderCode'
                            Debug.Print("Fetching ProductCode")
                            Await FetchProductProviderCode(Change)
                            PerformedOperations += 1
                        Case 22 'VisitSchedule (Trata somente exclusões, o restante trata abaixo.
                            Debug.Print("Fetching VisitSchedule")
                            If Change("fieldname") = "Deleção" Then
                                Await FetchVisitSchedule(Change)
                                PerformedOperations += 1
                            End If
                        Case 23 'Service'
                            Debug.Print("Fetching Service")
                            Await FetchService(Change)
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
                _SessionModel.ManagerSetting.Cloud.Synchronization.CloudLastSyncID = LastSyncID
                _SessionModel.ManagerSetting.Cloud.Synchronization.CloudOperationCount = PerformedOperations + OperationCount
                _SessionModel.ManagerSetting.LastExecution.CloudDataSended = Now.ToString("yyyy-MM-dd HH:mm:ss")
                _SettingsService.Save(_SessionModel.ManagerSetting)
            End If
        End If
        Return RemainingOperations - PerformedOperations
    End Function



    Private Async Function SyncSchedules(RemainingOperations As Long, Response As AsyncResponseModel, Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
        Dim TotalChanges As Integer
        Dim PerformedOperations As Integer
        If RemainingOperations > 0 Then
            Dim Result = Await _LocalDB.ExecuteSelect("visitschedule",
                                                  New List(Of String) From {"id", "creation", "statusid", "visitdate", "calltypeid", "customerid", "personcompressorid", "instructions", "lastupdate", "userid"},
                                                  "lastupdate > @lastupdate",
                                                  New Dictionary(Of String, Object) From {{"@lastupdate", _SessionModel.ManagerSetting.LastExecution.Cloud}},
                                                  "id ASC")
            Dim LocalResult As List(Of Dictionary(Of String, Object)) = Result.Data
            Dim Conditions As New List(Of Condition) From {New WhereGreaterThanCondition("lastupdate", DateTimeHelper.MillisecondsFromDate(_SessionModel.ManagerSetting.LastExecution.Cloud))}
            Dim RemoteResult As List(Of Dictionary(Of String, Object)) = Await _RemoteDB.ExecuteGet("visitschedules", Conditions)
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


                'Existe alteracao dos dois lados, atualizar o local com o remoto, o status será 1 (finalizado) pois no mobile apenas atualizara o status, data da visita e lastupdate.

                For Each Schedule In CommonResult


                    Await _LocalDB.ExecuteUpdate("visitschedule",
                                                 New Dictionary(Of String, String) From {
                                                    {"statusid", "@statusid"},
                                                    {"visitdate", "@visitdate"},
                                                    {"lastupdate", "@lastupdate"},
                                                    {"id", "@id"}
                                                 },
                                                 "id = @id",
                                                 New Dictionary(Of String, Object) From {
                                                    {"@statusid", RemoteResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("statusid")},
                                                    {"@visitdate", DateTimeHelper.DateFromMilliseconds(RemoteResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("visitdate"))},
                                                    {"@lastupdate", DateTimeHelper.DateFromMilliseconds(RemoteResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("lastupdate"))},
                                                    {"@id", RemoteResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("id")}
                                                })
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
                    Await _LocalDB.ExecuteUpdate("visitschedule",
                                                 New Dictionary(Of String, String) From {
                                                    {"statusid", "@statusid"},
                                                    {"visitdate", "@visitdate"},
                                                    {"lastupdate", "@lastupdate"},
                                                    {"id", "@id"}
                                                 },
                                                 "id = @id",
                                                 New Dictionary(Of String, Object) From {
                                                    {"@statusid", Schedule("statusid")},
                                                    {"@visitdate", DateTimeHelper.DateFromMilliseconds(Schedule("visitdate"))},
                                                    {"@lastupdate", DateTimeHelper.DateFromMilliseconds(Schedule("lastupdate"))},
                                                    {"@id", Schedule("id")}
                                                })
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
                    Schedule("creationdate") = DateTimeHelper.MillisecondsFromDate(Schedule("creation"))
                    Schedule.Remove("creation")
                    Schedule.Remove("customerid")
                    Schedule("lastupdate") = DateTimeHelper.MillisecondsFromDate(Schedule("lastupdate"))
                    Schedule("visitdate") = DateTimeHelper.MillisecondsFromDate(Schedule("visitdate"))
                    Await _RemoteDB.ExecutePut("visitschedules", Schedule, Schedule("id"))
                    PerformedOperations += 1
                    Response.Percent = CInt((PerformedOperations / TotalChanges) * 100)
                    Response.Text = $"Sincronização com a núvem - Enviando novos agendamentos para a núvem - {(Response.Percent)}%"
                    Response.Event.AddChildEvent($"Enviando novos agendamentos para a núvem")
                    If Progress IsNot Nothing Then Progress.Report(Response)
                    Await Task.Delay(Constants.WaitForLoop)
                Next Schedule
            End If
        End If
    End Function



    Private Async Function FetchVisitSchedule(Change As Dictionary(Of String, Object)) As Task
        Await _RemoteDB.ExecuteUpdate("visitschedules",
                                          New Dictionary(Of String, Object) From {{"statusid", 3}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})

    End Function
    Private Async Function FetchCompressor(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelect("compressor",
                                                  New List(Of String) From {"id", "name"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CompressorData As Dictionary(Of String, Object)
            CompressorData = Result.Data(0)
            CompressorData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Change("changedate"))
            CompressorData("visible") = If(CompressorData("statusid") = 0, 1, 0)
            CompressorData.Remove("statusid")
            Await _RemoteDB.ExecutePut("compressors", CompressorData, CompressorData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("compressors",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchPersonCompressorCoalescent(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelect("personcompressorsellable",
                                                  New List(Of String) From {"id", "personcompressorid", "productid", "statusid", "sellablebindid"},
                                                  "id = @id AND controltypeid = @controltypeid",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}, {"@controltypeid", 1}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CoalescentData As Dictionary(Of String, Object)
            CoalescentData = Result.Data(0)
            CoalescentData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Change("changedate"))
            Dim SellableBindID = Convert.ToInt32(CoalescentData("sellablebindid"))
            If SellableBindID <> 5 Then CoalescentData("statusid") = 1
            CoalescentData("visible") = If(CoalescentData("statusid") = 0, 1, 0)
            CoalescentData.Remove("statusid")
            CoalescentData.Remove("sellablebindid")
            Await _RemoteDB.ExecutePut("coalescents", CoalescentData, CoalescentData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("coalescents",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchPersonCompressor(Change As Dictionary(Of String, Object)) As Task

        Dim Result = Await _LocalDB.ExecuteSelect("personcompressor",
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
            PersonCompressorData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Change("changedate"))
            PersonCompressorData("visible") = If(PersonCompressorData("statusid") = 0, 1, 0)
                PersonCompressorData.Remove("statusid")
                Await _RemoteDB.ExecutePut("personcompressors", PersonCompressorData, PersonCompressorData("id"))
            End If
            If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("personcompressors",
                                              New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                              New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If


    End Function
    Private Async Function FetchPerson(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelect("person",
                                                  New List(Of String) From {"id", "statusid", "document", "shortname", "iscustomer", "istechnician"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim PersonData As Dictionary(Of String, Object) = Result.Data(0)
            Dim IsCustomer = Convert.ToBoolean(PersonData("iscustomer"))
            Dim IsTechnician = Convert.ToBoolean(PersonData("istechnician"))
            PersonData("visible") = If(PersonData("statusid") = 0, 1, 0)
            PersonData.Remove("statusid")
            PersonData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Change("changedate"))
            Await _RemoteDB.ExecutePut("persons", PersonData, PersonData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("persons",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchProduct(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelect("product",
                                                  New List(Of String) From {"id", "statusid", "name"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ProductData As Dictionary(Of String, Object)
            ProductData = Result.Data(0)
            ProductData("visible") = If(ProductData("statusid") = 0, 1, 0)
            ProductData.Remove("statusid")
            ProductData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Change("changedate"))
            Await _RemoteDB.ExecutePut("products", ProductData, ProductData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("products",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchProductProviderCode(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelect("productprovidercode",
                                                  New List(Of String) From {"id", "productid", "code", "ismainprovider"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim CodeData As Dictionary(Of String, Object) = Result.Data(0)
            CodeData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Change("changedate"))
            Await _RemoteDB.ExecutePut("codes", CodeData, CodeData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("codes",
                                          New Dictionary(Of String, Object) From {{"ismainprovider", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function
    Private Async Function FetchService(Change As Dictionary(Of String, Object)) As Task
        Dim Result = Await _LocalDB.ExecuteSelect("service",
                                                  New List(Of String) From {"id", "statusid", "name"},
                                                  "id = @id",
                                                  New Dictionary(Of String, Object) From {{"@id", Change("registryid")}},
                                                  Limit:=1)
        If Result.Data IsNot Nothing AndAlso Result.Data.Count > 0 Then
            Dim ServiceData As Dictionary(Of String, Object)
            ServiceData = Result.Data(0)
            ServiceData("lastupdate") = DateTimeHelper.MillisecondsFromDate(Change("changedate"))
            ServiceData("visible") = If(ServiceData("statusid") = 0, 1, 0)
            ServiceData.Remove("statusid")
            Await _RemoteDB.ExecutePut("service", ServiceData, ServiceData("id"))
        End If
        If Change("fieldname") = "Deleção" Then
            Await _RemoteDB.ExecuteUpdate("service",
                                          New Dictionary(Of String, Object) From {{"visible", 0}, {"lastupdate", DateTimeHelper.MillisecondsFromDate(Change("changedate"))}},
                                          New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))})
        End If
    End Function


End Class
