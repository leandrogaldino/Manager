Imports Newtonsoft.Json

Public Class EventModel
    <JsonIgnore>
    Public ReadyToPost As Boolean = False
    Public Property ID As String = Guid.NewGuid().ToString()
    Public Property StartTime As Date = Now
    Public Property EndTime As Date
    Public Property Description As String
    Public Property ExceptionMessage As String
    Public Property LogMessages As New List(Of String)
    Public Property Status As TaskStatus
    Public Sub New(ID As String, StartTime As Date, EndTime As Date, Description As String)
        Me.ID = ID
        Me.StartTime = StartTime
        Me.EndTime = EndTime
        Me.Description = Description
        Me.ReadyToPost = ReadyToPost
    End Sub

    Public Sub New(EndTime As Date, Description As String)
        Me.EndTime = EndTime
        Me.Description = Description
    End Sub

    Public Sub New()

    End Sub
End Class

Public Class EventList
    Public Property Events As New List(Of EventModel)
End Class

