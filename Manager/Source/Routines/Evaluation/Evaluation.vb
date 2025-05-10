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
                    For Each p In PartsWorkedHour.ToArray.Reverse
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
                    For Each p In PartsElapsedDay.ToArray.Reverse
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
    Public Property PartsWorkedHour As New List(Of EvaluationPart)
    Public Property PartsElapsedDay As New List(Of EvaluationPart)
    Public Property ReplacedItems As New List(Of EvaluationReplacedItem)
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
        PartsWorkedHour = New List(Of EvaluationPart)
        PartsElapsedDay = New List(Of EvaluationPart)
        ReplacedItems = New List(Of EvaluationReplacedItem)
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
                        GetParts(Tra)
                        GetReplacedItems(Tra)
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
    Private Sub GetParts(Transaction As MySqlTransaction)
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
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).SetID(Row.Item("id"))
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).SetCreation(Row.Item("creation"))
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).SetIsSaved(True)
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).CurrentCapacity = Row.Item("currentcapacity")
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Sold = Row.Item("sold")
                        PartsWorkedHour.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Lost = Row.Item("lost")
                    Else
                        Part = New EvaluationPart(CompressorPartType.WorkedHour) With {
                            .Part = Compressor.PartsWorkedHour.Single(Function(x) x.ID = Row.Item("personcompressorpartid")),
                            .CurrentCapacity = Row.Item("currentcapacity"),
                            .Sold = Row.Item("sold"),
                            .Lost = Row.Item("lost")
                        }
                        Part.SetID(Row.Item("id"))
                        Part.SetCreation(Row.Item("creation"))
                        Part.SetIsSaved(True)
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
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).SetIsSaved(True)
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).SetID(Row.Item("id"))
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).SetCreation(Row.Item("creation"))
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).CurrentCapacity = Row.Item("currentcapacity")
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Sold = Row.Item("sold")
                        PartsElapsedDay.Single(Function(x) x.Part.ID = Row.Item("personcompressorpartid")).Lost = Row.Item("lost")
                    Else
                        Part = New EvaluationPart(CompressorPartType.ElapsedDay) With {
                            .Part = Compressor.PartsElapsedDay.Single(Function(x) x.ID = Row.Item("personcompressorpartid")),
                            .CurrentCapacity = Row.Item("currentcapacity"),
                            .Sold = Row.Item("sold"),
                            .Lost = Row.Item("lost")
                        }
                        Part.SetIsSaved(True)
                        Part.SetID(Row.Item("id"))
                        Part.SetCreation(Row.Item("creation"))
                        PartsElapsedDay.Add(Part)
                    End If
                Next Row
            End Using
        End Using
    End Sub
    Private Sub GetReplacedItems(Transaction As MySqlTransaction)
        Dim TableResult As DataTable
        Dim Item As EvaluationReplacedItem
        Using CmdEvaluationItem As New MySqlCommand(My.Resources.EvaluationReplacedItemSelect, Transaction.Connection)
            CmdEvaluationItem.Transaction = Transaction
            CmdEvaluationItem.Parameters.AddWithValue("@evaluationid", ID)
            Using Adp As New MySqlDataAdapter(CmdEvaluationItem)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                For Each Row As DataRow In TableResult.Rows
                    Item = New EvaluationReplacedItem With {
                        .ItemName = Row.Item("itemname").ToString,
                        .Product = New Product().Load(Row.Item("productid"), False),
                        .Quantity = Row.Item("quantity")
                    }
                    Item.SetIsSaved(True)
                    Item.SetID(Row.Item("id"))
                    Item.SetCreation(Row.Item("creation"))
                    ReplacedItems.Add(Item)
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
        PartsWorkedHour.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        PartsElapsedDay.ToList().ForEach(Sub(x) x.SetIsSaved(True))
        ReplacedItems.ToList().ForEach(Sub(x) x.SetIsSaved(True))
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
                        PartWorkedHour.SetID(CmdPartWorkedHour.LastInsertedId)
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
                        PartElapsedDay.SetID(CmdPartElapsedDay.LastInsertedId)
                    End Using
                Next PartElapsedDay
                For Each Item As EvaluationReplacedItem In ReplacedItems
                    Using CmdItem As New MySqlCommand(My.Resources.EvaluationReplacedItemInsert, Con)
                        CmdItem.Parameters.AddWithValue("@evaluationid", ID)
                        CmdItem.Parameters.AddWithValue("@creation", Item.Creation)
                        CmdItem.Parameters.AddWithValue("@statusid", CInt(Status))
                        CmdItem.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(Item.ItemName), DBNull.Value, Item.ItemName))
                        CmdItem.Parameters.AddWithValue("@productid", If(Item.Product.ID = 0, DBNull.Value, Item.Product.ID))
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
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next Technician
                If Compressor.ID <> _Shadow.Compressor.ID Then
                    For Each ShadowPartWorkedHour As EvaluationPart In _Shadow.PartsWorkedHour.Where(Function(x) x.ID <> 0)
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
                            PartWorkedHour.SetID(CmdPartWorkedHour.LastInsertedId)
                        End Using
                    Next PartWorkedHour
                    For Each ShadowPartElapsedDay As EvaluationPart In _Shadow.PartsElapsedDay.Where(Function(x) x.ID <> 0)
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
                            PartElapsedDay.SetID(CmdPartElapsedDay.LastInsertedId)
                        End Using
                    Next PartElapsedDay
                Else
                    For Each PartWorkedHour As EvaluationPart In _Shadow.PartsWorkedHour
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
                                PartWorkedHour.SetID(CmdPartWorkedHour.LastInsertedId)
                            End Using
                        Else
                            Using CmdPartWorkedHour As New MySqlCommand(My.Resources.EvaluationPartUpdate, Con)
                                CmdPartWorkedHour.Parameters.AddWithValue("@id", _Shadow.PartsWorkedHour.First(Function(x) x.Guid = PartWorkedHour.Guid).ID)
                                CmdPartWorkedHour.Parameters.AddWithValue("@currentcapacity", PartWorkedHour.CurrentCapacity)
                                CmdPartWorkedHour.Parameters.AddWithValue("@sold", PartWorkedHour.Sold)
                                CmdPartWorkedHour.Parameters.AddWithValue("@lost", PartWorkedHour.Lost)
                                CmdPartWorkedHour.Parameters.AddWithValue("@userid", PartWorkedHour.User.ID)
                                CmdPartWorkedHour.ExecuteNonQuery()
                            End Using
                        End If
                    Next PartWorkedHour
                    For Each PartElapsedDay As EvaluationPart In _Shadow.PartsElapsedDay
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
                                PartElapsedDay.SetID(CmdPartElapsedDay.LastInsertedId)
                            End Using
                        Else
                            Using CmdPartElapsedDay As New MySqlCommand(My.Resources.EvaluationPartUpdate, Con)
                                CmdPartElapsedDay.Parameters.AddWithValue("@id", _Shadow.PartsElapsedDay.First(Function(x) x.Guid = PartElapsedDay.Guid).ID)
                                CmdPartElapsedDay.Parameters.AddWithValue("@currentcapacity", PartElapsedDay.CurrentCapacity)
                                CmdPartElapsedDay.Parameters.AddWithValue("@sold", PartElapsedDay.Sold)
                                CmdPartElapsedDay.Parameters.AddWithValue("@lost", PartElapsedDay.Lost)
                                CmdPartElapsedDay.Parameters.AddWithValue("@userid", PartElapsedDay.User.ID)
                                CmdPartElapsedDay.ExecuteNonQuery()
                            End Using
                        End If
                    Next PartElapsedDay
                End If
                For Each Item As EvaluationReplacedItem In _Shadow.ReplacedItems
                    If Not ReplacedItems.Any(Function(x) x.ID = Item.ID And x.ID > 0) Then
                        Using CmdItem As New MySqlCommand(My.Resources.EvaluationReplacedItemDelete, Con)
                            CmdItem.Parameters.AddWithValue("@id", Item.ID)
                            CmdItem.ExecuteNonQuery()
                        End Using
                    End If
                Next Item
                For Each Item As EvaluationReplacedItem In ReplacedItems
                    If Item.ID = 0 Then
                        Using CmdItem As New MySqlCommand(My.Resources.EvaluationReplacedItemInsert, Con)
                            CmdItem.Parameters.AddWithValue("@evaluationid", ID)
                            CmdItem.Parameters.AddWithValue("@creation", Item.Creation)
                            CmdItem.Parameters.AddWithValue("@statusid", CInt(Status))
                            CmdItem.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(Item.ItemName), DBNull.Value, Item.ItemName))
                            CmdItem.Parameters.AddWithValue("@productid", If(Item.Product.ID = 0, DBNull.Value, Item.Product.ID))
                            CmdItem.Parameters.AddWithValue("@quantity", Item.Quantity)
                            CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdItem.ExecuteNonQuery()
                            Item.SetID(CmdItem.LastInsertedId)
                        End Using
                    Else
                        Using CmdItem As New MySqlCommand(My.Resources.EvaluationReplacedItemUpdate, Con)
                            CmdItem.Parameters.AddWithValue("@id", Item.ID)
                            CmdItem.Parameters.AddWithValue("@itemname", If(String.IsNullOrEmpty(Item.ItemName), DBNull.Value, Item.ItemName))
                            CmdItem.Parameters.AddWithValue("@productid", If(Item.Product.ID = 0, DBNull.Value, Item.Product.ID))
                            CmdItem.Parameters.AddWithValue("@quantity", Item.Quantity)
                            CmdItem.Parameters.AddWithValue("@userid", Item.User.ID)
                            CmdItem.ExecuteNonQuery()
                        End Using
                    End If
                Next Item
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
        Dim Coalescent As EvaluationPart
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
        Dim AirFilter As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBindType.AirFilter).ToList
        Dim OilFilter As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBindType.OilFilter).ToList
        Dim Separator As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBindType.Separator).ToList
        Dim Oil As List(Of EvaluationPart) = Evaluation.PartsWorkedHour.Where(Function(x) x.Part.PartBind = CompressorPartBindType.Oil).ToList

        Evaluation.PartsWorkedHour.ToList.ForEach(Sub(x)
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
            Coalescent = Evaluation.PartsElapsedDay.Where(Function(y) y.Part.PartBinded).FirstOrDefault(Function(x) x.Part.ID = CoalescentData("coalescentid"))
            If Coalescent IsNot Nothing Then
                Coalescent.CurrentCapacity = DateDiff(DateInterval.Day, Today, DateTimeHelper.DateFromMilliseconds((CoalescentData("nextchange"))))
                Coalescent.Sold = False
                Coalescent.Lost = False
            End If
        Next CoalescentData
        Evaluation.PartsElapsedDay.ForEach(Sub(x) x.SetIsSaved(True))
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
        Dim PreviousPart As EvaluationPart
        If Horimeter < PreviousEvaluation.Horimeter Then
            For Each CurrentPart As EvaluationPart In PartsWorkedHour
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                End If
            Next CurrentPart
            For Each CurrentPart As EvaluationPart In PartsElapsedDay
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsElapsedDay.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                End If
            Next CurrentPart
            If Not ManualAverageWorkLoad Then AverageWorkLoad = PreviousEvaluation.AverageWorkLoad
            Return True
        Else
            For Each CurrentPart As EvaluationPart In PartsWorkedHour
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsWorkedHour.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (Horimeter - PreviousEvaluation.Horimeter)
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
                End If
            Next CurrentPart
            For Each CurrentPart As EvaluationPart In PartsElapsedDay
                CurrentPart.Sold = False
                CurrentPart.Lost = False
                PreviousPart = PreviousEvaluation.PartsElapsedDay.FirstOrDefault(Function(x) x.Part.ID = CurrentPart.Part.ID)
                If PreviousPart IsNot Nothing AndAlso PreviousPart.IsSaved Then
                    CurrentPart.CurrentCapacity = PreviousPart.CurrentCapacity - (EvaluationDate).Subtract(PreviousEvaluation.EvaluationDate).Days
                Else
                    CurrentPart.CurrentCapacity = CurrentPart.Part.Capacity
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
