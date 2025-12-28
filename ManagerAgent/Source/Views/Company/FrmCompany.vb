Imports ManagerCore
Public Class FrmCompany
    Private _Company As CompanyModel
    Private _Service As CompanyService
    Public Sub New(Company As CompanyModel)
        InitializeComponent()
        _Company = Company
        LoadData()
    End Sub

    Private Sub LoadData()
        ' Load company data into form fields
        Throw New NotImplementedException
    End Sub

    Private Sub UpdateData()
        ' Update company data from form fields
        Throw New NotImplementedException
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        UpdateData()
        _Service.Save(_Company)
    End Sub
End Class

