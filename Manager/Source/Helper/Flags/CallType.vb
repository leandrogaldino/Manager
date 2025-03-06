Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de chamado.
''' </summary>
Public Enum CallType
    <Description("LEVANTAMENTO")> Gathering = 0
    <Description("PREVENTIVA")> Preventive = 1
    <Description("CHAMADO")> Called = 2
    <Description("CONTRATO")> Contract = 3
    <Description("")> None = 4
End Enum