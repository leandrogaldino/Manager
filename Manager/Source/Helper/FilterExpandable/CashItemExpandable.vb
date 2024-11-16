Imports System.ComponentModel
Public Class CashItemExpandable
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Descrição")>
    Public Property Description As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <DisplayName("Nº Documento")>
    Public Property DocumentNumber As String
    <DisplayName("Data Documento")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property DocumentDate As New DateExpandable
    <DisplayName("Valor")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Value As New DecimalExpandable
    <DisplayName("Responsável")>
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Property Responsible As New PersonExpandable
    Public Overrides Function ToString() As String
        Return Nothing
    End Function
End Class
