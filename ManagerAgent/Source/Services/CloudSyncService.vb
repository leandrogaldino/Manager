Imports System.Text
Imports ManagerCore
Imports ManagerCore.LocalDB
Imports ManagerCore.RemoteDB

Public Class CloudSyncService
    Private _LocalDB As MySqlBackupService
    Private _RemoteDB As FirestoreService
    Public Sub New(LocalDB As LocalDB, RemoteDB As RemoteDB)
        _LocalDB = LocalDB
        _RemoteDB = RemoteDB
    End Sub
    Private Async Function ConfigOperations() As Task
        Dim Result As QueryResult = Await _LocalDB.ExecuteSelectAsync("config", {"value"}.ToList, "name = @name", New Dictionary(Of String, Object) From {{"@name", "CloudLastSyncDate"}})
        Dim LastSyncDate As Date = If(String.IsNullOrEmpty(Result.Data(0)("value")), Nothing, Result.Data(0)("value"))
        Dim Values As Dictionary(Of String, String)
        Dim Args As Dictionary(Of String, Object)
        Dim Where As String
        If (Now - LastSyncDate).TotalHours >= 24 Then
            Values = New Dictionary(Of String, String) From {{"value", "@value"}}
            Where = "name = @name"
            Args = New Dictionary(Of String, Object) From {{"@value", Now.ToString("yyyy-MM-dd HH:mm:ss")}, {"@name", "CloudLastSyncDate"}}
            Await _LocalDB.ExecuteUpdateAsync("config", Values, Where, Args)
            Args = New Dictionary(Of String, Object) From {{"@value", 0}, {"@name", "CloudOperationCount"}}
            Await _LocalDB.ExecuteUpdateAsync("config", Values, Where, Args)
        End If
    End Function

    Private Async Function GetLastSyncID() As Task(Of Integer)
        Dim Result As QueryResult = Await _LocalDB.ExecuteSelectAsync("config", {"value"}.ToList, "name = @name", New Dictionary(Of String, Object) From {{"@name", "CloudLastSyncID"}})
        Dim LastSyncID As Integer = Result.Data(0)("value")
        Return LastSyncID
    End Function

    Public Async Function FetchCloud(Optional Progress As IProgress(Of Object) = Nothing) As Task
        Dim LastSyncID As Integer = Await GetLastSyncID()
        Dim Columns As New List(Of String) From {"id", "routineid", "registryid", "fieldname", "oldvalue", "newvalue", "changedate"}
        Dim OrderBy As String = "id ASC"
        Dim Where As String = "id > @id AND routineid IN (@person, @personcompressor, @personcompressorpartelapsedday)"
        Dim WhereArgs As New Dictionary(Of String, Object) From {{"@id", LastSyncID}, {"@person", 2}, {"@personcompressor", 203}, {"@personcompressorpartelapsedday", 205}}
        Dim Result As QueryResult = Await _LocalDB.ExecuteSelectAsync("log", Columns, Where, WhereArgs, OrderBy)
        Await FetchCloudByRoutine(Result.Data, LastSyncID, Progress)
    End Function

    Private Async Function FetchCloudByRoutine(Changes As List(Of Dictionary(Of String, Object)), LastSyncID As Integer, Optional Progress As IProgress(Of Object) = Nothing) As Task(Of Integer)

        If Changes Is Nothing Then
            If Progress IsNot Nothing Then Progress.Report("Nenhuma alteração pendente para sincronização.")
            Return 0
        End If

        Await ConfigOperations()
        Dim PerformedOperations As Integer = 0
        Dim Columns As New List(Of String) From {"name", "value"}
        Dim Where As String = "name LIKE @name"
        Dim WhereArgs As New Dictionary(Of String, Object) From {{"@name", "Cloud%"}}
        Dim Result As QueryResult = Await _LocalDB.ExecuteSelectAsync("config", Columns, Where, WhereArgs)
        Dim LastSyncDateDictionary As Dictionary(Of String, Object) = Result.Data.First(Function(x) x("name") = "CloudLastSyncDate")
        Dim LastSyncDate As Date = If(String.IsNullOrEmpty(LastSyncDateDictionary("value")), Nothing, LastSyncDateDictionary("value"))
        Dim OperationCountDictionary As Dictionary(Of String, Object) = Result.Data.First(Function(x) x("name") = "CloudOperationCount")
        Dim OperationCount As Integer = If(String.IsNullOrEmpty(OperationCountDictionary("value")), 0, OperationCountDictionary("value"))
        If (Date.Now - LastSyncDate).TotalHours >= 24 Then
            OperationCount = 0
        End If
        Dim MaxOperationDictionary As Dictionary(Of String, Object) = Result.Data.First(Function(x) x("name") = "CloudMaxOperation")
        Dim MaxOperation As Integer = If(String.IsNullOrEmpty(MaxOperationDictionary("value")), 0, MaxOperationDictionary("value"))
        Dim RemainingOperations As Integer = MaxOperation - OperationCount
        If RemainingOperations > 0 Then
            Dim TotalChanges As Integer = If(Changes.Count > RemainingOperations, RemainingOperations, Changes.Count)
            For Each Change In Changes
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
                Dim ProgressPercentage As Integer = CInt((PerformedOperations / TotalChanges) * 100)
                If Progress IsNot Nothing Then Progress.Report(ProgressPercentage)
                If PerformedOperations >= RemainingOperations Then
                    Exit For
                End If
            Next Change
        Else
            If Progress IsNot Nothing Then Progress.Report("Nenhuma alteração pendente para sincronização.")
        End If
        Await SaveCloudConfig(LastSyncID, PerformedOperations + OperationCount)
        Return PerformedOperations
    End Function
    Private Async Function FetchPersonCompressorCoalescent(Change As Dictionary(Of String, Object)) As Task
        Dim Args As New Dictionary(Of String, Object) From {{"@id", Change("registryid")}, {"@parttypeid", 1}}
        Dim Result = Await _LocalDB.ExecuteRawQueryAsync("SELECT pcp.id, pcp.personcompressorid, pcp.statusid, pcp.partbindid, IFNULL(pcp.itemname, p.name) coalescentname  FROM personcompressorpart pcp  LEFT JOIN product p ON pcp.productid = p.id WHERE pcp.parttypeid = @parttypeid AND pcp.id = @id LIMIT 1", Args)
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
        Dim Conditions As New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))}
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
        Dim Result = Await _LocalDB.ExecuteRawQueryAsync("SELECT pc.id, pc.statusid, pc.personid, pc.compressorid, c.name compressorname,  IFNULL(pc.serialnumber, '') serialnumber  FROM personcompressor pc LEFT JOIN compressor c ON pc.compressorid = c.id WHERE pc.id = @id LIMIT 1", Args)
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
        Dim Conditions As New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))}
        If MustMaintain Then
            If CompressorData IsNot Nothing Then
                Dim DocumentName As String = RemoveSpecialCharacters($"ID: {CompressorData("id")} - {CompressorData("compressorname")}")
                Await _RemoteDB.ExecutePut("compressors", CompressorData, DocumentName)
            End If
        Else
            Await _RemoteDB.ExecuteDelete("compressors", Conditions)
            If Change("fieldname") = "Deleção" Then
                Conditions = New List(Of Condition) From {New WhereEqualToCondition("personcompressorid", Change("registryid"))}
                Await _RemoteDB.ExecuteDelete("coalescents", Conditions)
            End If
        End If
    End Function
    Private Async Function FetchPerson(Change As Dictionary(Of String, Object)) As Task
        Dim Columns As New List(Of String) From {"id", "statusid", "document", "shortname", "iscustomer", "istechnician"}
        Dim Where As String = "id = @id"
        Dim WhereArgs As New Dictionary(Of String, Object) From {{"@id", Change("registryid")}}
        Dim Result = Await _LocalDB.ExecuteSelectAsync("person", Columns, Where, WhereArgs, Limit:=1)
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

        Dim Conditions As New List(Of Condition) From {New WhereEqualToCondition("id", Change("registryid"))}

        If MustMaintain Then
            If PersonData IsNot Nothing Then
                Dim DocumentName As String = RemoveSpecialCharacters($"ID: {PersonData("id")} - {PersonData("shortname")}")
                Await _RemoteDB.ExecutePut("persons", PersonData, DocumentName)
            End If
        Else

            Await _RemoteDB.ExecuteDelete("persons", Conditions)
            If Change("fieldname") = "Deleção" Then


                Conditions = New List(Of Condition) From {New WhereEqualToCondition("personid", Change("registryid"))}
                Dim CompressorsData = Await _RemoteDB.ExecuteGet("compressors", Conditions)
                For Each Compressor In CompressorsData
                    Await _RemoteDB.ExecuteDelete("compressors", Conditions)
                    Conditions = New List(Of Condition) From {New WhereEqualToCondition("personcompressorid", Compressor("id"))}
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
        Await _LocalDB.ExecuteUpdateAsync("config", Values, Where, WhereArgs)
        WhereArgs = New Dictionary(Of String, Object) From {{"@value", CloudOperationCount}, {"@name", "CloudOperationCount"}}
        Await _LocalDB.ExecuteUpdateAsync("config", Values, Where, WhereArgs)
        WhereArgs = New Dictionary(Of String, Object) From {{"@value", Now.ToString("yyyy-MM-dd HH:MM:ss")}, {"@name", "CloudLastSyncDate"}}
        Await _LocalDB.ExecuteUpdateAsync("config", Values, Where, WhereArgs)
    End Function
End Class
