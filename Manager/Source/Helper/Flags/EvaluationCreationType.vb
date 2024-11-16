Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de criação da avaliação.
''' </summary>
Public Enum EvaluationCreationType
    <Description(Nothing)> Manual = 0
    <Description("Avaliação Automática")> Automatic = 0
    <Description("Avaliação Importada")> Imported = 1
End Enum
