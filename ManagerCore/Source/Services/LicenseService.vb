Imports System.IO
Imports System.Text
Imports CoreSuite.Services
Imports CoreSuite.Helpers

Public Class LicenseService
    Private ReadOnly _Key As String
    Private ReadOnly _Database As FirebaseService
    Public Sub New(Database As FirebaseService, CryptoKeyService As CryptoKeyService)
        _Database = Database
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub
    Public Function GetLocalLicenseKey() As String
        Dim Json As String
        Dim LicenseKey As String
        If File.Exists(ApplicationPaths.LicenseFile) Then
            Json = File.ReadAllText(ApplicationPaths.LicenseFile)
            Json = Cryptography.Decrypt(Json, _Key)
            Dim Model = LicenseModel.FromJson(Json)
            LicenseKey = Model.LicenseKey
            Return LicenseKey
        Else
            Return Nothing
        End If
    End Function

    Public Function GetLocalLicenseToken() As String
        Dim Json As String
        Dim LicenseToken As String
        If File.Exists(ApplicationPaths.LicenseFile) Then
            Json = File.ReadAllText(ApplicationPaths.LicenseFile)
            Json = Cryptography.Decrypt(Json, _Key)
            Dim Model = LicenseModel.FromJson(Json)
            LicenseToken = Model.LicenseToken
            Return LicenseToken
        Else
            Return Nothing
        End If
    End Function
    Public Function GetLocalLicense() As LicenseResultModel
        Dim Result As New LicenseResultModel
        Dim XmlStr As String
        If File.Exists(ApplicationPaths.LicenseFile) Then
            XmlStr = File.ReadAllText(ApplicationPaths.LicenseFile)
            XmlStr = Cryptography.Decrypt(XmlStr, _Key)
            Result.License = LicenseModel.FromJson(XmlStr)
            If (Not String.IsNullOrEmpty(Result.License.LicenseKey)) Then
                If Result.License.LastOnlineValidation.AddDays(1) >= Today Then
                    Result.Success = True
                    Result.Flag = LicenseMessages.None
                Else
                    Result.License = Nothing
                    Result.Success = False
                    Result.Flag = LicenseMessages.OutdatedLocalLicenseKey
                End If
            Else
                Result.License = Nothing
                Result.Success = False
                Result.Flag = LicenseMessages.MissingProductKey
            End If
        Else
            Result.License = Nothing
            Result.Success = False
            Result.Flag = LicenseMessages.LicenseFileNotFound
        End If
        Return Result
    End Function
    Public Async Function IsValidLicenseKey(LicenseKey As String) As Task(Of Boolean)
        Dim Key As String = If(String.IsNullOrEmpty(LicenseKey), String.Empty, LicenseKey)
        Dim Result = Await _Database.Firestore.QueryCompositeAsync("licenses", {New FirestoreFilter("license_key", FirestoreOperator.Equal, Key)}.ToList)
        If Result IsNot Nothing AndAlso Result.Count = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Async Function GetOnlineLicense(Optional LicenseKey As String = Nothing) As Task(Of LicenseResultModel)
        Dim Result As New LicenseResultModel
        Dim Key As String = If(String.IsNullOrEmpty(LicenseKey), GetLocalLicenseKey(), LicenseKey)
        Dim Token As String = GetLocalLicenseToken()
        If Not File.Exists(ApplicationPaths.RemoteDbCredentialsFile) Then
            Result.Flag = LicenseMessages.MissingCredentials
            Return Result
        End If
        ' Verifica se o arquivo de licença existe
        If Not File.Exists(ApplicationPaths.LicenseFile) Then
            Result.Flag = LicenseMessages.LicenseFileNotFound
            Return Result
        End If
        ' Verifica se a chave de licença foi fornecida
        If String.IsNullOrEmpty(Key) Then
            Result.Flag = LicenseMessages.MissingProductKey
            Return Result
        End If
        ' Verifica se há conexão com a internet
        If Not InternetHelper.IsInternetAvailable Then
            Result.Flag = LicenseMessages.NetworkNotAvailable
            Return Result
        End If
        ' Realiza a consulta ao banco de dados
        Dim DBResult = Await _Database.Firestore.QueryCompositeAsync("licenses", {New FirestoreFilter("license_key", FirestoreOperator.Equal, Key)}.ToList)
        If DBResult.Count = 1 Then
            Result.License = If(DBResult(0) Is Nothing, Nothing, LicenseModel.FromCloud(DBResult(0)))
        ElseIf DBResult.Count > 1 Then
            Result.Flag = LicenseMessages.DuplicateProductKey
            Return Result
        End If
        ' Verifica se a licença foi encontrada
        If Result.License Is Nothing Then
            Result.Flag = LicenseMessages.InvalidProductKey
            Return Result
        End If
        ' Atualiza a última validação online
        Result.License.LastOnlineValidation = Now
        Result.Success = True
        ' Verifica se o token da licença é válido
        If Not String.IsNullOrEmpty(Result.License.LicenseToken) AndAlso Result.License.LicenseToken <> Token Then
            Result.License = Nothing
            Result.Success = False
            Result.Flag = LicenseMessages.ProductKeyAlreadyActivatedOnAnother
            Return Result
        End If
        ' Atualiza o token da licença se necessário
        If String.IsNullOrEmpty(Token) AndAlso String.IsNullOrEmpty(Token) AndAlso String.IsNullOrEmpty(Result.License.LicenseToken) Then
            Dim NewToken As String = TextHelper.GetRandomString(1, 256, Nothing, {CharFilter.Alphanumeric, CharFilter.Numeric, CharFilter.SpecialCharacters}.ToList).Replace("=", String.Empty).Replace("+", String.Empty).Replace("/", String.Empty)
            Result.License = Await UpdateLicenseToken(Result.License, NewToken)
            Await SaveLocalLicense(Result.License)
            Return Result
        End If
        ' Verifica se a licença expirou
        If Result.License.ExpirationDate < Today Then
            Result.License = Nothing
            Result.Success = False
            Result.Flag = LicenseMessages.ExpiredProductKey
            Return Result
        End If
        Await SaveLocalLicense(Result.License)
        Return Result
    End Function
    Public Async Function SaveLocalLicense(License As LicenseModel) As Task(Of LicenseModel)
        Dim Json As String = License.ToJson()
        Json = Cryptography.Encrypt(Json, _Key)
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(Json)
        Using fs As New FileStream(ApplicationPaths.LicenseFile, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize:=4096, useAsync:=True)
            Await fs.WriteAsync(bytes, 0, bytes.Length)
            Await fs.FlushAsync()
        End Using
        Return License
    End Function
    Public Async Function UpdateLicenseToken(License As LicenseModel, NewToken As String) As Task(Of LicenseModel)
        Dim Data As Dictionary(Of String, Object) = License.ToCloud
        Data("license_token") = NewToken
        Await _Database.Firestore.SaveDocumentAsync("licenses", License.CustomerDocument, Data)
        License.LicenseToken = NewToken
        Return License
    End Function
    Public Async Function UpdateManagerAgentPassword(License As LicenseModel, NewPassword As String) As Task(Of LicenseModel)
        Dim Data As Dictionary(Of String, Object) = License.ToCloud
        Data("manager_agent_password") = NewPassword
        Await _Database.Firestore.SaveDocumentAsync("licenses", License.CustomerDocument, Data)
        License.ManagerAgentPassword = NewPassword
        Return License
    End Function
End Class
