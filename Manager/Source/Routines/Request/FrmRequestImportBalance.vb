Imports ControlLibrary
Imports ManagerCore

Public Class FrmRequestImportBalance
    Private _EvaluationData As Dictionary(Of String, Object)
    Private _LocalDB As LocalDB
    Private _RemoteDB As RemoteDB
    Private _EvaluationProducts As List(Of EvaluationReplacedSellable)
    Public Sub New(EvaluationData As Dictionary(Of String, Object))
        InitializeComponent()
        _LocalDB = Locator.GetInstance(Of LocalDB)
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        _EvaluationData = EvaluationData
        FillEvaluationProductsDataGridView()
    End Sub

    Private Sub FillEvaluationProductsDataGridView()
        Dim Evaluation As Evaluation = Evaluation.FromCloud(_EvaluationData, String.Empty, New List(Of String))
        Dim Shadow As Evaluation = Evaluation.FromCloud(_EvaluationData, String.Empty, New List(Of String))
        _EvaluationProducts = Shadow.ReplacedSellables.Where(Function(x) x.SellableType = SellableType.Product).ToList()

        DgvEvaluationProducts.DataSource = Evaluation.ReplacedSellables.Where(Function(x) x.SellableType = SellableType.Product).ToList()
        DgvEvaluationProducts.Columns("SellableType").Visible = False
        DgvEvaluationProducts.Columns("Service").Visible = False
        DgvEvaluationProducts.Columns("Sellable").Visible = False
        DgvEvaluationProducts.Columns("Name").Visible = False
        DgvEvaluationProducts.Columns("Guid").Visible = False
        DgvEvaluationProducts.Columns("ID").Visible = False
        DgvEvaluationProducts.Columns("Creation").Visible = False
        DgvEvaluationProducts.Columns("Routine").Visible = False
        DgvEvaluationProducts.Columns("IsSaved").Visible = False
        DgvEvaluationProducts.Columns("User").Visible = False
        DgvEvaluationProducts.Columns("SellableID").Visible = False
        DgvEvaluationProducts.Columns("Code").HeaderText = "Código"
        DgvEvaluationProducts.Columns("Code").DisplayIndex = 0
        DgvEvaluationProducts.Columns("Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluationProducts.Columns("code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgvEvaluationProducts.Columns("code").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgvEvaluationProducts.Columns("Product").HeaderText = "Produto"
        DgvEvaluationProducts.Columns("Product").DisplayIndex = 1
        DgvEvaluationProducts.Columns("Product").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvEvaluationProducts.Columns("Quantity").HeaderText = "Qtd."
        DgvEvaluationProducts.Columns("Quantity").DisplayIndex = 3
        DgvEvaluationProducts.Columns("Quantity").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DgvEvaluationProducts.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgvEvaluationProducts.Columns("Quantity").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Async Function FillRequestsProductsDataGridView() As Task
        Dim ReplacedProducts As List(Of Object) = _EvaluationData("replacedproducts")
        Dim ProductIds As List(Of Long) = ReplacedProducts.OfType(Of Dictionary(Of String, Object))().Select(Function(d) Convert.ToInt64(d("productid"))).ToList()
        Try

            Dim Params As New Dictionary(Of String, Object)
            Dim paramNames As New List(Of String)
            For i = 0 To ProductIds.Count - 1
                Dim paramName As String = "@id" & i
                paramNames.Add(paramName)
                Params.Add(paramName, ProductIds(i))
            Next
            Dim inClause As String = String.Join(",", paramNames)
            Dim sql As String = "
                SELECT
                    r.id requestid,
                    r.responsible,
                    r.destination,
                    ri.id itemid,
                    ri.productid,
                    pc.code,
                    p.name,
                    ri.taked - ri.returned - ri.applied - ri.lossed AS pending
                FROM requestitem ri
                JOIN product p ON p.id = ri.productid
                JOIN request r ON r.id = ri.requestid
                LEFT join productprovidercode pc on pc.productid = p.id AND pc.ismainprovider = 1
                WHERE
                    ri.statusid = 0
                    AND ri.productid IN (#inClause)
                ORDER BY r.id DESC"

            sql = sql.Replace("#inClause", inClause)

            Dim Result As LocalDB.QueryResult = Await _LocalDB.ExecuteRawQueryAsync(
                sql,
                Params
            )

            If Not Result.HasData Then Return

            DgvRequestsProducts.DataSource = ConvertToDataTable(Result.Data)


            DgvRequestsProducts.Columns("responsible").ReadOnly = True
            DgvRequestsProducts.Columns("responsible").HeaderText = "Responsável"
            DgvRequestsProducts.Columns("responsible").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvRequestsProducts.Columns("responsible").SortMode = DataGridViewColumnSortMode.NotSortable


            DgvRequestsProducts.Columns("destination").HeaderText = "Destino"
            DgvRequestsProducts.Columns("destination").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvRequestsProducts.Columns("destination").ReadOnly = True
            DgvRequestsProducts.Columns("destination").SortMode = DataGridViewColumnSortMode.NotSortable

            DgvRequestsProducts.Columns("name").HeaderText = "Produto"
            DgvRequestsProducts.Columns("name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DgvRequestsProducts.Columns("name").ReadOnly = True
            DgvRequestsProducts.Columns("name").SortMode = DataGridViewColumnSortMode.NotSortable

            DgvRequestsProducts.Columns("code").HeaderText = "Código"
            DgvRequestsProducts.Columns("code").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvRequestsProducts.Columns("code").ReadOnly = True
            DgvRequestsProducts.Columns("code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DgvRequestsProducts.Columns("code").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DgvRequestsProducts.Columns("code").SortMode = DataGridViewColumnSortMode.NotSortable

            DgvRequestsProducts.Columns("pending").HeaderText = "Pendente"
            DgvRequestsProducts.Columns("pending").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvRequestsProducts.Columns("pending").ReadOnly = True
            DgvRequestsProducts.Columns("pending").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DgvRequestsProducts.Columns("pending").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DgvRequestsProducts.Columns("pending").SortMode = DataGridViewColumnSortMode.NotSortable

            DgvRequestsProducts.Columns("requestid").Visible = False
            DgvRequestsProducts.Columns("itemid").Visible = False
            DgvRequestsProducts.Columns("productid").Visible = False



            Dim ToImportColumn As New DataGridViewDecimalColumn With {
                .Name = "ToImport",
                .HeaderText = "Qtd. a Importar",
                .DecimalPlaces = 2,
                .ReadOnly = False,
                .SortMode = DataGridViewColumnSortMode.NotSortable
            }
            ToImportColumn.DefaultCellStyle.NullValue = "0,00"
            ToImportColumn.DefaultCellStyle.BackColor = Color.Gainsboro
            ToImportColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ToImportColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DgvRequestsProducts.Columns.Add(ToImportColumn)



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function ConvertToDataTable(data As List(Of Dictionary(Of String, Object))) As DataTable
        Dim dt As New DataTable()
        If data Is Nothing OrElse data.Count = 0 Then
            Return dt
        End If

        ' Criar colunas baseado na primeira linha
        For Each key In data(0).Keys
            dt.Columns.Add(key)
        Next
        For Each rowDict In data
            Dim row = dt.NewRow()

            For Each key In rowDict.Keys
                row(key) = If(rowDict(key), DBNull.Value)
            Next
            dt.Rows.Add(row)
        Next
        Return dt
    End Function
    Private Async Sub FrmRequestImportBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await FillRequestsProductsDataGridView()
    End Sub

    Private Sub DgvRequestsProducts_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRequestsProducts.SelectionChanged
        If DgvRequestsProducts.SelectedRows.Count = 0 Then Exit Sub
        Dim Id As Long = DgvRequestsProducts.SelectedRows(0).Cells("productid").Value
        DgvEvaluationProducts.Rows.Cast(Of DataGridViewRow)().FirstOrDefault(Function(r) Convert.ToInt64(r.Cells("SellableID").Value) = Id).Selected = True
        DgvEvaluationProducts.FirstDisplayedScrollingRowIndex = DgvEvaluationProducts.SelectedRows(0).Index
        If DgvRequestsProducts.Columns.Contains("ToImport") Then
            DgvRequestsProducts.SelectedRows(0).Cells("ToImport").Selected = True
        End If
    End Sub

    Private Sub DgvRequestsProducts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRequestsProducts.CellValueChanged
        If Not DgvRequestsProducts.Columns.Contains("ToImport") Then Exit Sub


        If e.ColumnIndex = DgvRequestsProducts.Columns("ToImport").Index Then


            Dim ID As Long = DgvRequestsProducts.Rows(e.RowIndex).Cells("productid").Value


            Dim RequestValue As Decimal = DgvRequestsProducts.Rows.Cast(Of DataGridViewRow).Where(Function(x) x.Cells("productid").Value = ID).Sum(Function(y) Convert.ToDecimal(y.Cells("ToImport").Value))


            Dim EvaluationValue As Decimal = Convert.ToDecimal(_EvaluationProducts.First(Function(x) x.SellableID = ID).Quantity)


            If EvaluationValue < RequestValue Then
                MsgBox("A quantidade a importar não pode ser maior que a quantidade disponivel na avaliação.", MsgBoxStyle.Exclamation)
                DgvRequestsProducts.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                Exit Sub
            End If

            Dim Result As Decimal = EvaluationValue - RequestValue


            DgvEvaluationProducts.SelectedRows(0).Cells("Quantity").Value = Result

            If Not _Ignore Then
                If DgvEvaluationProducts.Rows.Cast(Of DataGridViewRow).All(Function(x) x.Cells("Quantity").Value = 0) Then
                    BtnImport.Enabled = True
                Else
                    BtnImport.Enabled = False
                End If
            Else
                BtnImport.Enabled = True
            End If




        End If

    End Sub

    Private _Ignore As Boolean


    Private Async Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click


        Dim AsyncLoader As AsyncLoader

        Using LoaderForm As New FrmLoader(My.Resources.Updating, "Atualizando Requisições")

            AsyncLoader = New AsyncLoader(Me, LoaderForm, 20, True, Color.White)

            LoaderForm.Cursor = Cursors.WaitCursor
            Await AsyncLoader.Start(2000)
            Cursor = Cursors.WaitCursor

            Try
                For Each Row As DataGridViewRow In DgvRequestsProducts.Rows
                    Dim ToImport As Decimal = Row.Cells("ToImport").Value
                    If ToImport > 0 Then
                        Dim Request As Request = New Request().Load(Row.Cells("requestid").Value, False)
                        Request.Items.First(Function(x) x.ID = Row.Cells("itemid").Value).Applied += ToImport
                        Request.UpdateStatus()
                        Request.SaveChanges()
                    End If
                Next Row

                _EvaluationData("info")("importingby") = Nothing
                _EvaluationData("info")("importingdate") = Nothing
                _EvaluationData("info")("requestprocessed") = True
                Await _RemoteDB.ExecutePut("evaluations", _EvaluationData, _EvaluationData("id"))
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try





            If AsyncLoader.IsRunning Then Await AsyncLoader.Stop()

            _EvaluationData = Nothing
            SyncTimer.Stop()
            Cursor = Cursors.Default
        End Using


        DialogResult = DialogResult.OK
    End Sub


    Private Sub CbxIgnore_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIgnore.CheckedChanged
        _Ignore = CbxIgnore.Checked
        BtnImport.Enabled = _Ignore
    End Sub
End Class