Imports ControlLibrary
Imports ManagerCore

Public Class FrmLicenseCredentials
    Private _LicenseCloudModel As LicenseCloudModel
    Private _LicenseCloudService As LicenseCloudService
    Public Sub New()

        InitializeComponent()

        _LicenseCloudService = Locator.GetInstance(Of LicenseCloudService)

        Height = 300
        PnCredential.Visible = False
    End Sub


    Private Async Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged, TxtCredentials.TextChanged
        Dim Name As String = TxtName.Text
        Dim Credentials As String = TxtCredentials.Text
        Dim Database As RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.License)

        If Not String.IsNullOrEmpty(Name) And Not String.IsNullOrEmpty(Credentials) Then
            PnCredential.Visible = True
            Height = 330
            _LicenseCloudModel = New LicenseCloudModel With {
                .ProjectID = Name,
                .JsonCredentials = Credentials
            }
            Try
                UpdateUIForCredentialsValidation(Nothing)
                Await Database.Initialize(_LicenseCloudModel)
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
        _LicenseCloudService.Save(_LicenseCloudModel)
        DialogResult = DialogResult.OK
    End Sub
End Class