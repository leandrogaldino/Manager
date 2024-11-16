Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de permissão do usuário a uma rotina.
''' </summary>
Public Enum PrivilegeLevel
    <Description("Acessar")> Access = 0
    <Description("Escrever")> Write = 1
    <Description("Excluir")> Delete = 2
End Enum
