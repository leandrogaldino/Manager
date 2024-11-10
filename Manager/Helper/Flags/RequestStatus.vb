Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar os status das requisições
''' </summary>
Public Enum RequestStatus
    <Description("PENDENTE")> Pending = 0
    <Description("PARCIAL")> [Partial] = 1
    <Description("CONCLUÍDO")> Concluded = 2
End Enum