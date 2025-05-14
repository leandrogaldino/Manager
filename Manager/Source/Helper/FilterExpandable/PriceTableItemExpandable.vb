Imports System.ComponentModel

Public Class PriceTableItemExpandable
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Código/Nome")>
    Public Property CodeOrName As String
    <DisplayName("Preço")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Price As New DecimalExpandable

    Public Overrides Function ToString() As String
        Return Nothing
    End Function
End Class
