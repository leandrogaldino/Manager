Imports ControlLibrary
''' <summary>
''' Representa uma produto/serviço de um compressor.
''' </summary>
Public Class CompressorSellable
    Inherits ChildModel
    Private ReadOnly _ControlType As CompressorSellableControlType
    Public Property Status As SimpleStatus = SimpleStatus.Active
    <IgnoreInToTable>
    Public Property SellableType As SellableType
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
    Public ReadOnly Property SellableControlType As CompressorSellableControlType
        Get
            Return _ControlType
        End Get
    End Property
    Public Property Sellable As Lazy(Of Sellable)
    Public Property SellableID As Long
    Public Property Code As String
    Public Property Name As String
    Public Property Quantity As Decimal
    Public Sub New(ControlType As CompressorSellableControlType)
        _ControlType = ControlType
        SetRoutine(Routine.CompressorSellable)
    End Sub
End Class
