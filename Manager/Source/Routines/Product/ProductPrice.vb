Public Class ProductPrice
    Inherits SellablePrice
    Public Sub New()
        SetRoutine(Routine.ProductPrice)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ProductPrice With {
            .Price = Me.Price,
            .PriceTableID = Me.PriceTableID,
            .PriceTableName = Me.PriceTableName,
            .PriceTable = New Lazy(Of PriceTable)(
                Function()
                    If PriceTable.IsValueCreated Then
                        Return CType(PriceTable.Value.Clone(), PriceTable)
                    Else
                        Return New PriceTable().Load(PriceTableID, False)
                    End If
                End Function
            )
        }
        Cloned.SetID(Me.ID)
        Cloned.SetCreation(Me.Creation)
        Cloned.SetIsSaved(Me.IsSaved)
        Return Cloned
    End Function
End Class
