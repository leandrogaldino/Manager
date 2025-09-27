Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports ManagerCore
Imports MySql.Data.MySqlClient
Public Class FrmEvaluation
#Region "Fields"
    Private _UcCallTypeHasRepairNeedProposal As UcEvaluationCallTypeHasRepairNeedProposal
    Private _UcUnitTemperaturePressure As UcEvaluationUnitTemperaturePressure
    Private _EvaluationsForm As FrmEvaluations
    Private _SelectedPicture As EvaluationPicture
    Private _EvaluationsGrid As DataGridView
    Private _Filter As EvaluationFilter
    Private _Evaluation As Evaluation
    Private _Resizer As FluidResizer
    Private _Calculated As Boolean
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _TargetSize As Size
    Private _User As User
#End Region
#Region "Properties"
    Private Property Calculated As Boolean
        Get
            Return _Calculated
        End Get
        Set(value As Boolean)
            _Calculated = value
            If Calculated Then
                _TargetSize = New Size(1055, 570 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            Else
                _TargetSize = New Size(433, 570 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            End If
            If _Resizer IsNot Nothing Then
                If _Loading Then
                    Size = _TargetSize
                Else
                    _Resizer.SetSize(_TargetSize)
                End If
            End If
        End Set
    End Property
    Private Property SelectedPicture As EvaluationPicture
        Get
            Return _SelectedPicture
        End Get
        Set(value As EvaluationPicture)
            _SelectedPicture = value
            If _SelectedPicture IsNot Nothing Then
                PbxPicture.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(_SelectedPicture.Picture.CurrentFile)))
            Else
                PbxPicture.Image = Nothing
            End If
        End Set
    End Property
#End Region
#Region "Constructors"
    Public Sub New(Evaluation As Evaluation, EvaluationsForm As FrmEvaluations)
        InitializeComponent()
        _Evaluation = Evaluation
        _EvaluationsForm = EvaluationsForm
        _EvaluationsGrid = _EvaluationsForm.DgvData
        _Filter = CType(_EvaluationsForm.PgFilter.SelectedObject, EvaluationFilter)
        ConfigureControls()
        LoadData()
    End Sub
    Public Sub New(Evaluation As Evaluation)
        InitializeComponent()
        _Evaluation = Evaluation
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        TcEvaluation.Height -= TsNavigation.Height
        Height -= TsNavigation.Height
        LblStatus.Visible = True
        LblStatusValue.Visible = True
        BtnStatusValue.Visible = False
        ConfigureControls()
        LoadData()
    End Sub
#End Region
#Region "Overrides"
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
#End Region
#Region "Form Events"
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvlTechnicianLayout.Load()
        DgvlElapsedDaySellable.Load()
        DgvlWorkedHourSellable.Load()
        DgvlReplacedSellable.Load()
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
    Private Sub Form_Closed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Evaluation.Unlock()
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
#End Region
#Region "Configuration & Initialization"
    Private Sub ConfigureControls()
        ControlHelper.EnableControlDoubleBuffer(DgvWorkedHourSellable, True)
        ControlHelper.EnableControlDoubleBuffer(DgvElapsedDaySellable, True)
        _Resizer = New FluidResizer(Me)
        _User = Locator.GetInstance(Of Session).User
        DgvNavigator.DataGridView = _EvaluationsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
        BtnStatusValue.Visible = _User.CanAccess(Routine.EvaluationApproveOrReject)
        LblStatusValue.Visible = Not _User.CanAccess(Routine.EvaluationApproveOrReject)
        LblDocumentPage.Text = Nothing
        TxtEvaluationNumber.ReadOnly = _Evaluation.EvaluationCreationType <> EvaluationCreationType.Manual
        Tip.SetToolTip(LblAverageWorkLoad, "Carga Média de Trabalho")
        _UcCallTypeHasRepairNeedProposal = New UcEvaluationCallTypeHasRepairNeedProposal()
        CcoCallTypeHasRepairNeedProposal.DropDownControl = _UcCallTypeHasRepairNeedProposal
        _UcUnitTemperaturePressure = New UcEvaluationUnitTemperaturePressure()
        CcoUnitTemperaturePressure.DropDownControl = _UcUnitTemperaturePressure
        AddHandler _UcCallTypeHasRepairNeedProposal.ValueChanged, AddressOf CallTypeHasRepairNeedProposalChanged
        AddHandler _UcUnitTemperaturePressure.ValueChanged, AddressOf UnitTemperaturePressureChanged
        RefreshPictureControls()
    End Sub
    Private Sub LoadData()
        _Loading = True
        TcEvaluation.SelectedTab = TabMain
        LblIDValue.Text = _Evaluation.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
        BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO DA REJEIÇÃO" & vbNewLine & _Evaluation.RejectReason)
        LblStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
        LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO DA REJEIÇÃO" & vbNewLine & _Evaluation.RejectReason)
        LblCreationValue.Text = _Evaluation.Creation.ToString("dd/MM/yyyy")
        BtnApprove.Visible = _Evaluation.Status <> EvaluationStatus.Approved
        BtnReject.Visible = _Evaluation.Status <> EvaluationStatus.Rejected
        BtnDisapprove.Visible = _Evaluation.Status <> EvaluationStatus.Disapproved
        _UcCallTypeHasRepairNeedProposal.CallType = _Evaluation.CallType
        _UcCallTypeHasRepairNeedProposal.HasRepair = _Evaluation.HasRepair
        _UcCallTypeHasRepairNeedProposal.NeedProposal = _Evaluation.NeedProposal
        _UcUnitTemperaturePressure.Unit = _Evaluation.UnitName
        _UcUnitTemperaturePressure.Temperature = _Evaluation.Temperature
        _UcUnitTemperaturePressure.Pressure = _Evaluation.Pressure
        DbxEvaluationDate.Text = _Evaluation.EvaluationDate
        TbxStartTime.Time = _Evaluation.StartTime
        TbxEndTime.Time = _Evaluation.EndTime
        TxtEvaluationNumber.Text = _Evaluation.EvaluationNumber
        TxtResponsible.Text = _Evaluation.Responsible
        QbxCompressor.Conditions.Clear()
        QbxCompressor.Parameters.Clear()
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "statusid", .[Operator] = "=", .Value = "@statusid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@statusid", .ParameterValue = 0})
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "personid", .[Operator] = "=", .Value = "@personid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@personid", .ParameterValue = QbxCustomer.FreezedPrimaryKey})
        QbxCustomer.Unfreeze()
        QbxCustomer.Freeze(_Evaluation.Customer.ID)
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(_Evaluation.Compressor.ID)
        DbxHorimeter.Text = _Evaluation.Horimeter
        CbxManualAverageWorkLoad.Checked = _Evaluation.ManualAverageWorkLoad
        DbxAverageWorkLoad.Text = _Evaluation.AverageWorkLoad
        TxtTechnicalAdvice.Text = _Evaluation.TechnicalAdvice
        DgvTechnician.Fill(_Evaluation.Technicians)
        If _Evaluation.EvaluationCreationType = EvaluationCreationType.Imported Or (_Evaluation.EvaluationCreationType = EvaluationCreationType.Manual And _Evaluation.ID > 0) Then
            For Each p As EvaluationControlledSellable In _Evaluation.WorkedHourControlledSelable.ToArray.Reverse()
                If Not p.IsSaved Then
                    _Evaluation.WorkedHourControlledSelable.Remove(p)
                End If
            Next p
            For Each p As EvaluationControlledSellable In _Evaluation.ElapsedDayControlledSellable.ToArray.Reverse()
                If Not p.IsSaved Then
                    _Evaluation.ElapsedDayControlledSellable.Remove(p)
                End If
            Next p
            If DgvWorkedHourSellable.Rows.Count > 0 Then
                DgvWorkedHourSellable.Rows(0).Selected = True
                DgvWorkedHourSellable.FirstDisplayedScrollingRowIndex = 0
            End If
            If DgvElapsedDaySellable.Rows.Count > 0 Then
                DgvElapsedDaySellable.Rows(0).Selected = True
                DgvElapsedDaySellable.FirstDisplayedScrollingRowIndex = 0
            End If
            Calculated = True
            BtnCalculate.Text = "Recalcular"
        Else
            Decalculate()
            BtnCalculate.Text = "Calcular"
        End If
        DgvWorkedHourSellable.Fill(_Evaluation.WorkedHourControlledSelable)
        DgvElapsedDaySellable.Fill(_Evaluation.ElapsedDayControlledSellable)
        DgvReplacedSellable.Fill(_Evaluation.ReplacedSellables)
        DgvlElapsedDaySellable.Load()
        DgvlWorkedHourSellable.Load()
        DgvlReplacedSellable.Load()
        If Not String.IsNullOrEmpty(_Evaluation.Document.CurrentFile) AndAlso File.Exists(_Evaluation.Document.CurrentFile) Then
            PdfDocumentViewer.Load(New MemoryStream(File.ReadAllBytes(_Evaluation.Document.CurrentFile)))
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
        If _Evaluation.Pictures.Count > 0 Then
            SelectedPicture = _Evaluation.Pictures(0)
        End If
        RefreshPictureControls()
        If File.Exists(_Evaluation.Signature.CurrentFile) Then
            PbxSignature.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(_Evaluation.Signature.CurrentFile)))
        End If
        BtnDelete.Enabled = _Evaluation.ID > 0 And _User.CanDelete(Routine.Evaluation)
        Text = "Avaliação de Compressor"
        If _Evaluation.LockInfo.IsLocked And Not _Evaluation.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Evaluation.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _Evaluation.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtEvaluationNumber.Select()
        _Loading = False
    End Sub
