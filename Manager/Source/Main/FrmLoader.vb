Public Class FrmLoader
    Public Sub New(Optional Message As String = "Carregando")
        InitializeComponent()
        LblMessage.Text = Message
        AnimatedBox.LoadGif(My.Resources.Downloading)
        AnimatedBox.StartAnimation()
    End Sub
End Class