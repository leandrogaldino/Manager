Imports ManagerCore.FirestoreService

Public MustInherit Class RemoteDB
    Event OnFirestoreChanged(args As FirestoreChangeEventArgs)
    Protected Sub RaiseOnFirestoreChanged(Args As FirestoreChangeEventArgs)
        RaiseEvent OnFirestoreChanged(Args)
    End Sub
    MustOverride Async Function Initialize(Settings As SettingCloudManagerDatabaseModel) As Task
    MustOverride Async Function TestConnection() As Task
    MustOverride Async Function ExecuteGet(Collection As String, Optional Args As List(Of Condition) = Nothing) As Task(Of List(Of Dictionary(Of String, Object)))
    MustOverride Async Function ExecuteDelete(Collection As String, Optional Args As List(Of Condition) = Nothing) As Task(Of Integer)
    MustOverride Async Function ExecutePut(Collection As String, Data As Dictionary(Of String, Object), Optional DocumentID As String = Nothing) As Task(Of DateTime)
    MustOverride Sub StartListening(Collection As String, Optional Args As List(Of Condition) = Nothing)
    MustOverride Sub StopListening()
    MustInherit Class Condition : End Class
    MustInherit Class FieldValueCondition
        Inherits Condition
        Public ReadOnly Property Field As String
        Public ReadOnly Property Value As Object
        Public Sub New(Field As String, Value As Object)
            Me.Field = Field
            Me.Value = Value
        End Sub
    End Class
    MustInherit Class FieldValuesCondition
        Inherits Condition
        Public ReadOnly Property Field As String
        Public ReadOnly Property Values As IEnumerable
        Public Sub New(Field As String, Values As IEnumerable)
            Me.Field = Field
            Me.Values = Values
        End Sub
    End Class
    Public Class WhereNotEqualToCondition
        Inherits FieldValueCondition

        Public Sub New(Field As String, Value As Object)
            MyBase.New(Field, Value)
        End Sub
    End Class
    Public Class WhereEqualToCondition
        Inherits FieldValueCondition
        Public Sub New(Field As String, Value As Object)
            MyBase.New(Field, Value)
        End Sub
    End Class
    Public Class WhereGreaterThanCondition
        Inherits FieldValueCondition

        Public Sub New(Field As String, Value As Object)
            MyBase.New(Field, Value)
        End Sub
    End Class
    Public Class WhereGreaterThanOrEqualToCondition
        Inherits FieldValueCondition

        Public Sub New(Field As String, Value As Object)
            MyBase.New(Field, Value)
        End Sub
    End Class
    Public Class WhereLessThanCondition
        Inherits FieldValueCondition

        Public Sub New(Field As String, Value As Object)
            MyBase.New(Field, Value)
        End Sub
    End Class
    Public Class WhereLessThanOrEqualToCondition
        Inherits FieldValueCondition

        Public Sub New(Field As String, Value As Object)
            MyBase.New(Field, Value)
        End Sub
    End Class
    Public Class WhereInCondition
        Inherits FieldValuesCondition

        Public Sub New(Field As String, Values As IEnumerable)
            MyBase.New(Field, Values)
        End Sub
    End Class

    Public Class WhereNotInCondition
        Inherits FieldValuesCondition

        Public Sub New(Field As String, Values As IEnumerable)
            MyBase.New(Field, Values)
        End Sub
    End Class
    Public Class OrderByCondition
        Inherits Condition
        Public ReadOnly Property Field As String
        Public ReadOnly Property Ascending As String
        Public Sub New(Field As String, Optional Ascending As Boolean = True)
            Me.Field = Field
            Me.Ascending = Ascending
        End Sub
    End Class


    Public Class LimitCondition
        Inherits Condition
        Public ReadOnly Property Limit As Integer

        Public Sub New(Limit As Integer)
            Me.Limit = Limit
        End Sub
    End Class

End Class
