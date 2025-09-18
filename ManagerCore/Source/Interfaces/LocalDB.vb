Imports System.Data.Common
Public MustInherit Class LocalDB
    MustOverride Sub Initialize(DatabaseSettings As SettingDatabaseModel)
    MustOverride Function GetConnection() As DbConnection
    MustOverride Async Function BeginTransactionAsync() As Task
    MustOverride Sub BeginTransaction()
    MustOverride Async Function CommitTransactionAsync() As Task
    MustOverride Sub CommitTransaction()
    MustOverride Async Function ExecuteRawQueryAsync(Query As String, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
    MustOverride Function ExecuteRawQuery(Query As String, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
    MustOverride Async Function ExecuteSelectAsync(Table As String, Optional Columns As List(Of String) = Nothing, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing, Optional OrderBy As String = Nothing, Optional Limit As Integer = Nothing) As Task(Of QueryResult)
    MustOverride Function ExecuteSelect(Table As String, Optional Columns As List(Of String) = Nothing, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing, Optional OrderBy As String = Nothing, Optional Limit As Integer = Nothing) As QueryResult
    MustOverride Async Function ExecuteInsertAsync(Table As String, Values As Dictionary(Of String, String), Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
    MustOverride Function ExecuteInsert(Table As String, Values As Dictionary(Of String, String), Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
    MustOverride Async Function ExecuteDeleteAsync(Table As String, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
    MustOverride Function ExecuteDelete(Table As String, Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
    MustOverride Async Function ExecuteUpdateAsync(Table As String, Values As Dictionary(Of String, String), Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
    MustOverride Function ExecuteUpdate(Table As String, Values As Dictionary(Of String, String), Optional Where As String = Nothing, Optional QueryArgs As Dictionary(Of String, Object) = Nothing) As QueryResult
    MustOverride Async Function ExecuteBackupAsync(FilePath As String, Optional Progress As IProgress(Of Integer) = Nothing) As Task
    MustOverride Sub ExecuteBackup(FilePath As String)
    MustOverride Async Function ExecuteRestoreAsync(FilePath As String, Optional Progress As IProgress(Of Integer) = Nothing) As Task
    MustOverride Sub ExecuteRestore(FilePath As String)
    MustOverride Function ExecuteProcedureAsync(ProcedureName As String, Optional Params As Dictionary(Of String, Object) = Nothing) As Task(Of QueryResult)
    MustOverride Function ExecuteProcedure(ProcedureName As String, Optional Params As Dictionary(Of String, Object) = Nothing) As QueryResult


    Public Class QueryResult
        Private _Data As List(Of Dictionary(Of String, Object))
        Private _AffectedRows As Long
        Private _LastInsertedID As Long

        Public Sub New(Optional Data As List(Of Dictionary(Of String, Object)) = Nothing, Optional AffectedRows As Long = 0, Optional LastInsertedID As Long = 0)
            _Data = Data
            _AffectedRows = AffectedRows
            _LastInsertedID = LastInsertedID
        End Sub

        Public ReadOnly Property LastInsertedID As Long
            Get
                Return _LastInsertedID
            End Get
        End Property

        Public ReadOnly Property AffectedRows As Long
            Get
                Return _AffectedRows
            End Get
        End Property

        Public ReadOnly Property HasData As Boolean
            Get
                If Data IsNot Nothing AndAlso Data.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
        Public ReadOnly Property Data As List(Of Dictionary(Of String, Object))
            Get
                Return _Data
            End Get
        End Property
    End Class


End Class
