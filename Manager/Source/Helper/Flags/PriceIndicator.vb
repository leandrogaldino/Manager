Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de indicador de preço de produto ou serviço.
''' </summary>
Public Enum PriceIndicator
    <Description("CUSTO BRUTO")> GrossCost = 0 'Produto
    <Description("CUSTO LÍQUIDO")> NetCost = 1 'Produto/Serviço
    <Description("CUSTO MÉDIO")> AverageCost = 2 'Produto/Serviço
    <Description("ÚLTIMO CUSTO BRUTO")> LastGrossCost = 3 'Produto
    <Description("ÚLTIMO CUSTO LÍQUIDO")> LastNetCost = 4 'Produto
    <Description("MAIOR VENDA")> HighestSale = 5 'Produto/Serviço
    <Description("MENOR VENDA")> LowestSale = 6 'Produto/Serviço
    <Description("VENDA MÍNIMA")> MinimumSale = 7 'Produto/Serviço
End Enum
