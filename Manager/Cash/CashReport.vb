Imports Syncfusion.ExcelToPdfConverter
Imports System.IO
Imports MySql.Data.MySqlClient
Imports ManagerCore
Imports ClosedXML.Excel
Imports ControlLibrary

Public Class CashReport
    Public Shared Function ProcessCashSheet(Cashes As List(Of Cash))
        Dim Session = Locator.GetInstance(Of Session)
        Dim WbMain As New XLWorkbook
        Dim WsReport As IXLWorksheet
        Dim Converter As ExcelToPdfConverter
        Dim TableExpense As DataTable
        Dim TableRefund As DataTable
        Dim Result As New ReportResult
        Dim Logo As Drawings.IXLPicture
        Dim PreviousBalance As Decimal
        Dim TotalRefund As Decimal
        Dim TotalExpense As Decimal
        Dim Row As Integer
        For Each Cash In Cashes
            WsReport = WbMain.Worksheets.Add($"Caixa {Cash.ID}")
            PreviousBalance = Cash.GetPreviousBalance()
            Row = 5
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                    Using ComMonth As New MySqlCommand(My.Resources.SetBrazilianDatabaseMonthNames, Con)
                        ComMonth.Transaction = Tra
                        ComMonth.ExecuteNonQuery()
                    End Using
                    Using Cmd As New MySqlCommand(My.Resources.CashReportCashSheet, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@cashid", Cash.ID)
                        Cmd.Parameters.AddWithValue("@itemtypeid", CInt(CashItemType.Income))
                        Using Adp As New MySqlDataAdapter(Cmd)
                            TableRefund = New DataTable
                            Adp.Fill(TableRefund)
                            TotalRefund = TableRefund.Rows.Cast(Of DataRow).Sum(Function(x) CDec(x.Item("value")))
                        End Using
                    End Using
                    Using Cmd As New MySqlCommand(My.Resources.CashReportCashSheet, Con)
                        Cmd.Transaction = Tra
                        Cmd.Parameters.AddWithValue("@cashid", Cash.ID)
                        Cmd.Parameters.AddWithValue("@itemtypeid", CInt(CashItemType.Expense))
                        Using Adp As New MySqlDataAdapter(Cmd)
                            TableExpense = New DataTable
                            Adp.Fill(TableExpense)
                            TotalExpense = TableExpense.Rows.Cast(Of DataRow).Sum(Function(x) CDec(x.Item("value")))
                        End Using
                    End Using
                    Tra.Commit()
                End Using
            End Using
            WsReport.ShowGridLines = False
            WsReport.Cells.Style.Font.FontName = "Century Gothic"
            WsReport.Cells.Style.Font.FontSize = 12
            WsReport.Rows(1, 3).Height = 25
            WsReport.Columns(1).Width = 15
            WsReport.Columns(2).Width = 50
            WsReport.Columns(3).Width = 15
            WsReport.Columns(4).Width = 15
            If File.Exists(Session.Setting.Company.LogoLocation) Then
                Logo = WsReport.AddPicture(New MemoryStream(File.ReadAllBytes(Session.Setting.Company.LogoLocation)))
                Logo.MoveTo(WsReport.Cell("A1"), New Point(0, 5))
                Logo.WithSize(156, 57)
            End If
            WsReport.Range(1, 2, 2, 3).Merge()
            WsReport.Range(1, 2, 2, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(1, 2, 2, 3).Value = "CAIXA " & UCase(Cash.CashFlow.Name)
            WsReport.Range(1, 2, 2, 3).Style.Font.FontSize = 16
            WsReport.Range(1, 2, 2, 3).Style.Font.Bold = True
            WsReport.Range(1, 4, 1, 4).Value = "Nº " & Cash.ID
            WsReport.Range(1, 4, 1, 4).Style.Font.Bold = True
            WsReport.Range(1, 4, 1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(2, 4, 2, 4).Value = Cash.Creation.ToString("dd/MM/yyyy")
            WsReport.Range(2, 4, 2, 4).Style.Font.Bold = True
            WsReport.Range(2, 4, 2, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center


            WsReport.Range(4, 1, 4, 3).Merge()
            WsReport.Range(4, 1, 4, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
            WsReport.Range(4, 1, 4, 3).Style.Font.Bold = True
            WsReport.Range(4, 1, 4, 3).Value = "SALDO ANTERIOR"
            WsReport.Range(4, 1, 4, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            WsReport.Range(4, 1, 4, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(4, 1, 4, 3).Style.Border.LeftBorderColor = XLColor.DimGray
            WsReport.Range(4, 1, 4, 3).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(4, 4, 4, 4).Style.NumberFormat.NumberFormatId = 2
            WsReport.Range(4, 4, 4, 4).Value = PreviousBalance
            WsReport.Range(4, 4, 4, 4).Style.Font.Bold = True
            WsReport.Range(4, 4, 4, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin
            WsReport.Range(4, 4, 4, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(4, 4, 4, 4).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(4, 4, 4, 4).Style.Border.RightBorderColor = XLColor.DimGray
            For Each TableRow As DataRow In TableRefund.Rows
                WsReport.Range(Row, 1, Row, 3).Merge()
                WsReport.Range(Row, 1, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                WsReport.Range(Row, 1, Row, 3).Style.Font.Bold = True
                WsReport.Range(Row, 1, Row, 3).Value = TableRow.Item("description").ToString
                WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorderColor = XLColor.DimGray
                WsReport.Range(Row, 1, Row, 3).Style.Border.TopBorderColor = XLColor.DimGray
                WsReport.Range(Row, 4, Row, 4).Style.NumberFormat.NumberFormatId = 2
                WsReport.Range(Row, 4, Row, 4).Value = CDec(TableRow.Item("value"))
                WsReport.Range(Row, 4, Row, 4).Style.Font.Bold = True
                WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorderColor = XLColor.DimGray
                WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorderColor = XLColor.DimGray
                Row += 1
            Next TableRow
            WsReport.Range(Row, 1, Row, 3).Merge()
            WsReport.Range(Row, 1, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
            WsReport.Range(Row, 1, Row, 3).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 3).Value = "TOTAL"
            WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 3).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.NumberFormat.NumberFormatId = 2
            WsReport.Range(Row, 4, Row, 4).Value = PreviousBalance + TotalRefund
            WsReport.Range(Row, 4, Row, 4).Style.Font.Bold = True
            WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorderColor = XLColor.DimGray
            Row += 1
            WsReport.Range(Row, 1, Row, 1).Value = "DATA"
            WsReport.Range(Row, 1, Row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(Row, 1, Row, 1).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 1).Style.Border.LeftBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 1).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 1).Style.Fill.BackgroundColor = XLColor.Silver
            WsReport.Range(Row, 2, Row, 2).Value = "DESCRIÇÃO"
            WsReport.Range(Row, 2, Row, 2).Style.Font.Bold = True
            WsReport.Range(Row, 2, Row, 2).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 2, Row, 2).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 2, Row, 2).Style.Fill.BackgroundColor = XLColor.Silver
            WsReport.Range(Row, 3, Row, 3).Value = "Nº DOC."
            WsReport.Range(Row, 3, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            WsReport.Range(Row, 3, Row, 3).Style.Font.Bold = True
            WsReport.Range(Row, 3, Row, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 3, Row, 3).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 3, Row, 3).Style.Fill.BackgroundColor = XLColor.Silver
            WsReport.Range(Row, 4, Row, 4).Value = "VALOR"
            WsReport.Range(Row, 4, Row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
            WsReport.Range(Row, 4, Row, 4).Style.Font.Bold = True
            WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.Fill.BackgroundColor = XLColor.Silver
            Row += 1
            For Each TableRow As DataRow In TableExpense.Rows
                WsReport.Range(Row, 1, Row, 1).Value = CDate(TableRow.Item("documentdate").ToString).ToString("dd/MM/yyyy")
                WsReport.Range(Row, 1, Row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 1, Row, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 1, Row, 1).Style.Border.LeftBorderColor = XLColor.DimGray
                WsReport.Range(Row, 2, Row, 2).Value = TableRow.Item("description").ToString
                WsReport.Range(Row, 2, Row, 2).Style.Alignment.WrapText = True
                WsReport.Range(Row, 2, Row, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
                WsReport.Range(Row, 3, Row, 3).Value = TableRow.Item("documentnumber").ToString
                WsReport.Range(Row, 3, Row, 3).Style.Alignment.WrapText = True
                WsReport.Range(Row, 3, Row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                WsReport.Range(Row, 3, Row, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
                WsReport.Range(Row, 4, Row, 4).Value = CDec(TableRow.Item("value"))
                WsReport.Range(Row, 4, Row, 4).Style.NumberFormat.NumberFormatId = 2
                WsReport.Range(Row, 4, Row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin
                WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorderColor = XLColor.DimGray
                If Not TableRow.Equals(TableExpense.Rows(TableExpense.Rows.Count - 1)) Then
                    WsReport.Range(Row, 1, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Dotted
                    WsReport.Range(Row, 1, Row, 4).Style.Border.BottomBorderColor = XLColor.DimGray
                End If
                Row += 1
            Next TableRow
            WsReport.Range(Row, 1, Row, 3).Merge()
            WsReport.Range(Row, 1, Row, 3).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 3).Value = "SOMA DESPESAS"
            WsReport.Range(Row, 1, Row, 3).Style.Fill.BackgroundColor = XLColor.Silver
            WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.NumberFormat.NumberFormatId = 2
            WsReport.Range(Row, 4, Row, 4).Value = TotalExpense
            WsReport.Range(Row, 4, Row, 4).Style.Font.Bold = True
            WsReport.Range(Row, 4, Row, 4).Style.Fill.BackgroundColor = XLColor.Silver
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorderColor = XLColor.DimGray
            Row += 1
            WsReport.Range(Row, 1, Row, 3).Merge()
            WsReport.Range(Row, 1, Row, 3).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 3).Value = "SALDO ATUAL"
            WsReport.Range(Row, 1, Row, 3).Style.Fill.BackgroundColor = XLColor.Silver
            WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 3).Style.Border.LeftBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 3).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 1, Row, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 3).Style.Border.BottomBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.NumberFormat.NumberFormatId = 2
            WsReport.Range(Row, 4, Row, 4).Value = PreviousBalance + TotalRefund - TotalExpense
            WsReport.Range(Row, 4, Row, 4).Style.Font.Bold = True
            WsReport.Range(Row, 4, Row, 4).Style.Fill.BackgroundColor = XLColor.Silver
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.RightBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.TopBorderColor = XLColor.DimGray
            WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            WsReport.Range(Row, 4, Row, 4).Style.Border.BottomBorderColor = XLColor.DimGray
            WsReport.Rows.Height = 18
            WsReport.PageSetup.PagesWide = 1
            WsReport.PageSetup.PagesTall = False
            WsReport.PageSetup.PagesWide = 1
            WsReport.PageSetup.PagesTall = False
        Next Cash
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName())
        WbMain.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Caixa " & ControlLibrary.Utility.GetTitleCase(Cashes.First.CashFlow.Name)
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Caixa " & ControlLibrary.Utility.GetTitleCase(Cashes.First.CashFlow.Name) & ".pdf"))
        Return Result
    End Function
    Public Shared Function ProcessExpensesPerResponsible(CashFlowID As Long, InitialDate As Date, FinalDate As Date, ResponsibleShortName As Boolean) As ReportResult
        Dim Session = Locator.GetInstance(Of Session)
        Dim WbMain As New XLWorkbook
        Dim WsData As IXLWorksheet = WbMain.Worksheets.Add("Dados")
        Dim WsPivot As IXLWorksheet = WbMain.Worksheets.Add("Tabela Dinâmica")
        Dim PvTable As IXLPivotTable
        Dim Converter As ExcelToPdfConverter
        Dim TableData As DataTable
        Dim Result As New ReportResult
        Dim Logo As Drawings.IXLPicture
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using ComMonth As New MySqlCommand(My.Resources.SetBrazilianDatabaseMonthNames, Con)
                    ComMonth.Transaction = Tra
                    ComMonth.ExecuteNonQuery()
                End Using
                Using Cmd As New MySqlCommand(My.Resources.CashReportExpensesPerResponsible, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@initialdate", InitialDate)
                    Cmd.Parameters.AddWithValue("@finaldate", FinalDate)
                    Cmd.Parameters.AddWithValue("@cashflowid", CashFlowID)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        TableData = New DataTable
                        Adp.Fill(TableData)
                    End Using
                End Using
                Tra.Commit()
            End Using
        End Using
        If TableData.Rows.Count = 0 Then Return Nothing
        WsData.ShowGridLines = False
        If File.Exists(Session.Setting.Company.LogoLocation) Then
            Logo = WsData.AddPicture(New MemoryStream(File.ReadAllBytes(Session.Setting.Company.LogoLocation)))
            Logo.MoveTo(WsData.Cell("A1"), New Point(0, 5))
            Logo.WithSize(156, 57)
        End If
        WsData.Cell(4, 1).InsertTable(TableData, "TableData").Theme = XLTableTheme.TableStyleLight1
        If ResponsibleShortName Then
            WsData.Column(7).Delete()
        Else
            WsData.Column(8).Delete()
        End If
        WsData.Rows.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
        WsData.Column(1).Width = 18
        WsData.Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsData.Column(2).Hide()
        WsData.Column(3).Hide()
        WsData.Column(4).Style.Alignment.WrapText = True
        WsData.Column(4).Width = 25
        WsData.Column(5).Width = 18
        WsData.Column(5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsData.Column(6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsData.Column(6).Width = 18
        WsData.Column(7).Style.Alignment.WrapText = True
        WsData.Column(7).Width = 25
        WsData.Column(8).Style.NumberFormat.NumberFormatId = 2
        WsData.Column(8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
        WsData.Column(8).Width = 18
        WsData.Rows.Height = 18
        WsData.Range(1, 1, 1, 8).Merge()
        WsData.Range(1, 1, 1, 8).Value = "RELATÓRIO DE CAIXA POR RESPONSÁVEL"
        WsData.Range(1, 1, 1, 8).Style.Font.FontSize = 12
        WsData.Range(1, 1, 1, 8).Style.Font.Bold = True
        WsData.Range(1, 1, 1, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsData.Range(2, 1, 2, 8).Merge()
        WsData.Range(2, 1, 2, 8).Value = "PERÍODO: " & InitialDate.ToString("dd/MM/yyyy") & " À " & FinalDate.ToString("dd/MM/yyyy")
        WsData.Range(2, 1, 2, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsData.Range(2, 1, 2, 8).Style.Font.Bold = True
        WsData.Range(3, 1, 3, 8).Merge()
        PvTable = WsPivot.PivotTables.Add("PivotTable", WsPivot.Cell(4, 1), WsData.Table("TableData").AsRange())
        If ResponsibleShortName Then
            PvTable.RowLabels.Add("NOME CURTO RESPONSÁVEL")
        Else
            PvTable.RowLabels.Add("NOME RESPONSÁVEL")
        End If
        PvTable.RowLabels.Add("ANO")
        PvTable.RowLabels.Add("MÊS")
        PvTable.RowLabels.Add("CATEGORIA")
        PvTable.RowLabels.Add("DESCRIÇÃO")
        PvTable.Values.Add("VALOR", "VALOR")
        PvTable.RowHeaderCaption = "RESPONSÁVEL"
        PvTable.Values(0).NumberFormat.NumberFormatId = 2
        For Each Label In PvTable.RowLabels
            Label.Collapsed = True
            Label.InsertBlankLines = False
        Next Label
        PvTable.Theme = XLPivotTableTheme.PivotStyleLight15
        WsPivot.ShowGridLines = False
        WsPivot.Column(1).Width = 45
        WsPivot.Column(2).Width = 15
        WsPivot.Rows.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        WsPivot.Range(1, 1, 1, 2).Merge()
        WsPivot.Range(1, 1, 1, 2).Value = "RELATÓRIO DE CAIXA POR RESPONSÁVEL"
        WsPivot.Range(1, 1, 1, 2).Style.Font.FontSize = 12
        WsPivot.Range(1, 1, 1, 2).Style.Font.Bold = True
        WsPivot.Range(1, 1, 1, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsPivot.Range(2, 1, 2, 2).Merge()
        WsPivot.Range(2, 1, 2, 2).Value = "PERÍODO: " & InitialDate.ToString("dd/MM/yyyy") & " À " & FinalDate.ToString("dd/MM/yyyy")
        WsPivot.Range(2, 1, 2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        WsPivot.Range(2, 1, 2, 2).Style.Font.Bold = True
        WsPivot.Range(3, 1, 3, 2).Merge()
        WsPivot.Rows.Height = 20
        WsPivot.Rows(3).Height = 10
        WbMain.Worksheets(1).TabSelected = True
        WsData.PageSetup.PagesWide = 1
        WsData.PageSetup.PagesTall = False
        WsData.PageSetup.CenterHorizontally = True
        WsPivot.PageSetup.PagesWide = 1
        WsPivot.PageSetup.PagesTall = False
        WsPivot.PageSetup.CenterHorizontally = True
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory(), Path.GetRandomFileName())
        WbMain.SaveAs(Result.FilePath & ".xlsx")
        PvTable.ColumnLabels.ToList().ForEach(Function(X) X.SetCollapsed(True))
        PvTable.RowLabels.ToList().ForEach(Function(X) X.SetCollapsed(True))
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Caixa - " & InitialDate.ToString("dd.MM.yyyy" & " a " & FinalDate.ToString("dd.MM.yyyy"))
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Despesas Por Responsável.pdf"))
        Return Result
    End Function
End Class
