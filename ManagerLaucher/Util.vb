Imports System.IO

Public Class Util
    Public Shared Function HasUpdate(DeployDirectory As String, ManagerDirectory As String) As Boolean
        Dim CurrentVersion As String = GetCurrentVersion(ManagerDirectory)
        Dim DeployVersion As String = GetDeployVersion(DeployDirectory)
        If String.IsNullOrEmpty(CurrentVersion) And String.IsNullOrEmpty(DeployVersion) Then
            Return False
        ElseIf Not String.IsNullOrEmpty(CurrentVersion) And String.IsNullOrEmpty(DeployVersion) Then
            Return False
        ElseIf String.IsNullOrEmpty(CurrentVersion) And Not String.IsNullOrEmpty(DeployVersion) Then
            Return True
        Else
            Return CurrentVersion.CompareTo(DeployVersion) < 0
        End If
    End Function

    Private Shared Function GetCurrentVersion(ManagerDirectory As String) As String
        Dim ManagerFile As String = Path.Combine(ManagerDirectory, "App", "Manager.exe")
        Dim Assembly As Reflection.Assembly
        Dim VersionInfo As FileVersionInfo
        Dim Version As String
        If File.Exists(ManagerFile) Then
            Assembly = Reflection.Assembly.GetExecutingAssembly()
            VersionInfo = FileVersionInfo.GetVersionInfo(ManagerFile)
            Version = $"{VersionInfo.FileMajorPart}.{VersionInfo.FileMinorPart}"
            Return Version
        Else
            Return String.Empty
        End If
    End Function
    Private Shared Function GetDeployVersion(DeployDirectory As String) As String
        Dim ManagerFile As String = Path.Combine(DeployDirectory, "Manager.exe")
        Dim Assembly As Reflection.Assembly
        Dim VersionInfo As FileVersionInfo
        Dim Version As String
        If File.Exists(ManagerFile) Then
            Assembly = Reflection.Assembly.GetExecutingAssembly()
            VersionInfo = FileVersionInfo.GetVersionInfo(ManagerFile)
            Version = $"{VersionInfo.FileMajorPart}.{VersionInfo.FileMinorPart}"
            Return Version
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function IsSingleInstanced() As Boolean
        Dim processes As Process() = Process.GetProcessesByName("Manager.exe")
        Return processes.Length = 0
    End Function

End Class
