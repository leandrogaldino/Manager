Imports System.ComponentModel
Public Class PersonContactExpandable
    <DisplayName("Nome")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Name As String
    <DisplayName("Cargo")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property JobTitle As String
    <DisplayName("Telefone")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Phone As String
    <DisplayName("E-Mail")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Email As String
    Public Overrides Function ToString() As String
        Return Nothing
    End Function
End Class
