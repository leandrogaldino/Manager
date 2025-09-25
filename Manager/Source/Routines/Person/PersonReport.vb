Imports ClosedXML
Imports Syncfusion.ExcelToPdfConverter
Imports System.IO
Imports System.Xml
Imports MySql.Data.MySqlClient
Imports ManagerCore
Imports ClosedXML.Excel
Imports System.Windows.Forms.DataVisualization.Charting
Imports ControlLibrary

Public Class PersonReport
    Public Shared Function ProcessMaintenancePlan(DgvCompressor As DataGridView, Person As Person, ShowTechnicalAdvice As Boolean, ShowMDHT As Boolean) As ReportResult
        Dim Session = Locator.GetInstance(Of Session)
        Dim WbReport As New XLWorkbook
        Dim WsReport As IXLWorksheet = WbReport.Worksheets.Add("Plano De Manutenção")
        Dim Converter As ExcelToPdfConverter
        Dim ReportingEvaluation As New Evaluation
        Dim SettingsDocument As XmlDocument
        Dim TableWorkedHour As DataTable
        Dim TableElapsedDay As DataTable
        Dim CompressorCount As Integer = 1
        Dim Row As Integer = 5
        Dim Result As New ReportResult
        Dim LastEvaluationID As Long
        Dim Logo As Drawings.IXLPicture
        Dim ChartPicture As Drawings.IXLPicture
        Dim CompressorsDataChart As New List(Of Tuple(Of String, Decimal))
        Dim Series As Series
        Dim ChartArea As ChartArea
        Dim ChartWidth As Integer = 650
        Dim ChartHeight As Integer = 350
        Dim Chart As Chart
        Dim ChartImage As Bitmap
        Dim ChartImageName As String
        Dim NextChange As Date
        Dim SelectedRows As List(Of DataGridViewRow)
        WsReport.ShowGridLines = False
        WsReport.Rows.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        WsReport.Rows.Style.NumberFormat.Format = "@"
        WsReport.Style.Font.FontName = "Century Gothic"
        WsReport.Style.Font.FontSize = 10
        WsReport.Columns(1, 1).Width = 3
        WsReport.Columns(2, 2).Width = 40
        WsReport.Columns(3, 3).Width = 16
        WsReport.Columns(4, 4).Width = 16
        WsReport.Columns(5, 5).Width = 16
        If File.Exists(Session.Setting.Company.LogoLocation) Then
            Logo = WsReport.AddPicture(New MemoryStream(File.ReadAllBytes(Session.Setting.Company.LogoLocation)))
            Logo.MoveTo(WsReport.Cell("A1"), New Point(0, 5))
            Logo.WithSize(156, 57)
        End If
        WsReport.Range(1, 1, 2, 5).Merge()
        WsReport.Range(1, 1, 2, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        WsReport.Range(1, 1, 2, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(1, 1, 2, 5).Style.Font.Bold = True
        WsReport.Range(1, 1, 2, 5).Style.Font.FontSize = 12
        WsReport.Range(1, 1, 2, 5).Value = "PLANO DE MANUTENÇÃO PREVENTIVA"
        WsReport.Range(3, 1, 3, 5).Merge()
        WsReport.Range(3, 1, 3, 5).Style.Border.BottomBorder = XLBorderStyleValues.Medium
        WsReport.Range(3, 1, 3, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        WsReport.Range(3, 1, 3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(3, 1, 3, 5).Style.Font.Bold = True
        WsReport.Range(3, 1, 3, 5).Style.Font.FontSize = 12
        WsReport.Range(3, 1, 3, 5).Value = Person.ShortName
        WsReport.Rows(1, 1).Height = 20
        WsReport.Rows(2, 2).Height = 20
        WsReport.Rows(3, 3).Height = 20
        WsReport.Rows(4, 4).Height = 290
        SelectedRows = DgvCompressor.Rows.Cast(Of DataGridViewRow).Where(Function(x) x.Cells("X").Value = True).ToList()
        For Each DgvRow As DataGridViewRow In SelectedRows
            LastEvaluationID = Evaluation.GetLastEvaluationID(DgvRow.Cells("ID").Value)
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                    Using Cmd As New MySqlCommand(My.Resources.EvaluationLastEvaluationSelect, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@personcompressorid", DgvRow.Cells("ID").Value)
                        LastEvaluationID = Cmd.ExecuteScalar()
                    End Using
                    Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementControlledSellableFilter, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("evaluationid", LastEvaluationID)
                        Cmd.Parameters.AddWithValue("controltypeid", CompressorSellableControlType.WorkedHour)
                        Using Adp As New MySqlDataAdapter(Cmd)
                            TableWorkedHour = New DataTable
                            Adp.Fill(TableWorkedHour)
                        End Using
                    End Using
                    Using Cmd As New MySqlCommand(My.Resources.EvaluationManagementControlledSellableFilter, Con)
                        Using Adp As New MySqlDataAdapter(Cmd)
                            Cmd.Transaction = Tra
                            Cmd.Parameters.AddWithValue("evaluationid", LastEvaluationID)
                            Cmd.Parameters.AddWithValue("controltypeid", CompressorSellableControlType.ElapsedDay)
                            TableElapsedDay = New DataTable
                            Adp.Fill(TableElapsedDay)
                        End Using
                    End Using
                    Tra.Commit()
                End Using
            End Using
            If TableWorkedHour.Rows.Cast(Of DataRow).Count(Function(x) x.Item("nextexchange").ToString <> Nothing) + TableElapsedDay.Rows.Cast(Of DataRow).Count(Function(x) x.Item("nextexchange").ToString <> Nothing) > 0 Then
                ReportingEvaluation = New Evaluation().Load(LastEvaluationID, False)
                CompressorsDataChart.Add(New Tuple(Of String, Decimal)($"{ReportingEvaluation.Compressor.CompressorName} {If(Not String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), $"NS {ReportingEvaluation.Compressor.SerialNumber}", "")}", ReportingEvaluation.AverageWorkLoad))
                If Not String.IsNullOrEmpty(ReportingEvaluation.Document.CurrentFile) AndAlso File.Exists(ReportingEvaluation.Document.CurrentFile) Then
                    Result.Attachments.Add(New ReportResult.ReportAttachment(ReportingEvaluation.Document.CurrentFile, ReportingEvaluation.Compressor.ToString & ".pdf"))
                End If
                WsReport.Rows(Row, Row).Height = 20
                'NUMERO DO COMPRESSOR
                WsReport.Range(Row, 1, Row, 1).Style.NumberFormat.NumberFormatId = 1
                WsReport.Range(Row, 1, Row, 1).Value = CompressorCount
                WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
                WsReport.Range(Row, 1, Row, 1).Style.Font.FontSize = 12
                WsReport.Range(Row, 1, Row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                'CABEÇALHO "COMPRESSOR"
                WsReport.Range(Row, 2, Row, 2).Value = "COMPRESSOR"
                WsReport.Range(Row, 2, Row, 2).Style.Font.Bold = True
                WsReport.Range(Row, 2, Row, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 2, Row, 2).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 2, Row, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 2, Row, 2).Style.Border.TopBorder = XLBorderStyleValues.Thin
                'CABEÇALHO "VISITA"
                WsReport.Range(Row, 3, Row, 3).Value = "VISITA"
                WsReport.Range(Row, 3, Row, 3).Style.Font.Bold = True
                WsReport.Range(Row, 3, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 3, Row, 3).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 3, Row, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin
                'CABEÇALHO "CARGA"
                WsReport.Range(Row, 4, Row, 4).Value = If(ShowMDHT, "CARGA", Nothing)
                WsReport.Range(Row, 4, Row, 4).Style.Font.Bold = True
                WsReport.Range(Row, 4, Row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 4, Row, 4).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin
                'CABEÇALHO "HORIMETRO"
                WsReport.Range(Row, 5, Row, 5).Value = "HORÍMETRO"
                WsReport.Range(Row, 5, Row, 5).Style.Font.Bold = True
                WsReport.Range(Row, 5, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 5, Row, 5).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 5, Row, 5).Style.Border.TopBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 5, Row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin
                Row += 1
                WsReport.Rows(Row, Row).Height = 20
                'VALOR DE COMPRESSOR
                WsReport.Range(Row, 2, Row, 2).Value = String.Format("{0} {1} {2} {3}", ReportingEvaluation.Compressor.CompressorName, If(String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), Nothing, "NS: " & ReportingEvaluation.Compressor.SerialNumber), If(String.IsNullOrEmpty(ReportingEvaluation.Compressor.Patrimony), Nothing, "PAT: " & ReportingEvaluation.Compressor.Patrimony), If(String.IsNullOrEmpty(ReportingEvaluation.Compressor.Sector), Nothing, "- " & ReportingEvaluation.Compressor.Sector))
                WsReport.Range(Row, 2, Row, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorderColor = XLColor.Black
                WsReport.Range(Row, 2, Row, 2).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 2, Row, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                'VALOR DE VISITA
                WsReport.Range(Row, 3, Row, 3).Value = ReportingEvaluation.EvaluationDate.ToString("dd/MM/yyyy")
                WsReport.Range(Row, 3, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorderColor = XLColor.Black
                WsReport.Range(Row, 3, Row, 3).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                'VALOR DE CARGA
                If ShowMDHT Then
                    WsReport.Range(Row, 4, Row, 4).Style.NumberFormat.NumberFormatId = 2
                    WsReport.Range(Row, 4, Row, 4).Value = If(ShowMDHT, ReportingEvaluation.AverageWorkLoad, Nothing)
                End If
                WsReport.Range(Row, 4, Row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorderColor = XLColor.Black
                WsReport.Range(Row, 4, Row, 4).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                'VALOR DE HORÍMETRO
                WsReport.Range(Row, 5, Row, 5).Style.NumberFormat.NumberFormatId = 3
                WsReport.Range(Row, 5, Row, 5).Value = ReportingEvaluation.Horimeter
                WsReport.Range(Row, 5, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorderColor = XLColor.Black
                WsReport.Range(Row, 5, Row, 5).Style.Fill.BackgroundColor = XLColor.Gainsboro
                WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 5, Row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin
                Row += 1
                WsReport.Rows(Row, Row).Height = 20
                'BORDAS
                WsReport.Range(Row, 2, Row, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorderColor = XLColor.DimGray
                'CABEÇALHO HORAS ATUAL
                WsReport.Range(Row, 3, Row, 3).Value = "HORAS ATUAL"
                WsReport.Range(Row, 3, Row, 3).Style.Font.Bold = True
                WsReport.Range(Row, 3, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorderColor = XLColor.DimGray
                'CABEÇALHO ULTIMA TROCA
                WsReport.Range(Row, 4, Row, 4).Value = "ÚLTIMA TROCA"
                WsReport.Range(Row, 4, Row, 4).Style.Font.Bold = True
                WsReport.Range(Row, 4, Row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorderColor = XLColor.DimGray
                'CABEÇALHO PROXIMA TROCA
                WsReport.Range(Row, 5, Row, 5).Value = "PRÓXIMA TROCA"
                WsReport.Range(Row, 5, Row, 5).Style.Font.Bold = True
                WsReport.Range(Row, 5, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 5, Row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorderColor = XLColor.DimGray
                Row += 1
                'ITENS DO COMPRESSOR
                For Each WorkedHourRow As DataRow In TableWorkedHour.Rows
                    WsReport.Rows(Row, Row).Height = 20
                    'NOME DO ITEM
                    WsReport.Range(Row, 2, Row, 2).Value = WorkedHourRow.Item("item").ToString
                    WsReport.Range(Row, 2, Row, 2).Style.Font.Bold = True
                    WsReport.Range(Row, 2, Row, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorderColor = XLColor.DimGray
                    'HORAS ATUAL
                    WsReport.Range(Row, 3, Row, 3).Style.NumberFormat.NumberFormatId = 3
                    WsReport.Range(Row, 3, Row, 3).Value = CInt(WorkedHourRow.Item("currentcapacity") - Today.Subtract(ReportingEvaluation.EvaluationDate).Days * ReportingEvaluation.AverageWorkLoad)
                    WsReport.Range(Row, 3, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorderColor = XLColor.DimGray
                    'ULTIMA TROCA
                    WsReport.Range(Row, 4, Row, 4).Value = If(IsDate(WorkedHourRow.Item("previousexchange").ToString), CDate(WorkedHourRow.Item("previousexchange")).ToString("dd/MM/yyyy"), Nothing)
                    WsReport.Range(Row, 4, Row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorderColor = XLColor.DimGray
                    'PROXIMA TROCA
                    If IsDate(WorkedHourRow.Item("nextexchange").ToString) Then
                        NextChange = CDate(WorkedHourRow.Item("nextexchange").ToString)
                        If NextChange >= ReportingEvaluation.EvaluationDate.AddYears(1) Then
                            WsReport.Range(Row, 5, Row, 5).Value = ReportingEvaluation.EvaluationDate.AddYears(1).ToString("dd/MM/yyyy")
                        Else
                            If NextChange <= ReportingEvaluation.EvaluationDate.AddYears(-1) Then
                                WsReport.Range(Row, 5, Row, 5).Value = ReportingEvaluation.EvaluationDate.AddYears(-1).ToString("dd/MM/yyyy")
                            Else
                                WsReport.Range(Row, 5, Row, 5).Value = CDate(WorkedHourRow.Item("nextexchange")).ToString("dd/MM/yyyy")
                            End If
                        End If
                    Else
                        WsReport.Range(Row, 5, Row, 5).Value = Nothing
                    End If
                    WsReport.Range(Row, 5, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    WsReport.Range(Row, 5, Row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorderColor = XLColor.DimGray
                    WsReport.Range(Row, 5, Row, 5).Style.Font.Bold = IsDate(WorkedHourRow.Item("nextexchange").ToString) AndAlso CDate(WorkedHourRow.Item("nextexchange").ToString) < Today
                    WsReport.Range(Row, 5, Row, 5).Style.Font.FontColor = If(IsDate(WorkedHourRow.Item("nextexchange").ToString) AndAlso CDate(WorkedHourRow.Item("nextexchange").ToString) < Today, XLColor.DarkRed, XLColor.Black)
                    Row += 1
                Next WorkedHourRow
                For Each ElapsedDayRow As DataRow In TableElapsedDay.Rows
                    WsReport.Rows(Row, Row).Height = 20
                    'NOME DO ITEM
                    WsReport.Range(Row, 2, Row, 2).Value = ElapsedDayRow.Item("item").ToString
                    WsReport.Range(Row, 2, Row, 2).Style.Font.Bold = True
                    WsReport.Range(Row, 2, Row, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 2).Style.Border.BottomBorderColor = XLColor.DimGray
                    'HORAS ATUAL
                    WsReport.Range(Row, 3, Row, 3).Style.NumberFormat.NumberFormatId = 3
                    WsReport.Range(Row, 3, Row, 3).Value = CInt(ElapsedDayRow.Item("currentcapacity") - Today.Subtract(ReportingEvaluation.EvaluationDate).Days)
                    WsReport.Range(Row, 3, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 3, Row, 3).Style.Border.BottomBorderColor = XLColor.DimGray
                    'ULTIMA TROCA
                    WsReport.Range(Row, 4, Row, 4).Value = If(IsDate(ElapsedDayRow.Item("previousexchange").ToString), CDate(ElapsedDayRow.Item("previousexchange")).ToString("dd/MM/yyyy"), Nothing)
                    WsReport.Range(Row, 4, Row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorderColor = XLColor.DimGray
                    'PROXIMA TROCA
                    If IsDate(ElapsedDayRow.Item("nextexchange").ToString) Then
                        NextChange = CDate(ElapsedDayRow.Item("nextexchange").ToString)
                        If NextChange >= ReportingEvaluation.EvaluationDate.AddYears(1) Then
                            WsReport.Range(Row, 5, Row, 5).Value = ReportingEvaluation.EvaluationDate.AddYears(1).ToString("dd/MM/yyyy")
                        Else
                            If NextChange <= ReportingEvaluation.EvaluationDate.AddYears(-1) Then
                                WsReport.Range(Row, 5, Row, 5).Value = ReportingEvaluation.EvaluationDate.AddYears(-1).ToString("dd/MM/yyyy")
                            Else
                                WsReport.Range(Row, 5, Row, 5).Value = CDate(ElapsedDayRow.Item("nextexchange")).ToString("dd/MM/yyyy")
                            End If
                        End If
                    Else
                        WsReport.Range(Row, 5, Row, 5).Value = Nothing
                    End If
                    WsReport.Range(Row, 5, Row, 5).Style.Font.Bold = True
                    WsReport.Range(Row, 5, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    WsReport.Range(Row, 5, Row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 5, Row, 5).Style.Border.BottomBorderColor = XLColor.DimGray
                    WsReport.Range(Row, 5, Row, 5).Style.Font.Bold = IsDate(ElapsedDayRow.Item("nextexchange").ToString) AndAlso CDate(ElapsedDayRow.Item("nextexchange").ToString) < Today
                    WsReport.Range(Row, 5, Row, 5).Style.Font.FontColor = If(IsDate(ElapsedDayRow.Item("nextexchange").ToString) AndAlso CDate(ElapsedDayRow.Item("nextexchange").ToString) < Today, XLColor.DarkRed, XLColor.Black)
                    Row += 1
                Next ElapsedDayRow
                If ReportingEvaluation.TechnicalAdvice <> Nothing And ShowTechnicalAdvice Then
                    WsReport.Rows(Row, Row).Height = 20
                    WsReport.Range(Row, 2, Row, 5).Merge()
                    WsReport.Range(Row, 2, Row, 5).Value = "PARECER TÉCNICO"
                    WsReport.Range(Row, 2, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    WsReport.Range(Row, 2, Row, 5).Style.Font.Bold = True
                    WsReport.Range(Row, 2, Row, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin
                    Row += 1
                    WsReport.Rows(Row, Row).Height = 40
                    WsReport.Range(Row, 2, Row, 5).Merge()
                    WsReport.Range(Row, 2, Row, 5).Value = ReportingEvaluation.TechnicalAdvice
                    WsReport.Range(Row, 2, Row, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                    WsReport.Range(Row, 2, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Justify
                    Row += 1
                End If
            End If
            Row += 1
            CompressorCount += 1
        Next DgvRow
        CompressorsDataChart.Sort(Function(x, y) x.Item2.CompareTo(y.Item2))
        Chart = New Chart()
        Chart.Width = ChartWidth
        Chart.Height = ChartHeight
        ChartArea = New ChartArea()
        ChartArea.Name = "ChartArea1"
        Chart.ChartAreas.Add(ChartArea)
        Chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.DarkGray
        Chart.ChartAreas(0).AxisX.LineColor = Color.DarkGray
        Chart.ChartAreas(0).AxisY.LineColor = Color.DarkGray
        Chart.ChartAreas(0).AxisY.Maximum = 24
        Chart.ChartAreas(0).AxisY.Interval = 4
        Chart.ChartAreas(0).AxisY.LabelStyle.Format = "0\h"
        If SelectedRows.Count <= 10 Then
            Chart.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Century Gothic", 10)
        ElseIf SelectedRows.Count <= 20 Then
            Chart.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Century Gothic", 8)
        Else
            Chart.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Century Gothic", 6)
        End If
        Chart.ChartAreas(0).AxisX.Interval = 1  ' força mostrar cada rótulo
        Chart.PaletteCustomColors = {Color.FromArgb(255, 128, 0)}
        Chart.Palette = ChartColorPalette.None
        Chart.Legends.Clear()
        Series = New Series With {
            .ChartType = SeriesChartType.Bar,
            .IsValueShownAsLabel = True,
            .LabelFormat = "0.00"
        }
        For Each v As Tuple(Of String, Decimal) In CompressorsDataChart
            Series.Points.AddXY(v.Item1, v.Item2)
        Next v
        Chart.Series.Add(Series)
        ChartImage = New Bitmap(ChartWidth, ChartHeight)
        Chart.DrawToBitmap(ChartImage, New Rectangle(0, 0, ChartImage.Width, ChartImage.Height))
        ChartImageName = TextHelper.GetRandomFileName(".png")
        ChartImage.Save(Path.Combine(ApplicationPaths.ManagerTempDirectory, ChartImageName), Imaging.ImageFormat.Png)
        ChartImage.Dispose()
        Chart.Dispose()
        ChartPicture = WsReport.AddPicture(New MemoryStream(File.ReadAllBytes(Path.Combine(ApplicationPaths.ManagerTempDirectory, ChartImageName))))
        ChartPicture.MoveTo(WsReport.Cell("A4"), New Point(0, 5))
        SettingsDocument = New XmlDocument
        SettingsDocument.Load(Path.Combine(ApplicationPaths.HelpersDirectory, "MaintenancePlan.xml"))
        If Not String.IsNullOrEmpty(SettingsDocument.SelectSingleNode("/Settings/FooterMessage").InnerText) Then
            WsReport.Rows(Row).Height = 20
            WsReport.Range(Row, 2, Row + 1, 5).Style.Border.TopBorder = XLBorderStyleValues.Medium
            WsReport.Range(Row, 2, Row + 1, 5).Style.Border.BottomBorder = XLBorderStyleValues.Medium
            WsReport.Range(Row, 2, Row + 1, 5).Merge()
            WsReport.Range(Row, 2, Row + 1, 5).Style.Alignment.WrapText = True
            WsReport.Range(Row, 2, Row + 1, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            WsReport.Range(Row, 2, Row + 1, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(Row, 2, Row + 1, 5).Value = SettingsDocument.SelectSingleNode("/Settings/FooterMessage").InnerText
            Row += 2
            WsReport.Rows(Row).Height = 20
        End If
        'DADOS DA EMPRESA
        WsReport.Range(Row, 1, Row, 5).Merge()
        WsReport.Range(Row, 1, Row, 5).Value = Session.Setting.Company.Name
        WsReport.Range(Row, 1, Row, 5).Style.Font.Bold = True
        WsReport.Range(Row, 1, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        Row += 1
        WsReport.Rows(Row).Height = 20
        WsReport.Range(Row, 1, Row, 5).Merge()
        WsReport.Range(Row, 1, Row, 5).Value = Join(New List(Of String)({Session.Setting.Company.Address.Street, "Nº " & Session.Setting.Company.Address.Number, Session.Setting.Company.Address.Complement, Session.Setting.Company.Address.District, Session.Setting.Company.Address.City & "-" & Session.Setting.Company.Address.State}).ToArray, " ")
        WsReport.Range(Row, 1, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        Row += 1
        WsReport.Rows(Row).Height = 20
        WsReport.Range(Row, 1, Row, 5).Merge()
        WsReport.Range(Row, 1, Row, 5).Value = Session.Setting.Company.Document
        WsReport.Range(Row, 1, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        Row += 1
        WsReport.Rows(Row).Height = 20
        WsReport.Range(Row, 1, Row, 5).Merge()
        WsReport.Range(Row, 1, Row, 5).Value = Session.Setting.Company.Contact.Phone1
        WsReport.Range(Row, 1, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        Row += 1
        WsReport.Rows(Row).Height = 10
        WsReport.Range(Row, 1, Row, 5).Merge()
        WsReport.Range(Row, 1, Row, 5).Value = "EMITIDO EM " & Today.ToShortDateString
        WsReport.Range(Row, 1, Row, 5).Style.Font.FontSize = 8
        WsReport.Range(Row, 1, Row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
        WsReport.PageSetup.PagesWide = 1
        WsReport.PageSetup.PagesTall = False
        WsReport.PageSetup.CenterHorizontally = True
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        WbReport.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Plano de Manutenção - " & ReportingEvaluation.Customer.ShortName
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Plano de Manutenção.pdf"))
        Return Result
    End Function
    Public Shared Function ProcessRegistrationForm(PersonID As Long, ShowAddresses As Boolean, ShowContacts As Boolean, ShowCompressors As Boolean) As ReportResult
        Dim WbMain As New XLWorkbook
        Dim WsReport As IXLWorksheet = WbMain.Worksheets.Add("Ficha Cadastral")
        Dim Converter As ExcelToPdfConverter
        Dim Person As Person
        Dim Row As Integer
        Dim Result As New ReportResult
        Person = New Person().Load(PersonID, False)
        WsReport.ShowGridLines = False
        WsReport.Columns.Width = 2.57
        WsReport.Rows.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        WsReport.Rows.Style.NumberFormat.Format = "@"
        Row = 1
        WsReport.Rows(Row).Height = 20
        WsReport.Range(Row, 1, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 1, Row, 28).Value = "FICHA CADASTRAL"
        WsReport.Range(Row, 1, Row, 28).Style.Font.FontSize = 12
        WsReport.Range(Row, 1, Row, 28).Style.Font.Bold = True
        Row += 1
        WsReport.Rows(Row).Height = 5
        Row += 1
        WsReport.Rows(Row).Height = 10
        WsReport.Range(Row, 1, Row, 1).Value = "NOME"
        WsReport.Range(Row, 1, Row, 1).Style.Font.FontSize = 8
        WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
        WsReport.Range(Row, 18, Row, 18).Value = "NOME CURTO"
        WsReport.Range(Row, 18, Row, 18).Style.Font.FontSize = 8
        WsReport.Range(Row, 18, Row, 18).Style.Font.Bold = True
        Row += 1
        WsReport.Rows(Row).Height = 20
        WsReport.Range(Row, 1, Row, 16).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
        WsReport.Range(Row, 1, Row, 16).Style.Alignment.ShrinkToFit = True
        WsReport.Range(Row, 1, Row, 16).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 1, Row, 16).Value = Person.Name
        WsReport.Range(Row, 18, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
        WsReport.Range(Row, 18, Row, 28).Style.Alignment.ShrinkToFit = True
        WsReport.Range(Row, 18, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 18, Row, 28).Value = Person.ShortName
        Row += 1
        WsReport.Rows(Row).Height = 5
        Row += 1
        WsReport.Rows(Row).Height = 10
        WsReport.Range(Row, 1, Row, 1).Value = If(Person.Entity = PersonEntityType.Legal, "CNPJ", "CPF")
        WsReport.Range(Row, 1, Row, 1).Style.Font.FontSize = 8
        WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
        WsReport.Range(Row, 9, Row, 10).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 9, Row, 10).Value = "CLIENTE"
        WsReport.Range(Row, 9, Row, 10).Style.Font.FontSize = 8
        WsReport.Range(Row, 9, Row, 10).Style.Font.Bold = True
        WsReport.Range(Row, 12, Row, 14).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 12, Row, 14).Value = "FORNECEDOR"
        WsReport.Range(Row, 12, Row, 14).Style.Font.FontSize = 8
        WsReport.Range(Row, 12, Row, 14).Style.Font.Bold = True
        WsReport.Range(Row, 16, Row, 17).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 16, Row, 17).Value = "TÉCNICO"
        WsReport.Range(Row, 16, Row, 17).Style.Font.FontSize = 8
        WsReport.Range(Row, 16, Row, 17).Style.Font.Bold = True
        WsReport.Range(Row, 19, Row, 22).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 19, Row, 22).Value = "TRANSPORTADORA"
        WsReport.Range(Row, 19, Row, 22).Style.Font.FontSize = 8
        WsReport.Range(Row, 19, Row, 22).Style.Font.Bold = True
        WsReport.Range(Row, 27, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 27, Row, 28).Value = "ATIVO"
        WsReport.Range(Row, 27, Row, 28).Style.Font.FontSize = 8
        WsReport.Range(Row, 27, Row, 28).Style.Font.Bold = True
        Row += 1
        WsReport.Rows(Row).Height = 20
        WsReport.Range(Row, 1, Row, 7).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 1, Row, 7).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 1, Row, 7).Value = Person.Document
        WsReport.Range(Row, 9, Row, 10).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 9, Row, 10).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 9, Row, 10).Value = If(Person.IsCustomer, "SIM", "NÃO")
        WsReport.Range(Row, 12, Row, 14).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 12, Row, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 12, Row, 14).Value = If(Person.IsProvider, "SIM", "NÃO")
        WsReport.Range(Row, 16, Row, 17).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 16, Row, 17).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 16, Row, 17).Value = If(Person.IsTechnician, "SIM", "NÃO")
        WsReport.Range(Row, 19, Row, 22).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 19, Row, 22).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 19, Row, 22).Value = If(Person.IsCarrier, "SIM", "NÃO")
        WsReport.Range(Row, 27, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsReport.Range(Row, 27, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
        WsReport.Range(Row, 27, Row, 28).Value = If(Person.Status = SimpleStatus.Active, "SIM", "NÃO")
        Row += 1
        If ShowAddresses Then
            WsReport.Rows(Row).Height = 5
            Row += 1
            WsReport.Rows(Row).Height = 20
            WsReport.Range(Row, 1, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(Row, 1, Row, 28).Value = If(Person.Addresses.Count = 1, "ENDEREÇO", "ENDEREÇOS")
            WsReport.Range(Row, 1, Row, 28).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 28).Style.Fill.BackgroundColor = XLColor.WhiteSmoke
            WsReport.Range(Row, 1, Row, 28).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 28).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorderColor = XLColor.DimGray
            Row += 1
            WsReport.Rows(Row).Height = 10
            For Each Address As PersonAddress In Person.Addresses
                Row += 1
                WsReport.Rows(Row).Height = 20
                WsReport.Range(Row, 1, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 1, Row, 28).Value = Address.Name & If(Address.IsMainAddress, " (PRINCIPAL)", Nothing)
                WsReport.Range(Row, 1, Row, 28).Style.Font.Bold = True
                WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                Row += 1
                WsReport.Rows(Row).Height = 5
                Row += 1
                WsReport.Range(Row, 1, Row, 1).Value = "CEP"
                WsReport.Range(Row, 1, Row, 1).Style.Font.FontSize = 8
                WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
                WsReport.Range(Row, 6, Row, 6).Value = "RUA"
                WsReport.Range(Row, 6, Row, 6).Style.Font.FontSize = 8
                WsReport.Range(Row, 6, Row, 6).Style.Font.Bold = True
                WsReport.Range(Row, 15, Row, 15).Value = "NÚMERO"
                WsReport.Range(Row, 15, Row, 15).Style.Font.FontSize = 8
                WsReport.Range(Row, 15, Row, 15).Style.Font.Bold = True
                WsReport.Range(Row, 19, Row, 19).Value = "COMPLEMENTO"
                WsReport.Range(Row, 19, Row, 19).Style.Font.FontSize = 8
                WsReport.Range(Row, 19, Row, 19).Style.Font.Bold = True
                Row += 1
                WsReport.Rows(Row).Height = 20
                WsReport.Range(Row, 1, Row, 4).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 1, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 4).Value = Address.ZipCode
                WsReport.Range(Row, 6, Row, 13).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 6, Row, 13).Style.Alignment.ShrinkToFit = True
                WsReport.Range(Row, 6, Row, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 6, Row, 13).Value = Address.Street
                WsReport.Range(Row, 15, Row, 17).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 15, Row, 17).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 15, Row, 17).Value = Address.Number
                WsReport.Range(Row, 19, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 19, Row, 28).Style.Alignment.ShrinkToFit = True
                WsReport.Range(Row, 19, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 19, Row, 28).Value = Address.Complement
                Row += 1
                WsReport.Rows(Row).Height = 5
                Row += 1
                WsReport.Rows(Row).Height = 10
                WsReport.Range(Row, 1, Row, 1).Value = "BAIRRO"
                WsReport.Range(Row, 1, Row, 1).Style.Font.FontSize = 8
                WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
                WsReport.Range(Row, 16, Row, 16).Value = "CIDADE"
                WsReport.Range(Row, 16, Row, 16).Style.Font.FontSize = 8
                WsReport.Range(Row, 16, Row, 16).Style.Font.Bold = True
                WsReport.Range(Row, 27, Row, 27).Value = "UF"
                WsReport.Range(Row, 27, Row, 27).Style.Font.FontSize = 8
                WsReport.Range(Row, 27, Row, 27).Style.Font.Bold = True
                Row += 1
                WsReport.Rows(Row).Height = 20
                WsReport.Range(Row, 1, Row, 14).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 1, Row, 14).Style.Alignment.ShrinkToFit = True
                WsReport.Range(Row, 1, Row, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 14).Value = Address.District
                WsReport.Range(Row, 16, Row, 25).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 16, Row, 25).Style.Alignment.ShrinkToFit = True
                WsReport.Range(Row, 16, Row, 25).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 16, Row, 25).Value = Address.City.Name
                WsReport.Range(Row, 27, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 27, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 27, Row, 28).Value = Address.City.State.ShortName
                Row += 1
                WsReport.Rows(Row).Height = 5
                Row += 1
                WsReport.Rows(Row).Height = 10
                WsReport.Range(Row, 1, Row, 1).Value = "INSC. MUNICIPAL"
                WsReport.Range(Row, 1, Row, 1).Style.Font.FontSize = 8
                WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
                WsReport.Range(Row, 7, Row, 7).Value = "INSC. ESTADUAL"
                WsReport.Range(Row, 7, Row, 7).Style.Font.FontSize = 8
                WsReport.Range(Row, 7, Row, 7).Style.Font.Bold = True
                WsReport.Range(Row, 13, Row, 13).Value = "CONTRIBUIÇÃO"
                WsReport.Range(Row, 13, Row, 13).Style.Font.FontSize = 8
                WsReport.Range(Row, 13, Row, 13).Style.Font.Bold = True
                WsReport.Range(Row, 20, Row, 20).Value = "TRANSPORTADORA"
                WsReport.Range(Row, 20, Row, 20).Style.Font.FontSize = 8
                WsReport.Range(Row, 20, Row, 20).Style.Font.Bold = True
                Row += 1
                WsReport.Rows(Row).Height = 20
                WsReport.Range(Row, 1, Row, 5).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 1, Row, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 5).Value = Address.CityDocument
                WsReport.Range(Row, 7, Row, 11).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 7, Row, 11).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 7, Row, 11).Value = Address.StateDocument
                WsReport.Range(Row, 13, Row, 18).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 13, Row, 18).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 13, Row, 18).Value = UCase(Address.ContributionType)
                WsReport.Range(Row, 20, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 20, Row, 28).Style.Alignment.ShrinkToFit = True
                WsReport.Range(Row, 20, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 20, Row, 28).Value = Address.Carrier.Name
                Row += 1
                WsReport.Rows(Row).Height = 10
            Next Address
        End If
        If ShowContacts Then
            WsReport.Rows(Row).Height = 5
            Row += 1
            WsReport.Rows(Row).Height = 20
            WsReport.Range(Row, 1, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(Row, 1, Row, 28).Value = If(Person.Contacts.Count = 1, "CONTATO", "CONTATOS")
            WsReport.Range(Row, 1, Row, 28).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 28).Style.Fill.BackgroundColor = XLColor.WhiteSmoke
            WsReport.Range(Row, 1, Row, 28).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 28).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorderColor = XLColor.DimGray
            Row += 1
            WsReport.Rows(Row).Height = 10
            For Each Contact As PersonContact In Person.Contacts
                Row += 1
                WsReport.Rows(Row).Height = 20
                WsReport.Range(Row, 1, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 1, Row, 28).Value = Contact.Name & If(Contact.IsMainContact, " (PRINCIPAL)", Nothing)
                WsReport.Range(Row, 1, Row, 28).Style.Font.Bold = True
                WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                Row += 1
                WsReport.Rows(Row).Height = 5
                Row += 1
                WsReport.Range(Row, 1, Row, 1).Value = "CARGO"
                WsReport.Range(Row, 1, Row, 1).Style.Font.FontSize = 8
                WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
                WsReport.Range(Row, 10, Row, 10).Value = "TELEFONE"
                WsReport.Range(Row, 10, Row, 10).Style.Font.FontSize = 8
                WsReport.Range(Row, 10, Row, 10).Style.Font.Bold = True
                WsReport.Range(Row, 16, Row, 16).Value = "E-MAIL"
                WsReport.Range(Row, 16, Row, 16).Style.Font.FontSize = 8
                WsReport.Range(Row, 16, Row, 16).Style.Font.Bold = True
                Row += 1
                WsReport.Rows(Row).Height = 20
                WsReport.Range(Row, 1, Row, 8).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 1, Row, 8).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 8).Value = Contact.JobTitle
                WsReport.Range(Row, 10, Row, 14).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 10, Row, 14).Style.Alignment.ShrinkToFit = True
                WsReport.Range(Row, 10, Row, 14).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 10, Row, 14).Value = Contact.Phone
                WsReport.Range(Row, 16, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 16, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 16, Row, 28).Value = Contact.Email
                Row += 1
                WsReport.Rows(Row).Height = 10
            Next Contact
        End If
        If ShowCompressors And Person.Compressors.Count > 0 Then
            WsReport.Rows(Row).Height = 5
            Row += 1
            WsReport.Rows(Row).Height = 20
            WsReport.Range(Row, 1, Row, 28).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(Row, 1, Row, 28).Value = If(Person.Compressors.Count = 1, "COMPRESSOR", "COMPRESSORES")
            WsReport.Range(Row, 1, Row, 28).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 28).Style.Fill.BackgroundColor = XLColor.WhiteSmoke
            WsReport.Range(Row, 1, Row, 28).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 28).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 28).Style.Border.BottomBorderColor = XLColor.DimGray
            Row += 1
            WsReport.Rows(Row).Height = 10
            For Each Compressor As PersonCompressor In Person.Compressors
                Row += 1
                WsReport.Rows(Row).Height = 10
                WsReport.Range(Row, 1, Row, 8).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 1, Row, 8).Value = "COMPRESSOR"
                WsReport.Range(Row, 1, Row, 8).Style.Font.FontSize = 8
                WsReport.Range(Row, 1, Row, 8).Style.Font.Bold = True
                WsReport.Range(Row, 10, Row, 13).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 10, Row, 13).Value = "Nº SÉRIE"
                WsReport.Range(Row, 10, Row, 13).Style.Font.FontSize = 8
                WsReport.Range(Row, 10, Row, 13).Style.Font.Bold = True
                WsReport.Range(Row, 15, Row, 18).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 15, Row, 18).Value = "PATRIMÔNIO"
                WsReport.Range(Row, 15, Row, 18).Style.Font.FontSize = 8
                WsReport.Range(Row, 15, Row, 18).Style.Font.Bold = True
                WsReport.Range(Row, 20, Row, 28).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 20, Row, 28).Value = "SETOR"
                WsReport.Range(Row, 20, Row, 28).Style.Font.FontSize = 8
                WsReport.Range(Row, 20, Row, 28).Style.Font.Bold = True
                Row += 1
                WsReport.Rows(Row).Height = 20
                WsReport.Range(Row, 1, Row, 8).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 1, Row, 8).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 8).Value = Compressor.CompressorName
                WsReport.Range(Row, 10, Row, 13).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 10, Row, 13).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 10, Row, 13).Value = Compressor.SerialNumber
                WsReport.Range(Row, 15, Row, 18).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 15, Row, 18).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 15, Row, 18).Value = Compressor.Patrimony
                WsReport.Range(Row, 20, Row, 28).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 20, Row, 28).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 20, Row, 28).Value = Compressor.Sector
                Row += 1
                WsReport.Rows(Row).Height = 10
            Next Compressor
        End If
        Row += 1
        WsReport.Rows(Row).Height = 10
        WsReport.Range(Row, 1, Row, 28).Merge.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
        WsReport.Range(Row, 1, Row, 28).Style.Font.FontSize = 8
        WsReport.Range(Row, 1, Row, 28).Value = "EMITIDO EM " & Today.ToShortDateString
        WsReport.PageSetup.PagesWide = 1
        WsReport.PageSetup.PagesTall = False
        WsReport.PageSetup.CenterHorizontally = True
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        WbMain.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Ficha Cadastral - " & Person.ShortName
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Ficha Cadastral.pdf"))
        Return Result
    End Function
End Class
