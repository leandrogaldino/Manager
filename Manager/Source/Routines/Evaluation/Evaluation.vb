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
    Public Property EvaluationCreationType As EvaluationCreationType = EvaluationCreationType.Manual
    Public Property CallType As CallType = CallType.None
    Public Property NeedProposal As ConfirmationType = ConfirmationType.None
    Public Property HasRepair As ConfirmationType = ConfirmationType.None
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
            Dim CurrentPart As EvaluationControlledSellable
            If value IsNot Nothing Then
                If value.ID <> _Compressor.ID Then
                    WorkedHourControlledSelable.Clear()
                    ElapsedDayControlledSellable.Clear()
                    For Each p In value.WorkedHourSellables.Where(Function(x) x.Status = SimpleStatus.Active)
                        WorkedHourControlledSelable.Add(New EvaluationControlledSellable(CompressorSellableControlType.WorkedHour) With {.Sellable = p.Sellable})
                    Next p
                    For Each p In value.ElapsedDaySellables.Where(Function(x) x.Status = SimpleStatus.Active)
                        ElapsedDayControlledSellable.Add(New EvaluationControlledSellable(CompressorSellableControlType.ElapsedDay) With {.Sellable = p.Sellable})
                    Next p
                Else
                    For Each p In value.WorkedHourSellables
                        CurrentPart = WorkedHourControlledSelable.SingleOrDefault(Function(x) x.SellableID = p.ID)
                        If CurrentPart IsNot Nothing Then
                            CurrentPart.Sellable = p.Sellable
                            CurrentPart.Lost = False
                            CurrentPart.Sold = False
                        Else
                            WorkedHourControlledSelable.Add(New EvaluationControlledSellable(CompressorSellableControlType.WorkedHour) With {.Sellable = p.Sellable})
                        End If
                    Next p
                    For Each p In WorkedHourControlledSelable.ToArray.Reverse
                        If p.SellableStatus = SimpleStatus.Inactive Then
                            WorkedHourControlledSelable.Remove(p)
                        End If
                    Next p
                    For Each p In value.ElapsedDaySellables
                        CurrentPart = ElapsedDayControlledSellable.SingleOrDefault(Function(x) x.SellableID = p.ID)
                        If CurrentPart IsNot Nothing Then
                            CurrentPart.Sellable = p.Sellable
                            CurrentPart.Lost = False
                            CurrentPart.Sold = False
                        Else
                            ElapsedDayControlledSellable.Add(New EvaluationControlledSellable(CompressorSellableControlType.ElapsedDay) With {.Sellable = p.Sellable})
                        End If
                    Next p
                    For Each p In ElapsedDayControlledSellable.ToArray.Reverse
                        If p.SellableStatus = SimpleStatus.Inactive Then
                            ElapsedDayControlledSellable.Remove(p)
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
    Public Property WorkedHourControlledSelable As New List(Of EvaluationControlledSellable)
    Public Property ElapsedDayControlledSellable As New List(Of EvaluationControlledSellable)
    Public Property ReplacedSellables As New List(Of EvaluationReplacedSellable)
    Public Property TechnicalAdvice As String
    Public Property Document As New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
    Public Property Signature As New FileManager(ApplicationPaths.EvaluationSignatureDirectory)
    Public Property Photos As New List(Of EvaluationPhoto)
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
        WorkedHourControlledSelable = New List(Of EvaluationControlledSellable)
        ElapsedDayControlledSellable = New List(Of EvaluationControlledSellable)
        ReplacedSellables = New List(Of EvaluationReplacedSellable)
        TechnicalAdvice = Nothing
        Document = New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
        Signature = New FileManager(ApplicationPaths.EvaluationDocumentDirectory)
        Photos = New List(Of EvaluationPhoto)
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
                        _Status = TableResult.Rows(0).Item("statusid")
                        CallType = TableResult.Rows(0).Item("calltypeid")
                        NeedProposal = TableResult.Rows(0).Item("needproposalid")
                        HasRepair = TableResult.Rows(0).Item("hasrepairid")
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
                            Document.SetCurrentFile(Path.Combine(ApplicationPaths.EvaluationDocumentDirectory, TableResult.Rows(0).Item("documentname").ToString), True)
                        End If
                        If TableResult.Rows(0).Item("signaturename") IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(TableResult.Rows(0).Item("signaturename")) Then
                            Signature.SetCurrentFile(Path.Combine(ApplicationPaths.EvaluationSignatureDirectory, TableResult.Rows(0).Item("signaturename").ToString), True)
                        End If
                        Photos = GetPhotos(Tra)
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
        End Using
        _Shadow = Clone()
        Return Me
    End Function
    Private Function GetPhotos(Transaction As MySqlTransaction) As List(Of EvaluationPhoto)
        Dim TableResult As DataTable
        Dim Photo As EvaluationPhoto
        Dim Photos As New List(Of EvaluationPhoto)
        Using Cmd As New MySqlCommand(My.Resources.EvaluationPhotoSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@evaluationid", ID)
            Using Adp As New MySqlDataAdapter(Cmd)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    Photo = New EvaluationPhoto
                    Photo.Photo.SetCurrentFile((Path.Combine(ApplicationPaths.EvaluationPhotoDirectory, Row.Item("photoname").ToString)), True)
                    Photo.SetID(Row.Item("id"))
                    Photo.SetCreation(Row.Item("creation"))
                    Photo.SetIsSaved(True)
                    Photos.Add(Photo)
                Next Row
            End Using
        End Using
        Return Photos
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
        Using CmdEvaluationSellable As New MySqlCommand(My.Resources.EvaluationReplacedSellableSelect, Transaction.Connection)
            CmdEvaluationSellable.Transaction = Transaction
            CmdEvaluationSellable.Parameters.AddWithValue("@evaluationid", ID)
            CmdEvaluationSellable.Parameters.AddWithValue("@parttypeid", CInt(CompressorSellableControlType.WorkedHour))
            Using Adp As New MySqlDataAdapter(CmdEvaluationSellable)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    If WorkedHourControlledSelable.Any(Function(x) x.SellableID = Row.Item("personcompressorsellableid")) Then
                        WorkedHourControlledSelable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).SetID(Row.Item("id"))
                        WorkedHourControlledSelable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).SetCreation(Row.Item("creation"))
                        WorkedHourControlledSelable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).SetIsSaved(True)
                        WorkedHourControlledSelable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).CurrentCapacity = Row.Item("currentcapacity")
                        WorkedHourControlledSelable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).Sold = Row.Item("sold")
                        WorkedHourControlledSelable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).Lost = Row.Item("lost")
                    Else
                        Sellable = New EvaluationControlledSellable(CompressorSellableControlType.WorkedHour) With {
                            .Sellable = Compressor.WorkedHourSellables.Single(Function(x) x.ID = Row.Item("personcompressorsellableid")).Sellable,
                            .CurrentCapacity = Row.Item("currentcapacity"),
                            .Sold = Row.Item("sold"),
                            .Lost = Row.Item("lost")
                        }
                        Sellable.SetID(Row.Item("id"))
                        Sellable.SetCreation(Row.Item("creation"))
                        Sellable.SetIsSaved(True)
                        WorkedHourControlledSelable.Add(Sellable)
                    End If
                Next Row
            End Using
        End Using
        Using CmdEvaluationPart As New MySqlCommand(My.Resources.EvaluationReplacedSellableSelect, Transaction.Connection)
            CmdEvaluationPart.Transaction = Transaction
            CmdEvaluationPart.Parameters.AddWithValue("@evaluationid", ID)
            CmdEvaluationPart.Parameters.AddWithValue("@parttypeid", CInt(CompressorSellableControlType.ElapsedDay))
            Using Adp As New MySqlDataAdapter(CmdEvaluationPart)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    If ElapsedDayControlledSellable.Any(Function(x) x.SellableID = Row.Item("personcompressorsellableid")) Then
                        ElapsedDayControlledSellable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).SetIsSaved(True)
                        ElapsedDayControlledSellable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).SetID(Row.Item("id"))
                        ElapsedDayControlledSellable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).SetCreation(Row.Item("creation"))
                        ElapsedDayControlledSellable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).CurrentCapacity = Row.Item("currentcapacity")
                        ElapsedDayControlledSellable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).Sold = Row.Item("sold")
                        ElapsedDayControlledSellable.Single(Function(x) x.SellableID = Row.Item("personcompressorsellableid")).Lost = Row.Item("lost")
                    Else
                        Sellable = New EvaluationControlledSellable(CompressorSellableControlType.ElapsedDay) With {
                            .Sellable = Compressor.ElapsedDaySellables.Single(Function(x) x.ID = Row.Item("personcompressorsellableid")).Sellable,
                            .CurrentCapacity = Row.Item("currentcapacity"),
                            .Sold = Row.Item("sold"),
                            .Lost = Row.Item("lost")
                        }
                        Sellable.SetIsSaved(True)
                        Sellable.SetID(Row.Item("id"))
                        Sellable.SetCreation(Row.Item("creation"))
                        ElapsedDayControlledSellable.Add(Sellable)
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
                        .ProductID = Convert.ToInt32(Row.Item("productid")),
                        .ProductCode = Row.Item("productcode").ToString,
                        .ProductName = Row.Item("productname").ToString,
                        .Product = New Lazy(Of Product)(Function() New Product().Load(Convert.ToInt32(Row.Item("productid")), False)),
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
    Public Sub SaveChanges()
        If Not IsSaved Then
            Insert()
        Else
            Update()
        End If
        SetIsSaved(True)
        Technicians.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        WorkedHourControlledSelable.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        ElapsedDayControlledSellable.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        ReplacedSellables.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        Photos.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        _Shadow = Clone()
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationInsert, Con)
                    CmdEvaluation.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdEvaluation.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdEvaluation.Parameters.AddWithValue("@calltypeid", CInt(CallType))
                    CmdEvaluation.Parameters.AddWithValue("@needproposalid", CInt(NeedProposal))
                    CmdEvaluation.Parameters.AddWithValue("@hasrepairid", CInt(HasRepair))
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
                For Each WorkedHourSellable As EvaluationControlledSellable In WorkedHourControlledSelable
                    Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@evaluationid", ID)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorsellableid", WorkedHourSellable.SellableID)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                        CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                        CmdWorkedHourSellable.ExecuteNonQuery()
                        WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                    End Using
                Next WorkedHourSellable
                For Each ElapsedDaySellable As EvaluationControlledSellable In ElapsedDayControlledSellable
                    Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@evaluationid", ID)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorsellableid", ElapsedDaySellable.SellableID)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@currentcapacity", ElapsedDaySellable.CurrentCapacity)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@sold", ElapsedDaySellable.Sold)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@lost", ElapsedDaySellable.Lost)
                        CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                        CmdElapsedDaySellable.ExecuteNonQuery()
                        ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                    End Using
                Next ElapsedDaySellable
                For Each Item As EvaluationReplacedSellable In ReplacedSellables
                    Using CmdItem As New MySqlCommand(My.Resources.EvaluationReplacedSellableInsert, Con)
                        CmdItem.Parameters.AddWithValue("@evaluationid", ID)
                        CmdItem.Parameters.AddWithValue("@creation", Item.Creation)
                        CmdItem.Parameters.AddWithValue("@productid", Item.ProductID)
                        CmdItem.Parameters.AddWithValue("@quantity", Item.Quantity)
                        CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                        CmdItem.ExecuteNonQuery()
                        Item.SetID(CmdItem.LastInsertedId)
                    End Using
                Next Item
                For Each Photo As EvaluationPhoto In Photos
                    Using CmdPhoto As New MySqlCommand(My.Resources.EvaluationPhotoInsert, Con)
                        CmdPhoto.Parameters.AddWithValue("@creation", Photo.Creation)
                        CmdPhoto.Parameters.AddWithValue("@evaluationid", ID)
                        CmdPhoto.Parameters.AddWithValue("@photoname", Path.GetFileName(Photo.Photo.CurrentFile))
                        CmdPhoto.Parameters.AddWithValue("@userid", Photo.User.ID)
                        CmdPhoto.ExecuteNonQuery()
                        Photo.SetID(CmdPhoto.LastInsertedId)
                    End Using
                Next Photo
            End Using
            Document.Execute()
            Signature.Execute()
            Photos.ToList.ForEach(Sub(x) x.Photo.Execute())
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
                    CmdEvaluation.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdEvaluation.Parameters.AddWithValue("@calltypeid", CInt(CallType))
                    CmdEvaluation.Parameters.AddWithValue("@needproposalid", CInt(NeedProposal))
                    CmdEvaluation.Parameters.AddWithValue("@hasrepairid", CInt(HasRepair))
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
                    For Each ShadowWorkedHourSellable As EvaluationControlledSellable In _Shadow.WorkedHourControlledSelable.Where(Function(x) x.ID <> 0)
                        Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@id", ShadowWorkedHourSellable.ID)
                            CmdWorkedHourSellable.ExecuteNonQuery()
                        End Using
                    Next ShadowWorkedHourSellable
                    For Each WorkedHourSellable As EvaluationControlledSellable In WorkedHourControlledSelable.Where(Function(x) x.ID = 0)
                        Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@evaluationid", ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorsellableid", WorkedHourSellable.Sellable.ID)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                            CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                            CmdWorkedHourSellable.ExecuteNonQuery()
                            WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                        End Using
                    Next WorkedHourSellable
                    For Each ShadowElapsedDaySellable As EvaluationControlledSellable In _Shadow.ElapsedDayControlledSellable.Where(Function(x) x.ID <> 0)
                        Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@id", ShadowElapsedDaySellable.ID)
                            CmdElapsedDaySellable.ExecuteNonQuery()
                        End Using
                    Next ShadowElapsedDaySellable
                    For Each ElapsedDaySellable As EvaluationControlledSellable In ElapsedDayControlledSellable.Where(Function(x) x.ID = 0)
                        Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@evaluationid", ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorsellableid", ElapsedDaySellable.Sellable.ID)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@currentcapacity", ElapsedDaySellable.CurrentCapacity)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@sold", ElapsedDaySellable.Sold)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@lost", ElapsedDaySellable.Lost)
                            CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                            CmdElapsedDaySellable.ExecuteNonQuery()
                            ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                        End Using
                    Next ElapsedDaySellable
                Else
                    For Each WorkedHourSellable As EvaluationControlledSellable In _Shadow.WorkedHourControlledSelable
                        If Not WorkedHourControlledSelable.Any(Function(x) x.ID = WorkedHourSellable.ID And x.ID > 0) Then
                            Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@id", WorkedHourSellable.ID)
                                CmdWorkedHourSellable.ExecuteNonQuery()
                            End Using
                        End If
                    Next WorkedHourSellable
                    For Each WorkedHourSellable As EvaluationControlledSellable In WorkedHourControlledSelable
                        If WorkedHourSellable.ID = 0 Then
                            Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@creation", WorkedHourSellable.Creation)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@evaluationid", ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@personcompressorsellableid", WorkedHourSellable.Sellable.ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                                CmdWorkedHourSellable.ExecuteNonQuery()
                                WorkedHourSellable.SetID(CmdWorkedHourSellable.LastInsertedId)
                            End Using
                        Else
                            Using CmdWorkedHourSellable As New MySqlCommand(My.Resources.EvaluationControlledSellableUpdate, Con)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@id", _Shadow.WorkedHourControlledSelable.First(Function(x) x.Guid = WorkedHourSellable.Guid).ID)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@currentcapacity", WorkedHourSellable.CurrentCapacity)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@sold", WorkedHourSellable.Sold)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@lost", WorkedHourSellable.Lost)
                                CmdWorkedHourSellable.Parameters.AddWithValue("@userid", WorkedHourSellable.User.ID)
                                CmdWorkedHourSellable.ExecuteNonQuery()
                            End Using
                        End If
                    Next WorkedHourSellable
                    For Each ElapsedDaySellable As EvaluationControlledSellable In _Shadow.ElapsedDayControlledSellable
                        If Not ElapsedDayControlledSellable.Any(Function(x) x.ID = ElapsedDaySellable.ID And x.ID > 0) Then
                            Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableDelete, Con)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@id", ElapsedDaySellable.ID)
                                CmdElapsedDaySellable.ExecuteNonQuery()
                            End Using
                        End If
                    Next ElapsedDaySellable
                    For Each ElapsedDaySellable As EvaluationControlledSellable In ElapsedDayControlledSellable
                        If ElapsedDaySellable.ID = 0 Then
                            Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableInsert, Con)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@creation", ElapsedDaySellable.Creation)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@evaluationid", ID)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorid", Compressor.ID)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@personcompressorsellableid", ElapsedDaySellable.Sellable.ID)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@currentcapacity", ElapsedDaySellable.CurrentCapacity)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@sold", ElapsedDaySellable.Sold)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@lost", ElapsedDaySellable.Lost)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@userid", ElapsedDaySellable.User.ID)
                                CmdElapsedDaySellable.ExecuteNonQuery()
                                ElapsedDaySellable.SetID(CmdElapsedDaySellable.LastInsertedId)
                            End Using
                        Else
                            Using CmdElapsedDaySellable As New MySqlCommand(My.Resources.EvaluationControlledSellableUpdate, Con)
                                CmdElapsedDaySellable.Parameters.AddWithValue("@id", _Shadow.ElapsedDayControlledSellable.First(Function(x) x.Guid = ElapsedDaySellable.Guid).ID)
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
                            CmdReplacedSellable.Parameters.AddWithValue("@productid", ReplacedSellable.ProductID)
                            CmdReplacedSellable.Parameters.AddWithValue("@quantity", ReplacedSellable.Quantity)
                            CmdReplacedSellable.Parameters.AddWithValue("@userid", ReplacedSellable.User.ID)
                            CmdReplacedSellable.ExecuteNonQuery()
                            ReplacedSellable.SetID(CmdReplacedSellable.LastInsertedId)
                        End Using
                    Else
                        Using CmdReplacedSellable As New MySqlCommand(My.Resources.EvaluationReplacedSellableUpdate, Con)
                            CmdReplacedSellable.Parameters.AddWithValue("@id", ReplacedSellable.ID)
                            CmdReplacedSellable.Parameters.AddWithValue("@productid", ReplacedSellable.ProductID)
                            CmdReplacedSellable.Parameters.AddWithValue("@quantity", ReplacedSellable.Quantity)
                            CmdReplacedSellable.Parameters.AddWithValue("@userid", ReplacedSellable.User.ID)
                            CmdReplacedSellable.ExecuteNonQuery()
                        End Using
                    End If
                Next ReplacedSellable
                For Each Photo As EvaluationPhoto In _Shadow.Photos
                    If Not Photos.Any(Function(x) x.ID = Photo.ID And x.ID > 0) Then
                        Using Cmd As New MySqlCommand(My.Resources.EvaluationPhotoDelete, Con)
                            Cmd.Parameters.AddWithValue("@id", Photo.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Photo
                For Each Photo As EvaluationPhoto In Photos.Where(Function(x) x.Photo.CurrentFile Is Nothing)
                    Using Cmd As New MySqlCommand(My.Resources.EvaluationPhotoDelete, Con)
                        Cmd.Parameters.AddWithValue("@id", Photo.ID)
                        Cmd.ExecuteNonQuery()
                    End Using
                Next
                For Each Photo As EvaluationPhoto In Photos.Where(Function(x) x.Photo.CurrentFile IsNot Nothing)
                    If Photo.ID = 0 Then
                        Using Cmd As New MySqlCommand(My.Resources.EvaluationPhotoInsert, Con)
                            Cmd.Parameters.AddWithValue("@creation", Photo.Creation)
                            Cmd.Parameters.AddWithValue("@evaluationid", ID)
                            Cmd.Parameters.AddWithValue("@photoname", Path.GetFileName(Photo.Photo.CurrentFile))
                            Cmd.Parameters.AddWithValue("@userid", Photo.User.ID)
                            Cmd.ExecuteNonQuery()
                            Photo.SetID(Cmd.LastInsertedId)
                        End Using
                    Else
                        Using Cmd As New MySqlCommand(My.Resources.EvaluationPhotoUpdate, Con)
                            Cmd.Parameters.AddWithValue("@id", Photo.ID)
                            Cmd.Parameters.AddWithValue("@photoname", Path.GetFileName(Photo.Photo.CurrentFile))
                            Cmd.Parameters.AddWithValue("@userid", Photo.User.ID)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Photo
            End Using
            Document.Execute()
            Signature.Execute()
            Photos.ToList.ForEach(Sub(x) x.Photo.Execute())
            Transaction.Complete()
        End Using
    End Sub

    Public Shared Sub FillControlledSellableDataGridView(EvaluationID As Long, Dgv As DataGridView, PartType As CompressorSellableControlType)
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





    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Dim FileManager As New TxFileManager(ApplicationPaths.ManagerTempDirectory)
        Using Transaction As New Transactions.TransactionScope()
            Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                Con.Open()
                Using CmdEvaluation As New MySqlCommand(My.Resources.EvaluationDelete, Con)
                    CmdEvaluation.Parameters.AddWithValue("@id", ID)
                    CmdEvaluation.ExecuteNonQuery()
                    If File.Exists(Document.OriginalFile) Then FileManager.Delete(Document.OriginalFile)
                    If File.Exists(Signature.OriginalFile) Then FileManager.Delete(Signature.OriginalFile)
                    For Each ShadowPhoto In _Shadow.Photos
                        If File.Exists(ShadowPhoto.Photo.OriginalFile) Then
                            FileManager.Delete(ShadowPhoto.Photo.OriginalFile)
                        End If
                    Next ShadowPhoto
                    Photos.ToList.ForEach(Sub(x)
                                              If File.Exists(x.Photo.OriginalFile) Then
                                                  FileManager.Delete(x.Photo.OriginalFile)
                                              End If
                                          End Sub)

                End Using
            End Using
            Transaction.Complete()
        End Using
        Clear()
    End Sub

    Public Shared Function FromCloud(Data As Dictionary(Of String, Object), Signature As String, Photos As List(Of String)) As Evaluation
        Dim Evaluation As New Evaluation
        Dim EvaluationTechnician As EvaluationTechnician
        Dim Coalescent As EvaluationControlledSellable
        Evaluation.EvaluationNumber = GetEvaluationNumber(EvaluationCreationType.Imported)
        Evaluation.EvaluationCreationType = EvaluationCreationType.Imported
        Evaluation.CallType = CallType.None
        Evaluation.NeedProposal = If(Data("needproposal") = True, ConfirmationType.Yes, ConfirmationType.No)
        Evaluation.HasRepair = ConfirmationType.None
        Evaluation.TechnicalAdvice = Data("advice")
        Evaluation.Customer = New Person().Load(Data("customerid"), False)
        Evaluation.Compressor = Evaluation.Customer.Compressors.SingleOrDefault(Function(x) x.ID = Data("personcompressorid"))
        Evaluation.EvaluationDate = DateTimeHelper.DateFromMilliseconds(Data("creationdate"))
        Evaluation.StartTime = TimeSpan.ParseExact(Data("starttime"), "hh\:mm", Nothing)
        Evaluation.EndTime = TimeSpan.ParseExact(Data("endtime"), "hh\:mm", Nothing)
        Evaluation.Horimeter = Data("horimeter")
        Dim AirFilter As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelable.Where(Function(x) x.Sellable.SellableBind = CompressorSellableBindType.AirFilter).ToList
        Dim OilFilter As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelable.Where(Function(x) x.Sellable.SellableBind = CompressorSellableBindType.OilFilter).ToList
        Dim Separator As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelable.Where(Function(x) x.Sellable.SellableBind = CompressorSellableBindType.Separator).ToList
        Dim Oil As List(Of EvaluationControlledSellable) = Evaluation.WorkedHourControlledSelable.Where(Function(x) x.Sellable.SellableBind = CompressorSellableBindType.Oil).ToList

        Evaluation.WorkedHourControlledSelable.ToList.ForEach(Sub(x)
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
            Coalescent = Evaluation.ElapsedDayControlledSellable.Where(Function(y) y.Sellable.IsSellableBinded).FirstOrDefault(Function(x) x.Sellable.ID = CoalescentData("coalescentid"))
            If Coalescent IsNot Nothing Then
                Coalescent.CurrentCapacity = DateDiff(DateInterval.Day, Today, DateTimeHelper.DateFromMilliseconds((CoalescentData("nextchange"))))
                Coalescent.Sold = False
                Coalescent.Lost = False
            End If
        Next CoalescentData
        Evaluation.ElapsedDayControlledSellable.ForEach(Sub(x) x.SetIsSaved(True))
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
        For Each p In Photos
            Dim Photo As New EvaluationPhoto With {
                .Photo = New FileManager(ApplicationPaths.EvaluationPhotoDirectory)
            }
            Photo.SetIsSaved(True)
            Photo.Photo.SetCurrentFile(p)
            Evaluation.Photos.Add(Photo)
        Next p
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
    Public Function Calculate() As Boolean
        Dim PreviousEvaluationID As Long
        Dim PreviousEvaluation As Evaluation
        PreviousEvaluationID = GetPreviousEvaluationID(Compressor, CDate(EvaluationDate), ID)
        PreviousEvaluation = New Evaluation().Load(PreviousEvaluationID, False)
        Dim PreviousPart As EvaluationControlledSellable
        If Horimeter < PreviousEvaluation.Horimeter Then
            For Each CurrentPart As EvaluationControlledSellable In WorkedHourControlledSelable
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.WorkedHourControlledSelable.FirstOrDefault(Function(x) x.Sellable.ID = CurrentPart.Sellable.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Sellable.Capacity
                End If
            Next CurrentPart
            For Each CurrentPart As EvaluationControlledSellable In ElapsedDayControlledSellable
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.ElapsedDayControlledSellable.FirstOrDefault(Function(x) x.Sellable.ID = CurrentPart.Sellable.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Sellable.Capacity
                End If
            Next CurrentPart
            If Not ManualAverageWorkLoad Then AverageWorkLoad = PreviousEvaluation.AverageWorkLoad
            Return True
        Else
            For Each CurrentPart As EvaluationControlledSellable In WorkedHourControlledSelable
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.WorkedHourControlledSelable.FirstOrDefault(Function(x) x.Sellable.ID = CurrentPart.Sellable.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (Horimeter - PreviousEvaluation.Horimeter)
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Sellable.Capacity
                End If
            Next CurrentPart
            For Each CurrentPart As EvaluationControlledSellable In ElapsedDayControlledSellable
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.ElapsedDayControlledSellable.FirstOrDefault(Function(x) x.Sellable.ID = CurrentPart.Sellable.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (EvaluationDate).Subtract(PreviousEvaluation.EvaluationDate).Days
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Sellable.Capacity
                End If
            Next CurrentPart
            If Not ManualAverageWorkLoad Then AverageWorkLoad = GetCMT()
            Return False
        End If
    End Function
    Private Function GetCMT() As Decimal
        Dim Value As Decimal
        Value = 5.71
        If Horimeter >= 0 Then
            If Evaluation.HasPreviousEvaluation(Compressor, EvaluationDate, ID) Then
                If Evaluation.GetPreviousEvaluationDate(Compressor, EvaluationDate, ID) <= EvaluationDate Then
                    Value = Evaluation.GetAverageWorkLoad(Compressor, Horimeter, EvaluationDate, ID)
                    If Value = 0 Then Value = 0.01
                    If Value < 0 Then Value = 5.71
                    If Value > 24 And Value < 25 Then Value = 24
                End If
            End If
        End If
        Return Value
    End Function
    Public Shared Function GetEvaluationNumber(CreationType As EvaluationCreationType) As String
        Dim EvaluationNumber As String = String.Empty
        Dim IsUnique As Boolean
        Dim Session = Locator.GetInstance(Of Session)
        Do Until IsUnique
            EvaluationNumber = TextHelper.GetRandomString(1, 8, Nothing, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
            If CreationType = EvaluationCreationType.Automatic Then
                EvaluationNumber = $"A-{EvaluationNumber}"
            ElseIf CreationType = EvaluationCreationType.Imported Then
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
        Return EvaluationNumber
    End Function
End Class
