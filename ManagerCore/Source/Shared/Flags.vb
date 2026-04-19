Imports System.ComponentModel
Public Enum LicenseMessages
    <Description(Nothing)> None
    <Description("O token de vínculo do cliente está vazio ou não foi informado.")> EmptyCustomerLinkToken
    <Description("A rede não está disponível. Verifique sua conexão.")> NetworkNotAvailable
    <Description("O token de vínculo do cliente é inválido.")> InvalidCustomerLinkToken
    <Description("A licença expirou. Entre em contato com o administrador do sistema para regularizar.")> Expired
    <Description("Usuário ou senha inválidos.")> BadUserOrPassword
End Enum

Public Enum RemoteDatabaseType
    <Description("Cliente")> Customer = 0
    <Description("Sistema")> System = 1
End Enum
