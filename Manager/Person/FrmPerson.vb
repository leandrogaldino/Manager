Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Public Class FrmPerson
    Private _Person As Person
    Private _PersonsForm As FrmPersons
    Private _PersonsGrid As DataGridView
    Private _Filter As PersonFilter
    Private _CompressorsShadow As New OrdenedList(Of PersonCompressor)
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(Person As Person, PersonsForm As FrmPersons)
        _Person = Person
        _PersonsForm = PersonsForm
        _PersonsGrid = _PersonsForm.DgvData
        _Filter = CType(_PersonsForm.PgFilter.SelectedObject, PersonFilter)
        InitializeComponent()
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(Person As Person)
        _Person = Person
        InitializeComponent()
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        TcPerson.Height -= TsNavigation.Height
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvCompressorLayout.Load()
        DgvAddressLayout.Load()
        DgvContactLayout.Load()
    End Sub
    Private Sub LoadForm()
        Utility.EnableControlDoubleBuffer(DgvCompressor, True)
        Utility.EnableControlDoubleBuffer(DgvAddress, True)
        Utility.EnableControlDoubleBuffer(DgvContact, True)
        DgvNavigator.DataGridView = _PersonsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralLogAccess
    End Sub
    Private Sub LoadData()
        _Loading = True
        TcPerson.SelectedTab = TabMain
        LblIDValue.Text = _Person.ID
        BtnStatusValue.Text = GetEnumDescription(_Person.Status)
        LblCreationValue.Text = _Person.Creation.ToString("dd/MM/yyyy")
        RbtIsNaturalEntity.Checked = _Person.Entity = PersonEntity.Natural
        RbtIsLegalEntity.Checked = _Person.Entity = PersonEntity.Legal
        CbxIsCustomer.Checked = _Person.IsCustomer
        CbxIsProvider.Checked = _Person.IsProvider
        CbxIsEmployee.Checked = _Person.IsEmployee
        CbxIsTechnician.Checked = _Person.IsTechnician
        CbxIsCarrier.Checked = _Person.IsCarrier
        CbxMaintenance.Checked = _Person.ControlMaintenance
        TxtDocument.Text = _Person.Document
        TxtName.Text = _Person.Name
        TxtShortName.Text = _Person.ShortName
        TxtNote.Text = _Person.Note
        TxtFilterAddress.Clear()
        TxtFilterContact.Clear()
        TxtFilterCompressor.Clear()
        If _Person.Addresses IsNot Nothing Then _Person.Addresses.FillDataGridView(DgvAddress)
        If _Person.Contacts IsNot Nothing Then _Person.Contacts.FillDataGridView(DgvContact)
        If _Person.Compressors IsNot Nothing Then _Person.Compressors.FillDataGridView(DgvCompressor)
        BtnDelete.Enabled = _Person.ID < 0 And Locator.GetInstance(Of Session).User.Privilege.PersonDelete
        _CompressorsShadow.Clear()
        For Each Compressor As PersonCompressor In _Person.Compressors
            _CompressorsShadow.Add(Compressor.Clone)
        Next
        Text = "Pessoa"
        If _Person.LockInfo.IsLocked And Not _Person.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Person.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_Person.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtDocument.Select()
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
            _Person.Load(_PersonsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO PS001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
            If _PersonsForm IsNot Nothing Then
                _Person.Addresses.FillDataGridView(DgvAddress)
                _Person.Contacts.FillDataGridView(DgvContact)
                _Person.Compressors.FillDataGridView(DgvCompressor)
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
        _Person = New Person
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Person.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Person.LockInfo.IsLocked Or (_Person.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Person.LockInfo.SessionToken) Then
                        _Person.Delete()
                        If _PersonsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _PersonsForm.DgvPersonLayout.Load()
                            _PersonsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_Person.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO PS002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.Person, _Person.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive)
            If _Person.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
            If _Person.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub Radio_CheckedChanged(sender As Object, e As EventArgs) Handles RbtIsLegalEntity.CheckedChanged, RbtIsNaturalEntity.CheckedChanged
        TxtDocument.Text = Nothing
        LblDocument.Text = If(RbtIsLegalEntity.Checked, "CNPJ", "CPF")
        TxtDocument.Text = Nothing
        TxtDocument.MaxLength = If(RbtIsLegalEntity.Checked, 18, 14)
        BtnDocument.Visible = If(RbtIsLegalEntity.Checked, True, False)
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxCheckedChanged(sender As Object, e As EventArgs) Handles CbxIsCustomer.CheckedChanged,
                                                        CbxIsProvider.CheckedChanged,
                                                        CbxIsEmployee.CheckedChanged,
                                                        CbxIsCarrier.CheckedChanged,
                                                        CbxIsTechnician.CheckedChanged,
                                                        CbxMaintenance.CheckedChanged
        EprValidation.Clear()
        BtnSave.Enabled = True
    End Sub
    Private Sub TxtDocument_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocument.KeyPress
        If e.KeyChar = Chr(13) Then
            BtnDocument.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtDocument.TextChanged,
                                                        TxtName.TextChanged,
                                                        TxtShortName.TextChanged,
                                                        TxtNote.TextChanged
        EprValidation.Clear()
        BtnDocument.Enabled = IsValidLegalEntityDocument(TxtDocument.Text)
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtNote_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TxtNote.LinkClicked
        Process.Start(e.LinkText)
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
    Private Sub TxtDocument_Leave(sender As Object, e As EventArgs) Handles TxtDocument.Leave
        TxtDocument.Text = GetFormatedDocument(TxtDocument.Text)
    End Sub
    Private Sub BtnDocument_Click(sender As Object, e As EventArgs) Handles BtnDocument.Click
        Dim DataSearch As Consulta.CNPJ.Services.CNPJService
        Dim SearchResult As Consulta.CNPJ.Models.CNPJResult
        Dim Person As Person
        Dim FormGet As FrmPersonGetDocument
        TxtDocument.Text = GetFormatedDocument(TxtDocument.Text)
        Try
            Cursor = Cursors.WaitCursor
            If IsInternetAvailable() Then
                DataSearch = New Consulta.CNPJ.Services.CNPJService
                SearchResult = DataSearch.ConsultarCPNJ(TxtDocument.Text.Replace(".", Nothing).Replace("-", Nothing).Replace("/", Nothing))
                If SearchResult IsNot Nothing Then
                    Person = New Person
                    Person.Document = TxtDocument.Text
                    Person.Name = SearchResult.Nome
                    Person.ShortName = SearchResult.Fantasia
                    Person.Contacts.Add(New PersonContact With {
                        .Name = Nothing,
                        .Phone = GetFormatedPhoneNumber(SearchResult.Telefone),
                        .Email = SearchResult.Email,
                        .IsMainContact = _Person.Contacts.Count = 0,
                        .IsSaved = True
                    })
                    Person.Addresses.Add(New PersonAddress() With {
                        .Name = "SEDE",
                        .ZipCode = SearchResult.Cep,
                        .Street = SearchResult.Logradouro,
                        .Number = SearchResult.Numero,
                        .Complement = SearchResult.Complemento,
                        .District = SearchResult.Bairro,
                        .City = New City().Load(City.GetID(RemoveAccents(SearchResult.Municipio), SearchResult.Uf), False),
                        .IsMainAddress = _Person.Addresses.Count = 0,
                        .IsSaved = True
                    })
                    FormGet = New FrmPersonGetDocument(Person, SearchResult)
                    If FormGet.ShowDialog() = DialogResult.OK Then
                        If FormGet.CbxImportIdentity.Checked Then
                            TxtName.Text = Person.Name
                            TxtShortName.Text = Person.ShortName
                        End If
                        If FormGet.CbxImportContact.Checked Then
                            _Person.Contacts.Add(Person.Contacts(0))
                            _Person.Contacts.FillDataGridView(DgvContact)
                        End If
                        If FormGet.CbxImportAddress.Checked Then
                            _Person.Addresses.Add(Person.Addresses(0))
                            _Person.Addresses.FillDataGridView(DgvAddress)
                        End If
                    End If
                Else
                    CMessageBox.Show("A busca não retornou dados, verifique o número digitado e tente novamente.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                End If
            Else
                CMessageBox.Show("Por favor, verifique se há conexão com a internet e tente novamente..", CMessageBoxType.Warning)
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO PS003", "Ocorreu um erro ao consultar o CNPJ.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Sub BtnIncludeAddress_Click(sender As Object, e As EventArgs) Handles BtnIncludeAddress.Click
        Dim Form As New FrmPersonAddress(_Person, New PersonAddress(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditAddress_Click(sender As Object, e As EventArgs) Handles BtnEditAddress.Click
        Dim Form As FrmPersonAddress
        Dim Address As PersonAddress
        If DgvAddress.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            Address = _Person.Addresses.Single(Function(x) x.Order = DgvAddress.SelectedRows(0).Cells("Order").Value)
            Form = New FrmPersonAddress(_Person, Address, Me)
            Form.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub BtnDeleteAddress_Click(sender As Object, e As EventArgs) Handles BtnDeleteAddress.Click
        Dim Address As PersonAddress
        If DgvAddress.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Address = _Person.Addresses.Single(Function(x) x.Order = DgvAddress.SelectedRows(0).Cells("Order").Value)
                If Not Address.IsMainAddress Then
                    _Person.Addresses.Remove(Address)
                    _Person.Addresses.FillDataGridView(DgvAddress)
                    BtnSave.Enabled = True
                Else
                    CMessageBox.Show("O endereço principal não pode ser excluido.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub
    Private Sub BtnIncludeContact_Click(sender As Object, e As EventArgs) Handles BtnIncludeContact.Click
        Dim Form As New FrmPersonContact(_Person, New PersonContact, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditContact_Click(sender As Object, e As EventArgs) Handles BtnEditContact.Click
        Dim Form As FrmPersonContact
        Dim Contact As PersonContact
        If DgvContact.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            Contact = _Person.Contacts.Single(Function(x) x.Order = DgvContact.SelectedRows(0).Cells("Order").Value)
            Form = New FrmPersonContact(_Person, Contact, Me)
            Form.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub BtnDeleteContact_Click(sender As Object, e As EventArgs) Handles BtnDeleteContact.Click
        Dim Contact As PersonContact
        If DgvContact.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Contact = _Person.Contacts.Single(Function(x) x.Order = DgvContact.SelectedRows(0).Cells("Order").Value)
                If Not Contact.IsMainContact Then
                    _Person.Contacts.Remove(Contact)
                    _Person.Contacts.FillDataGridView(DgvContact)
                    BtnSave.Enabled = True
                Else
                    CMessageBox.Show("O contato principal não pode ser excluido.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub
    Private Sub BtnIncludeCompressor_Click(sender As Object, e As EventArgs) Handles BtnIncludeCompressor.Click
        Dim Form As New FrmPersonCompressor(_Person, New PersonCompressor(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditCompressor_Click(sender As Object, e As EventArgs) Handles BtnEditCompressor.Click
        Dim Form As FrmPersonCompressor
        Dim Compressor As PersonCompressor
        If DgvCompressor.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            Compressor = _Person.Compressors.Single(Function(x) x.Order = DgvCompressor.SelectedRows(0).Cells("Order").Value)
            Form = New FrmPersonCompressor(_Person, Compressor, Me)
            Form.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub BtnDeleteCompressor_Click(sender As Object, e As EventArgs) Handles BtnDeleteCompressor.Click
        Dim Compressor As PersonCompressor
        If DgvCompressor.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Compressor = _Person.Compressors.Single(Function(x) x.Order = DgvCompressor.SelectedRows(0).Cells("Order").Value)
                _Person.Compressors.Remove(Compressor)
                _Person.Compressors.FillDataGridView(DgvCompressor)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub TcPerson_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcPerson.SelectedIndexChanged
        If TcPerson.SelectedTab Is TabMain Then
            Size = If(_PersonsForm IsNot Nothing, New Size(653, 270), New Size(653, 270 - TsNavigation.Height))
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvCompressor_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvCompressor.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Status").Index Then
            Select Case e.Value
                Case Is = SimpleStatus.Active
                    e.Value = GetEnumDescription(SimpleStatus.Active)
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case Is = SimpleStatus.Inactive
                    e.Value = GetEnumDescription(SimpleStatus.Inactive)
                    e.CellStyle.ForeColor = Color.DarkRed
            End Select
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvAddress_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvAddress.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Status").Index Then
            Select Case e.Value
                Case Is = SimpleStatus.Active
                    e.Value = GetEnumDescription(SimpleStatus.Active)
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case Is = SimpleStatus.Inactive
                    e.Value = GetEnumDescription(SimpleStatus.Inactive)
                    e.CellStyle.ForeColor = Color.DarkRed
            End Select
        ElseIf e.ColumnIndex = Dgv.Columns("ContributionType").Index Then
            Select Case e.Value
                Case Is = PersonContribution.TaxPayer
                    e.Value = GetEnumDescription(PersonContribution.TaxPayer)
                Case Is = PersonContribution.NonTaxPayer
                    e.Value = GetEnumDescription(PersonContribution.NonTaxPayer)
                Case Is = PersonContribution.TaxFree
                    e.Value = GetEnumDescription(PersonContribution.TaxFree)
            End Select
        End If
    End Sub
    Private Sub DgvAddress_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvAddress.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvAddress.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditAddress.PerformClick()
        End If
    End Sub
    Private Sub DgvContact_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvContact.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvContact.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditContact.PerformClick()
        End If
    End Sub
    Private Sub DgvCompressor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCompressor.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCompressor.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditCompressor.PerformClick()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtDocument.Text) Then
            EprValidation.SetError(LblDocument, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblDocument, ErrorIconAlignment.MiddleRight)
            TcPerson.SelectedTab = TabMain
            TxtDocument.Select()
            Return False
        ElseIf _Person.ID > 0 AndAlso (Not Locator.GetInstance(Of Session).User.Privilege.PersonChangeDocument And _Person.Document <> TxtDocument.Text) Then
            EprValidation.SetError(LblDocument, String.Format("Você não tem permissão para alterar o {0} de uma pessoa que já foi salva.", If(RbtIsLegalEntity.Checked, "CNPJ", "CPF")))
            EprValidation.SetIconAlignment(LblDocument, ErrorIconAlignment.MiddleRight)
            TcPerson.SelectedTab = TabMain
            TxtDocument.Select()
            Return False
        ElseIf RbtIsNaturalEntity.Checked And Not IsValidNaturalEntityDocument(TxtDocument.Text) Then
            EprValidation.SetError(LblDocument, "CPF inválido.")
            EprValidation.SetIconAlignment(LblDocument, ErrorIconAlignment.MiddleRight)
            TcPerson.SelectedTab = TabMain
            TxtDocument.Select()
            Return False
        ElseIf RbtIsLegalEntity.Checked And Not IsValidLegalEntityDocument(TxtDocument.Text) Then
            EprValidation.SetError(LblDocument, "CNPJ inválido.")
            EprValidation.SetIconAlignment(LblDocument, ErrorIconAlignment.MiddleRight)
            TcPerson.SelectedTab = TabMain
            TxtDocument.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TcPerson.SelectedTab = TabMain
            TxtName.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtShortName.Text) Then
            EprValidation.SetError(LblShortName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblShortName, ErrorIconAlignment.MiddleRight)
            TcPerson.SelectedTab = TabMain
            TxtShortName.Select()
            Return False
        ElseIf _Person.Addresses.Count = 0 Then
            EprValidation.SetError(TsAddress, "É necessário cadastrar pelo menos um endereço.")
            EprValidation.SetIconAlignment(TsAddress, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsAddress, -90)
            TcPerson.SelectedTab = TabAddress
            DgvAddress.Select()
            Return False
        ElseIf _Person.Contacts.Count = 0 Then
            EprValidation.SetError(TsContact, "É necessário cadastrar pelo menos um contato.")
            EprValidation.SetIconAlignment(TsContact, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsContact, -90)
            TcPerson.SelectedTab = TabContact
            DgvContact.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = RemoveAccents(TxtName.Text.Trim)
        TxtShortName.Text = RemoveAccents(TxtShortName.Text.Trim)
        TxtNote.Text = RemoveAccents(TxtNote.Text.ToUpper)
        If _Person.LockInfo.IsLocked And _Person.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_Person.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Person.Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    _Person.Entity = If(RbtIsLegalEntity.Checked, PersonEntity.Legal, PersonEntity.Natural)
                    _Person.IsCustomer = CbxIsCustomer.Checked
                    _Person.IsProvider = CbxIsProvider.Checked
                    _Person.IsEmployee = CbxIsEmployee.Checked
                    _Person.IsTechnician = CbxIsTechnician.Checked
                    _Person.IsCarrier = CbxIsCarrier.Checked
                    _Person.ControlMaintenance = CbxMaintenance.Checked
                    _Person.Name = TxtName.Text
                    _Person.ShortName = TxtShortName.Text
                    _Person.Document = TxtDocument.Text
                    _Person.Note = TxtNote.Text
                    _Person.SaveChanges()
                    _Person.Lock()
                    LblIDValue.Text = _Person.ID
                    _Person.Addresses.FillDataGridView(DgvAddress)
                    _Person.Contacts.FillDataGridView(DgvContact)
                    _Person.Compressors.FillDataGridView(DgvCompressor)
                    _CompressorsShadow.Clear()
                    For Each Compressor As PersonCompressor In _Person.Compressors
                        _CompressorsShadow.Add(Compressor.Clone)
                    Next
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = Locator.GetInstance(Of Session).User.Privilege.PersonDelete
                    If _PersonsForm IsNot Nothing Then
                        _Filter.Filter()
                        _PersonsForm.DgvPersonLayout.Load()
                        Row = _PersonsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        If RbtIsNaturalEntity.Checked Then
                            CMessageBox.Show("Já existe uma pessoa cadastrada com esse CPF. Caso o cadastro tenha sido importado será necessário excluir o endereço e contato manualmente.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                        Else
                            CMessageBox.Show("Já existe uma pessoa cadastrada com esse CNPJ. Caso o cadastro tenha sido importado será necessário excluir o endereço e contato manualmente", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                        End If
                    ElseIf ex.Message.Contains("evaluation_personcompressor") Then
                        CMessageBox.Show("Existe avaliação para um ou mais compressores excluídos. Todos os compressores excluídos serão restaurados.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                        For Each Compressor As PersonCompressor In _CompressorsShadow
                            If Not _Person.Compressors.Any(Function(x) x.ID = Compressor.ID) Then
                                _Person.Compressors.Add(Compressor.Clone)
                            End If
                        Next
                        _Person.Compressors.FillDataGridView(DgvCompressor)
                    ElseIf ex.Message.Contains("evaluationpart_personcompressorpart") Then
                        CMessageBox.Show("Existe avaliação para um ou mais itens excluídos. Todos os itens excluídos serão restaurados.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                        For Each Compressor As PersonCompressor In _CompressorsShadow
                            For Each PartWorkedHour As PersonCompressorPart In Compressor.PartsWorkedHour
                                If Not _Person.Compressors.Single(Function(x) x.ID = Compressor.ID).PartsWorkedHour.Any(Function(y) y.ID = PartWorkedHour.ID) Then
                                    _Person.Compressors.Single(Function(x) x.ID = Compressor.ID).PartsWorkedHour.Add(Compressor.PartsWorkedHour.Single(Function(y) y.ID = PartWorkedHour.ID))
                                End If
                            Next PartWorkedHour
                            For Each PartElapsedDay As PersonCompressorPart In Compressor.PartsElapsedDay
                                If Not _Person.Compressors.Single(Function(x) x.ID = Compressor.ID).PartsElapsedDay.Any(Function(y) y.ID = PartElapsedDay.ID) Then
                                    _Person.Compressors.Single(Function(x) x.ID = Compressor.ID).PartsElapsedDay.Add(Compressor.PartsElapsedDay.Single(Function(y) y.ID = PartElapsedDay.ID))
                                End If
                            Next PartElapsedDay
                        Next
                        _Person.Compressors.FillDataGridView(DgvCompressor)
                    Else
                        CMessageBox.Show("ERRO PS004", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
    Private Sub TxtFilterAddress_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterAddress.TextChanged
        FilterAddress()
    End Sub
    Private Sub FilterAddress()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2} OR {3} OR {4} OR {5} OR {6} OR {7}",
                                "ZipCode LIKE '%@VALUE%'",
                                "Street LIKE '%@VALUE%'",
                                "Number LIKE '%@VALUE%'",
                                "Complement LIKE '%@VALUE%'",
                                "District LIKE '%@VALUE%'",
                                "Convert([City], 'System.String') LIKE '%@VALUE%'",
                                "CityDocument LIKE '%@VALUE%'",
                                "StateDocument LIKE '%@VALUE%'"
                        )
        If DgvAddress.DataSource IsNot Nothing Then
            Table = DgvAddress.DataSource
            View = Table.DefaultView
            If TxtFilterAddress.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterAddress.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterAddress.KeyPress,
                                                                        TxtFilterContact.KeyPress,
                                                                        TxtFilterCompressor.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}

        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterContact_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterContact.TextChanged
        FilterContact()
    End Sub
    Private Sub FilterContact()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2} OR {3}",
                                "Name LIKE '%@VALUE%'",
                                "JobTitle LIKE '%@VALUE%'",
                                "Phone LIKE '%@VALUE%'",
                                "Email LIKE '%@VALUE%'"
                        )
        If DgvContact.DataSource IsNot Nothing Then
            Table = DgvContact.DataSource
            View = Table.DefaultView
            If TxtFilterContact.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterContact.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterCompressor_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterCompressor.TextChanged
        FilterCompressor()
    End Sub
    Private Sub FilterCompressor()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2} OR {3}",
                                "Convert([Compressor], 'System.String') LIKE '%@VALUE%'",
                                "[Patrimony] LIKE '%@VALUE%'",
                                "[SerialNumber] LIKE '%@VALUE%'",
                                "[Sector] LIKE '%@VALUE%'"
                        )
        If DgvCompressor.DataSource IsNot Nothing Then
            Table = DgvCompressor.DataSource
            View = Table.DefaultView
            If TxtFilterCompressor.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterCompressor.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub DgvAddress_SelectionChanged(sender As Object, e As EventArgs) Handles DgvAddress.SelectionChanged
        If DgvAddress.SelectedRows.Count = 0 Then
            BtnEditAddress.Enabled = False
            BtnDeleteAddress.Enabled = False
        Else
            BtnEditAddress.Enabled = True
            BtnDeleteAddress.Enabled = True
        End If
    End Sub
    Private Sub DgvContact_SelectionChanged(sender As Object, e As EventArgs) Handles DgvContact.SelectionChanged
        If DgvContact.SelectedRows.Count = 0 Then
            BtnEditContact.Enabled = False
            BtnDeleteContact.Enabled = False
        Else
            BtnEditContact.Enabled = True
            BtnDeleteContact.Enabled = True
        End If
    End Sub
    Private Sub DgvCompressor_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCompressor.SelectionChanged
        If DgvCompressor.SelectedRows.Count = 0 Then
            BtnEditCompressor.Enabled = False
            BtnDeleteCompressor.Enabled = False
        Else
            BtnEditCompressor.Enabled = True
            BtnDeleteCompressor.Enabled = True
        End If
    End Sub
    Private Sub BtnDocument_EnabledChanged(sender As Object, e As EventArgs) Handles BtnDocument.EnabledChanged
        If BtnDocument.Enabled Then
            BtnDocument.BackgroundImage = My.Resources.Magnifier
        Else
            BtnDocument.BackgroundImage = Utility.GetRecoloredImage(My.Resources.Magnifier, Color.Gray)
        End If
    End Sub
    Private Sub TxtFilterAddress_Enter(sender As Object, e As EventArgs) Handles TxtFilterAddress.Enter
        EprInformation.SetError(TsAddress, "Filtrando os campos: CEP, Rua, Número, Complemento, Bairro, Cidade, IE, IM.")
        EprInformation.SetIconAlignment(TsAddress, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsAddress, -365)
    End Sub
    Private Sub TxtFilterAddress_Leave(sender As Object, e As EventArgs) Handles TxtFilterAddress.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterContact_Enter(sender As Object, e As EventArgs) Handles TxtFilterContact.Enter
        EprInformation.SetError(TsContact, "Filtrando os campos: Nome, Cargo, Telefone e E-Mail.")
        EprInformation.SetIconAlignment(TsContact, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsContact, -365)
    End Sub
    Private Sub TxtFilterContact_Leave(sender As Object, e As EventArgs) Handles TxtFilterContact.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterCompressor_Enter(sender As Object, e As EventArgs) Handles TxtFilterCompressor.Enter
        EprInformation.SetError(TsCompressor, "Filtrando os campos: Compressor, Patrimônio, Nº Série e Setor.")
        EprInformation.SetIconAlignment(TsCompressor, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsCompressor, -365)
    End Sub
    Private Sub TxtFilterCompressor_Leave(sender As Object, e As EventArgs) Handles TxtFilterCompressor.Leave
        EprInformation.Clear()
    End Sub
    Private Sub FrmPerson_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Person.Unlock()
    End Sub

    Private Sub DgvAddress_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvAddress.DataSourceChanged
        FilterAddress()
    End Sub
    Private Sub DgvContact_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvContact.DataSourceChanged
        FilterContact()
    End Sub
    Private Sub DgvCompressor_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvCompressor.DataSourceChanged
        FilterCompressor()
    End Sub
End Class