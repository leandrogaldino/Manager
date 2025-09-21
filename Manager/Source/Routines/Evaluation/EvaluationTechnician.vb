Public Class EvaluationTechnician
    Inherits ChildModel
    Public Property Technician As New Person
    Public Sub New()
        SetRoutine(Routine.EvaluationTechnician)
    End Sub

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New EvaluationTechnician With {
            .Technician = CType(Technician.Clone(), Person)
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
