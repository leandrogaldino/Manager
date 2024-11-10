Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmPersonContact
    Private _PersonForm As FrmPerson
    Private _Person As Person
    Private _PersonContact As PersonContact
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
    Public Sub New(Person As Person, Contact As PersonContact, PersonForm As FrmPerson)
        InitializeComponent()
        _Person = Person
        _PersonContact = Contact
        _PersonForm = PersonForm
        LoadForm()
        DgvNavigator.DataGridView = _PersonForm.DgvContact
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.CanAccessLog)
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
        If _PersonForm.DgvContact.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _PersonContact = _Person.Contacts.Single(Function(x) x.Order = _PersonForm.DgvContact.SelectedRows(0).Cells("Order").Value)
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
        _PersonContact = New PersonContact()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PersonForm.DgvContact.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _PersonContact = _Person.Contacts.Single(Function(x) x.Order = _PersonForm.DgvContact.SelectedRows(0).Cells("Order").Value)
                If Not _PersonContact.IsMainContact Then
                    _Person.Contacts.Remove(_PersonContact)
                    _Person.Contacts.FillDataGridView(_PersonForm.DgvContact)
                    _PersonForm.DgvContactLayout.Load()
                    _Deleting = True
                    Dispose()
                    _PersonForm.BtnSave.Enabled = True
                Else
                    CMessageBox.Show("O contato principal não pode ser excluido.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.PersonContact, _PersonContact.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub CbxCheckedChanged(sender As Object, e As EventArgs) Handles CbxIsMainContact.CheckedChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged,
                                                                         TxtJobTitle.TextChanged,
                                                                         TxtPhone.TextChanged,
                                                                         TxtEmail.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _PersonContact.Order
        LblCreationValue.Text = _PersonContact.Creation
        CbxIsMainContact.Checked = _PersonContact.IsMainContact
        TxtName.Text = _PersonContact.Name
        TxtJobTitle.Text = _PersonContact.JobTitle
        TxtPhone.Text = _PersonContact.Phone
        TxtEmail.Text = _PersonContact.Email
        If _Person.Contacts.Count = 0 Then
            CbxIsMainContact.Checked = True
        End If
        If _PersonContact.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        If CbxIsMainContact.Checked Then
            CbxIsMainContact.Enabled = False
        Else
            CbxIsMainContact.Enabled = True
        End If
        BtnSave.Enabled = False
        TxtName.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) And String.IsNullOrWhiteSpace(TxtPhone.Text) And String.IsNullOrWhiteSpace(TxtEmail.Text) Then
            EprValidation.SetError(LblName, "Informe pelo menos um nome, telefone ou e-mail.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TxtName.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtPhone.Text) And Utility.GetWhichPhoneFormat(TxtPhone.Text) = Utility.PhoneFormat.InvalidPhone Then
            EprValidation.SetError(LblPhone, String.Format("Telefone inválido.{0}1) Verifique se o DDD foi informado;{0}2) Verifique se há algum caractere que não seja número, parênteses ou traço;{0}3)Verifique se o telefone tem entre 10 e 11 digitos.", vbNewLine))
            EprValidation.SetIconAlignment(LblPhone, ErrorIconAlignment.MiddleRight)
            TxtPhone.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtEmail.Text) And Not IsValidEmail(TxtEmail.Text) Then
            EprValidation.SetError(LblEmail, "E-Mail inválido.")
            EprValidation.SetIconAlignment(LblEmail, ErrorIconAlignment.MiddleRight)
            TxtEmail.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = RemoveAccents(TxtName.Text.Trim)
        TxtJobTitle.Text = RemoveAccents(TxtJobTitle.Text.Trim)
        TxtPhone.Text = RemoveAccents(TxtPhone.Text.Trim)
        TxtEmail.Text = RemoveAccents(TxtEmail.Text.Trim)
        If IsValidFields() Then
            If _PersonContact.IsSaved Then
                _Person.Contacts.Single(Function(x) x.Order = _PersonContact.Order).IsMainContact = CbxIsMainContact.Checked
                _Person.Contacts.Single(Function(x) x.Order = _PersonContact.Order).Name = TxtName.Text
                _Person.Contacts.Single(Function(x) x.Order = _PersonContact.Order).JobTitle = TxtJobTitle.Text
                _Person.Contacts.Single(Function(x) x.Order = _PersonContact.Order).Phone = TxtPhone.Text
                _Person.Contacts.Single(Function(x) x.Order = _PersonContact.Order).Email = TxtEmail.Text
            Else
                _PersonContact = New PersonContact()
                _PersonContact.IsMainContact = CbxIsMainContact.Checked
                _PersonContact.Name = TxtName.Text
                _PersonContact.JobTitle = TxtJobTitle.Text
                _PersonContact.Phone = TxtPhone.Text
                _PersonContact.Email = TxtEmail.Text
                _PersonContact.IsSaved = True
                _Person.Contacts.Add(_PersonContact)
            End If

            If CbxIsMainContact.Checked Then
                CbxIsMainContact.Enabled = False
                For Each Contacts As PersonContact In _Person.Contacts
                    If Contacts.Order <> _PersonContact.Order Then
                        Contacts.IsMainContact = False
                    End If
                Next Contacts
            Else
                CbxIsMainContact.Enabled = True
            End If

            _Person.Contacts.FillDataGridView(_PersonForm.DgvContact)
            LblOrderValue.Text = _PersonContact.Order
            _PersonForm.DgvContactLayout.Load()
            BtnSave.Enabled = False
            If _PersonContact.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _PersonForm.DgvContact.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _PersonContact.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _PersonForm.EprValidation.Clear()
            _PersonForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TxtPhone_Leave(sender As Object, e As EventArgs) Handles TxtPhone.Leave
        TxtPhone.Text = GetFormatedPhoneNumber(TxtPhone.Text)
    End Sub
End Class