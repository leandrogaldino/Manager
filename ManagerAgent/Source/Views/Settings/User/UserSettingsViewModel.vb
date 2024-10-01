Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class UserSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As SettingService
    Private ReadOnly _SessionModel As SessionModel
    Private _DefaultPassword As String
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of SettingService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property DefaultPassword As String
        Get
            Return _DefaultPassword
        End Get
        Set(value As String)
            _DefaultPassword = value
            OnPropertyChanged()
        End Set
    End Property

    Private Sub LoadData()
        DefaultPassword = _SessionModel.ManagerSetting.General.User.DefaultPassword
    End Sub

    Public Function Save() As Boolean
        _SessionModel.ManagerSetting.General.User.DefaultPassword = DefaultPassword
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
