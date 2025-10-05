Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar a origem da avaliação.
''' </summary>
Public Enum EvaluationSource
    <Description("Manual")> Manual = 0
    <Description("Automática")> Automatic = 1
    <Description("Importada")> Imported = 2
End Enum
