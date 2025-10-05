Public Class ProductPriceIndicator
    Inherits SellablePriceIndicator
    Public Sub New(Indicator As PriceIndicator, Price As Decimal)
        SetRoutine(Routine.ProductPriceIndicator)
        Me.Indicator = Indicator
        Me.Price = Price
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ProductPriceIndicator(Me.Indicator, Me.Price)
        Cloned.SetID(Me.ID)
        Cloned.SetCreation(Me.Creation)
        Cloned.SetIsSaved(Me.IsSaved)
        Return Cloned
    End Function
End Class
