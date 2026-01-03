Imports System.Collections.ObjectModel
Imports CoreSuite.Infrastructure
Imports CoreSuite.Controls
Imports CoreSuite.Services
Imports System.IO

Public Class RestoreBackupViewModel
    Private ReadOnly _Session As SessionModel
    Public Property BackupFiles As ObservableCollection(Of BackupFileModel)
    Public Sub New()
        _Session = Locator.GetInstance(Of SessionModel)
        BackupFiles = New ObservableCollection(Of BackupFileModel)()
        LoadBackupFiles()
    End Sub
    Private Sub LoadBackupFiles()
        BackupFiles.Clear()

        Dim Directory As New DirectoryInfo(_Session.Preferences.Backup.Location)
        If Directory.Exists Then
            'ler metadados aqui
            For Each File As FileInfo In Directory.GetFiles.Reverse().OrderBy(Function(y) y.CreationTime)
                If FileMerger.IsValidFile(File.FullName) Then
                    Dim MetaData As Dictionary(Of String, Object) = FileMerger.GetMetadata(File.FullName)
                    BackupFiles.Add(New BackupFileModel With {
                        .Date = MetaData("CreationDate"),
                        .Size = FormatNumber(MetaData("TotalSize") / (1024 * 1024), 2, TriState.True) & " MB",
                        .FilePath = File.FullName
                    })
                End If
            Next File
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
