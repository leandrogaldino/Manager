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
End Class
