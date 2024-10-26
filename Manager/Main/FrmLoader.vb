Imports CefSharp
Imports ManagerCore

Public Class FrmLoader
    Private _Message As String

    Public Async Function SetMessage(Message As String) As Task
        _Message = Message
        Await RefreshLoader()
        Await Task.Delay(1000)
    End Function

    Public Sub New(Optional Message As String = "Carregando")
        InitializeComponent()
        _Message = Message
    End Sub
    Private Async Function RefreshLoader() As Task

        Dim FileName As String = Util.GetFilename(".html")
        Dim HtmlTempPath As String = IO.Path.Combine(ApplicationPaths.ManagerTempDirectory, FileName)
        IO.File.WriteAllText(HtmlTempPath, My.Resources.Loading.Replace("@LoadingMessage", _Message))
        Await WbLoader.LoadUrlAsync("file:///" & HtmlTempPath)
    End Function

    Private Async Sub FrmLoader_Load(sender As Object, e As EventArgs) Handles Me.Load
        Await RefreshLoader()
    End Sub
End Class