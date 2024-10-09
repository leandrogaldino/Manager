Imports System.ComponentModel
Imports ControlLibrary

Public Class FrmBackupSettings
    Private _ViewModel As BackupSettingsViewModel
    Private _UcBackupDays As UcBackupDays
    Private _BackupDays As List(Of String)

    Public Sub New()
        InitializeComponent()
        _ViewModel = New BackupSettingsViewModel()
        _BackupDays = New List(Of String)
        _UcBackupDays = New UcBackupDays(CcBackupDays)
        CcBackupDays.DropDownControl = _UcBackupDays
        InitializeBindings()
        SetupHandlers()
        BtnBackupDays.Text = GetBackupDaysText()
    End Sub

    Public Sub SetupHandlers()
        AddHandler _ViewModel.PropertyChanged, AddressOf OnViewModelPropertychanged
        AddHandler _UcBackupDays.CbxMonday.CheckedChanged, AddressOf OnCheckedChanged
        AddHandler _UcBackupDays.CbxTuesday.CheckedChanged, AddressOf OnCheckedChanged
        AddHandler _UcBackupDays.CbxWednesday.CheckedChanged, AddressOf OnCheckedChanged
        AddHandler _UcBackupDays.CbxThursday.CheckedChanged, AddressOf OnCheckedChanged
        AddHandler _UcBackupDays.CbxFriday.CheckedChanged, AddressOf OnCheckedChanged
        AddHandler _UcBackupDays.CbxSaturday.CheckedChanged, AddressOf OnCheckedChanged
        AddHandler _UcBackupDays.CbxSunday.CheckedChanged, AddressOf OnCheckedChanged
    End Sub

    Private Function GetBackupDaysText() As String
        Dim Text As String
        _BackupDays.Clear()
        If _ViewModel.Monday Then _BackupDays.Add("Seg")
        If _ViewModel.Tuesday Then _BackupDays.Add("Ter")
        If _ViewModel.Wednesday Then _BackupDays.Add("Qua")
        If _ViewModel.Thursday Then _BackupDays.Add("Qui")
        If _ViewModel.Friday Then _BackupDays.Add("Sex")
        If _ViewModel.Saturday Then _BackupDays.Add("Sáb")
        If _ViewModel.Sunday Then _BackupDays.Add("Dom")
        Text = String.Join(", ", _BackupDays)
        If String.IsNullOrEmpty(Text) Then Text = "Nenhum"
        Return Text
    End Function

    Private Sub OnCcBackupDays_Closed(sender As Object) Handles CcBackupDays.Closed
        BtnBackupDays.Text = GetBackupDaysText()
    End Sub

    Private Sub OnCheckedChanged(sender As Object, e As EventArgs)
        Dim CheckBox As CheckBox = CType(sender, CheckBox)
        CheckBox.Text = If(CheckBox.Checked, "Sim", "Não")
    End Sub

    Private Sub OnViewModelPropertychanged(sender As Object, e As PropertyChangedEventArgs)
        BtnSave.Enabled = True
    End Sub

    Private Sub InitializeBindings()
        Dim Binding As Binding
        Binding = New Binding("Text", _ViewModel, "Time", True, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler Binding.Format, Sub(sender, e)
                                       If TypeOf e.Value Is TimeSpan Then
                                           e.Value = DirectCast(e.Value, TimeSpan).ToString("hh\:mm\:ss")
                                       End If
                                   End Sub
        AddHandler Binding.Parse, Sub(sender, e)
                                      If TypeOf e.Value Is String Then
                                          Dim timeSpan As TimeSpan
                                          If TimeSpan.TryParse(DirectCast(e.Value, String), timeSpan) Then
                                              e.Value = timeSpan
                                          Else
                                              e.Value = TimeSpan.Zero
                                          End If
                                      End If
                                  End Sub
        TxtBackupTime.DataBindings.Add(Binding)
        Binding = New Binding("Text", _ViewModel, "Keep", False, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler Binding.Format, Sub(sender, e)
                                       If TypeOf e.Value Is String Then
                                           If (String.IsNullOrEmpty(e.Value)) Then
                                               e.Value = 0
                                           End If
                                       End If
                                   End Sub
        AddHandler Binding.Parse, Sub(sender, e)
                                      If TypeOf e.Value Is String Then
                                          If e.Value = "" Then
                                              e.Value = 0
                                          End If
                                      End If
                                  End Sub
        DbxBackupKeep.DataBindings.Add(Binding)

        _UcBackupDays.CbxMonday.DataBindings.Add("Checked", _ViewModel, "Monday", True, DataSourceUpdateMode.OnPropertyChanged)
        _UcBackupDays.CbxTuesday.DataBindings.Add("Checked", _ViewModel, "Tuesday", True, DataSourceUpdateMode.OnPropertyChanged)
        _UcBackupDays.CbxWednesday.DataBindings.Add("Checked", _ViewModel, "Wednesday", True, DataSourceUpdateMode.OnPropertyChanged)
        _UcBackupDays.CbxThursday.DataBindings.Add("Checked", _ViewModel, "Thursday", True, DataSourceUpdateMode.OnPropertyChanged)
        _UcBackupDays.CbxFriday.DataBindings.Add("Checked", _ViewModel, "Friday", True, DataSourceUpdateMode.OnPropertyChanged)
        _UcBackupDays.CbxSaturday.DataBindings.Add("Checked", _ViewModel, "Saturday", True, DataSourceUpdateMode.OnPropertyChanged)
        _UcBackupDays.CbxSunday.DataBindings.Add("Checked", _ViewModel, "Sunday", True, DataSourceUpdateMode.OnPropertyChanged)
        CbxIgnoreNext.DataBindings.Add("Checked", _ViewModel, "IgnoreNext", True, DataSourceUpdateMode.OnPropertyChanged)
        TxtBackupLocation.DataBindings.Add("Text", _ViewModel, "Location", False, DataSourceUpdateMode.OnPropertyChanged)
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

    Private Sub TxtTime_Leave(sender As Object, e As EventArgs) Handles TxtBackupTime.Leave
        Dim TxtControl As MaskedTextBox = CType(sender, MaskedTextBox)
        Dim TimeParts As String()
        Dim Hour As Integer
        Dim Minutes As Integer
        Dim Seconds As Integer
        TimeParts = TxtControl.Text.Split(":"c)
        Integer.TryParse(TimeParts(0), Hour)
        Integer.TryParse(TimeParts(1), Minutes)
        Integer.TryParse(TimeParts(2), Seconds)
        If Hour > 23 Then Hour = 23
        If Minutes > 59 Then Minutes = 59
        If Seconds > 59 Then Seconds = 59
        If Hour < 0 Then Hour = 0
        If Minutes < 0 Then Minutes = 0
        If Seconds < 0 Then Seconds = 0
        TxtControl.Text = $"{Hour.ToString.PadLeft(2, "0")}:{Minutes.ToString.PadLeft(2, "0")}:{Seconds.ToString.PadLeft(2, "0")}"
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

    Private Sub BtnBackupLocation_Click(sender As Object, e As EventArgs) Handles BtnBackupLocation.Click
        If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
            TxtBackupLocation.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub Cbx_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIgnoreNext.CheckedChanged
        CbxIgnoreNext.Text = If(CbxIgnoreNext.Checked, "Sim", "Não")
    End Sub

    Private Sub DbxBackupKeep_Validated(sender As Object, e As EventArgs) Handles DbxBackupKeep.Validated
        If IsNumeric(DbxBackupKeep.Text) Then
            If DbxBackupKeep.Text < 0 Then DbxBackupKeep.Text = 0
        Else
            DbxBackupKeep.Text = 0
        End If
    End Sub

End Class