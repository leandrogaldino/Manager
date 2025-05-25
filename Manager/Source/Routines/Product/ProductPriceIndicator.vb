Public Class ProductPriceIndicator
    Inherits SellablePriceIndicator
    Public Sub New(Indicator As PriceIndicator, Price As Decimal)
        SetRoutine(Routine.ProductPriceIndicator)
        Me.Indicator = Indicator
        Me.Price = Price
    End Sub
End Class
