Imports System.IO

Public Class FrmRestoreBackup
    Private _ViewModel As RestoreBackupViewModel
    Public Sub New()
        InitializeComponent()
        _ViewModel = New RestoreBackupViewModel()
        BindData()
    End Sub

    Private Sub BindData()
        DgvRestore.Columns.Clear()
        DgvRestore.Columns.Add("Date", "Data/Hora")
        DgvRestore.Columns.Add("Size", "Tamanho")
        DgvRestore.Columns(0).Width = 150
        DgvRestore.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each File In _ViewModel.BackupFiles
            Dim rowIndex As Integer = DgvRestore.Rows.Add(File.Date, File.Size)
            DgvRestore.Rows(rowIndex).Tag = File
        Next
    End Sub

    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Dim SelectedRow As DataGridViewRow = DgvRestore.CurrentRow
        If SelectedRow IsNot Nothing Then
            Dim SelectedFile As BackupFileModel = CType(SelectedRow.Tag, BackupFileModel)
            Using Frm As New FrmLogin
                If Frm.ShowDialog = DialogResult.OK Then
                    If _ViewModel.RestoreBackup(SelectedFile) Then

                        DialogResult = DialogResult.OK
                    End If

                End If
            End Using

        End If
    End Sub

    Private Sub DgvRestore_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRestore.SelectionChanged
        If DgvRestore.SelectedRows.Count = 1 Then
            BtnRestore.Enabled = True
        Else
            BtnRestore.Enabled = False
        End If
    End Sub
End Class
