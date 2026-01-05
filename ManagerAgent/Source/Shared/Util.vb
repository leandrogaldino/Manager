Imports System.IO
Imports CoreSuite.Helpers
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports ManagerCore
Public Class Util
    Public Shared Function GetBackupFiles() As List(Of FileInfo)
        Dim Session As SessionModel = Locator.GetInstance(Of SessionModel)
        Dim BackupDirectory As New DirectoryInfo(Session.Preferences.Backup.Location)
        If BackupDirectory.Exists Then
            Return BackupDirectory.GetFiles().OrderBy(Function(x) x.CreationTime).Where(Function(y) FileMerger.IsValidFile(y.FullName)).ToList
        Else
            Return New List(Of FileInfo)
        End If
    End Function
    Public Shared Async Function TestCloudConnectionAsync(Credentials As RemoteDbCredentialsModel) As Task(Of DatabaseTestResultModel)
        Dim Result As New DatabaseTestResultModel()
        Dim Name As String = "connectiontest"
        Dim TestDb As New FirebaseService(Credentials.ApiKey, Credentials.ProjectID, Credentials.BucketName)
        Try
            Await TestDb.Auth.LoginAsync($"{Credentials.Username}@nexor.com", Credentials.Password)
            Dim DocumentId As String = TextHelper.GetRandomFileName()
            Await TestDb.Firestore.SaveDocumentAsync(Name, DocumentId, New Dictionary(Of String, Object))
            Await TestDb.Firestore.DeleteDocumentAsync(Name, DocumentId)
            Dim TempFile = Path.Combine(ApplicationPaths.AgentTempDirectory, Name)
            File.WriteAllBytes(TempFile, Array.Empty(Of Byte))
            Await TestDb.Storage.UploadFile(TempFile, Name)
            Await TestDb.Storage.DeleteFileAsync(Name)
            Result.Success = True
            Return Result
        Catch ex As Exception
            Result.Success = False
            Result.ErrorMessage = "Não foi possível conectar ao banco de dados remoto com as credenciais informadas."
            Result.Exception = ex
            Return Result
        End Try
    End Function
    Public Shared Async Function TestLocalDbConnection(Credentials As LocalDbCredentialsModel) As Task(Of DatabaseTestResultModel)
        Dim Result As New DatabaseTestResultModel()
        Dim TestDb As New MySqlService(Credentials.Server, Credentials.Name, Credentials.Username, Credentials.Password)
        Try
            Await TestDb.Request.ExecuteRawQueryAsync("SELECT 1")
            Result.Success = True
            Return Result
        Catch ex As Exception
            Result.Success = False
            Result.ErrorMessage = "Não foi possível conectar ao banco de dados local com as credenciais informadas."
            Result.Exception = ex
            Return Result
        End Try
    End Function
End Class
