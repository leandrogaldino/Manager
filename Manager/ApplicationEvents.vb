Imports Microsoft.VisualBasic.ApplicationServices
Namespace My
    ' Os seguintes eventos estão disponíveis para MyApplication:
    ' Inicialização: Ocorre quando o aplicativo é iniciado, antes da criação do formulário de inicialização.
    ' Desligamento: Ocorre após todos os formulários de aplicativo serem fechados.  Esse evento não ocorrerá se o aplicativo for encerrado de forma anormal.
    ' UnhandledException: Ocorre se o aplicativo encontra uma exceção sem tratamento.
    ' StartupNextInstance: Ocorre durante a inicialização de um aplicativo de instância única quando o aplicativo já está ativo. 
    ' NetworkAvailabilityChanged: Ocorre quando a conexão de rede é conectada ou desconectada.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            SetupApp.SetupIO()
            SetupLocator.Setup()
            SetupSettings.Setup()
            SetupCMessageBox.SetupBeforeLogin()
            SetupApp.SetupDatabases()
            SetupQueriedBox.Setup()
            If Application.CommandLineArgs.Count > 0 Then
                If LCase(Application.CommandLineArgs(0)) = "-panels" Then
                    e.Cancel = True
                    Try
                        Using PanelForm As New Form
                            PanelForm.ShowIcon = True
                            PanelForm.ShowInTaskbar = True
                            PanelForm.WindowState = FormWindowState.Maximized
                            PanelForm.FormBorderStyle = FormBorderStyle.FixedSingle
                            PanelForm.Text = "Painel de Gerenciamento de Compressores"
                            Using PanelControl As New UcEvaluationManagementPanelGrid
                                PanelControl.BtnClose.Visible = False
                                PanelControl.BtnExport.Visible = False
                                PanelControl.Dock = DockStyle.Fill
                                PanelForm.Controls.Add(PanelControl)
                                PanelForm.ShowDialog()
                            End Using
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
        End Sub
    End Class
End Namespace
