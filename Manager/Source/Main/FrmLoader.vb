Public Class FrmLoader
    Public Sub New(Optional Message As String = "Carregando")
        InitializeComponent()
        LblMessage.Text = Message
        AnimatedBox.LoadGif(Image.FromFile("C:\Users\leand\Desktop\Loading.gif"))
        AnimatedBox.StartAnimation()
    End Sub
End Class