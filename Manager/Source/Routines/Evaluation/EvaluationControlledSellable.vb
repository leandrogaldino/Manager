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
    Public ReadOnly Property SellableControlType As CompressorSellableControlType
        Get
            Return _ControlType
        End Get
    End Property
    Public Property Sellable As Lazy(Of Sellable)
    Public Property SellableID As Long
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
