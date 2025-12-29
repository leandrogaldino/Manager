Imports ControlLibrary
Imports ManagerCore

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
        Height = 300
        PnCredential.Visible = False
        TxtName.Text = _LicenseCredentialsModel.ProjectID
        TxtCredentials.Text = _LicenseCredentialsModel.JsonCredentials
        _Loading = False
    End Sub
    Private Async Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged, TxtCredentials.TextChanged
        If _Loading Then Return
        Dim Name As String = TxtName.Text
        Dim Credentials As String = TxtCredentials.Text
        Dim Database As RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.License)

        If Not String.IsNullOrEmpty(Name) And Not String.IsNullOrEmpty(Credentials) Then
            PnCredential.Visible = True
            Height = 330
            _LicenseCredentialsModel = New LicenseCredentialsModel With {
                .ProjectID = Name,
                .JsonCredentials = Credentials
            }
            Try
                UpdateUIForCredentialsValidation(Nothing)
                Await Database.Initialize(_LicenseCredentialsModel)
                Await Database.TestConnection()
                UpdateUIForCredentialsValidation(True)
            Catch ex As Exception
                UpdateUIForCredentialsValidation(False)
            End Try

        Else
            BtnOK.Enabled = False
            PnCredential.Visible = False
            Height = 300
        End If
    End Sub
    Private Sub UpdateUIForCredentialsValidation(isValid As Boolean?)
        If isValid Is Nothing Then
            BtnOK.Enabled = False
            PbxLoading.Image = My.Resources.LoadingKey
            LblStatus.Text = "Validando credenciais."
            LblStatus.ForeColor = Color.DodgerBlue
        ElseIf isValid Then
            BtnOK.Enabled = True
            PbxLoading.Image = My.Resources.ValidKey
            LblStatus.Text = "A credencial fornecida é válida."
            LblStatus.ForeColor = Color.DarkGreen
        Else
            BtnOK.Enabled = False
            PbxLoading.Image = My.Resources.InvalidKey
            LblStatus.Text = "A credencial fornecida é inválida."
            LblStatus.ForeColor = Color.DarkRed
        End If
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _LicenseCredentialsService.Save(_LicenseCredentialsModel)
        Dim Result As LicenseResultModel = _LicenseService.GetLocalLicense()
        If Result.Flag = LicenseMessages.LicenseFileNotFound Then _LicenseService.SaveLocalLicense(New LicenseModel())
        DialogResult = DialogResult.OK
    End Sub
End Class