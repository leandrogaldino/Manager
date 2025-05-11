Public Class EvaluationReplacedPart
    Inherits ChildModel
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
    Public Property Quantity As Decimal
    Public Sub New()
        SetRoutine(Routine.EvaluationReplacedPart)
    End Sub
End Class
