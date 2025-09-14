Imports System.Text
Imports ControlLibrary
Imports ManagerCore

Public Class AppService
    Private _SettingService As SettingService

    Public Sub New(SettingService As SettingService)
        _SettingService = SettingService
    End Sub

    Public Function ValidateBackup() As List(Of String)
        Dim BackupSettings As SettingBackupModel = _SettingService.GetSettings().Backup
        Dim Validations As New List(Of String)
        If String.IsNullOrEmpty(BackupSettings.Location) Then
            Validations.Add($"O diretório de backup não foi definido;")
        Else
            If Not IO.Directory.Exists(BackupSettings.Location) Then
                Validations.Add("O direrório de backup informado não existe;")
            End If
        End If
        Return Validations
    End Function

    Public Async Function ValidateManagerCloudDB() As Task(Of List(Of String))
        Dim CloudDbSettings As SettingCloudManagerDatabaseModel = _SettingService.GetSettings().Cloud.ManagerDB
        Dim ManagerValidations As New List(Of String)
        Dim Validations As New List(Of String)
        If String.IsNullOrEmpty(CloudDbSettings.ProjectID) Then ManagerValidations.Add($"O nome do banco de dados cloud do Gerenciador não foi definido;")
        If String.IsNullOrEmpty(CloudDbSettings.JsonCredentials) Then ManagerValidations.Add("As credenciais do banco de dados cloud do Gerenciador não foram definidos;")
        Dim ManagerDB As RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Manager)
        Try
            Await ManagerDB.TestConnection()
        Catch ex As Exception
            If ManagerValidations.Count = 0 Then ManagerValidations.Add($"Erro ao conectar ou consultar no banco de dados cloud do gerenciador: {ex.Message};")
        End Try
        Validations.AddRange(ManagerValidations)
        Return Validations
    End Function
    Public Async Function ValidateCustomerCloudDB() As Task(Of List(Of String))
        Dim CloudDbSettings As SettingCloudManagerDatabaseModel = _SettingService.GetSettings().Cloud.CustomerDB
        Dim CustomerValidations As New List(Of String)
        Dim Validations As New List(Of String)
        If String.IsNullOrEmpty(CloudDbSettings.ProjectID) Then CustomerValidations.Add($"O nome do banco de dados cloud do cliente não foi definido;")
        If String.IsNullOrEmpty(CloudDbSettings.JsonCredentials) Then CustomerValidations.Add("As credenciais do banco de dados cloud do cliente não foram definidos;")
        Dim CustomerDB As RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        Try
            Await CustomerDB.TestConnection()
        Catch ex As Exception
            If CustomerValidations.Count = 0 Then CustomerValidations.Add($"Erro ao conectar ou consultar no banco de dados cloud do cliente: {ex.Message};")
        End Try
        Validations.AddRange(CustomerValidations)
        Return Validations
    End Function
    Public Async Function ValidateStorage() As Task(Of List(Of String))
        Dim StorageSettings As SettingCloudStorageModel = _SettingService.GetSettings().Cloud.Storage
        Dim Validations As New List(Of String)
        If String.IsNullOrEmpty(StorageSettings.BucketName) Then Validations.Add($"O nome do armazenamento não foi definido;")
        If String.IsNullOrEmpty(StorageSettings.JsonCredentials) Then Validations.Add("As credenciais do armazenamento não foram definidos;")
        Dim Storage As Storage = Locator.GetInstance(Of Storage)
        Try
            Await Storage.TestConnection()
        Catch ex As Exception
            If Validations.Count = 0 Then Validations.Add($"Erro ao conectar ou executar tarefa no armazenamento: {ex.Message};")
        End Try
        Return Validations
    End Function
    Public Async Function ValidateLocalDB() As Task(Of List(Of String))
        Dim DbSettings As SettingDatabaseModel = _SettingService.GetSettings().Database
        Dim Validations As New List(Of String)
        If String.IsNullOrEmpty(DbSettings.Name) Then Validations.Add($"O nome do banco de dados não foi definido;")
        If String.IsNullOrEmpty(DbSettings.Server) Then Validations.Add("O servidor do banco de dados não foi definido;")
        If String.IsNullOrEmpty(DbSettings.Username) Then Validations.Add("O nome de usuário do banco de dados não foi definido;")
        If String.IsNullOrEmpty(DbSettings.Password) Then Validations.Add("A senha do banco de dados não foi definida;")
        Dim LocalDB As LocalDB = Locator.GetInstance(Of LocalDB)
        Try
            Await LocalDB.ExecuteRawQueryAsync("SELECT 1")
        Catch ex As Exception
            If Validations.Count = 0 Then Validations.Add($"Erro ao conectar ou executar consulta no banco de dados: {ex.Message};")
        End Try
        Return Validations
    End Function
End Class
