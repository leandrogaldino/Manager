Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient

Public Class VisitSchedule
    Inherits ParentModel
    Private _RemoteDB As RemoteDB
    Private _ID As String
    Private _Evaluation As Lazy(Of Evaluation)


    Public Overloads ReadOnly Property ID As String
        Get
            Return _ID
        End Get
    End Property
    Public Property Status As VisitScheduleStatus
    Public Property VisitType As VisitScheduleType
    Public Property VisitDate As Date
    Public Property Customer As New Person
    Public Property Compressor As New PersonCompressor
    Public Property Instructions As String
    Public ReadOnly Property Evaluation As Lazy(Of Evaluation)
        Get
            Return _Evaluation
        End Get
    End Property

    Public Sub New()
        SetRoutine(Routine.VisitSchedule)
        Status = VisitScheduleStatus.Pending
        VisitType = VisitScheduleType.None
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        VisitDate = Today
    End Sub

    Public Overloads Sub SetID(ID As String)
        _ID = ID
    End Sub
    Public Sub SetEvaluation(EvaluationID As Long)
        If EvaluationID > 0 Then
            _Evaluation = New Lazy(Of Evaluation)(Function() New Evaluation().Load(EvaluationID, True))
        Else
            _Evaluation = New Lazy(Of Evaluation)
        End If
    End Sub

    Public Sub FromCloud(Data As Dictionary(Of String, Object))
        Customer = New Person().Load(Convert.ToInt64(Data("customer_id")), False)
        Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = Convert.ToInt64(Data("compressor_id")))
        Instructions = Convert.ToString(Data("instructions"))
        Status = Convert.ToInt32(Data("status_id"))
        VisitType = Convert.ToInt32(Data("visit_type_id"))
        VisitDate = Convert.ToDateTime(Data("visit_date"))
        SetID(Convert.ToString(Data("document_id")))
        SetCreation(Convert.ToDateTime(Data("creation_date")))
        SetIsSaved(True)
        If Convert.ToInt32(Data("evaluation_id")) > 0 Then
            SetEvaluation(Convert.ToInt64(Data("evaluation_id")))
        End If
    End Sub

    Public Function ToCloud() As Dictionary(Of String, Object)
        Dim Data As New Dictionary(Of String, Object) From {
            {"document_id", ID},
            {"creation_date", Creation.ToString("yyyy-MM-dd")},
            {"status_id", Convert.ToInt32(Status)},
            {"visit_type_id", Convert.ToInt32(VisitType)},
            {"visit_date", VisitDate.ToString("yyyy-MM-dd")},
            {"customer_id", Customer.ID},
            {"compressor_id", Compressor.ID},
            {"instructions", Instructions},
            {"evaluation_id", If(Evaluation IsNot Nothing AndAlso Evaluation.Value IsNot Nothing, Evaluation.Value.ID, 0)}
        }
        Return Data
    End Function
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        SetEvaluation(0)
        Status = VisitScheduleStatus.Pending
        VisitDate = Today
        Customer = New Person()
        Compressor = New PersonCompressor()
        Instructions = Nothing
    End Sub
    Public Function Load(Identity As String, LockMe As Boolean) As VisitSchedule
        Dim Conditions As New List(Of RemoteDB.Condition) From {
            New RemoteDB.WhereEqualToCondition("document_id", Identity)
        }
        Dim Result As List(Of Dictionary(Of String, Object)) = ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecuteGet("schedule", Conditions))
        If Result.Count = 1 Then
            Dim RemoteVisit As Dictionary(Of String, Object) = Result(0)
            Clear()
            FromCloud(RemoteVisit)
            LockInfo = GetLockInfo()
            If LockMe AndAlso Not LockInfo.IsLocked Then Lock()
        Else
            Clear()
            Throw New Exception("Registro não encontrado.")
        End If
        Return Me
    End Function

    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.VisitScheduleDelete, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim TempID As String = $"{Now.Ticks}{Guid.NewGuid()}"
        Dim Data As Dictionary(Of String, Object) = ToCloud()
        Data("document_id") = TempID
        ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecutePut("schedule", Data, Data("document_id")))
        SetID(TempID)
    End Sub
    Private Sub Update()
        Dim Data As Dictionary(Of String, Object) = ToCloud()
        ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecutePut("schedule", Data, Data("document_id")))
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Customer.Name}: {Compressor.Compressor.Name}{If(Not String.IsNullOrEmpty(Compressor.SerialNumber), $" {Compressor.SerialNumber}", {String.Empty})}"
    End Function
End Class
