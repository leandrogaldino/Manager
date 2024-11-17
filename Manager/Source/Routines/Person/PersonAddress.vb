''' <summary>
''' Representa um endereço de uma pessoa.
''' </summary>
Public Class PersonAddress
    Inherits ChildModel
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
    Public Property ContributionType As PersonContributionType = PersonContributionType.TaxPayer
    Public Property Carrier As New Person
    Public Sub New()
        SetRoutine(Routine.PersonAddress)
    End Sub
End Class