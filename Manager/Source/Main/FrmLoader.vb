Imports CefSharp
Public Class FrmLoader
    Public Sub New(Optional Message As String = "Carregando")
        InitializeComponent()
        WbLoader.LoadHtml(My.Resources.Loading.Replace("@LoadingMessage", Message), False)
    End Sub
End Class