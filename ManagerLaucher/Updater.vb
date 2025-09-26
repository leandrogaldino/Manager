Imports System.IO

Public Class Updater
    Public Delegate Sub UpdateProgressChange(sender As Object, e As ProgressEventArgs)
    Public Event UpdateProgressChanged As UpdateProgressChange
    Private ReadOnly _ServerDirectory As DirectoryInfo
    Private ReadOnly _ManagerDirectory As DirectoryInfo
    Public Sub New(ServerDirectory As DirectoryInfo, ManagerDirectory As DirectoryInfo)
        _ServerDirectory = ServerDirectory
        _ManagerDirectory = ManagerDirectory
    End Sub
    Public Sub Update()
        Dim AllFiles As FileInfo()
        Dim AllDirectories As DirectoryInfo()
        Dim HandledLength As Long = 0
        Dim RelativePath As String
        Dim DestFilePath As String
        Dim DestFileDir As DirectoryInfo
        Dim Args As ProgressEventArgs
        AllFiles = _ManagerDirectory.GetFiles().Where(Function(x) Not x.Name.Equals("ManagerLaucher.exe") And Not x.Name.Equals("AgentLocation.txt")).ToArray
        AllDirectories = _ManagerDirectory.GetDirectories()
        For Each ManagerFile As FileInfo In AllFiles
            ManagerFile.Delete()
        Next ManagerFile
        For Each ManagerDirectory As DirectoryInfo In AllDirectories
            ManagerDirectory.Delete(True)
        Next ManagerDirectory

        Dim AppDirectory As String = Path.Combine(_ManagerDirectory.FullName, "App")

        Directory.CreateDirectory(AppDirectory)
        AllFiles = _ServerDirectory.GetFiles("*", SearchOption.AllDirectories)
        AllDirectories = _ServerDirectory.GetDirectories("*", SearchOption.AllDirectories)
        Args = New ProgressEventArgs With {
                    .TotalSize = AllFiles.Sum(Function(File) File.Length)
                }
        For Each SourceDir As DirectoryInfo In AllDirectories
            RelativePath = SourceDir.FullName.Substring(_ServerDirectory.FullName.Length + 1)
            DestFilePath = Path.Combine(AppDirectory, RelativePath)
            Directory.CreateDirectory(DestFilePath)
        Next SourceDir
        For Each SourceFile As FileInfo In AllFiles
            RelativePath = SourceFile.FullName.Substring(_ServerDirectory.FullName.Length + 1)
            DestFilePath = Path.Combine(AppDirectory, RelativePath)
            DestFileDir = New DirectoryInfo(Path.GetDirectoryName(DestFilePath))
            Directory.CreateDirectory(DestFileDir.FullName)
            File.Copy(SourceFile.FullName, DestFilePath, True)
            HandledLength += SourceFile.Length
            Args.HandledSize = HandledLength
            RaiseEvent UpdateProgressChanged(Me, Args)
        Next SourceFile
    End Sub
    Public Class ProgressEventArgs
        Inherits EventArgs
        Public Property TotalSize As Long
        Public Property HandledSize As Long
        Public ReadOnly Property PercentCompleted As Integer
            Get
                If TotalSize > 0 Then
                    Return HandledSize / TotalSize * 100
                Else
                    Return 0
                End If
            End Get
        End Property
    End Class
End Class
