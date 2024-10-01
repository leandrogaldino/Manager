Imports System.ComponentModel
Public Class DecimalConverter
    Inherits TypeConverter
    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Return sourceType = GetType(String)
    End Function
    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object) As Object
        If TypeOf value Is String Then
            If IsNumeric(value) Then
                Return FormatNumber(value, 2, TriState.True)
            Else
                Return Nothing
            End If
        End If
        Return MyBase.ConvertFrom(context, culture, value)
    End Function
End Class
