Public Class FrmConfigurationWizard
    Private _Pages As New List(Of ConfigurationPageModel)
    Private _SelectedPage As ConfigurationPageModel
    Public Sub New()
        InitializeComponent()
        _Pages.Add(New ConfigurationPageModel With {
            .Index = 0,
            .Title = "License Agreement",
            .Description = "Please read the license agreement carefully before proceeding.",
            .Page = New UcLicense() With {
                .OnSave = Sub()
                          End Sub,
                .OnValidade = Sub()
                                  MessageBox.Show("License validated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                              End Sub
            }
        })
        SelectPage(0)
    End Sub
    Public Sub SelectPage(Index As Integer)
        Dim Page = _Pages.FirstOrDefault(Function(p) p.Index = Index)
        If Page IsNot Nothing Then
            _SelectedPage = Page
            LblTitle.Text = Page.Title
            LblDescription.Text = Page.Description
            PnPage.Controls.Clear()
            PnPage.Controls.Add(Page.Page)
        End If
    End Sub

End Class



