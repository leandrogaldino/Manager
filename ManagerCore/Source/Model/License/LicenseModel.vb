Imports Newtonsoft.Json

Public Class LicenseModel
    Implements ICloneable
    Public Property LicenseKey As String
    Public Property LicenseToken As String
    Public Property CustomerDocument As String
    Public Property CustomerName As String
    Public Property ExpirationDate As String
    Public Property ManagerAgentPassword As String
    Public Property ManagerAgentUsername As String
    <JsonIgnore>
    Public LastOnlineValidation As Date
    Public Function Clone() As Object Implements ICloneable.Clone
        Return New LicenseModel With {
            .LicenseKey = Me.LicenseKey,
            .LicenseToken = Me.LicenseToken,
            .CustomerDocument = Me.CustomerDocument,
            .CustomerName = Me.CustomerName,
            .ExpirationDate = Me.ExpirationDate,
            .ManagerAgentPassword = Me.ManagerAgentPassword,
            .ManagerAgentUsername = Me.ManagerAgentUsername,
            .LastOnlineValidation = Me.LastOnlineValidation
        }
    End Function
    Public Shared Function FromCloud(Data As Dictionary(Of String, Object)) As LicenseModel
        Dim Model As New LicenseModel()
        If Data.ContainsKey("license_key") Then Model.LicenseKey = TryCast(Data("license_key"), String)
        If Data.ContainsKey("license_token") Then Model.LicenseToken = TryCast(Data("license_token"), String)
        If Data.ContainsKey("customer_document") Then Model.CustomerDocument = TryCast(Data("customer_document"), String)
        If Data.ContainsKey("customer_name") Then Model.CustomerName = TryCast(Data("customer_name"), String)
        If Data.ContainsKey("expiration_date") Then Model.ExpirationDate = TryCast(Data("expiration_date"), String)
        If Data.ContainsKey("manager_agent_password") Then Model.ManagerAgentPassword = TryCast(Data("manager_agent_password"), String)
        If Data.ContainsKey("manager_agent_username") Then Model.ManagerAgentUsername = TryCast(Data("manager_agent_username"), String)
        Return Model
    End Function
    Public Function ToCloud() As Dictionary(Of String, Object)
        Dim Dictionary As New Dictionary(Of String, Object) From {
            {"license_key", LicenseKey},
            {"license_token", LicenseToken},
            {"customer_document", CustomerDocument},
            {"customer_name", CustomerName},
            {"expiration_date", ExpirationDate},
            {"manager_agent_password", ManagerAgentPassword},
            {"manager_agent_username", ManagerAgentUsername}
        }
        Return Dictionary
    End Function
    Public Function ToJson(Optional formatted As Boolean = False) As String
        Dim settings As New JsonSerializerSettings With {
            .Formatting = If(formatted, Formatting.Indented, Formatting.None)
        }
        Return JsonConvert.SerializeObject(Me, settings)
    End Function

    Public Shared Function FromJson(json As String) As LicenseModel
        If String.IsNullOrWhiteSpace(json) Then
            Throw New ArgumentException("JSON inválido ou vazio.")
        End If
        Return JsonConvert.DeserializeObject(Of LicenseModel)(json)
    End Function
End Class
