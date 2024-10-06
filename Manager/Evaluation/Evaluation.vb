Imports System.IO
Imports System.Reflection
Imports ChinhDo.Transactions
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
Public Class Evaluation
    Inherits ModelBase
    Private _Compressor As New PersonCompressor
    Private _Status As EvaluationStatus = EvaluationStatus.Disapproved
    Private _RejectReason As String
    Private _IsSaved As Boolean
    Public ReadOnly Property Status As EvaluationStatus
        Get
            Return _Status
        End Get
    End Property
    Public Property EvaluationCreationType As EvaluationCreationType = EvaluationCreationType.Manual
    Public Property EvaluationType As EvaluationType = EvaluationType.Gathering
    Public Property EvaluationDate As Date = Today
    Public Property StartTime As New TimeSpan(0, 0, 0)
    Public Property EndTime As New TimeSpan(0, 0, 0)
    Public Property EvaluationNumber As String
    Public Property Technicians As New OrdenedList(Of EvaluationTechnician)
    Public Property Customer As New Person
    Public Property Responsible As String
    Public Property Compressor As PersonCompressor
        Get
            Return _Compressor
        End Get
        Set(value As PersonCompressor)
            Dim CurrentPart As EvaluationPart
            If value IsNot Nothing Then
                If value.ID <> _Compressor.ID Then
                    PartsWorkedHour.Clear()
                    PartsElapsedDay.Clear()
                    For Each p In value.PartsWorkedHour.Where(Function(x) x.Status = SimpleStatus.Active)
                        PartsWorkedHour.Add(New EvaluationPart(CompressorPartType.WorkedHour) With {.Part = p})
                    Next p
                    For Each p In value.PartsElapsedDay.Where(Function(x) x.Status = SimpleStatus.Active)
                        PartsElapsedDay.Add(New EvaluationPart(CompressorPartType.ElapsedDay) With {.Part = p})
                    Next p
                Else
                    For Each p In value.PartsWorkedHour
                        CurrentPart = PartsWorkedHour.SingleOrDefault(Function(x) x.Part.ID = p.ID)
                        If CurrentPart IsNot Nothing Then
                            CurrentPart.Part = p
                            CurrentPart.Lost = False
                            CurrentPart.Sold = False
                        Else
                            PartsWorkedHour.Add(New EvaluationPart(CompressorPartType.WorkedHour) With {.Part = p})
                        End If
                    Next p
                    For Each p In PartsWorkedHour.Reverse
                        If p.Part.Status = SimpleStatus.Inactive Then
                            PartsWorkedHour.Remove(p)
                        End If
                    Next p
                    For Each p In value.PartsElapsedDay
                        CurrentPart = PartsElapsedDay.SingleOrDefault(Function(x) x.Part.ID = p.ID)
                        If CurrentPart IsNot Nothing Then
                            CurrentPart.Part = p
                            CurrentPart.Lost = False
                            CurrentPart.Sold = False
                        Else
                            PartsElapsedDay.Add(New EvaluationPart(CompressorPartType.ElapsedDay) With {.Part = p})
                        End If
                    Next p
                    For Each p In PartsElapsedDay.Reverse
                        If p.Part.Status = SimpleStatus.Inactive Then
                            PartsElapsedDay.Remove(p)
                        End If
                    Next p
                End If
            End If
            _Compressor = value
        End Set
    End Property
    Public Property Horimeter As Integer
    Public Property ManualAverageWorkLoad As Boolean
    Public Property AverageWorkLoad As Decimal = 5.71
    Public Property PartsWorkedHour As New OrdenedList(Of EvaluationPart)
    Public Property PartsElapsedDay As New OrdenedList(Of EvaluationPart)
    Public Property TechnicalAdvice As String
    Public Property DocumentPath As New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
    Public Property SignaturePath As New FileManager(ApplicationPaths.EvaluationSignatureDirectory)
    Public Property PhotoPaths As New List(Of FileManager)
    Public ReadOnly Property RejectReason As String
        Get
            Return _RejectReason
        End Get
    End Property
    Public Sub New()
        _Routine = Routine.Evaluation
    End Sub



    Public Shared Function FromDictionary(Data As Dictionary(Of String, Object), Signature As String, Photos As List(Of String)) As Evaluation
        Dim Evaluation As New Evaluation
        Dim EvaluationTechnician As EvaluationTechnician
        Dim Coalescent As EvaluationPart
        Evaluation.EvaluationType = If(Data("is_execution") = True, EvaluationType.Execution, EvaluationType.Gathering)
        Evaluation.TechnicalAdvice = Data("advice")
        Evaluation.AverageWorkLoad = Data("awl")
        Evaluation.Customer = New Person().Load(Data("customer")("person_id"), False)
        Evaluation.Compressor = Evaluation.Customer.Compressors.SingleOrDefault(Function(x) x.ID = Data("compressor")("compressor_id"))
        Evaluation.EvaluationDate = Data("date")
        Evaluation.EndTime = TimeSpan.ParseExact(Data("end_time"), "hh\:mm", Nothing)
        Evaluation.Horimeter = Data("horimeter")
        Dim AirFilters As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.AirFilter).ToList
        Dim OilFilters As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.OilFilter).ToList
        Dim Separators As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.Separator).ToList
        Dim Oils As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBind.Oil).ToList
        AirFilters.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("air_filter"))
        OilFilters.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("oil_filter"))
        Separators.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("separator"))
        Oils.ForEach(Sub(x) x.CurrentCapacity = Data("parts")("oil"))
        For Each CoalescentData In Data("parts")("coalescents")
            Coalescent = Evaluation.PartsElapsedDay.Where(Function(y) y.Part.PartBinded).FirstOrDefault(Function(x) x.Part.ID = CoalescentData("coalescent_id"))
            If Coalescent IsNot Nothing Then Coalescent.CurrentCapacity = DateDiff(DateInterval.Day, Today, CDate(CoalescentData("next_change")))
        Next CoalescentData
        Evaluation.Responsible = Data("responsible")
        Evaluation.StartTime = TimeSpan.ParseExact(Data("start_time"), "hh\:mm", Nothing)
        For Each TechnicianData In Data("technicians")
            EvaluationTechnician = New EvaluationTechnician With {
                .Technician = New Person().Load(TechnicianData("person_id"), False),
                .IsSaved = True
            }
            Evaluation.Technicians.Add(EvaluationTechnician)
        Next TechnicianData
        Evaluation.SignaturePath.SetCurrentFile(Signature)
        For Each Photo In Photos
            Dim PhotoFile As New FileManager(ApplicationPaths.EvaluationPhotoDirectory)
            PhotoFile.SetCurrentFile(Photo)
            Evaluation.PhotoPaths.Add(PhotoFile)
        Next Photo
        Return Evaluation
    End Function





    Public Shared Function CountEvaluation(PersonCompressorID As Long, StatusFilter As List(Of EvaluationStatus), Optional IgnoreEvaluation As Long = 0) As Long
        Dim Session = Locator.GetInstance(Of Session)
        Dim StatusIntList As New List(Of Integer)
        StatusFilter.ForEach(Sub(x) StatusIntList.Add(CInt(x)))
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.EvaluationCount, Con)
                Cmd.Parameters.AddWithValue("@evaluationid", IgnoreEvaluation)
                Cmd.Parameters.AddWithValue("@personcompressorid", PersonCompressorID)
                Cmd.Parameters.AddWithValue("@statusid", String.Join(",", StatusIntList))
                Con.Open()
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        _Status = EvaluationStatus.Disapproved
        EvaluationType = EvaluationType.Gathering
        EvaluationDate = Today
        StartTime = New TimeSpan(0, 0, 0)
        EndTime = New TimeSpan(0, 0, 0)
        EvaluationNumber = Nothing
        Technicians = New OrdenedList(Of EvaluationTechnician)
        Customer = New Person
        Responsible = Nothing
        Compressor = New PersonCompressor
        Horimeter = 0
        ManualAverageWorkLoad = False
        AverageWorkLoad = 0
        PartsWorkedHour = New OrdenedList(Of EvaluationPart)
        PartsElapsedDay = New OrdenedList(Of EvaluationPart)
        TechnicalAdvice = Nothing
        DocumentPath = New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
        _RejectReason = Nothing
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As Evaluation
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdEvaluationSelect As New MySqlCommand(My.Resources.EvaluationSelect, Con)
                    CmdEvaluationSelect.Transaction = Tra
                    CmdEvaluationSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdEvaluationSelect)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        _ID = TableResult.Rows(0).Item("id")
                        _Creation = TableResult.Rows(0).Item("creation")
                        _Status = TableResult.Rows(0).Item("statusid")
                        EvaluationType = TableResult.Rows(0).Item("evaluationtypeid")
                        EvaluationDate = TableResult.Rows(0).Item("evaluationdate")
                        StartTime = TimeSpan.Parse(TableResult.Rows(0).Item("starttime"))
                        EndTime = TimeSpan.Parse(TableResult.Rows(0).Item("endtime"))
                        EvaluationNumber = TableResult.Rows(0).Item("evaluationnumber").ToString
                        Customer = New Person().Load(TableResult.Rows(0).Item("customerid"), False)
                        Responsible = TableResult.Rows(0).Item("responsible").ToString
                        Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = TableResult.Rows(0).Item("personcompressorid"))
                        Horimeter = TableResult.Rows(0).Item("horimeter")
                        ManualAverageWorkLoad = TableResult.Rows(0).Item("manualaverageworkload")
                        AverageWorkLoad = TableResult.Rows(0).Item("averageworkload")
                        TechnicalAdvice = TableResult.Rows(0).Item("technicaladvice").ToString
                        If TableResult.Rows(0).Item("documentname") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("documentname")) Then
                            DocumentPath.SetCurrentFile(Path.Combine(ApplicationPaths.EvaluationDocumentDirectory, TableResult.Rows(0).Item("documentname").ToString), True)
                        End If
                        _RejectReason = TableResult.Rows(0).Item("rejectreason").ToString
                        Technicians = GetTechnicians(Tra)
                        FillParts(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                        _IsSaved = True
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
        End Using
        Return Me
    End Function
    Private Function GetTechnicians(Transaction As MySqlTransaction) As OrdenedList(Of EvaluationTechnician)
        Dim TableResult As DataTable
        Dim Technician As EvaluationTechnician
        Dim Technicians As New OrdenedList(Of EvaluationTechnician)
        Using Cmd As New MySqlCommand(My.Resources.EvaluationTechnicianSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@evaluationid", ID)
            Using Adp As New MySqlDataAdapter(Cmd)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    Technician = New EvaluationTechnician
                    Technician.Technician = New Person().Load(Row.Item("technicianid"), False)
                    Technician.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Technician, Row.Item("id"))
                    Technician.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Technician, Row.Item("creation"))
                    Technician.IsSaved = True
                    Technicians.Add(Technician)
                Next Row
            End Using
        End Using
        Return Technicians
    End Function

    Private Sub FillParts(Transaction As MySqlTransaction)
        Dim TableResult As DataTable
        Dim Part As EvaluationPart
        Using CmdEvaluationPart As New MySqlCommand(My.Resources.EvaluationPartSelect, Transaction.Connection)
            CmdEvaluationPart.Transaction = Transaction
            CmdEvaluationPart.Parameters.AddWithValue("@evaluationid", ID)
            CmdEvaluationPart.Parameters.AddWithValue("@parttypeid", CInt(CompressorPartType.WorkedHour))
            Using Adp As New MySqlDataAdapter(CmdEvaluationPart)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    If PartsWorkedHour.Any(Function(x) x.Part.ID = Row.Item("personcompressorpartid")) Then
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).IsSaved = True
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).CurrentCapacity = Row.Item("currentcapacity")
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Sold = Row.Item("sold")
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Lost = Row.Item("lost")
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")), Row.Item("id"))
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")), Row.Item("creation"))
                    Else
                        Part = New EvaluationPart(CompressorPartType.WorkedHour)
                        Part.Part = Compressor.PartsWorkedHour.Single(Function(x) x.ID = Row.Item("personcompressorpartid"))
                        Part.IsSaved = True
                        Part.CurrentCapacity = Row.Item("currentcapacity")
                        Part.Sold = Row.Item("sold")
                        Part.Lost = Row.Item("lost")
                        Part.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Part, Row.Item("id"))
                        Part.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Part, Row.Item("creation"))
                        PartsWorkedHour.Add(Part)
                    End If
                Next Row
            End Using
        End Using
        Using CmdEvaluationPart As New MySqlCommand(My.Resources.EvaluationPartSelect, Transaction.Connection)
            CmdEvaluationPart.Transaction = Transaction
            CmdEvaluationPart.Parameters.AddWithValue("@evaluationid", ID)
            CmdEvaluationPart.Parameters.AddWithValue("@parttypeid", CInt(CompressorPartType.ElapsedDay))
            Using Adp As New MySqlDataAdapter(CmdEvaluationPart)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    If PartsElapsedDay.Any(Function(x) x.Part.ID = Row.Item("personcompressorpartid")) Then
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).IsSaved = True
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).CurrentCapacity = Row.Item("currentcapacity")
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Sold = Row.Item("sold")
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Lost = Row.Item("lost")
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")), Row.Item("id"))
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")), Row.Item("creation"))
                    Else
                        Part = New EvaluationPart(CompressorPartType.ElapsedDay)
                        Part.Part = Compressor.PartsElapsedDay.Single(Function(x) x.ID = Row.Item("personcompressorpartid"))
                        Part.IsSaved = True
                        Part.CurrentCapacity = Row.Item("currentcapacity")
                        Part.Sold = Row.Item("sold")
                        Part.Lost = Row.Item("lost")
                        Part.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Part, Row.Item("id"))
                        Part.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Part, Row.Item("creation"))
                        PartsElapsedDay.Add(Part)
                    End If
                Next Row
            End Using
        End Using
    End Sub
    Public Sub SaveChanges()
        If Not _IsSaved Then
            Insert()
        Else
            Update()
        End If
        _IsSaved = True
        Technicians.ToList().ForEach(Sub(x) x.IsSaved = True)
        PartsWorkedHour.ToList().ForEach(Sub(x) x.IsSaved = True)
        PartsElapsedDay.ToList().ForEach(Sub(x) x.IsSaved = True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Dim FileManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationDelete, Con)
                    CmdEvaluation.Parameters.AddWithValue("@id", ID)
                    CmdEvaluation.ExecuteNonQuery()
                    If File.Exists(DocumentPath.OriginalFile) Then FileManager.Delete(DocumentPath.OriginalFile)
                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationInsert, Con)
                    CmdEvaluation.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdEvaluation.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationtypeid", CInt(EvaluationType))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationdate", EvaluationDate.ToString("yyyy-MM-dd"))
                    CmdEvaluation.Parameters.AddWithValue("@starttime", StartTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@endtime", EndTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationnumber", EvaluationNumber)
                    CmdEvaluation.Parameters.AddWithValue("@customerid", Customer.ID)
                    CmdEvaluation.Parameters.AddWithValue("@responsible", If(String.IsNullOrEmpty(Responsible), DBNull.Value, Responsible))
                    CmdEvaluation.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    CmdEvaluation.Parameters.AddWithValue("@horimeter", Horimeter)
                    CmdEvaluation.Parameters.AddWithValue("@manualaverageworkload", ManualAverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@averageworkload", AverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@technicaladvice", If(String.IsNullOrEmpty(TechnicalAdvice), DBNull.Value, TechnicalAdvice))
                    CmdEvaluation.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(DocumentPath.CurrentFile), DBNull.Value, Path.GetFileName(DocumentPath.CurrentFile)))
                    CmdEvaluation.Parameters.AddWithValue("@rejectreason", If(String.IsNullOrEmpty(RejectReason), DBNull.Value, RejectReason))
                    CmdEvaluation.Parameters.AddWithValue("@userid", User.ID)
                    CmdEvaluation.ExecuteNonQuery()
                    _ID = CmdEvaluation.LastInsertedId
                End Using
                For Each Technician As EvaluationTechnician In Technicians
                    Using Cmd As New MySqlCommand(My.Resources.EvaluationTechnicianInsert, Con)
                        Cmd.Parameters.AddWithValue("@creation", Technician.Creation)
                        Cmd.Parameters.AddWithValue("@evaluationid", ID)
                        Cmd.Parameters.AddWithValue("@technicianid", Technician.Technician.ID)
                        Cmd.Parameters.AddWithValue("@userid", Technician.User.ID)
                        Cmd.ExecuteNonQuery()
                        Technician.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Technician, Cmd.LastInsertedId)
                    End Using
                Next Technician
                For Each PartWorkedHour As EvaluationPart In PartsWorkedHour
                    Using CmdPartWorkedHour As New MySqlCommand(My.Resources.EvaluationPartInsert, Con)
                        CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                        CmdPartWorkedHour.Parameters.AddWithValue("@evaluationid", ID)
                        CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                        CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorpartid", PartWorkedHour.Part.ID)
                        CmdPartWorkedHour.Parameters.AddWithValue("@currentcapacity", PartWorkedHour.CurrentCapacity)
                        CmdPartWorkedHour.Parameters.AddWithValue("@sold", PartWorkedHour.Sold)
                        CmdPartWorkedHour.Parameters.AddWithValue("@lost", PartWorkedHour.Lost)
                        CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                        CmdPartWorkedHour.ExecuteNonQuery()
                        PartWorkedHour.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartWorkedHour, CmdPartWorkedHour.LastInsertedId)
                    End Using
                Next PartWorkedHour
                For Each PartElapsedDay As EvaluationPart In PartsElapsedDay
                    Using CmdPartElapsedDay As New MySqlCommand(My.Resources.EvaluationPartInsert, Con)
                        CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                        CmdPartElapsedDay.Parameters.AddWithValue("@evaluationid", ID)
                        CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                        CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorpartid", PartElapsedDay.Part.ID)
                        CmdPartElapsedDay.Parameters.AddWithValue("@currentcapacity", PartElapsedDay.CurrentCapacity)
                        CmdPartElapsedDay.Parameters.AddWithValue("@sold", PartElapsedDay.Sold)
                        CmdPartElapsedDay.Parameters.AddWithValue("@lost", PartElapsedDay.Lost)
                        CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                        CmdPartElapsedDay.ExecuteNonQuery()
                        PartElapsedDay.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartElapsedDay, CmdPartElapsedDay.LastInsertedId)
                    End Using
                Next PartElapsedDay
            End Using
            DocumentPath.Execute()
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Shadow As Evaluation = New Evaluation().Load(ID, False)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationUpdate, Con)
                    CmdEvaluation.Parameters.AddWithValue("@id", ID)
                    CmdEvaluation.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationtypeid", CInt(EvaluationType))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationdate", EvaluationDate)
                    CmdEvaluation.Parameters.AddWithValue("@starttime", StartTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@endtime", EndTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationnumber", EvaluationNumber)
                    CmdEvaluation.Parameters.AddWithValue("@customerid", Customer.ID)
                    CmdEvaluation.Parameters.AddWithValue("@responsible", If(String.IsNullOrEmpty(Responsible), DBNull.Value, Responsible))
                    CmdEvaluation.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    CmdEvaluation.Parameters.AddWithValue("@horimeter", Horimeter)
                    CmdEvaluation.Parameters.AddWithValue("@manualaverageworkload", ManualAverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@averageworkload", AverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@technicaladvice", If(String.IsNullOrEmpty(TechnicalAdvice), DBNull.Value, TechnicalAdvice))
                    CmdEvaluation.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(DocumentPath.CurrentFile), DBNull.Value, Path.GetFileName(DocumentPath.CurrentFile)))
                    CmdEvaluation.Parameters.AddWithValue("@rejectreason", If(String.IsNullOrEmpty(RejectReason), DBNull.Value, RejectReason))
                    CmdEvaluation.Parameters.AddWithValue("@userid", User.ID)
                    CmdEvaluation.ExecuteNonQuery()
                End Using
                For Each Technician As EvaluationTechnician In Shadow.Technicians
                    If Not Technicians.Any(Function(x) x.ID = Technician.ID And x.ID > 0) Then
                        Using Cmd As New MySqlCommand(My.Resources.EvaluationTechnicianDelete, Con)
                            Cmd.Parameters.AddWithValue("@id", Technician.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Technician
                For Each Technician As EvaluationTechnician In Technicians
                    If Technician.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.EvaluationTechnicianInsert, Con)
                            Cmd.Parameters.AddWithValue("@creation", Technician.Creation)
                            Cmd.Parameters.AddWithValue("@evaluationid", ID)
                            Cmd.Parameters.AddWithValue("@technicianid", Technician.Technician.ID)
                            Cmd.Parameters.AddWithValue("@userid", Technician.User.ID)
                            Cmd.ExecuteNonQuery()
                            Technician.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Technician, Cmd.LastInsertedId)
                        End Using
                    Else
                        Using Cmd As New MySqlCommand(My.Resources.EvaluationTechnicianUpdate, Con)
                            Cmd.Parameters.AddWithValue("@id", Technician.ID)
                            Cmd.Parameters.AddWithValue("@technicianid", Technician.Technician.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Technician
                If Compressor.ID <> Shadow.Compressor.ID Then
                    For Each ShadowPartWorkedHour As EvaluationPart In Shadow.PartsWorkedHour.Where(Function(x) x.ID <> 0)
                        Using CmdPartWorkedHour As New MySqlCommand(My.Resources.EvaluationPartDelete, Con)
                            CmdPartWorkedHour.Parameters.AddWithValue("@id", ShadowPartWorkedHour.ID)
                            CmdPartWorkedHour.ExecuteNonQuery()
                        End Using
                    Next ShadowPartWorkedHour
                    For Each PartWorkedHour As EvaluationPart In PartsWorkedHour.Where(Function(x) x.ID = 0)
                        Using CmdPartWorkedHour As New MySqlCommand(My.Resources.EvaluationPartInsert, Con)
                            CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                            CmdPartWorkedHour.Parameters.AddWithValue("@evaluationid", ID)
                            CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                            CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorpartid", PartWorkedHour.Part.ID)
                            CmdPartWorkedHour.Parameters.AddWithValue("@currentcapacity", PartWorkedHour.CurrentCapacity)
                            CmdPartWorkedHour.Parameters.AddWithValue("@sold", PartWorkedHour.Sold)
                            CmdPartWorkedHour.Parameters.AddWithValue("@lost", PartWorkedHour.Lost)
                            CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                            CmdPartWorkedHour.ExecuteNonQuery()
                            PartWorkedHour.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartWorkedHour, CmdPartWorkedHour.LastInsertedId)
                        End Using
                    Next PartWorkedHour
                    For Each ShadowPartElapsedDay As EvaluationPart In Shadow.PartsElapsedDay.Where(Function(x) x.ID <> 0)
                        Using CmdPartElapsedDay As New MySqlCommand(My.Resources.EvaluationPartDelete, Con)
                            CmdPartElapsedDay.Parameters.AddWithValue("@id", ShadowPartElapsedDay.ID)
                            CmdPartElapsedDay.ExecuteNonQuery()
                        End Using
                    Next ShadowPartElapsedDay
                    For Each PartElapsedDay As EvaluationPart In PartsElapsedDay.Where(Function(x) x.ID = 0)
                        Using CmdPartElapsedDay As New MySqlCommand(My.Resources.EvaluationPartInsert, Con)
                            CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                            CmdPartElapsedDay.Parameters.AddWithValue("@evaluationid", ID)
                            CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                            CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorpartid", PartElapsedDay.Part.ID)
                            CmdPartElapsedDay.Parameters.AddWithValue("@currentcapacity", PartElapsedDay.CurrentCapacity)
                            CmdPartElapsedDay.Parameters.AddWithValue("@sold", PartElapsedDay.Sold)
                            CmdPartElapsedDay.Parameters.AddWithValue("@lost", PartElapsedDay.Lost)
                            CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                            CmdPartElapsedDay.ExecuteNonQuery()
                            PartElapsedDay.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartElapsedDay, CmdPartElapsedDay.LastInsertedId)
                        End Using
                    Next PartElapsedDay
                Else
                    For Each PartWorkedHour As EvaluationPart In Shadow.PartsWorkedHour
                        If Not PartsWorkedHour.Any(Function(x) x.ID = PartWorkedHour.ID And x.ID > 0) Then
                            Using CmdPartWorkedHour As New MySqlCommand(My.Resources.EvaluationPartDelete, Con)
                                CmdPartWorkedHour.Parameters.AddWithValue("@id", PartWorkedHour.ID)
                                CmdPartWorkedHour.ExecuteNonQuery()
                            End Using
                        End If
                    Next PartWorkedHour
                    For Each PartWorkedHour As EvaluationPart In PartsWorkedHour
                        If PartWorkedHour.ID = 0 Then
                            Using CmdPartWorkedHour As New MySqlCommand(My.Resources.EvaluationPartInsert, Con)
                                CmdPartWorkedHour.Parameters.AddWithValue("@creation", PartWorkedHour.Creation)
                                CmdPartWorkedHour.Parameters.AddWithValue("@evaluationid", ID)
                                CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                                CmdPartWorkedHour.Parameters.AddWithValue("@personcompressorpartid", PartWorkedHour.Part.ID)
                                CmdPartWorkedHour.Parameters.AddWithValue("@currentcapacity", PartWorkedHour.CurrentCapacity)
                                CmdPartWorkedHour.Parameters.AddWithValue("@sold", PartWorkedHour.Sold)
                                CmdPartWorkedHour.Parameters.AddWithValue("@lost", PartWorkedHour.Lost)
                                CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                                CmdPartWorkedHour.ExecuteNonQuery()
                                PartWorkedHour.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartWorkedHour, CmdPartWorkedHour.LastInsertedId)
                            End Using
                        Else
                            Using CmdPartWorkedHour As New MySqlCommand(My.Resources.EvaluationPartUpdate, Con)
                                CmdPartWorkedHour.Parameters.AddWithValue("@id", Shadow.PartsWorkedHour.First(Function(x) x.Order = PartWorkedHour.Order).ID)
                                CmdPartWorkedHour.Parameters.AddWithValue("@currentcapacity", PartWorkedHour.CurrentCapacity)
                                CmdPartWorkedHour.Parameters.AddWithValue("@sold", PartWorkedHour.Sold)
                                CmdPartWorkedHour.Parameters.AddWithValue("@lost", PartWorkedHour.Lost)
                                CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                                CmdPartWorkedHour.ExecuteNonQuery()
                            End Using
                        End If
                    Next PartWorkedHour
                    For Each PartElapsedDay As EvaluationPart In Shadow.PartsElapsedDay
                        If Not PartsElapsedDay.Any(Function(x) x.ID = PartElapsedDay.ID And x.ID > 0) Then
                            Using CmdPartElapsedDay As New MySqlCommand(My.Resources.EvaluationPartDelete, Con)
                                CmdPartElapsedDay.Parameters.AddWithValue("@id", PartElapsedDay.ID)
                                CmdPartElapsedDay.ExecuteNonQuery()
                            End Using
                        End If
                    Next PartElapsedDay
                    For Each PartElapsedDay As EvaluationPart In PartsElapsedDay
                        If PartElapsedDay.ID = 0 Then
                            Using CmdPartElapsedDay As New MySqlCommand(My.Resources.EvaluationPartInsert, Con)
                                CmdPartElapsedDay.Parameters.AddWithValue("@creation", PartElapsedDay.Creation)
                                CmdPartElapsedDay.Parameters.AddWithValue("@evaluationid", ID)
                                CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                                CmdPartElapsedDay.Parameters.AddWithValue("@personcompressorpartid", PartElapsedDay.Part.ID)
                                CmdPartElapsedDay.Parameters.AddWithValue("@currentcapacity", PartElapsedDay.CurrentCapacity)
                                CmdPartElapsedDay.Parameters.AddWithValue("@sold", PartElapsedDay.Sold)
                                CmdPartElapsedDay.Parameters.AddWithValue("@lost", PartElapsedDay.Lost)
                                CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                                CmdPartElapsedDay.ExecuteNonQuery()
                                PartElapsedDay.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(PartElapsedDay, CmdPartElapsedDay.LastInsertedId)
                            End Using
                        Else
                            Using CmdPartElapsedDay As New MySqlCommand(My.Resources.EvaluationPartUpdate, Con)
                                CmdPartElapsedDay.Parameters.AddWithValue("@id", Shadow.PartsElapsedDay.First(Function(x) x.Order = PartElapsedDay.Order).ID)
                                CmdPartElapsedDay.Parameters.AddWithValue("@currentcapacity", PartElapsedDay.CurrentCapacity)
                                CmdPartElapsedDay.Parameters.AddWithValue("@sold", PartElapsedDay.Sold)
                                CmdPartElapsedDay.Parameters.AddWithValue("@lost", PartElapsedDay.Lost)
                                CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                                CmdPartElapsedDay.ExecuteNonQuery()
                            End Using
                        End If
                    Next PartElapsedDay
                End If
            End Using
            DocumentPath.Execute()
            Transaction.Complete()
        End Using
    End Sub
    Public Shared Function HasPreviousEvaluation(PersonCompressor As PersonCompressor, EvaluationDate As Date, EvaluationID As Long) As Boolean
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationHasPreviousEvaluationSelect, Con)
                Cmd.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                Cmd.Parameters.AddWithValue("@evaluationdate", EvaluationDate)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Shared Function GetPreviousEvaluationHorimeter(PersonCompressor As PersonCompressor, EvaluationDate As Date, EvaluationID As Long) As Integer
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationPreviousEvaluationHorimeterSelect, Con)
                Cmd.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                Cmd.Parameters.AddWithValue("@evaluationdate", EvaluationDate)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Shared Function GetPreviousEvaluationDate(PersonCompressor As PersonCompressor, EvaluationDate As Date, EvaluationID As Long) As Date
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationPreviousEvaluationDateSelect, Con)
                Cmd.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                Cmd.Parameters.AddWithValue("@evaluationdate", EvaluationDate)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Shared Function GetPreviousEvaluationID(PersonCompressor As PersonCompressor, EvaluationDate As Date, EvaluationID As Long) As Long
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationPreviousEvaluationIDSelect, Con)
                Cmd.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
                Cmd.Parameters.AddWithValue("@evaluationdate", EvaluationDate)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Shared Function GetAverageWorkLoad(PersonCompressor As PersonCompressor, Horimeter As Integer, EvaluationDate As Date, EvaluationID As Long) As Decimal
        Dim Avg As Decimal
        Dim HasPrevious As Boolean
        Dim PreviousHorimeter As Integer
        Dim PreviousDate As Date
        HasPrevious = HasPreviousEvaluation(PersonCompressor, EvaluationDate, EvaluationID)
        If Not HasPrevious Then
            Avg = 5.71
        Else
            PreviousHorimeter = GetPreviousEvaluationHorimeter(PersonCompressor, EvaluationDate, EvaluationID)
            PreviousDate = GetPreviousEvaluationDate(PersonCompressor, EvaluationDate, EvaluationID)
            If PreviousHorimeter > Horimeter Then
                Avg = (PreviousHorimeter - PersonCompressor.UnitCapacity + Horimeter) / If(CDate(EvaluationDate).Subtract(PreviousDate).TotalDays = 0, 1, CDate(EvaluationDate).Subtract(PreviousDate).TotalDays)
            ElseIf PreviousHorimeter < Horimeter Then
                Avg = (Horimeter - PreviousHorimeter) / If(CDate(EvaluationDate).Subtract(PreviousDate).TotalDays = 0, 1, CDate(EvaluationDate).Subtract(PreviousDate).TotalDays)
            ElseIf PreviousHorimeter = Horimeter Then
                Avg = 0.01
            End If
        End If
        Return Avg
    End Function
    Public Shared Function GetLastEvaluationID(PersonCompressorID As Long) As Long
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationLastEvaluationSelect, Con)
                Cmd.Parameters.AddWithValue("@personcompressorid", PersonCompressorID)
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Sub SetStatus(Status As EvaluationStatus, Optional Reason As String = Nothing)
        Dim Session = Locator.GetInstance(Of Session)
        If Status = EvaluationStatus.Reviewed Then Reason = RejectReason
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationSetStatus, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@statusid", CInt(Status))
                Cmd.Parameters.AddWithValue("@rejectreason", If(String.IsNullOrEmpty(Reason), DBNull.Value, Reason))
                Cmd.Parameters.AddWithValue("@userid", Session.User.ID)
                Cmd.ExecuteNonQuery()
                _Status = Status
                _RejectReason = Reason
            End Using
        End Using
    End Sub
    Public Shared Sub FillDataGridView(EvaluationID As Long, Dgv As DataGridView, PartType As CompressorPartType)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.EvaluationDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Cmd.Parameters.AddWithValue("@parttypeid", CInt(PartType))
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.AutoGenerateColumns = False
                    Dgv.Columns.Clear()
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Item", .HeaderText = "Item", .DataPropertyName = "Item", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Cap. Atual", .HeaderText = "Cap. Atual", .DataPropertyName = "Cap. Atual", .CellTemplate = New DataGridViewTextBoxCell})
                    Dgv.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Vendido", .HeaderText = "Vendido", .DataPropertyName = "Vendido", .CellTemplate = New DataGridViewCheckBoxCell})
                    Dgv.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Perdido", .HeaderText = "Perdido", .DataPropertyName = "Perdido", .CellTemplate = New DataGridViewCheckBoxCell})
                    Dgv.DataSource = TableResult
                    Dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Dgv.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(1).Width = 110
                    Dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(2).Width = 110
                    Dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv.Columns(3).Width = 110
                End Using
            End Using
        End Using
    End Sub
End Class
