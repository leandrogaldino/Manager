Imports System.ComponentModel
Imports System.IO
Public Class UcChekUpdate
    Private _AgentDirectory As String
    Private _ManagerDirectory As String
    Public Sub New(DeployDirectory As String, ManagerDirectory As String)
        InitializeComponent()
        _AgentDirectory = DeployDirectory
        _ManagerDirectory = ManagerDirectory
    End Sub
    Public Sub CheckUpdate()
        If Util.IsSingleInstanced Then
            If Not BwUpdate.IsBusy Then
                BwUpdate.RunWorkerAsync()
            End If
        End If
    End Sub
    Private Sub BwUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles BwUpdate.DoWork
        Dim Updater As New Updater(New DirectoryInfo(_AgentDirectory), New DirectoryInfo(_ManagerDirectory))
        AddHandler Updater.UpdateProgressChanged,
            Sub(USender As Object, UEvent As Updater.ProgressEventArgs)
                BwUpdate.ReportProgress(UEvent.PercentCompleted)
                Threading.Thread.Sleep(300)
            End Sub
        Updater.Update()
    End Sub
    Private Sub BwUpdate_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BwUpdate.ProgressChanged
        CpbUpdate.Value = e.ProgressPercentage
        LblProgress.Text = $"{e.ProgressPercentage}%"
    End Sub

    Private Sub BwUpdate_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwUpdate.RunWorkerCompleted
        CpbUpdate.Value = 100
        Process.Start(Path.Combine(_ManagerDirectory, "App", "Manager.exe"))
        Application.Exit()
    End Sub
End Class
