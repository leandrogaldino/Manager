Public Class AsyncResponseModel
    Public Property [Event] As New EventModel
    Public Property Text As String
    Public Property Percent As Integer

    Public Sub SetTextAndLog(Message As String)
        Me.Text = Message
        Me.Event.LogMessages.Add(Message)
    End Sub
End Class