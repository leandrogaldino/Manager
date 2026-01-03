Imports ManagerCore
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports CoreSuite.Controls
Public Class FrmLicenseCredentials
    Private _LicenseService As LicenseService
    Private _LicenseCredentials As LicenseRemoteDatabaseModel
    Private _LicenseCredentialsService As LicenseCredentialsService
    Private _Loading As Boolean
    Public Sub New(Credentials As LicenseRemoteDatabaseModel)
        InitializeComponent()
        _Loading = True
        _LicenseService = Locator.GetInstance(Of LicenseService)
        _LicenseCredentialsService = Locator.GetInstance(Of LicenseCredentialsService)
        _LicenseCredentials = Credentials
        TxtApiKey.Text = _LicenseCredentials.ApiKey
        TxtProjectID.Text = _LicenseCredentials.ProjectID
        TxtBucketName.Text = _LicenseCredentials.BucketName
        TxtUsername.Text = _LicenseCredentials.Username
        TxtPassword.Text = _LicenseCredentials.Password
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
    Private Async Sub BtnOK_Click(sender As Object, e As EventArgs)
        _LicenseCredentialsService.Save(_LicenseCredentials)
        Dim Result As LicenseResultModel = _LicenseService.GetLocalLicense()
        If Result.Flag = LicenseMessages.LicenseFileNotFound Then Await _LicenseService.SaveLocalLicense(New LicenseModel())
        DialogResult = DialogResult.OK
    End Sub
    Private Async Sub BtnTest_Click(sender As Object, e As EventArgs)
        Using LoaderForm As New FrmLoader(My.Resources.Loading)
            Dim Loader As New AsyncLoader(Me, LoaderForm, 10, True, Color.White)
            Await Loader.Start()
            Await Task.Delay(3000)
            Dim Result As DatabaseTestResultModel = Await Util.TestCloudConnectionAsync(_LicenseCredentials)
            If Result.Success Then
                RemoveHandler BtnTestAndOK.Click, AddressOf BtnTest_Click
                AddHandler BtnTestAndOK.Click, AddressOf BtnOK_Click
                BtnTestAndOK.Text = "OK"
            Else
                CMessageBox.Show(Result.ErrorMessage, CMessageBoxType.Error, CMessageBoxButtons.OK, Result.Exception)
            End If
            Await Loader.Stop()
        End Using
    End Sub
End Class