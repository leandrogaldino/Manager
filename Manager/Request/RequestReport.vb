Imports System.IO
Imports ClosedXML
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
Imports Syncfusion.ExcelToPdfConverter
Public Class RequestReport
    Public Shared Function ProcessRequestSheet(Request As Request, ShowCode As Boolean, ShowReturned As Boolean, ShowApplied As Boolean, ShowLossed As Boolean, ShowPending As Boolean) As ReportResult
        Dim Wb As New Excel.XLWorkbook
        Dim WsReport As Excel.IXLWorksheet = Wb.Worksheets.Add("Relatório")
        Dim Row As Integer = 6
        Dim Converter As ExcelToPdfConverter
        Dim Result As New ReportResult
        WsReport.ShowGridLines = False
        WsReport.Rows.Height = 20
        WsReport.Rows.Style.Alignment.Vertical = Excel.XLAlignmentVerticalValues.Center
        WsReport.Columns(1).Width = 16
        WsReport.Column(1).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Columns(2).Width = 40
        WsReport.Column(2).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Left
        WsReport.Columns(3).Width = 13
        WsReport.Column(3).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Columns(4).Width = 13
        WsReport.Column(4).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Columns(5).Width = 13
        WsReport.Column(5).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Columns(6).Width = 13
        WsReport.Column(6).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Columns(7).Width = 13
        WsReport.Column(7).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Range(1, 1, 1, 7).Merge()
        WsReport.Range(1, 1, 1, 7).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Range(1, 1, 1, 7).Style.Font.FontSize = 12
        WsReport.Range(1, 1, 1, 7).Style.Font.Bold = True
        WsReport.Range(2, 1, 2, 7).Merge()
        WsReport.Range(2, 1, 2, 7).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Left
        WsReport.Range(3, 1, 3, 7).Merge()
        WsReport.Range(3, 1, 3, 7).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Left
        WsReport.Range(4, 1, 4, 7).Merge()
        WsReport.Range(4, 1, 4, 7).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Left
        WsReport.Cell(5, 1).Value = "CÓDIGO"
        WsReport.Cell(5, 1).Style.Font.Bold = True
        WsReport.Cell(5, 2).Value = "ITEM"
        WsReport.Cell(5, 2).Style.Font.Bold = True
        WsReport.Cell(5, 3).Value = "RETIRADO"
        WsReport.Cell(5, 3).Style.Font.Bold = True
        WsReport.Cell(5, 4).Value = "DEVOLVIDO"
        WsReport.Cell(5, 4).Style.Font.Bold = True
        WsReport.Cell(5, 5).Value = "APLICADO"
        WsReport.Cell(5, 5).Style.Font.Bold = True
        WsReport.Cell(5, 6).Value = "PERDIDO"
        WsReport.Cell(5, 6).Style.Font.Bold = True
        WsReport.Cell(5, 7).Value = "ACERTAR"
        WsReport.Cell(5, 7).Style.Font.Bold = True
        WsReport.Range(2, 1, 5, 7).Style.Fill.BackgroundColor = Excel.XLColor.Silver
        For Each Item As RequestItem In Request.Items
            WsReport.Cell(Row, 1).Value = Item.Code
            WsReport.Cell(Row, 2).Value = Item.ItemNameOrProduct
            WsReport.Cell(Row, 3).Value = Item.Taked
            WsReport.Cell(Row, 3).Style.NumberFormat.NumberFormatId = 2
            WsReport.Cell(Row, 4).Value = Item.Returned
            WsReport.Cell(Row, 4).Style.NumberFormat.NumberFormatId = 2
            WsReport.Cell(Row, 5).Value = Item.Applied
            WsReport.Cell(Row, 5).Style.NumberFormat.NumberFormatId = 2
            WsReport.Cell(Row, 6).Value = Item.Lossed
            WsReport.Cell(Row, 6).Style.NumberFormat.NumberFormatId = 2
            WsReport.Cell(Row, 7).Value = Item.Pending
            WsReport.Cell(Row, 7).Style.NumberFormat.NumberFormatId = 2
            Row += 1
        Next Item
        WsReport.Range(2, 1, Row - 1, 7).Style.Border.OutsideBorder = Excel.XLBorderStyleValues.Thin
        WsReport.Range(2, 1, Row - 1, 7).Style.Border.OutsideBorderColor = Excel.XLColor.DarkGray
        WsReport.Range(2, 1, Row - 1, 7).Style.Border.InsideBorder = Excel.XLBorderStyleValues.Thin
        WsReport.Range(2, 1, Row - 1, 7).Style.Border.InsideBorderColor = Excel.XLColor.DarkGray
        WsReport.Range(Row, 1, Row, 7).Merge()
        WsReport.Range(Row, 1, Row, 7).Value = "EMITIDO DIA " & Today.ToString("dd/MM/yyyy")
        WsReport.Range(Row, 1, Row, 7).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Right
        WsReport.Range(Row, 1, Row, 7).Style.Font.FontSize = 8
        If Not ShowCode Then WsReport.Search("CÓDIGO")(0).WorksheetColumn.Delete()
        If Not ShowReturned Then WsReport.Search("DEVOLVIDO")(0).WorksheetColumn.Delete()
        If Not ShowApplied Then WsReport.Search("APLICADO")(0).WorksheetColumn.Delete()
        If Not ShowLossed Then WsReport.Search("PERDIDO")(0).WorksheetColumn.Delete()
        If Not ShowPending Then WsReport.Search("ACERTAR")(0).WorksheetColumn.Delete()
        WsReport.Range(1, 1, 1, 1).Value = "REQUISIÇÃO " & Request.ID
        WsReport.Range(2, 1, 2, 1).Value = "DATA: " & Request.Creation.ToString("dd/MM/yyyy")
        WsReport.Cell(2, 1).CreateRichText.Substring(0, 5).Bold = True
        WsReport.Range(3, 1, 3, 1).Value = "DESTINO: " & Request.Destination
        WsReport.Cell(3, 1).CreateRichText.Substring(0, 8).Bold = True
        WsReport.Range(4, 1, 4, 1).Value = "RESPONSÁVEL: " & Request.Responsible
        WsReport.Cell(4, 1).CreateRichText.Substring(0, 12).Bold = True
        WsReport.PageSetup.PagesWide = 1
        WsReport.PageSetup.PagesTall = False
        WsReport.PageSetup.CenterHorizontally = True
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        Result.ReportName = $"Folha de Requisição {Request.ID}"
        Wb.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Requisição " & Request.ID))
        Return Result
    End Function
    Public Shared Function ProcessPendingItems(InitialDate As String, FinalDate As String, ShowResponsible As Boolean, ShowDestination As Boolean) As ReportResult
        Dim Wb As New Excel.XLWorkbook
        Dim WsReport As Excel.IXLWorksheet = Wb.Worksheets.Add("Relatório")
        Dim TableData As DataTable
        Dim Row As Integer = 3
        Dim Converter As ExcelToPdfConverter
        Dim Result As New ReportResult
        If Not IsDate(InitialDate) Then InitialDate = "0001-01-01"
        If Not IsDate(FinalDate) Then FinalDate = "9999-12-31"
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.RequestReportPendingItems, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@initialdate", CDate(InitialDate))
                    Cmd.Parameters.AddWithValue("@finaldate", CDate(FinalDate))
                    Using Adp As New MySqlDataAdapter(Cmd)
                        TableData = New DataTable
                        Adp.Fill(TableData)
                    End Using
                End Using
                Tra.Commit()
            End Using
        End Using
        WsReport.ShowGridLines = False
        WsReport.Rows.Style.Alignment.Vertical = Excel.XLAlignmentVerticalValues.Center
        WsReport.Columns(1).Width = 11
        WsReport.Column(1).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Columns(2).Width = 11
        WsReport.Column(2).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Columns(3).Width = 15
        WsReport.Column(3).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Column(3).Style.NumberFormat.Format = "@"
        WsReport.Columns(4).Width = 30
        WsReport.Column(4).Style.NumberFormat.Format = "@"
        WsReport.Columns(5).Width = 15
        WsReport.Column(5).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Column(5).Style.NumberFormat.NumberFormatId = 2
        WsReport.Columns(6).Width = 30
        WsReport.Column(6).Style.NumberFormat.Format = "@"
        WsReport.Columns(7).Width = 30
        WsReport.Column(7).Style.NumberFormat.Format = "@"
        WsReport.Range(1, 1, 1, 7).Merge().Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
        WsReport.Range(1, 1, 1, 7).Style.Border.BottomBorder = Excel.XLBorderStyleValues.Thin
        WsReport.Range(1, 1, 1, 7).Style.Border.BottomBorderColor = Excel.XLColor.DimGray
        WsReport.Range(1, 1, 1, 7).Value = "RELATÓRIO DE PEÇAS DE PENDENTES DA REQUISIÇÃO"
        WsReport.Range(1, 1, 1, 7).Style.Font.FontSize = 12
        WsReport.Row(1).Height = 20
        WsReport.Range(2, 1, 2, 1).Value = "REQUISIÇÃO"
        WsReport.Row(2).Height = 20
        WsReport.Range(2, 2, 2, 2).Value = "DATA"
        WsReport.Range(2, 3, 2, 3).Value = "CÓDIGO"
        WsReport.Range(2, 4, 2, 4).Value = "ITEM"
        WsReport.Range(2, 5, 2, 5).Value = "QTD"
        WsReport.Range(2, 6, 2, 6).Value = "RESPONSÁVEL"
        WsReport.Range(2, 7, 2, 7).Value = "DESTINO"
        WsReport.Range(2, 1, 2, 7).Style.Border.BottomBorder = Excel.XLBorderStyleValues.Thin
        WsReport.Range(2, 1, 2, 7).Style.Border.BottomBorderColor = Excel.XLColor.DimGray
        WsReport.Range(1, 1, 2, 7).Style.Font.Bold = True
        WsReport.Range(1, 1, 2, 7).Style.Fill.BackgroundColor = Excel.XLColor.Silver
        For Each r As DataRow In TableData.Rows
            WsReport.Row(Row).Height = 20
            WsReport.Range(Row, 1, Row, 7).Style.Border.BottomBorder = Excel.XLBorderStyleValues.Thin
            WsReport.Range(Row, 1, Row, 7).Style.Border.BottomBorderColor = Excel.XLColor.DimGray
            WsReport.Range(Row, 1, Row, 1).Value = r.Item("id")
            WsReport.Range(Row, 2, Row, 2).Value = r.Item("creation").ToString
            WsReport.Range(Row, 3, Row, 3).Value = r.Item("code").ToString
            WsReport.Range(Row, 4, Row, 4).Value = r.Item("part").ToString
            WsReport.Range(Row, 5, Row, 5).Value = r.Item("qty")
            WsReport.Range(Row, 6, Row, 6).Value = r.Item("responsible")
            WsReport.Range(Row, 7, Row, 7).Value = r.Item("destination")
            Row += 1
        Next r
        WsReport.Row(Row).Height = 5
        Row += 1
        WsReport.Range(Row, 1, Row, 7).Merge()
        WsReport.Range(Row, 1, Row, 7).Value = "EMITIDO DIA " & Today.ToString("dd/MM/yyyy")
        WsReport.Range(Row, 1, Row, 7).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Right
        WsReport.Range(Row, 1, Row, 7).Style.Font.FontSize = 8
        WsReport.Range(2, 1, Row - 2, 7).Style.Border.InsideBorder = Excel.XLBorderStyleValues.Thin
        WsReport.Range(2, 1, Row - 2, 7).Style.Border.InsideBorderColor = Excel.XLColor.Gainsboro
        WsReport.Range(2, 1, Row - 2, 7).Style.Border.OutsideBorder = Excel.XLBorderStyleValues.Thin
        WsReport.Range(2, 1, Row - 2, 7).Style.Border.OutsideBorderColor = Excel.XLColor.Gainsboro
        If Not ShowResponsible Then
            WsReport.Column(6).Hide()
        End If
        If Not ShowDestination Then
            WsReport.Column(7).Hide()
        End If
        If ShowDestination Or ShowResponsible Then
            WsReport.PageSetup.PageOrientation = Excel.XLPageOrientation.Landscape
        Else
            WsReport.PageSetup.PageOrientation = Excel.XLPageOrientation.Portrait
        End If
        WsReport.PageSetup.PagesWide = 1
        WsReport.PageSetup.PagesTall = False
        WsReport.PageSetup.CenterHorizontally = True
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        Wb.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Itens Pendentes da Requisição"
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Itens Pendentes da Requisição.pdf"))
        Return Result
    End Function
End Class
