''' <summary>
''' Representa uma peça da avaliação do compressor.
''' </summary>
Public Class EvaluationPart
    Inherits ChildModel
    Private _PartType As CompressorSellableControlType
    Public ReadOnly Property Code As String
        Get
            Return Part.Code
        End Get
    End Property
    Public Property Part As New PersonCompressorPart(_PartType)
    Public Property CurrentCapacity As Integer
    Public Property Sold As Boolean
    Public Property Lost As Boolean
    Public Sub New(PartType As CompressorSellableControlType)
        _PartType = PartType
        SetRoutine(Routine.EvaluationPart)
    End Sub
End Class
