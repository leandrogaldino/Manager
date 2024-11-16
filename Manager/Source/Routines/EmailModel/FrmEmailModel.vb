Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Imports System.Text
Public Class FrmEmailModel
    Private _EmailModel As EmailModel
    Private _EmailModelsForm As FrmEmailModels
    Private _EmailModelsGrid As DataGridView
    Private _Filter As EmailModelFilter
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
    Public Sub New(EmailModel As EmailModel, EmailModelsForm As FrmEmailModels)
        InitializeComponent()
        _EmailModel = EmailModel
        _EmailModelsForm = EmailModelsForm
        _EmailModelsGrid = _EmailModelsForm.DgvData
        _Filter = CType(_EmailModelsForm.PgFilter.SelectedObject, EmailModelFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(EmailModel As EmailModel)
        InitializeComponent()
        _EmailModel = EmailModel
        _User = Locator.GetInstance(Of Session).User
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        MinimumSize = Nothing
        Height -= TsNavigation.Height
        LblName.Top -= TsNavigation.Height
        TxtName.Top -= TsNavigation.Height
        LblSubject.Top -= TsNavigation.Height
        TxtSubject.Top -= TsNavigation.Height
        LblBody.Top -= TsNavigation.Height
        PnBody.Top -= TsNavigation.Height
        LblSignature.Top -= TsNavigation.Height
        CbxSignature.Top -= TsNavigation.Height
        LoadData()
        LoadForm()
    End Sub
    Private Sub LoadForm()
        Dim Sb As New StringBuilder
        DgvNavigator.DataGridView = _EmailModelsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
        TsBody.Renderer = New CustomToolstripRender
        TxtFont.Text = TxtBody.Font.Name
        Sb.AppendLine("#sdl#: é substituido por bom dia, boa tarde ou boa noite.")
        Sb.AppendLine("#sdn#: é substituido por Bom dia, Boa tarde ou Boa noite.")
        Sb.Append("#sdu#: é substituido por BOM DIA, BOA TARDE ou BOA NOITE.")
        EprInformation.SetError(TsBody, Sb.ToString())
        EprInformation.SetIconAlignment(TsBody, ErrorIconAlignment.MiddleRight)
        EprInformation.SetIconPadding(TsBody, -25)
    End Sub
    Private Sub LoadData()
        Dim Signatures As List(Of EmailSignature)
        _Loading = True
        LblIDValue.Text = _EmailModel.ID
        LblCreationValue.Text = _EmailModel.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _EmailModel.Name
        TxtSubject.Text = _EmailModel.Subject
        TxtBody.Rtf = _EmailModel.Body
        Signatures = EmailSignature.GetSignatures(Locator.GetInstance(Of Session).User.ID)
        Signatures.Insert(0, New EmailSignature With {.Name = ""})
        CbxSignature.DataSource = Signatures
        CbxSignature.DisplayMember = "Name"
        CbxSignature.ValueMember = "ID"
        If _EmailModel.Signature.ID > 0 Then
            CbxSignature.SelectedValue = _EmailModel.Signature.ID
        Else
            CbxSignature.SelectedValue = 0
        End If
        If _EmailModel.ID = 0 Then
            If CbxSignature.Items.Count > 1 Then CbxSignature.SelectedIndex = 1
            BtnDelete.Enabled = False
        Else
            BtnDelete.Enabled = True
        End If
        Text = "Modelo de E-mail"
        If _EmailModel.LockInfo.IsLocked And Not _EmailModel.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _EmailModel.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_EmailModel.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtName.Select()
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then DgvNavigator.CancelNextMove = True
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            _EmailModel.Load(_EmailModelsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO EM002", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
        _EmailModel = New EmailModel
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _EmailModel.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _EmailModel.LockInfo.IsLocked Or (_EmailModel.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _EmailModel.LockInfo.SessionToken) Then
                        _EmailModel.Delete()
                        If _EmailModelsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _EmailModelsForm.DgvEmailModelsLayout.Load()
                            _EmailModelsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_EmailModel.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                CMessageBox.Show("ERRO EM003", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.EmailModel, _EmailModel.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged, TxtSubject.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtBody_TextChanged(sender As Object, e As EventArgs) Handles TxtBody.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxSignature_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxSignature.SelectedIndexChanged
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
        TxtName.Text = RemoveAccents(TxtName.Text.Trim)
        If _EmailModel.LockInfo.IsLocked And _EmailModel.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_EmailModel.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _EmailModel.Name = TxtName.Text
                    _EmailModel.Subject = TxtSubject.Text
                    _EmailModel.Body = TxtBody.Rtf
                    _EmailModel.Signature = New EmailSignature().Load(CbxSignature.SelectedValue, False)
                    _EmailModel.SaveChanges()
                    _EmailModel.Lock()
                    LblIDValue.Text = _EmailModel.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = True
                    If _EmailModelsForm IsNot Nothing Then
                        _Filter.Filter()
                        _EmailModelsForm.DgvEmailModelsLayout.Load()
                        Row = _EmailModelsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    CMessageBox.Show("ERRO EM004", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Return False
                Catch ex As Exception
                    CMessageBox.Show("ERRO EM009", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Frm As FrmHtmlPreview
        Dim TempModel As New EmailModel
        TempModel.Body = TxtBody.Rtf
        If CbxSignature.SelectedIndex > 0 Then TempModel.Signature = New EmailSignature().Load(CbxSignature.SelectedValue, False)
        Frm = New FrmHtmlPreview(TempModel)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtBody_SelectionChanged(sender As Object, e As EventArgs) Handles TxtBody.SelectionChanged
        If TxtBody.SelectionFont IsNot Nothing Then
            TxtFont.Text = TxtBody.SelectionFont.Name
            BtnColor.Image = GetRecoloredImage(BtnColor.Image, TxtBody.SelectionColor)
            TxtFont.ForeColor = TxtBody.SelectionColor
        End If
    End Sub
    Private Sub BtnColor_Click(sender As Object, e As EventArgs) Handles BtnColor.Click
        CdColor.Color = TxtBody.SelectionColor
        If CdColor.ShowDialog = DialogResult.OK Then
            TxtBody.SelectionColor = CdColor.Color
            BtnColor.Image = GetRecoloredImage(BtnColor.Image, CdColor.Color)
        End If
    End Sub
    Private Sub TxtFont_Click(sender As Object, e As EventArgs) Handles TxtFont.Click
        FdFont.Font = TxtBody.SelectionFont
        If FdFont.ShowDialog = DialogResult.OK Then
            TxtBody.SelectionFont = FdFont.Font
            TxtFont.Text = TxtBody.SelectionFont.Name
        End If
    End Sub
    Private Sub TxtFont_MouseEnter(sender As Object, e As EventArgs) Handles TxtFont.MouseEnter, BtnColor.MouseEnter, BtnLeft.MouseEnter, BtnCenter.MouseEnter, BtnRight.MouseEnter
        TsBody.Cursor = Cursors.Hand
    End Sub
    Private Sub TxtFont_MouseLeave(sender As Object, e As EventArgs) Handles TxtFont.MouseLeave, BtnColor.MouseLeave, BtnLeft.MouseLeave, BtnCenter.MouseLeave, BtnRight.MouseLeave
        TsBody.Cursor = Cursors.Default
    End Sub
    Private Sub BtnLeft_Click(sender As Object, e As EventArgs) Handles BtnLeft.Click
        BtnLeft.Checked = True
        BtnCenter.Checked = False
        BtnRight.Checked = False
        TxtBody.SelectionAlignment = HorizontalAlignment.Left
    End Sub
    Private Sub BtnCenter_Click(sender As Object, e As EventArgs) Handles BtnCenter.Click
        BtnLeft.Checked = False
        BtnCenter.Checked = True
        BtnRight.Checked = False
        TxtBody.SelectionAlignment = HorizontalAlignment.Center
    End Sub
    Private Sub BtnRight_Click(sender As Object, e As EventArgs) Handles BtnRight.Click
        BtnLeft.Checked = False
        BtnCenter.Checked = False
        BtnRight.Checked = True
        TxtBody.SelectionAlignment = HorizontalAlignment.Right
    End Sub
    Private Sub FrmEmailModel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _EmailModel.Unlock()
    End Sub
End Class