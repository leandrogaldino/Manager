''' <summary>
''' Representa um usuário autórizado no fluxo de caixa.
''' </summary>
Public Class CashFlowAuthorized
    Inherits ChildModel
    Public Property Authorized As New Person
    Public Sub New()
        SetRoutine(Routine.CashFlowAuthorized)
    End Sub
End Class

