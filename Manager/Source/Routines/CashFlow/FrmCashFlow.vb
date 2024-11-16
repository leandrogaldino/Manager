Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Imports DocumentFormat.OpenXml.Bibliography

Public Class FrmCashFlow
    Private _CashFlow As CashFlow
    Private _CashFlowsForm As FrmCashFlows
    Private _CashFlowsGrid As DataGridView
    Private _Filter As CashFlowFilter
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
    Public Sub New(CashFlow As CashFlow, CashFlowsForm As FrmCashFlows)
        _CashFlow = CashFlow
        _CashFlowsForm = CashFlowsForm
        _CashFlowsGrid = _CashFlowsForm.DgvData
        _Filter = CType(_CashFlowsForm.PgFilter.SelectedObject, CashFlowFilter)
        _User = Locator.GetInstance(Of Session).User
        InitializeComponent()
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(CashFlow As CashFlow)
        _CashFlow = CashFlow
        _User = Locator.GetInstance(Of Session).User
        InitializeComponent()
        Height -= TsNavigation.Height
        LblName.Top -= TsNavigation.Height
        TxtName.Top -= TsNavigation.Height
        LblAuthorized.Top -= TsNavigation.Height
        PnAuthorized.Top -= TsNavigation.Height
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        LoadData()
        LoadForm()
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _CashFlowsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _CashFlow.ID
        BtnStatusValue.Text = GetEnumDescription(_CashFlow.Status)
        LblCreationValue.Text = _CashFlow.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _CashFlow.Name
        FillDataGridView()
        Text = "Rota"
        BtnDelete.Enabled = _CashFlow.ID > 0 And _User.CanDelete(Routine.CashFlow)
        If _CashFlow.LockInfo.IsLocked And Not _CashFlow.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _CashFlow.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_CashFlow.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
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
            _CashFlow.Load(_CashFlowsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO CF001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
            If _CashFlowsForm IsNot Nothing Then
                FillDataGridView()
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
        _CashFlow = New CashFlow
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CashFlow.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _CashFlow.LockInfo.IsLocked Or (_CashFlow.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _CashFlow.LockInfo.SessionToken) Then
                        _CashFlow.Delete()
                        If _CashFlowsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _CashFlowsForm.DgvCashFlowLayout.Load()
                            _CashFlowsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_CashFlow.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO CF002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.CashFlow, _CashFlow.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive)
            If _CashFlow.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
            If _CashFlow.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
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
        TxtName.Text = RemoveAccents(TxtName.Text.Trim)
        If _CashFlow.LockInfo.IsLocked And _CashFlow.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_CashFlow.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _CashFlow.Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _CashFlow.Name = TxtName.Text
                Try
                    Cursor = Cursors.WaitCursor
                    _CashFlow.SaveChanges()
                    _CashFlow.Lock()
                    LblIDValue.Text = _CashFlow.ID
                    FillDataGridView()
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.CashFlow)
                    If _CashFlowsForm IsNot Nothing Then
                        _Filter.Filter()
                        _CashFlowsForm.DgvCashFlowLayout.Load()
                        Row = _CashFlowsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma fluxo de caixa cadastrado com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO CF003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub FrmCashFlow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _CashFlow.Unlock()
    End Sub





    Private Sub BtnIncludeAuthorized_Click(sender As Object, e As EventArgs) Handles BtnIncludeAuthorized.Click
        Dim Form As New FrmCashFlowAuthorized(_CashFlow, New CashFlowAuthorized(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditAuthorized_Click(sender As Object, e As EventArgs) Handles BtnEditAuthorized.Click
        Dim Form As FrmCashFlowAuthorized
        Dim Authorized As CashFlowAuthorized
        If DgvAuthorized.SelectedRows.Count = 1 Then
            Authorized = _CashFlow.Authorized.Single(Function(x) x.Order = DgvAuthorized.SelectedRows(0).Cells("Order").Value)
            Form = New FrmCashFlowAuthorized(_CashFlow, Authorized, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteAuthorized_Click(sender As Object, e As EventArgs) Handles BtnDeleteAuthorized.Click
        Dim Authorized As CashFlowAuthorized
        If DgvAuthorized.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Authorized = _CashFlow.Authorized.Single(Function(x) x.Order = DgvAuthorized.SelectedRows(0).Cells("Order").Value)
                _CashFlow.Authorized.Remove(Authorized)
                FillDataGridView()
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DgvAuthorized_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvAuthorized.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvAuthorized.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditAuthorized.PerformClick()
        End If
    End Sub
    Private Sub DgvAuthorized_SelectionChanged(sender As Object, e As EventArgs) Handles DgvAuthorized.SelectionChanged
        If DgvAuthorized.SelectedRows.Count = 0 Then
            BtnEditAuthorized.Enabled = False
            BtnDeleteAuthorized.Enabled = False
        Else
            BtnEditAuthorized.Enabled = True
            BtnDeleteAuthorized.Enabled = True
        End If
    End Sub
    Public Sub FillDataGridView()
        _CashFlow.Authorized.FillDataGridView(DgvAuthorized)
        DgvAuthorized.Columns.Cast(Of DataGridViewColumn).Where(Function(x) x.Name <> "Authorized").ToList.ForEach(Sub(y) y.Visible = False)
        DgvAuthorized.Columns.Cast(Of DataGridViewColumn).Single(Function(x) x.Name = "Authorized").HeaderText = "Usuário Autorizado"
        DgvAuthorized.Columns.Cast(Of DataGridViewColumn).Single(Function(x) x.Name = "Authorized").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
End Class