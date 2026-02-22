Public Class FrmLoader
    Public Sub New(Image As Image, Optional Message As String = "Carregando")
        InitializeComponent()
        LblMessage.Text = Message
        AnimatedBox.LoadGif(Image)
        AnimatedBox.StartAnimation()
    End Sub
End Class