Imports Google.Apis.Auth.OAuth2
Imports Google.Cloud.Firestore
Public Class FirestoreService
    Inherits RemoteDB

    Private _Listeners As New Dictionary(Of String, FirestoreChangeListener)



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

        ' Gera uma chave única para o listener
        Dim ListenerKey As String = GenerateListenerKey(Collection, Args)

        ' Se já existe um listener para esta chave, para o anterior
        If _Listeners.ContainsKey(ListenerKey) Then
            StopListening(ListenerKey)
        End If

        ' Adiciona o novo listener ao dicionário
        Dim Listener As FirestoreChangeListener = Query.Listen(Sub(Snapshot As QuerySnapshot)
                                                                   HandleSnapshotAsync(Collection, Snapshot)
                                                               End Sub)
        _Listeners(ListenerKey) = Listener
    End Sub

    Private Sub HandleSnapshotAsync(Collection As String, Snapshot As QuerySnapshot)
        Dim EventArgs As New FirestoreChangeEventArgs() With {
            .CollectionName = Collection,
            .Documents = Snapshot.Documents.Select(Function(doc) doc.ToDictionary()).ToList()
        }
        RaiseOnFirestoreChanged(EventArgs)
    End Sub

    Public Overrides Sub StopListening(Optional ListenerKey As String = Nothing)
        If ListenerKey Is Nothing Then
            ' Para todos os listeners se nenhuma chave for fornecida
            For Each Listener In _Listeners.Values
                Listener.StopAsync()
            Next
            _Listeners.Clear()
        ElseIf _Listeners.ContainsKey(ListenerKey) Then
            ' Para um listener específico
            _Listeners(ListenerKey).StopAsync()
            _Listeners.Remove(ListenerKey)
        End If
    End Sub

    ' Gera uma chave única para cada listener com base na coleção e argumentos
    Private Function GenerateListenerKey(Collection As String, Args As List(Of Condition)) As String
        If Args Is Nothing Then Return Collection
        Dim ConditionsString As String = String.Join("_", Args.Select(Function(arg) DescribeCondition(arg)))
        Return $"{Collection}_{ConditionsString}"
    End Function

    ' Converte uma Condition em uma descrição única para a chave
    Private Function DescribeCondition(condition As Condition) As String
        Select Case True
            Case TypeOf condition Is WhereEqualToCondition
                Dim c = DirectCast(condition, WhereEqualToCondition)
                Return $"WhereEqualTo-{c.Field}-{c.Value}"
            Case TypeOf condition Is WhereNotEqualToCondition
                Dim c = DirectCast(condition, WhereNotEqualToCondition)
                Return $"WhereNotEqualTo-{c.Field}-{c.Value}"
            Case TypeOf condition Is WhereGreaterThanCondition
                Dim c = DirectCast(condition, WhereGreaterThanCondition)
                Return $"WhereGreaterThan-{c.Field}-{c.Value}"
            Case TypeOf condition Is WhereGreaterThanOrEqualToCondition
                Dim c = DirectCast(condition, WhereGreaterThanOrEqualToCondition)
                Return $"WhereGreaterThanOrEqualTo-{c.Field}-{c.Value}"
            Case TypeOf condition Is WhereLessThanCondition
                Dim c = DirectCast(condition, WhereLessThanCondition)
                Return $"WhereLessThan-{c.Field}-{c.Value}"
            Case TypeOf condition Is WhereLessThanOrEqualToCondition
                Dim c = DirectCast(condition, WhereLessThanOrEqualToCondition)
                Return $"WhereLessThanOrEqualTo-{c.Field}-{c.Value}"
            Case TypeOf condition Is WhereInCondition
                Dim c = DirectCast(condition, WhereInCondition)
                Return $"WhereIn-{c.Field}-[{String.Join(",", c.Values.Cast(Of Object)())}]"
            Case TypeOf condition Is WhereNotInCondition
                Dim c = DirectCast(condition, WhereNotInCondition)
                Return $"WhereNotIn-{c.Field}-[{String.Join(",", c.Values.Cast(Of Object)())}]"
            Case TypeOf condition Is OrderByCondition
                Dim c = DirectCast(condition, OrderByCondition)
                Return $"OrderBy-{c.Field}-{c.Ascending}"
            Case TypeOf condition Is LimitCondition
                Dim c = DirectCast(condition, LimitCondition)
                Return $"Limit-{c.Limit}"
            Case Else
                Return "UnknownCondition"
        End Select
    End Function







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
            Dim DocData As Dictionary(Of String, Object) = Doc.ToDictionary()
            DocData("document_id") = Doc.Id
            Result.Add(DocData)
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
