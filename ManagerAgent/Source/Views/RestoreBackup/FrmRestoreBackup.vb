Imports System.IO
Imports CoreSuite.Controls
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services

Public Class FrmRestoreBackup
    Private ReadOnly _Session As SessionModel
    Private ReadOnly _BackupFiles As List(Of BackupFileModel)
    Public Sub New()
        InitializeComponent()
        _Session = Locator.GetInstance(Of SessionModel)()
        _BackupFiles = New List(Of BackupFileModel)
        LoadBackupFiles()
        BindGrid()
    End Sub
    Private Sub LoadBackupFiles()
        _BackupFiles.Clear()
        Dim DirPath = _Session.Preferences.Backup.Location
        Dim Directory As New DirectoryInfo(DirPath)
        If Not Directory.Exists Then
            MessageBox.Show("A pasta de backups não foi encontrada. Defina nas configurações.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        For Each File As FileInfo In Directory.GetFiles().OrderBy(Function(f) f.CreationTime).Reverse()
            If Not FileMerger.IsValidFile(File.FullName) Then
                Continue For
            End If
            Dim Meta As Dictionary(Of String, Object) = FileMerger.GetMetadata(File.FullName)
            _BackupFiles.Add(New BackupFileModel With {
                .Date = Meta("CreationDate"),
                .Size = FormatNumber(Meta("TotalSize") / (1024 * 1024), 2, TriState.True) & " MB",
                .FilePath = File.FullName
            })
        Next File
    End Sub
    Private Sub BindGrid()
        DgvRestore.Rows.Clear()
        DgvRestore.Columns.Clear()
        DgvRestore.Columns.Add("Date", "Data/Hora")
        DgvRestore.Columns.Add("Size", "Tamanho")
        DgvRestore.Columns(0).Width = 150
        DgvRestore.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each File In _BackupFiles
            Dim RowIndex = DgvRestore.Rows.Add(File.Date, File.Size)
            DgvRestore.Rows(RowIndex).Tag = File
        Next File
    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Dim SelectedRow = DgvRestore.CurrentRow
        If SelectedRow Is Nothing Then Return
        Dim SelectedFile As BackupFileModel = TryCast(SelectedRow.Tag, BackupFileModel)
        If SelectedFile Is Nothing Then Return
        Using Frm As New FrmLogin
            If Frm.ShowDialog() <> DialogResult.OK Then Return
        End Using
        If Not ConfirmRestore() Then Return
        If RestoreBackup(SelectedFile) Then
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Function ConfirmRestore() As Boolean
        Return CMessageBox.Show("ATENÇÃO", "Você está prestes a restaurar um backup. Isso irá apagar todos os dados atuais. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes
    End Function
    Private Function RestoreBackup(file As BackupFileModel) As Boolean
        Dim Task As TaskRestoreBackup = Locator.GetInstance(Of TaskBase)(TaskName.BackupRestore)
        Task.NextRun = Now
        Task.IsRunNeeded = True
        Task.BackupFile = file
        Return True
    End Function
    Private Sub DgvRestore_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRestore.SelectionChanged
        BtnRestore.Enabled = (DgvRestore.SelectedRows.Count = 1)
    End Sub
End Class