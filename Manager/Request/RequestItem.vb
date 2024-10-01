Imports ControlLibrary
''' <summary>
''' Representa um item de uma requisição.
''' </summary>
Public Class RequestItem
    Implements IEquatable(Of RequestItem)

    Public IsSaved As Boolean
    Private _Order As Long
    Private _ID As Long
    Private _Creation As Date = Today
    Public ReadOnly Property Order As Long
        Get
            Return _Order
        End Get
    End Property
    Public ReadOnly Property ID As Long
        Get
            Return _ID
        End Get
    End Property
    Public ReadOnly Property Creation As Date
        Get
            Return _Creation
        End Get
    End Property
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
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        If TypeOf obj IsNot RequestItem Then
            Return False
        End If
        Return Me.Equals(DirectCast(obj, RequestItem))
    End Function

    Public Overloads Function Equals(Other As RequestItem) As Boolean Implements IEquatable(Of RequestItem).Equals
        If Other Is Nothing Then
            Return False
        End If


        Return Me.Code = Other.Code AndAlso Me.ItemNameOrProduct = Other.ItemNameOrProduct AndAlso Me.Product.ID.Equals(Other.Product.ID)
    End Function

    Public Overrides Function GetHashCode() As Integer
        ' Calcular um código hash com base nas propriedades que você está usando para a igualdade
        Return Code.GetHashCode() Xor ItemNameOrProduct.GetHashCode() Xor Product.GetHashCode()
    End Function
End Class
