Imports ManagerCore
Imports ControlLibrary
Imports System.IO
Imports ControlLibrary.Utility

Public Class FrmEvaluationImport
    Private _EvaluationData As Dictionary(Of String, Object) = Nothing
    Private _EvaluationsForm As Form
    Private _RemoteDB As RemoteDB
    Private _Storage As Storage
    Private _Session As Session

    Public Sub New()
        InitializeComponent()
        _Session = Locator.GetInstance(Of Session)
        _Storage = Locator.GetInstance(Of Storage)
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        Dim Condition As New List(Of RemoteDB.Condition) From {
            New RemoteDB.WhereEqualToCondition("info.is_sync", False)
        }

        _RemoteDB.StartListening("evaluations", Condition)
        AddHandler _RemoteDB.OnFirestoreChanged, Async Sub(Args)
                                                     If DgvEvaluations.Created Then
                                                         DgvEvaluations.Invoke(Sub() FillDgv(Args.Documents))
                                                         Await RefreshSync()
                                                     End If
                                                 End Sub
    End Sub

    Public Sub New(EvaluationsForm As Form)
        InitializeComponent()
        _EvaluationsForm = EvaluationsForm
    End Sub

    Private Sub FrmEvaluationImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Utility.EnableDataGridViewDoubleBuffer(DgvEvaluations, True)
        SyncTimer.Stop()
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
                Dim Status As String = If(String.IsNullOrEmpty(doc("info")("syncing_by")), GetEnumDescription(CloudSyncStatus.UnSynchronized), "Sincronizando")
                Dim CustomerName As String = doc("customer")("customer_name")
                Dim CompressorName As String = $"{doc("compressor")("compressor_name")}"
                Dim SerialNumber As String = If(String.IsNullOrEmpty(doc("compressor")("serial_number")), String.Empty, $"NS: {doc("compressor")("serial_number")}")
                Dim EvaluationDate As String = CDate(doc("date")).ToString("dd/MM/yyyy")
                Dim TechniciansList As List(Of Dictionary(Of String, Object)) = DirectCast(DirectCast(doc("technicians"), IEnumerable(Of Object)).Select(Function(Item) DirectCast(Item, Dictionary(Of String, Object))).ToList(), List(Of Dictionary(Of String, Object)))
                Dim Technicians As List(Of String) = TechniciansList.Select(Function(tech) If(tech.ContainsKey("person_name"), tech("person_name").ToString(), String.Empty)).ToList()
                Dim row As New DataGridViewRow()


                If IsDate(doc("info")("sync_date")) AndAlso Now < CDate(doc("info")("sync_date")).AddMinutes(10) Then
                    Status = GetEnumDescription(CloudSyncStatus.Synchronizing)
                Else
                    Status = GetEnumDescription(CloudSyncStatus.UnSynchronized)
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


    Private Function GetCMT(Evaluation As Evaluation) As Decimal
        Dim Value As Decimal
        Value = 5.71
        If Evaluation.Horimeter >= 0 Then
            If Evaluation.HasPreviousEvaluation(Evaluation.Compressor, Evaluation.EvaluationDate, Evaluation.ID) Then
                If Evaluation.GetPreviousEvaluationDate(Evaluation.Compressor, Evaluation.EvaluationDate, Evaluation.ID) <= Evaluation.EvaluationDate Then
                    Value = Evaluation.GetAverageWorkLoad(Evaluation.Compressor, Evaluation.Horimeter, Evaluation.EvaluationDate, Evaluation.ID)
                    If Value = 0 Then Value = 0.01
                    If Value < 0 Then Value = 5.71
                    If Value > 24 And Value < 25 Then Value = 24
                End If
            End If
        End If
        Return Value
    End Function



    Private Async Sub DgvEvaluations_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvEvaluations.CellMouseDoubleClick
        Cursor = Cursors.WaitCursor
        Dim TempPath As String
        Dim TempSignature As String
        Dim TempPhotos As New List(Of String)
        Dim PreviousEvaluationID As Long
        Dim PreviousEvaluation As Evaluation





        _EvaluationData = DgvEvaluations.Rows(e.RowIndex).Tag

        If DgvEvaluations.Rows(e.RowIndex).Cells("Status").Value = GetEnumDescription(CloudSyncStatus.Synchronizing) Then
            CMessageBox.Show($"Essa avaliação esta sendo sincronizada por {_EvaluationData("info")("syncing_by")}", CMessageBoxType.Information)
            Cursor = Cursors.Default

            Exit Sub
        End If

        Dim LoaderForm As New FrmLoader("Sincronizando com a nuvem")
        Dim AsyncLoader As New AsyncLoader(LoaderForm, 20, True, 1000, Color.White)
        LoaderForm.Cursor = Cursors.WaitCursor
        Await AsyncLoader.Show()




        _EvaluationData("info")("sync_date") = Now.ToString("yyyy-MM-dd HH:mm:ss")
        _EvaluationData("info")("syncing_by") = _Session.User.Username


        Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
        SyncTimer.Start()



        Dim SignatureData As Byte() = Await _Storage.DownloadFile(_EvaluationData("signature_url"))

        TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Util.GetFilename(".png"))

        Using SignatureStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
            Await SignatureStream.WriteAsync(SignatureData, 0, SignatureData.Length)
        End Using

        TempSignature = TempPath





        For Each Photo As String In _EvaluationData("photo_urls")
            Dim PhotoData As Byte() = Await _Storage.DownloadFile(Photo)
            TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Util.GetFilename(".jpg"))

            Using PhotoStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                Await PhotoStream.WriteAsync(PhotoData, 0, PhotoData.Length)
            End Using

            TempPhotos.Add(TempPath)

        Next Photo



        Dim Evaluation As Evaluation = Evaluation.FromCloud(_EvaluationData, TempSignature, TempPhotos)


        PreviousEvaluationID = Evaluation.GetPreviousEvaluationID(Evaluation.Compressor, CDate(Evaluation.EvaluationDate), Evaluation.ID)
        PreviousEvaluation = New Evaluation().Load(PreviousEvaluationID, False)



        Dim PreviousPart As EvaluationPart
        If Evaluation.Horimeter < PreviousEvaluation.Horimeter Then
            CMessageBox.Show("O horímetro informado é menor do que o horímetro da última avalição desse compressor, só mantenha esse valor caso a unidade tenha sido reconstruída. A capacidade atual dos itens será a mesma da última avaliação.", CMessageBoxType.Warning)
            Cursor = Cursors.WaitCursor
            For Each CurrentPart As EvaluationPart In Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBinded = False)
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                End If
            Next CurrentPart
            For Each CurrentPart As EvaluationPart In Evaluation.PartsElapsedDay.Where(Function(x) x.Part.PartBinded = False)
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsElapsedDay.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                End If
            Next CurrentPart
            If Not Evaluation.ManualAverageWorkLoad Then Evaluation.AverageWorkLoad = PreviousEvaluation.AverageWorkLoad
        Else
            For Each CurrentPart As EvaluationPart In Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBinded = False)
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (Evaluation.Horimeter - PreviousEvaluation.Horimeter)
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                End If
            Next CurrentPart
            For Each CurrentPart As EvaluationPart In Evaluation.PartsElapsedDay.Where(Function(x) x.Part.PartBinded = False)
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsElapsedDay.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (Evaluation.EvaluationDate).Subtract(PreviousEvaluation.EvaluationDate).Days
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                End If
            Next CurrentPart
            If Not Evaluation.ManualAverageWorkLoad Then Evaluation.AverageWorkLoad = GetCMT(Evaluation)
        End If








        preciso emular a soltura do botao do mouse da barra do loader se ele tiver clicado









        Dim Form As FrmEvaluation

        If _EvaluationsForm IsNot Nothing Then
            Form = New FrmEvaluation(Evaluation, _EvaluationsForm)
        Else
            Form = New FrmEvaluation(Evaluation)
        End If

        Form.BtnSave.Enabled = True

        Await AsyncLoader.Close()


        Form.ShowDialog()



        If Evaluation.ID = 0 Then
            _EvaluationData("info")("sync_date") = String.Empty
            _EvaluationData("info")("syncing_by") = String.Empty
            Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
        Else
            _EvaluationData("info")("sync_date") = String.Empty
            _EvaluationData("info")("syncing_by") = String.Empty
            _EvaluationData("info")("is_sync") = True
            _EvaluationData("info")("returnedid") = Evaluation.ID
            Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
        End If



        _EvaluationData = Nothing
        SyncTimer.Stop()
        Cursor = Cursors.Default

    End Sub




    Private Async Sub SyncTimer_Tick(sender As Object, e As EventArgs) Handles SyncTimer.Tick
        If _EvaluationData IsNot Nothing AndAlso _EvaluationData.Count > 0 Then
            If IsDate(_EvaluationData("info")("sync_date")) AndAlso Now > CDate(_EvaluationData("info")("sync_date")).AddMinutes(1) Then
                _EvaluationData("info")("sync_date") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
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
            If Row.Cells("Status").Value = GetEnumDescription(CloudSyncStatus.Synchronizing) Then
                Dim Data As Dictionary(Of String, Object) = DirectCast(Row.Tag, Dictionary(Of String, Object))
                If IsDate(Data("info")("sync_date")) AndAlso Now > CDate(Data("info")("sync_date")).AddMinutes(1.5) Then
                    Data("info")("sync_date") = String.Empty
                    Data("info")("syncing_by") = String.Empty
                    Await _RemoteDB.ExecutePut("evaluations", Data, Data("id"))
                End If
            End If
        Next Row
    End Function


End Class

