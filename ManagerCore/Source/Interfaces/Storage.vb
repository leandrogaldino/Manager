Imports System.Threading
Public MustInherit Class Storage
    MustOverride Sub Initialize(Settings As SettingCloudStorageModel)
    MustOverride Async Function TestConnection() As Task
    MustOverride Async Function DownloadFile(FileName As String, Optional Progress As IProgress(Of Integer) = Nothing, Optional CancellationToken As CancellationToken = Nothing) As Task(Of Byte())
    MustOverride Async Function UploadFile(FileName As String, ContentType As String, FileData As Byte(), Optional Progress As IProgress(Of Integer) = Nothing, Optional CancellationToken As CancellationToken = Nothing) As Task
    MustOverride Async Function DeleteFile(FileName As String, Optional CancellationToken As CancellationToken = Nothing) As Task
End Class
