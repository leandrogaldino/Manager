Imports ManagerCore

Public Class TaskCloudSyncManual
    Inherits TaskCloudSync

    Public Sub New(LocalDatabaseService As LocalDB, RemoteDatabaseService As RemoteDB, SettingsService As ManagerCore.CompanyService, SessionModel As SessionModel)
        MyBase.New(LocalDatabaseService, RemoteDatabaseService, SettingsService, SessionModel)
    End Sub
    Private _NextRun As Date = Nothing
    Public Overrides Property NextRun As Date
        Get
            Return _NextRun
        End Get
        Set(value As Date)
            _NextRun = value
        End Set
    End Property
    Public Overrides ReadOnly Property Name As TaskName
        Get
            Return TaskName.CloudSyncManual
        End Get
    End Property
    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return True
        End Get
    End Property
End Class
