Imports System.IO
Imports ClosedXML.Excel
Imports ControlLibrary
Imports ManagerCore
Imports Syncfusion.ExcelToPdfConverter
Public Class EvaluationReport
    Public Shared Function EvaluationSheet(ReportingEvaluation As Evaluation) As ReportResult
        Dim Session = Locator.GetInstance(Of Session)
        Dim WbReport As New XLWorkbook
        Dim WsReport As IXLWorksheet = WbReport.Worksheets.Add("Relatório de Atendimento")
        Dim Converter As ExcelToPdfConverter
        Dim Result As New ReportResult
        Dim Logo As Drawings.IXLPicture
        WsReport.ShowGridLines = False
        WsReport.Rows.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        WsReport.Rows.Style.NumberFormat.Format = "@"
        WsReport.Style.Font.FontName = "Century Gothic"
        WsReport.Style.Font.FontSize = 10
        WsReport.RowHeight = 18
        WsReport.Columns(1, 7).Width = 15
        WsReport.Range(1, 7, 3, 7).Merge()
        WsReport.Range(1, 7, 1, 7).Value = ReportingEvaluation.EvaluationNumber
        WsReport.Range(1, 7, 1, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        If File.Exists(Session.Setting.Company.LogoLocation) Then
            Using Stream As New MemoryStream(File.ReadAllBytes(Session.Setting.Company.LogoLocation))
                Logo = WsReport.AddPicture(Stream)
                Logo.MoveTo(WsReport.Cell("A1"), New Point(0, 5))
                Logo.WithSize(156, 57)
            End Using
        End If



        WsReport.PageSetup.PagesWide = 1
        WsReport.PageSetup.PagesTall = False
        WsReport.PageSetup.CenterHorizontally = True
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        WbReport.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Relatório de Atendimento - " & ReportingEvaluation.Customer.ShortName
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Relatório de Atendimento.pdf"))
        Return Result
    End Function
End Class
