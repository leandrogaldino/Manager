Imports System.IO
Imports CoreSuite.Services
Imports Newtonsoft.Json

Public Class LocalDbCredentialsService
    Private ReadOnly _Key As String
    Private ReadOnly _DbFile As String
    Public Sub New(CryptoKeyService As CryptoKeyService)
        _Key = CryptoKeyService.ReadCryptoKey()
        _DbFile = ApplicationPaths.LocalDbCredentialsFile
    End Sub
    Public Function Load() As LocalDbCredentialsModel
        Dim Model As LocalDbCredentialsModel = Nothing
        If File.Exists(_DbFile) Then
            Dim Json As String = Cryptography.Decrypt(File.ReadAllText(_DbFile), _Key)
            Model = JsonConvert.DeserializeObject(Of LocalDbCredentialsModel)(Json)
        End If
        Return Model
    End Function
    Public Function Save(Model As LocalDbCredentialsModel) As LocalDbCredentialsModel
        Dim Json As String = Cryptography.Encrypt(JsonConvert.SerializeObject(Model, Formatting.Indented), _Key)
        File.WriteAllText(_DbFile, Json)
        Return Model
    End Function
End Class
