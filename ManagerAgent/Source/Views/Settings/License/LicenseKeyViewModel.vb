Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class LicenseKeyViewModel
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _LicenseService As LicenseService
    Private _SessionModel As SessionModel
    Private _KeyPartA As String
    Private _KeyPartB As String
    Private _KeyPartC As String
    Private _KeyPartD As String
    Private _KeyPartE As String
    Private _Key As String
    Private _IsValidKey As String
    Public Property KeyPartA As String
        Get
            Return _KeyPartA
        End Get
        Set(value As String)
            _KeyPartA = value
            FillKey()
            OnPropertyChanged()
        End Set
    End Property
    Public Property KeyPartB As String
        Get
            Return _KeyPartB
        End Get
        Set(value As String)
            _KeyPartB = value
            FillKey()
            OnPropertyChanged()
        End Set
    End Property
    Public Property KeyPartC As String
        Get
            Return _KeyPartC
        End Get
        Set(value As String)
            _KeyPartC = value
            FillKey()
            OnPropertyChanged()
        End Set
    End Property
    Public Property KeyPartD As String
        Get
            Return _KeyPartD
        End Get
        Set(value As String)
            _KeyPartD = value
            FillKey()
            OnPropertyChanged()
        End Set
    End Property
    Public Property KeyPartE As String
        Get
            Return _KeyPartE
        End Get
        Set(value As String)
            _KeyPartE = value
            FillKey()
            OnPropertyChanged()
        End Set
    End Property
    Public Property Key As String
        Get
            Return _Key
        End Get
        Set(value As String)
            _Key = value
            OnPropertyChanged()
        End Set
    End Property
    Public Property IsValidKey As Boolean
        Get
            Return _IsValidKey
        End Get
        Set(value As Boolean)
            _IsValidKey = value
            OnPropertyChanged()
        End Set
    End Property

    Public Sub New(LicenseService As LicenseService, SessionModel As SessionModel)
        _LicenseService = LicenseService
        _SessionModel = SessionModel
    End Sub
    Private Sub FillKey()
        _Key = $"{_KeyPartA}{_KeyPartB}{_KeyPartC}{_KeyPartD}{_KeyPartE}"
    End Sub
    Public Async Function ValidateLicenseAsync() As Task
        If Not String.IsNullOrEmpty(_Key) AndAlso Await Utility.IsInternetAvailableAsync() Then
            IsValidKey = Await _LicenseService.IsValidLicenseKey(_Key)
        Else
            IsValidKey = False
        End If
    End Function

    Public Async Function ProcessLicense() As Task(Of LicenseResultModel)
        Dim LicenseResult As New LicenseResultModel
        Dim LocalToken As String = _LicenseService.GetLocalLicenseToken()
        Dim LocalKey As String = _LicenseService.GetLocalLicenseKey()
        LicenseResult.License.LicenseKey = _Key
        LicenseResult = Await _LicenseService.GetOnlineLicense(_Key, LocalToken)
        If LicenseResult.Success Then
            If LicenseResult.License.LicenseKey = LocalKey And LicenseResult.License.LicenseToken = LocalToken Then
                LicenseResult.Success = False
                LicenseResult.License = Nothing
                LicenseResult.Flag = LicenseMessages.ProductKeyAlreadyActivatedOnThis
            Else
                Await _LicenseService.SaveLocalLicense(LicenseResult.License)
                Await _LicenseService.UpdateManagerAgentPassword(LicenseResult.License, Cryptography.Encrypt(_SessionModel.ManagerSetting.General.User.DefaultPassword, Locator.GetInstance(Of CryptoKeyService).ReadCryptoKey()))
                _SessionModel.ManagerLicenseResult = LicenseResult.Clone()
            End If
        End If
        Return LicenseResult
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
