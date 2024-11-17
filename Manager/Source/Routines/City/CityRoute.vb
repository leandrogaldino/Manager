Imports ControlLibrary
Imports Manager.Util
''' <summary>
''' Representa uma rota de uma cidade.
''' </summary>
Public Class CityRoute
    Inherits ChildModel
    Public Property Route As New Route
    Public Sub New()
        SetRoutine(Routine.CityRoute)
    End Sub
End Class
