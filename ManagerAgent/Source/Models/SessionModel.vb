Imports ManagerCore
Public Class SessionModel
    Public Property Companies As New List(Of CompanyModel)
    Public Property ManagerLicenseResult As LicenseResultModel
    Public Property IsAgentPaused As Boolean = True
    Public Property ForceAgentExit As Boolean
    Public Property Preferences As PreferencesModel
End Class