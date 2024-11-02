Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Public Class FrmCashes
    Private _Cash As New Cash
    Private _Filter As CashFilter
    Private _CmsPoint As Point
    Private _ShowApproval As Boolean
    Private _Flow As CashFlow
    Public Sub New(Flow As CashFlow)
        InitializeComponent()
        EnableControlDoubleBuffer(DgvData, True)
        EnableControlDoubleBuffer(DgvCashItem, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer2.Panel1Collapsed = True
        _Flow = Flow
        _Filter = New CashFilter(DgvData, PgFilter, Flow)
        _Filter.Filter()
        PgFilter.SelectedObject = _Filter
        LoadDetails()
        BtnInclude.Visible = Locator.GetInstance(Of Session).User.Privilege.CashWrite
        BtnEdit.Visible = Locator.GetInstance(Of Session).User.Privilege.CashWrite
        BtnDelete.Visible = Locator.GetInstance(Of Session).User.Privilege.CashDelete
        BtnExport.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralExportGrid
    End Sub
    Private Sub FrmCashes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvCashesLayout.Load()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvCashItem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvCashItem.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Tipo").Index Then
            Select Case e.Value
                Case Is = GetEnumDescription(CashItemType.Expense)
                    e.CellStyle.ForeColor = Color.DarkRed
                Case Is = GetEnumDescription(CashItemType.Income)
                    e.CellStyle.ForeColor = Color.DarkGreen
            End Select
        ElseIf e.ColumnIndex = Dgv.Columns("Valor").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N2"
        End If
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        Dim Form As New FrmCash(New Cash With {.CashFlow = _Flow}, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim Form As FrmCash
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Cash = New Cash().Load(DgvData.SelectedRows(0).Cells("id").Value, True)
                Form = New FrmCash(_Cash, Me)
                _Cash.CashItems.FillDataGridView(Form.DgvCashItem)
                Form.ShowDialog()
            Catch ex As Exception
                CMessageBox.Show("ERRO CS005", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Cash.Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                If Not _Cash.LockInfo.IsLocked Then
                    If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Try
                            _Cash.Delete()
                            _Filter.Filter()
                            DgvCashesLayout.Load()
                            DgvData.ClearSelection()
                        Catch ex As MySqlException
                            If ex.Number = 1451 Then
                                CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                            Else
                                CMessageBox.Show("ERRO CS006", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                            End If
                        End Try
                    End If
                Else
                    CMessageBox.Show(String.Format("Esse registro não pode ser excluído no momento pois está sendo utilizado por {0}.", GetTitleCase(_Cash.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO CS007", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        _Filter.Filter()
        DgvCashesLayout.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = If(BtnFilter.Checked, False, True)
        SplitContainer1.SplitterDistance = 350
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dim Index As Integer
        If Not Control.ModifierKeys = Keys.Shift Then
            Index = FrmMain.TcWindows.SelectedIndex
            FrmMain.TcWindows.TabPages.Remove(FrmMain.TcWindows.SelectedTab)
            If Index > 0 Then
                FrmMain.TcWindows.SelectTab(Index - 1)
            End If
        Else
            For Each Page As TabPage In FrmMain.TcWindows.TabPages
                FrmMain.TcWindows.TabPages.Remove(Page)
            Next Page
        End If
    End Sub
    Private Sub BtnCloseFilter_Click(sender As Object, e As EventArgs) Handles BtnCloseFilter.Click
        SplitContainer1.Panel1Collapsed = True
        BtnFilter.Checked = False
    End Sub
    Private Sub BtnClean_Click(sender As Object, e As EventArgs) Handles BtnClean.Click
        _Filter.Clean()
        _Filter.Filter()
        PgFilter.Refresh()
        DgvCashesLayout.Load()
        LblStatus.Text = Nothing
        LblStatus.ForeColor = Color.Black
        LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
    End Sub
    Private Sub BtnDetail_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        SplitContainer2.Panel1Collapsed = Not BtnDetails.Checked
        SplitContainer2.SplitterDistance = 700
        LoadDetails()
    End Sub
    Private Sub BtnCloseDetails_Click(sender As Object, e As EventArgs) Handles BtnCloseDetails.Click
        SplitContainer2.Panel1Collapsed = True
        BtnDetails.Checked = False
    End Sub
    Private Sub DgvData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvData.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvData.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEdit.PerformClick()
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvData.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Saldo Atual").Index Then
            If e.Value = 0 Then
                e.CellStyle.ForeColor = Color.Black
            ElseIf e.Value < 0 Then
                e.CellStyle.ForeColor = Color.DarkRed
            Else
                e.CellStyle.ForeColor = Color.DarkGreen
            End If
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ElseIf e.ColumnIndex = Dgv.Columns("Saldo Anterior").Index Or
            e.ColumnIndex = Dgv.Columns("Receita").Index Or
            e.ColumnIndex = Dgv.Columns("Despesa").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ElseIf e.ColumnIndex = Dgv.Columns("Status").Index Then
            Select Case e.Value
                Case Is = GetEnumDescription(CashStatus.Opened)
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case Is = GetEnumDescription(CashStatus.Closed)
                    e.CellStyle.ForeColor = Color.DarkGreen
            End Select
        End If
    End Sub
    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvData.SelectionChanged
        TmrLoadDetail.Start()
        If DgvData.SelectedRows.Count = 0 Then
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        End If
    End Sub
    Private Sub TmrLoadDetail_Tick(sender As Object, e As EventArgs) Handles TmrLoadDetail.Tick
        LoadDetails()
        TmrLoadDetail.Stop()
    End Sub
    Private Sub PgFilter_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PgFilter.PropertyValueChanged
        If _Filter.Filter() = True Then
            DgvCashesLayout.Load()
            LblStatus.Text = "Filtro Ativo"
            LblStatus.ForeColor = Color.DarkRed
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Bold)
        Else
            LblStatus.Text = String.Empty
            LblStatus.ForeColor = Color.Black
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
        End If
    End Sub
    Private Sub LoadDetails()
        If BtnDetails.Checked Then
            If DgvData.SelectedRows.Count = 1 Then
                Try
                    Cash.FillDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvCashItem)
                Catch ex As Exception
                    TmrLoadDetail.Stop()
                    CMessageBox.Show("ERRO CS008", "Ocorreu um erro ao consultar os detalhes do registro selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            Else
                DgvCashItem.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub DgvData_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvData.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEdit.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub DgvData_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvData.DataSourceChanged
        If DgvData.Rows.Count > 0 Then
            LblCounter.Text = DgvData.Rows.Count & " registro" & If(DgvData.Rows.Count > 1, "s", Nothing)
            LblCounter.ForeColor = Color.DimGray
            LblCounter.Font = New Font(LblCounter.Font, FontStyle.Bold)
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub FrmMain_ResizeEnd(sender As Object, e As EventArgs)
        If BtnFilter.Checked Then BtnFilter.PerformClick()
        If Parent.FindForm IsNot Nothing Then
            Height = Parent.FindForm.Height - 196
            Width = Parent.FindForm.Width - 24
        End If
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "Caixas", .Grid = DgvData}})
        Dim FormReport As New FrmReport(Result)
        FrmMain.OpenTab(FormReport, GetEnumDescription(Routine.ExportGrid))
    End Sub
    Private Sub DgvData_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvData.MouseDown
        Dim Click As DataGridView.HitTestInfo = DgvData.HitTest(e.X, e.Y)
        If Click.Type = DataGridViewHitTestType.Cell And e.Button = MouseButtons.Right Then
            DgvData.Rows(Click.RowIndex).Selected = True
            _ShowApproval = True
            _CmsPoint = e.Location
        End If
    End Sub
    Private Sub DgvData_MouseUp(sender As Object, e As MouseEventArgs) Handles DgvData.MouseUp
        If _ShowApproval Then
            BtnOpenCash.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> GetEnumDescription(CashStatus.Opened) And Locator.GetInstance(Of Session).User.Privilege.CashReopen
            BtnCloseCash.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> GetEnumDescription(CashStatus.Closed)
            CmsSetStatus.Show(DgvData.PointToScreen(_CmsPoint))
            _ShowApproval = False
        End If
    End Sub
    Private Sub BtnOpenCash_Click(sender As Object, e As EventArgs) Handles BtnOpenCash.Click
        Try
            Cursor = Cursors.WaitCursor
            _Cash = New Cash().Load(DgvData.SelectedRows(0).Cells("id").Value, False)
            _Cash.SetStatus(CashStatus.Opened)
            BtnCloseCash.Visible = _Cash.Status <> CashStatus.Closed
            BtnOpenCash.Visible = _Cash.Status <> CashStatus.Opened And Locator.GetInstance(Of Session).User.Privilege.CashReopen
            _Filter.Filter()
            DgvCashesLayout.Load()
        Catch ex As Exception
            CMessageBox.Show("ERRO CS012", "Ocorreu um erro ao abrir o caixa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnCloseCash_Click(sender As Object, e As EventArgs) Handles BtnCloseCash.Click
        If _Cash.ID > 0 Then
            Try
                Cursor = Cursors.WaitCursor
                _Cash = New Cash().Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                _Cash.SetStatus(CashStatus.Closed)
                BtnCloseCash.Visible = _Cash.Status <> CashStatus.Closed
                BtnOpenCash.Visible = _Cash.Status <> CashStatus.Opened And Locator.GetInstance(Of Session).User.Privilege.CashReopen
                _Filter.Filter()
                DgvCashesLayout.Load()
            Catch ex As Exception
                CMessageBox.Show("ERRO CS011", "Ocorreu um erro ao fechar o caixa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        Else
            CMessageBox.Show("Esse caixa não pode ser fechado, pois ainda não foi salvo.")
        End If
    End Sub
End Class