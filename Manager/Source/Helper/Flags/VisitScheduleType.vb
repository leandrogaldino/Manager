Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo da visita.
''' </summary>
Public Enum VisitScheduleType
    <Description("LEVANTAMENTO")> Gathering = 0
    <Description("PREVENTIVA")> Preventive = 1
    <Description("CHAMADO")> Called = 2
    <Description("CONTRATO")> Contract = 3
End Enum