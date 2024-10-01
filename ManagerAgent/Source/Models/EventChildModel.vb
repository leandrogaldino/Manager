Public Class EventChildModel
    Inherits EventModel
    Public Sub New(Description As String)
        Me.EventType = EventTypes.Child
        Me.Description = Description
    End Sub
End Class