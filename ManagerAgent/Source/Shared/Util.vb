Imports System.IO
Imports ControlLibrary
Imports ManagerCore
Public Class Util
    Public Shared Function GetBackupFiles(Company As CompanyModel) As List(Of FileInfo)
        Dim SessionModel As SessionModel = Locator.GetInstance(Of SessionModel)
        Dim BackupDirectory As New DirectoryInfo(Company.Backup.Location)
        If BackupDirectory.Exists Then
            Return BackupDirectory.GetFiles().OrderBy(Function(x) x.CreationTime).Where(Function(y) FileMerge.IsValidFile(y.FullName)).ToList
        Else
            Return New List(Of FileInfo)
        End If
    End Function
End Class
