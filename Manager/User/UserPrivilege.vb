Public Class UserPrivilege
    Private _ID As Long
    Public ReadOnly Property ID As Long
        Get
            Return _ID
        End Get
    End Property
    Public Property CrmAccess As Boolean
    Public Property CrmWrite As Boolean



    Public Property CrmDelete As Boolean
    Public Property CrmTreatmentDelete As Boolean
    Public Property CrmTreatmentEdit As Boolean
    Public Property CrmChangeResponsible As Boolean
    Public Property CrmChangeSubject As Boolean
    Public Property CrmChangeCustomer As Boolean
    Public Property CrmChangeToPendingStatus As Boolean



    Public Property PersonAccess As Boolean
    Public Property PersonWrite As Boolean
    Public Property PersonDelete As Boolean
    Public Property PersonChangeDocument As Boolean
    Public Property PersonRegistration As Boolean
    Public Property PersonMaintenancePlan As Boolean
    Public Property CityAccess As Boolean
    Public Property CityWrite As Boolean
    Public Property CityDelete As Boolean
    Public Property CompressorAccess As Boolean
    Public Property CompressorWrite As Boolean
    Public Property CompressorDelete As Boolean
    Public Property RouteAccess As Boolean
    Public Property RouteWrite As Boolean
    Public Property RouteDelete As Boolean
    Public Property ProductAccess As Boolean
    Public Property ProductWrite As Boolean
    Public Property ProductDelete As Boolean
    Public Property ProductFamilyAccess As Boolean
    Public Property ProductFamilyWrite As Boolean
    Public Property ProductFamilyDelete As Boolean
    Public Property ProductGroupAccess As Boolean
    Public Property ProductGroupWrite As Boolean
    Public Property ProductGroupDelete As Boolean
    Public Property ProductPriceTableAccess As Boolean
    Public Property ProductPriceTableWrite As Boolean
    Public Property ProductPriceTableDelete As Boolean
    Public Property ProductUnitAccess As Boolean
    Public Property ProductUnitWrite As Boolean
    Public Property ProductUnitDelete As Boolean
    Public Property EvaluationAccess As Boolean
    Public Property EvaluationWrite As Boolean
    Public Property EvaluationDelete As Boolean
    Public Property EvaluationManagementAccess As Boolean
    Public Property EvaluationManagementPanelAccess As Boolean
    Public Property EvaluationApproveOrReject As Boolean


    Public Property VisitScheduleAccess As Boolean = True
    Public Property VisitScheduleWrite As Boolean = True
    Public Property VisitScheduleDelete As Boolean = True

    Public Property CashAccess As Boolean
    Public Property CashWrite As Boolean
    Public Property CashDelete As Boolean
    Public Property CashFlowAccess As Boolean
    Public Property CashFlowWrite As Boolean
    Public Property CashFlowDelete As Boolean
    Public Property CashExpensesPerResponsible As Boolean
    Public Property CashReopen As Boolean
    Public Property RequestAccess As Boolean
    Public Property RequestWrite As Boolean
    Public Property RequestDelete As Boolean
    Public Property RequestPendingItems As Boolean
    Public Property RequestSheet As Boolean
    Public Property UserAccess As Boolean
    Public Property UserWrite As Boolean
    Public Property UserDelete As Boolean
    Public Property UserResetPassword As Boolean
    Public Property UserPrivilegePresetAccess As Boolean
    Public Property UserPrivilegePresetWrite As Boolean
    Public Property UserPrivilegePresetDelete As Boolean
    Public Property SeveralExportGrid As Boolean
    Public Property SeveralLogAccess As Boolean
End Class
