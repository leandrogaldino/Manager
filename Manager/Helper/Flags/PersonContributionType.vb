Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de contribuição de ICMS de uma pessoa.
''' </summary>
Public Enum PersonContributionType
    <Description("CONTRIBUINTE")> TaxPayer = 0
    <Description("NÃO CONTRIBUINTE")> NonTaxPayer = 1
    <Description("ISENTO")> TaxFree = 2
End Enum