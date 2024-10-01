Imports System.ComponentModel
Imports ControlLibrary
Imports System.Runtime.CompilerServices
Imports ManagerCore

Public Class CleanSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As SettingService
    Private ReadOnly _SessionModel As SessionModel
    Private _Interval As Integer
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of SettingService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property Interval As Integer
        Get
            Return _Interval
        End Get
        Set(value As Integer)
            _Interval = value
            OnPropertyChanged()
        End Set
    End Property

    Private Sub LoadData()
        Interval = _SessionModel.ManagerSetting.General.Clean.Interval

    End Sub

    Public Function Save() As Boolean
        _SessionModel.ManagerSetting.General.Clean.Interval = Interval
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub
End Class
