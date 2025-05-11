''' <summary>
''' Representa o preço de um produto.
''' </summary>
Public Class SellablePrice
    Inherits ChildModel
    Public Property PriceTable As New SellablePriceTable
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

    Public ReadOnly Property Code As String
        Get
            If Product IsNot Nothing Then
                Dim ProviderCode As ProductProviderCode = Product.ProviderCodes.FirstOrDefault(Function(x) x.IsMainProvider = True)
                If ProviderCode IsNot Nothing Then
                    Return ProviderCode.Code
                Else
                    Return String.Empty
                End If
            End If
            Return String.Empty
        End Get
    End Property


    Public ReadOnly Property Name As String
        Get
            If Product IsNot Nothing Then
                Return Product.Name
            ElseIf Service IsNot Nothing Then
                Return Service.Name
            End If
            Return String.Empty
        End Get
    End Property



    Public Property Price As Decimal
    Public Sub New()
        SetRoutine(Routine.SellablePriceTableSellablePrice)
    End Sub
End Class
