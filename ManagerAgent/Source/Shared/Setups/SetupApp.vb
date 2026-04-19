Imports CoreSuite.Controls
Imports CoreSuite.Infrastructure
Public Class SetupApp
    Public Shared Sub SetupCMessageBox()
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.ShowEmailErrorButton = True
        Dim Config = Session.Preferences.Support
        If String.IsNullOrWhiteSpace(Config.SMTPServer) Then Exit Sub
        If Config.Port <= 0 OrElse Config.Port > 65535 Then Exit Sub
        If String.IsNullOrWhiteSpace(Config.Email) OrElse String.IsNullOrWhiteSpace(Config.Password) Then Exit Sub
        Dim Smtp As New Net.Mail.SmtpClient()
        Smtp.Host = Config.SMTPServer
        Smtp.Port = Config.Port
        Smtp.EnableSsl = Config.EnableSSL
        Smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
        Smtp.UseDefaultCredentials = False
        Smtp.Credentials = New Net.NetworkCredential(Config.Email, Config.Password)
        CMessageBox.SmtpMailServer = Smtp
    End Sub
End Class
