Imports ManagerCore
Imports ControlLibrary
Imports System.IO

Public Class FrmEvaluationImport
    Private _EvaluationData As Dictionary(Of String, Object) = Nothing
    Private _EvaluationsForm As Form
    Private _RemoteDB As RemoteDB
    Private _LocalDB As LocalDB
    Private _Storage As Storage
    Private _Session As Session

    Public Sub New()
        InitializeComponent()
        InitializeDatabases()
        InitializeDbListener()
    End Sub

    Public Sub New(EvaluationsForm As Form)
        InitializeComponent()
        InitializeDatabases()
        InitializeDbListener()
        _EvaluationsForm = EvaluationsForm
    End Sub


    Private Sub InitializeDatabases()
        _Session = Locator.GetInstance(Of Session)
        _Storage = Locator.GetInstance(Of Storage)
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        _LocalDB = Locator.GetInstance(Of LocalDB)
    End Sub

    Private Sub InitializeDbListener()
        Dim Condition As New List(Of RemoteDB.Condition) From {
            New RemoteDB.WhereEqualToCondition("info.importedid", Nothing)
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
        ControlHelper.EnableControlDoubleBuffer(DgvEvaluations, True)
        SyncTimer.Stop()
        If Not InternetHelper.IsInternetAvailable() Then
            CMessageBox.Show("Não foi possível estabelecer uma conexão com a internet. Verifique sua conexão para realizar importações.", CMessageBoxType.Warning)
            DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Async Sub FillDgv(Docs As List(Of Dictionary(Of String, Object)))
        ' Defina as colunas do DataGridView se ainda não estiverem definidas
        If DgvEvaluations.Columns.Count = 0 Then
            DgvEvaluations.Columns.Add("Status", "Status")
            DgvEvaluations.Columns.Add("Data", "Data")
            DgvEvaluations.Columns.Add("Cliente", "Cliente")
            DgvEvaluations.Columns.Add("Compressor", "Compressor")
        End If

        ' Limpar as linhas existentes
        DgvEvaluations.Rows.Clear()

        ' Adicione os dados ao DataGridView
        If Docs IsNot Nothing AndAlso Docs.Count > 0 Then
            For Each doc In Docs
                Dim Status As String = If(String.IsNullOrEmpty(doc("info")("importingby")), EnumHelper.GetEnumDescription(CloudSyncStatus.NotImported), EnumHelper.GetEnumDescription(CloudSyncStatus.Importing))
                Dim Result As LocalDB.QueryResult = Await _LocalDB.ExecuteRawQuery("SELECT c.id, c.name, pc.serialnumber, pc.sector FROM compressor c LEFT JOIN personcompressor pc ON c.id = pc.compressorid WHERE pc.id = @id", New Dictionary(Of String, Object) From {{"@id", doc("personcompressorid")}})
                Dim CompressorName As String = Result.Data(0)("name").ToString
                Dim SerialNumber As String = $" {Result.Data(0)("serialnumber")}"
                Dim Sector As String = $" {Result.Data(0)("sector")}"
                doc("compressorid") = Result.Data(0)("id")

                Result = Await _LocalDB.ExecuteRawQuery("SELECT p.id, p.shortname FROM person p LEFT JOIN personcompressor pc ON p.id = pc.personid WHERE pc.id = @id", New Dictionary(Of String, Object) From {{"@id", doc("personcompressorid")}})
                Dim CustomerName As String = Result.Data(0)("shortname").ToString
                doc("customerid") = Result.Data(0)("id")
                Dim EvaluationDate As String = DateTimeHelper.DateFromMilliseconds(doc("creationdate")).ToString("dd/MM/yyyy")

                Dim row As New DataGridViewRow()


                If IsDate(doc("info")("importingdate")) AndAlso Now < CDate(doc("info")("importingdate")).AddMinutes(10) Then
                    Status = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing)
                Else
                    Status = EnumHelper.GetEnumDescription(CloudSyncStatus.NotImported)
                End If


                row.CreateCells(DgvEvaluations)
                row.Cells(0).Value = Status
                row.Cells(1).Value = EvaluationDate
                row.Cells(2).Value = CustomerName
                row.Cells(3).Value = $"{CompressorName}{SerialNumber}{Sector}"
                row.Tag = doc
                DgvEvaluations.Rows.Add(row)
            Next
        End If
        DgvEvaluations.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvEvaluations.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

    End Sub

    Private Async Sub DgvEvaluations_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvEvaluations.CellMouseDoubleClick
        Await Import()
    End Sub

    Private Async Sub SyncTimer_Tick(sender As Object, e As EventArgs) Handles SyncTimer.Tick
        If _EvaluationData IsNot Nothing AndAlso _EvaluationData.Count > 0 Then
            If IsDate(_EvaluationData("info")("importingdate")) AndAlso Now > CDate(_EvaluationData("info")("importingdate")).AddMinutes(1) Then
                _EvaluationData("info")("importingdate") = Now.ToString("yyyy-MM-dd HH:mm:ss")
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
                If Row.Cells("Status").Value = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing) Then
                    Dim Data As Dictionary(Of String, Object) = DirectCast(Row.Tag, Dictionary(Of String, Object))
                    If IsDate(Data("info")("importingdate")) AndAlso Now > CDate(Data("info")("importingdate")).AddMinutes(1.5) Then
                        Data("info")("importingdate") = Nothing
                        Data("info")("importingby") = Nothing
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
        Dim SignatureData As Byte()
        Dim PhotoData As Byte()
        If Await InternetHelper.IsInternetAvailableAsync() Then
            Try
                If DgvEvaluations.InvokeRequired Then
                    SelectedRow = DgvEvaluations.Invoke(Function() DgvEvaluations.SelectedRows(0))
                Else
                    SelectedRow = DgvEvaluations.SelectedRows(0)
                End If
                _EvaluationData = SelectedRow.Tag
                If Not SelectedRow.Cells("Status").Value = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing) Then

                    _EvaluationData("info")("importingdate") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    _EvaluationData("info")("importingby") = _Session.User.Username

                    Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))

                    SyncTimer.Start()

                    SignatureData = Await _Storage.DownloadFile(_EvaluationData("signaturepath"))

                    TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Util.GetFilename(".png"))
                    Using SignatureStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                        Await SignatureStream.WriteAsync(SignatureData, 0, SignatureData.Length)
                    End Using
                    TempSignature = TempPath
                    For Each Photo As Dictionary(Of String, Object) In _EvaluationData("photos")

                        PhotoData = Await _Storage.DownloadFile(Photo("path"))

                        TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, Util.GetFilename(".jpg"))
                        Using PhotoStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync:=True)
                            Await PhotoStream.WriteAsync(PhotoData, 0, PhotoData.Length)
                        End Using
                        TempPhotos.Add(TempPath)
                    Next Photo

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

                    If EvaluationSourceForm Is Nothing OrElse (EvaluationSourceForm IsNot Nothing AndAlso EvaluationSourceForm.ResultEvaluation.ID = 0) Then
                        _EvaluationData("info")("importingby") = Nothing
                        _EvaluationData("info")("importingdate") = Nothing
                        _EvaluationData("info")("importedid") = Nothing
                        _EvaluationData("info")("importingby") = Nothing
                        _EvaluationData("info")("importingdate") = Nothing
                        Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
                    Else
                        _EvaluationData("info")("importedby") = _Session.User.Username
                        _EvaluationData("info")("importeddate") = Now.ToString("dd/MM/yyyy HH:mm:ss")
                        _EvaluationData("info")("importedid") = EvaluationSourceForm.ResultEvaluation.ID
                        _EvaluationData("info")("importingby") = Nothing
                        _EvaluationData("info")("importingdate") = Nothing
                        Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))

                    End If
                Else
                    CMessageBox.Show($"Essa avaliação esta sendo importada por {_EvaluationData("info")("importingby")}", CMessageBoxType.Information)
                    Cursor = Cursors.Default
                End If
            Catch ex As Exception
                If Not InternetHelper.IsInternetAvailable() Then
                    CMessageBox.Show("É necessário estar conectado à internet para importar avaliações.", CMessageBoxType.Warning)
                Else
                    CMessageBox.Show("ERRO EV023", "Ocorreu um erro ao importar a avaliação.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            End Try
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

