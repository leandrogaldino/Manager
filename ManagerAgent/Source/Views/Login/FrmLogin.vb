Imports ManagerCore
Imports CoreSuite.Infrastructure
Imports CoreSuite.Helpers
Imports CoreSuite.Controls
Imports CoreSuite.Services

Public Class FrmLogin
    Private ReadOnly _Session As SessionModel
    Private ReadOnly _LicenseService As LicenseService
    Private ReadOnly _CryptoService As CryptoKeyService
    Private _Key As String
    Public Sub New()
        InitializeComponent()
        _Session = Locator.GetInstance(Of SessionModel)()
        _LicenseService = Locator.GetInstance(Of LicenseService)()
        _CryptoService = Locator.GetInstance(Of CryptoKeyService)()
        _Key = _CryptoService.ReadCryptoKey()
        BtnConfirm.Enabled = False
    End Sub
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPassword.Text = ""
    End Sub
    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnConfirm.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TxtFields_TextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged, TxtPassword.TextChanged
        BtnConfirm.Enabled = Not String.IsNullOrWhiteSpace(TxtUsername.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtPassword.Text)
    End Sub
    Private Async Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim Result As LicenseMessages = Await LoginAsync()
        Select Case Result
            Case LicenseMessages.None
                DialogResult = DialogResult.OK
            Case LicenseMessages.BadUserOrPassword
                CMessageBox.Show("Usuário e/ou senha incorretos. Verifique suas credenciais.", CMessageBoxType.Warning)
            Case LicenseMessages.Expired,
                 LicenseMessages.InvalidCustomerLinkToken,
                 LicenseMessages.EmptyCustomerLinkToken
                CMessageBox.Show(EnumHelper.GetEnumDescription(Result), CMessageBoxType.Warning)
                Using Frm As New FrmCustomerLinkToken
                    If Frm.ShowDialog() = DialogResult.OK Then
                        If ValidateCredentials() Then
                            DialogResult = DialogResult.OK
                        End If
                    End If
                End Using
        End Select
    End Sub
    Private Async Function LoginAsync() As Task(Of LicenseMessages)
        _Session.ManagerLicenseResult = Await _LicenseService.GetLocalLicense()
        If Not _Session.ManagerLicenseResult.Success Then
            Return _Session.ManagerLicenseResult.Flag
        End If
        If ValidateCredentials() Then
            Return LicenseMessages.None
        End If
        Return LicenseMessages.BadUserOrPassword
    End Function
    Private Function ValidateCredentials() As Boolean
        Dim License = _Session.ManagerLicenseResult.License
        If License Is Nothing Then Return False
        Dim EncryptedPassword = Cryptography.Encrypt(TxtPassword.Text, _Key)
        If License.ManagerAgentUsername = TxtUsername.Text AndAlso License.ManagerAgentPassword = EncryptedPassword Then
            Return True
        End If
        _Session.ManagerLicenseResult.Flag = LicenseMessages.BadUserOrPassword
        Return False
    End Function
End Class