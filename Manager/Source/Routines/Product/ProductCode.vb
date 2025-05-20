''' <summary>
''' Representa um código qualquer de um produto (EAN e ANP etc.).
''' </summary>
Public Class ProductCode
    Inherits SellableCode
    Public Sub New()
        SetRoutine(Routine.ProductCode)
    End Sub
End Class
