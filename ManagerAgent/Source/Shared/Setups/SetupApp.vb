Imports ControlLibrary
Imports ManagerCore
Public Class SetupApp
    Public Shared Sub SetupCMessageBox()
        CMessageBox.TitleFont = New Font("Century Gothic", 12, FontStyle.Bold)
        CMessageBox.MessageFont = New Font("Century Gothic", 11.25, FontStyle.Regular)
        CMessageBox.ShowEmailErrorButton = False
    End Sub
    Public Shared Sub SetupData()
        Dim SessionModel As SessionModel = Locator.GetInstance(Of SessionModel)
        Locator.GetInstance(Of LocalDB)().Initialize(SessionModel.ManagerSetting.Database)
        Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Manager).Initialize(SessionModel.ManagerSetting.Cloud.ManagerDB)
        Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer).Initialize(SessionModel.ManagerSetting.Cloud.CustomerDB)
        Locator.GetInstance(Of Storage)().Initialize(SessionModel.ManagerSetting.Cloud.Storage)
    End Sub
End Class
