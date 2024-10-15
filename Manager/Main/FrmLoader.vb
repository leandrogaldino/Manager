Imports ManagerCore

Public Class FrmLoader
    Private _Message As String

    Public Sub New(Optional Message As String = "Carregando")
        InitializeComponent()
        _Message = Message
    End Sub
    Private Async Function InitializeLoader() As Task
        Await WbLoader.EnsureCoreWebView2Async(Nothing)
        Dim FileName As String = Util.GetFilename(".html")
        Dim HtmlTempPath As String = IO.Path.Combine(ApplicationPaths.ManagerTempDirectory, FileName)
        IO.File.WriteAllText(HtmlTempPath, My.Resources.Loading.Replace("@LoadingMessage", _Message))
        WbLoader.CoreWebView2.Navigate("file:///" & HtmlTempPath)
    End Function

    Private Async Sub FrmLoader_Load(sender As Object, e As EventArgs) Handles Me.Load
        Await InitializeLoader()
    End Sub
End Class