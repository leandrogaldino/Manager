Imports ControlLibrary

Public Class EvaluationReplacedSellable
    Inherits ChildModel
    Public Property ProductID As Long
    Public Property ProductCode As String
    Public Property ProductName As String
    <IgnoreInToTable>
    Public Property Product As New Lazy(Of Product)
    Public Property Quantity As Decimal
    Public Sub New()
        SetRoutine(Routine.EvaluationReplacedSellable)
    End Sub
End Class
