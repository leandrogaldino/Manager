Imports ControlLibrary
Public Class PriceTableItem
    Inherits ChildModel
    <IgnoreInToTable>
    Public ReadOnly Property SellableType As SellableType
        Get
            If Sellable.Value IsNot Nothing Then
                If TypeOf Sellable.Value Is Product Then Return SellableType.Product
                If TypeOf Sellable.Value Is Service Then Return SellableType.Service
            End If
            Return SellableType.None
        End Get
    End Property

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
    Public Property Sellable As Lazy(Of Sellable)
    Public Property SellableID As Long
    Public Property Code As String
    Public Property Name As String
    Public Property Price As Decimal
    Public Sub New()
        SetRoutine(Routine.PriceTableItem)
    End Sub
End Class