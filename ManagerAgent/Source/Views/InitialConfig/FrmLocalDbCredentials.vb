Imports CoreSuite.Controls
Imports CoreSuite.Infrastructure
Imports ManagerCore

Public Class FrmLocalDbCredentials
    Private _LocalDbCredentialsService As LocalDbCredentialsService
    Public Sub New()
        InitializeComponent()
        _LocalDbCredentialsService = Locator.GetInstance(Of LocalDbCredentialsService)
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Message As String = ValidateCredentials()
        If Message = Nothing Then
            _LocalDbCredentialsService.Save(New LocalDbCredentialsModel With {
               .Server = TxtServer.Text,
               .Name = TxtName.Text,
               .Username = TxtUsername.Text,
               .Password = TxtPassword.Text
           })
            CMessageBox.Show("Sucesso", "Credenciais validadas com sucesso.", CMessageBoxType.Done)
            DialogResult = DialogResult.OK
        Else
            CMessageBox.Show("Erro", Message, CMessageBoxType.Error)
        End If
    End Sub
    Private Function ValidateCredentials() As String
        Dim Credentials = New LocalDbCredentialsModel With {
            .Server = TxtServer.Text,
            .Name = TxtName.Text,
            .Username = TxtUsername.Text,
            .Password = TxtPassword.Text
        }
        Dim Result = ManagerCore.Util.AsyncLock(Function() Util.TestLocalDbConnection(Credentials))
        If Not Result.Success Then Return Result.ErrorMessage
        Return Nothing
    End Function
End Class