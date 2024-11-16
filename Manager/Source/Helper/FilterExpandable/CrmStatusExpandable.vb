Imports System.ComponentModel

Public Class CrmStatusExpandable
    <DisplayName("Pendente")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property Pending As String
    <DisplayName("Finalizado")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property Finished As String
    <DisplayName("Perdido")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithSpace))>
    Public Property Lost As String
    Public Sub New()
        Pending = ""
        Finished = ""
        Lost = ""
    End Sub
    Public Overrides Function ToString() As String
        Dim StausList As New List(Of String)
        If Pending = "Sim" Then StausList.Add("Pendente")
        If Finished = "Sim" Then StausList.Add("Finalizado")
        If Lost = "Sim" Then StausList.Add("Perdido")
        Return String.Join(", ", StausList)
    End Function
End Class
