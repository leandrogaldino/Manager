Imports ControlLibrary
Imports Manager.Util
''' <summary>
''' Representa um responsável por um item lançado no caixa.
''' </summary>
Public Class CashItemResponsible
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
    Public Property Responsible As New Person
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
End Class