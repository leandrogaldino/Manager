Imports ControlLibrary
Imports System.ComponentModel

Public Class FrmUserSettings
    Private _ViewModel As UserSettingsViewModel
    Public Sub New()
        InitializeComponent()
        _ViewModel = New UserSettingsViewModel()
        InitializeBindings()
        AddHandler _ViewModel.PropertyChanged, AddressOf OnViewModelPropertychanged
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(TxtUserDefaultPassword.Text) Then
            EprValidation.SetError(LblUserDefaultPassword, "Campo obrigatório")
            EprValidation.SetIconAlignment(LblUserDefaultPassword, ErrorIconAlignment.MiddleRight)
            TxtUserDefaultPassword.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub OnViewModelPropertychanged(sender As Object, e As PropertyChangedEventArgs)
        BtnSave.Enabled = True
    End Sub
    Private Sub InitializeBindings()
        TxtUserDefaultPassword.DataBindings.Add("Text", _ViewModel, "DefaultPassword", False, DataSourceUpdateMode.OnPropertyChanged)
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