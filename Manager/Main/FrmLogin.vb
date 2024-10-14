Imports System.IO
Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Imports ManagerCore
Imports System.Reflection
Public Class FrmLogin

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Locator.GetInstance(Of Session).ManagerVersion = $"Versão: {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileMajorPart}.{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileMinorPart}"
        LblVersion.Text = Locator.GetInstance(Of Session).ManagerVersion
        BtnLogin.Enabled = False
    End Sub


    <DebuggerStepThrough>
    Protected Overrides Sub DefWndProc(ByRef m As Message)
        Const _MouseButtonDown As Long = &HA1
        Const _MouseButtonUp As Long = &HA0
        Const _CloseButton As Long = 20
        If CLng(m.Msg) = _MouseButtonDown And Not m.WParam = _CloseButton Then
            If Opacity <> 0.5 Then Opacity = 0.5
        ElseIf CLng(m.Msg) = _MouseButtonUp Then
            If Opacity <> 1.0 Then Opacity = 1.0
        End If
        MyBase.DefWndProc(m)
    End Sub
    Private Sub TxtUser_Leave(sender As Object, e As EventArgs) Handles TxtUsername.Leave
        If TxtUsername.Text <> Nothing Then
            TxtUsername.Text = RemoveAccents(TxtUsername.Text)
        End If
    End Sub
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Cursor = Cursors.WaitCursor
        BtnLogin.Enabled = False
        Dim TypedPassword As String
        Dim DbPassword As String
        Dim FormChangePassword As FrmUserChangePassword

        Dim Session = Locator.GetInstance(Of Session)
        Dim License = Locator.GetInstance(Of LicenseService)
        Dim CryptoKey = Locator.GetInstance(Of CryptoKeyService)

        Try
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Using Com As New MySqlCommand(My.Resources.UserLoginSelect, Con)
                    Com.Parameters.AddWithValue("@username", TxtUsername.Text)
                    Con.Open()
                    Using Reader As MySqlDataReader = Com.ExecuteReader
                        If Reader.HasRows Then
                            Reader.Read()
                            TypedPassword = Cryptography.Encrypt(TxtPassword.Text, CryptoKey.ReadCryptoKey)
                            DbPassword = Reader.GetString(Reader.GetOrdinal("password"))
                            If TypedPassword = DbPassword Then
                                Try
                                    Session.User = New User().Load(Reader.GetInt64(Reader.GetOrdinal("id")), False)
                                    Session.Token = Guid.NewGuid.ToString.ToUpper()
                                    If Session.User.Status = SimpleStatus.Active Then
                                        If Not Session.User.RequestPassword Then
                                            SetupApp.SetupUserEnvironment()
                                            Try
                                                Session.LicenseResult = License.GetLocalLicense()
                                                If Session.LicenseResult.Success Then
                                                    Hide()
                                                    'FrmMain.Show()

                                                    Dim frm As New FrmEvaluationImport() : frm.Show()




                                                Else
                                                    Select Case Session.LicenseResult.Flag
                                                        Case LicenseMessages.OutdatedLocalLicenseKey
                                                            Session.LicenseResult = ManagerCore.Util.AsyncLock(Function() License.GetOnlineLicense(License.GetLocalLicenseKey, License.GetLocalLicenseToken))
                                                            If Session.LicenseResult.Success Then
                                                                FrmMain.Show()
                                                            Else
                                                                CMessageBox.Show(GetEnumDescription(Session.LicenseResult.Flag), CMessageBoxType.Warning)
                                                            End If
                                                        Case Else
                                                            CMessageBox.Show(GetEnumDescription(Session.LicenseResult.Flag), CMessageBoxType.Warning)
                                                    End Select
                                                End If
                                            Catch ex As Exception
                                                CMessageBox.Show("ERRO LN003", "Ocorreu um erro ao efetuar o login.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                                            End Try
                                        Else
                                            CMessageBox.Show("Será necessário alterar a sua senha.", CMessageBoxType.Information)
                                            FormChangePassword = New FrmUserChangePassword(Session.User)
                                            FormChangePassword.ShowDialog()
                                            TxtPassword.Clear()
                                            TxtPassword.Select()
                                        End If
                                    Else
                                        CMessageBox.Show("O usuário informado está inativo.", CMessageBoxType.Warning)
                                        TxtUsername.Text = Nothing
                                        TxtPassword.Text = Nothing
                                        TxtUsername.Select()
                                    End If
                                Catch ex As Exception
                                    CMessageBox.Show("ERRO LN001", "Ocorreu um erro ao efetuar o login.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                                End Try
                            Else
                                CMessageBox.Show("Senha incorreta.", CMessageBoxType.Warning)
                                TxtPassword.Text = Nothing
                                TxtPassword.Select()
                            End If
                        Else
                            CMessageBox.Show("O usuário não existe no banco de dados selecionado.", CMessageBoxType.Warning)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            CMessageBox.Show("ERRO LN002", "Ocorreu um erro ao efetuar o login.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            BtnLogin.Enabled = True
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub TxtUsername_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles TxtUsername.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If TxtPassword.Text = Nothing Then
                TxtPassword.Select()
            Else
                BtnLogin.PerformClick()
            End If
        End If
    End Sub
    Private Sub TxtPassword_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles TxtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If TxtUsername.Text = Nothing Then
                TxtUsername.Select()
            Else
                BtnLogin.PerformClick()
            End If
        End If
    End Sub
    Private Sub TxtUsername_TextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged
        TxtPassword.Text = Nothing
        If TxtUsername.Text <> Nothing And TxtPassword.Text <> Nothing Then
            BtnLogin.Enabled = True
        Else
            BtnLogin.Enabled = False
        End If
    End Sub
    Private Sub TxtUsername_Leave(sender As Object, e As EventArgs) Handles TxtUsername.Leave
        TxtUsername.Text = RemoveAccents(TxtUsername.Text)
    End Sub
    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtPassword.TextChanged
        If TxtUsername.Text <> Nothing And TxtPassword.Text <> Nothing Then
            BtnLogin.Enabled = True
        Else
            BtnLogin.Enabled = False
        End If
    End Sub

    Private Sub LblVersion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblVersion.LinkClicked
        Using Frm As New FrmUpdateNotes()
            Frm.ShowDialog()
        End Using
    End Sub
End Class