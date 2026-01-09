Imports ControlLibrary

Public Class EventInitialModel
    Inherits EventModel
    Public Sub New(Description As String)
        Me.EventType = EventTypes.Initial
        Me.Description = Description
        TempID = TextHelper.GetRandomString(1, 64, Nothing, {CharFilter.Alphanumeric, CharFilter.Numeric, CharFilter.SpecialCharacters}.ToList())
    End Sub
End Class
