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




                'A PARTIR DAQUI O FOCO MUDA E SINCRONIZA OS DADOS DE UMA TABELA ESPECIFICA COM A NUVEM


                Columns = New List(Of String) From {"id", "creation", "statusid", "visitdate", "visittypeid", "customerid", "personcompressorid", "instructions", "evaluationid", "lastupdate", "userid"}
                OrderBy = "id ASC"
                Where = "lastupdate > @lastupdate AND parentid IS NULL"
                Args = New Dictionary(Of String, Object) From {{"@lastupdate", _SessionModel.ManagerSetting.LastExecution.CloudVisitScheduleSync}}
                Result = Await _LocalDB.ExecuteSelect("visitschedule", Columns, Where, Args, OrderBy)
                Dim LocalResult As List(Of Dictionary(Of String, Object)) = Result.Data
                Dim Conditions As New List(Of RemoteDB.Condition) From {New WhereGreaterThanCondition("lastupdate", DateTimeHelper.MillisecondsFromDate(_SessionModel.ManagerSetting.LastExecution.CloudVisitScheduleSync))}
                Dim RemoteResult As List(Of Dictionary(Of String, Object)) = Await _RemoteDB.ExecuteGet("schedule", Conditions)
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
                        Dim Values As New Dictionary(Of String, String) From {
                            {"creation", "@creation"},
                            {"statusid", "@statusid"},
                            {"visitdate", "@visitdate"},
                            {"visittypeid", "@visittypeid"},
                            {"customerid", "@customerid"},
                            {"personcompressorid", "@personcompressorid"},
                            {"instructions", "@instructions"},
                            {"evaluationid", "@evaluationid"},
                            {"lastupdate", "@lastupdate"},
                            {"userid", "@userid"},
                            {"parentid", "@parentid"}
                        }
                        Args = New Dictionary(Of String, Object) From {
                            {"@creation", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("creation")},
                            {"@statusid", 4},
                            {"@visitdate", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("visitdate")},
                            {"@visittypeid", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("visittypeid")},
                            {"@customerid", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("customerid")},
                            {"@personcompressorid", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("personcompressorid")},
                            {"@instructions", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("instructions")},
                            {"@evaluationid", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("evaluationid")},
                            {"@lastupdate", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("lastupdate")},
                            {"@userid", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("userid")},
                            {"@parentid", LocalResult.First(Function(x) x("id").ToString.Equals(Schedule("id").ToString))("id")}
                        }
                        Await _LocalDB.ExecuteInsert("visitschedule", Values, Args)
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
                            {"@lastupdate", DateTimeHelper.DateFromMilliseconds(Schedule("lastupdate"))},
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
                            {"@statusid", Schedule("statusid")},
                            {"@visitdate", DateTimeHelper.DateFromMilliseconds(Schedule("visitdate"))},
                            {"@lastupdate", DateTimeHelper.DateFromMilliseconds(Schedule("lastupdate"))},
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
                        Schedule("creation") = DateTimeHelper.MillisecondsFromDate(Schedule("creation"))
                        Schedule("lastupdate") = DateTimeHelper.MillisecondsFromDate(Schedule("lastupdate"))
                        Schedule("visitdate") = DateTimeHelper.MillisecondsFromDate(Schedule("visitdate"))
                        Await _RemoteDB.ExecutePut("schedule", Schedule, Schedule("id"))
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
        Dim CoalescentData As Dictionary(Of String, Object) = Nothing
        Dim MustMaintain As Boolean
        If Result.Data Is Nothing OrElse Result.Data.Count = 0 Then
            MustMaintain = False
        Else
            CoalescentData = Result.Data(0)
            Dim StatusID = Convert.ToInt32(CoalescentData("statusid"))
            Dim PartBindID = Convert.ToInt32(CoalescentData("partbindid"))
            CoalescentData("lastchange") = Now.ToString("yyyy-MM-dd HH:mm:ss")
            CoalescentData.Remove("statusid")
            CoalescentData.Remove("partbindid")
            If StatusID = 0 And PartBindID = 5 Then
                MustMaintain = True
            Else
                MustMaintain = False
            End If
        End If
        Dim Conditions As New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("id", Change("registryid"))}
        If MustMaintain Then
            If CoalescentData IsNot Nothing Then
                Dim DocumentName As String = RemoveSpecialCharacters($"ID: {CoalescentData("id")} - {CoalescentData("coalescentname")}")
                Await _RemoteDB.ExecutePut("coalescents", CoalescentData, DocumentName)
            End If
        Else
            Await _RemoteDB.ExecuteDelete("coalescents", Conditions)
        End If
    End Function
    Private Async Function FetchPersonCompressor(Change As Dictionary(Of String, Object)) As Task
        Dim Args As New Dictionary(Of String, Object) From {{"@id", Change("registryid")}}
        Dim Result = Await _LocalDB.ExecuteRawQuery("SELECT pc.id, pc.statusid, pc.personid, pc.compressorid, c.name compressorname,  IFNULL(pc.serialnumber, '') serialnumber  FROM personcompressor pc LEFT JOIN compressor c ON pc.compressorid = c.id WHERE pc.id = @id LIMIT 1", Args)
        Dim MustMaintain As Boolean
        Dim CompressorData As Dictionary(Of String, Object) = Nothing
        If Result.Data Is Nothing OrElse Result.Data.Count = 0 Then
            MustMaintain = False
        Else
            CompressorData = Result.Data(0)
            Dim StatusID = Convert.ToInt32(CompressorData("statusid"))
            CompressorData("lastchange") = Now.ToString("yyyy-MM-dd HH:mm:ss")
            CompressorData.Remove("statusid")
            If StatusID = 0 Then
                MustMaintain = True
            Else
                MustMaintain = False
            End If
        End If
        Dim Conditions As New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("id", Change("registryid"))}
        If MustMaintain Then
            If CompressorData IsNot Nothing Then
                Dim DocumentName As String = RemoveSpecialCharacters($"ID: {CompressorData("id")} - {CompressorData("compressorname")}")
                Await _RemoteDB.ExecutePut("compressors", CompressorData, DocumentName)
            End If
        Else
            Await _RemoteDB.ExecuteDelete("compressors", Conditions)
            If Change("fieldname") = "Deleção" Then
                Conditions = New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("personcompressorid", Change("registryid"))}
                Await _RemoteDB.ExecuteDelete("coalescents", Conditions)
            End If
        End If
    End Function
    Private Async Function FetchPerson(Change As Dictionary(Of String, Object)) As Task
        Dim Columns As New List(Of String) From {"id", "statusid", "document", "shortname", "iscustomer", "istechnician"}
        Dim Where As String = "id = @id"
        Dim WhereArgs As New Dictionary(Of String, Object) From {{"@id", Change("registryid")}}
        Dim Result = Await _LocalDB.ExecuteSelect("person", Columns, Where, WhereArgs, Limit:=1)
        Dim MustMaintain As Boolean
        Dim PersonData As Dictionary(Of String, Object) = Nothing
        If Result.Data Is Nothing OrElse Result.Data.Count = 0 Then
            MustMaintain = False
        Else
            PersonData = Result.Data(0)
            Dim IsCustomer = Convert.ToBoolean(PersonData("iscustomer"))
            Dim IsTechnician = Convert.ToBoolean(PersonData("istechnician"))
            Dim StatusID = Convert.ToInt32(PersonData("statusid"))
            PersonData("lastchange") = Now.ToString("yyyy-MM-dd HH:mm:ss")
            PersonData.Remove("statusid")
            If StatusID = 0 And (IsCustomer Or IsTechnician) Then
                MustMaintain = True
            Else
                MustMaintain = False
            End If
        End If

        Dim Conditions As New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("id", Change("registryid"))}

        If MustMaintain Then
            If PersonData IsNot Nothing Then
                Dim DocumentName As String = RemoveSpecialCharacters($"ID: {PersonData("id")} - {PersonData("shortname")}")
                Await _RemoteDB.ExecutePut("persons", PersonData, DocumentName)
            End If
        Else

            Await _RemoteDB.ExecuteDelete("persons", Conditions)
            If Change("fieldname") = "Deleção" Then


                Conditions = New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("personid", Change("registryid"))}
                Dim CompressorsData = Await _RemoteDB.ExecuteGet("compressors", Conditions)
                For Each Compressor In CompressorsData
                    Await _RemoteDB.ExecuteDelete("compressors", Conditions)
                    Conditions = New List(Of RemoteDB.Condition) From {New WhereEqualToCondition("personcompressorid", Compressor("id"))}
                    Await _RemoteDB.ExecuteDelete("coalescents", Conditions)
                Next Compressor

            End If
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
