Imports System.ComponentModel

Public Enum TaskName
    <Description("Backup")> Backup = 1
    <Description("Backup - Manual")> BackupManual = 10
    <Description("Restaurar Backup")> BackupRestore = 11
    <Description("Limpeza")> Clean = 2
    <Description("Limpeza - Manual")> CleanManual = 20
    <Description("Sincroniza Núvem")> CloudSync = 3
    <Description("Sincroniza Núvem - Manual")> CloudSyncManual = 30
    <Description("Desbloqueio")> Release = 4
    <Description("Desbloqueio - Manual")> ReleaseManual = 40
End Enum



Public Enum BackupDirectories
    CashDocument = 0
    EmailSignature = 1
    EvaluationDocument = 2
    EvaluationPicture = 3
    EvaluationSignature = 4
    ProductPicture = 5
    RequestDocument = 6
    Helpers = 7
End Enum