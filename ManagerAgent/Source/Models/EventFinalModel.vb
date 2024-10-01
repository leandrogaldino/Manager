Public Class EventFinalModel
    Inherits EventModel
    Public Sub New(Description As String)
        Me.EventType = EventTypes.Final
        Me.Description = Description
    End Sub
End Class