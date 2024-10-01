Imports ManagerCore

Public Class TaskReleaseManual
    Inherits TaskRelease

    Public Sub New(DatabaseService As LocalDB, SettingsService As SettingService, SessionModel As SessionModel)
        MyBase.New(DatabaseService, SettingsService, SessionModel)
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
            Return TaskName.ReleaseManual
        End Get
    End Property
    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return True
        End Get
    End Property
End Class
