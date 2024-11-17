''' <summary>
''' Representa o preço de um produto.
''' </summary>
Public Class ProductPrice
    Inherits ChildModel
    Public Property PriceTable As New ProductPriceTable
    Public Property Price As Decimal
    Public Sub New()
        SetRoutine(Routine.ProductPrice)
    End Sub
End Class
