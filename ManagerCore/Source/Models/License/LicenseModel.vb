Imports Newtonsoft.Json

Public Class LicenseModel
    Implements ICloneable
    Public Property CustomerLinkToken As String
    Public Property CustomerDocument As String
    Public Property CustomerName As String
    Public Property ExpirationDate As String
    Public Property ManagerAgentPassword As String
    Public Property ManagerAgentUsername As String
    Public Function Clone() As Object Implements ICloneable.Clone
        Return New LicenseModel With {
            .CustomerLinkToken = Me.CustomerLinkToken,
            .CustomerDocument = Me.CustomerDocument,
            .CustomerName = Me.CustomerName,
            .ExpirationDate = Me.ExpirationDate,
            .ManagerAgentPassword = Me.ManagerAgentPassword,
            .ManagerAgentUsername = Me.ManagerAgentUsername
        }
    End Function
    Public Shared Function FromCloud(Data As Dictionary(Of String, Object)) As LicenseModel
        Dim Model As New LicenseModel()
        If Data.ContainsKey("customer_link_token") Then Model.CustomerLinkToken = Convert.ToString(Data("customer_link_token"))
        If Data.ContainsKey("customer_document") Then Model.CustomerDocument = Convert.ToString(Data("customer_document"))
        If Data.ContainsKey("customer_name") Then Model.CustomerName = Convert.ToString(Data("customer_name"))
        If Data.ContainsKey("expiration_date") Then Model.ExpirationDate = Convert.ToString(Data("expiration_date"))
        If Data.ContainsKey("manager_agent_password") Then Model.ManagerAgentPassword = Convert.ToString(Data("manager_agent_password"))
        If Data.ContainsKey("manager_agent_username") Then Model.ManagerAgentUsername = Convert.ToString(Data("manager_agent_username"))
        Return Model
    End Function
    Public Function ToCloud() As Dictionary(Of String, Object)
        Dim Dictionary As New Dictionary(Of String, Object) From {
            {"customer_link_token", CustomerLinkToken},
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
