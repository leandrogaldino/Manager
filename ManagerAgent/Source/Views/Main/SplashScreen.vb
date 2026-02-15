Imports ManagerCore

Public Class SplashScreen
    Private Async Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await Task.Delay(2000)
        SetupPaths.Setup()
        SetupLocator.Setup()
        Await SetupDatabase.Setup()
        SetupSession.Setup()
        SetupApp.SetupCMessageBox()
        SetupTasks.Setup()
        Me.Hide()
        If Not IO.File.Exists(ApplicationPaths.RemoteSystemDbCredentialsFile) Then
            Dim Frm As New FrmLicenseCredentials()
            Frm.ShowDialog()
        End If
        If Not IO.File.Exists(ApplicationPaths.LicenseFile) Then
            Dim Frm As New FrmCustomerLinkToken()
            Frm.ShowDialog()
        End If
        If IO.File.Exists(ApplicationPaths.RemoteSystemDbCredentialsFile) And IO.File.Exists(ApplicationPaths.LicenseFile) Then
            Dim Frm As New FrmMain()
            Frm.Show()
        End If
    End Sub
End Class