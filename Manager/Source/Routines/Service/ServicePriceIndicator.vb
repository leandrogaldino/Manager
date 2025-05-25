Public Class ServicePriceIndicator
    Inherits SellablePriceIndicator
    Public Sub New(Indicator As PriceIndicator, Price As Decimal)
        Me.Indicator = Indicator
        Me.Price = Price
    End Sub
End Class
