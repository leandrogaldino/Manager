Imports ManagerCore

Public Class FrmAbout
    Public Sub New(License As LicenseModel, RemoteCredentialsService As RemoteDbCredentialsService)
        InitializeComponent()
        LblDocument.Text = $"Documento: {License.CustomerDocument}"
        LblName.Text = $"Nome: {License.CustomerName}"
        LblExpirationDate.Text = $"Expira em: {License.ExpirationDate}"
        Dim RemoteCredentials = RemoteCredentialsService.Load(RemoteDatabaseType.Customer)
        Dim ProjectID = RemoteCredentials.ProjectID
        LblCloudBase.Text = $"Base Cloud: {ProjectID}"
    End Sub
End Class