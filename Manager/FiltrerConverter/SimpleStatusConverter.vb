Imports System.ComponentModel
Imports ControlLibrary.Utility
Public Class SimpleStatusConverter
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
            GetEnumDescription(SimpleStatus.Active),
            GetEnumDescription(SimpleStatus.Inactive)
        }
        Return New StandardValuesCollection(List)
    End Function
End Class