#End Region
#Region "Validation & Calculation"
    Private Function IsValidFieldsToSave() As Boolean
        If _UcCallTypeHasRepairNeedProposal.CallType = CallType.None Then
            EprValidation.SetError(BtnCallTypeHasRepairNeedProposal, "Selecione um tipo de visita.")
            EprValidation.SetIconAlignment(BtnCallTypeHasRepairNeedProposal, ErrorIconAlignment.MiddleRight)
            EprValidation.SetIconPadding(BtnCallTypeHasRepairNeedProposal, -20)
            TcEvaluation.SelectedTab = TabMain
            BtnCallTypeHasRepairNeedProposal.Select()
            Return False
        ElseIf _UcCallTypeHasRepairNeedProposal.HasRepair = ConfirmationType.None Then
            EprValidation.SetError(BtnCallTypeHasRepairNeedProposal, "Selecione se houve reparo nessa avaliação.")
            EprValidation.SetIconAlignment(BtnCallTypeHasRepairNeedProposal, ErrorIconAlignment.MiddleRight)
            EprValidation.SetIconPadding(BtnCallTypeHasRepairNeedProposal, -20)
            TcEvaluation.SelectedTab = TabMain
            BtnCallTypeHasRepairNeedProposal.Select()
            Return False
        ElseIf _UcCallTypeHasRepairNeedProposal.NeedProposal = ConfirmationType.None Then
            EprValidation.SetError(BtnCallTypeHasRepairNeedProposal, "Selecione se será necessário fazer proposta para essa avaliação.")
            EprValidation.SetIconAlignment(BtnCallTypeHasRepairNeedProposal, ErrorIconAlignment.MiddleRight)
            EprValidation.SetIconPadding(BtnCallTypeHasRepairNeedProposal, -20)
            TcEvaluation.SelectedTab = TabMain
            BtnCallTypeHasRepairNeedProposal.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtEvaluationNumber.Text) Then
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
        ElseIf Not TbxStartTime.Time.HasValue Then
            EprValidation.SetError(LblStartTime, "Hora inválida.")
            EprValidation.SetIconAlignment(LblStartTime, ErrorIconAlignment.MiddleRight)
            TbxStartTime.Select()
            Return False
        ElseIf Not TbxEndTime.Time.HasValue Then
            EprValidation.SetError(LblEndTime, "Hora inválida.")
            EprValidation.SetIconAlignment(LblEndTime, ErrorIconAlignment.MiddleRight)
            TbxEndTime.Select()
            Return False
        ElseIf TbxStartTime.Time = TbxEndTime.Time Then
            EprValidation.SetError(LblEndTime, "Os horários de chegada e saída não podem ser iguais.")
            EprValidation.SetIconAlignment(LblEndTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TbxEndTime.Select()
            Return False
        ElseIf TbxStartTime.Time > TbxEndTime.Time Then
            EprValidation.SetError(LblEndTime, "O horário de saída deve ser maior que o de chegada.")
            EprValidation.SetIconAlignment(LblEndTime, ErrorIconAlignment.MiddleRight)
            TcEvaluation.SelectedTab = TabMain
            TbxEndTime.Select()
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
        ElseIf Not Calculated Then
            EprValidation.SetError(BtnCalculate, "A avaliação precisa ser calculada.")
            EprValidation.SetIconAlignment(BtnCalculate, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(BtnCalculate, -125)
            TcEvaluation.SelectedTab = TabMain
            BtnCalculate.Select()
            Return False
        ElseIf _Evaluation.WorkedHourControlledSelable.Count + _Evaluation.ElapsedDayControlledSellable.Count = 0 Then
            EprValidation.SetError(GbxWorkedHourSellable, "A avaliação precisa ter pelo menos um item.")
            EprValidation.SetIconAlignment(GbxWorkedHourSellable, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxWorkedHourSellable, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvWorkedHourSellable.Select()
            Return False
        ElseIf _Evaluation.WorkedHourControlledSelable.Any(Function(x) x.CurrentCapacity > x.PersonCompressorSellable.Capacity) Then
            EprValidation.SetError(GbxWorkedHourSellable, "Existe um ou mais itens com a capacidade atual superior a capacidade total.")
            EprValidation.SetIconAlignment(GbxWorkedHourSellable, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxWorkedHourSellable, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvWorkedHourSellable.Select()
            Return False
        ElseIf _Evaluation.ElapsedDayControlledSellable.Any(Function(x) x.CurrentCapacity > x.PersonCompressorSellable.Capacity) Then
            EprValidation.SetError(GbxElapsedDaySellable, "Existe um ou mais itens com a capacidade atual superior a capacidade total.")
            EprValidation.SetIconAlignment(GbxElapsedDaySellable, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxElapsedDaySellable, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvElapsedDaySellable.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        Dim Success As Boolean
        QbxCustomer.Text = QbxCustomer.Text.Trim.ToUnaccented()
        TxtResponsible.Text = TxtResponsible.Text.Trim.ToUnaccented()
        QbxCompressor.Text = QbxCompressor.Text.Trim.ToUnaccented()
        TxtTechnicalAdvice.Text = TxtTechnicalAdvice.Text.ToUpper.ToUnaccented()
        If _Evaluation.LockInfo.IsLocked And _Evaluation.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Evaluation.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Success = False
        ElseIf _Evaluation.Status = EvaluationStatus.Approved AndAlso Not _User.CanAccess(Routine.EvaluationApproveOrReject) Then
            CMessageBox.Show("Esta avaliação já foi aprovada e não pode mais ser alterada.", CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFieldsToSave() Then
                Try
                    Cursor = Cursors.WaitCursor
                    _Evaluation.CallType = _UcCallTypeHasRepairNeedProposal.CallType
                    _Evaluation.HasRepair = _UcCallTypeHasRepairNeedProposal.HasRepair
                    _Evaluation.NeedProposal = _UcCallTypeHasRepairNeedProposal.NeedProposal
                    _Evaluation.UnitName = _Evaluation.UnitName
                    _Evaluation.Temperature = _Evaluation.Temperature
                    _Evaluation.Pressure = _Evaluation.Pressure
                    _Evaluation.EvaluationDate = DbxEvaluationDate.Text
                    _Evaluation.StartTime = TbxStartTime.Time
                    _Evaluation.EndTime = TbxEndTime.Time
                    _Evaluation.EvaluationNumber = TxtEvaluationNumber.Text
                    _Evaluation.Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
                    _Evaluation.Responsible = TxtResponsible.Text
                    _Evaluation.Horimeter = DbxHorimeter.DecimalValue
                    _Evaluation.ManualAverageWorkLoad = CbxManualAverageWorkLoad.Checked
                    _Evaluation.AverageWorkLoad = DbxAverageWorkLoad.Text
                    _Evaluation.TechnicalAdvice = TxtTechnicalAdvice.Text
                    If _Evaluation.ID = 0 AndAlso _User.CanAccess(Routine.EvaluationApproveOrReject) Then
                        _Evaluation.SaveChanges()
                        BtnApprove.PerformClick()
                    Else
                        _Evaluation.SaveChanges()
                    End If
                    _Evaluation.Lock()
                    LblIDValue.Text = _Evaluation.ID
                    DgvTechnician.Fill(_Evaluation.Technicians)
                    DgvWorkedHourSellable.Fill(_Evaluation.WorkedHourControlledSelable)
                    DgvElapsedDaySellable.Fill(_Evaluation.ElapsedDayControlledSellable)
                    DgvReplacedSellable.Fill(_Evaluation.ReplacedSellables)
                    DgvlElapsedDaySellable.Load()
                    DgvlWorkedHourSellable.Load()
                    DgvlReplacedSellable.Load()
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.Evaluation)
                    If _Evaluation.Status = EvaluationStatus.Rejected Then
                        If CMessageBox.Show("Deseja alterar o status da avaliação para REVISADO?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                            _Evaluation.SetStatus(EvaluationStatus.Reviewed)
                            BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
                            BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
                            LblStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
                            LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
                            BtnApprove.Visible = _Evaluation.Status <> EvaluationStatus.Approved
                            BtnReject.Visible = _Evaluation.Status <> EvaluationStatus.Rejected
                            BtnDisapprove.Visible = _Evaluation.Status <> EvaluationStatus.Disapproved
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
                    CMessageBox.Show("ERRO EV020", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Success = False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Success = False
            End If
        End If
        Return Success
    End Function
    Private Function GetCMT() As Decimal
        Dim Value As Decimal
        Value = 5.71
        If IsDate(DbxEvaluationDate.Text) Then
            If QbxCompressor.IsFreezed Then
                If DbxHorimeter.DecimalValue >= 0 Then
                    If Evaluation.HasPreviousEvaluation(_Evaluation.Compressor, DbxEvaluationDate.Text, LblIDValue.Text) Then
                        If Evaluation.GetPreviousEvaluationDate(_Evaluation.Compressor, DbxEvaluationDate.Text, LblIDValue.Text) <= CDate(DbxEvaluationDate.Text) Then
                            Value = Evaluation.GetAverageWorkLoad(_Evaluation.Compressor, DbxHorimeter.DecimalValue, DbxEvaluationDate.Text, LblIDValue.Text)
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
        ElseIf Evaluation.CountEvaluation(QbxCompressor.FreezedPrimaryKey, {EvaluationStatus.Disapproved, EvaluationStatus.Rejected, EvaluationStatus.Reviewed}.ToList, _Evaluation.ID) > 0 Then
            EprValidation.SetError(BtnCalculate, "Não foi possível calcular pois há avaliação não aprovada para esse compressor.")
            EprValidation.SetIconAlignment(BtnCalculate, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(BtnCalculate, -125)
            TcEvaluation.SelectedTab = TabMain
            BtnCalculate.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub Decalculate()
        Calculated = False
        DgvWorkedHourSellable.DataSource = Nothing
        DgvElapsedDaySellable.DataSource = Nothing
    End Sub
    Private Sub EditEvaluationControlledSellable(ControlType As CompressorSellableControlType)
        Dim Result As DialogResult
        Dim Sellable As EvaluationControlledSellable
        Dim RowIndex As Long
        If ControlType = CompressorSellableControlType.ElapsedDay Then
            Sellable = _Evaluation.ElapsedDayControlledSellable.Single(Function(x) x.PersonCompressorSellable.ID = DgvElapsedDaySellable.SelectedRows(0).Cells("PersonCompressorSellable").Value.ID)
            RowIndex = DgvElapsedDaySellable.SelectedRows(0).Index
            Using Form As New FrmEvaluationControlledSellable(Sellable)
                Result = Form.ShowDialog()
                DgvElapsedDaySellable.Fill(_Evaluation.ElapsedDayControlledSellable)
                DgvlElapsedDaySellable.Load()
                NavElapsedDaySellable.EnsureVisibleRow(RowIndex)
            End Using
        Else
            Sellable = _Evaluation.WorkedHourControlledSelable.Single(Function(x) x.PersonCompressorSellable.ID = DgvWorkedHourSellable.SelectedRows(0).Cells("PersonCompressorSellable").Value.ID)
            RowIndex = DgvWorkedHourSellable.SelectedRows(0).Index
            Using Form As New FrmEvaluationControlledSellable(Sellable)
                Result = Form.ShowDialog()
                DgvWorkedHourSellable.Fill(_Evaluation.WorkedHourControlledSelable)
                DgvlWorkedHourSellable.Load()
                NavWorkedHourSellable.EnsureVisibleRow(RowIndex)
            End Using
        End If
        If _Evaluation.WorkedHourControlledSelable.Any(Function(x) x.Sold) Or _Evaluation.ElapsedDayControlledSellable.Any(Function(x) x.Sold) Then
            _UcCallTypeHasRepairNeedProposal.HasRepair = ConfirmationType.Yes
        Else
            If _UcCallTypeHasRepairNeedProposal.HasRepair = ConfirmationType.Yes Then
                _UcCallTypeHasRepairNeedProposal.HasRepair = ConfirmationType.No
            End If
        End If
        If Not BtnSave.Enabled Then
            BtnSave.Enabled = Result = DialogResult.OK
        End If
    End Sub
    Private Sub FilterComplement()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = "Name LIKE '%@VALUE%' OR Code LIKE '%@VALUE%'"
        If DgvReplacedSellable.DataSource IsNot Nothing Then
            Table = DgvReplacedSellable.DataSource
            View = Table.DefaultView
            If TxtFilterReplacedSellable.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterReplacedSellable.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
#End Region
#Region "Aux Events"
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
            _Evaluation.Load(_EvaluationsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO EV001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CallTypeHasRepairNeedProposalChanged(sender As Object, e As EventArgs)
        Dim VisitType As String = If(String.IsNullOrEmpty(EnumHelper.GetEnumDescription(_UcCallTypeHasRepairNeedProposal.CallType)), "N/A", EnumHelper.GetEnumDescription(_UcCallTypeHasRepairNeedProposal.CallType).ToTitle)
        Dim HasRepair As String = If(String.IsNullOrEmpty(EnumHelper.GetEnumDescription(_UcCallTypeHasRepairNeedProposal.HasRepair)), "N/A", EnumHelper.GetEnumDescription(_UcCallTypeHasRepairNeedProposal.HasRepair).ToTitle)
        Dim NeedProposal As String = If(String.IsNullOrEmpty(EnumHelper.GetEnumDescription(_UcCallTypeHasRepairNeedProposal.NeedProposal)), "N/A", EnumHelper.GetEnumDescription(_UcCallTypeHasRepairNeedProposal.NeedProposal).ToTitle)
        BtnCallTypeHasRepairNeedProposal.TextParts(1).Text = VisitType
        BtnCallTypeHasRepairNeedProposal.TextParts(4).Text = HasRepair
        BtnCallTypeHasRepairNeedProposal.TextParts(7).Text = NeedProposal
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
        BtnCallTypeHasRepairNeedProposal.Invalidate()
    End Sub
    Private Sub UnitTemperaturePressureChanged(sender As Object, e As EventArgs)
        Dim Unit As String = If(String.IsNullOrEmpty(_UcUnitTemperaturePressure.Unit), "N/A", $"{ _UcUnitTemperaturePressure.Unit}")
        Dim Temperature As String = If(_UcUnitTemperaturePressure.Temperature <= 0, "N/A", $"{ _UcUnitTemperaturePressure.Temperature}ºC ")
        Dim Pressure As String = If(_UcUnitTemperaturePressure.Pressure <= 0, "N/A", $"{ _UcUnitTemperaturePressure.Pressure}BAR ")
        BtnUnitTemperaturePressure.TextParts(1).Text = Unit
        BtnUnitTemperaturePressure.TextParts(4).Text = Temperature
        BtnUnitTemperaturePressure.TextParts(7).Text = Pressure
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
        BtnUnitTemperaturePressure.Invalidate()
    End Sub
#End Region
#Region "Document"
    Private Sub BtnAttachPDF_Click(sender As Object, e As EventArgs) Handles BtnAttachPDF.Click
        Dim Filename As String
        If OfdDocument.ShowDialog = DialogResult.OK Then
            Filename = TextHelper.GetRandomFileName(Path.GetExtension(OfdDocument.FileName))
            File.Copy(OfdDocument.FileName, Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            _Evaluation.Document.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
            If Not String.IsNullOrEmpty(_Evaluation.Document.CurrentFile) AndAlso File.Exists(_Evaluation.Document.CurrentFile) Then
                Try
                    PdfDocumentViewer.Load(_Evaluation.Document.CurrentFile)
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
    Private Sub BtnSavePDF_Click(sender As Object, e As EventArgs) Handles BtnSavePDF.Click
        SfdDocument.FileName = Path.GetFileName("Avaliação " & _Evaluation.EvaluationNumber)
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
    Private Sub BtnDeletePDF_Click(sender As Object, e As EventArgs) Handles BtnDeletePDF.Click
        If CMessageBox.Show("O documento será excluído permanentemente quando essa avaliação for salva. Confirma a exclusão?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            _Evaluation.Document.SetCurrentFile(Nothing)
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
    Private Sub BtnZoomOut_Click(sender As Object, e As EventArgs) Handles BtnZoomOut.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage - 10)
    End Sub
    Private Sub BtnZoomIn_Click(sender As Object, e As EventArgs) Handles BtnZoomIn.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage + 10)
    End Sub
    Private Sub PdfDocumentViewer_CurrentPageChanged(sender As Object, args As EventArgs) Handles PdfDocumentViewer.CurrentPageChanged
        LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
    End Sub
#End Region
#Region "Picture"
    Private Sub BtnSavePicture_Click(sender As Object, e As EventArgs) Handles BtnSavePicture.Click
        Using Sfd As New SaveFileDialog()
            Sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp"
            Sfd.Title = "Salvar Imagem"
            Sfd.FileName = "Foto"
            If Sfd.ShowDialog() = DialogResult.OK Then
                Dim FileExtension As String = IO.Path.GetExtension(Sfd.FileName).ToLower()
                Dim ImageFormat As Imaging.ImageFormat
                Select Case FileExtension
                    Case ".jpg"
                        ImageFormat = Imaging.ImageFormat.Jpeg
                    Case ".png"
                        ImageFormat = Imaging.ImageFormat.Png
                    Case ".bmp"
                        ImageFormat = Imaging.ImageFormat.Bmp
                    Case Else
                        MessageBox.Show("Formato de arquivo não suportado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                End Select
                PbxPicture.Image.Save(Sfd.FileName, ImageFormat)
            End If
        End Using
    End Sub
    Private Sub BtnIncludePicture_Click(sender As Object, e As EventArgs) Handles BtnIncludePicture.Click
        Dim Filename As String
        Dim Picture As EvaluationPicture
        Using Ofd As New OpenFileDialog()
            Ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*"
            Ofd.Title = "Selecionar Imagem"
            If Ofd.ShowDialog() = DialogResult.OK Then
                Filename = TextHelper.GetRandomFileName(Path.GetExtension(Ofd.FileName))
                File.Copy(Ofd.FileName, Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
                Picture = New EvaluationPicture()
                Picture.Picture.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
                _Evaluation.Pictures.Add(Picture)
                SelectedPicture = Picture
                EprValidation.Clear()
                BtnSave.Enabled = True
            End If
        End Using
        RefreshPictureControls()
    End Sub
    Private Sub BtnRemovePicture_Click(sender As Object, e As EventArgs) Handles BtnRemovePicture.Click
        Dim Pictures As List(Of EvaluationPicture) = _Evaluation.Pictures.ToList()
        If CMessageBox.Show("A foto será excluída permanentemente quando essa avaliação for salva. Confirma a exclusão?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            SelectedPicture.Picture.SetCurrentFile(Nothing)
            Dim Index As Integer = Pictures.IndexOf(SelectedPicture)
            Dim Found As Boolean = False
            For i As Integer = Index - 1 To 0 Step -1
                If Pictures(i).Picture.CurrentFile IsNot Nothing Then
                    SelectedPicture = Pictures(i)
                    Found = True
                    Exit For
                End If
            Next
            If Not Found Then
                For i As Integer = Index + 1 To Pictures.Count - 1
                    If Pictures(i).Picture.CurrentFile IsNot Nothing Then
                        SelectedPicture = Pictures(i)
                        Found = True
                        Exit For
                    End If
                Next
            End If
            If Not Found Then
                SelectedPicture = Nothing
            End If
            RefreshPictureControls()
            EprValidation.Clear()
            BtnSave.Enabled = True
        End If
    End Sub
    Private Sub BtnPreviousPicture_Click(sender As Object, e As EventArgs) Handles BtnPreviousPicture.Click
        Dim ValidPictures As List(Of EvaluationPicture) = _Evaluation.Pictures.Where(Function(x) x.Picture.CurrentFile IsNot Nothing).ToList
        SelectedPicture = ValidPictures(ValidPictures.IndexOf(SelectedPicture) - 1)
        RefreshPictureControls()
    End Sub

    Private Sub BtnNextPicture_Click(sender As Object, e As EventArgs) Handles BtnNextPicture.Click
        Dim ValidPictures As List(Of EvaluationPicture) = _Evaluation.Pictures.Where(Function(x) x.Picture.CurrentFile IsNot Nothing).ToList
        SelectedPicture = ValidPictures(ValidPictures.IndexOf(SelectedPicture) + 1)
        RefreshPictureControls()
    End Sub

    Private Sub BtnFirstPicture_Click(sender As Object, e As EventArgs) Handles BtnFirstPicture.Click
        Dim ValidPicture As List(Of EvaluationPicture) = _Evaluation.Pictures.Where(Function(x) x.Picture.CurrentFile IsNot Nothing).ToList
        SelectedPicture = ValidPicture(0)
        RefreshPictureControls()
    End Sub

    Private Sub BtnLastPicture_Click(sender As Object, e As EventArgs) Handles BtnLastPicture.Click
        Dim ValidPicture As List(Of EvaluationPicture) = _Evaluation.Pictures.Where(Function(x) x.Picture.CurrentFile IsNot Nothing).ToList
        SelectedPicture = ValidPicture(ValidPicture.Count - 1)
        RefreshPictureControls()
    End Sub
    Private Sub RefreshPictureControls()
        Dim ValidPictures As List(Of EvaluationPicture) = _Evaluation.Pictures.Where(Function(x) x.Picture.CurrentFile IsNot Nothing).ToList
        Dim PictureCount As Integer = ValidPictures.Count
        Dim PictureIndex As Integer = ValidPictures.IndexOf(SelectedPicture)
        If PictureCount < 1 Then
            LblPictureCount.Visible = False
            BtnSavePicture.Enabled = False
            BtnRemovePicture.Enabled = False
            BtnFirstPicture.Enabled = False
            BtnPreviousPicture.Enabled = False
            BtnNextPicture.Enabled = False
            BtnLastPicture.Enabled = False
            PbxPicture.Image = Nothing
        Else
            LblPictureCount.Visible = True
            LblPictureCount.Text = $"Foto {PictureIndex + 1} de {PictureCount}"
            BtnRemovePicture.Enabled = True
            BtnSavePicture.Enabled = True
            BtnFirstPicture.Enabled = (PictureIndex > 0)
            BtnPreviousPicture.Enabled = (PictureIndex > 0)
            BtnNextPicture.Enabled = (PictureIndex < PictureCount - 1)
            BtnLastPicture.Enabled = (PictureIndex < PictureCount - 1)
        End If
    End Sub
    Private Sub BtnPicture_EnabledChanged(sender As Object, e As EventArgs) Handles BtnSavePicture.EnabledChanged, BtnRemovePicture.EnabledChanged, BtnPreviousPicture.EnabledChanged, BtnNextPicture.EnabledChanged, BtnLastPicture.EnabledChanged, BtnIncludePicture.EnabledChanged, BtnFirstPicture.EnabledChanged
        Dim Button As NoFocusCueButton = sender
        If Button.Enabled Then
            Select Case True
                Case Button Is BtnFirstPicture
                    Button.BackgroundImage = My.Resources.NavFirst
                Case Button Is BtnPreviousPicture
                    Button.BackgroundImage = My.Resources.NavPrevious
                Case Button Is BtnNextPicture
                    Button.BackgroundImage = My.Resources.NavNext
                Case Button Is BtnLastPicture
                    Button.BackgroundImage = My.Resources.NavLast
                Case Button Is BtnIncludePicture
                    Button.BackgroundImage = My.Resources.ImageInclude
                Case Button Is BtnRemovePicture
                    Button.BackgroundImage = My.Resources.ImageDelete
                Case Button Is BtnSavePicture
                    Button.BackgroundImage = My.Resources.ImageSave
            End Select
        Else
            Dim Img As Image = Button.BackgroundImage
            Dim Colors As List(Of Color) = ImageHelper.GetImageColors(Img)
            Img = ImageHelper.GetRecoloredImage(Img, Color.Gray)
            Button.BackgroundImage = Img
        End If
    End Sub
#End Region
#Region "Button Events"
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _Evaluation = New Evaluation
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Evaluation.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Evaluation.LockInfo.IsLocked Or (_Evaluation.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Evaluation.LockInfo.SessionToken) Then
                        _Evaluation.Delete()
                        If _EvaluationsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _EvaluationsForm.DgvEvaluationLayout.Load()
                            _EvaluationsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Evaluation.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
        Using Form As New FrmLog(Routine.Evaluation, _Evaluation.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles BtnApprove.Click
        Dim Row As DataGridViewRow
        If _Evaluation.ID > 0 Then
            Try
                Cursor = Cursors.WaitCursor
                _Evaluation.SetStatus(EvaluationStatus.Approved)
                BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
                BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
                LblStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
                LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
                BtnApprove.Visible = _Evaluation.Status <> EvaluationStatus.Approved
                BtnReject.Visible = _Evaluation.Status <> EvaluationStatus.Rejected
                BtnDisapprove.Visible = _Evaluation.Status <> EvaluationStatus.Disapproved
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
            CMessageBox.Show("Esta avaliação ainda não foi salva e, por isso, não pode ser aprovada.")
        End If
    End Sub
    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles BtnDisapprove.Click
        Dim Row As DataGridViewRow
        Try
            Cursor = Cursors.WaitCursor
            _Evaluation.SetStatus(EvaluationStatus.Disapproved)
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
            BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
            LblStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
            LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
            BtnApprove.Visible = _Evaluation.Status <> EvaluationStatus.Approved
            BtnReject.Visible = _Evaluation.Status <> EvaluationStatus.Rejected
            BtnDisapprove.Visible = _Evaluation.Status <> EvaluationStatus.Disapproved
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
    Private Sub BtnReject_Click(sender As Object, e As EventArgs) Handles BtnReject.Click
        Dim Row As DataGridViewRow
        If _Evaluation.ID > 0 Then
            Using Form As New FrmEvaluationRejectReason
                If Form.ShowDialog = DialogResult.OK Then
                    Try
                        Cursor = Cursors.WaitCursor
                        _Evaluation.SetStatus(EvaluationStatus.Rejected, Form.TxtReason.Text)
                        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
                        BtnStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
                        LblStatusValue.Text = EnumHelper.GetEnumDescription(_Evaluation.Status)
                        LblStatusValue.ToolTipText = If(String.IsNullOrEmpty(_Evaluation.RejectReason), Nothing, "MOTIVO:" & vbNewLine & _Evaluation.RejectReason)
                        BtnApprove.Visible = _Evaluation.Status <> EvaluationStatus.Approved
                        BtnReject.Visible = _Evaluation.Status <> EvaluationStatus.Rejected
                        BtnDisapprove.Visible = _Evaluation.Status <> EvaluationStatus.Disapproved
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
    Private Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles BtnCalculate.Click
        Dim Customer As Person
        Dim PreviousEvaluation As Evaluation
        Dim PreviousEvaluationID As Long
        Dim PreviousSellable As EvaluationControlledSellable
        If IsValidFieldsToCalculate() Then
            EprValidation.Clear()
            If Not Calculated And DbxHorimeter.DecimalValue = 0 Then
                If CMessageBox.Show("O horímetro informado foi 0 (zero). Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
            End If
            If Calculated Then
                If CMessageBox.Show("Os itens dessa avaliação já foram calculados. Calcular novamente irá redefinir as capacidades e o CMT com base na avaliação anterior. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
            End If
            Try
                Cursor = Cursors.WaitCursor
                Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
                _Evaluation.Compressor = Customer.Compressors.Single(Function(x) x.ID = QbxCompressor.FreezedPrimaryKey)
                PreviousEvaluationID = Evaluation.GetPreviousEvaluationID(_Evaluation.Compressor, CDate(DbxEvaluationDate.Text), _Evaluation.ID)
                PreviousEvaluation = New Evaluation().Load(PreviousEvaluationID, False)
                For Each CurrentSellable As EvaluationControlledSellable In _Evaluation.WorkedHourControlledSelable.ToArray.Reverse
                    If CurrentSellable.PersonCompressorSellable.Status = SimpleStatus.Inactive Then
                        _Evaluation.WorkedHourControlledSelable.Remove(CurrentSellable)
                    End If
                Next CurrentSellable
                For Each CurrentSellable As EvaluationControlledSellable In _Evaluation.ElapsedDayControlledSellable.ToArray.Reverse
                    If CurrentSellable.PersonCompressorSellable.Status = SimpleStatus.Inactive Then
                        _Evaluation.ElapsedDayControlledSellable.Remove(CurrentSellable)
                    End If
                Next CurrentSellable
                If DbxHorimeter.DecimalValue < PreviousEvaluation.Horimeter Then
                    CMessageBox.Show("O horímetro informado é menor que o da última avaliação deste compressor. Só mantenha esse valor caso a unidade tenha sido reconstruída. Nesse caso, a capacidade atual dos itens e a carga média de trabalho (CMT) serão mantidas conforme a última avaliação.", CMessageBoxType.Warning)
                    Cursor = Cursors.WaitCursor
                    For Each CurrentSellable As EvaluationControlledSellable In _Evaluation.WorkedHourControlledSelable
                        CurrentSellable.Sold = False
                        CurrentSellable.Lost = False
                        PreviousSellable = PreviousEvaluation.WorkedHourControlledSelable.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                        If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                            CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity
                        Else
                            CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                        End If
                    Next CurrentSellable
                    For Each CurrentSellable As EvaluationControlledSellable In _Evaluation.ElapsedDayControlledSellable
                        CurrentSellable.Sold = False
                        CurrentSellable.Lost = False
                        PreviousSellable = PreviousEvaluation.ElapsedDayControlledSellable.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                        If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                            CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity
                        Else
                            CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                        End If
                    Next CurrentSellable
                    If Not CbxManualAverageWorkLoad.Checked Then DbxAverageWorkLoad.Text = PreviousEvaluation.AverageWorkLoad
                Else
                    For Each CurrentSellable As EvaluationControlledSellable In _Evaluation.WorkedHourControlledSelable
                        CurrentSellable.Sold = False
                        CurrentSellable.Lost = False
                        PreviousSellable = PreviousEvaluation.WorkedHourControlledSelable.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                        If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                            CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity - (DbxHorimeter.DecimalValue - PreviousEvaluation.Horimeter)
                        Else
                            CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                        End If
                    Next CurrentSellable
                    For Each CurrentSellable As EvaluationControlledSellable In _Evaluation.ElapsedDayControlledSellable
                        CurrentSellable.Sold = False
                        CurrentSellable.Lost = False
                        PreviousSellable = PreviousEvaluation.ElapsedDayControlledSellable.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                        If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                            CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity - (CDate(DbxEvaluationDate.Text).Subtract(PreviousEvaluation.EvaluationDate).Days)
                        Else
                            CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                        End If
                    Next CurrentSellable
                    If Not CbxManualAverageWorkLoad.Checked Then DbxAverageWorkLoad.Text = GetCMT()
                End If
                DgvWorkedHourSellable.Fill(_Evaluation.WorkedHourControlledSelable)
                DgvElapsedDaySellable.Fill(_Evaluation.ElapsedDayControlledSellable)
                DgvlElapsedDaySellable.Load()
                DgvlWorkedHourSellable.Load()
                TcEvaluation.SelectedTab = TabMain
                Calculated = True
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
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(EvaluationStatus.Approved) Then
            BtnStatusValue.ForeColor = Color.DarkBlue
            LblStatusValue.ForeColor = Color.DarkBlue
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(EvaluationStatus.Rejected) Then
            BtnStatusValue.ForeColor = Color.DarkRed
            LblStatusValue.ForeColor = Color.DarkRed
        Else
            BtnStatusValue.ForeColor = Color.Chocolate
            LblStatusValue.ForeColor = Color.Chocolate
        End If
    End Sub
    Private Sub BtnNewCustomer_Click(sender As Object, e As EventArgs) Handles BtnNewCustomer.Click
        Dim Customer As Person
        Customer = New Person With {
            .IsCustomer = True,
            .ControlMaintenance = True
        }
        Using Form As New FrmPerson(Customer)
            Form.CbxIsCustomer.Enabled = False
            Form.CbxMaintenance.Enabled = False
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Customer.ID > 0 Then
            QbxCustomer.Freeze(Customer.ID)
            Decalculate()
            BtnCalculate.Text = "Calcular"
        End If
        QbxCustomer.Select()
    End Sub
    Private Sub BtnViewCustomer_Click(sender As Object, e As EventArgs) Handles BtnViewCustomer.Click
        Dim FreezedCustomerID As Long = QbxCustomer.FreezedPrimaryKey
        Dim FreezedCompressorID As Long = QbxCompressor.FreezedPrimaryKey
        Using Form As New FrmPerson(New Person().Load(QbxCustomer.FreezedPrimaryKey, True))
            Form.CbxIsCustomer.Enabled = False
            Form.CbxMaintenance.Enabled = False
            Form.ShowDialog()
        End Using
        _Loading = True
        QbxCustomer.Unfreeze()
        QbxCustomer.Freeze(FreezedCustomerID)
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(FreezedCompressorID)
        QbxCustomer.Select()
        _Loading = False
    End Sub
    Private Sub BtnFilterCustomer_Click(sender As Object, e As EventArgs) Handles BtnFilterCustomer.Click
        Using Form As New FrmFilter(New PersonCustomerQueriedBoxFilter("Sim"), QbxCustomer) With {.Text = "Filtro de Clientes"}
            Form.ShowDialog()
        End Using
        QbxCustomer.Select()
    End Sub
    Private Sub BtnIncludetechnician_Click(sender As Object, e As EventArgs) Handles BtnIncludeTechnician.Click
        Using Form As New FrmEvaluationTechnician(_Evaluation, New EvaluationTechnician(), Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEditTechnician_Click(sender As Object, e As EventArgs) Handles BtnEditTechnician.Click
        Dim Technician As EvaluationTechnician
        If DgvTechnician.SelectedRows.Count = 1 Then
            Technician = _Evaluation.Technicians.Single(Function(x) x.Guid = DgvTechnician.SelectedRows(0).Cells("Guid").Value)
            Using Form As New FrmEvaluationTechnician(_Evaluation, Technician, Me)
                Form.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnDeleteTechnician_Click(sender As Object, e As EventArgs) Handles BtnDeleteTechnician.Click
        Dim Technician As EvaluationTechnician
        If DgvTechnician.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Technician = _Evaluation.Technicians.Single(Function(x) x.Guid = DgvTechnician.SelectedRows(0).Cells("Guid").Value)
                _Evaluation.Technicians.Remove(Technician)
                DgvTechnician.Fill(_Evaluation.Technicians)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnIncludeReplacedSellable_Click(sender As Object, e As EventArgs) Handles BtnIncludeReplacedSellable.Click
        Using Form As New FrmEvaluationReplacedSellable(_Evaluation, New EvaluationReplacedSellable(), Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEditReplacedSellable_Click(sender As Object, e As EventArgs) Handles BtnEditReplacedSellable.Click
        Dim Item As EvaluationReplacedSellable
        If DgvReplacedSellable.SelectedRows.Count = 1 Then
            Item = _Evaluation.ReplacedSellables.Single(Function(x) x.Guid = DgvReplacedSellable.SelectedRows(0).Cells("Guid").Value)
            Using Form As New FrmEvaluationReplacedSellable(_Evaluation, Item, Me)
                Form.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnDeleteReplacedSellable_Click(sender As Object, e As EventArgs) Handles BtnDeleteReplacedSellable.Click
        Dim Item As EvaluationReplacedSellable
        If DgvReplacedSellable.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Item = _Evaluation.ReplacedSellables.Single(Function(x) x.Guid = DgvReplacedSellable.SelectedRows(0).Cells("Guid").Value)
                _Evaluation.ReplacedSellables.Remove(Item)
                DgvReplacedSellable.Fill(_Evaluation.ReplacedSellables)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
#End Region
#Region "Textbox Events"
    Private Sub TxtTechnicalAdvice_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TxtTechnicalAdvice.LinkClicked
        Process.Start(e.LinkText)
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtTechnicalAdvice.TextChanged,
                                                                         TxtResponsible.TextChanged,
                                                                         TxtEvaluationNumber.TextChanged,
                                                                         QbxCustomer.TextChanged,
                                                                         DbxAverageWorkLoad.TextChanged,
                                                                         TbxStartTime.TextChanged,
                                                                         TbxEndTime.TextChanged
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
    Private Sub TxtKeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterReplacedSellable.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterReplacedSellable_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterReplacedSellable.TextChanged
        FilterComplement()
    End Sub
    Private Sub TxtFilterReplacedSellable_Enter(sender As Object, e As EventArgs) Handles TxtFilterReplacedSellable.Enter
        EprInformation.SetError(TsReplacedSellable, "Filtrando os campos: Produto/Serviço")
        EprInformation.SetIconAlignment(TsReplacedSellable, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsReplacedSellable, -365)
    End Sub
    Private Sub TxtFilterReplacedSellable_Leave(sender As Object, e As EventArgs) Handles TxtFilterReplacedSellable.Leave
        EprInformation.Clear()
    End Sub
#End Region
#Region "CheckBox Events"
    Private Sub CbxManualAverageWorkLoad_CheckedChanged(sender As Object, e As EventArgs) Handles CbxManualAverageWorkLoad.CheckedChanged
        If CbxManualAverageWorkLoad.Checked Then
            DbxAverageWorkLoad.ReadOnly = False
        Else
            DbxAverageWorkLoad.ReadOnly = True
        End If
        EprValidation.Clear()
        BtnSave.Enabled = True
    End Sub
#End Region
#Region "DataGridView Events"
    Private Sub DgvWorkedHourSellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvWorkedHourSellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvWorkedHourSellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            EditEvaluationControlledSellable(CompressorSellableControlType.WorkedHour)
        End If
    End Sub
    Private Sub DgvElapsedDaySellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvElapsedDaySellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvElapsedDaySellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            EditEvaluationControlledSellable(CompressorSellableControlType.ElapsedDay)
        End If
    End Sub
    Private Sub DgvWorkedHourSellable_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvWorkedHourSellable.KeyDown
        If e.KeyCode = Keys.Enter Then
            EditEvaluationControlledSellable(CompressorSellableControlType.WorkedHour)
            e.Handled = True
        End If
    End Sub
    Private Sub DgvElapsedDaySellable_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvElapsedDaySellable.KeyDown
        If e.KeyCode = Keys.Enter Then
            EditEvaluationControlledSellable(CompressorSellableControlType.ElapsedDay)
            e.Handled = True
        End If
    End Sub
    Private Sub DgvTechnician_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvTechnician.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvTechnician.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditTechnician.PerformClick()
        End If
    End Sub
    Private Sub DgvReplacedSellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvReplacedSellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvReplacedSellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditReplacedSellable.PerformClick()
        End If
    End Sub
    Private Sub DgvReplacedSellable_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvReplacedSellable.DataSourceChanged
        FilterComplement()
    End Sub
    Private Sub DgvReplacedSellable_SelectionChanged(sender As Object, e As EventArgs) Handles DgvReplacedSellable.SelectionChanged
        If DgvReplacedSellable.SelectedRows.Count = 0 Then
            BtnEditReplacedSellable.Enabled = False
            BtnDeleteReplacedSellable.Enabled = False
        Else
            BtnEditReplacedSellable.Enabled = True
            BtnDeleteReplacedSellable.Enabled = True
        End If
    End Sub
#End Region
#Region "TabControl Events"
    Private Sub TcEvaluation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcEvaluation.SelectedIndexChanged
        If TcEvaluation.SelectedTab Is TabMain Then
            If Calculated Then
                FormBorderStyle = FormBorderStyle.FixedSingle
                WindowState = FormWindowState.Normal
                MaximizeBox = False
                Size = New Size(1055, 570 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            Else
                FormBorderStyle = FormBorderStyle.FixedSingle
                WindowState = FormWindowState.Normal
                MaximizeBox = False
                Size = New Size(433, 570 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            End If
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
#End Region
#Region "QueriedBox Events"
    Private Sub QbxCustomer_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCustomer.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewCustomer.Visible = QbxCustomer.IsFreezed And _User.CanWrite(Routine.Person)
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
    Private Sub QbxCustomer_Enter(sender As Object, e As EventArgs) Handles QbxCustomer.Enter
        TmrCustomer.Stop()
        BtnViewCustomer.Visible = QbxCustomer.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNewCustomer.Visible = _User.CanWrite(Routine.Person)
        BtnFilterCustomer.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxCustomer_Leave(sender As Object, e As EventArgs) Handles QbxCustomer.Leave
        TmrCustomer.Stop()
        TmrCustomer.Start()
    End Sub
#End Region
#Region "Timer Events"
    Private Sub TmrCustomer_Tick(sender As Object, e As EventArgs) Handles TmrCustomer.Tick
        BtnViewCustomer.Visible = False
        BtnNewCustomer.Visible = False
        BtnFilterCustomer.Visible = False
        TmrCustomer.Stop()
    End Sub
#End Region
End Class