Imports System.IO
Imports ChinhDo.Transactions
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
Public Class Evaluation
    Inherits ParentModel
    Private _Shadow As Evaluation
    Private _Compressor As New PersonCompressor
    Private _Status As EvaluationStatus = EvaluationStatus.Disapproved
    Private _RejectReason As String
    Public ReadOnly Property Status As EvaluationStatus
        Get
            Return _Status
        End Get
    End Property
    Public Property Source As EvaluationSource = EvaluationSource.Manual
    Public Property CallType As CallType = CallType.None
    Public Property NeedProposal As ConfirmationType = ConfirmationType.None
    Public Property HasRepair As ConfirmationType = ConfirmationType.None
    Public Property UnitName As String
    Public Property Temperature As Integer
    Public Property Pressure As Decimal
    Public Property EvaluationDate As Date = Today
    Public Property StartTime As New TimeSpan(0, 0, 0)
    Public Property EndTime As New TimeSpan(0, 0, 0)
    Public Property EvaluationNumber As String
    Public Property Technicians As New List(Of EvaluationTechnician)
    Public Property Customer As New Person
    Public Property Responsible As String
    Public Property Compressor As PersonCompressor
        Get
            Return _Compressor
        End Get
        Set(value As PersonCompressor)
            SetCompressor(value)
        End Set
    End Property
    Public Property Horimeter As Integer
    Public Property ManualAverageWorkLoad As Boolean
    Public Property AverageWorkLoad As Decimal = 5.71
    Public Property WorkedHourControlledSelables As New List(Of EvaluationControlledSellable)
    Public Property ElapsedDayControlledSellables As New List(Of EvaluationControlledSellable)
    Public Property ReplacedSellables As New List(Of EvaluationReplacedSellable)
    Public Property TechnicalAdvice As String
    Public Property Document As New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
    Public Property Signature As New FileManager(ApplicationPaths.EvaluationSignatureDirectory)
    Public Property Pictures As New List(Of EvaluationPicture)
    Public ReadOnly Property RejectReason As String
        Get
            Return _RejectReason
        End Get
    End Property
    Public Sub New()
        SetRoutine(Routine.Evaluation)
    End Sub
    Public Sub Clear()
        Unlock()
        SetIsSaved(False)
        SetID(0)
        SetCreation(Today)
        _Status = EvaluationStatus.Disapproved
        CallType = CallType.None
        NeedProposal = ConfirmationType.None
        HasRepair = ConfirmationType.None
        UnitName = Nothing
        Temperature = 0
        Pressure = 0
        EvaluationDate = Today
        StartTime = New TimeSpan(0, 0, 0)
        EndTime = New TimeSpan(0, 0, 0)
        EvaluationNumber = Nothing
        Technicians = New List(Of EvaluationTechnician)
        Customer = New Person
        Responsible = Nothing
        Compressor = New PersonCompressor
        Horimeter = 0
        ManualAverageWorkLoad = False
        AverageWorkLoad = 0
        WorkedHourControlledSelables = New List(Of EvaluationControlledSellable)
        ElapsedDayControlledSellables = New List(Of EvaluationControlledSellable)
        ReplacedSellables = New List(Of EvaluationReplacedSellable)
        TechnicalAdvice = Nothing
        Document = New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
        Signature = New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
        Pictures = New List(Of EvaluationPicture)
        _RejectReason = Nothing
        If LockInfo.IsLocked Then Unlock()
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
                        SetID(TableResult.Rows(0).Item("id"))
                        SetCreation(TableResult.Rows(0).Item("creation"))
                        SetIsSaved(True)
                        _Status = Convert.ToInt32(TableResult.Rows(0).Item("statusid"))
                        Source = Convert.ToInt32(TableResult.Rows(0).Item("sourceid"))
                        CallType = Convert.ToInt32(TableResult.Rows(0).Item("calltypeid"))
                        NeedProposal = Convert.ToInt32(TableResult.Rows(0).Item("needproposalid"))
                        HasRepair = Convert.ToInt32(TableResult.Rows(0).Item("hasrepairid"))
                        UnitName = Convert.ToString(TableResult.Rows(0).Item("unitname"))
                        Temperature = Convert.ToInt32(TableResult.Rows(0).Item("temperature"))
                        Pressure = Convert.ToDecimal(TableResult.Rows(0).Item("pressure"))
                        EvaluationDate = Convert.ToDateTime(TableResult.Rows(0).Item("evaluationdate"))
                        StartTime = TimeSpan.Parse(TableResult.Rows(0).Item("starttime"))
                        EndTime = TimeSpan.Parse(TableResult.Rows(0).Item("endtime"))
                        EvaluationNumber = Convert.ToString(TableResult.Rows(0).Item("evaluationnumber"))
                        Customer = New Person().Load(TableResult.Rows(0).Item("customerid"), False)
                        Responsible = Convert.ToString(TableResult.Rows(0).Item("responsible"))
                        Compressor = Customer.Compressors.SingleOrDefault(Function(x) x.ID = TableResult.Rows(0).Item("personcompressorid"))
                        Horimeter = Convert.ToInt32(TableResult.Rows(0).Item("horimeter"))
                        ManualAverageWorkLoad = Convert.ToBoolean(TableResult.Rows(0).Item("manualaverageworkload"))
                        AverageWorkLoad = Convert.ToDecimal(TableResult.Rows(0).Item("averageworkload"))
                        TechnicalAdvice = Convert.ToString(TableResult.Rows(0).Item("technicaladvice"))
                        If TableResult.Rows(0).Item("documentname") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("documentname")) Then
                            Document.SetCurrentFile(Path.Combine(ApplicationPaths.EvaluationDocumentDirectory, TableResult.Rows(0).Item("documentname").ToString), True)
                        End If
                        If TableResult.Rows(0).Item("signaturename") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("signaturename")) Then
                            Signature.SetCurrentFile(Path.Combine(ApplicationPaths.EvaluationSignatureDirectory, TableResult.Rows(0).Item("signaturename").ToString), True)
                        End If
                        Pictures = GetPictures(Tra)
                        _RejectReason = TableResult.Rows(0).Item("rejectreason").ToString
                        Technicians = GetTechnicians(Tra)
                        GetControlledSellables(Tra)
                        GetReplacedSellables(Tra)
                        LockInfo = GetLockInfo(Tra)
                        If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                    Else
                        Throw New Exception("Registro não encontrado.")
                    End If
                End Using
                Tra.Commit()
            End Using
            _Shadow = Clone()
        End Using
        Return Me
    End Function
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Dim FileManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                UpdateUser(Con)
                Technicians.ForEach(Sub(t) t.UpdateUser(Con))
                WorkedHourControlledSelables.ForEach(Sub(w) w.UpdateUser(Con))
                ElapsedDayControlledSellables.ForEach(Sub(e) e.UpdateUser(Con))
                ReplacedSellables.ForEach(Sub(r) r.UpdateUser(Con))
                Pictures.ForEach(Sub(p) p.UpdateUser(Con))
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationDelete, Con)
                    CmdEvaluation.Parameters.AddWithValue("@id", ID)
                    CmdEvaluation.ExecuteNonQuery()
                    If File.Exists(Document.OriginalFile) Then FileManager.Delete(Document.OriginalFile)
                    If File.Exists(Signature.OriginalFile) Then FileManager.Delete(Signature.OriginalFile)
                    For Each ShadowPicture In _Shadow.Pictures
                        If File.Exists(ShadowPicture.Picture.OriginalFile) Then
                            FileManager.Delete(ShadowPicture.Picture.OriginalFile)
                        End If
                    Next ShadowPicture
                    Pictures.ToList.ForEach(Sub(x)
                                                If File.Exists(x.Picture.OriginalFile) Then
                                                    FileManager.Delete(x.Picture.OriginalFile)
                                                End If
                                            End Sub)

                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Technicians.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        WorkedHourControlledSelables.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        ElapsedDayControlledSellables.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        ReplacedSellables.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        Pictures.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationInsert, Con)
                    CmdEvaluation.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdEvaluation.Parameters.AddWithValue("@statusid", Convert.ToInt32(Status))
                    CmdEvaluation.Parameters.AddWithValue("@sourceid", Convert.ToInt32(Source))
                    CmdEvaluation.Parameters.AddWithValue("@calltypeid", Convert.ToInt32(CallType))
                    CmdEvaluation.Parameters.AddWithValue("@needproposalid", Convert.ToInt32(NeedProposal))
                    CmdEvaluation.Parameters.AddWithValue("@hasrepairid", Convert.ToInt32(HasRepair))
                    CmdEvaluation.Parameters.AddWithValue("@unitname", UnitName)
                    CmdEvaluation.Parameters.AddWithValue("@temperature", Temperature)
                    CmdEvaluation.Parameters.AddWithValue("@pressure", Pressure)
                    CmdEvaluation.Parameters.AddWithValue("@evaluationdate", EvaluationDate.ToString("yyyy-MM-dd"))
                    CmdEvaluation.Parameters.AddWithValue("@starttime", StartTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@endtime", EndTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationnumber", If(String.IsNullOrEmpty(EvaluationNumber), DBNull.Value, EvaluationNumber))
                    CmdEvaluation.Parameters.AddWithValue("@customerid", Customer.ID)
                    CmdEvaluation.Parameters.AddWithValue("@responsible", If(String.IsNullOrEmpty(Responsible), DBNull.Value, Responsible))
                    CmdEvaluation.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    CmdEvaluation.Parameters.AddWithValue("@horimeter", Horimeter)
                    CmdEvaluation.Parameters.AddWithValue("@manualaverageworkload", ManualAverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@averageworkload", AverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@technicaladvice", If(String.IsNullOrEmpty(TechnicalAdvice), DBNull.Value, TechnicalAdvice))
                    CmdEvaluation.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(Document.CurrentFile), DBNull.Value, Path.GetFileName(Document.CurrentFile)))
                    CmdEvaluation.Parameters.AddWithValue("@signaturename", If(String.IsNullOrEmpty(Signature.CurrentFile), DBNull.Value, Path.GetFileName(Signature.CurrentFile)))
                    CmdEvaluation.Parameters.AddWithValue("@rejectreason", If(String.IsNullOrEmpty(RejectReason), DBNull.Value, RejectReason))
                    CmdEvaluation.Parameters.AddWithValue("@userid", User.ID)
                    CmdEvaluation.ExecuteNonQuery()
                    SetID(CmdEvaluation.LastInsertedId)
                End Using
                For Each Technician As EvaluationTechnician In Technicians
                    Using CmdTechnician As New MySqlCommand(My.Resources.EvaluationTechnicianInsert, Con)
                        CmdTechnician.Parameters.AddWithValue("@creation", Technician.Creation)
                        CmdTechnician.Parameters.AddWithValue("@evaluationid", ID)
                        CmdTechnician.Parameters.AddWithValue("@technicianid", Technician.Technician.ID)
                        CmdTechnician.Parameters.AddWithValue("@userid", Technician.User.ID)
                        CmdTechnician.ExecuteNonQuery()
                        Technician.SetID(CmdTechnician.LastInsertedId)
                    End Using
                Next Technician
                For Each WorkedHourSellable As EvaluationControlledSellable In WorkedHourControlledSelables
                    Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@evaluationid", ID)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorsellableid", WorkedHourSellable.PersonCompressorSellable.ID)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                        CmdWorkedHourSellable.ExecuteNonQuery()
                        WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                    End Using
                Next WorkedHourSellable
                For Each ElapsedDaySellable As EvaluationControlledSellable In ElapsedDayControlledSellables
                    Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@evaluationid", ID)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorsellableid", ElapsedDaySellable.PersonCompressorSellable.ID)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@currentcapacity", ElapsedDaySellable.CurrentCapacity)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@sold", ElapsedDaySellable.Sold)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@lost", ElapsedDaySellable.Lost)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                        CmdElapsedDaySellable.ExecuteNonQuery()
                        ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                    End Using
                Next ElapsedDaySellable
                For Each ReplacedSellable As EvaluationReplacedSellable In ReplacedSellables
                    Using CmdReplacedSellable As New MySqlCommand(My.Resources.EvaluationReplacedSellableInsert, Con)
                        CmdReplacedSellable.Parameters.AddWithValue("@evaluationid", ID)
                        CmdReplacedSellable.Parameters.AddWithValue("@creation", ReplacedSellable.Creation)
                        CmdReplacedSellable.Parameters.AddWithValue("@productid", If(ReplacedSellable.SellableType = SellableType.Product, ReplacedSellable.SellableID, DBNull.Value))
                        CmdReplacedSellable.Parameters.AddWithValue("@serviceid", If(ReplacedSellable.SellableType = SellableType.Service, ReplacedSellable.SellableID, DBNull.Value))
                        CmdReplacedSellable.Parameters.AddWithValue("@quantity", ReplacedSellable.Quantity)
                        CmdReplacedSellable.Parameters.AddWithValue("@userid", ReplacedSellable.User.ID)
                        CmdReplacedSellable.ExecuteNonQuery()
                        ReplacedSellable.SetID(CmdReplacedSellable.LastInsertedId)
                    End Using
                Next ReplacedSellable
                For Each Picture As EvaluationPicture In Pictures
                    Using CmdPicture As New MySqlCommand(My.Resources.EvaluationPictureInsert, Con)
                        CmdPicture.Parameters.AddWithValue("@creation", Picture.Creation)
                        CmdPicture.Parameters.AddWithValue("@evaluationid", ID)
                        CmdPicture.Parameters.AddWithValue("@picturenamename", Path.GetFileName(Picture.Picture.CurrentFile))
                        CmdPicture.Parameters.AddWithValue("@userid", Picture.User.ID)
                        CmdPicture.ExecuteNonQuery()
                        Picture.SetID(CmdPicture.LastInsertedId)
                    End Using
                Next Picture
            End Using
            Document.Execute()
            Signature.Execute()
            Pictures.ToList.ForEach(Sub(x) x.Picture.Execute())
            Transaction.Complete()
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationUpdate, Con)
                    CmdEvaluation.Parameters.AddWithValue("@id", ID)
                    CmdEvaluation.Parameters.AddWithValue("@statusid", Convert.ToInt32(Status))
                    CmdEvaluation.Parameters.AddWithValue("@calltypeid", Convert.ToInt32(CallType))
                    CmdEvaluation.Parameters.AddWithValue("@needproposalid", Convert.ToInt32(NeedProposal))
                    CmdEvaluation.Parameters.AddWithValue("@hasrepairid", Convert.ToInt32(HasRepair))
                    CmdEvaluation.Parameters.AddWithValue("@unitname", UnitName)
                    CmdEvaluation.Parameters.AddWithValue("@temperature", Temperature)
                    CmdEvaluation.Parameters.AddWithValue("@pressure", Pressure)
                    CmdEvaluation.Parameters.AddWithValue("@evaluationdate", EvaluationDate)
                    CmdEvaluation.Parameters.AddWithValue("@starttime", StartTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@endtime", EndTime.ToString("hh\:mm"))
                    CmdEvaluation.Parameters.AddWithValue("@evaluationnumber", If(String.IsNullOrEmpty(EvaluationNumber), DBNull.Value, EvaluationNumber))
                    CmdEvaluation.Parameters.AddWithValue("@customerid", Customer.ID)
                    CmdEvaluation.Parameters.AddWithValue("@responsible", If(String.IsNullOrEmpty(Responsible), DBNull.Value, Responsible))
                    CmdEvaluation.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                    CmdEvaluation.Parameters.AddWithValue("@horimeter", Horimeter)
                    CmdEvaluation.Parameters.AddWithValue("@manualaverageworkload", ManualAverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@averageworkload", AverageWorkLoad)
                    CmdEvaluation.Parameters.AddWithValue("@technicaladvice", If(String.IsNullOrEmpty(TechnicalAdvice), DBNull.Value, TechnicalAdvice))
                    CmdEvaluation.Parameters.AddWithValue("@documentname", If(String.IsNullOrEmpty(Document.CurrentFile), DBNull.Value, Path.GetFileName(Document.CurrentFile)))
                    CmdEvaluation.Parameters.AddWithValue("@signaturename", If(String.IsNullOrEmpty(Signature.CurrentFile), DBNull.Value, Path.GetFileName(Signature.CurrentFile)))
                    CmdEvaluation.Parameters.AddWithValue("@rejectreason", If(String.IsNullOrEmpty(RejectReason), DBNull.Value, RejectReason))
                    CmdEvaluation.Parameters.AddWithValue("@userid", User.ID)
                    CmdEvaluation.ExecuteNonQuery()
                End Using
                For Each Technician As EvaluationTechnician In _Shadow.Technicians
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
                            Technician.SetID(Cmd.LastInsertedId)
                        End Using
                    Else
                        Using Cmd As New MySqlCommand(My.Resources.EvaluationTechnicianUpdate, Con)
                            Cmd.Parameters.AddWithValue("@id", Technician.ID)
                            Cmd.Parameters.AddWithValue("@technicianid", Technician.Technician.ID)
                            Cmd.Parameters.AddWithValue("@userid", Technician.User.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Technician
                If Compressor.ID <> _Shadow.Compressor.ID Then
                    For Each ShadowWorkedHourSellable As EvaluationControlledSellable In _Shadow.WorkedHourControlledSelables.Where(Function(x) x.ID <> 0)
                        Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@id", ShadowWorkedHourSellable.ID)
                            CmdWorkedHourSellable.ExecuteNonQuery()
                        End Using
                    Next ShadowWorkedHourSellable
                    For Each WorkedHourSellable As EvaluationControlledSellable In WorkedHourControlledSelables.Where(Function(x) x.ID = 0)
                        Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@evaluationid", ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorsellableid", WorkedHourSellable.PersonCompressorSellable.ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                            CmdWorkedHourSellable.ExecuteNonQuery()
                            WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                        End Using
                    Next WorkedHourSellable
                    For Each ShadowElapsedDaySellable As EvaluationControlledSellable In _Shadow.ElapsedDayControlledSellables.Where(Function(x) x.ID <> 0)
                        Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@id", ShadowElapsedDaySellable.ID)
                            CmdElapsedDaySellable.ExecuteNonQuery()
                        End Using
                    Next ShadowElapsedDaySellable
                    For Each ElapsedDaySellable As EvaluationControlledSellable In ElapsedDayControlledSellables.Where(Function(x) x.ID = 0)
                        Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@evaluationid", ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorsellableid", ElapsedDaySellable.PersonCompressorSellable.ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@currentcapacity", ElapsedDaySellable.CurrentCapacity)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@sold", ElapsedDaySellable.Sold)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@lost", ElapsedDaySellable.Lost)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                            CmdElapsedDaySellable.ExecuteNonQuery()
                            ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                        End Using
                    Next ElapsedDaySellable
                Else
                    For Each WorkedHourSellable As EvaluationControlledSellable In _Shadow.WorkedHourControlledSelables
                        If Not WorkedHourControlledSelables.Any(Function(x) x.ID = WorkedHourSellable.ID And x.ID > 0) Then
                            Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@id", WorkedHourSellable.ID)
                                CmdWorkedHourSellable.ExecuteNonQuery()
                            End Using
                        End If
                    Next WorkedHourSellable
                    For Each WorkedHourSellable As EvaluationControlledSellable In WorkedHourControlledSelables
                        If WorkedHourSellable.ID = 0 Then
                            Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@evaluationid", ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorsellableid", WorkedHourSellable.PersonCompressorSellable.ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                                CmdWorkedHourSellable.ExecuteNonQuery()
                                WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                            End Using
                        Else
                            Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableUpdate, Con)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@id", _Shadow.WorkedHourControlledSelables.First(Function(x) x.Guid = WorkedHourSellable.Guid).ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                                CmdWorkedHourSellable.ExecuteNonQuery()
                            End Using
                        End If
                    Next WorkedHourSellable
                    For Each ElapsedDaySellable As EvaluationControlledSellable In _Shadow.ElapsedDayControlledSellables
                        If Not ElapsedDayControlledSellables.Any(Function(x) x.ID = ElapsedDaySellable.ID And x.ID > 0) Then
                            Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@id", ElapsedDaySellable.ID)
                                CmdElapsedDaySellable.ExecuteNonQuery()
                            End Using
                        End If
                    Next ElapsedDaySellable
                    For Each ElapsedDaySellable As EvaluationControlledSellable In ElapsedDayControlledSellables
                        If ElapsedDaySellable.ID = 0 Then
                            Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@evaluationid", ID)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorsellableid", ElapsedDaySellable.PersonCompressorSellable.ID)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@currentcapacity", ElapsedDaySellable.CurrentCapacity)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@sold", ElapsedDaySellable.Sold)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@lost", ElapsedDaySellable.Lost)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                                CmdElapsedDaySellable.ExecuteNonQuery()
                                ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                            End Using
                        Else
                            Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableUpdate, Con)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@id", _Shadow.ElapsedDayControlledSellables.First(Function(x) x.Guid = ElapsedDaySellable.Guid).ID)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@currentcapacity", ElapsedDaySellable.CurrentCapacity)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@sold", ElapsedDaySellable.Sold)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@lost", ElapsedDaySellable.Lost)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                                CmdElapsedDaySellable.ExecuteNonQuery()
                            End Using
                        End If
                    Next ElapsedDaySellable
                End If
                For Each ReplacedSellable As EvaluationReplacedSellable In _Shadow.ReplacedSellables
                    If Not ReplacedSellables.Any(Function(x) x.ID = ReplacedSellable.ID And x.ID > 0) Then
                        Using CmdReplacedSellable As New MySqlCommand(My.Resources.EvaluationReplacedSellableDelete, Con)
                            CmdReplacedSellable.Parameters.AddWithValue("@id", ReplacedSellable.ID)
                            CmdReplacedSellable.ExecuteNonQuery()
                        End Using
                    End If
                Next ReplacedSellable
                For Each ReplacedSellable As EvaluationReplacedSellable In ReplacedSellables
                    If ReplacedSellable.ID = 0 Then
                        Using CmdReplacedSellable As New MySqlCommand(My.Resources.EvaluationReplacedSellableInsert, Con)
                            CmdReplacedSellable.Parameters.AddWithValue("@evaluationid", ID)
                            CmdReplacedSellable.Parameters.AddWithValue("@creation", ReplacedSellable.Creation)
                            CmdReplacedSellable.Parameters.AddWithValue("@productid", If(ReplacedSellable.SellableType = SellableType.Product, ReplacedSellable.SellableID, DBNull.Value))
                            CmdReplacedSellable.Parameters.AddWithValue("@serviceid", If(ReplacedSellable.SellableType = SellableType.Service, ReplacedSellable.SellableID, DBNull.Value))
                            CmdReplacedSellable.Parameters.AddWithValue("@quantity", ReplacedSellable.Quantity)
                            CmdReplacedSellable.Parameters.AddWithValue("@userid", ReplacedSellable.User.ID)
                            CmdReplacedSellable.ExecuteNonQuery()
                            ReplacedSellable.SetID(CmdReplacedSellable.LastInsertedId)
                        End Using
                    Else
                        Using CmdReplacedSellable As New MySqlCommand(My.Resources.EvaluationReplacedSellableUpdate, Con)
                            CmdReplacedSellable.Parameters.AddWithValue("@id", ReplacedSellable.ID)
                            CmdReplacedSellable.Parameters.AddWithValue("@productid", If(ReplacedSellable.SellableType = SellableType.Product, ReplacedSellable.SellableID, DBNull.Value))
                            CmdReplacedSellable.Parameters.AddWithValue("@serviceid", If(ReplacedSellable.SellableType = SellableType.Service, ReplacedSellable.SellableID, DBNull.Value))
                            CmdReplacedSellable.Parameters.AddWithValue("@quantity", ReplacedSellable.Quantity)
                            CmdReplacedSellable.Parameters.AddWithValue("@userid", ReplacedSellable.User.ID)
                            CmdReplacedSellable.ExecuteNonQuery()
                        End Using
                    End If
                Next ReplacedSellable
                For Each Picture As EvaluationPicture In _Shadow.Pictures
                    If Not Pictures.Any(Function(x) x.ID = Picture.ID And x.ID > 0) Then
                        Using CmdPicture As New MySqlCommand(My.Resources.EvaluationPictureDelete, Con)
                            CmdPicture.Parameters.AddWithValue("@id", Picture.ID)
                            CmdPicture.ExecuteNonQuery()
                        End Using
                    End If
                Next Picture
                For Each Picture As EvaluationPicture In Pictures.Where(Function(x) x.Picture.CurrentFile Is Nothing)
                    Using CmdPicture As New MySqlCommand(My.Resources.EvaluationPictureDelete, Con)
                        CmdPicture.Parameters.AddWithValue("@id", Picture.ID)
                        CmdPicture.ExecuteNonQuery()
                    End Using
                Next
                For Each Picture As EvaluationPicture In Pictures.Where(Function(x) x.Picture.CurrentFile IsNot Nothing)
                    If Picture.ID = 0 Then
                        Using CmdPicture As New MySqlCommand(My.Resources.EvaluationPictureInsert, Con)
                            CmdPicture.Parameters.AddWithValue("@creation", Picture.Creation)
                            CmdPicture.Parameters.AddWithValue("@evaluationid", ID)
                            CmdPicture.Parameters.AddWithValue("@picturename", Path.GetFileName(Picture.Picture.CurrentFile))
                            CmdPicture.Parameters.AddWithValue("@userid", Picture.User.ID)
                            CmdPicture.ExecuteNonQuery()
                            Picture.SetID(CmdPicture.LastInsertedId)
                        End Using
                    Else
                        Using CmdPicture As New MySqlCommand(My.Resources.EvaluationPictureUpdate, Con)
                            CmdPicture.Parameters.AddWithValue("@id", Picture.ID)
                            CmdPicture.Parameters.AddWithValue("@picturename", Path.GetFileName(Picture.Picture.CurrentFile))
                            CmdPicture.Parameters.AddWithValue("@userid", Picture.User.ID)
                            CmdPicture.ExecuteNonQuery()
                        End Using
                    End If
                Next Picture
            End Using
            Document.Execute()
            Signature.Execute()
            Pictures.ToList.ForEach(Sub(x) x.Picture.Execute())
            Transaction.Complete()
        End Using
    End Sub
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
    Public Function Calculate() As Boolean
        Dim PreviousEvaluationID As Long
        Dim PreviousEvaluation As Evaluation
        PreviousEvaluationID = GetPreviousEvaluationID(Compressor, CDate(EvaluationDate), ID)
        PreviousEvaluation = New Evaluation().Load(PreviousEvaluationID, False)
        Dim PreviousSellable As EvaluationControlledSellable
        If Horimeter < PreviousEvaluation.Horimeter Then
            For Each CurrentSellable As EvaluationControlledSellable In WorkedHourControlledSelables
                CurrentSellable.Sold = False
                CurrentSellable.Lost = False
                PreviousSellable = PreviousEvaluation.WorkedHourControlledSelables.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                    CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity
                Else
                    CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                End If
            Next CurrentSellable
            For Each CurrentSellable As EvaluationControlledSellable In ElapsedDayControlledSellables
                CurrentSellable.Sold = False
                CurrentSellable.Lost = False
                PreviousSellable = PreviousEvaluation.ElapsedDayControlledSellables.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                    CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity
                Else
                    CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                End If
            Next CurrentSellable
            If Not ManualAverageWorkLoad Then AverageWorkLoad = PreviousEvaluation.AverageWorkLoad
            Return True
        Else
            For Each CurrentSellable As EvaluationControlledSellable In WorkedHourControlledSelables
                CurrentSellable.Sold = False
                CurrentSellable.Lost = False
                PreviousSellable = PreviousEvaluation.WorkedHourControlledSelables.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                    CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity - (Horimeter - PreviousEvaluation.Horimeter)
                Else
                    CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                End If
            Next CurrentSellable
            For Each CurrentSellable As EvaluationControlledSellable In ElapsedDayControlledSellables
                CurrentSellable.Sold = False
                CurrentSellable.Lost = False
                PreviousSellable = PreviousEvaluation.ElapsedDayControlledSellables.FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CurrentSellable.PersonCompressorSellable.ID)
                If PreviousSellable IsNot Nothing AndAlso PreviousSellable.IsSaved Then
                    CurrentSellable.CurrentCapacity = PreviousSellable.CurrentCapacity - (EvaluationDate).Subtract(PreviousEvaluation.EvaluationDate).Days
                Else
                    CurrentSellable.CurrentCapacity = CurrentSellable.PersonCompressorSellable.Capacity
                End If
            Next CurrentSellable
            If Not ManualAverageWorkLoad Then AverageWorkLoad = GetCMT()
            Return False
        End If
    End Function
    Private Sub SetCompressor(Compressor As PersonCompressor)
        Dim CurrentSellable As EvaluationControlledSellable
        If Compressor IsNot Nothing Then
            If Compressor.ID <> _Compressor.ID Then
                WorkedHourControlledSelables.Clear()
                ElapsedDayControlledSellables.Clear()
                For Each Sellable In Compressor.WorkedHourSellables.Where(Function(x) x.Status = SimpleStatus.Active)
                    WorkedHourControlledSelables.Add(New EvaluationControlledSellable() With {.PersonCompressorSellable = Sellable})
                Next Sellable
                For Each Sellable In Compressor.ElapsedDaySellables.Where(Function(x) x.Status = SimpleStatus.Active)
                    ElapsedDayControlledSellables.Add(New EvaluationControlledSellable() With {.PersonCompressorSellable = Sellable})
                Next Sellable
            Else
                For Each Sellable In Compressor.WorkedHourSellables
                    CurrentSellable = WorkedHourControlledSelables.SingleOrDefault(Function(x) x.PersonCompressorSellable.ID = Sellable.ID)
                    If CurrentSellable IsNot Nothing Then
                        CurrentSellable.PersonCompressorSellable = Sellable
                        CurrentSellable.Lost = False
                        CurrentSellable.Sold = False
                    Else
                        WorkedHourControlledSelables.Add(New EvaluationControlledSellable() With {.PersonCompressorSellable = Sellable})
                    End If
                Next Sellable
                For Each Sellable In WorkedHourControlledSelables.ToArray.Reverse
                    If Sellable.SellableStatus = SimpleStatus.Inactive Then
                        WorkedHourControlledSelables.Remove(Sellable)
                    End If
                Next Sellable
                For Each Sellable In Compressor.ElapsedDaySellables
                    CurrentSellable = ElapsedDayControlledSellables.SingleOrDefault(Function(x) x.PersonCompressorSellable.ID = Sellable.ID)
                    If CurrentSellable IsNot Nothing Then
                        CurrentSellable.PersonCompressorSellable = Sellable
                        CurrentSellable.Lost = False
                        CurrentSellable.Sold = False
                    Else
                        ElapsedDayControlledSellables.Add(New EvaluationControlledSellable() With {.PersonCompressorSellable = Sellable})
                    End If
                Next Sellable
                For Each Sellable In ElapsedDayControlledSellables.ToArray.Reverse
                    If Sellable.SellableStatus = SimpleStatus.Inactive Then
                        ElapsedDayControlledSellables.Remove(Sellable)
                    End If
                Next Sellable
            End If
        End If
        _Compressor = Compressor
    End Sub

    Private Function GetPictures(Transaction As MySqlTransaction) As List(Of EvaluationPicture)
        Dim TableResult As DataTable
        Dim Picture As EvaluationPicture
        Dim Pictures As New List(Of EvaluationPicture)
        Using Cmd As New MySqlCommand(My.Resources.EvaluationPictureSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@evaluationid", ID)
            Using Adp As New MySqlDataAdapter(Cmd)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    Picture = New EvaluationPicture
                    Picture.Picture.SetCurrentFile((Path.Combine(ApplicationPaths.EvaluationPictureDirectory, Row.Item("picturename").ToString)), True)
                    Picture.SetID(Row.Item("id"))
                    Picture.SetCreation(Row.Item("creation"))
                    Picture.SetIsSaved(True)
                    Pictures.Add(Picture)
                Next Row
            End Using
        End Using
        Return Pictures
    End Function
    Private Function GetTechnicians(Transaction As MySqlTransaction) As List(Of EvaluationTechnician)
        Dim TableResult As DataTable
        Dim Technician As EvaluationTechnician
        Dim Technicians As New List(Of EvaluationTechnician)
        Using Cmd As New MySqlCommand(My.Resources.EvaluationTechnicianSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@evaluationid", ID)
            Using Adp As New MySqlDataAdapter(Cmd)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    Technician = New EvaluationTechnician With {
                        .Technician = New Person().Load(Row.Item("technicianid"), False)
                    }
                    Technician.SetID(Row.Item("id"))
                    Technician.SetCreation(Row.Item("creation"))
                    Technician.SetIsSaved(True)
                    Technicians.Add(Technician)
                Next Row
            End Using
        End Using
        Return Technicians
    End Function
    Private Sub GetControlledSellables(Transaction As MySqlTransaction)
        Dim TableResult As DataTable
        Dim Sellable As EvaluationControlledSellable
        WorkedHourControlledSelables.Clear()
        Using CmdWorkedHour As New MySqlCommand(My.Resources.EvaluationControlledSellableSelect, Transaction.Connection)
            CmdWorkedHour.Transaction = Transaction
            CmdWorkedHour.Parameters.AddWithValue("@evaluationid", ID)
            CmdWorkedHour.Parameters.AddWithValue("@controltypeid", CInt(CompressorSellableControlType.WorkedHour))
            Using Adp As New MySqlDataAdapter(CmdWorkedHour)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    If WorkedHourControlledSelables.Any(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")) Then
                        WorkedHourControlledSelables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).SetID(Row.Item("id"))
                        WorkedHourControlledSelables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).SetCreation(Row.Item("creation"))
                        WorkedHourControlledSelables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).SetIsSaved(True)
                        WorkedHourControlledSelables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).CurrentCapacity = Row.Item("currentcapacity")
                        WorkedHourControlledSelables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).Sold = Row.Item("sold")
                        WorkedHourControlledSelables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).Lost = Row.Item("lost")
                    Else
                        Sellable = New EvaluationControlledSellable() With {
                            .PersonCompressorSellable = Compressor.WorkedHourSellables.Single(Function(x) x.ID = Row.Item("personcompressorsellableid")),
                            .CurrentCapacity = Row.Item("currentcapacity"),
                            .Sold = Row.Item("sold"),
                            .Lost = Row.Item("lost")
                        }
                        Sellable.SetID(Row.Item("id"))
                        Sellable.SetCreation(Row.Item("creation"))
                        Sellable.SetIsSaved(True)
                        WorkedHourControlledSelables.Add(Sellable)
                    End If
                Next Row
            End Using
        End Using
        ElapsedDayControlledSellables.Clear()
        Using CmdElapsedDay As New MySqlCommand(My.Resources.EvaluationControlledSellableSelect, Transaction.Connection)
            CmdElapsedDay.Transaction = Transaction
            CmdElapsedDay.Parameters.AddWithValue("@evaluationid", ID)
            CmdElapsedDay.Parameters.AddWithValue("@controltypeid", CInt(CompressorSellableControlType.ElapsedDay))
            Using Adp As New MySqlDataAdapter(CmdElapsedDay)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    If ElapsedDayControlledSellables.Any(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")) Then
                        ElapsedDayControlledSellables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).SetIsSaved(True)
                        ElapsedDayControlledSellables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).SetID(Row.Item("id"))
                        ElapsedDayControlledSellables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).SetCreation(Row.Item("creation"))
                        ElapsedDayControlledSellables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).CurrentCapacity = Row.Item("currentcapacity")
                        ElapsedDayControlledSellables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).Sold = Row.Item("sold")
                        ElapsedDayControlledSellables.Single(Function(x) x.PersonCompressorSellable.ID = Row.Item("personcompressorsellableid")).Lost = Row.Item("lost")
                    Else
                        Sellable = New EvaluationControlledSellable() With {
                            .PersonCompressorSellable = Compressor.ElapsedDaySellables.Single(Function(x) x.ID = Row.Item("personcompressorsellableid")),
                            .CurrentCapacity = Row.Item("currentcapacity"),
                            .Sold = Row.Item("sold"),
                            .Lost = Row.Item("lost")
                        }
                        Sellable.SetIsSaved(True)
                        Sellable.SetID(Row.Item("id"))
                        Sellable.SetCreation(Row.Item("creation"))
                        ElapsedDayControlledSellables.Add(Sellable)
                    End If
                Next Row




            End Using
        End Using
    End Sub
    Private Sub GetReplacedSellables(Transaction As MySqlTransaction)
        Dim TableResult As DataTable
        Dim Sellable As EvaluationReplacedSellable
        Using CmdEvaluationItem As New MySqlCommand(My.Resources.EvaluationReplacedSellableSelect, Transaction.Connection)
            CmdEvaluationItem.Transaction = Transaction
            CmdEvaluationItem.Parameters.AddWithValue("@evaluationid", ID)
            Using Adp As New MySqlDataAdapter(CmdEvaluationItem)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    Sellable = New EvaluationReplacedSellable With {
                        .SellableID = If(Row.Item("productid") IsNot DBNull.Value, Convert.ToInt32(Row.Item("productid")), Convert.ToInt32(Row.Item("serviceid"))),
                        .Code = Row.Item("code").ToString,
                        .Name = Row.Item("name").ToString,
                        .SellableType = Row.Item("sellabletypeid"),
                        .Sellable = New Lazy(Of Sellable)(Function()
                                                              If .SellableType = SellableType.Product Then
                                                                  Return New Product().Load(Row.Item("productid"), False)
                                                              Else
                                                                  Return New Service().Load(Row.Item("serviceid"), False)
                                                              End If
                                                          End Function),
                        .Quantity = Row.Item("quantity")
                    }
                    Sellable.SetIsSaved(True)
                    Sellable.SetID(Row.Item("id"))
                    Sellable.SetCreation(Row.Item("creation"))
                    ReplacedSellables.Add(Sellable)
                Next Row
            End Using
        End Using
    End Sub
    Private Function GetCMT() As Decimal
        Dim Value As Decimal
        Value = 5.71
        If Horimeter >= 0 Then
            If HasPreviousEvaluation(Compressor, EvaluationDate, ID) Then
                If GetPreviousEvaluationDate(Compressor, EvaluationDate, ID) <= EvaluationDate Then
                    Value = GetAverageWorkLoad(Compressor, Horimeter, EvaluationDate, ID)
                    If Value = 0 Then Value = 0.01
                    If Value < 0 Then Value = 5.71
                    If Value > 24 And Value < 25 Then Value = 24
                End If
            End If
        End If
        Return Value
    End Function
    Public Shared Sub FillControlledSellableDataGridView(EvaluationID As Long, Dgv As DataGridView, ControlType As CompressorSellableControlType)
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As New DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.EvaluationDetailSelect, Con)
                Cmd.Parameters.AddWithValue("@evaluationid", EvaluationID)
                Cmd.Parameters.AddWithValue("@controltypeid", CInt(ControlType))
                Using Adp As New MySqlDataAdapter(Cmd)
                    Adp.Fill(TableResult)
                    Dgv.AutoGenerateColumns = False
                    Dgv.Columns.Clear()
                    Dgv.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Sellable", .HeaderText = "Produto/Serviço", .DataPropertyName = "Produto/Serviço", .CellTemplate = New DataGridViewTextBoxCell})
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
    Public Shared Function GetFirstEvaluationDate(PersonCompressor As PersonCompressor) As Date
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.EvaluationFirstEvaluationDateSelect, Con)
                Cmd.Parameters.AddWithValue("@personcompressorid", PersonCompressor.ID)
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
    Public Shared Function FromCloud(Data As Dictionary(Of String, Object), Signature As String, Pictures As List(Of String)) As Evaluation
        Dim Evaluation As New Evaluation
        Dim EvaluationTechnician As EvaluationTechnician
        Dim Coalescent As EvaluationControlledSellable
        Evaluation.EvaluationNumber = GetEvaluationNumber(EvaluationSource.Imported)
        Evaluation.Source = EvaluationSource.Imported
        Evaluation.CallType = Convert.ToInt32(Data("calltypeid"))
        Evaluation.HasRepair = ConfirmationType.None
        Evaluation.NeedProposal = If(Data("needproposal") = 1, ConfirmationType.Yes, ConfirmationType.No)
        Evaluation.UnitName = Convert.ToString(Data("unitname"))
        Evaluation.Temperature = Convert.ToInt32(Data("temperature"))
        Evaluation.Pressure = Convert.ToDecimal(Data("pressure"))
        Evaluation.TechnicalAdvice = Data("advice")
        Evaluation.Customer = New Person().Load(Data("customerid"), False)
        Evaluation.Compressor = Evaluation.Customer.Compressors.SingleOrDefault(Function(x) x.ID = Data("compressorid"))
        Evaluation.EvaluationDate = DateTimeHelper.DateFromMilliseconds(Data("creationdate"))
        Evaluation.StartTime = TimeSpan.ParseExact(Data("starttime"), "hh\:mm", Nothing)
        Evaluation.EndTime = TimeSpan.ParseExact(Data("endtime"), "hh\:mm", Nothing)
        Evaluation.Horimeter = Data("horimeter")
        Dim AirFilter As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelables.Where(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.AirFilter).ToList
        Dim OilFilter As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelables.Where(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.OilFilter).ToList
        Dim Separator As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelables.Where(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Separator).ToList
        Dim Oil As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelables.Where(Function(x) x.PersonCompressorSellable.SellableBind = CompressorSellableBindType.Oil).ToList

        Evaluation.WorkedHourControlledSelables.ToList.ForEach(Sub(x)
                                                                   x.SetIsSaved(True)
                                                               End Sub)

        AirFilter.ForEach(Sub(x)
                              x.CurrentCapacity = Data("airfilter")
                              x.Sold = False
                              x.Lost = False
                              x.SetIsSaved(True)
                          End Sub)
        OilFilter.ForEach(Sub(x)
                              x.CurrentCapacity = Data("oilfilter")
                              x.Sold = False
                              x.Lost = False
                              x.SetIsSaved(True)
                          End Sub)
        Separator.ForEach(Sub(x)
                              x.CurrentCapacity = Data("separator")
                              x.Sold = False
                              x.Lost = False
                              x.SetIsSaved(True)
                          End Sub)
        Oil.ForEach(Sub(x)
                        x.CurrentCapacity = Data("oil")
                        x.Sold = False
                        x.Lost = False
                        x.SetIsSaved(True)
                    End Sub)
        For Each CoalescentData As Dictionary(Of String, Object) In Data("coalescents")
            Coalescent = Evaluation.ElapsedDayControlledSellables.Where(Function(y) y.PersonCompressorSellable.IsSellableBinded).FirstOrDefault(Function(x) x.PersonCompressorSellable.ID = CoalescentData("coalescentid"))
            If Coalescent IsNot Nothing Then
                Coalescent.CurrentCapacity = DateDiff(DateInterval.Day, Today, DateTimeHelper.DateFromMilliseconds((CoalescentData("nextchange"))))
                Coalescent.Sold = False
                Coalescent.Lost = False
            End If
        Next CoalescentData
        Evaluation.ElapsedDayControlledSellables.ForEach(Sub(x) x.SetIsSaved(True))
        Evaluation.Responsible = Data("responsible")
        Evaluation.StartTime = TimeSpan.ParseExact(Data("starttime"), "hh\:mm", Nothing)
        For Each TechnicianData In Data("technicians")
            EvaluationTechnician = New EvaluationTechnician With {
                .Technician = New Person().Load(TechnicianData("personid"), False)
            }
            EvaluationTechnician.SetIsSaved(True)
            Evaluation.Technicians.Add(EvaluationTechnician)
        Next TechnicianData
        Evaluation.Signature.SetCurrentFile(Signature)
        For Each p In Pictures
            Dim Picture As New EvaluationPicture With {
                .Picture = New FileManager(ApplicationPaths.EvaluationPictureDirectory)
            }
            Picture.SetIsSaved(True)
            Picture.Picture.SetCurrentFile(p)
            Evaluation.Pictures.Add(Picture)
        Next p
        Return Evaluation
    End Function
    Public Shared Function GetEvaluationNumber(CreationType As EvaluationSource) As String
        Dim EvaluationNumber As String = String.Empty
        Dim IsUnique As Boolean
        Dim Session = Locator.GetInstance(Of Session)
        If CreationType <> EvaluationSource.Manual Then
            Do Until IsUnique
                EvaluationNumber = TextHelper.GetRandomString(1, 8, Nothing, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
                If CreationType = EvaluationSource.Automatic Then
                    EvaluationNumber = $"A-{EvaluationNumber}"
                ElseIf CreationType = EvaluationSource.Imported Then
                    EvaluationNumber = $"I-{EvaluationNumber}"
                End If
                Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                    Con.Open()
                    Using Cmd As New MySqlCommand("SELECT COUNT(id) FROM evaluation WHERE evaluationnumber = @evaluationnumber", Con)
                        Cmd.Parameters.AddWithValue("@evaluationnumber", EvaluationNumber)
                        Dim Count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())
                        IsUnique = (Count = 0)
                    End Using
                End Using
            Loop
        End If
        Return EvaluationNumber
    End Function
    Public Shared Function GetLastEvaluationReplacedSellableDate(PersonCompressorSellableID As Long, ReferencedDate As Date) As Date?
        Dim Db As LocalDB = Locator.GetInstance(Of LocalDB)
        Dim r = Db.ExecuteRawQuery(My.Resources.EvaluationLastReplacedSellableDateSelect, New Dictionary(Of String, Object) From
                                   {{"@personcompressorsellableid", PersonCompressorSellableID}, {"@refevaluationdate", ReferencedDate}})
        If r.HasData Then
            If r.Data(0)("evaluationdate") IsNot DBNull.Value Then
                Return Convert.ToDateTime(r.Data(0)("evaluationdate"))
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetLastEvaluationReplacedSellableCapacity(PersonCompressorSellableID As Long, ReferencedDate As Date) As Integer?
        Dim Db As LocalDB = Locator.GetInstance(Of LocalDB)
        Dim r = Db.ExecuteRawQuery(My.Resources.EvaluationLastReplacedSellableCapacitySelect, New Dictionary(Of String, Object) From
                                   {{"@personcompressorsellableid", PersonCompressorSellableID}, {"@refevaluationdate", ReferencedDate}})
        If r.HasData Then
            If r.Data(0)("currentcapacity") IsNot DBNull.Value Then
                Return Convert.ToInt32(r.Data(0)("currentcapacity"))
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New Evaluation With {
            .AverageWorkLoad = AverageWorkLoad,
            .CallType = CallType,
            .Compressor = CType(Compressor.Clone(), PersonCompressor),
            .Customer = CType(Customer.Clone(), Person),
            .Document = Document.Clone(),
            .EndTime = EndTime,
            .Source = Source,
            .EvaluationNumber = EvaluationNumber,
            .EvaluationDate = EvaluationDate,
            .HasRepair = HasRepair,
            .Horimeter = Horimeter,
            .ManualAverageWorkLoad = ManualAverageWorkLoad,
            .NeedProposal = NeedProposal,
            .Pressure = Pressure,
            .Responsible = Responsible,
            .Signature = Signature.Clone(),
            .StartTime = StartTime,
            .TechnicalAdvice = TechnicalAdvice,
            .Temperature = Temperature,
            .UnitName = UnitName,
            .Pictures = Pictures.Select(Function(x) CType(x.Clone(), EvaluationPicture)).ToList(),
            .ElapsedDayControlledSellables = ElapsedDayControlledSellables.Select(Function(x) CType(x.Clone(), EvaluationControlledSellable)).ToList(),
            .WorkedHourControlledSelables = WorkedHourControlledSelables.Select(Function(x) CType(x.Clone(), EvaluationControlledSellable)).ToList(),
            .ReplacedSellables = ReplacedSellables.Select(Function(x) CType(x.Clone(), EvaluationReplacedSellable)).ToList(),
            .Technicians = Technicians.Select(Function(x) CType(x.Clone(), EvaluationTechnician)).ToList()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Return Cloned
    End Function
End Class
