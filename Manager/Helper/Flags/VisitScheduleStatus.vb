Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar os status do agendamento de visita.
''' </summary>
Public Enum VisitScheduleStatus
    <Description("PENDENTE")> Pending = 0
    <Description("INICIADA")> Started = 1
    <Description("FINALIZADA")> Finished = 2
    <Description("CANCELADA")> Canceled = 3
End Enum