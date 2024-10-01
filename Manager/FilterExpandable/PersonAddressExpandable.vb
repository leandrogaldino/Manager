Imports System.ComponentModel
Public Class PersonAddressExpandable
    Private _ZipCode As String
    <DisplayName("Cep")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property ZipCode As String
        Get
            Return _ZipCode
        End Get
        Set(value As String)
            Dim Str As String = String.Empty
            If value <> Nothing Then
                Str = value.Replace(".", "").Replace("-", "").Replace(" ", "")
                If IsNumeric(Str) Then
                    If Str.Length = 8 Then
                        Str = Str.Substring(0, 2) & "." & Str.Substring(2, 3) & "-" & Str.Substring(5, 3)
                    End If
                End If
            End If
            _ZipCode = Str
        End Set
    End Property
    <DisplayName("Endereço")>
    <NotifyParentProperty(True)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Address As String
    <DisplayName("Cidade")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(UpperNoAccentConverter))>
    Public Property City As String
    <DisplayName("Estado")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(StateConverter))>
    Public Property State As String
    Public Overrides Function ToString() As String
        Dim Str As String = String.Empty
        If ZipCode <> Nothing Then Str += "CEP: " & ZipCode & " "
        If Address <> Nothing Then Str += "Endereço: " & Address & " "
        If City <> Nothing Then Str += "Cidade: " & City & " "
        If State <> Nothing Then Str += "Estado: " & State
        Return Str
    End Function
End Class
