Imports System.Net.Mail
Imports System.IO
Imports MySql.Data.MySqlClient
Imports ManagerCore
Imports System.Text
Imports ControlLibrary

Public Class Email
    Public Shared Sub Send(UserEmail As UserEmail, Model As EmailModel, [To] As List(Of MailAddress), Cc As List(Of MailAddress), Bcc As List(Of MailAddress), Attachments As List(Of Attachment))
        Dim Credential As Net.NetworkCredential
        Dim Addresses As String
        Dim ID As Long
        Dim AttachmentCount As Integer = 0
        Dim HtmlDocument As HtmlAgilityPack.HtmlDocument
        Dim HtmlImgSource As String
        Dim HtmlImgUri As Uri
        Dim HtmlUri As Uri
        Dim HtmlImgPath As String
        Dim HtmlImgAttachment As Attachment
        Dim TempHtmlFile As String
        Using Client As New SmtpClient(UserEmail.SmtpServer, UserEmail.Port)
            Client.DeliveryMethod = SmtpDeliveryMethod.Network
            Client.UseDefaultCredentials = False
            Client.Credentials = New Net.NetworkCredential(UserEmail.Email, ControlLibrary.Cryptography.Decrypt(UserEmail.Password, Locator.GetInstance(Of CryptoKeyService).ReadCryptoKey()))
            Client.EnableSsl = UserEmail.EnableSSL
            Credential = Client.Credentials
            Using Message As New MailMessage()
                Message.From = New MailAddress(Credential.UserName)
                If [To] IsNot Nothing Then [To].ForEach(Sub(x) Message.To.Add(x))
                If Cc IsNot Nothing Then Cc.ForEach(Sub(x) Message.CC.Add(x))
                If Bcc IsNot Nothing Then Bcc.ForEach(Sub(x) Message.Bcc.Add(x))
                If Attachments IsNot Nothing Then Attachments.ForEach(Sub(x)
                                                                          Message.Attachments.Add(x)
                                                                          AttachmentCount += 1
                                                                      End Sub)
                Message.Subject = Model.Subject
                Message.IsBodyHtml = True
                TempHtmlFile = Model.CreateHtmlFile()
                HtmlDocument = New HtmlAgilityPack.HtmlDocument
                HtmlDocument.Load(Path.Combine(TempHtmlFile), Encoding.UTF8)
                For Each img In HtmlDocument.DocumentNode.Descendants("img")
                    HtmlImgSource = img.GetAttributeValue("src", "")
                    HtmlImgUri = New Uri(HtmlImgSource, UriKind.RelativeOrAbsolute)
                    If Not HtmlImgUri.IsAbsoluteUri Then
                        HtmlUri = New Uri(TempHtmlFile, UriKind.Absolute)
                        HtmlImgUri = New Uri(HtmlUri, HtmlImgUri)
                    End If
                    HtmlImgPath = HtmlImgUri.LocalPath
                    If Not String.IsNullOrEmpty(HtmlImgSource) Then
                        HtmlImgAttachment = New Attachment(HtmlImgPath)
                        HtmlImgAttachment.ContentId = Guid.NewGuid().ToString()
                        Message.Attachments.Add(HtmlImgAttachment)
                        img.SetAttributeValue("src", "cid:" & HtmlImgAttachment.ContentId)
                    End If
                Next
                Message.BodyEncoding = Encoding.UTF8
                Message.Body = HtmlDocument.DocumentNode.OuterHtml
                Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
                    Con.Open()
                    Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                        Using Cmd As New MySqlCommand(My.Resources.EmailSentInsert, Con)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("@ofuserid", Locator.GetInstance(Of Session).User.ID)
                            Cmd.Parameters.AddWithValue("@sentdate", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            Cmd.Parameters.AddWithValue("@fromemail", Message.From.Address)
                            Cmd.Parameters.AddWithValue("@subject", Message.Subject)
                            If [To] IsNot Nothing Then
                                Addresses = String.Empty
                                [To].ToList.ForEach(Sub(x) Addresses &= x.Address & "; ")
                                Cmd.Parameters.AddWithValue("@toemail", Addresses)
                            End If
                            If Cc Is Nothing Then Cc = New List(Of MailAddress)
                            Addresses = String.Empty
                            [Cc].ToList.ForEach(Sub(x) Addresses &= x.Address & "; ")
                            Cmd.Parameters.AddWithValue("@ccemail", Addresses)
                            If Bcc Is Nothing Then Bcc = New List(Of MailAddress)
                            Addresses = String.Empty
                            [Bcc].ToList.ForEach(Sub(x) Addresses &= x.Address & "; ")
                            Cmd.Parameters.AddWithValue("@bccemail", Addresses)
                            If Attachments Is Nothing Then Attachments = New List(Of Attachment)
                            Cmd.Parameters.AddWithValue("@attachment", AttachmentCount)
                            Cmd.ExecuteNonQuery()
                            ID = Cmd.LastInsertedId()
                            Client.Send(Message)
                        End Using
                        Tra.Commit()
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class
