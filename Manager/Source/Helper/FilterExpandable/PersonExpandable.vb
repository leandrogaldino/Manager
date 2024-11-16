Imports System.ComponentModel
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
            Dim Str As String = String.Empty
            If value <> Nothing Then
                Str = value.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")
                If IsNumeric(Str) Then
                    If Str.Length = 14 Then
                        Str = Str.Substring(0, 2) & "." & Str.Substring(2, 3) & "." & Str.Substring(5, 3) & "/" & Str.Substring(8, 4) & "-" & Str.Substring(12, 2)
                        _Document = Str
                    ElseIf Str.Length = 11 Then
                        Str = Str.Substring(0, 3) & "." & Str.Substring(3, 3) & "." & Str.Substring(6, 3) & "-" & Str.Substring(9, 2)
                        _Document = Str
                    Else
                        _Document = value
                    End If
                End If
            End If
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
