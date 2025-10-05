''' <summary>
''' Representa um código qualquer de um serviço.
''' </summary>
Public Class ServiceCode
    Inherits SellableCode
    Public Sub New()
        SetRoutine(Routine.ServiceCode)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ServiceCode With {
            .Name = Me.Name,
            .Code = Me.Code
        }
        Cloned.SetID(Me.ID)
        Cloned.SetCreation(Me.Creation)
        Cloned.SetIsSaved(Me.IsSaved)
        Return Cloned
    End Function
End Class
