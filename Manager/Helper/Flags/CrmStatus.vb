Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar os status do Crm.
''' </summary>
Public Enum CrmStatus
    <Description("PENDENTE")> Pending = 0
    <Description("REALIZADO")> Finished = 1
    <Description("PERDIDO")> Lost = 2
End Enum