''' <summary>
''' Representa o preço de um produto.
''' </summary>
Public Class SellablePrice
    Inherits SellablePriceModel
    Public Property PriceTable As New SellablePriceTable
    Public Property Price As Decimal
    Public Sub New()
        SetRoutine(Routine.SellablePrice)
    End Sub
End Class
