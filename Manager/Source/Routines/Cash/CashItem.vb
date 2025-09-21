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

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New CashItem With {
            .Description = Description,
            .DocumentDate = DocumentDate,
            .DocumentNumber = DocumentNumber,
            .ItemCategory = ItemCategory,
            .ItemType = ItemType,
            .Value = Value,
            .Responsibles = Responsibles.Select(Function(x) CType(x.Clone(), CashItemResponsible)).ToList()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetGuid(Guid)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function
End Class