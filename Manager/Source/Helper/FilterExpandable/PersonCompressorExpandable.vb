Imports System.ComponentModel
Public Class PersonCompressorExpandable
    <DisplayName("Nome")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Name As String
    <DisplayName("Número de Série")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property SerialNumber As String
    <DisplayName("Patrimônio")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Patrimony As String
    <DisplayName("Setor")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Sector As String
    <DisplayName("Controlado")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Overridable Property Controlled As String
    Public Overrides Function ToString() As String
        Return Nothing
    End Function
End Class
