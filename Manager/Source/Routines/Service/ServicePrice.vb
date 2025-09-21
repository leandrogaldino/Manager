Public Class ServicePrice
    Inherits SellablePrice
    Public Sub New()
        SetRoutine(Routine.ServicePrice)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Return MyBase.Clone()
    End Function
End Class
