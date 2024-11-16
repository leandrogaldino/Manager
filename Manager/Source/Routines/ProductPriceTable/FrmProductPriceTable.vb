Imports ControlLibrary
Imports ControlLibrary.Utility
Imports MySql.Data.MySqlClient
Public Class FrmProductPriceTable
    Private _PriceTable As ProductPriceTable
    Private _PriceTablesForm As FrmProductPriceTables
    Private _PriceTablesGrid As DataGridView
    Private _Filter As ProductPriceTableFilter
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
    Public Sub New(PriceTable As ProductPriceTable, PriceTablesForm As FrmProductPriceTables)
        InitializeComponent()
        _PriceTable = PriceTable
        _PriceTablesForm = PriceTablesForm
        _PriceTablesGrid = _PriceTablesForm.DgvData
        _Filter = CType(_PriceTablesForm.PgFilter.SelectedObject, ProductPriceTableFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(PriceTable As ProductPriceTable)
        InitializeComponent()
        _PriceTable = PriceTable
        _User = Locator.GetInstance(Of Session).User
        Height -= TsNavigation.Height
        LblName.Top -= TsNavigation.Height
        TxtName.Top -= TsNavigation.Height
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        LoadData()
        LoadForm()
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _PriceTablesGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _PriceTable.ID
        BtnStatusValue.Text = GetEnumDescription(_PriceTable.Status)
        LblCreationValue.Text = _PriceTable.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _PriceTable.Name
        BtnDelete.Enabled = _PriceTable.ID > 0 And _User.CanDelete(Routine.ProductPriceTable)
        Text = "Tabela de Preço"
        If _PriceTable.LockInfo.IsLocked And Not _PriceTable.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _PriceTable.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_PriceTable.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
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
            _PriceTable.Load(_PriceTablesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO PP001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
        _PriceTable = New ProductPriceTable
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PriceTable.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _PriceTable.LockInfo.IsLocked Or (_PriceTable.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _PriceTable.LockInfo.SessionToken) Then
                        _PriceTable.Delete()
                        If _PriceTablesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _PriceTablesForm.DgvPriceTableLayout.Load()
                            _PriceTablesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_PriceTable.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO PP002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.ProductPriceTable, _PriceTable.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive)
            If _PriceTable.Status = GetEnumDescription(SimpleStatus.Active) Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
            If _PriceTable.Status = SimpleStatus.Inactive Then
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
        If _PriceTable.LockInfo.IsLocked And _PriceTable.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_PriceTable.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _PriceTable.Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _PriceTable.Name = TxtName.Text
                Try
                    _PriceTable.SaveChanges()
                    _PriceTable.Lock()
                    LblIDValue.Text = _PriceTable.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.ProductPriceTable)
                    If _PriceTablesForm IsNot Nothing Then
                        _Filter.Filter()
                        _PriceTablesForm.DgvPriceTableLayout.Load()
                        Row = _PriceTablesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma tabela de preços cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO PP003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Return False
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub FrmProductPriceTable_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _PriceTable.Unlock()
    End Sub
End Class