Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmPersonMaintenancePlan
    Private _Person As Person
    <DebuggerStepThrough>
    Protected Overrides Sub DefWndProc(ByRef m As Message)
        Const _MouseButtonDown As Long = &HA1
        Const _MouseButtonUp As Long = &HA0
        Const _CloseButton As Long = 20
        If CLng(m.Msg) = _MouseButtonDown And Not m.WParam = _CloseButton Then
            If Opacity <> 0.5 Then Opacity = 0.5
        ElseIf CLng(m.Msg) = _MouseButtonUp Then
            If Opacity <> 1.0 Then Opacity = 1.0
        End If
        MyBase.DefWndProc(m)
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        QbxPerson.Select()
        BtnGenerate.Enabled = False
        Size = New Size(500, 155)
    End Sub
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim Result As ReportResult
        Try
            Cursor = Cursors.WaitCursor
            BtnGenerate.Enabled = False
            Result = PersonReport.ProcessMaintenancePlan(DgvCompressor, _Person, CbxShowTechnicalAdvice.Checked, CbxShowMDHT.Checked)
            DialogResult = DialogResult.OK
            FrmMain.OpenTab(New FrmReport(Result), GetEnumDescription(Routine.PersonMaintenancePlan))
        Catch ex As Exception
            CMessageBox.Show("ERRO PS012", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            BtnGenerate.Enabled = True
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub QbxPerson_Enter(sender As Object, e As EventArgs) Handles QbxPerson.Enter
        TmrQueriedBox.Stop()
        BtnViewPerson.Visible = QbxPerson.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnNewPerson.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnFilterPerson.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonAccess
    End Sub
    Private Sub QbxPerson_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPerson.FreezedPrimaryKeyChanged
        Dim XColumn As DataGridViewCheckBoxColumn
        Try
            Cursor = Cursors.WaitCursor
            _Person = New Person().Load(QbxPerson.FreezedPrimaryKey, False)
            DgvCompressor.Columns.Clear()
            _Person.Compressors.FillDataGridView(DgvCompressor)
            DgvCompressor.Columns("Order").Visible = False
            DgvCompressor.Columns("ID").Visible = False
            DgvCompressor.Columns("Creation").Visible = False
            DgvCompressor.Columns("Status").Visible = False
            DgvCompressor.Columns("Note").Visible = False
            DgvCompressor.Columns("Compressor").ReadOnly = True
            DgvCompressor.Columns("Compressor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvCompressor.Columns("SerialNumber").ReadOnly = True
            DgvCompressor.Columns("SerialNumber").HeaderText = "Nº de Série"
            DgvCompressor.Columns("SerialNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvCompressor.Columns("Patrimony").ReadOnly = True
            DgvCompressor.Columns("Patrimony").HeaderText = "Patrimônio"
            DgvCompressor.Columns("Patrimony").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvCompressor.Columns("Sector").HeaderText = "Setor"
            DgvCompressor.Columns("Sector").ReadOnly = True
            DgvCompressor.Columns("Sector").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DgvCompressor.Columns("UnitCapacity").Visible = False
            XColumn = New DataGridViewCheckBoxColumn With {.Name = "X", .HeaderText = "X".PadRight(3, " ")}
            XColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            XColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            XColumn.DisplayIndex = 0
            XColumn.ReadOnly = False
            DgvCompressor.Columns.Add(XColumn)
            LblCompressor.Text = If(DgvCompressor.Rows.Count > 1, "Compressores", "Compressor")
            Dim Ex As New List(Of String)
            For Each Row As DataGridViewRow In DgvCompressor.Rows.Cast(Of DataGridViewRow).Reverse
                If Evaluation.GetLastEvaluationID(Row.Cells("ID").Value) = 0 Or Evaluation.CountEvaluation(Row.Cells("ID").Value, {EvaluationStatus.Disapproved, EvaluationStatus.Rejected, EvaluationStatus.Reviewed}.ToList) > 0 Then
                    Ex.Add(String.Format("{0} {1} {2} {3}", Row.Cells("Compressor").Value, If(Row.Cells("SerialNumber").Value = Nothing, Nothing, "NS: " & Row.Cells("SerialNumber").Value), If(Row.Cells("Patrimony").Value = Nothing, Nothing, "PAT: " & Row.Cells("Patrimony").Value), If(Row.Cells("Sector").Value = Nothing, Nothing, "- " & Row.Cells("Sector").Value)))
                    DgvCompressor.Rows.Remove(Row)
                End If
            Next Row
            If Ex.Count > 0 Then
                If Ex.Count = 1 Then
                    Ex.Insert(0, "O compressor abaixo não foi exibido pois não há avaliação lançada ou existe pelo menos uma avaliação não aprovada para ele.")
                ElseIf Ex.Count > 1 Then
                    Ex.Insert(0, "Os compressores abaixo não foram exibidos pois não há avaliação lançada ou existe pelo menos uma avaliação não aprovada para ele.")
                End If
                EprInformation.SetIconPadding(LblCompressor, -20)
                EprInformation.SetError(LblCompressor, Join(Ex.ToArray, vbNewLine))
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO PS011", "Ocorreu ao selecionar a pessoa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            If QbxPerson.IsFreezed Then
                If Locator.GetInstance(Of Session).User.Privilege.PersonWrite Then
                    BtnViewPerson.Visible = True
                Else
                    BtnViewPerson.Visible = False
                End If
                'BtnGenerate.Enabled = True
                Size = New Size(500, 475)
            Else
                'BtnGenerate.Enabled = False
                Size = New Size(500, 155)
            End If
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub QbxPerson_Leave(sender As Object, e As EventArgs) Handles QbxPerson.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub BtnNewPerson_Click(sender As Object, e As EventArgs) Handles BtnNewPerson.Click
        Dim Person As Person
        Dim Form As FrmPerson
        Person = New Person
        Person.IsCustomer = True
        Person.ControlMaintenance = True
        Form = New FrmPerson(Person)
        Form.CbxIsCustomer.Enabled = False
        Form.CbxMaintenance.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Person.ID > 0 Then
            QbxPerson.Freeze(Person.ID)
        End If
        QbxPerson.Select()
    End Sub
    Private Sub BtnViewPerson_Click(sender As Object, e As EventArgs) Handles BtnViewPerson.Click
        Dim Form As New FrmPerson(New Person().Load(QbxPerson.FreezedPrimaryKey, True))
        Form.CbxIsCustomer.Enabled = False
        Form.CbxMaintenance.Enabled = False
        Form.ShowDialog()
        QbxPerson.Freeze(QbxPerson.FreezedPrimaryKey)
        QbxPerson.Select()
    End Sub
    Private Sub BtnFilterPerson_Click(sender As Object, e As EventArgs) Handles BtnFilterPerson.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonCustomerQueriedBoxFilter("Sim"), QbxPerson)
        FilterForm.Text = "Filtro de Clientes"
        FilterForm.ShowDialog()
        QbxPerson.Select()
    End Sub
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnViewPerson.Visible = False
        BtnNewPerson.Visible = False
        BtnFilterPerson.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub DgvCompressor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCompressor.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCompressor.HitTest(e.X, e.Y)
        Dim Cell As DataGridViewCheckBoxCell
        Dim CellValue As Boolean
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            Cell = DgvCompressor.SelectedRows(0).Cells("X")
            If Cell.IsInEditMode Then Exit Sub
            CellValue = If(Cell.Value, False, True)
            Cell.Value = CellValue
            Cell.EditingCellFormattedValue = CellValue
        End If
        DgvCompressor.RefreshEdit()
        BtnGenerate.Enabled = DgvCompressor.Rows.Cast(Of DataGridViewRow).Any(Function(x) x.Cells("X").Value = True)
    End Sub
    Private Sub DgvCompressor_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvCompressor.ColumnHeaderMouseClick
        If e.ColumnIndex = DgvCompressor.Columns("X").Index Then
            If DgvCompressor.Rows.Cast(Of DataGridViewRow).All(Function(x) x.Cells("x").Value = True) Then
                For Each Row As DataGridViewRow In DgvCompressor.Rows
                    Row.Cells("X").Value = False
                Next Row
            Else
                For Each Row As DataGridViewRow In DgvCompressor.Rows
                    Row.Cells("X").Value = True
                Next Row
            End If
        End If
        DgvCompressor.RefreshEdit()
        BtnGenerate.Enabled = DgvCompressor.Rows.Cast(Of DataGridViewRow).Any(Function(x) x.Cells("X").Value = True)
    End Sub
    Private Sub DgvCompressor_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCompressor.CellContentClick
        If e.RowIndex = DgvCompressor.SelectedRows(0).Cells("X").RowIndex Then
            DgvCompressor.EndEdit()
            BtnGenerate.Enabled = DgvCompressor.Rows.Cast(Of DataGridViewRow).Any(Function(x) x.Cells("X").Value = True)
        End If
    End Sub
End Class