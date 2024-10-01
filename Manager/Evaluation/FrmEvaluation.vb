Imports System.IO
Imports ControlLibrary
Imports MySql.Data.MySqlClient
Imports ControlLibrary.Utility
Imports ManagerCore
Public Class FrmEvaluation
    Public Evaluation As Evaluation
    Private _EvaluationsForm As FrmEvaluations
    Private _EvaluationsGrid As DataGridView
    Private _Filter As EvaluationFilter
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _Calculated As Boolean
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(Evaluation As Evaluation, EvaluationsForm As FrmEvaluations)
        Me.Evaluation = Evaluation
        _EvaluationsForm = EvaluationsForm
        _EvaluationsGrid = _EvaluationsForm.DgvData
        _Filter = CType(_EvaluationsForm.PgFilter.SelectedObject, EvaluationFilter)
        InitializeComponent()
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(Evaluation As Evaluation)
        Me.Evaluation = Evaluation
        InitializeComponent()
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        TcEvaluation.Height -= TsNavigation.Height
        Height -= TsNavigation.Height
        LoadData()
        LoadForm()
        LblStatus.Visible = True
        LblStatusValue.Visible = True
        BtnStatusValue.Visible = False
    End Sub
    Private Sub LoadForm()
        Utility.EnableDataGridViewDoubleBuffer(DgvPartWorkedHour, True)
        Utility.EnableDataGridViewDoubleBuffer(DgvPartElapsedDay, True)
        DgvNavigator.DataGridView = _EvaluationsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralLogAccess
        BtnStatusValue.Visible = Locator.GetInstance(Of Session).User.Privilege.EvaluationApproveOrReject
        LblStatusValue.Visible = Not Locator.GetInstance(Of Session).User.Privilege.EvaluationApproveOrReject
        LblDocumentPage.Text = Nothing
        Size = If(_Calculated, New Size(1050, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height)), New Size(433, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height)))
    End Sub
    Private Sub LoadData()
        _Loading = True
        TcEvaluation.SelectedTab = TabMain
        LblIDValue.Text = Evaluation.ID
        BtnStatusValue.Text = GetEnumDescription(Evaluation.Status)
        BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO DA REJEIÇÃO" & vbNewLine & Evaluation.RejectReason)
        LblStatusValue.Text = GetEnumDescription(Evaluation.Status)
        LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO DA REJEIÇÃO" & vbNewLine & Evaluation.RejectReason)
        LblCreationValue.Text = Evaluation.Creation.ToString("dd/MM/yyyy")
        BtnApprove.Visible = Evaluation.Status <> EvaluationStatus.Approved
        BtnReject.Visible = Evaluation.Status <> EvaluationStatus.Rejected
        BtnDisapprove.Visible = Evaluation.Status <> EvaluationStatus.Disapproved
        RbtGathering.Checked = Evaluation.EvaluationType = EvaluationType.Gathering
        RbtExecution.Checked = Evaluation.EvaluationType = EvaluationType.Execution
        DbxEvaluationDate.Text = Evaluation.EvaluationDate
        TxtStartTime.Text = Evaluation.StartTime.ToString("hh\:mm")
        TxtEndTime.Text = Evaluation.EndTime.ToString("hh\:mm")
        TxtEvaluationNumber.Text = Evaluation.EvaluationNumber
        TxtResponsible.Text = Evaluation.Responsible
        QbxCompressor.Conditions.Clear()
        QbxCompressor.Parameters.Clear()
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "statusid", .[Operator] = "=", .Value = "@statusid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@statusid", .ParameterValue = 0})
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "personid", .[Operator] = "=", .Value = "@personid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@personid", .ParameterValue = QbxCustomer.FreezedPrimaryKey})
        QbxCustomer.Unfreeze()
        QbxCustomer.Freeze(Evaluation.Customer.ID)
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(Evaluation.Compressor.ID)
        DbxHorimeter.Text = Evaluation.Horimeter
        CbxManualAverageWorkLoad.Checked = Evaluation.ManualAverageWorkLoad
        DbxAverageWorkLoad.Text = Evaluation.AverageWorkLoad
        TxtTechnicalAdvice.Text = Evaluation.TechnicalAdvice
        FillDataGridViewTechnician()
        If Evaluation.ID > 0 Then
            For Each p As EvaluationPart In Evaluation.PartsWorkedHour.Reverse()
                If Not p.IsSaved Then
                    Evaluation.PartsWorkedHour.Remove(p)
                End If
            Next p
            For Each p As EvaluationPart In Evaluation.PartsElapsedDay.Reverse()
                If Not p.IsSaved Then
                    Evaluation.PartsElapsedDay.Remove(p)
                End If
            Next p
            FillDataGridViewPart(DgvPartWorkedHour, Evaluation.PartsWorkedHour)
            If DgvPartWorkedHour.Rows.Count > 0 Then
                DgvPartWorkedHour.Rows(0).Selected = True
                DgvPartWorkedHour.FirstDisplayedScrollingRowIndex = 0
            End If
            FillDataGridViewPart(DgvPartElapsedDay, Evaluation.PartsElapsedDay)
            If DgvPartElapsedDay.Rows.Count > 0 Then
                DgvPartElapsedDay.Rows(0).Selected = True
                DgvPartElapsedDay.FirstDisplayedScrollingRowIndex = 0
            End If
            Size = New Size(1050, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            _Calculated = True
            BtnCalculate.Text = "Recalcular"
        Else
            Decalculate()
            BtnCalculate.Text = "Calcular"
        End If
        If Not String.IsNullOrEmpty(Evaluation.DocumentName.CurrentFile) AndAlso File.Exists(Evaluation.DocumentName.CurrentFile) Then
            PdfDocumentViewer.Load(New MemoryStream(File.ReadAllBytes(Evaluation.DocumentName.CurrentFile)))
            LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
            BtnDeletePDF.Enabled = True
            BtnSavePDF.Enabled = True
            BtnPrintPDF.Enabled = True
            BtnZoomIn.Enabled = True
            BtnZoomOut.Enabled = True
        Else
            PdfDocumentViewer.Unload()
            LblDocumentPage.Text = Nothing
            BtnDeletePDF.Enabled = False
            BtnSavePDF.Enabled = False
            BtnPrintPDF.Enabled = False
            BtnZoomIn.Enabled = False
            BtnZoomOut.Enabled = False
        End If
        BtnDelete.Enabled = Evaluation.ID > 0 And Locator.GetInstance(Of Session).User.Privilege.EvaluationDelete
        Text = "Avaliação de Compressor"
        If Evaluation.LockInfo.IsLocked And Not Evaluation.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not Evaluation.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", GetTitleCase(Evaluation.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtEvaluationNumber.Select()
        _Loading = False
    End Sub
    Public Sub FillDataGridViewPart(Dgv As DataGridView, Parts As OrdenedList(Of EvaluationPart))
        Dim View As DataView
        Dim FirstDisplayedRowIndex As Integer
        Dim SelectedRowIndex As Integer
        Dim CurrentCellIndex As Integer = -1
        If Dgv.SelectedRows.Count = 1 Then
            FirstDisplayedRowIndex = Dgv.FirstDisplayedScrollingRowIndex
            SelectedRowIndex = Dgv.SelectedRows(0).Index
            If Dgv.CurrentCell IsNot Nothing Then CurrentCellIndex = Dgv.CurrentCell.ColumnIndex
        End If
        Parts.FillDataGridView(Dgv)
        View = New DataView(Dgv.DataSource, Nothing, "Part Asc", DataViewRowState.CurrentRows)
        Dgv.DataSource = View
        If Dgv.SelectedRows.Count = 1 And Dgv.Rows.Count - 1 >= SelectedRowIndex Then
            Dgv.Rows(SelectedRowIndex).Selected = True
            Dgv.FirstDisplayedScrollingRowIndex = FirstDisplayedRowIndex
            If Dgv.CurrentCell IsNot Nothing AndAlso CurrentCellIndex >= 0 And _Calculated Then
                Dgv.CurrentCell = Dgv.Rows(SelectedRowIndex).Cells(CurrentCellIndex)
            End If
        End If
        Dgv.Columns(0).Visible = False
        Dgv.Columns(1).Visible = False
        Dgv.Columns(2).Visible = False
        Dgv.Columns(3).HeaderText = "Código"
        Dgv.Columns(3).Width = 100
        Dgv.Columns(4).HeaderText = "Item"
        Dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Dgv.Columns(5).HeaderText = "Cap. Atual"
        Dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dgv.Columns(5).Width = 105
        Dgv.Columns(6).HeaderText = "Vendido"
        Dgv.Columns(6).Width = 70
        Dgv.Columns(7).HeaderText = "Perdido"
        Dgv.Columns(7).Width = 70
    End Sub
    Public Sub FillDataGridViewTechnician()
        Dim View As DataView
        Dim FirstDisplayedRowIndex As Integer
        Dim SelectedRowIndex As Integer
        Dim CurrentCellIndex As Integer = -1
        If DgvTechnician.SelectedRows.Count = 1 Then
            FirstDisplayedRowIndex = DgvTechnician.FirstDisplayedScrollingRowIndex
            SelectedRowIndex = DgvTechnician.SelectedRows(0).Index
            If DgvTechnician.CurrentCell IsNot Nothing Then CurrentCellIndex = DgvTechnician.CurrentCell.ColumnIndex
        End If
        Evaluation.Technicians.FillDataGridView(DgvTechnician)
        View = New DataView(DgvTechnician.DataSource, Nothing, "Technician Asc", DataViewRowState.CurrentRows)
        DgvTechnician.DataSource = View
        If DgvTechnician.SelectedRows.Count = 1 And DgvTechnician.Rows.Count - 1 >= SelectedRowIndex Then
            DgvTechnician.Rows(SelectedRowIndex).Selected = True
            DgvTechnician.FirstDisplayedScrollingRowIndex = FirstDisplayedRowIndex
            If DgvTechnician.CurrentCell IsNot Nothing AndAlso CurrentCellIndex >= 0 And _Calculated Then
                DgvTechnician.CurrentCell = DgvTechnician.Rows(SelectedRowIndex).Cells(CurrentCellIndex)
            End If
        End If
        DgvTechnician.Columns.Cast(Of DataGridViewColumn).Where(Function(x) x.Name <> "Technician").ToList.ForEach(Sub(y) y.Visible = False)
        DgvTechnician.Columns("Technician").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then
                    DgvNavigator.CancelNextMove = True
                End If
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            Evaluation.Load(_EvaluationsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO EV001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If BtnSave.Enabled Then
                    If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        If Not Save() Then e.Cancel = True
                    End If
                End If
            End If
            _Deleting = False
        End If
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        Evaluation = New Evaluation
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If Evaluation.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not Evaluation.LockInfo.IsLocked Or (Evaluation.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = Evaluation.LockInfo.SessionToken) Then
                        Evaluation.Delete()
                        If _EvaluationsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _EvaluationsForm.DgvEvaluationLayout.Load()
                            _EvaluationsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(Evaluation.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                CMessageBox.Show("ERRO EV002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.Evaluation, Evaluation.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        If BtnStatusValue.Text = GetEnumDescription(EvaluationStatus.Approved) Then
            BtnStatusValue.ForeColor = Color.DarkBlue
            LblStatusValue.ForeColor = Color.DarkBlue
        ElseIf BtnStatusValue.Text = GetEnumDescription(EvaluationStatus.Rejected) Then
            BtnStatusValue.ForeColor = Color.DarkRed
            LblStatusValue.ForeColor = Color.DarkRed
        Else
            BtnStatusValue.ForeColor = Color.Chocolate
            LblStatusValue.ForeColor = Color.Chocolate
        End If
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtTechnicalAdvice.TextChanged,
                                                                         TxtResponsible.TextChanged,
                                                                         TxtEvaluationNumber.TextChanged,
                                                                         TxtEndTime.TextChanged,
                                                                         TxtStartTime.TextChanged,
                                                                         RbtGathering.CheckedChanged,
                                                                         RbtExecution.CheckedChanged,
                                                                         QbxCustomer.TextChanged,
                                                                         DbxAverageWorkLoad.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Txt2TextChanged(sender As Object, e As EventArgs) Handles QbxCompressor.TextChanged,
                                                                          DbxHorimeter.TextChanged,
                                                                          DbxEvaluationDate.TextChanged
        EprValidation.Clear()
        If Not _Loading Then
            Decalculate()
            BtnCalculate.Text = "Calcular"
            BtnSave.Enabled = True
        End If
    End Sub
    Private Sub TxtTechnicalAdvice_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TxtTechnicalAdvice.LinkClicked
        Process.Start(e.LinkText)
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Insert And e.Control Then
            If BtnInclude.Enabled Then BtnInclude.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Delete And e.Control Then
            If BtnDelete.Enabled Then BtnDelete.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Sub TcEvaluation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcEvaluation.SelectedIndexChanged
        If TcEvaluation.SelectedTab Is TabMain Then
            If _Calculated Then
                Size = New Size(1050, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
                FormBorderStyle = FormBorderStyle.FixedSingle
                WindowState = FormWindowState.Normal
                MaximizeBox = False
            Else
                Size = New Size(433, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
                FormBorderStyle = FormBorderStyle.FixedSingle
                WindowState = FormWindowState.Normal
                MaximizeBox = False
            End If
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
    Private Function IsValidFieldsToSave() As Boolean
        If String.IsNullOrWhiteSpace(TxtEvaluationNumber.Text) Then
            EprValidation.SetError(LblEvaluationNumber, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblEvaluationNumber, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TxtEvaluationNumber.Select()
            Return False
        ElseIf Not IsDate(DbxEvaluationDate.Text) Then
            EprValidation.SetError(LblEvaluationDate, "Data inválida")
            EprValidation.SetIconAlignment(LblEvaluationDate, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            DbxEvaluationDate.Select()
            Return False
        ElseIf Not IsNumeric(TxtStartTime.Text) Then
            EprValidation.SetError(LblStartTime, "Formato inválido.")
            EprValidation.SetIconAlignment(LblStartTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TxtStartTime.Select()
            Return False
        ElseIf TxtStartTime.Text.Length < 4 Or
            (Strings.Left(TxtStartTime.Text, 2) < 0 Or Strings.Left(TxtStartTime.Text, 2) > 23) Or
            (Strings.Right(TxtStartTime.Text, 2) < 0 Or Strings.Right(TxtStartTime.Text, 2) > 59) Then
            EprValidation.SetError(LblStartTime, "Formato inválido.")
            EprValidation.SetIconAlignment(LblStartTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TxtStartTime.Select()
            Return False
        ElseIf Not IsNumeric(TxtEndTime.Text) Then
            EprValidation.SetError(LblEndTime, "Formato inválido.")
            EprValidation.SetIconAlignment(LblEndTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TxtEndTime.Select()
            Return False
        ElseIf TxtEndTime.Text.Length < 4 Or
            (Strings.Left(TxtEndTime.Text, 2) < 0 Or Strings.Left(TxtEndTime.Text, 2) > 23) Or
            (Strings.Right(TxtEndTime.Text, 2) < 0 Or Strings.Right(TxtEndTime.Text, 2) > 59) Then
            EprValidation.SetError(LblEndTime, "Formato inválido.")
            EprValidation.SetIconAlignment(LblEndTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TxtEndTime.Select()
            Return False
        ElseIf TimeSpan.Compare(TimeSpan.Parse(TxtStartTime.Text), TimeSpan.Parse(TxtEndTime.Text)) = 0 Then
            EprValidation.SetError(LblEndTime, "Os horários de chegada e saída não podem ser iguais.")
            EprValidation.SetIconAlignment(LblEndTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TxtEndTime.Select()
            Return False
        ElseIf TimeSpan.Compare(TimeSpan.Parse(TxtStartTime.Text), TimeSpan.Parse(TxtEndTime.Text)) = 1 Then
            EprValidation.SetError(LblEndTime, "O horário de chegada deve ser menor que o de saída.")
            EprValidation.SetIconAlignment(LblEndTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TxtEndTime.Select()
            Return False
        ElseIf DgvTechnician.Rows.Count = 0 Then
            EprValidation.SetError(TsTechnician, "A avaliação deve ter pelo menos um técnico.")
            EprValidation.SetIconAlignment(TsTechnician, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsTechnician, -90)
            DgvTechnician.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxCustomer.Text) Then
            EprValidation.SetError(LblCustomer, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCustomer, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCustomer.Select()
            Return False
        ElseIf Not QbxCustomer.IsFreezed Then
            EprValidation.SetError(LblCustomer, "Cliente não encontrado.")
            EprValidation.SetIconAlignment(LblCustomer, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCustomer.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxCompressor.Text) Then
            EprValidation.SetError(LblCompressor, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCompressor.Select()
            Return False
        ElseIf Not QbxCompressor.IsFreezed Then
            EprValidation.SetError(LblCompressor, "Compressor não encontrado.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCompressor.Select()
            Return False
        ElseIf DbxHorimeter.DecimalValue < 0 Then
            EprValidation.SetError(LblCompressor, "O horímero não pode ser menor que 0.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCompressor.Select()
            Return False
        ElseIf DbxAverageWorkLoad.DecimalValue < 0.01 Then
            EprValidation.SetError(LblAverageWorkLoad, "O CMT deve ser maior ou igual a 0.01 horas por dia.")
            EprValidation.SetIconAlignment(LblAverageWorkLoad, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            DbxAverageWorkLoad.Select()
            Return False
        ElseIf DbxAverageWorkLoad.DecimalValue > 24 Then
            EprValidation.SetError(LblAverageWorkLoad, "O CMT não pode ultrapassar 24 horas por dia.")
            EprValidation.SetIconAlignment(LblAverageWorkLoad, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            DbxAverageWorkLoad.Select()
            Return False
        ElseIf Not _Calculated Then
            EprValidation.SetError(BtnCalculate, "A avaliação precisa ser calculada.")
            EprValidation.SetIconAlignment(BtnCalculate, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(BtnCalculate, -125)
            TcEvaluation.SelectedTab = TabMain
            BtnCalculate.Select()
            Return False
        ElseIf Evaluation.PartsWorkedHour.Count + Evaluation.PartsElapsedDay.Count = 0 Then
            EprValidation.SetError(GbxPartWorkedHour, "A avaliação precisa ter pelo menos um item.")
            EprValidation.SetIconAlignment(GbxPartWorkedHour, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxPartWorkedHour, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvPartWorkedHour.Select()
            Return False
        ElseIf Not PdfDocumentViewer.IsDocumentLoaded Then
            EprValidation.SetError(TsDocument, "Anexar um documento é obrigatório.")
            EprValidation.SetIconAlignment(TsDocument, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsDocument, -180)
            TcEvaluation.SelectedTab = TabDocument
            BtnAttachPDF.Select()
            Return False
        ElseIf Evaluation.PartsWorkedHour.Any(Function(x) x.CurrentCapacity > x.Part.Capacity) Then
            EprValidation.SetError(GbxPartWorkedHour, "Existe um ou mais itens com a capacidade atual superior a capacidade total.")
            EprValidation.SetIconAlignment(GbxPartWorkedHour, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxPartWorkedHour, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvPartWorkedHour.Select()
            Return False
        ElseIf Evaluation.PartsElapsedDay.Any(Function(x) x.CurrentCapacity > x.Part.Capacity) Then
            EprValidation.SetError(GbxPartElapsedDay, "Existe um ou mais itens com a capacidade atual superior a capacidade total.")
            EprValidation.SetIconAlignment(GbxPartElapsedDay, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxPartElapsedDay, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvPartElapsedDay.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        Dim DocumentName As String = String.Empty
        Dim Success As Boolean
        Dim CurrentFile As String = Evaluation.DocumentName.CurrentFile
        Dim OriginalFile As String = Evaluation.DocumentName.OriginalFile
        QbxCustomer.Text = RemoveAccents(QbxCustomer.Text.Trim)
        TxtResponsible.Text = RemoveAccents(TxtResponsible.Text.Trim)
        QbxCompressor.Text = RemoveAccents(QbxCompressor.Text.Trim)
        TxtTechnicalAdvice.Text = RemoveAccents(TxtTechnicalAdvice.Text.ToUpper)
        If Evaluation.LockInfo.IsLocked And Evaluation.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", GetTitleCase(Evaluation.LockInfo.LockedBy.Value.Username)), CMessageBoxType.Information)
            Success = False
        ElseIf Evaluation.Status = EvaluationStatus.Approved AndAlso Not Locator.GetInstance(Of Session).User.Privilege.EvaluationApproveOrReject Then
            CMessageBox.Show("Essa avaliação não pode ser alterada pois já foi aprovada.", CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFieldsToSave() Then
                Try
                    Cursor = Cursors.WaitCursor
                    Evaluation.EvaluationType = If(RbtGathering.Checked, EvaluationType.Gathering, EvaluationType.Execution)
                    Evaluation.EvaluationDate = DbxEvaluationDate.Text
                    Evaluation.StartTime = TimeSpan.Parse(TxtStartTime.Text.Insert(2, ":"))
                    Evaluation.EndTime = TimeSpan.Parse(TxtEndTime.Text.Insert(2, ":"))
                    Evaluation.EvaluationNumber = TxtEvaluationNumber.Text
                    Evaluation.Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
                    Evaluation.Responsible = TxtResponsible.Text
                    Evaluation.Horimeter = DbxHorimeter.DecimalValue
                    Evaluation.ManualAverageWorkLoad = CbxManualAverageWorkLoad.Checked
                    Evaluation.AverageWorkLoad = DbxAverageWorkLoad.Text
                    Evaluation.TechnicalAdvice = TxtTechnicalAdvice.Text
                    If Evaluation.ID = 0 AndAlso Locator.GetInstance(Of Session).User.Privilege.EvaluationApproveOrReject Then
                        Evaluation.SaveChanges()
                        BtnApprove.PerformClick()
                    Else
                        Evaluation.SaveChanges()
                    End If
                    Evaluation.Lock()
                    LblIDValue.Text = Evaluation.ID
                    FillDataGridViewTechnician()
                    FillDataGridViewPart(DgvPartWorkedHour, Evaluation.PartsWorkedHour)
                    FillDataGridViewPart(DgvPartElapsedDay, Evaluation.PartsElapsedDay)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = Locator.GetInstance(Of Session).User.Privilege.EvaluationDelete
                    If Evaluation.Status = EvaluationStatus.Rejected Then
                        If CMessageBox.Show("Deseja alterar o status da avaliação para REVISADO?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                            Evaluation.SetStatus(EvaluationStatus.Reviewed)
                            BtnStatusValue.Text = GetEnumDescription(Evaluation.Status)
                            BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
                            LblStatusValue.Text = GetEnumDescription(Evaluation.Status)
                            LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
                            BtnApprove.Visible = Evaluation.Status <> EvaluationStatus.Approved
                            BtnReject.Visible = Evaluation.Status <> EvaluationStatus.Rejected
                            BtnDisapprove.Visible = Evaluation.Status <> EvaluationStatus.Disapproved
                        End If
                    End If
                    If _EvaluationsForm IsNot Nothing Then
                        _Filter.Filter()
                        _EvaluationsForm.DgvEvaluationLayout.Load()
                        Row = _EvaluationsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Success = True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma avaliação lançada para esse compressor com essa data.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO EV003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Success = False
                Catch ex As Exception
                    If Not String.IsNullOrEmpty(DocumentName) AndAlso File.Exists(DocumentName) Then
                        File.Delete(DocumentName)
                    End If
                    CMessageBox.Show("ERRO EV020", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Success = False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Success = False
            End If
        End If
        If Not Success Then
            If Not File.Exists(Evaluation.DocumentName.OriginalFile) Then
                Evaluation.DocumentName.SetCurrentFile(OriginalFile, True)
                Evaluation.DocumentName.SetCurrentFile(CurrentFile)
            End If
        End If
        Return Success
    End Function

    Private Sub TmrCustomer_Tick(sender As Object, e As EventArgs) Handles TmrCustomer.Tick
        BtnViewCustomer.Visible = False
        BtnNewCustomer.Visible = False
        BtnFilterCustomer.Visible = False
        TmrCustomer.Stop()
    End Sub
    Private Sub QbxCustomer_Enter(sender As Object, e As EventArgs) Handles QbxCustomer.Enter
        TmrCustomer.Stop()
        BtnViewCustomer.Visible = QbxCustomer.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnNewCustomer.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnFilterCustomer.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonAccess
    End Sub
    Private Sub QbxCustomer_Leave(sender As Object, e As EventArgs) Handles QbxCustomer.Leave
        TmrCustomer.Stop()
        TmrCustomer.Start()
    End Sub
    Private Sub QbxCustomer_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCustomer.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewCustomer.Visible = QbxCustomer.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        QbxCompressor.Unfreeze()
        If QbxCompressor.Conditions.Count = 2 Then QbxCompressor.Conditions.RemoveAt(1)
        If QbxCompressor.Parameters.Count = 2 Then QbxCompressor.Parameters.RemoveAt(1)
        QbxCompressor.Conditions.Clear()
        QbxCompressor.Parameters.Clear()
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "statusid", .[Operator] = "=", .Value = "@statusid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@statusid", .ParameterValue = 0})
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "personid", .[Operator] = "=", .Value = "@personid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@personid", .ParameterValue = QbxCustomer.FreezedPrimaryKey})
        If QbxCustomer.IsFreezed Then
            QbxCompressor.Enabled = True
        Else
            QbxCompressor.Enabled = False
        End If
    End Sub
    Private Sub BtnNewCustomer_Click(sender As Object, e As EventArgs) Handles BtnNewCustomer.Click
        Dim Customer As Person
        Dim Form As FrmPerson
        Customer = New Person
        Customer.IsCustomer = True
        Customer.ControlMaintenance = True
        Form = New FrmPerson(Customer)
        Form.CbxIsCustomer.Enabled = False
        Form.CbxMaintenance.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Customer.ID > 0 Then
            QbxCustomer.Freeze(Customer.ID)
            Decalculate()
            BtnCalculate.Text = "Calcular"
        End If
        QbxCustomer.Select()
    End Sub
    Private Sub BtnViewCustomer_Click(sender As Object, e As EventArgs) Handles BtnViewCustomer.Click
        Dim Form As New FrmPerson(New Person().Load(QbxCustomer.FreezedPrimaryKey, True))
        Dim FreezedCustomerID As Long = QbxCustomer.FreezedPrimaryKey
        Dim FreezedCompressorID As Long = QbxCompressor.FreezedPrimaryKey
        Form.CbxIsCustomer.Enabled = False
        Form.CbxMaintenance.Enabled = False
        Form.ShowDialog()
        _Loading = True
        QbxCustomer.Unfreeze()
        QbxCustomer.Freeze(FreezedCustomerID)
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(FreezedCompressorID)
        QbxCustomer.Select()
        _Loading = False
    End Sub
    Private Sub BtnFilterCustomer_Click(sender As Object, e As EventArgs) Handles BtnFilterCustomer.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonCustomerQueriedBoxFilter("Sim"), QbxCustomer)
        FilterForm.Text = "Filtro de Clientes"
        FilterForm.ShowDialog()
        QbxCustomer.Select()
    End Sub
    Private Sub BtnZoomOut_Click(sender As Object, e As EventArgs) Handles BtnZoomOut.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage - 10)
    End Sub
    Private Sub BtnZoomIn_Click(sender As Object, e As EventArgs) Handles BtnZoomIn.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage + 10)
    End Sub
    Private Sub BtnAttachPDF_Click(sender As Object, e As EventArgs) Handles BtnAttachPDF.Click
        Dim Filename As String
        If OfdDocument.ShowDialog = DialogResult.OK Then
            Filename = Util.GetFilename(Path.GetExtension(OfdDocument.FileName))
            File.Copy(OfdDocument.FileName, Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            Evaluation.DocumentName.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            If Not String.IsNullOrEmpty(Evaluation.DocumentName.CurrentFile) AndAlso File.Exists(Evaluation.DocumentName.CurrentFile) Then
                Try
                    PdfDocumentViewer.Load(Evaluation.DocumentName.CurrentFile)
                    LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
                    BtnDeletePDF.Enabled = True
                    BtnSavePDF.Enabled = True
                    BtnPrintPDF.Enabled = True
                    BtnZoomIn.Enabled = True
                    BtnZoomOut.Enabled = True
                    EprValidation.Clear()
                    BtnSave.Enabled = True
                Catch ex As Exception
                    CMessageBox.Show("ERRO EV004", "Ocorreu um erro ao carregar o documento.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End Try
            End If
        End If
    End Sub
    Private Sub PdfDocumentViewer_CurrentPageChanged(sender As Object, args As EventArgs) Handles PdfDocumentViewer.CurrentPageChanged
        LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
    End Sub
    Private Sub BtnDeletePDF_Click(sender As Object, e As EventArgs) Handles BtnDeletePDF.Click
        If CMessageBox.Show("O documento será excluído permanentemente quando essa avaliação for salva. Confirma a exclusão?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            Evaluation.DocumentName.SetCurrentFile(Nothing)
            PdfDocumentViewer.Unload()
            LblDocumentPage.Text = Nothing
            BtnDeletePDF.Enabled = False
            BtnSavePDF.Enabled = False
            BtnPrintPDF.Enabled = False
            BtnZoomIn.Enabled = False
            BtnZoomOut.Enabled = False
            EprValidation.Clear()
            BtnSave.Enabled = True
        End If
    End Sub
    Private Sub BtnSavePDF_Click(sender As Object, e As EventArgs) Handles BtnSavePDF.Click
        SfdDocument.FileName = Path.GetFileName("Avaliação " & Evaluation.EvaluationNumber)
        SfdDocument.Filter = "Documento PDF|*.pdf"
        If SfdDocument.ShowDialog() = DialogResult.OK Then
            PdfDocumentViewer.LoadedDocument.Save(SfdDocument.FileName)
        End If
    End Sub
    Private Sub BtnPrintPDF_Click(sender As Object, e As EventArgs) Handles BtnPrintPDF.Click
        Using Dialog As New PrintDialog
            Dialog.Document = PdfDocumentViewer.PrintDocument
            If Dialog.ShowDialog() = DialogResult.OK Then
                Dialog.Document.Print()
            End If
        End Using
    End Sub
    Private Function GetCMT() As Decimal
        Dim Value As Decimal
        Value = 5.71
        If IsDate(DbxEvaluationDate.Text) Then
            If QbxCompressor.IsFreezed Then
                If DbxHorimeter.DecimalValue >= 0 Then
                    If Evaluation.HasPreviousEvaluation(Evaluation.Compressor, DbxEvaluationDate.Text, LblIDValue.Text) Then
                        If Evaluation.GetPreviousEvaluationDate(Evaluation.Compressor, DbxEvaluationDate.Text, LblIDValue.Text) <= CDate(DbxEvaluationDate.Text) Then
                            Value = Evaluation.GetAverageWorkLoad(Evaluation.Compressor, DbxHorimeter.DecimalValue, DbxEvaluationDate.Text, LblIDValue.Text)
                            If Value = 0 Then Value = 0.01
                            If Value < 0 Then Value = 5.71
                            If Value > 24 And Value < 25 Then Value = 24
                        End If
                    Else
                        EprInformation.SetError(LblAverageWorkLoad, String.Format("Não existe avaliação anterior a essa para esse compressor, foi utilizado o CMT padrão (5,71)."))
                    End If
                End If
            End If
        End If
        Return Value
    End Function
    Private Sub CbxManualAverageWorkLoad_CheckedChanged(sender As Object, e As EventArgs) Handles CbxManualAverageWorkLoad.CheckedChanged
        If CbxManualAverageWorkLoad.Checked Then
            DbxAverageWorkLoad.ReadOnly = False
        Else
            DbxAverageWorkLoad.ReadOnly = True
        End If
        EprValidation.Clear()
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles BtnApprove.Click
        Dim Row As DataGridViewRow
        If Evaluation.ID > 0 Then
            Try
                Cursor = Cursors.WaitCursor
                Evaluation.SetStatus(EvaluationStatus.Approved)
                BtnStatusValue.Text = GetEnumDescription(Evaluation.Status)
                BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
                LblStatusValue.Text = GetEnumDescription(Evaluation.Status)
                LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
                BtnApprove.Visible = Evaluation.Status <> EvaluationStatus.Approved
                BtnReject.Visible = Evaluation.Status <> EvaluationStatus.Rejected
                BtnDisapprove.Visible = Evaluation.Status <> EvaluationStatus.Disapproved
                If _EvaluationsForm IsNot Nothing Then
                    _Filter.Filter()
                    _EvaluationsForm.DgvEvaluationLayout.Load()
                    Row = _EvaluationsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                    If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                    DgvNavigator.RefreshButtons()
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO EV013", "Ocorreu um erro ao aprovar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        Else
            CMessageBox.Show("Essa avaliação não pode ser aprovada, pois ainda não foi salva.")
        End If
    End Sub
    Private Sub BtnReject_Click(sender As Object, e As EventArgs) Handles BtnReject.Click
        Dim Row As DataGridViewRow
        If Evaluation.ID > 0 Then
            Using FormReject As New FrmEvaluationRejectReason
                If FormReject.ShowDialog = DialogResult.OK Then
                    Try
                        Cursor = Cursors.WaitCursor
                        Evaluation.SetStatus(EvaluationStatus.Rejected, FormReject.TxtReason.Text)
                        BtnStatusValue.Text = GetEnumDescription(Evaluation.Status)
                        BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
                        LblStatusValue.Text = GetEnumDescription(Evaluation.Status)
                        LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
                        BtnApprove.Visible = Evaluation.Status <> EvaluationStatus.Approved
                        BtnReject.Visible = Evaluation.Status <> EvaluationStatus.Rejected
                        BtnDisapprove.Visible = Evaluation.Status <> EvaluationStatus.Disapproved
                        If _EvaluationsForm IsNot Nothing Then
                            _Filter.Filter()
                            _EvaluationsForm.DgvEvaluationLayout.Load()
                            Row = _EvaluationsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                            DgvNavigator.RefreshButtons()
                        End If
                    Catch ex As Exception
                        CMessageBox.Show("ERRO EV014", "Ocorreu um erro ao rejeitar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Finally
                        Cursor = Cursors.Default
                    End Try
                End If
            End Using
        Else
            CMessageBox.Show("Essa avaliação não pode ser rejeitada, pois ainda não foi salva.")
        End If
    End Sub
    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles BtnDisapprove.Click
        Dim Row As DataGridViewRow
        Try
            Cursor = Cursors.WaitCursor
            Evaluation.SetStatus(EvaluationStatus.Disapproved)
            BtnStatusValue.Text = GetEnumDescription(Evaluation.Status)
            BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
            LblStatusValue.Text = GetEnumDescription(Evaluation.Status)
            LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & Evaluation.RejectReason)
            BtnApprove.Visible = Evaluation.Status <> EvaluationStatus.Approved
            BtnReject.Visible = Evaluation.Status <> EvaluationStatus.Rejected
            BtnDisapprove.Visible = Evaluation.Status <> EvaluationStatus.Disapproved
            If _EvaluationsForm IsNot Nothing Then
                _Filter.Filter()
                _EvaluationsForm.DgvEvaluationLayout.Load()
                Row = _EvaluationsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                DgvNavigator.RefreshButtons()
            End If
        Catch ex As Exception
            CMessageBox.Show("ERRO EV019", "Ocorreu um erro ao desaprovar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub FrmEvaluation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Evaluation.Unlock()
    End Sub
    Private Sub TxtTime_Enter(sender As Object, e As EventArgs) Handles TxtEndTime.Enter, TxtStartTime.Enter
        BeginInvoke(CType(Sub()
                              sender.SelectAll()
                          End Sub, Action))
    End Sub
    Private Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles BtnCalculate.Click
        Dim Customer As Person
        Dim PreviousEvaluation As Evaluation
        Dim PreviousEvaluationID As Long
        Dim PreviousPart As EvaluationPart
        If IsValidFieldsToCalculate() Then
            EprValidation.Clear()
            If Not _Calculated And DbxHorimeter.DecimalValue = 0 Then
                If CMessageBox.Show("O horímetro informado foi 0 (zero). Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
            End If
            If _Calculated Then
                If CMessageBox.Show("Os itens dessa avaliação já foram calculados. Calcular novamente irá redefinir as capacidades e o CMT com base na avaliação anterior. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
            End If
            Try
                Cursor = Cursors.WaitCursor
                Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
                Evaluation.Compressor = Customer.Compressors.Single(Function(x) x.ID = QbxCompressor.FreezedPrimaryKey)
                PreviousEvaluationID = Evaluation.GetPreviousEvaluationID(Evaluation.Compressor, CDate(DbxEvaluationDate.Text), Evaluation.ID)
                PreviousEvaluation = New Evaluation().Load(PreviousEvaluationID, False)
                For Each CurrentPart As EvaluationPart In Evaluation.PartsWorkedHour.Reverse
                    If CurrentPart.Part.Status = SimpleStatus.Inactive Then
                        Evaluation.PartsWorkedHour.Remove(CurrentPart)
                    End If
                Next CurrentPart
                For Each CurrentPart As EvaluationPart In Evaluation.PartsElapsedDay.Reverse
                    If CurrentPart.Part.Status = SimpleStatus.Inactive Then
                        Evaluation.PartsElapsedDay.Remove(CurrentPart)
                    End If
                Next CurrentPart
                If DbxHorimeter.DecimalValue < PreviousEvaluation.Horimeter Then
                    CMessageBox.Show("O horímetro digitado é menor do que o horímetro da última avalição desse compressor, só mantenha esse valor caso a unidade tenha sido reconstruída. A capacidade atual dos itens será a mesma da última avaliação.", CMessageBoxType.Warning)
                    Cursor = Cursors.WaitCursor
                    For Each CurrentPart As EvaluationPart In Evaluation.PartsWorkedHour
                        CurrentPart.Sold = False
                        CurrentPart.Lost = False
                        PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                        If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                            CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                        Else
                            CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                        End If
                    Next CurrentPart
                    For Each CurrentPart As EvaluationPart In Evaluation.PartsElapsedDay
                        CurrentPart.Sold = False
                        CurrentPart.Lost = False
                        PreviousPart = PreviousEvaluation.PartsElapsedDay.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                        If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                            CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                        Else
                            CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                        End If
                    Next CurrentPart
                    If Not CbxManualAverageWorkLoad.Checked Then DbxAverageWorkLoad.Text = PreviousEvaluation.AverageWorkLoad
                Else
                    For Each CurrentPart As EvaluationPart In Evaluation.PartsWorkedHour
                        CurrentPart.Sold = False
                        CurrentPart.Lost = False
                        PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                        If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                            CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (DbxHorimeter.DecimalValue - PreviousEvaluation.Horimeter)
                        Else
                            CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                        End If
                    Next CurrentPart
                    For Each CurrentPart As EvaluationPart In Evaluation.PartsElapsedDay
                        CurrentPart.Sold = False
                        CurrentPart.Lost = False
                        PreviousPart = PreviousEvaluation.PartsElapsedDay.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                        If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                            CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (CDate(DbxEvaluationDate.Text).Subtract(PreviousEvaluation.EvaluationDate).Days)
                        Else
                            CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                        End If
                    Next CurrentPart
                    If Not CbxManualAverageWorkLoad.Checked Then DbxAverageWorkLoad.Text = GetCMT()
                End If
                FillDataGridViewPart(DgvPartWorkedHour, Evaluation.PartsWorkedHour)
                FillDataGridViewPart(DgvPartElapsedDay, Evaluation.PartsElapsedDay)
                TcEvaluation.SelectedTab = TabMain
                Size = New Size(1050, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
                _Calculated = True
                BtnCalculate.Text = "Recalcular"
            Catch ex As Exception
                Decalculate()
                BtnCalculate.Text = "Calcular"
                CMessageBox.Show("ERRO EV010", "Ocorreu um erro ao carregar os itens do compressor selecionado.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                BtnSave.Enabled = True
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Function IsValidFieldsToCalculate() As Boolean
        If Not IsDate(DbxEvaluationDate.Text) Then
            EprValidation.SetError(LblEvaluationDate, "Data inválida")
            EprValidation.SetIconAlignment(LblEvaluationDate, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            DbxEvaluationDate.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxCustomer.Text) Then
            EprValidation.SetError(LblCustomer, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCustomer, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCustomer.Select()
            Return False
        ElseIf Not QbxCustomer.IsFreezed Then
            EprValidation.SetError(LblCustomer, "Cliente não encontrado.")
            EprValidation.SetIconAlignment(LblCustomer, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCustomer.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxCompressor.Text) Then
            EprValidation.SetError(LblCompressor, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCompressor.Select()
            Return False
        ElseIf Not QbxCompressor.IsFreezed Then
            EprValidation.SetError(LblCompressor, "Compressor não encontrado.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCompressor.Select()
            Return False
        ElseIf DbxHorimeter.DecimalValue < 0 Then
            EprValidation.SetError(LblCompressor, "O horímero não pode ser menor que 0.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            QbxCompressor.Select()
            Return False
        ElseIf Evaluation.CountEvaluation(QbxCompressor.FreezedPrimaryKey, {EvaluationStatus.Disapproved, EvaluationStatus.Rejected, EvaluationStatus.Reviewed}.ToList, Evaluation.ID) > 0 Then
            EprValidation.SetError(BtnCalculate, "Não foi possível calcular pois há avaliação não aprovada para esse compressor.")
            EprValidation.SetIconAlignment(BtnCalculate, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(BtnCalculate, -125)
            TcEvaluation.SelectedTab = TabMain
            BtnCalculate.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub DgvPartWorkedHour_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPartWorkedHour.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPartWorkedHour.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            EditEvaluationPart(CompressorPartType.WorkedHour)
        End If
    End Sub
    Private Sub DgvPartElapsedDay_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPartElapsedDay.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPartElapsedDay.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            EditEvaluationPart(CompressorPartType.ElapsedDay)
        End If
    End Sub
    Private Sub DgvPartWorkedHour_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPartWorkedHour.KeyDown
        If e.KeyCode = Keys.Enter Then
            EditEvaluationPart(CompressorPartType.WorkedHour)
            e.Handled = True
        End If
    End Sub
    Private Sub DgvPartElapsedDay_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPartElapsedDay.KeyDown
        If e.KeyCode = Keys.Enter Then
            EditEvaluationPart(CompressorPartType.ElapsedDay)
            e.Handled = True
        End If
    End Sub
    Private Sub EditEvaluationPart(PartType As CompressorPartType)
        Dim Result As DialogResult
        Dim Part As EvaluationPart



        If PartType = CompressorPartType.ElapsedDay Then
            Part = Evaluation.PartsElapsedDay.Single(Function(x) x.Part.ID = DgvPartElapsedDay.SelectedRows(0).Cells("Part").Value.ID)
            Using Frm As New FrmEvaluationPart(Part)
                Result = Frm.ShowDialog()
                FillDataGridViewPart(DgvPartElapsedDay, Evaluation.PartsElapsedDay)
            End Using
        Else
            Part = Evaluation.PartsWorkedHour.Single(Function(x) x.Part.ID = DgvPartWorkedHour.SelectedRows(0).Cells("Part").Value.ID)
            Using Frm As New FrmEvaluationPart(Part)
                Result = Frm.ShowDialog()
                FillDataGridViewPart(DgvPartWorkedHour, Evaluation.PartsWorkedHour)
            End Using
        End If
        If Evaluation.PartsWorkedHour.Any(Function(x) x.Sold) Or Evaluation.PartsElapsedDay.Any(Function(x) x.Sold) Then
            RbtExecution.Checked = True
        Else
            If RbtExecution.Checked Then
                If CMessageBox.Show("Nenhuma das peças controladas foi vendida, deseja marcar o tipo da avaliação como levantamento?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    RbtGathering.Checked = True
                End If
            End If
        End If
        BtnSave.Enabled = Result = DialogResult.OK
    End Sub
    Private Sub Decalculate()
        Size = New Size(433, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
        DgvPartWorkedHour.DataSource = Nothing
        DgvPartElapsedDay.DataSource = Nothing
        _Calculated = False
    End Sub
    Private Sub BtnIncludetechnician_Click(sender As Object, e As EventArgs) Handles BtnIncludeTechnician.Click
        Dim Form As New FrmEvaluationTechnician(Evaluation, New EvaluationTechnician(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditTechnician_Click(sender As Object, e As EventArgs) Handles BtnEditTechnician.Click
        Dim Form As FrmEvaluationTechnician
        Dim Technician As EvaluationTechnician
        If DgvTechnician.SelectedRows.Count = 1 Then
            Technician = Evaluation.Technicians.Single(Function(x) x.Order = DgvTechnician.SelectedRows(0).Cells("Order").Value)
            Form = New FrmEvaluationTechnician(Evaluation, Technician, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteTechnician_Click(sender As Object, e As EventArgs) Handles BtnDeleteTechnician.Click
        Dim Technician As EvaluationTechnician
        If DgvTechnician.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Technician = Evaluation.Technicians.Single(Function(x) x.Order = DgvTechnician.SelectedRows(0).Cells("Order").Value)
                Evaluation.Technicians.Remove(Technician)
                FillDataGridViewTechnician()
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DgvTechnician_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvTechnician.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvTechnician.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditTechnician.PerformClick()
        End If
    End Sub
End Class