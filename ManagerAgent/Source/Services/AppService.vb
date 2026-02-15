Imports System.Net
Imports CoreSuite.Helpers
Imports CoreSuite.Infrastructure
Imports CoreSuite.Services
Imports ManagerCore
Public Class AppService
    Private ReadOnly _Session As SessionModel
    Private ReadOnly _LocalDbCredentialsService As LocalDbCredentialsService
    Private ReadOnly _RemoteDbCredentialsService As RemoteDbCredentialsService
    Public Sub New(Session As SessionModel, LocalDbCredentialsService As LocalDbCredentialsService, RemoteDbCredendialsService As RemoteDbCredentialsService)
        _Session = Session
        _LocalDbCredentialsService = LocalDbCredentialsService
        _RemoteDbCredentialsService = RemoteDbCredendialsService
    End Sub
    Public Async Function ValidateLicense() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim LicenseService As LicenseService = Locator.GetInstance(Of LicenseService)
        Try
            Dim Token As String = LicenseService.GetLocalCustomerLinkToken
            _Session.ManagerLicenseResult = Await LicenseService.GetOnlineLicense(Token)
            If Not _Session.ManagerLicenseResult.Success Then
                Validations.Add(EnumHelper.GetEnumDescription(_Session.ManagerLicenseResult.Flag))
            End If
        Catch ex As Exception
            Validations.Add($"Erro ao consultar a licença: {ex.Message}")
        End Try
        Return Validations
    End Function
    Public Async Function ValidateSystemRemoteDb() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim DbCredentials As RemoteDbCredentialsModel = _RemoteDbCredentialsService.Load(RemoteDatabaseType.System)

        'If String.IsNullOrEmpty(DbCredentials.ProjectID) Then Validations.Add($"O nome do banco de dados remoto de licença não foi definido.")
        'If String.IsNullOrEmpty(DbCredentials.ApiKey) Then Validations.Add($"A Api Key do banco de dados remoto de licença não foi definida.")
        'If String.IsNullOrEmpty(DbCredentials.BucketName) Then Validations.Add($"O nome do bucket do storage do banco de dados remoto de licença não foi definido.")
        If DbCredentials Is Nothing Then
            Validations.Add($"As credenciais do banco de dados remoto do sistema não foram definidas.")
        Else
            Try
                Dim Result As DatabaseTestResultModel = Await Util.TestCloudConnectionAsync(DbCredentials)
                If Not Result.Success Then
                    Validations.Add($"Banco de dados remoto de licença não conectado, verifique as informações de conexão.")
                End If
            Catch ex As Exception
                Validations.Add($"Erro ao conectar ou consultar no banco de dados remoto de licença: {ex.Message}")
            End Try
        End If
        Return Validations
    End Function
    Public Async Function ValidateCustomerRemoteDb() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim DbCredentials As RemoteDbCredentialsModel = _RemoteDbCredentialsService.Load(RemoteDatabaseType.Customer)

        'If String.IsNullOrEmpty(DbCredentials.ProjectID) Then Validations.Add($"O nome do banco de dados remoto do cliente não foi definido.")
        'If String.IsNullOrEmpty(DbCredentials.ApiKey) Then Validations.Add($"A Api Key do banco de dados remoto do cliente não foi definida.")
        'If String.IsNullOrEmpty(DbCredentials.BucketName) Then Validations.Add($"O nome do bucket do storage do banco de dados remoto do cliente não foi definido.")
        If DbCredentials Is Nothing Then
            Validations.Add($"As credenciais do banco de dados remoto do cliente não foram definidas.")
        Else
            Try
                Dim Result As DatabaseTestResultModel = Await Util.TestCloudConnectionAsync(DbCredentials)
                If Not Result.Success Then
                    Validations.Add($"Banco de dados remoto do cliente não conectado, verifique as informações de conexão.")
                End If
            Catch ex As Exception
                Validations.Add($"Erro ao conectar ou consultar no banco de dados remoto do cliente.")
            End Try
        End If

        Return Validations
    End Function
    Public Async Function ValidateCompanyLocalDb() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim DbCredentials As LocalDbCredentialsModel = _LocalDbCredentialsService.Load()

        If DbCredentials Is Nothing Then
            Validations.Add($"As credenciais do banco de dados local não foram definidas.")
        Else
            Try
                Dim Result As DatabaseTestResultModel = Await Util.TestLocalDbConnection(New LocalDbCredentialsModel With {
                        .Server = DbCredentials.Server,
                        .Name = DbCredentials.Name,
                        .Username = DbCredentials.Username,
                        .Password = DbCredentials.Password
                    })
                If Not Result.Success Then
                    Validations.Add($"banco de dados local do cliete não conectado, verifique as informações de conexão.")
                End If
            Catch ex As Exception
                If Validations.Count = 0 Then Validations.Add($"Erro ao conectar ou executar consulta no banco de dados local: {ex.Message}.")
            End Try
        End If
        'If String.IsNullOrEmpty(DbCredentials.Name) Then Validations.Add($"O nome do banco de dados local não foi definido.")
        'If String.IsNullOrEmpty(DbCredentials.Server) Then Validations.Add($"O servidor do banco de dados local não foi definido.")
        'If String.IsNullOrEmpty(DbCredentials.Username) Then Validations.Add($"O nome de usuário do banco de dados local não foi definido.")
        'If String.IsNullOrEmpty(DbCredentials.Password) Then Validations.Add($"A senha do banco de dados local não foi definida.")
        Return Validations
    End Function
    Public Function ValidateBackup() As List(Of String)
        Dim Preferences As PreferencesModel = _Session.Preferences
        Dim Validations As New List(Of String)
        If Preferences Is Nothing OrElse String.IsNullOrEmpty(Preferences.Backup.Location) Then
            Validations.Add($"O diretório de backup não foi definido.")
        Else
            If Not IO.Directory.Exists(Preferences.Backup.Location) Then
                Validations.Add($"O direrório de backup não existe.")
            End If
        End If
        Return Validations
    End Function
End Class
