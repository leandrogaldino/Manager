Imports ManagerCore
Public Class AppService
    Private ReadOnly _Session As SessionModel
    Private ReadOnly _LocalDB As LocalDB
    Private ReadOnly _LicenseCloud As RemoteDB
    Private ReadOnly _CustomerCloud As RemoteDB
    Private ReadOnly _CustomerStorage As Storage
    Private ReadOnly _LicenseCloudService As LicenseCloudService
    Public Sub New(Session As SessionModel, LocalDB As LocalDB, LicenseCloud As RemoteDB, CustomerCloud As RemoteDB, CustomerStorage As Storage, LicenseCloudService As LicenseCloudService)
        _Session = Session
        _LocalDB = LocalDB
        _LicenseCloud = LicenseCloud
        _CustomerCloud = CustomerCloud
        _CustomerStorage = CustomerStorage
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
    Public Async Function ValidateLicenseCloud() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim LicenseCloudModel As LicenseCloudModel = _LicenseCloudService.Load()
        Dim ManagerValidations As New List(Of String)

        If LicenseCloudModel Is Nothing Then Return Validations


        If String.IsNullOrEmpty(LicenseCloudModel.ProjectID) Then ManagerValidations.Add($"O nome do banco de dados cloud de licença não foi definido.")
        If String.IsNullOrEmpty(LicenseCloudModel.JsonCredentials) Then ManagerValidations.Add($"As credenciais do banco de dados cloud de licença não foram definidas.")
        Try
            Await _LicenseCloud.TestConnection()
        Catch ex As Exception
            ManagerValidations.Add($"Erro ao conectar ou consultar no banco de dados cloud de licença;")
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
            If String.IsNullOrEmpty(Cloud.JsonCredentials) Then CustomerValidations.Add($"As credenciais do banco de dados cloud do cliente {Company.Register.ShortName} não foram definidos.")
            Try
                Await _CustomerCloud.TestConnection()
            Catch ex As Exception
                If CustomerValidations.Count = 0 Then CustomerValidations.Add($"Erro ao conectar ou consultar no banco de dados cloud do cliente: {ex.Message}.")
            End Try
            Validations.AddRange(CustomerValidations)
        Next Company
        Return Validations
    End Function
    Public Async Function ValidateStorage() As Task(Of List(Of String))
        Dim Validations As New List(Of String)
        Dim Companies As List(Of CompanyModel) = _Session.Companies
        For Each Company In Companies
            Dim Storage As CompanyCloudModel = Company.Cloud
            If String.IsNullOrEmpty(Storage.BucketName) Then Validations.Add($"O nome do armazenamento não foi definido na empresa {Company.Register.ShortName}.")
            If String.IsNullOrEmpty(Storage.JsonCredentials) Then Validations.Add($"As credenciais do armazenamento não foram definidos na empresa {Company.Register.ShortName}.")
            Try
                Await _CustomerStorage.TestConnection()
            Catch ex As Exception
                If Validations.Count = 0 Then Validations.Add($"Erro ao conectar ou executar tarefa no armazenamento da empresa {Company.Register.ShortName}: {ex.Message}.")
            End Try
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
                Await _LocalDB.ExecuteRawQueryAsync("SELECT 1")
            Catch ex As Exception
                If Validations.Count = 0 Then Validations.Add($"Erro ao conectar ou executar consulta no banco de dados na empresa {Company.Register.ShortName}: {ex.Message}.")
            End Try
        Next Company
        Return Validations
    End Function
End Class
