Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient

Public Class VisitSchedule
    Inherits ParentModel
    Private _RemoteDB As RemoteDB
    Private _Evaluation As Lazy(Of Evaluation)
    Public Property Status As VisitScheduleStatus = VisitScheduleStatus.Pending
    Public Property CallType As CallType = CallType.None
    Public Property VisitDate As Date = Today
    Public Property Customer As New Person
    Public Property Compressor As New PersonCompressor
    Public Property Instructions As String
    Public Property LastUpdate As Date = Now


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
        VisitDate = Today
        Customer = New Person()
        Compressor = New PersonCompressor()
        Instructions = Nothing
        LastUpdate = Now
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
                        VisitDate = Convert.ToDateTime(TableResult.Rows(0).Item("visitdate"))
                        CallType = Convert.ToInt32(TableResult.Rows(0).Item("calltypeid"))
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
                    Cmd.Parameters.AddWithValue("@calltypeid", Convert.ToInt32(CallType))
                    Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                    Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                    Cmd.Parameters.AddWithValue("@lastupdate", LastUpdate)
                    Cmd.Parameters.AddWithValue("@userid", User.ID)
                    Cmd.Parameters.AddWithValue("@evaluationid", DBNull.Value)
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
                Cmd.Parameters.AddWithValue("@calltypeid", Convert.ToInt32(CallType))
                Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                Cmd.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                Cmd.Parameters.AddWithValue("@lastupdate", LastUpdate)
                Cmd.Parameters.AddWithValue("@userid", User.ID)
                Cmd.Parameters.AddWithValue("@evaluationid", If(_Evaluation IsNot Nothing, _Evaluation.Value.ID, DBNull.Value))
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Customer.Name}: {Compressor.Compressor.Name}{If(Not String.IsNullOrEmpty(Compressor.SerialNumber), $" {Compressor.SerialNumber}", {String.Empty})}"
    End Function
End Class
