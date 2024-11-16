Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar os status das avaliações de compressor.
''' </summary>
Public Enum EvaluationStatus
    <Description("DESAPROVADA")> Disapproved = 0
    <Description("APROVADA")> Approved = 1
    <Description("REJEITADA")> Rejected = 2
    <Description("REVISADA")> Reviewed = 3
End Enum
