Imports System.IO
Imports CoreSuite.Services
Imports Newtonsoft.Json

Public Class RemoteDbCredentialsService
    Private ReadOnly _Key As String
    Public Sub New(CryptoKeyService As CryptoKeyService)
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub
    Public Function Load(DatabaseType As RemoteDatabaseType) As RemoteDbCredentialsModel
        Dim Model As RemoteDbCredentialsModel = Nothing
        Dim DbFile As String
        If DatabaseType = RemoteDatabaseType.System Then
            DbFile = ApplicationPaths.RemoteDbCredentialsFile
        Else
            DbFile = ApplicationPaths.LocalDbCredentialsFile
        End If
        If File.Exists(DbFile) Then
            Dim Json As String = Cryptography.Decrypt(File.ReadAllText(DbFile), _Key)
            Model = JsonConvert.DeserializeObject(Of RemoteDbCredentialsModel)(Json)
        End If
        Return Model
    End Function
    Public Function Save(Model As RemoteDbCredentialsModel, DatabaseType As RemoteDatabaseType) As RemoteDbCredentialsModel
        Dim Json As String = Cryptography.Encrypt(JsonConvert.SerializeObject(Model, Formatting.Indented), _Key)
        Dim DbFile As String
        If DatabaseType = RemoteDatabaseType.System Then
            DbFile = ApplicationPaths.RemoteDbCredentialsFile
        Else
            DbFile = ApplicationPaths.LocalDbCredentialsFile
        End If
        File.WriteAllText(DbFile, Json)
        Return Model
    End Function
End Class
