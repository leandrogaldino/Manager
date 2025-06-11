Imports ControlLibrary.Extensions
Public Class FrmPersonCompressorImport
    Public Sub New(Compressor As Compressor, PersonCompressor As PersonCompressor)
        InitializeComponent()
        Dim XColumn As DataGridViewCheckBoxColumn
        Compressor.WorkedHourSellables.Where(Function(x) x.Status = SimpleStatus.Inactive).ToList.ForEach(Sub(y) Compressor.WorkedHourSellables.Remove(y))
        DgvPartWorkedHour.Fill(Compressor.WorkedHourSellables)
        For Each Column As DataGridViewColumn In DgvPartWorkedHour.Columns
            Column.ReadOnly = True
        Next Column
        XColumn = New DataGridViewCheckBoxColumn With {.Name = "X", .HeaderText = "X".PadRight(3, " ")}
        XColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        XColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        XColumn.DisplayIndex = 0
        DgvPartWorkedHour.Columns.Add(XColumn)
        DgvPartWorkedHour.Columns("Order").HeaderText = "Ordem"
        DgvPartWorkedHour.Columns("Order").Width = 70
        DgvPartWorkedHour.Columns("ID").Visible = False
        DgvPartWorkedHour.Columns("Creation").HeaderText = "Criação"
        DgvPartWorkedHour.Columns("Creation").Width = 100
        DgvPartWorkedHour.Columns("Status").Visible = False
        DgvPartWorkedHour.Columns("PartType").Visible = False
        DgvPartWorkedHour.Columns("Code").HeaderText = "Código"
        DgvPartWorkedHour.Columns("Code").Width = 100
        DgvPartWorkedHour.Columns("ItemName").Visible = False
        DgvPartWorkedHour.Columns("Product").Visible = False
        DgvPartWorkedHour.Columns("Quantity").HeaderText = "Qtd."
        DgvPartWorkedHour.Columns("Quantity").Width = 70
        DgvPartWorkedHour.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvPartWorkedHour.Columns("Quantity").DefaultCellStyle.Format = "N2"
        DgvPartWorkedHour.Columns("LinkedProduct").Visible = False
        DgvPartWorkedHour.Columns("ItemNameOrProduct").HeaderText = "Item"
        DgvPartWorkedHour.Columns("ItemNameOrProduct").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Compressor.ElapsedDaySellables.Where(Function(x) x.Status = SimpleStatus.Inactive).ToList.ForEach(Sub(y) Compressor.ElapsedDaySellables.Remove(y))
        DgvPartElapsedDay.Fill(Compressor.ElapsedDaySellables)
        For Each Column As DataGridViewColumn In DgvPartElapsedDay.Columns
            Column.ReadOnly = True
        Next Column
        XColumn = New DataGridViewCheckBoxColumn With {.Name = "X", .HeaderText = "X".PadRight(3, " ")}
        XColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        XColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        XColumn.DisplayIndex = 0
        DgvPartElapsedDay.Columns.Add(XColumn)
        DgvPartElapsedDay.Columns("Order").HeaderText = "Ordem"
        DgvPartElapsedDay.Columns("Order").Width = 70
        DgvPartElapsedDay.Columns("ID").Visible = False
        DgvPartElapsedDay.Columns("Creation").HeaderText = "Criação"
        DgvPartElapsedDay.Columns("Creation").Width = 100
        DgvPartElapsedDay.Columns("Status").Visible = False
        DgvPartElapsedDay.Columns("PartType").Visible = False
        DgvPartElapsedDay.Columns("Code").HeaderText = "Código"
        DgvPartElapsedDay.Columns("Code").Width = 100
        DgvPartElapsedDay.Columns("ItemName").Visible = False
        DgvPartElapsedDay.Columns("Product").Visible = False
        DgvPartElapsedDay.Columns("Quantity").HeaderText = "Qtd."
        DgvPartElapsedDay.Columns("Quantity").Width = 70
        DgvPartElapsedDay.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvPartElapsedDay.Columns("Quantity").DefaultCellStyle.Format = "N2"
        DgvPartElapsedDay.Columns("LinkedProduct").Visible = False
        DgvPartElapsedDay.Columns("ItemNameOrProduct").HeaderText = "Item"
        DgvPartElapsedDay.Columns("ItemNameOrProduct").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub DgvPartWorkedHour_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPartWorkedHour.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPartWorkedHour.HitTest(e.X, e.Y)
        Dim Cell As DataGridViewCheckBoxCell
        Dim CellValue As Boolean
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            Cell = DgvPartWorkedHour.SelectedRows(0).Cells("X")
            If Cell.IsInEditMode Then Exit Sub
            CellValue = If(Cell.Value, False, True)
            Cell.Value = CellValue
            Cell.EditingCellFormattedValue = CellValue
        End If
        DgvPartWorkedHour.RefreshEdit()
    End Sub
    Private Sub DgvPartElapsedDay_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPartElapsedDay.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPartElapsedDay.HitTest(e.X, e.Y)
        Dim Cell As DataGridViewCheckBoxCell
        Dim CellValue As Boolean
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            Cell = DgvPartElapsedDay.SelectedRows(0).Cells("X")
            If Cell.IsInEditMode Then Exit Sub
            CellValue = If(Cell.Value, False, True)
            Cell.Value = CellValue
            Cell.EditingCellFormattedValue = CellValue
        End If
        DgvPartElapsedDay.RefreshEdit()
    End Sub
    Private Sub DgvPartWorkedHour_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvPartWorkedHour.ColumnHeaderMouseClick
        If e.ColumnIndex = 0 Then
            If DgvPartWorkedHour.Rows.Cast(Of DataGridViewRow).All(Function(x) x.Cells(0).Value = True) Then
                For Each Row As DataGridViewRow In DgvPartWorkedHour.Rows
                    Row.Cells(0).Value = False
                Next Row
            Else
                For Each Row As DataGridViewRow In DgvPartWorkedHour.Rows
                    Row.Cells(0).Value = True
                Next Row
            End If
        End If
        DgvPartWorkedHour.RefreshEdit()
    End Sub
    Private Sub DgvPartElapsedDay_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvPartElapsedDay.ColumnHeaderMouseClick
        If e.ColumnIndex = 0 Then
            If DgvPartElapsedDay.Rows.Cast(Of DataGridViewRow).All(Function(x) x.Cells(0).Value = True) Then
                For Each Row As DataGridViewRow In DgvPartElapsedDay.Rows
                    Row.Cells(0).Value = False
                Next Row
            Else
                For Each Row As DataGridViewRow In DgvPartElapsedDay.Rows
                    Row.Cells(0).Value = True
                Next Row
            End If
        End If
        DgvPartElapsedDay.RefreshEdit()
    End Sub
End Class