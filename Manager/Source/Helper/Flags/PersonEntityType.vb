Imports System.ComponentModel

''' <summary>
''' Utilizado para sinalizar o tipo de entidade de uma pessoa.<br/>0 = Pessoa Jurídica | 1 = Pessoa Física
''' </summary>
Public Enum PersonEntityType
    <Description("PESSOA JURÍDICA")> Legal = 0
    <Description("PESSOA FÍSICA")> Natural = 1
End Enum