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
        Return New CashItemResponsible With {
            .Responsible = Responsible.Clone()
        }
    End Function
End Class