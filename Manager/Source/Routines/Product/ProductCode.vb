''' <summary>
''' Representa um código qualquer de um produto (EAN e ANP etc.).
''' </summary>
Public Class ProductCode
    Inherits SellableCode
    Public Sub New()
        SetRoutine(Routine.ProductCode)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Return MyBase.Clone()
    End Function
End Class
