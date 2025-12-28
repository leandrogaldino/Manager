Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class LicenseSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As ManagerCore.CompanyService
    Private ReadOnly _SessionModel As SessionModel
    Private _CloudName As String
    Private _CloudCredentials As String
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of ManagerCore.CompanyService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property CloudName As String
        Get
            Return _CloudName
        End Get
        Set(value As String)
            _CloudName = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property CloudCredentials As String
        Get
            Return _CloudCredentials
        End Get
        Set(value As String)
            _CloudCredentials = value
            OnPropertyChanged()
        End Set
    End Property
    Private Sub LoadData()
        CloudName = _SessionModel.ManagerSetting.Cloud.ManagerDB.ProjectID
        CloudCredentials = _SessionModel.ManagerSetting.Cloud.ManagerDB.JsonCredentials
    End Sub


    Public Function Save() As Boolean
        Dim TestSettings As New CompanySystemCloudModel With {
            .ProjectID = CloudName,
            .JsonCredentials = CloudCredentials
        }
        Dim Result As CloudTestResultModel
        If String.IsNullOrEmpty(CloudCredentials) And String.IsNullOrEmpty(CloudName) Then
            Result = New CloudTestResultModel With {
                .Success = True
            }
        Else
            Result = ManagerCore.Util.AsyncLock(Function() CloudPass(TestSettings))
        End If
        If Result.Success Then
            _SessionModel.ManagerSetting.Cloud.ManagerDB = TestSettings
            _SettingService.Save(_SessionModel.ManagerSetting)
            SetupApp.SetupData()
            Return True
        Else
            CMessageBox.Show($"Falha na conexão com a nuvem. Verifique os dados informados e tente novamente. Detalhes do erro: {Result.ErrorMessage}")
            Return False
        End If
    End Function
    Private Async Function CloudPass(Cloud As CompanySystemCloudModel) As Task(Of CloudTestResultModel)
        Dim Database As RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.System)
        Dim Result As New CloudTestResultModel
        Try
            Await Database.Initialize(Cloud)
            Await Database.TestConnection()
            Result.Success = True
            Return Result
        Catch ex As Exception
            Result.Success = False
            Result.ErrorMessage = ex.Message
            Return Result
        End Try
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
