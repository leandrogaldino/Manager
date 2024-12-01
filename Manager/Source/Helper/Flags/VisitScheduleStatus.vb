Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar os status do agendamento de visita.
''' </summary>
Public Enum VisitScheduleStatus
    <Description("PENDENTE")> Pending = 0
    <Description("INICIADO")> Started = 1
    <Description("FINALIZADO")> Finished = 2
    <Description("CANCELADO")> Canceled = 3
    <Description("NENHUM")> None = 4
End Enum