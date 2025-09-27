Imports System.Reflection
Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Bcpg
Public Class FrmUser
    Private _User As User
    Private _UsersForm As FrmUsers
    Private _UsersGrid As DataGridView
    Private _Filter As UserFilter
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
    Public Sub New(User As User, UsersForm As FrmUsers)
        _User = User
        _UsersForm = UsersForm
        _UsersGrid = _UsersForm.DgvData
        _Filter = CType(_UsersForm.PgFilter.SelectedObject, UserFilter)
        _LoggedUser = Locator.GetInstance(Of Session).User
        InitializeComponent()
        LoadForm()
        LoadData()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvEmailLayout.Load()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(DgvEmail, True)
        ControlHelper.EnableControlDoubleBuffer(FlpPrivilege, True)
        ControlHelper.EnableControlDoubleBuffer(TcUser, True)
        ControlHelper.EnableControlDoubleBuffer(TabPrivilege, True)
        DgvNavigator.DataGridView = _UsersGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnRequestPassword.Visible = _LoggedUser.CanAccess(Routine.UserResetPassword)
        BtnRequestPassword.ToolTipText = String.Format("Resetar Senha ({0})", Locator.GetInstance(Of Session).Setting.General.User.DefaultPassword)
        BtnLog.Visible = _LoggedUser.CanAccess(Routine.Log)
        BtnImportPrivilege.Visible = False
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
            Dim Privileges As List(Of UserPrivilege) = _User.Privileges.Where(Function(x) x.PrivilegedRoutine = TriStatePrivilege).ToList()
            PrivilegeItem.CanAccess = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Access)
            PrivilegeItem.CanWrite = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Write)
            PrivilegeItem.CanDelete = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Delete)
            ControlIndex += 1
        Next
        ControlIndex += 1
        Dim BiStatePrivileges As List(Of Routine) = EnumHelper.GetEnumItems(Of Routine)(Function(x) x.GetCustomAttributes(GetType(BiStatePrivilege), True).Any()).OrderBy(Function(x) EnumHelper.GetEnumDescription(x)).ToList
        For Each BiStatePrivilege In BiStatePrivileges
            Dim PrivilegeItem = CType(FlpPrivilege.Controls(ControlIndex), UcBiStatePrivilegeItem)
            Dim Privileges As List(Of UserPrivilege) = _User.Privileges.Where(Function(x) x.PrivilegedRoutine = BiStatePrivilege).ToList()
            PrivilegeItem.Granted = Privileges.Any(Function(p) p.Level = PrivilegeLevel.Access)
            ControlIndex += 1
        Next
        TabPrivilege.Visible = True
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _User.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_User.Status)
        LblCreationValue.Text = _User.Creation.ToString("dd/MM/yyyy")
        TxtUsername.Text = _User.Username
        QbxPerson.Unfreeze()
        QbxPerson.Freeze(_User.Person.Value.ID)
        TxtNote.Text = _User.Note
        TxtFilterEmail.Clear()
        TxtFilterPrivileges.Clear()
        If _User.Emails IsNot Nothing Then DgvEmail.Fill(_User.Emails)
        BtnDelete.Enabled = _User.ID > 0 And _LoggedUser.CanDelete(Routine.User)
        UpdatePrivileges()
        Text = "Usuário"
        If _User.LockInfo.IsLocked And Not _User.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _User.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _User.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtUsername.Select()
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
            _User.Load(_UsersGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO US001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
        If _UsersForm IsNot Nothing Then
            DgvEmail.Fill(_User.Emails)
        End If
        _Deleting = False
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _User = New User
        LoadData()
    End Sub
    Private Sub TcUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcUser.SelectedIndexChanged
        If TcUser.SelectedTab Is TabMain Then
            Size = New Size(475, 230)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            BtnImportPrivilege.Visible = False
        ElseIf TcUser.SelectedTab Is TabPrivilege Then
            FlpPrivilege.SuspendLayout()
            SuspendLayout()
            Size = New Size(520, 550)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            BtnImportPrivilege.Visible = True
            FlpPrivilege.ResumeLayout(True)
            ResumeLayout()
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
            BtnImportPrivilege.Visible = False
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _User.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _User.LockInfo.IsLocked Or (_User.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _User.LockInfo.SessionToken) Then
                        _User.Delete()
                        If _UsersGrid IsNot Nothing Then
                            _Filter.Filter()
                            _UsersForm.DgvUserLayout.Load()
                            _UsersGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _User.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO US002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.User, _User.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _User.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _User.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub PrivilegeItemCheckedChange(sender As Object, e As EventArgs)
        Dim IsTriState As Boolean = sender.GetType().Equals(GetType(UcTristatePrivilegeItem))
        Dim Routine = sender.Routine
        Dim AccessPrivilege As UserPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = Routine AndAlso p.Level = PrivilegeLevel.Access)
        If (IsTriState AndAlso sender.CanAccess) OrElse (Not IsTriState AndAlso sender.Granted) Then
            ' Adiciona o privilégio se estiver marcado e ainda não existir
            If AccessPrivilege Is Nothing Then
                _User.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = Routine, .Level = PrivilegeLevel.Access})
                AccessPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = Routine AndAlso p.Level = PrivilegeLevel.Access)
                Dim Attr = AttributeHelper.GetAttribute(Of RoutineDependencyAttribute)(AccessPrivilege.PrivilegedRoutine.GetType(), AccessPrivilege.PrivilegedRoutine.ToString)
                If Attr IsNot Nothing Then
                    FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem).FirstOrDefault(Function(x) x.Routine = Attr.Dependency).CanAccess = True
                End If
            End If
        Else
            ' Remove o privilégio se não estiver marcado e já existir
            If AccessPrivilege IsNot Nothing Then
                _User.Privileges.Remove(AccessPrivilege)
                Dim Dependents = EnumHelper.GetEnumItems(Of Routine)(Function(field)
                                                                         Dim attribute = CType(field.GetCustomAttribute(GetType(RoutineDependencyAttribute)), RoutineDependencyAttribute)
                                                                         Return attribute IsNot Nothing AndAlso attribute.Dependency = AccessPrivilege.PrivilegedRoutine
                                                                     End Function)
                For Each Dependent In Dependents
                    Dim TriStateControl = FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem).FirstOrDefault(Function(x) x.Routine = Dependent)
                    If TriStateControl IsNot Nothing Then
                        TriStateControl.CanAccess = False
                    End If
                    Dim BiStateControl = FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeItem).FirstOrDefault(Function(x) x.Routine = Dependent)
                    If BiStateControl IsNot Nothing Then
                        BiStateControl.Granted = False
                    End If
                Next
            End If
        End If
        If IsTriState Then
            Dim WritePrivilege As UserPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = Routine AndAlso p.Level = PrivilegeLevel.Write)
            If sender.CanWrite Then
                ' Adiciona o privilégio se estiver marcado e ainda não existir
                If WritePrivilege Is Nothing Then
                    _User.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = Routine, .Level = PrivilegeLevel.Write})
                End If
            Else
                ' Remove o privilégio se não estiver marcado e já existir
                If WritePrivilege IsNot Nothing Then
                    _User.Privileges.Remove(WritePrivilege)
                End If
            End If
            ' Verifica e atualiza o privilégio de "Delete"
            Dim DeletePrivilege As UserPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = Routine AndAlso p.Level = PrivilegeLevel.Delete)
            If sender.CanDelete Then
                ' Adiciona o privilégio se estiver marcado e ainda não existir
                If DeletePrivilege Is Nothing Then
                    _User.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = Routine, .Level = PrivilegeLevel.Delete})
                End If
            Else
                ' Remove o privilégio se não estiver marcado e já existir
                If DeletePrivilege IsNot Nothing Then
                    _User.Privileges.Remove(DeletePrivilege)
                End If
            End If
        End If
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged,
                                                                         QbxPerson.TextChanged,
                                                                         TxtNote.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtNote_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TxtNote.LinkClicked
        Process.Start(e.LinkText)
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
        If _User.ID = Locator.GetInstance(Of Session).User.ID Then
            If CMessageBox.Show("Você está alterando seu próprio usuário, para que isso seja feito com segurança você será deslogado do sistema após a operação. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Save()
                FrmMain.Dispose()
                FrmLogin.Show()
            End If
        Else
            Save()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtUsername.Text) Then
            TcUser.SelectedTab = TabMain
            EprValidation.SetError(LblUsername, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblUsername, ErrorIconAlignment.MiddleRight)
            TxtUsername.Select()
            Return False
        ElseIf Not QbxPerson.IsFreezed Then
            TcUser.SelectedTab = TabMain
            EprValidation.SetError(LblPerson, "É obrigatório vincular uma pessoa.")
            EprValidation.SetIconAlignment(LblPerson, ErrorIconAlignment.MiddleRight)
            QbxPerson.Select()
            Return False
        ElseIf QbxPerson.IsFreezed And User.HasPerson(QbxPerson.FreezedPrimaryKey) And _User.ID = 0 Then
            TcUser.SelectedTab = TabMain
            EprValidation.SetError(LblPerson, "Essa pessoa já foi vinculada a um usuário.")
            EprValidation.SetIconAlignment(LblPerson, ErrorIconAlignment.MiddleRight)
            QbxPerson.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtUsername.Text = TxtUsername.Text.Trim.ToUnaccented()
        TxtNote.Text = TxtNote.Text.ToUpper.ToUnaccented()
        If _User.LockInfo.IsLocked And _User.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _User.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _User.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _User.Username = TxtUsername.Text
                    _User.Person = New Lazy(Of Person)(Function() New Person().Load(QbxPerson.FreezedPrimaryKey, False))
                    _User.Note = TxtNote.Text
                    ' Percorre todos os controles do tipo UcTristatePrivilegeItem dentro do FlowLayoutPanel
                    For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcTristatePrivilegeItem).Reverse()
                        ' Obtém a rotina atual
                        Dim routine = PrivilegeControl.Routine
                        ' Verifica e atualiza o privilégio de "Access"
                        Dim accessPrivilege As UserPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Access)
                        If PrivilegeControl.CanAccess Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If accessPrivilege Is Nothing Then
                                _User.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Access})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If accessPrivilege IsNot Nothing Then
                                _User.Privileges.Remove(accessPrivilege)
                            End If
                        End If
                        ' Verifica e atualiza o privilégio de "Write"
                        Dim writePrivilege As UserPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Write)
                        If PrivilegeControl.CanWrite Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If writePrivilege Is Nothing Then
                                _User.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Write})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If writePrivilege IsNot Nothing Then
                                _User.Privileges.Remove(writePrivilege)
                            End If
                        End If
                        ' Verifica e atualiza o privilégio de "Delete"
                        Dim deletePrivilege As UserPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Delete)
                        If PrivilegeControl.CanDelete Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If deletePrivilege Is Nothing Then
                                _User.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Delete})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If deletePrivilege IsNot Nothing Then
                                _User.Privileges.Remove(deletePrivilege)
                            End If
                        End If
                    Next
                    ' Percorre todos os controles do tipo UcTristatePrivilegeItem dentro do FlowLayoutPanel
                    For Each PrivilegeControl In FlpPrivilege.Controls.OfType(Of UcBiStatePrivilegeItem)
                        ' Obtém a rotina atual
                        Dim routine = PrivilegeControl.Routine
                        ' Verifica e atualiza o privilégio de "Access"
                        Dim accessPrivilege As UserPrivilege = _User.Privileges.FirstOrDefault(Function(p) p.PrivilegedRoutine = routine AndAlso p.Level = PrivilegeLevel.Access)
                        If PrivilegeControl.Granted Then
                            ' Adiciona o privilégio se estiver marcado e ainda não existir
                            If accessPrivilege Is Nothing Then
                                _User.Privileges.Add(New UserPrivilege With {.PrivilegedRoutine = routine, .Level = PrivilegeLevel.Access})
                            End If
                        Else
                            ' Remove o privilégio se não estiver marcado e já existir
                            If accessPrivilege IsNot Nothing Then
                                _User.Privileges.Remove(accessPrivilege)
                            End If
                        End If
                    Next
                    _User.SaveChanges()
                    _User.Lock()
                    LblIDValue.Text = _User.ID
                    DgvEmail.Fill(_User.Emails)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _LoggedUser.CanDelete(Routine.User)
                    If _UsersForm IsNot Nothing Then
                        _Filter.Filter()
                        _UsersForm.DgvUserLayout.Load()
                        Row = _UsersGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe um usuário cadastrado com esse nome de usuário.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO US003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
    Private Sub BtnRequestPassword_Click(sender As Object, e As EventArgs) Handles BtnRequestPassword.Click
        If CMessageBox.Show(String.Format("A senha desse usuário será redefinida para a senha padrão '{0}'. Deseja continuar?", Locator.GetInstance(Of Session).Setting.General.User.DefaultPassword), CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                _User.ResetPassword()
            Catch ex As Exception
                CMessageBox.Show("ERRO US004", "Ocorreu um erro redefinir a senha.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            End Try
        End If
    End Sub
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxPerson_Enter(sender As Object, e As EventArgs) Handles QbxPerson.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxPerson.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNew.Visible = _User.CanWrite(Routine.Person)
        BtnFilter.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxPerson_Leave(sender As Object, e As EventArgs) Handles QbxPerson.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxPerson_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPerson.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxPerson.IsFreezed And _User.CanWrite(Routine.Person)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Person As Person
        Person = New Person With {.IsEmployee = True}
        Using Form As New FrmPerson(Person)
            Form.CbxIsEmployee.Enabled = False
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Person.ID > 0 Then
            QbxPerson.Freeze(Person.ID)
        End If
        QbxPerson.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Using Form As New FrmPerson(New Person().Load(QbxPerson.FreezedPrimaryKey, True))
            Form.CbxIsEmployee.Enabled = False
            Form.ShowDialog()
        End Using
        QbxPerson.Freeze(QbxPerson.FreezedPrimaryKey)
        QbxPerson.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New PersonEmployeeQueriedBoxFilter(), QbxPerson) With {.Text = "Filtro de Funcionários"}
            Form.ShowDialog()
        End Using
        QbxPerson.Select()
    End Sub
    Private Sub BtnIncludeEmail_Click(sender As Object, e As EventArgs) Handles BtnIncludeEmail.Click
        Using Form As New FrmUserEmail(_User, New UserEmail, Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEditEmail_Click(sender As Object, e As EventArgs) Handles BtnEditEmail.Click
        Dim Email As UserEmail
        If DgvEmail.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            Email = _User.Emails.Single(Function(x) x.Guid = DgvEmail.SelectedRows(0).Cells("Guid").Value)
            Using Form As New FrmUserEmail(_User, Email, Me)
                Form.ShowDialog()
            End Using
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub BtnDeleteEmail_Click(sender As Object, e As EventArgs) Handles BtnDeleteEmail.Click
        Dim Email As UserEmail
        If DgvEmail.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Email = _User.Emails.Single(Function(x) x.Guid = DgvEmail.SelectedRows(0).Cells("Guid").Value)
                _User.Emails.Remove(Email)
                DgvEmail.Fill(_User.Emails)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DgvEmail_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvEmail.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvEmail.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditEmail.PerformClick()
        End If
    End Sub

    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterEmail.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}

        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterEmail.TextChanged
        FilterEmail()
    End Sub
    Private Sub FilterEmail()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1}",
                                                 "Email LIKE '%@VALUE%'",
                                                 "SmtpServer LIKE '%@VALUE%'"
                                            )
        If DgvEmail.DataSource IsNot Nothing Then
            Table = DgvEmail.DataSource
            View = Table.DefaultView
            If TxtFilterEmail.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterEmail.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub FrmUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _User.Unlock()
    End Sub

    Private Sub DgvEmail_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvEmail.DataSourceChanged
        FilterEmail()
    End Sub
    Private Sub DgvEmail_SelectionChanged(sender As Object, e As EventArgs) Handles DgvEmail.SelectionChanged
        If DgvEmail.SelectedRows.Count = 0 Then
            BtnEditEmail.Enabled = False
            BtnDeleteEmail.Enabled = False
        Else
            BtnEditEmail.Enabled = True
            BtnDeleteEmail.Enabled = True
        End If
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

    Private Sub BtnImportPrivilege_Click(sender As Object, e As EventArgs) Handles BtnImportPrivilege.Click
        Dim Preset As PrivilegePreset
        Dim UserPrivilege As UserPrivilege
        Using Form As New FrmUserImportPrivilege()
            If Form.ShowDialog() = DialogResult.OK Then
                Preset = New PrivilegePreset().Load(Form.QbxPreset.FreezedPrimaryKey, False)
                _User.Privileges.Clear()
                For Each Privilege In Preset.Privileges
                    UserPrivilege = New UserPrivilege With {
                        .PrivilegedRoutine = Privilege.PrivilegedRoutine,
                        .Level = Privilege.Level
                    }
                    _User.Privileges.Add(UserPrivilege)
                Next Privilege
                UpdatePrivileges()
            End If
        End Using
    End Sub
End Class