Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            SetupApp.SetupIO()
            SetupLocator.Setup()
            SetupSettings.Setup()
            SetupCMessageBox.SetupBeforeLogin()
            SetupApp.SetupDatabases()
            SetupQueriedBox.Setup()
        End Sub
    End Class
End Namespace
