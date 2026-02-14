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
            New RemoteDB.WhereEqualToCondition("info.importedby", Nothing)
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

    '================ GRID INCREMENTAL =================

    Private Async Function SyncGrid(Docs As List(Of Dictionary(Of String, Object))) As Task

        EnsureColumns()

        If Docs Is Nothing Then Return

        Dim existing As New Dictionary(Of String, DataGridViewRow)

        For Each row As DataGridViewRow In DgvEvaluations.Rows
            If row.Tag IsNot Nothing Then
                Dim data = DirectCast(row.Tag, Dictionary(Of String, Object))
                existing(data("id").ToString()) = row
            End If
        Next

        Dim processedIds As New HashSet(Of String)

        For Each doc In Docs

            Dim docId = doc("id").ToString()
            processedIds.Add(docId)

            Dim row As DataGridViewRow = Nothing

            If existing.ContainsKey(docId) Then
                row = existing(docId)
            Else
                row = New DataGridViewRow()
                row.CreateCells(DgvEvaluations)
                DgvEvaluations.Rows.Add(row)
            End If

            Await FillRow(row, doc)

        Next

        For Each row As DataGridViewRow In DgvEvaluations.Rows.Cast(Of DataGridViewRow).ToList()

            If row.Tag Is Nothing Then Continue For

            Dim data = DirectCast(row.Tag, Dictionary(Of String, Object))
            Dim id = data("id").ToString()

            If Not processedIds.Contains(id) Then
                DgvEvaluations.Rows.Remove(row)
            End If

        Next

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

    Private Async Function FillRow(row As DataGridViewRow, doc As Dictionary(Of String, Object)) As Task

        Dim Result As LocalDB.QueryResult = Await _LocalDB.ExecuteRawQueryAsync(
            "SELECT c.name, pc.serialnumber, pc.sector 
             FROM compressor c
             LEFT JOIN personcompressor pc ON c.id = pc.compressorid
             WHERE pc.id = @id",
            New Dictionary(Of String, Object) From {{"@id", doc("compressorid")}}
        )

        Dim compressorName = Result.Data(0)("name").ToString()
        Dim serial = $" {Result.Data(0)("serialnumber")}"
        Dim sector = $" {Result.Data(0)("sector")}"

        Result = Await _LocalDB.ExecuteRawQueryAsync(
            "SELECT p.shortname
             FROM person p
             LEFT JOIN personcompressor pc ON p.id = pc.personid
             WHERE pc.id = @id",
            New Dictionary(Of String, Object) From {{"@id", doc("compressorid")}}
        )

        Dim customer = Result.Data(0)("shortname").ToString()

        Dim evalDate = DateTimeHelper.DateFromMilliseconds(doc("creationdate")).ToString("dd/MM/yyyy")

        Dim status As String

        If IsDate(doc("info")("importingdate")) AndAlso
           Now < CDate(doc("info")("importingdate")).AddMinutes(10) Then

            status = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing)

        Else
            status = EnumHelper.GetEnumDescription(CloudSyncStatus.NotImported)
        End If

        row.Cells(0).Value = status
        row.Cells(1).Value = evalDate
        row.Cells(2).Value = customer
        row.Cells(3).Value = $"{compressorName}{serial}{sector}"

        row.Tag = doc

    End Function

    '================ TIMERS =================

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

        For Each row As DataGridViewRow In DgvEvaluations.Rows

            If row.Tag Is Nothing Then Continue For

            If row.Cells("Status").Value =
                EnumHelper.GetEnumDescription(CloudSyncStatus.Importing) Then

                Dim data = DirectCast(row.Tag, Dictionary(Of String, Object))

                If IsDate(data("info")("importingdate")) AndAlso
                   Now > CDate(data("info")("importingdate")).AddMinutes(1.5) Then

                    data("info")("importingdate") = Nothing
                    data("info")("importingby") = Nothing

                    Await _RemoteDB.ExecutePut("evaluations", data, data("id"))

                End If

            End If

        Next

    End Function

    '================ EVENTOS =================

    Private Async Sub DgvEvaluations_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvEvaluations.CellMouseDoubleClick
        Await Import()
    End Sub

    Private Async Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Await Import()
    End Sub

    Private Sub DgvEvaluations_SelectionChanged(sender As Object, e As EventArgs) Handles DgvEvaluations.SelectionChanged
        BtnImport.Enabled = DgvEvaluations.SelectedRows.Count = 1
    End Sub

    '================ IMPORT =================

    Private Async Function Import() As Task

        Dim TempPath As String
        Dim TempSignature As String
        Dim TempPictures As New List(Of String)
        Dim EvaluationForm As FrmEvaluation
        Dim SelectedRow As DataGridViewRow
        Dim SignatureData As Byte()
        Dim PictureData As Byte()
        Dim AsyncLoader As AsyncLoader

        Using LoaderForm As New FrmLoader("Importando Avaliação")

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

                            If EvaluationSourceForm Is Nothing OrElse
                               EvaluationSourceForm.ResultEvaluation.ID = 0 Then

                                _EvaluationData("info")("importingby") = Nothing
                                _EvaluationData("info")("importingdate") = Nothing

                                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))

                            Else

                                _EvaluationData("info")("importedby") = _Session.User.Username
                                _EvaluationData("info")("importeddate") = Now.ToString("dd/MM/yyyy HH:mm:ss")
                                _EvaluationData("info")("importingby") = Nothing
                                _EvaluationData("info")("importingdate") = Nothing

                                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))

                            End If

                        End Using

                    Else

                        CMessageBox.Show(
                            $"Essa avaliação esta sendo importada por {_EvaluationData("info")("importingby")}.",
                            CMessageBoxType.Information)

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
