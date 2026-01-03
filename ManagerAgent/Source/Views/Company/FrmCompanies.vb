Imports ManagerCore
Imports CoreSuite.Infrastructure
Public Class FrmCompanies
    Private Sub OpenCompany(Model As CompanyModel)
        Using Form As New FrmCompany(Model)
            Form.ShowDialog()
        End Using
    End Sub

    Private Sub FrmCompanies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Tile As UcCompanyTile
        Dim Companies As List(Of CompanyModel) = Locator.GetInstance(Of CompanyService).LoadAll()
        For Each Company As CompanyModel In Companies
            Tile = New UcCompanyTile(Company) With {
                .OnClickAction = AddressOf OpenCompany
            }
            FlpPrivilege.Controls.Add(Tile)
        Next Company
    End Sub

    Private Sub RefreshCompanies()
        Throw New NotImplementedException
    End Sub

    Private Sub RegisterCompany_Click(sender As Object, e As EventArgs) Handles RegisterCompany.Click
        Using Form As New FrmCompany(New CompanyModel())
            Form.ShowDialog()
        End Using
        RefreshCompanies()
    End Sub

    Private Sub EditCompany_Click(sender As Object, e As EventArgs) Handles EditCompany.Click
        Dim SelectedTile = FlpPrivilege.Controls.OfType(Of UcCompanyTile).ToList().First(Function(x) x.IsSelected)
        SelectedTile.OnClickAction?.Invoke(SelectedTile.Company)
    End Sub
End Class