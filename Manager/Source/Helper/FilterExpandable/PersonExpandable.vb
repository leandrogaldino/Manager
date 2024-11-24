Imports System.ComponentModel
Imports ControlLibrary
Public Class PersonExpandable
    Private _Document As String
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property ID As String
    <DisplayName("CPF/CNPJ")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Document As String
        Get
            Return _Document
        End Get
        Set(value As String)
            _Document = BrazilianFormatHelper.GetFormatedDocument(value)
        End Set
    End Property
    <DisplayName("Nome/Nome Curto")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property Name As String
    Public Overrides Function ToString() As String
        Dim Str As String = String.Empty
        If ID <> Nothing Then Str += "ID: " & ID & " "
        If Document <> Nothing Then Str += "CPF/CNPJ: " & Document & " "
        If Name <> Nothing Then Str += "Nome: " & Name
        Return Str
    End Function
End Class
