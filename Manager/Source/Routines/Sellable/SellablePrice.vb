''' <summary>
''' Representa o preço de um produto.
''' </summary>
Public Class SellablePrice
    Inherits ChildModel

    Public Property Product As Product
    Public Property Service As Service

    Public ReadOnly Property Sellable As SellableModel
        Get
            If Product IsNot Nothing Then
                Return Product
            ElseIf Service IsNot Nothing Then
                Return Service
            End If
            Return Nothing
        End Get
    End Property

    Public Property PriceTable As New SellablePriceTable
    Public Property Price As Decimal
    Public Sub New()
        SetRoutine(Routine.SellablePrice)
    End Sub
End Class
