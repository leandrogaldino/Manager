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

    Public Async Function GetOnlineLicense(CustomerLinkToken As String) As Task(Of LicenseResultModel)
        Dim Result As New LicenseResultModel
        Dim Token As String = CustomerLinkToken

        If String.IsNullOrEmpty(Token) Then
            Result.License = Nothing
            Result.Success = False
            Result.Flag = LicenseMessages.EmptyCustomerLinkToken
            Return Result
        End If


        If Not InternetHelper.IsInternetAvailable Then
            Result.License = Nothing
            Result.Success = False
            Result.Flag = LicenseMessages.NetworkNotAvailable
            Return Result
        End If


        Dim DBResult = Await _Database.Firestore.QueryCompositeAsync("licenses", {New FirestoreFilter("customer_link_token", FirestoreOperator.Equal, Token)}.ToList)
        If DBResult.Count = 1 Then
            Result.License = If(DBResult(0) Is Nothing, Nothing, LicenseModel.FromCloud(DBResult(0)))
        End If


        If Result.License Is Nothing Then
            Result.Success = False
            Result.Flag = LicenseMessages.InvalidCustomerLinkToken
            Return Result
        End If


        If Result.License.ExpirationDate < Today Then
            Result.Success = True
            Result.Flag = LicenseMessages.Expired
            Return Result
        End If

        Return Result
    End Function

    Public Async Function GetLocalLicense() As Task(Of LicenseResultModel)
        Dim Result As New LicenseResultModel
        Dim Json As String
        If File.Exists(ApplicationPaths.LicenseFile) Then
            Json = File.ReadAllText(ApplicationPaths.LicenseFile)
            Json = Cryptography.Decrypt(Json, _Key)
            Result.License = LicenseModel.FromJson(Json)
            If Result.License.ExpirationDate < Today Then
                Dim OnlineLicense As LicenseResultModel = Await GetOnlineLicense(Result.License.CustomerLinkToken)
                If OnlineLicense.Flag <> LicenseMessages.Expired Then
                    Result = OnlineLicense
                End If
            End If
        End If
        Return Result
    End Function
    Public Function GetLocalCustomerLinkToken() As String
        Dim Json As String
        Dim LicenseKey As String
        If File.Exists(ApplicationPaths.LicenseFile) Then
            Json = File.ReadAllText(ApplicationPaths.LicenseFile)
            Json = Cryptography.Decrypt(Json, _Key)
            Dim Model = LicenseModel.FromJson(Json)
            LicenseKey = Model.CustomerLinkToken
            Return LicenseKey
        Else
            Return Nothing
        End If
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

    Public Async Function UpdateManagerAgentPassword(License As LicenseModel, NewPassword As String) As Task(Of LicenseModel)
        Dim Data As Dictionary(Of String, Object) = License.ToCloud
        Data("manager_agent_password") = NewPassword
        Await _Database.Firestore.SaveDocumentAsync("licenses", License.CustomerDocument.Replace("/", Nothing).Replace("-", Nothing).Replace(".", Nothing), Data)
        License.ManagerAgentPassword = NewPassword
        Return License
    End Function
End Class
