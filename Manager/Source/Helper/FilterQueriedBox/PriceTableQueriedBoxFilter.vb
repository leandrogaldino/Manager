Imports ControlLibrary
Imports System.ComponentModel

Public Class PriceTableQueriedBoxFilter
    Inherits PriceTableFilter
    <Browsable(False)>
    Overrides Property Status As String

    <Browsable(False)>
    Overrides Property Source As String
    Public Overrides Function Filter() As Boolean
        Status = EnumHelper.GetEnumDescription(SimpleStatus.Active)
        Source = EnumHelper.GetEnumDescription(PriceTableSource.FromUser)
        Return MyBase.Filter()
    End Function
End Class



