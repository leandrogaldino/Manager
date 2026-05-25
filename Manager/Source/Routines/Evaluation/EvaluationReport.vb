Imports System.IO
Imports ControlLibrary.Extensions
Imports ManagerCore
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports PdfSharp.Fonts
Public Class EvaluationReport
    Public Class CustomFontResolver
        Implements IFontResolver
        Public Function ResolveTypeface(FamilyName As String, IsBold As Boolean, IsItalic As Boolean) As FontResolverInfo Implements IFontResolver.ResolveTypeface
            If FamilyName.ToLower().Contains("century gothic") Then
                If IsBold And IsItalic Then
                    Return New FontResolverInfo("CG_BI")
                ElseIf IsBold Then
                    Return New FontResolverInfo("CG_B")
                ElseIf IsItalic Then
                    Return New FontResolverInfo("CG_I")
                Else
                    Return New FontResolverInfo("CG_R")
                End If
            ElseIf FamilyName.ToLower().Contains("cookie") Then
                Return New FontResolverInfo("COOKIE_R")
            End If
            Return New FontResolverInfo("CG_R")
        End Function

        Private Function LoadFont(Filename As String) As Byte()
            Dim UserPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\Windows\Fonts")
            Dim SystemPath As String = "C:\Windows\Fonts\"
            Dim fullUser = Path.Combine(UserPath, Filename)
            If File.Exists(fullUser) Then
                Return File.ReadAllBytes(fullUser)
            End If
            Dim fullSystem = Path.Combine(SystemPath, Filename)
            If File.Exists(fullSystem) Then
                Return File.ReadAllBytes(fullSystem)
            End If
            Throw New FileNotFoundException("Fonte não encontrada: " & Filename)
        End Function

        Public Function GetFont(Facename As String) As Byte() Implements IFontResolver.GetFont
            Select Case Facename
                Case "CG_R"
                    Return LoadFont("GOTHIC.TTF")

                Case "CG_B"
                    Return LoadFont("GOTHICB.TTF")

                Case "CG_I"
                    Return LoadFont("GOTHICI.TTF")

                Case "CG_BI"
                    Return LoadFont("GOTHICBI.TTF")
                Case "COOKIE_R"
                    Return LoadFont("Cookie-Regular.ttf")
            End Select
            Return Nothing
        End Function
    End Class

    Public Shared Function EvaluationTreatment(ReportingEvaluation As Evaluation, ShowIdAsCode As Boolean, Pictures As List(Of String)) As ReportResult
        GlobalFontSettings.FontResolver = New CustomFontResolver()
        Const Separator As String = "   •   "
        Dim NormalColor As Color = Color.FromRgb(255, 255, 255)
        Dim HeaderColor As Color = Color.FromRgb(250, 250, 250)
        Dim SuperHeaderColor As Color = Color.FromRgb(220, 220, 220)
        Dim Table As Table
        Dim Row As Row
        Dim Paragraph As Paragraph
        Dim Section As Section
        Dim Document As Document
        Dim TotalWidth As Double
        Dim Cols As Integer
        Dim ColWidth As Double
        Dim Result As New ReportResult
        Dim Cell As Cell
        Document = New Document()
        Dim Style As Style = Document.Styles("Normal")
        Style.Font.Size = 10
        Style.Font.Name = "Century Gothic"
        Section = Document.AddSection()
        Paragraph = Section.AddParagraph()
        Paragraph.AddFormattedText("RELATÓRIO DE ATENDIMENTO", TextFormat.Bold)
        Paragraph.Format.Font.Size = 12
        Paragraph.Format.Alignment = ParagraphAlignment.Center
        Paragraph.Format.SpaceAfter = Unit.FromCentimeter(0.25)
        Paragraph = Section.AddParagraph()
        Paragraph.AddFormattedText("REF: ", TextFormat.Bold)
        Paragraph.AddText(ReportingEvaluation.Reference)
        Paragraph.Format.Alignment = ParagraphAlignment.Center
        Paragraph.Format.Font.Size = 8
        Paragraph.Format.SpaceAfter = Unit.FromCentimeter(0.5)
        Table = Section.AddTable()
        Table.Rows.VerticalAlignment = VerticalAlignment.Center
        Table.Rows.Height = Unit.FromCentimeter(0.55)
        Table.Rows.HeightRule = RowHeightRule.Exactly
        TotalWidth = 16
        Cols = 7
        ColWidth = TotalWidth / Cols
        For i As Integer = 1 To Cols
            Dim Col = Table.AddColumn()
            Col.Width = Unit.FromCentimeter(ColWidth)
        Next i
        Row = Table.AddRow()
        AddRichTextCell(Row, 0, 6, ParagraphAlignment.Left, 0.5, NormalColor,
                        {
                            ("CLIENTE: ", TextFormat.Bold), (ReportingEvaluation.Customer.ShortName & If(String.IsNullOrEmpty(ReportingEvaluation.Compressor.Sector), String.Empty, $" {Separator} {ReportingEvaluation.Compressor.Sector}"), Nothing)
                        })
        Row = Table.AddRow()
        AddRichTextCell(Row, 0, 6, ParagraphAlignment.Left, 0.5, NormalColor,
                        {
                            ("CIDADE: ", TextFormat.Bold), ("GOIÂNIA", Nothing),
                            (Separator, Nothing),
                            ("UF: ", TextFormat.Bold), ("GO", Nothing),
                            (Separator, Nothing),
                            ("CONTATO: ", TextFormat.Bold), ("FULANO", Nothing),
                            (Separator, Nothing),
                            ("FONE: ", TextFormat.Bold), ("(00) 0000-0000", Nothing)
                        })
        Row = Table.AddRow()
        AddRichTextCell(Row, 0, 6, ParagraphAlignment.Left, 0.5, NormalColor,
                        {
                            ("TIPO DE VISITA: ", TextFormat.Bold), ("PREVENTIVA", Nothing),
                            (Separator, Nothing),
                            ("DATA: ", TextFormat.Bold), ("00/00/0000", Nothing),
                            (Separator, Nothing),
                            ("INICIO: ", TextFormat.Bold), ("00:00", Nothing),
                            (Separator, Nothing),
                            ("FIM: ", TextFormat.Bold), ("00:00", Nothing)
                        })
        AddSeparatorRow(Table)
        Row = Table.AddRow()
        AddTitleCell(Row, "INFORMAÇÕES DO COMPRESSOR")
        Row = Table.AddRow()
        AddSubtitleCell(Row, 0, 0, ParagraphAlignment.Center, "COMPRESSOR", 8)
        AddSubtitleCell(Row, 1, 0, ParagraphAlignment.Center, "HORÍMETRO", 8)
        AddSubtitleCell(Row, 2, 0, ParagraphAlignment.Center, "Nº SÉRIE/PAT", 8)
        AddSubtitleCell(Row, 3, 0, ParagraphAlignment.Center, "PRESSÃO TRAB.", 8)
        AddSubtitleCell(Row, 4, 0, ParagraphAlignment.Center, "TEMPERATURA", 8)
        AddSubtitleCell(Row, 5, 0, ParagraphAlignment.Center, "UND. COMP.", 8)
        AddSubtitleCell(Row, 6, 0, ParagraphAlignment.Center, "REGIME TRAB.", 8)
        Row = Table.AddRow()
        AddContentCell(Row, 0, 0, ParagraphAlignment.Center, "SRP 4100")
        AddContentCell(Row, 1, 0, ParagraphAlignment.Center, "10.469")
        AddContentCell(Row, 2, 0, ParagraphAlignment.Center, "13458")
        AddContentCell(Row, 3, 0, ParagraphAlignment.Center, "7.5BAR")
        AddContentCell(Row, 4, 0, ParagraphAlignment.Center, "85ºC")
        AddContentCell(Row, 5, 0, ParagraphAlignment.Center, "EVO9")
        AddContentCell(Row, 6, 0, ParagraphAlignment.Center, "24 H/DIA")
        AddSeparatorRow(Table)
        Row = Table.AddRow()
        AddTitleCell(Row, "HORAS RESTANTES PARA SUBSTITUIÇÃO")
        Row = Table.AddRow()
        AddSubtitleCell(Row, 0, 0, ParagraphAlignment.Center, "RECONSTRUIR UND.", 6)
        AddSubtitleCell(Row, 1, 0, ParagraphAlignment.Center, "FILTRO AR", 8)
        AddSubtitleCell(Row, 2, 0, ParagraphAlignment.Center, "FILTRO ÓLEO", 8)
        AddSubtitleCell(Row, 3, 0, ParagraphAlignment.Center, "SEPARADOR", 8)
        AddSubtitleCell(Row, 4, 0, ParagraphAlignment.Center, "LUB. MOTOR", 8)
        AddSubtitleCell(Row, 5, 0, ParagraphAlignment.Center, "ÓLEO", 8)
        AddSubtitleCell(Row, 6, 0, ParagraphAlignment.Center, "TIPO ÓLEO", 8)
        Row = Table.AddRow()
        AddContentCell(Row, 0, 0, ParagraphAlignment.Center, "NÃO")
        AddContentCell(Row, 1, 0, ParagraphAlignment.Center, "1.000")
        AddContentCell(Row, 2, 0, ParagraphAlignment.Center, "1.000")
        AddContentCell(Row, 3, 0, ParagraphAlignment.Center, "1.000")
        AddContentCell(Row, 4, 0, ParagraphAlignment.Center, "1.000")
        AddContentCell(Row, 5, 0, ParagraphAlignment.Center, "1.000")
        AddContentCell(Row, 6, 0, ParagraphAlignment.Center, "SEMI-SINTÉTICO", 6)
        If ReportingEvaluation.ElapsedDayControlledSellables.Any(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Coalescent) Then
            AddSeparatorRow(Table)
            Row = Table.AddRow()
            AddTitleCell(Row, "FILTROS COALESCENTES")
            Row = Table.AddRow()
            AddSubtitleCell(Row, 0, 2, ParagraphAlignment.Center, "ELEMENTO", 8)
            AddSubtitleCell(Row, 3, 0, ParagraphAlignment.Center, "ÚLTIMA TROCA", 8)
            AddSubtitleCell(Row, 4, 0, ParagraphAlignment.Center, "PROX. TROCA", 8)
            AddSubtitleCell(Row, 5, 0, ParagraphAlignment.Center, "CAPACIDADE", 8)
            AddSubtitleCell(Row, 6, 0, ParagraphAlignment.Center, "UTILIZADO", 8)
            Dim FirstEvaluationDate = Evaluation.GetFirstEvaluationDate(ReportingEvaluation.Compressor)
            For Each Coalescent In ReportingEvaluation.ElapsedDayControlledSellables.Where(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Coalescent)
                Dim LastReplace = Evaluation.GetLastEvaluationReplacedSellableDate(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
                Dim LastReplaceCapacity = Evaluation.GetLastEvaluationReplacedSellableCapacity(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
                Dim CurrentCapacityOnReplace = Evaluation.GetLastEvaluationReplacedSellableCapacity(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
                Row = Table.AddRow()
                AddContentCell(Row, 0, 2, ParagraphAlignment.Center, Coalescent.Name, 8)
                If LastReplace.HasValue Then
                    AddContentCell(Row, 3, 0, ParagraphAlignment.Center, LastReplace.Value.ToString("dd/MM/yyyy"))
                    AddContentCell(Row, 4, 0, ParagraphAlignment.Center, ReportingEvaluation.EvaluationDate.AddDays(Coalescent.CurrentCapacity).ToString("dd/MM/yyyy"))
                Else
                    AddContentCell(Row, 3, 0, ParagraphAlignment.Center, "N/A")
                    AddContentCell(Row, 4, 0, ParagraphAlignment.Center, FirstEvaluationDate.AddDays(Coalescent.CurrentCapacity).ToString("dd/MM/yyyy"))
                End If
                AddContentCell(Row, 5, 0, ParagraphAlignment.Center, Coalescent.CurrentCapacity)
                AddContentCell(Row, 6, 0, ParagraphAlignment.Center, Coalescent.PersonCompressorSellable.Capacity - Coalescent.CurrentCapacity)
            Next Coalescent
        End If
        If ReportingEvaluation.ReplacedSellables.Any() Then
            AddSeparatorRow(Table)
            Row = Table.AddRow()
            AddTitleCell(Row, "PEÇAS SUBSTITUÍDAS/SERVIÇOS EXECUTADOS")
            Row = Table.AddRow()
            AddSubtitleCell(Row, 0, 1, ParagraphAlignment.Center, "CÓDIGO", 8)
            AddSubtitleCell(Row, 2, 3, ParagraphAlignment.Center, "PEÇAS/SERVIÇOS", 8)
            AddSubtitleCell(Row, 6, 0, ParagraphAlignment.Center, "QTD.", 8)
            For Each ReplacedSellable In ReportingEvaluation.ReplacedSellables
                Row = Table.AddRow()
                If ReplacedSellable.SellableType = SellableType.Product Then
                    If ShowIdAsCode Then
                        AddContentCell(Row, 0, 1, ParagraphAlignment.Center, $"P{ReplacedSellable.SellableID}")
                    Else
                        Cell = AddContentCell(Row, 0, 1, ParagraphAlignment.Center, ReplacedSellable.Code)
                    End If
                Else
                    AddContentCell(Row, 0, 1, ParagraphAlignment.Center, $"S{ReplacedSellable.SellableID}")
                End If
                AddContentCell(Row, 2, 3, ParagraphAlignment.Left, ReplacedSellable.Name)
                AddContentCell(Row, 6, 0, ParagraphAlignment.Center, ReplacedSellable.Quantity)
            Next ReplacedSellable
        End If
        If Not String.IsNullOrWhiteSpace(ReportingEvaluation.TechnicalAdvice) Then
            AddSeparatorRow(Table)
            Row = Table.AddRow()
            AddTitleCell(Row, "PARECER TÉCNICO")
            Row = Table.AddRow()
            Row.HeightRule = RowHeightRule.Auto
            AddContentCell(Row, 0, 6, ParagraphAlignment.Left, ReportingEvaluation.TechnicalAdvice)
        End If
        Dim Culture As New Globalization.CultureInfo("pt-BR")
        Dim MonthName As String = DateAndTime.MonthName(ReportingEvaluation.EvaluationDate.Month, False)
        MonthName = MonthName.ToUpper(Culture)
        Paragraph = Section.AddParagraph()
        Paragraph.Format.Font.Size = 9
        Paragraph.Format.SpaceBefore = Unit.FromCentimeter(0.5)
        Paragraph.AddText($"AS PARTES DECLARAM ESTAR DE ARCORDO COM ESTE RELATÓRIO, EM {ReportingEvaluation.EvaluationDate.Day} DE {MonthName} DE {ReportingEvaluation.EvaluationDate.Year}.")
        Cols = 2
        ColWidth = TotalWidth / Cols
        Table = Section.AddTable()
        For i As Integer = 1 To Cols
            Dim Col = Table.AddColumn()
            Col.Width = Unit.FromCentimeter(ColWidth)
        Next i
        AddSeparatorRow(Table, 1.5)
        Row = Table.AddRow()
        Row.Height = Unit.FromCentimeter(1)
        Row.VerticalAlignment = VerticalAlignment.Center
        If File.Exists(ReportingEvaluation.Signature.CurrentFile) Then
            AddImageCell(Row, 0, 0, ReportingEvaluation.Signature.CurrentFile)
        Else
            AddContentCell(Row, 0, 0, ParagraphAlignment.Center, ReportingEvaluation.Responsible.ToTitle(), 24, 0, "Cookie")
        End If
        AddContentCell(Row, 1, 0, ParagraphAlignment.Center, ReportingEvaluation.Technicians(0).Technician.ShortName.ToTitle(), 24, 0, "Cookie")
        Row = Table.AddRow()
        Cell = AddContentCell(Row, 0, 0, ParagraphAlignment.Center, "CLIENTE", 8, 0)
        Cell.Format.Font.Bold = True
        Cell = AddContentCell(Row, 1, 0, ParagraphAlignment.Center, "TÉCNICO", 8, 0)
        Cell.Format.Font.Bold = True
        If Pictures.Count > 0 Then
            Section.AddPageBreak()
            Cols = 1
            ColWidth = TotalWidth / Cols
            Table = Section.AddTable()
            For i As Integer = 1 To Cols
                Dim Col = Table.AddColumn()
                Col.Width = Unit.FromCentimeter(ColWidth)
            Next i
            For Each Picture In Pictures
                Row = Table.AddRow()
                Row.Height = Unit.FromCentimeter(12)
                Row.HeightRule = RowHeightRule.Exactly
                Cell = Row.Cells(0)
                Cell.Format.Alignment = ParagraphAlignment.Center
                Cell.VerticalAlignment = VerticalAlignment.Center
                Cell.Borders.Width = 0.5
                Paragraph = Cell.AddParagraph()
                Paragraph.Format.Alignment = ParagraphAlignment.Center
                Dim DrawingImage = Image.FromFile(Picture)
                Dim IsPortrait As Boolean = DrawingImage.Height > DrawingImage.Width
                DrawingImage.Dispose()
                Dim Img = Paragraph.AddImage(Picture)
                Img.LockAspectRatio = True
                If IsPortrait Then
                    Img.Height = Unit.FromCentimeter(10.5)
                Else
                    Img.Width = Unit.FromCentimeter(15)
                End If
            Next
        End If
        Dim Render As New PdfDocumentRenderer With {
            .Document = Document
        }
        Render.RenderDocument()
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        Render.PdfDocument.Save(Result.FilePath & ".pdf")
        Result.ReportName = $"Relatório de Atendimento {ReportingEvaluation.Reference} - { ReportingEvaluation.Customer.ShortName} - {ReportingEvaluation.Compressor.CompressorName}{If(Not String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), $" NS {ReportingEvaluation.Compressor.SerialNumber}", String.Empty)}"
        Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Relatório de Atendimento.pdf"))
        Result.hasExcelFile = False
        Return Result
    End Function

    Private Shared Sub AddSeparatorRow(Table As Table, Optional Height As Double = 0.25)
        Dim Row = Table.AddRow()
        Row.Height = Unit.FromCentimeter(Height)
    End Sub

    Private Shared Function AddRichTextCell(Row As Row, CellIndex As Integer, MergeRight As Integer, Alignment As ParagraphAlignment, BorderWidth As Double, BackColor As Color, TextParts As (Text As String, Format As TextFormat?)()) As Cell
        Dim Cell = Row.Cells(CellIndex)
        Cell.MergeRight = MergeRight
        Cell.Borders.Width = BorderWidth
        Cell.Format.Alignment = Alignment
        Cell.Shading.Color = BackColor
        Dim Paragraph = Cell.AddParagraph()
        For i As Integer = 0 To TextParts.Length - 1
            Dim Part = TextParts(i)
            If Part.Format.HasValue Then
                Paragraph.AddFormattedText(Part.Text, Part.Format.Value)
            Else
                Paragraph.AddText(Part.Text)
            End If
        Next i
        Return Cell
    End Function


    Private Shared Function AddTitleCell(Row As Row, Text As String, Optional FontSize As Integer = 10) As Cell
        Dim Cell = Row.Cells(0)
        Cell.MergeRight = Cell.Table.Columns.Count - 1
        Cell.Borders.Width = 0.5
        Cell.Format.Alignment = ParagraphAlignment.Center
        Cell.Format.Font.Size = FontSize
        Cell.Shading.Color = Color.FromRgb(220, 220, 220)
        Dim Paragraph = Cell.AddParagraph()
        Paragraph.AddFormattedText(Text, TextFormat.Bold)
        Return Cell
    End Function

    Private Shared Function AddSubtitleCell(Row As Row, CellIndex As Integer, MergeRight As Integer, Alignment As ParagraphAlignment, Text As String, Optional FontSize As Integer = 10, Optional BorderSize As Double = 0.5) As Cell
        Dim Cell = Row.Cells(CellIndex)
        Cell.MergeRight = MergeRight
        Cell.Borders.Width = Unit.FromPoint(BorderSize)
        Cell.Format.Alignment = Alignment
        Cell.Format.Font.Size = FontSize
        Cell.Shading.Color = Color.FromRgb(245, 245, 245)
        Dim Paragraph = Cell.AddParagraph()
        Paragraph.AddFormattedText(Text, TextFormat.Bold)
        Return Cell
    End Function

    Private Shared Function AddContentCell(Row As Row, CellIndex As Integer, MergeRight As Integer, Alignment As ParagraphAlignment, Text As String, Optional FontSize As Integer = 10, Optional BorderSize As Double = 0.5, Optional FontName As String = Nothing) As Cell
        Dim Cell = Row.Cells(CellIndex)
        Cell.MergeRight = MergeRight
        Cell.Borders.Width = Unit.FromPoint(BorderSize)
        Cell.Format.Alignment = Alignment
        Cell.Format.Font.Size = FontSize
        Cell.Shading.Color = Color.FromRgb(255, 255, 255)
        If Not String.IsNullOrEmpty(FontName) Then
            Cell.Format.Font.Name = FontName
        End If
        Dim Paragraph = Cell.AddParagraph()
        Paragraph.AddText(Text)
        Return Cell
    End Function

    Private Shared Function AddImageCell(Row As Row, CellIndex As Integer, MergeRight As Integer, ImagePath As String)
        Dim Cell = Row.Cells(CellIndex)
        Cell.MergeRight = MergeRight
        Cell.Borders.Width = 0
        Cell.Format.Alignment = ParagraphAlignment.Center
        Cell.VerticalAlignment = VerticalAlignment.Center
        Cell.Shading.Color = Color.FromRgb(255, 255, 255)
        Dim Paragraph = Cell.AddParagraph()
        Paragraph.Format.Alignment = ParagraphAlignment.Center
        Dim Image = Paragraph.AddImage(ImagePath)
        Image.LockAspectRatio = True
        Image.Width = Unit.FromCentimeter(7)
        Return Cell
    End Function
    'Public Shared Function EvaluationTreatment(ReportingEvaluation As Evaluation) As ReportResult
    '    Dim Session = Locator.GetInstance(Of Session)
    '    Dim WbReport As New XLWorkbook
    '    Dim WsReport As IXLWorksheet = WbReport.Worksheets.Add("Relatório de Atendimento")
    '    Dim Converter As ExcelToPdfConverter
    '    Dim Result As New ReportResult
    '    Dim Logo As Drawings.IXLPicture
    '    Dim Row As Integer = 14
    '    Dim Address As String
    '    Dim Phones As String
    '    Dim LastReplace As Date?
    '    Dim CurrentCapacityOnReplace As Integer?
    '    Dim LastReplaceCapacity As Integer?
    '    WsReport.ShowGridLines = False
    '    WsReport.Rows.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
    '    WsReport.Rows.Style.NumberFormat.SetFormat("@")
    '    WsReport.Style.Font.SetFontName("Century Gothic")
    '    WsReport.Style.Font.SetFontSize(10)
    '    WsReport.RowHeight = 18
    '    WsReport.Columns(1, 7).Width = 15
    '    WsReport.Rows(1).Height = 50
    '    WsReport.Range(1, 1, 1, 5).Merge()
    '    WsReport.Range(1, 1, 1, 5).SetValue("RELATÓRIO DE ATENDIMENTO".PadLeft(85, " "))
    '    WsReport.Range(1, 1, 1, 5).Style.Font.SetBold(True)
    '    WsReport.Range(1, 1, 1, 5).Style.Font.SetFontSize(14)
    '    WsReport.Range(1, 6, 1, 7).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
    '    WsReport.Cell(1, 6).CreateRichText.
    '        AddText("REF: ").SetBold(True).SetFontSize(10).
    '        AddText(ReportingEvaluation.Reference).SetFontSize(10)
    '    WsReport.Range(1, 7, 1, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    Dim LogoLocation As String = Path.Combine(ApplicationPaths.LogoDirectory, Path.GetFileName(Session.Setting.Company.LogoLocation))
    '    If File.Exists(LogoLocation) Then
    '        Using Stream As New MemoryStream(File.ReadAllBytes(LogoLocation))
    '            Logo = WsReport.AddPicture(Stream)
    '            Logo.MoveTo(WsReport.Cell(1, 1), New Point(0, 5))
    '            Logo.WithSize(156, 57)
    '        End Using
    '    End If
    '    WsReport.Rows(2).Height = 5
    '    WsReport.Range(3, 1, 3, 7).Merge()
    '    WsReport.Range(3, 1, 3, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(3, 1, 3, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '    WsReport.Cell(3, 1).CreateRichText().
    '        AddText("CLIENTE: ").SetBold().
    '        AddText(ReportingEvaluation.Customer.ShortName).
    '        AddText(If(String.IsNullOrEmpty(ReportingEvaluation.Compressor.Sector), String.Empty, $" - {ReportingEvaluation.Compressor.Sector}"))
    '    WsReport.Range(4, 1, 4, 7).Merge()
    '    WsReport.Range(4, 1, 4, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(4, 1, 4, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '    WsReport.Cell(4, 1).CreateRichText().
    '        AddText("CIDADE: ").SetBold().
    '        AddText(ReportingEvaluation.Customer.Addresses.First(Function(x) x.IsMainAddress).City.Name).
    '        AddText("      ").
    '        AddText("UF: ").SetBold().
    '        AddText(ReportingEvaluation.Customer.Addresses.First(Function(x) x.IsMainAddress).City.State.ShortName).
    '        AddText("      ").
    '        AddText("CONTATO: ").SetBold().
    '        AddText(ReportingEvaluation.Customer.Contacts.First(Function(x) x.IsMainContact).Name).
    '        AddText("      ").
    '        AddText("FONE: ").SetBold().
    '        AddText(ReportingEvaluation.Customer.Contacts.First(Function(x) x.IsMainContact).Phone)
    '    WsReport.Range(5, 1, 5, 7).Merge()
    '    WsReport.Range(5, 1, 5, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(5, 1, 5, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '    WsReport.Cell(5, 1).CreateRichText().
    '        AddText("TIPO DE VISITA: ").SetBold().
    '        AddText(EnumHelper.GetEnumDescription(ReportingEvaluation.CallType)).
    '        AddText("      ").
    '        AddText("DATA: ").SetBold().
    '        AddText(ReportingEvaluation.EvaluationDate.ToString("dd/MM/yyyy")).
    '        AddText("    ").
    '        AddText("INÍCIO: ").SetBold().
    '        AddText(ReportingEvaluation.StartTime.ToString("hh\:mm")).
    '        AddText("      ").AddText("FIM: ").SetBold().
    '        AddText(ReportingEvaluation.EndTime.ToString("hh\:mm"))
    '    WsReport.Rows(6).Height = 5
    '    CreateHeader(WsReport, 7, "INFORMAÇÕES DO COMPRESSOR")
    '    WsReport.Cell(8, 1).SetValue("COMPRESSOR")
    '    WsReport.Cell(8, 2).SetValue("HORÍMETRO")
    '    WsReport.Cell(8, 3).SetValue("Nº SÉRIE/PAT.")
    '    WsReport.Cell(8, 4).SetValue("PRESSÃO TRAB.")
    '    WsReport.Cell(8, 5).SetValue("TEMP. (ºC)")
    '    WsReport.Cell(8, 6).SetValue("UND. COMP.")
    '    WsReport.Cell(8, 7).SetValue("REGIME TRAB.")
    '    WsReport.Range(8, 1, 8, 7).Style.Font.Bold = True
    '    WsReport.Range(8, 1, 8, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(8, 1, 8, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
    '    WsReport.Range(8, 1, 8, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(8, 1, 8, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '    WsReport.Range(8, 1, 8, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(8, 1, 8, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '    WsReport.Cell(9, 1).SetValue(ReportingEvaluation.Compressor.CompressorName)
    '    WsReport.Cell(9, 2).SetValue(FormatNumber(ReportingEvaluation.Horimeter, 0))
    '    WsReport.Cell(9, 3).SetValue(If(Not String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), ReportingEvaluation.Compressor.SerialNumber, ReportingEvaluation.Compressor.Patrimony))
    '    WsReport.Cell(9, 4).SetValue($"{ReportingEvaluation.Pressure} BAR")
    '    WsReport.Cell(9, 5).SetValue($"{ReportingEvaluation.Temperature} ºC")
    '    WsReport.Cell(9, 6).SetValue(ReportingEvaluation.UnitName)
    '    WsReport.Cell(9, 7).SetValue($"{ReportingEvaluation.AverageWorkLoad} H/DIA")
    '    WsReport.Range(9, 1, 9, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(9, 1, 9, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(9, 1, 9, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '    WsReport.Range(9, 1, 9, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(9, 1, 9, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '    WsReport.Rows(10).Height = 5
    '    CreateHeader(WsReport, 11, "HORAS RESTANTES PARA SUBSTITUIÇÃO")
    '    WsReport.Cell(12, 1).Style.Font.SetFontSize(8)
    '    WsReport.Cell(12, 1).SetValue("RECONSTRUIR UND.")
    '    WsReport.Cell(12, 2).SetValue("FILTRO AR")
    '    WsReport.Cell(12, 3).SetValue("FILTRO ÓLEO")
    '    WsReport.Cell(12, 4).SetValue("SEPARADOR")
    '    WsReport.Cell(12, 5).SetValue("LUB. MOTOR")
    '    WsReport.Cell(12, 6).SetValue("ÓLEO")
    '    WsReport.Cell(12, 7).SetValue("TIPO ÓLEO")
    '    WsReport.Range(12, 1, 12, 7).Style.Font.Bold = True
    '    WsReport.Range(12, 1, 12, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(12, 1, 12, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
    '    WsReport.Range(12, 1, 12, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(12, 1, 12, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '    WsReport.Range(12, 1, 12, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(12, 1, 12, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '    WsReport.Cell(13, 1).SetValue(If(ReportingEvaluation.Compressor.UnitCapacity <= ReportingEvaluation.Horimeter, "SIM", "NÃO"))
    '    WsReport.Cell(13, 2).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.AirFilter).CurrentCapacity, 0, TriState.True))
    '    WsReport.Cell(13, 3).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.OilFilter).CurrentCapacity, 0, TriState.True))
    '    WsReport.Cell(13, 4).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Separator).CurrentCapacity, 0, TriState.True))
    '    Dim HasGreasing As Boolean = ReportingEvaluation.WorkedHourControlledSelables.Any(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Greasing)
    '    WsReport.Cell(13, 5).SetValue(If(HasGreasing, FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Greasing).CurrentCapacity, 0, TriState.True), "N/A"))
    '    WsReport.Cell(13, 6).SetValue(FormatNumber(ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Oil).CurrentCapacity, 0, TriState.True))
    '    Dim OilCapacity As Integer = ReportingEvaluation.WorkedHourControlledSelables.First(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Oil).PersonCompressorSellable.Capacity
    '    Dim OilType As String = If(OilCapacity <= 1000, "MINERAL", If(OilCapacity <= 4000, "SEMI SINTÉTICO", "SINTÉTICO"))
    '    WsReport.Cell(13, 7).SetValue(OilType)
    '    WsReport.Range(13, 1, 13, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(13, 1, 13, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(13, 1, 13, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '    WsReport.Range(13, 1, 13, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '    WsReport.Range(13, 1, 13, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '    WsReport.Range(13, 1, 13, 1).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
    '    WsReport.Range(13, 7, 13, 7).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
    '    If ReportingEvaluation.ElapsedDayControlledSellables.Any(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Coalescent) Then
    '        WsReport.Rows(14).Height = 5
    '        CreateHeader(WsReport, 15, "FILTROS COALESCENTES")
    '        WsReport.Range(16, 1, 16, 3).Merge()
    '        WsReport.Cell(16, 1).SetValue("ELEMENTO")
    '        WsReport.Cell(16, 4).SetValue("ÚLTIMA TROCA")
    '        WsReport.Cell(16, 5).SetValue("PROX. TROCA")
    '        WsReport.Cell(16, 6).SetValue("CAPACIDADE")
    '        WsReport.Cell(16, 7).SetValue("UTILIZADO")
    '        WsReport.Range(16, 1, 16, 7).Style.Font.Bold = True
    '        WsReport.Range(16, 1, 16, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '        WsReport.Range(16, 1, 16, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
    '        WsReport.Range(16, 1, 16, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '        WsReport.Range(16, 1, 16, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '        WsReport.Range(16, 1, 16, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '        WsReport.Range(16, 1, 16, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '        Row = 17

    '        Dim FirstEvaluationDate As Date

    '        FirstEvaluationDate = Evaluation.GetFirstEvaluationDate(ReportingEvaluation.Compressor)
    '        For Each Coalescent In ReportingEvaluation.ElapsedDayControlledSellables.Where(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Coalescent)
    '            WsReport.Range(Row, 1, Row, 3).Merge()
    '            WsReport.Cell(Row, 1).SetValue(Coalescent.Name)
    '            LastReplace = Evaluation.GetLastEvaluationReplacedSellableDate(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
    '            LastReplaceCapacity = Evaluation.GetLastEvaluationReplacedSellableCapacity(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
    '            If LastReplace.HasValue Then
    '                WsReport.Cell(Row, 4).SetValue(LastReplace.Value.ToString("dd/MM/yyyy"))
    '                WsReport.Cell(Row, 5).SetValue(ReportingEvaluation.EvaluationDate.AddDays(Coalescent.CurrentCapacity).ToString("dd/MM/yyyy"))
    '            Else
    '                WsReport.Cell(Row, 4).SetValue("N/A")

    '                WsReport.Cell(Row, 5).SetValue(FirstEvaluationDate.AddDays(Coalescent.CurrentCapacity).ToString("dd/MM/yyyy"))
    '            End If
    '            WsReport.Cell(Row, 6).SetValue(Coalescent.CurrentCapacity)
    '            CurrentCapacityOnReplace = Evaluation.GetLastEvaluationReplacedSellableCapacity(Coalescent.PersonCompressorSellable.ID, ReportingEvaluation.EvaluationDate)
    '            If CurrentCapacityOnReplace.HasValue Then
    '                WsReport.Cell(Row, 7).SetValue(CurrentCapacityOnReplace.Value - Coalescent.CurrentCapacity)
    '            Else
    '                WsReport.Cell(Row, 7).SetValue((ReportingEvaluation.EvaluationDate - FirstEvaluationDate).Days)
    '            End If
    '            WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '            Row += 1
    '        Next Coalescent
    '        WsReport.Rows(Row).Height = 5
    '        Row += 1
    '    End If
    '    If ReportingEvaluation.ReplacedSellables.Any() Then
    '        WsReport.Rows(Row).Height = 5
    '        Row += 1
    '        CreateHeader(WsReport, Row, "PEÇAS SUBSTITUÍDAS/SERVIÇOS EXECUTADOS")
    '        Row += 1
    '        WsReport.Cell(Row, 1).SetValue("CÓDIGO")
    '        WsReport.Range(Row, 2, Row, 6).Merge()
    '        WsReport.Cell(Row, 2).SetValue("PEÇAS/SERVIÇOS")
    '        WsReport.Cell(Row, 7).SetValue("QTD.")
    '        WsReport.Range(Row, 1, Row, 7).Style.Font.Bold = True
    '        WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '        WsReport.Range(Row, 1, Row, 7).Style.Fill.SetBackgroundColor(XLColor.WhiteSmoke)
    '        WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '        WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '        WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '        WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '        Row += 1
    '        For Each ReplacedSellable In ReportingEvaluation.ReplacedSellables
    '            WsReport.Cell(Row, 1).SetValue($"{If(ReplacedSellable.SellableType = SellableType.Product, "P", "S")}{ReplacedSellable.SellableID}")
    '            WsReport.Range(Row, 2, Row, 6).Merge()
    '            WsReport.Cell(Row, 2).SetValue(ReplacedSellable.Name)
    '            WsReport.Cell(Row, 7).SetValue(ReplacedSellable.Quantity)
    '            WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
    '            WsReport.Range(Row, 1, Row, 7).Style.Border.SetInsideBorderColor(XLColor.DimGray)
    '            Row += 1
    '        Next ReplacedSellable
    '    End If
    '    If Not String.IsNullOrWhiteSpace(ReportingEvaluation.TechnicalAdvice) Then
    '        WsReport.Rows(Row).Height = 5
    '        Row += 1
    '        CreateHeader(WsReport, Row, "PARECER TÉCNICO")
    '        Row += 1
    '        Dim MaxCharsPerLine As Integer = 90

    '        Dim Lines As New List(Of String)

    '        Dim Paragraphs = ReportingEvaluation.TechnicalAdvice.Replace(vbCrLf, vbLf).Split(vbLf)
    '        For Each Paragraph In Paragraphs
    '            If String.IsNullOrWhiteSpace(Paragraph) Then
    '                Lines.Add("")
    '                Continue For
    '            End If
    '            Dim Words = Paragraph.Split(" "c)
    '            Dim CurrentLine As String = ""
    '            For Each Word In Words
    '                Dim TestLine As String
    '                If String.IsNullOrWhiteSpace(CurrentLine) Then
    '                    TestLine = Word
    '                Else
    '                    TestLine = $"{CurrentLine} {Word}"
    '                End If
    '                If TestLine.Length > MaxCharsPerLine Then
    '                    Lines.Add(CurrentLine)
    '                    CurrentLine = Word
    '                Else
    '                    CurrentLine = TestLine
    '                End If
    '            Next
    '            If Not String.IsNullOrWhiteSpace(CurrentLine) Then
    '                Lines.Add(CurrentLine)
    '            End If
    '        Next Paragraph
    '        Dim StartRow As Integer = Row
    '        For Each Line In Lines
    '            WsReport.Range(Row, 1, Row, 7).Merge()
    '            With WsReport.Range(Row, 1, Row, 7)
    '                .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
    '                .Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
    '                .Style.Alignment.WrapText = False
    '                .Style.Border.LeftBorder = XLBorderStyleValues.Thin
    '                .Style.Border.RightBorder = XLBorderStyleValues.Thin
    '                .Style.Border.LeftBorderColor = XLColor.DimGray
    '                .Style.Border.RightBorderColor = XLColor.DimGray
    '            End With
    '            WsReport.Cell(Row, 1).Value = Line
    '            WsReport.Row(Row).Height = 18
    '            Row += 1
    '        Next Line
    '        WsReport.Range(StartRow, 1, StartRow, 7).Style.Border.TopBorder = XLBorderStyleValues.Thin
    '        WsReport.Range(StartRow, 1, StartRow, 7).Style.Border.TopBorderColor = XLColor.DimGray
    '        WsReport.Range(Row - 1, 1, Row - 1, 7).Style.Border.BottomBorder = XLBorderStyleValues.Thin
    '        WsReport.Range(Row - 1, 1, Row - 1, 7).Style.Border.BottomBorderColor = XLColor.DimGray
    '        WsReport.Rows(Row).Height = 5
    '    End If
    '    Row += 1
    '    Dim Culture As New Globalization.CultureInfo("pt-BR")
    '    Dim MonthName As String = DateAndTime.MonthName(ReportingEvaluation.EvaluationDate.Month, False)
    '    MonthName = MonthName.ToUpper(Culture)
    '    WsReport.Range(Row, 1, Row, 7).Merge()
    '    WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Cell(Row, 1).SetValue($"AS PARTES DECLARAM ESTAR DE ARCORDO COM ESTE RELATÓRIO, EM {ReportingEvaluation.EvaluationDate.Day} DE {MonthName} DE {ReportingEvaluation.EvaluationDate.Year}.")
    '    WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetShrinkToFit(True)
    '    Row += 2
    '    WsReport.Range(Row, 1, Row + 2, 4).Merge()
    '    WsReport.Range(Row, 1, Row + 2, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(Row, 1, Row + 2, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
    '    'WsReport.Range(1, 4, 100, 4).Style.Border.RightBorder = XLBorderStyleValues.Medium
    '    If File.Exists(ReportingEvaluation.Signature.CurrentFile) Then
    '        Using Img As Image = Image.FromFile(ReportingEvaluation.Signature.CurrentFile)
    '            Dim MaxHeight As Double = 60
    '            Dim MaxWidth As Double = 440
    '            Dim Ratio As Double = MaxHeight / Img.Height
    '            Dim NewWidth As Double = Img.Width * Ratio
    '            Dim NewHeight As Double = MaxHeight
    '            If NewWidth > MaxWidth Then
    '                Ratio = MaxWidth / Img.Width
    '                NewWidth = MaxWidth
    '                NewHeight = Img.Height * Ratio
    '            End If
    '            Dim OffsetX As Double = (MaxWidth - NewWidth) / 2
    '            Using Stream As New MemoryStream(File.ReadAllBytes(ReportingEvaluation.Signature.CurrentFile))
    '                Dim picture = WsReport.AddPicture(Stream)
    '                picture.WithPlacement(XLPicturePlacement.FreeFloating)
    '                picture.WithSize(CInt(NewWidth), CInt(NewHeight))
    '                picture.MoveTo(WsReport.Cell(Row, 1), New Point(CInt(OffsetX), 0))
    '            End Using
    '        End Using
    '    End If
    '    WsReport.Range(Row, 5, Row + 2, 7).Merge()
    '    WsReport.Range(Row, 5, Row + 2, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(Row, 5, Row + 2, 7).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
    '    WsReport.Cell(Row, 5).SetValue(ReportingEvaluation.Technicians(0).Technician.ShortName.ToTitle())
    '    WsReport.Cell(Row, 5).Style.Font.SetFontName("Cookie")
    '    WsReport.Cell(Row, 5).Style.Font.SetFontSize(26)
    '    Row += 3
    '    WsReport.Range(Row, 1, Row, 4).Merge()
    '    WsReport.Range(Row, 1, Row, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(Row, 1, Row, 4).Style.Font.SetBold(True)
    '    WsReport.Cell(Row, 1).SetValue("CLIENTE")
    '    WsReport.Range(Row, 5, Row, 7).Merge()
    '    WsReport.Range(Row, 5, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Range(Row, 5, Row, 7).Style.Font.SetBold(True)
    '    WsReport.Cell(Row, 5).SetValue("TÉCNICO")
    '    Row += 2
    '    WsReport.Range(Row, 1, Row, 7).Merge()
    '    WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    Address = String.Empty
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Address.Street) Then Address &= Session.Setting.Company.Address.Street
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Address.Complement) Then Address &= $" {Session.Setting.Company.Address.Complement}"
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Address.Number) Then Address &= $" Nº {Session.Setting.Company.Address.Number}"
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Address.District) Then Address &= $" {Session.Setting.Company.Address.District}"
    '    Address &= ", "
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Address.City) Then Address &= $" {Session.Setting.Company.Address.City}"
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Address.State) Then Address &= $"/{Session.Setting.Company.Address.State}"
    '    Phones = String.Empty
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Contact.Phone1) Then Phones &= Session.Setting.Company.Contact.Phone1
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Contact.Phone2) Then Phones &= $" | {Session.Setting.Company.Contact.Phone2}"
    '    If Not String.IsNullOrEmpty(Session.Setting.Company.Contact.CellPhone) Then Phones &= $" | {Session.Setting.Company.Contact.CellPhone}"
    '    WsReport.Cell(Row, 1).SetValue($"{Address}{If(Not String.IsNullOrWhiteSpace(Phones), $" - {Phones}", String.Empty)}")
    '    WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetShrinkToFit(True)
    '    Row += 1
    '    WsReport.Range(Row, 1, Row, 7).Merge()
    '    WsReport.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    WsReport.Cell(Row, 1).SetValue($"{Session.Setting.Company.Contact.Email}{If(Not String.IsNullOrEmpty(Session.Setting.Company.Contact.Site), $" - {Session.Setting.Company.Contact.Site}", String.Empty)}")


    '    If ReportingEvaluation.Pictures.Count > 0 Then
    '        WsReport.PageSetup.AddHorizontalPageBreak(Row)
    '        Row += 1
    '        WsReport.Range(Row, 1, Row, 7).Merge()
    '        WsReport.Range(Row, 1, Row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    '        WsReport.Cell(Row, 1).Value = "FOTOS"
    '        Row += 2
    '        For Each picPath In ReportingEvaluation.Pictures
    '            If File.Exists(picPath.Picture.CurrentFile) Then
    '                Using Img As Image = Image.FromFile(picPath.Picture.CurrentFile)
    '                    Dim MaxHeight As Double = 500
    '                    Dim MaxWidth As Double = 500
    '                    Dim Ratio As Double = MaxHeight / Img.Height
    '                    Dim NewWidth As Double = Img.Width * Ratio
    '                    Dim NewHeight As Double = MaxHeight
    '                    If NewWidth > MaxWidth Then
    '                        Ratio = MaxWidth / Img.Width
    '                        NewWidth = MaxWidth
    '                        NewHeight = Img.Height * Ratio
    '                    End If
    '                    Dim OffsetX As Double = (MaxWidth - NewWidth) / 2
    '                    Using Stream As New MemoryStream(File.ReadAllBytes(picPath.Picture.CurrentFile))
    '                        Dim picture = WsReport.AddPicture(Stream)
    '                        picture.WithPlacement(XLPicturePlacement.FreeFloating)
    '                        picture.WithSize(CInt(NewWidth), CInt(NewHeight))
    '                        picture.MoveTo(WsReport.Cell(Row, 1), New Point(CInt(OffsetX), 0))
    '                    End Using
    '                End Using
    '            End If
    '        Next
    '    End If





    '    WsReport.PageSetup.SetPagesWide(1)
    '    WsReport.PageSetup.SetPagesTall(False)
    '    WsReport.PageSetup.SetCenterHorizontally(True)
    '    Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
    '    WbReport.SaveAs(Result.FilePath & ".xlsx")
    '    Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
    '    Converter.Convert(New ExcelToPdfConverterSettings() With {.EmbedFonts = True}).Save(Result.FilePath & ".pdf")
    '    Result.ReportName = $"Relatório de Atendimento {ReportingEvaluation.Reference} - { ReportingEvaluation.Customer.ShortName} - {ReportingEvaluation.Compressor.CompressorName}{If(Not String.IsNullOrEmpty(ReportingEvaluation.Compressor.SerialNumber), $" NS {ReportingEvaluation.Compressor.SerialNumber}", String.Empty)}"
    '    Result.Attachments.Insert(0, New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Relatório de Atendimento.pdf"))
    '    Return Result
    'End Function
    'Private Shared Sub CreateHeader(Sheet As IXLWorksheet, Row As Integer, HeaderText As String)
    '    Sheet.Range(Row, 1, Row, 7).Merge()
    '    Sheet.Range(Row, 1, Row, 7).SetValue(HeaderText)
    '    Sheet.Range(Row, 1, Row, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
    '    Sheet.Range(Row, 1, Row, 7).Style.Fill.SetBackgroundColor(XLColor.Gainsboro)
    '    Sheet.Range(Row, 1, Row, 7).Style.Font.SetBold(True)
    '    Sheet.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
    '    Sheet.Range(Row, 1, Row, 7).Style.Border.SetOutsideBorderColor(XLColor.DimGray)
    'End Sub
End Class
