Imports ManagerCore
Imports CoreSuite.Services

Public Class TaskReleaseManual
    Inherits TaskRelease
    Public Sub New(Preferences As PreferencesModel, PreferencesService As PreferencesService, LocalDb As MySqlService)
        MyBase.New(Preferences, PreferencesService, LocalDb)
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
