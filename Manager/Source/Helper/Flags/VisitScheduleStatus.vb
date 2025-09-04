Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar os status do agendamento de visita.
''' </summary>
Public Enum VisitScheduleStatus
    <Description("PENDENTE")> Pending = 0
    <Description("FINALIZADO")> Finished = 1
    <Description("CANCELADO")> Canceled = 2
    <Description("EXCLUÍDO")> Deleted = 3
End Enum