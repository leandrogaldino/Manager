Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Public Class UcPersonGrid
    Private _Person As New Person
    Private _Filter As PersonFilter
    Public Sub New()
        InitializeComponent()
        ControlHelper.EnableControlDoubleBuffer(DgvData, True)
        ControlHelper.EnableControlDoubleBuffer(DgvAddress, True)
        ControlHelper.EnableControlDoubleBuffer(DgvCompressor, True)
        ControlHelper.EnableControlDoubleBuffer(DgvContact, True)
        SplitContainer1.Panel1Collapsed = True
        SplitContainer1.SplitterDistance = 250
        SplitContainer2.Panel1Collapsed = True
        SplitContainer2.SplitterDistance = 500
        _Filter = New PersonFilter(DgvData, PgFilter)
        _Filter.Filter()
        PgFilter.SelectedObject = _Filter
        LoadDetails()
        BtnInclude.Visible = Locator.GetInstance(Of Session).User.CanWrite(Routine.Person)
        BtnEdit.Visible = Locator.GetInstance(Of Session).User.CanWrite(Routine.Person)
        BtnDelete.Visible = Locator.GetInstance(Of Session).User.CanDelete(Routine.Person)
        BtnExport.Visible = Locator.GetInstance(Of Session).User.CanAccess(Routine.ExportGrid)
    End Sub
    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvlPerson.Load()
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        Using Form As New FrmPerson(New Person, Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Person = New Person().Load(CLng(DgvData.SelectedRows(0).Cells("id").Value), True)
                Using Form As New FrmPerson(_Person, Me)
                    Form.DgvCompressor.Fill(_Person.Compressors)
                    Form.DgvAddress.Fill(_Person.Addresses)
                    Form.DgvContact.Fill(_Person.Contacts)
                    Form.ShowDialog()
                End Using
            Catch ex As Exception
                CMessageBox.Show("ERRO PS007", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DgvData.SelectedRows.Count = 1 Then
            Try
                Cursor = Cursors.WaitCursor
                _Person.Load(DgvData.SelectedRows(0).Cells("id").Value, False)
                If Not _Person.LockInfo.IsLocked Then
                    If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Try
                            _Person.Delete()
                            _Filter.Filter()
                            DgvlPerson.Load()
                            DgvData.ClearSelection()
                        Catch ex As MySqlException
                            If ex.Number = 1451 Then
                                CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                            Else
                                CMessageBox.Show("ERRO PS008", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                            End If
                        End Try
                    End If
                Else
                    CMessageBox.Show(String.Format("Esse registro não pode ser excluído no momento pois está sendo utilizado por {0}.", _Person.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO PS009", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        _Filter.Filter()
        DgvlPerson.Load()
        DgvData.ClearSelection()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        SplitContainer1.Panel1Collapsed = If(BtnFilter.Checked, False, True)
        SplitContainer1.SplitterDistance = 350
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dim Index As Integer
        Dim Page As TabPage
        If Not Control.ModifierKeys = Keys.Shift Then
            Index = FrmMain.TcWindows.SelectedIndex
            Page = FrmMain.TcWindows.SelectedTab
            FrmMain.TcWindows.TabPages.Remove(Page)
            Page.Dispose()
            If Index > 0 Then
                FrmMain.TcWindows.SelectTab(Index - 1)
            End If
        Else
            For Each Page In FrmMain.TcWindows.TabPages
                FrmMain.TcWindows.TabPages.Remove(Page)
                Page.Controls(0).Dispose()
                Page.Dispose()
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
        DgvlPerson.Load()
        LblStatus.Text = Nothing
        LblStatus.ForeColor = Color.Black
        LblStatus.Font = New Font(LblStatus.Font, FontStyle.Regular)
    End Sub
    Private Sub BtnDetails_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        SplitContainer2.Panel1Collapsed = Not BtnDetails.Checked
        LoadDetails()
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
        DgvlPerson.Load()
    End Sub
    Private Sub LoadDetails()
        If BtnDetails.Checked Then
            If DgvData.SelectedRows.Count = 1 Then
                Try
                    Person.FillAddressDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvAddress)
                    Person.FillCompressorDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvCompressor)
                    Person.FillContactDataGridView(DgvData.SelectedRows(0).Cells("id").Value, DgvContact)
                Catch ex As Exception
                    TmrLoadDetails.Stop()
                    CMessageBox.Show("ERRO PS010", "Ocorreu um erro ao consultar os dados do registro selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            Else
                DgvCompressor.DataSource = Nothing
                DgvAddress.DataSource = Nothing
                DgvContact.DataSource = Nothing
            End If
        End If
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
    <DebuggerStepThrough>
    Private Sub DgvCompressors_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvCompressor.CellFormatting
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
    <DebuggerStepThrough>
    Private Sub DgvAddress_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvAddress.CellFormatting
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
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim Result As ReportResult = ExportGrid.Export({New ExportGrid.ExportGridInfo With {.Title = "Pessoas", .Grid = DgvData}})
        FrmMain.OpenTab(New UcReport(Result), "Grade Exportada")
    End Sub
End Class
