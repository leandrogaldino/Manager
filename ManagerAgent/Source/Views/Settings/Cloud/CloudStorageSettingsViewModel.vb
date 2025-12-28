Imports ControlLibrary
Imports ManagerCore
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class CloudStorageSettingsViewModel
    Implements INotifyPropertyChanged
    Private ReadOnly _SettingService As ManagerCore.CompanyService
    Private ReadOnly _SessionModel As SessionModel
    Private _BucketName As String
    Private _CloudCredentials As String
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _SettingService = Locator.GetInstance(Of ManagerCore.CompanyService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub

    Public Property BucketName As String
        Get
            Return _BucketName
        End Get
        Set(value As String)
            _BucketName = value
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
        BucketName = _SessionModel.ManagerSetting.Cloud.Storage.BucketName
        CloudCredentials = _SessionModel.ManagerSetting.Cloud.Storage.JsonCredentials
    End Sub

    Public Function Save() As Boolean
        Dim TestSettings As New SettingCloudStorageModel With {
            .BucketName = BucketName,
            .JsonCredentials = CloudCredentials
        }
        Dim Result As CloudTestResultModel
        If String.IsNullOrEmpty(CloudCredentials) And String.IsNullOrEmpty(BucketName) Then
            Result = New CloudTestResultModel With {
                .Success = True
            }
        Else
            Result = ManagerCore.Util.AsyncLock(Function() CloudPass(TestSettings))
        End If
        If Result.Success Then
            _SessionModel.ManagerSetting.Cloud.Storage = TestSettings
            _SettingService.Save(_SessionModel.ManagerSetting)
            SetupApp.SetupData()
            Return True
        Else
            CMessageBox.Show($"Falha na conexão com a nuvem. Verifique os dados informados e tente novamente. Detalhes do erro: {Result.ErrorMessage}")
            Return False
        End If
    End Function

    Private Async Function CloudPass(Cloud As SettingCloudStorageModel) As Task(Of CloudTestResultModel)
        Dim Storage As Storage = Locator.GetInstance(Of Storage)
        Dim Result As New CloudTestResultModel
        Try
            Storage.Initialize(Cloud)
            Await Storage.TestConnection()
            Result.Success = True
            Return Result
        Catch ex As Exception
            Result.Success = False
            If ex.Message = "O preenchimento é inválido e não pode ser removido." Then
                Result.ErrorMessage = "Tentativa de descriptografia utilizando uma CryptoKey diferente da original."
            Else
                Result.ErrorMessage = ex.Message
            End If


            Return Result
        End Try
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
