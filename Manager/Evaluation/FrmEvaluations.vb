Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility

Public Class FrmEvaluations
    Private _Evaluation As New Evaluation
    Private _Filter As EvaluationFilter
    Private _CmsPoint As Point
    Private _ShowApproval As Boolean
    Public Sub New()
        InitializeComponent()
        Utility.EnableDataGridViewDoubleBuffer(DgvData, True)
        Utility.EnableDataGridViewDoubleBuffer(DgvPartWorkedHour, True)
        Utility.EnableDataGridViewDoubleBuffer(DgvPartElapsedDay, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer2.Panel1Collapsed = True
        _Filter = New EvaluationFilter(DgvData, PgFilter)
        _Filter.Filter()
        PgFilter.SelectedObject = _Filter
        LoadDetails()
        DgvEvaluationLayout.Load()
        BtnInclude.Visible = Locator.GetInstance(Of Session).User.Privilege.EvaluationWrite
        BtnEdit.Visible = Locator.GetInstance(Of Session).User.Privilege.EvaluationWrite
        BtnDelete.Visible = Locator.GetInstance(Of Session).User.Privilege.EvaluationDelete
        BtnExport.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralExportGrid
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvEvaluationLayout.Load()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        Dim Form As New FrmEvaluation(New Evaluation, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim EvaluationForm As FrmEvaluation
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("id").Value, True)
                EvaluationForm = New FrmEvaluation(_Evaluation, Me)
                Evaluation.FillDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvPartWorkedHour, CompressorPartType.WorkedHour)
                EvaluationForm.ShowDialog()
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
                            DgvEvaluationLayout.Load()
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
                    CMessageBox.Show(String.Format("Esse registro não pode ser excluído no momento pois está sendo utilizado por {0}.", GetTitleCase(_Evaluation.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
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
        DgvEvaluationLayout.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = If(BtnFilter.Checked, False, True)
        SplitContainer1.SplitterDistance = 350
    End Sub
    Private Sub BtnDetails_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        SplitContainer2.Panel1Collapsed = Not BtnDetails.Checked
        SplitContainer2.SplitterDistance = 700
        LoadDetails()
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
        DgvEvaluationLayout.Load()
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
                Case Is = GetEnumDescription(EvaluationStatus.Approved)
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case Is = GetEnumDescription(EvaluationStatus.Rejected)
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
    Private Sub DgvDetail_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvPartWorkedHour.CellFormatting, DgvPartElapsedDay.CellFormatting
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
            DgvEvaluationLayout.Load()
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
                    Evaluation.FillDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvPartWorkedHour, CompressorPartType.WorkedHour)
                    Evaluation.FillDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvPartElapsedDay, CompressorPartType.ElapsedDay)
                Catch ex As Exception
                    TmrLoadDetails.Stop()
                    CMessageBox.Show("ERRO EV009", "Ocorreu um erro ao consultar os detalhes do registro selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            Else
                DgvPartWorkedHour.DataSource = Nothing
                DgvPartElapsedDay.DataSource = Nothing
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
    Private Sub FrmMain_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If BtnFilter.Checked Then BtnFilter.PerformClick()
        If Parent.FindForm IsNot Nothing Then
            Height = Parent.FindForm.Height - 196
            Width = Parent.FindForm.Width - 24
        End If
    End Sub
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "Avaliações", .Grid = DgvData}})
        Dim FormReport As New FrmReport(Result)
        FrmMain.OpenTab(FormReport, GetEnumDescription(Routine.ExportGrid))
    End Sub
    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles BtnApprove.Click
        Try
            Cursor = Cursors.WaitCursor
            _Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("id").Value, False)
            _Evaluation.SetStatus(EvaluationStatus.Approved)
            _Filter.Filter()
            DgvEvaluationLayout.Load()
        Catch ex As Exception
            CMessageBox.Show("ERRO EV015", "Ocorreu um erro ao aprovar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnReject_Click(sender As Object, e As EventArgs) Handles BtnReject.Click
        Using FormReject As New FrmEvaluationRejectReason
            If FormReject.ShowDialog = DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                    _Evaluation.SetStatus(EvaluationStatus.Rejected, FormReject.TxtReason.Text)
                    _Filter.Filter()
                    DgvEvaluationLayout.Load()
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
            DgvEvaluationLayout.Load()
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
        If _ShowApproval And Locator.GetInstance(Of Session).User.Privilege.EvaluationApproveOrReject Then
            BtnApprove.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> GetEnumDescription(EvaluationStatus.Approved)
            BtnReject.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> GetEnumDescription(EvaluationStatus.Rejected)
            BtnDisapprove.Visible = DgvData.SelectedRows(0).Cells("Status").Value <> GetEnumDescription(EvaluationStatus.Disapproved)
            CmsSetStatus.Show(DgvData.PointToScreen(_CmsPoint))
            _ShowApproval = False
        End If
    End Sub
End Class