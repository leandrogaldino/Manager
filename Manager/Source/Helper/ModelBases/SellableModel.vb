Public Class SellableModel
    Inherits ParentModel
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Prices As New List(Of SellablePrice)
    Public Property Note As String
End Class
