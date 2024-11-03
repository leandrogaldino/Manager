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
        InitializeDbListener()
    End Sub

    Public Sub New(EvaluationsForm As Form)
        InitializeComponent()
        _EvaluationsForm = EvaluationsForm
        InitializeDbListener()
    End Sub

    Private Sub InitializeDbListener()
        _Session = Locator.GetInstance(Of Session)
        _Storage = Locator.GetInstance(Of Storage)
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        Dim Condition As New List(Of RemoteDB.Condition) From {
            New RemoteDB.WhereEqualToCondition("info.imported", False)
        }
        _RemoteDB.StartListening("evaluations", Condition)
        AddHandler _RemoteDB.OnFirestoreChanged, Async Sub(Args)
                                                     If DgvEvaluations.Created Then
                                                         DgvEvaluations.Invoke(Sub() FillDgv(Args.Documents))
                                                         Await RefreshSync()
                                                     End If
                                                 End Sub
    End Sub


    Private Sub FrmEvaluationImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        EnableControlDoubleBuffer(DgvEvaluations, True)
        SyncTimer.Stop()
        If Not IsInternetAvailable() Then
            CMessageBox.Show("Não foi possível estabelecer uma conexão com a internet. Verifique sua conexão para realizar importações.", CMessageBoxType.Warning)
            DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub FillDgv(Docs As List(Of Dictionary(Of String, Object)))
        ' Defina as colunas do DataGridView se ainda não estiverem definidas
        If DgvEvaluations.Columns.Count = 0 Then
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

                Dim Status As String = If(String.IsNullOrEmpty(doc("info")("importing_by")), GetEnumDescription(CloudSyncStatus.NotImported), GetEnumDescription(CloudSyncStatus.Importing))
                Dim CustomerName As String = doc("customer")("customer_name")
                Dim CompressorName As String = $"{doc("compressor")("compressor_name")}"
                Dim SerialNumber As String = If(String.IsNullOrEmpty(doc("compressor")("serial_number")), String.Empty, $"NS: {doc("compressor")("serial_number")}")
                Dim EvaluationDate As String = CDate(doc("date")).ToString("dd/MM/yyyy")
                Dim TechniciansList As List(Of Dictionary(Of String, Object)) = DirectCast(DirectCast(doc("technicians"), IEnumerable(Of Object)).Select(Function(Item) DirectCast(Item, Dictionary(Of String, Object))).ToList(), List(Of Dictionary(Of String, Object)))
                Dim Technicians As List(Of String) = TechniciansList.Select(Function(tech) If(tech.ContainsKey("person_name"), tech("person_name").ToString(), String.Empty)).ToList()
                Dim row As New DataGridViewRow()


                If IsDate(doc("info")("importing_date")) AndAlso Now < CDate(doc("info")("importing_date")).AddMinutes(10) Then
                    Status = GetEnumDescription(CloudSyncStatus.Importing)
                Else
                    Status = GetEnumDescription(CloudSyncStatus.NotImported)
                End If


                row.CreateCells(DgvEvaluations)
                row.Cells(0).Value = Status
                row.Cells(1).Value = EvaluationDate
                row.Cells(2).Value = CustomerName
                row.Cells(3).Value = $"{CompressorName}  {SerialNumber}"
                row.Cells(4).Value = String.Join(", ", Technicians)
                row.Tag = doc
                DgvEvaluations.Rows.Add(row)
            Next
        End If


        DgvEvaluations.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvEvaluations.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub






    Private Async Sub DgvEvaluations_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvEvaluations.CellMouseDoubleClick
        Await Import()
    End Sub

    Private Async Sub SyncTimer_Tick(sender As Object, e As EventArgs) Handles SyncTimer.Tick
        If _EvaluationData IsNot Nothing AndAlso _EvaluationData.Count > 0 Then
            If IsDate(_EvaluationData("info")("importing_date")) AndAlso Now > CDate(_EvaluationData("info")("importing_date")).AddMinutes(1) Then
                _EvaluationData("info")("importing_date") = Now.ToString("yyyy-MM-dd HH:mm:ss")
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
            If Row.DataGridView.Columns.Contains("Status") Then
                If Row.Cells("Status").Value = GetEnumDescription(CloudSyncStatus.Importing) Then
                    Dim Data As Dictionary(Of String, Object) = DirectCast(Row.Tag, Dictionary(Of String, Object))
                    If IsDate(Data("info")("importing_date")) AndAlso Now > CDate(Data("info")("importing_date")).AddMinutes(1.5) Then
                        Data("info")("importing_date") = String.Empty
                        Data("info")("importing_by") = String.Empty
                        Await _RemoteDB.ExecutePut("evaluations", Data, Data("id"))
                    End If
                End If
            End If
        Next Row
    End Function

    Private Async Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Await Import()
    End Sub


    Private Async Function Import() As Task
        Dim LoaderForm As New FrmLoader("Importando Avaliação")
        Dim AsyncLoader As New AsyncLoader(Me, LoaderForm, 20, True, Color.White)
        LoaderForm.Cursor = Cursors.WaitCursor
        Await AsyncLoader.Start(2000)
        Cursor = Cursors.WaitCursor
        Dim TempPath As String
        Dim TempSignature As String
        Dim TempPhotos As New List(Of String)
        Dim EvaluationForm As FrmEvaluation
        Dim EvaluationSourceForm As FrmEvaluationSource = Nothing
        Dim SelectedRow As DataGridViewRow

        If Await IsInternetAvailableAsync() Then


            If DgvEvaluations.InvokeRequired Then
                SelectedRow = DgvEvaluations.Invoke(Function() DgvEvaluations.SelectedRows(0))
            Else
                SelectedRow = DgvEvaluations.SelectedRows(0)
            End If
            _EvaluationData = SelectedRow.Tag
            If SelectedRow.Cells("Status").Value = GetEnumDescription(CloudSyncStatus.Importing) Then
                CMessageBox.Show($"Essa avaliação esta sendo importada por {_EvaluationData("info")("importing_by")}", CMessageBoxType.Information)
                Cursor = Cursors.Default
                Exit Function
            End If

            _EvaluationData("info")("importing_date") = Now.ToString("yyyy-MM-dd HH:mm:ss")
            _EvaluationData("info")("importing_by") = _Session.User.Username


            Try

                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))


            Catch ex As Exception
                Return
            End Try








            SyncTimer.Start()



            'COLOCAR TRY AQUI
            Dim SignatureData As Byte() = Await _Storage.DownloadFile(_EvaluationData("signature_url"))




            TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Util.GetFilename(".png"))
            Using SignatureStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                Await SignatureStream.WriteAsync(SignatureData, 0, SignatureData.Length)
            End Using
            TempSignature = TempPath
            For Each Photo As String In _EvaluationData("photo_urls")



                'COLOCAR TRY AQUI
                Dim PhotoData As Byte() = Await _Storage.DownloadFile(Photo)




                TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Util.GetFilename(".jpg"))
                Using PhotoStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                    Await PhotoStream.WriteAsync(PhotoData, 0, PhotoData.Length)
                End Using
                TempPhotos.Add(TempPath)
            Next Photo
            Try
                EvaluationSourceForm = New FrmEvaluationSource(_EvaluationData, TempSignature, TempPhotos)
                If EvaluationSourceForm.ShowDialog() = DialogResult.OK Then
                    If _EvaluationsForm IsNot Nothing Then
                        EvaluationForm = New FrmEvaluation(EvaluationSourceForm.ResultEvaluation, _EvaluationsForm)
                    Else
                        EvaluationForm = New FrmEvaluation(EvaluationSourceForm.ResultEvaluation)
                    End If
                    EvaluationForm.BtnSave.Enabled = True
                    EvaluationForm.ShowDialog()
                    EvaluationForm.Dispose()
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO EV023", "Ocorreu um erro ao importar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            End Try
            If EvaluationSourceForm Is Nothing OrElse (EvaluationSourceForm IsNot Nothing AndAlso EvaluationSourceForm.ResultEvaluation.ID = 0) Then
                _EvaluationData("info")("importing_by") = String.Empty
                _EvaluationData("info")("importing_date") = String.Empty
                _EvaluationData("info")("imported_id") = 0
                _EvaluationData("info")("importing_by") = String.Empty
                _EvaluationData("info")("importing_date") = String.Empty






                'COLOCAR TRY AQUI
                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
            Else
                _EvaluationData("info")("imported") = True
                _EvaluationData("info")("imported_by") = _Session.User.Username
                _EvaluationData("info")("imported_date") = Now.ToString("dd/MM/yyyy HH:mm:ss")
                _EvaluationData("info")("imported_id") = EvaluationSourceForm.ResultEvaluation.ID
                _EvaluationData("info")("importing_by") = String.Empty
                _EvaluationData("info")("importing_date") = String.Empty





                'COLOCAR TRY AQUI
                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
            End If

        Else
            CMessageBox.Show("É necessário estar conectado à internet para importar avaliações.", CMessageBoxType.Warning)
        End If
        If AsyncLoader.IsRunning Then Await AsyncLoader.Stop()
        _EvaluationData = Nothing
        SyncTimer.Stop()
        Cursor = Cursors.Default
    End Function

    Private Sub DgvEvaluations_SelectionChanged(sender As Object, e As EventArgs) Handles DgvEvaluations.SelectionChanged
        BtnImport.Enabled = DgvEvaluations.SelectedRows.Count = 1
    End Sub
End Class

