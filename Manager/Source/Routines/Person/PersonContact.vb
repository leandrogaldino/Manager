
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
End Class
