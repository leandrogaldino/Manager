Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de avaliação.
''' </summary>
Public Enum EvaluationType
    <Description("LEVANTAMENTO")> Gathering = 0
    <Description("EXECUÇÃO")> Execution = 1
    <Description("N/A")> None = 2
End Enum