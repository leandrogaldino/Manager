Imports System.ComponentModel
Public Class RequestStatusExpandable
    <DisplayName("Pendente")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Pending As String
    <DisplayName("Parcial")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property [Partial] As String
    <DisplayName("Concluído")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Concluded As String
    Public Sub New()
        Pending = "Sim"
        [Partial] = "Sim"
        Concluded = "Não"
    End Sub
    Public Overrides Function ToString() As String
        Dim StausList As New List(Of String)
        If Pending = "Sim" Then StausList.Add("Pendente")
        If [Partial] = "Sim" Then StausList.Add("Parcial")
        If Concluded = "Sim" Then StausList.Add("Concluído")
        Return String.Join(", ", StausList)
    End Function
End Class
