Imports System.ComponentModel

Public Class VisitScheduleStatusExpandable
    <DisplayName("Pendente")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Pending As String
    <DisplayName("Finalizada")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Finished As String
    <DisplayName("Cancelada")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Canceled As String
    Public Sub New()
        Pending = "Sim"
        Finished = "Não"
        Canceled = "Não"
    End Sub
    Public Overrides Function ToString() As String
        Dim StausList As New List(Of String)
        If Pending = "Sim" Then StausList.Add("Pendente")
        If Finished = "Sim" Then StausList.Add("Finalizada")
        If Canceled = "Sim" Then StausList.Add("Cancelada")
        Return String.Join(", ", StausList)
    End Function
End Class
