''' <summary>
''' Representa uma peça da avaliação do compressor.
''' </summary>
Public Class EvaluationControlledSellable
    Inherits ChildModel
    Public Property SellableStatus As SimpleStatus = SimpleStatus.Active
    Public Property PersonCompressorSellable As PersonCompressorSellable
    Public ReadOnly Property Code As String
        Get
            If PersonCompressorSellable IsNot Nothing Then
                Return PersonCompressorSellable.Code
            End If
            Return String.Empty
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            If PersonCompressorSellable IsNot Nothing Then
                Return PersonCompressorSellable.Name
            End If
            Return String.Empty
        End Get
    End Property
    Public Property CurrentCapacity As Integer
    Public Property Sold As Boolean
    Public Property Lost As Boolean
    Public Sub New()
        SetRoutine(Routine.EvaluationControlledSellable)
    End Sub

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New EvaluationControlledSellable With {
            .CurrentCapacity = CurrentCapacity,
            .Lost = Lost,
            .PersonCompressorSellable = CType(PersonCompressorSellable.Clone(), PersonCompressorSellable),
            .SellableStatus = SellableStatus,
            .Sold = Sold
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
