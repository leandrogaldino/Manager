Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient

Public Class FrmPrivilegePreset
    Private _PrivilegePreset As PrivilegePreset
    Private _GridControl As UcPrivilegePresetGrid
    Private _PrivilegePresetsGrid As DataGridView
    Private _Filter As PrivilegePresetFilter
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _LoggedUser As User
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
    Public Sub New(PrivilegePreset As PrivilegePreset, GridControl As UcPrivilegePresetGrid)
        _PrivilegePreset = PrivilegePreset
        _GridControl = GridControl
        _PrivilegePresetsGrid = _GridControl.DgvData
        _Filter = CType(_GridControl.PgFilter.SelectedObject, PrivilegePresetFilter)
        _LoggedUser = Locator.GetInstance(Of Session).User
        InitializeComponent()
        LoadForm()
        LoadData()
    End Sub
    Public Sub New(PrivilegePreset As PrivilegePreset)
        InitializeComponent()
        _PrivilegePreset = PrivilegePreset
        _LoggedUser = Locator.GetInstance(Of Session).User
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        TcPrivilegePreset.Height -= TsNavigation.Height
        Height -= TsNavigation.Height
        LoadForm()
        LoadData()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(FlpPrivilege, True)
        ControlHelper.EnableControlDoubleBuffer(TcPrivilegePreset, True)
        ControlHelper.EnableControlDoubleBuffer(TabPrivilege, True)
        DgvNavigator.DataGridView = _PrivilegePresetsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _LoggedUser.CanAccess(Routine.Log)
        InitializePrivileges()
    End Sub

    Private Sub InitializePrivileges()
        Dim Controls As New List(Of Control) From {New UcTriStatePrivilegeTitle()}
        Dim TriStatePrivileges As List(Of Routine) = EnumHelper.GetEnumItems(Of Routine)(Function(x) x.GetCustomAttributes(GetType(TriStatePrivilege), True).Any()).OrderBy(Function(x) EnumHelper.GetEnumDescription(x)).ToList
        For Each TriStatePrivilege In TriStatePrivileges
            Dim PrivilegeItem = New UcTristatePrivilegeItem() With {.Routine = TriStatePrivilege}
            AddHandler PrivilegeItem.CheckedChanged, AddressOf PrivilegeItemCheckedChange
            Controls.Add(PrivilegeItem)
        Next
        Controls.Add(New UcBiStatePrivilegeTitle())
        Dim BiStatePrivileges As List(Of Routine) = EnumHelper.GetEnumItems(Of Routine)(Function(x) x.GetCustomAttributes(GetType(BiStatePrivilege), True).Any()).OrderBy(Function(x) EnumHelper.GetEnumDescription(x)).ToList
        For Each BiStatePrivilege In BiStatePrivileges
            Dim PrivilegeItem = New UcBiStatePrivilegeItem() With {.Routine = BiStatePrivilege}
            AddHandler PrivilegeItem.CheckedChanged, AddressOf PrivilegeItemCheckedChange
            Controls.Add(PrivilegeItem)
        Next
        FlpPrivilege.Controls.AddRange(Controls.ToArray())
    End Sub
    Private Sub UpdatePrivileges()
        TabPrivilege.Visible = False
        Dim ControlIndex As Integer = 1
        Dim TriStatePrivileges As List(Of Routine) = EnumHelper.GetEnumItems(Of Routine)(Function(x) x.GetCustomAttributes(GetType(TriStatePrivilege), True).Any()).OrderBy(Function(x) EnumHelper.GetEnumDescription(x)).ToList
        For Each TriStatePrivilege In TriStatePrivileges
            Dim PrivilegeItem = CType(FlpPrivilege.Controls(ControlIndex), UcTristatePrivilegeItem)
            Dim Privileges As List(Of UserPrivilege) = _PrivilegePreset.Privileges.Where(Function(x) x.PrivilegedRoutine = TriStatePrivilege).ToList()
            PrivilegeItem.CanAccess = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Access)
            PrivilegeItem.CanWrite = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Write)
            PrivilegeItem.CanDelete = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Delete)
            ControlIndex += 1
        Next
        ControlIndex += 1
        Dim BiStatePrivileges As List(Of Routine) = EnumHelper.GetEnumItems(Of Routine)(Function(x) x.GetCustomAttributes(GetType(BiStatePrivilege), True).Any()).OrderBy(Function(x) EnumHelper.GetEnumDescription(x)).ToList
        For Each BiStatePrivilege In BiStatePrivileges
            Dim PrivilegeItem = CType(FlpPrivilege.Controls(ControlIndex), UcBiStatePrivilegeItem)
            Dim Privileges As List(Of UserPrivilege) = _PrivilegePreset.Privileges.Where(Function(x) x.PrivilegedRoutine = BiStatePrivilege).ToList()
            PrivilegeItem.Granted = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Access)
            ControlIndex += 1
        Next
        TabPrivilege.Visible = True
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _PrivilegePreset.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_PrivilegePreset.Status)
        LblCreationValue.Text = _PrivilegePreset.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _PrivilegePreset.Name
        TxtFilterPrivileges.Clear()
        BtnDelete.Enabled = _PrivilegePreset.ID > 0 And _LoggedUser.CanDelete(Routine.PrivilegePreset)
        UpdatePrivileges()
        Text = "Predefinição de Permissões"
        If _PrivilegePreset.LockInfo.IsLocked And Not _PrivilegePreset.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _PrivilegePreset.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _PrivilegePreset.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
            _PrivilegePreset.Load(_PrivilegePresetsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO PPR001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _Deleting AndAlso BtnSave.Enabled Then
            If BtnSave.Enabled Then
                If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not Save() Then e.Cancel = True
                End If
            End If
        End If
        _Deleting = False
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _PrivilegePreset = New PrivilegePreset()
        LoadData()
    End Sub
    Private Sub TcUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcPrivilegePreset.SelectedIndexChanged
        If TcPrivilegePreset.SelectedTab Is TabMain Then
            Size = New Size(475, 230)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
        ElseIf TcPrivilegePreset.SelectedTab Is TabPrivilege Then
            FlpPrivilege.SuspendLayout()
            SuspendLayout()
            Size = New Size(520, 550)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FlpPrivilege.ResumeLayout(True)
            ResumeLayout()
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PrivilegePreset.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _PrivilegePreset.LockInfo.IsLocked Or (_PrivilegePreset.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _PrivilegePreset.LockInfo.SessionToken) Then
                        _PrivilegePreset.Delete()
                        If _PrivilegePresetsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _GridControl.DgvlPrivilegePreset.Load()
                            _PrivilegePresetsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _PrivilegePreset.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO PPR002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.PrivilegePreset, _PrivilegePreset.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub PrivilegeItemCheckedChange(sender As Object, e As EventArgs)
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Insert And e.Control Then
            If BtnInclude.Enabled Then BtnInclude.PerformClick()
        ElseIf e.KeyCode = Keys.Delete And e.Control Then
            If BtnDelete.Enabled Then BtnDelete.PerformClick()
        ElseIf e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Function IsValidFields() As Boolean
        Dim Privileges As Integer
        Privileges = FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeItem).ToList.Where(Function(x) x.Granted).Count
        Privileges += FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem).ToList.Where(Function(x) x.CanAccess).Count
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            TcPrivilegePreset.SelectedTab = TabMain
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TxtName.Select()
            Return False
        ElseIf Privileges = 0 Then
            UpdatePrivileges()
            TcPrivilegePreset.SelectedTab = TabPrivilege
            EprValidation.SetError(PnFilter, "A predefinição precisa ter pelo menos uma permissão.")
            EprValidation.SetIconAlignment(PnFilter, ErrorIconAlignment.MiddleRight)
            FlpPrivilege.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        If _PrivilegePreset.LockInfo.IsLocked And _PrivilegePreset.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _PrivilegePreset.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _PrivilegePreset.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _PrivilegePreset.Name = TxtName.Text
                    ' Percorre todos os controles do tipo UcTristatePrivilegeItem dentro do FlowLayoutPanel
                    For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem)
                        ' Obtém a rotina atual
                        Dim routine = PrivilegeControl.Routine
                        ' Verifica e atualiza o privilégio de "Access"
                        Dim accessPrivilege = _PrivilegePreset.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Access)
                        If PrivilegeControl.CanAccess Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If accessPrivilege Is Nothing Then
                                _PrivilegePreset.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Access})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If accessPrivilege IsNot Nothing Then
                                _PrivilegePreset.Privileges.Remove(accessPrivilege)
                            End If
                        End If

                        ' Verifica e atualiza o privilégio de "Write"
                        Dim writePrivilege = _PrivilegePreset.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Write)
                        If PrivilegeControl.CanWrite Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If writePrivilege Is Nothing Then
                                _PrivilegePreset.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Write})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If writePrivilege IsNot Nothing Then
                                _PrivilegePreset.Privileges.Remove(writePrivilege)
                            End If
                        End If

                        ' Verifica e atualiza o privilégio de "Delete"
                        Dim deletePrivilege = _PrivilegePreset.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Delete)
                        If PrivilegeControl.CanDelete Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If deletePrivilege Is Nothing Then
                                _PrivilegePreset.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Delete})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If deletePrivilege IsNot Nothing Then
                                _PrivilegePreset.Privileges.Remove(deletePrivilege)
                            End If
                        End If
                    Next
                    ' Percorre todos os controles do tipo UcTristatePrivilegeItem dentro do FlowLayoutPanel
                    For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeItem)
                        ' Obtém a rotina atual
                        Dim routine = PrivilegeControl.Routine
                        ' Verifica e atualiza o privilégio de "Access"
                        Dim accessPrivilege = _PrivilegePreset.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Access)
                        If PrivilegeControl.Granted Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If accessPrivilege Is Nothing Then
                                _PrivilegePreset.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Access})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If accessPrivilege IsNot Nothing Then
                                _PrivilegePreset.Privileges.Remove(accessPrivilege)
                            End If
                        End If
                    Next
                    _PrivilegePreset.SaveChanges()
                    _PrivilegePreset.Lock()
                    LblIDValue.Text = _PrivilegePreset.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _LoggedUser.CanDelete(Routine.PrivilegePreset)
                    If _GridControl IsNot Nothing Then
                        _Filter.Filter()
                        _GridControl.DgvlPrivilegePreset.Load()
                        Row = _PrivilegePresetsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma predefinição de permissões cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO PPR003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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

    Private Sub FrmUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _PrivilegePreset.Unlock()
    End Sub
    Private Sub TxtFilterPrivileges_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterPrivileges.TextChanged
        Dim Filter As String = TxtFilterPrivileges.Text
        FlpPrivilege.SuspendLayout()
        If Not String.IsNullOrEmpty(Filter) Then
            For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem)
                If Not EnumHelper.GetEnumDescription(PrivilegeControl.Routine).ToUpper.Contains(Filter.ToUpper) Then
                    PrivilegeControl.Visible = False
                Else
                    PrivilegeControl.Visible = True
                End If
            Next PrivilegeControl

            For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeItem)
                If Not EnumHelper.GetEnumDescription(PrivilegeControl.Routine).ToUpper.Contains(Filter.ToUpper) Then
                    PrivilegeControl.Visible = False
                Else
                    PrivilegeControl.Visible = True
                End If
            Next PrivilegeControl
        Else
            For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem)
                PrivilegeControl.Visible = True
            Next PrivilegeControl
            For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeItem)
                PrivilegeControl.Visible = True
            Next PrivilegeControl
        End If

        If FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem).Cast(Of UcTristatePrivilegeItem).Any(Function(x) x.Visible) Then
            FlpPrivilege.Controls.OfType(Of UcTriStatePrivilegeTitle).First.Visible = True
        Else
            FlpPrivilege.Controls.OfType(Of UcTriStatePrivilegeTitle).First.Visible = False
        End If


        If FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeItem).Cast(Of UcBiStatePrivilegeItem).Any(Function(x) x.Visible) Then
            FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeTitle).First.Visible = True
        Else
            FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeTitle).First.Visible = False
        End If

        FlpPrivilege.ResumeLayout()
    End Sub
End Class