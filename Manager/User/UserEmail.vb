Imports ControlLibrary
Imports Manager.Util
''' <summary>
''' Representa uma conta de e-mail do usuário.
''' </summary>
Public Class UserEmail
    Public IsSaved As Boolean
    Private _Order As Long
    Private _ID As Long
    Private _Creation As Date = Today
    Public ReadOnly Property Order As Long
        Get
            Return _Order
        End Get
    End Property
    Public ReadOnly Property ID As Long
        Get
            Return _ID
        End Get
    End Property
    Public ReadOnly Property Creation As Date
        Get
            Return _Creation
        End Get
    End Property
    Public Property IsMainEmail As Boolean
    Public Property EnableSSL As Boolean = False
    Public Property Email As String
    Public Property SmtpServer As String
    Public Property Port As Integer = 0
    Public Property Password As String

    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
End Class
