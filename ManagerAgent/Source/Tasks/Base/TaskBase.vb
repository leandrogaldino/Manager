Imports ManagerCore

Public MustInherit Class TaskBase
    Private _NextRun As Date
    Private _IsRunNeeded As Boolean
    Private _Company As CompanyModel
    MustOverride Async Function Run(Optional Progress As IProgress(Of AsyncResponseModel) = Nothing) As Task
    MustOverride ReadOnly Property Name As TaskName
    MustOverride ReadOnly Property RunIntervalMinutes As Integer
    MustOverride ReadOnly Property LastRun As Date
    MustOverride ReadOnly Property IsManual As Boolean
    Public Property IsRunning As Boolean
    Public Property CancelRun As Boolean
    Public Property Waiting As Boolean
    Public Sub New(Company As CompanyModel)
        _Company = Company
    End Sub

    Public ReadOnly Property Company As CompanyModel
        Get
            Return _Company
        End Get
    End Property

    Public Overridable Property NextRun As Date
        Get
            If IsManual Then
                Return _NextRun
            Else
                Return LastRun.AddMinutes(RunIntervalMinutes)
            End If
        End Get
        Set(value As Date)
            _NextRun = value
        End Set
    End Property
    Public Overridable Property IsRunNeeded As Boolean
        Get
            If IsManual Then
                Return _IsRunNeeded
            Else
                Return LastRun.AddMinutes(RunIntervalMinutes) <= Now
            End If
        End Get
        Set(value As Boolean)
            _IsRunNeeded = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
