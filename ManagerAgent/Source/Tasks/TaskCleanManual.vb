Imports ManagerCore

Public Class TaskCleanManual
    Inherits TaskClean

    Public Sub New(CompanyModel As CompanyModel, DatabaseService As LocalDB, CompanyService As CompanyService)
        MyBase.New(CompanyModel, DatabaseService, CompanyService)
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
