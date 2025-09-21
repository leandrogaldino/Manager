''' <summary>
''' Representa uma conta de e-mail do usuário.
''' </summary>
Public Class UserEmail
    Inherits ChildModel
    Public Property IsMainEmail As Boolean
    Public Property EnableSSL As Boolean = False
    Public Property Email As String
    Public Property SmtpServer As String
    Public Property Port As Integer = 0
    Public Property Password As String
    Public Sub New()
        SetRoutine(Routine.UserEmail)
    End Sub
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New UserEmail With {
            .Email = Email,
            .EnableSSL = EnableSSL,
            .IsMainEmail = IsMainEmail,
            .SmtpServer = SmtpServer,
            .Port = Port,
            .Password = Password
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
