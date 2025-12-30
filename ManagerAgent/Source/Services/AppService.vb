Imports FirebaseController
Imports ManagerCore
Imports MySqlController
Public Class AppService
    Private ReadOnly _Session As SessionModel
    Private ReadOnly _LocalDB As MySqlService
    Private ReadOnly _LicenseCloud As FirebaseService
    Private ReadOnly _CustomerCloud As FirebaseService
    Private ReadOnly _LicenseCloudService As LicenseCredentialsService
    Public Sub New(Session As SessionModel, LocalDB As MySqlService, LicenseCloud As FirebaseService, CustomerCloud As FirebaseService, LicenseCloudService As LicenseCredentialsService)
        _Session = Session
        _LocalDB = LocalDB
        _LicenseCloud = LicenseCloud
        _CustomerCloud = CustomerCloud
        _LicenseCloudService = LicenseCloudService
    End Sub

    Public Function ValidateBackup() As List(Of String)
        Dim Companies As List(Of CompanyModel) = _Session.Companies
        Dim Validations As New List(Of String)
        For Each Company In Companies
            If String.IsNullOrEmpty(Company.Backup.Location) Then
                Validations.Add($"O diretório de backup da empresa {Company.Register.ShortName} não foi definido.")
            Else
                If Not IO.Directory.Exists(Company.Backup.Location) Then
                    Validations.Add($"O direrório de backup da empresa {Company.Register.ShortName} não existe.")
                End If
            End If
        Next Company
        Return Validations
    End Function
    Public Async Function ValidateLicenseCredentials() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim LicenseCloudModel As LicenseCredentialsModel = _LicenseCloudService.Load()
        Dim ManagerValidations As New List(Of String)
        If LicenseCloudModel Is Nothing Then Return Validations
        If String.IsNullOrEmpty(LicenseCloudModel.ProjectID) Then ManagerValidations.Add($"O nome do banco de dados cloud de licença não foi definido.")
        If String.IsNullOrEmpty(LicenseCloudModel.ApiKey) Then ManagerValidations.Add($"A Api Key do banco de dados cloud de licença não foi definida.")
        If String.IsNullOrEmpty(LicenseCloudModel.StorageBucket) Then ManagerValidations.Add($"O nome do bucket do storage do banco de dados cloud de licença não foi definido.")
        Try
            If Await _LicenseCloud.TestConnection() = False Then
                ManagerValidations.Add($"Banco de dados cloud de licença não conectado, verifique as informações de conexão.")
            End If
        Catch ex As Exception
            ManagerValidations.Add($"Erro ao conectar ou consultar no banco de dados cloud de licença.")
        End Try
        Validations.AddRange(ManagerValidations)

        Return Validations
    End Function
    Public Async Function ValidateCustomerCloud() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim Companies As List(Of CompanyModel) = _Session.Companies
        For Each Company In Companies
            Dim Cloud As CompanyCloudModel = Company.Cloud
            Dim CustomerValidations As New List(Of String)
            If String.IsNullOrEmpty(Cloud.ProjectID) Then CustomerValidations.Add($"O nome do banco de dados cloud do cliete {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Cloud.ApiKey) Then CustomerValidations.Add($"A Api Key do banco de dados cloud do cliente {Company.Register.ShortName} não foi definida.")
            If String.IsNullOrEmpty(Cloud.StorageBucket) Then CustomerValidations.Add($"O nome do Bucket do storage do banco de dados cloud do cliente {Company.Register.ShortName} não foi definido.")
            Try
                If Await _CustomerCloud.TestConnection() = False Then
                    CustomerValidations.Add($"banco de dados cloud do cliete {Company.Register.ShortName} não conectado, verifique as informações de conexão.")
                End If
            Catch ex As Exception
                If CustomerValidations.Count = 0 Then CustomerValidations.Add($"Erro ao conectar ou consultar no banco de dados cloud do cliente: {ex.Message}.")
            End Try
            Validations.AddRange(CustomerValidations)
        Next Company
        Return Validations
    End Function
    Public Async Function ValidateLocalDB() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim Companies As List(Of CompanyModel) = _Session.Companies
        For Each Company In Companies
            Dim Database As CompanyDatabaseModel = Company.Database
            If String.IsNullOrEmpty(Database.Name) Then Validations.Add($"O nome do banco de dados na empresa {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Database.Server) Then Validations.Add($"O servidor do banco de dados na empresa {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Database.Username) Then Validations.Add($"O nome de usuário do banco de dados na empresa {Company.Register.ShortName} não foi definido.")
            If String.IsNullOrEmpty(Database.Password) Then Validations.Add($"A senha do banco de dados na empresa {Company.Register.ShortName} não foi definida.")
            Try
                Await _LocalDB.Request.ExecuteRawQueryAsync("SELECT 1")
            Catch ex As Exception
                If Validations.Count = 0 Then Validations.Add($"Erro ao conectar ou executar consulta no banco de dados local do cliente {Company.Register.ShortName}: {ex.Message}.")
            End Try
        Next Company
        Return Validations
    End Function
End Class
