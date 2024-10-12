Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.Utility
Imports ManagerCore

Public Class FrmProductPicture
    Private _ProductForm As FrmProduct
    Private _Product As Product
    Private _ProductPicture As ProductPicture
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
    Public Sub New(Product As Product, ProductPicture As ProductPicture, ProductForm As FrmProduct)
        InitializeComponent()
        _Product = Product
        _ProductPicture = ProductPicture
        _ProductForm = ProductForm
        LoadForm()
        DgvNavigator.DataGridView = _ProductForm.DgvPicture
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralLogAccess
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
        If _ProductForm.DgvPicture.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ProductPicture = _Product.Pictures.Single(Function(x) x.Order = _ProductForm.DgvPicture.SelectedRows(0).Cells("Order").Value)
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
        _ProductPicture = New ProductPicture()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ProductForm.DgvPicture.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ProductPicture = _Product.Pictures.Single(Function(x) x.Order = _ProductForm.DgvPicture.SelectedRows(0).Cells("Order").Value)
                _Product.Pictures.Remove(_ProductPicture)
                _Product.Pictures.FillDataGridView(_ProductForm.DgvPicture)
                _ProductForm.DgvPictureLayout.Load()
                _Deleting = True
                _ProductForm.BtnSave.Enabled = True
                Dispose()
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.ProductPicture, _ProductPicture.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtCaption_TextChanged(sender As Object, e As EventArgs) Handles TxtCaption.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _ProductPicture.Order
        LblCreationValue.Text = _ProductPicture.Creation
        If Not String.IsNullOrEmpty(_ProductPicture.Picture.CurrentFile) AndAlso File.Exists(_ProductPicture.Picture.CurrentFile) Then
            PbxPicture.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(_ProductPicture.Picture.CurrentFile)))
            BtnDeletePicture.Visible = True
            BtnSavePicture.Visible = True
        Else
            PbxPicture.Image = Nothing
            BtnDeletePicture.Visible = False
            BtnSavePicture.Visible = False
        End If
        _ProductPicture.Caption = If(_ProductPicture.IsSaved, _ProductPicture.Caption, "FOTO " & _Product.Pictures.Count + 1)
        TxtCaption.Text = _ProductPicture.Caption
        If _ProductPicture.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        TxtCaption.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If PbxPicture.Image Is Nothing Then
            EprValidation.SetError(LblPicture, "É necessário escolher uma imagem para o produto.")
            EprValidation.SetIconAlignment(LblPicture, ErrorIconAlignment.MiddleRight)
            PbxPicture.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtCaption.Text) Then
            EprValidation.SetError(LblCaption, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCaption, ErrorIconAlignment.MiddleRight)
            TxtCaption.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtCaption.Text = RemoveAccents(TxtCaption.Text.Trim)
        If IsValidFields() Then
            If _ProductPicture.IsSaved Then
                _Product.Pictures.Single(Function(x) x.Order = _ProductPicture.Order).Caption = TxtCaption.Text
            Else
                _ProductPicture.Caption = TxtCaption.Text
                _ProductPicture.IsSaved = True
                _Product.Pictures.Add(_ProductPicture)
            End If
            _Product.Pictures.FillDataGridView(_ProductForm.DgvPicture)
            LblOrderValue.Text = _ProductPicture.Order
            _ProductForm.DgvPictureLayout.Load()
            BtnSave.Enabled = False
            If _ProductPicture.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _ProductForm.DgvPicture.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _ProductPicture.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _ProductForm.EprValidation.Clear()
            _ProductForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub BtnIncludePicture_Click(sender As Object, e As EventArgs) Handles BtnIncludePicture.Click
        Dim Filename As String
        OfdPicture.FileName = Nothing
        OfdPicture.Filter = "Imagens (*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;"
        If OfdPicture.ShowDialog = DialogResult.OK Then
            Filename = Util.GetFilename(Path.GetExtension(OfdPicture.FileName))
            File.Copy(OfdPicture.FileName, Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            _ProductPicture.Picture.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            If Not String.IsNullOrEmpty(_ProductPicture.Picture.CurrentFile) AndAlso File.Exists(_ProductPicture.Picture.CurrentFile) Then
                Try
                    PbxPicture.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(_ProductPicture.Picture.CurrentFile)))
                    BtnDeletePicture.Visible = True
                    BtnSavePicture.Visible = True
                    BtnSave.Enabled = True
                    EprValidation.Clear()
                Catch ex As Exception
                    CMessageBox.Show("ERRO PD008", "Ocorreu um erro ao carregar a imagem.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            End If
        End If
    End Sub
    Private Sub BtnSavePicture_Click(sender As Object, e As EventArgs) Handles BtnSavePicture.Click
        Dim SignatureFormat As Imaging.ImageFormat
        Dim SignatureImage As Image
        SfdPicture.FileName = "Imagem da Assinatura"
        SfdPicture.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp"
        If SfdPicture.ShowDialog() = DialogResult.OK Then
            If SfdPicture.FilterIndex = 0 Then
                SignatureFormat = Imaging.ImageFormat.Png
            ElseIf SfdPicture.FilterIndex = 1 Then
                SignatureFormat = Imaging.ImageFormat.Jpeg
            Else SfdPicture.FilterIndex = 2
                SignatureFormat = Imaging.ImageFormat.Bmp
            End If
            SignatureImage = Image.FromStream(New MemoryStream(File.ReadAllBytes(_ProductPicture.Picture.CurrentFile)))
            SignatureImage.Save(SfdPicture.FileName, SignatureFormat)
        End If
    End Sub
    Private Sub BtnDeletePicture_Click(sender As Object, e As EventArgs) Handles BtnDeletePicture.Click
        If CMessageBox.Show("A imagem será excluída permanentemente quando esse modelo for salvo. Confirma a exclusão?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            _ProductPicture.Picture.SetCurrentFile(Nothing)
            PbxPicture.Image = Nothing
            BtnDeletePicture.Visible = False
            BtnSavePicture.Visible = False
            BtnSave.Enabled = True
            EprValidation.Clear()
        End If
    End Sub
End Class