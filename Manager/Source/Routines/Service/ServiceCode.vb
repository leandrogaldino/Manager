Public Class ServiceCode
    Inherits SellableCode
    Public Sub New()
        SetRoutine(Routine.ServiceCode)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Return MyBase.Clone()
    End Function
End Class
