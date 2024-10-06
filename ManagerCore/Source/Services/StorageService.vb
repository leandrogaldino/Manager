Imports Google.Cloud.Storage.V1
Imports System.IO
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Download
Imports System.Threading
Imports Google.Apis.Upload
Public Class StorageService
    Inherits Storage
    Private _BucketName As String
    Private _JsonCredentials As String



    Public Overrides Sub Initialize(Settings As SettingCloudStorageModel)
        _BucketName = Settings.BucketName
        _JsonCredentials = Settings.JsonCredentials
    End Sub


    Private Async Function GetClient() As Task(Of StorageClient)
        Dim Credentials As GoogleCredential = GoogleCredential.FromJson(_JsonCredentials)
        Return Await New StorageClientBuilder With {
            .GoogleCredential = Credentials
        }.BuildAsync()
    End Function

    Public Overrides Async Function TestConnection() As Task
        Using StorageClient As StorageClient = Await GetClient()
            Dim Objects = Await StorageClient.ListObjectsAsync(_BucketName).ToListAsync()
            If Objects Is Nothing Then Throw New Exception("Falha ao obter dados do armazenamento")
        End Using
    End Function
    Public Overrides Async Function DownloadFile(FileName As String, Optional Progress As IProgress(Of Integer) = Nothing, Optional CancellationToken As CancellationToken = Nothing) As Task(Of Byte())
        Using StorageClient As StorageClient = Await GetClient()
            Using MemoryStream As New MemoryStream()
                Dim ObjectMetadata = Await StorageClient.GetObjectAsync(_BucketName, FileName)
                Dim TotalBytes As Long = ObjectMetadata.Size.GetValueOrDefault()
                Dim DownloadProgress As Progress(Of IDownloadProgress) = Nothing
                If Progress IsNot Nothing Then
                    DownloadProgress = New Progress(Of IDownloadProgress)(Sub(p)
                                                                              Dim BytesDownloaded As Long = p.BytesDownloaded
                                                                              Dim PercentComplete As Integer = CInt((BytesDownloaded / TotalBytes) * 100)
                                                                              Progress.Report(PercentComplete)
                                                                          End Sub)
                End If
                Await StorageClient.DownloadObjectAsync(_BucketName, FileName, MemoryStream, progress:=DownloadProgress, cancellationToken:=CancellationToken)
                Dim DownloadedData As Byte() = MemoryStream.ToArray()
                Return DownloadedData
            End Using
        End Using
    End Function

    Public Overrides Async Function UploadFile(FileName As String, ContentType As String, FileData As Byte(), Optional Progress As IProgress(Of Integer) = Nothing, Optional CancellationToken As CancellationToken = Nothing) As Task
        Using StorageClient As StorageClient = Await GetClient()
            Dim UploadProgress As Progress(Of IUploadProgress) = Nothing
            Dim TotalBytes As Long = New FileInfo(FileName).Length
            If Progress IsNot Nothing Then
                UploadProgress = New Progress(Of IUploadProgress)(Sub(p)
                                                                      Dim BytesDownloaded As Long = p.BytesSent
                                                                      Dim PercentComplete As Integer = CInt((BytesDownloaded / TotalBytes) * 100)
                                                                      Progress.Report(PercentComplete)
                                                                  End Sub)
            End If
            Using MemoryStream As New MemoryStream(FileData)
                Await StorageClient.UploadObjectAsync(_BucketName, FileName, ContentType, MemoryStream, progress:=UploadProgress, cancellationToken:=CancellationToken)
            End Using
        End Using
    End Function
    Public Overrides Async Function DeleteFile(FileName As String, Optional CancellationToken As CancellationToken = Nothing) As Task
        Using StorageClient As StorageClient = Await GetClient()
            Await StorageClient.DeleteObjectAsync(_BucketName, FileName, cancellationToken:=CancellationToken)
        End Using
    End Function
End Class

