Imports ControlLibrary
Imports ControlLibrary.Utility

Public Class FrmPersonAddressGetZipCode
    Private _PersonAddress As PersonAddress

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
    Public Sub New(PersonAddress As PersonAddress, AddressFinder As ViaCep.ViaCepResult)
        InitializeComponent()
        _PersonAddress = PersonAddress
        TxtAddressName.Text = _PersonAddress.Name
        TxtZipCode.Text = GetFormatedZipCode(_PersonAddress.ZipCode)
        TxtStreet.Text = _PersonAddress.Street
        TxtDistrict.Text = _PersonAddress.District
        If _PersonAddress.City.ID = 0 Or (_PersonAddress.City.ID > 0 And _PersonAddress.City.Status = SimpleStatus.Inactive) Then
            QbxCity.Text = RemoveAccents(AddressFinder.City.ToUpper.Trim)
        Else
            QbxCity.Unfreeze()
            QbxCity.Freeze(_PersonAddress.City.ID)
        End If
        TxtAddressName.Select()
    End Sub
    Private Function IsValidFields() As Boolean
        If Not String.IsNullOrWhiteSpace(QbxCity.Text) And Not QbxCity.IsFreezed Then
            EprValidation.SetError(LblCity, "Cidade não encontrada.")
            EprValidation.SetIconAlignment(LblCity, ErrorIconAlignment.MiddleRight)
            QbxCity.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        TxtAddressName.Text = RemoveAccents(TxtAddressName.Text.Trim)
        TxtZipCode.Text = RemoveAccents(TxtZipCode.Text.Trim)
        TxtStreet.Text = RemoveAccents(TxtStreet.Text.Trim)
        TxtDistrict.Text = RemoveAccents(TxtDistrict.Text.Trim)
        If IsValidFields() Then
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
        BtnViewCity.Visible = QbxCity.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.CityWrite
        BtnNewCity.Visible = Locator.GetInstance(Of Session).User.Privilege.CityWrite
        BtnFilterCity.Visible = Locator.GetInstance(Of Session).User.Privilege.CityAccess
    End Sub
    Private Sub QbxCity_Leave(sender As Object, e As EventArgs) Handles QbxCity.Leave
        TmrQueriedBoxCity.Stop()
        TmrQueriedBoxCity.Start()
    End Sub
    Private Sub QbxCity_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCity.FreezedPrimaryKeyChanged
        BtnViewCity.Visible = QbxCity.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.CityWrite
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
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtStreet.TextChanged,
                                                                         TxtDistrict.TextChanged,
                                                                         TxtAddressName.TextChanged,
                                                                         QbxCity.TextChanged
        EprValidation.Clear()
    End Sub
End Class