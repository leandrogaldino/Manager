Imports CoreSuite.Controls
Imports CoreSuite.Infrastructure
Imports ManagerCore
Public Class FrmRemoteDbCredentials
    Private _RemoteDbCredentialsService As RemoteDbCredentialsService
    Private ReadOnly _DatabaseType As RemoteDatabaseType
    Public Sub New(DatabaseType As RemoteDatabaseType)
        InitializeComponent()
        _DatabaseType = DatabaseType
        _RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Message As String = ValidateCredentials()
        If Message = Nothing Then
            _RemoteDbCredentialsService.Save(New RemoteDbCredentialsModel With {
               .ApiKey = TxtApiKey.Text,
               .ProjectID = TxtProjectID.Text,
               .BucketName = TxtBucketName.Text,
               .Username = TxtUsername.Text,
               .Password = TxtPassword.Text
           }, _DatabaseType)
            CMessageBox.Show("Sucesso", "Credenciais validadas com sucesso.", CMessageBoxType.Done)
            DialogResult = DialogResult.OK
        Else
            CMessageBox.Show("Erro", Message, CMessageBoxType.Error)
        End If
    End Sub
    Private Function ValidateCredentials() As String
        Dim Credentials = New RemoteDbCredentialsModel With {
            .ApiKey = TxtApiKey.Text,
            .ProjectID = TxtProjectID.Text,
            .BucketName = TxtBucketName.Text,
            .Username = TxtUsername.Text,
            .Password = TxtPassword.Text
        }
        Dim Result = ManagerCore.Util.AsyncLock(Function() Util.TestCloudConnectionAsync(Credentials))
        If Not Result.Success Then Return Result.ErrorMessage
        Return Nothing
    End Function
End Class