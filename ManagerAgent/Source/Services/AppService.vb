Imports ManagerCore
Public Class AppService
    Private ReadOnly _Session As SessionModel
    Private ReadOnly _LicenseCredentialsService As LicenseCredentialsService
    Public Sub New(Session As SessionModel, LicenseCredendialsService As LicenseCredentialsService)
        _Session = Session
        _LicenseCredentialsService = LicenseCredendialsService
    End Sub

    Public Function ValidateBackup() As List(Of String)
        Dim Preferences As PreferencesModel = _Session.Preferences
        Dim Validations As New List(Of String)
        If String.IsNullOrEmpty(Preferences.Backup.Location) Then
            Validations.Add($"O diretório de backup não foi definido.")
        Else
            If Not IO.Directory.Exists(Preferences.Backup.Location) Then
                Validations.Add($"O direrório de backup não existe.")
            End If
        End If
        Return Validations
    End Function
    Public Async Function ValidateLicenseRemoteDatabase() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim LicenseCredentials As LicenseRemoteDatabaseModel = _LicenseCredentialsService.Load()
        Dim ManagerValidations As New List(Of String)
        If LicenseCredentials Is Nothing Then Return Validations
        If String.IsNullOrEmpty(LicenseCredentials.ProjectID) Then ManagerValidations.Add($"O nome do banco de dados remoto de licença não foi definido.")
        If String.IsNullOrEmpty(LicenseCredentials.ApiKey) Then ManagerValidations.Add($"A Api Key do banco de dados remoto de licença não foi definida.")
        If String.IsNullOrEmpty(LicenseCredentials.BucketName) Then ManagerValidations.Add($"O nome do bucket do storage do banco de dados remoto de licença não foi definido.")
        Try
            Dim Result As DatabaseTestResultModel = Await Util.TestCloudConnectionAsync(LicenseCredentials)

            If Not Result.Success Then
                ManagerValidations.Add($"Banco de dados remoto de licença não conectado, verifique as informações de conexão.")
            End If
        Catch ex As Exception
            ManagerValidations.Add($"Erro ao conectar ou consultar no banco de dados remoto de licença.")
        End Try
        Validations.AddRange(ManagerValidations)
        Return Validations
    End Function
    Public Async Function ValidateCompanyRemoteDatabase() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim Companies As List(Of CompanyModel) = _Session.Companies
        For Each Company In Companies
            Dim Database As CompanyRemoteDatabaseModel = Company.RemoteDatabase
            Dim CompanyValidations As New List(Of String)
            If String.IsNullOrEmpty(Database.ProjectID) Then CompanyValidations.Add($"O nome do banco de dados remoto do cliete {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Database.ApiKey) Then CompanyValidations.Add($"A Api Key do banco de dados remoto do cliente {Company.Register.ShortName} não foi definida.")
            If String.IsNullOrEmpty(Database.BucketName) Then CompanyValidations.Add($"O nome do Bucket do storage do banco de dados remoto do cliente {Company.Register.ShortName} não foi definido.")
            Try
                Dim Result As DatabaseTestResultModel = Await Util.TestCloudConnectionAsync(New LicenseRemoteDatabaseModel() With {
                    .ApiKey = Database.ApiKey,
                    .ProjectID = Database.ProjectID,
                    .BucketName = Database.BucketName,
                    .Username = Database.Username,
                    .Password = Database.Password
                })
                If Not Result.Success Then
                    CompanyValidations.Add($"Banco de dados remoto do cliete {Company.Register.ShortName} não conectado, verifique as informações de conexão.")
                End If
            Catch ex As Exception
                If CompanyValidations.Count = 0 Then CompanyValidations.Add($"Erro ao conectar ou consultar no banco de dados remoto do cliente: {ex.Message}.")
            End Try
            Validations.AddRange(CompanyValidations)
        Next Company
        Return Validations
    End Function
    Public Async Function ValidateCompanyLocalDatabase() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim Companies As List(Of CompanyModel) = _Session.Companies
        For Each Company In Companies
            Dim Database As CompanyLocalDatabaseModel = Company.LocalDatabase
            Dim CompanyValidations As New List(Of String)
            If String.IsNullOrEmpty(Database.Name) Then CompanyValidations.Add($"O nome do banco de dados na empresa {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Database.Server) Then CompanyValidations.Add($"O servidor do banco de dados na empresa {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Database.Username) Then CompanyValidations.Add($"O nome de usuário do banco de dados na empresa {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Database.Password) Then CompanyValidations.Add($"A senha do banco de dados na empresa {Company.Register.ShortName} não foi definida.")
            Try
                Dim Result As DatabaseTestResultModel = Await Util.TestLocalDbConnection(New CompanyLocalDatabaseModel With {
                    .Server = Database.Server,
                    .Name = Database.Name,
                    .Username = Database.Username,
                    .Password = Database.Password
                })
                If Not Result.Success Then
                    CompanyValidations.Add($"banco de dados local do cliete {Company.Register.ShortName} não conectado, verifique as informações de conexão.")
                End If
            Catch ex As Exception
                If Validations.Count = 0 Then Validations.Add($"Erro ao conectar ou executar consulta no banco de dados local do cliente {Company.Register.ShortName}: {ex.Message}.")
            End Try
            Validations.AddRange(CompanyValidations)
        Next Company
        Return Validations
    End Function
End Class
