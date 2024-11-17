﻿Imports System.ComponentModel
Imports ControlLibrary
Public Class PersonCarrierQueriedBoxFilter
    Inherits PersonFilter
    <Browsable(False)>
    Overrides Property Status As String
    <Browsable(False)>
    Overrides Property Category As New PersonCategoryExpandable
    Public Overrides Function Filter() As Boolean
        Status = EnumHelper.GetEnumDescription(SimpleStatus.Active)
        Category.IsCarrier = "Sim"
        Return MyBase.Filter()
    End Function
End Class