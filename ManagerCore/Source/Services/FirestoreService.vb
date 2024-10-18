Imports Google.Apis.Auth.OAuth2
Imports Google.Cloud.Firestore
Public Class FirestoreService
    Inherits RemoteDB

    Private _Listener As FirestoreChangeListener
    Private _Database As FirestoreDb

    Public Sub New()
    End Sub

    Public Overrides Async Function Initialize(Settings As SettingCloudManagerDatabaseModel) As Task
        Dim Json As String = Settings.JsonCredentials
        Dim Credential As GoogleCredential = GoogleCredential.FromJson(Json)
        Dim builder = New FirestoreDbBuilder() With {
            .ProjectId = Settings.ProjectID,
            .Credential = Credential
        }
        _Database = Await builder.BuildAsync()
    End Function

    Public Overrides Async Function TestConnection() As Task
        If _Database IsNot Nothing Then
            Dim List = _Database.ListRootCollectionsAsync()
            Dim Count = Await List.CountAsync()
            If Count = 0 Then Throw New Exception("Erro ao obter dados do banco de dados na núvem")
        Else
            Throw New Exception("O banco de dados não foi definido.")
        End If
    End Function

    Public Overrides Sub StartListening(Collection As String, Optional Args As List(Of Condition) = Nothing)
        Dim Query As Query = _Database.Collection(Collection)
        If Args IsNot Nothing Then Query = ProcessArgs(Query, Args)
        _Listener = Query.Listen(Sub(Snapshot As QuerySnapshot)
                                     HandleSnapshotAsync(Collection, Snapshot)
                                 End Sub)
    End Sub



    Private Sub HandleSnapshotAsync(Collection As String, Snapshot As QuerySnapshot)
        Dim EventArgs As New FirestoreChangeEventArgs() With {
            .CollectionName = Collection,
            .Documents = Snapshot.Documents.Select(Function(doc) doc.ToDictionary()).ToList()
        }
        RaiseOnFirestoreChanged(EventArgs)
    End Sub

    Public Overrides Sub StopListening()
        _Listener?.StopAsync()
    End Sub
    Public Class FirestoreChangeEventArgs
        Public Property CollectionName As String
        Public Property Documents As List(Of Dictionary(Of String, Object))
    End Class
    Public Overrides Async Function ExecuteGet(Collection As String, Optional Args As List(Of Condition) = Nothing) As Task(Of List(Of Dictionary(Of String, Object)))
        Dim QueryRef As Query = _Database.Collection(Collection)
        If Args IsNot Nothing Then QueryRef = ProcessArgs(QueryRef, Args)
        Dim Snapshot = Await QueryRef.GetSnapshotAsync()
        Dim Result As New List(Of Dictionary(Of String, Object))()
        For Each Doc As DocumentSnapshot In Snapshot.Documents
            Result.Add(Doc.ToDictionary())
        Next Doc
        Return Result
    End Function

    Public Overrides Async Function ExecuteDelete(Collection As String, Optional Args As List(Of Condition) = Nothing) As Task(Of Integer)
        Dim QueryRef As Query = _Database.Collection(Collection)
        If Args IsNot Nothing Then QueryRef = ProcessArgs(QueryRef, Args)
        Dim Snapshot = Await QueryRef.GetSnapshotAsync()
        Dim DeletedCount As Integer = 0
        For Each Doc As DocumentSnapshot In Snapshot.Documents
            Await Doc.Reference.DeleteAsync()
            DeletedCount += 1
        Next
        Return DeletedCount
    End Function

    Public Overrides Async Function ExecutePut(Collection As String, Data As Dictionary(Of String, Object), Optional DocumentID As String = Nothing) As Task(Of DateTime)
        Dim DocRef As DocumentReference = If(Not String.IsNullOrEmpty(DocumentID), _Database.Collection(Collection).Document(DocumentID), _Database.Collection(Collection).Document())
        Dim Result As WriteResult = Await DocRef.SetAsync(Data)
        Return Result.UpdateTime.ToDateTime
    End Function
    Private Function ProcessArgs(Query As Query, Args As List(Of Condition)) As Query
        For Each Arg In Args
            Select Case Arg.GetType
                Case GetType(WhereEqualToCondition)
                    Dim ConvertedArg = CType(Arg, FieldValueCondition)
                    Query = Query.WhereEqualTo(ConvertedArg.Field, ConvertedArg.Value)
                Case GetType(WhereNotEqualToCondition)
                    Dim ConvertedArg = CType(Arg, FieldValueCondition)
                    Query = Query.WhereNotEqualTo(ConvertedArg.Field, ConvertedArg.Value)
                Case GetType(WhereGreaterThanCondition)
                    Dim ConvertedArg = CType(Arg, FieldValueCondition)
                    Query = Query.WhereGreaterThan(ConvertedArg.Field, ConvertedArg.Value)
                Case GetType(WhereGreaterThanOrEqualToCondition)
                    Dim ConvertedArg = CType(Arg, FieldValueCondition)
                    Query = Query.WhereGreaterThanOrEqualTo(ConvertedArg.Field, ConvertedArg.Value)
                Case GetType(WhereLessThanCondition)
                    Dim ConvertedArg = CType(Arg, FieldValueCondition)
                    Query = Query.WhereLessThan(ConvertedArg.Field, ConvertedArg.Value)
                Case GetType(WhereLessThanOrEqualToCondition)
                    Dim ConvertedArg = CType(Arg, FieldValueCondition)
                    Query = Query.WhereLessThanOrEqualTo(ConvertedArg.Field, ConvertedArg.Value)
                Case GetType(WhereInCondition)
                    Dim ConvertedArg = CType(Arg, FieldValuesCondition)
                    Query = Query.WhereIn(ConvertedArg.Field, ConvertedArg.Values)
                Case GetType(WhereNotInCondition)
                    Dim ConvertedArg = CType(Arg, FieldValuesCondition)
                    Query = Query.WhereNotIn(ConvertedArg.Field, ConvertedArg.Values)
                Case GetType(OrderByCondition)
                    Dim ConvertedArg = CType(Arg, OrderByCondition)
                    If ConvertedArg.Ascending Then
                        Query = Query.OrderBy(ConvertedArg.Field)
                    Else
                        Query = Query.OrderByDescending(ConvertedArg.Field)
                    End If
                Case GetType(LimitCondition)
                    Dim ConvertedArg = CType(Arg, LimitCondition)
                    Query = Query.Limit(ConvertedArg.Limit)
            End Select
        Next Arg
        Return Query
    End Function
End Class
