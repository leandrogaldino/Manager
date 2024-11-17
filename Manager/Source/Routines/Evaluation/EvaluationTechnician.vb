Public Class EvaluationTechnician
    Inherits ChildModel
    Public Property Technician As New Person
    Public Sub New()
        SetRoutine(Routine.EvaluationTechnician)
    End Sub
End Class
