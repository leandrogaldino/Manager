''' <summary>
''' Representa um código qualquer de um produto (EAN e ANP etc.).
''' </summary>
Public Class ProductCode
    Inherits SellableCode
    Public Sub New()
        SetRoutine(Routine.ProductCode)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ProductCode With {
            .Name = Me.Name,
            .Code = Me.Code
        }
        Cloned.SetID(Me.ID)
        Cloned.SetCreation(Me.Creation)
        Cloned.SetIsSaved(Me.IsSaved)
        Return Cloned
    End Function
End Class
