﻿Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Public Class FrmProductFamily
    Private _ProductFamily As ProductFamily
    Private _ProductFamiliesForm As FrmProductFamilies
    Private _ProductFamiliesGrid As DataGridView
    Private _Filter As ProductFamilyFilter
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
    Public Sub New(ProductFamily As ProductFamily, ProductFamiliesForm As FrmProductFamilies)
        InitializeComponent()
        _ProductFamily = ProductFamily
        _ProductFamiliesForm = ProductFamiliesForm
        _ProductFamiliesGrid = _ProductFamiliesForm.DgvData
        _Filter = CType(_ProductFamiliesForm.PgFilter.SelectedObject, ProductFamilyFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(ProductFamily As ProductFamily)
        InitializeComponent()
        _ProductFamily = ProductFamily
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
        DgvNavigator.DataGridView = _ProductFamiliesGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _ProductFamily.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_ProductFamily.Status)
        LblCreationValue.Text = _ProductFamily.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _ProductFamily.Name
        BtnDelete.Enabled = _ProductFamily.ID > 0 And _User.CanDelete(Routine.ProductFamily)
        Text = "Família de Produto"
        If _ProductFamily.LockInfo.IsLocked And Not _ProductFamily.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _ProductFamily.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _ProductFamily.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
            _ProductFamily.Load(_ProductFamiliesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO PF004", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
        _ProductFamily = New ProductFamily
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ProductFamily.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _ProductFamily.LockInfo.IsLocked Or (_ProductFamily.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _ProductFamily.LockInfo.SessionToken) Then
                        _ProductFamily.Delete()
                        If _ProductFamiliesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _ProductFamiliesForm.DgvProductFamilyLayout.Load()
                            _ProductFamiliesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _ProductFamily.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO PF005", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.ProductFamily, _ProductFamily.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _ProductFamily.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _ProductFamily.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
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
        If _ProductFamily.LockInfo.IsLocked And _ProductFamily.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _ProductFamily.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _ProductFamily.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _ProductFamily.Name = TxtName.Text
                Try
                    Cursor = Cursors.WaitCursor
                    _ProductFamily.SaveChanges()
                    _ProductFamily.Lock()
                    LblIDValue.Text = _ProductFamily.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.ProductFamily)
                    If _ProductFamiliesForm IsNot Nothing Then
                        _Filter.Filter()
                        _ProductFamiliesForm.DgvProductFamilyLayout.Load()
                        Row = _ProductFamiliesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma família de produtos cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO PF006", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
    Private Sub FrmProductFamily_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _ProductFamily.Unlock()
    End Sub
End Class