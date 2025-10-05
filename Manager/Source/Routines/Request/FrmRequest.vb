Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Imports System.IO
Imports ManagerCore
Public Class FrmRequest
    Private _Request As Request
    Private _RequestsForm As FrmRequests
    Private _RequestsGrid As DataGridView
    Private _Filter As RequestFilter
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(Request As Request, RequestsForm As FrmRequests)
        InitializeComponent()
        _Request = Request
        _RequestsForm = RequestsForm
        _RequestsGrid = _RequestsForm.DgvData
        _Filter = CType(_RequestsForm.PgFilter.SelectedObject, RequestFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(Request As Request)
        InitializeComponent()
        _Request = Request
        _User = Locator.GetInstance(Of Session).User
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        LblStatusValue.Enabled = False
        TcRequest.Height -= TsNavigation.Height
        MinimumSize = Nothing
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvItemLayout.Load()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(DgvItem, True)
        DgvNavigator.DataGridView = _RequestsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
        LblDocumentPage.Text = Nothing
    End Sub
    Private Sub LoadData()
        _Loading = True
        TcRequest.SelectedTab = TabMain
        LblIDValue.Text = _Request.ID
        LblStatusValue.Text = EnumHelper.GetEnumDescription(_Request.Status)
        LblCreationValue.Text = _Request.Creation.ToString("dd/MM/yyyy")
        TxtDestination.Text = _Request.Destination
        TxtResponsible.Text = _Request.Responsible
        TxtNote.Text = _Request.Note
        If Not String.IsNullOrEmpty(_Request.Document.CurrentFile) AndAlso File.Exists(_Request.Document.CurrentFile) Then
            PdfDocumentViewer.Load(New MemoryStream(File.ReadAllBytes(_Request.Document.CurrentFile)))
            LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
            BtnDeletePDF.Enabled = True
            BtnSavePDF.Enabled = True
            BtnPrintPDF.Enabled = True
            BtnZoomIn.Enabled = True
            BtnZoomOut.Enabled = True
        Else
            PdfDocumentViewer.Unload()
            LblDocumentPage.Text = Nothing
            BtnDeletePDF.Enabled = False
            BtnSavePDF.Enabled = False
            BtnPrintPDF.Enabled = False
            BtnZoomIn.Enabled = False
            BtnZoomOut.Enabled = False
        End If
        TxtFilterItem.Clear()
        If _Request.Items IsNot Nothing Then DgvItem.Fill(_Request.Items)
        BtnDelete.Enabled = _Request.ID > 0 And _User.CanDelete(Routine.Request)
        Text = "Requisição"
        If _Request.LockInfo.IsLocked And Not _Request.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Request.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _Request.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtDestination.Select()
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
            _Request.Load(_RequestsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO RQ001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
            If _RequestsForm IsNot Nothing Then
                DgvItem.Fill(_Request.Items)
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
        _Request = New Request
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Request.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Request.LockInfo.IsLocked Or (_Request.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Request.LockInfo.SessionToken) Then
                        _Request.Delete()
                        If _RequestsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _RequestsForm.DgvRequestLayout.Load()
                            _RequestsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Request.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                CMessageBox.Show("ERRO RQ002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.Request, _Request.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtDestination.TextChanged,
                                                                          TxtResponsible.TextChanged,
                                                                          TxtNote.TextChanged
        EprValidation.Clear()
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
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Sub BtnIncludeItem_Click(sender As Object, e As EventArgs) Handles BtnIncludeItem.Click
        Using Form As New FrmRequestItem(_Request, New RequestItem(), Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEditItem_Click(sender As Object, e As EventArgs) Handles BtnEditItem.Click
        Dim Item As RequestItem
        If DgvItem.SelectedRows.Count = 1 Then
            Item = _Request.Items.Single(Function(x) x.Guid = DgvItem.SelectedRows(0).Cells("Guid").Value)
            Using Form As New FrmRequestItem(_Request, Item, Me)
                Form.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnDeleteItem_Click(sender As Object, e As EventArgs) Handles BtnDeleteItem.Click
        Dim Item As RequestItem
        If DgvItem.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Item = _Request.Items.Single(Function(x) x.Guid = DgvItem.SelectedRows(0).Cells("Guid").Value)
                _Request.Items.Remove(Item)
                DgvItem.Fill(_Request.Items)
                DgvItemLayout.Load()
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub TcRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcRequest.SelectedIndexChanged
        If TcRequest.SelectedTab Is TabMain Then
            Size = New Size(560, 248)
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
    Private Sub DgvItem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvItem.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Status").Index Then
            Select Case e.Value
                Case Is = RequestStatus.Pending
                    e.Value = EnumHelper.GetEnumDescription(RequestStatus.Pending)
                    e.CellStyle.ForeColor = Color.DarkRed
                Case Is = RequestStatus.Partial
                    e.Value = EnumHelper.GetEnumDescription(RequestStatus.Partial)
                    e.CellStyle.ForeColor = Color.Chocolate
                Case Is = RequestStatus.Concluded
                    e.Value = EnumHelper.GetEnumDescription(RequestStatus.Concluded)
                    e.CellStyle.ForeColor = Color.DarkGreen
            End Select
        ElseIf e.ColumnIndex = Dgv.Columns("Taked").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N2"
        ElseIf e.ColumnIndex = Dgv.Columns("Returned").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N2"
        ElseIf e.ColumnIndex = Dgv.Columns("Applied").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N2"
        ElseIf e.ColumnIndex = Dgv.Columns("Lossed").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N2"
        End If
    End Sub
    Private Sub DgvItem_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvItem.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvItem.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditItem.PerformClick()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtDestination.Text) Then
            TcRequest.SelectedTab = TabMain
            EprValidation.SetError(LblDestination, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblDestination, ErrorIconAlignment.MiddleRight)
            TcRequest.SelectedTab = TabMain
            TxtDestination.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtResponsible.Text) Then
            TcRequest.SelectedTab = TabMain
            EprValidation.SetError(LblResponsible, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblResponsible, ErrorIconAlignment.MiddleRight)
            TcRequest.SelectedTab = TabMain
            TxtResponsible.Select()
            Return False
        ElseIf _Request.Items.Count = 0 Then
            TcRequest.SelectedTab = TabItems
            EprValidation.SetError(TsItem, "Não é possível salvar uma requisição sem itens.")
            EprValidation.SetIconAlignment(TsItem, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsItem, -365)
            BtnIncludeItem.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        Dim Success As Boolean
        Dim CurrentFile As String = _Request.Document.CurrentFile
        Dim OriginalFile As String = _Request.Document.OriginalFile
        TxtDestination.Text = TxtDestination.Text.Trim.ToUnaccented()
        TxtResponsible.Text = TxtResponsible.Text.Trim.ToUnaccented()
        TxtNote.Text = TxtNote.Text.ToUpper.ToUnaccented()
        If _Request.LockInfo.IsLocked And _Request.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Request.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFields() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Request.Status = EnumHelper.GetEnumValue(Of RequestStatus)(LblStatusValue.Text)
                    _Request.Destination = TxtDestination.Text
                    _Request.Responsible = TxtResponsible.Text
                    _Request.Note = TxtNote.Text
                    _Request.SaveChanges()
                    _Request.Lock()
                    LblIDValue.Text = _Request.ID
                    DgvItem.Fill(_Request.Items)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.Request)
                    If _RequestsForm IsNot Nothing Then
                        _Filter.Filter()
                        _RequestsForm.DgvRequestLayout.Load()
                        Row = _RequestsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Success = True
                Catch ex As MySqlException
                    CMessageBox.Show("ERRO RQ003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Catch ex As Exception
                    CMessageBox.Show("ERRO RQ011", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Finally
                    Cursor = Cursors.Default
                End Try
            End If
        End If
        If Not Success Then
            If Not File.Exists(_Request.Document.OriginalFile) Then
                _Request.Document.SetCurrentFile(OriginalFile, True)
                _Request.Document.SetCurrentFile(CurrentFile)
            End If
        End If
        Return Success
    End Function
    Private Sub BtnZoomOut_Click(sender As Object, e As EventArgs) Handles BtnZoomOut.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage - 10)
    End Sub
    Private Sub BtnZoomIn_Click(sender As Object, e As EventArgs) Handles BtnZoomIn.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage + 10)
    End Sub
    Private Sub BtnAttachPDF_Click(sender As Object, e As EventArgs) Handles BtnAttachPDF.Click
        Dim Filename As String
        OfdDocument.FileName = Nothing
        If OfdDocument.ShowDialog = DialogResult.OK Then
            Filename = TextHelper.GetRandomFileName(Path.GetExtension(OfdDocument.FileName))
            File.Copy(OfdDocument.FileName, Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            _Request.Document.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            If Not String.IsNullOrEmpty(_Request.Document.CurrentFile) AndAlso File.Exists(_Request.Document.CurrentFile) Then
                Try
                    PdfDocumentViewer.Load(_Request.Document.CurrentFile)
                    LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
                    BtnDeletePDF.Enabled = True
                    BtnSavePDF.Enabled = True
                    BtnPrintPDF.Enabled = True
                    BtnZoomIn.Enabled = True
                    BtnZoomOut.Enabled = True
                    EprValidation.Clear()
                    BtnSave.Enabled = True
                Catch ex As Exception
                    CMessageBox.Show("ERRO RQ004", "Ocorreu um erro ao carregar o documento.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            End If
        End If
    End Sub
    Private Sub PdfDocumentViewer_CurrentPageChanged(sender As Object, args As EventArgs) Handles PdfDocumentViewer.CurrentPageChanged
        LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
    End Sub
    Private Sub BtnDeletePDF_Click(sender As Object, e As EventArgs) Handles BtnDeletePDF.Click
        If CMessageBox.Show("O documento será excluído permanentemente quando essa avaliação for salva. Confirma a exclusão?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            _Request.Document.SetCurrentFile(Nothing)
            PdfDocumentViewer.Unload()
            LblDocumentPage.Text = Nothing
            BtnDeletePDF.Enabled = False
            BtnSavePDF.Enabled = False
            BtnPrintPDF.Enabled = False
            BtnZoomIn.Enabled = False
            BtnZoomOut.Enabled = False
            EprValidation.Clear()
            BtnSave.Enabled = True
        End If
    End Sub
    Private Sub BtnSavePDF_Click(sender As Object, e As EventArgs) Handles BtnSavePDF.Click
        SfdDocument.FileName = Path.GetFileName(String.Format("Requisição {0} - {1} x {2}", _Request.ID, _Request.Responsible, _Request.Destination))
        SfdDocument.Filter = "Documento PDF|*.pdf"
        If SfdDocument.ShowDialog() = DialogResult.OK Then
            PdfDocumentViewer.LoadedDocument.Save(SfdDocument.FileName)
        End If
    End Sub
    Private Sub BtnPrintPDF_Click(sender As Object, e As EventArgs) Handles BtnPrintPDF.Click
        Using Dialog As New PrintDialog
            Dialog.Document = PdfDocumentViewer.PrintDocument
            If Dialog.ShowDialog() = DialogResult.OK Then
                Dialog.Document.Print()
            End If
        End Using
    End Sub
    Private Sub DgvItemLayout_Loaded(sender As Object, e As EventArgs) Handles DgvItemLayout.Loaded
        If _Request.Items.All(Function(x) x.Status = RequestStatus.Pending) Then
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Pending)
        ElseIf _Request.Items.All(Function(x) x.Status = RequestStatus.Concluded) Then
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Concluded)
        Else
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Partial)
        End If
    End Sub
    Private Sub LblStatusValue_TextChanged(sender As Object, e As EventArgs) Handles LblStatusValue.TextChanged
        If LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Pending) Then
            LblStatusValue.ForeColor = Color.DarkRed
        ElseIf LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Partial) Then
            LblStatusValue.ForeColor = Color.Chocolate
        Else
            LblStatusValue.ForeColor = Color.DarkGreen
        End If
    End Sub
    Private Sub BtnRequestSheet_Click(sender As Object, e As EventArgs) Handles BtnRequestSheet.Click
        Using Form As New FrmRequestSheet(_Request, BtnSave.Enabled)
            Form.ShowDialog()
        End Using
    End Sub


    Private Sub TxtKeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterItem.KeyPress
        Dim LstChar As New List(Of Char) From {"", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterItem_Enter(sender As Object, e As EventArgs) Handles TxtFilterItem.Enter
        EprInformation.SetError(TsItem, "Filtrando os campos: Código e Item.")
        EprInformation.SetIconAlignment(TsItem, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsItem, -365)
    End Sub
    Private Sub TxtFilterItem_Leave(sender As Object, e As EventArgs) Handles TxtFilterItem.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterItem_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterItem.TextChanged
        FilterRequestItem()
    End Sub
    Private Sub FilterRequestItem()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = "ItemNameOrProduct LIKE '%@value%' OR Code LIKE '%@value%'"
        If DgvItem.DataSource IsNot Nothing Then
            Table = DgvItem.DataSource
            View = Table.DefaultView
            If TxtFilterItem.Text <> Nothing Then
                Filter = Filter.Replace("@value", TxtFilterItem.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub DgvItem_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvItem.DataSourceChanged
        If _Request.Items.All(Function(x) x.Status = RequestStatus.Pending) Then
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Pending)
        ElseIf _Request.Items.All(Function(x) x.Status = RequestStatus.Concluded) Then
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Concluded)
        Else
            LblStatusValue.Text = EnumHelper.GetEnumDescription(RequestStatus.Partial)
        End If
        FilterRequestItem()
    End Sub
    Private Sub FrmRequest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Request.Unlock()
    End Sub
End Class