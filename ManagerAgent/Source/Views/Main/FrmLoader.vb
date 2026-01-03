Public Class FrmLoader
    Public Sub New(Gif As Image)
        InitializeComponent()
        Viewer.LoadGif(Gif)
        Viewer.StartAnimation()
    End Sub
End Class