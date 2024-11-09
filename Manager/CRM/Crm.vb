Imports System.IO
Imports System.Reflection
Imports ControlLibrary
Imports HtmlAgilityPack
Imports ManagerCore
Imports MySql.Data.MySqlClient

''' <summary>
''' Representa um CRM.
''' </summary>
Public Class Crm
    Inherits ModelBase
    Private Shared _LastHtml As String
    Private _IsSaved As Boolean
    Public Property Status As CrmStatus = CrmStatus.Pending
    Public Property Customer As New Person
    Public Property Responsible As Person = Locator.GetInstance(Of Session).User.Person.Value
    Public Property Subject As String
    Public Property Treatments As New OrdenedList(Of CrmTreatment)
    Public Sub New()
        _Routine = Routine.Crm
    End Sub
    Public Sub Clear()
        Dim Session = Locator.GetInstance(Of Session)
        Unlock()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        Status = CrmStatus.Pending
        Customer = New Person
        Responsible = Session.User.Person.Value
        Subject = Nothing
        Treatments = New OrdenedList(Of CrmTreatment)
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Crm
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCrm As New MySqlCommand(My.Resources.CrmSelect, Con)
                    CmdCrm.Transaction = Tra
                    CmdCrm.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdCrm)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        _ID = TableResult.Rows(0).Item("id")
                        _Creation = TableResult.Rows(0).Item("creation")
                        Status = TableResult.Rows(0).Item("statusid")
                        Customer = New Person().Load(TableResult.Rows(0).Item("customerid"), False)
                        Responsible = New Person().Load(TableResult.Rows(0).Item("responsibleid"), False)
                        Subject = TableResult.Rows(0).Item("subject").ToString
                        Treatments = GetTreatments(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                        _IsSaved = True
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Public Sub SaveChanges()
        If Not _IsSaved Then
            Insert()
        Else
            Update()
        End If
        _IsSaved = True
        Treatments.ToList().ForEach(Sub(x) x.IsSaved = True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdCrm As New MySqlCommand(My.Resources.CrmDelete, Con)
                CmdCrm.Parameters.AddWithValue("@id", ID)
                CmdCrm.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCrm As New MySqlCommand(My.Resources.CrmInsert, Con)
                    CmdCrm.Transaction = Tra
                    CmdCrm.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdCrm.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdCrm.Parameters.AddWithValue("@customerid", Customer.ID)
                    CmdCrm.Parameters.AddWithValue("@responsibleid", Responsible.ID)
                    CmdCrm.Parameters.AddWithValue("@subject", Subject)
                    CmdCrm.Parameters.AddWithValue("@userid", User.ID)
                    CmdCrm.ExecuteNonQuery()
                    _ID = CmdCrm.LastInsertedId
                End Using
                For Each Treatment As CrmTreatment In Treatments
                    Using CmdTreatment As New MySqlCommand(My.Resources.CrmTreatmentInsert, Con)
                        CmdTreatment.Transaction = Tra
                        CmdTreatment.Parameters.AddWithValue("@crmid", ID)
                        CmdTreatment.Parameters.AddWithValue("@creation", Treatment.Creation)
                        CmdTreatment.Parameters.AddWithValue("@responsibleid", Treatment.Responsible.ID)
                        CmdTreatment.Parameters.AddWithValue("@contact", Treatment.Contact.ToString("yyyy-MM-dd"))
                        CmdTreatment.Parameters.AddWithValue("@nextcontact", Treatment.NextContact.ToString("yyyy-MM-dd"))
                        CmdTreatment.Parameters.AddWithValue("@contacttypeid", CInt(Treatment.ContactType))
                        CmdTreatment.Parameters.AddWithValue("@summary", Treatment.Summary)
                        CmdTreatment.Parameters.AddWithValue("@userid", Treatment.User.ID)
                        CmdTreatment.ExecuteNonQuery()
                        Treatment.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Treatment, CmdTreatment.LastInsertedId)
                    End Using
                Next Treatment
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Shadow As Crm = New Crm().Load(ID, False)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdCrm As New MySqlCommand(My.Resources.CrmUpdate, Con)
                    CmdCrm.Transaction = Tra
                    CmdCrm.Parameters.AddWithValue("@id", ID)
                    CmdCrm.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdCrm.Parameters.AddWithValue("@customerid", Customer.ID)
                    CmdCrm.Parameters.AddWithValue("@responsibleid", Responsible.ID)
                    CmdCrm.Parameters.AddWithValue("@subject", Subject)
                    CmdCrm.Parameters.AddWithValue("@userid", User.ID)
                    CmdCrm.ExecuteNonQuery()
                End Using
                For Each Treatment As CrmTreatment In Shadow.Treatments
                    If Not Treatments.Any(Function(x) x.ID = Treatment.ID And x.ID > 0) Then
                        Using CmdTreatment As New MySqlCommand(My.Resources.CrmTreatmentDelete, Con)
                            CmdTreatment.Transaction = Tra
                            CmdTreatment.Parameters.AddWithValue("@id", Treatment.ID)
                            CmdTreatment.ExecuteNonQuery()
                        End Using
                    End If
                Next Treatment
                For Each Treatment As CrmTreatment In Treatments
                    If Treatment.ID = 0 Then
                        Using CmdTreatment As New MySqlCommand(My.Resources.CrmTreatmentInsert, Con)
                            CmdTreatment.Transaction = Tra
                            CmdTreatment.Parameters.AddWithValue("@crmid", ID)
                            CmdTreatment.Parameters.AddWithValue("@creation", Treatment.Creation)
                            CmdTreatment.Parameters.AddWithValue("@responsibleid", Treatment.Responsible.ID)
                            CmdTreatment.Parameters.AddWithValue("@contact", Treatment.Contact.ToString("yyyy-MM-dd"))
                            CmdTreatment.Parameters.AddWithValue("@nextcontact", Treatment.NextContact.ToString("yyyy-MM-dd"))
                            CmdTreatment.Parameters.AddWithValue("@contacttypeid", CInt(Treatment.ContactType))
                            CmdTreatment.Parameters.AddWithValue("@summary", Treatment.Summary)
                            CmdTreatment.Parameters.AddWithValue("@userid", Treatment.User.ID)
                            CmdTreatment.ExecuteNonQuery()
                            Treatment.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Treatment, CmdTreatment.LastInsertedId)
                        End Using
                    Else
                        Using CmdAddress As New MySqlCommand(My.Resources.CrmTreatmentUpdate, Con)
                            CmdAddress.Transaction = Tra
                            CmdAddress.Parameters.AddWithValue("@id", Treatment.ID)
                            CmdAddress.Parameters.AddWithValue("@responsibleid", Treatment.Responsible.ID)
                            CmdAddress.Parameters.AddWithValue("@contact", Treatment.Contact.ToString("yyyy-MM-dd"))
                            CmdAddress.Parameters.AddWithValue("@nextcontact", Treatment.NextContact.ToString("yyyy-MM-dd"))
                            CmdAddress.Parameters.AddWithValue("@contacttypeid", CInt(Treatment.ContactType))
                            CmdAddress.Parameters.AddWithValue("@summary", Treatment.Summary)
                            CmdAddress.Parameters.AddWithValue("@userid", Treatment.User.ID)
                            CmdAddress.ExecuteNonQuery()
                        End Using
                    End If
                Next Treatment
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetTreatments(Transaction As MySqlTransaction) As OrdenedList(Of CrmTreatment)
        Dim TableResult As DataTable
        Dim Treatments As OrdenedList(Of CrmTreatment)
        Dim Treatment As CrmTreatment
        Using CmdTreatment As New MySqlCommand(My.Resources.CrmTreatmentSelect, Transaction.Connection)
            CmdTreatment.Transaction = Transaction
            CmdTreatment.Parameters.AddWithValue("@crmid", ID)
            Using Adp As New MySqlDataAdapter(CmdTreatment)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Treatments = New OrdenedList(Of CrmTreatment)
                For Each Row As DataRow In TableResult.Rows
                    Treatment = New CrmTreatment()
                    Treatment.Responsible = New Person().Load(Row.Item("responsibleid"), False)
                    Treatment.Contact = Row.Item("contact")
                    Treatment.NextContact = Row.Item("nextcontact")
                    Treatment.ContactType = Row.Item("contacttypeid")
                    Treatment.Summary = Row.Item("summary").ToString
                    Treatment.IsSaved = True
                    Treatment.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Treatment, Row.Item("id"))
                    Treatment.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Treatment, Row.Item("creation"))
                    Treatments.Add(Treatment)
                Next Row
            End Using
        End Using
        Return Treatments
    End Function
    Public Shared Function GetHtml(CrmID As Long, Optional Filter As String = Nothing)
        Dim Session = Locator.GetInstance(Of Session)
        Dim Filename As String
        Dim Doc As New HtmlDocument()
        Dim DivCard As HtmlNode
        Dim DivCardHeader As HtmlNode
        Dim DivContactInfo As HtmlNode
        Dim ImgContactType As HtmlNode
        Dim PContact As HtmlNode
        Dim PNextContact As HtmlNode
        Dim PResponsible As HtmlNode
        Dim PSummary As HtmlNode
        Dim BodyNode As HtmlNode
        Dim DivSeparator As HtmlNode
        Dim TableResult As DataTable
        Doc.LoadHtml(My.Resources.CrmCards)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.CrmDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@crmid", CrmID)
                Cmd.Parameters.AddWithValue("@summaryfilter", If(String.IsNullOrEmpty(Filter), "%", Filter))
                Con.Open()
                Using Adp As New MySqlDataAdapter(Cmd)
                    TableResult = New DataTable
                    Adp.Fill(TableResult)
                End Using
                For Each Row As DataRow In TableResult.Rows
                    DivCard = Doc.CreateElement("div")
                    DivCard.SetAttributeValue("class", "card")
                    DivCardHeader = Doc.CreateElement("div")
                    DivCardHeader.SetAttributeValue("class", "cardheader-black")
                    DivContactInfo = Doc.CreateElement("div")
                    DivContactInfo.SetAttributeValue("class", "contactinfo")
                    ImgContactType = Doc.CreateElement("img")
                    Dim ContactTypeImage As Image
                    If Row.Item("contacttypeid") = 0 Then
                        ContactTypeImage = My.Resources.ContactPhone
                    ElseIf Row.Item("contacttypeid") = 1 Then
                        ContactTypeImage = My.Resources.ContactEmail
                    Else
                        ContactTypeImage = My.Resources.ContactWhatsapp
                    End If
                    ImgContactType.SetAttributeValue("src", $"data:image/png;base64,{ImageToBase64(ContactTypeImage)}")
                    ImgContactType.SetAttributeValue("width", "24")
                    ImgContactType.SetAttributeValue("height", "24")
                    DivContactInfo.AppendChild(ImgContactType)
                    PContact = Doc.CreateElement("p")
                    PContact.SetAttributeValue("class", "colorwhite")
                    PContact.InnerHtml = $"<span class='title'>Contato:</span> {Row.Item("contact"):dd/MM/yyyy}"
                    DivContactInfo.AppendChild(PContact)
                    PNextContact = Doc.CreateElement("p")
                    PNextContact.SetAttributeValue("class", "colorwhite nextcontact-margin")
                    PNextContact.InnerHtml = $"<span class='title'>Próx. Contato:</span> {Row.Item("nextcontact"):dd/MM/yyyy}"
                    DivContactInfo.AppendChild(PNextContact)
                    DivCardHeader.AppendChild(DivContactInfo)
                    PResponsible = Doc.CreateElement("p")
                    PResponsible.SetAttributeValue("class", "colorwhite")
                    PResponsible.InnerHtml = $"<span class='title'>Responsável:</span> {Utility.GetTitleCase(PrepareString(Row.Item("responsible").ToString))}"
                    DivCardHeader.AppendChild(PResponsible)
                    DivCard.AppendChild(DivCardHeader)
                    PSummary = Doc.CreateElement("p")
                    PSummary.SetAttributeValue("class", "summary")
                    PSummary.InnerHtml = $"{PrepareString(Row.Item("summary").ToString)}"
                    DivCard.AppendChild(PSummary)
                    BodyNode = Doc.DocumentNode.SelectSingleNode("//body")
                    BodyNode.PrependChild(DivCard)
                    If Row IsNot TableResult.Rows(TableResult.Rows.Count - 1) Then
                        DivSeparator = Doc.CreateElement("div")
                        DivSeparator.SetAttributeValue("class", "separator")
                        DivSeparator.InnerHtml = "• • •"
                        BodyNode.PrependChild(DivSeparator)
                    End If
                Next Row
                Filename = Path.Combine(ApplicationPaths.ManagerTempDirectory, $"{Session.Token}.html")
                If _LastHtml <> Doc.DocumentNode.OuterHtml Then
                    _LastHtml = Doc.DocumentNode.OuterHtml
                    File.WriteAllText(Filename, Doc.DocumentNode.OuterHtml)
                End If
                Return Filename
            End Using
        End Using
    End Function
    Public Function GetHtml(Optional Filter As String = Nothing) As String
        Dim User As User = Locator.GetInstance(Of Session).User
        Dim Filename As String
        Dim FilteredTreatments As List(Of CrmTreatment)
        Dim Doc As New HtmlDocument()
        Dim DivCard As HtmlNode
        Dim DivCardHeader As HtmlNode
        Dim DivContactInfo As HtmlNode
        Dim ImgContactType As HtmlNode
        Dim PContact As HtmlNode
        Dim PNextContact As HtmlNode
        Dim LinkEdit As HtmlNode
        Dim ImgEdit As HtmlNode
        Dim LinkDelete As HtmlNode
        Dim ImgDelete As HtmlNode
        Dim PResponsible As HtmlNode
        Dim PSummary As HtmlNode
        Dim BodyNode As HtmlNode
        Dim DivSeparator As HtmlNode
        If Not String.IsNullOrEmpty(Filter) Then
            FilteredTreatments = Treatments.Where(Function(x) x.Summary.Contains(Filter)).ToList
        Else
            FilteredTreatments = Treatments.ToList
        End If
        Doc.LoadHtml(My.Resources.CrmCards)
        For Each Treatment As CrmTreatment In FilteredTreatments
            DivCard = Doc.CreateElement("div")
            DivCard.SetAttributeValue("class", "card")
            DivCardHeader = Doc.CreateElement("div")
            DivCardHeader.SetAttributeValue("class", If(Treatment.ID = 0, "cardheader-green", "cardheader-black"))
            DivContactInfo = Doc.CreateElement("div")
            DivContactInfo.SetAttributeValue("class", "contactinfo")
            ImgContactType = Doc.CreateElement("img")
            ImgContactType.SetAttributeValue("src", $"data:image/png;base64,{ImageToBase64(Treatment.ContactTypeImage)}")
            ImgContactType.SetAttributeValue("width", "24")
            ImgContactType.SetAttributeValue("height", "24")
            DivContactInfo.AppendChild(ImgContactType)
            PContact = Doc.CreateElement("p")
            PContact.SetAttributeValue("class", "colorwhite")
            PContact.InnerHtml = $"<span class='title'>Contato:</span> {Treatment.Contact:dd/MM/yyyy}"
            DivContactInfo.AppendChild(PContact)
            PNextContact = Doc.CreateElement("p")
            PNextContact.SetAttributeValue("class", "colorwhite nextcontact-margin")
            PNextContact.InnerHtml = $"<span class='title'>Próx. Contato:</span> {Treatment.NextContact:dd/MM/yyyy}"
            DivContactInfo.AppendChild(PNextContact)
            DivCardHeader.AppendChild(DivContactInfo)
            LinkEdit = Doc.CreateElement("a")
            LinkEdit.Attributes.Add("href", "#")
            LinkEdit.Attributes.Add("class", "no-decoration")
            LinkEdit.Attributes.Add("treatmentorder", Treatment.Order)
            LinkEdit.Attributes.Add("eventtype", "edit")
            ImgEdit = Doc.CreateElement("img")
            ImgEdit.SetAttributeValue("src", $"data:image/png;base64,{ImageToBase64(Utility.GetRecoloredImage(My.Resources.EditSmall, Color.White))}")
            ImgEdit.Attributes.Add("class", "edit-button")
            DivContactInfo.AppendChild(LinkEdit)
            LinkDelete = Doc.CreateElement("a")
            LinkDelete.Attributes.Add("href", "#")
            LinkDelete.Attributes.Add("class", "no-decoration")
            LinkDelete.Attributes.Add("treatmentorder", Treatment.Order)
            LinkDelete.Attributes.Add("eventtype", "delete")
            ImgDelete = Doc.CreateElement("img")
            ImgDelete.SetAttributeValue("src", $"data:image/png;base64,{ImageToBase64(Utility.GetRecoloredImage(My.Resources.DeleteSmall2, Color.White))}")
            ImgDelete.Attributes.Add("class", "delete-button")
            LinkDelete.AppendChild(ImgDelete)
            If Treatment.ID = 0 Then
                LinkEdit.AppendChild(ImgEdit)
                DivContactInfo.AppendChild(LinkDelete)
            Else
                If User.CanAccess(Routine.CrmTreatment) Then
                    LinkEdit.AppendChild(ImgEdit)
                End If
                If User.CanDelete(Routine.CrmTreatment) Then
                    DivContactInfo.AppendChild(LinkDelete)
                End If
            End If
            If Treatment.Responsible.ID > 0 Then
                PResponsible = Doc.CreateElement("p")
                PResponsible.SetAttributeValue("class", "colorwhite")
                PResponsible.InnerHtml = $"<span class='title'>Responsável:</span> {Utility.GetTitleCase(PrepareString(Treatment.Responsible.Name))}"
                DivCardHeader.AppendChild(PResponsible)
            End If
            DivCard.AppendChild(DivCardHeader)
            PSummary = Doc.CreateElement("p")
            PSummary.SetAttributeValue("class", "summary")
            PSummary.InnerHtml = $"{PrepareString(Treatment.Summary)}"
            DivCard.AppendChild(PSummary)
            BodyNode = Doc.DocumentNode.SelectSingleNode("//body")
            BodyNode.PrependChild(DivCard)
            If Treatment IsNot FilteredTreatments.Last Then
                DivSeparator = Doc.CreateElement("div")
                DivSeparator.SetAttributeValue("class", "separator")
                DivSeparator.InnerHtml = "• • •"
                BodyNode.PrependChild(DivSeparator)
            End If
        Next Treatment
        Filename = Path.Combine(ApplicationPaths.ManagerTempDirectory, $"{Session.Token}.html")
        If _LastHtml <> Doc.DocumentNode.OuterHtml Then
            _LastHtml = Doc.DocumentNode.OuterHtml
            File.WriteAllText(Filename, Doc.DocumentNode.OuterHtml)
        End If
        Return Filename
    End Function
    Private Shared Function PrepareString(Text As String) As String
        If Not String.IsNullOrEmpty(Text) Then
            Text = Text.Replace("&", "&amp;")
            Text = Text.Replace("<", "&lt;")
            Text = Text.Replace(">", "&gt;")
            Text = Text.Replace("""", "&quot;")
            Text = Text.Replace("'", "&#39;")
            Text = Text.Replace(vbCrLf, "<br>")
        End If
        Return Text
    End Function
    Private Shared Function ImageToBase64(Image As Bitmap) As String
        Dim ImageBytes As Byte()
        Dim Base64String As String
        Using MemoryStream As New MemoryStream()
            Image.Save(MemoryStream, Imaging.ImageFormat.Png)
            ImageBytes = MemoryStream.ToArray()
            Base64String = Convert.ToBase64String(ImageBytes)
            Return Base64String
        End Using
    End Function
    Public Sub SetStatus(Status As CrmStatus)
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.CrmSetStatus, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                Cmd.ExecuteNonQuery()
                _Status = Status
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Subject, String.Empty)
    End Function
End Class
