Imports Newtonsoft.Json

Public Class EventModel
    <JsonIgnore>
    Public ReadyToPost As Boolean = False
    Public Property ID As String = Guid.NewGuid().ToString()
    Public Property StartTime As Date = Now
    Public Property EndTime As Date
    Public Property Description As String
    Public Property ExceptionMessage As String

    Public Function GetFullDescription() As String
        Dim TimeInfo As String = $"Início: {StartTime:dd/MM/yyyy HH:mm:ss} {Constants.SeparatorSymbol} " & $"Fim: {EndTime:dd/MM/yyyy HH:mm:ss}"

        If String.IsNullOrEmpty(ExceptionMessage) Then
            Return $"{Description}: {TimeInfo}"
        Else
            Return $"{Description}: {TimeInfo} {Constants.SeparatorSymbol} [ERRO]: {ExceptionMessage}"
        End If
    End Function
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

