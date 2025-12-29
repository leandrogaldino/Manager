Imports System.IO
Imports ControlLibrary
Imports Newtonsoft.Json

Public Class LicenseCloudService
    Private ReadOnly _Key As String
    Public Sub New(CryptoKeyService As CryptoKeyService)
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub
    Public Function Load() As LicenseCloudModel
        Dim Model As LicenseCloudModel = Nothing
        Dim LicenseCredentialsFile As String = ApplicationPaths.LicenseCredentialsFile
        If File.Exists(LicenseCredentialsFile) Then
            Dim Json As String = Cryptography.Decrypt(File.ReadAllText(LicenseCredentialsFile), _Key)
            Model = JsonConvert.DeserializeObject(Of LicenseCloudModel)(Json)
        End If
        Return Model
    End Function
    Public Function Save(Model As LicenseCloudModel) As LicenseCloudModel
        Dim LicenseCredentialsFile As String = ApplicationPaths.LicenseCredentialsFile
        Dim Json As String = Cryptography.Encrypt(JsonConvert.SerializeObject(Model, Formatting.Indented), _Key)
        File.WriteAllText(LicenseCredentialsFile, Json)
        Return Model
    End Function
End Class
