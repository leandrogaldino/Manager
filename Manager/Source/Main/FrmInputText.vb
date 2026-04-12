
Imports ControlLibrary.Extensions
Public Class FrmInputText
    Public Sub New(Title As String, Caption As String)
        InitializeComponent()
        Text = Title
        LblCaption.Text = Caption
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        TxtText.Text = TxtText.Text.ToUnaccented()
        If IsValidFields() Then
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub TxtReason_TextChanged(sender As Object, e As EventArgs) Handles TxtText.TextChanged
        EprValidation.Clear()
        BtnSave.Enabled = True
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(TxtText.Text) Then
            EprValidation.SetError(TxtText, "Campo obrigatório.")
            EprValidation.SetIconAlignment(TxtText, ErrorIconAlignment.MiddleRight)
            TxtText.Select()
            Return False
        End If
        Return True
    End Function
    Public Function GetText() As String
        Return TxtText.Text
    End Function
End Class