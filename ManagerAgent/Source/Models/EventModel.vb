Public Enum EventTypes
    Initial = 0
    Child = 1
    Final = 2
End Enum
Public MustInherit Class EventModel
    Public Property ID As Long
    Public Property ParentID As Long
    Public Property EventType As EventTypes
    Public Property Time As Date = Now
    Public Property Description As String
    Public Property Processed As Boolean
    Public Property TempID As String
End Class



