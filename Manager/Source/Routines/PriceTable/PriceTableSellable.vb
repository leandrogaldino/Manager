Imports ControlLibrary
Public Class PriceTableSellable
    Inherits ChildModel
    <IgnoreInToTable>
    Public Property SellableType As SellableType = SellableType.None
    <IgnoreInToTable>
    Public ReadOnly Property Product As Product
        Get
            Return TryCast(Sellable.Value, Product)
        End Get
    End Property
    <IgnoreInToTable>
    Public ReadOnly Property Service As Service
        Get
            Return TryCast(Sellable.Value, Service)
        End Get
    End Property
    Public Property Sellable As New Lazy(Of Sellable)
    Public Property SellableID As Long
    Public Property Code As String
    Public Property Name As String
    Public Property Price As Decimal
    Public Sub New()
        SetRoutine(Routine.PriceTableSellable)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New PriceTableSellable With {
            .Code = Code,
            .Name = Name,
            .Price = Price,
            .SellableID = SellableID,
            .Sellable = New Lazy(Of Sellable)(
                Function()
                    If Sellable.IsValueCreated Then
                        If SellableType = SellableType.Product Then
                            Return CType(Sellable.Value.Clone(), Product)
                        Else
                            Return CType(Sellable.Value.Clone(), Service)
                        End If
                    Else
                        If SellableType = SellableType.Product Then
                            Return New Product().Load(SellableID, False)
                        Else
                            Return New Service().Load(SellableID, False)
                        End If
                    End If
                End Function
            )
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class