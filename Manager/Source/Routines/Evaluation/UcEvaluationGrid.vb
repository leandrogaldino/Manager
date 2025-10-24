Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Extensions
Public Class UcEvaluationGrid
    Private _Evaluation As New Evaluation
    Private _Filter As EvaluationFilter
    Private _CmsPoint As Point
    Private _ShowApproval As Boolean
    Private _User As User
    Public Sub New()
        InitializeComponent()
        ControlHelper.EnableControlDoubleBuffer(DgvData, True)
        ControlHelper.EnableControlDoubleBuffer(DgvWorkedHourSellable, True)
        ControlHelper.EnableControlDoubleBuffer(DgvElapsedDaySellable, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer2.Panel1Collapsed = True
        _Filter = New EvaluationFilter(DgvData, PgFilter)
        _Filter.Filter()
        _User = Locator.GetInstance(Of Session).User
        PgFilter.SelectedObject = _Filter
        LoadDetails()
        DgvlEvaluation.Load()
        BtnInclude.Visible = _User.CanWrite(Routine.Evaluation)
        BtnEdit.Visible = _User.CanWrite(Routine.Evaluation)
        BtnDelete.Visible = _User.CanDelete(Routine.Evaluation)
        BtnExport.Visible = _User.CanAccess(Routine.ExportGrid)
        BtnImport.Visible = _User.CanAccess(Routine.EvaluationImport)
    End Sub
    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvlEvaluation.Load()
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        Using Form As New FrmEvaluation(New Evaluation, Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("id").Value, True)
                Evaluation.FillControlledSellableDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvWorkedHourSellable, CompressorSellableControlType.WorkedHour)
                Using Form As New FrmEvaluation(_Evaluation, Me)
                    Form.ShowDialog()
                End Using
            Catch ex As Exception
                CMessageBox.Show("ERRO EV006", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Evaluation.Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                If Not _Evaluation.LockInfo.IsLocked Then
                    If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Try
                            _Evaluation.Delete()
                            _Filter.Filter()
                            DgvlEvaluation.Load()
                            DgvData.ClearSelection()
                        Catch ex As MySqlException
                            If ex.Number = 1451 Then
                                CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                            Else
                                CMessageBox.Show("ERRO EV007", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                            End If
                        End Try
                    End If
                Else
                    CMessageBox.Show(String.Format("Esse registro não pode ser excluído no momento pois está sendo utilizado por {0}.", _Evaluation.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO EV008", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        _Filter.Filter()
        DgvlEvaluation.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = Not BtnFilter.Checked
        SplitContainer1.SplitterDistance = 350
    End Sub
    Private Sub BtnDetails_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        SplitContainer2.Panel1Collapsed = Not BtnDetails.Checked
        SplitContainer2.SplitterDistance = 700
        LoadDetails()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dim Index As Integer
        Dim Page As TabPage
        If Not Control.ModifierKeys = Keys.Shift Then
            Index = FrmMain.TcWindows.SelectedIndex
            Page = FrmMain.TcWindows.SelectedTab
            FrmMain.TcWindows.TabPages.Remove(Page)
            Page.Dispose()
            If Index > 0 Then
                FrmMain.TcWindows.SelectTab(Index - 1)
            End If
        Else
            For Each Page In FrmMain.TcWindows.TabPages
                FrmMain.TcWindows.TabPages.Remove(Page)
                Page.Dispose()
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
        DgvlEvaluation.Load()
        LblStatus.Text = Nothing
        LblStatus.ForeColor = Color.Black
        LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
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
        If e.ColumnIndex = Dgv.Columns("Status").Index Then
            Select Case e.Value
                Case Is = EnumHelper.GetEnumDescription(EvaluationStatus.Approved)
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case Is = EnumHelper.GetEnumDescription(EvaluationStatus.Rejected)
                    e.CellStyle.ForeColor = Color.DarkRed
                Case Else
                    e.CellStyle.ForeColor = Color.Chocolate
            End Select
        ElseIf e.ColumnIndex = Dgv.Columns("Horímetro").Index Then
            e.CellStyle.Format = "N0"
        ElseIf e.ColumnIndex = Dgv.Columns("CMT").Index Then
            e.CellStyle.Format = "N2"
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvDetail_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvWorkedHourSellable.CellFormatting, DgvElapsedDaySellable.CellFormatting
        Dim Dgv As DataGridView = sender
        If Dgv.Columns.Cast(Of DataGridViewColumn).Any(Function(x) x.Name = "Cap. Atual") Then
            If e.ColumnIndex = Dgv.Columns("Cap. Atual").Index Then
                e.CellStyle.Format = "N0"
            End If
        End If
    End Sub
    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvData.SelectionChanged
        TmrLoadDetails.Start()
        If DgvData.SelectedRows.Count = 0 Then
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        End If
    End Sub
    Private Sub TmrLoadDetails_Tick(sender As Object, e As EventArgs) Handles TmrLoadDetails.Tick
        LoadDetails()
        TmrLoadDetails.Stop()
    End Sub
    Private Sub PgFilter_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PgFilter.PropertyValueChanged
        If _Filter.Filter() = True Then
            DgvlEvaluation.Load()
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
                    Evaluation.FillControlledSellableDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvWorkedHourSellable, CompressorSellableControlType.WorkedHour)
                    Evaluation.FillControlledSellableDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvElapsedDaySellable, CompressorSellableControlType.ElapsedDay)
                Catch ex As Exception
                    TmrLoadDetails.Stop()
                    CMessageBox.Show("ERRO EV009", "Ocorreu um erro ao consultar os detalhes do registro selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            Else
                DgvWorkedHourSellable.DataSource = Nothing
                DgvElapsedDaySellable.DataSource = Nothing
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
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "Avaliações", .Grid = DgvData}})
        FrmMain.OpenTab(New UcReport(Result), EnumHelper.GetEnumDescription(Routine.ExportGrid))
    End Sub
    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles BtnApprove.Click
        Try
            Cursor = Cursors.WaitCursor
            _Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("id").Value, False)
            _Evaluation.SetStatus(EvaluationStatus.Approved)
            _Filter.Filter()
            DgvlEvaluation.Load()
        Catch ex As Exception
            CMessageBox.Show("ERRO EV015", "Ocorreu um erro ao aprovar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnReject_Click(sender As Object, e As EventArgs) Handles BtnReject.Click
        Using Form As New FrmEvaluationRejectReason
            If Form.ShowDialog = DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                    _Evaluation.SetStatus(EvaluationStatus.Rejected, Form.TxtReason.Text)
                    _Filter.Filter()
                    DgvlEvaluation.Load()
                Catch ex As Exception
                    CMessageBox.Show("ERRO EV016", "Ocorreu um erro ao rejeitar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Finally
                    Cursor = Cursors.Default
                End Try
            End If
        End Using
    End Sub
    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles BtnDisapprove.Click
        Try
            Cursor = Cursors.WaitCursor
            _Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("id").Value, False)
            _Evaluation.SetStatus(EvaluationStatus.Disapproved)
            _Filter.Filter()
            DgvlEvaluation.Load()
        Catch ex As Exception
            CMessageBox.Show("ERRO EV021", "Ocorreu um erro ao desaprovar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
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
        If _ShowApproval And _User.CanAccess(Routine.EvaluationApproveOrReject) Then
            BtnApprove.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> EnumHelper.GetEnumDescription(EvaluationStatus.Approved)
            BtnReject.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> EnumHelper.GetEnumDescription(EvaluationStatus.Rejected)
            BtnDisapprove.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> EnumHelper.GetEnumDescription(EvaluationStatus.Disapproved)
            CmsSetStatus.Show(DgvData.PointToScreen(_CmsPoint))
            _ShowApproval = False
        End If
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Using Form As New FrmEvaluationImport(Me)
            Form.ShowDialog()
        End Using
    End Sub
End Class
