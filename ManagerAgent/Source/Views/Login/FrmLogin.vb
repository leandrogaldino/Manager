Imports ControlLibrary
Imports ManagerCore

Public Class FrmLogin
    Private _SessionModel As SessionModel
    Private _Key As String
    Private _ViewModel As LoginViewModel
    Public Sub New()
        InitializeComponent()
        Dim SessionModel = Locator.GetInstance(Of SessionModel)
        Dim LicenseService = Locator.GetInstance(Of LicenseService)
        Dim CryptoService = Locator.GetInstance(Of CryptoKeyService)
        _ViewModel = New LoginViewModel(SessionModel, LicenseService, CryptoService)
        TxtUsername.DataBindings.Add("Text", _ViewModel, "Username", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtPassword.DataBindings.Add("Text", _ViewModel, "Password", False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPassword.Text = Nothing
    End Sub
    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnConfirm.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Async Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim Result = _ViewModel.Login()
        Select Case Result
            Case LicenseMessages.None
                DialogResult = DialogResult.OK
            Case LicenseMessages.BadPassword
                CMessageBox.Show("Usuário e/ou senha incorretos. Por favor, verifique suas credenciais e tente novamente.", CMessageBoxType.Warning)
            Case LicenseMessages.ExpiredProductKey, LicenseMessages.InvalidProductKey, LicenseMessages.MissingProductKey
                CMessageBox.Show(EnumHelper.GetEnumDescription(Result), CMessageBoxType.Warning)
                Using Frm As New FrmLicenseKey
                    If Frm.ShowDialog() = DialogResult.OK AndAlso _ViewModel.IsValidCredentials() Then
                        DialogResult = DialogResult.OK
                    End If
                End Using
            Case LicenseMessages.OutdatedLocalLicenseKey
                Await _ViewModel.RenewLicense()
        End Select
    End Sub

    Private Sub TxtUsername_TextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged, TxtPassword.TextChanged
        If String.IsNullOrEmpty(TxtUsername.Text) Or String.IsNullOrEmpty(TxtPassword.Text) Then
            BtnConfirm.Enabled = False
        Else
            BtnConfirm.Enabled = True
        End If
    End Sub
End Class