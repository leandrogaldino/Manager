Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore
Public Class CloudSynchronizationViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As SettingService
    Private ReadOnly _SessionModel As SessionModel
    Private _CloudMaxOperation As Long
    Private _CloudLastSyncID As Long
    Private _CloudOperationCount As Long
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub New()
        _SettingService = Locator.GetInstance(Of SettingService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub
    Public Property CloudMaxOperation As Long
        Get
            Return _CloudMaxOperation
        End Get
        Set(value As Long)
            _CloudMaxOperation = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property CloudLastSyncID As Long
        Get
            Return _CloudLastSyncID
        End Get
        Set(value As Long)
            _CloudLastSyncID = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property CloudOperationCount As Long
        Get
            Return _CloudOperationCount
        End Get
        Set(value As Long)
            _CloudOperationCount = value
            OnPropertyChanged()
        End Set
    End Property
    Private Sub LoadData()
        CloudMaxOperation = _SessionModel.ManagerSetting.Cloud.Synchronization.CloudMaxOperation
        CloudLastSyncID = _SessionModel.ManagerSetting.Cloud.Synchronization.CloudLastSyncID
        CloudOperationCount = _SessionModel.ManagerSetting.Cloud.Synchronization.CloudOperationCount
    End Sub
    Public Function Save() As Boolean
        _SessionModel.ManagerSetting.Cloud.Synchronization.CloudMaxOperation = CloudMaxOperation
        _SessionModel.ManagerSetting.Cloud.Synchronization.CloudLastSyncID = CloudLastSyncID
        _SessionModel.ManagerSetting.Cloud.Synchronization.CloudOperationCount = CloudOperationCount
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function
    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub
End Class
