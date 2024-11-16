Imports System.ComponentModel
Imports ControlLibrary.Utility
Public Class UpperNoAccentConverter
    Inherits TypeConverter
    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Return sourceType = GetType(String)
    End Function
    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object) As Object
        If TypeOf value Is String Then
            Dim s As String = CStr(value)
            Return RemoveAccents(s.ToUpper)
        End If
        Return MyBase.ConvertFrom(context, culture, value)
    End Function
End Class
