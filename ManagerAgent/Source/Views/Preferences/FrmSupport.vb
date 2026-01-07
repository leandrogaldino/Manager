Imports CoreSuite.Controls
Imports CoreSuite.Helpers
Imports CoreSuite.Infrastructure
Imports ManagerCore

Public Class FrmSupport
    Private ReadOnly _Preferences As PreferencesModel
    Private ReadOnly _PreferencesService As PreferencesService
    Private _Loading As Boolean
    Public Sub New()
        InitializeComponent()
        _Preferences = Locator.GetInstance(Of SessionModel).Preferences
        If _Preferences Is Nothing Then _Preferences = New PreferencesModel()
        _PreferencesService = Locator.GetInstance(Of PreferencesService)
        FillFormWithModel()
    End Sub
    Private Sub FillFormWithModel()
        _Loading = True
        CbxEnableSSL.Checked = _Preferences.Support.EnableSSL
        TxtSupportEmail.Text = _Preferences.Support.Email
        TxtSupportSMTPServer.Text = _Preferences.Support.SMTPServer
        DbxSupportPort.Text = _Preferences.Support.Port
        _Loading = False
    End Sub
    Private Sub FillModelWithForm()
        _Preferences.Support.EnableSSL = CbxEnableSSL.Checked
        _Preferences.Support.Email = TxtSupportEmail.Text
        _Preferences.Support.SMTPServer = TxtSupportSMTPServer.Text
        _Preferences.Support.Port = DbxSupportPort.Text
    End Sub
    Private Sub CbxEnableSSL_CheckedChanged(sender As Object, e As EventArgs) Handles CbxEnableSSL.CheckedChanged
        If Not _Loading Then BtnSave.Enabled = True
        CbxEnableSSL.Text = If(CbxEnableSSL.Checked, "Sim", "Não")
    End Sub

    Private Sub TxtSupportEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtSupportEmail.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub TxtSupportSMTPServer_TextChanged(sender As Object, e As EventArgs) Handles TxtSupportSMTPServer.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub DbxSupportPort_TextChanged(sender As Object, e As EventArgs) Handles DbxSupportPort.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub DbxSupportPort_Leave(sender As Object, e As EventArgs) Handles DbxSupportPort.Leave
        If DbxSupportPort.DecimalValue < 0 Then
            DbxSupportPort.Text = 0
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            Cursor = Cursors.WaitCursor
            FillModelWithForm()
            ManagerCore.Util.AsyncLock(Function() _PreferencesService.SaveAsync(_Preferences))
            SetupApp.SetupCMessageBox()
            DialogResult = DialogResult.OK
        Catch ex As Exception
            CMessageBox.Show("Ocorreu um erro ao salvar.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TxtSupportEmail_Leave(sender As Object, e As EventArgs) Handles TxtSupportEmail.Leave
        If Not BrazilianFormatHelper.IsValidEmail(TxtSupportEmail.Text) Then
            TxtSupportEmail.Text = String.Empty
        End If
    End Sub
End Class