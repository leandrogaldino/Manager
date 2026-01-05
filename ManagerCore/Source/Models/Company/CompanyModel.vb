Public Class CompanyModel
    Public Property Document As String
    Public Property LogoName As String
    Public Property Name As String
    Public Property ShortName As String
    Public Property CityDocument As String
    Public Property StateDocument As String
    Public Property Address As New CompanyAddressModel
    Public Property Contact As New CompanyContactModel
    Public Overrides Function ToString() As String
        Return Document.Replace(".", String.Empty.Replace("/", String.Empty.Replace("-", String.Empty)))
    End Function
    Public Shared Function FromDictionary(Row As Dictionary(Of String, Object)) As CompanyModel
        Return New CompanyModel With {
            .Document = Row("document").ToString(),
            .Name = Row("name")?.ToString(),
            .ShortName = Row("short_name")?.ToString(),
            .LogoName = Row("logo_location")?.ToString(),
            .CityDocument = Row("city_document")?.ToString(),
            .StateDocument = Row("state_document")?.ToString(),
            .Address = New CompanyAddressModel With {
                .ZipCode = Row("zip_code")?.ToString(),
                .Street = Row("street")?.ToString(),
                .Number = Row("number")?.ToString(),
                .Complement = Row("complement")?.ToString(),
                .District = Row("district")?.ToString(),
                .City = Row("city")?.ToString(),
                .State = Row("state")?.ToString()
            },
            .Contact = New CompanyContactModel With {
                .Phone1 = Row("phone1")?.ToString(),
                .Phone2 = Row("phone2")?.ToString(),
                .CellPhone = Row("cell_phone")?.ToString(),
                .Email = Row("email")?.ToString(),
                .Facebook = Row("facebook")?.ToString(),
                .Instagram = Row("instagram")?.ToString(),
                .Linkedin = Row("linkedin")?.ToString(),
                .Site = Row("site")?.ToString()
            }
        }
    End Function
End Class
