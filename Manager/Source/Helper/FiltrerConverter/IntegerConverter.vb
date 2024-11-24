Imports System.ComponentModel

Public Class IntegerConverter
    Inherits TypeConverter
    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Return sourceType = GetType(String)
    End Function
    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object) As Object
        If TypeOf value Is String Then
            Dim s As String = CStr(value)
            Dim r As Integer
            If Integer.TryParse(s, r) Then
                ' Retorne o valor convertido diretamente.
                Return r.ToString
            Else
                ' Retorne Nothing ou um valor padrão.
                Return Nothing
            End If
        End If
        ' Se não for uma string, delegue ao comportamento padrão.
        Return MyBase.ConvertFrom(context, culture, value)
    End Function
End Class
