Public Class FrmCompany
    Public Sub New(Company As CompanyModel)


        InitializeComponent()

        TxtName.Text = Company.Name

    End Sub
End Class