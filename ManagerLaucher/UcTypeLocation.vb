Imports System.IO

Public Class UcTypeLocation
    Private _ManagerDirectory As String
    Public Sub New(ManagerDirectory As String)
        InitializeComponent()
        _ManagerDirectory = ManagerDirectory
    End Sub
    Private Sub BtnAgentDir_Click(sender As Object, e As EventArgs) Handles BtnAgentDir.Click
        If File.Exists(Path.Combine(TxtAgentDir.Text, "ManagerAgent.exe")) Then
            File.WriteAllText(Path.Combine(_ManagerDirectory, ".AgentLocation"), TxtAgentDir.Text)
            MessageBox.Show("A configuração foi salva, por favor inicie o sistema novamente.")
            Application.Exit()
        Else
            MessageBox.Show("O caminho selecionado não é válido.", "Caminho Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
