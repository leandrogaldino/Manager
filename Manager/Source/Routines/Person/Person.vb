Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma pessoa.
''' </summary>
Public Class Person
    Inherits ParentModel
    Private _Shadow As Person
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Entity As PersonEntityType = PersonEntityType.Legal
    Public Property IsCustomer As Boolean
    Public Property IsProvider As Boolean
    Public Property IsEmployee As Boolean
    Public Property IsTechnician As Boolean
    Public Property IsCarrier As Boolean
    Public Property ControlMaintenance As Boolean
    Public Property Addresses As New List(Of PersonAddress)
    Public Property Contacts As New List(Of PersonContact)
    Public Property Compressors As New List(Of PersonCompressor)
    Public Property Document As String
    Public Property Name As String
    Public Property ShortName As String
    Public Property Note As String
    Public Sub New()
        SetRoutine(Routine.Person)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = SimpleStatus.Active
        Entity = PersonEntityType.Legal
        IsCustomer = False
        IsProvider = False
        IsEmployee = False
        IsTechnician = False
        IsCarrier = False
        ControlMaintenance = False
        Addresses = New List(Of PersonAddress)
        Contacts = New List(Of PersonContact)
        Compressors = New List(Of PersonCompressor)
        Document = Nothing
        Name = Nothing
        ShortName = Nothing
        Note = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Person
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdPerson As New MySqlCommand(My.Resources.PersonSelect, Con, Tra)
                    CmdPerson.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdPerson)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        SetIsSaved(True)
                        Status = TableResult.Rows(0).Item("statusid")
                        Entity = TableResult.Rows(0).Item("entityid")
                        IsCustomer = TableResult.Rows(0).Item("iscustomer")
                        IsProvider = TableResult.Rows(0).Item("isprovider")
                        IsEmployee = TableResult.Rows(0).Item("isemployee")
                        IsTechnician = TableResult.Rows(0).Item("istechnician")
                        IsCarrier = TableResult.Rows(0).Item("iscarrier")
                        ControlMaintenance = TableResult.Rows(0).Item("controlmaintenance")
                        Document = TableResult.Rows(0).Item("document").ToString
                        Name = TableResult.Rows(0).Item("name").ToString
                        ShortName = TableResult.Rows(0).Item("shortname").ToString
                        Note = TableResult.Rows(0).Item("note").ToString
                        Addresses = GetAddresses(Tra)
                        Contacts = GetContacts(Tra)
                        Compressors = GetCompressors(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        _Shadow = Clone()
        Return Me
    End Function
    Public Function Load(Document As String, LockMe As Boolean) As Person
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdPerson As New MySqlCommand(My.Resources.PersonSelectByDocument, Con)
                    CmdPerson.Transaction = Tra
                    CmdPerson.Parameters.AddWithValue("@document", Document)
                    Using Adp As New MySqlDataAdapter(CmdPerson)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        SetIsSaved(True)
                        Status = TableResult.Rows(0).Item("statusid")
                        Entity = TableResult.Rows(0).Item("entityid")
                        IsCustomer = TableResult.Rows(0).Item("iscustomer")
                        IsProvider = TableResult.Rows(0).Item("isprovider")
                        IsEmployee = TableResult.Rows(0).Item("isemployee")
                        IsTechnician = TableResult.Rows(0).Item("istechnician")
                        IsCarrier = TableResult.Rows(0).Item("iscarrier")
                        ControlMaintenance = TableResult.Rows(0).Item("controlmaintenance")
                        Document = TableResult.Rows(0).Item("document").ToString
                        Name = TableResult.Rows(0).Item("name").ToString
                        ShortName = TableResult.Rows(0).Item("shortname").ToString
                        Note = TableResult.Rows(0).Item("note").ToString
                        Addresses = GetAddresses(Tra)
                        Contacts = GetContacts(Tra)
                        Compressors = GetCompressors(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        _Shadow = Clone()
        Return Me
    End Function

    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Addresses.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        Contacts.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        Compressors.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        Compressors.ToList().ForEach(Sub(x) x.PartsWorkedHour.ToList().ForEach(Sub(y) y.SetIsSaved(True)))
        Compressors.ToList().ForEach(Sub(x) x.PartsElapsedDay.ToList().ForEach(Sub(y) y.SetIsSaved(True)))
        _Shadow = Clone()
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPerson As New MySqlCommand(My.Resources.PersonDelete, Con)
                CmdPerson.Parameters.AddWithValue("@id", ID)
                CmdPerson.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdPerson As New MySqlCommand(My.Resources.PersonInsert, Con)
                    CmdPerson.Transaction = Tra
                    CmdPerson.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdPerson.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdPerson.Parameters.AddWithValue("@entityid", CInt(Entity))
                    CmdPerson.Parameters.AddWithValue("@iscustomer", IsCustomer)
                    CmdPerson.Parameters.AddWithValue("@isprovider", IsProvider)
                    CmdPerson.Parameters.AddWithValue("@isemployee", IsEmployee)
                    CmdPerson.Parameters.AddWithValue("@istechnician", IsTechnician)
                    CmdPerson.Parameters.AddWithValue("@iscarrier", IsCarrier)
                    CmdPerson.Parameters.AddWithValue("@controlmaintenance", ControlMaintenance)
                    CmdPerson.Parameters.AddWithValue("@document", Document)
                    CmdPerson.Parameters.AddWithValue("@name", Name)
                    CmdPerson.Parameters.AddWithValue("@shortname", ShortName)
                    CmdPerson.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdPerson.Parameters.AddWithValue("@userid", User.ID)
                    CmdPerson.ExecuteNonQuery()
                    SetID(CmdPerson.LastInsertedId)
                End Using
                For Each Address As PersonAddress In Addresses
                    Using CmdAddress As New MySqlCommand(My.Resources.PersonAddressInsert, Con)
                        CmdAddress.Transaction = Tra
                        CmdAddress.Parameters.AddWithValue("@personid", ID)
                        CmdAddress.Parameters.AddWithValue("@ismainaddress", Address.IsMainAddress)
                        CmdAddress.Parameters.AddWithValue("@creation", Address.Creation)
                        CmdAddress.Parameters.AddWithValue("@statusid", CInt(Address.Status))
                        CmdAddress.Parameters.AddWithValue("@name", Address.Name)
                        CmdAddress.Parameters.AddWithValue("@zipcode", Address.ZipCode)
                        CmdAddress.Parameters.AddWithValue("@street", Address.Street)
                        CmdAddress.Parameters.AddWithValue("@number", If(String.IsNullOrEmpty(Address.Number), DBNull.Value, Address.Number))
                        CmdAddress.Parameters.AddWithValue("@complement", If(String.IsNullOrEmpty(Address.Complement), DBNull.Value, Address.Complement))
                        CmdAddress.Parameters.AddWithValue("@district", Address.District)
                        CmdAddress.Parameters.AddWithValue("@cityid", Address.City.ID)
                        CmdAddress.Parameters.AddWithValue("@citydocument", If(String.IsNullOrEmpty(Address.CityDocument), DBNull.Value, Address.CityDocument))
                        CmdAddress.Parameters.AddWithValue("@statedocument", If(String.IsNullOrEmpty(Address.StateDocument), DBNull.Value, Address.StateDocument))
                        CmdAddress.Parameters.AddWithValue("@contributiontypeid", CInt(Address.ContributionType))
                        CmdAddress.Parameters.AddWithValue("@carrierid", If(Address.Carrier.ID = 0, DBNull.Value, Address.Carrier.ID))
                        CmdAddress.Parameters.AddWithValue("@userid", Address.User.ID)
                        CmdAddress.ExecuteNonQuery()
                        Address.SetID(CmdAddress.LastInsertedId)
                    End Using
                Next Address
                For Each Contact As PersonContact In Contacts
                    Using CmdContact As New MySqlCommand(My.Resources.PersonContactInsert, Con)
                        CmdContact.Transaction = Tra
                        CmdContact.Parameters.AddWithValue("@personid", ID)
                        CmdContact.Parameters.AddWithValue("@ismaincontact", Contact.IsMainContact)
                        CmdContact.Parameters.AddWithValue("@creation", Contact.Creation)
                        CmdContact.Parameters.AddWithValue("@name", If(String.IsNullOrEmpty(Contact.Name), DBNull.Value, Contact.Name))
                        CmdContact.Parameters.AddWithValue("@jobtitle", If(String.IsNullOrEmpty(Contact.JobTitle), DBNull.Value, Contact.JobTitle))
                        CmdContact.Parameters.AddWithValue("@phone", If(String.IsNullOrEmpty(Contact.Phone), DBNull.Value, Contact.Phone))
                        CmdContact.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Contact.Email), DBNull.Value, Contact.Email))
                        CmdContact.Parameters.AddWithValue("@userid", Contact.User.ID)
                        CmdContact.ExecuteNonQuery()
                        Contact.SetID(CmdContact.LastInsertedId)
                    End Using
                Next Contact
                For Each PersonCompressor As PersonCompressor In Compressors
                    Using CmdCompressor As New MySqlCommand(My.Resources.PersonCompressorInsert, Con)
                        CmdCompressor.Transaction = Tra
                        CmdCompressor.Parameters.AddWithValue("@personid", ID)
                        CmdCompressor.Parameters.AddWithValue("@creation", PersonCompressor.Creation)
                        CmdCompressor.Parameters.AddWithValue("@statusid", CInt(PersonCompressor.Status))
                        CmdCompressor.Parameters.AddWithValue("@compressorid", PersonCompressor.Compressor.ID)
                        CmdCompressor.Parameters.AddWithValue("@serialnumber", If(String.IsNullOrEmpty(PersonCompressor.SerialNumber), DBNull.Value, PersonCompressor.SerialNumber))
                        CmdCompressor.Parameters.AddWithValue("@patrimony", If(String.IsNullOrEmpty(PersonCompressor.Patrimony), DBNull.Value, PersonCompressor.Patrimony))
                        CmdCompressor.Parameters.AddWithValue("@sector", If(String.IsNullOrEmpty(PersonCompressor.Sector), DBNull.Value, PersonCompressor.Sector))
                        CmdCompressor.Parameters.AddWithValue("@unitcapacity", PersonCompressor.UnitCapacity)
                        CmdCompressor.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(PersonCompressor.Note), DBNull.Value, PersonCompressor.Note))
                        CmdCompressor.Parameters.AddWithValue("@userid", PersonCompressor.User.ID)
                        CmdCompressor.ExecuteNonQuery()
                        PersonCompressor.SetID(CmdCompressor.LastInsertedId)
                        For Each PartWorkedHour In PersonCompressor.PartsWorkedHour
                            Using CmdPartWorkedHour As New MySqlCommand(My.Resources.PersonCompressorSellableInsert, Con)
                                CmdPartWorkedHour.Transaction = Tra
                                CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                                CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                                CmdPartWorkedHour.Parameters.AddWithValue("@statusid", CInt(PartWorkedHour.Status))
                                CmdPartWorkedHour.Parameters.AddWithValue("@partbindid", CInt(PartWorkedHour.PartBind))
                                CmdPartWorkedHour.Parameters.AddWithValue("@parttypeid", PartWorkedHour.PartType)
                                CmdPartWorkedHour.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartWorkedHour.ItemName), DBNull.Value, PartWorkedHour.ItemName))
                                CmdPartWorkedHour.Parameters.AddWithValue("@productid", If(PartWorkedHour.Product.Value.ID = 0, DBNull.Value, PartWorkedHour.Product.Value.ID))
                                CmdPartWorkedHour.Parameters.AddWithValue("@quantity", PartWorkedHour.Quantity)
                                CmdPartWorkedHour.Parameters.AddWithValue("@capacity", PartWorkedHour.Capacity)
                                CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                                CmdPartWorkedHour.ExecuteNonQuery()
                                PartWorkedHour.SetID(CmdPartWorkedHour.LastInsertedId)
                            End Using
                        Next PartWorkedHour
                        For Each PartElapsedDay In PersonCompressor.PartsElapsedDay
                            Using CmdPartElapsedDay As New MySqlCommand(My.Resources.PersonCompressorSellableInsert, Con)
                                CmdPartElapsedDay.Transaction = Tra
                                CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                                CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                                CmdPartElapsedDay.Parameters.AddWithValue("@statusid", CInt(PartElapsedDay.Status))
                                CmdPartElapsedDay.Parameters.AddWithValue("@partbindid", CInt(PartElapsedDay.PartBind))
                                CmdPartElapsedDay.Parameters.AddWithValue("@parttypeid", PartElapsedDay.PartType)
                                CmdPartElapsedDay.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartElapsedDay.ItemName), DBNull.Value, PartElapsedDay.ItemName))
                                CmdPartElapsedDay.Parameters.AddWithValue("@productid", If(PartElapsedDay.Product.Value.ID = 0, DBNull.Value, PartElapsedDay.Product.Value.ID))
                                CmdPartElapsedDay.Parameters.AddWithValue("@quantity", PartElapsedDay.Quantity)
                                CmdPartElapsedDay.Parameters.AddWithValue("@capacity", PartElapsedDay.Capacity)
                                CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                                CmdPartElapsedDay.ExecuteNonQuery()
                                PartElapsedDay.SetID(CmdPartElapsedDay.LastInsertedId)
                            End Using
                        Next PartElapsedDay
                    End Using
                Next PersonCompressor
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Compressor As PersonCompressor
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdPerson As New MySqlCommand(My.Resources.PersonUpdate, Con)
                    CmdPerson.Transaction = Tra
                    CmdPerson.Parameters.AddWithValue("@id", ID)
                    CmdPerson.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdPerson.Parameters.AddWithValue("@entityid", CInt(Entity))
                    CmdPerson.Parameters.AddWithValue("@iscustomer", IsCustomer)
                    CmdPerson.Parameters.AddWithValue("@isprovider", IsProvider)
                    CmdPerson.Parameters.AddWithValue("@isemployee", IsEmployee)
                    CmdPerson.Parameters.AddWithValue("@istechnician", IsTechnician)
                    CmdPerson.Parameters.AddWithValue("@iscarrier", IsCarrier)
                    CmdPerson.Parameters.AddWithValue("@controlmaintenance", ControlMaintenance)
                    CmdPerson.Parameters.AddWithValue("@document", Document)
                    CmdPerson.Parameters.AddWithValue("@name", Name)
                    CmdPerson.Parameters.AddWithValue("@shortname", ShortName)
                    CmdPerson.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdPerson.Parameters.AddWithValue("@userid", User.ID)
                    CmdPerson.ExecuteNonQuery()
                End Using
                For Each Address As PersonAddress In _Shadow.Addresses
                    If Not Addresses.Any(Function(x) x.ID = Address.ID And x.ID > 0) Then
                        Using CmdAddress As New MySqlCommand(My.Resources.PersonAddressDelete, Con)
                            CmdAddress.Transaction = Tra
                            CmdAddress.Parameters.AddWithValue("@id", Address.ID)
                            CmdAddress.ExecuteNonQuery()
                        End Using
                    End If
                Next Address
                For Each Address As PersonAddress In Addresses
                    If Address.ID = 0 Then
                        Using CmdAddress As New MySqlCommand(My.Resources.PersonAddressInsert, Con)
                            CmdAddress.Transaction = Tra
                            CmdAddress.Parameters.AddWithValue("@personid", ID)
                            CmdAddress.Parameters.AddWithValue("@ismainaddress", Address.IsMainAddress)
                            CmdAddress.Parameters.AddWithValue("@creation", Address.Creation)
                            CmdAddress.Parameters.AddWithValue("statusid", CInt(Address.Status))
                            CmdAddress.Parameters.AddWithValue("@name", Address.Name)
                            CmdAddress.Parameters.AddWithValue("@zipcode", Address.ZipCode)
                            CmdAddress.Parameters.AddWithValue("@street", Address.Street)
                            CmdAddress.Parameters.AddWithValue("@number", If(String.IsNullOrEmpty(Address.Number), DBNull.Value, Address.Number))
                            CmdAddress.Parameters.AddWithValue("@complement", If(String.IsNullOrEmpty(Address.Complement), DBNull.Value, Address.Complement))
                            CmdAddress.Parameters.AddWithValue("@district", Address.District)
                            CmdAddress.Parameters.AddWithValue("@cityid", Address.City.ID)
                            CmdAddress.Parameters.AddWithValue("@citydocument", If(String.IsNullOrEmpty(Address.CityDocument), DBNull.Value, Address.CityDocument))
                            CmdAddress.Parameters.AddWithValue("@statedocument", If(String.IsNullOrEmpty(Address.StateDocument), DBNull.Value, Address.StateDocument))
                            CmdAddress.Parameters.AddWithValue("@contributiontypeid", CInt(Address.ContributionType))
                            CmdAddress.Parameters.AddWithValue("@carrierid", If(Address.Carrier.ID = 0, DBNull.Value, Address.Carrier.ID))
                            CmdAddress.Parameters.AddWithValue("@userid", Address.User.ID)
                            CmdAddress.ExecuteNonQuery()
                            Address.SetID(CmdAddress.LastInsertedId)
                        End Using
                    Else
                        Using CmdAddress As New MySqlCommand(My.Resources.PersonAddressUpdate, Con)
                            CmdAddress.Transaction = Tra
                            CmdAddress.Parameters.AddWithValue("@id", Address.ID)
                            CmdAddress.Parameters.AddWithValue("@ismainaddress", Address.IsMainAddress)
                            CmdAddress.Parameters.AddWithValue("@statusid", CInt(Address.Status))
                            CmdAddress.Parameters.AddWithValue("@name", Address.Name)
                            CmdAddress.Parameters.AddWithValue("@zipcode", Address.ZipCode)
                            CmdAddress.Parameters.AddWithValue("@street", Address.Street)
                            CmdAddress.Parameters.AddWithValue("@number", If(String.IsNullOrEmpty(Address.Number), DBNull.Value, Address.Number))
                            CmdAddress.Parameters.AddWithValue("@complement", If(String.IsNullOrEmpty(Address.Complement), DBNull.Value, Address.Complement))
                            CmdAddress.Parameters.AddWithValue("@district", Address.District)
                            CmdAddress.Parameters.AddWithValue("@cityid", Address.City.ID)
                            CmdAddress.Parameters.AddWithValue("@citydocument", If(String.IsNullOrEmpty(Address.CityDocument), DBNull.Value, Address.CityDocument))
                            CmdAddress.Parameters.AddWithValue("@statedocument", If(String.IsNullOrEmpty(Address.StateDocument), DBNull.Value, Address.StateDocument))
                            CmdAddress.Parameters.AddWithValue("@contributiontypeid", CInt(Address.ContributionType))
                            CmdAddress.Parameters.AddWithValue("@carrierid", If(Address.Carrier.ID = 0, DBNull.Value, Address.Carrier.ID))
                            CmdAddress.Parameters.AddWithValue("@userid", Address.User.ID)
                            CmdAddress.ExecuteNonQuery()
                        End Using
                    End If
                Next Address
                For Each Contact As PersonContact In _Shadow.Contacts
                    If Not Contacts.Any(Function(x) x.ID = Contact.ID And x.ID > 0) Then
                        Using CmdContact As New MySqlCommand(My.Resources.PersonContactDelete, Con)
                            CmdContact.Transaction = Tra
                            CmdContact.Parameters.AddWithValue("@id", Contact.ID)
                            CmdContact.ExecuteNonQuery()
                        End Using
                    End If
                Next Contact
                For Each Contact As PersonContact In Contacts
                    If Contact.ID = 0 Then
                        Using CmdContact As New MySqlCommand(My.Resources.PersonContactInsert, Con)
                            CmdContact.Transaction = Tra
                            CmdContact.Parameters.AddWithValue("@personid", ID)
                            CmdContact.Parameters.AddWithValue("@ismaincontact", Contact.IsMainContact)
                            CmdContact.Parameters.AddWithValue("@creation", Contact.Creation)
                            CmdContact.Parameters.AddWithValue("@name", If(String.IsNullOrEmpty(Contact.Name), DBNull.Value, Contact.Name))
                            CmdContact.Parameters.AddWithValue("@jobtitle", If(String.IsNullOrEmpty(Contact.JobTitle), DBNull.Value, Contact.JobTitle))
                            CmdContact.Parameters.AddWithValue("@phone", If(String.IsNullOrEmpty(Contact.Phone), DBNull.Value, Contact.Phone))
                            CmdContact.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Contact.Email), DBNull.Value, Contact.Email))
                            CmdContact.Parameters.AddWithValue("@userid", Contact.User.ID)
                            CmdContact.ExecuteNonQuery()
                            Contact.SetID(CmdContact.LastInsertedId)
                        End Using
                    Else
                        Using CmdContact As New MySqlCommand(My.Resources.PersonContactUpdate, Con)
                            CmdContact.Transaction = Tra
                            CmdContact.Parameters.AddWithValue("@id", Contact.ID)
                            CmdContact.Parameters.AddWithValue("@ismaincontact", Contact.IsMainContact)
                            CmdContact.Parameters.AddWithValue("@name", If(String.IsNullOrEmpty(Contact.Name), DBNull.Value, Contact.Name))
                            CmdContact.Parameters.AddWithValue("@jobtitle", If(String.IsNullOrEmpty(Contact.JobTitle), DBNull.Value, Contact.JobTitle))
                            CmdContact.Parameters.AddWithValue("@phone", If(String.IsNullOrEmpty(Contact.Phone), DBNull.Value, Contact.Phone))
                            CmdContact.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Contact.Email), DBNull.Value, Contact.Email))
                            CmdContact.Parameters.AddWithValue("@userid", Contact.User.ID)
                            CmdContact.ExecuteNonQuery()
                        End Using
                    End If
                Next Contact
                For Each ShadowCompressor As PersonCompressor In _Shadow.Compressors
                    If Not Compressors.Any(Function(x) x.ID = ShadowCompressor.ID And x.ID > 0) Then
                        Using CmdCashItem As New MySqlCommand(My.Resources.PersonCompressorDelete, Con)
                            CmdCashItem.Transaction = Tra
                            CmdCashItem.Parameters.AddWithValue("@id", ShadowCompressor.ID)
                            CmdCashItem.ExecuteNonQuery()
                        End Using
                    End If
                    For Each ShadowPartWorkedHour As PersonCompressorSellable In ShadowCompressor.PartsWorkedHour
                        Compressor = Compressors.SingleOrDefault(Function(x) x.ID = ShadowCompressor.ID)
                        If Compressor IsNot Nothing AndAlso (Not Compressor.PartsWorkedHour.Any(Function(x) x.ID = ShadowPartWorkedHour.ID And x.ID > 0)) Then
                            Using CmdPartWorkedHour As New MySqlCommand(My.Resources.PersonCompressorSellableDelete, Con)
                                CmdPartWorkedHour.Transaction = Tra
                                CmdPartWorkedHour.Parameters.AddWithValue("@id", ShadowPartWorkedHour.ID)
                                CmdPartWorkedHour.ExecuteNonQuery()
                            End Using
                        End If
                    Next ShadowPartWorkedHour
                    For Each ShadowPartElapsedDay As PersonCompressorSellable In ShadowCompressor.PartsElapsedDay
                        Compressor = Compressors.SingleOrDefault(Function(x) x.ID = ShadowCompressor.ID)
                        If Compressor IsNot Nothing AndAlso (Not Compressor.PartsElapsedDay.Any(Function(x) x.ID = ShadowPartElapsedDay.ID And x.ID > 0)) Then
                            Using CmdPartElapsedDay As New MySqlCommand(My.Resources.PersonCompressorSellableDelete, Con)
                                CmdPartElapsedDay.Transaction = Tra
                                CmdPartElapsedDay.Parameters.AddWithValue("@id", ShadowPartElapsedDay.ID)
                                CmdPartElapsedDay.ExecuteNonQuery()
                            End Using
                        End If
                    Next ShadowPartElapsedDay
                Next ShadowCompressor
                For Each PersonCompressor As PersonCompressor In Compressors
                    If PersonCompressor.ID = 0 Then
                        Using CmdCompressor As New MySqlCommand(My.Resources.PersonCompressorInsert, Con)
                            CmdCompressor.Transaction = Tra
                            CmdCompressor.Parameters.AddWithValue("@personid", ID)
                            CmdCompressor.Parameters.AddWithValue("@creation", PersonCompressor.Creation)
                            CmdCompressor.Parameters.AddWithValue("@statusid", CInt(PersonCompressor.Status))
                            CmdCompressor.Parameters.AddWithValue("@compressorid", PersonCompressor.Compressor.ID)
                            CmdCompressor.Parameters.AddWithValue("@serialnumber", If(String.IsNullOrEmpty(PersonCompressor.SerialNumber), DBNull.Value, PersonCompressor.SerialNumber))
                            CmdCompressor.Parameters.AddWithValue("@patrimony", If(String.IsNullOrEmpty(PersonCompressor.Patrimony), DBNull.Value, PersonCompressor.Patrimony))
                            CmdCompressor.Parameters.AddWithValue("@sector", If(String.IsNullOrEmpty(PersonCompressor.Sector), DBNull.Value, PersonCompressor.Sector))
                            CmdCompressor.Parameters.AddWithValue("@unitcapacity", PersonCompressor.UnitCapacity)
                            CmdCompressor.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(PersonCompressor.Note), DBNull.Value, PersonCompressor.Note))
                            CmdCompressor.Parameters.AddWithValue("@userid", PersonCompressor.User.ID)
                            CmdCompressor.ExecuteNonQuery()
                            PersonCompressor.SetID(CmdCompressor.LastInsertedId)
                            For Each PartWorkedHour In PersonCompressor.PartsWorkedHour
                                Using CmdPartWorkedHour As New MySqlCommand(My.Resources.PersonCompressorSellableInsert, Con)
                                    CmdPartWorkedHour.Transaction = Tra
                                    CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                                    CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                                    CmdPartWorkedHour.Parameters.AddWithValue("@statusid", CInt(PartWorkedHour.Status))
                                    CmdPartWorkedHour.Parameters.AddWithValue("@partbindid", CInt(PartWorkedHour.PartBind))
                                    CmdPartWorkedHour.Parameters.AddWithValue("@parttypeid", PartWorkedHour.PartType)
                                    CmdPartWorkedHour.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartWorkedHour.ItemName), DBNull.Value, PartWorkedHour.ItemName))
                                    CmdPartWorkedHour.Parameters.AddWithValue("@productid", If(PartWorkedHour.Product.Value.ID = 0, DBNull.Value, PartWorkedHour.Product.Value.ID))
                                    CmdPartWorkedHour.Parameters.AddWithValue("@quantity", PartWorkedHour.Quantity)
                                    CmdPartWorkedHour.Parameters.AddWithValue("@capacity", PartWorkedHour.Capacity)
                                    CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                                    CmdPartWorkedHour.ExecuteNonQuery()
                                    PartWorkedHour.SetID(CmdPartWorkedHour.LastInsertedId)
                                End Using
                            Next PartWorkedHour
                            For Each PartElapsedDay In PersonCompressor.PartsElapsedDay
                                Using CmdPartElapsedDay As New MySqlCommand(My.Resources.PersonCompressorSellableInsert, Con)
                                    CmdPartElapsedDay.Transaction = Tra
                                    CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                                    CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                                    CmdPartElapsedDay.Parameters.AddWithValue("@statusid", CInt(PartElapsedDay.Status))
                                    CmdPartElapsedDay.Parameters.AddWithValue("@partbindid", CInt(PartElapsedDay.PartBind))
                                    CmdPartElapsedDay.Parameters.AddWithValue("@parttypeid", PartElapsedDay.PartType)
                                    CmdPartElapsedDay.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartElapsedDay.ItemName), DBNull.Value, PartElapsedDay.ItemName))
                                    CmdPartElapsedDay.Parameters.AddWithValue("@productid", If(PartElapsedDay.Product.Value.ID = 0, DBNull.Value, PartElapsedDay.Product.Value.ID))
                                    CmdPartElapsedDay.Parameters.AddWithValue("@quantity", PartElapsedDay.Quantity)
                                    CmdPartElapsedDay.Parameters.AddWithValue("@capacity", PartElapsedDay.Capacity)
                                    CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                                    CmdPartElapsedDay.ExecuteNonQuery()
                                    PartElapsedDay.SetID(CmdPartElapsedDay.LastInsertedId)
                                End Using
                            Next PartElapsedDay
                        End Using
                    Else
                        Using CmdCompressor As New MySqlCommand(My.Resources.PersonCompressorUpdate, Con)
                            CmdCompressor.Transaction = Tra
                            CmdCompressor.Parameters.AddWithValue("@id", PersonCompressor.ID)
                            CmdCompressor.Parameters.AddWithValue("@statusid", CInt(PersonCompressor.Status))
                            CmdCompressor.Parameters.AddWithValue("@compressorid", PersonCompressor.Compressor.ID)
                            CmdCompressor.Parameters.AddWithValue("@serialnumber", If(String.IsNullOrEmpty(PersonCompressor.SerialNumber), DBNull.Value, PersonCompressor.SerialNumber))
                            CmdCompressor.Parameters.AddWithValue("@patrimony", If(String.IsNullOrEmpty(PersonCompressor.Patrimony), DBNull.Value, PersonCompressor.Patrimony))
                            CmdCompressor.Parameters.AddWithValue("@sector", If(String.IsNullOrEmpty(PersonCompressor.Sector), DBNull.Value, PersonCompressor.Sector))
                            CmdCompressor.Parameters.AddWithValue("@unitcapacity", PersonCompressor.UnitCapacity)
                            CmdCompressor.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(PersonCompressor.Note), DBNull.Value, PersonCompressor.Note))
                            CmdCompressor.Parameters.AddWithValue("@userid", PersonCompressor.User.ID)
                            CmdCompressor.ExecuteNonQuery()
                            For Each PartWorkedHour As PersonCompressorSellable In PersonCompressor.PartsWorkedHour
                                If PartWorkedHour.ID = 0 Then
                                    Using CmdPartWorkedHour As New MySqlCommand(My.Resources.PersonCompressorSellableInsert, Con)
                                        CmdPartWorkedHour.Transaction = Tra
                                        CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@statusid", CInt(PartWorkedHour.Status))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@partbindid", CInt(PartWorkedHour.PartBind))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@parttypeid", PartWorkedHour.PartType)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartWorkedHour.ItemName), DBNull.Value, PartWorkedHour.ItemName))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@productid", If(PartWorkedHour.Product.Value.ID = 0, DBNull.Value, PartWorkedHour.Product.Value.ID))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@quantity", PartWorkedHour.Quantity)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@capacity", PartWorkedHour.Capacity)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                                        CmdPartWorkedHour.ExecuteNonQuery()
                                        PartWorkedHour.SetID(CmdPartWorkedHour.LastInsertedId)
                                    End Using
                                Else
                                    Using CmdPartWorkedHour As New MySqlCommand(My.Resources.PersonCompressorSellableUpdate, Con)
                                        CmdPartWorkedHour.Transaction = Tra
                                        CmdPartWorkedHour.Parameters.AddWithValue("@id", PartWorkedHour.ID)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@statusid", CInt(PartWorkedHour.Status))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@partbindid", CInt(PartWorkedHour.PartBind))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartWorkedHour.ItemName), DBNull.Value, PartWorkedHour.ItemName))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@productid", If(PartWorkedHour.Product.Value.ID = 0, DBNull.Value, PartWorkedHour.Product.Value.ID))
                                        CmdPartWorkedHour.Parameters.AddWithValue("@quantity", PartWorkedHour.Quantity)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@capacity", PartWorkedHour.Capacity)
                                        CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                                        CmdPartWorkedHour.ExecuteNonQuery()
                                    End Using
                                End If
                            Next PartWorkedHour
                            For Each PartElapsedDay In PersonCompressor.PartsElapsedDay
                                If PartElapsedDay.ID = 0 Then
                                    Using CmdPartElapsedDay As New MySqlCommand(My.Resources.PersonCompressorSellableInsert, Con)
                                        CmdPartElapsedDay.Transaction = Tra
                                        CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@statusid", CInt(PartElapsedDay.Status))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@partbindid", CInt(PartElapsedDay.PartBind))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@parttypeid", PartElapsedDay.PartType)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartElapsedDay.ItemName), DBNull.Value, PartElapsedDay.ItemName))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@productid", If(PartElapsedDay.Product.Value.ID = 0, DBNull.Value, PartElapsedDay.Product.Value.ID))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@quantity", PartElapsedDay.Quantity)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@capacity", PartElapsedDay.Capacity)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                                        CmdPartElapsedDay.ExecuteNonQuery()
                                        PartElapsedDay.SetID(CmdPartElapsedDay.LastInsertedId)
                                    End Using
                                Else
                                    Using CmdPartElapsedDay As New MySqlCommand(My.Resources.PersonCompressorSellableUpdate, Con)
                                        CmdPartElapsedDay.Transaction = Tra
                                        CmdPartElapsedDay.Parameters.AddWithValue("@id", PartElapsedDay.ID)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@statusid", CInt(PartElapsedDay.Status))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@partbindid", CInt(PartElapsedDay.PartBind))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(PartElapsedDay.ItemName), DBNull.Value, PartElapsedDay.ItemName))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@productid", If(PartElapsedDay.Product.Value.ID = 0, DBNull.Value, PartElapsedDay.Product.Value.ID))
                                        CmdPartElapsedDay.Parameters.AddWithValue("@quantity", PartElapsedDay.Quantity)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@capacity", PartElapsedDay.Capacity)
                                        CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                                        CmdPartElapsedDay.ExecuteNonQuery()
                                    End Using
                                End If
                            Next PartElapsedDay
                        End Using
                    End If
                Next PersonCompressor
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetAddresses(Transaction As MySqlTransaction) As List(Of PersonAddress)
        Dim TableResult As DataTable
        Dim Addresses As List(Of PersonAddress)
        Dim Address As PersonAddress
        Using CmdAddress As New MySqlCommand(My.Resources.PersonAddressSelect, Transaction.Connection)
            CmdAddress.Transaction = Transaction
            CmdAddress.Parameters.AddWithValue("@personid", ID)
            Using Adp As New MySqlDataAdapter(CmdAddress)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Addresses = New List(Of PersonAddress)
                For Each Row As DataRow In TableResult.Rows
                    Address = New PersonAddress With {
                        .IsMainAddress = Row.Item("ismainaddress"),
                        .Status = Row.Item("statusid"),
                        .Name = Row.Item("name").ToString,
                        .ZipCode = Row.Item("zipcode").ToString,
                        .Street = Row.Item("street").ToString,
                        .Number = Row.Item("number").ToString,
                        .Complement = Row.Item("complement").ToString,
                        .District = Row.Item("district").ToString,
                        .City = New City().Load(Row.Item("cityid"), False),
                        .CityDocument = Row.Item("citydocument").ToString,
                        .StateDocument = Row.Item("statedocument").ToString,
                        .ContributionType = Row.Item("contributiontypeid"),
                        .Carrier = If(Row.Item("carrierid") = ID, Me, New Person().Load(Row.Item("carrierid"), False))
                    }
                    Address.SetIsSaved(True)
                    Address.SetID(Row.Item("id"))
                    Address.SetCreation(Row.Item("creation"))
                    Addresses.Add(Address)
                Next Row
            End Using
        End Using
        Return Addresses
    End Function
    Private Function GetContacts(Transaction As MySqlTransaction) As List(Of PersonContact)
        Dim TableResult As DataTable
        Dim Contacts As List(Of PersonContact)
        Dim Contact As PersonContact
        Using CmdContact As New MySqlCommand(My.Resources.PersonContactSelect, Transaction.Connection)
            CmdContact.Transaction = Transaction
            CmdContact.Parameters.AddWithValue("@personid", ID)
            Using Adp As New MySqlDataAdapter(CmdContact)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Contacts = New List(Of PersonContact)
                For Each Row As DataRow In TableResult.Rows
                    Contact = New PersonContact With {
                        .IsMainContact = Row.Item("ismaincontact"),
                        .Name = Row.Item("name").ToString,
                        .JobTitle = Row.Item("jobtitle").ToString,
                        .Phone = Row.Item("phone").ToString,
                        .Email = Row.Item("email").ToString
                    }
                    Contact.SetIsSaved(True)
                    Contact.SetID(Row.Item("id"))
                    Contact.SetCreation(Row.Item("creation"))
                    Contacts.Add(Contact)
                Next Row
            End Using
        End Using
        Return Contacts
    End Function
    Private Function GetCompressors(Transaction As MySqlTransaction) As List(Of PersonCompressor)
        Dim TableResult As DataTable
        Dim Compressors As List(Of PersonCompressor)
        Dim Compressor As PersonCompressor
        Using CmdCompressor As New MySqlCommand(My.Resources.PersonCompressorSelect, Transaction.Connection)
            CmdCompressor.Transaction = Transaction
            CmdCompressor.Parameters.AddWithValue("@personid", ID)
            Using Adp As New MySqlDataAdapter(CmdCompressor)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Compressors = New List(Of PersonCompressor)
                For Each Row As DataRow In TableResult.Rows
                    Compressor = New PersonCompressor With {
                        .Status = Row.Item("statusid"),
                        .SerialNumber = Row.Item("serialnumber").ToString,
                        .Patrimony = Row.Item("patrimony").ToString,
                        .Sector = Row.Item("sector").ToString,
                        .UnitCapacity = Row.Item("unitcapacity"),
                        .Note = Row.Item("note").ToString
                    }
                    Compressor.Compressor = New Compressor().Load(Row.Item("compressorid"), False)
                    Compressor.SetIsSaved(True)
                    Compressor.SetID(Row.Item("id"))
                    Compressor.SetCreation(Row.Item("creation"))
                    Compressor.PartsWorkedHour = GetCompressorPartsWorkedHour(Transaction, Compressor.ID)
                    Compressor.PartsElapsedDay = GetCompressorPartsElapsedDay(Transaction, Compressor.ID)
                    Compressors.Add(Compressor)
                Next Row
            End Using
        End Using
        Return Compressors
    End Function
    Private Function GetCompressorPartsWorkedHour(Transaction As MySqlTransaction, PersonCompressorID As Long) As List(Of PersonCompressorSellable)
        Dim TableResult As DataTable
        Dim PartsWorkedHour As List(Of PersonCompressorSellable)
        Dim PartWorkedHour As PersonCompressorSellable
        Using CmdPartWorkedHour As New MySqlCommand(My.Resources.PersonCompressorSellableSelect, Transaction.Connection)
            CmdPartWorkedHour.Transaction = Transaction
            CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorid", PersonCompressorID)
            CmdPartWorkedHour.Parameters.AddWithValue("@parttypeid", CompressorSellableControlType.WorkedHour)
            Using Adp As New MySqlDataAdapter(CmdPartWorkedHour)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                PartsWorkedHour = New List(Of PersonCompressorSellable)
                For Each Row As DataRow In TableResult.Rows
                    PartWorkedHour = New PersonCompressorSellable(Row.Item("parttypeid")) With {
                        .Status = Row.Item("statusid"),
                        .PartBind = Row.Item("partbindid"),
                        .ItemName = Row.Item("itemname").ToString,
                        .Product = New Lazy(Of Product)(Function() New Product().Load(Row.Item("productid"), False)),
                        .Quantity = Row.Item("quantity"),
                        .Capacity = Row.Item("capacity")
                    }
                    PartWorkedHour.SetID(Row.Item("id"))
                    PartWorkedHour.SetCreation(Row.Item("creation"))
                    PartWorkedHour.SetIsSaved(True)
                    PartsWorkedHour.Add(PartWorkedHour)
                Next Row
            End Using
        End Using
        Return PartsWorkedHour
    End Function
    Private Function GetCompressorPartsElapsedDay(Transaction As MySqlTransaction, PersonCompressorID As Long) As List(Of PersonCompressorSellable)
        Dim TableResult As DataTable
        Dim PartsElapsedDay As List(Of PersonCompressorSellable)
        Dim PartElapsedDay As PersonCompressorSellable
        Using CmdPartElapsedDay As New MySqlCommand(My.Resources.PersonCompressorSellableSelect, Transaction.Connection)
            CmdPartElapsedDay.Transaction = Transaction
            CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorid", PersonCompressorID)
            CmdPartElapsedDay.Parameters.AddWithValue("@parttypeid", CompressorSellableControlType.ElapsedDay)
            Using Adp As New MySqlDataAdapter(CmdPartElapsedDay)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                PartsElapsedDay = New List(Of PersonCompressorSellable)
                For Each Row As DataRow In TableResult.Rows
                    PartElapsedDay = New PersonCompressorSellable(Row.Item("parttypeid")) With {
                        .Status = Row.Item("statusid"),
                        .PartBind = Row.Item("partbindid"),
                        .ItemName = Row.Item("itemname").ToString,
                        .Product = New Lazy(Of Product)(Function() New Product().Load(Row.Item("productid"), False)),
                        .Quantity = Row.Item("quantity"),
                        .Capacity = Row.Item("capacity")
                    }
                    PartElapsedDay.SetID(Row.Item("id"))
                    PartElapsedDay.SetCreation(Row.Item("creation"))
                    PartElapsedDay.SetIsSaved(True)
                    PartsElapsedDay.Add(PartElapsedDay)
                Next Row
            End Using
        End Using
        Return PartsElapsedDay
    End Function
    Public Shared Sub FillAddressDataGridView(PersonID As Long, Dgv As DataGridView)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.PersonAddressDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@personid", PersonID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.AutoGenerateColumns = False
                    Dgv.Columns.Clear()
                    Dgv.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Principal", .HeaderText = "Principal", .DataPropertyName = "Principal", .CellTemplate = New DataGridViewCheckBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Status", .HeaderText = "Status", .DataPropertyName = "Status", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Endereço", .HeaderText = "Endereço", .DataPropertyName = "Endereço", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).Width = 70
                    Dgv.Columns(1).Width = 100
                    Dgv.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End Using
            End Using
        End Using
    End Sub
    Public Shared Sub FillContactDataGridView(PersonID As Long, Dgv As DataGridView)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.PersonContactDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@personid", PersonID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Dgv.AutoGenerateColumns = False
                    Dgv.Columns.Clear()
                    Dgv.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Principal", .HeaderText = "Principal", .DataPropertyName = "Principal", .CellTemplate = New DataGridViewCheckBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nome", .HeaderText = "Nome", .DataPropertyName = "Nome", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Cargo", .HeaderText = "Cargo", .DataPropertyName = "Cargo", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Telefone", .HeaderText = "Telefone", .DataPropertyName = "Telefone", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "E-Mail", .HeaderText = "E-Mail", .DataPropertyName = "E-Mail", .CellTemplate = New DataGridViewTextBoxCell})
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).Width = 70
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv.Columns(3).Width = 120
                    Dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End Using
            End Using
        End Using
    End Sub
    Public Shared Sub FillCompressorDataGridView(PersonID As Long, Dgv As DataGridView)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.PersonCompressorDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@personid", PersonID)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).Width = 100
                    Dgv.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(2).Width = 150
                    Dgv.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Using
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(ShortName, String.Empty)
    End Function
End Class
