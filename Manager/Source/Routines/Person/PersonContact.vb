
''' <summary>
''' Representa um contato de uma pessoa.
''' </summary>
Public Class PersonContact
    Inherits ChildModel
    Public Property IsMainContact As Boolean
    Public Property Name As String
    Public Property JobTitle As String
    Public Property Phone As String
    Public Property Email As String
    Public Sub New()
        SetRoutine(Routine.PersonContact)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New PersonContact With {
            .Email = Email,
            .IsMainContact = IsMainContact,
            .JobTitle = JobTitle,
            .Name = Name,
            .Phone = Phone
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
