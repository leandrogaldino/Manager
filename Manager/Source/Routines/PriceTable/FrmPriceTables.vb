Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient

Public Class FrmPriceTables
    Private _PriceTable As New PriceTable
    Private _Filter As PriceTableFilter
    Public Sub New()
        InitializeComponent()
        ControlHelper.EnableControlDoubleBuffer(DgvData, True)
        ControlHelper.EnableControlDoubleBuffer(DgvItems, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer2.Panel1Collapsed = True
        _Filter = New PriceTableFilter(DgvData, PgFilter)
        _Filter.Filter()
        PgFilter.SelectedObject = _Filter
        BtnInclude.Visible = Locator.GetInstance(Of Session).User.CanWrite(Routine.PriceTable)
        BtnEdit.Visible = Locator.GetInstance(Of Session).User.CanWrite(Routine.PriceTable)
        BtnDelete.Visible = Locator.GetInstance(Of Session).User.CanDelete(Routine.PriceTable)
        BtnExport.Visible = Locator.GetInstance(Of Session).User.CanAccess(Routine.ExportGrid)
    End Sub
    Private Sub Frm(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvPriceTablesLayout.Load()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        Dim Form As New FrmPriceTable(New PriceTable(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim Form As FrmPriceTable
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _PriceTable = New PriceTable().Load(DgvData.SelectedRows(0).Cells("id").Value, True)
                Form = New FrmPriceTable(_PriceTable, Me)
                Form.DgvPriceTableItem.Fill(_PriceTable.Items)
                Form.ShowDialog()
            Catch ex As Exception
                CMessageBox.Show("ERRO PT001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _PriceTable.Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                If Not _PriceTable.LockInfo.IsLocked Then
                    If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Try
                            _PriceTable.Delete()
                            _Filter.Filter()
                            DgvPriceTablesLayout.Load()
                            DgvData.ClearSelection()
                        Catch ex As MySqlException
                            If ex.Number = 1451 Then
                                CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                            Else
                                CMessageBox.Show("ERRO PT002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                            End If
                        End Try
                    End If
                Else
                    CMessageBox.Show(String.Format("Esse registro não pode ser excluído no momento pois está sendo utilizado por {0}.", _PriceTable.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO PT003", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        _Filter.Filter()
        DgvPriceTablesLayout.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = Not BtnFilter.Checked
        SplitContainer1.SplitterDistance = 350
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dim Index As Integer
        If Not Control.ModifierKeys = Keys.Shift Then
            Index = FrmMain.TcWindows.SelectedIndex
            FrmMain.TcWindows.TabPages.Remove(FrmMain.TcWindows.SelectedTab)
            If Index > 0 Then
                FrmMain.TcWindows.SelectTab(Index - 1)
            End If
        Else
            For Each Page As TabPage In FrmMain.TcWindows.TabPages
                FrmMain.TcWindows.TabPages.Remove(Page)
            Next Page
        End If
    End Sub
    Private Sub BtnCloseFilter_Click(sender As Object, e As EventArgs) Handles BtnCloseFilter.Click
        SplitContainer1.Panel1Collapsed = True
        BtnFilter.Checked = False
    End Sub
    Private Sub BtnClean_Click(sender As Object, e As EventArgs) Handles BtnClean.Click
        _Filter.Clean()
        _Filter.Filter()
        PgFilter.Refresh()
        DgvPriceTablesLayout.Load()
        LblStatus.Text = Nothing
        LblStatus.ForeColor = Color.Black
        LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
    End Sub
    Private Sub BtnDetails_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        SplitContainer2.Panel1Collapsed = Not BtnDetails.Checked
    End Sub
    Private Sub BtnCloseDetails_Click(sender As Object, e As EventArgs) Handles BtnCloseDetails.Click
        SplitContainer2.Panel1Collapsed = True
        BtnDetails.Checked = False
    End Sub
    Private Sub DgvData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvData.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvData.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEdit.PerformClick()
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvData.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Status").Index Then
            Select Case e.Value
                Case Is = EnumHelper.GetEnumDescription(SimpleStatus.Active)
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case Is = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
                    e.CellStyle.ForeColor = Color.DarkRed
            End Select
        End If
    End Sub
    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvData.SelectionChanged
        If DgvData.SelectedRows.Count = 0 Then
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        End If
    End Sub
    Private Sub PgFilter_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PgFilter.PropertyValueChanged
        If _Filter.Filter() = True Then
            LblStatus.Text = "Filtro Ativo"
            LblStatus.ForeColor = Color.DarkRed
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Bold)
        Else
            LblStatus.Text = String.Empty
            LblStatus.ForeColor = Color.Black
            LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
        End If
        DgvPriceTablesLayout.Load()
    End Sub
    Private Sub DgvData_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvData.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEdit.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub DgvData_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvData.DataSourceChanged
        If DgvData.Rows.Count > 0 Then
            LblCounter.Text = DgvData.Rows.Count & " registro" & If(DgvData.Rows.Count > 1, "s", Nothing)
            LblCounter.ForeColor = Color.DimGray
            LblCounter.Font = New Font(LblCounter.Font, FontStyle.Bold)
        End If
    End Sub

    Private Sub TmrLoadDetails_Tick(sender As Object, e As EventArgs) Handles TmrLoadDetails.Tick

    End Sub
    Private Sub LoadDetails()
        If BtnDetails.Checked Then
            If DgvData.SelectedRows.Count = 1 Then
                Try
                    PriceTable.FillItemsDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvItems)
                Catch ex As Exception
                    TmrLoadDetails.Stop()
                    CMessageBox.Show("ERRO PT004", "Ocorreu um erro ao consultar os dados do registro selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            Else
                DgvItems.DataSource = Nothing
            End If
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub FrmMain_ResizeEnd(sender As Object, e As EventArgs)
        If BtnFilter.Checked Then BtnFilter.PerformClick()
        If Parent.FindForm IsNot Nothing Then
            Height = Parent.FindForm.Height - 196
            Width = Parent.FindForm.Width - 24
        End If
    End Sub
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "Tabelas de Preço", .Grid = DgvData}})
        Dim FormReport As New FrmReport(Result)
        FrmMain.OpenTab(FormReport, EnumHelper.GetEnumDescription(Routine.ExportGrid))
    End Sub
End Class