Imports System.ComponentModel

Public Class EvaluationInvoicedExpandable
    <DisplayName("Faturado")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Invoiced As String
    <DisplayName("Não Faturado")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property NotInvoiced As String
    <DisplayName("N/A")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property None As String

    Public Sub New()
        Invoiced = "Sim"
        NotInvoiced = "Sim"
        None = "Sim"
    End Sub
    Public Overrides Function ToString() As String
        Dim StausList As New List(Of String)
        If Invoiced = "Sim" Then StausList.Add("Faturado")
        If NotInvoiced = "Sim" Then StausList.Add("Não Faturado")
        If None = "Sim" Then StausList.Add("N/A")
        Return String.Join(", ", StausList)
    End Function
End Class
