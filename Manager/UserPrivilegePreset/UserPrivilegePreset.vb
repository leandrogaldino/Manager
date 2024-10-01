Imports System.Reflection
Imports ControlLibrary
Imports MySql.Data.MySqlClient
''' <summary>
''' Representa uma predefinição de permissões de usuário.
''' </summary>
Public Class UserPrivilegePreset
    Inherits ModelBase
    Private _IsSaved As Boolean
    Public Property Status As SimpleStatus = SimpleStatus.Active
    Public Property Name As String
    Public Property Privilege As New UserPrivilege
    Public Sub New()
        _Routine = Routine.UserPrivilegePreset
    End Sub
    Public Sub Clear()
        Unlock()
        _IsSaved = False
        _ID = 0
        _Creation = Today
        Status = SimpleStatus.Active
        Name = Nothing
        Privilege = New UserPrivilege
    End Sub

    Public Function Load(Identity As Long, LockMe As Boolean) As UserPrivilegePreset
        Dim TableResult As DataTable
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using Tra As MySqlTransaction = Con.BeginTransaction(IsolationLevel.Serializable)
                Using CmdPrivilegePreset As New MySqlCommand(My.Resources.UserPrivilegePresetSelect, Con)
                    CmdPrivilegePreset.Transaction = Tra
                    CmdPrivilegePreset.Parameters.AddWithValue("@id", Identity)
                    Using Adp As New MySqlDataAdapter(CmdPrivilegePreset)
                        TableResult = New DataTable
                        Adp.Fill(TableResult)
                    End Using
                    If TableResult.Rows.Count = 0 Then
                        Clear()
                    ElseIf TableResult.Rows.Count = 1 Then
                        Clear()
                        _ID = TableResult.Rows(0).Item("id")
                        _Creation = TableResult.Rows(0).Item("creation")
                        Status = TableResult.Rows(0).Item("statusid")
                        Name = TableResult.Rows(0).Item("name").ToString
                        Privilege.PersonAccess = TableResult.Rows(0).Item("personaccess")
                        Privilege.PersonWrite = TableResult.Rows(0).Item("personwrite")
                        Privilege.PersonDelete = TableResult.Rows(0).Item("persondelete")
                        Privilege.PersonChangeDocument = TableResult.Rows(0).Item("personchangedocument")
                        Privilege.PersonRegistration = TableResult.Rows(0).Item("personregistration")
                        Privilege.PersonMaintenancePlan = TableResult.Rows(0).Item("personmaintenanceplan")
                        Privilege.CityAccess = TableResult.Rows(0).Item("cityaccess")
                        Privilege.CityWrite = TableResult.Rows(0).Item("citywrite")
                        Privilege.CityDelete = TableResult.Rows(0).Item("citydelete")
                        Privilege.CompressorAccess = TableResult.Rows(0).Item("compressoraccess")
                        Privilege.CompressorWrite = TableResult.Rows(0).Item("compressorwrite")
                        Privilege.CompressorDelete = TableResult.Rows(0).Item("compressordelete")
                        Privilege.RouteAccess = TableResult.Rows(0).Item("routeaccess")
                        Privilege.RouteWrite = TableResult.Rows(0).Item("routewrite")
                        Privilege.RouteDelete = TableResult.Rows(0).Item("routedelete")
                        Privilege.CrmAccess = TableResult.Rows(0).Item("crmaccess")
                        Privilege.CrmWrite = TableResult.Rows(0).Item("crmwrite")

                        Privilege.CrmDelete = TableResult.Rows(0).Item("crmdelete")
                        Privilege.CrmTreatmentDelete = TableResult.Rows(0).Item("crmtreatmentdelete")
                        Privilege.CrmTreatmentEdit = TableResult.Rows(0).Item("crmtreatmentedit")
                        Privilege.CrmChangeCustomer = TableResult.Rows(0).Item("crmchangecustomer")
                        Privilege.CrmChangeResponsible = TableResult.Rows(0).Item("crmchangeresponsible")
                        Privilege.CrmChangeSubject = TableResult.Rows(0).Item("crmchangesubject")
                        Privilege.CrmChangeToPendingStatus = TableResult.Rows(0).Item("crmchangetopendingstatus")


                        Privilege.ProductAccess = TableResult.Rows(0).Item("productaccess")
                        Privilege.ProductWrite = TableResult.Rows(0).Item("productwrite")
                        Privilege.ProductDelete = TableResult.Rows(0).Item("productdelete")
                        Privilege.ProductFamilyAccess = TableResult.Rows(0).Item("productfamilyaccess")
                        Privilege.ProductFamilyWrite = TableResult.Rows(0).Item("productfamilywrite")
                        Privilege.ProductFamilyDelete = TableResult.Rows(0).Item("productfamilydelete")
                        Privilege.ProductGroupAccess = TableResult.Rows(0).Item("productgroupaccess")
                        Privilege.ProductGroupWrite = TableResult.Rows(0).Item("productgroupwrite")
                        Privilege.ProductGroupDelete = TableResult.Rows(0).Item("productgroupdelete")
                        Privilege.ProductPriceTableAccess = TableResult.Rows(0).Item("productpricetableaccess")
                        Privilege.ProductPriceTableWrite = TableResult.Rows(0).Item("productpricetablewrite")
                        Privilege.ProductPriceTableDelete = TableResult.Rows(0).Item("productpricetabledelete")
                        Privilege.ProductUnitAccess = TableResult.Rows(0).Item("productunitaccess")
                        Privilege.ProductUnitWrite = TableResult.Rows(0).Item("productunitwrite")
                        Privilege.ProductUnitDelete = TableResult.Rows(0).Item("productunitdelete")
                        Privilege.EvaluationAccess = TableResult.Rows(0).Item("evaluationaccess")
                        Privilege.EvaluationWrite = TableResult.Rows(0).Item("evaluationwrite")
                        Privilege.EvaluationDelete = TableResult.Rows(0).Item("evaluationdelete")
                        Privilege.EvaluationManagementAccess = TableResult.Rows(0).Item("evaluationmanagementaccess")
                        Privilege.EvaluationManagementPanelAccess = TableResult.Rows(0).Item("evaluationmanagementpanelaccess")
                        Privilege.EvaluationApproveOrReject = TableResult.Rows(0).Item("evaluationapproveorreject")
                        Privilege.CashAccess = TableResult.Rows(0).Item("cashaccess")
                        Privilege.CashWrite = TableResult.Rows(0).Item("cashwrite")
                        Privilege.CashDelete = TableResult.Rows(0).Item("cashdelete")
                        Privilege.CashFlowAccess = TableResult.Rows(0).Item("cashflowaccess")
                        Privilege.CashFlowWrite = TableResult.Rows(0).Item("cashflowwrite")
                        Privilege.CashFlowDelete = TableResult.Rows(0).Item("cashflowdelete")
                        Privilege.CashExpensesPerResponsible = TableResult.Rows(0).Item("cashexpensesperresponsible")
                        Privilege.CashReopen = TableResult.Rows(0).Item("cashreopen")
                        Privilege.RequestAccess = TableResult.Rows(0).Item("requestaccess")
                        Privilege.RequestWrite = TableResult.Rows(0).Item("requestwrite")
                        Privilege.RequestDelete = TableResult.Rows(0).Item("requestdelete")
                        Privilege.RequestPendingItems = TableResult.Rows(0).Item("requestpendingitems")
                        Privilege.RequestSheet = TableResult.Rows(0).Item("requestsheet")
                        Privilege.UserAccess = TableResult.Rows(0).Item("useraccess")
                        Privilege.UserWrite = TableResult.Rows(0).Item("userwrite")
                        Privilege.UserDelete = TableResult.Rows(0).Item("userdelete")
                        Privilege.UserResetPassword = TableResult.Rows(0).Item("userresetpassword")
                        Privilege.UserPrivilegePresetAccess = TableResult.Rows(0).Item("userprivilegepresetaccess")
                        Privilege.UserPrivilegePresetWrite = TableResult.Rows(0).Item("userprivilegepresetwrite")
                        Privilege.UserPrivilegePresetDelete = TableResult.Rows(0).Item("userprivilegepresetdelete")
                        Privilege.SeveralExportGrid = TableResult.Rows(0).Item("severalexportgrid")
                        Privilege.SeveralLogAccess = TableResult.Rows(0).Item("severallogaccess")
                        Privilege.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(Privilege, TableResult.Rows(0).Item("id"))
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
    Public Sub SaveChanges()
        If Not _IsSaved Then
            Insert()
        Else
            Update()
        End If
        _IsSaved = True
    End Sub
    Public Sub Delete()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPrivilegePreset As New MySqlCommand(My.Resources.UserPrivilegePresetDelete, Con)
                CmdPrivilegePreset.Parameters.AddWithValue("@id", ID)
                CmdPrivilegePreset.ExecuteNonQuery()
                Clear()
            End Using
        End Using
    End Sub
    Private Sub Insert()
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPrivilegePreset As New MySqlCommand(My.Resources.UserPrivilegePresetInsert, Con)
                CmdPrivilegePreset.Parameters.AddWithValue("@creation", Creation.ToString("yyyy-MM-dd"))
                CmdPrivilegePreset.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdPrivilegePreset.Parameters.AddWithValue("@name", Name)
                CmdPrivilegePreset.Parameters.AddWithValue("@personaccess", Privilege.PersonAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@personwrite", Privilege.PersonWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@persondelete", Privilege.PersonDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@personchangedocument", Privilege.PersonDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@personregistration", Privilege.PersonRegistration)
                CmdPrivilegePreset.Parameters.AddWithValue("@personmaintenanceplan", Privilege.PersonMaintenancePlan)
                CmdPrivilegePreset.Parameters.AddWithValue("@cityaccess", Privilege.CityAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@citywrite", Privilege.CityWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@citydelete", Privilege.CityDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@compressoraccess", Privilege.CompressorAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@compressorwrite", Privilege.CompressorWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@compressordelete", Privilege.CompressorDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@routeaccess", Privilege.RouteAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@routewrite", Privilege.RouteWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@routedelete", Privilege.RouteDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmaccess", Privilege.CrmAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmwrite", Privilege.CrmWrite)

                CmdPrivilegePreset.Parameters.AddWithValue("@crmdelete", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmtreatmentdelete", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmtreatmentedit", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangecustomer", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangeresponsible", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangesubject", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangetopendingstatus", Privilege.CrmWrite)

                CmdPrivilegePreset.Parameters.AddWithValue("@productaccess", Privilege.ProductAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productwrite", Privilege.ProductWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productdelete", Privilege.ProductDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productfamilyaccess", Privilege.ProductFamilyAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productfamilywrite", Privilege.ProductFamilyWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productfamilydelete", Privilege.ProductFamilyDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productgroupaccess", Privilege.ProductGroupAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productgroupwrite", Privilege.ProductGroupWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productgroupdelete", Privilege.ProductGroupDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productpricetableaccess", Privilege.ProductPriceTableAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productpricetablewrite", Privilege.ProductPriceTableWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productpricetabledelete", Privilege.ProductPriceTableDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productunitaccess", Privilege.ProductUnitAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productunitwrite", Privilege.ProductUnitWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productunitdelete", Privilege.ProductUnitDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationaccess", Privilege.EvaluationAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationwrite", Privilege.EvaluationWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationdelete", Privilege.EvaluationDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationmanagementaccess", Privilege.EvaluationManagementAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationmanagementpanelaccess", Privilege.EvaluationManagementPanelAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationapproveorreject", Privilege.EvaluationApproveOrReject)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashaccess", Privilege.CashAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashwrite", Privilege.CashWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashdelete", Privilege.CashDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashflowaccess", Privilege.CashFlowAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashflowwrite", Privilege.CashFlowWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashflowdelete", Privilege.CashFlowDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashexpensesperresponsible", Privilege.CashExpensesPerResponsible)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashreopen", Privilege.CashReopen)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestaccess", Privilege.RequestAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestwrite", Privilege.RequestWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestdelete", Privilege.RequestDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestpendingitems", Privilege.RequestPendingItems)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestsheet", Privilege.RequestSheet)
                CmdPrivilegePreset.Parameters.AddWithValue("@useraccess", Privilege.UserAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@userwrite", Privilege.UserWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@userdelete", Privilege.UserDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@userresetpassword", Privilege.UserResetPassword)
                CmdPrivilegePreset.Parameters.AddWithValue("@userprivilegepresetaccess", Privilege.UserPrivilegePresetAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@userprivilegepresetwrite", Privilege.UserPrivilegePresetWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@userprivilegepresetdelete", Privilege.UserPrivilegePresetDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@severalexportgrid", Privilege.SeveralExportGrid)
                CmdPrivilegePreset.Parameters.AddWithValue("@severallogaccess", Privilege.SeveralLogAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@userid", Locator.GetInstance(Of Session).User.ID)
                CmdPrivilegePreset.ExecuteNonQuery()
                _ID = CmdPrivilegePreset.LastInsertedId
            End Using
        End Using
    End Sub
    Private Sub Update()
        Dim Shadow As Product = New Product().Load(ID, False)
        Using Con As New MySqlConnection(Locator.GetInstance(Of Session).Setting.Database.GetConnectionString())
            Con.Open()
            Using CmdPrivilegePreset As New MySqlCommand(My.Resources.UserPrivilegePresetUpdate, Con)
                CmdPrivilegePreset.Parameters.AddWithValue("@id", Privilege.ID)
                CmdPrivilegePreset.Parameters.AddWithValue("@statusid", CInt(Status))
                CmdPrivilegePreset.Parameters.AddWithValue("@name", Name)
                CmdPrivilegePreset.Parameters.AddWithValue("@personaccess", Privilege.PersonAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@personwrite", Privilege.PersonWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@persondelete", Privilege.PersonDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@personchangedocument", Privilege.PersonChangeDocument)
                CmdPrivilegePreset.Parameters.AddWithValue("@personregistration", Privilege.PersonRegistration)
                CmdPrivilegePreset.Parameters.AddWithValue("@personmaintenanceplan", Privilege.PersonMaintenancePlan)
                CmdPrivilegePreset.Parameters.AddWithValue("@cityaccess", Privilege.CityAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@citywrite", Privilege.CityWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@citydelete", Privilege.CityDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@compressoraccess", Privilege.CompressorAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@compressorwrite", Privilege.CompressorWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@compressordelete", Privilege.CompressorDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@routeaccess", Privilege.RouteAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@routewrite", Privilege.RouteWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@routedelete", Privilege.RouteDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmaccess", Privilege.CrmAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmwrite", Privilege.CrmWrite)

                CmdPrivilegePreset.Parameters.AddWithValue("@crmdelete", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmtreatmentdelete", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmtreatmentedit", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangecustomer", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangeresponsible", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangesubject", Privilege.CrmWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@crmchangetopendingstatus", Privilege.CrmWrite)

                CmdPrivilegePreset.Parameters.AddWithValue("@productaccess", Privilege.ProductAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productwrite", Privilege.ProductWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productdelete", Privilege.ProductDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productfamilyaccess", Privilege.ProductFamilyAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productfamilywrite", Privilege.ProductFamilyWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productfamilydelete", Privilege.ProductFamilyDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productgroupaccess", Privilege.ProductGroupAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productgroupwrite", Privilege.ProductGroupWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productgroupdelete", Privilege.ProductGroupDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productpricetableaccess", Privilege.ProductPriceTableAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productpricetablewrite", Privilege.ProductPriceTableWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productpricetabledelete", Privilege.ProductPriceTableDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@productunitaccess", Privilege.ProductUnitAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@productunitwrite", Privilege.ProductUnitWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@productunitdelete", Privilege.ProductUnitDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationaccess", Privilege.EvaluationAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationwrite", Privilege.EvaluationWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationdelete", Privilege.EvaluationDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationmanagementaccess", Privilege.EvaluationManagementAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationmanagementpanelaccess", Privilege.EvaluationManagementPanelAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@evaluationapproveorreject", Privilege.EvaluationApproveOrReject)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashaccess", Privilege.CashAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashwrite", Privilege.CashWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashdelete", Privilege.CashDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashflowaccess", Privilege.CashFlowAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashflowwrite", Privilege.CashFlowWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashflowdelete", Privilege.CashFlowDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@cashexpensesperresponsible", Privilege.CashExpensesPerResponsible)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestaccess", Privilege.RequestAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestwrite", Privilege.RequestWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestdelete", Privilege.RequestDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestpendingitems", Privilege.RequestPendingItems)
                CmdPrivilegePreset.Parameters.AddWithValue("@requestsheet", Privilege.RequestSheet)
                CmdPrivilegePreset.Parameters.AddWithValue("@useraccess", Privilege.UserAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@userwrite", Privilege.UserWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@userdelete", Privilege.UserDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@userresetpassword", Privilege.UserResetPassword)
                CmdPrivilegePreset.Parameters.AddWithValue("@userprivilegepresetaccess", Privilege.UserPrivilegePresetAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@userprivilegepresetwrite", Privilege.UserPrivilegePresetWrite)
                CmdPrivilegePreset.Parameters.AddWithValue("@userprivilegepresetdelete", Privilege.UserPrivilegePresetDelete)
                CmdPrivilegePreset.Parameters.AddWithValue("@severalexportgrid", Privilege.SeveralExportGrid)
                CmdPrivilegePreset.Parameters.AddWithValue("@severallogaccess", Privilege.SeveralLogAccess)
                CmdPrivilegePreset.Parameters.AddWithValue("@userid", User.ID)
                CmdPrivilegePreset.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Overrides Function ToString() As String
        Return If(Name, String.Empty)
    End Function
End Class
