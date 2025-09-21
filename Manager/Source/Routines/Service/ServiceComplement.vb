Public Class ServiceComplement
    Inherits ChildModel
    Public Property Complement As String
    Public Sub New()
        SetRoutine(Routine.ServiceComplement)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ServiceComplement With {
            .Complement = Complement
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
