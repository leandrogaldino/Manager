Public Class SellablePriceIndicator
    Inherits ChildModel
    Public Property Indicator As PriceIndicator
    Public Property Price As Decimal

    Public Function GetIndicatorDescription() As String
        Select Case Indicator
            Case PriceIndicator.GrossCost
                Return "Custo do produto incluindo impostos, frete e encargos."
            Case PriceIndicator.NetCost
                Return "Custo do produto descontando impostos e frete e encargos."
            Case PriceIndicator.AverageCost
                Return "Média dos custos líquidos das compras realizadas ao longo do tempo."
            Case PriceIndicator.LastGrossCost
                Return "Último preço de compra incluindo impostos, frete e encargos."
            Case PriceIndicator.LastNetCost
                Return "Último preço de compra descontando impostos e frete e encargos."
            Case PriceIndicator.HighestSale
                Return "Maior valor de venda registrado."
            Case PriceIndicator.LowestSale
                Return "Menor valor de venda registrado."
            Case PriceIndicator.MinimumSale
                Return "Menor valor que pode ser praticado na venda sem prejuízo."
            Case Else
                Return String.Empty
        End Select
    End Function


End Class
