Imports ManagerCore
Imports ControlLibrary
Imports System.IO

'TODO: Ao importar, o formulario da avaliação ja deve vir calulado, porem depois de calvular deve-se alterar as capacityes das parts
'TODO: Utilizar Enum nos status da sincronizacao: Não Sincronizado e Sincronizando
Public Class FrmEvaluationImport
    Private _EvaluationData As Dictionary(Of String, Object) = Nothing
    Private _EvaluationsForm As Form

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(EvaluationsForm As Form)
        InitializeComponent()
        _EvaluationsForm = EvaluationsForm
    End Sub

    Private Sub FrmEvaluationImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Utility.EnableDataGridViewDoubleBuffer(DgvEvaluations, True)
        RefreshEvaluations()
        SyncTimer.Stop()
    End Sub


    Private Sub RefreshEvaluations()
        Dim Firestore = Locator.GetInstance(Of RemoteDB)("Customer")

        Dim Condition As New List(Of FirestoreService.Condition) From {
            New FirestoreService.WhereEqualToCondition("info.is_sync", False)
        }

        'TODO: Necessario passar o listeneter da implementacao para o contrato RemoteDB

        'Firestore.StartListening("evaluations", Condition)
        'AddHandler Firestore.OnFirestoreChanged, Async Sub(Args)
        '                                             DgvEvaluations.Invoke(Sub() FillDgv(Args.Documents))
        '                                             Await RefreshSync()
        '                                         End Sub

    End Sub





    Private Sub FillDgv(Docs As List(Of Dictionary(Of String, Object)))
        ' Defina as colunas do DataGridView se ainda não estiverem definidas
        If DgvEvaluations.Columns.Count = 0 Then
            DgvEvaluations.Columns.Add("CloudID", "CloudID")
            DgvEvaluations.Columns.Add("Status", "Status")
            DgvEvaluations.Columns.Add("Data", "Data")
            DgvEvaluations.Columns.Add("Cliente", "Cliente")
            DgvEvaluations.Columns.Add("Compressor", "Compressor")
            DgvEvaluations.Columns.Add("Técnico", "Técnico")
        End If

        ' Limpar as linhas existentes
        DgvEvaluations.Rows.Clear()

        ' Adicione os dados ao DataGridView
        If Docs IsNot Nothing AndAlso Docs.Count > 0 Then
            For Each doc In Docs
                Dim CloudID As String = doc("id")
                Dim Status As String = If(String.IsNullOrEmpty(doc("info")("syncing_by")), "Não Sincronizado", "Sincronizando")
                Dim CustomerName As String = doc("customer")("customername")
                Dim CompressorName As String = $"{doc("compressor")("compressorname")}"
                Dim SerialNumber As String = If(String.IsNullOrEmpty(doc("compressor")("serialnumber")), String.Empty, $"NS: {doc("compressor")("serialnumber")}")
                Dim EvaluationDate As String = CDate(doc("date")).ToString("dd/MM/yyyy")
                Dim TechniciansList As List(Of Dictionary(Of String, Object)) = DirectCast(DirectCast(doc("technicians"), IEnumerable(Of Object)).Select(Function(Item) DirectCast(Item, Dictionary(Of String, Object))).ToList(), List(Of Dictionary(Of String, Object)))
                Dim Technicians As List(Of String) = TechniciansList.Select(Function(tech) If(tech.ContainsKey("personname"), tech("personname").ToString(), String.Empty)).ToList()
                Dim row As New DataGridViewRow()


                If IsDate(doc("info")("sync_date")) AndAlso Now < CDate(doc("info")("sync_date")).AddMinutes(10) Then
                    Status = "Sincronizando"
                Else
                    Status = "Não Sincronizado"
                End If


                row.CreateCells(DgvEvaluations)
                row.Cells(0).Value = CloudID
                row.Cells(1).Value = Status
                row.Cells(2).Value = EvaluationDate
                row.Cells(3).Value = CustomerName
                row.Cells(4).Value = $"{CompressorName}  {SerialNumber}"
                row.Cells(5).Value = String.Join(", ", Technicians)
                row.Tag = doc
                DgvEvaluations.Rows.Add(row)
            Next
        End If


        DgvEvaluations.Columns(0).Visible = False
        DgvEvaluations.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvEvaluations.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub






    Private Async Sub DgvEvaluations_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvEvaluations.CellMouseDoubleClick
        _EvaluationData = DgvEvaluations.Rows(e.RowIndex).Tag

        If DgvEvaluations.Rows(e.RowIndex).Cells("Status").Value = "Sincronizando" Then
            MsgBox($"Essa avaliação esta sendo sincronizada por {_EvaluationData("info")("syncing_by")}")
            Exit Sub
        End If



        _EvaluationData("info")("sync_date") = Now.ToString("yyyy-MM-dd HH:mm:ss")
        _EvaluationData("info")("syncing_by") = "Leandro"

        Dim Firestore = Locator.GetInstance(Of RemoteDB)("Customer")
        Await Firestore.ExecutePut("evaluations", _EvaluationData, "1")
        SyncTimer.Start()

        Dim Evaluation As Evaluation = EvaluationFromDictionary(_EvaluationData)

        Dim Form As FrmEvaluation

        If _EvaluationsForm IsNot Nothing Then
            Form = New FrmEvaluation(Evaluation, _EvaluationsForm)
        Else
            Form = New FrmEvaluation(Evaluation)
        End If

        Form.ShowDialog()

        If Form.Evaluation.ID = 0 Then
            _EvaluationData("info")("sync_date") = String.Empty
            _EvaluationData("info")("syncing_by") = String.Empty
            Await Firestore.ExecutePut("evaluations", _EvaluationData, "1")
        Else
            _EvaluationData("info")("sync_date") = String.Empty
            _EvaluationData("info")("syncing_by") = String.Empty
            _EvaluationData("info")("is_sync") = True
            _EvaluationData("info")("returnedid") = Form.Evaluation.ID
            Await Firestore.ExecutePut("evaluations", _EvaluationData, "1")
        End If



        _EvaluationData = Nothing
        SyncTimer.Stop()
    End Sub


    Public Function EvaluationFromDictionary(Data As Dictionary(Of String, Object)) As Evaluation
        Dim Evaluation As New Evaluation
        Dim EvaluationTechnician As EvaluationTechnician
        Dim Coalescent As EvaluationPart
        Evaluation.TechnicalAdvice = Data("advice")
        Evaluation.AverageWorkLoad = Data("awl")
        Evaluation.Customer = New Person().Load(Data("customer")("personid"), False)
        Evaluation.Compressor = Evaluation.Customer.Compressors.SingleOrDefault(Function(x) x.ID = Data("compressor")("compressorid"))
        Evaluation.EvaluationDate = Data("date")
        Evaluation.EndTime = TimeSpan.ParseExact(Data("endtime"), "hh\:mm", Nothing)
        Evaluation.Horimeter = Data("horimeter")
        Dim AirFilters As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.AirFilter).ToList
        Dim OilFilters As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.OilFilter).ToList
        Dim Separators As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.Separator).ToList
        Dim Oils As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.Oil).ToList
        AirFilters.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("airfilter"))
        OilFilters.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("oilfilter"))
        Separators.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("separator"))
        Oils.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("oil"))
        For Each CoalescentData In Data("parts")("coalescents")
            Coalescent = Evaluation.PartsElapsedDay.Where(Function(y) y.Part.PartBinded).FirstOrDefault(Function(x) x.Part.ID = CoalescentData("coalescentid"))
            If Coalescent IsNot Nothing Then Coalescent.CurrentCapacity = DateDiff(DateInterval.Day, Today, CDate(CoalescentData("nextchange")))
        Next CoalescentData
        Evaluation.Responsible = Data("responsible")
        Evaluation.StartTime = TimeSpan.ParseExact(Data("starttime"), "hh\:mm", Nothing)
        For Each TechnicianData In Data("technicians")
            EvaluationTechnician = New EvaluationTechnician With {
                .Technician = New Person().Load(TechnicianData("personid"), False),
                .IsSaved = True
            }
            Evaluation.Technicians.Add(EvaluationTechnician)
        Next TechnicianData
        'TODO: falta assinatura
        Return Evaluation
    End Function

    Private Async Sub SyncTimer_Tick(sender As Object, e As EventArgs) Handles SyncTimer.Tick
        If _EvaluationData IsNot Nothing AndAlso _EvaluationData.Count > 0 Then
            If IsDate(_EvaluationData("info")("sync_date")) AndAlso Now > CDate(_EvaluationData("info")("sync_date")).AddMinutes(10) Then
                _EvaluationData("info")("sync_date") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                Dim Firestore = Locator.GetInstance(Of RemoteDB)("Customer")
                Await Firestore.ExecutePut("evaluations", _EvaluationData, "1")
            End If
        End If
    End Sub

    Private Async Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        RefreshTimer.Stop()
        Await RefreshSync()
        RefreshTimer.Start()
    End Sub


    Private Async Function RefreshSync() As Task

        For Each Row As DataGridViewRow In DgvEvaluations.Rows
            If Row.Cells("Status").Value = "Sincronizando" Then
                Dim Data As Dictionary(Of String, Object) = DirectCast(Row.Tag, Dictionary(Of String, Object))
                If IsDate(Data("info")("sync_date")) AndAlso Now > CDate(Data("info")("sync_date")).AddMinutes(10.5) Then
                    Data("info")("sync_date") = String.Empty
                    Data("info")("syncing_by") = String.Empty
                    Dim Firestore = Locator.GetInstance(Of RemoteDB)("Customer")
                    Await Firestore.ExecutePut("evaluations", Data, "1")
                End If
            End If
        Next Row
    End Function

End Class

