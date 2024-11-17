Imports ControlLibrary
Imports System.ComponentModel

Public Class FrmSuportSettings
    Private _ViewModel As SuportSettingsViewModel

    Public Sub New()
        InitializeComponent()
        _ViewModel = New SuportSettingsViewModel()
        InitializeBindings()
        AddHandler _ViewModel.PropertyChanged, AddressOf OnViewModelPropertychanged
    End Sub
    Private Sub CbxEnableSSL_CheckedChanged(sender As Object, e As EventArgs) Handles CbxEnableSSL.CheckedChanged
        CbxEnableSSL.Text = If(CbxEnableSSL.Checked, "Sim", "Não")
    End Sub
    Private Function IsValidFields() As Boolean
        If Not BrazilianFormatHelper.IsValidEmail(TxtSupportEmail.Text) Then
            EprValidation.SetError(LblEmail, "E-Mail inválido")
            EprValidation.SetIconAlignment(LblEmail, ErrorIconAlignment.MiddleRight)
            TxtSupportEmail.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub OnViewModelPropertychanged(sender As Object, e As PropertyChangedEventArgs)
        BtnSave.Enabled = True
    End Sub
    Private Sub InitializeBindings()
        CbxEnableSSL.DataBindings.Add("Checked", _ViewModel, "EnableSSL", True, DataSourceUpdateMode.OnPropertyChanged)
        TxtSupportEmail.DataBindings.Add("Text", _ViewModel, "Email", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtSupportSMTPServer.DataBindings.Add("Text", _ViewModel, "SmtpServer", False, DataSourceUpdateMode.OnPropertyChanged)
        DbxSupportPort.DataBindings.Add("Text", _ViewModel, "Port", False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Result As Boolean
        Cursor = Cursors.WaitCursor
        If IsValidFields() Then
            Result = _ViewModel.Save()
        End If
        Cursor = Cursors.Default
        BtnSave.Enabled = Not Result
    End Sub

    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim IsValid As Boolean
        Dim Result As Boolean
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                IsValid = IsValidFields()
                If IsValid Then
                    Result = _ViewModel.Save()
                End If

                If Not IsValid Or Not Result Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
End Class