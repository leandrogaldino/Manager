Imports ControlLibrary
Imports System.ComponentModel

Public Class FrmCleanSettings
    Private _ViewModel As CleanSettingsViewModel
    Public Sub New()
        InitializeComponent()
        _ViewModel = New CleanSettingsViewModel()
        InitializeBindings()
        AddHandler _ViewModel.PropertyChanged, AddressOf OnViewModelPropertychanged
    End Sub
    Private Sub TbrInterval_ValueChanged(sender As Object, e As EventArgs) Handles TbrInterval.ValueChanged
        LblInterval.Text = String.Format("Executar a limpeza a cada {0} {1}", TbrInterval.Value, If(TbrInterval.Value = 1, "dia", "dias"))
    End Sub
    Private Sub OnViewModelPropertychanged(sender As Object, e As PropertyChangedEventArgs)
        BtnSave.Enabled = True
    End Sub
    Private Sub InitializeBindings()
        TbrInterval.DataBindings.Add("Value", _ViewModel, "Interval", False, DataSourceUpdateMode.OnPropertyChanged)
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
        Cursor = Cursors.WaitCursor
        Dim Result As Boolean = _ViewModel.Save()
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