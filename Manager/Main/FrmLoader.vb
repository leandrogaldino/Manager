Public Class FrmLoader
    Private _Message As String

    Public Sub New(Optional Message As String = "Carregando")
        InitializeComponent()
        _Message = Message
    End Sub



    Private Async Function InitializeLoader() As Task
        Await WbLoader.EnsureCoreWebView2Async(Nothing)
        Dim tempPath As String = System.IO.Path.GetTempPath()
        Dim htmlTempPath As String = System.IO.Path.Combine(tempPath, "Loading.html")
        IO.File.WriteAllText(htmlTempPath, My.Resources.Loading.Replace("@LoadingMessage", _Message))
        WbLoader.CoreWebView2.Navigate("file:///" & htmlTempPath)
    End Function

    Private Async Sub FrmLoader_Load(sender As Object, e As EventArgs) Handles Me.Load
        Await InitializeLoader()
    End Sub



End Class