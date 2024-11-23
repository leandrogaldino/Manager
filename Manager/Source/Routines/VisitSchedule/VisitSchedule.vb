Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient

Public Class VisitSchedule
    Inherits ParentModel

    Private _RemoteDB As RemoteDB

    Public Property Status As VisitScheduleStatus
    Public Property VisitType As VisitScheduleType
    Public Property VisitDate As Date
    Public Property Customer As New Person
    Public Property Compressor As New PersonCompressor
    Public Property Instructions As String
    Public Property Evaluation As Lazy(Of Evaluation)

    Public Sub New()
        SetRoutine(Routine.VisitSchedule)
        Status = VisitScheduleStatus.Pending
        VisitType = VisitScheduleType.None
        _RemoteDB = Locator.GetInstance(Of RemoteDB)(CloudDatabaseType.Customer)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = VisitScheduleStatus.Pending
        VisitDate = Today
        Customer = New Person()
        Compressor = New PersonCompressor()
        Instructions = Nothing
        Evaluation = New Lazy(Of Evaluation)
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As VisitSchedule
        Dim Session = Locator.GetInstance(Of Session)
        Dim Table As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.VisitScheduleSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(Cmd)
                        Table = New DataTable()
                        Adp.Fill(Table)
                        If Table.Rows.Count = 1 Then
                            Clear()
                            SetID(Convert.ToInt64(Table.Rows(0).Item("id")))
                            SetCreation(Convert.ToDateTime(Table.Rows(0).Item("creation")))
                            SetIsSaved(True)
                            Status = CType(Convert.ToInt32(Table.Rows(0).Item("statusid")), VisitScheduleStatus)
                            VisitType = CType(Convert.ToInt32(Table.Rows(0).Item("visittypeid")), VisitScheduleType)
                            VisitDate = Convert.ToDateTime(Table.Rows(0).Item("visitdate"))
                            Customer = New Person().Load(Convert.ToInt64(Table.Rows(0).Item("customerid")), False)
                            Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = Table.Rows(0).Item("personcompressorid"))
                            Instructions = Convert.ToString(Table.Rows(0).Item("instructions"))
                            If Table.Rows(0).Item("evaluationid") IsNot DBNull.Value Then
                                Evaluation = New Lazy(Of Evaluation)(Function() New Evaluation().Load(Convert.ToInt64(Table.Rows(0).Item("evaluationid")), True))
                            End If


                            Dim Conditions As New List(Of RemoteDB.Condition) From {
                                New RemoteDB.WhereEqualToCondition("id", Identity)
                            }
                            Dim Result = ManagerCore.Util.AsyncLock(Function() _RemoteDB.ExecuteGet("schedule", Conditions))

                            If Result.Count = 1 Then


                                Dim RemoteVisit = Result(0)

                                If Status <> CInt(RemoteVisit("status_id")) Then

                                    Status = CInt(RemoteVisit("status_id"))
                                End If

                            End If
                            LockInfo = GetLockInfo(Tra)
                            If LockMe AndAlso Not LockInfo.IsLocked Then Lock(Tra)
                        Else
                            Clear()
                            Throw New Exception("Registro não encontrado.")
                        End If
                    End Using
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
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.VisitScheduleInsert, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                    Cmd.Parameters.AddWithValue("@visitdate", VisitDate.ToString("yyyy-MM-dd"))
                    Cmd.Parameters.AddWithValue("@visittypeid", CInt(VisitType))
                    Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                    Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                    Cmd.Parameters.AddWithValue("@evaluationid", DBNull.Value)
                    Cmd.Parameters.AddWithValue("@userid", User.ID)
                    Cmd.ExecuteNonQuery()
                    SetID(Cmd.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using

        Dim Data As New Dictionary(Of String, Object) From {
            {"id", ID},
            {"status_id", CInt(Status)},
            {"visit_type_id", CInt(VisitType)},
            {"customer_id", Customer.ID},
            {"compressor_id", Compressor.ID},
            {"visit_date", VisitDate.ToString("yyyy-MM-dd")},
            {"instructions", Instructions}
        }

        ManagerCore.Util.AsyncLock(Sub() _RemoteDB.ExecutePut("schedule", Data))

    End Sub
    Private Sub Update()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.VisitScheduleUpdate, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                Cmd.Parameters.AddWithValue("@visitdate", VisitDate.ToString("yyyy-MM-dd"))
                Cmd.Parameters.AddWithValue("@visittypeid", CInt(VisitType))
                Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                Cmd.Parameters.AddWithValue("@evaluationid", If(Not Evaluation.IsValueCreated OrElse Evaluation.Value.ID = 0, DBNull.Value, Evaluation.Value.ID))
                Cmd.Parameters.AddWithValue("@userid", User.ID)
                Cmd.ExecuteNonQuery()
            End Using
        End Using

        Dim Data As New Dictionary(Of String, Object) From {
            {"id", ID},
            {"status_id", CInt(Status)},
            {"visit_type_id", CInt(VisitType)},
            {"customer_id", Customer.ID},
            {"compressor_id", Compressor.ID},
            {"visit_date", VisitDate.ToString("yyyy-MM-dd")},
            {"instructions", Instructions}
        }

        ManagerCore.Util.AsyncLock(Sub() _RemoteDB.ExecutePut("schedule", Data))

    End Sub
    Public Overrides Function ToString() As String
        Return $"{Customer.Name}: {Compressor.Compressor.Name}{If(Not String.IsNullOrEmpty(Compressor.SerialNumber), $" {Compressor.SerialNumber}", {String.Empty})}"
    End Function
End Class
