Imports ControlLibrary
''' <summary>
''' Representa uma peça de um compressor.
''' </summary>
Public Class CompressorPart
    Public IsSaved As Boolean
    Private _Order As Long
    Private _ID As Long
    Private _Creation As Date = Today
    Private _PartType As CompressorPartType
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
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public ReadOnly Property PartType As CompressorPartType
        Get
            Return _PartType
        End Get
    End Property
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
    Public ReadOnly Property LinkedProduct As Boolean
        Get
            Return Product.ID > 0
        End Get
    End Property
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
    Public Sub New(PartType As CompressorPartType)
        _PartType = PartType
    End Sub
End Class
