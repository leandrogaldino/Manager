''' <summary>
''' Representa um usuário autórizado no fluxo de caixa.
''' </summary>
Public Class CashFlowAuthorized
    Inherits ChildModel
    Public Property Authorized As New Person
    Public Sub New()
        SetRoutine(Routine.CashFlowAuthorized)
    End Sub

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New CashFlowAuthorized With {
        .Authorized = CType(Authorized.Clone(), Person)
    }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function
End Class

