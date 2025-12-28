Imports System.IO
Imports ControlLibrary
Imports Newtonsoft.Json
Public Class CompanyService
    Private _Key As String
    Public Sub New(CryptoKeyService As CryptoKeyService)
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub
    Public Function Load(CompanyDocument As String) As CompanyModel
        Dim Model As CompanyModel
        Dim CompanyFile As String = Path.Combine(ApplicationPaths.CompanyDirectory, $".{CompanyDocument}")
        If File.Exists(CompanyFile) Then
            Dim Json As String = Cryptography.Decrypt(File.ReadAllText(CompanyFile), _Key)
            Model = JsonConvert.DeserializeObject(Of CompanyModel)(Json)
            Return Model
        Else
            Throw New Exception("Company File Not Found, Run ManagerAgent to create.")
        End If
    End Function
    Public Function Save(Model As CompanyModel) As CompanyModel
        Dim CompanyFile As String = Path.Combine(ApplicationPaths.CompanyDirectory, $".{Model.Register.Document.Replace(".", String.Empty).Replace("/", String.Empty).Replace("-", String.Empty)}")
        Dim Json As String = Cryptography.Encrypt(JsonConvert.SerializeObject(Model, Formatting.Indented), _Key)
        File.WriteAllText(CompanyFile, Json)
        Return Model
    End Function

    Public Function LoadAll() As List(Of CompanyModel)
        Dim Companies As New List(Of CompanyModel)
        Dim CompanyDirectory As New DirectoryInfo(ApplicationPaths.CompanyDirectory)
        For Each CompanyFile As FileInfo In CompanyDirectory.GetFiles(".*")
            Dim Json As String = Cryptography.Decrypt(File.ReadAllText(CompanyFile.FullName), _Key)
            Dim Model As CompanyModel = JsonConvert.DeserializeObject(Of CompanyModel)(Json)
            Companies.Add(Model)
        Next
        Return Companies
    End Function
End Class
