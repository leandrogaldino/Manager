Public Class EventBuilder
    Private _InitialEvent As EventInitialModel
    Private _ChildEvents As List(Of EventChildModel)
    Private _FinalEvent As EventFinalModel

    Public ReadOnly Property IsInitialized As Boolean
        Get
            Return _InitialEvent IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property IsFinished As Boolean
        Get
            Return _FinalEvent IsNot Nothing
        End Get
    End Property

    Public Sub SetInitialEvent(InitialEvent As String)
        _InitialEvent = New EventInitialModel(InitialEvent)
    End Sub
    Public Function GetInitialEvent() As EventInitialModel
        Return _InitialEvent
    End Function

    Public Sub SetFinalEvent(FinalEvent As String)
        If _FinalEvent IsNot Nothing Then
            Throw New InvalidOperationException("O evento final já foi definido.")
        ElseIf _InitialEvent Is Nothing Then
            Throw New InvalidOperationException("O evento inicial não foi definido.")
        Else
            _FinalEvent = New EventFinalModel(FinalEvent) With {.TempID = _InitialEvent.TempID}
        End If
    End Sub
    Public Function GetFinalEvent() As EventFinalModel
        Return _FinalEvent
    End Function

    Public Sub AddChildEvent(ChildEvent As String)
        If _InitialEvent IsNot Nothing Then
            If _ChildEvents Is Nothing Then _ChildEvents = New List(Of EventChildModel)
            Dim Model As New EventChildModel(ChildEvent)
            _ChildEvents.Add(Model)
            Model.TempID = _InitialEvent.TempID
        Else
            Throw New InvalidOperationException("O evento inicial não foi definido.")
        End If
    End Sub
    Public Function GetChildEvents() As List(Of EventChildModel)
        If _ChildEvents Is Nothing Then
            Return New List(Of EventChildModel)()
        Else
            SyncLock _ChildEvents
                Return New List(Of EventChildModel)(_ChildEvents)
            End SyncLock
        End If
    End Function

End Class
