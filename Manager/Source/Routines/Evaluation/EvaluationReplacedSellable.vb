Imports ControlLibrary
Public Class EvaluationReplacedSellable
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
    Public Property Sellable As Lazy(Of Sellable)
    Public Property SellableID As Long
    Public Property Code As String
    Public Property Name As String
    Public Property Quantity As Decimal
    Public Sub New()
        SetRoutine(Routine.EvaluationReplacedSellable)
    End Sub
End Class
