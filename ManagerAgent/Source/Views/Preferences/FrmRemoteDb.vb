Imports CoreSuite.Infrastructure
Imports ManagerCore

Public Class FrmRemoteDb
    Private _RemoteDbCredentials As RemoteDbCredentialsModel
    Private _RemoteDbCredentialsService As RemoteDbCredentialsService
    Private _Loading As Boolean
    Public Sub New(Credentials As RemoteDbCredentialsModel)
        InitializeComponent()
        _Loading = True
        _RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
        _RemoteDbCredentials = Credentials
        TxtApiKey.Text = _RemoteDbCredentials.ApiKey
        TxtProjectID.Text = _RemoteDbCredentials.ProjectID
        TxtBucketName.Text = _RemoteDbCredentials.BucketName
        TxtUsername.Text = _RemoteDbCredentials.Username
        TxtPassword.Text = _RemoteDbCredentials.Password
        _Loading = False
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtApiKey.TextChanged, TxtBucketName.TextChanged, TxtProjectID.TextChanged, TxtPassword.TextChanged, TxtUsername.TextChanged
        If _Loading Then Return
        Dim ApiKey As String = TxtApiKey.Text
        Dim ProjectID As String = TxtProjectID.Text
        Dim BucketName As String = TxtBucketName.Text
        Dim Username As String = TxtUsername.Text
        Dim Password As String = TxtPassword.Text
        BtnSave.Enabled = False
        If Not String.IsNullOrEmpty(ApiKey) And Not String.IsNullOrEmpty(ProjectID) And Not String.IsNullOrEmpty(BucketName) And Not String.IsNullOrEmpty(Username) And Not String.IsNullOrEmpty(Password) Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        _RemoteDbCredentials.ApiKey = TxtApiKey.Text
        _RemoteDbCredentials.ProjectID = TxtProjectID.Text
        _RemoteDbCredentials.BucketName = TxtBucketName.Text
        _RemoteDbCredentials.Username = TxtUsername.Text
        _RemoteDbCredentials.Password = TxtPassword.Text
        _RemoteDbCredentialsService.Save(_RemoteDbCredentials, RemoteDatabaseType.Customer)
        DialogResult = DialogResult.OK
    End Sub
End Class