Imports System.IO
Imports System.Transactions
Imports CoreSuite.Services
Public Class CompanyService

    Private ReadOnly _LocalDb As MySqlService

    Public Sub New(LocalDb As MySqlService)
        _LocalDb = LocalDb
    End Sub

    Public Async Function LoadAsync(Document As String) As Task(Of CompanyModel)
        Dim Result = Await _LocalDb.Request.ExecuteRawQueryAsync(
            "SELECT 
                c.id AS companyid,
                c.isactive AS companyisactive,
                c.document AS companydocument,
                c.name AS companyname,
                c.shortname AS companyshortname,
                c.logoname AS companylogoname,
                c.citydocument AS companycitydocument,
                c.statedocument AS companystatedocument,
                a.companyid AS addresscompanyid,
                a.zipcode AS addresszipcode,
                a.street AS addressstreet,
                a.number AS addressnumber,
                a.complement AS addresscomplement,
                a.district AS addressdistrict,
                a.city AS addresscity,
                a.state AS addressstate,
                ct.companyid AS contactcompanyid,
                ct.phone1 AS contactphone1,
                ct.phone2 AS contactphone2,
                ct.cellphone AS contactcellphone,
                ct.email AS contactemail,
                ct.facebook AS contactfacebook,
                ct.instagram AS contactinstagram,
                ct.linkedin AS contactlinkedin,
                ct.site AS contactsite
            FROM company c
            LEFT JOIN companyaddress a ON a.companyid = c.id
            LEFT JOIN companycontact ct ON ct.companyid = c.id
             WHERE c.document = @document;",
            New Dictionary(Of String, Object) From {
                {"@document", Document}
            })
        If Result.Data Is Nothing OrElse Result.Data.Count = 0 Then
            Throw New Exception("Company not found.")
        End If
        Dim Row = Result.Data(0)
        Return CompanyModel.FromDictionary(Row)
    End Function
    Public Async Function LoadAllAsync() As Task(Of List(Of CompanyModel))
        Dim Result = Await _LocalDb.Request.ExecuteRawQueryAsync(
            "SELECT 
                c.id AS companyid,
                c.isactive AS companyisactive,
                c.document AS companydocument,
                c.name AS companyname,
                c.shortname AS companyshortname,
                c.logoname AS companylogoname,
                c.citydocument AS companycitydocument,
                c.statedocument AS companystatedocument,
                a.companyid AS addresscompanyid,
                a.zipcode AS addresszipcode,
                a.street AS addressstreet,
                a.number AS addressnumber,
                a.complement AS addresscomplement,
                a.district AS addressdistrict,
                a.city AS addresscity,
                a.state AS addressstate,
                ct.companyid AS contactcompanyid,
                ct.phone1 AS contactphone1,
                ct.phone2 AS contactphone2,
                ct.cellphone AS contactcellphone,
                ct.email AS contactemail,
                ct.facebook AS contactfacebook,
                ct.instagram AS contactinstagram,
                ct.linkedin AS contactlinkedin,
                ct.site AS contactsite
            FROM company c
            LEFT JOIN companyaddress a ON a.companyid = c.id
            LEFT JOIN companycontact ct ON ct.companyid = c.id;")
        Dim Companies As New List(Of CompanyModel)
        If Result.Data Is Nothing Then Return Companies
        For Each Row In Result.Data
            Companies.Add(CompanyModel.FromDictionary(Row))
        Next Row
        Return Companies
    End Function
    Public Async Function SaveAsync(Model As CompanyModel) As Task(Of CompanyModel)
        Dim Existing = Await _LocalDb.Request.ExecuteRawQueryAsync(
            "SELECT id FROM company WHERE document = @document",
            New Dictionary(Of String, Object) From {
                {"@document", Model.Document}
            })
        Dim CompanyId As Integer
        Using Connection = _LocalDb.Client.CreateDatabaseConnection()
            If Existing.Data Is Nothing OrElse Existing.Data.Count = 0 Then
                Using Transaction As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                    Dim Insert = Await _LocalDb.Request.ExecuteInsertAsync(
                        "company",
                        New Dictionary(Of String, Object) From {
                            {"isactive", Model.IsActive},
                            {"document", Model.Document},
                            {"name", Model.Name},
                            {"shortname", Model.ShortName},
                            {"@logoname", If(String.IsNullOrEmpty(Model.Logo.CurrentFile), DBNull.Value, Path.GetFileName(Model.Logo.CurrentFile))},
                            {"citydocument", If(String.IsNullOrEmpty(Model.CityDocument), DBNull.Value, Model.CityDocument)},
                            {"statedocument", If(String.IsNullOrEmpty(Model.StateDocument), DBNull.Value, Model.CityDocument)}
                        }, Connection)
                    Model.Logo.Execute()
                    CompanyId = Insert.LastInsertedID
                    Model.ID = CompanyId
                    Await InsertAddressAsync(CompanyId, Model.Address, Connection)
                    Await InsertContactAsync(CompanyId, Model.Contact, Connection)
                    Transaction.Complete()
                End Using
            Else
                Using Transaction As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                    CompanyId = Convert.ToInt32(Existing.Data(0)("id"))
                    Await _LocalDb.Request.ExecuteRawQueryAsync(
                "UPDATE company SET
                    isactive = @isactive,
                    name = @name,
                    shortname = @shortname,
                    logoname = @logoname,
                    citydocument = @citydocument,
                    statedocument = @statedocument
                 WHERE id = @id",
                New Dictionary(Of String, Object) From {
                    {"@id", CompanyId},
                    {"@isactive", Model.IsActive},
                    {"@name", Model.Name},
                    {"@shortname", Model.ShortName},
                    {"@logoname", If(String.IsNullOrEmpty(Model.Logo.CurrentFile), DBNull.Value, Path.GetFileName(Model.Logo.CurrentFile))},
                    {"@citydocument", If(String.IsNullOrEmpty(Model.CityDocument), DBNull.Value, Model.CityDocument)},
                    {"@statedocument", If(String.IsNullOrEmpty(Model.StateDocument), DBNull.Value, Model.CityDocument)}
                })
                    Model.Logo.Execute()
                    Await UpdateAddressAsync(CompanyId, Model.Address, Connection)
                    Await UpdateContactAsync(CompanyId, Model.Contact, Connection)
                    Transaction.Complete()
                End Using
            End If
        End Using
        Return Model
    End Function

    Private Async Function InsertAddressAsync(Id As Integer, Address As CompanyAddressModel, Connection As Common.DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "INSERT INTO companyaddress VALUES
             (@id,@zipcode,@street,@number,@complement,@district,@city,@state)",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@zipcode", If(String.IsNullOrEmpty(Address.ZipCode), DBNull.Value, Address.ZipCode)},
                {"@street", If(String.IsNullOrEmpty(Address.Street), DBNull.Value, Address.Street)},
                {"@number", If(String.IsNullOrEmpty(Address.Number), DBNull.Value, Address.Number)},
                {"@complement", If(String.IsNullOrEmpty(Address.Complement), DBNull.Value, Address.Complement)},
                {"@district", If(String.IsNullOrEmpty(Address.District), DBNull.Value, Address.District)},
                {"@city", If(String.IsNullOrEmpty(Address.City), DBNull.Value, Address.City)},
                {"@state", If(String.IsNullOrEmpty(Address.State), DBNull.Value, Address.State)}
            }, Connection)
    End Function

    Private Async Function UpdateAddressAsync(Id As Integer, Address As CompanyAddressModel, Connection As Common.DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "UPDATE companyaddress SET
                zipcode=@zipcode, street=@street, number=@number,
                complement=@complement, district=@district, city=@city, state=@state
             WHERE companyid=@id",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@zipcode", If(String.IsNullOrEmpty(Address.ZipCode), DBNull.Value, Address.ZipCode)},
                {"@street", If(String.IsNullOrEmpty(Address.Street), DBNull.Value, Address.Street)},
                {"@number", If(String.IsNullOrEmpty(Address.Number), DBNull.Value, Address.Number)},
                {"@complement", If(String.IsNullOrEmpty(Address.Complement), DBNull.Value, Address.Complement)},
                {"@district", If(String.IsNullOrEmpty(Address.District), DBNull.Value, Address.District)},
                {"@city", If(String.IsNullOrEmpty(Address.City), DBNull.Value, Address.City)},
                {"@state", If(String.IsNullOrEmpty(Address.State), DBNull.Value, Address.State)}
            }, Connection)
    End Function

    Private Async Function InsertContactAsync(Id As Integer, C As CompanyContactModel, Connection As Common.DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "INSERT INTO companycontact VALUES
             (@id,@phone1,@phone2,@cellphone,@email,@facebook,@instagram,@linkedin,@site)",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@phone1", If(String.IsNullOrEmpty(C.Phone1), DBNull.Value, C.Phone1)},
                {"@phone2", If(String.IsNullOrEmpty(C.Phone2), DBNull.Value, C.Phone2)},
                {"@cellphone", If(String.IsNullOrEmpty(C.CellPhone), DBNull.Value, C.CellPhone)},
                {"@email", If(String.IsNullOrEmpty(C.Email), DBNull.Value, C.Email)},
                {"@facebook", If(String.IsNullOrEmpty(C.Facebook), DBNull.Value, C.Facebook)},
                {"@instagram", If(String.IsNullOrEmpty(C.Instagram), DBNull.Value, C.Instagram)},
                {"@linkedin", If(String.IsNullOrEmpty(C.Linkedin), DBNull.Value, C.Linkedin)},
                {"@site", If(String.IsNullOrEmpty(C.Site), DBNull.Value, C.Site)}
            }, Connection)
    End Function

    Private Async Function UpdateContactAsync(Id As Integer, C As CompanyContactModel, Connection As Common.DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "UPDATE companycontact SET
                phone1=@phone1, phone2=@phone2, cellphone=@cellphone,
                email=@email, facebook=@facebook, instagram=@instagram,
                linkedin=@linkedin, site=@site
             WHERE companyid=@id",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@phone1", If(String.IsNullOrEmpty(C.Phone1), DBNull.Value, C.Phone1)},
                {"@phone2", If(String.IsNullOrEmpty(C.Phone2), DBNull.Value, C.Phone2)},
                {"@cellphone", If(String.IsNullOrEmpty(C.CellPhone), DBNull.Value, C.CellPhone)},
                {"@email", If(String.IsNullOrEmpty(C.Email), DBNull.Value, C.Email)},
                {"@facebook", If(String.IsNullOrEmpty(C.Facebook), DBNull.Value, C.Facebook)},
                {"@instagram", If(String.IsNullOrEmpty(C.Instagram), DBNull.Value, C.Instagram)},
                {"@linkedin", If(String.IsNullOrEmpty(C.Linkedin), DBNull.Value, C.Linkedin)},
                {"@site", If(String.IsNullOrEmpty(C.Site), DBNull.Value, C.Site)}
            }, Connection)
    End Function

End Class
