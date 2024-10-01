Imports System.IO

Public Class UcChoseLocation
    Private _ManagerDirectory As String
    Public Sub New(ManagerDirectory As String)
        InitializeComponent()
        _ManagerDirectory = ManagerDirectory
    End Sub
    Private Sub BtnAgentDir_Click(sender As Object, e As EventArgs) Handles BtnAgentDir.Click
        If FbdAgentDir.ShowDialog = DialogResult.OK Then
            If File.Exists(Path.Combine(FbdAgentDir.SelectedPath, "ManagerAgent.exe")) Then
                File.WriteAllText(Path.Combine(_ManagerDirectory, "AgentLocation.txt"), FbdAgentDir.SelectedPath)
                MessageBox.Show("A configuração foi salva, o sistema será reiniciado.")
                Application.Restart()
            Else
                MessageBox.Show("O caminho selecionado não é válido.", "Caminho Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class
