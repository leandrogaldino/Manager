Imports ManagerCore

Public Class UcLicense
    Private _IsValid As Boolean


    Public Property OnValidade As Action
    Public Property OnSave As Action




    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Message As String
        If _IsValid Then
            OnSave?.Invoke()
        Else
            Message = IsValid()
            If Message Is Nothing Then
                _IsValid = True
                BtnSave.Text = "Avançar"
                MessageBox.Show("Dados da base de licença validados com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                _IsValid = False
                BtnSave.Text = "Validar"
                MessageBox.Show(Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Function IsValid() As String
        Return Validation.ValidateLicense(New RemoteDbCredentialsModel With {
            .ApiKey = TxtApiKey.Text,
            .ProjectID = TxtProjectID.Text,
            .BucketName = TxtBucketName.Text,
            .Username = TxtUsername.Text,
            .Password = TxtPassword.Text
        })
    End Function

    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged, TxtProjectID.TextChanged, TxtPassword.TextChanged, TxtBucketName.TextChanged, TxtApiKey.TextChanged
        BtnSave.Text = "Validar"
        _IsValid = False
    End Sub
End Class
