Imports System.IO
Imports CoreSuite.Infrastructure
Imports ManagerCore

Public Class Validation
    Public Shared Function ValidateLicense(Credentials As RemoteDbCredentialsModel) As String
        Dim CredService As RemoteDbCredentialsService = Locator.GetInstance(Of RemoteDbCredentialsService)
        Dim LicenseService As LicenseService = Locator.GetInstance(Of LicenseService)
        Dim s = New CoreSuite.Services.FirebaseService(Credentials.ApiKey, Credentials.ProjectID, Credentials.BucketName)
        Try
            'Testa usuário e senha
            ManagerCore.Util.AsyncLock(Function() s.Auth.LoginAsync(Credentials.Username & "@nexor.com", Credentials.Password))
        Catch ex As Exception
            Return "Erro no login, verifique o usuário e senha informados ."
        End Try
        Try
            'Testa a conexao com o banco
            ManagerCore.Util.AsyncLock(Function() s.Firestore.SaveDocumentAsync("Test", "Test", New Dictionary(Of String, Object) From {{"Test", "Test"}}))
            ManagerCore.Util.AsyncLock(Function() s.Firestore.DeleteDocumentAsync("Test", "Test"))
        Catch ex As Exception
            Return "Erro na conexão com a base de dados de licenciamento, verifique os dados informados."
        End Try
        Try        'Testa a storage
            Dim Filename = Path.Combine(ApplicationPaths.AgentTempDirectory, ".test")
            File.WriteAllText(Filename, "Storage Test")
            ManagerCore.Util.AsyncLock(Function() (s.Storage.UploadFile(Filename, "test/.test")))
            File.Delete(Filename)
            ManagerCore.Util.AsyncLock(Function() s.Storage.DeleteFileAsync("test/.test"))
        Catch ex As Exception
            Return "Erro na conexão com a storage de licenciamento, verifique os dados informados."
        End Try
        If s.Auth.IsLoggedIn Then s.Auth.Logout()
        Return Nothing
    End Function
End Class
