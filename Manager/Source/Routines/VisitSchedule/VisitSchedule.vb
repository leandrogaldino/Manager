Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient

Public Class VisitSchedule
    Inherits ParentModel
    Private ReadOnly _RemoteDB As RemoteDB
    Public Property Status As VisitScheduleStatus = VisitScheduleStatus.Pending
    Public Property CallType As CallType = CallType.None
    Public Property ScheduledDate As Date = Now.AddHours(1)
    Public Property PerformedDate As Date? = Nothing
    Public Property Customer As New Person
    Public Property Compressor As New PersonCompressor
    Public Property Technician As New Person
    Public Property Instructions As String
    Public Property EvaluationID As Long
    Public Property Evaluation As New Lazy(Of Evaluation)
    Public Property OverridedVisitScheduleID As Long
    Public Property OverridedVisitSchedule As New Lazy(Of VisitSchedule)
    Public Sub New()
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        SetRoutine(Routine.VisitSchedule)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = VisitScheduleStatus.Pending
        ScheduledDate = Now
        PerformedDate = Nothing
        Customer = New Person()
        Compressor = New PersonCompressor()
        Technician = New Person()
        Instructions = Nothing
        Evaluation = Nothing
        OverridedVisitSchedule = Nothing
        If LockInfo.IsLocked Then Unlock()
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As VisitSchedule
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.VisitScheduleSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        SetID(Convert.ToInt64(TableResult.Rows(0).Item("id")))
                        SetCreation(Convert.ToDateTime(TableResult.Rows(0).Item("creation")))
                        SetIsSaved(True)
                        Status = Convert.ToInt32(TableResult.Rows(0).Item("statusid"))
                        ScheduledDate = Convert.ToDateTime(TableResult.Rows(0).Item("scheduleddate"))
                        PerformedDate = If(IsDBNull(TableResult.Rows(0).Item("performeddate")), Nothing, CType((TableResult.Rows(0).Item("performeddate")), Date?))
                        CallType = Convert.ToInt32(TableResult.Rows(0).Item("calltypeid"))
                        Customer = New Person().Load(Convert.ToInt64(TableResult.Rows(0).Item("customerid")), False)
                        Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = Convert.ToInt64(TableResult.Rows(0).Item("personcompressorid")))
                        Technician = New Person().Load(Convert.ToInt64(TableResult.Rows(0).Item("technicianid")), False)
                        Instructions = Convert.ToString(TableResult.Rows(0).Item("instructions"))
                        EvaluationID = If(Not IsDBNull(TableResult.Rows(0).Item("evaluationid")), Convert.ToInt64(TableResult.Rows(0).Item("evaluationid")), 0)
                        Evaluation = New Lazy(Of Evaluation)(Function() If(Not IsDBNull(TableResult.Rows(0).Item("evaluationid")), New Evaluation().Load(Convert.ToInt64(TableResult.Rows(0).Item("evaluationid")), False), Nothing))
                        OverridedVisitScheduleID = If(Not IsDBNull(TableResult.Rows(0).Item("overridedvisitscheduleid")), Convert.ToInt64(TableResult.Rows(0).Item("overridedvisitscheduleid")), 0)
                        OverridedVisitSchedule = New Lazy(Of VisitSchedule)(Function() If(Not IsDBNull(TableResult.Rows(0).Item("overridedvisitscheduleid")), New VisitSchedule().Load(Convert.ToInt64(TableResult.Rows(0).Item("overridedvisitscheduleid")), False), Nothing))
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
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
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                UpdateUser(Con, Tra)
                Using Cmd As New MySqlCommand(My.Resources.VisitScheduleDelete, Con, Tra)
                    Cmd.Parameters.AddWithValue("@id", ID)
                    Cmd.ExecuteNonQuery()
                    Clear()
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.VisitScheduleInsert, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    Cmd.Parameters.AddWithValue("@statusid", Convert.ToInt32(Status))
                    Cmd.Parameters.AddWithValue("@scheduleddate", ScheduledDate.ToString("yyyy-MM-dd HH:mm"))
                    Cmd.Parameters.AddWithValue("@performeddate", If(PerformedDate.HasValue, PerformedDate.Value.ToString("yyyy-MM-dd HH:mm"), DBNull.Value))
                    Cmd.Parameters.AddWithValue("@calltypeid", Convert.ToInt32(CallType))
                    Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                    Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    Cmd.Parameters.AddWithValue("@technicianid", Technician.ID)
                    Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                    Cmd.Parameters.AddWithValue("@evaluationid", DBNull.Value)
                    Cmd.Parameters.AddWithValue("@overridedvisitscheduleid", DBNull.Value)
                    Cmd.Parameters.AddWithValue("@userid", User.ID)
                    Cmd.ExecuteNonQuery()
                    SetID(Cmd.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.VisitScheduleUpdate, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                Cmd.Parameters.AddWithValue("@scheduleddate", ScheduledDate.ToString("yyyy-MM-dd HH:mm"))
                Cmd.Parameters.AddWithValue("@performeddate", If(PerformedDate.HasValue, PerformedDate.Value.ToString("yyyy-MM-dd HH:mm"), DBNull.Value))
                Cmd.Parameters.AddWithValue("@calltypeid", Convert.ToInt32(CallType))
                Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                Cmd.Parameters.AddWithValue("@technicianid", Technician.ID)
                Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                Cmd.Parameters.AddWithValue("@userid", User.ID)
                Cmd.Parameters.AddWithValue("@evaluationid", If(EvaluationID = 0, DBNull.Value, EvaluationID))
                Cmd.Parameters.AddWithValue("@overridedvisitscheduleid", If(OverridedVisitScheduleID = 0, DBNull.Value, OverridedVisitScheduleID))
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Customer.Name}: {Compressor.CompressorName}{If(Not String.IsNullOrEmpty(Compressor.SerialNumber), $" {Compressor.SerialNumber}", {String.Empty})}"
    End Function
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New VisitSchedule With {
            .CallType = CallType,
            .Compressor = CType(Compressor.Clone(), PersonCompressor),
            .Customer = CType(Customer.Clone(), Person),
            .EvaluationID = EvaluationID,
            .Instructions = Instructions,
            .OverridedVisitScheduleID = OverridedVisitScheduleID,
            .PerformedDate = PerformedDate,
            .ScheduledDate = ScheduledDate,
            .Status = Status,
            .Technician = CType(Technician.Clone(), Person),
            .Evaluation = New Lazy(Of Evaluation)(
                Function()
                    If Evaluation.IsValueCreated Then
                        Return CType(Evaluation.Value.Clone(), Evaluation)
                    Else
                        Return New Evaluation().Load(EvaluationID, False)
                    End If
                End Function
            ),
            .OverridedVisitSchedule = New Lazy(Of VisitSchedule)(
                Function()
                    If OverridedVisitSchedule.IsValueCreated Then
                        Return CType(OverridedVisitSchedule.Value.Clone(), VisitSchedule)
                    Else
                        Return New VisitSchedule().Load(OverridedVisitScheduleID, False)
                    End If
                End Function
            )
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function
End Class
