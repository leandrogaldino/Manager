Public Class FrmLoader
    Public Sub New(Gif As Image)
        InitializeComponent()
        Viewer.GifImage = Gif
        Viewer.StartAnimation()
        Invalidate()
    End Sub
End Class