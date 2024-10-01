Imports System.ComponentModel
Public Enum CompressorPartBind
    <Description("NENHUM")> None = 0
    <Description("FILTRO DE AR")> AirFilter = 1
    <Description("FILTRO DE OLEO")> OilFilter = 2
    <Description("ELEMENTO SEPARADOR")> Separator = 3
    <Description("OLEO")> Oil = 4
    <Description("COALESCENTE")> Coalescent = 5
End Enum

Public Enum EvaluationPanelInformation
        <Description("VISITAS")> Visits = 0
        <Description("TÉCNICO X PRODUTIVIDADE")> Productivity = 1
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar os status simples dos registros.
    ''' </summary>
    Public Enum SimpleStatus
        <Description("ATIVO")> Active = 0
        <Description("INATIVO")> Inactive = 1
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar os status do caixa.
    ''' </summary>
    Public Enum CashStatus
        <Description("ABERTO")> Opened = 0
        <Description("FECHADO")> Closed = 1
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar os status do Crm.
    ''' </summary>
    Public Enum CrmStatus
        <Description("PENDENTE")> Pending = 0
        <Description("REALIZADO")> Finished = 1
        <Description("PERDIDO")> Lost = 2
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar os status das avaliações de compressor.
    ''' </summary>
    Public Enum EvaluationStatus
        <Description("DESAPROVADA")> Disapproved = 0
        <Description("APROVADA")> Approved = 1
        <Description("REJEITADA")> Rejected = 2
        <Description("REVISADA")> Reviewed = 3
    End Enum
''' <summary>
''' Utilizado para sinalizar o tipo de avaliação.
''' </summary>
Public Enum EvaluationType
    <Description("LEVANTAMENTO")> Gathering = 0
    <Description("EXECUÇÃO")> Execution = 1
End Enum
''' <summary>
''' Utilizado para sinalizar o tipo de criação da avaliação.
''' </summary>
Public Enum EvaluationCreationType
    <Description(nothing)> Manual = 0
    <Description("Avaliação Automática")> Automatic = 1
    <Description("Avaliação Importada")> Imported = 1
End Enum
''' <summary>
''' Utilizado para sinalizar os status das requisições
''' </summary>
Public Enum RequestStatus
        <Description("PENDENTE")> Pending = 0
        <Description("PARCIAL")> [Partial] = 1
        <Description("CONCLUÍDO")> Concluded = 2
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar o tipo de entidade de uma pessoa.<br/>0 = Pessoa Jurídica | 1 = Pessoa Física
    ''' </summary>
    Public Enum PersonEntity
        <Description("PESSOA JURÍDICA")> Legal = 0
        <Description("PESSOA FÍSICA")> Natural = 1
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar o tipo de contribuição de ICMS de uma pessoa.
    ''' </summary>
    Public Enum PersonContribution
        <Description("CONTRIBUINTE")> TaxPayer = 0
        <Description("NÃO CONTRIBUINTE")> NonTaxPayer = 1
        <Description("ISENTO")> TaxFree = 2
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar o tipo de item do caixa
    ''' </summary>
    Public Enum CashItemType
        <Description("DESPESA")> Expense = 0
        <Description("RECEITA")> Income = 1
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar o tipo de contato da atividade do CRM.
    ''' </summary>
    Public Enum CrmTreatmentContactType
        <Description("TELEFONE")> Phone = 0
        <Description("E-MAIL")> Email = 1
        <Description("WHATSAPP")> Whatsapp = 2
    End Enum
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
    ''' <summary>
    ''' Utilizado para sinalizar o tipo de peça do compressor.
    ''' </summary>
    Public Enum CompressorPartType
        <Description("Hora Trabalhada")> WorkedHour = 0
        <Description("Dia Corrido")> ElapsedDay = 1
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar as rotinas do sistema.
    ''' </summary>
    Public Enum Routine
        <Description("Usuário")> User = 1
        <Description("E-mail do Usuário")> UserEmail = 101
        <Description("Pessoa")> Person = 2
        <Description("Endereço da Pessoa")> PersonAddress = 201
        <Description("Contato da Pessoa")> PersonContact = 202
        <Description("Compressor da Pessoa")> PersonCompressor = 203
        <Description("Item do Compressor da Pessoa (Hora de Trabalho)")> PersonCompressorPartWorkedHour = 204
        <Description("Item do Compressor da Pessoa (Dia Corrido)")> PersonCompressorPartElapsedDay = 205
        <Description("Ficha Cadastral da Pessoa")> PersonRegistrationForm = 206
        <Description("Plano de Manutenção")> PersonMaintenancePlan = 207
        <Description("Cidade")> City = 3
        <Description("Rota da Cidade")> CityRoute = 301
        <Description("Estado")> State = 4
        <Description("Rota")> Route = 5
        <Description("Produto")> Product = 6
        <Description("Código de Fornecedor de Produto")> ProductProviderCode = 601
        <Description("Código de Produto")> ProductCode = 602
        <Description("Preço de Produto")> ProductPrice = 603
        <Description("Foto do Produto")> ProductPicture = 604
        <Description("Unidade de Medida")> ProductUnit = 7
        <Description("Tabela de Preços")> ProductPriceTable = 8
        <Description("Família de Produtos")> ProductFamily = 9
        <Description("Grupo de Produtos")> ProductGroup = 10
        <Description("Caixa")> Cash = 11
        <Description("Item do Caixa")> CashItem = 1101
        <Description("Responsável Pelo Item do Caixa")> CashItemResponsible = 1102
        <Description("Folha de Caixa")> CashSheet = 1103
        <Description("Compressor")> Compressor = 12
        <Description("Item do Compressor (Hora de Trabalho)")> CompressorPartWorkedHour = 1201
        <Description("Item do Compressor (Dia Corrido)")> CompressorPartElapsedDay = 1202
        <Description("Avaliação de Compressor")> Evaluation = 13
        <Description("Gerenciamento de Avaliações")> EvaluationManagement = 1301
        <Description("Gerenciamento de Item Trocado (Hora de Trabalho)")> EvaluationManagementPartWorkedHour = 1302
        <Description("Gerenciamento de Item Trocado (Dia Corrido)")> EvaluationManagementPartElapsedDay = 1303
        <Description("Painel de Compressores")> EvaluationManagementPanel = 1304
        <Description("Exportar Grades do Painel de Compressores")> EvaluationManagementPanelExport = 1305
        <Description("Item da Avaliação")> EvaluationPart = 1306
        <Description("Técnico da Avaliação")> EvaluationTechnician = 1307
        <Description("Predefinição de Permissões do Usuário")> UserPrivilegePreset = 14
        <Description("Requisição")> Request = 15
        <Description("Item da Requisição")> RequestItem = 1501
        <Description("Folha de Requisição")> RequestSheet = 1502
        <Description("Itens Pendentes da Requisição")> RequestPendingItems = 1503
        <Description("Modelo de E-mail")> EmailModel = 16
        <Description("E-mails Enviados")> EmailSent = 17
        <Description("Grade Exportada")> ExportGrid = 18
        <Description("Fluxo de Caixa")> CashFlow = 19
        <Description("Funcionário Autorizado do Fluxo de Caixa")> CashFlowAuthorized = 1901
        <Description("Assinatura de E-Mail")> EmailSignature = 20
        <Description("CRM")> Crm = 21
        <Description("Atendimento do CRM")> CrmTreatment = 2101
    End Enum
    ''' <summary>
    ''' Utilizado para sinalizar erros a serem tratados nas queries.
    ''' </summary>
    Public Enum MysqlError
        UniqueKey = 1062
        ForeignKey = 1451
    End Enum

