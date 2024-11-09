Imports System.Net.Mail
Imports ControlLibrary
Imports ControlLibrary.Utility
Imports ManagerCore

Public Class FrmUserEmail
    Private _UserForm As FrmUser
    Private _User As User
    Private _UserEmail As UserEmail
    Private _Deleting As Boolean
    Private _Loading As Boolean
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
    Public Sub New(User As User, Email As UserEmail, UserForm As FrmUser)
        InitializeComponent()
        _User = User
        _UserEmail = Email
        _UserForm = UserForm
        LoadForm()
        DgvNavigator.DataGridView = _UserForm.DgvEmail
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privileges.SeveralLogAccess
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then
                    DgvNavigator.CancelNextMove = True
                End If
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        If _UserForm.DgvEmail.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _UserEmail = _User.Emails.Single(Function(x) x.Order = _UserForm.DgvEmail.SelectedRows(0).Cells("Order").Value)
            LoadForm()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not PreSave() Then e.Cancel = True
                End If
            End If
            _Deleting = False
        End If
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Insert And e.Control Then
            If BtnInclude.Enabled Then BtnInclude.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Delete And e.Control Then
            If BtnDelete.Enabled Then BtnDelete.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _UserEmail = New UserEmail()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _UserForm.DgvEmail.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _UserEmail = _User.Emails.Single(Function(x) x.Order = _UserForm.DgvEmail.SelectedRows(0).Cells("Order").Value)
                _User.Emails.Remove(_UserEmail)
                _User.Emails.FillDataGridView(_UserForm.DgvEmail)
                _UserForm.DgvEmailLayout.Load()
                _Deleting = True
                Dispose()
                _UserForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.UserEmail, _UserEmail.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
        Dim Model As New EmailModel
        Dim UserEmail As New UserEmail
        UserEmail.EnableSSL = CbxEnableSSL.Checked
        UserEmail.Email = TxtEmail.Text.Trim
        UserEmail.SmtpServer = TxtSmtpServer.Text.Trim
        UserEmail.Port = DbxPort.Text
        UserEmail.Password = Cryptography.Encrypt(TxtPassword.Text, Locator.GetInstance(Of CryptoKeyService).ReadCryptoKey())
        Model.Subject = "Gerenciador - Teste"
        Model.Body = "{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1046{\fonttbl{\f0\fnil\fcharset0 Century Gothic;}{\f1\fnil\fcharset0 Calibri;}}{\*\generator Riched20 10.0.19041}\viewkind4\uc1 \pard\sa200\sl276\slmult1\b\f0\fs24\lang22 E-Mail de teste enviado pelo Gerenciador.\b0\f1\fs22\par}"
        Try
            Cursor = Cursors.WaitCursor
            Email.Send(UserEmail, Model, {New MailAddress(UserEmail.Email)}.ToList, Nothing, Nothing, Nothing)
            CMessageBox.Show("E-mail enviado com sucesso.", CMessageBoxType.Done)
        Catch ex As Exception
            CMessageBox.Show("ERRO US004", "Ocorreu um erro ao enviar o e-mail.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CbxIsMainEmail_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIsMainEmail.CheckedChanged, CbxEnableSSL.CheckedChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged, TxtSmtpServer.TextChanged, DbxPort.TextChanged, TxtPassword.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxCheckedChanged(sender As Object, e As EventArgs) Handles CbxIsMainEmail.CheckedChanged, CbxEnableSSL.CheckedChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _UserEmail.Order
        LblCreationValue.Text = _UserEmail.Creation
        CbxIsMainEmail.Checked = _UserEmail.IsMainEmail
        CbxEnableSSL.Checked = _UserEmail.EnableSSL
        TxtEmail.Text = _UserEmail.Email
        TxtSmtpServer.Text = _UserEmail.SmtpServer
        DbxPort.Text = _UserEmail.Port
        TxtPassword.Text = Cryptography.Decrypt(_UserEmail.Password, Locator.GetInstance(Of CryptoKeyService).ReadCryptoKey())
        If _UserEmail.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        TxtEmail.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtEmail.Text) Then
            EprValidation.SetError(TxtEmail, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblEmail, ErrorIconAlignment.MiddleRight)
            TxtEmail.Select()
            Return False
        ElseIf Not IsValidEmail(TxtEmail.Text) Then
            EprValidation.SetError(LblEmail, "E-Mail inválido.")
            EprValidation.SetIconAlignment(LblEmail, ErrorIconAlignment.MiddleRight)
            TxtEmail.Select()
            Return False
        ElseIf String.IsNullOrEmpty(TxtSmtpServer.Text) Then
            EprValidation.SetError(LblSmtpServer, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblSmtpServer, ErrorIconAlignment.MiddleRight)
            TxtSmtpServer.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtEmail.Text = TxtEmail.Text.Trim
        TxtSmtpServer.Text = TxtSmtpServer.Text.Trim
        If IsValidFields() Then
            If _UserEmail.IsSaved Then
                _User.Emails.Single(Function(x) x.Order = _UserEmail.Order).IsMainEmail = CbxIsMainEmail.Checked
                _User.Emails.Single(Function(x) x.Order = _UserEmail.Order).EnableSSL = CbxEnableSSL.Checked
                _User.Emails.Single(Function(x) x.Order = _UserEmail.Order).Email = TxtEmail.Text
                _User.Emails.Single(Function(x) x.Order = _UserEmail.Order).SmtpServer = TxtSmtpServer.Text
                _User.Emails.Single(Function(x) x.Order = _UserEmail.Order).Port = DbxPort.Text
                _User.Emails.Single(Function(x) x.Order = _UserEmail.Order).Password = Cryptography.Encrypt(TxtPassword.Text, Locator.GetInstance(Of CryptoKeyService).ReadCryptoKey())
            Else
                _UserEmail = New UserEmail()
                _UserEmail.IsMainEmail = CbxIsMainEmail.Checked
                _UserEmail.EnableSSL = CbxEnableSSL.Checked
                _UserEmail.Email = TxtEmail.Text
                _UserEmail.SmtpServer = TxtSmtpServer.Text
                _UserEmail.Port = DbxPort.Text
                _UserEmail.Password = Cryptography.Encrypt(TxtPassword.Text, Locator.GetInstance(Of CryptoKeyService).ReadCryptoKey())
                _UserEmail.IsSaved = True
                _User.Emails.Add(_UserEmail)
            End If
            If CbxIsMainEmail.Checked Then
                For Each Email As UserEmail In _User.Emails
                    If Email.Order <> _UserEmail.Order Then
                        Email.IsMainEmail = False
                    End If
                Next Email
            End If
            _User.Emails.FillDataGridView(_UserForm.DgvEmail)
            LblOrderValue.Text = _UserEmail.Order
            _UserForm.DgvEmailLayout.Load()
            BtnSave.Enabled = False
            If _UserEmail.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _UserForm.DgvEmail.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _UserEmail.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _UserForm.EprValidation.Clear()
            _UserForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
End Class