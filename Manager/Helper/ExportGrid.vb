Imports System.IO
Imports ClosedXML
Imports ManagerCore
Imports Syncfusion.ExcelToPdfConverter
Public Class ExportGrid
    Public Class ExportGridInfo
        Public Property Title As String
        Public Property Grid As DataGridView
    End Class
    Public Shared Function Export(Infos() As ExportGridInfo) As ReportResult
        Dim Wb As New Excel.XLWorkbook
        Dim Ws As Excel.IXLWorksheet
        Dim c As Integer
        Dim r As Integer
        Dim Converter As ExcelToPdfConverter
        Dim Result As New ReportResult
        Dim Value As Object
        For Each Info In Infos
            Ws = Wb.Worksheets.Add(Info.Title)
            Ws.ShowGridLines = False
            Ws.Rows.Style.Font.FontName = "Century Gothic"
            r = 1
            c = 1
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Merge()
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Value = Info.Title
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Alignment.Horizontal = Excel.XLAlignmentHorizontalValues.Center
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Font.Bold = True
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Font.FontColor = Excel.XLColor.Black
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Fill.BackgroundColor = Excel.XLColor.WhiteSmoke
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.LeftBorder = Excel.XLBorderStyleValues.Thin
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.LeftBorderColor = Excel.XLColor.DarkGray
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.TopBorder = Excel.XLBorderStyleValues.Thin
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.TopBorderColor = Excel.XLColor.DarkGray
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.RightBorder = Excel.XLBorderStyleValues.Thin
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.RightBorderColor = Excel.XLColor.DarkGray
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.BottomBorder = Excel.XLBorderStyleValues.Thin
            Ws.Range(r, c, r, Info.Grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)).Style.Border.BottomBorderColor = Excel.XLColor.DarkGray
            r += 1
            For Head = 0 To Info.Grid.Columns.Count - 1
                If Info.Grid.Columns(Head).Visible Then
                    Ws.Cell(r, c).Value = Info.Grid.Columns(Head).HeaderText
                    Ws.Cell(r, c).Style.Font.Bold = True
                    Ws.Cell(r, c).Style.Font.FontColor = Excel.XLColor.Black
                    Ws.Cell(r, c).Style.Fill.BackgroundColor = Excel.XLColor.WhiteSmoke
                    Ws.Cell(r, c).Style.Border.LeftBorder = Excel.XLBorderStyleValues.Thin
                    Ws.Cell(r, c).Style.Border.LeftBorderColor = Excel.XLColor.DarkGray
                    Ws.Cell(r, c).Style.Border.TopBorder = Excel.XLBorderStyleValues.Thin
                    Ws.Cell(r, c).Style.Border.TopBorderColor = Excel.XLColor.DarkGray
                    Ws.Cell(r, c).Style.Border.RightBorder = Excel.XLBorderStyleValues.Thin
                    Ws.Cell(r, c).Style.Border.RightBorderColor = Excel.XLColor.DarkGray
                    Ws.Cell(r, c).Style.Border.BottomBorder = Excel.XLBorderStyleValues.Thin
                    Ws.Cell(r, c).Style.Border.BottomBorderColor = Excel.XLColor.DarkGray
                    c += 1
                End If
            Next Head
            r += 1
            c = 1
            For Row = 0 To Info.Grid.Rows.Count - 1
                For Col = 0 To Info.Grid.Columns.Count - 1
                    If Info.Grid.Columns(Col).Visible Then
                        Value = Info.Grid.Rows(Row).Cells(Col).Value
                        If TypeOf Info.Grid.Rows(Row).Cells(Col).Value Is Integer Then
                            Ws.Cell(r, c).Value = CType(Value, Integer)
                        ElseIf TypeOf Value Is Long Then
                            Ws.Cell(r, c).Value = CType(Value, Long)
                        ElseIf TypeOf Value Is Double Then
                            Ws.Cell(r, c).Value = CType(Value, Double)
                        ElseIf TypeOf Value Is Decimal Then
                            Ws.Cell(r, c).Value = CType(Value, Decimal)
                        ElseIf TypeOf Value Is Boolean Then
                            Ws.Cell(r, c).Value = CType(Value, Boolean)
                        ElseIf TypeOf Value Is Date Then
                            Ws.Cell(r, c).Value = CType(Value, Date).ToString("dd/MM/yyyy")
                        Else
                            Ws.Cell(r, c).Value = Value.ToString
                        End If
                        Ws.Cell(r, c).Style.Border.LeftBorder = Excel.XLBorderStyleValues.Thin
                        Ws.Cell(r, c).Style.Border.LeftBorderColor = Excel.XLColor.DarkGray
                        Ws.Cell(r, c).Style.Border.TopBorder = Excel.XLBorderStyleValues.Thin
                        Ws.Cell(r, c).Style.Border.TopBorderColor = Excel.XLColor.DarkGray
                        Ws.Cell(r, c).Style.Border.RightBorder = Excel.XLBorderStyleValues.Thin
                        Ws.Cell(r, c).Style.Border.RightBorderColor = Excel.XLColor.DarkGray
                        Ws.Cell(r, c).Style.Border.BottomBorder = Excel.XLBorderStyleValues.Thin
                        Ws.Cell(r, c).Style.Border.BottomBorderColor = Excel.XLColor.DarkGray
                        Ws.Range("A2:" & Ws.Range("2:2").LastColumnUsed.ColumnLetter & "2").SetAutoFilter()
                        c += 1
                    End If
                Next Col
                r += 1
                c = 1
            Next Row
            Ws.Columns().AdjustToContents(2, 15, 70)
            Ws.SheetView.FreezeRows(2)
            Ws.PageSetup.PagesWide = 1
            Ws.PageSetup.PagesTall = False
            Ws.PageSetup.CenterHorizontally = True
        Next Info
        Result.FilePath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Path.GetRandomFileName)
        Wb.SaveAs(Result.FilePath & ".xlsx")
        Converter = New ExcelToPdfConverter(Result.FilePath & ".xlsx")
        Converter.Convert().Save(Result.FilePath & ".pdf")
        Result.ReportName = "Grade Exportada"
        Result.Attachments.Add(New ReportResult.ReportAttachment(Result.FilePath & ".pdf", "Grade Exportada.pdf"))
        Return Result
    End Function
End Class
