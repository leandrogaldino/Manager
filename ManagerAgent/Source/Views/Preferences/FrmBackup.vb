Imports CoreSuite.Controls
Imports CoreSuite.Infrastructure
Imports ManagerCore

Public Class FrmBackup
    Private ReadOnly _Preferences As PreferencesModel
    Private ReadOnly _PreferencesService As PreferencesService
    Private ReadOnly _BackupDays As UcBackupDays
    Private _Loading As Boolean
    Public Sub New()
        InitializeComponent()
        _Preferences = Locator.GetInstance(Of SessionModel).Preferences
        If _Preferences Is Nothing Then _Preferences = New PreferencesModel()
        _PreferencesService = Locator.GetInstance(Of PreferencesService)
        _BackupDays = New UcBackupDays(ControlContainer)
        InitializeControls()
        FillFormWithModel()
    End Sub
    Private Sub InitializeControls()
        ControlContainer.DropDownControl = _BackupDays
        ControlContainer.HostControl = BtnBackupDays
        AddHandler _BackupDays.ValueChanged, AddressOf BackupDaysValueChanged
    End Sub
    Private Sub FillFormWithModel()
        _Loading = True
        _BackupDays.Monday = _Preferences.Backup.Monday
        _BackupDays.Tuesday = _Preferences.Backup.Tuesday
        _BackupDays.Wednesday = _Preferences.Backup.Wednesday
        _BackupDays.Thursday = _Preferences.Backup.Thursday
        _BackupDays.Friday = _Preferences.Backup.Friday
        _BackupDays.Saturday = _Preferences.Backup.Saturday
        _BackupDays.Sunday = _Preferences.Backup.Sunday
        TbxBackupTime.Time = _Preferences.Backup.Time
        DbxBackupKeep.Text = _Preferences.Backup.Keep
        CbxIgnoreNext.Checked = _Preferences.Backup.IgnoreNext
        TxtBackupLocation.Text = _Preferences.Backup.Location
        _Loading = False
    End Sub

    Private Sub FillModelWithForm()
        _Preferences.Backup.Monday = _BackupDays.Monday
        _Preferences.Backup.Tuesday = _BackupDays.Tuesday
        _Preferences.Backup.Wednesday = _BackupDays.Wednesday
        _Preferences.Backup.Thursday = _BackupDays.Thursday
        _Preferences.Backup.Friday = _BackupDays.Friday
        _Preferences.Backup.Saturday = _BackupDays.Saturday
        _Preferences.Backup.Sunday = _BackupDays.Sunday
        _Preferences.Backup.Time = TbxBackupTime.Time
        _Preferences.Backup.Keep = DbxBackupKeep.Text
        _Preferences.Backup.IgnoreNext = CbxIgnoreNext.Checked
        _Preferences.Backup.Location = TxtBackupLocation.Text
    End Sub

    Private Sub BackupDaysValueChanged(Day As String)
        If Not _Loading Then BtnSave.Enabled = True
        BtnBackupDays.Text = _BackupDays.ToString()
    End Sub

    Private Sub TxtBackupTime_TextChanged(sender As Object, e As EventArgs)
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub DbxBackupKeep_TextChanged(sender As Object, e As EventArgs) Handles DbxBackupKeep.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxIgnoreNext_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIgnoreNext.CheckedChanged
        If Not _Loading Then BtnSave.Enabled = True
        CbxIgnoreNext.Text = If(CbxIgnoreNext.Checked, "Sim", "Não")
    End Sub

    Private Sub TxtBackupLocation_TextChanged(sender As Object, e As EventArgs) Handles TxtBackupLocation.TextChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TbxBackupTime_Leave(sender As Object, e As EventArgs) Handles TbxBackupTime.Leave
        Dim TimeSpan As TimeSpan
        If Not TimeSpan.TryParse(TbxBackupTime.Text, TimeSpan) Then
            TbxBackupTime.Time = New TimeSpan(0, 0, 0)
        End If
    End Sub
    Private Sub DbxBackupKeep_Leave(sender As Object, e As EventArgs) Handles DbxBackupKeep.Leave
        If DbxBackupKeep.DecimalValue < 0 Then
            DbxBackupKeep.Text = 0
        End If
    End Sub
    Private Sub BtnBackupLocation_Click(sender As Object, e As EventArgs) Handles BtnBackupLocation.Click
        FolderBrowserDialog.SelectedPath = _Preferences.Backup.Location
        If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
            TxtBackupLocation.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            Cursor = Cursors.WaitCursor
            FillModelWithForm()
            ManagerCore.Util.AsyncLock(Function() _PreferencesService.SaveAsync(_Preferences))
            DialogResult = DialogResult.OK
        Catch ex As Exception
            CMessageBox.Show("Ocorreu um erro ao salvar.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class