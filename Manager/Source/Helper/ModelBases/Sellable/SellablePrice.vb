Public Class SellablePrice
    Inherits ChildModel
    Public Property PriceTableID As Long
    Public Property PriceTableName As String
    Public Property PriceTable As New Lazy(Of PriceTable)
    Public Property Price As Decimal
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New SellablePrice With {
            .Price = Price,
            .PriceTableID = PriceTableID,
            .PriceTableName = PriceTableName,
            .PriceTable = New Lazy(Of PriceTable)(
            Function()
                If PriceTable.IsValueCreated Then
                    Return CType(PriceTable.Value.Clone(), PriceTable)
                Else
                    Return New PriceTable().Load(PriceTableID, False)
                End If
            End Function)
        }
        Cloned.SetID(ID)
        Cloned.SetCreation(Creation)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function
End Class
