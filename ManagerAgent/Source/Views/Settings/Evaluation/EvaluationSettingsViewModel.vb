Imports ControlLibrary
Imports ManagerCore
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class EvaluationSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As ManagerCore.CompanyService
    Private ReadOnly _SessionModel As SessionModel

    Private _DaysBeforeMaintenanceAlert As Integer
    Private _DaysBeforeVisitAlert As Integer
    Private _MonthsBeforeRecordDeletion As Integer

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of ManagerCore.CompanyService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property DaysBeforeMaintenanceAlert As Integer
        Get
            Return _DaysBeforeMaintenanceAlert
        End Get
        Set(value As Integer)
            _DaysBeforeMaintenanceAlert = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property DaysBeforeVisitAlert As Integer
        Get
            Return _DaysBeforeVisitAlert
        End Get
        Set(value As Integer)
            _DaysBeforeVisitAlert = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property MonthsBeforeRecordDeletion As Integer
        Get
            Return _MonthsBeforeRecordDeletion
        End Get
        Set(value As Integer)
            _MonthsBeforeRecordDeletion = value
            OnPropertyChanged()
        End Set
    End Property
    Private Sub LoadData()
        DaysBeforeMaintenanceAlert = _SessionModel.ManagerSetting.General.Evaluation.DaysBeforeMaintenanceAlert
        DaysBeforeVisitAlert = _SessionModel.ManagerSetting.General.Evaluation.DaysBeforeVisitAlert
        MonthsBeforeRecordDeletion = _SessionModel.ManagerSetting.General.Evaluation.MonthsBeforeRecordDeletion
    End Sub

    Public Function Save() As Boolean
        _SessionModel.ManagerSetting.General.Evaluation.DaysBeforeMaintenanceAlert = DaysBeforeMaintenanceAlert
        _SessionModel.ManagerSetting.General.Evaluation.DaysBeforeVisitAlert = DaysBeforeVisitAlert
        _SessionModel.ManagerSetting.General.Evaluation.MonthsBeforeRecordDeletion = MonthsBeforeRecordDeletion
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
