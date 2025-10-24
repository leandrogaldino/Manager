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
        WsReport.Rows.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
        WsReport.Rows.Style.NumberFormat.SetFormat("@")
        WsReport.Style.Font.SetFontName("Century Gothic")
        WsReport.Style.Font.SetFontSize(10)
        WsReport.RowHeight = 18
        WsReport.Columns(1, 7).Width = 15
        WsReport.Range(1, 7, 3, 7).Merge()
        WsReport.Range(1, 7, 1, 7).SetValue(ReportingEvaluation.EvaluationNumber)
        WsReport.Range(1, 7, 1, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        If File.Exists(Session.Setting.Company.LogoLocation) Then
            Using Stream As New MemoryStream(File.ReadAllBytes(Session.Setting.Company.LogoLocation))
                Logo = WsReport.AddPicture(Stream)
                Logo.MoveTo(WsReport.Cell("A1"), New Point(0, 5))
                Logo.WithSize(156, 57)
            End Using
        End If
        WsReport.Range(4, 1, 4, 7).Merge()
        WsReport.Range(4, 1, 4, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(4, 1, 4, 7).SetValue("RELATÓRIO DE ATENDIMENTO")
        WsReport.Range(4, 1, 4, 7).Style.Font.SetBold(True)
        WsReport.Range(4, 1, 4, 7).Style.Font.SetFontSize(12)
        WsReport.Rows(5).Height = 5
        WsReport.Range(6, 1, 6, 7).Merge()
        WsReport.Range(6, 1, 6, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(6, 1, 6, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(6, 1).CreateRichText().
            AddText("CLIENTE: ").SetBold().
            AddText(ReportingEvaluation.Customer.ShortName)
        WsReport.Range(7, 1, 7, 7).Merge()
        WsReport.Range(7, 1, 7, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(7, 1, 7, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(7, 1).CreateRichText().
            AddText("CIDADE: ").SetBold().
            AddText(ReportingEvaluation.Customer.Addresses.First(Function(x) x.IsMainAddress).City.Name).
            AddText("      ").
            AddText("UF: ").SetBold().
            AddText(ReportingEvaluation.Customer.Addresses.First(Function(x) x.IsMainAddress).City.State.ShortName).
            AddText("      ").
            AddText("CONTATO: ").SetBold().
            AddText(ReportingEvaluation.Customer.Contacts.First(Function(x) x.IsMainContact).Name).
            AddText("      ").
            AddText("FONE: ").SetBold().
            AddText(ReportingEvaluation.Customer.Contacts.First(Function(x) x.IsMainContact).Phone)
        WsReport.Range(8, 1, 8, 7).Merge()
        WsReport.Range(8, 1, 8, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(8, 1, 8, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(8, 1).CreateRichText().
            AddText("TIPO DE VISITA: ").SetBold().
            AddText(EnumHelper.GetEnumDescription(ReportingEvaluation.CallType)).
            AddText("      ").
            AddText("DATA: ").SetBold().
            AddText(ReportingEvaluation.EvaluationDate.ToString("dd/MM/yyyy")).
            AddText("    ").
            AddText("INÍCIO: ").SetBold().
            AddText(ReportingEvaluation.StartTime.ToString("hh\:mm")).
            AddText("      ").AddText("FIM: ").SetBold().
            AddText(ReportingEvaluation.EndTime.ToString("hh\:mm"))
        WsReport.Rows(9).Height = 5
        WsReport.Range(10, 1, 10, 7).Merge()
        WsReport.Range(10, 1, 10, 7).SetValue("INFORMAÇÕES DO COMPRESSOR")
        WsReport.Range(10, 1, 10, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(10, 1, 10, 7).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
        WsReport.Range(10, 1, 10, 7).Style.Font.SetBold(True)
        WsReport.Range(10, 1, 10, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(10, 1, 10, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(11, 1).SetValue("COMPRESSOR")
        WsReport.Cell(11, 2).SetValue("HORÍMETRO")
        WsReport.Cell(11, 3).SetValue("Nº SÉRIE/PAT.")
        WsReport.Cell(11, 4).SetValue("PRESSÃO TRAB.")
        WsReport.Cell(11, 5).SetValue("TEMP. (ºC)")
        WsReport.Cell(11, 6).SetValue("UND. COMP.")
        WsReport.Cell(11, 7).SetValue("REGIME TRAB.")
        WsReport.Range(11, 1, 11, 7).Style.Font.Bold = True
        WsReport.Range(11, 1, 11, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(11, 1, 11, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
        WsReport.Range(11, 1, 11, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(11, 1, 11, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(11, 1, 11, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(11, 1, 11, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
        WsReport.Cell(12, 1).SetValue(ReportingEvaluation.Compressor.CompressorName)
        WsReport.Cell(12, 2).SetValue(FormatNumber(ReportingEvaluation.Horimeter, 2, TriState.True))
        WsReport.Cell(12, 3).SetValue(If(Not String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), ReportingEvaluation.Compressor.SerialNumber, ReportingEvaluation.Compressor.Patrimony))
        WsReport.Cell(12, 4).SetValue($"{ReportingEvaluation.Pressure}BAR")
        WsReport.Cell(12, 5).SetValue($"{ReportingEvaluation.Temperature}ºC")
        WsReport.Cell(12, 6).SetValue(ReportingEvaluation.UnitName)
        WsReport.Cell(12, 7).SetValue(ReportingEvaluation.AverageWorkLoad)
        WsReport.Range(12, 1, 12, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
        WsReport.Rows(13).Height = 5


        WsReport.Range(14, 1, 14, 7).Merge()
        WsReport.Range(14, 1, 14, 7).SetValue("HORAS RESTANTES PARA SUBSTITUIÇÃO")
        WsReport.Range(14, 1, 14, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(14, 1, 14, 7).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
        WsReport.Range(14, 1, 14, 7).Style.Font.SetBold(True)
        WsReport.Range(14, 1, 14, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(14, 1, 14, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(15, 1).SetValue("RECONSTRUIR UND.")
        WsReport.Cell(15, 2).SetValue("FILTRO AR")
        WsReport.Cell(15, 3).SetValue("FILTRO ÓLEO")
        WsReport.Cell(15, 4).SetValue("SEPARADOR")
        WsReport.Cell(15, 5).SetValue("LUB. MOTOR")
        WsReport.Cell(15, 6).SetValue("ÓLEO")
        WsReport.Cell(15, 7).SetValue("TIPO ÓLEO")
        WsReport.Range(15, 1, 15, 7).Style.Font.Bold = True
        WsReport.Range(15, 1, 15, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(15, 1, 15, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
        WsReport.Range(15, 1, 15, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(15, 1, 15, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(15, 1, 15, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(15, 1, 15, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
        WsReport.Cell(16, 1).SetValue(If(ReportingEvaluation.Compressor.UnitCapacity <= ReportingEvaluation.Horimeter, "SIM", "NÃO"))

        WsReport.Cell(16, 2).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelable.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.AirFilter).CurrentCapacity, 0, TriState.True))
        WsReport.Cell(16, 3).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelable.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.OilFilter).CurrentCapacity, 0, TriState.True))
        WsReport.Cell(16, 4).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelable.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Separator).CurrentCapacity, 0, TriState.True))
        WsReport.Cell(16, 5).SetValue("lub motor")
        WsReport.Cell(16, 6).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelable.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Oil).CurrentCapacity, 0, TriState.True))
        Dim OilCapacity As Integer = ReportingEvaluation.WorkedHourControlledSelable.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Oil).PersonCompressorSellable.Capacity
        Dim OilType As String = If(OilCapacity <= 1000, "MINERAL", If(OilCapacity <= 4000, "SEMI SINTÉTICO", "SINTÉTICO"))
        WsReport.Cell(16, 7).SetValue(OilType)

        WsReport.Range(16, 1, 16, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(16, 1, 16, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(16, 1, 16, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(16, 1, 16, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(16, 1, 16, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)

        WsReport.Range(15, 1, 16, 1).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
        WsReport.Range(15, 7, 16, 7).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
        WsReport.Cell(15, 1).Style.Font.SetFontSize(8)

        WsReport.Rows(17).Height = 5



        WsReport.PageSetup.SetPagesWide(1)
        WsReport.PageSetup.SetPagesTall(False)
        WsReport.PageSetup.SetCenterHorizontally(True)
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        WbReport.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Relatório de Atendimento - " & ReportingEvaluation.Customer.ShortName
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Relatório de Atendimento.pdf"))
        Return Result
    End Function
End Class
