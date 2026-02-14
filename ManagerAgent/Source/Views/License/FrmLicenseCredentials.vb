Imports ManagerCore
Imports CoreSuite.Infrastructure
Imports CoreSuite.Controls
Public Class FrmLicenseCredentials
    Private _LicenseService As LicenseService
    Private _RemoteDbCredentialsService As RemoteDbCredentialsService
    Private _IsValid As Boolean
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Message As String
        If _IsValid Then
            _RemoteDbCredentialsService.Save(New RemoteDbCredentialsModel With {
                .ApiKey = TxtApiKey.Text,
                .ProjectID = TxtProjectID.Text,
                .BucketName = TxtBucketName.Text,
                .Username = TxtUsername.Text,
                .Password = TxtPassword.Text
            }, RemoteDatabaseType.System)
            Application.Restart()
        Else
            Message = IsValid()
            If Message Is Nothing Then
                _IsValid = True
                BtnSave.Text = "Concluir"
                CMessageBox.Show("Sucesso", "Dados da base de licenciamento validados com sucesso. Clique em concluir para continuar.", CMessageBoxType.Done)
            Else
                _IsValid = False
                BtnSave.Text = "Validar"
                CMessageBox.Show("Erro", Message, CMessageBoxType.Error)
            End If
        End If
    End Sub
    Private Function IsValid() As String
        Return Validation.ValidateLicense(New RemoteDbCredentialsModel With {
            .ApiKey = TxtApiKey.Text,
            .ProjectID = TxtProjectID.Text,
            .BucketName = TxtBucketName.Text,
            .Username = TxtUsername.Text,
            .Password = TxtPassword.Text
        })
    End Function
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged, TxtProjectID.TextChanged, TxtPassword.TextChanged, TxtBucketName.TextChanged, TxtApiKey.TextChanged
        BtnSave.Text = "Validar"
        _IsValid = False
    End Sub
    Public Sub New()
        InitializeComponent()
        _LicenseService = Locator.GetInstance(Of LicenseService)
        _RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
    End Sub
End Class