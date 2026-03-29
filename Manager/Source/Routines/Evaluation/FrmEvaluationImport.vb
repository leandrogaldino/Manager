Imports ManagerCore
Imports ControlLibrary
Imports System.IO
Public Class FrmEvaluationImport
    Private _EvaluationData As Dictionary(Of String, Object) = Nothing
    Private _GridControl As UcEvaluationGrid
    Private _RemoteDB As RemoteDB
    Private _LocalDB As LocalDB
    Private _Storage As Storage
    Private _Session As Session
    Private _IsSyncing As Boolean = False
    Public Sub New()
        InitializeComponent()
        InitializeDatabases()
        InitializeDbListener()
    End Sub
    Public Sub New(GridControl As UcEvaluationGrid)
        InitializeComponent()
        InitializeDatabases()
        InitializeDbListener()
        _GridControl = GridControl
    End Sub
    Private Sub InitializeDatabases()
        _Session = Locator.GetInstance(Of Session)
        _Storage = Locator.GetInstance(Of Storage)
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        _LocalDB = Locator.GetInstance(Of LocalDB)
    End Sub
    Private Sub InitializeDbListener()
        Dim Condition As New List(Of RemoteDB.Condition) From {
            New RemoteDB.WhereEqualToCondition("info.importedby", Nothing),
            New RemoteDB.WhereEqualToCondition("info.requestprocessed", True)
        }
        _RemoteDB.StartListening("evaluations", Condition)
        AddHandler _RemoteDB.OnFirestoreChanged,
            Async Sub(args)
                If Not DgvEvaluations.Created Then Return
                Await DgvEvaluations.Invoke(
                    Async Function()
                        Await SyncGrid(args.Documents)
                        Await RefreshSync()
                    End Function)
            End Sub
    End Sub
    Private Sub FrmEvaluationImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ControlHelper.EnableControlDoubleBuffer(DgvEvaluations, True)
        SyncTimer.Stop()
        If Not InternetHelper.IsInternetAvailable() Then
            CMessageBox.Show("Não foi possível estabelecer uma conexão com a internet.", CMessageBoxType.Warning)
            DialogResult = DialogResult.Cancel
        End If
    End Sub
    Private Async Function SyncGrid(Docs As List(Of Dictionary(Of String, Object))) As Task
        EnsureColumns()
        If Docs Is Nothing Then Return
        Dim Existing As New Dictionary(Of String, DataGridViewRow)
        For Each Row As DataGridViewRow In DgvEvaluations.Rows
            If Row.Tag IsNot Nothing Then
                Dim data = DirectCast(Row.Tag, Dictionary(Of String, Object))
                Existing(data("id").ToString()) = Row
            End If
        Next Row
        Dim ProcessedIds As New HashSet(Of String)
        Dim RowDataList As New List(Of (Doc As Dictionary(Of String, Object), Status As String, EvalDate As String, Customer As String, Compressor As String))
        For Each Doc In Docs
            Dim RowData = Await BuildRowData(Doc)
            RowDataList.Add((Doc, RowData.Status, RowData.EvalDate, RowData.Customer, RowData.Compressor))
        Next Doc
        For Each Item In RowDataList
            Dim Doc = Item.Doc
            Dim DocID = Doc("id").ToString()
            ProcessedIds.Add(DocID)
            Dim Row As DataGridViewRow
            If Existing.ContainsKey(DocID) Then
                Row = Existing(DocID)
            Else
                Dim rowIndex As Integer = DgvEvaluations.Rows.Add()
                Row = DgvEvaluations.Rows(rowIndex)
            End If
            If Row Is Nothing OrElse Row.DataGridView Is Nothing Then Continue For
            If Row.Cells.Count < 4 Then Continue For
            Row.Cells(0).Value = Item.Status
            Row.Cells(1).Value = Item.EvalDate
            Row.Cells(2).Value = Item.Customer
            Row.Cells(3).Value = Item.Compressor
            Row.Tag = Doc
        Next Item
        For Each Row As DataGridViewRow In DgvEvaluations.Rows.Cast(Of DataGridViewRow).ToList()
            If Row.Tag Is Nothing Then Continue For
            Dim Data = DirectCast(Row.Tag, Dictionary(Of String, Object))
            Dim ID = Data("id").ToString()
            If Not ProcessedIds.Contains(ID) Then
                DgvEvaluations.Rows.Remove(Row)
            End If
        Next
        DgvEvaluations.Sort(DgvEvaluations.Columns(1), ComponentModel.ListSortDirection.Ascending)
    End Function
    Private Sub EnsureColumns()
        If DgvEvaluations.Columns.Count > 0 Then Return
        DgvEvaluations.Columns.Add("Status", "Status")
        DgvEvaluations.Columns.Add("Data", "Data")
        DgvEvaluations.Columns.Add("Cliente", "Cliente")
        DgvEvaluations.Columns.Add("Compressor", "Compressor")
        DgvEvaluations.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluations.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvEvaluations.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub
    Private Async Function BuildRowData(doc As Dictionary(Of String, Object)) _
    As Task(Of (Status As String, EvalDate As String, Customer As String, Compressor As String))
        Dim Result As LocalDB.QueryResult = Await _LocalDB.ExecuteRawQueryAsync(
            My.Resources.SelectCompressorData,
            New Dictionary(Of String, Object) From {{"@id", doc("compressorid")}}
        )
        If Result.Data.Count = 0 Then
            Return ("-", "-", "-", "-")
        End If
        Dim CompressorName = Result.Data(0)("name").ToString()
        Dim Serial = $" {Result.Data(0)("serialnumber")}"
        Dim Sector = $" {Result.Data(0)("sector")}"
        Result = Await _LocalDB.ExecuteRawQueryAsync(
            My.Resources.SelectCustomerData,
            New Dictionary(Of String, Object) From {{"@id", doc("compressorid")}}
        )
        Dim Customer As String = "-"
        If Result.Data.Count > 0 Then
            Customer = Result.Data(0)("shortname").ToString()
        End If
        Dim EvaluationDate = DateTimeHelper.DateFromMilliseconds(doc("creationdate")).ToString("dd/MM/yyyy")
        Dim Status As String
        If IsDate(doc("info")("importingdate")) AndAlso
       Now < CDate(doc("info")("importingdate")).AddMinutes(10) Then
            Status = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing)
        Else
            Status = EnumHelper.GetEnumDescription(CloudSyncStatus.NotImported)
        End If
        Return (Status, EvaluationDate, Customer, $"{CompressorName}{Serial}{Sector}")
    End Function
    Private Async Sub SyncTimer_Tick(sender As Object, e As EventArgs) Handles SyncTimer.Tick
        If _EvaluationData Is Nothing Then Return
        If IsDate(_EvaluationData("info")("importingdate")) AndAlso
           Now > CDate(_EvaluationData("info")("importingdate")).AddMinutes(1) Then
            _EvaluationData("info")("importingdate") = Now.ToString("yyyy-MM-dd HH:mm:ss")
            Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
        End If
    End Sub
    Private Async Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        RefreshTimer.Stop()
        Await RefreshSync()
        RefreshTimer.Start()
    End Sub
    Private Async Function RefreshSync() As Task
        For Each Row As DataGridViewRow In DgvEvaluations.Rows
            If Row.Tag Is Nothing Then Continue For
            If Row.Cells("Status").Value = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing) Then
                Dim data = DirectCast(Row.Tag, Dictionary(Of String, Object))
                If IsDate(data("info")("importingdate")) AndAlso Now > CDate(data("info")("importingdate")).AddMinutes(1.5) Then
                    data("info")("importingdate") = Nothing
                    data("info")("importingby") = Nothing
                    Await _RemoteDB.ExecutePut("evaluations", data, data("id"))
                End If
            End If
        Next Row
    End Function
    Private Async Sub DgvEvaluations_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvEvaluations.CellMouseDoubleClick
        Await Import()
    End Sub
    Private Async Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Await Import()
    End Sub
    Private Sub DgvEvaluations_SelectionChanged(sender As Object, e As EventArgs) Handles DgvEvaluations.SelectionChanged
        BtnImport.Enabled = DgvEvaluations.SelectedRows.Count = 1
    End Sub
    Private Async Function Import() As Task
        Dim TempPath As String
        Dim TempSignature As String
        Dim TempPictures As New List(Of String)
        Dim EvaluationForm As FrmEvaluation
        Dim SelectedRow As DataGridViewRow
        Dim SignatureData As Byte()
        Dim PictureData As Byte()
        Dim AsyncLoader As AsyncLoader
        Using LoaderForm As New FrmLoader(My.Resources.Downloading, "Importando Avaliação")
            AsyncLoader = New AsyncLoader(Me, LoaderForm, 20, True, Color.White)
            LoaderForm.Cursor = Cursors.WaitCursor
            Await AsyncLoader.Start(2000)
            Cursor = Cursors.WaitCursor
            If Await InternetHelper.IsInternetAvailableAsync() Then
                Try
                    SelectedRow = DgvEvaluations.SelectedRows(0)
                    _EvaluationData = DirectCast(SelectedRow.Tag, Dictionary(Of String, Object))
                    If Not SelectedRow.Cells("Status").Value =
                        EnumHelper.GetEnumDescription(CloudSyncStatus.Importing) Then
                        _EvaluationData("info")("importingdate") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                        _EvaluationData("info")("importingby") = _Session.User.Username
                        Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
                        SyncTimer.Start()
                        SignatureData = Await _Storage.DownloadFile(_EvaluationData("signaturepath"))
                        TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, TextHelper.GetRandomFileName(".png"))
                        Using SignatureStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, True)
                            Await SignatureStream.WriteAsync(SignatureData, 0, SignatureData.Length)
                        End Using
                        TempSignature = TempPath
                        For Each Picture As Dictionary(Of String, Object) In _EvaluationData("photos")
                            PictureData = Await _Storage.DownloadFile(Picture("path"))
                            TempPath = Path.Combine(ApplicationPaths.ManagerTempDirectory, TextHelper.GetRandomFileName(".jpg"))
                            Using PictureStream As New FileStream(TempPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, True)
                                Await PictureStream.WriteAsync(PictureData, 0, PictureData.Length)
                            End Using
                            TempPictures.Add(TempPath)
                        Next
                        Using EvaluationSourceForm = New FrmEvaluationSource(_EvaluationData, TempSignature, TempPictures)
                            If EvaluationSourceForm.ShowDialog() = DialogResult.OK Then
                                If _GridControl IsNot Nothing Then
                                    EvaluationForm = New FrmEvaluation(EvaluationSourceForm.ResultEvaluation, _GridControl)
                                Else
                                    EvaluationForm = New FrmEvaluation(EvaluationSourceForm.ResultEvaluation)
                                End If
                                EvaluationForm.BtnSave.Enabled = True
                                EvaluationForm.ShowDialog()
                                EvaluationForm.Dispose()
                            End If
                            If EvaluationSourceForm Is Nothing OrElse EvaluationSourceForm.ResultEvaluation.ID = 0 Then
                                _EvaluationData("info")("importingby") = Nothing
                                _EvaluationData("info")("importingdate") = Nothing
                                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
                            Else
                                _EvaluationData("info")("importedby") = _Session.User.Username
                                _EvaluationData("info")("importeddate") = Now.ToString("dd/MM/yyyy HH:mm:ss")
                                _EvaluationData("info")("importedid") = EvaluationSourceForm.ResultEvaluation.ID
                                _EvaluationData("lastupdate") = DateTimeHelper.MillisecondsFromDate(DateTimeHelper.Now)
                                _EvaluationData("info")("importingby") = Nothing
                                _EvaluationData("info")("importingdate") = Nothing
                                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
                            End If
                        End Using
                    Else
                        CMessageBox.Show($"Essa avaliação esta sendo importada por {_EvaluationData("info")("importingby")}.", CMessageBoxType.Information)
                    End If
                Catch ex As Exception
                    If Not InternetHelper.IsInternetAvailable() Then
                        CMessageBox.Show("É necessário estar conectado à internet.", CMessageBoxType.Warning)
                    Else
                        CMessageBox.Show("ERRO EV023", "Erro ao importar.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                End Try
            Else
                CMessageBox.Show("É necessário estar conectado à internet.", CMessageBoxType.Warning)
            End If
            If AsyncLoader.IsRunning Then Await AsyncLoader.Stop()
            _EvaluationData = Nothing
            SyncTimer.Stop()
            Cursor = Cursors.Default
        End Using
    End Function
End Class
