Imports System.IO
Imports ControlLibrary
Public Class Util
    Public Shared Function IsBackupFile(BackupFile As FileInfo) As Boolean
        Dim SessionModel As SessionModel = Locator.GetInstance(Of SessionModel)
        If Not IsZipFile(BackupFile) Then
            Return False
        End If
        'Using ZipFile As ZipFile = ZipFile.Read(BackupFile.FullName)
        'ZipFile.Password = SessionModel.ZipPassword
        'Try
        'ZipFile.ExtractSelectedEntries("", "Database\Database.sql")
        Return True
        'Catch ex As Exception
        'Return False
        'End Try
        'End Using
    End Function
    Public Shared Function GetBackupFiles() As List(Of FileInfo)
        Dim SessionModel As SessionModel = Locator.GetInstance(Of SessionModel)
        Dim BackupDirectory As New DirectoryInfo(SessionModel.ManagerSetting.Backup.Location)
        If Directory.Exists(SessionModel.ManagerSetting.Backup.Location) Then
            Return BackupDirectory.GetFiles().OrderBy(Function(x) x.CreationTime).Where(Function(y) IsBackupFile(y)).ToList
        Else
            Return New List(Of FileInfo)
        End If
    End Function
    Private Shared Function IsZipFile(file As FileInfo) As Boolean
        Try
            'Using zip As ZipFile = ZipFile.Read(file.FullName)
            Return True
            'End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function HasUpdate(Dir As String) As Boolean
        Dim DeployDirectory As New DirectoryInfo(Dir)
        If DeployDirectory.GetFiles("*", SearchOption.AllDirectories).Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function DictionariesToDataTable(Data As List(Of Dictionary(Of String, Object))) As DataTable
        Dim Table As New DataTable()
        If Data Is Nothing OrElse Data.Count = 0 Then
            Return Table
        End If
        For Each key As String In Data(0).Keys
            Table.Columns.Add(key)
        Next
        For Each dict As Dictionary(Of String, Object) In Data
            Dim row As DataRow = Table.NewRow()
            For Each key As String In dict.Keys
                row(key) = dict(key)
            Next
            Table.Rows.Add(row)
        Next
        Return Table
    End Function
End Class
