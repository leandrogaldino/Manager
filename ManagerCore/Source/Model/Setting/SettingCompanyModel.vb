Public Class SettingCompanyModel
    Public Property Document As String
    Public Property LogoLocation As String
    Public Property Name As String
    Public Property ShortName As String
    Public Property CityDocument As String
    Public Property StateDocument As String
    Public Property Address As New SettingCompanyAddressModel
    Public Property Contact As New SettingCompanyContactModel
End Class
