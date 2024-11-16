Imports ControlLibrary
Imports System.Net

Public Class SetupCMessageBox
    Public Shared Sub SetupBeforeLogin()
        Dim Session = Locator.GetInstance(Of Session)
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.AditionalExceptionInformation.Add("Computador", Environment.MachineName)
        CMessageBox.SmtpMailServer.EnableSsl = Session.Setting.Support.EnableSSL
        CMessageBox.SmtpMailServer.Credentials = New NetworkCredential(Session.Setting.Support.Email, Session.Setting.Support.Password)
        If Not String.IsNullOrEmpty(Session.Setting.Support.SMTPServer) Then
            CMessageBox.SmtpMailServer.Host = Session.Setting.Support.SMTPServer
        End If
        If Session.Setting.Support.Port >= 1 And Session.Setting.Support.Port <= 65535 Then
            CMessageBox.SmtpMailServer.Port = Session.Setting.Support.Port
        End If
    End Sub
    Public Shared Sub SetupAfterLogin()
        Dim Session = Locator.GetInstance(Of Session)
        CMessageBox.AditionalExceptionInformation.Clear()
        CMessageBox.AditionalExceptionInformation.Add("Usuario", Session.User.Username)
        CMessageBox.AditionalExceptionInformation.Add("Nome_Curto_Usuario", Session.User.Person.Value.ShortName)
        CMessageBox.AditionalExceptionInformation.Add("Nome_Usuario", Session.User.Person.Value.Name)
    End Sub
End Class
