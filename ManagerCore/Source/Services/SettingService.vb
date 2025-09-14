Imports System.IO
Imports System.Text
Imports System.Xml
Imports ControlLibrary
Public Class SettingService
    Private _Key As String
    Public Sub New(CryptoKeyService As CryptoKeyService)
        _Key = CryptoKeyService.ReadCryptoKey()
    End Sub
    Public Function GetSettings() As SettingModel
        Dim Model As SettingModel
        Dim XmlStr As String
        Dim XmlDoc As XmlDocument
        If File.Exists(ApplicationPaths.SettingFile) Then
            Model = New SettingModel
            XmlStr = File.ReadAllText(ApplicationPaths.SettingFile)
            XmlStr = Cryptography.Decrypt(XmlStr, _Key)
            XmlDoc = New XmlDocument
            XmlDoc.LoadXml(XmlStr)
            Model.Company.Document = XmlDoc.SelectSingleNode("Setting/Company/Document").InnerText
            Model.Company.LogoLocation = XmlDoc.SelectSingleNode("Setting/Company/LogoLocation").InnerText
            Model.Company.Name = XmlDoc.SelectSingleNode("Setting/Company/Name").InnerText
            Model.Company.ShortName = XmlDoc.SelectSingleNode("Setting/Company/Shortname").InnerText
            Model.Company.CityDocument = XmlDoc.SelectSingleNode("Setting/Company/CityDocument").InnerText
            Model.Company.StateDocument = XmlDoc.SelectSingleNode("Setting/Company/StateDocument").InnerText
            Model.Company.Address.ZipCode = XmlDoc.SelectSingleNode("Setting/Company/Address/ZipCode").InnerText
            Model.Company.Address.Street = XmlDoc.SelectSingleNode("Setting/Company/Address/Street").InnerText
            Model.Company.Address.Number = XmlDoc.SelectSingleNode("Setting/Company/Address/Number").InnerText
            Model.Company.Address.Complement = XmlDoc.SelectSingleNode("Setting/Company/Address/Complement").InnerText
            Model.Company.Address.District = XmlDoc.SelectSingleNode("Setting/Company/Address/District").InnerText
            Model.Company.Address.City = XmlDoc.SelectSingleNode("Setting/Company/Address/City").InnerText
            Model.Company.Address.State = XmlDoc.SelectSingleNode("Setting/Company/Address/State").InnerText
            Model.Company.Contact.Phone1 = XmlDoc.SelectSingleNode("Setting/Company/Contact/Phone1").InnerText
            Model.Company.Contact.Phone2 = XmlDoc.SelectSingleNode("Setting/Company/Contact/Phone2").InnerText
            Model.Company.Contact.CellPhone = XmlDoc.SelectSingleNode("Setting/Company/Contact/CellPhone").InnerText
            Model.Company.Contact.Email = XmlDoc.SelectSingleNode("Setting/Company/Contact/Email").InnerText
            Model.Company.Contact.Facebook = XmlDoc.SelectSingleNode("Setting/Company/Contact/Facebook").InnerText
            Model.Company.Contact.Instagram = XmlDoc.SelectSingleNode("Setting/Company/Contact/Instagram").InnerText
            Model.Company.Contact.Linkedin = XmlDoc.SelectSingleNode("Setting/Company/Contact/Linkedin").InnerText
            Model.Company.Contact.Site = XmlDoc.SelectSingleNode("Setting/Company/Contact/Site").InnerText
            Model.Backup.Monday = CBool(XmlDoc.SelectSingleNode("Setting/Backup/Monday").InnerText)
            Model.Backup.Tuesday = CBool(XmlDoc.SelectSingleNode("Setting/Backup/Tuesday").InnerText)
            Model.Backup.Wednesday = CBool(XmlDoc.SelectSingleNode("Setting/Backup/Wednesday").InnerText)
            Model.Backup.Thursday = CBool(XmlDoc.SelectSingleNode("Setting/Backup/Thursday").InnerText)
            Model.Backup.Friday = CBool(XmlDoc.SelectSingleNode("Setting/Backup/Friday").InnerText)
            Model.Backup.Saturday = CBool(XmlDoc.SelectSingleNode("Setting/Backup/Saturday").InnerText)
            Model.Backup.Sunday = CBool(XmlDoc.SelectSingleNode("Setting/Backup/Sunday").InnerText)
            Model.Backup.Time = TimeSpan.Parse(XmlDoc.SelectSingleNode("Setting/Backup/Time").InnerText)
            Model.Backup.Keep = CInt(XmlDoc.SelectSingleNode("Setting/Backup/Keep").InnerText)
            Model.Backup.IgnoreNext = CBool(XmlDoc.SelectSingleNode("Setting/Backup/IgnoreNext").InnerText)
            Model.Backup.Location = XmlDoc.SelectSingleNode("Setting/Backup/Location").InnerText
            Model.Database.Server = XmlDoc.SelectSingleNode("Setting/Database/Server").InnerText
            Model.Database.Name = XmlDoc.SelectSingleNode("Setting/Database/Name").InnerText
            Model.Database.Username = XmlDoc.SelectSingleNode("Setting/Database/Username").InnerText
            Model.Database.Password = XmlDoc.SelectSingleNode("Setting/Database/Password").InnerText
            Model.General.Clean.Interval = CInt(XmlDoc.SelectSingleNode("Setting/General/Clean/Interval").InnerText)
            Model.General.Release.RefreshBlockedRegistryInterval = CInt(XmlDoc.SelectSingleNode("Setting/General/Release/RefreshBlockedRegistryInterval").InnerText)
            Model.General.Release.ReleaseBlockedRegisterInterval = CInt(XmlDoc.SelectSingleNode("Setting/General/Release/ReleaseBlockedRegisterInterval").InnerText)
            Model.General.Evaluation.DaysBeforeMaintenanceAlert = CInt(XmlDoc.SelectSingleNode("Setting/General/Evaluation/DaysBeforeMaintenanceAlert").InnerText)
            Model.General.Evaluation.DaysBeforeVisitAlert = CInt(XmlDoc.SelectSingleNode("Setting/General/Evaluation/DaysBeforeVisitAlert").InnerText)
            Model.General.Evaluation.MonthsBeforeRecordDeletion = CInt(XmlDoc.SelectSingleNode("Setting/General/Evaluation/MonthsBeforeRecordDeletion").InnerText)
            Model.General.User.DefaultPassword = XmlDoc.SelectSingleNode("Setting/General/User/DefaultPassword").InnerText
            Model.Support.EnableSSL = CBool(XmlDoc.SelectSingleNode("Setting/Support/EnableSSL").InnerText)
            Model.Support.Email = XmlDoc.SelectSingleNode("Setting/Support/Email").InnerText
            Model.Support.SMTPServer = XmlDoc.SelectSingleNode("Setting/Support/SMTPServer").InnerText
            Model.Support.Port = CInt(XmlDoc.SelectSingleNode("Setting/Support/Port").InnerText)
            Model.Support.Password = XmlDoc.SelectSingleNode("Setting/Support/Password").InnerText
            Model.Cloud.ManagerDB.ProjectID = XmlDoc.SelectSingleNode("Setting/Cloud/ManagerCloud/ProjectId").InnerText
            Model.Cloud.ManagerDB.JsonCredentials = XmlDoc.SelectSingleNode("Setting/Cloud/ManagerCloud/JsonCredentials").InnerText
            Model.Cloud.CustomerDB.ProjectID = XmlDoc.SelectSingleNode("Setting/Cloud/CustomerCloud/ProjectId").InnerText
            Model.Cloud.CustomerDB.JsonCredentials = XmlDoc.SelectSingleNode("Setting/Cloud/CustomerCloud/JsonCredentials").InnerText
            Model.Cloud.CustomerDB.SyncInterval = XmlDoc.SelectSingleNode("Setting/Cloud/CustomerCloud/SyncInterval").InnerText
            Model.Cloud.Storage.BucketName = XmlDoc.SelectSingleNode("Setting/Cloud/Storage/BucketName").InnerText
            Model.Cloud.Storage.JsonCredentials = XmlDoc.SelectSingleNode("Setting/Cloud/Storage/JsonCredentials").InnerText
            Model.Cloud.Synchronization.CloudMaxOperation = CLng(XmlDoc.SelectSingleNode("Setting/Cloud/Synchronization/CloudMaxOperation").InnerText)
            Model.Cloud.Synchronization.CloudOperationCount = CLng(XmlDoc.SelectSingleNode("Setting/Cloud/Synchronization/CloudOperationCount").InnerText)
            Model.Cloud.Synchronization.CloudLastSyncID = CLng(XmlDoc.SelectSingleNode("Setting/Cloud/Synchronization/CloudLastSyncID").InnerText)
            Model.LastExecution.Backup = CDate(XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Backup").InnerText)
            Model.LastExecution.Clean = CDate(XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Clean").InnerText)
            Model.LastExecution.Release = CDate(XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Release").InnerText)
            Model.LastExecution.Cloud = CDate(XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Cloud").InnerText)
            Model.LastExecution.CloudDataSended = CDate(XmlDoc.SelectSingleNode("Setting/LastExecutionDates/CloudDataSended").InnerText)
            Return Model
        Else
            Throw New Exception("Setting File Not Found, Run ManagerAgent to create.")
        End If
    End Function
    Public Function Save(Model As SettingModel) As SettingModel
        Dim XmlStr As String
        Dim XmlDoc As XmlDocument
        XmlStr = File.ReadAllText(ApplicationPaths.SettingFile)
        XmlStr = Cryptography.Decrypt(XmlStr, _Key)
        XmlDoc = New XmlDocument
        XmlDoc.LoadXml(XmlStr)
        XmlDoc.SelectSingleNode("Setting/Company/Document").InnerText = Model.Company.Document
        XmlDoc.SelectSingleNode("Setting/Company/LogoLocation").InnerText = Model.Company.LogoLocation
        XmlDoc.SelectSingleNode("Setting/Company/Name").InnerText = Model.Company.Name
        XmlDoc.SelectSingleNode("Setting/Company/Shortname").InnerText = Model.Company.ShortName
        XmlDoc.SelectSingleNode("Setting/Company/CityDocument").InnerText = Model.Company.CityDocument
        XmlDoc.SelectSingleNode("Setting/Company/StateDocument").InnerText = Model.Company.StateDocument
        XmlDoc.SelectSingleNode("Setting/Company/Address/ZipCode").InnerText = Model.Company.Address.ZipCode
        XmlDoc.SelectSingleNode("Setting/Company/Address/Street").InnerText = Model.Company.Address.Street
        XmlDoc.SelectSingleNode("Setting/Company/Address/Number").InnerText = Model.Company.Address.Number
        XmlDoc.SelectSingleNode("Setting/Company/Address/Complement").InnerText = Model.Company.Address.Complement
        XmlDoc.SelectSingleNode("Setting/Company/Address/District").InnerText = Model.Company.Address.District
        XmlDoc.SelectSingleNode("Setting/Company/Address/City").InnerText = Model.Company.Address.City
        XmlDoc.SelectSingleNode("Setting/Company/Address/State").InnerText = Model.Company.Address.State
        XmlDoc.SelectSingleNode("Setting/Company/Contact/Phone1").InnerText = Model.Company.Contact.Phone1
        XmlDoc.SelectSingleNode("Setting/Company/Contact/Phone2").InnerText = Model.Company.Contact.Phone2
        XmlDoc.SelectSingleNode("Setting/Company/Contact/CellPhone").InnerText = Model.Company.Contact.CellPhone
        XmlDoc.SelectSingleNode("Setting/Company/Contact/Email").InnerText = Model.Company.Contact.Email
        XmlDoc.SelectSingleNode("Setting/Company/Contact/Facebook").InnerText = Model.Company.Contact.Facebook
        XmlDoc.SelectSingleNode("Setting/Company/Contact/Instagram").InnerText = Model.Company.Contact.Instagram
        XmlDoc.SelectSingleNode("Setting/Company/Contact/Linkedin").InnerText = Model.Company.Contact.Linkedin
        XmlDoc.SelectSingleNode("Setting/Company/Contact/Site").InnerText = Model.Company.Contact.Site
        XmlDoc.SelectSingleNode("Setting/Backup/Monday").InnerText = CStr(Model.Backup.Monday)
        XmlDoc.SelectSingleNode("Setting/Backup/Tuesday").InnerText = CStr(Model.Backup.Tuesday)
        XmlDoc.SelectSingleNode("Setting/Backup/Wednesday").InnerText = CStr(Model.Backup.Wednesday)
        XmlDoc.SelectSingleNode("Setting/Backup/Thursday").InnerText = CStr(Model.Backup.Thursday)
        XmlDoc.SelectSingleNode("Setting/Backup/Friday").InnerText = CStr(Model.Backup.Friday)
        XmlDoc.SelectSingleNode("Setting/Backup/Saturday").InnerText = CStr(Model.Backup.Saturday)
        XmlDoc.SelectSingleNode("Setting/Backup/Sunday").InnerText = CStr(Model.Backup.Sunday)
        XmlDoc.SelectSingleNode("Setting/Backup/Time").InnerText = $"{Model.Backup.Time.Hours.ToString.PadLeft(2, "0")}:{Model.Backup.Time.Minutes.ToString.PadLeft(2, "0")}:{Model.Backup.Time.Seconds.ToString.PadLeft(2, "0")}"
        XmlDoc.SelectSingleNode("Setting/Backup/Keep").InnerText = CStr(Model.Backup.Keep)
        XmlDoc.SelectSingleNode("Setting/Backup/IgnoreNext").InnerText = CStr(Model.Backup.IgnoreNext)
        XmlDoc.SelectSingleNode("Setting/Backup/Location").InnerText = Model.Backup.Location
        XmlDoc.SelectSingleNode("Setting/Database/Server").InnerText = Model.Database.Server
        XmlDoc.SelectSingleNode("Setting/Database/Name").InnerText = Model.Database.Name
        XmlDoc.SelectSingleNode("Setting/Database/Username").InnerText = Model.Database.Username
        XmlDoc.SelectSingleNode("Setting/Database/Password").InnerText = Model.Database.Password
        XmlDoc.SelectSingleNode("Setting/General/Clean/Interval").InnerText = CStr(Model.General.Clean.Interval)
        XmlDoc.SelectSingleNode("Setting/General/Release/RefreshBlockedRegistryInterval").InnerText = CStr(Model.General.Release.RefreshBlockedRegistryInterval)
        XmlDoc.SelectSingleNode("Setting/General/Release/ReleaseBlockedRegisterInterval").InnerText = CStr(Model.General.Release.ReleaseBlockedRegisterInterval)
        XmlDoc.SelectSingleNode("Setting/General/Evaluation/DaysBeforeMaintenanceAlert").InnerText = CStr(Model.General.Evaluation.DaysBeforeMaintenanceAlert)
        XmlDoc.SelectSingleNode("Setting/General/Evaluation/DaysBeforeVisitAlert").InnerText = CStr(Model.General.Evaluation.DaysBeforeVisitAlert)
        XmlDoc.SelectSingleNode("Setting/General/Evaluation/MonthsBeforeRecordDeletion").InnerText = CStr(Model.General.Evaluation.MonthsBeforeRecordDeletion)
        XmlDoc.SelectSingleNode("Setting/General/User/DefaultPassword").InnerText = Model.General.User.DefaultPassword
        XmlDoc.SelectSingleNode("Setting/Support/EnableSSL").InnerText = CStr(Model.Support.EnableSSL)
        XmlDoc.SelectSingleNode("Setting/Support/Email").InnerText = Model.Support.Email
        XmlDoc.SelectSingleNode("Setting/Support/SMTPServer").InnerText = Model.Support.SMTPServer
        XmlDoc.SelectSingleNode("Setting/Support/Port").InnerText = CStr(Model.Support.Port)
        XmlDoc.SelectSingleNode("Setting/Support/Password").InnerText = Model.Support.Password
        XmlDoc.SelectSingleNode("Setting/Cloud/ManagerCloud/ProjectId").InnerText = Model.Cloud.ManagerDB.ProjectID
        XmlDoc.SelectSingleNode("Setting/Cloud/ManagerCloud/JsonCredentials").InnerText = Model.Cloud.ManagerDB.JsonCredentials
        XmlDoc.SelectSingleNode("Setting/Cloud/CustomerCloud/ProjectId").InnerText = Model.Cloud.CustomerDB.ProjectID
        XmlDoc.SelectSingleNode("Setting/Cloud/CustomerCloud/JsonCredentials").InnerText = Model.Cloud.CustomerDB.JsonCredentials
        XmlDoc.SelectSingleNode("Setting/Cloud/CustomerCloud/SyncInterval").InnerText = Model.Cloud.CustomerDB.SyncInterval
        XmlDoc.SelectSingleNode("Setting/Cloud/Storage/BucketName").InnerText = Model.Cloud.Storage.BucketName
        XmlDoc.SelectSingleNode("Setting/Cloud/Storage/JsonCredentials").InnerText = Model.Cloud.Storage.JsonCredentials
        XmlDoc.SelectSingleNode("Setting/Cloud/Synchronization/CloudMaxOperation").InnerText = CLng(Model.Cloud.Synchronization.CloudMaxOperation).ToString
        XmlDoc.SelectSingleNode("Setting/Cloud/Synchronization/CloudOperationCount").InnerText = CLng(Model.Cloud.Synchronization.CloudOperationCount).ToString
        XmlDoc.SelectSingleNode("Setting/Cloud/Synchronization/CloudLastSyncID").InnerText = CLng(Model.Cloud.Synchronization.CloudLastSyncID).ToString
        XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Backup").InnerText = Model.LastExecution.Backup.ToString("yyyy-MM-dd HH:mm:ss")
        XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Clean").InnerText = Model.LastExecution.Clean.ToString("yyyy-MM-dd HH:mm:ss")
        XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Release").InnerText = Model.LastExecution.Release.ToString("yyyy-MM-dd HH:mm:ss")
        XmlDoc.SelectSingleNode("Setting/LastExecutionDates/Cloud").InnerText = Model.LastExecution.Cloud.ToString("yyyy-MM-dd HH:mm:ss")
        XmlDoc.SelectSingleNode("Setting/LastExecutionDates/CloudDataSended").InnerText = Model.LastExecution.CloudDataSended.ToString("yyyy-MM-dd HH:mm:ss")
        Dim Builder As New StringBuilder()
        Dim Settings As New XmlWriterSettings()
        Settings.Indent = True
        Settings.IndentChars = vbTab
        Settings.NewLineOnAttributes = False
        Using writer As XmlWriter = XmlWriter.Create(Builder, Settings)
            XmlDoc.Save(writer)
        End Using
        XmlStr = Cryptography.Encrypt(Builder.ToString(), _Key)
        File.WriteAllText(ApplicationPaths.SettingFile, XmlStr)
        Return Model
    End Function
End Class
