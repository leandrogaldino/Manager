Public Class ProductPrice
    Inherits SellablePrice
    Public Sub New()
        SetRoutine(Routine.ProductPrice)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Return MyBase.Clone()
    End Function
End Class
