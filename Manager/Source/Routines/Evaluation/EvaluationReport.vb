Imports System.IO
Imports ClosedXML.Excel
Imports ControlLibrary
Imports ControlLibrary.Extensions
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
        Dim Row As Integer = 14
        Dim Address As String
        Dim Phones As String
        Dim LastReplace As Date?
        Dim CurrentCapacityOnReplace As Integer?
        Dim LastReplaceCapacity As Integer?
        WsReport.ShowGridLines = False
        WsReport.Rows.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
        WsReport.Rows.Style.NumberFormat.SetFormat("@")
        WsReport.Style.Font.SetFontName("Century Gothic")
        WsReport.Style.Font.SetFontSize(10)
        WsReport.RowHeight = 18
        WsReport.Columns(1, 7).Width = 15
        WsReport.Rows(1).Height = 50
        WsReport.Range(1, 1, 1, 6).Merge()
        WsReport.Range(1, 1, 1, 6).SetValue("RELATÓRIO DE ATENDIMENTO".PadLeft(85, " "))
        WsReport.Range(1, 1, 1, 6).Style.Font.SetBold(True)
        WsReport.Range(1, 1, 1, 6).Style.Font.SetFontSize(14)
        WsReport.Cell(1, 7).CreateRichText.
            AddText("Nº ").SetBold(True).SetFontSize(14).
            AddText(ReportingEvaluation.EvaluationNumber).SetFontSize(12)
        WsReport.Range(1, 7, 1, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        If File.Exists(Session.Setting.Company.LogoLocation) Then
            Using Stream As New MemoryStream(File.ReadAllBytes(Session.Setting.Company.LogoLocation))
                Logo = WsReport.AddPicture(Stream)
                Logo.MoveTo(WsReport.Cell(1, 1), New Point(0, 5))
                Logo.WithSize(156, 57)
            End Using
        End If
        WsReport.Rows(2).Height = 5
        WsReport.Range(3, 1, 3, 7).Merge()
        WsReport.Range(3, 1, 3, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(3, 1, 3, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(3, 1).CreateRichText().
            AddText("CLIENTE: ").SetBold().
            AddText(ReportingEvaluation.Customer.ShortName)
        WsReport.Range(4, 1, 4, 7).Merge()
        WsReport.Range(4, 1, 4, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(4, 1, 4, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(4, 1).CreateRichText().
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
        WsReport.Range(5, 1, 5, 7).Merge()
        WsReport.Range(5, 1, 5, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(5, 1, 5, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Cell(5, 1).CreateRichText().
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
        WsReport.Rows(6).Height = 5
        CreateHeader(WsReport, 7, "INFORMAÇÕES DO COMPRESSOR")
        WsReport.Cell(8, 1).SetValue("COMPRESSOR")
        WsReport.Cell(8, 2).SetValue("HORÍMETRO")
        WsReport.Cell(8, 3).SetValue("Nº SÉRIE/PAT.")
        WsReport.Cell(8, 4).SetValue("PRESSÃO TRAB.")
        WsReport.Cell(8, 5).SetValue("TEMP. (ºC)")
        WsReport.Cell(8, 6).SetValue("UND. COMP.")
        WsReport.Cell(8, 7).SetValue("REGIME TRAB.")
        WsReport.Range(8, 1, 8, 7).Style.Font.Bold = True
        WsReport.Range(8, 1, 8, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(8, 1, 8, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
        WsReport.Range(8, 1, 8, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(8, 1, 8, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(8, 1, 8, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(8, 1, 8, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
        WsReport.Cell(9, 1).SetValue(ReportingEvaluation.Compressor.CompressorName)
        WsReport.Cell(9, 2).SetValue(FormatNumber(ReportingEvaluation.Horimeter, 2, TriState.True))
        WsReport.Cell(9, 3).SetValue(If(Not String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), ReportingEvaluation.Compressor.SerialNumber, ReportingEvaluation.Compressor.Patrimony))
        WsReport.Cell(9, 4).SetValue($"{ReportingEvaluation.Pressure} BAR")
        WsReport.Cell(9, 5).SetValue($"{ReportingEvaluation.Temperature} ºC")
        WsReport.Cell(9, 6).SetValue(ReportingEvaluation.UnitName)
        WsReport.Cell(9, 7).SetValue(ReportingEvaluation.AverageWorkLoad)
        WsReport.Range(9, 1, 9, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(9, 1, 9, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(9, 1, 9, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(9, 1, 9, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(9, 1, 9, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
        WsReport.Rows(10).Height = 5
        CreateHeader(WsReport, 11, "HORAS RESTANTES PARA SUBSTITUIÇÃO")
        WsReport.Cell(12, 1).Style.Font.SetFontSize(8)
        WsReport.Cell(12, 1).SetValue("RECONSTRUIR UND.")
        WsReport.Cell(12, 2).SetValue("FILTRO AR")
        WsReport.Cell(12, 3).SetValue("FILTRO ÓLEO")
        WsReport.Cell(12, 4).SetValue("SEPARADOR")
        WsReport.Cell(12, 5).SetValue("LUB. MOTOR")
        WsReport.Cell(12, 6).SetValue("ÓLEO")
        WsReport.Cell(12, 7).SetValue("TIPO ÓLEO")

        WsReport.Range(12, 1, 12, 7).Style.Font.Bold = True
        WsReport.Range(12, 1, 12, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(12, 1, 12, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(12, 1, 12, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
        WsReport.Cell(13, 1).SetValue(If(ReportingEvaluation.Compressor.UnitCapacity <= ReportingEvaluation.Horimeter, "SIM", "NÃO"))
        WsReport.Cell(13, 2).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.AirFilter).CurrentCapacity, 0, TriState.True))
        WsReport.Cell(13, 3).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.OilFilter).CurrentCapacity, 0, TriState.True))
        WsReport.Cell(13, 4).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Separator).CurrentCapacity, 0, TriState.True))

        Dim HasGreasing As Boolean = ReportingEvaluation.WorkedHourControlledSelables.Any(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Greasing)

        WsReport.Cell(13, 5).SetValue(If(HasGreasing, FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Greasing).CurrentCapacity, 0, TriState.True), "N/A"))
        WsReport.Cell(13, 6).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Oil).CurrentCapacity, 0, TriState.True))
        Dim OilCapacity As Integer = ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Oil).PersonCompressorSellable.Capacity
        Dim OilType As String = If(OilCapacity <= 1000, "MINERAL", If(OilCapacity <= 4000, "SEMI SINTÉTICO", "SINTÉTICO"))
        WsReport.Cell(13, 7).SetValue(OilType)
        WsReport.Range(13, 1, 13, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(13, 1, 13, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(13, 1, 13, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
        WsReport.Range(13, 1, 13, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
        WsReport.Range(13, 1, 13, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
        WsReport.Range(13, 1, 13, 1).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
        WsReport.Range(13, 7, 13, 7).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)

        If ReportingEvaluation.ElapsedDayControlledSellables.Any(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Coalescent) Then
            WsReport.Rows(14).Height = 5
            CreateHeader(WsReport, 15, "FILTROS COALESCENTES")
            WsReport.Range(16, 1, 19, 3).Merge()
            WsReport.Cell(16, 1).SetValue("ELEMENTO")
            WsReport.Cell(16, 4).SetValue("ÚLTIMA TROCA")
            WsReport.Cell(16, 5).SetValue("PROX. TROCA")
            WsReport.Cell(16, 6).SetValue("CAPACIDADE")
            WsReport.Cell(16, 7).SetValue("UTILIZADO")
            WsReport.Range(16, 1, 16, 7).Style.Font.Bold = True
            WsReport.Range(16, 1, 16, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            WsReport.Range(16, 1, 16, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
            WsReport.Range(16, 1, 16, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
            WsReport.Range(16, 1, 16, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
            WsReport.Range(16, 1, 16, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
            WsReport.Range(16, 1, 16, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
            Row = 17

            Dim FirstEvaluationDate As Date

            FirstEvaluationDate = Evaluation.GetFirstEvaluationDate(ReportingEvaluation.Compressor)
            For Each Coalescent In ReportingEvaluation.ElapsedDayControlledSellables.Where(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Coalescent)
                WsReport.Range(Row, 1, Row, 3).Merge()
                WsReport.Cell(Row, 1).SetValue(Coalescent.Name)
                LastReplace = Evaluation.GetLastEvaluationReplacedSellableDate(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
                LastReplaceCapacity = Evaluation.GetLastEvaluationReplacedSellableCapacity(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
                If LastReplace.HasValue Then
                    WsReport.Cell(Row, 4).SetValue(LastReplace.Value.ToString("dd/MM/yyyy"))
                    WsReport.Cell(Row, 5).SetValue(ReportingEvaluation.EvaluationDate.AddDays(Coalescent.CurrentCapacity).ToString("dd/MM/yyyy"))
                Else
                    WsReport.Cell(Row, 4).SetValue("N/A")

                    WsReport.Cell(Row, 5).SetValue(FirstEvaluationDate.AddDays(Coalescent.CurrentCapacity).ToString("dd/MM/yyyy"))
                End If
                WsReport.Cell(Row, 6).SetValue(Coalescent.CurrentCapacity)
                CurrentCapacityOnReplace = Evaluation.GetLastEvaluationReplacedSellableCapacity(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
                If CurrentCapacityOnReplace.HasValue Then
                    WsReport.Cell(Row, 7).SetValue(CurrentCapacityOnReplace.Value - Coalescent.CurrentCapacity)
                Else
                    WsReport.Cell(Row, 7).SetValue((ReportingEvaluation.EvaluationDate - FirstEvaluationDate).Days)
                End If
                WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
                Row += 1
            Next Coalescent
            WsReport.Rows(Row).Height = 5
            Row += 1
        End If
        If ReportingEvaluation.ReplacedSellables.Any() Then
            WsReport.Rows(Row).Height = 5
            Row += 1
            CreateHeader(WsReport, Row, "PEÇAS SUBSTITUÍDAS/SERVIÇOS EXECUTADOS")
            Row += 1
            WsReport.Cell(Row, 1).SetValue("CÓDIGO")
            WsReport.Range(Row, 2, Row, 6).Merge()
            WsReport.Cell(Row, 2).SetValue("PEÇAS/SERVIÇOS")
            WsReport.Cell(Row, 7).SetValue("QTD.")
            WsReport.Range(Row, 1, Row, 7).Style.Font.Bold = True
            WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            WsReport.Range(Row, 1, Row, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
            WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
            WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
            WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
            WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
            Row += 1
            For Each ReplacedSellable In ReportingEvaluation.ReplacedSellables
                WsReport.Cell(Row, 1).SetValue($"{If(ReplacedSellable.SellableType = SellableType.Product, "P", "S")}{ReplacedSellable.SellableID}")
                WsReport.Range(Row, 2, Row, 6).Merge()
                WsReport.Cell(Row, 2).SetValue(ReplacedSellable.Name)
                WsReport.Cell(Row, 7).SetValue(ReplacedSellable.Quantity)
                WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
                WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
                Row += 1
            Next ReplacedSellable
        End If
        If Not String.IsNullOrEmpty(ReportingEvaluation.TechnicalAdvice) Then
            WsReport.Rows(Row).Height = 5
            Row += 1
            CreateHeader(WsReport, Row, "PARECER TÉCNICO")
            Row += 1
            WsReport.Range(Row, 1, Row + 3, 7).Merge()
            WsReport.Range(Row, 1, Row + 3, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
            WsReport.Range(Row, 1, Row + 3, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
            WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
            WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top)
            WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetWrapText(True)
            WsReport.Cell(Row, 1).SetValue(ReportingEvaluation.TechnicalAdvice)
            Row += 4
            WsReport.Rows(Row).Height = 5
        End If
        Row += 1
        Dim Culture As New System.Globalization.CultureInfo("pt-BR")
        Dim MonthName As String = DateAndTime.MonthName(ReportingEvaluation.EvaluationDate.Month, False)
        MonthName = MonthName.ToUpper(Culture)
        WsReport.Range(Row, 1, Row, 7).Merge()
        WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Cell(Row, 1).SetValue($"AS PARTES DECLARAM ESTAR DE ARCORDO COM ESTE RELATÓRIO, EM {ReportingEvaluation.EvaluationDate.Day} DE {MonthName} DE {ReportingEvaluation.EvaluationDate.Year}.")
        WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetShrinkToFit(True)
        Row += 2
        WsReport.Range(Row, 1, Row + 2, 4).Merge()
        WsReport.Range(Row, 1, Row + 2, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(Row, 1, Row + 2, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
        If File.Exists(ReportingEvaluation.Signature.CurrentFile) Then
            Using Stream As New MemoryStream(File.ReadAllBytes(ReportingEvaluation.Signature.CurrentFile))
                Logo = WsReport.AddPicture(Stream)
                Logo.MoveTo(WsReport.Cell(Row, 1), New Point(0, 5))
                Logo.WithSize(156, 57)
            End Using
        End If
        WsReport.Range(Row, 5, Row + 2, 7).Merge()
        WsReport.Range(Row, 5, Row + 2, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(Row, 5, Row + 2, 7).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
        WsReport.Cell(Row, 5).SetValue(ReportingEvaluation.Technicians(0).Technician.ShortName.ToTitle())
        WsReport.Cell(Row, 5).Style.Font.SetFontName("Brush Script MT")
        WsReport.Cell(Row, 5).Style.Font.SetFontSize(26)
        Row += 3
        WsReport.Range(Row, 1, Row, 4).Merge()
        WsReport.Range(Row, 1, Row, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(Row, 1, Row, 4).Style.Font.SetBold(True)
        WsReport.Cell(Row, 1).SetValue("CLIENTE")
        WsReport.Range(Row, 5, Row, 7).Merge()
        WsReport.Range(Row, 5, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Range(Row, 5, Row, 7).Style.Font.SetBold(True)
        WsReport.Cell(Row, 5).SetValue("TÉCNICO")
        Row += 2
        WsReport.Range(Row, 1, Row, 7).Merge()
        WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        Address = String.Empty
        If Not String.IsNullOrEmpty(Session.Setting.Company.Address.Street) Then Address &= Session.Setting.Company.Address.Street
        If Not String.IsNullOrEmpty(Session.Setting.Company.Address.Complement) Then Address &= $" {Session.Setting.Company.Address.Complement}"
        If Not String.IsNullOrEmpty(Session.Setting.Company.Address.Number) Then Address &= $" Nº {Session.Setting.Company.Address.Number}"
        If Not String.IsNullOrEmpty(Session.Setting.Company.Address.District) Then Address &= $" {Session.Setting.Company.Address.District}"
        Address &= ", "
        If Not String.IsNullOrEmpty(Session.Setting.Company.Address.City) Then Address &= $" {Session.Setting.Company.Address.City}"
        If Not String.IsNullOrEmpty(Session.Setting.Company.Address.State) Then Address &= $"/{Session.Setting.Company.Address.State}"
        Phones = String.Empty
        If Not String.IsNullOrEmpty(Session.Setting.Company.Contact.Phone1) Then Phones &= Session.Setting.Company.Contact.Phone1
        If Not String.IsNullOrEmpty(Session.Setting.Company.Contact.Phone2) Then Phones &= $" | {Session.Setting.Company.Contact.Phone2}"
        If Not String.IsNullOrEmpty(Session.Setting.Company.Contact.CellPhone) Then Phones &= $" | {Session.Setting.Company.Contact.CellPhone}"
        WsReport.Cell(Row, 1).SetValue($"{Address}{If(Not String.IsNullOrWhiteSpace(Phones), $" - {Phones}", String.Empty)}")
        WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetShrinkToFit(True)
        Row += 1
        WsReport.Range(Row, 1, Row, 7).Merge()
        WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        WsReport.Cell(Row, 1).SetValue($"{Session.Setting.Company.Contact.Email}{If(Not String.IsNullOrEmpty(Session.Setting.Company.Contact.Site), $" - {Session.Setting.Company.Contact.Site}", String.Empty)}")
        WsReport.PageSetup.SetPagesWide(1)
        WsReport.PageSetup.SetPagesTall(False)
        WsReport.PageSetup.SetCenterHorizontally(True)
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        WbReport.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert(New ExcelToPdfConverterSettings() With {.EmbedFonts = True}).Save(Result.FilePath & ".pdf")
        Result.ReportName = $"Relatório de Atendimento {ReportingEvaluation.EvaluationNumber} - { ReportingEvaluation.Customer.ShortName} - {ReportingEvaluation.Compressor.CompressorName}{If(Not String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), $" NS {ReportingEvaluation.Compressor.SerialNumber}", String.Empty)}"
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Relatório de Atendimento.pdf"))
        Return Result
    End Function

    Private Shared Sub CreateHeader(Sheet As IXLWorksheet, Row As Integer, HeaderText As String)
        Sheet.Range(Row, 1, Row, 7).Merge()
        Sheet.Range(Row, 1, Row, 7).SetValue(HeaderText)
        Sheet.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        Sheet.Range(Row, 1, Row, 7).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
        Sheet.Range(Row, 1, Row, 7).Style.Font.SetBold(True)
        Sheet.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
        Sheet.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    End Sub
End Class
