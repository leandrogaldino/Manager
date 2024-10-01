Imports System.ComponentModel
Public Class PersonCategoryExpandable
    <DisplayName("Cliente")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property IsCustomer As String
    <DisplayName("Fornecedor")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property IsProvider As String
    <DisplayName("Funcionário")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property IsEmployee As String
    <DisplayName("Técnico")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property IsTechnician As String
    <DisplayName("Transportadora")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property IsCarrier As String
    Public Overrides Function ToString() As String
        Dim Str As String = String.Empty
        If IsCustomer = "Sim" Then
            Str += "É Cliente" & " "
        ElseIf IsCustomer = "Não" Then
            Str += "Não é Cliente" & " "
        End If
        If IsProvider = "Sim" Then
            Str += "É Fornecedor" & " "
        ElseIf IsProvider = "Não" Then
            Str += "Não é Fornecedor" & " "
        End If
        If IsEmployee = "Sim" Then
            Str += "É Funcionário" & " "
        ElseIf IsEmployee = "Não" Then
            Str += "Não é Funcionário"
        End If
        If IsTechnician = "Sim" Then
            Str += "É Técnico" & " "
        ElseIf IsEmployee = "Não" Then
            Str += "Não é Técnico"
        End If
        If IsCarrier = "Sim" Then
            Str += "É Transportadora" & " "
        ElseIf IsCarrier = "Não" Then
            Str += "Não é Transportadora" & " "
        End If
        If Str <> Nothing Then
            Str = Trim(UCase(Str(0)) & LCase(Right(Str, Str.Length - 1))) & "."
        End If
        Return Str
    End Function
End Class
