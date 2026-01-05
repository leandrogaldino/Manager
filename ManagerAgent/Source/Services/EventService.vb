Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Threading
Imports ManagerCore
Imports Newtonsoft.Json
Imports CoreSuite.Helpers
Public Class EventService
    Private ReadOnly _Semaphore As SemaphoreSlim
    Private _HasErrorOnSave As Boolean = False
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
        NewRow.Item("Status") = EnumHelper.GetEnumDescription([Event].Status)
        NewRow.Item("StartTime") = [Event].StartTime.ToString("dd/MM/yyyy HH:mm:ss")
        NewRow.Item("EndTime") = [Event].EndTime.ToString("dd/MM/yyyy HH:mm:ss")
        NewRow.Item("Description") = [Event].Description
        NewRow.Item("IsSaved") = False
        NewRow.Item("ExceptionMessage") = [Event].ExceptionMessage
        NewRow.Item("LogMessages") = [Event].LogMessages
        Data.Rows.InsertAt(NewRow, 0)
    End Sub
    Public Async Function Save(Data As DataTable) As Task
        Dim EventModel As EventModel
        Dim EventList As EventList
        Dim Exception As Exception = Nothing
        If _HasErrorOnSave Then Return
        If Data Is Nothing OrElse Data.Columns.Count = 0 Then Return
        If Data.Rows.Cast(Of DataRow).Any(Function(x) Not CBool(x("IsSaved"))) Then
            Await _Semaphore.WaitAsync()
            Try
                Dim JsonPath As String = Path.Combine(ApplicationPaths.AgentEventsFile)
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
                        Convert.ToString(Row("Description"))
                    ) With {
                        .Status = EnumHelper.GetEnumValue(Of TaskStatus)(Row("Status")),
                        .ExceptionMessage = If(Row("ExceptionMessage") Is DBNull.Value, String.Empty, Row("ExceptionMessage")),
                        .LogMessages = Row("LogMessages")
                    }
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
                _HasErrorOnSave = True
                Dim [Event] As New EventModel(Now, "Erro ao salvar os eventos") With {
                    .ReadyToPost = True,
                    .Status = TaskStatus.Error,
                    .ExceptionMessage = $"{ex.Message}{vbNewLine}{ex.StackTrace}"
                }
                WriteSingle([Event], Data)
            Finally
                _Semaphore.Release()
            End Try
        End If
    End Function
    Public Async Function Read() As Task(Of DataTable)
        Dim Table As New DataTable()
        Table.Columns.Add("ID", GetType(String))
        Table.Columns.Add("StartTime", GetType(String))
        Table.Columns.Add("EndTime", GetType(String))
        Table.Columns.Add("Description", GetType(String))
        Table.Columns.Add("Status", GetType(String))
        Table.Columns.Add("IsSaved", GetType(Boolean))
        Table.Columns.Add("ExceptionMessage", GetType(String))
        Table.Columns.Add("LogMessages", GetType(List(Of String)))
        Dim JsonPath As String = Path.Combine(ApplicationPaths.AgentEventsFile)
        If Not File.Exists(JsonPath) Then
            Return Table
        End If
        Await _Semaphore.WaitAsync()
        Await CleanupOldEventsAsync(JsonPath, Table)
        Try
            Dim EventList As EventList
            Using fs As New FileStream(JsonPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync:=True)
                Using sr As New StreamReader(fs, Encoding.UTF8)
                    Dim json As String = Await sr.ReadToEndAsync()
                    EventList = JsonConvert.DeserializeObject(Of EventList)(json)
                End Using
            End Using
            If EventList Is Nothing OrElse EventList.Events Is Nothing Then
                Return Table
            End If
            EventList.Events = EventList.Events.OrderByDescending(Function(e) e.EndTime).ToList()
            For Each [Event] As EventModel In EventList.Events
                Dim row = Table.NewRow()
                row("ID") = [Event].ID.ToString()
                row("StartTime") = [Event].StartTime.ToString("dd/MM/yyyy HH:mm:ss")
                row("EndTime") = [Event].EndTime.ToString("dd/MM/yyyy HH:mm:ss")
                row("Description") = [Event].Description
                row("Status") = EnumHelper.GetEnumDescription([Event].Status)
                row("IsSaved") = True
                row("ExceptionMessage") = [Event].ExceptionMessage
                row("LogMessages") = [Event].LogMessages
                Table.Rows.Add(row)
            Next
            Return Table
        Catch ex As Exception
            Dim [Event] As New EventModel(Now, "Erro ao carregar os eventos") With {
                .ReadyToPost = True,
                .Status = TaskStatus.Error,
                .ExceptionMessage = $"{ex.Message}{vbNewLine}{ex.StackTrace}"
            }
            WriteSingle([Event], Table)
        Finally
            _Semaphore.Release()
        End Try
        Return Table
    End Function
    Private Async Function CleanupOldEventsAsync(JsonPath As String, Table As DataTable, Optional months As Integer = 3) As Task
        Try
            Dim EventList As EventList
            Using FileStream As New FileStream(JsonPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync:=True)
                Using StreamReader As New StreamReader(FileStream, Encoding.UTF8)
                    Dim Json As String = Await StreamReader.ReadToEndAsync()
                    EventList = JsonConvert.DeserializeObject(Of EventList)(Json)
                End Using
            End Using
            If EventList Is Nothing OrElse EventList.Events Is Nothing Then Return
            Dim LimitDate As DateTime = DateTime.Now.AddMonths(-months)
            EventList.Events = EventList.Events.Where(Function(e) e.EndTime >= LimitDate).OrderBy(Function(e) e.EndTime).ToList()
            Dim NewJson As String = JsonConvert.SerializeObject(EventList, Formatting.Indented)
            Using FileStream As New FileStream(JsonPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                Dim Buffer As Byte() = Encoding.UTF8.GetBytes(NewJson)
                Await FileStream.WriteAsync(Buffer, 0, Buffer.Length)
            End Using
        Catch ex As Exception
            Dim [Event] As New EventModel(Now, "Erro ao limpar os eventos")
            [Event].ReadyToPost = True
            [Event].Status = TaskStatus.Error
            [Event].ExceptionMessage = $"{ex.Message}{vbNewLine}{ex.StackTrace}"
            WriteSingle([Event], Table)
        End Try
    End Function
End Class