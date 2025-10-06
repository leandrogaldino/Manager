Imports System.IO

Public Class Util
    Public Shared Function HasUpdate(DeployDirectory As String, ManagerDirectory As String) As Boolean
        Dim CurrentVersionStr As String = GetCurrentVersion(ManagerDirectory)
        Dim DeployVersionStr As String = GetDeployVersion(DeployDirectory)

        ' Se não houver nenhuma versão, não há atualização
        If String.IsNullOrEmpty(CurrentVersionStr) AndAlso String.IsNullOrEmpty(DeployVersionStr) Then
            Return False
        End If

        ' Se o deploy tem versão mas o atual não, então há update
        If String.IsNullOrEmpty(CurrentVersionStr) AndAlso Not String.IsNullOrEmpty(DeployVersionStr) Then
            Return True
        End If

        ' Se o atual tem versão mas o deploy não, então não há update
        If Not String.IsNullOrEmpty(CurrentVersionStr) AndAlso String.IsNullOrEmpty(DeployVersionStr) Then
            Return False
        End If

        ' Tenta converter as versões para objeto Version e comparar numericamente
        Try
            Dim currentVer As New Version(CurrentVersionStr)
            Dim deployVer As New Version(DeployVersionStr)
            Return deployVer > currentVer
        Catch ex As Exception
            ' Se algo der errado na conversão, evita crash
            Return False
        End Try
    End Function


    Private Shared Function GetCurrentVersion(ManagerDirectory As String) As String
        Dim ManagerFile As String = Path.Combine(ManagerDirectory, "App", "Manager.exe")

        If File.Exists(ManagerFile) Then
            Dim VersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(ManagerFile)
            Return $"{VersionInfo.FileMajorPart}.{VersionInfo.FileMinorPart}.{VersionInfo.FileBuildPart}"
        Else
            Return String.Empty
        End If
    End Function


    Private Shared Function GetDeployVersion(DeployDirectory As String) As String
        Dim ManagerFile As String = Path.Combine(DeployDirectory, "Manager.exe")

        If File.Exists(ManagerFile) Then
            Dim VersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(ManagerFile)
            Return $"{VersionInfo.FileMajorPart}.{VersionInfo.FileMinorPart}.{VersionInfo.FileBuildPart}"
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function IsSingleInstanced() As Boolean
        Dim processes As Process() = Process.GetProcessesByName("Manager.exe")
        Return processes.Length = 0
    End Function

End Class
