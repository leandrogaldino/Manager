Imports ControlLibrary
Imports MySql.Data.MySqlClient

Public Class VisitSchedule
    Inherits ParentModel
    Public Property Status As VisitScheduleStatus
    Public Property VisitType As VisitScheduleType
    Public Property Customer As New Person
    Public Property Compressor As New PersonCompressor
    Public Property Instructions As String
    Public Property GeneratedEvaluation As Lazy(Of Evaluation)

    Public Sub New()
        SetRoutine(Routine.VisitSchedule)
        Status = VisitScheduleStatus.Pending
        VisitType = VisitScheduleType.Gathering
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        Status = VisitScheduleStatus.Pending
        Customer = New Person()
        Compressor = New PersonCompressor()
        Instructions = Nothing
        GeneratedEvaluation = New Lazy(Of Evaluation)
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As VisitSchedule
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using Cmd As New MySqlCommand(My.Resources.VisitScheduleSelect, Con)
                    Cmd.Transaction = Tra
                    Cmd.Parameters.AddWithValue("@id", Identity)
                    Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                        If Reader.HasRows Then
                            Reader.Read()
                            Clear()
                            SetID(Reader.GetInt64("id"))
                            SetCreation(Reader.GetDateTime("creation"))
                            SetIsSaved(True)
                            Status = CType(Reader.GetInt32("statusid"), VisitScheduleStatus)
                            Customer = New Person().Load(Reader.GetInt64("customerid"), False)
                            Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = Reader.GetInt64("compressorid"))
                            Instructions = Reader("instructions").ToString()
                            GeneratedEvaluation = New Lazy(Of Evaluation)(Function() New Evaluation().Load(1, False))
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
                    Cmd.Parameters.AddWithValue("@visitetypeid", CInt(VisitType))
                    Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                    Cmd.Parameters.AddWithValue("@compressorid", Compressor.ID)
                    Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                    Cmd.Parameters.AddWithValue("@evaluationid", If(GeneratedEvaluation.Value.ID <= 0, DBNull.Value, GeneratedEvaluation.Value.ID))
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
                Cmd.Parameters.AddWithValue("@visittypeid", CInt(VisitType))
                Cmd.Parameters.AddWithValue("@customerid", Customer.ID)
                Cmd.Parameters.AddWithValue("@compressorid", Compressor.ID)
                Cmd.Parameters.AddWithValue("@instructions", If(String.IsNullOrEmpty(Instructions), DBNull.Value, Instructions))
                Cmd.Parameters.AddWithValue("@evaluationid", If(GeneratedEvaluation.Value.ID <= 0, DBNull.Value, GeneratedEvaluation.Value.ID))
                Cmd.Parameters.AddWithValue("@userid", User.ID)
                Cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Customer.Name}: {Compressor.Compressor.Name}{If(Not String.IsNullOrEmpty(Compressor.SerialNumber), $" {Compressor.SerialNumber}", {String.Empty})}"
    End Function
End Class
