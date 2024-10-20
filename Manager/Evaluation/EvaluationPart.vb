Imports System.Reflection
Imports ControlLibrary
''' <summary>
''' Representa uma peça da avaliação do compressor.
''' </summary>
Public Class EvaluationPart
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
    Public ReadOnly Property Code As String
        Get
            Return Part.Code
        End Get
    End Property
    Public Property Part As New PersonCompressorPart(_PartType)
    Public Property CurrentCapacity As Integer
    Public Property Sold As Boolean
    Public Property Lost As Boolean
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
    Public Sub New(PartType As CompressorPartType)
        _PartType = PartType
    End Sub

End Class
