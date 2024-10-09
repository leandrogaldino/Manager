Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class BackupSettingsViewModel
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private ReadOnly _SettingService As SettingService
    Private ReadOnly _SessionModel As SessionModel

    Private _Monday As Boolean
    Private _Tuesday As Boolean
    Private _Wednesday As Boolean
    Private _Thursday As Boolean
    Private _Friday As Boolean
    Private _Saturday As Boolean
    Private _Sunday As Boolean
    Private _Time As TimeSpan
    Private _Keep As Integer
    Private _IgnoreNext As Boolean
    Private _Location As String

    Public Sub New()
        _SettingService = Locator.GetInstance(Of SettingService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property Monday As Boolean
        Get
            Return _Monday
        End Get
        Set(value As Boolean)
            _Monday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Tuesday As Boolean
        Get
            Return _Tuesday
        End Get
        Set(value As Boolean)
            _Tuesday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Wednesday As Boolean
        Get
            Return _Wednesday
        End Get
        Set(value As Boolean)
            _Wednesday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Thursday As Boolean
        Get
            Return _Thursday
        End Get
        Set(value As Boolean)
            _Thursday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Friday As Boolean
        Get
            Return _Friday
        End Get
        Set(value As Boolean)
            _Friday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Saturday As Boolean
        Get
            Return _Saturday
        End Get
        Set(value As Boolean)
            _Saturday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Sunday As Boolean
        Get
            Return _Sunday
        End Get
        Set(value As Boolean)
            _Sunday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Time As TimeSpan
        Get
            Return _Time
        End Get
        Set(value As TimeSpan)
            _Time = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Keep As Integer
        Get
            Return _Keep
        End Get
        Set(value As Integer)
            _Keep = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property IgnoreNext As Boolean
        Get
            Return _IgnoreNext
        End Get
        Set(value As Boolean)
            _IgnoreNext = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Location As String
        Get
            Return _Location
        End Get
        Set(value As String)
            _Location = value
            OnPropertyChanged()
        End Set
    End Property

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

    Private Sub LoadData()
        Monday = _SessionModel.ManagerSetting.Backup.Monday
        Tuesday = _SessionModel.ManagerSetting.Backup.Tuesday
        Wednesday = _SessionModel.ManagerSetting.Backup.Wednesday
        Thursday = _SessionModel.ManagerSetting.Backup.Thursday
        Friday = _SessionModel.ManagerSetting.Backup.Friday
        Saturday = _SessionModel.ManagerSetting.Backup.Saturday
        Sunday = _SessionModel.ManagerSetting.Backup.Sunday
        Time = _SessionModel.ManagerSetting.Backup.Time
        Keep = _SessionModel.ManagerSetting.Backup.Keep
        IgnoreNext = _SessionModel.ManagerSetting.Backup.IgnoreNext
        Location = _SessionModel.ManagerSetting.Backup.Location
    End Sub

    Public Function Save() As Boolean
        If String.IsNullOrEmpty(Location) OrElse (Not String.IsNullOrEmpty(Location) And Directory.Exists(Location)) Then
            _SessionModel.ManagerSetting.Backup.Monday = Monday
            _SessionModel.ManagerSetting.Backup.Tuesday = Tuesday
            _SessionModel.ManagerSetting.Backup.Wednesday = Wednesday
            _SessionModel.ManagerSetting.Backup.Thursday = Thursday
            _SessionModel.ManagerSetting.Backup.Friday = Friday
            _SessionModel.ManagerSetting.Backup.Saturday = Saturday
            _SessionModel.ManagerSetting.Backup.Sunday = Sunday
            _SessionModel.ManagerSetting.Backup.Time = Time
            _SessionModel.ManagerSetting.Backup.Keep = Keep
            _SessionModel.ManagerSetting.Backup.IgnoreNext = IgnoreNext
            _SessionModel.ManagerSetting.Backup.Location = Location
            _SettingService.Save(_SessionModel.ManagerSetting)
            Return True
        Else
            CMessageBox.Show("Não foi possível salvar pois o diretório escolhido não existe, por favor verifique.")
            Return False
        End If
    End Function

End Class