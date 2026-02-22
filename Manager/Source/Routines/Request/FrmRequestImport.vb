Imports System.IO
Imports ControlLibrary
Imports ManagerCore

Public Class FrmRequestImport
    Private _EvaluationData As Dictionary(Of String, Object) = Nothing
    Private _GridControl As UcRequestGrid
    Private _RemoteDB As RemoteDB
    Private _LocalDB As LocalDB
    Private _Storage As Storage
    Private _Session As Session

    Public Sub New()
        InitializeComponent()
        InitializeDatabases()
        InitializeDbListener()
    End Sub

    Public Sub New(GridControl As UcRequestGrid)
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
            New RemoteDB.WhereEqualToCondition("info.hasreplacedproducts", True),
            New RemoteDB.WhereEqualToCondition("info.requestprocessed", False)
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
    Private _isSyncing As Boolean = False

    Private Async Function SyncGrid(Docs As List(Of Dictionary(Of String, Object))) As Task

        EnsureColumns()

        If Docs Is Nothing Then Return

        ' ===== Snapshot das linhas existentes =====
        Dim existing As New Dictionary(Of String, DataGridViewRow)

        For Each r As DataGridViewRow In DgvEvaluations.Rows
            If r.Tag IsNot Nothing Then
                Dim data = DirectCast(r.Tag, Dictionary(Of String, Object))
                existing(data("id").ToString()) = r
            End If
        Next

        Dim processedIds As New HashSet(Of String)

        ' ===== Buscar dados FORA da grid =====
        Dim rowDataList As New List(Of (Doc As Dictionary(Of String, Object),
                                     Status As String,
                                     EvalDate As String,
                                     Customer As String,
                                     Compressor As String))

        For Each doc In Docs
            Dim rowData = Await BuildRowData(doc)
            rowDataList.Add((doc, rowData.Status, rowData.EvalDate, rowData.Customer, rowData.Compressor))
        Next

        ' ===== Atualizar grid (SEM awaits aqui) =====
        For Each item In rowDataList

            Dim doc = item.Doc
            Dim docId = doc("id").ToString()

            processedIds.Add(docId)

            Dim row As DataGridViewRow = Nothing

            If existing.ContainsKey(docId) Then
                row = existing(docId)
            Else
                ' 🔥 FORMA CORRETA DE CRIAR LINHA
                Dim rowIndex As Integer = DgvEvaluations.Rows.Add()
                row = DgvEvaluations.Rows(rowIndex)
            End If

            ' Segurança extra
            If row Is Nothing OrElse row.DataGridView Is Nothing Then Continue For
            If row.Cells.Count < 4 Then Continue For

            row.Cells(0).Value = item.Status
            row.Cells(1).Value = item.EvalDate
            row.Cells(2).Value = item.Customer
            row.Cells(3).Value = item.Compressor
            row.Tag = doc

        Next

        ' ===== Remover linhas que não existem mais =====
        For Each r As DataGridViewRow In DgvEvaluations.Rows.Cast(Of DataGridViewRow).ToList()

            If r.Tag Is Nothing Then Continue For

            Dim data = DirectCast(r.Tag, Dictionary(Of String, Object))
            Dim id = data("id").ToString()

            If Not processedIds.Contains(id) Then
                DgvEvaluations.Rows.Remove(r)
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

    Private Async Function BuildRowData(doc As Dictionary(Of String, Object)) _
    As Task(Of (Status As String, EvalDate As String, Customer As String, Compressor As String))

        ' ===== QUERY 1 =====
        Dim Result As LocalDB.QueryResult = Await _LocalDB.ExecuteRawQueryAsync(
        "SELECT c.name, pc.serialnumber, pc.sector 
         FROM compressor c
         LEFT JOIN personcompressor pc ON c.id = pc.compressorid
         WHERE pc.id = @id",
        New Dictionary(Of String, Object) From {{"@id", doc("compressorid")}}
    )

        If Result.Data.Count = 0 Then
            Return ("-", "-", "-", "-")
        End If

        Dim compressorName = Result.Data(0)("name").ToString()
        Dim serial = $" {Result.Data(0)("serialnumber")}"
        Dim sector = $" {Result.Data(0)("sector")}"

        ' ===== QUERY 2 =====
        Result = Await _LocalDB.ExecuteRawQueryAsync(
        "SELECT p.shortname
         FROM person p
         LEFT JOIN personcompressor pc ON p.id = pc.personid
         WHERE pc.id = @id",
        New Dictionary(Of String, Object) From {{"@id", doc("compressorid")}}
    )

        Dim customer As String = "-"

        If Result.Data.Count > 0 Then
            customer = Result.Data(0)("shortname").ToString()
        End If

        Dim evalDate = DateTimeHelper.DateFromMilliseconds(doc("creationdate")).ToString("dd/MM/yyyy")

        Dim status As String

        If IsDate(doc("info")("importingdate")) AndAlso
       Now < CDate(doc("info")("importingdate")).AddMinutes(10) Then

            status = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing)

        Else

            status = EnumHelper.GetEnumDescription(CloudSyncStatus.NotImported)

        End If

        Return (status, evalDate, customer, $"{compressorName}{serial}{sector}")

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



        Dim SelectedRow As DataGridViewRow

        Dim AsyncLoader As AsyncLoader

        Using LoaderForm As New FrmLoader(My.Resources.Downloading, "Importando Produtos da Avaliação")

            AsyncLoader = New AsyncLoader(Me, LoaderForm, 20, True, Color.White)

            LoaderForm.Cursor = Cursors.WaitCursor
            Await AsyncLoader.Start(2000)
            Cursor = Cursors.WaitCursor

            If Await InternetHelper.IsInternetAvailableAsync() Then

                Try

                    SelectedRow = DgvEvaluations.SelectedRows(0)

                    _EvaluationData = DirectCast(SelectedRow.Tag, Dictionary(Of String, Object))

                    If Not SelectedRow.Cells("Status").Value = EnumHelper.GetEnumDescription(CloudSyncStatus.Importing) Then

                        _EvaluationData("info")("importingdate") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                        _EvaluationData("info")("importingby") = _Session.User.Username

                        Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))

                        SyncTimer.Start()


                        Dim ReplacedProducts As List(Of Object) = _EvaluationData("replacedproducts")

                        Dim ProductIds As List(Of Long) = ReplacedProducts.OfType(Of Dictionary(Of String, Object))().Select(Function(d) Convert.ToInt64(d("productid"))).ToList()







                        Using RequestImportBalanceForm = New FrmRequestImportBalance(_EvaluationData)

                            If RequestImportBalanceForm.ShowDialog() = DialogResult.OK Then
                                _EvaluationData("info")("requestprocessed") = True
                            End If

                            _EvaluationData("info")("importingby") = Nothing
                            _EvaluationData("info")("importingdate") = Nothing

                            Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))



                        End Using

                    Else

                        CMessageBox.Show($"Os itens dessa avaliação estão sendo importados por {_EvaluationData("info")("importingby")}.", CMessageBoxType.Information)

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