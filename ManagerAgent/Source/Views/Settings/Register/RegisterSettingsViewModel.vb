Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports ControlLibrary
Imports ManagerCore

Public Class RegisterSettingsViewModel
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private ReadOnly _SettingService As ManagerCore.CompanyService
    Private ReadOnly _SessionModel As SessionModel
    Public Sub New()
        _SettingService = Locator.GetInstance(Of ManagerCore.CompanyService)
        _SessionModel = Locator.GetInstance(Of SessionModel)
        LoadData()
    End Sub
    Private _Name As String
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
            OnPropertyChanged()
        End Set
    End Property
    Private _ShortName As String
    Public Property ShortName As String
        Get
            Return _ShortName
        End Get
        Set(value As String)
            _ShortName = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Document As String
    Public Property Document As String
        Get
            Return _Document
        End Get
        Set(value As String)
            _Document = value
            OnPropertyChanged()
        End Set
    End Property
    Private _StateDocument As String
    Public Property StateDocument As String
        Get
            Return _StateDocument
        End Get
        Set(value As String)
            _StateDocument = value
            OnPropertyChanged()
        End Set
    End Property
    Private _CityDocument As String
    Public Property CityDocument As String
        Get
            Return _CityDocument
        End Get
        Set(value As String)
            _CityDocument = value
            OnPropertyChanged()
        End Set
    End Property
    Private _ZipCode As String
    Public Property ZipCode As String
        Get
            Return _ZipCode
        End Get
        Set(value As String)
            _ZipCode = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Street As String
    Public Property Street As String
        Get
            Return _Street
        End Get
        Set(value As String)
            _Street = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Number As String
    Public Property Number As String
        Get
            Return _Number
        End Get
        Set(value As String)
            _Number = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Complement As String
    Public Property Complement As String
        Get
            Return _Complement
        End Get
        Set(value As String)
            _Complement = value
            OnPropertyChanged()
        End Set
    End Property
    Private _District As String
    Public Property District As String
        Get
            Return _District
        End Get
        Set(value As String)
            _District = value
            OnPropertyChanged()
        End Set
    End Property
    Private _City As String
    Public Property City As String
        Get
            Return _City
        End Get
        Set(value As String)
            _City = value
            OnPropertyChanged()
        End Set
    End Property
    Private _State As String
    Public Property State As String
        Get
            Return _State
        End Get
        Set(value As String)
            _State = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Phone1 As String
    Public Property Phone1 As String
        Get
            Return _Phone1
        End Get
        Set(value As String)
            _Phone1 = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Phone2 As String
    Public Property Phone2 As String
        Get
            Return _Phone2
        End Get
        Set(value As String)
            _Phone2 = value
            OnPropertyChanged()
        End Set
    End Property
    Private _CellPhone As String
    Public Property CellPhone As String
        Get
            Return _CellPhone
        End Get
        Set(value As String)
            _CellPhone = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Email As String
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
            OnPropertyChanged()
        End Set
    End Property

    Private _Facebook As String
    Public Property Facebook As String
        Get
            Return _Facebook
        End Get
        Set(value As String)
            _Facebook = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Instagram As String
    Public Property Instagram As String
        Get
            Return _Instagram
        End Get
        Set(value As String)
            _Instagram = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Linkedin As String
    Public Property Linkedin As String
        Get
            Return _Linkedin
        End Get
        Set(value As String)
            _Linkedin = value
            OnPropertyChanged()
        End Set
    End Property
    Private _Site As String
    Public Property Site As String
        Get
            Return _Site
        End Get
        Set(value As String)
            _Site = value
            OnPropertyChanged()
        End Set
    End Property
    Private _LogoLocation As String
    Public Property LogoLocation As String
        Get
            Return _LogoLocation
        End Get
        Set(value As String)
            _LogoLocation = value
            OnPropertyChanged()
        End Set
    End Property
    Protected Sub OnPropertyChanged(<CallerMemberName> Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Private Sub LoadData()
        Name = _SessionModel.ManagerSetting.Register.Name
        ShortName = _SessionModel.ManagerSetting.Register.ShortName
        Document = _SessionModel.ManagerSetting.Register.Document
        StateDocument = _SessionModel.ManagerSetting.Register.StateDocument
        CityDocument = _SessionModel.ManagerSetting.Register.CityDocument
        ZipCode = _SessionModel.ManagerSetting.Register.Address.ZipCode
        Street = _SessionModel.ManagerSetting.Register.Address.Street
        Number = _SessionModel.ManagerSetting.Register.Address.Number
        Complement = _SessionModel.ManagerSetting.Register.Address.Complement
        District = _SessionModel.ManagerSetting.Register.Address.District
        City = _SessionModel.ManagerSetting.Register.Address.City
        State = _SessionModel.ManagerSetting.Register.Address.State
        Phone1 = _SessionModel.ManagerSetting.Register.Contact.Phone1
        Phone2 = _SessionModel.ManagerSetting.Register.Contact.Phone2
        CellPhone = _SessionModel.ManagerSetting.Register.Contact.CellPhone
        Email = _SessionModel.ManagerSetting.Register.Contact.Email
        Facebook = _SessionModel.ManagerSetting.Register.Contact.Facebook
        Instagram = _SessionModel.ManagerSetting.Register.Contact.Instagram
        Linkedin = _SessionModel.ManagerSetting.Register.Contact.Linkedin
        Site = _SessionModel.ManagerSetting.Register.Contact.Site
        LogoLocation = _SessionModel.ManagerSetting.Register.LogoLocation
    End Sub
    Public Function Save() As Boolean

        Dim Dir As New DirectoryInfo(ApplicationPaths.LogoDirectory)
        For Each f In Dir.GetFiles()
            File.Delete(f.FullName)
        Next f

        If Not String.IsNullOrEmpty(LogoLocation) Then
            _SessionModel.ManagerSetting.Register.LogoLocation = Path.Combine(ApplicationPaths.LogoDirectory, Now.ToString("ddMMyyyyHHmmss") & UCase(Path.GetRandomFileName().Replace(".", Nothing)) & New FileInfo(LogoLocation).Extension)
            File.Copy(LogoLocation, _SessionModel.ManagerSetting.Register.LogoLocation, True)
        End If

        _SessionModel.ManagerSetting.Register.Name = Name
        _SessionModel.ManagerSetting.Register.ShortName = ShortName
        _SessionModel.ManagerSetting.Register.Document = Document
        _SessionModel.ManagerSetting.Register.StateDocument = StateDocument
        _SessionModel.ManagerSetting.Register.CityDocument = CityDocument
        _SessionModel.ManagerSetting.Register.Address.ZipCode = ZipCode
        _SessionModel.ManagerSetting.Register.Address.Street = Street
        _SessionModel.ManagerSetting.Register.Address.Number = Number
        _SessionModel.ManagerSetting.Register.Address.Complement = Complement
        _SessionModel.ManagerSetting.Register.Address.District = District
        _SessionModel.ManagerSetting.Register.Address.City = City
        _SessionModel.ManagerSetting.Register.Address.State = State
        _SessionModel.ManagerSetting.Register.Contact.Phone1 = Phone1
        _SessionModel.ManagerSetting.Register.Contact.Phone2 = Phone2
        _SessionModel.ManagerSetting.Register.Contact.CellPhone = CellPhone
        _SessionModel.ManagerSetting.Register.Contact.Email = Email
        _SessionModel.ManagerSetting.Register.Contact.Facebook = Facebook
        _SessionModel.ManagerSetting.Register.Contact.Instagram = Instagram
        _SessionModel.ManagerSetting.Register.Contact.Linkedin = Linkedin
        _SessionModel.ManagerSetting.Register.Contact.Site = Site
        _SettingService.Save(_SessionModel.ManagerSetting)
        Return True
    End Function
End Class
