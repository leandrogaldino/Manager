Imports System.ComponentModel
Imports ControlLibrary
Public Class EvaluationCallTypeConverter
    Inherits StringConverter
    Public Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Dim List As New List(Of String)(EnumHelper.GetEnumDescriptions(Of CallType))
        List.RemoveAt(List.Count - 1)
        Return New StandardValuesCollection(List)
    End Function
End Class
