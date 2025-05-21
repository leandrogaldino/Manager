Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de tabela de preços.
''' </summary>
Public Enum PriceTableSource
    <Description("USUÁRIO")> FromUser = 0
    <Description("SISTEMA")> FromSystem = 1
End Enum