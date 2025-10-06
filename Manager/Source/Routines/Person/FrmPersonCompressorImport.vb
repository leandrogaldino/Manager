Imports ControlLibrary.Extensions
Public Class FrmPersonCompressorImport
    Public Sub New(Compressor As Compressor, PersonCompressor As PersonCompressor)
        InitializeComponent()
        Dim XColumn As DataGridViewCheckBoxColumn
        Compressor.WorkedHourSellables.Where(Function(x) x.Status = SimpleStatus.Inactive).ToList.ForEach(Sub(y) Compressor.WorkedHourSellables.Remove(y))
        DgvWorkedHourSellable.Fill(Compressor.WorkedHourSellables)
        For Each Column As DataGridViewColumn In DgvWorkedHourSellable.Columns
            Column.ReadOnly = True
        Next Column
        XColumn = New DataGridViewCheckBoxColumn With {.Name = "X", .HeaderText = "X".PadRight(3, " ")}
        XColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        XColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        XColumn.DisplayIndex = 0
        DgvWorkedHourSellable.Columns.Add(XColumn)
        DgvWorkedHourSellable.Columns("Order").HeaderText = "Ordem"
        DgvWorkedHourSellable.Columns("Order").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvWorkedHourSellable.Columns("Order").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgvWorkedHourSellable.Columns("Status").Visible = False
        DgvWorkedHourSellable.Columns("SellableType").Visible = False
        DgvWorkedHourSellable.Columns("SellableControlType").Visible = False
        DgvWorkedHourSellable.Columns("Sellable").Visible = False
        DgvWorkedHourSellable.Columns("SellableID").Visible = False
        DgvWorkedHourSellable.Columns("Code").HeaderText = "Código"
        DgvWorkedHourSellable.Columns("Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvWorkedHourSellable.Columns("Name").HeaderText = "Produto/Serviço"
        DgvWorkedHourSellable.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvWorkedHourSellable.Columns("Quantity").HeaderText = "Qtd."
        DgvWorkedHourSellable.Columns("Quantity").Width = 70
        DgvWorkedHourSellable.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvWorkedHourSellable.Columns("Quantity").DefaultCellStyle.Format = "N2"
        DgvWorkedHourSellable.Columns("Guid").Visible = False
        DgvWorkedHourSellable.Columns("ID").Visible = False
        DgvWorkedHourSellable.Columns("Creation").Visible = False
        DgvWorkedHourSellable.Columns("Routine").Visible = False
        DgvWorkedHourSellable.Columns("IsSaved").Visible = False
        DgvWorkedHourSellable.Columns("User").Visible = False
        Compressor.ElapsedDaySellables.Where(Function(x) x.Status = SimpleStatus.Inactive).ToList.ForEach(Sub(y) Compressor.ElapsedDaySellables.Remove(y))
        DgvElapsedDaySellable.Fill(Compressor.ElapsedDaySellables)
        For Each Column As DataGridViewColumn In DgvElapsedDaySellable.Columns
            Column.ReadOnly = True
        Next Column
        XColumn = New DataGridViewCheckBoxColumn With {.Name = "X", .HeaderText = "X".PadRight(3, " ")}
        XColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        XColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        XColumn.DisplayIndex = 0
        DgvElapsedDaySellable.Columns.Add(XColumn)
        DgvElapsedDaySellable.Columns("Order").HeaderText = "Ordem"
        DgvElapsedDaySellable.Columns("Order").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvElapsedDaySellable.Columns("Order").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgvElapsedDaySellable.Columns("Status").Visible = False
        DgvElapsedDaySellable.Columns("SellableType").Visible = False
        DgvElapsedDaySellable.Columns("SellableControlType").Visible = False
        DgvElapsedDaySellable.Columns("Sellable").Visible = False
        DgvElapsedDaySellable.Columns("SellableID").Visible = False
        DgvElapsedDaySellable.Columns("Code").HeaderText = "Código"
        DgvElapsedDaySellable.Columns("Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvElapsedDaySellable.Columns("Name").HeaderText = "Produto/Serviço"
        DgvElapsedDaySellable.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvElapsedDaySellable.Columns("Quantity").HeaderText = "Qtd."
        DgvElapsedDaySellable.Columns("Quantity").Width = 70
        DgvElapsedDaySellable.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgvElapsedDaySellable.Columns("Quantity").DefaultCellStyle.Format = "N2"
        DgvElapsedDaySellable.Columns("Guid").Visible = False
        DgvElapsedDaySellable.Columns("ID").Visible = False
        DgvElapsedDaySellable.Columns("Creation").Visible = False
        DgvElapsedDaySellable.Columns("Routine").Visible = False
        DgvElapsedDaySellable.Columns("IsSaved").Visible = False
        DgvElapsedDaySellable.Columns("User").Visible = False
    End Sub
    Private Sub DgvWorkedHourSellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvWorkedHourSellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvWorkedHourSellable.HitTest(e.X, e.Y)
        Dim Cell As DataGridViewCheckBoxCell
        Dim CellValue As Boolean
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            Cell = DgvWorkedHourSellable.SelectedRows(0).Cells("X")
            If Cell.IsInEditMode Then Exit Sub
            CellValue = If(Cell.Value, False, True)
            Cell.Value = CellValue
            Cell.EditingCellFormattedValue = CellValue
        End If
        DgvWorkedHourSellable.RefreshEdit()
    End Sub
    Private Sub DgvElapsedDaySellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvElapsedDaySellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvElapsedDaySellable.HitTest(e.X, e.Y)
        Dim Cell As DataGridViewCheckBoxCell
        Dim CellValue As Boolean
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            Cell = DgvElapsedDaySellable.SelectedRows(0).Cells("X")
            If Cell.IsInEditMode Then Exit Sub
            CellValue = If(Cell.Value, False, True)
            Cell.Value = CellValue
            Cell.EditingCellFormattedValue = CellValue
        End If
        DgvElapsedDaySellable.RefreshEdit()
    End Sub
    Private Sub DgvWorkedHourSellable_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvWorkedHourSellable.ColumnHeaderMouseClick
        If e.ColumnIndex = 0 Then
            If DgvWorkedHourSellable.Rows.Cast(Of DataGridViewRow).All(Function(x) x.Cells(0).Value = True) Then
                For Each Row As DataGridViewRow In DgvWorkedHourSellable.Rows
                    Row.Cells(0).Value = False
                Next Row
            Else
                For Each Row As DataGridViewRow In DgvWorkedHourSellable.Rows
                    Row.Cells(0).Value = True
                Next Row
            End If
        End If
        DgvWorkedHourSellable.RefreshEdit()
    End Sub
    Private Sub DgvElapsedDaySellable_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvElapsedDaySellable.ColumnHeaderMouseClick
        If e.ColumnIndex = 0 Then
            If DgvElapsedDaySellable.Rows.Cast(Of DataGridViewRow).All(Function(x) x.Cells(0).Value = True) Then
                For Each Row As DataGridViewRow In DgvElapsedDaySellable.Rows
                    Row.Cells(0).Value = False
                Next Row
            Else
                For Each Row As DataGridViewRow In DgvElapsedDaySellable.Rows
                    Row.Cells(0).Value = True
                Next Row
            End If
        End If
        DgvElapsedDaySellable.RefreshEdit()
    End Sub
End Class