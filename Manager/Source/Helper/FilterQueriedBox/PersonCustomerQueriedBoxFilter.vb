Imports System.ComponentModel
Imports ControlLibrary.Utility
Public Class PersonCustomerQueriedBoxFilter
    Inherits PersonFilter
    Private _Maintenance As String
    <Browsable(False)>
    Overrides Property Status As String
    <Browsable(False)>
    Overrides Property Category As New PersonCategoryExpandable
    <Browsable(False)>
    Overrides Property ControlMaintenance As String
    Public Sub New(ControlMaintenance As String)
        _Maintenance = ControlMaintenance
    End Sub
    Public Overrides Function Filter() As Boolean
        Status = GetEnumDescription(SimpleStatus.Active)
        Category.IsCustomer = "Sim"
        If Not String.IsNullOrEmpty(_Maintenance) Then
            ControlMaintenance = _Maintenance
        End If
        Return MyBase.Filter()
    End Function
End Class
