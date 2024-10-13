Public Class FrmLoader
    Private animatedImage As Image

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        animatedImage = Image.FromFile("C:\Users\leand\OneDrive\Desktop\loading.gif")
        PictureBox1.Image = animatedImage
        ImageAnimator.Animate(animatedImage, New EventHandler(AddressOf OnFrameChanged))
    End Sub

    Private Sub OnFrameChanged(sender As Object, e As EventArgs)
        PictureBox1.Invalidate() ' Redesenha o PictureBox
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        ImageAnimator.UpdateFrames(animatedImage) ' Atualiza o quadro atual do GIF
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ImageAnimator.StopAnimate(animatedImage, New EventHandler(AddressOf OnFrameChanged))
    End Sub
End Class