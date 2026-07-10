Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar se a interface do compressor conta as horas de trabalho de forma crescente ou decrescente.
''' </summary>
Public Enum CompressorInterfaceDirection
    <Description("")> None = 0
    <Description("CRESCENTE")> Ascending = 1
    <Description("DECRESCENTE")> Descending = 2
End Enum