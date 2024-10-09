Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class ReleaseSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As SettingService
    Private ReadOnly _SessionModel As SessionModel
    Private _ReleaseRegister As Integer
    Private _RefreshRegister As Integer

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of SettingService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property ReleaseRegister As Integer
        Get
            Return _ReleaseRegister
        End Get
        Set(value As Integer)
            _ReleaseRegister = value
            OnPropertyChanged()
        End Set
    End Property

    Public ReadOnly Property RefreshRegister As Integer
        Get
            Return _ReleaseRegister - 1
        End Get
    End Property

    Private Sub LoadData()
        ReleaseRegister = _SessionModel.ManagerSetting.General.Release.ReleaseBlockedRegisterInterval
    End Sub

    Public Function Save() As Boolean
        _SessionModel.ManagerSetting.General.Release.ReleaseBlockedRegisterInterval = ReleaseRegister
        _SessionModel.ManagerSetting.General.Release.RefreshBlockedRegistryInterval = RefreshRegister
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

End Class