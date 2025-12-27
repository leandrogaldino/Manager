Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Threading
Imports ManagerCore
Imports Newtonsoft.Json
Public Class EventService
    Private ReadOnly _Semaphore As SemaphoreSlim

    Public Sub New(Semaphore As SemaphoreSlim)
        _Semaphore = Semaphore
    End Sub
    Public Sub Write([Event] As EventModel, Data As DataTable)
        If Data Is Nothing OrElse Data.Columns.Count = 0 Then Exit Sub
        WriteSingle([Event], Data)
    End Sub
    Private Sub WriteSingle([Event] As EventModel, Data As DataTable)
        If Not [Event].ReadyToPost Then Return
        Dim NewRow As DataRow
        If Data Is Nothing OrElse Data.Columns.Count = 0 Then Exit Sub
        NewRow = Data.NewRow()
        NewRow.Item("ID") = [Event].ID
        NewRow.Item("StartTime") = [Event].StartTime.ToString("dd/MM/yyyy HH:mm:ss")
        NewRow.Item("EndTime") = [Event].EndTime.ToString("dd/MM/yyyy HH:mm:ss")
        NewRow.Item("Description") = [Event].GetFullDescription
        NewRow.Item("IsSaved") = False
        Data.Rows.InsertAt(NewRow, 0)
    End Sub
    Public Async Function Save(Data As DataTable) As Task
        Dim EventModel As EventModel
        Dim EventList As EventList
        If Data Is Nothing OrElse Data.Columns.Count = 0 Then Return
        If Data.Rows.Cast(Of DataRow).Any(Function(x) Not CBool(x("IsSaved"))) Then
            Await _Semaphore.WaitAsync()
            Try
                Dim JsonPath As String = Path.Combine(ApplicationPaths.FilesDirectory, "AgentEvents.json")
                If File.Exists(JsonPath) Then
                    Using fs As New FileStream(JsonPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync:=True)
                        Using sr As New StreamReader(fs, Encoding.UTF8)
                            Dim jsonExistente As String = Await sr.ReadToEndAsync()
                            EventList = JsonConvert.DeserializeObject(Of EventList)(jsonExistente)
                        End Using
                    End Using
                Else
                    EventList = New EventList()
                End If
                If EventList Is Nothing Then
                    EventList = New EventList()
                End If
                For Each Row As DataRow In Data.Rows.Cast(Of DataRow).Where(Function(x) Not CBool(x("IsSaved"))).Reverse()
                    EventModel = New EventModel(
                        Convert.ToString(Row("ID")),
                        DateTime.ParseExact(Row("StartTime"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                        DateTime.ParseExact(Row("EndTime"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                        Convert.ToString(Row("Description").ToString.Replace($"{Constants.SeparatorSymbol} ", ""))
                    )
                    EventList.Events.Add(EventModel)
                Next Row
                Dim Json As String = JsonConvert.SerializeObject(EventList, Formatting.Indented)
                Using fs As New FileStream(JsonPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                    Dim buffer As Byte() = Encoding.UTF8.GetBytes(Json)
                    Await fs.WriteAsync(buffer, 0, buffer.Length)
                End Using
                For Each Row As DataRow In Data.Rows.Cast(Of DataRow).Where(Function(x) Not CBool(x("IsSaved")))
                    Row("issaved") = True
                Next
            Catch ex As Exception
                EventModel = New EventModel(
                    Now,
                    $"Ocorreu um erro ao salvar os eventos - {ex.Message}"
                )
                WriteSingle(EventModel, Data)
            Finally
                _Semaphore.Release()
            End Try
        End If
    End Function
    Public Async Function Read() As Task(Of DataTable)
        Dim EventModel As EventModel
        Dim table As New DataTable()
        table.Columns.Add("ID", GetType(String))
        table.Columns.Add("StartTime", GetType(String))
        table.Columns.Add("EndTime", GetType(String))
        table.Columns.Add("Description", GetType(String))
        table.Columns.Add("IsSaved", GetType(Boolean))
        Dim JsonPath As String = Path.Combine(ApplicationPaths.FilesDirectory, "AgentEvents.json")
        If Not File.Exists(JsonPath) Then
            Return table
        End If
        Await _Semaphore.WaitAsync()
        Await CleanupOldEventsAsync(JsonPath, table)
        Try
            Dim eventList As EventList
            Using fs As New FileStream(JsonPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync:=True)
                Using sr As New StreamReader(fs, Encoding.UTF8)
                    Dim json As String = Await sr.ReadToEndAsync()
                    eventList = JsonConvert.DeserializeObject(Of EventList)(json)
                End Using
            End Using
            If eventList Is Nothing OrElse eventList.Events Is Nothing Then
                Return table
            End If
            For Each [Event] As EventModel In eventList.Events
                Dim row = table.NewRow()
                row("ID") = [Event].ID.ToString()
                row("StartTime") = [Event].StartTime.ToString("dd/MM/yyyy HH:mm:ss")
                row("EndTime") = [Event].EndTime.ToString("dd/MM/yyyy HH:mm:ss")
                row("Description") = [Event].Description
                row("IsSaved") = True
                table.Rows.Add(row)
            Next
            Return table
        Catch ex As Exception
            EventModel = New EventModel(
                Now,
                $"Ocorreu um erro ao carregar os eventos - {ex.Message}"
            )
            WriteSingle(EventModel, table)
            Return table
        Finally
            _Semaphore.Release()
        End Try
    End Function
    Private Async Function CleanupOldEventsAsync(JsonPath As String, Table As DataTable, Optional months As Integer = 3) As Task
        Dim EventModel As EventModel

        Try
            Dim eventList As EventList
            Using fs As New FileStream(JsonPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync:=True)
                Using sr As New StreamReader(fs, Encoding.UTF8)
                    Dim json As String = Await sr.ReadToEndAsync()
                    eventList = JsonConvert.DeserializeObject(Of EventList)(json)
                End Using
            End Using
            If eventList Is Nothing OrElse eventList.Events Is Nothing Then Return
            Dim limitDate As DateTime = DateTime.Now.AddMonths(-months)
            eventList.Events = eventList.Events.Where(Function(e) e.EndTime >= limitDate).OrderBy(Function(e) e.EndTime).ToList()
            Dim newJson As String = JsonConvert.SerializeObject(eventList, Formatting.Indented)
            Using fs As New FileStream(JsonPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                Dim buffer As Byte() = Encoding.UTF8.GetBytes(newJson)
                Await fs.WriteAsync(buffer, 0, buffer.Length)
            End Using
        Catch ex As Exception
            EventModel = New EventModel(
                Now,
                $"Ocorreu um erro ao limpar os eventos - {ex.Message}"
            )
            WriteSingle(EventModel, Table)
        End Try
    End Function

End Class