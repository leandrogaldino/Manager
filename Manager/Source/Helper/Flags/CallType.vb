Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de visita.
''' </summary>
Public Enum CallType
    <Description("")> None = 0
    <Description("LEVANTAMENTO")> Gathering = 1
    <Description("PREVENTIVA")> Preventive = 2
    <Description("CORRETIVA")> Corrective = 3
    <Description("CONTRATO")> Contract = 4
End Enum