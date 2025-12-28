Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class DatabaseSettingsViewModel
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private ReadOnly _SettingService As ManagerCore.CompanyService
    Private ReadOnly _SessionModel As SessionModel
    Private _Key As String
    Private _Server As String
    Private _Name As String
    Private _User As String
    Private _Password As String

    Public Sub New()
        _SettingService = Locator.GetInstance(Of ManagerCore.CompanyService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property Server As String
        Get
            Return _Server
        End Get
        Set(value As String)
            _Server = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property User As String
        Get
            Return _User
        End Get
        Set(value As String)
            _User = value
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
    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Sub LoadData()
        Server = _SessionModel.ManagerSetting.Database.Server
        Name = _SessionModel.ManagerSetting.Database.Name
        User = _SessionModel.ManagerSetting.Database.Username
        Password = _SessionModel.ManagerSetting.Database.Password
    End Sub
    Public Function Save() As Boolean
        Dim Pass As Boolean
        Dim OriginalServer As String = _SessionModel.ManagerSetting.Database.Server
        Dim OriginalName As String = _SessionModel.ManagerSetting.Database.Name
        Dim OriginalUser As String = _SessionModel.ManagerSetting.Database.Username
        Dim OriginalPassword As String = _SessionModel.ManagerSetting.Database.Password
        _SessionModel.ManagerSetting.Database.Server = Server
        _SessionModel.ManagerSetting.Database.Name = Name
        _SessionModel.ManagerSetting.Database.Username = User
        _SessionModel.ManagerSetting.Database.Password = Password
        _SettingService.Save(_SessionModel.ManagerSetting)
        If String.IsNullOrEmpty(_Server) And String.IsNullOrEmpty(_Name) And String.IsNullOrEmpty(_User) And String.IsNullOrEmpty(_Password) Then
            Pass = True
        Else
            Pass = ManagerCore.Util.AsyncLock(Function() DatabasePass(_SessionModel.ManagerSetting.Database))
        End If
        If Not Pass Then
            CMessageBox.Show("Não foi possível se conectar ao banco de dados com os dados informados, por favor verifique.")
            _SessionModel.ManagerSetting.Database.Server = OriginalServer
            _SessionModel.ManagerSetting.Database.Name = OriginalName
            _SessionModel.ManagerSetting.Database.Username = OriginalUser
            _SessionModel.ManagerSetting.Database.Password = OriginalPassword
            _SettingService.Save(_SessionModel.ManagerSetting)
            Return False
        End If
        Return True
    End Function
    Private Async Function DatabasePass(DatabaseSettings As CompanyDatabaseModel) As Task(Of Boolean)
        Dim Pass As Boolean
        Dim Database As LocalDB = Locator.GetInstance(Of LocalDB)
        Database.Initialize(DatabaseSettings)
        Try
            Await Database.ExecuteRawQueryAsync("SELECT 1;")
            Pass = True
        Catch ex As Exception
            Pass = False
        End Try
        Return Pass
    End Function
End Class
