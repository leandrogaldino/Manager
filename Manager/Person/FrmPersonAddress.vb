Imports ControlLibrary
Imports ControlLibrary.Utility
Imports ViaCep
Public Class FrmPersonAddress
    Private _PersonForm As FrmPerson
    Private _Person As Person
    Private _PersonAddress As PersonAddress
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
    Public Sub New(Person As Person, Address As PersonAddress, PersonForm As FrmPerson)
        InitializeComponent()
        _Person = Person
        _PersonAddress = Address
        _PersonForm = PersonForm
        _User = Locator.GetInstance(Of Session).User
        CbxContributionType.DataSource = {GetEnumDescription(PersonContributionType.TaxPayer), GetEnumDescription(PersonContributionType.NonTaxPayer), GetEnumDescription(PersonContributionType.TaxFree)}
        LoadForm()
        DgvNavigator.DataGridView = _PersonForm.DgvAddress
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
        If _PersonForm.DgvAddress.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _PersonAddress = _Person.Addresses.Single(Function(x) x.Order = _PersonForm.DgvAddress.SelectedRows(0).Cells("Order").Value)
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
        _PersonAddress = New PersonAddress()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PersonForm.DgvAddress.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _PersonAddress = _Person.Addresses.Single(Function(x) x.Order = _PersonForm.DgvAddress.SelectedRows(0).Cells("Order").Value)
                _Person.Addresses.Remove(_PersonAddress)
                _Person.Addresses.FillDataGridView(_PersonForm.DgvAddress)
                _PersonForm.DgvAddressLayout.Load()
                _Deleting = True
                Dispose()
                _PersonForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.PersonAddress, _PersonAddress.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active) Then
            If CbxIsMainAddress.Checked Then
                CMessageBox.Show("O endereço principal não pode inativado.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
            Else
                BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive)
                If _PersonAddress.Status = SimpleStatus.Active Then
                    CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
                End If
                BtnSave.Enabled = True
            End If
        ElseIf BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
            If _PersonAddress.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
            BtnSave.Enabled = True
        End If
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
        CbxIsMainAddress.Enabled = BtnStatusValue.Text = GetEnumDescription(SimpleStatus.Active)
    End Sub
    Private Sub CbxIsMainAddress_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIsMainAddress.CheckedChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged,
                                                                         TxtZipCode.TextChanged,
                                                                         TxtStreet.TextChanged,
                                                                         TxtNumber.TextChanged,
                                                                         TxtComplement.TextChanged,
                                                                         TxtDistrict.TextChanged,
                                                                         QbxCity.TextChanged,
                                                                         TxtCityDocument.TextChanged,
                                                                         TxtStateDocument.TextChanged,
                                                                         QbxCarrier.TextChanged
        EprValidation.Clear()
        BtnZipCode.Enabled = IsValidZipCode(TxtZipCode.Text)
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxContributionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxContributionType.SelectedIndexChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _PersonAddress.Order
        BtnStatusValue.Text = GetEnumDescription(_PersonAddress.Status)
        LblCreationValue.Text = _PersonAddress.Creation
        TxtName.Text = _PersonAddress.Name
        CbxIsMainAddress.Checked = _PersonAddress.IsMainAddress
        TxtZipCode.Text = _PersonAddress.ZipCode
        TxtStreet.Text = _PersonAddress.Street
        TxtNumber.Text = _PersonAddress.Number
        TxtComplement.Text = _PersonAddress.Complement
        TxtDistrict.Text = _PersonAddress.District
        QbxCity.Unfreeze()
        QbxCity.Freeze(_PersonAddress.City.ID)
        TxtCityDocument.Text = _PersonAddress.CityDocument
        TxtStateDocument.Text = _PersonAddress.StateDocument
        CbxContributionType.Text = GetEnumDescription(_PersonAddress.ContributionType)
        QbxCarrier.Unfreeze()
        QbxCarrier.Freeze(_PersonAddress.Carrier.ID)
        If _Person.Addresses.Count = 0 Then
            CbxIsMainAddress.Checked = True
        End If
        If CbxIsMainAddress.Checked Then
            CbxIsMainAddress.Enabled = False
        Else
            CbxIsMainAddress.Enabled = _PersonAddress.Status = SimpleStatus.Active
        End If
        If _PersonAddress.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        TxtName.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TxtName.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtZipCode.Text) Then
            EprValidation.SetError(LblZipCode, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblZipCode, ErrorIconAlignment.MiddleRight)
            TxtZipCode.Select()
            Return False
        ElseIf Not IsValidZipCode(TxtZipCode.Text) Then
            EprValidation.SetError(LblZipCode, "CEP inválido.")
            EprValidation.SetIconAlignment(LblZipCode, ErrorIconAlignment.MiddleRight)
            TxtZipCode.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtStreet.Text) Then
            EprValidation.SetError(LblStreet, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblStreet, ErrorIconAlignment.MiddleRight)
            TxtStreet.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtNumber.Text) And String.IsNullOrWhiteSpace(TxtComplement.Text) Then
            EprValidation.SetError(LblNumber, "Um endereço deve conter um número, ou um complemento, ou os dois.")
            EprValidation.SetIconAlignment(LblNumber, ErrorIconAlignment.MiddleRight)
            TxtNumber.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtDistrict.Text) Then
            EprValidation.SetError(LblDistrict, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblDistrict, ErrorIconAlignment.MiddleRight)
            TxtDistrict.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxCity.Text) Then
            EprValidation.SetError(LblCity, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCity, ErrorIconAlignment.MiddleRight)
            QbxCity.Select()
            Return False
        ElseIf Not QbxCity.IsFreezed Then
            EprValidation.SetError(LblCity, "Cidade não encontrada.")
            EprValidation.SetIconAlignment(LblCity, ErrorIconAlignment.MiddleRight)
            QbxCity.Select()
            Return False
        ElseIf CbxContributionType.Text = GetEnumDescription(PersonContributionType.TaxPayer) And String.IsNullOrWhiteSpace(TxtStateDocument.Text) Then
            EprValidation.SetError(LblStateDocument, "Campo obrigatório para Contribuintes de ICMS.")
            EprValidation.SetIconAlignment(LblStateDocument, ErrorIconAlignment.MiddleRight)
            TxtStateDocument.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(QbxCarrier.Text) And Not QbxCarrier.IsFreezed Then
            EprValidation.SetError(LblCarrier, "Transportadora não encontrada.")
            EprValidation.SetIconAlignment(LblCarrier, ErrorIconAlignment.MiddleRight)
            QbxCarrier.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = RemoveAccents(TxtName.Text.Trim)
        TxtZipCode.Text = RemoveAccents(TxtZipCode.Text.Trim)
        TxtStreet.Text = RemoveAccents(TxtStreet.Text.Trim)
        TxtNumber.Text = RemoveAccents(TxtNumber.Text.Trim)
        TxtComplement.Text = RemoveAccents(TxtComplement.Text.Trim)
        TxtDistrict.Text = RemoveAccents(TxtDistrict.Text.Trim)
        TxtStateDocument.Text = RemoveAccents(TxtStateDocument.Text.Trim)
        TxtCityDocument.Text = RemoveAccents(TxtCityDocument.Text.Trim)
        If IsValidFields() Then
            If _PersonAddress.IsSaved Then
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).IsMainAddress = CbxIsMainAddress.Checked
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).Name = TxtName.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).ZipCode = TxtZipCode.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).Street = TxtStreet.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).Number = TxtNumber.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).Complement = TxtComplement.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).District = TxtDistrict.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).City = New City().Load(QbxCity.FreezedPrimaryKey, False)
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).CityDocument = TxtCityDocument.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).StateDocument = TxtStateDocument.Text
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).ContributionType = GetEnumValue(Of PersonContributionType)(CbxContributionType.Text)
                _Person.Addresses.Single(Function(x) x.Order = _PersonAddress.Order).Carrier = New Person().Load(QbxCarrier.FreezedPrimaryKey, False)
            Else
                _PersonAddress = New PersonAddress()
                _PersonAddress.IsMainAddress = CbxIsMainAddress.Checked
                _PersonAddress.Status = GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _PersonAddress.Name = TxtName.Text
                _PersonAddress.ZipCode = TxtZipCode.Text
                _PersonAddress.Street = TxtStreet.Text
                _PersonAddress.Number = TxtNumber.Text
                _PersonAddress.Complement = TxtComplement.Text
                _PersonAddress.District = TxtDistrict.Text
                _PersonAddress.City = New City().Load(QbxCity.FreezedPrimaryKey, False)
                _PersonAddress.CityDocument = TxtCityDocument.Text
                _PersonAddress.StateDocument = TxtStateDocument.Text
                _PersonAddress.ContributionType = GetEnumValue(Of PersonContributionType)(CbxContributionType.Text)
                _PersonAddress.Carrier = New Person().Load(QbxCarrier.FreezedPrimaryKey, False)
                _PersonAddress.IsSaved = True
                _Person.Addresses.Add(_PersonAddress)
            End If
            If CbxIsMainAddress.Checked Then
                CbxIsMainAddress.Enabled = False
                For Each Address As PersonAddress In _Person.Addresses
                    If Address.Order <> _PersonAddress.Order Then
                        Address.IsMainAddress = False
                    End If
                Next Address
            Else
                CbxIsMainAddress.Enabled = _PersonAddress.Status = SimpleStatus.Active
            End If
            _Person.Addresses.FillDataGridView(_PersonForm.DgvAddress)
            LblOrderValue.Text = _PersonAddress.Order
            _PersonForm.DgvAddressLayout.Load()
            BtnSave.Enabled = False
            If _PersonAddress.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _PersonForm.DgvAddress.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _PersonAddress.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _PersonForm.EprValidation.Clear()
            _PersonForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TmrQueriedBoxCity_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBoxCity.Tick
        BtnViewCity.Visible = False
        BtnNewCity.Visible = False
        BtnFilterCity.Visible = False
        TmrQueriedBoxCity.Stop()
    End Sub
    Private Sub QbxCity_Enter(sender As Object, e As EventArgs) Handles QbxCity.Enter
        TmrQueriedBoxCity.Stop()
        BtnViewCity.Visible = QbxCity.IsFreezed And _User.CanWrite(Routine.City)
        BtnNewCity.Visible = _User.CanWrite(Routine.City)
        BtnFilterCity.Visible = _User.CanAccess(Routine.City)
    End Sub
    Private Sub QbxCity_Leave(sender As Object, e As EventArgs) Handles QbxCity.Leave
        TmrQueriedBoxCity.Stop()
        TmrQueriedBoxCity.Start()
    End Sub
    Private Sub QbxCity_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCity.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewCity.Visible = QbxCity.IsFreezed And _User.CanWrite(Routine.City)
    End Sub
    Private Sub BtnNewCity_Click(sender As Object, e As EventArgs) Handles BtnNewCity.Click
        Dim City As City
        Dim Form As FrmCity
        City = New City
        Form = New FrmCity(City)
        Form.ShowDialog()
        EprValidation.Clear()
        If City.ID > 0 Then
            QbxCity.Freeze(City.ID)
        End If
        QbxCity.Select()
    End Sub
    Private Sub BtnViewCity_Click(sender As Object, e As EventArgs) Handles BtnViewCity.Click
        Dim Form As New FrmCity(New City().Load(QbxCity.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxCity.Freeze(QbxCity.FreezedPrimaryKey)
        QbxCity.Select()
    End Sub
    Private Sub BtnFilterCity_Click(sender As Object, e As EventArgs) Handles BtnFilterCity.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New CityQueriedBoxFilter(), QbxCity)
        FilterForm.Text = "Filtro de Cidades"
        FilterForm.ShowDialog()
        QbxCity.Select()
    End Sub
    Private Sub TmrQueriedBoxCarrier_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBoxCarrier.Tick
        BtnViewCarrier.Visible = False
        BtnNewCarrier.Visible = False
        BtnFilterCarrier.Visible = False
        TmrQueriedBoxCarrier.Stop()
    End Sub
    Private Sub QbxCarrier_Enter(sender As Object, e As EventArgs) Handles QbxCarrier.Enter
        TmrQueriedBoxCarrier.Stop()
        BtnViewCarrier.Visible = QbxCarrier.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNewCarrier.Visible = _User.CanWrite(Routine.Person)
        BtnFilterCarrier.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxCarrier_Leave(sender As Object, e As EventArgs) Handles QbxCarrier.Leave
        TmrQueriedBoxCarrier.Stop()
        TmrQueriedBoxCarrier.Start()
    End Sub
    Private Sub QbxCarrier_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCarrier.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewCarrier.Visible = QbxCarrier.IsFreezed And _User.CanWrite(Routine.Person)
    End Sub
    Private Sub BtnNewCarrier_Click(sender As Object, e As EventArgs) Handles BtnNewCarrier.Click
        Dim Carrier As Person
        Dim Form As FrmPerson
        Carrier = New Person
        Carrier.IsCarrier = True
        Form = New FrmPerson(Carrier)
        Form.CbxIsCarrier.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Carrier.ID > 0 Then
            QbxCarrier.Freeze(Carrier.ID)
        End If
        QbxCarrier.Select()
    End Sub
    Private Sub BtnViewCarrier_Click(sender As Object, e As EventArgs) Handles BtnViewCarrier.Click
        Dim Form As New FrmPerson(New Person().Load(QbxCarrier.FreezedPrimaryKey, True))
        Form.CbxIsCarrier.Enabled = False
        Form.ShowDialog()
        QbxCarrier.Freeze(QbxCarrier.FreezedPrimaryKey)
        QbxCarrier.Select()
    End Sub
    Private Sub BtnFilterCarrier_Click(sender As Object, e As EventArgs) Handles BtnFilterCarrier.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonCarrierQueriedBoxFilter(), QbxCarrier)
        FilterForm.Text = "Filtro de Transportadoras"
        FilterForm.ShowDialog()
        QbxCarrier.Select()
    End Sub
    Private Sub TxtZipCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtZipCode.KeyPress
        If e.KeyChar = Chr(13) Then
            BtnZipCode.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub TxtZipCode_Leave(sender As Object, e As EventArgs) Handles TxtZipCode.Leave
        EprValidation.Clear()
        If IsValidZipCode(TxtZipCode.Text) Then TxtZipCode.Text = GetFormatedZipCode(TxtZipCode.Text)
    End Sub
    Private Sub BtnZipCode_Click(sender As Object, e As EventArgs) Handles BtnZipCode.Click
        Dim PersonAddress As PersonAddress
        Dim FormGet As FrmPersonAddressGetZipCode
        TxtZipCode.Text = GetFormatedZipCode(TxtZipCode.Text)
        Try
            Cursor = Cursors.WaitCursor
            If IsInternetAvailable() Then
                Dim Client = New ViaCepClient()
                Dim Result = Client.Search(TxtZipCode.Text.Trim)


                If Result IsNot Nothing Then
                    PersonAddress = New PersonAddress With {
                            .Name = Nothing,
                            .ZipCode = Result.ZipCode,
                            .Street = Result.Street,
                            .District = Result.Neighborhood,
                            .City = New City().Load(City.GetID(RemoveAccents(Result.City), Result.StateInitials), False),
                            .IsMainAddress = _Person.Addresses.Count = 0,
                            .IsSaved = True
                        }
                    FormGet = New FrmPersonAddressGetZipCode(PersonAddress, Result)
                    If FormGet.ShowDialog() = DialogResult.OK Then
                        TxtName.Text = FormGet.TxtAddressName.Text
                        TxtStreet.Text = FormGet.TxtStreet.Text
                        TxtDistrict.Text = FormGet.TxtDistrict.Text
                        QbxCity.Unfreeze()
                        If FormGet.QbxCity.IsFreezed Then

                            QbxCity.Freeze(FormGet.QbxCity.FreezedPrimaryKey)
                        Else
                            QbxCity.QueryEnabled = False
                            QbxCity.Text = FormGet.QbxCity.Text
                            QbxCity.QueryEnabled = True
                        End If
                    End If
                Else
                    CMessageBox.Show("A busca não retornou dados, verifique o número digitado e tente novamente.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    End If

            Else
                CMessageBox.Show("Por favor, verifique se há conexão com a internet e tente novamente..", CMessageBoxType.Warning)
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO PS005", "Ocorreu um erro ao consultar o CEP.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnZipCode_EnabledChanged(sender As Object, e As EventArgs) Handles BtnZipCode.EnabledChanged
        If BtnZipCode.Enabled Then
            BtnZipCode.BackgroundImage = My.Resources.Magnifier
        Else
            BtnZipCode.BackgroundImage = Utility.GetRecoloredImage(My.Resources.Magnifier, Color.Gray)
        End If
    End Sub
End Class