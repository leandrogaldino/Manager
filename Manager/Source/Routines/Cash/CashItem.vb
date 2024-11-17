''' <summary>
''' Representa um lançamento do caixa.
''' </summary>
Public Class CashItem
    Inherits ChildModel
    Public Property ItemType As CashItemType = CashItemType.Expense
    Public Property ItemCategory As CashItemCategory = CashItemCategory.Food
    Public Property Responsibles As New List(Of CashItemResponsible)
    Public Property Description As String
    Public Property DocumentDate As Date = Today
    Public Property DocumentNumber As String
    Public Property Value As Decimal
    Public Sub New()
        SetRoutine(Routine.CashItem)
    End Sub
End Class