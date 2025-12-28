Imports ManagerCore
Public Class SessionModel
    Public Property Companies As New List(Of CompanyModel)
    Public Property ManagerLicenseResult As LicenseResultModel
    Public Property IsAgentPaused As Boolean = True
    Public Property ForceAgentExit As Boolean
    Public ReadOnly Property ManagerPassword As String = "jK&%^avLV$BSoVIEovV@T$l%tyYFIXj7"
End Class