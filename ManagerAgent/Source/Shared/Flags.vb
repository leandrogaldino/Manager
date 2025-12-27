Imports System.ComponentModel

Public Enum TaskName
    <Description("Backup")> Backup = 1
    <Description("Backup Manual")> BackupManual = 10
    <Description("Restaurar Backup")> BackupRestore = 11
    <Description("Limpeza")> Clean = 2
    <Description("Limpeza Manual")> CleanManual = 20
    <Description("Sincronizar")> CloudSync = 3
    <Description("Sincronizar Manual")> CloudSyncManual = 30
    <Description("Desbloquear")> Release = 4
    <Description("Desbloquear Manual")> ReleaseManual = 40
End Enum

Public Enum TaskStatus
    <Description("Sucesso")> Success = 0
    <Description("Erro")> [Error] = 1
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