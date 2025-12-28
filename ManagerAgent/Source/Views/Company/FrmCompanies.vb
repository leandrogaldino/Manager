Public Class FrmCompanies


    Private Sub OpenCompany(Model As CompanyModel)
        Using Form As New FrmCompany(Model)
            Form.ShowDialog()
        End Using
    End Sub

    Private Sub FrmCompanies_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ct As UcCompanyTile

        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Tech Solutions",
            .Document = "34.567.890/0001-12",
            .Address = "Rio de Janeiro - RJ",
            .LogoFileName = "C:\Users\leand\Desktop\Captura de tela 2025-10-18 162648.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Reicol Comércio",
            .Document = "12.764.271/0001-00",
            .Address = "Goiânia - GO",
            .LogoFileName = "reicol.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Nexor Sistemas Ltda",
            .Document = "45.892.113/0001-42",
            .Address = "São Paulo - SP",
            .LogoFileName = "nexor.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Alfa Distribuidora",
            .Document = "09.331.764/0001-85",
            .Address = "Campinas - SP",
            .LogoFileName = "alfa.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Horizonte Tecnologia",
            .Document = "33.508.921/0001-10",
            .Address = "Belo Horizonte - MG",
            .LogoFileName = "horizonte.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Prime Solutions",
            .Document = "61.774.205/0001-67",
            .Address = "Curitiba - PR",
            .LogoFileName = "prime.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Solaris Indústria",
            .Document = "28.119.450/0001-03",
            .Address = "Joinville - SC",
            .LogoFileName = "solaris.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


        ct = New UcCompanyTile(New CompanyModel() With {
            .Name = "Vértice Comércio e Serviços",
            .Document = "74.902.388/0001-91",
            .Address = "Porto Alegre - RS",
            .LogoFileName = "vertice.png"
        })
        ct.OnClickAction = AddressOf OpenCompany
        FlpPrivilege.Controls.Add(ct)


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