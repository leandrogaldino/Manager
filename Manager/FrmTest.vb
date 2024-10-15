Public Class FrmTest
    Private SecondPanelLocation As New Point(221, 12)
    Private ThirdPanelLocation As New Point(430, 12)

    Private Sub FrmTest_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Debug.Print(Width)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Width = 237
        Panel2.Visible = False
        Panel3.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = True
        Panel2.Location = SecondPanelLocation
        Panel3.Visible = False
        Width = 443
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Visible = False
        Panel3.Visible = True
        Panel3.Location = SecondPanelLocation
        Width = 443
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Visible = True
        Panel2.Location = SecondPanelLocation
        Panel3.Visible = True
        Panel3.Location = ThirdPanelLocation
        Width = 653
    End Sub
End Class


