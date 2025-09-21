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
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New CompressorSellable(SellableControlType) With {
            .Code = Code,
            .Name = Name,
            .Quantity = Quantity,
            .Status = Status,
            .SellableID = SellableID,
            .SellableType = SellableType,
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
