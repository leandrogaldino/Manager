Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Imports System.IO
Imports ManagerCore
Imports ChinhDo.Transactions
Public Class FrmEmailSignature
    Private _EmailSignature As EmailSignature
    Private _EmailSignaturesForm As FrmEmailSignatures
    Private _EmailSignaturesGrid As DataGridView
    Private _Filter As EmailSignatureFilter
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _User As User
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(EmailSignature As EmailSignature, EmailSignaturesForm As FrmEmailSignatures)
        InitializeComponent()
        _EmailSignature = EmailSignature
        _EmailSignaturesForm = EmailSignaturesForm
        _EmailSignaturesGrid = _EmailSignaturesForm.DgvData
        _Filter = CType(_EmailSignaturesForm.PgFilter.SelectedObject, EmailSignatureFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(EmailSignature As EmailSignature)
        InitializeComponent()
        _EmailSignature = EmailSignature
        _User = Locator.GetInstance(Of Session).User
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblName.Top -= TsNavigation.Height
        TxtName.Top -= TsNavigation.Height
        PnEmailSignature.Top -= TsNavigation.Height
        MinimumSize = Nothing
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _EmailSignaturesGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _EmailSignature.ID
        LblCreationValue.Text = _EmailSignature.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _EmailSignature.Name
        WbPreview.DocumentText = Nothing
        If Not String.IsNullOrEmpty(_EmailSignature.Directory.CurrentDirectory) Then
            If Directory.Exists(_EmailSignature.Directory.CurrentDirectory) Then
                If File.Exists(Path.Combine(_EmailSignature.Directory.CurrentDirectory, "sign.html")) Then
                    WbPreview.Navigate(Path.Combine(_EmailSignature.Directory.CurrentDirectory, "sign.html"))
                End If
            End If
        End If
        Text = "Assinatura de E-Mail"
        BtnDelete.Enabled = _EmailSignature.ID > 0
        If _EmailSignature.LockInfo.IsLocked And Not _EmailSignature.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _EmailSignature.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _EmailSignature.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtName.Select()
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then
                    DgvNavigator.CancelNextMove = True
                End If
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            _EmailSignature.Load(_EmailSignaturesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO ES001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If BtnSave.Enabled Then
                    If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        If Not Save() Then e.Cancel = True
                    End If
                End If
            End If
            _Deleting = False
        End If
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _EmailSignature = New EmailSignature
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _EmailSignature.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _EmailSignature.LockInfo.IsLocked Or (_EmailSignature.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _EmailSignature.LockInfo.SessionToken) Then
                        _EmailSignature.Delete()
                        If _EmailSignaturesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _EmailSignaturesForm.DgvEmailSignaturesLayout.Load()
                            _EmailSignaturesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _EmailSignature.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                CMessageBox.Show("ERRO ES002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.EmailSignature, _EmailSignature.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
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
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TxtName.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        If _EmailSignature.LockInfo.IsLocked And _EmailSignature.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _EmailSignature.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _EmailSignature.Name = TxtName.Text
                    _EmailSignature.SaveChanges()
                    _EmailSignature.Lock()
                    LblIDValue.Text = _EmailSignature.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = True
                    If _EmailSignaturesForm IsNot Nothing Then
                        _Filter.Filter()
                        _EmailSignaturesForm.DgvEmailSignaturesLayout.Load()
                        Row = _EmailSignaturesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma assinatura cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO ES003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Return False
                Catch ex As Exception
                    CMessageBox.Show("ERRO ES004", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub BtnOpenSignature_Click(sender As Object, e As EventArgs) Handles BtnOpenSignature.Click
        Dim DirectoryPath As String
        Dim SelectedDirectory As DirectoryInfo
        Dim DirectorySize As Long
        Dim DirectoryManager As TxFileManager
        If FbdSignature.ShowDialog = DialogResult.OK Then
            DirectoryPath = TextHelper.GetRandomFileName()
            SelectedDirectory = New DirectoryInfo(FbdSignature.SelectedPath)
            If File.Exists(Path.Combine(SelectedDirectory.FullName, "sign.html")) Then
                SelectedDirectory.GetFiles.ToList.ForEach(Sub(x) DirectorySize += x.Length)
                DirectorySize = DirectorySize / 1024 / 1024
                If DirectorySize <= 1 Then
                    DirectoryManager = New TxFileManager(ApplicationPaths.ManagerTempDirectory)
                    DirectoryManager.CopyDirectory(SelectedDirectory.FullName, Path.Combine(ApplicationPaths.ManagerTempDirectory, DirectoryPath))
                    _EmailSignature.Directory.SetCurrentDirectory(Path.Combine(ApplicationPaths.ManagerTempDirectory, DirectoryPath))
                    If Not String.IsNullOrEmpty(_EmailSignature.Directory.CurrentDirectory) AndAlso Directory.Exists(_EmailSignature.Directory.CurrentDirectory) AndAlso File.Exists(Path.Combine(_EmailSignature.Directory.CurrentDirectory, "sign.html")) Then
                        Try
                            WbPreview.Navigate(Path.Combine(_EmailSignature.Directory.CurrentDirectory, "sign.html"))
                            BtnExportSignature.Enabled = True
                            EprValidation.Clear()
                            BtnSave.Enabled = True
                        Catch ex As Exception
                            CMessageBox.Show("ERRO ES005", "Ocorreu um erro ao carregar o documento.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                        End Try
                    End If
                Else
                    CMessageBox.Show("O diretório selecionado deve ter no máximo 1MB.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                End If
            Else
                CMessageBox.Show("O diretório selecionado não tem um arquivo sign.html.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
            End If
        End If
    End Sub

    Private Sub BtnExportSignature_Click(sender As Object, e As EventArgs) Handles BtnExportSignature.Click
        Dim DirectoryManager As TxFileManager
        If FbdSignature.ShowDialog() = DialogResult.OK Then
            DirectoryManager = New TxFileManager(ApplicationPaths.ManagerTempDirectory)
            If DirectoryManager.DirectoryExists(FbdSignature.SelectedPath) And DirectoryManager.DirectoryExists(_EmailSignature.Directory.CurrentDirectory) Then
                DirectoryManager.CopyDirectory(_EmailSignature.Directory.CurrentDirectory, Path.Combine(FbdSignature.SelectedPath, "Assinatura " & _EmailSignature.Name))
            End If
        End If
    End Sub
    Private Sub FrmRequest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _EmailSignature.Unlock()
    End Sub
End Class