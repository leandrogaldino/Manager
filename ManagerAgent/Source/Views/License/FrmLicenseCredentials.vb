Imports ManagerCore
Imports CoreSuite.Infrastructure
Imports CoreSuite.Controls
Public Class FrmLicenseCredentials
    Private _LicenseService As LicenseService
    Private _RemoteDbCredentialsService As RemoteDbCredentialsService
    Private Async Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Message As String = ValidateCredentials()

        If Message = Nothing Then
            _RemoteDbCredentialsService.Save(New RemoteDbCredentialsModel With {
               .ApiKey = TxtApiKey.Text,
               .ProjectID = TxtProjectID.Text,
               .BucketName = TxtBucketName.Text,
               .Username = TxtUsername.Text,
               .Password = TxtPassword.Text
           }, RemoteDatabaseType.System)
            CMessageBox.Show("Sucesso", "Dados da base de licenciamento validados com sucesso.", CMessageBoxType.Done)
            Await SetupDatabase.Setup()
            DialogResult = DialogResult.OK
        Else
            CMessageBox.Show("Erro", Message, CMessageBoxType.Error)
        End If
    End Sub
    Private Function ValidateCredentials() As String
        Return Validation.ValidateLicenseDatabase(New RemoteDbCredentialsModel With {
            .ApiKey = TxtApiKey.Text,
            .ProjectID = TxtProjectID.Text,
            .BucketName = TxtBucketName.Text,
            .Username = TxtUsername.Text,
            .Password = TxtPassword.Text
        })
    End Function
    Public Sub New()
        InitializeComponent()
        _LicenseService = Locator.GetInstance(Of LicenseService)
        _RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
    End Sub
End Class