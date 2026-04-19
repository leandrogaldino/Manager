Imports CoreSuite.Controls
Imports ManagerCore
Public Class SplashScreen
    Private Async Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await Task.Delay(2000)
        SetupPaths.Setup()
        SetupLocator.Setup()
        If Not IO.File.Exists(ApplicationPaths.RemoteSystemDbCredentialsFile) Then
            Dim Frm As New FrmRemoteDbCredentials(RemoteDatabaseType.System)
            Frm.ShowDialog()
        End If
        If IO.File.Exists(ApplicationPaths.RemoteSystemDbCredentialsFile) Then
            Await SetupDatabase.SetupSystem()
        End If
        If Not IO.File.Exists(ApplicationPaths.LicenseFile) Then
            Dim Frm As New FrmCustomerLinkToken()
            Frm.ShowDialog()
        End If
        If Not IO.File.Exists(ApplicationPaths.RemoteCustomerDbCredentialsFile) Then
            Dim Frm As New FrmRemoteDbCredentials(RemoteDatabaseType.Customer) With {
                .Text = "Credenciais da Base de Dados Remota do Cliente"
            }
            Frm.LblTitle.Text = "Base de Dados Remota"
            Frm.LblDescription.Text = "Informe aqui as credenciais de acesso à base de dados remota do cliente."
            Frm.ShowDialog()
        End If
        If IO.File.Exists(ApplicationPaths.RemoteCustomerDbCredentialsFile) Then
            Await SetupDatabase.SetupCustomer()
        End If
        If Not IO.File.Exists(ApplicationPaths.LocalDbCredentialsFile) Then
            Dim Frm As New FrmLocalDbCredentials()
            Frm.ShowDialog()
        End If
        If IO.File.Exists(ApplicationPaths.LocalDbCredentialsFile) Then
            SetupDatabase.SetupLocal()
        End If
        If IO.File.Exists(ApplicationPaths.RemoteSystemDbCredentialsFile) And IO.File.Exists(ApplicationPaths.LicenseFile) And IO.File.Exists(ApplicationPaths.LocalDbCredentialsFile) Then
            SetupSession.Setup()
            SetupApp.SetupCMessageBox()
            SetupTasks.Setup()
            Me.Hide()
            Dim Frm As New FrmMain()
            Frm.Show()
        Else
            CMessageBox.Show("Configurações Pendentes", "As configurações iniciais do sistema não foram concluídas. O sistema será encerrado.", CMessageBoxType.Warning)
            Application.Exit()
        End If
    End Sub
End Class