Imports System.Reflection
Imports ControlLibrary
Imports ManagerCore
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa um usuário.
''' </summary>
Public Class User
    Inherits ModelBase
    Private _IsSaved As Boolean
    Private _UserID As Long = If(Locator.GetInstance(Of Session).User IsNot Nothing, Locator.GetInstance(Of Session).User.ID, 0)
    Private _PersonID As Long
    Private _Password As String = Locator.GetInstance(Of Session).Setting.General.User.DefaultPassword
    Public ReadOnly RequestPassword As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Username As String = String.Empty
    Public ReadOnly Property Password As String
        Get
            Return _Password
        End Get
    End Property
    Public Property Person As New Lazy(Of Person)(Function() New Person().Load(_PersonID, False))
    Public Property Note As String
    Public Property Privilege As New UserPrivilege
    Public Property Emails As New OrdenedList(Of UserEmail)
    Public Shadows User As New Lazy(Of User)(Function() New User().Load(_UserID, False))
    Public Sub New()
        _Routine = Routine.User
    End Sub
    Public Sub ResetPassword()
        Dim Session = Locator.GetInstance(Of Session)
        Dim CryptoKey = Locator.GetInstance(Of CryptoKeyService)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.UserChangePassword, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@password", Cryptography.Encrypt(Session.Setting.General.User.DefaultPassword, CryptoKey.ReadCryptoKey()))
                Cmd.Parameters.AddWithValue("@requestnewpassword", True)
                Cmd.ExecuteNonQuery()
                Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, True)
            End Using
        End Using
    End Sub
    Public Sub ChangePassword(NewPassword As String)
        Dim Session = Locator.GetInstance(Of Session)
        Dim CryptoKey = Locator.GetInstance(Of CryptoKeyService)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Cmd As New MySqlCommand(My.Resources.UserChangePassword, Con)
                Cmd.Parameters.AddWithValue("@id", ID)
                Cmd.Parameters.AddWithValue("@password", Cryptography.Encrypt(NewPassword, CryptoKey.ReadCryptoKey()))
                Cmd.Parameters.AddWithValue("@requestnewpassword", False)
                Cmd.ExecuteNonQuery()
                Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, False)
            End Using
        End Using
    End Sub
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _UserID = 0
        Status = SimpleStatus.Active
        Username = Nothing
        _Password = Nothing
        Person = New Lazy(Of Person)(Function() New Person().Load(_PersonID, False))
        Privilege = New UserPrivilege
        Emails = New OrdenedList(Of UserEmail)
        Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, False)
        User = New Lazy(Of User)(Function() New User().Load(_UserID, False))
    End Sub
    Public Function Load(Identity As Long, LockMe As Boolean) As User
        Dim Session = Locator.GetInstance(Of Session)
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdUserSelect As New MySqlCommand(My.Resources.UserSelect, Con)
                    CmdUserSelect.Transaction = Tra
                    CmdUserSelect.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdUserSelect)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                        If TableResult.Rows.Count = 0 Then
                            Clear()
                        ElseIf TableResult.Rows.Count = 1 Then
                            Clear()
                            _ID = TableResult.Rows(0).Item("id")
                            _UserID = _ID
                            _PersonID = TableResult.Rows(0).Item("personid")
                            _Creation = TableResult.Rows(0).Item("creation")
                            Status = TableResult.Rows(0).Item("statusid")
                            Username = TableResult.Rows(0).Item("username").ToString
                            _Password = TableResult.Rows(0).Item("password").ToString
                            Note = TableResult.Rows(0).Item("note").ToString
                            Me.GetType.GetField("RequestPassword", BindingFlags.Instance Or BindingFlags.Public).SetValue(Me, CBool(TableResult.Rows(0).Item("requestnewpassword")))
                            Privilege = GetUserPrivilege(Tra)
                            Emails = GetEmails(Tra)
                            LockInfo = GetLockInfo(Tra)
                            If LockMe And Not LockInfo.IsLocked Then Lock(Tra)
                            _IsSaved = True
                        Else
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
        If Not _IsSaved Then
            Insert()
        Else
            Update()
        End If
        _IsSaved = True
        Emails.ToList().ForEach(Sub(x) x.IsSaved = True)
    End Sub
    Public Sub Delete()
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdUserDelete As New MySqlCommand(My.Resources.UserDelete, Con)
                CmdUserDelete.Parameters.AddWithValue("@id", ID)
                CmdUserDelete.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Dim Session = Locator.GetInstance(Of Session)
        Dim CryptoKey = Locator.GetInstance(Of CryptoKeyService)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdUserInsert As New MySqlCommand(My.Resources.UserInsert, Con)
                    CmdUserInsert.Transaction = Tra
                    CmdUserInsert.Parameters.AddWithValue("@id", DBNull.Value)
                    CmdUserInsert.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                    CmdUserInsert.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdUserInsert.Parameters.AddWithValue("@username", Username)
                    CmdUserInsert.Parameters.AddWithValue("@password", Cryptography.Encrypt(Password, CryptoKey.ReadCryptoKey()))
                    CmdUserInsert.Parameters.AddWithValue("@personid", If(Person.Value.ID = 0, DBNull.Value, Person.Value.ID))
                    CmdUserInsert.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdUserInsert.Parameters.AddWithValue("@requestnewpassword", True)
                    CmdUserInsert.Parameters.AddWithValue("@userid", Session.User.ID)
                    CmdUserInsert.ExecuteNonQuery()
                    _ID = CmdUserInsert.LastInsertedId
                End Using
                For Each Email As UserEmail In Emails
                    Using CmdUserEmailInsert As New MySqlCommand(My.Resources.UserEmailInsert, Con)
                        CmdUserEmailInsert.Transaction = Tra
                        CmdUserEmailInsert.Parameters.AddWithValue("@ofuserid", ID)
                        CmdUserEmailInsert.Parameters.AddWithValue("@ismainemail", Email.IsMainEmail)
                        CmdUserEmailInsert.Parameters.AddWithValue("@creation", Email.Creation)
                        CmdUserEmailInsert.Parameters.AddWithValue("@host", If(String.IsNullOrEmpty(Email.SmtpServer), DBNull.Value, Email.SmtpServer))
                        CmdUserEmailInsert.Parameters.AddWithValue("@port", Email.Port)
                        CmdUserEmailInsert.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Email.Email), DBNull.Value, Email.Email))
                        CmdUserEmailInsert.Parameters.AddWithValue("@password", If(String.IsNullOrEmpty(Email.Password), DBNull.Value, Email.Password))
                        CmdUserEmailInsert.Parameters.AddWithValue("@enablessl", Email.EnableSSL)
                        CmdUserEmailInsert.Parameters.AddWithValue("@ofuserid", ID)
                        CmdUserEmailInsert.Parameters.AddWithValue("@userid", Session.User.ID)
                        CmdUserEmailInsert.ExecuteNonQuery()
                        Email.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(Email, CmdUserEmailInsert.LastInsertedId)
                    End Using
                Next Email
                Using CmdUserPrivilegeInsert As New MySqlCommand(My.Resources.UserPrivilegeInsert, Con)
                    CmdUserPrivilegeInsert.Transaction = Tra
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@ofuserid", ID)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmaccess", Privilege.CrmAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmwrite", Privilege.CrmWrite)

                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmdelete", Privilege.CrmDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmtreatmentdelete", Privilege.CrmTreatmentDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmtreatmentedit", Privilege.CrmTreatmentEdit)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmchangecustomer", Privilege.CrmChangeCustomer)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmchangeresponsible", Privilege.CrmChangeResponsible)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmchangesubject", Privilege.CrmChangeSubject)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@crmchangetopendingstatus", Privilege.CrmChangeToPendingStatus)

                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@personaccess", Privilege.PersonAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@personwrite", Privilege.PersonWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@persondelete", Privilege.PersonDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@personchangedocument", Privilege.PersonChangeDocument)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@personregistration", Privilege.PersonRegistration)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@personmaintenanceplan", Privilege.PersonMaintenancePlan)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cityaccess", Privilege.CityAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@citywrite", Privilege.CityWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@citydelete", Privilege.CityDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@compressoraccess", Privilege.CompressorAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@compressorwrite", Privilege.CompressorWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@compressordelete", Privilege.CompressorDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@routeaccess", Privilege.RouteAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@routewrite", Privilege.RouteWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@routedelete", Privilege.RouteDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productaccess", Privilege.ProductAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productwrite", Privilege.ProductWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productdelete", Privilege.ProductDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productfamilyaccess", Privilege.ProductFamilyAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productfamilywrite", Privilege.ProductFamilyWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productfamilydelete", Privilege.ProductFamilyDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productgroupaccess", Privilege.ProductGroupAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productgroupwrite", Privilege.ProductGroupWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productgroupdelete", Privilege.ProductGroupDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productpricetableaccess", Privilege.ProductPriceTableAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productpricetablewrite", Privilege.ProductPriceTableWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productpricetabledelete", Privilege.ProductPriceTableDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productunitaccess", Privilege.ProductUnitAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productunitwrite", Privilege.ProductUnitWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@productunitdelete", Privilege.ProductUnitDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@evaluationaccess", Privilege.EvaluationAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@evaluationwrite", Privilege.EvaluationWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@evaluationdelete", Privilege.EvaluationDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@evaluationmanagementaccess", Privilege.EvaluationManagementAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@evaluationmanagementpanelaccess", Privilege.EvaluationManagementPanelAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@evaluationapproveorreject", Privilege.EvaluationApproveOrReject)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashaccess", Privilege.CashAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashwrite", Privilege.CashWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashdelete", Privilege.CashDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashflowaccess", Privilege.CashFlowAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashflowwrite", Privilege.CashFlowWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashflowdelete", Privilege.CashFlowDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashexpensesperresponsible", Privilege.CashExpensesPerResponsible)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@cashreopen", Privilege.CashReopen)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@requestaccess", Privilege.RequestAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@requestwrite", Privilege.RequestWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@requestdelete", Privilege.RequestDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@requestpendingitems", Privilege.RequestPendingItems)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@requestsheet", Privilege.RequestSheet)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@useraccess", Privilege.UserAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@userwrite", Privilege.UserWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@userdelete", Privilege.UserDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@userresetpassword", Privilege.UserResetPassword)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@userprivilegepresetaccess", Privilege.UserPrivilegePresetAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@userprivilegepresetwrite", Privilege.UserPrivilegePresetWrite)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@userprivilegepresetdelete", Privilege.UserPrivilegePresetDelete)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@severalexportgrid", Privilege.SeveralExportGrid)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@severallogaccess", Privilege.SeveralLogAccess)
                    CmdUserPrivilegeInsert.Parameters.AddWithValue("@userid", Session.User.ID)
                    CmdUserPrivilegeInsert.ExecuteNonQuery()
                    Privilege.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(Privilege, CmdUserPrivilegeInsert.LastInsertedId)
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Session = Locator.GetInstance(Of Session)
        Dim Shadow As User = New User().Load(ID, False)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdUser As New MySqlCommand(My.Resources.UserUpdate, Con)
                    CmdUser.Transaction = Tra
                    CmdUser.Parameters.AddWithValue("@id", ID)
                    CmdUser.Parameters.AddWithValue("@statusid", CInt(Status))
                    CmdUser.Parameters.AddWithValue("@username", Username)
                    CmdUser.Parameters.AddWithValue("@personid", If(Person.Value.ID = 0, DBNull.Value, Person.Value.ID))
                    CmdUser.Parameters.AddWithValue("@note", If(String.IsNullOrEmpty(Note), DBNull.Value, Note))
                    CmdUser.Parameters.AddWithValue("@userid", Session.User.ID)
                    CmdUser.ExecuteNonQuery()
                End Using
                For Each Email As UserEmail In Shadow.Emails
                    If Not Emails.Any(Function(x) x.ID = Email.ID And x.ID > 0) Then
                        Using CmdEmail As New MySqlCommand(My.Resources.UserEmailDelete, Con)
                            CmdEmail.Transaction = Tra
                            CmdEmail.Parameters.AddWithValue("@id", Email.ID)
                            CmdEmail.ExecuteNonQuery()
                        End Using
                    End If
                Next Email
                For Each Email As UserEmail In Emails
                    If Email.ID = 0 Then
                        Using CmdEmail As New MySqlCommand(My.Resources.UserEmailInsert, Con)
                            CmdEmail.Transaction = Tra
                            CmdEmail.Parameters.AddWithValue("@ofuserid", ID)
                            CmdEmail.Parameters.AddWithValue("@ismainemail", Email.IsMainEmail)
                            CmdEmail.Parameters.AddWithValue("@creation", Email.Creation)
                            CmdEmail.Parameters.AddWithValue("@id", Email.ID)
                            CmdEmail.Parameters.AddWithValue("@host", If(String.IsNullOrEmpty(Email.SmtpServer), DBNull.Value, Email.SmtpServer))
                            CmdEmail.Parameters.AddWithValue("@port", Email.Port)
                            CmdEmail.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Email.Email), DBNull.Value, Email.Email))
                            CmdEmail.Parameters.AddWithValue("@password", If(String.IsNullOrEmpty(Email.Password), DBNull.Value, Email.Password))
                            CmdEmail.Parameters.AddWithValue("@enablessl", Email.EnableSSL)
                            CmdEmail.Parameters.AddWithValue("@userid", Session.User.ID)
                            CmdEmail.ExecuteNonQuery()
                            Email.[GetType].GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Email, CmdEmail.LastInsertedId)
                        End Using
                    Else
                        Using CmdEmail As New MySqlCommand(My.Resources.UserEmailUpdate, Con)
                            CmdEmail.Transaction = Tra
                            CmdEmail.Parameters.AddWithValue("@id", Email.ID)
                            CmdEmail.Parameters.AddWithValue("@ismainemail", Email.IsMainEmail)
                            CmdEmail.Parameters.AddWithValue("@host", If(String.IsNullOrEmpty(Email.SmtpServer), DBNull.Value, Email.SmtpServer))
                            CmdEmail.Parameters.AddWithValue("@port", Email.Port)
                            CmdEmail.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(Email.Email), DBNull.Value, Email.Email))
                            CmdEmail.Parameters.AddWithValue("@password", If(String.IsNullOrEmpty(Email.Password), DBNull.Value, Email.Password))
                            CmdEmail.Parameters.AddWithValue("@enablessl", Email.EnableSSL)
                            CmdEmail.Parameters.AddWithValue("@userid", Email.User.ID)
                            CmdEmail.ExecuteNonQuery()
                        End Using
                    End If
                Next Email
                Using CmdPrivilegeUpdate As New MySqlCommand(My.Resources.UserPrivilegeUpdate, Con)
                    CmdPrivilegeUpdate.Transaction = Tra
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@id", Privilege.ID)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmaccess", Privilege.CrmAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmwrite", Privilege.CrmWrite)

                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmdelete", Privilege.CrmDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmtreatmentdelete", Privilege.CrmTreatmentDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmtreatmentedit", Privilege.CrmTreatmentEdit)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmchangecustomer", Privilege.CrmChangeCustomer)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmchangeresponsible", Privilege.CrmChangeResponsible)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmchangesubject", Privilege.CrmChangeSubject)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@crmchangetopendingstatus", Privilege.CrmChangeToPendingStatus)

                    CmdPrivilegeUpdate.Parameters.AddWithValue("@personaccess", Privilege.PersonAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@personwrite", Privilege.PersonWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@persondelete", Privilege.PersonDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@personchangedocument", Privilege.PersonChangeDocument)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@personregistration", Privilege.PersonRegistration)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@personmaintenanceplan", Privilege.PersonMaintenancePlan)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cityaccess", Privilege.CityAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@citywrite", Privilege.CityWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@citydelete", Privilege.CityDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@compressoraccess", Privilege.CompressorAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@compressorwrite", Privilege.CompressorWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@compressordelete", Privilege.CompressorDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@routeaccess", Privilege.RouteAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@routewrite", Privilege.RouteWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@routedelete", Privilege.RouteDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productaccess", Privilege.ProductAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productwrite", Privilege.ProductWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productdelete", Privilege.ProductDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productfamilyaccess", Privilege.ProductFamilyAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productfamilywrite", Privilege.ProductFamilyWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productfamilydelete", Privilege.ProductFamilyDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productgroupaccess", Privilege.ProductGroupAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productgroupwrite", Privilege.ProductGroupWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productgroupdelete", Privilege.ProductGroupDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productpricetableaccess", Privilege.ProductPriceTableAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productpricetablewrite", Privilege.ProductPriceTableWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productpricetabledelete", Privilege.ProductPriceTableDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productunitaccess", Privilege.ProductUnitAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productunitwrite", Privilege.ProductUnitWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@productunitdelete", Privilege.ProductUnitDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@evaluationaccess", Privilege.EvaluationAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@evaluationwrite", Privilege.EvaluationWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@evaluationdelete", Privilege.EvaluationDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@evaluationmanagementaccess", Privilege.EvaluationManagementAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@evaluationmanagementpanelaccess", Privilege.EvaluationManagementPanelAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@evaluationapproveorreject", Privilege.EvaluationApproveOrReject)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashaccess", Privilege.CashAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashwrite", Privilege.CashWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashdelete", Privilege.CashDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashflowaccess", Privilege.CashFlowAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashflowwrite", Privilege.CashFlowWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashflowdelete", Privilege.CashFlowDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashexpensesperresponsible", Privilege.CashExpensesPerResponsible)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@cashreopen", Privilege.CashReopen)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@requestaccess", Privilege.RequestAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@requestwrite", Privilege.RequestWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@requestdelete", Privilege.RequestDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@requestpendingitems", Privilege.RequestPendingItems)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@requestsheet", Privilege.RequestSheet)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@useraccess", Privilege.UserAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@userwrite", Privilege.UserWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@userdelete", Privilege.UserDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@userresetpassword", Privilege.UserResetPassword)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@userprivilegepresetaccess", Privilege.UserPrivilegePresetAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@userprivilegepresetwrite", Privilege.UserPrivilegePresetWrite)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@userprivilegepresetdelete", Privilege.UserPrivilegePresetDelete)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@severalexportgrid", Privilege.SeveralExportGrid)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@severallogaccess", Privilege.SeveralLogAccess)
                    CmdPrivilegeUpdate.Parameters.AddWithValue("@userid", Session.User.ID)
                    CmdPrivilegeUpdate.ExecuteNonQuery()
                End Using
                Tra.Commit()
            End Using
        End Using
    End Sub
    Private Function GetEmails(Transaction As MySqlTransaction) As OrdenedList(Of UserEmail)
        Dim TableResult As DataTable
        Dim Emails As OrdenedList(Of UserEmail)
        Dim Email As UserEmail
        Using CmdEmail As New MySqlCommand(My.Resources.UserEmailSelect, Transaction.Connection)
            CmdEmail.Transaction = Transaction
            CmdEmail.Parameters.AddWithValue("@ofuserid", ID)
            Using Adp As New MySqlDataAdapter(CmdEmail)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                Emails = New OrdenedList(Of UserEmail)
                For Each Row As DataRow In TableResult.Rows
                    Email = New UserEmail
                    Email.IsMainEmail = Row.Item("ismainemail")
                    Email.SmtpServer = Row.Item("host").ToString
                    Email.Port = Row.Item("port")
                    Email.Email = Row.Item("email").ToString
                    Email.EnableSSL = Row.Item("enablessl").ToString
                    Email.Password = Row.Item("password").ToString
                    Email.IsSaved = True
                    Email.GetType.GetField("_ID", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Email, Row.Item("id"))
                    Email.GetType.GetField("_Creation", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(Email, Row.Item("creation"))
                    Emails.Add(Email)
                Next Row
            End Using
        End Using
        Return Emails
    End Function
    Private Function GetUserPrivilege(Transaction As MySqlTransaction) As UserPrivilege
        Dim Privilege As New UserPrivilege
        Dim TableResult As DataTable
        Using Cmd As New MySqlCommand(My.Resources.UserPrivilegeSelect, Transaction.Connection)
            Cmd.Transaction = Transaction
            Cmd.Parameters.AddWithValue("@ofuserid", ID)
            Using Adp As New MySqlDataAdapter(Cmd)
                TableResult = New DataTable
                Adp.Fill(TableResult)
                If TableResult.Rows.Count = 1 Then
                    Privilege = New UserPrivilege With {
                        .CrmAccess = TableResult.Rows(0).Item("crmaccess"),
                        .CrmWrite = TableResult.Rows(0).Item("crmwrite"),
                        .CrmDelete = TableResult.Rows(0).Item("crmdelete"),
                        .CrmTreatmentDelete = TableResult.Rows(0).Item("crmtreatmentdelete"),
                        .CrmTreatmentEdit = TableResult.Rows(0).Item("crmtreatmentedit"),
                        .CrmChangeCustomer = TableResult.Rows(0).Item("crmchangecustomer"),
                        .CrmChangeResponsible = TableResult.Rows(0).Item("crmchangeresponsible"),
                        .CrmChangeSubject = TableResult.Rows(0).Item("crmchangesubject"),
                        .CrmChangeToPendingStatus = TableResult.Rows(0).Item("crmchangetopendingstatus"),
                        .PersonAccess = TableResult.Rows(0).Item("personaccess"),
                        .PersonWrite = TableResult.Rows(0).Item("personwrite"),
                        .PersonDelete = TableResult.Rows(0).Item("persondelete"),
                        .PersonChangeDocument = TableResult.Rows(0).Item("personchangedocument"),
                        .PersonRegistration = TableResult.Rows(0).Item("personregistration"),
                        .PersonMaintenancePlan = TableResult.Rows(0).Item("personmaintenanceplan"),
                        .CityAccess = TableResult.Rows(0).Item("cityaccess"),
                        .CityWrite = TableResult.Rows(0).Item("citywrite"),
                        .CityDelete = TableResult.Rows(0).Item("citydelete"),
                        .CompressorAccess = TableResult.Rows(0).Item("compressoraccess"),
                        .CompressorWrite = TableResult.Rows(0).Item("compressorwrite"),
                        .CompressorDelete = TableResult.Rows(0).Item("compressordelete"),
                        .RouteAccess = TableResult.Rows(0).Item("routeaccess"),
                        .RouteWrite = TableResult.Rows(0).Item("routewrite"),
                        .RouteDelete = TableResult.Rows(0).Item("routedelete"),
                        .ProductAccess = TableResult.Rows(0).Item("productaccess"),
                        .ProductWrite = TableResult.Rows(0).Item("productwrite"),
                        .ProductDelete = TableResult.Rows(0).Item("productdelete"),
                        .ProductFamilyAccess = TableResult.Rows(0).Item("productfamilyaccess"),
                        .ProductFamilyWrite = TableResult.Rows(0).Item("productfamilywrite"),
                        .ProductFamilyDelete = TableResult.Rows(0).Item("productfamilydelete"),
                        .ProductGroupAccess = TableResult.Rows(0).Item("productgroupaccess"),
                        .ProductGroupWrite = TableResult.Rows(0).Item("productgroupwrite"),
                        .ProductGroupDelete = TableResult.Rows(0).Item("productgroupdelete"),
                        .ProductPriceTableAccess = TableResult.Rows(0).Item("productpricetableaccess"),
                        .ProductPriceTableWrite = TableResult.Rows(0).Item("productpricetablewrite"),
                        .ProductPriceTableDelete = TableResult.Rows(0).Item("productpricetabledelete"),
                        .ProductUnitAccess = TableResult.Rows(0).Item("productunitaccess"),
                        .ProductUnitWrite = TableResult.Rows(0).Item("productunitwrite"),
                        .ProductUnitDelete = TableResult.Rows(0).Item("productunitdelete"),
                        .EvaluationAccess = TableResult.Rows(0).Item("evaluationaccess"),
                        .EvaluationWrite = TableResult.Rows(0).Item("evaluationwrite"),
                        .EvaluationDelete = TableResult.Rows(0).Item("evaluationdelete"),
                        .EvaluationManagementAccess = TableResult.Rows(0).Item("evaluationmanagementaccess"),
                        .EvaluationManagementPanelAccess = TableResult.Rows(0).Item("evaluationmanagementpanelaccess"),
                        .EvaluationApproveOrReject = TableResult.Rows(0).Item("evaluationapproveorreject"),
                        .CashAccess = TableResult.Rows(0).Item("cashaccess"),
                        .CashWrite = TableResult.Rows(0).Item("cashwrite"),
                        .CashDelete = TableResult.Rows(0).Item("cashdelete"),
                        .CashFlowAccess = TableResult.Rows(0).Item("cashflowaccess"),
                        .CashFlowWrite = TableResult.Rows(0).Item("cashflowwrite"),
                        .CashFlowDelete = TableResult.Rows(0).Item("cashflowdelete"),
                        .CashExpensesPerResponsible = TableResult.Rows(0).Item("cashexpensesperresponsible"),
                        .CashReopen = TableResult.Rows(0).Item("cashreopen"),
                        .RequestAccess = TableResult.Rows(0).Item("requestaccess"),
                        .RequestWrite = TableResult.Rows(0).Item("requestwrite"),
                        .RequestDelete = TableResult.Rows(0).Item("requestdelete"),
                        .RequestPendingItems = TableResult.Rows(0).Item("requestpendingitems"),
                        .RequestSheet = TableResult.Rows(0).Item("requestsheet"),
                        .UserAccess = TableResult.Rows(0).Item("useraccess"),
                        .UserWrite = TableResult.Rows(0).Item("userwrite"),
                        .UserDelete = TableResult.Rows(0).Item("userdelete"),
                        .UserResetPassword = TableResult.Rows(0).Item("userresetpassword"),
                        .UserPrivilegePresetAccess = TableResult.Rows(0).Item("userprivilegepresetaccess"),
                        .UserPrivilegePresetWrite = TableResult.Rows(0).Item("userprivilegepresetwrite"),
                        .UserPrivilegePresetDelete = TableResult.Rows(0).Item("userprivilegepresetdelete"),
                        .SeveralExportGrid = TableResult.Rows(0).Item("severalexportgrid"),
                        .SeveralLogAccess = TableResult.Rows(0).Item("severallogaccess")
                    }
                    Privilege.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(Privilege, TableResult.Rows(0).Item("id"))
                End If
            End Using
        End Using
        Return Privilege
    End Function
    Public Shared Sub FillTreeViewNodes(Tvw As TreeView)
        Tvw.Nodes.Add(New TreeNode With {.Name = "EvaluationAccess", .Text = "Avaliação", .Tag = "Especifica se o usuário pode acessar as avaliações de compressores."})
        Tvw.Nodes.Find("EvaluationAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EvaluationWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar avaliações de compressores."})
        Tvw.Nodes.Find("EvaluationAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EvaluationDelete", .Text = "Exluir", .Tag = "Especifica se o usuário pode excluir avaliações de compressores."})
        Tvw.Nodes.Find("EvaluationAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EvaluationManagementAccess", .Text = "Gerenciamento", .Tag = "Especifica se o usuário pode acessar o gerenciador de avaliações de compressores."})
        Tvw.Nodes.Find("EvaluationAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EvaluationManagementPanelAccess", .Text = "Painel", .Tag = "Especifica se o usuário pode acessar o painel de avaliações de compressores."})
        Tvw.Nodes.Find("EvaluationAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EvaluationApproveOrReject", .Text = "Aprovar/Rejeitar", .Tag = "Especifica se o usuário pode aprovar ou rejeitar as avaliações de compressores."})
        Tvw.Nodes.Add(New TreeNode With {.Name = "CashAccess", .Text = "Caixa", .Tag = "Especifica se o usuário pode acessar o caixa."})
        Tvw.Nodes.Find("CashAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CashWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o caixa."})
        Tvw.Nodes.Find("CashAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CashDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o caixa."})
        Tvw.Nodes.Find("CashAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CashReopen", .Text = "Reabrir Caixa", .Tag = "Especifica se o usuário pode abrir um caixa fechado."})
        Tvw.Nodes.Find("CashAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CashFlowAccess", .Text = "Fluxo de Caixa", .Tag = "Especifica se o usuário pode acessar o cadastro de fluxo de caixa."})
        Tvw.Nodes.Find("CashFlowAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CashFlowWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o fluxo de caixa."})
        Tvw.Nodes.Find("CashFlowAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CashFlowDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de fluxo de caixa."})
        Tvw.Nodes.Find("CashAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CashReport", .Text = "Relatórios", .Tag = "Contém relatórios do caixa."})
        Tvw.Nodes.Find("CashReport", True)(0).Nodes.Add(New TreeNode With {.Name = "CashExpensesPerResponsible", .Text = "Despesas Por Responsável", .Tag = "Especifica se o usuário pode acessar o relatório de despesas por responsável."})
        Tvw.Nodes.Add(New TreeNode With {.Name = "PersonAccess", .Text = "Pessoa", .Tag = "Especifica se o usuário pode acessar o cadastro de pessoas."})
        Tvw.Nodes.Find("PersonAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "PersonWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuario pode incluir ou editar o cadastro de pessoas."})
        Tvw.Nodes.Find("PersonAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "PersonDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de pessoas."})
        Tvw.Nodes.Find("PersonAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "PersonChangeDocument", .Text = "Alterar Documento", .Tag = "Especifica se o usuário pode alterar o CPF ou CNPJ de uma pessoa já cadastrada."})
        Tvw.Nodes.Find("PersonAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CityAccess", .Text = "Cidade", .Tag = "Especifica se o usuário pode acessar o cadastro de cidades."})
        Tvw.Nodes.Find("CityAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CityWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de cidades."})
        Tvw.Nodes.Find("CityAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CityDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de cidades."})
        Tvw.Nodes.Find("PersonAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "RouteAccess", .Text = "Rota", .Tag = "Especifica se o usuário pode acessar o cadastro de rotas."})
        Tvw.Nodes.Add(New TreeNode With {.Name = "CrmAccess", .Text = "CRM", .Tag = "Especifica se o usuário pode acessar o CRM."})
        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuario pode incluir ou editar o cadastro de CRM."})

        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmDelete", .Text = "Excluir", .Tag = "Especifica se o usuario pode excluir o cadastro de CRM."})
        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmTreatmentDelete", .Text = "Excluir Atendimento", .Tag = "Especifica se o usuario pode excluir atendimentos do CRM depois de salvo."})
        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmTreatmentEdit", .Text = "Editar Atendimento", .Tag = "Especifica se o usuario pode editar atendimentos do CRM depois de salvo."})
        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmChangeResponsible", .Text = "Alterar Responsável", .Tag = "Especifica se o usuario pode alterar o responsável pelo CRM depois de salvo."})
        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmChangeCustomer", .Text = "Alterar Cliente", .Tag = "Especifica se o usuario pode alterar o cliente do CRM depois de salvo."})
        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmChangeSubject", .Text = "Alterar Assunto", .Tag = "Especifica se o usuario pode alterar o assunto do CRM depois de salvo."})
        Tvw.Nodes.Find("CrmAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CrmChangeToPendingStatus", .Text = "Alterar Status Para Pendente", .Tag = "Especifica se o usuario pode alterar o status de volta para pendente."})


        Tvw.Nodes.Add(New TreeNode With {.Name = "RequestAccess", .Text = "Requisição", .Tag = "Especifica se o usuário pode acessar as requisições."})
        Tvw.Nodes.Find("RequestAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "RequestWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar requisições."})
        Tvw.Nodes.Find("RequestAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "RequestDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o requisições."})
        Tvw.Nodes.Find("RequestAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "RequestReport", .Text = "Relatórios", .Tag = "Contém relatórios da Requisição."})
        Tvw.Nodes.Find("RequestReport", True)(0).Nodes.Add(New TreeNode With {.Name = "RequestPendingItems", .Text = "Itens Pendentes", .Tag = "Especifica se o usuário pode acessar o relatório de itens pendentes nas requisições."})
        Tvw.Nodes.Find("RequestReport", True)(0).Nodes.Add(New TreeNode With {.Name = "RequestSheet", .Text = "Folha de Requisição", .Tag = "Especifica se o usuário pode acessar o relatório de folha de requisição."})
        Tvw.Nodes.Find("RouteAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "RouteWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de rotas."})
        Tvw.Nodes.Find("RouteAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "RouteDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de rotas."})
        Tvw.Nodes.Find("PersonAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CompressorAccess", .Text = "Compressor", .Tag = "Especifica se o usuário pode acessar o cadastro de compressores."})
        Tvw.Nodes.Find("CompressorAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CompressorWrite", .Text = "Incluir", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de compressores."})
        Tvw.Nodes.Find("CompressorAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "CompressorDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de compressores."})
        Tvw.Nodes.Find("PersonAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "PersonReport", .Text = "Relatórios", .Tag = "Contém relatórios do cadastro de pessoas."})
        Tvw.Nodes.Find("PersonReport", True)(0).Nodes.Add(New TreeNode With {.Name = "PersonRegistration", .Text = "Ficha Cadastral", .Tag = "Especifica se o usuário pode acessar o relatório de ficha cadastral da pessoa."})
        Tvw.Nodes.Find("PersonReport", True)(0).Nodes.Add(New TreeNode With {.Name = "PersonMaintenancePlan", .Text = "Plano de Manutenção", .Tag = "Especifica se o usuário pode acessar o relatório de plano de manutenção de compressor."})
        Tvw.Nodes.Add(New TreeNode With {.Name = "ProductAccess", .Text = "Produto", .Tag = "Especifica se o usuário pode acessar o cadastro de produtos."})
        Tvw.Nodes.Find("ProductAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de produtos."})
        Tvw.Nodes.Find("ProductAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de produtos."})
        Tvw.Nodes.Find("ProductAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductFamilyAccess", .Text = "Família de Produto", .Tag = "Especifica se o usuário pode acessar o cadastro de família de produto."})
        Tvw.Nodes.Find("ProductFamilyAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductFamilyWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de família de produto."})
        Tvw.Nodes.Find("ProductFamilyAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductFamilyDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de família de produto."})
        Tvw.Nodes.Find("ProductAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductGroupAccess", .Text = "Grupo de Produto", .Tag = "Especifica se o usuário pode acessar o cadastro de grupo de produto."})
        Tvw.Nodes.Find("ProductGroupAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductGroupWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de grupo de produto."})
        Tvw.Nodes.Find("ProductGroupAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductGroupDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de grupo de produto."})
        Tvw.Nodes.Find("ProductAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductPriceTableAccess", .Text = "Tabela de Preços de Produto", .Tag = "Especifica se o usuário pode acessar o cadastro de tabela de preços de produto."})
        Tvw.Nodes.Find("ProductPriceTableAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductPriceTableWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de tabela de preços de produto."})
        Tvw.Nodes.Find("ProductPriceTableAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductPriceTableDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de tabela de preços de produto."})
        Tvw.Nodes.Find("ProductAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductUnitAccess", .Text = "Unidade de Medida de Produto", .Tag = "Especifica se o usuário pode acessar o cadastro de unidade de medida do produto."})
        Tvw.Nodes.Find("ProductUnitAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductUnitWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de unidade de medida do produto."})
        Tvw.Nodes.Find("ProductUnitAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "ProductUnitDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de unidade de medida de produto."})
        Tvw.Nodes.Add(New TreeNode With {.Name = "UserAccess", .Text = "Usuário", .Tag = "Especifica se o usuário pode acessar o cadastro de usuários."})
        Tvw.Nodes.Find("UserAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "UserWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de usuários."})
        Tvw.Nodes.Find("UserAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "UserDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de usuários."})
        Tvw.Nodes.Find("UserAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "UserResetPassword", .Text = "Resetar Senha", .Tag = "Especifica se o usuário pode resetar a senha de usuários."})
        Tvw.Nodes.Find("UserAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "UserPrivilegePresetAccess", .Text = "Predefinição de Permissões", .Tag = "Especifica se o usuário pode acessar o cadastro de predefinição de permissões do usuário."})
        Tvw.Nodes.Find("UserPrivilegePresetAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "UserPrivilegePresetWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro de predefinição de permissões do usuário."})
        Tvw.Nodes.Find("UserPrivilegePresetAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "UserPrivilegePresetDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de predefinição de permissões do usuário."})
        Tvw.Nodes.Find("UserAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EmailModelAccess", .Text = "Modelo de E-mail", .Tag = "Especifica se o usuário pode acessar o cadastro de modelos de e-mail."})
        Tvw.Nodes.Find("EmailModelAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EmailModelWrite", .Text = "Incluir/Editar", .Tag = "Especifica se o usuário pode incluir ou editar o cadastro modelos de e-mail."})
        Tvw.Nodes.Find("EmailModelAccess", True)(0).Nodes.Add(New TreeNode With {.Name = "EmailModelDelete", .Text = "Excluir", .Tag = "Especifica se o usuário pode excluir o cadastro de modelo de e-mail."})
        Tvw.Nodes.Add(New TreeNode With {.Name = "Several", .Text = "Diversos", .Tag = "Contém permissões diversas."})
        Tvw.Nodes.Find("Several", True)(0).Nodes.Add(New TreeNode With {.Name = "SeveralExportGrid", .Text = "Exportar Grade", .Tag = "Especifica se o usuário pode exportar as grades nas telas de filtro de registro de cada rotina."})
        Tvw.Nodes.Find("Several", True)(0).Nodes.Add(New TreeNode With {.Name = "SeveralLogAccess", .Text = "Histórico", .Tag = "Especifica se o usuário pode acessar o histórico de registro através do botão localizado no canto superior direito da tela do registro."})
    End Sub
    Public Shared Function HasPerson(PersonID As Long) As Boolean
        Dim Session = Locator.GetInstance(Of Session)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.UserHasPersonSelect, Con)
                Cmd.Parameters.AddWithValue("@personid", PersonID)
                Con.Open()
                Return Cmd.ExecuteScalar
            End Using
        End Using
    End Function
    Public Shared Function GetUsersPersonSortName() As List(Of String)
        Dim Session = Locator.GetInstance(Of Session)
        Dim Username As String
        Dim Usernames As New List(Of String)
        Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
            Using Cmd As New MySqlCommand(My.Resources.UserPersonShortNameSelect, Con)
                Con.Open()
                Using Reader As MySqlDataReader = Cmd.ExecuteReader()
                    While Reader.Read
                        Username = Reader.GetString("shortname").ToString
                        Usernames.Add(Username)
                    End While
                End Using
            End Using
        End Using
        Return Usernames
    End Function
    Public Overrides Function ToString() As String
        Return If(Username, String.Empty)
    End Function
End Class
