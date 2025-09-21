Imports ControlLibrary

''' <summary>
''' Representa uma peça de um compressor da pessoa.
''' </summary>
Public Class PersonCompressorSellable
    Inherits ChildModel
    Private ReadOnly _ControlType As CompressorSellableControlType
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property SellableBind As CompressorSellableBindType = CompressorSellableBindType.None
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
    Public ReadOnly Property SellableControlType As CompressorSellableControlType
        Get
            Return _ControlType
        End Get
    End Property
    Public Property Sellable As New Lazy(Of Sellable)
    Public Property SellableID As Long
    Public Property Code As String
    Public Property Name As String
    Public Property Quantity As Decimal
    Public Property Capacity As Integer
    Public ReadOnly Property IsSellableBinded As Boolean
        Get
            Return SellableBind <> CompressorSellableBindType.None
        End Get
    End Property
    Public Sub New(ControlType As CompressorSellableControlType)
        _ControlType = ControlType
        SetRoutine(Routine.PersonCompressorSellable)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New PersonCompressorSellable(_ControlType) With {
            .Capacity = Capacity,
            .Code = Code,
            .Name = Name,
            .Quantity = Quantity,
            .SellableBind = SellableBind,
            .SellableID = SellableID,
            .SellableType = SellableType,
            .Status = Status,
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
