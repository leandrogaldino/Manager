Imports System.IO
Imports ControlLibrary
Imports FirebaseController
Imports Helpers
Imports ManagerCore
Imports AsyncLoader

Public Class FrmLicenseCredentials
    Private _LicenseService As LicenseService
    Private _LicenseCredentialsModel As LicenseCredentialsModel
    Private _LicenseCredentialsService As LicenseCredentialsService
    Private _Loading As Boolean
    Public Sub New(LicenseCredentialsModel As LicenseCredentialsModel)
        InitializeComponent()
        _Loading = True
        _LicenseService = Locator.GetInstance(Of LicenseService)
        _LicenseCredentialsService = Locator.GetInstance(Of LicenseCredentialsService)
        _LicenseCredentialsModel = LicenseCredentialsModel
        TxtApiKey.Text = _LicenseCredentialsModel.ApiKey
        TxtProjectID.Text = _LicenseCredentialsModel.ProjectID
        TxtBucketName.Text = _LicenseCredentialsModel.BucketName
        TxtUsername.Text = _LicenseCredentialsModel.Username
        TxtPassword.Text = _LicenseCredentialsModel.Password


        TxtApiKey.Text = "AIzaSyDHKmoQB7o9wKOT1hTF6FKqoSS8r1BtY58"
        TxtProjectID.Text = "manager-license-2a24d"
        TxtBucketName.Text = "manager-license-2a24d.firebasestorage.app"
        TxtUsername.Text = "admin"
        TxtPassword.Text = "123456"

        _Loading = False
        AddHandler BtnTestAndOK.Click, AddressOf BtnTest_Click
    End Sub

    Private _TestPassed As Boolean

    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtApiKey.TextChanged, TxtBucketName.TextChanged, TxtProjectID.TextChanged, TxtPassword.TextChanged, TxtUsername.TextChanged
        If _Loading Then Return
        Dim ApiKey As String = TxtApiKey.Text
        Dim ProjectID As String = TxtProjectID.Text
        Dim BucketName As String = TxtBucketName.Text
        Dim Username As String = TxtUsername.Text
        Dim Password As String = TxtPassword.Text
        RemoveHandler BtnTestAndOK.Click, AddressOf BtnTest_Click
        RemoveHandler BtnTestAndOK.Click, AddressOf BtnOK_Click
        AddHandler BtnTestAndOK.Click, AddressOf BtnTest_Click
        BtnTestAndOK.Enabled = False
        BtnTestAndOK.Text = "Testar"
        If Not String.IsNullOrEmpty(ApiKey) And Not String.IsNullOrEmpty(ProjectID) And Not String.IsNullOrEmpty(BucketName) And Not String.IsNullOrEmpty(Username) And Not String.IsNullOrEmpty(Password) Then
            BtnTestAndOK.Enabled = True
        Else
            BtnTestAndOK.Enabled = False
        End If
    End Sub

    Private Async Function TestConnectionAsync() As Task
        Dim ErrorMessage As String = "Não foi possível conectar ao Firebase com as credenciais informadas."
        Dim RemoteDb = Locator.GetInstance(Of FirebaseService)(CloudDatabaseType.License)
        Dim Name As String = "connectiontest"
        _LicenseCredentialsModel = New LicenseCredentialsModel With {
            .ApiKey = TxtApiKey.Text,
            .ProjectID = TxtProjectID.Text,
            .BucketName = TxtBucketName.Text,
            .Username = TxtUsername.Text,
            .Password = TxtPassword.Text
        }
        RemoteDb.Initialize(_LicenseCredentialsModel.ApiKey, _LicenseCredentialsModel.ProjectID, _LicenseCredentialsModel.BucketName)
        Try
            Await RemoteDb.Auth.LoginAsync($"{_LicenseCredentialsModel.Username}@nexor.com", _LicenseCredentialsModel.Password)
        Catch ex As Exception
            CMessageBox.Show(ErrorMessage, CMessageBoxType.Error)
            _TestPassed = False
            Return
        End Try
        Try
            Dim DocumentID As String = TextHelper.GetRandomFileName
            Await RemoteDb.Firestore.SaveDocumentAsync(Name, DocumentID, New Dictionary(Of String, Object))
            Await RemoteDb.Firestore.DeleteDocumentAsync(Name, DocumentID)
        Catch ex As Exception
            CMessageBox.Show(ErrorMessage, CMessageBoxType.Error)
            _TestPassed = False
            Return
        End Try
        Try
            Dim ConnectionTestFile As String = Path.Combine(ApplicationPaths.AgentTempDirectory, Name)
            File.WriteAllBytes(ConnectionTestFile, {})
            Await RemoteDb.Storage.UploadFile(ConnectionTestFile, Name)
            Await RemoteDb.Storage.DeleteFileAsync(Name)
        Catch ex As Exception
            CMessageBox.Show(ErrorMessage, CMessageBoxType.Error)
            _TestPassed = False
            Return
        End Try
        _TestPassed = True
    End Function

    Private Async Sub BtnOK_Click(sender As Object, e As EventArgs)
        _LicenseCredentialsService.Save(_LicenseCredentialsModel)
        Dim Result As LicenseResultModel = _LicenseService.GetLocalLicense()
        If Result.Flag = LicenseMessages.LicenseFileNotFound Then Await _LicenseService.SaveLocalLicense(New LicenseModel())
        DialogResult = DialogResult.OK
    End Sub
    Private Async Sub BtnTest_Click(sender As Object, e As EventArgs)
        Using LoaderForm As New FrmLoader(My.Resources.Loading)
            Dim Loader As New LoaderController(Me, LoaderForm, 10, True, Color.White)
            Await Loader.Start()
            Await Task.Delay(3000)
            Await TestConnectionAsync()
            If _TestPassed Then
                RemoveHandler BtnTestAndOK.Click, AddressOf BtnTest_Click
                AddHandler BtnTestAndOK.Click, AddressOf BtnOK_Click
                BtnTestAndOK.Text = "OK"
            End If
            Await Loader.Stop()
        End Using
    End Sub
End Class