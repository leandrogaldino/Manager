Imports ManagerCore
Imports CoreSuite.Services

Public Class TaskCleanManual
    Inherits TaskClean

    Public Sub New(Session As SessionModel, PreferencesService As PreferencesService, LocalDb As MySqlService)
        MyBase.New(Session, PreferencesService, LocalDb)
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
            Return TaskName.CleanManual
        End Get
    End Property
    Public Overrides ReadOnly Property IsManual As Boolean
        Get
            Return True
        End Get
    End Property
End Class
