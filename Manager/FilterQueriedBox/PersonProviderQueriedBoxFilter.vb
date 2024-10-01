Imports System.ComponentModel
Imports ControlLibrary.Utility
Public Class PersonProviderQueriedBoxFilter
    Inherits PersonFilter
    <Browsable(False)>
    Overrides Property Status As String
    <Browsable(False)>
    Overrides Property Category As New PersonCategoryExpandable
    Public Overrides Function Filter() As Boolean
        Status = GetEnumDescription(SimpleStatus.Active)
        Category.IsProvider = "Sim"
        Return MyBase.Filter()
    End Function
End Class
