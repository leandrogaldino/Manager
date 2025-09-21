''' <summary>
''' Representa um responsável por um item lançado no caixa.
''' </summary>
Public Class CashItemResponsible
    Inherits ChildModel
    Public Property Responsible As New Person
    Public Sub New()
        SetRoutine(Routine.CashItemResponsible)
    End Sub

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New CashItemResponsible With {
            .Responsible = Responsible.Clone()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetGuid(Guid)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function
End Class