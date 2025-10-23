Imports ControlLibrary
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Globalization
Imports ManagerCore
Imports ManagerCore.LocalDB
Imports System.Transactions
Public Class UcEvaluationManagementPanelGrid
    Private _InDayDetail As New UcEvaluationCardDetail
    Private _ToOverdueDetail As New UcEvaluationCardDetail
    Private _OverDueDetail As New UcEvaluationCardDetail
    Private _UnitOverdueDetail As New UcEvaluationCardDetail
    Private _NeverVisitDetail As New UcEvaluationCardDetail
    Private _ToVisitDetail As New UcEvaluationCardDetail
    Private _TotalDetail As New UcEvaluationCardDetail
    Private _Dates As New List(Of Dictionary(Of String, Object))
    Private _YearChanged As Boolean
    Private _Session As Session
    Private _User As User
    Public Sub New()
        InitializeComponent()
        _Session = Locator.GetInstance(Of Session)
        _User = _Session.User
        ConfigureControls()
    End Sub
    Private Async Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        Await RefreshDates()
        Await RefreshData()
    End Sub
    Private Sub ConfigureControls()
        CbxInformation.Items.AddRange(EnumHelper.GetEnumDescriptions(Of EvaluationPanelInformation).ToArray)
        CbxInformation.SelectedIndex = 0
        CcoInDay.DropDownControl = _InDayDetail
        CcoInDay.HostControl = LblInDayValue
        CcoToOverdue.DropDownControl = _ToOverdueDetail
        CcoToOverdue.HostControl = LblToOverdueValue
        CcoOverdue.DropDownControl = _OverDueDetail
        CcoOverdue.HostControl = LblOverdueValue
        CcoOverdueUnit.DropDownControl = _UnitOverdueDetail
        CcoOverdueUnit.HostControl = LblOverdueUnitValue
        CcoNoVisited.DropDownControl = _NeverVisitDetail
        CcoNoVisited.HostControl = LblNeverVisitedValue
        CcoToVisit.DropDownControl = _ToVisitDetail
        CcoToVisit.HostControl = LblToVisitValue
        CcoTotal.DropDownControl = _TotalDetail
        CcoTotal.HostControl = LblTotalValue
        Tip.SetToolTip(LblInDayValue, "Compressores sem itens vencidos")
        Tip.SetToolTip(LblToOverdueValue, String.Format("Compressores com itens vencendo em até {0} dias", _Session.Setting.General.Evaluation.DaysBeforeMaintenanceAlert))
        Tip.SetToolTip(LblOverdueValue, "Compressores com itens vencidos")
        Tip.SetToolTip(LblOverdueUnit, "Compressores com manutenção da unidade compressora vencida.")
        Tip.SetToolTip(LblNeverVisitedValue, "Compressores sem avaliação lançada e/ou aprovada")
        Tip.SetToolTip(LblToVisitValue, String.Format("Compressores com avaliação lançada mas não visitados há mais de {0} dias", _Session.Setting.General.Evaluation.DaysBeforeVisitAlert))
        Tip.SetToolTip(LblTotalValue, "Todos os compressores cadastrados.")
        BtnExport.Visible = _User.CanAccess(Routine.EvaluationExportManagementPanel) Or _User.CanAccess(Routine.ExportGrid)
        BtnExportPanelImage.Visible = _User.CanAccess(Routine.EvaluationExportManagementPanel)
        BtnExportGrid.Visible = _User.CanAccess(Routine.ExportGrid)
    End Sub
    Private Async Function RefreshDates() As Task
        Dim Db As LocalDB = Locator.GetInstance(Of LocalDB)
        Dim Result As QueryResult
        Dim Years As List(Of Integer)
        Await Db.ExecuteRawQueryAsync(My.Resources.SetBrazilianDatabaseMonthNames)
        Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementPanelDatesSelect)
        _Dates = Result.Data
        Years = _Dates.Select(Of Integer)(Function(d) d("yearnumber")).Distinct().OrderByDescending(Function(y) y).ToList()
        CbxYear.DataSource = Years
    End Function

    Private Async Sub ComboBoxYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxYear.SelectedIndexChanged
        _YearChanged = True
        Dim SelectedYear As String = CbxYear.SelectedItem.ToString()
        Dim Months As List(Of String) = _Dates.Where(Function(d) d("yearnumber") = SelectedYear).Select(Of String)(Function(d) d("monthname")).Distinct().ToList()
        CbxMonth.DataSource = Months
        Await FillChart()
        _YearChanged = False
    End Sub
    Private Async Sub CbxMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMonth.SelectedIndexChanged
        If Not _YearChanged Then
            Await FillChart()
        End If
    End Sub
    Private Async Sub CbxInformation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxInformation.SelectedIndexChanged
        If CbxInformation.SelectedIndex = CInt(EvaluationPanelInformation.Visits) Then
            LblMonth.Visible = False
            CbxMonth.Visible = False
        Else
            LblMonth.Visible = True
            CbxMonth.Visible = True
        End If
        Await FillChart()
    End Sub
    Private Async Function RefreshData() As Task
        Await RefreshDates()
        Await FillCards()
        Await FillChart()
    End Function
    Private Async Function FillCards() As Task
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Dim TableNeverVisited As New DataTable
        Dim TableToVisit As New DataTable
        Dim TableUnitOverdue As New DataTable
        Dim Db As LocalDB = Locator.GetInstance(Of LocalDB)
        Dim Result As QueryResult
        Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
            Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementFilter, New Dictionary(Of String, Object) From {
                {"@personid", "%"},
                {"@persondocument", "%"},
                {"@personname", "%"},
                {"@zipcode", "%"},
                {"@address", "%"},
                {"@city", "%"},
                {"@state", "%"},
                {"@compressorname", "%"},
                {"@serialnumber", "%"},
                {"@patrimony", "%"},
                {"@sector", "%"},
                {"@route", "%"},
                {"@nextexchangei", "0000-01-01"},
                {"@nextexchangef", "9999-12-31"}
            })
            TableResult = Result.Table
            Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementPanelNoVisited)
            TableNeverVisited = Result.Table
            Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementPanelCustomerToVisit, New Dictionary(Of String, Object) From {{"@days", Session.Setting.General.Evaluation.DaysBeforeVisitAlert}})
            TableToVisit = Result.Table
            Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementPanelUnitOverdue)
            TableUnitOverdue = Result.Table
            Scope.Complete()
        End Using
        FillCardInDay(TableResult, Session)
        FillCardToOverdue(TableResult, Session)
        FillCardOverdue(TableResult)
        FillCardUnitOverdue(TableUnitOverdue)
        FillCardNeverVisited(TableNeverVisited)
        FillCardToVisit(TableToVisit)
        FillCardTotal()
    End Function
    Private Sub FillCardInDay(tableResult As DataTable, session As Session)
        Dim tableInDay = tableResult.Clone()
        Dim rows = tableResult.AsEnumerable().Where(Function(x) x.Item("nextexchange") IsNot DBNull.Value AndAlso
                                                 CDate(x.Item("nextexchange")) > Today.AddDays(session.Setting.General.Evaluation.DaysBeforeMaintenanceAlert)).ToList()
        rows.ForEach(Sub(x) tableInDay.ImportRow(x))
        FillDataGridView(_InDayDetail.DgvCardDetail, tableInDay)
        LblInDayValue.Text = If(tableInDay.Rows.Count > 0, tableInDay.Rows.Count.ToString(), "-")
    End Sub
    Private Sub FillCardToOverdue(tableResult As DataTable, session As Session)
        Dim tableToOverdue = tableResult.Clone()
        Dim rows = tableResult.AsEnumerable().Where(Function(x) x.Item("nextexchange") IsNot DBNull.Value AndAlso
                                                 (CDate(x.Item("nextexchange")) >= Today AndAlso CDate(x.Item("nextexchange")) <= Today.AddDays(session.Setting.General.Evaluation.DaysBeforeMaintenanceAlert))).ToList()
        rows.ForEach(Sub(x) tableToOverdue.ImportRow(x))
        FillDataGridView(_ToOverdueDetail.DgvCardDetail, tableToOverdue)
        LblToOverdueValue.Text = If(tableToOverdue.Rows.Count > 0, tableToOverdue.Rows.Count.ToString(), "-")
    End Sub

    Private Sub FillCardOverdue(tableResult As DataTable)
        Dim tableOverdue = tableResult.Clone()
        Dim rows = tableResult.AsEnumerable().Where(Function(x) x.Item("nextexchange") IsNot DBNull.Value AndAlso
                                                 CDate(x.Item("nextexchange")) < Today).ToList()
        rows.ForEach(Sub(x) tableOverdue.ImportRow(x))
        FillDataGridView(_OverDueDetail.DgvCardDetail, tableOverdue)
        LblOverdueValue.Text = If(tableOverdue.Rows.Count > 0, tableOverdue.Rows.Count.ToString(), "-")
    End Sub

    Private Sub FillCardUnitOverdue(tableUnitOverdue As DataTable)
        FillDataGridView(_UnitOverdueDetail.DgvCardDetail, tableUnitOverdue)
        LblOverdueUnitValue.Text = If(tableUnitOverdue.Rows.Count > 0, tableUnitOverdue.Rows.Count.ToString(), "-")
    End Sub

    Private Sub FillCardNeverVisited(tableNeverVisited As DataTable)
        FillDataGridView(_NeverVisitDetail.DgvCardDetail, tableNeverVisited)
        LblNeverVisitedValue.Text = If(tableNeverVisited.Rows.Count > 0, tableNeverVisited.Rows.Count.ToString(), "-")
    End Sub

    Private Sub FillCardToVisit(tableToVisit As DataTable)
        FillDataGridView(_ToVisitDetail.DgvCardDetail, tableToVisit)
        LblToVisitValue.Text = If(tableToVisit.Rows.Count > 0, tableToVisit.Rows.Count.ToString(), "-")
    End Sub

    Private Sub FillCardTotal()
        Dim TableTotal As New DataTable
        TableTotal.Columns.Add("customer", GetType(String))
        TableTotal.Columns.Add("city", GetType(String))
        TableTotal.Columns.Add("compressor", GetType(String))
        TableTotal.Columns.Add("serialnumber", GetType(String))
        Dim allRows As New List(Of DataGridView) From {
            _InDayDetail.DgvCardDetail,
            _ToOverdueDetail.DgvCardDetail,
            _OverDueDetail.DgvCardDetail,
            _NeverVisitDetail.DgvCardDetail
        }
        Dim totalCount As Integer = 0
        For Each dgv In allRows
            For Each row As DataGridViewRow In dgv.Rows
                TableTotal.Rows.Add({row.Cells("customer").Value, row.Cells("city").Value, row.Cells("compressor").Value, row.Cells("serialnumber").Value})
                totalCount += 1
            Next
        Next
        If totalCount > 0 Then
            TableTotal.DefaultView.Sort = "customer ASC"
            _TotalDetail.DgvCardDetail.DataSource = TableTotal
            FillDataGridView(_TotalDetail.DgvCardDetail, TableTotal)
            LblTotalValue.Text = totalCount.ToString()
        Else
            LblTotalValue.Text = "-"
        End If
    End Sub
    Private Sub FillDataGridView(dgv As DataGridView, dt As DataTable)
        dgv.DataSource = dt
        For Each col As DataGridViewColumn In dgv.Columns
            Select Case col.Name.ToLower()
                Case "evaluation", "personid", "personcompressorid", "hasevaluation", "workedhourexchangeday", "elapseddayexchangeday"
                    col.Visible = False
                Case "customer"
                    col.HeaderText = "Cliente"
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Case "city"
                    col.HeaderText = "Cidade"
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "compressor"
                    col.HeaderText = "Compressor"
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "serialnumber"
                    col.HeaderText = "Nº Série"
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "nextexchange"
                    col.HeaderText = "Próx. Troca"
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "horimeter"
                    col.HeaderText = "Horímetro"
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "evaluationdate"
                    col.HeaderText = "Ult. Visita"
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End Select
        Next
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
    Private Function ExportImage() As String
        Dim Filename As String = Path.GetRandomFileName
        Dim Enc = ImageCodecInfo.GetImageEncoders().First(Function(c) c.FormatID = ImageFormat.Jpeg.Guid)
        Dim EncParams As New EncoderParameters() With {.Param = {New EncoderParameter(Encoder.Quality, 100L)}}
        PnContainer.BackColor = Color.White
        Using Bmp = New Bitmap(PnContainer.Width, PnContainer.Height)
            PnContainer.DrawToBitmap(Bmp, New Rectangle(0, 0, Bmp.Width, Bmp.Height))
            Bmp.Save(Path.Combine(ApplicationPaths.ManagerTempDirectory, String.Format("{0}.jpg", Filename)), Enc, EncParams)
        End Using
        PnContainer.BackColor = Color.FromArgb(40, 40, 40)
        Return Path.Combine(ApplicationPaths.ManagerTempDirectory, String.Format("{0}.jpg", Filename))
    End Function
    Private Sub BtnExportPanelImage_Click(sender As Object, e As EventArgs) Handles BtnExportPanelImage.Click
        Dim Sfd As New SaveFileDialog
        Dim File As String = ExportImage()
        Sfd.Title = "Exportar"
        Sfd.Filter = "Imagem (*.jpg*)|*.jpg"
        Sfd.FileName = "Painel de Compressores"
        If Sfd.ShowDialog = DialogResult.OK Then
            IO.File.Copy(File, Sfd.FileName, True)
        End If
    End Sub
    Private Sub BtnExportGrid_Click(sender As Object, e As EventArgs) Handles BtnExportGrid.Click
        Using Form As New FrmEvaluationManagementPanelExport(_InDayDetail.DgvCardDetail, _ToOverdueDetail.DgvCardDetail, _OverDueDetail.DgvCardDetail, _UnitOverdueDetail.DgvCardDetail, _NeverVisitDetail.DgvCardDetail, _ToVisitDetail.DgvCardDetail, _TotalDetail.DgvCardDetail)
            Form.ShowDialog()
        End Using
    End Sub
    Private Function GetElapsedHoursInMonth() As Decimal
        Const AverageHourPerDay As Decimal = 6.285
        If CbxMonth.Text = New DateTimeFormatInfo().GetMonthName(Today.Month) Then
            Return Today.Day * AverageHourPerDay
        Else
            Return Date.DaysInMonth(CbxYear.Text, Date.ParseExact(CbxMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month) * AverageHourPerDay
        End If
    End Function
    Private Async Function FillChart() As Task
        If CbxInformation.SelectedIndex = EvaluationPanelInformation.Visits Then
            If CbxYear.Text <> Nothing Then
                Try
                    Cursor = Cursors.WaitCursor
                    Await FillChartVisits()
                Catch ex As Exception
                    CMessageBox.Show("ERRO EV012", "Ocorreu um erro ao carregar os paineis.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Finally
                    Cursor = Cursors.Default
                End Try
            End If
        ElseIf CbxInformation.SelectedIndex = EvaluationPanelInformation.Productivity Then
            If CbxYear.Text <> Nothing And CbxMonth.Text <> Nothing Then
                Try
                    Cursor = Cursors.WaitCursor
                    Await FillChartProductivity()
                Catch ex As Exception
                    CMessageBox.Show("ERRO EV022", "Ocorreu um erro ao carregar os paineis.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Finally
                    Cursor = Cursors.Default
                End Try
            End If
        End If
    End Function
    Private Async Function FillChartProductivity() As Task
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableGathering As New DataTable
        Dim TableExecution As New DataTable
        Dim TableMerged As New DataTable
        Dim Highest As Decimal
        Dim Time As TimeSpan
        Dim Db As LocalDB = Locator.GetInstance(Of LocalDB)
        Dim Result As QueryResult
        Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
            Await Db.ExecuteRawQueryAsync(My.Resources.SetBrazilianDatabaseMonthNames)
            Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementPanelFillChartProductivityChartSelect, New Dictionary(Of String, Object) From {
                {"@hasrepairid", ConfirmationType.No},
                {"@month", CbxMonth.Text},
                {"@year", CbxYear.Text}
            })
            TableGathering = Result.Table
            Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementPanelFillChartProductivityChartSelect, New Dictionary(Of String, Object) From {
                {"@hasrepairid", ConfirmationType.Yes},
                {"@month", CbxMonth.Text},
                {"@year", CbxYear.Text}
            })
            TableExecution = Result.Table
            Scope.Complete()
        End Using
        'Chart.ChartAreas(0).AxisY.Maximum = GetElapsedHoursInMonth()
        Chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart.Series.Clear()
        Chart.Series.Add("Execution")
        Chart.Series("Execution").LabelForeColor = Color.Black
        Chart.Series("Execution").Color = Color.ForestGreen
        Chart.Series("Execution").ChartType = SeriesChartType.StackedColumn
        Chart.Series("Execution").IsVisibleInLegend = True
        Chart.Series("Execution").LegendText = "Execução"
        Chart.Series.Add("Gathering")
        Chart.Series("Gathering").LabelForeColor = Color.Black
        Chart.Series("Gathering").Color = Color.DodgerBlue
        Chart.Series("Gathering").ChartType = SeriesChartType.StackedColumn
        Chart.Series("Gathering").IsVisibleInLegend = True
        Chart.Series("Gathering").LegendText = "Levantamento"
        'Chart.Series.Add("Idle")
        'Chart.Series("Idle").LabelForeColor = Color.Black
        'Chart.Series("Idle").Color = Color.Brown
        'Chart.Series("Idle").ChartType = SeriesChartType.StackedColumn
        'Chart.Series("Idle").IsVisibleInLegend = True
        'Chart.Series("Idle").LegendText = "Ocioso"
        If TableGathering.Rows.Count + TableExecution.Rows.Count > 0 AndAlso TableGathering.Rows.Count = TableExecution.Rows.Count Then
            TableMerged.Columns.Add("technician", GetType(String))
            TableMerged.Columns.Add("gatheringhours", GetType(Decimal))
            TableMerged.Columns.Add("executinghours", GetType(Decimal))
            For i = 0 To TableGathering.Rows.Count - 1
                TableMerged.Rows.Add({TableGathering.Rows(i).Item("technician").ToString, TableGathering.Rows(i).Item("hours"), TableExecution.Rows(i).Item("hours")})
            Next i
            For i = 0 To TableMerged.Rows.Count - 1
                If TableMerged.Rows(i).Item("executinghours") > 0 Then
                    Chart.Series("Execution").Points.AddXY(TableMerged.Rows(i).Item("technician").ToString, TableMerged.Rows(i).Item("executinghours"))
                End If
                If TableMerged.Rows(i).Item("gatheringhours") > 0 Then
                    Chart.Series("Gathering").Points.AddXY(TableMerged.Rows(i).Item("technician").ToString, TableMerged.Rows(i).Item("gatheringhours"))
                End If
                'Chart.Series("Idle").Points.AddXY(TableMerged.Rows(i).Item("technician").ToString, GetElapsedHoursInMonth() - TableMerged.Rows(i).Item("gatheringhours") - TableMerged.Rows(i).Item("executinghours"))
                If TableMerged.Rows(i).Item("executinghours") + TableMerged.Rows(i).Item("gatheringhours") > Highest Then
                    Highest = TableMerged.Rows(i).Item("executinghours") + TableMerged.Rows(i).Item("gatheringhours")
                End If
            Next i
            Chart.ChartAreas(0).AxisY.Maximum = Highest
            For Each s In Chart.Series
                s.Font = New Font("Century Gothic", 9.75, FontStyle.Bold)
                s.LabelForeColor = Color.White
                For Each dp In s.Points
                    If IsNumeric(dp.YValues(0)) Then
                        If dp.YValues(0) = 0 Then
                            dp.IsValueShownAsLabel = False
                        Else
                            dp.IsValueShownAsLabel = True
                            Time = TimeSpan.FromHours(dp.YValues(0))
                            dp.Label = String.Format("{0}:{1}h", Time.Days * 24 + Time.Hours, Time.Minutes.ToString.PadLeft(2, "0"))
                            '    TotalTime = TimeSpan.FromHours(GetElapsedHoursInMonth())
                            '    e.Text = String.Format("Total de Horas no mês: {1}:{2}h{0}Horas ocioso no mês: {3}:{4}h{0}Resultado: {5}% do tempo ocioso.",
                            '                               vbNewLine,
                            '                               TotalTime.Days * 24 + TotalTime.Hours,
                            '                               TotalTime.Minutes,
                            '                               Time.Days * 24 + Time.Hours,
                            '                               Time.Minutes,
                            '                               CInt((Time.TotalHours / TotalTime.TotalHours) * 100),
                            '                               dataPoint.YValues(0)
                            '                          )
                        End If
                    End If
                Next
            Next
            Chart.Titles.Clear()
            Chart.Titles.Add(New Title("PRODUTIVIDADE EM " & CbxMonth.Text & " DE " & CbxYear.Text, Docking.Top, New Font("Century Ghotic", 12, FontStyle.Bold), Color.FromArgb(40, 40, 40)))
        Else
            'Chart.Series("Idle").Points.Clear()
            Chart.Series("Gathering").Points.Clear()
            Chart.Series("Execution").Points.Clear()
            Chart.Titles.Clear()
            Chart.Titles.Add(New Title(EnumHelper.GetEnumDescription(EvaluationPanelInformation.Productivity), Docking.Top, New Font("Century Ghotic", 12, FontStyle.Bold), Color.FromArgb(40, 40, 40)))
        End If
    End Function
    Private Async Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        Dim YearIndex As Integer
        Dim MonthIndex As Integer
        Try
            Cursor = Cursors.WaitCursor
            YearIndex = CbxYear.SelectedIndex
            MonthIndex = CbxMonth.SelectedIndex
            Await RefreshData()
            If CbxYear.Items.Count > 0 Then
                If CbxYear.Items.Count >= YearIndex + 1 Then
                    CbxYear.SelectedIndex = YearIndex
                Else
                    CbxYear.SelectedIndex = 0
                End If
            End If
            If CbxMonth.Items.Count > 0 Then
                If CbxMonth.Items.Count >= MonthIndex + 1 Then
                    CbxMonth.SelectedIndex = MonthIndex
                Else
                    CbxMonth.SelectedIndex = CbxMonth.Items.Count - 1
                End If
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO EV011", "Ocorreu um erro ao carregar os paineis.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Async Function FillChartVisits() As Task
        Dim Session = Locator.GetInstance(Of Session)
        Dim Db As LocalDB = Locator.GetInstance(Of LocalDB)
        Dim Result As QueryResult
        Dim TableResult As New DataTable
        Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
            Await Db.ExecuteRawQueryAsync(My.Resources.SetBrazilianDatabaseMonthNames)
            Result = Await Db.ExecuteRawQueryAsync(My.Resources.EvaluationManagementPanelVisitsChartSelect, New Dictionary(Of String, Object) From {
                {"@year", CbxYear.Text}
            })
            TableResult = Result.Table
            Scope.Complete()
        End Using
        Chart.Series.Clear()
        Chart.ChartAreas(0).AxisY.Maximum = Double.NaN
        Chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart.Series.Add("Visit")
        Chart.Series("Visit").Color = Color.FromArgb(255, 128, 0)
        Chart.Series("Visit").LabelForeColor = Color.FromArgb(210, 105, 0)
        Chart.Series("Visit").ChartType = SeriesChartType.Column
        Chart.Series("Visit").IsValueShownAsLabel = True
        Chart.Series("Visit").Font = New Font(Chart.Series(0).Font.Name, 12, FontStyle.Bold)
        Chart.Series("Visit").IsVisibleInLegend = False
        If TableResult.Rows.Count > 0 Then
            For Each Row As DataRow In TableResult.Rows
                Chart.Series("Visit").Points.AddXY(Row.Item("MonthName").ToString.ToUpper, Row.Item("CountEvaluation"))
            Next Row
            Chart.Titles.Clear()
            Chart.Titles.Add(New Title("VISITAS EM " & CbxYear.Text, Docking.Top, New Font("Century Ghotic", 12, FontStyle.Bold), Color.FromArgb(40, 40, 40)))
        Else
            Chart.Series("Visit").Points.Clear()
            Chart.Titles.Clear()
            Chart.Titles.Add(New Title(EnumHelper.GetEnumDescription(EvaluationPanelInformation.Visits), Docking.Top, New Font("Century Ghotic", 12, FontStyle.Bold), Color.FromArgb(40, 40, 40)))
        End If
    End Function
    Private Sub Chart_GetToolTipText(sender As Object, e As ToolTipEventArgs) Handles Chart.GetToolTipText
        Dim Time As TimeSpan
        Dim TotalTime As TimeSpan
        Select Case e.HitTestResult.ChartElementType
            Case ChartElementType.DataPoint
                Dim dataPoint = e.HitTestResult.Series.Points(e.HitTestResult.PointIndex)
                Select Case dataPoint.LegendText
                    Case "Levantamento"
                        Time = TimeSpan.FromHours(dataPoint.YValues(0))
                        TotalTime = TimeSpan.FromHours(GetElapsedHoursInMonth())
                        e.Text = String.Format("Total de Horas no mês: {1}:{2}h{0}Horas fazendo levantamento no mês: {3}:{4}h{0}Resultado: {5}% do tempo fazendo levantamento.",
                                                   vbNewLine,
                                                   TotalTime.Days * 24 + TotalTime.Hours,
                                                   TotalTime.Minutes,
                                                   Time.Days * 24 + Time.Hours,
                                                   Time.Minutes,
                                                   CInt((Time.TotalHours / TotalTime.TotalHours) * 100),
                                                   dataPoint.YValues(0)
                                              )
                    Case "Execução"
                        Time = TimeSpan.FromHours(dataPoint.YValues(0))
                        TotalTime = TimeSpan.FromHours(GetElapsedHoursInMonth())
                        e.Text = String.Format("Total de Horas no mês: {1}:{2}h{0}Horas executando serviço no mês: {3}:{4}h{0}Resultado: {5}% do tempo executando serviço.",
                                                   vbNewLine,
                                                   TotalTime.Days * 24 + TotalTime.Hours,
                                                   TotalTime.Minutes,
                                                   Time.Days * 24 + Time.Hours,
                                                   Time.Minutes,
                                                   CInt((Time.TotalHours / TotalTime.TotalHours) * 100),
                                                   dataPoint.YValues(0)
                                              )

                End Select
        End Select
    End Sub

End Class
