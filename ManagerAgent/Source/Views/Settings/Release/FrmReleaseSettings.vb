Imports System.ComponentModel
Imports ControlLibrary

Public Class FrmReleaseSettings
    Private _ViewModel As ReleaseSettingsViewModel

    Public Sub New()
        InitializeComponent()
        _ViewModel = New ReleaseSettingsViewModel()
        InitializeBindings()
        AddHandler _ViewModel.PropertyChanged, AddressOf OnViewModelPropertychanged
    End Sub

    Private Sub TbrReleaseRegister_ValueChanged(sender As Object, e As EventArgs) Handles TbrReleaseRegister.ValueChanged
        LblReleaseRegister.Text = String.Format("Liberar registros não atualizados a mais de {0} minutos", TbrReleaseRegister.Value)
        EprValidation.Clear()
    End Sub

    Private Sub OnViewModelPropertychanged(sender As Object, e As PropertyChangedEventArgs)
        BtnSave.Enabled = True
    End Sub

    Private Sub InitializeBindings()
        TbrReleaseRegister.DataBindings.Add("Value", _ViewModel, "ReleaseRegister", False, DataSourceUpdateMode.OnPropertyChanged)
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
        Result = _ViewModel.Save()
        Cursor = Cursors.Default
        BtnSave.Enabled = Not Result
    End Sub

    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not _ViewModel.Save() Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

End Class