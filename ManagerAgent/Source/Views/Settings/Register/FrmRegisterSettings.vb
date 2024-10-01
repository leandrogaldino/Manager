Imports ControlLibrary
Imports ControlLibrary.Utility
Imports ManagerCore
Imports System.ComponentModel
Imports System.IO

Public Class FrmRegisterSettings
    Private _ViewModel As RegisterSettingsViewModel
    Private _TempLogoLocation As String
    Private _DeleteLogo As Boolean
    Public Sub New()
        InitializeComponent()
        _ViewModel = New RegisterSettingsViewModel()
        CbxState.SelectedIndex = 0
        InitializeBindings()
        AddHandler _ViewModel.PropertyChanged, AddressOf OnViewModelPropertychanged
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub BtnDeleteLogo_Click(sender As Object, e As EventArgs) Handles BtnDeleteLogo.Click
        _TempLogoLocation = Nothing
        _DeleteLogo = True
        PbxLogo.Image = Nothing
        BtnSave.Enabled = True
        EprValidation.Clear()
    End Sub
    Private Sub TxtDocument_Leave(sender As Object, e As EventArgs) Handles TxtDocument.Leave
        TxtDocument.Text = GetFormatedDocument(TxtDocument.Text)
    End Sub
    Private Sub TxtZipCode_Leave(sender As Object, e As EventArgs) Handles TxtZipCode.Leave
        TxtZipCode.Text = GetFormatedZipCode(TxtZipCode.Text)
    End Sub
    Private Sub TxtPhone_Leave(sender As Object, e As EventArgs) Handles TxtPhone1.Leave, TxtCellPhone.Leave, TxtPhone2.Leave
        Dim Txt As TextBox = CType(sender, TextBox)
        Txt.Text = GetFormatedPhoneNumber(Txt.Text)
    End Sub
    Private Sub BtnIncludeLogo_Click(sender As Object, e As EventArgs) Handles BtnIncludeLogo.Click
        Dim Filename As String
        If OfdLogo.ShowDialog = DialogResult.OK Then
            Filename = Now.ToString("ddMMyyyyHHmmss") & UCase(Path.GetRandomFileName().Replace(".", Nothing)) & New FileInfo(OfdLogo.FileName).Extension
            _TempLogoLocation = Path.Combine(ApplicationPaths.AgentTempDirectory(), Filename)
            File.Copy(OfdLogo.FileName, _TempLogoLocation)
            PbxLogo.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(_TempLogoLocation)))
            BtnSave.Enabled = True
            EprValidation.Clear()
        End If
    End Sub
    Private Sub OnViewModelPropertychanged(sender As Object, e As PropertyChangedEventArgs)
        EprValidation.Clear()
        BtnSave.Enabled = True
    End Sub
    Private Function IsValidFields() As Boolean
        Dim b As Boolean = IsValidLegalEntityDocument(TxtDocument.Text)
        If Not IsValidNaturalEntityDocument(TxtDocument.Text) And Not IsValidLegalEntityDocument(TxtDocument.Text) Then
            EprValidation.SetError(LblDocument, "Documento inválido.")
            EprValidation.SetIconAlignment(LblDocument, ErrorIconAlignment.MiddleRight)
            TxtDocument.Select()
            Return False
        ElseIf Not String.IsNullOrEmpty(TxtZipCode.Text) And Not IsValidZipCode(TxtZipCode.Text) Then
            EprValidation.SetError(LblZipCode, "CEP inválido.")
            EprValidation.SetIconAlignment(LblZipCode, ErrorIconAlignment.MiddleRight)
            TxtZipCode.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub InitializeBindings()
        Dim Binding As Binding
        Binding = New Binding("Image", _ViewModel, "LogoLocation", False, DataSourceUpdateMode.OnPropertyChanged)
        AddHandler Binding.Format, Sub(sender, e)
                                       If e.DesiredType Is GetType(Image) AndAlso TypeOf e.Value Is String Then
                                           Dim ImagePath As String = CType(e.Value, String)
                                           Try
                                               If Not String.IsNullOrEmpty(ImagePath) AndAlso IO.File.Exists(ImagePath) Then
                                                   e.Value = Image.FromStream(New MemoryStream(File.ReadAllBytes(ImagePath)))
                                                   CType(e.Value, Image).Tag = ImagePath
                                               Else
                                                   e.Value = New Bitmap(1, 1)
                                               End If
                                           Catch ex As Exception
                                               e.Value = New Bitmap(1, 1)
                                           End Try
                                       End If
                                   End Sub
        AddHandler Binding.Parse, Sub(sender, e)
                                      If e.DesiredType Is GetType(String) AndAlso TypeOf e.Value Is Image Then
                                          e.Value = CType(e.Value, Image).Tag
                                      End If
                                  End Sub
        PbxLogo.DataBindings.Add(Binding)
        TxtName.DataBindings.Add("Text", _ViewModel, "Name", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtShortName.DataBindings.Add("Text", _ViewModel, "ShortName", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtDocument.DataBindings.Add("Text", _ViewModel, "Document", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtStateDocument.DataBindings.Add("Text", _ViewModel, "StateDocument", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtCityDocument.DataBindings.Add("Text", _ViewModel, "CityDocument", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtZipCode.DataBindings.Add("Text", _ViewModel, "ZipCode", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtStreet.DataBindings.Add("Text", _ViewModel, "Street", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtNumber.DataBindings.Add("Text", _ViewModel, "Number", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtComplement.DataBindings.Add("Text", _ViewModel, "Complement", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtDistrict.DataBindings.Add("Text", _ViewModel, "District", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtCity.DataBindings.Add("Text", _ViewModel, "City", False, DataSourceUpdateMode.OnPropertyChanged)
        CbxState.DataBindings.Add("Text", _ViewModel, "State", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtPhone1.DataBindings.Add("Text", _ViewModel, "Phone1", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtPhone2.DataBindings.Add("Text", _ViewModel, "Phone2", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtCellPhone.DataBindings.Add("Text", _ViewModel, "CellPhone", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtEmail.DataBindings.Add("Text", _ViewModel, "Email", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtFacebook.DataBindings.Add("Text", _ViewModel, "Facebook", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtInstagram.DataBindings.Add("Text", _ViewModel, "Instagram", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtLinkedin.DataBindings.Add("Text", _ViewModel, "Linkedin", False, DataSourceUpdateMode.OnPropertyChanged)
        TxtSite.DataBindings.Add("Text", _ViewModel, "Site", False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Result As Boolean
        Cursor = Cursors.WaitCursor
        If IsValidFields() Then
            Result = _ViewModel.Save(_TempLogoLocation, _DeleteLogo)
            _DeleteLogo = False
        End If
        Cursor = Cursors.Default
        BtnSave.Enabled = Not Result
    End Sub

    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim IsValid As Boolean
        Dim Result As Boolean
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                IsValid = IsValidFields()
                If IsValid Then
                    Result = _ViewModel.Save(_TempLogoLocation, _DeleteLogo)
                End If

                If Not IsValid Or Not Result Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
End Class