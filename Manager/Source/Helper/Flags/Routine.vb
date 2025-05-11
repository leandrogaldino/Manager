Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar as rotinas do sistema (Rotinas que tem DataGridView).
''' </summary>
Public Enum Routine
    <Description("Usuário")> <TriStatePrivilege>
    User = 1
    UserEmail = 101
    <Description("Permite Resetar Senha")> <BiStatePrivilege> <RoutineDependency(User)>
    UserResetPassword = 102
    UserPrivilege = 103
    <Description("Pessoa")> <TriStatePrivilege>
    Person = 2
    PersonAddress = 201
    PersonContact = 202
    PersonCompressor = 203
    PersonCompressorPartWorkedHour = 204
    PersonCompressorPartElapsedDay = 205
    <Description("Alterar o documento da Pessoa")> <BiStatePrivilege> <RoutineDependency(Person)>
    PersonChangeDocument = 206
    <Description("Gerar o relatório de ficha cadastral da pessoa")> <BiStatePrivilege> <RoutineDependency(Person)>
    PersonRegistrationFormReport = 207
    <Description("Gerar o relatório de plano de manutenção")> <BiStatePrivilege> <RoutineDependency(Person)>
    PersonMaintenancePlanReport = 208
    <Description("Cidade")> <TriStatePrivilege> <RoutineDependency(Person)>
    City = 3
    CityRoute = 301
    <Description("Estado")> <TriStatePrivilege>
    State = 4
    <Description("Rota")> <TriStatePrivilege> <RoutineDependency(Person)>
    Route = 5
    <Description("Produto")> <TriStatePrivilege>
    Product = 6
    ProductProviderCode = 601
    ProductCode = 602
    ProductSellablePrice = 603
    ProductPicture = 604
    <Description("Unidade de Medida")> <TriStatePrivilege> <RoutineDependency(Product)>
    ProductUnit = 7
    <Description("Tabela de Preços")> <TriStatePrivilege> <RoutineDependency(Product)>
    SellablePriceTable = 8
    SellablePriceTableSellablePrice = 801
    <Description("Família de Produtos")> <TriStatePrivilege> <RoutineDependency(Product)>
    ProductFamily = 9
    <Description("Grupo de Produtos")> <TriStatePrivilege> <RoutineDependency(Product)>
    ProductGroup = 10
    <Description("Caixa")> <TriStatePrivilege>
    Cash = 11
    CashItem = 1101
    CashItemResponsible = 1102
    <Description("Compressor")> <TriStatePrivilege> <RoutineDependency(Person)>
    Compressor = 12
    CompressorPartWorkedHour = 1201
    CompressorPartElapsedDay = 1202
    <Description("Avaliação de Compressor")> <TriStatePrivilege>
    Evaluation = 13
    <Description("Gerenciamento de Avaliações")> <BiStatePrivilege> <RoutineDependency(Evaluation)>
    EvaluationManagement = 1301
    EvaluationManagementPartWorkedHour = 1302
    EvaluationManagementPartElapsedDay = 1303
    <Description("Painel de Compressores")> <BiStatePrivilege> <RoutineDependency(Evaluation)>
    EvaluationManagementPanel = 1304
    <Description("Exportar imagem do painel de compressores")> <BiStatePrivilege> <RoutineDependency(Evaluation)>
    EvaluationExportManagementPanel = 1305
    EvaluationPart = 1306
    EvaluationTechnician = 1307
    EvaluationPhoto = 1308
    <Description("Aprovar e rejeitar uma avaliação")> <BiStatePrivilege> <RoutineDependency(Evaluation)>
    EvaluationApproveOrReject = 1309
    <Description("Criar avaliações automáticas")> <BiStatePrivilege> <RoutineDependency(Evaluation)>
    EvaluationCreateAutomaticRecord = 1310
    <Description("Importar avaliações da núvem")> <BiStatePrivilege> <RoutineDependency(Evaluation)>
    EvaluationImport = 1311
    EvaluationReplacedPart = 1312
    <Description("Predefinição de Permissões")> <TriStatePrivilege> <RoutineDependency(User)>
    PrivilegePreset = 14
    PrivilegePresetPrivilege = 1401
    <Description("Requisição")> <TriStatePrivilege>
    Request = 15
    RequestItem = 1501
    <Description("Gerar o relatório de folha de requisição de itens")> <BiStatePrivilege> <RoutineDependency(Request)>
    RequestSheetReport = 1502
    <Description("Gerar o relatório de itens pendentes da requisição de itens")> <BiStatePrivilege> <RoutineDependency(Request)>
    RequestPendingItemsReport = 1503
    <Description("Modelo de E-mail")> <TriStatePrivilege>
    EmailModel = 16
    <Description("E-mails Enviados")> <TriStatePrivilege>
    EmailSent = 17
    <Description("Fluxo de Caixa")> <TriStatePrivilege> <RoutineDependency(Cash)>
    CashFlow = 19
    CashFlowAuthorized = 1901
    <Description("Gerar o relatório de folha de caixa")> <BiStatePrivilege> <RoutineDependency(Cash)>
    CashSheetReport = 1902
    <Description("Gerar o relatório de despesas por responsável do caixa")> <BiStatePrivilege> <RoutineDependency(Cash)>
    CashExpensesPerResponsibleReport = 1903
    <Description("Reabrir um caixa")> <BiStatePrivilege> <RoutineDependency(Cash)>
    CashReopen = 1904
    <Description("Assinatura de E-Mail")> <TriStatePrivilege>
    EmailSignature = 20
    <Description("CRM")> <TriStatePrivilege>
    Crm = 21
    CrmTreatment = 2101
    <Description("Alterar o status do CRM para pendente")> <BiStatePrivilege> <RoutineDependency(Crm)>
    CrmChangeStatusToPending = 2102
    <Description("Alterar o cliente do CRM")> <BiStatePrivilege> <RoutineDependency(Crm)>
    CrmChangeCustomer = 2103
    <Description("Alterar o responsavel do CRM")> <BiStatePrivilege> <RoutineDependency(Crm)>
    CrmChangeResponsible = 2104
    <Description("Alterar o assunto do CRM")> <BiStatePrivilege> <RoutineDependency(Crm)>
    CrmChangeSubject = 2105
    <Description("Editar um atendimento do CRM")> <BiStatePrivilege> <RoutineDependency(Crm)>
    CrmEditTreatment = 2106
    <Description("Agenda de Visita")> <TriStatePrivilege> <RoutineDependency(Evaluation)>
    VisitSchedule = 22
    <Description("Serviço")> <TriStatePrivilege>
    Service = 23
    ServiceComplement = 2301
    <Description("Exportar as grades")> <BiStatePrivilege>
    ExportGrid = 9901
    <Description("Acessar o histórico")> <BiStatePrivilege>
    Log = 9902
End Enum