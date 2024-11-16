Imports System.ComponentModel
Public Class IntegerExpandable
    Private _MinimumValue As String
    Private _MaximumValue As String
    <DisplayName("Mínimo")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(DecimalConverter))>
    Public Property MinimumValue As String
        Get
            Return _MinimumValue
        End Get
        Set(value As String)
            If IsNumeric(value) Then
                _MinimumValue = FormatNumber(value, 0, TriState.True)
            Else
                _MinimumValue = Nothing
            End If
        End Set
    End Property
    <DisplayName("Máximo")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(DecimalConverter))>
    Public Property MaximumValue As String
        Get
            Return _MaximumValue
        End Get
        Set(value As String)
            If IsNumeric(value) Then
                _MaximumValue = FormatNumber(value, 0, TriState.True)
            Else
                _MaximumValue = Nothing
            End If
        End Set
    End Property
    Public Overrides Function ToString() As String
        If MinimumValue <> Nothing And MaximumValue = Nothing Then
            Return String.Format("A partir de {0}", FormatNumber(MinimumValue, 0, TriState.True))
        ElseIf MinimumValue <> Nothing And MaximumValue <> Nothing Then
            Return String.Format("De {0} a {1}", FormatNumber(MinimumValue, 0, TriState.True), FormatNumber(MaximumValue, 0, TriState.True))
        ElseIf MinimumValue = Nothing And MaximumValue <> Nothing Then
            Return String.Format("Até {0}", FormatNumber(MaximumValue, 0, TriState.True))
        End If
        Return Nothing
    End Function
    Public Sub New()
        MinimumValue = Nothing
        MaximumValue = Nothing
    End Sub
End Class
