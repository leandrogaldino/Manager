Imports ControlLibrary
Imports ManagerCore
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class EvaluationSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As SettingService
    Private ReadOnly _SessionModel As SessionModel

    Private _AlertMaintenance As Integer
    Private _AlertVisit As Integer

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of SettingService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property AlertMaintenance As Integer
        Get
            Return _AlertMaintenance
        End Get
        Set(value As Integer)
            _AlertMaintenance = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property AlertVisit As Integer
        Get
            Return _AlertVisit
        End Get
        Set(value As Integer)
            _AlertVisit = value
            OnPropertyChanged()
        End Set
    End Property
    Private Sub LoadData()
        AlertMaintenance = _SessionModel.ManagerSetting.General.Evaluation.DaysToAlertMaintenance
        AlertVisit = _SessionModel.ManagerSetting.General.Evaluation.DaysToAlertVisit
    End Sub

    Public Function Save() As Boolean
        _SessionModel.ManagerSetting.General.Evaluation.DaysToAlertMaintenance = AlertMaintenance
        _SessionModel.ManagerSetting.General.Evaluation.DaysToAlertVisit = AlertVisit
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
