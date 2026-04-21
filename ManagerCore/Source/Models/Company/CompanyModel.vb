Imports System.IO
Imports CoreSuite.Services

Public Class CompanyModel
    Public Property ID As Long = 0
    Public Property IsActive As Boolean = True
    Public Property Document As String
    Public Property Logo As New FileStateManager(ApplicationPaths.CompanyLogoDirectory)
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
        Dim Company As New CompanyModel With {
            .ID = Convert.ToInt64(Row("companyid")),
            .IsActive = Convert.ToBoolean(Row("companyisactive")),
            .Document = Row("companydocument").ToString(),
            .Name = Row("companyname")?.ToString(),
            .ShortName = Row("companyshortname")?.ToString(),
            .CityDocument = Row("companycitydocument")?.ToString(),
            .StateDocument = Row("companystatedocument")?.ToString(),
            .Address = New CompanyAddressModel With {
                .ZipCode = Row("addresszipcode")?.ToString(),
                .Street = Row("addressstreet")?.ToString(),
                .Number = Row("addressnumber")?.ToString(),
                .Complement = Row("addresscomplement")?.ToString(),
                .District = Row("addressdistrict")?.ToString(),
                .City = Row("addresscity")?.ToString(),
                .State = Row("addressstate")?.ToString()
            },
            .Contact = New CompanyContactModel With {
                .Phone1 = Row("contactphone1")?.ToString(),
                .Phone2 = Row("contactphone2")?.ToString(),
                .CellPhone = Row("contactcellphone")?.ToString(),
                .Email = Row("contactemail")?.ToString(),
                .Facebook = Row("contactfacebook")?.ToString(),
                .Instagram = Row("contactinstagram")?.ToString(),
                .Linkedin = Row("contactlinkedin")?.ToString(),
                .Site = Row("contactsite")?.ToString()
            }
        }
        Company.Logo.SetCurrentFile(Row("companylogoname")?.ToString(), True)
        If Row("companylogoname") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(Row("companylogoname").ToString()) Then
            Company.Logo.SetCurrentFile(Path.Combine(ApplicationPaths.CompanyLogoDirectory, Row("companylogoname").ToString), True)
        End If
        Return Company
    End Function
End Class
