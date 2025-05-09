Imports System.IO
Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports ManagerCore
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Tls
Public Class FrmEvaluation
    Private _Evaluation As Evaluation
    Private _EvaluationsForm As FrmEvaluations
    Private _EvaluationsGrid As DataGridView
    Private _Filter As EvaluationFilter
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _Calculated As Boolean
    Private _TargetSize As Size
    Private _SelectedPhoto As EvaluationPhoto
    Private _Resizer As FluidResizer
    Private _User As User

    Private _UcUnitTemperaturePressure As UcEvaluationUnitTemperaturePressure
    Private _UcCallTypeHasRepairNeedProposal As UcEvaluationCallTypeHasRepairNeedProposal

    Private Property SelectedPhoto As EvaluationPhoto
        Get
            Return _SelectedPhoto
        End Get
        Set(value As EvaluationPhoto)
            _SelectedPhoto = value
            If _SelectedPhoto IsNot Nothing Then
                PbxPhoto.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(_SelectedPhoto.Photo.CurrentFile)))
            Else
                PbxPhoto.Image = Nothing
            End If
        End Set
    End Property



    Private Sub BtnRemovePhoto_Click(sender As Object, e As EventArgs) Handles BtnRemovePhoto.Click
        Dim Photos As List(Of EvaluationPhoto) = _Evaluation.Photos.ToList()

        If CMessageBox.Show("A foto será excluída permanentemente quando essa avaliação for salva. Confirma a exclusão?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
            SelectedPhoto.Photo.SetCurrentFile(Nothing)

            ' Definir o SelectedPhoto para o item anterior com CurrentFile diferente de Nothing
            Dim index As Integer = Photos.IndexOf(SelectedPhoto)
            Dim found As Boolean = False

            ' Tenta encontrar um item anterior com CurrentFile diferente de Nothing
            For i As Integer = index - 1 To 0 Step -1
                If Photos(i).Photo.CurrentFile IsNot Nothing Then
                    SelectedPhoto = Photos(i)
                    found = True
                    Exit For
                End If
            Next

            ' Se não encontrou um anterior, tenta encontrar um posterior
            If Not found Then
                For i As Integer = index + 1 To Photos.Count - 1
                    If Photos(i).Photo.CurrentFile IsNot Nothing Then
                        SelectedPhoto = Photos(i)
                        found = True
                        Exit For
                    End If
                Next
            End If

            ' Se não encontrou nenhum, define como Nothing
            If Not found Then
                SelectedPhoto = Nothing
            End If

            RefreshPhotoControls()
            EprValidation.Clear()
            BtnSave.Enabled = True
        End If
    End Sub

    Private Sub BtnSavePhoto_Click(sender As Object, e As EventArgs) Handles BtnSavePhoto.Click
        ' Verifica se há uma imagem no PictureBox
        ' Cria e configura o SaveFileDialog
        Using Sfd As New SaveFileDialog()
            Sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp"
            Sfd.Title = "Salvar Imagem"
            Sfd.FileName = "Foto"
            ' Exibe o diálogo e verifica se o usuário clicou em 'Salvar'
            If Sfd.ShowDialog() = DialogResult.OK Then
                ' Obtém a extensão do arquivo selecionado
                Dim FileExtension As String = IO.Path.GetExtension(Sfd.FileName).ToLower()
                Dim ImageFormat As Imaging.ImageFormat

                ' Define o formato da imagem com base na extensão do arquivo
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
                ' Salva a imagem no caminho especificado
                PbxPhoto.Image.Save(Sfd.FileName, ImageFormat)
            End If
        End Using
    End Sub

    Private Sub RefreshPhotoControls()

        Dim ValidPhotos As List(Of EvaluationPhoto) = _Evaluation.Photos.Where(Function(x) x.Photo.CurrentFile IsNot Nothing).ToList
        Dim PhotoCount As Integer = ValidPhotos.Count
        Dim PhotoIndex As Integer = ValidPhotos.IndexOf(SelectedPhoto)

        ' Se não houver fotos
        If PhotoCount < 1 Then
            LblPhotoCount.Visible = False
            BtnSavePhoto.Enabled = False
            BtnRemovePhoto.Enabled = False
            BtnFirstPhoto.Enabled = False
            BtnPreviousPhoto.Enabled = False
            BtnNextPhoto.Enabled = False
            BtnLastPhoto.Enabled = False
        Else
            ' Se há fotos
            LblPhotoCount.Visible = True
            LblPhotoCount.Text = $"Foto {PhotoIndex + 1} de {PhotoCount}"
            BtnRemovePhoto.Enabled = True
            BtnSavePhoto.Enabled = True

            ' Habilitar ou desabilitar os botões de navegação
            BtnFirstPhoto.Enabled = (PhotoIndex > 0)
            BtnPreviousPhoto.Enabled = (PhotoIndex > 0)
            BtnNextPhoto.Enabled = (PhotoIndex < PhotoCount - 1)
            BtnLastPhoto.Enabled = (PhotoIndex < PhotoCount - 1)
        End If
    End Sub



    Private Sub BtnPreviousPhoto_Click(sender As Object, e As EventArgs) Handles BtnPreviousPhoto.Click
        Dim ValidPhotos As List(Of EvaluationPhoto) = _Evaluation.Photos.Where(Function(x) x.Photo.CurrentFile IsNot Nothing).ToList
        SelectedPhoto = ValidPhotos(ValidPhotos.IndexOf(SelectedPhoto) - 1)
        RefreshPhotoControls()
    End Sub

    Private Sub BtnNextPhoto_Click(sender As Object, e As EventArgs) Handles BtnNextPhoto.Click
        Dim ValidPhotos As List(Of EvaluationPhoto) = _Evaluation.Photos.Where(Function(x) x.Photo.CurrentFile IsNot Nothing).ToList
        SelectedPhoto = ValidPhotos(ValidPhotos.IndexOf(SelectedPhoto) + 1)
        RefreshPhotoControls()
    End Sub

    Private Sub BtnFirstPhoto_Click(sender As Object, e As EventArgs) Handles BtnFirstPhoto.Click
        Dim ValidPhotos As List(Of EvaluationPhoto) = _Evaluation.Photos.Where(Function(x) x.Photo.CurrentFile IsNot Nothing).ToList
        SelectedPhoto = ValidPhotos(0)
        RefreshPhotoControls()
    End Sub

    Private Sub BtnLastPhoto_Click(sender As Object, e As EventArgs) Handles BtnLastPhoto.Click
        Dim ValidPhotos As List(Of EvaluationPhoto) = _Evaluation.Photos.Where(Function(x) x.Photo.CurrentFile IsNot Nothing).ToList
        SelectedPhoto = ValidPhotos(ValidPhotos.Count - 1)
        RefreshPhotoControls()
    End Sub

    Private Sub BtnPhoto_EnabledChanged(sender As Object, e As EventArgs) Handles BtnSavePhoto.EnabledChanged, BtnRemovePhoto.EnabledChanged, BtnPreviousPhoto.EnabledChanged, BtnNextPhoto.EnabledChanged, BtnLastPhoto.EnabledChanged, BtnIncludePhoto.EnabledChanged, BtnFirstPhoto.EnabledChanged
        Dim Button As NoFocusCueButton = sender
        If Button.Enabled Then
            Select Case True
                Case Button Is BtnFirstPhoto
                    Button.BackgroundImage = My.Resources.NavFirst
                Case Button Is BtnPreviousPhoto
                    Button.BackgroundImage = My.Resources.NavPrevious
                Case Button Is BtnNextPhoto
                    Button.BackgroundImage = My.Resources.NavNext
                Case Button Is BtnLastPhoto
                    Button.BackgroundImage = My.Resources.NavLast
                Case Button Is BtnIncludePhoto
                    Button.BackgroundImage = My.Resources.ImageInclude
                Case Button Is BtnRemovePhoto
                    Button.BackgroundImage = My.Resources.ImageDelete
                Case Button Is BtnSavePhoto
                    Button.BackgroundImage = My.Resources.ImageSave
            End Select
        Else
            Dim Img As Image = Button.BackgroundImage
            Dim Colors As List(Of Color) = ImageHelper.GetImageColors(Img)
            Img = ImageHelper.GetRecoloredImage(Img, Color.Gray)
            Button.BackgroundImage = Img
        End If
    End Sub

    Private Property Calculated As Boolean
        Get
            Return _Calculated
        End Get
        Set(value As Boolean)
            _Calculated = value
            If Calculated Then
                _TargetSize = New Size(1050, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            Else
                _TargetSize = New Size(433, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
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

    'Private Sub TmrResize_Tick(sender As Object, e As EventArgs) Handles TmrResize.Tick
    '    ' Define os incrementos em largura e altura
    '    Dim stepWidth As Integer = Math.Max(1, Math.Abs(_TargetSize.Width - Me.Width) / 5) ' Incrementa no mínimo 1 pixel
    '    Dim stepHeight As Integer = Math.Max(1, Math.Abs(_TargetSize.Height - Me.Height) / 5)

    '    ' Aumenta ou diminui a largura gradualmente
    '    If Me.Width < _TargetSize.Width Then
    '        Me.Width = Math.Min(Me.Width + stepWidth, _TargetSize.Width)
    '    ElseIf Me.Width > _TargetSize.Width Then
    '        Me.Width = Math.Max(Me.Width - stepWidth, _TargetSize.Width)
    '    End If

    '    ' Aumenta ou diminui a altura gradualmente
    '    If Me.Height < _TargetSize.Height Then
    '        Me.Height = Math.Min(Me.Height + stepHeight, _TargetSize.Height)
    '    ElseIf Me.Height > _TargetSize.Height Then
    '        Me.Height = Math.Max(Me.Height - stepHeight, _TargetSize.Height)
    '    End If

    '    ' Verifica se o formulário já alcançou o tamanho desejado
    '    If Me.Width = _TargetSize.Width AndAlso Me.Height = _TargetSize.Height Then
    '        TmrResize.Stop() ' Para o timer ao alcançar o tamanho final
    '    End If
    'End Sub


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
        InitializeComponent()
        _Evaluation = Evaluation
        _EvaluationsForm = EvaluationsForm
        _EvaluationsGrid = _EvaluationsForm.DgvData
        _Filter = CType(_EvaluationsForm.PgFilter.SelectedObject, EvaluationFilter)
        LoadForm()
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
        LoadForm()
        LoadData()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(DgvPartWorkedHour, True)
        ControlHelper.EnableControlDoubleBuffer(DgvPartElapsedDay, True)
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


        RefreshPhotoControls()

        AddHandler _UcCallTypeHasRepairNeedProposal.ValueChanged, AddressOf CallTypeHasRepairNeedProposalChanged
        AddHandler _UcUnitTemperaturePressure.ValueChanged, AddressOf UnitTemperaturePressureChanged

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



        DbxEvaluationDate.Text = _Evaluation.EvaluationDate
        TxtStartTime.Text = _Evaluation.StartTime.ToString("hh\:mm")
        TxtEndTime.Text = _Evaluation.EndTime.ToString("hh\:mm")
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
        'FillDataGridViewTechnician()
        DgvTechnician.Fill(_Evaluation.Technicians)
        If _Evaluation.EvaluationCreationType = EvaluationCreationType.Imported Or (_Evaluation.EvaluationCreationType = EvaluationCreationType.Manual And _Evaluation.ID > 0) Then
            For Each p As EvaluationPart In _Evaluation.PartsWorkedHour.ToArray.Reverse()
                If Not p.IsSaved Then
                    _Evaluation.PartsWorkedHour.Remove(p)
                End If
            Next p
            For Each p As EvaluationPart In _Evaluation.PartsElapsedDay.ToArray.Reverse()
                If Not p.IsSaved Then
                    _Evaluation.PartsElapsedDay.Remove(p)
                End If
            Next p
            '   DgvPartWorkedHour.Fill(_Evaluation.PartsWorkedHour)
            'FillDataGridViewPart(DgvPartWorkedHour, _Evaluation.PartsWorkedHour)
            If DgvPartWorkedHour.Rows.Count > 0 Then
                DgvPartWorkedHour.Rows(0).Selected = True
                DgvPartWorkedHour.FirstDisplayedScrollingRowIndex = 0
            End If
            '   DgvPartElapsedDay.Fill(_Evaluation.PartsElapsedDay)
            'FillDataGridViewPart(DgvPartElapsedDay, _Evaluation.PartsElapsedDay)
            If DgvPartElapsedDay.Rows.Count > 0 Then
                DgvPartElapsedDay.Rows(0).Selected = True
                DgvPartElapsedDay.FirstDisplayedScrollingRowIndex = 0
            End If
            Calculated = True
            BtnCalculate.Text = "Recalcular"
        Else
            Decalculate()
            BtnCalculate.Text = "Calcular"
        End If
        DgvPartWorkedHour.Fill(_Evaluation.PartsWorkedHour)
        DgvPartElapsedDay.Fill(_Evaluation.PartsElapsedDay)
        DgvlPartElapsedDayLayout.Load()
        DgvlPartWorkedHourLayout.Load()

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



        If _Evaluation.Photos.Count > 0 Then
            SelectedPhoto = _Evaluation.Photos(0)
        End If


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
    'Public Sub FillDataGridViewPart(Dgv As DataGridView, Parts As List(Of EvaluationPart))
    '    Dim View As DataView
    '    Dim FirstDisplayedRowIndex As Integer
    '    Dim SelectedRowIndex As Integer
    '    Dim CurrentCellIndex As Integer = -1
    '    If Dgv.SelectedRows.Count = 1 Then
    '        FirstDisplayedRowIndex = Dgv.FirstDisplayedScrollingRowIndex
    '        SelectedRowIndex = Dgv.SelectedRows(0).Index
    '        If Dgv.CurrentCell IsNot Nothing Then CurrentCellIndex = Dgv.CurrentCell.ColumnIndex
    '    End If
    '    Dgv.Fill(Parts)
    '    View = New DataView(Dgv.DataSource, Nothing, "Part Asc", DataViewRowState.CurrentRows)
    '    Dgv.DataSource = View
    '    If Dgv.SelectedRows.Count = 1 And Dgv.Rows.Count - 1 >= SelectedRowIndex Then
    '        Dgv.Rows(SelectedRowIndex).Selected = True
    '        Dgv.FirstDisplayedScrollingRowIndex = FirstDisplayedRowIndex
    '        If Dgv.CurrentCell IsNot Nothing AndAlso CurrentCellIndex >= 0 And Calculated Then
    '            Dgv.CurrentCell = Dgv.Rows(SelectedRowIndex).Cells(CurrentCellIndex)
    '        End If
    '    End If
    '    Dgv.Columns(0).Visible = False
    '    Dgv.Columns(1).Visible = False
    '    Dgv.Columns(2).Visible = False
    '    Dgv.Columns(3).HeaderText = "Código"
    '    Dgv.Columns(3).Width = 100
    '    Dgv.Columns(4).HeaderText = "Item"
    '    Dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    Dgv.Columns(5).HeaderText = "Cap. Atual"
    '    Dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    Dgv.Columns(5).Width = 105
    '    Dgv.Columns(6).HeaderText = "Vendido"
    '    Dgv.Columns(6).Width = 70
    '    Dgv.Columns(7).HeaderText = "Perdido"
    '    Dgv.Columns(7).Width = 70
    'End Sub
    'Public Sub FillDataGridViewTechnician()
    '    Dim View As DataView
    '    Dim FirstDisplayedRowIndex As Integer
    '    Dim SelectedRowIndex As Integer
    '    Dim CurrentCellIndex As Integer = -1
    '    If DgvTechnician.SelectedRows.Count = 1 Then
    '        FirstDisplayedRowIndex = DgvTechnician.FirstDisplayedScrollingRowIndex
    '        SelectedRowIndex = DgvTechnician.SelectedRows(0).Index
    '        If DgvTechnician.CurrentCell IsNot Nothing Then CurrentCellIndex = DgvTechnician.CurrentCell.ColumnIndex
    '    End If
    '    DgvTechnician.Fill(_Evaluation.Technicians)
    '    View = New DataView(DgvTechnician.DataSource, Nothing, "Technician Asc", DataViewRowState.CurrentRows)
    '    DgvTechnician.DataSource = View
    '    If DgvTechnician.SelectedRows.Count = 1 And DgvTechnician.Rows.Count - 1 >= SelectedRowIndex Then
    '        DgvTechnician.Rows(SelectedRowIndex).Selected = True
    '        DgvTechnician.FirstDisplayedScrollingRowIndex = FirstDisplayedRowIndex
    '        If DgvTechnician.CurrentCell IsNot Nothing AndAlso CurrentCellIndex >= 0 And Calculated Then
    '            DgvTechnician.CurrentCell = DgvTechnician.Rows(SelectedRowIndex).Cells(CurrentCellIndex)
    '        End If
    '    End If
    '    DgvTechnician.Columns.Cast(Of DataGridViewColumn).Where(Function(x) x.Name <> "Technician").ToList.ForEach(Sub(y) y.Visible = False)
    '    DgvTechnician.Columns("Technician").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    'End Sub
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
        Dim Frm As New FrmLog(Routine.Evaluation, _Evaluation.ID)
        Frm.ShowDialog()
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
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtTechnicalAdvice.TextChanged,
                                                                         TxtResponsible.TextChanged,
                                                                         TxtEvaluationNumber.TextChanged,
                                                                         TxtEndTime.TextChanged,
                                                                         TxtStartTime.TextChanged,
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
            If Calculated Then
                FormBorderStyle = FormBorderStyle.FixedSingle
                WindowState = FormWindowState.Normal
                MaximizeBox = False
                Size = New Size(1050, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            Else
                FormBorderStyle = FormBorderStyle.FixedSingle
                WindowState = FormWindowState.Normal
                MaximizeBox = False
                Size = New Size(433, 550 - If(_EvaluationsForm IsNot Nothing, 0, TsNavigation.Height))
            End If
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
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
        ElseIf Not Calculated Then
            EprValidation.SetError(BtnCalculate, "A avaliação precisa ser calculada.")
            EprValidation.SetIconAlignment(BtnCalculate, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(BtnCalculate, -125)
            TcEvaluation.SelectedTab = TabMain
            BtnCalculate.Select()
            Return False
        ElseIf _Evaluation.PartsWorkedHour.Count + _Evaluation.PartsElapsedDay.Count = 0 Then
            EprValidation.SetError(GbxPartWorkedHour, "A avaliação precisa ter pelo menos um item.")
            EprValidation.SetIconAlignment(GbxPartWorkedHour, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxPartWorkedHour, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvPartWorkedHour.Select()
            Return False
            'ElseIf Not PdfDocumentViewer.IsDocumentLoaded Then
            '    EprValidation.SetError(TsDocument, "Anexar um documento é obrigatório.")
            '    EprValidation.SetIconAlignment(TsDocument, ErrorIconAlignment.MiddleLeft)
            '    EprValidation.SetIconPadding(TsDocument, -180)
            '    TcEvaluation.SelectedTab = TabDocument
            '    BtnAttachPDF.Select()
            '    Return False
        ElseIf _Evaluation.PartsWorkedHour.Any(Function(x) x.CurrentCapacity > x.Part.Capacity) Then
            EprValidation.SetError(GbxPartWorkedHour, "Existe um ou mais itens com a capacidade atual superior a capacidade total.")
            EprValidation.SetIconAlignment(GbxPartWorkedHour, ErrorIconAlignment.TopRight)
            EprValidation.SetIconPadding(GbxPartWorkedHour, -15)
            TcEvaluation.SelectedTab = TabMain
            DgvPartWorkedHour.Select()
            Return False
        ElseIf _Evaluation.PartsElapsedDay.Any(Function(x) x.CurrentCapacity > x.Part.Capacity) Then
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
        'Dim DocumentPath As String = String.Empty
        Dim Success As Boolean
        ' Dim CurrentDocument As String = _Evaluation.Document.CurrentFile
        'Dim OriginalDocument As String = _Evaluation.Document.OriginalFile
        QbxCustomer.Text = QbxCustomer.Text.Trim.ToUnaccented()
        TxtResponsible.Text = TxtResponsible.Text.Trim.ToUnaccented()
        QbxCompressor.Text = QbxCompressor.Text.Trim.ToUnaccented()
        TxtTechnicalAdvice.Text = TxtTechnicalAdvice.Text.ToUpper.ToUnaccented()
        If _Evaluation.LockInfo.IsLocked And _Evaluation.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Evaluation.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Success = False
        ElseIf _Evaluation.Status = EvaluationStatus.Approved AndAlso Not _User.CanAccess(Routine.EvaluationApproveOrReject) Then
            CMessageBox.Show("Essa avaliação não pode ser alterada pois já foi aprovada.", CMessageBoxType.Information)
            Success = False
        Else
            If IsValidFieldsToSave() Then
                Try
                    Cursor = Cursors.WaitCursor

                    _Evaluation.CallType = _UcCallTypeHasRepairNeedProposal.CallType
                    _Evaluation.HasRepair = _UcCallTypeHasRepairNeedProposal.HasRepair
                    _Evaluation.NeedProposal = _UcCallTypeHasRepairNeedProposal.NeedProposal

                    _Evaluation.EvaluationDate = DbxEvaluationDate.Text
                    _Evaluation.StartTime = TimeSpan.Parse(TxtStartTime.Text.Insert(2, ":"))
                    _Evaluation.EndTime = TimeSpan.Parse(TxtEndTime.Text.Insert(2, ":"))
                    _Evaluation.EvaluationNumber = TxtEvaluationNumber.Text
                    _Evaluation.Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
                    _Evaluation.Responsible = TxtResponsible.Text
                    _Evaluation.Horimeter = DbxHorimeter.DecimalValue
                    _Evaluation.ManualAverageWorkLoad = CbxManualAverageWorkLoad.Checked
                    _Evaluation.AverageWorkLoad = DbxAverageWorkLoad.Text
                    _Evaluation.TechnicalAdvice = TxtTechnicalAdvice.Text

                    'For Each Photo In _Evaluation.Photos.Reverse
                    '    If Photo.Photo.CurrentFile Is Nothing Then _Evaluation.Photos.Remove(Photo)
                    'Next Photo

                    If _Evaluation.ID = 0 AndAlso _User.CanAccess(Routine.EvaluationApproveOrReject) Then
                        _Evaluation.SaveChanges()
                        BtnApprove.PerformClick()
                    Else
                        _Evaluation.SaveChanges()
                    End If
                    _Evaluation.Lock()
                    LblIDValue.Text = _Evaluation.ID
                    'FillDataGridViewTechnician()
                    DgvTechnician.Fill(_Evaluation.Technicians)
                    DgvPartWorkedHour.Fill(_Evaluation.PartsWorkedHour)
                    DgvPartElapsedDay.Fill(_Evaluation.PartsElapsedDay)
                    DgvlPartElapsedDayLayout.Load()
                    DgvlPartWorkedHourLayout.Load()
                    'FillDataGridViewPart(DgvPartWorkedHour, _Evaluation.PartsWorkedHour)
                    'FillDataGridViewPart(DgvPartElapsedDay, _Evaluation.PartsElapsedDay)
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
                    'If Not String.IsNullOrEmpty(DocumentPath) AndAlso File.Exists(DocumentPath) Then
                    '    File.Delete(DocumentPath)
                    'End If
                    CMessageBox.Show("ERRO EV020", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Success = False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Success = False
            End If
        End If

        'If Not Success Then
        '    If Not File.Exists(_Evaluation.Document.OriginalFile) Then
        '        _Evaluation.Document.SetCurrentFile(OriginalDocument, True)
        '        _Evaluation.Document.SetCurrentFile(CurrentDocument)
        '    End If
        'End If

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
        BtnViewCustomer.Visible = QbxCustomer.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNewCustomer.Visible = _User.CanWrite(Routine.Person)
        BtnFilterCustomer.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxCustomer_Leave(sender As Object, e As EventArgs) Handles QbxCustomer.Leave
        TmrCustomer.Stop()
        TmrCustomer.Start()
    End Sub
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
    Private Sub BtnNewCustomer_Click(sender As Object, e As EventArgs) Handles BtnNewCustomer.Click
        Dim Customer As Person
        Dim Form As FrmPerson
        Customer = New Person With {
            .IsCustomer = True,
            .ControlMaintenance = True
        }
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
        FilterForm = New FrmFilter(New PersonCustomerQueriedBoxFilter("Sim"), QbxCustomer) With {
            .Text = "Filtro de Clientes"
        }
        FilterForm.ShowDialog()
        QbxCustomer.Select()
    End Sub
    Private Sub BtnZoomOut_Click(sender As Object, e As EventArgs) Handles BtnZoomOut.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage - 10)
    End Sub
    Private Sub BtnZoomIn_Click(sender As Object, e As EventArgs) Handles BtnZoomIn.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage + 10)
    End Sub
    Private Sub BtnIncludePhoto_Click(sender As Object, e As EventArgs) Handles BtnIncludePhoto.Click
        Dim Filename As String
        Dim Photo As EvaluationPhoto
        Using Ofd As New OpenFileDialog()
            Ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*"
            Ofd.Title = "Selecionar Imagem"
            If Ofd.ShowDialog() = DialogResult.OK Then
                Filename = Util.GetFilename(Path.GetExtension(Ofd.FileName))
                File.Copy(Ofd.FileName, Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
                Photo = New EvaluationPhoto()
                Photo.Photo.SetCurrentFile(Path.Combine(ApplicationPaths.ManagerTempDirectory, Filename))
                _Evaluation.Photos.Add(Photo)
                SelectedPhoto = Photo
                EprValidation.Clear()
                BtnSave.Enabled = True
            End If
        End Using
        RefreshPhotoControls()
    End Sub
    Private Sub BtnAttachPDF_Click(sender As Object, e As EventArgs) Handles BtnAttachPDF.Click
        Dim Filename As String
        If OfdDocument.ShowDialog = DialogResult.OK Then
            Filename = Util.GetFilename(Path.GetExtension(OfdDocument.FileName))
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
    Private Sub PdfDocumentViewer_CurrentPageChanged(sender As Object, args As EventArgs) Handles PdfDocumentViewer.CurrentPageChanged
        LblDocumentPage.Text = "Página " & PdfDocumentViewer.CurrentPageIndex & " de " & PdfDocumentViewer.PageCount
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
            CMessageBox.Show("Essa avaliação não pode ser aprovada, pois ainda não foi salva.")
        End If
    End Sub
    Private Sub BtnReject_Click(sender As Object, e As EventArgs) Handles BtnReject.Click
        Dim Row As DataGridViewRow
        If _Evaluation.ID > 0 Then
            Using FormReject As New FrmEvaluationRejectReason
                If FormReject.ShowDialog = DialogResult.OK Then
                    Try
                        Cursor = Cursors.WaitCursor
                        _Evaluation.SetStatus(EvaluationStatus.Rejected, FormReject.TxtReason.Text)
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
    Private Sub FrmEvaluation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Evaluation.Unlock()
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
                For Each CurrentPart As EvaluationPart In _Evaluation.PartsWorkedHour.ToArray.Reverse
                    If CurrentPart.Part.Status = SimpleStatus.Inactive Then
                        _Evaluation.PartsWorkedHour.Remove(CurrentPart)
                    End If
                Next CurrentPart
                For Each CurrentPart As EvaluationPart In _Evaluation.PartsElapsedDay.ToArray.Reverse
                    If CurrentPart.Part.Status = SimpleStatus.Inactive Then
                        _Evaluation.PartsElapsedDay.Remove(CurrentPart)
                    End If
                Next CurrentPart
                If DbxHorimeter.DecimalValue < PreviousEvaluation.Horimeter Then
                    CMessageBox.Show("O horímetro digitado é menor do que o horímetro da última avalição desse compressor, só mantenha esse valor caso a unidade tenha sido reconstruída. A capacidade atual dos itens será a mesma da última avaliação.", CMessageBoxType.Warning)
                    Cursor = Cursors.WaitCursor
                    For Each CurrentPart As EvaluationPart In _Evaluation.PartsWorkedHour
                        CurrentPart.Sold = False
                        CurrentPart.Lost = False
                        PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                        If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                            CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                        Else
                            CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                        End If
                    Next CurrentPart
                    For Each CurrentPart As EvaluationPart In _Evaluation.PartsElapsedDay
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
                    For Each CurrentPart As EvaluationPart In _Evaluation.PartsWorkedHour
                        CurrentPart.Sold = False
                        CurrentPart.Lost = False
                        PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                        If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                            CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (DbxHorimeter.DecimalValue - PreviousEvaluation.Horimeter)
                        Else
                            CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                        End If
                    Next CurrentPart
                    For Each CurrentPart As EvaluationPart In _Evaluation.PartsElapsedDay
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
                DgvPartWorkedHour.Fill(_Evaluation.PartsWorkedHour)
                DgvPartElapsedDay.Fill(_Evaluation.PartsElapsedDay)
                DgvlPartElapsedDayLayout.Load()
                DgvlPartWorkedHourLayout.Load()
                'FillDataGridViewPart(DgvPartWorkedHour, _Evaluation.PartsWorkedHour)
                'FillDataGridViewPart(DgvPartElapsedDay, _Evaluation.PartsElapsedDay)
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
        Dim RowIndex As Long
        If PartType = CompressorPartType.ElapsedDay Then
            Part = _Evaluation.PartsElapsedDay.Single(Function(x) x.Part.ID = DgvPartElapsedDay.SelectedRows(0).Cells("Part").Value.ID)
            RowIndex = DgvPartElapsedDay.SelectedRows(0).Index
            Using Frm As New FrmEvaluationPart(Part)
                Result = Frm.ShowDialog()
                'FillDataGridViewPart(DgvPartElapsedDay, _Evaluation.PartsElapsedDay)
                DgvPartElapsedDay.Fill(_Evaluation.PartsElapsedDay)
                DgvlPartElapsedDayLayout.Load()
                DgvPartElapsedDayNavigator.EnsureVisibleRow(RowIndex)

            End Using
        Else
            Part = _Evaluation.PartsWorkedHour.Single(Function(x) x.Part.ID = DgvPartWorkedHour.SelectedRows(0).Cells("Part").Value.ID)
            RowIndex = DgvPartWorkedHour.SelectedRows(0).Index
            Using Frm As New FrmEvaluationPart(Part)
                Result = Frm.ShowDialog()
                DgvPartWorkedHour.Fill(_Evaluation.PartsWorkedHour)
                DgvlPartWorkedHourLayout.Load()
                'FillDataGridViewPart(DgvPartWorkedHour, _Evaluation.PartsWorkedHour)
                DgvPartWorkedHourNavigator.EnsureVisibleRow(RowIndex)
            End Using
        End If
        If _Evaluation.PartsWorkedHour.Any(Function(x) x.Sold) Or _Evaluation.PartsElapsedDay.Any(Function(x) x.Sold) Then
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
    Private Sub Decalculate()
        Calculated = False
        DgvPartWorkedHour.DataSource = Nothing
        DgvPartElapsedDay.DataSource = Nothing
    End Sub
    Private Sub BtnIncludetechnician_Click(sender As Object, e As EventArgs) Handles BtnIncludeTechnician.Click
        Dim Form As New FrmEvaluationTechnician(_Evaluation, New EvaluationTechnician(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditTechnician_Click(sender As Object, e As EventArgs) Handles BtnEditTechnician.Click
        Dim Form As FrmEvaluationTechnician
        Dim Technician As EvaluationTechnician
        If DgvTechnician.SelectedRows.Count = 1 Then
            Technician = _Evaluation.Technicians.Single(Function(x) x.Guid = DgvTechnician.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmEvaluationTechnician(_Evaluation, Technician, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteTechnician_Click(sender As Object, e As EventArgs) Handles BtnDeleteTechnician.Click
        Dim Technician As EvaluationTechnician
        If DgvTechnician.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Technician = _Evaluation.Technicians.Single(Function(x) x.Guid = DgvTechnician.SelectedRows(0).Cells("Guid").Value)
                _Evaluation.Technicians.Remove(Technician)
                'FillDataGridViewTechnician()
                DgvTechnician.Fill(_Evaluation.Technicians)
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

    Private Sub FrmEvaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvlTechnicianLayout.Load()
        DgvlPartElapsedDayLayout.Load()
        DgvlPartWorkedHourLayout.Load()
    End Sub



    Private Sub BtnIncludeReplacedItem_Click(sender As Object, e As EventArgs) Handles BtnIncludeItem.Click
        Dim Form As New FrmEvaluationReplacedItem(_Evaluation, New EvaluationReplacedItem(), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditReplacedItem_Click(sender As Object, e As EventArgs) Handles BtnEditItem.Click
        Dim Form As FrmEvaluationReplacedItem
        Dim Item As EvaluationReplacedItem
        If DgvReplacedItems.SelectedRows.Count = 1 Then
            Item = _Evaluation.ReplacedItems.Single(Function(x) x.Guid = DgvReplacedItems.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmEvaluationReplacedItem(_Evaluation, Item, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteReplacedItem_Click(sender As Object, e As EventArgs) Handles BtnDeleteItem.Click
        Dim Item As EvaluationReplacedItem
        If DgvReplacedItems.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Item = _Evaluation.ReplacedItems.Single(Function(x) x.Guid = DgvReplacedItems.SelectedRows(0).Cells("Guid").Value)
                _Evaluation.ReplacedItems.Remove(Item)
                DgvReplacedItems.Fill(_Evaluation.ReplacedItems)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class