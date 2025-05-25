Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de indicador de preço de produto ou serviço.
''' </summary>
Public Enum PriceIndicator
    <Description("CUSTO BRUTO")> GrossCost = 0
    <Description("CUSTO LÍQUIDO")> NetCost = 1
    <Description("CUSTO MÉDIO")> AverageCost = 2
    <Description("ÚLTIMO CUSTO BRUTO")> LastGrossCost = 3
    <Description("ÚLTIMO CUSTO LÍQUIDO")> LastNetCost = 4
    <Description("MAIOR VENDA")> HighestSale = 5
    <Description("MENOR VENDA")> LowestSale = 6
    <Description("VENDA MÍNIMA")> MinimumSale = 7
End Enum
