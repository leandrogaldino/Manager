Imports System.ComponentModel
Imports ControlLibrary

Public Class CashStatusConverter
    Inherits StringConverter
    Public Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Dim List As New List(Of String) From {
            "",
            EnumHelper.GetEnumDescription(CashStatus.Opened),
            EnumHelper.GetEnumDescription(CashStatus.Closed)
        }
        Return New StandardValuesCollection(List)
    End Function
End Class
