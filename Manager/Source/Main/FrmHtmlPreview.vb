Public Class FrmHtmlPreview
    Public Sub New(Model As EmailModel)
        InitializeComponent()
        WbPreview.Navigate(Model.CreateHtmlFile())
    End Sub
End Class