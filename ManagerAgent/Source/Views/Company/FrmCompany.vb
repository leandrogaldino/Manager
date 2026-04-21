Imports System.IO
Imports CoreSuite.Controls
Imports CoreSuite.Helpers
Imports ManagerCore
Public Class FrmCompany
    Private _Service As CompanyService
    Private _Company As CompanyModel
    Public Sub New(Service As CompanyService, Company As CompanyModel)
        InitializeComponent()
        _Service = Service
        _Company = Company
        LoadData()
    End Sub

    Private Sub LoadData()
        If _Company.ID > 0 Then
            Text = $"{_Company.ShortName}"
        Else
            Text = "Nova Empresa"
        End If
        LblID.Text = _Company.ID
        PvLogo.AddPicture(_Company.Logo.CurrentFile)
        If PvLogo.Pictures.Count > 0 Then
            BtnDeleteLogo.Enabled = True
            BtnIncludeLogo.Enabled = False
        Else
            BtnDeleteLogo.Enabled = False
            BtnIncludeLogo.Enabled = True
        End If
        BtnStatusValue.Text = If(_Company.IsActive, "Ativo", "Inativo")
        TxtName.Text = _Company.Name
        TxtShortName.Text = _Company.ShortName
        TxtDocument.Text = _Company.Document
        TxtStateDocument.Text = _Company.StateDocument
        TxtCityDocument.Text = _Company.CityDocument
        TxtZipCode.Text = _Company.Address.ZipCode
        TxtStreet.Text = _Company.Address.Street
        TxtNumber.Text = _Company.Address.Number
        TxtDistrict.Text = _Company.Address.District
        TxtCity.Text = _Company.Address.City
        CbxState.SelectedItem = _Company.Address.State
        TxtComplement.Text = _Company.Address.Complement
        TxtPhone1.Text = _Company.Contact.Phone1
        TxtPhone2.Text = _Company.Contact.Phone2
        TxtCellPhone.Text = _Company.Contact.CellPhone
        TxtEmail.Text = _Company.Contact.Email
        TxtFacebook.Text = _Company.Contact.Facebook
        TxtInstagram.Text = _Company.Contact.Instagram
        TxtLinkedin.Text = _Company.Contact.Linkedin
        TxtSite.Text = _Company.Contact.Site
    End Sub

    Private Sub UpdateData()
        _Company.IsActive = BtnStatusValue.Text = "Ativo"
        _Company.Logo.SetCurrentFile(PvLogo.SelectedPicture)
        _Company.Name = TxtName.Text
        _Company.ShortName = TxtShortName.Text
        _Company.Document = TxtDocument.Text
        _Company.StateDocument = TxtStateDocument.Text
        _Company.CityDocument = TxtCityDocument.Text
        _Company.Address.ZipCode = TxtZipCode.Text
        _Company.Address.Street = TxtStreet.Text
        _Company.Address.Number = TxtNumber.Text
        _Company.Address.District = TxtDistrict.Text
        _Company.Address.City = TxtCity.Text
        _Company.Address.State = CbxState.SelectedItem?.ToString()
        _Company.Address.Complement = TxtComplement.Text
        _Company.Contact.Phone1 = TxtPhone1.Text
        _Company.Contact.Phone2 = TxtPhone2.Text
        _Company.Contact.CellPhone = TxtCellPhone.Text
        _Company.Contact.Email = TxtEmail.Text
        _Company.Contact.Facebook = TxtFacebook.Text
        _Company.Contact.Instagram = TxtInstagram.Text
        _Company.Contact.Linkedin = TxtLinkedin.Text
        _Company.Contact.Site = TxtSite.Text
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            Cursor = Cursors.WaitCursor
            UpdateData()
            _Company = ManagerCore.Util.AsyncLock(Function() _Service.SaveAsync(_Company))
            Text = $"{_Company.ShortName}"
            LblID.Text = _Company.ID
            DialogResult = DialogResult.OK
        Catch ex As Exception
            CMessageBox.Show("Erro ao salvar empresa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnDeleteLogo_Click(sender As Object, e As EventArgs) Handles BtnDeleteLogo.Click
        PvLogo.RemovePicture(PvLogo.SelectedPicture)
    End Sub

    Private Sub BtnIncludeLogo_Click(sender As Object, e As EventArgs) Handles BtnIncludeLogo.Click
        Dim Filename As String
        Dim FilePath As String
        If OfdLogo.ShowDialog() = DialogResult.OK Then
            Filename = TextHelper.GetRandomFileName(Path.GetExtension(OfdLogo.FileName))
            FilePath = Path.Combine(ApplicationPaths.AgentTempDirectory, Filename)
            File.Copy(OfdLogo.FileName, FilePath)
            '_Request.Document.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            PvLogo.AddPicture(FilePath)
        End If
    End Sub

    Private Sub PvLogo_PictureAdded(Path As String) Handles PvLogo.PictureAdded
        BtnDeleteLogo.Enabled = True
        BtnIncludeLogo.Enabled = False
    End Sub

    Private Sub PvLogo_PictureRemoved(Path As String) Handles PvLogo.PictureRemoved
        BtnDeleteLogo.Enabled = False
        BtnIncludeLogo.Enabled = True
    End Sub

    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = "Ativo" Then
            BtnStatusValue.Text = "Inativo"
        ElseIf BtnStatusValue.Text = "Inativo" Then
            BtnStatusValue.Text = "Ativo"
        End If
        BtnSave.Enabled = True
    End Sub

    Private Sub TxtName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtName.Validating
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EpValidator.SetError(LblName, "Campo obrigatório.")
            e.Cancel = True
        Else
            EpValidator.SetError(LblName, "")
        End If
    End Sub
    Private Sub TxtShortName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtShortName.Validating
        If String.IsNullOrWhiteSpace(TxtShortName.Text) Then
            EpValidator.SetError(LblShortName, "Campo obrigatório.")
            e.Cancel = True
        Else
            EpValidator.SetError(LblShortName, "")
        End If
    End Sub
    Private Sub TxtDocument_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDocument.Validating
        If String.IsNullOrWhiteSpace(TxtDocument.Text) Then
            EpValidator.SetError(LblDocument, "Campo obrigatório.")
            e.Cancel = True
        Else
            EpValidator.SetError(LblDocument, "")
        End If
    End Sub
End Class

