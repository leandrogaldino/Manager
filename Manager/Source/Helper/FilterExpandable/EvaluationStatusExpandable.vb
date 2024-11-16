Imports System.ComponentModel
Public Class EvaluationStatusExpandable
    <DisplayName("Aprovada")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Approved As String
    <DisplayName("Rejeitada")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Rejected As String
    <DisplayName("Desaprovada")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Disapproved As String
    <DisplayName("Revisada")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Reviewed As String
    Public Sub New()
        Approved = "Sim"
        Rejected = "Sim"
        Disapproved = "Sim"
        Reviewed = "Sim"
    End Sub
    Public Overrides Function ToString() As String
        Dim StausList As New List(Of String)
        If Approved = "Sim" Then StausList.Add("Aprovada")
        If Rejected = "Sim" Then StausList.Add("Rejeitada")
        If Disapproved = "Sim" Then StausList.Add("Desaprovada")
        If Reviewed = "Sim" Then StausList.Add("Revisada")
        Return String.Join(", ", StausList)
    End Function
End Class
