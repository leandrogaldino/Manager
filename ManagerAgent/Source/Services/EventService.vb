Imports System.Threading
Imports System.Transactions
Imports ControlLibrary
Imports ManagerCore
Public Class EventService
    Private ReadOnly _Database As LocalDB
    Private ReadOnly _Semaphore As SemaphoreSlim

    Public Sub New(Database As LocalDB, Semaphore As SemaphoreSlim)
        _Database = Database
        _Semaphore = Semaphore
    End Sub
    Public Sub Write(Builder As EventBuilder, Data As DataTable)
        Dim Initial As EventInitialModel = Builder.GetInitialEvent()
        Dim Childs As List(Of EventChildModel) = Builder.GetChildEvents()
        Dim Final As EventFinalModel = Builder.GetFinalEvent()
        If Data Is Nothing OrElse Data.Columns.Count = 0 Then Exit Sub
        If Initial IsNot Nothing AndAlso Not Initial.Processed Then
            WriteSingle(Initial, Data)
        End If
        Dim BuilderChilds As List(Of EventChildModel) = Nothing
        If Childs IsNot Nothing Then BuilderChilds = Childs.ToList
        If BuilderChilds IsNot Nothing AndAlso BuilderChilds.Any(Function(x) Not x.Processed) Then
            For Each Child As EventChildModel In BuilderChilds.Where(Function(x) Not x.Processed)
                WriteSingle(Child, Data)
            Next Child
        End If
        If Final IsNot Nothing AndAlso Not Final.Processed Then
            Final.TempID = Final.TempID
            WriteSingle(Final, Data)
        End If
    End Sub
    Private Sub WriteSingle([Event] As EventModel, Data As DataTable)
        Dim NewRow As DataRow
        If Data Is Nothing OrElse Data.Columns.Count = 0 Then Exit Sub
        NewRow = Data.NewRow()
        NewRow.Item("id") = [Event].ID
        NewRow.Item("parentid") = [Event].ParentID
        NewRow.Item("eventtype") = CInt([Event].EventType)
        NewRow.Item("time") = [Event].Time
        NewRow.Item("description") = If([Event].EventType = EventTypes.Child, $"{Constants.SubItemSymbol} {[Event].Description}", [Event].Description)
        NewRow.Item("tempid") = [Event].TempID
        NewRow.Item("issaved") = False
        Data.Rows.InsertAt(NewRow, 0)
        [Event].Processed = True
        Debug.Print([Event].Description)
    End Sub
    Public Async Function Save(Data As DataTable) As Task
        Dim Values As Dictionary(Of String, String)
        Dim Args As Dictionary(Of String, Object)
        If Data Is Nothing OrElse Data.Columns.Count = 0 Then Exit Function
        If Data.Rows.Cast(Of DataRow).Any(Function(x) Not CBool(x("issaved"))) Then
            Await _Semaphore.WaitAsync()
            Try
                Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                    For Each Row As DataRow In Data.Rows.Cast(Of DataRow).Where(Function(x) Not CBool(x("issaved"))).Reverse()
                        Values = New Dictionary(Of String, String) From {
                                {"id", "@id"},
                                {"parentid", "@parentid"},
                                {"eventtype", "@eventtype"},
                                {"time", "@time"},
                                {"description", "@description"}
                            }
                        Args = New Dictionary(Of String, Object) From {
                                {"@id", DBNull.Value},
                                {"@parentid", If(Row("parentid") > 0, Row("parentid"), DBNull.Value)},
                                {"@eventtype", CInt(Row("eventtype"))},
                                {"@time", CDate(Row("time")).ToString("yyyy-MM-dd HH:mm:ss")},
                                {"@description", Row("description").ToString.Replace($"{Constants.SubItemSymbol} ", Nothing)}
                            }
                        Dim Result = Await _Database.ExecuteInsertAsync("agentevent", Values, Args)
                        Row("id") = Result.LastInsertedID
                        If Row("eventtype") = EventTypes.Initial Then
                            For Each r As DataRow In Data.Rows.Cast(Of DataRow).Where(Function(x) x("tempid") IsNot DBNull.Value AndAlso x("tempid") = Row("tempid") And x("eventtype") <> EventTypes.Initial)
                                r("parentid") = Row("id")
                                Values = New Dictionary(Of String, String) From {
                                        {"parentid", "@parentid"}
                                    }
                                Args = New Dictionary(Of String, Object) From {
                                        {"@parentid", r("parentid")},
                                        {"@id", r("id")}
                                    }
                                Await _Database.ExecuteUpdateAsync("agentevent", Values, "id = @id", Args)
                            Next r
                        End If
                    Next Row
                    For Each Row As DataRow In Data.Rows.Cast(Of DataRow).Where(Function(x) Not CBool(x("issaved")))
                        Row("issaved") = True
                    Next
                    Scope.Complete()
                End Using
            Catch ex As Exception
                WriteSingle(New EventInitialModel($"Ocorreu um erro ao salvar os eventos - {ex.Message}"), Data)
            Finally
                _Semaphore.Release()
            End Try
        End If
    End Function
    Public Async Function Read() As Task(Of DataTable)
        Dim TableParent As DataTable
        Dim TableChild As DataTable
        Dim TableAll As New DataTable
        Dim NewRow As DataRow
        Dim Columns As List(Of String)
        Dim Args As Dictionary(Of String, Object)
        _Semaphore.Wait()
        Try
            Using Scope As New TransactionScope(TransactionScopeAsyncFlowOption.Enabled)
                Columns = New List(Of String) From {"id", "parentid", "eventtype", "time", "description"}
                Args = New Dictionary(Of String, Object) From {{"@eventtype", EventTypes.Initial}}
                Dim Result = Await _Database.ExecuteSelectAsync("agentevent", Columns, " eventtype = @eventtype", Args, "id DESC", 10)
                TableParent = Util.DictionariesToDataTable(Result.Data)
                For Each Column As String In Columns
                    TableAll.Columns.Add(Column)
                Next Column
                TableAll.Columns.Add("issaved")
                TableAll.Columns.Add("tempid")
                For Each ParentRow As DataRow In TableParent.Rows
                    Args = New Dictionary(Of String, Object) From {{"@parentid", ParentRow.Item("id")}}
                    Result = Await _Database.ExecuteSelectAsync("agentevent", Columns, "parentid = @parentid", Args, "id DESC")
                    TableChild = Util.DictionariesToDataTable(Result.Data)
                    For Each ChildRow As DataRow In TableChild.Rows
                        If ChildRow.Item("eventtype") = EventTypes.Child Then
                            ChildRow.Item("Description") = $"{Constants.SubItemSymbol} {ChildRow.Item("Description")}"
                        End If
                        NewRow = TableAll.NewRow()
                        NewRow.Item("id") = ChildRow.Item("id")
                        NewRow.Item("parentid") = ChildRow.Item("parentid")
                        NewRow.Item("eventtype") = ChildRow.Item("eventtype")
                        NewRow.Item("time") = ChildRow.Item("time")
                        NewRow.Item("description") = ChildRow.Item("description")
                        NewRow.Item("issaved") = True
                        TableAll.Rows.Add(NewRow)
                    Next ChildRow
                    NewRow = TableAll.NewRow()
                    NewRow.Item("id") = ParentRow.Item("id")
                    NewRow.Item("parentid") = ParentRow.Item("parentid")
                    NewRow.Item("eventtype") = ParentRow.Item("eventtype")
                    NewRow.Item("time") = ParentRow.Item("time")
                    NewRow.Item("description") = ParentRow.Item("description")
                    NewRow.Item("issaved") = True
                    TableAll.Rows.Add(NewRow)
                Next ParentRow
                Scope.Complete()
                Return TableAll
            End Using

        Catch ex As Exception
            CMessageBox.Show("Erro ao ler", "Ocorreu um erro ao ler os eventos.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Return New DataTable()
        Finally
            _Semaphore.Release()
        End Try
    End Function
End Class