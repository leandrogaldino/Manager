Public Class SellablePrice
    Inherits ChildModel
    Public Property PriceTableID As Long
    Public Property PriceTableName As String
    Public Property PriceTable As Lazy(Of PriceTable)
    Public Property Price As Decimal
End Class
