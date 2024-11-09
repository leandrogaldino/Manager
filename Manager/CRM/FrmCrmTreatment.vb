Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmCrmTreatment
    Private _CrmForm As FrmCrm
    Private _Crm As Crm
    Private _CrmTreatment As CrmTreatment
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
    Public Sub New(Crm As Crm, CrmTreatment As CrmTreatment, CrmForm As FrmCrm)
        InitializeComponent()
        _Crm = Crm
        _CrmTreatment = CrmTreatment
        _CrmForm = CrmForm
        CbxContactType.DataSource = GetEnumDescriptions(GetType(CrmTreatmentContactType))
        LoadForm()
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privileges.SeveralLogAccess
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
        _CrmTreatment = New CrmTreatment()
        LoadForm()
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.CrmTreatment, _CrmTreatment.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles DbxContact.TextChanged,
                                                                         DbxNextContact.TextChanged,
                                                                         TxtSummary.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxContactType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxContactType.SelectedIndexChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _CrmTreatment.Order
        LblCreationValue.Text = _CrmTreatment.Creation.ToString("dd/MM/yyyy")
        DbxContact.Text = _CrmTreatment.Contact.ToString("dd/MM/yyyy")
        DbxNextContact.Text = _CrmTreatment.NextContact.ToString("dd/MM/yyyy")
        CbxContactType.Text = GetEnumDescription(_CrmTreatment.ContactType)
        TxtSummary.Text = _CrmTreatment.Summary
        If _CrmTreatment.Order = 0 Then
            BtnSave.Text = "Incluir"
        Else
            BtnSave.Text = "Alterar"
        End If
        BtnSave.Enabled = False
        DbxContact.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If Not IsDate(DbxContact.Text) Then
            EprValidation.SetError(LblContact, "Data inválida.")
            EprValidation.SetIconAlignment(LblContact, ErrorIconAlignment.MiddleRight)
            DbxContact.Select()
            Return False
        ElseIf CDate(DbxContact.Text) > Today Then
            EprValidation.SetError(LblContact, "A data de contato não pode ser maior que hoje.")
            EprValidation.SetIconAlignment(LblContact, ErrorIconAlignment.MiddleRight)
            DbxContact.Select()
            Return False
        ElseIf _Crm.Treatments.Any(Function(x) x.Contact > CDate(DbxContact.Text) AndAlso x.Order <> _CrmTreatment.Order) Then
            EprValidation.SetError(LblContact, $"A data do contato não pode ser menor que {_Crm.Treatments.Max(Function(x) x.Contact):dd/MM/yyyy}.")
            EprValidation.SetIconAlignment(LblContact, ErrorIconAlignment.MiddleRight)
            DbxContact.Select()
            Return False
        ElseIf Not IsDate(DbxNextContact.Text) Then
            EprValidation.SetError(LblNextContact, "Data inválida.")
            EprValidation.SetIconAlignment(LblNextContact, ErrorIconAlignment.MiddleRight)
            DbxNextContact.Select()
            Return False
        ElseIf CDate(DbxNextContact.Text) < CDate(DbxContact.Text) Then
            EprValidation.SetError(LblNextContact, "A data do próximo contato nao pode ser anterior a data do contato.")
            EprValidation.SetIconAlignment(LblNextContact, ErrorIconAlignment.MiddleRight)
            DbxNextContact.Select()
            Return False
        ElseIf CDate(DbxNextContact.Text).DayOfWeek = DayOfWeek.Saturday Then
            EprValidation.SetError(LblNextContact, "A data do próximo contato nao pode ser em um sábado.")
            EprValidation.SetIconAlignment(LblNextContact, ErrorIconAlignment.MiddleRight)
            DbxNextContact.Select()
            Return False
        ElseIf CDate(DbxNextContact.Text).DayOfWeek = DayOfWeek.Sunday Then
            EprValidation.SetError(LblNextContact, "A data do próximo contato nao pode ser em um domingo.")
            EprValidation.SetIconAlignment(LblNextContact, ErrorIconAlignment.MiddleRight)
            DbxNextContact.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtSummary.Text) Then
            EprValidation.SetError(LblSummary, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblSummary, ErrorIconAlignment.MiddleRight)
            TxtSummary.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        TxtSummary.Text = RemoveAccents(TxtSummary.Text.Trim)
        If IsValidFields() Then
            If _CrmTreatment.IsSaved Then
                _Crm.Treatments.Single(Function(x) x.Order = _CrmTreatment.Order).Contact = DbxContact.Text
                _Crm.Treatments.Single(Function(x) x.Order = _CrmTreatment.Order).NextContact = DbxNextContact.Text
                _Crm.Treatments.Single(Function(x) x.Order = _CrmTreatment.Order).ContactType = GetEnumValue(Of CrmTreatmentContactType)(CbxContactType.Text)
                _Crm.Treatments.Single(Function(x) x.Order = _CrmTreatment.Order).Responsible = _Crm.Responsible
                _Crm.Treatments.Single(Function(x) x.Order = _CrmTreatment.Order).Summary = TxtSummary.Text
            Else
                _CrmTreatment = New CrmTreatment()
                _CrmTreatment.Contact = DbxContact.Text
                _CrmTreatment.NextContact = DbxNextContact.Text
                _CrmTreatment.ContactType = GetEnumValue(Of CrmTreatmentContactType)(CbxContactType.Text)
                _CrmTreatment.Responsible = _Crm.Responsible
                _CrmTreatment.Summary = TxtSummary.Text
                _CrmTreatment.IsSaved = True
                _Crm.Treatments.Add(_CrmTreatment)
            End If
            _CrmForm.WebTreatments.Navigate(_Crm.GetHtml())
            LblOrderValue.Text = _CrmTreatment.Order
            BtnSave.Enabled = False
            If _CrmTreatment.Order = 0 Then
                BtnSave.Text = "Incluir"
            Else
                BtnSave.Text = "Alterar"
            End If
            _CrmForm.EprValidation.Clear()
            _CrmForm.BtnSave.Enabled = True
            Return True
        Else
            Return False
        End If
    End Function
End Class