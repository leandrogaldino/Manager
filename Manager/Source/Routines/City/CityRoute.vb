''' <summary>
''' Representa uma rota de uma cidade.
''' </summary>
Public Class CityRoute
    Inherits ChildModel
    Public Property Route As New Route
    Public Sub New()
        SetRoutine(Routine.CityRoute)
    End Sub

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New CityRoute With {
            .Route = CType(Route.Clone(), Route)
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
