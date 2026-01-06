Imports CoreSuite.Controls
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Public Class SetupApp
    Public Shared Sub SetupCMessageBox()
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.ShowEmailErrorButton = True

        Dim LocalDb As MySqlService = Locator.GetInstance(Of MySqlService)
        If LocalDb.Client IsNot Nothing Then
            CMessageBox.SmtpMailServer = New Net.Mail.SmtpClient() With {
           .Host = Session.Preferences.Support.SMTPServer,
           .Port = Session.Preferences.Support.Port,
           .EnableSsl = Session.Preferences.Support.EnableSSL,
           .DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network,
           .UseDefaultCredentials = False,
           .Credentials = New Net.NetworkCredential(
                    Session.Preferences.Support.Email,
                    Session.Preferences.Support.Password
                )
            }
        End If

    End Sub
End Class
