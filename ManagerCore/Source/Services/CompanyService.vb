
Imports System.Transactions
Imports CoreSuite.Services
Public Class CompanyService

    Private ReadOnly _LocalDb As MySqlService

    Public Sub New(LocalDb As MySqlService)
        _LocalDb = LocalDb
    End Sub

    Public Async Function LoadAsync(Document As String) As Task(Of CompanyModel)
        Dim Result = Await _LocalDb.Request.ExecuteRawQueryAsync(
            "SELECT c.*, a.*, ct.* 
             FROM company c
             LEFT JOIN companyaddress a ON a.companyid = c.id
             LEFT JOIN companycontact ct ON ct.companyid = c.id
             WHERE c.document = @document",
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
            "SELECT c.*, a.*, ct.*
             FROM companies c
             LEFT JOIN companyaddress a ON a.companyid = c.id
             LEFT JOIN companycontact ct ON ct.companyid = c.id")
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
                        "companies",
                        New Dictionary(Of String, String) From {
                            {"document", "@document"},
                            {"name", "@name"},
                            {"shortname", "@shortname"},
                            {"logoname", "@logoname"},
                            {"citydocument", "@citydocument"},
                            {"statedocument", "@statedocument"}
                        },
                        New Dictionary(Of String, Object) From {
                            {"@document", Model.Document},
                            {"@name", Model.Name},
                            {"@shortname", Model.ShortName},
                            {"@logoname", Model.LogoName},
                            {"@citydocument", Model.CityDocument},
                            {"@state_document", Model.StateDocument}
                        }, Connection)
                    CompanyId = Insert.LastInsertedID
                    Await InsertAddressAsync(CompanyId, Model.Address, Connection)
                    Await InsertContactAsync(CompanyId, Model.Contact, Connection)
                    Transaction.Complete()
                End Using
            Else
                Using Transaction As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                    CompanyId = Convert.ToInt32(Existing.Data(0)("id"))
                    Await _LocalDb.Request.ExecuteRawQueryAsync(
                "UPDATE companies SET 
                    name = @name,
                    shortname = @shortname,
                    logoname = @logoname,
                    citydocument = @citydocument,
                    statedocument = @statedocument
                 WHERE id = @id",
                New Dictionary(Of String, Object) From {
                    {"@id", CompanyId},
                    {"@name", Model.Name},
                    {"@shortname", Model.ShortName},
                    {"@logo", Model.LogoName},
                    {"@citydocument", Model.CityDocument},
                    {"@statedocument", Model.StateDocument}
                })
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
             (@id,@zip,@street,@number,@comp,@district,@city,@state)",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@zipcode", Address.ZipCode},
                {"@street", Address.Street},
                {"@number", Address.Number},
                {"@comp", Address.Complement},
                {"@district", Address.District},
                {"@city", Address.City},
                {"@state", Address.State}
            }, Connection)
    End Function

    Private Async Function UpdateAddressAsync(Id As Integer, Address As CompanyAddressModel, Connection As Common.DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "UPDATE companyaddres SET
                zipcode=@zip, street=@street, number=@number,
                complement=@comp, district=@district, city=@city, state=@state
             WHERE companyid=@id",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@zipcode", Address.ZipCode},
                {"@street", Address.Street},
                {"@number", Address.Number},
                {"@comp", Address.Complement},
                {"@district", Address.District},
                {"@city", Address.City},
                {"@state", Address.State}
            }, Connection)
    End Function

    Private Async Function InsertContactAsync(Id As Integer, C As CompanyContactModel, Connection As Common.DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "INSERT INTO companycontact VALUES
             (@id,@p1,@p2,@cell,@email,@fb,@ig,@ln,@site)",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@p1", C.Phone1},
                {"@p2", C.Phone2},
                {"@cell", C.CellPhone},
                {"@email", C.Email},
                {"@fb", C.Facebook},
                {"@ig", C.Instagram},
                {"@ln", C.Linkedin},
                {"@site", C.Site}
            }, Connection)
    End Function

    Private Async Function UpdateContactAsync(Id As Integer, C As CompanyContactModel, Connection As Common.DbConnection) As Task
        Await _LocalDb.Request.ExecuteRawQueryAsync(
            "UPDATE companycontact SET
                phone1=@p1, phone2=@p2, cell_phone=@cell,
                email=@email, facebook=@fb, instagram=@ig,
                linkedin=@ln, site=@site
             WHERE companyid=@id",
            New Dictionary(Of String, Object) From {
                {"@id", Id},
                {"@p1", C.Phone1},
                {"@p2", C.Phone2},
                {"@cell", C.CellPhone},
                {"@email", C.Email},
                {"@fb", C.Facebook},
                {"@ig", C.Instagram},
                {"@ln", C.Linkedin},
                {"@site", C.Site}
            }, Connection)
    End Function

End Class
