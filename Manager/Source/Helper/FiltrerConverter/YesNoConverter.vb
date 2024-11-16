Imports System.ComponentModel
Public Class YesNoConverter
    Public Class WithSpace
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
                "Sim",
                "Não"
            }
            Return New StandardValuesCollection(List)
        End Function
    End Class
    Public Class WithoutSpace
        Inherits StringConverter
        Public Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function
        Public Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function
        Public Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Dim List As New List(Of String) From {
                "Sim",
                "Não"
            }
            Return New StandardValuesCollection(List)
        End Function
    End Class
End Class