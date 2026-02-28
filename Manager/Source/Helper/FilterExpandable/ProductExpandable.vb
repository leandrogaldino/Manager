Imports System.ComponentModel
Public Class ProductExpandable
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property ID As String
    <DisplayName("Código")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Code As String
    <DisplayName("Nome/Nome Curto")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Name As String
    Public Overrides Function ToString() As String
        Dim Str As String = String.Empty
        If ID <> Nothing Then Str += "ID: " & ID & " "
        If Code <> Nothing Then Str += "Código: " & Code & " "
        If Name <> Nothing Then Str += "Nome: " & Name
        Return Str
    End Function
End Class
