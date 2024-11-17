''' <summary>
''' Representa um item de uma requisição.
''' </summary>
Public Class RequestItem
    Inherits ChildModel
    Public Property Status As RequestStatus = RequestStatus.Pending
    Public ReadOnly Property Code As String
        Get
            Dim ProviderCode As ProductProviderCode = Product.ProviderCodes.FirstOrDefault(Function(x) x.IsMainProvider = True)
            If ProviderCode IsNot Nothing Then
                Return ProviderCode.Code
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property ItemName As String
    Public Property Product As New Product

    Public ReadOnly Property ItemNameOrProduct As String
        Get
            Return ItemName & Product.ToString
        End Get
    End Property
    Public Property Taked As Decimal
    Public Property Returned As Decimal
    Public Property Applied As Decimal
    Public Property Lossed As Decimal
    Public ReadOnly Property Pending As Decimal
        Get
            Return Taked - Returned - Applied - Lossed
        End Get
    End Property
    Public Property LossReason As String
    Public Sub New()
        SetRoutine(Routine.RequestItem)
    End Sub
End Class
