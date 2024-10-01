Imports ControlLibrary
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.IO

Public Class RestoreBackupViewModel
    Private ReadOnly _SessionModel As SessionModel
    Public Property BackupFiles As ObservableCollection(Of BackupFileModel)
    Public Sub New()
        _SessionModel = Locator.GetInstance(Of SessionModel)
        BackupFiles = New ObservableCollection(Of BackupFileModel)()
        LoadBackupFiles()
    End Sub
    Private Sub LoadBackupFiles()
        BackupFiles.Clear()
        Dim Dir As New DirectoryInfo(_SessionModel.ManagerSetting.Backup.Location)
        If Dir.Exists Then
            For Each File As FileInfo In Dir.GetFiles.Reverse().Where(Function(x) x.Extension = ".bkp").OrderBy(Function(y) y.CreationTime)
                BackupFiles.Add(New BackupFileModel With {
                    .Date = File.Name.Replace("Backup ", "").Replace(".bkp", "").Replace("-", "/").Replace(".", ":"),
                    .Size = FormatNumber(File.Length / (1024 * 1024), 2, TriState.True) & " MB",
                    .FilePath = File.FullName
                })
            Next
        Else
            MessageBox.Show("A pasta de backups não foi encontrada. Defina nas configurações.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Public Function RestoreBackup(SelectedFile As BackupFileModel) As Boolean
        If SelectedFile IsNot Nothing Then
            Dim Task As TaskRestoreBackup = Locator.GetInstance(Of TaskBase)(TaskName.BackupRestore)
            Task.NextRun = Now
            Task.IsRunNeeded = True
            Task.BackupFile = SelectedFile
            If CMessageBox.Show("ATENÇÂO", "Você está prestes a restaurar um backup. Isso irá apagar todos os arquivos e dados atuais, substituindo-os pelos do arquivo de backup. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
