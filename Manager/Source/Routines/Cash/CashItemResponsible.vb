''' <summary>
''' Representa um responsável por um item lançado no caixa.
''' </summary>
Public Class CashItemResponsible
    Inherits ChildModel
    Public Property Responsible As New Person
    Public Sub New()
        SetRoutine(Routine.CashItemResponsible)
    End Sub
End Class