Imports System.ComponentModel

Public Class EvaluationSourceExpandable
    <DisplayName("Manual")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Manual As String
    <DisplayName("Automática")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Automatic As String
    <DisplayName("Importada")>
    <NotifyParentProperty(True)>
    <RefreshProperties(RefreshProperties.All)>
    <TypeConverter(GetType(YesNoConverter.WithoutSpace))>
    Public Property Imported As String
    Public Sub New()
        Manual = "Sim"
        Automatic = "Não"
        Imported = "Sim"
    End Sub
    Public Overrides Function ToString() As String
        Dim StausList As New List(Of String)
        If Manual = "Sim" Then StausList.Add("Manual")
        If Automatic = "Sim" Then StausList.Add("Automática")
        If Imported = "Sim" Then StausList.Add("Importada")
        Return String.Join(", ", StausList)
    End Function
End Class
