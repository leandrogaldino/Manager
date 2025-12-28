Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class LoginViewModel
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _SessionModel As SessionModel
    Private _LicenseService As LicenseService
    Private _Key As String
    Private _Username As String
    Private _Password As String
    Public Property Username As String
        Get
            Return _Username
        End Get
        Set(value As String)
            _Username = value
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
    Public Sub New(SessionModel As SessionModel, LicenseService As LicenseService, CryptoKeyService As CryptoKeyService)
        _SessionModel = SessionModel
        _LicenseService = LicenseService
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub
    Public Function IsValidCredentials() As Boolean
        If _SessionModel.ManagerLicenseResult.License IsNot Nothing AndAlso _SessionModel.ManagerLicenseResult.License.ManagerAgentUsername = Username AndAlso _SessionModel.ManagerLicenseResult.License.ManagerAgentPassword = Cryptography.Encrypt(Password, _Key) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Login() As LicenseMessages
        Dim LicenseService = Locator.GetInstance(Of LicenseService)
        _SessionModel.ManagerLicenseResult = LicenseService.GetLocalLicense()
        If _SessionModel.ManagerLicenseResult.Success Then
            If IsValidCredentials() Then
                Return LicenseMessages.None
            Else
                Return LicenseMessages.BadPassword
            End If
        Else
            Return _SessionModel.ManagerLicenseResult.Flag
        End If
        Return False
    End Function
    Public Async Function RenewLicense() As Task
        _SessionModel.ManagerLicenseResult = Await _LicenseService.GetOnlineLicense()
        If Not (_SessionModel.ManagerLicenseResult.Success AndAlso IsValidCredentials()) Then
            CMessageBox.Show(EnumHelper.GetEnumDescription(_SessionModel.ManagerLicenseResult.Flag), CMessageBoxType.Warning)
        End If
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub
End Class
