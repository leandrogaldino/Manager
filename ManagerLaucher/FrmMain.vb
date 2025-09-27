Imports System.IO

Public Class FrmMain
    Private _ManagerDirectory As String = Directory.GetCurrentDirectory()
    Private _AgentDirectory As String
    Private _AgentLocationFile As String = Path.Combine(_ManagerDirectory, ".AgentLocation")
    Private _DeployDirectory As String
    Private _UcChose As UcChoseLocation
    Private _UcType As UcTypeLocation
    Private _UcUpdate As UcChekUpdate
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Application.Exit()
    End Sub
    Private Sub TimerRun_Tick(sender As Object, e As EventArgs) Handles TimerRun.Tick
        TimerRun.Stop()
        UcSplash.Visible = False
        If File.Exists(_AgentLocationFile) Then
            _AgentDirectory = File.ReadAllText(_AgentLocationFile)
            If Not String.IsNullOrEmpty(_AgentDirectory) AndAlso File.Exists(_AgentLocationFile) Then
                _DeployDirectory = Path.Combine(_AgentDirectory, "Files", "Deploy")
                BtnClose.Visible = False
                If Util.HasUpdate(_DeployDirectory, _ManagerDirectory) Then
                    _UcUpdate = New UcChekUpdate(_DeployDirectory, _ManagerDirectory) With {
                        .Dock = DockStyle.Fill
                    }
                    PnContent.Controls.Add(_UcUpdate)
                    _UcUpdate.CheckUpdate()
                Else
                    Try
                        Process.Start(Path.Combine(_ManagerDirectory, "App", "Manager.exe"))
                    Catch ex As Exception
                        MessageBox.Show($"Não foi possível iniciar o sistema{vbNewLine}Erro: {ex.Message}")
                    Finally
                        Application.Exit()
                    End Try
                End If
            Else
                RbtChose.Visible = True
                RbtType.Visible = True
                _UcType = New UcTypeLocation(_ManagerDirectory) With {
                    .Dock = DockStyle.Fill
                }
                _UcChose = New UcChoseLocation(_ManagerDirectory) With {
                    .Dock = DockStyle.Fill
                }
                PnContent.Controls.Add(_UcChose)
                PnContent.Controls.Add(_UcType)
                _UcType.BringToFront()
                AddHandler RbtChose.CheckedChanged,
                    Sub()
                        If RbtChose.Checked Then
                            _UcChose.BringToFront()
                        Else
                            _UcType.BringToFront()
                        End If
                    End Sub
            End If
        Else
            RbtChose.Visible = True
            RbtType.Visible = True
            _UcChose = New UcChoseLocation(_ManagerDirectory) With {
                .Dock = DockStyle.Fill
            }
            _UcType = New UcTypeLocation(_ManagerDirectory) With {
                .Dock = DockStyle.Fill
            }
            PnContent.Controls.Add(_UcChose)
            PnContent.Controls.Add(_UcType)
            _UcType.BringToFront()
            AddHandler RbtChose.CheckedChanged,
        Sub()
            If RbtChose.Checked Then _UcChose.BringToFront()
        End Sub
        End If
    End Sub
End Class