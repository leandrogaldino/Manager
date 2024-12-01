Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports ManagerCore
Imports MySql.Data.MySqlClient
Imports Syncfusion.Pdf.Tables

Public Class VisitSchedule
    Inherits ParentModel
    Private _RemoteDB As RemoteDB
    Private _Evaluation As Lazy(Of Evaluation)
    Public Property Status As VisitScheduleStatus = VisitScheduleStatus.Pending
    Public Property VisitType As VisitScheduleType = VisitType = VisitScheduleType.None
    Public Property VisitDate As Date = Today
    Public Property Customer As New Person
    Public Property Compressor As New PersonCompressor
    Public Property Instructions As String
    Public Property LastUpdate As Date = Now
    Public ReadOnly Property Evaluation As Lazy(Of Evaluation)
        Get
            Return _Evaluation
        End Get
    End Property

    Public Sub New()
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
        SetRoutine(Routine.VisitSchedule)
    End Sub

    Public Sub SetEvaluation(EvaluationID As Long)
        If EvaluationID > 0 Then
            _Evaluation = New Lazy(Of Evaluation)(Function() New Evaluation().Load(EvaluationID, True))
        Else
            _Evaluation = New Lazy(Of Evaluation)
        End If
    End Sub

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
        LastUpdate = Now
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
                        SetEvaluation(Convert.ToInt64(TableResult.Rows(0).Item("evaluationid")))
                        Status = Convert.ToInt32(TableResult.Rows(0).Item("statusid"))
                        VisitDate = Convert.ToDateTime(TableResult.Rows(0).Item("visitdate"))
                        VisitType = Convert.ToInt32(TableResult.Rows(0).Item("visittypeid"))
                        Customer = New Person().Load(Convert.ToInt64(TableResult.Rows(0).Item("customerid")), False)
                        Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = Convert.ToInt64(TableResult.Rows(0).Item("personcompressorid")))
                        Instructions = Convert.ToString(TableResult.Rows(0).Item("instructions"))
                        LastUpdate = Convert.ToDateTime(TableResult.Rows(0).Item("lastupdate"))
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
        LastUpdate = Now
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
            Using Cmd As New MySqlCommand(My.Resources.VisitScheduleDelete, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.ExecuteNonQuery()
                Clear()
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
                    Cmd.Parameters.AddWithValue("@visitdate", VisitDate.ToString("yyyy-MM-dd"))
                    Cmd.Parameters.AddWithValue("@visittypeid", Convert.ToInt32(VisitType))
                    Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                    Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                    Cmd.Parameters.AddWithValue("@evaluationid", 0)
                    Cmd.Parameters.AddWithValue("@lastupdate", LastUpdate)
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
                Cmd.Parameters.AddWithValue("@visitdate", VisitDate.ToString("yyyy-MM-dd"))
                Cmd.Parameters.AddWithValue("@visittypeid", Convert.ToInt32(VisitType))
                Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                Cmd.Parameters.AddWithValue("@evaluationid", If(Evaluation IsNot Nothing AndAlso Evaluation.Value IsNot Nothing, Evaluation.Value.ID, 0))
                Cmd.Parameters.AddWithValue("@lastupdate", LastUpdate)
                Cmd.Parameters.AddWithValue("@userid", User.ID)
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Public Function GetCloudStatus() As VisitScheduleStatus
        Dim Data As Dictionary(Of String, Object)
        If ID > 0 Then
            Dim Condition As New List(Of RemoteDB.Condition) From {New RemoteDB.WhereEqualToCondition("id", ID)}
            Dim DataList = ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecuteGet("schedule", Condition))
            If DataList.Count = 1 Then
                Data = DataList(0)
                Return Data("status_id")
            End If
        End If
        Return VisitScheduleStatus.None
    End Function

    Public Sub UpdateStatus(Status As VisitScheduleStatus)
        LastUpdate = Now
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.VisitScheduleUpdateStatus, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                Cmd.Parameters.AddWithValue("@lastupdate", LastUpdate)
                Cmd.ExecuteNonQuery()
                Me.Status = Status
            End Using
        End Using
    End Sub


    Public Sub SendToCloud()
        Dim Data As Dictionary(Of String, Object)
        Data = ToCloud()
        ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecutePut("schedule", Data, Data("id")))
    End Sub

    Public Sub GetFromCloud()
        Dim Data As Dictionary(Of String, Object)
        Dim Condition As New List(Of RemoteDB.Condition) From {New RemoteDB.WhereEqualToCondition("id", ID)}
        Dim DataList = ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecuteGet("schedule", Condition))
        If DataList.Count = 1 Then
            Data = DataList(0)
            FromCloud(Data)
            Update()
        End If
    End Sub

    Public Sub DeleteFromCloud()
        Dim Conditions As New List(Of RemoteDB.Condition) From {
            New RemoteDB.WhereEqualToCondition("id", ID)
        }
        ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecuteDelete("schedule", Conditions))
    End Sub

    'Public Sub Synchronize()
    '    Dim Data As Dictionary(Of String, Object)
    '    If ID > 0 Then
    '        'Leio a nuvem e vejo se o id ja esta salvo
    '        Dim Condition As New List(Of RemoteDB.Condition) From {New RemoteDB.WhereEqualToCondition("id", ID)}
    '        Dim DataList = ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecuteGet("schedule", Condition))
    '        'se sim
    '        If DataList.Count = 1 Then
    '            Data = DataList(0)


    '            If Data("status_id") <> Convert.ToInt32(Status) Then


    '                'se lastupdate da nuvem é maior que aqui entao sincronizo de la pra ca
    '                If Convert.ToInt64(Data("last_update") > DateTimeHelper.MillisecondsFromDate(LastUpdate)) Then
    '                    FromCloud(Data)
    '                    If Not _SavingChanges Then Update()
    '                End If


    '                'se lastupdate da nuvem é menor que aqui entao sinzroniza de ca pra la
    '                If Convert.ToInt64(Data("last_update") < DateTimeHelper.MillisecondsFromDate(LastUpdate)) Then
    '                    Data = ToCloud()
    '                    If Status <> VisitScheduleStatus.Canceled Then
    '                        ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecutePut("schedule", Data, Data("id")))
    '                    Else
    '                        Dim Conditions As New List(Of RemoteDB.Condition) From {
    '                            New RemoteDB.WhereEqualToCondition("id", Data("id"))
    '                        }
    '                        ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecuteDelete("schedule", Conditions))
    '                    End If
    '                End If




    '            End If





    '        End If
    '        'sincroniza de ca pra la
    '        If DataList.Count = 0 Then
    '            Data = ToCloud()
    '            ManagerCore.Util.AsyncLock(Sub() _RemoteDB.ExecutePut("schedule", Data, Data("id")))
    '        End If
    '    Else
    '        Throw New Exception("Tentativa de sincronização de um registro não salvo.")
    '    End If
    'End Sub
    Public Sub FromCloud(Data As Dictionary(Of String, Object))
        Customer = New Person().Load(Convert.ToInt64(Data("customer_id")), False)
        Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = Convert.ToInt64(Data("compressor_id")))
        Instructions = Convert.ToString(Data("instructions"))
        Status = Convert.ToInt32(Data("status_id"))
        VisitType = Convert.ToInt32(Data("visit_type_id"))
        VisitDate = DateTimeHelper.DateFromMilliseconds(Convert.ToInt64(Data("visit_date")))
        LastUpdate = DateTimeHelper.DateFromMilliseconds(Convert.ToInt64(Data("last_update")))
        SetID(Convert.ToString(Data("id")))
        SetCreation(DateTimeHelper.DateFromMilliseconds(Convert.ToInt64(Data("creation_date"))))
        SetIsSaved(True)
        If Convert.ToInt32(Data("evaluation_id")) > 0 Then
            SetEvaluation(Convert.ToInt64(Data("evaluation_id")))
        End If
    End Sub
    Public Function ToCloud() As Dictionary(Of String, Object)
        Dim Data As New Dictionary(Of String, Object) From {
            {"id", ID},
            {"creation_date", DateTimeHelper.MillisecondsFromDate(Creation)},
            {"status_id", Convert.ToInt32(Status)},
            {"visit_type_id", Convert.ToInt32(VisitType)},
            {"visit_date", DateTimeHelper.MillisecondsFromDate(VisitDate)},
            {"customer_id", Customer.ID},
            {"compressor_id", Compressor.ID},
            {"instructions", Instructions},
            {"evaluation_id", If(Evaluation IsNot Nothing AndAlso Evaluation.Value IsNot Nothing, Evaluation.Value.ID, 0)},
            {"last_update", DateTimeHelper.MillisecondsFromDate(LastUpdate)}
        }
        Return Data
    End Function
    Public Overrides Function ToString() As String
        Return $"{Customer.Name}: {Compressor.Compressor.Name}{If(Not String.IsNullOrEmpty(Compressor.SerialNumber), $" {Compressor.SerialNumber}", {String.Empty})}"
    End Function
End Class
