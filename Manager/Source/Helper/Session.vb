Imports ManagerCore
Public Class Session
    Public Property Token As String
    Public Property User As User
    Public Property UserDirectoryLocation As String
    Public Property Setting As New SettingModel
    Public Property LicenseResult As New LicenseResultModel
    Public Property AutoCloseApp As Boolean
    Public Property ManagerVersion As String
End Class
