Imports ControlLibrary

''' <summary>
''' Representa uma peça da avaliação do compressor.
''' </summary>
Public Class EvaluationControlledSellable
    Inherits ChildModel
    Private ReadOnly _ControlType As CompressorSellableControlType
    <IgnoreInToTable>
    Public ReadOnly Property SellableType As SellableType
        Get
            If PersonCompressorSellable.Value IsNot Nothing Then
                If TypeOf PersonCompressorSellable.Value.Sellable.Value Is Product Then Return SellableType.Product
                If TypeOf PersonCompressorSellable.Value.Sellable.Value Is Service Then Return SellableType.Service
            End If
            Return SellableType.None
        End Get
    End Property
    <IgnoreInToTable>
    Public ReadOnly Property Product As Product
        Get
            Return TryCast(PersonCompressorSellable.Value.Sellable.Value, Product)
        End Get
    End Property
    <IgnoreInToTable>
    Public ReadOnly Property Service As Service
        Get
            Return TryCast(PersonCompressorSellable.Value.Sellable.Value, Service)
        End Get
    End Property
    Public ReadOnly Property SellableControlType As CompressorSellableControlType
        Get
            Return _ControlType
        End Get
    End Property
    Public Property PersonCompressorSellable As Lazy(Of PersonCompressorSellable)
    Public Property PersonCompressorSellableID As Long
    Public Property SellableStatus As SimpleStatus = SimpleStatus.Active
    Public Property Code As String
    Public Property Name As String
    Public Property Quantity As Decimal
    Public Property CurrentCapacity As Integer
    Public Property Sold As Boolean
    Public Property Lost As Boolean
    Public Sub New(ControlType As CompressorSellableControlType)
        _ControlType = ControlType
        If _ControlType = CompressorSellableControlType.ElapsedDay Then
            SetRoutine(Routine.EvaluationControlledSellableElapsedDay)
        Else
            SetRoutine(Routine.EvaluationControlledSellableWorkedHour)
        End If
    End Sub
End Class
