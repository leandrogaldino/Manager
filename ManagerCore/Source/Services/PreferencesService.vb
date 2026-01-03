Imports System.IO
Imports CoreSuite.Services
Imports Newtonsoft.Json

Public Class PreferencesService
    Private ReadOnly _Key As String
    Public Sub New(CryptoKeyService As CryptoKeyService)
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub
    Public Function Load() As PreferencesModel
        Dim Model As PreferencesModel = Nothing
        Dim PreferencesFile As String = ApplicationPaths.PreferencesFile
        If File.Exists(PreferencesFile) Then
            Dim Json As String = Cryptography.Decrypt(File.ReadAllText(PreferencesFile), _Key)
            Model = JsonConvert.DeserializeObject(Of PreferencesModel)(Json)
        End If
        Return Model
    End Function
    Public Function Save(Model As PreferencesModel) As PreferencesModel
        Dim PreferencesFile As String = ApplicationPaths.PreferencesFile
        Dim Json As String = Cryptography.Encrypt(JsonConvert.SerializeObject(Model, Formatting.Indented), _Key)
        File.WriteAllText(PreferencesFile, Json)
        Return Model
    End Function
End Class
