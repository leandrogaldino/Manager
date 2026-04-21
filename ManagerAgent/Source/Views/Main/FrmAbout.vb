Imports ManagerCore

Public Class FrmAbout
    Public Sub New(License As LicenseModel)
        InitializeComponent()
        LblDocument.Text = $"Documento: {License.CustomerDocument}"
        LblName.Text = $"Nome: {License.CustomerName}"
        LblExpirationDate.Text = $"Expira em: {License.ExpirationDate}"
    End Sub
End Class