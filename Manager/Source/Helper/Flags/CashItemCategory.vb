Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar a categoria de um item do caixa.
''' </summary>
Public Enum CashItemCategory
    <Description("SUPERMERCADO")> Supermarket = 0
    <Description("ALIMENTAÇÃO")> Food = 1
    <Description("COMBUSTÍVEL")> Fuel = 2
    <Description("HOSPEDAGEM")> Accommodation = 3
    <Description("DESPESA ADM.")> AdministrativeExpense = 4
    <Description("DESPESA OP.")> OperationalExpense = 5
    <Description("REEMBOLSO")> Refund = 6
    <Description("ADIANTAMENTO PGTO")> PaymentAdvance = 7
End Enum