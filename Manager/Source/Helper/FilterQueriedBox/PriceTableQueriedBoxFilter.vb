Imports ControlLibrary
Imports System.ComponentModel

Public Class PriceTableQueriedBoxFilter
    Inherits PriceTableFilter
    <Browsable(False)>
    Overrides Property Status As String
    Public Overrides Function Filter() As Boolean
        Status = EnumHelper.GetEnumDescription(SimpleStatus.Active)
        Return MyBase.Filter()
    End Function
End Class
