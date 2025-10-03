Imports ControlLibrary
Imports Syncfusion.Pdf
Imports Syncfusion.Pdf.Graphics
Imports ManagerCore
Imports System.IO

Public Class FrmEvaluationManagement
    Private _Filter As EvaluationManagementFilter
    Private _CmsPoint As Point
    Private _ShowCms As Boolean
    Private _Session As Session
    Private _User As User
    Public Sub New()
        InitializeComponent()
        _Filter = New EvaluationManagementFilter(DgvData, PgFilter)
        ControlHelper.EnableControlDoubleBuffer(DgvData, True)
        ControlHelper.EnableControlDoubleBuffer(DgvWorkedHourSellable, True)
        ControlHelper.EnableControlDoubleBuffer(DgvElapsedDaySellable, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer2.Panel1Collapsed = True
        _Filter.Filter()
        _Session = Locator.GetInstance(Of Session)
        _User = _Session.User
        PgFilter.SelectedObject = _Filter
        LoadDetails()
        BtnExport.Visible = Locator.GetInstance(Of Session).User.CanAccess(Routine.ExportGrid)
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvEvaluationManagementLayout.Load()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        _Filter.Filter()
        DgvEvaluationManagementLayout.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = Not BtnFilter.Checked
        SplitContainer1.SplitterDistance = 350
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
        DgvEvaluationManagementLayout.Load()
        LblStatus.Text = Nothing
        LblStatus.ForeColor = Color.Black
        LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
    End Sub
    Private Sub BtnDetails_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        SplitContainer2.Panel1Collapsed = Not BtnDetails.Checked
        SplitContainer2.SplitterDistance = 520
        LoadDetails()
    End Sub
    Private Sub BtnCloseDetails_Click(sender As Object, e As EventArgs) Handles BtnCloseDetails.Click
        SplitContainer2.Panel1Collapsed = True
        BtnDetails.Checked = False
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvData.CellFormatting
        Dim Dgv As DataGridView = sender
        If Dgv.Rows(e.RowIndex).Cells("nextexchange").Value >= Today And Dgv.Rows(e.RowIndex).Cells("nextexchange").Value <= Today.AddDays(_Session.Setting.General.Evaluation.DaysBeforeMaintenanceAlert) Then
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Bisque
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkOrange
            Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Orange
        ElseIf Dgv.Rows(e.RowIndex).Cells("nextexchange").Value < Today Then
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightCoral
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkRed
            Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        Else
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightGreen
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkGreen
            Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub Dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvWorkedHourSellable.CellFormatting, DgvElapsedDaySellable.CellFormatting
        Dim Dgv As DataGridView = sender
        If Dgv.Rows(e.RowIndex).Cells("nextexchange").Value >= Today And Dgv.Rows(e.RowIndex).Cells("nextexchange").Value <= Today.AddDays(_Session.Setting.General.Evaluation.DaysBeforeMaintenanceAlert) Then
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Bisque
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkOrange
            Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Orange
        ElseIf Dgv.Rows(e.RowIndex).Cells("nextexchange").Value < Today Then
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightCoral
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkRed
            Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        Else
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightGreen
            Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkGreen
            Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
        End If
    End Sub
    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvData.SelectionChanged
        TmrLoadDetails.Start()
    End Sub
    Private Sub TmrLoadDetails_Tick(sender As Object, e As EventArgs) Handles TmrLoadDetails.Tick
        LoadDetails()
        TmrLoadDetails.Stop()
    End Sub
    Private Sub PgFilter_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PgFilter.PropertyValueChanged
        If _Filter.Filter() = True Then
            LblStatus.Text = "Filtro Ativo"
            LblStatus.ForeColor = Color.DarkRed
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Bold)
        Else
            LblStatus.Text = String.Empty
            LblStatus.ForeColor = Color.Black
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
        End If
        DgvEvaluationManagementLayout.Load()
    End Sub
    Private Sub LoadDetails()
        If BtnDetails.Checked Then
            If DgvData.SelectedRows.Count = 1 Then
                Try
                    _Filter.FilterControlledSellable(DgvData.SelectedRows(0).Cells("evaluation").Value, DgvWorkedHourSellable, CompressorSellableControlType.WorkedHour)
                    _Filter.FilterControlledSellable(DgvData.SelectedRows(0).Cells("evaluation").Value, DgvElapsedDaySellable, CompressorSellableControlType.ElapsedDay)
                    LblUnit.Text = _Filter.GetUnitNextChange(DgvData.SelectedRows(0).Cells("evaluation").Value).ToString("dd/MM/yyyy")
                    If LblUnit.Text >= Today And LblUnit.Text <= Today.AddDays(_Session.Setting.General.Evaluation.DaysBeforeMaintenanceAlert) Then
                        LblUnit.ForeColor = Color.Orange
                    ElseIf CDate(LblUnit.Text) < Today Then
                        LblUnit.ForeColor = Color.Red
                    Else
                        LblUnit.ForeColor = Color.Green
                    End If
                Catch ex As Exception
                    TmrLoadDetails.Stop()
                    CMessageBox.Show("ERRO EV005", "Ocorreu um erro ao consultar os dados do registro selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            Else
                DgvWorkedHourSellable.DataSource = Nothing
                DgvElapsedDaySellable.DataSource = Nothing
            End If
        End If
    End Sub
    Private Sub DgvData_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvData.DataSourceChanged
        If DgvData.Rows.Count > 0 Then
            LblCounter.Text = DgvData.Rows.Count & " registro" & If(DgvData.Rows.Count > 1, "s", Nothing)
            LblCounter.ForeColor = Color.DimGray
            LblCounter.Font = New Font(LblCounter.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub DgvWorkedHourSellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvWorkedHourSellable.MouseDoubleClick
        Dim Evaluation As Evaluation
        Dim ClickPlace As DataGridView.HitTestInfo = DgvWorkedHourSellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            Evaluation = New Evaluation().Load(DgvWorkedHourSellable.SelectedRows(0).Cells("lastchangeevaluation").Value, False)
            Using Form As New FrmEvaluation(Evaluation)
                Form.ShowDialog()
            End Using
            _Filter.Filter()
            DgvEvaluationManagementLayout.Load()
            LoadDetails()
        End If
    End Sub
    Private Sub DgvElapsedDaySellableMouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvElapsedDaySellable.MouseDoubleClick
        Dim Evaluation As Evaluation
        Dim ClickPlace As DataGridView.HitTestInfo = DgvElapsedDaySellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            Evaluation = New Evaluation().Load(DgvElapsedDaySellable.SelectedRows(0).Cells("lastchangeevaluation").Value, False)
            Using Form As New FrmEvaluation(Evaluation)
                Form.ShowDialog()
            End Using
            _Filter.Filter()
            DgvEvaluationManagementLayout.Load()
            LoadDetails()
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub FrmMain_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If Me.Disposing OrElse Me.IsDisposed Then Return
        If BtnFilter.Checked Then BtnFilter.PerformClick()
        If Parent.FindForm IsNot Nothing Then
            Height = Parent.FindForm.Height - 196
            Width = Parent.FindForm.Width - 24
        End If
    End Sub
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "Gerenciamento de Avaliações", .Grid = DgvData}})
        Dim Form As New FrmReport(Result)
        FrmMain.OpenTab(Form, EnumHelper.GetEnumDescription(Routine.ExportGrid))
    End Sub
    Private Sub DgvData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvData.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvData.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            LoadEvaluation()
        End If
    End Sub
    Private Sub DgvData_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvData.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadEvaluation()
            e.Handled = True
        End If
    End Sub
    Private Sub LoadEvaluation()
        Dim Evaluation As Evaluation
        Dim Row As DataGridViewRow
        Dim EvaluationID As Long
        Dim Nav As New DataGridViewNavigator() With {.DataGridView = DgvData}
        Try
            Cursor = Cursors.WaitCursor
            EvaluationID = DgvData.SelectedRows(0).Cells("evaluation").Value
            Evaluation = New Evaluation().Load(EvaluationID, True)
            Using Form As New FrmEvaluation(Evaluation)
                Form.ShowDialog()
            End Using
            _Filter.Filter()
            DgvEvaluationManagementLayout.Load()
            Row = DgvData.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("evaluation").Value = EvaluationID)
            If Row IsNot Nothing Then Nav.EnsureVisibleRow(Row.Index)
        Catch ex As Exception
            CMessageBox.Show("ERRO EV017", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Function GetAutomaticPDF() As String
        Dim Filename As String
        Filename = TextHelper.GetRandomFileName(".pdf")
        Using document As New PdfDocument()
            Dim page As PdfPage = document.Pages.Add()
            Dim graphics As PdfGraphics = page.Graphics
            Dim font As PdfFont = New PdfStandardFont(PdfFontFamily.Helvetica, 100)
            Dim text As String = "AUTOMÁTICO"
            Dim textSize As SizeF = font.MeasureString(text)
            Dim startPoint As New PointF((page.Size.Width - textSize.Width) / 2, (page.Size.Height - textSize.Height) / 2)
            graphics.TranslateTransform(startPoint.X + textSize.Width / 2, startPoint.Y + textSize.Height / 2)
            graphics.RotateTransform(45)
            graphics.TranslateTransform(-textSize.Width / 2, -textSize.Height / 2)
            graphics.DrawString(text, font, PdfBrushes.DarkRed, PointF.Empty)
            graphics.TranslateTransform(startPoint.X + textSize.Width / 2, startPoint.Y + textSize.Height / 2)
            graphics.RotateTransform(-45)
            graphics.TranslateTransform(-startPoint.X - textSize.Width / 2, -startPoint.Y - textSize.Height / 2)
            Filename = Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename)
            Try
                document.Save(Filename)
                Return Filename
            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Function
    Private Sub DgvData_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvData.MouseDown
        Dim Click As DataGridView.HitTestInfo = DgvData.HitTest(e.X, e.Y)
        If Click.Type = DataGridViewHitTestType.Cell And e.Button = MouseButtons.Right Then
            DgvData.Rows(Click.RowIndex).Selected = True
            _ShowCms = True
            _CmsPoint = e.Location
        End If
    End Sub
    Private Sub DgvData_MouseUp(sender As Object, e As MouseEventArgs) Handles DgvData.MouseUp
        If _ShowCms Then
            CmsOptions.Show(DgvData.PointToScreen(_CmsPoint))
            _ShowCms = False
        End If
    End Sub
    Private Sub CmsOptions_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CmsOptions.Opening
        If Not _User.CanAccess(Routine.EvaluationCreateAutomaticRecord) And Not _User.CanAccess(Routine.VisitSchedule) Then e.Cancel = True
        BtnAutoEvaluation.Visible = _User.CanAccess(Routine.EvaluationCreateAutomaticRecord)
        BtnVisitSchedule.Visible = _User.CanAccess(Routine.VisitSchedule)
    End Sub
    Private Sub BtnAutoEvaluation_Click(sender As Object, e As EventArgs) Handles BtnAutoEvaluation.Click
        Try
            If DgvData.SelectedRows.Count = 1 Then
                If CMessageBox.Show("Confirma o lançamento automático para esse compressor?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Dim SelectedEvaluation As Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("evaluation").Value, False)
                    Dim NewEvaluation As New Evaluation With {
                        .EvaluationNumber = Evaluation.GetEvaluationNumber(EvaluationSource.Automatic),
                        .AverageWorkLoad = SelectedEvaluation.AverageWorkLoad,
                        .Compressor = SelectedEvaluation.Compressor,
                        .Customer = SelectedEvaluation.Customer,
                        .StartTime = New TimeSpan(0, 1, 0),
                        .EndTime = New TimeSpan(0, 2, 0),
                        .EvaluationDate = Today,
                        .Horimeter = SelectedEvaluation.Horimeter + ((Today - SelectedEvaluation.EvaluationDate).Days * SelectedEvaluation.AverageWorkLoad),
                        .CallType = CallType.Contract,
                        .Responsible = SelectedEvaluation.Responsible,
                        .TechnicalAdvice = SelectedEvaluation.TechnicalAdvice
                    }
                    NewEvaluation.Document.SetCurrentFile(GetAutomaticPDF)
                    SelectedEvaluation.Technicians.ToList().ForEach(Sub(x) NewEvaluation.Technicians.Add(x))



                    NewEvaluation.WorkedHourControlledSelable.ToList().ForEach(Sub(x)
                                                                       x.Lost = False
                                                                       x.Sold = False
                                                                       x.CurrentCapacity = x.PersonCompressorSellable.Capacity
                                                                   End Sub
                                                                   )
                    NewEvaluation.ElapsedDayControlledSellable.ToList().ForEach(Sub(x)
                                                                       x.Lost = False
                                                                       x.Sold = False
                                                                       x.CurrentCapacity = x.PersonCompressorSellable.Capacity
                                                                   End Sub
                                                                   )
                    NewEvaluation.SaveChanges()
                    NewEvaluation.SetStatus(EvaluationStatus.Approved)
                    BtnRefresh.PerformClick()
                End If
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO EV024", "Ocorreu um erro ao gerar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
    End Sub
    Private Sub BtnVisitSchedule_Click(sender As Object, e As EventArgs) Handles BtnVisitSchedule.Click
        Try
            If DgvData.SelectedRows.Count = 1 Then
                Dim SelectedEvaluation As Evaluation = New Evaluation().Load(DgvData.SelectedRows(0).Cells("evaluation").Value, False)
                Dim Visit As New VisitSchedule With {
                    .Compressor = SelectedEvaluation.Compressor,
                    .Customer = SelectedEvaluation.Customer
                }
                Using Form As New FrmVisitSchedule(Visit)
                    Form.ShowDialog()
                End Using
                BtnRefresh.PerformClick()
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO EV025", "Ocorreu um erro agendar uma visita.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
    End Sub
End Class