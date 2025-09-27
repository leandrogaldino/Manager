Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmPersonGetDocument
    Private _Person As Person
    Private _Search As Consulta.CNPJ.Models.CNPJResult
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
    Public Sub New(Person As Person, Search As Consulta.CNPJ.Models.CNPJResult)
        InitializeComponent()
        _Person = Person
        _Search = Search
        _User = Locator.GetInstance(Of Session).User
        TxtDocument.Text = _Person.Document
        TxtName.Text = _Person.Name
        TxtShortName.Text = _Person.ShortName
        TxtContactName.Text = _Person.Contacts(0).Name
        TxtPhone.Text = _Person.Contacts(0).Phone
        TxtEmail.Text = _Person.Contacts(0).Email
        TxtAddressName.Text = _Person.Addresses(0).Name
        TxtZipCode.Text = _Person.Addresses(0).ZipCode
        TxtStreet.Text = _Person.Addresses(0).Street
        TxtNumber.Text = _Person.Addresses(0).Number
        TxtComplement.Text = _Person.Addresses(0).Complement
        TxtDistrict.Text = _Person.Addresses(0).District
        If _Person.Addresses(0).City.ID = 0 Or (_Person.Addresses(0).City.ID > 0 And _Person.Addresses(0).City.Status = SimpleStatus.Inactive) Then
            QbxCity.Text = _Search.Municipio
        Else
            QbxCity.Unfreeze()
            QbxCity.Freeze(_Person.Addresses(0).City.ID)
        End If
        TxtName.Select()
    End Sub
    Private Sub CbxImportIdentity_CheckedChanged(sender As Object, e As EventArgs) Handles CbxImportIdentity.CheckedChanged
        If CbxImportIdentity.Checked Then
            GbxIdentity.Enabled = True
        Else
            GbxIdentity.Enabled = False
        End If
        If Not CbxImportIdentity.Checked And Not CbxImportContact.Checked And Not CbxImportAddress.Checked Then
            BtnImport.Enabled = False
        Else
            BtnImport.Enabled = True
        End If
    End Sub
    Private Sub CbxContact_CheckedChanged(sender As Object, e As EventArgs) Handles CbxImportContact.CheckedChanged
        If CbxImportContact.Checked Then
            GbxContact.Enabled = True
        Else
            GbxContact.Enabled = False
        End If
        If Not CbxImportIdentity.Checked And Not CbxImportContact.Checked And Not CbxImportAddress.Checked Then
            BtnImport.Enabled = False
        Else
            BtnImport.Enabled = True
        End If
    End Sub
    Private Sub CbxAddress_CheckedChanged(sender As Object, e As EventArgs) Handles CbxImportAddress.CheckedChanged
        If CbxImportAddress.Checked Then
            GbxAddress.Enabled = True
        Else
            GbxAddress.Enabled = False
        End If
        If Not CbxImportIdentity.Checked And Not CbxImportContact.Checked And Not CbxImportAddress.Checked Then
            BtnImport.Enabled = False
        Else
            BtnImport.Enabled = True
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If CbxImportIdentity.Checked Then
            If String.IsNullOrWhiteSpace(TxtName.Text) Then
                EprValidation.SetError(LblName, "Campo obrigatório.")
                EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
                TxtName.Select()
                Return False
            ElseIf String.IsNullOrWhiteSpace(TxtShortName.Text) Then
                EprValidation.SetError(LblShortName, "Campo obrigatório.")
                EprValidation.SetIconAlignment(LblShortName, ErrorIconAlignment.MiddleRight)
                TxtShortName.Select()
                Return False
            End If
        End If
        If CbxImportContact.Checked Then
            If String.IsNullOrWhiteSpace(TxtContactName.Text) Then
                EprValidation.SetError(LblContactName, "Campo obrigatório.")
                EprValidation.SetIconAlignment(LblContactName, ErrorIconAlignment.MiddleRight)
                TxtContactName.Select()
                Return False
            ElseIf Not String.IsNullOrWhiteSpace(TxtPhone.Text) And BrazilianFormatHelper.GetWhichPhoneFormat(TxtPhone.Text) = PhoneFormat.InvalidPhone Then
                EprValidation.SetError(LblPhone, String.Format("Telefone inválido.{0}1) Verifique se o DDD foi informado;{0}2) Verifique se há algum caractere que não seja número, parentesis ou traço;{0}3)Verifique se o telefone tem entre 10 e 11 digitos.", vbNewLine))
                EprValidation.SetIconAlignment(LblPhone, ErrorIconAlignment.MiddleRight)
                TxtPhone.Select()
                Return False
            ElseIf Not String.IsNullOrWhiteSpace(TxtEmail.Text) And Not BrazilianFormatHelper.IsValidEmail(TxtEmail.Text) Then
                EprValidation.SetError(LblEmail, "E-Mail inválido.")
                EprValidation.SetIconAlignment(LblEmail, ErrorIconAlignment.MiddleRight)
                TxtEmail.Select()
                Return False
            End If
        End If
        If CbxImportAddress.Checked Then
            If String.IsNullOrWhiteSpace(TxtAddressName.Text) Then
                EprValidation.SetError(LblAddressName, "Campo obrigatório.")
                EprValidation.SetIconAlignment(LblAddressName, ErrorIconAlignment.MiddleRight)
                TxtAddressName.Select()
                Return False
            ElseIf String.IsNullOrWhiteSpace(TxtZipCode.Text) Then
                EprValidation.SetError(LblZipCode, "Campo obrigatório.")
                EprValidation.SetIconAlignment(LblZipCode, ErrorIconAlignment.MiddleRight)
                TxtZipCode.Select()
                Return False
            ElseIf Not BrazilianFormatHelper.IsValidZipCode(TxtZipCode.Text) Then
                EprValidation.SetError(LblZipCode, "CEP inválido.")
                EprValidation.SetIconAlignment(LblZipCode, ErrorIconAlignment.MiddleRight)
                TxtZipCode.Select()
                Return False
            ElseIf String.IsNullOrWhiteSpace(TxtStreet.Text) Then
                EprValidation.SetError(LblStreet, "Campo obrigatório.")
                EprValidation.SetIconAlignment(LblStreet, ErrorIconAlignment.MiddleRight)
                TxtStreet.Select()
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
            End If
        End If
        Return True
    End Function
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        TxtShortName.Text = TxtShortName.Text.Trim.ToUnaccented()
        TxtContactName.Text = TxtContactName.Text.Trim.ToUnaccented()
        TxtPhone.Text = TxtPhone.Text.Trim.ToUnaccented()
        TxtEmail.Text = TxtEmail.Text.Trim.ToUnaccented()
        TxtAddressName.Text = TxtAddressName.Text.Trim.ToUnaccented()
        TxtZipCode.Text = TxtZipCode.Text.Trim.ToUnaccented()
        TxtStreet.Text = TxtStreet.Text.Trim.ToUnaccented()
        TxtNumber.Text = TxtNumber.Text.Trim.ToUnaccented()
        TxtComplement.Text = TxtComplement.Text.Trim.ToUnaccented()
        TxtDistrict.Text = TxtDistrict.Text.Trim.ToUnaccented()
        If IsValidFields() Then
            _Person.Document = TxtDocument.Text
            _Person.Name = TxtName.Text
            _Person.ShortName = TxtShortName.Text
            _Person.Contacts(0).Name = TxtContactName.Text
            _Person.Contacts(0).Phone = TxtPhone.Text
            _Person.Contacts(0).Email = TxtEmail.Text
            _Person.Addresses(0).Name = TxtAddressName.Text
            _Person.Addresses(0).ZipCode = TxtZipCode.Text
            _Person.Addresses(0).Street = TxtStreet.Text
            _Person.Addresses(0).Number = TxtNumber.Text
            _Person.Addresses(0).Complement = TxtComplement.Text
            _Person.Addresses(0).District = TxtDistrict.Text
            _Person.Addresses(0).City = New City().Load(QbxCity.FreezedPrimaryKey, False)
            DialogResult = DialogResult.OK
        End If
    End Sub
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
        BtnViewCity.Visible = QbxCity.IsFreezed And _User.CanWrite(Routine.City)
    End Sub
    Private Sub BtnNewCity_Click(sender As Object, e As EventArgs) Handles BtnNewCity.Click
        Dim City As City
        City = New City
        Using Form As New FrmCity(City)
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If City.ID > 0 Then
            QbxCity.Freeze(City.ID)
        End If
        QbxCity.Select()
    End Sub
    Private Sub BtnViewCity_Click(sender As Object, e As EventArgs) Handles BtnViewCity.Click
        Using Form As New FrmCity(New City().Load(QbxCity.FreezedPrimaryKey, False))
            Form.ShowDialog()
        End Using
        QbxCity.Freeze(QbxCity.FreezedPrimaryKey)
        QbxCity.Select()
    End Sub
    Private Sub BtnFilterCity_Click(sender As Object, e As EventArgs) Handles BtnFilterCity.Click
        Using Form As New FrmFilter(New CityQueriedBoxFilter(), QbxCity) With {.Text = "Filtro de Cidades"}
            Form.ShowDialog()
        End Using
        QbxCity.Select()
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtZipCode.TextChanged,
                                                                              TxtStreet.TextChanged,
                                                                              TxtShortName.TextChanged,
                                                                              TxtPhone.TextChanged,
                                                                              TxtNumber.TextChanged,
                                                                              TxtName.TextChanged,
                                                                              TxtEmail.TextChanged,
                                                                              TxtDistrict.TextChanged,
                                                                              TxtContactName.TextChanged,
                                                                              TxtComplement.TextChanged,
                                                                              TxtAddressName.TextChanged,
                                                                              QbxCity.TextChanged
        EprValidation.Clear()
    End Sub
    Private Sub TxtPhone_Leave(sender As Object, e As EventArgs) Handles TxtPhone.Leave
        TxtPhone.Text = BrazilianFormatHelper.GetFormatedPhoneNumber(TxtPhone.Text)
    End Sub
End Class