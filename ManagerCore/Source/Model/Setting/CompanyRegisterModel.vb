Public Class CompanyRegisterModel
    Public Property Document As String
    Public Property LogoLocation As String
    Public Property Name As String
    Public Property ShortName As String
    Public Property CityDocument As String
    Public Property StateDocument As String
    Public Property Address As New CompanyAddressModel
    Public Property Contact As New CompanyContactModel
End Class
