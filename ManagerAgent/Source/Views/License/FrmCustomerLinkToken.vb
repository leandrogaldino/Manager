

Imports CoreSuite.Controls
Imports CoreSuite.Helpers
Imports CoreSuite.Infrastructure
Imports ManagerCore

Public Class FrmCustomerLinkToken
    Private _LicenseService As LicenseService
    Private _Result As LicenseResultModel

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            _Result = ManagerCore.Util.AsyncLock(Function() _LicenseService.GetOnlineLicense(TxtLinkToken.Text))
            If _Result.Success Then
                ManagerCore.Util.AsyncLock(Function() _LicenseService.SaveLocalLicense(_Result.License))
                CMessageBox.Show("Sucesso", "Licença validada com sucesso..", CMessageBoxType.Done)
                SetupSession.Setup()
                DialogResult = DialogResult.OK
            Else
                CMessageBox.Show("Falha", EnumHelper.GetEnumDescription(_Result.Flag), CMessageBoxType.Information)
            End If
        Catch ex As Exception
            CMessageBox.Show("Erro", "Erro ao obter a licença.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
    End Sub

    Public Sub New()
        InitializeComponent()
        _LicenseService = Locator.GetInstance(Of LicenseService)
    End Sub
End Class
