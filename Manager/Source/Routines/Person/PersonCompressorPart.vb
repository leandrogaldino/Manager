''' <summary>
''' Representa uma peça de um compressor da pessoa.
''' </summary>
Public Class PersonCompressorPart
    Inherits ChildModel
    Private _ProductID As Long
    Private _PartType As CompressorPartType
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property PartBind As CompressorPartBindType = CompressorPartBindType.None
    Public ReadOnly Property PartType As CompressorPartType
        Get
            Return _PartType
        End Get
    End Property
    Public ReadOnly Property Code As String
        Get
            Dim ProviderCode As ProductProviderCode = Product.Value.ProviderCodes.FirstOrDefault(Function(x) x.IsMainProvider = True)
            If ProviderCode IsNot Nothing Then
                Return ProviderCode.Code
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property ItemName As String
    Public Property Product As New Lazy(Of Product)(Function() New Product().Load(_ProductID, False))
    Public ReadOnly Property ItemNameOrProduct As String
        Get
            Return ItemName & Product.ToString
        End Get
    End Property
    Public Property Quantity As Decimal
    Public Property Capacity As Integer
    Public ReadOnly Property PartBinded As Boolean
        Get
            Return PartBind <> CompressorPartBindType.None
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return ItemName & Product.Value.Name
    End Function
    Public Sub New(PartType As CompressorPartType)
        _PartType = PartType
        If _PartType = CompressorPartType.ElapsedDay Then
            SetRoutine(Routine.PersonCompressorPartElapsedDay)
        Else
            SetRoutine(Routine.PersonCompressorPartWorkedHour)
        End If
    End Sub
End Class
