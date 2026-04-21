Imports ManagerCore
Imports CoreSuite.Infrastructure
Public Class FrmCompanies
    Private ReadOnly _Service As CompanyService
    Private _SelectedTile As UcCompanyTile
    Public Sub New(Service As CompanyService)
        InitializeComponent()
        _Service = Service
    End Sub

    Private Sub OpenCompany(Model As CompanyModel)
        Using Form As New FrmCompany(_Service, Model)
            Form.ShowDialog()
        End Using

    End Sub

    Private Sub FrmCompanies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCompanies()
    End Sub

    Private Sub RefreshCompany()
        FlpPrivilege.Controls.OfType(Of UcCompanyTile).ToList().First(Function(x) x.IsSelected).Reload()
    End Sub


    Private Sub LoadCompanies()
        Debug.Print("Refreshing companies...")
        Dim Tile As UcCompanyTile
        Dim Companies As List(Of CompanyModel) = ManagerCore.Util.AsyncLock(Function() Locator.GetInstance(Of CompanyService).LoadAllAsync())
        Companies = Companies.OrderByDescending(Function(c) c.ID).ToList()
        FlpPrivilege.Controls.Clear()

        For Each Company As CompanyModel In Companies
            Tile = New UcCompanyTile(Company) With {
                .OnClickAction = AddressOf OpenCompany
            }
            AddHandler Tile.ActionEnded, Sub() RefreshCompany()
            FlpPrivilege.Controls.Add(Tile)
        Next Company
    End Sub

    Private Sub RegisterCompany_Click(sender As Object, e As EventArgs) Handles BtnIncludeCompany.Click
        Using Form As New FrmCompany(_Service, New CompanyModel())
            Form.ShowDialog()
        End Using
    End Sub

    Private Sub EditCompany_Click(sender As Object, e As EventArgs) Handles BtnEditCompany.Click
        _SelectedTile = FlpPrivilege.Controls.OfType(Of UcCompanyTile).ToList().FirstOrDefault(Function(x) x.IsSelected)
        _SelectedTile?.OnClickAction?.Invoke(_SelectedTile.Company)
    End Sub
End Class