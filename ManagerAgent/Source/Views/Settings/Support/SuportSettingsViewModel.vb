Imports ControlLibrary
Imports ManagerCore
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class SuportSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As SettingService
    Private ReadOnly _SessionModel As SessionModel

    Private _EnableSSL As Boolean
    Private _Email As String
    Private _SmtpServer As String
    Private _Port As Integer
    Private _Password As String

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of SettingService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property EnableSSL As Boolean
        Get
            Return _EnableSSL
        End Get
        Set(value As Boolean)
            _EnableSSL = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property SmtpServer As String
        Get
            Return _SmtpServer
        End Get
        Set(value As String)
            _SmtpServer = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property Port As Integer
        Get
            Return _Port
        End Get
        Set(value As Integer)
            _Port = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
            OnPropertyChanged()
        End Set
    End Property
    Private Sub LoadData()
        EnableSSL = _SessionModel.ManagerSetting.Support.EnableSSL
        Email = _SessionModel.ManagerSetting.Support.Email
        SmtpServer = _SessionModel.ManagerSetting.Support.SMTPServer
        Port = _SessionModel.ManagerSetting.Support.Port
        Password = _SessionModel.ManagerSetting.Support.Password
    End Sub

    Public Function Save() As Boolean
        _SessionModel.ManagerSetting.Support.EnableSSL = EnableSSL
        _SessionModel.ManagerSetting.Support.Email = Email
        _SessionModel.ManagerSetting.Support.SMTPServer = SmtpServer
        _SessionModel.ManagerSetting.Support.Port = Port
        _SessionModel.ManagerSetting.Support.Password = Password
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
