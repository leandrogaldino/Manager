Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Imports System.IO
Imports ManagerCore

Public Class FrmCash
    Private _Cash As Cash
    Private _CashesForm As FrmCashes
    Private _CashesGrid As DataGridView
    Private _Filter As CashFilter
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
    Public Sub New(Cash As Cash, CashesForm As FrmCashes)
        InitializeComponent()
        _Cash = Cash
        _CashesForm = CashesForm
        _CashesGrid = _CashesForm.DgvData
        _Filter = CType(_CashesForm.PgFilter.SelectedObject, CashFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
    End Sub
    Private Sub FrmCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadForm()
    End Sub
    Private Sub LoadForm()
        Utility.EnableControlDoubleBuffer(DgvCashItem, True)
        DgvNavigator.DataGridView = _CashesGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        DgvCashItemsLayout.Load()
        BtnLog.Visible = _User.CanAccess(Routine.Log)
        LblDocumentPage.Text = Nothing
    End Sub
    Private Sub LoadData()
        _Loading = True
        If _Cash.ID > 0 Then
            If _Cash.Status = CashStatus.Closed Then
                If _User.CanAccess(Routine.CashReopen) Then
                    BtnStatusValue.Visible = True
                    LblStatusValue.Visible = False
                Else
                    BtnStatusValue.Visible = False
                    LblStatusValue.Visible = True
                End If
            Else
                BtnStatusValue.Visible = True
                LblStatusValue.Visible = False
            End If
        Else
            BtnStatusValue.Visible = True
            LblStatusValue.Visible = False
        End If
        If Not String.IsNullOrEmpty(_Cash.Document.CurrentFile) AndAlso File.Exists(_Cash.Document.CurrentFile) Then
            PdfDocumentViewer.Load(New MemoryStream(File.ReadAllBytes(_Cash.Document.CurrentFile)))
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
        TcCash.SelectedTab = TabMain
        LblIDValue.Text = _Cash.ID
        BtnStatusValue.Text = GetEnumDescription(_Cash.Status)
        LblStatusValue.Text = GetEnumDescription(_Cash.Status)
        BtnOpenCash.Visible = _Cash.Status <> CashStatus.Opened And _User.CanAccess(Routine.CashReopen)
        BtnCloseCash.Visible = _Cash.Status <> CashStatus.Closed
        LblCreationDateValue.Text = _Cash.Creation.ToString("dd/MM/yyyy")
        TxtNote.Text = _Cash.Note
        _Cash.CashItems.FillDataGridView(DgvCashItem)
        CalculateValues()
        BtnDelete.Enabled = _Cash.ID > 0 And _User.CanDelete(Routine.Cash)
        Text = "Caixa"
        If _Cash.LockInfo.IsLocked And Not _Cash.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Cash.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(_Cash.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then DgvNavigator.CancelNextMove = True
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            _Cash.Load(_CashesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO CS001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
            If _CashesForm IsNot Nothing Then
                _Cash.CashItems.FillDataGridView(DgvCashItem)
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
        _Cash = New Cash With {.CashFlow = _Cash.CashFlow}
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Cash.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Cash.LockInfo.IsLocked Or (_Cash.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Cash.LockInfo.SessionToken) Then
                        _Cash.Delete()
                        If _CashesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _CashesForm.DgvCashesLayout.Load()
                            _CashesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_Cash.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                CMessageBox.Show("ERRO CS002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.Cash, _Cash.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        If BtnStatusValue.Text = GetEnumDescription(CashStatus.Opened) Then
            BtnStatusValue.ForeColor = Color.DarkBlue
            LblStatusValue.ForeColor = Color.DarkBlue
        ElseIf BtnStatusValue.Text = GetEnumDescription(CashStatus.Closed) Then
            BtnStatusValue.ForeColor = Color.DarkGreen
            LblStatusValue.ForeColor = Color.DarkGreen
        End If
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
    Private Sub BtnIncludeCashItem_Click(sender As Object, e As EventArgs) Handles BtnIncludeCashItem.Click
        Dim Form As New FrmCashItem(_Cash, New CashItem(), Me)
        Form.ShowDialog()
        CalculateValues()
    End Sub
    Private Sub BtnEditCashItem_Click(sender As Object, e As EventArgs) Handles BtnEditCashItem.Click
        Dim Form As FrmCashItem
        Dim CashItem As CashItem
        If DgvCashItem.SelectedRows.Count = 1 Then
            CashItem = _Cash.CashItems.Single(Function(x) x.Order = DgvCashItem.SelectedRows(0).Cells("Order").Value)
            Form = New FrmCashItem(_Cash, CashItem, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteCashItem_Click(sender As Object, e As EventArgs) Handles BtnDeleteCashItem.Click
        Dim CashItem As CashItem
        If DgvCashItem.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                CashItem = _Cash.CashItems.Single(Function(x) x.Order = DgvCashItem.SelectedRows(0).Cells("Order").Value)
                _Cash.CashItems.Remove(CashItem)
                _Cash.CashItems.FillDataGridView(DgvCashItem)
                BtnSave.Enabled = True
            End If
        End If
        CalculateValues()
    End Sub

    <DebuggerStepThrough>
    Private Sub DgvCashItems_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvCashItem.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("ItemType").Index Then
            Select Case e.Value
                Case Is = CashItemType.Expense
                    e.Value = GetEnumDescription(CashItemType.Expense)
                    e.CellStyle.ForeColor = Color.DarkRed
                Case Is = CashItemType.Income
                    e.Value = GetEnumDescription(CashItemType.Income)
                    e.CellStyle.ForeColor = Color.DarkGreen
            End Select
        ElseIf e.ColumnIndex = Dgv.Columns("ItemCategory").Index Then
            Select Case e.Value
                Case Is = CashItemCategory.Supermarket
                    e.Value = GetEnumDescription(CashItemCategory.Supermarket)
                Case Is = CashItemCategory.Food
                    e.Value = GetEnumDescription(CashItemCategory.Food)
                Case Is = CashItemCategory.Fuel
                    e.Value = GetEnumDescription(CashItemCategory.Fuel)
                Case Is = CashItemCategory.Accommodation
                    e.Value = GetEnumDescription(CashItemCategory.Accommodation)
                Case Is = CashItemCategory.AdministrativeExpense
                    e.Value = GetEnumDescription(CashItemCategory.AdministrativeExpense)
                Case Is = CashItemCategory.OperationalExpense
                    e.Value = GetEnumDescription(CashItemCategory.OperationalExpense)
                Case Is = CashItemCategory.Refund
                    e.Value = GetEnumDescription(CashItemCategory.Refund)
            End Select
        ElseIf e.ColumnIndex = Dgv.Columns("Value").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.Value = FormatNumber(e.Value, 2)
        End If
    End Sub
    Private Sub DgvCashItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCashItem.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCashItem.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditCashItem.PerformClick()
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If DgvCashItem.Rows.Count < 1 Then
            EprValidation.SetError(TsCashItem, "O caixa deve ter pelo menos um lançamento.")
            EprValidation.SetIconAlignment(TsCashItem, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsCashItem, -90)
            TcCash.SelectedTab = TabMain
            DgvCashItem.Select()
            Return False
        ElseIf Cash.CountCash({CashStatus.Opened}.ToList, _Cash.CashFlow.ID, _Cash.ID) > 0 Then
            EprValidation.SetError(BtnSave, "Não foi possível salvar pois existe pelo menos um caixa aberto.")
            EprValidation.SetIconAlignment(BtnSave, ErrorIconAlignment.MiddleRight)
            EprValidation.SetIconPadding(BtnSave, -115)
            TcCash.SelectedTab = TabMain
            BtnSave.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        Dim Success As Boolean
        Dim CurrentFile As String = _Cash.Document.CurrentFile
        Dim OriginalFile As String = _Cash.Document.OriginalFile
        TxtNote.Text = RemoveAccents(TxtNote.Text.ToUpper)
        If _Cash.LockInfo.IsLocked And _Cash.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(_Cash.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Success = False
        ElseIf _Cash.Status = CashStatus.Closed Then
            CMessageBox.Show("Esse caixa não pode ser alterado pois já está fechado.", CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFields() Then
                _Cash.Note = TxtNote.Text
                Try
                    Cursor = Cursors.WaitCursor
                    _Cash.SaveChanges()
                    _Cash.Lock()
                    LblIDValue.Text = _Cash.ID
                    LblCreationDateValue.Text = _Cash.Creation.ToString("dd/MM/yyyy")
                    _Cash.CashItems.FillDataGridView(DgvCashItem)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.Cash)
                    If _CashesForm IsNot Nothing Then
                        _Filter.Filter()
                        _CashesForm.DgvCashesLayout.Load()
                        Row = _CashesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Success = True
                Catch ex As Exception
                    CMessageBox.Show("ERRO CS003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Success = False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Success = False
            End If
        End If
        If Not Success Then
            If Not File.Exists(_Cash.Document.OriginalFile) Then
                _Cash.Document.SetCurrentFile(OriginalFile, True)
                _Cash.Document.SetCurrentFile(CurrentFile)
            End If
        End If
        Return Success
    End Function
    Private Sub TxtFilter_TextChanged(sender As Object, e As EventArgs) Handles TxtFilter.TextChanged
        Filter()
    End Sub
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
            Filename = Util.GetFilename(Path.GetExtension(OfdDocument.FileName))
            File.Copy(OfdDocument.FileName, Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            _Cash.Document.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            If Not String.IsNullOrEmpty(_Cash.Document.CurrentFile) AndAlso File.Exists(_Cash.Document.CurrentFile) Then
                Try
                    PdfDocumentViewer.Load(_Cash.Document.CurrentFile)
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
            _Cash.Document.SetCurrentFile(Nothing)
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
        SfdDocument.FileName = Path.GetFileName(String.Format("Documentos do Caixa {0} de {1}", _Cash.ID, _Cash.Creation.ToString("dd.MM.yyyy")))
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
    Private Sub Filter()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2} OR {3}",
                                                 "[Description] LIKE '%@VALUE%'",
                                                 "[DocumentNumber] LIKE '%@VALUE%'",
                                                 "Convert([DocumentDate], 'System.String') LIKE '%@VALUE%'",
                                                 "Convert([Value], 'System.String') LIKE '%@VALUE%'"
                                            )
        If DgvCashItem.DataSource IsNot Nothing Then
            Table = DgvCashItem.DataSource
            View = Table.DefaultView
            If TxtFilter.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilter.Text.Replace("%", Nothing).Replace("*", Nothing))
                Try
                    View.RowFilter = Filter
                Catch ex As Exception

                End Try

            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilter.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Public Sub CalculateValues()
        Dim Expense As Decimal = 0
        Dim Refund As Decimal = 0
        Try
            Expense = _Cash.CashItems.Where(Function(x) x.ItemType = CashItemType.Expense).Sum(Function(y) y.Value)
            Refund = _Cash.CashItems.Where(Function(x) x.ItemType = CashItemType.Income).Sum(Function(y) y.Value)
            LblRefund.Text = FormatNumber(Refund, 2)
            LblExpense.Text = FormatNumber(Expense, 2)
            If _Cash.ID = 0 Then
                LblPrevious.Text = FormatNumber(_Cash.GetLastBalance(), 2, TriState.True)
            Else
                LblPrevious.Text = FormatNumber(_Cash.GetPreviousBalance(), 2, TriState.True)
            End If
            LblCurrent.Text = FormatNumber(CDec(LblPrevious.Text) + CDec(LblRefund.Text) - CDec(LblExpense.Text), 2)
        Catch ex As Exception
            CMessageBox.Show("ERRO CS004", "Ocorreu ao atualizar os valores do caixa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
    End Sub
    Private Sub LblCurrent_TextChanged(sender As Object, e As EventArgs) Handles LblCurrent.TextChanged
        If LblCurrent.Text = 0 Then
            LblCurrent.ForeColor = Color.Black
        ElseIf LblCurrent.Text < 0 Then
            LblCurrent.ForeColor = Color.DarkRed
        Else
            LblCurrent.ForeColor = Color.DarkGreen
        End If
    End Sub
    Private Sub DgvCashItems_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCashItem.SelectionChanged
        If DgvCashItem.SelectedRows.Count = 0 Then
            BtnEditCashItem.Enabled = False
            BtnDeleteCashItem.Enabled = False
        Else
            BtnEditCashItem.Enabled = True
            BtnDeleteCashItem.Enabled = True
        End If
    End Sub
    Private Sub TxtNote_TextChanged(sender As Object, e As EventArgs) Handles TxtNote.TextChanged
        EprValidation.Clear()
        If Not _Loading Then
            BtnSave.Enabled = True
        End If
    End Sub

    Private Sub TxtFilter_Enter(sender As Object, e As EventArgs) Handles TxtFilter.Enter
        EprInformation.SetError(TsCashItem, "Filtrando os campos: Descrição, Nº Documento, Data Documento e Valor.")
        EprInformation.SetIconAlignment(TsCashItem, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsCashItem, -365)
    End Sub
    Private Sub TxtFilter_Leave(sender As Object, e As EventArgs) Handles TxtFilter.Leave
        EprInformation.Clear()
    End Sub
    Private Sub FrmCash_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Cash.Unlock()
    End Sub
    Private Sub DgvCashItem_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvCashItem.DataSourceChanged
        Filter()
    End Sub
    Private Sub BtnCashOne_Click(sender As Object, e As EventArgs) Handles BtnCashSheet.Click
        Dim Result As ReportResult
        If BtnSave.Enabled Then CMessageBox.Show("O caixa foi modificado sem ser salvo. O relatório será gerado com base nos dados previamente salvos.", CMessageBoxType.Information)
        Try
            Cursor = Cursors.WaitCursor
            Result = CashReport.ProcessCashSheet({_Cash}.ToList)
            FrmMain.OpenTab(New FrmReport(Result), GetEnumDescription(Routine.CashSheetReport))
            CMessageBox.Show("O Relátório foi gerado na tela inicial.", CMessageBoxType.Information)
        Catch ex As Exception
            CMessageBox.Show("ERRO CS010", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnCloseCash_Click(sender As Object, e As EventArgs) Handles BtnCloseCash.Click
        Dim Row As DataGridViewRow
        If _Cash.ID > 0 Then
            If Not BtnSave.Enabled Then
                If Not String.IsNullOrEmpty(_Cash.Document.CurrentFile) AndAlso _Cash.Document.CurrentFile.StartsWith(ApplicationPaths.CashDocumentDirectory) Then
                    Try
                        Cursor = Cursors.WaitCursor
                        _Cash.SetStatus(CashStatus.Closed)
                        BtnStatusValue.Text = GetEnumDescription(_Cash.Status)
                        LblStatusValue.Text = GetEnumDescription(_Cash.Status)
                        BtnCloseCash.Visible = _Cash.Status <> CashStatus.Closed
                        BtnOpenCash.Visible = _Cash.Status <> CashStatus.Opened And _User.CanAccess(Routine.CashReopen)
                        If _Cash.Status = CashStatus.Closed Then
                            If _User.CanAccess(Routine.CashReopen) Then
                                BtnStatusValue.Visible = True
                                LblStatusValue.Visible = False
                            Else
                                BtnStatusValue.Visible = False
                                LblStatusValue.Visible = True
                            End If
                        Else
                            BtnStatusValue.Visible = True
                            LblStatusValue.Visible = False
                        End If
                        If _CashesForm IsNot Nothing Then
                            _Filter.Filter()
                            _CashesForm.DgvCashesLayout.Load()
                            Row = _CashesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                            DgvNavigator.RefreshButtons()
                        End If
                    Catch ex As Exception
                        CMessageBox.Show("ERRO CS013", "Ocorreu um erro ao fechar o caixa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Finally
                        Cursor = Cursors.Default
                    End Try
                Else
                    CMessageBox.Show("Esse caixa não pode ser fechado, pois o documento não foi anexado.", CMessageBoxType.Warning)
                End If
            Else
                CMessageBox.Show("Esse caixa não pode ser fechado, pois há alterações que ainda não foram salvas, salve o caixa e tente novamente.", CMessageBoxType.Warning)
            End If
        Else
            CMessageBox.Show("Esse caixa não pode ser fechado, pois ainda não foi salvo.", CMessageBoxType.Warning)
        End If
    End Sub
    Private Sub BtnOpenCash_Click(sender As Object, e As EventArgs) Handles BtnOpenCash.Click
        Dim Row As DataGridViewRow
        Try
            Cursor = Cursors.WaitCursor
            _Cash.SetStatus(CashStatus.Opened)
            BtnStatusValue.Text = GetEnumDescription(_Cash.Status)
            LblStatusValue.Text = GetEnumDescription(_Cash.Status)
            BtnCloseCash.Visible = _Cash.Status <> CashStatus.Closed
            BtnOpenCash.Visible = _Cash.Status <> CashStatus.Opened And _User.CanAccess(Routine.CashReopen)
            If _CashesForm IsNot Nothing Then
                _Filter.Filter()
                _CashesForm.DgvCashesLayout.Load()
                Row = _CashesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                DgvNavigator.RefreshButtons()
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO CS014", "Ocorreu um erro ao abrir o caixa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

End Class