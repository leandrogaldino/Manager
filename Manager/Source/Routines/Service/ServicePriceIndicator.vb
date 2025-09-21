Public Class ServicePriceIndicator
    Inherits SellablePriceIndicator
    Public Sub New(Indicator As PriceIndicator, Price As Decimal)
        SetRoutine(Routine.ServicePriceIndicator)
        Me.Indicator = Indicator
        Me.Price = Price
    End Sub
    Public Overrides Function Clone() As BaseModel
        Return MyBase.Clone()
    End Function
End Class
