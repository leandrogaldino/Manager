Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Public Class FrmCrms
    Private _Crm As New Crm
    Private _Filter As CrmFilter
    Public Sub New()
        InitializeComponent()
        Utility.EnableControlDoubleBuffer(DgvData, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer2.Panel1Collapsed = True
        _Filter = New CrmFilter(DgvData, PgFilter)
        _Filter.Filter()
        PgFilter.SelectedObject = _Filter
        LoadDetails()
        BtnInclude.Visible = Locator.GetInstance(Of Session).User.Privileges.CrmWrite
        BtnEdit.Visible = Locator.GetInstance(Of Session).User.Privileges.CrmWrite
        BtnDelete.Visible = Locator.GetInstance(Of Session).User.Privileges.CrmDelete
        BtnExport.Visible = Locator.GetInstance(Of Session).User.Privileges.SeveralExportGrid
    End Sub
    Private Sub Frm(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvCrmLayout.Load()
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        Dim Form As New FrmCrm(New Crm, Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim CrmForm As FrmCrm
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Crm = New Crm().Load(DgvData.SelectedRows(0).Cells("id").Value, True)
                CrmForm = New FrmCrm(_Crm, Me)
                WebTreatments.Navigate(_Crm.GetHtml())
                CrmForm.ShowDialog()
            Catch ex As Exception
                CMessageBox.Show("ERRO CR005", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Crm.Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                If Not _Crm.LockInfo.IsLocked Then
                    If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Try
                            _Crm.Delete()
                            _Filter.Filter()
                            DgvCrmLayout.Load()
                            DgvData.ClearSelection()
                        Catch ex As MySqlException
                            If ex.Number = 1451 Then
                                CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                            Else
                                CMessageBox.Show("ERRO CR006", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                            End If
                        End Try
                    End If
                Else
                    CMessageBox.Show(String.Format("Esse registro não pode ser excluído no momento pois está sendo utilizado por {0}.", GetTitleCase(_Crm.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO CR007", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        _Filter.Filter()
        DgvCrmLayout.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = If(BtnFilter.Checked, False, True)
        SplitContainer1.SplitterDistance = 350
    End Sub
    Private Sub BtnDetails_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        SplitContainer2.Panel1Collapsed = Not BtnDetails.Checked
        SplitContainer2.SplitterDistance = 450
        LoadDetails()
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
        DgvCrmLayout.Load()
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
        Select Case Dgv.Rows(e.RowIndex).Cells("status").Value
            Case Is = GetEnumDescription(CrmStatus.Pending)
                If Dgv.Rows(e.RowIndex).Cells("Próx. Contato").Value > Today Then
                    Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightBlue
                    Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkBlue
                    Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Bisque
                    Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkOrange
                    Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Orange
                End If
            Case Is = GetEnumDescription(CrmStatus.Finished)
                Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightGreen
                Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkGreen
                Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
            Case Is = GetEnumDescription(CrmStatus.Lost)
                Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightCoral
                Dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.DarkRed
                Dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End Select
    End Sub
    Private Sub DgvData_SelectionChanged(sender As Object, e As EventArgs) Handles DgvData.SelectionChanged
        TmrLoadDetails.Start()
        If DgvData.SelectedRows.Count = 0 Then
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        End If
    End Sub
    Private Sub TmrLoadDetails_Tick(sender As Object, e As EventArgs) Handles TmrLoadDetails.Tick
        LoadDetails()
        TmrLoadDetails.Stop()
    End Sub
    Private Sub PgFilter_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PgFilter.PropertyValueChanged
        _Filter.Filter()
    End Sub
    Private Sub LoadDetails()
        Dim CrmID As Long
        If BtnDetails.Checked Then
            If DgvData.SelectedRows.Count = 1 Then
                CrmID = DgvData.SelectedRows(0).Cells("id").Value
                Try
                    WebTreatments.Navigate(Crm.GetHtml(CrmID))
                Catch ex As Exception
                    TmrLoadDetails.Stop()
                    WebTreatments.Navigate("about:blank")
                    CMessageBox.Show("ERRO CR008", "Ocorreu um erro ao consultar os dados do registro selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            Else
                WebTreatments.Navigate("about:blank")
            End If
        End If
    End Sub
    Private Sub DgvData_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvData.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEdit.PerformClick()
            e.Handled = True
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
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "CRM", .Grid = DgvData}})
        Dim FormReport As New FrmReport(Result)
        FrmMain.OpenTab(FormReport, GetEnumDescription(Routine.ExportGrid))
    End Sub
End Class