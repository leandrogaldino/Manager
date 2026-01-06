Imports System.ComponentModel
Public Enum LicenseMessages
    <Description(Nothing)> None = 0
    <Description("Infelizmente, não conseguimos validar a chave online. Por favor, verifique sua conexão com a internet e tente novamente.")> NetworkNotAvailable = 1
    <Description("Licença do produto não encontrada.")> LicenseFileNotFound = 2
    <Description("A chave do produto não foi informada.")> MissingProductKey = 3
    <Description("A chave do produto que você informou já foi ativada anteriormente. Por favor, verifique se inseriu a chave correta ou entre em contato com o suporte para obter ajuda.")> ProductKeyAlreadyActivatedOnAnother = 4
    <Description("A chave do produto expirou. Por favor, entre em contato com o administrador do sistema para renovar a chave ou obter uma nova chave de produto.")> ExpiredProductKey = 5
    <Description("A chave que você informou não é válida. Por favor, verifique se inseriu a chave correta e tente novamente. Se precisar de mais ajuda, entre em contato com o suporte para obter ajuda.")> InvalidProductKey = 6
    <Description("É necessário validar a chave do produto online para prosseguir.")> OutdatedLocalLicenseKey = 7
    <Description("A chave do produto que você informou está correta, mas também está vinculada a outro cadastro. Por favor, entre em contato com o suporte para obter ajuda.")> DuplicateProductKey = 8
    <Description("A chave do produto que você informou já está ativada neste dispositivo.")> ProductKeyAlreadyActivatedOnThis = 9
    <Description("Senha inválida")> BadPassword = 10
    <Description("Não foi possível acessar o servidor de validação da licença, verifique as credenciais.")> InaccessibleDestination = 11
    <Description("O banco de dados cloud de licença não foi configurado.")> MissingCredentials = 12
End Enum
Public Enum RemoteDatabaseType
    <Description("Cliente")> Customer = 0
    <Description("Sistema")> System = 1
End Enum
