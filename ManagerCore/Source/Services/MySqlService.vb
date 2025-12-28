Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Public Class MySqlService
    Inherits LocalDB
    Private _DatabaseSettings As CompanyDatabaseModel
    Public Overrides Sub Initialize(DatabaseSettings As CompanyDatabaseModel)
        _DatabaseSettings = DatabaseSettings
    End Sub
    Public Overrides Function GetConnection() As Common.DbConnection
        Return New MySqlConnection(_DatabaseSettings.GetConnectionString())
    End Function


    Public Overrides Async Function ExecuteRestoreAsync(FilePath As String, Optional Progress As IProgress(Of Integer) = Nothing) As Task
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(Nothing, Connection)
                Using Bkp As New MySqlBackup(Cmd)
                    Bkp.ImportInfo.IntervalForProgressReport = 1
                    AddHandler Bkp.ImportProgressChanged, Sub(BkpSender, BkpEventArgs)
                                                              Dim TotalBytes As Long = New FileInfo(FilePath).Length
                                                              Dim CurrentBytes = BkpEventArgs.CurrentBytes
                                                              Dim Percent As Integer = (CurrentBytes / TotalBytes) * 100
                                                              Progress?.Report(Percent)
                                                          End Sub
                    AddHandler Bkp.ImportCompleted, Sub(BkpSender, BkpEventArgs)
                                                        Progress?.Report(100)
                                                    End Sub
                    If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                    Bkp.ImportFromFile(FilePath)
                End Using
            End Using
        End Using
    End Function
    Public Overrides Sub ExecuteRestore(FilePath As String)
        Util.AsyncLock(Function() ExecuteRestoreAsync(FilePath))
    End Sub
    Public Overrides Async Function ExecuteBackupAsync(FilePath As String, Optional Progress As IProgress(Of Integer) = Nothing) As Task
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(Nothing, Connection)
                Using Bkp As New MySqlBackup(Cmd)
                    Bkp.ExportInfo.IntervalForProgressReport = 1
                    AddHandler Bkp.ExportProgressChanged, Sub(BkpSender, BkpEventArgs)
                                                              Dim TotalRows As Long = BkpEventArgs.TotalRowsInAllTables
                                                              Dim CurrentRow = BkpEventArgs.CurrentRowIndexInAllTables
                                                              Dim Percent As Integer = (CurrentRow / TotalRows) * 100
                                                              Progress?.Report(Percent)
                                                          End Sub
                    AddHandler Bkp.ExportCompleted, Sub(BkpSender, BkpEventArgs)
                                                        Progress?.Report(100)
                                                    End Sub
                    If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                    Using Stream As New FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, True)
                        Bkp.ExportToStream(Stream)
                        Await Stream.FlushAsync()
                    End Using
                End Using
            End Using
        End Using
    End Function
    Public Overrides Sub ExecuteBackup(FilePath As String)
        Util.AsyncLock(Function() ExecuteBackupAsync(FilePath))
    End Sub

    Public Overrides Async Function ExecuteSelectAsync(Table As String, Optional Columns As List(Of String) = Nothing, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing, Optional OrderBy As String = Nothing, Optional Limit As Integer = Nothing) As Task(Of QueryResult)
        Dim Data As New List(Of Dictionary(Of String, Object))
        Dim Item As Dictionary(Of String, Object)
        Dim Query As String = "SELECT "
        If Columns IsNot Nothing AndAlso Columns.Count > 0 Then
            Query &= String.Join(", ", Columns)
        Else
            Query &= "* "
        End If
        Query &= $" FROM {Table} "
        If Not String.IsNullOrEmpty(Where) Then
            Query &= $"WHERE {Where} "
        End If
        If Not String.IsNullOrEmpty(OrderBy) Then
            Query &= $"ORDER BY {OrderBy} "
        End If
        If Limit <> Nothing Then
            Query &= $"LIMIT {Limit} "
        End If
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(Query, Connection)
                If QueryArgs IsNot Nothing AndAlso QueryArgs.Count > 0 Then
                    For Each Arg In QueryArgs
                        Cmd.Parameters.AddWithValue(Arg.Key, If(Arg.Value, DBNull.Value))
                    Next Arg
                End If
                If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                Using reader = Await Cmd.ExecuteReaderAsync()
                    While Await reader.ReadAsync()
                        Item = New Dictionary(Of String, Object)
                        For i = 0 To reader.FieldCount - 1
                            Item.Add(reader.GetName(i), reader.GetValue(i))
                        Next
                        Data.Add(Item)
                    End While
                End Using
            End Using
        End Using
        Return New QueryResult(Data, 0)
    End Function
    Public Overrides Function ExecuteSelect(Table As String, Optional Columns As List(Of String) = Nothing, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing, Optional OrderBy As String = Nothing, Optional Limit As Integer = 0) As QueryResult
        Return Util.AsyncLock(Function() ExecuteSelectAsync(Table, Columns, Where, QueryArgs, OrderBy, Limit))
    End Function
    Public Overrides Async Function ExecuteInsertAsync(Table As String, Values As Dictionary(Of String, String), Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
        Dim Query As String = $"INSERT INTO {Table} ({String.Join(", ", Values.Keys)}) VALUES ({String.Join(", ", Values.Values)})"
        Dim AffectedRows As Integer
        Dim LastInsertedRow As Integer
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(Query, Connection)
                If QueryArgs IsNot Nothing AndAlso QueryArgs.Count > 0 Then
                    For Each Arg In QueryArgs
                        Cmd.Parameters.AddWithValue(Arg.Key, If(Arg.Value, DBNull.Value))
                    Next Arg
                End If
                If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                AffectedRows = Await Cmd.ExecuteNonQueryAsync()
                LastInsertedRow = Cmd.LastInsertedId
            End Using
        End Using
        Return New QueryResult(Nothing, AffectedRows, LastInsertedRow)
    End Function
    Public Overrides Function ExecuteInsert(Table As String, Values As Dictionary(Of String, String), Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
        Return Util.AsyncLock(Function() ExecuteInsertAsync(Table, Values, QueryArgs))
    End Function
    Public Overrides Async Function ExecuteUpdateAsync(Table As String, Values As Dictionary(Of String, String), Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
        Dim Query As String = $"UPDATE {Table} SET "
        Dim ValuesList As New List(Of String)
        Dim AffectedRows As Integer
        For Each Value In Values
            ValuesList.Add($"{Value.Key} = {Value.Value}")
        Next Value
        Query &= String.Join(" ,", ValuesList)
        If Not String.IsNullOrEmpty(Where) Then
            Query &= $" WHERE {Where}"
        End If
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(Query, Connection)
                If QueryArgs IsNot Nothing AndAlso QueryArgs.Count > 0 Then
                    For Each Arg In QueryArgs
                        Cmd.Parameters.AddWithValue(Arg.Key, If(Arg.Value, DBNull.Value))
                    Next Arg
                End If
                If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                AffectedRows = Await Cmd.ExecuteNonQueryAsync()
            End Using
        End Using
        Return New QueryResult(Nothing, AffectedRows)
    End Function
    Public Overrides Function ExecuteUpdate(Table As String, Values As Dictionary(Of String, String), Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
        Return Util.AsyncLock(Function() ExecuteUpdateAsync(Table, Values, Where, QueryArgs))
    End Function
    Public Overrides Async Function ExecuteDeleteAsync(Table As String, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
        Dim Query As String = $"DELETE FROM {Table} "
        Dim AffectedRows As Integer
        If Not String.IsNullOrEmpty(Where) Then
            Query &= $"WHERE {Where}"
        End If
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(Query, Connection)
                If QueryArgs IsNot Nothing AndAlso QueryArgs.Count > 0 Then
                    For Each Arg In QueryArgs
                        Cmd.Parameters.AddWithValue(Arg.Key, If(Arg.Value, DBNull.Value))
                    Next Arg
                End If
                If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                AffectedRows = Await Cmd.ExecuteNonQueryAsync()
            End Using
        End Using
        Return New QueryResult(Nothing, AffectedRows)
    End Function
    Public Overrides Function ExecuteDelete(Table As String, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
        Return Util.AsyncLock(Function() ExecuteDeleteAsync(Table, Where, QueryArgs))
    End Function
    Public Overrides Async Function ExecuteRawQueryAsync(Query As String, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
        Dim isSelect As Boolean = Query.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase)
        Dim AffectedRows As Integer = 0
        Dim Data As List(Of Dictionary(Of String, Object)) = Nothing
        Dim Item As Dictionary(Of String, Object)
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(Query, Connection)
                If QueryArgs IsNot Nothing AndAlso QueryArgs.Count > 0 Then
                    For Each Arg In QueryArgs
                        Cmd.Parameters.AddWithValue(Arg.Key, If(Arg.Value, DBNull.Value))
                    Next Arg
                End If
                If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                If isSelect Then
                    Data = New List(Of Dictionary(Of String, Object))()
                    Using Reader = Await Cmd.ExecuteReaderAsync()
                        While Await Reader.ReadAsync()
                            Item = New Dictionary(Of String, Object)
                            For i = 0 To Reader.FieldCount - 1
                                Item.Add(Reader.GetName(i), Reader.GetValue(i))
                            Next
                            Data.Add(Item)
                        End While
                    End Using
                Else
                    AffectedRows = Await Cmd.ExecuteNonQueryAsync()
                End If
            End Using
        End Using
        Return New QueryResult(Data, AffectedRows)
    End Function
    Public Overrides Function ExecuteRawQuery(Query As String, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
        Return Util.AsyncLock(Function() ExecuteRawQueryAsync(Query, QueryArgs))
    End Function
    Public Overrides Function ExecuteProcedure(ProcedureName As String, Optional Params As Dictionary(Of String, Object) = Nothing) As QueryResult
        Return Util.AsyncLock(Function() ExecuteProcedureAsync(ProcedureName, Params))
    End Function
    Public Overrides Async Function ExecuteProcedureAsync(ProcedureName As String, Optional Params As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
        Dim Data As List(Of Dictionary(Of String, Object)) = Nothing
        Dim Item As Dictionary(Of String, Object)
        Using Connection As New MySqlConnection(_DatabaseSettings.GetConnectionString())
            Using Cmd As New MySqlCommand(ProcedureName, Connection)
                Cmd.CommandType = CommandType.StoredProcedure
                If Params IsNot Nothing Then
                    For Each Arg In Params
                        Cmd.Parameters.AddWithValue(Arg.Key, If(Arg.Value, DBNull.Value))
                    Next
                End If
                If Connection.State <> ConnectionState.Open Then Await Connection.OpenAsync()
                Data = New List(Of Dictionary(Of String, Object))
                Using Reader = Await Cmd.ExecuteReaderAsync()
                    While Await Reader.ReadAsync()
                        Item = New Dictionary(Of String, Object)
                        For i = 0 To Reader.FieldCount - 1
                            Item.Add(Reader.GetName(i), Reader.GetValue(i))
                        Next
                        Data.Add(Item)
                    End While
                End Using
            End Using
        End Using
        Return New QueryResult(Data, 0)
    End Function
End Class
