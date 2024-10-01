Imports ControlLibrary
Imports Manager.Util
''' <summary>
''' Representa um contato de uma pessoa.
''' </summary>
Public Class PersonContact
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
    Public Property IsMainContact As Boolean
    Public Property Name As String
    Public Property JobTitle As String
    Public Property Phone As String
    Public Property Email As String
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
End Class
