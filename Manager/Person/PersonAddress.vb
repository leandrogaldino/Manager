Imports ControlLibrary
''' <summary>
''' Representa um endereço de uma pessoa.
''' </summary>
Public Class PersonAddress
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
    Public Property IsMainAddress As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property ZipCode As String
    Public Property Street As String
    Public Property Number As String
    Public Property Complement As String
    Public Property District As String
    Public Property City As New City
    Public Property CityDocument As String
    Public Property StateDocument As String
    Public Property ContributionType As PersonContribution = PersonContribution.TaxPayer
    Public Property Carrier As New Person
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
End Class