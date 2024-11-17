''' <summary>
''' Representa um código qualquer de um produto (EAN e ANP etc.).
''' </summary>
Public Class ProductCode
    Inherits ChildModel
    Public Property Name As String
    Public Property Code As String
    Public Sub New()
        SetRoutine(Routine.ProductCode)
    End Sub
End Class
