''' <summary>
''' Representa um código de fornecedor de um produto.
''' </summary>
Public Class ProductProviderCode
    Inherits ChildModel
    Public Property IsMainProvider As Boolean
    Public Property Code As String
    Public Property Provider As New Person
    Public Sub New()
        SetRoutine(Routine.ProductProviderCode)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ProductProviderCode With {
            .IsMainProvider = IsMainProvider,
            .Code = Code,
            .Provider = CType(Provider.Clone(), Person)
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function
End Class
