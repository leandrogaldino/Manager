Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar as rotinas do sistema (Rotinas que tem DataGridView).
''' </summary>
Public Enum Routine
    <Description("Usuário")> <TriStatePrivilege>
    User = 1
    UserEmail = 101
    <Description("Permite Resetar Senha")> <BiStatePrivilege>
    UserResetPassword = 102
    UserPrivilege = 103
    <Description("Pessoa")> <TriStatePrivilege>
    Person = 2
    PersonAddress = 201
    PersonContact = 202
    PersonCompressor = 203
    PersonCompressorPartWorkedHour = 204
    PersonCompressorPartElapsedDay = 205
    <Description("Alterar o documento da Pessoa")> <BiStatePrivilege>
    PersonChangeDocument = 206
    <Description("Gerar o relatório de ficha cadastral da pessoa")> <BiStatePrivilege>
    PersonRegistrationFormReport = 207
    <Description("Gerar o relatório de plano de manutenção")> <BiStatePrivilege>
    PersonMaintenancePlanReport = 208
    <Description("Cidade")> <TriStatePrivilege>
    City = 3
    CityRoute = 301
    <Description("Estado")> <TriStatePrivilege>
    State = 4
    <Description("Rota")> <TriStatePrivilege>
    Route = 5
    <Description("Produto")> <TriStatePrivilege>
    Product = 6
    ProductProviderCode = 601
    ProductCode = 602
    ProductPrice = 603
    ProductPicture = 604
    <Description("Unidade de Medida")> <TriStatePrivilege>
    ProductUnit = 7
    <Description("Tabela de Preços")> <TriStatePrivilege>
    ProductPriceTable = 8
    <Description("Família de Produtos")> <TriStatePrivilege>
    ProductFamily = 9
    <Description("Grupo de Produtos")> <TriStatePrivilege>
    ProductGroup = 10
    <Description("Caixa")> <TriStatePrivilege>
    Cash = 11
    CashItem = 1101
    CashItemResponsible = 1102
    <Description("Compressor")> <TriStatePrivilege>
    Compressor = 12
    CompressorPartWorkedHour = 1201
    CompressorPartElapsedDay = 1202
    <Description("Avaliação de Compressor")> <TriStatePrivilege>
    Evaluation = 13
    <Description("Gerenciamento de Avaliações")> <TriStatePrivilege>
    EvaluationManagement = 1301
    EvaluationManagementPartWorkedHour = 1302
    EvaluationManagementPartElapsedDay = 1303
    <Description("Painel de Compressores")> <TriStatePrivilege>
    EvaluationManagementPanel = 1304
    <Description("Exportar imagem do painel de compressores")> <BiStatePrivilege>
    EvaluationExportManagementPanel = 1305
    EvaluationPart = 1306
    EvaluationTechnician = 1307
    EvaluationPhoto = 1308
    <Description("Aprovar e rejeitar uma avaliação")> <BiStatePrivilege>
    EvaluationApproveOrReject = 1309
    <Description("Criar avaliações automáticas")> <BiStatePrivilege>
    EvaluationCreateAutomaticRecord = 1310
    <Description("Importar avaliações da núvem")> <BiStatePrivilege>
    EvaluationImport = 1311
    <Description("Predefinição de Permissões")> <TriStatePrivilege>
    PrivilegePreset = 14
    <Description("Requisição")> <TriStatePrivilege>
    Request = 15
    RequestItem = 1501
    <Description("Gerar o relatório de folha de requisição de itens")> <BiStatePrivilege>
    RequestSheetReport = 1502
    <Description("Gerar o relatório de itens pendentes da requisição de itens")> <BiStatePrivilege>
    RequestPendingItemsReport = 1503
    <Description("Modelo de E-mail")> <TriStatePrivilege>
    EmailModel = 16
    <Description("E-mails Enviados")> <TriStatePrivilege>
    EmailSent = 17
    <Description("Fluxo de Caixa")> <TriStatePrivilege>
    CashFlow = 19
    CashFlowAuthorized = 1901
    <Description("Gerar o relatório de folha de caixa")> <BiStatePrivilege>
    CashSheetReport = 1902
    <Description("Gerar o relatório de despesas por responsável do caixa")> <BiStatePrivilege>
    CashExpensesPerResponsibleReport = 1903
    <Description("Reabrir um caixa")> <BiStatePrivilege>
    CashReopen = 1904
    <Description("Assinatura de E-Mail")> <TriStatePrivilege>
    EmailSignature = 20
    <Description("CRM")> <TriStatePrivilege>
    Crm = 21
    CrmTreatment = 2101
    <Description("Alterar o status do CRM para pendente")> <BiStatePrivilege>
    CrmChangeStatusToPending = 2102
    <Description("Alterar o cliente do CRM")> <BiStatePrivilege>
    CrmChangeCustomer = 2103
    <Description("Alterar o responsavel do CRM")> <BiStatePrivilege>
    CrmChangeResponsible = 2104
    <Description("Alterar o assunto do CRM")> <BiStatePrivilege>
    CrmChangeSubject = 2105
    <Description("Alterar o assunto do CRM")> <BiStatePrivilege>
    CrmEditTreatment = 2106
    <Description("Agendamento de Visita")> <TriStatePrivilege>
    VisitSchedule = 22
    <Description("Exportar as grades")> <BiStatePrivilege>
    ExportGrid = 9901
    <Description("Acessar o histórico")> <BiStatePrivilege>
    Log = 9902
End Enum