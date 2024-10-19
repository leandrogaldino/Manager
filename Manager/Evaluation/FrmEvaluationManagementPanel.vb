Imports MySql.Data.MySqlClient
Imports ControlLibrary
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Globalization
Imports ControlLibrary.Utility
Imports ManagerCore

Public Class FrmEvaluationManagementPanel
    Private _InDayDetail As New UcEvaluationCardDetail
    Private _ToOverdueDetail As New UcEvaluationCardDetail
    Private _OverDueDetail As New UcEvaluationCardDetail
    Private _UnitOverdueDetail As New UcEvaluationCardDetail
    Private _NeverVisitDetail As New UcEvaluationCardDetail
    Private _ToVisitDetail As New UcEvaluationCardDetail
    Private _TotalDetail As New UcEvaluationCardDetail
    Private Sub FrmEvaluationManagementPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Session = Locator.GetInstance(Of Session)
        CbxInformation.Items.AddRange(GetEnumDescriptions(GetType(EvaluationPanelInformation)).ToArray)
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
        Tip.SetToolTip(LblInDayValue, "Compressores sem itens vencidos.")
        Tip.SetToolTip(LblToOverdueValue, String.Format("Compressores com itens vencendo em até {0} dias", Session.Setting.General.Evaluation.DaysToAlertMaintenance))
        Tip.SetToolTip(LblOverdueValue, "Compressores com itens vencidos")
        Tip.SetToolTip(LblOverdueUnit, "Compressores com manutenção da unidade compressora vencida.")
        Tip.SetToolTip(LblNeverVisitedValue, "Compressores sem avaliação lançada e/ou aprovada.")
        Tip.SetToolTip(LblToVisitValue, String.Format("Compressores com avaliação lançada mas não visitados há mais de {0} dias.", Session.Setting.General.Evaluation.DaysToAlertVisit))
        Tip.SetToolTip(LblTotalValue, "Todos os compressores cadastrados.")
        Try
            FillComboBoxYear()
            FillChartVisits()
            FillCards()
        Catch ex As Exception
            CMessageBox.Show("ERRO EV010", "Ocorreu um erro ao carregar os paineis.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Parent IsNot Nothing Then
            AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub FrmMain_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If Parent IsNot Nothing AndAlso Parent.FindForm IsNot Nothing Then
            Height = Parent.FindForm.Height - 196
            Width = Parent.FindForm.Width - 24
        End If
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        Dim YearIndex As Integer
        Dim MonthIndex As Integer
        Try
            Cursor = Cursors.WaitCursor
            YearIndex = CbxYear.SelectedIndex
            MonthIndex = CbxMonth.SelectedIndex
            FillCards()
            FillComboBoxYear()
            FillComboBoxMonth()
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
            If CbxInformation.SelectedIndex = CbxInformation.FindStringExact(EvaluationPanelInformation.Visits) Then
                FillChartVisits()
            ElseIf CbxInformation.SelectedIndex = CbxInformation.FindStringExact(EvaluationPanelInformation.Productivity) Then
                FillChartProductivity()
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO EV011", "Ocorreu um erro ao carregar os paineis.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub FillCards()
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Dim TableInDay As New DataTable
        Dim TableToOverdue As New DataTable
        Dim TableOverdue As New DataTable
        Dim TableUnitOverdue As New DataTable
        Dim TableNeverVisited As New DataTable
        Dim TableToVisit As New DataTable
        Dim TableTotal As New DataTable
        Dim Rows As List(Of DataRow)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementFilter, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@personid", "%")
                    Cmd.Parameters.AddWithValue("@persondocument", "%")
                    Cmd.Parameters.AddWithValue("@personname", "%")
                    Cmd.Parameters.AddWithValue("@zipcode", "%")
                    Cmd.Parameters.AddWithValue("@address", "%")
                    Cmd.Parameters.AddWithValue("@city", "%")
                    Cmd.Parameters.AddWithValue("@state", "%")
                    Cmd.Parameters.AddWithValue("@compressorname", "%")
                    Cmd.Parameters.AddWithValue("@serialnumber", "%")
                    Cmd.Parameters.AddWithValue("@patrimony", "%")
                    Cmd.Parameters.AddWithValue("@sector", "%")
                    Cmd.Parameters.AddWithValue("@route", "%")
                    Cmd.Parameters.AddWithValue("@nextexchangei", "0000-01-01")
                    Cmd.Parameters.AddWithValue("@nextexchangef", "9999-12-31")
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableResult)
                    End Using
                End Using
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelNoVisited, Con)
                    Cmd.Transaction = Tra
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableNeverVisited)
                    End Using
                End Using
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelCustomerToVisit, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@days", Session.Setting.General.Evaluation.DaysToAlertVisit)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableToVisit)
                    End Using
                End Using
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelUnitOverdue, Con)
                    Cmd.Transaction = Tra
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableUnitOverdue)
                    End Using
                End Using
                Tra.Commit()
            End Using
        End Using
        If TableResult.Rows.Count > 0 Then
            TableInDay = TableResult.Clone()
            Rows = TableResult.Rows.Cast(Of DataRow).Where(
                        Function(x) x.Item("nextexchange") IsNot DBNull.Value AndAlso
                        CDate(x.Item("nextexchange")) > Today.AddDays(Session.Setting.General.Evaluation.DaysToAlertMaintenance)).ToList
            Rows.ForEach(Sub(x) TableInDay.ImportRow(x))
            LblInDayValue.Text = TableInDay.Rows.Count
            _InDayDetail.DgvCardDetail.DataSource = TableInDay
            _InDayDetail.DgvCardDetail.Columns("evaluation").Visible = False
            _InDayDetail.DgvCardDetail.Columns("customer").HeaderText = "Cliente"
            _InDayDetail.DgvCardDetail.Columns("customer").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _InDayDetail.DgvCardDetail.Columns("city").HeaderText = "Cidade"
            _InDayDetail.DgvCardDetail.Columns("city").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _InDayDetail.DgvCardDetail.Columns("compressor").HeaderText = "Compressor"
            _InDayDetail.DgvCardDetail.Columns("compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _InDayDetail.DgvCardDetail.Columns("serialnumber").HeaderText = "Nº Série"
            _InDayDetail.DgvCardDetail.Columns("serialnumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _InDayDetail.DgvCardDetail.Columns("workedhourexchangeday").Visible = False
            _InDayDetail.DgvCardDetail.Columns("elapseddayexchangeday").Visible = False
            _InDayDetail.DgvCardDetail.Columns("nextexchange").Visible = False
            TableToOverdue = TableResult.Clone()
            Rows = TableResult.AsEnumerable().Where(
                        Function(x) x.Item("nextexchange") IsNot DBNull.Value AndAlso
                        (CDate(x.Item("nextexchange")) >= Today And CDate(x.Item("nextexchange")) <= Today.AddDays(Session.Setting.General.Evaluation.DaysToAlertMaintenance))).ToList
            Rows.ForEach(Sub(x) TableToOverdue.ImportRow(x))
            LblToOverdueValue.Text = TableToOverdue.Rows.Count
            _ToOverdueDetail.DgvCardDetail.DataSource = TableToOverdue
            _ToOverdueDetail.DgvCardDetail.Columns("evaluation").Visible = False
            _ToOverdueDetail.DgvCardDetail.Columns("customer").HeaderText = "Cliente"
            _ToOverdueDetail.DgvCardDetail.Columns("customer").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _ToOverdueDetail.DgvCardDetail.Columns("city").HeaderText = "Cidade"
            _ToOverdueDetail.DgvCardDetail.Columns("city").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _ToOverdueDetail.DgvCardDetail.Columns("compressor").HeaderText = "Compressor"
            _ToOverdueDetail.DgvCardDetail.Columns("compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _ToOverdueDetail.DgvCardDetail.Columns("serialnumber").HeaderText = "Nº Série"
            _ToOverdueDetail.DgvCardDetail.Columns("serialnumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _ToOverdueDetail.DgvCardDetail.Columns("workedhourexchangeday").Visible = False
            _ToOverdueDetail.DgvCardDetail.Columns("elapseddayexchangeday").Visible = False
            _ToOverdueDetail.DgvCardDetail.Columns("nextexchange").HeaderText = "Próx. Troca"
            _ToOverdueDetail.DgvCardDetail.Columns("nextexchange").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            TableOverdue = TableResult.Clone()
            Rows = TableResult.AsEnumerable().Where(
                        Function(x) x.Item("nextexchange") IsNot DBNull.Value AndAlso
                        CDate(x.Item("nextexchange")) < Today).ToList
            Rows.ForEach(Sub(x) TableOverdue.ImportRow(x))
            LblOverdueValue.Text = TableOverdue.Rows.Count
            _OverDueDetail.DgvCardDetail.DataSource = TableOverdue
            _OverDueDetail.DgvCardDetail.Columns("evaluation").Visible = False
            _OverDueDetail.DgvCardDetail.Columns("customer").HeaderText = "Cliente"
            _OverDueDetail.DgvCardDetail.Columns("customer").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _OverDueDetail.DgvCardDetail.Columns("city").HeaderText = "Cidade"
            _OverDueDetail.DgvCardDetail.Columns("city").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _OverDueDetail.DgvCardDetail.Columns("compressor").HeaderText = "Compressor"
            _OverDueDetail.DgvCardDetail.Columns("compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _OverDueDetail.DgvCardDetail.Columns("serialnumber").HeaderText = "Nº Série"
            _OverDueDetail.DgvCardDetail.Columns("serialnumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _OverDueDetail.DgvCardDetail.Columns("workedhourexchangeday").Visible = False
            _OverDueDetail.DgvCardDetail.Columns("elapseddayexchangeday").Visible = False
            _OverDueDetail.DgvCardDetail.Columns("nextexchange").HeaderText = "Próx. Troca"
            _OverDueDetail.DgvCardDetail.Columns("nextexchange").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Else
            LblInDayValue.Text = "-"
            LblToOverdueValue.Text = "-"
            LblOverdueValue.Text = "-"
        End If
        If TableUnitOverdue.Rows.Count > 0 Then
            LblOverdueUnitValue.Text = TableUnitOverdue.Rows.Count
            _UnitOverdueDetail.DgvCardDetail.DataSource = TableUnitOverdue
            _UnitOverdueDetail.DgvCardDetail.Columns("personid").Visible = False
            _UnitOverdueDetail.DgvCardDetail.Columns("customer").HeaderText = "Cliente"
            _UnitOverdueDetail.DgvCardDetail.Columns("customer").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _UnitOverdueDetail.DgvCardDetail.Columns("city").HeaderText = "Cidade"
            _UnitOverdueDetail.DgvCardDetail.Columns("city").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _UnitOverdueDetail.DgvCardDetail.Columns("compressor").HeaderText = "Compressor"
            _UnitOverdueDetail.DgvCardDetail.Columns("compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _UnitOverdueDetail.DgvCardDetail.Columns("serialnumber").HeaderText = "Nº Série"
            _UnitOverdueDetail.DgvCardDetail.Columns("serialnumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _UnitOverdueDetail.DgvCardDetail.Columns("horimeter").HeaderText = "Horímetro"
            _UnitOverdueDetail.DgvCardDetail.Columns("horimeter").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _UnitOverdueDetail.DgvCardDetail.Columns("nextexchange").HeaderText = "Próx. Reconstrução"
            _UnitOverdueDetail.DgvCardDetail.Columns("nextexchange").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Else
            LblOverdueUnitValue.Text = "-"
        End If
        If TableNeverVisited.Rows.Count > 0 Then
            LblNeverVisitedValue.Text = TableNeverVisited.Rows.Count
            _NeverVisitDetail.DgvCardDetail.DataSource = TableNeverVisited
            _NeverVisitDetail.DgvCardDetail.Columns("personid").Visible = False
            _NeverVisitDetail.DgvCardDetail.Columns("customer").HeaderText = "Cliente"
            _NeverVisitDetail.DgvCardDetail.Columns("customer").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _NeverVisitDetail.DgvCardDetail.Columns("city").HeaderText = "Cidade"
            _NeverVisitDetail.DgvCardDetail.Columns("city").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _NeverVisitDetail.DgvCardDetail.Columns("compressor").HeaderText = "Compressor"
            _NeverVisitDetail.DgvCardDetail.Columns("compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _NeverVisitDetail.DgvCardDetail.Columns("serialnumber").HeaderText = "Nº Série"
            _NeverVisitDetail.DgvCardDetail.Columns("serialnumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _NeverVisitDetail.DgvCardDetail.Columns("hasevaluation").Visible = False
        Else
            LblNeverVisitedValue.Text = "-"
        End If
        If TableToVisit.Rows.Count > 0 Then
            LblToVisitValue.Text = TableToVisit.Rows.Count
            _ToVisitDetail.DgvCardDetail.DataSource = TableToVisit
            _ToVisitDetail.DgvCardDetail.Columns("evaluationid").Visible = False
            _ToVisitDetail.DgvCardDetail.Columns("personcompressorid").Visible = False
            _ToVisitDetail.DgvCardDetail.Columns("customer").HeaderText = "Cliente"
            _ToVisitDetail.DgvCardDetail.Columns("customer").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _ToVisitDetail.DgvCardDetail.Columns("city").HeaderText = "Cidade"
            _ToVisitDetail.DgvCardDetail.Columns("city").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _ToVisitDetail.DgvCardDetail.Columns("compressor").HeaderText = "Compressor"
            _ToVisitDetail.DgvCardDetail.Columns("compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _ToVisitDetail.DgvCardDetail.Columns("serialnumber").HeaderText = "Nº Série"
            _ToVisitDetail.DgvCardDetail.Columns("serialnumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _ToVisitDetail.DgvCardDetail.Columns("evaluationdate").HeaderText = "Ult. Visita"
            _ToVisitDetail.DgvCardDetail.Columns("evaluationdate").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Else
            LblToVisitValue.Text = "-"
        End If
        TableTotal.Columns.Add("customer", GetType(String))
        TableTotal.Columns.Add("city", GetType(String))
        TableTotal.Columns.Add("compressor", GetType(String))
        TableTotal.Columns.Add("serialnumber", GetType(String))
        If TableInDay.Rows.Count + TableToOverdue.Rows.Count + TableOverdue.Rows.Count + TableNeverVisited.Rows.Count > 0 Then
            LblTotalValue.Text = TableInDay.Rows.Count + TableToOverdue.Rows.Count + TableOverdue.Rows.Count + TableNeverVisited.Rows.Count
            For Each Row As DataGridViewRow In _InDayDetail.DgvCardDetail.Rows
                TableTotal.Rows.Add({Row.Cells("customer").Value, Row.Cells("city").Value, Row.Cells("compressor").Value, Row.Cells("serialnumber").Value})
            Next Row
            For Each Row As DataGridViewRow In _ToOverdueDetail.DgvCardDetail.Rows
                TableTotal.Rows.Add({Row.Cells("customer").Value, Row.Cells("city").Value, Row.Cells("compressor").Value, Row.Cells("serialnumber").Value})
            Next Row
            For Each Row As DataGridViewRow In _OverDueDetail.DgvCardDetail.Rows
                TableTotal.Rows.Add({Row.Cells("customer").Value, Row.Cells("city").Value, Row.Cells("compressor").Value, Row.Cells("serialnumber").Value})
            Next Row
            For Each Row As DataGridViewRow In _NeverVisitDetail.DgvCardDetail.Rows
                TableTotal.Rows.Add({Row.Cells("customer").Value, Row.Cells("city").Value, Row.Cells("compressor").Value, Row.Cells("serialnumber").Value})
            Next Row
            TableTotal.DefaultView.Sort = "customer ASC"
            _TotalDetail.DgvCardDetail.DataSource = TableTotal
            _TotalDetail.DgvCardDetail.Columns("customer").HeaderText = "Cliente"
            _TotalDetail.DgvCardDetail.Columns("customer").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            _TotalDetail.DgvCardDetail.Columns("city").HeaderText = "Cidade"
            _TotalDetail.DgvCardDetail.Columns("city").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _TotalDetail.DgvCardDetail.Columns("compressor").HeaderText = "Compressor"
            _TotalDetail.DgvCardDetail.Columns("compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            _TotalDetail.DgvCardDetail.Columns("serialnumber").HeaderText = "Nº Série"
            _TotalDetail.DgvCardDetail.Columns("serialnumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Else
            LblTotalValue.Text = "-"
        End If
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
    Private Sub CbxInformation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxInformation.SelectedIndexChanged
        If CbxInformation.SelectedIndex = CInt(EvaluationPanelInformation.Visits) Then
            LblMonth.Visible = False
            CbxMonth.Visible = False
        Else
            LblMonth.Visible = True
            CbxMonth.Visible = True
        End If
        LoadData()
    End Sub
    Private Sub CbxYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxYear.SelectedIndexChanged
        FillComboBoxMonth()
        LoadData()
    End Sub
    Private Sub FillComboBoxYear()
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Dim Result As List(Of String)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelYearSelect, Con)
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                End Using
            End Using
        End Using
        If TableResult.Rows.Count > 0 Then
            Result = TableResult.AsEnumerable().Select(Of String)(Function(x) x.Item("evaluationyear")).Distinct.ToList
            CbxYear.DataSource = Result
            CbxYear.SelectedIndex = 0
        End If
    End Sub
    Private Sub FillComboBoxMonth()
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Dim Result As List(Of String)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.SetBrazilianDatabaseMonthNames, Con)
                    Cmd.Transaction = Tra
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelMonthSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@year", CbxYear.Text)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableResult)
                    End Using
                End Using
                Tra.Commit()
            End Using
        End Using
        If TableResult.Rows.Count > 0 Then
            Result = TableResult.AsEnumerable().Select(Of String)(Function(x) x.Item("evaluationmonth")).Distinct.ToList
            CbxMonth.DataSource = Result
            CbxMonth.SelectedIndex = 0
        End If
    End Sub
    Private Sub LoadData()
        If CbxInformation.SelectedIndex = EvaluationPanelInformation.Visits Then
            If CbxYear.Text <> Nothing Then
                Try
                    Cursor = Cursors.WaitCursor
                    FillChartVisits()
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
                    FillChartProductivity()
                Catch ex As Exception
                    CMessageBox.Show("ERRO EV022", "Ocorreu um erro ao carregar os paineis.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                Finally
                    Cursor = Cursors.Default
                End Try
            End If
        End If
    End Sub
    Private Function GetElapsedHoursInMonth() As Decimal
        Const AverageHourPerDay As Decimal = 6.285
        If CbxMonth.Text = New DateTimeFormatInfo().GetMonthName(Today.Month) Then
            Return Today.Day * AverageHourPerDay
        Else
            Return Date.DaysInMonth(CbxYear.Text, Date.ParseExact(CbxMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month) * AverageHourPerDay
        End If

    End Function
    Private Sub FillChartProductivity()
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableGathering As New DataTable
        Dim TableExecution As New DataTable
        Dim TableMerged As New DataTable
        Dim Highest As Decimal
        Dim Time As TimeSpan
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.SetBrazilianDatabaseMonthNames, Con)
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelFillChartProductivityChartSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@evaluationtypeid", EvaluationType.Gathering)
                    Cmd.Parameters.AddWithValue("@month", CbxMonth.Text)
                    Cmd.Parameters.AddWithValue("@year", CbxYear.Text)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableGathering)
                    End Using
                End Using
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelFillChartProductivityChartSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@evaluationtypeid", EvaluationType.Execution)
                    Cmd.Parameters.AddWithValue("@month", CbxMonth.Text)
                    Cmd.Parameters.AddWithValue("@year", CbxYear.Text)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableExecution)
                    End Using
                End Using
                Tra.Commit()
            End Using
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
            Chart.Titles.Add(New Title(GetEnumDescription(EvaluationPanelInformation.Productivity), Docking.Top, New Font("Century Ghotic", 12, FontStyle.Bold), Color.FromArgb(40, 40, 40)))
        End If
    End Sub
    Private Sub FillChartVisits()
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.SetBrazilianDatabaseMonthNames, Con)
                    Cmd.ExecuteNonQuery()
                End Using
                Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementPanelVisitsChartSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@year", CbxYear.Text)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Adp.Fill(TableResult)
                    End Using
                End Using
                Tra.Commit()
            End Using
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
            Chart.Titles.Add(New Title(GetEnumDescription(EvaluationPanelInformation.Visits), Docking.Top, New Font("Century Ghotic", 12, FontStyle.Bold), Color.FromArgb(40, 40, 40)))
        End If
    End Sub
    Private Sub CbxMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMonth.SelectedIndexChanged
        LoadData()
    End Sub
    'Private Sub Chart_GetToolTipText(sender As Object, e As ToolTipEventArgs) Handles Chart.GetToolTipText
    '    Dim Time As TimeSpan
    '    Dim TotalTime As TimeSpan
    '    Select Case e.HitTestResult.ChartElementType
    '        Case ChartElementType.DataPoint
    '            Dim dataPoint = e.HitTestResult.Series.Points(e.HitTestResult.PointIndex)
    '            Select Case dataPoint.LegendText
    '                'Case "Ocioso"
    '                '    Time = TimeSpan.FromHours(dataPoint.YValues(0))
    '                '    TotalTime = TimeSpan.FromHours(GetElapsedHoursInMonth())
    '                '    e.Text = String.Format("Total de Horas no mês: {1}:{2}h{0}Horas ocioso no mês: {3}:{4}h{0}Resultado: {5}% do tempo ocioso.",
    '                '                               vbNewLine,
    '                '                               TotalTime.Days * 24 + TotalTime.Hours,
    '                '                               TotalTime.Minutes,
    '                '                               Time.Days * 24 + Time.Hours,
    '                '                               Time.Minutes,
    '                '                               CInt((Time.TotalHours / TotalTime.TotalHours) * 100),
    '                '                               dataPoint.YValues(0)
    '                '                          )
    '                Case "Levantamento"
    '                    Time = TimeSpan.FromHours(dataPoint.YValues(0))
    '                    TotalTime = TimeSpan.FromHours(GetElapsedHoursInMonth())
    '                    e.Text = String.Format("Total de Horas no mês: {1}:{2}h{0}Horas fazendo levantamento no mês: {3}:{4}h{0}Resultado: {5}% do tempo fazendo levantamento.",
    '                                               vbNewLine,
    '                                               TotalTime.Days * 24 + TotalTime.Hours,
    '                                               TotalTime.Minutes,
    '                                               Time.Days * 24 + Time.Hours,
    '                                               Time.Minutes,
    '                                               CInt((Time.TotalHours / TotalTime.TotalHours) * 100),
    '                                               dataPoint.YValues(0)
    '                                          )
    '                Case "Execução"
    '                    Time = TimeSpan.FromHours(dataPoint.YValues(0))
    '                    TotalTime = TimeSpan.FromHours(GetElapsedHoursInMonth())
    '                    e.Text = String.Format("Total de Horas no mês: {1}:{2}h{0}Horas executando serviço no mês: {3}:{4}h{0}Resultado: {5}% do tempo executando serviço.",
    '                                               vbNewLine,
    '                                               TotalTime.Days * 24 + TotalTime.Hours,
    '                                               TotalTime.Minutes,
    '                                               Time.Days * 24 + Time.Hours,
    '                                               Time.Minutes,
    '                                               CInt((Time.TotalHours / TotalTime.TotalHours) * 100),
    '                                               dataPoint.YValues(0)
    '                                          )

    '            End Select
    '    End Select
    'End Sub
End Class