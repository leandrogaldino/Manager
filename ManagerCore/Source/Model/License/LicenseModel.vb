﻿Imports System.Xml

Public Class LicenseModel
    Implements ICloneable
    Public Property LicenseKey As String
    Public Property LicenseToken As String
    Public Property CustomerDocument As String
    Public Property CustomerName As String
    Public Property ExpirationDate As String
    Public Property ManagerAgentPassword As String
    Public Property ManagerAgentUsername As String

    Public LastOnlineValidation As Date
    Public Function Clone() As Object Implements ICloneable.Clone
        Return New LicenseModel With {
            .LicenseKey = Me.LicenseKey,
            .LicenseToken = Me.LicenseToken,
            .CustomerDocument = Me.CustomerDocument,
            .CustomerName = Me.CustomerName,
            .ExpirationDate = Me.ExpirationDate,
            .ManagerAgentPassword = Me.ManagerAgentPassword,
            .ManagerAgentUsername = Me.ManagerAgentUsername,
            .LastOnlineValidation = Me.LastOnlineValidation
        }
    End Function
    Public Shared Function FromDictionary(Data As Dictionary(Of String, Object)) As LicenseModel
        Dim Model As New LicenseModel()
        If Data.ContainsKey("license_key") Then Model.LicenseKey = TryCast(Data("license_key"), String)
        If Data.ContainsKey("license_token") Then Model.LicenseToken = TryCast(Data("license_token"), String)
        If Data.ContainsKey("customer_document") Then Model.CustomerDocument = TryCast(Data("customer_document"), String)
        If Data.ContainsKey("customer_name") Then Model.CustomerName = TryCast(Data("customer_name"), String)
        If Data.ContainsKey("expiration_date") Then Model.ExpirationDate = TryCast(Data("expiration_date"), String)
        If Data.ContainsKey("manager_agent_password") Then Model.ManagerAgentPassword = TryCast(Data("manager_agent_password"), String)
        If Data.ContainsKey("manager_agent_username") Then Model.ManagerAgentUsername = TryCast(Data("manager_agent_username"), String)
        Return Model
    End Function
    Public Function ToDictionary() As Dictionary(Of String, Object)
        Dim Dictionary As New Dictionary(Of String, Object) From {
            {"license_key", LicenseKey},
            {"license_token", LicenseToken},
            {"customer_document", CustomerDocument},
            {"customer_name", CustomerName},
            {"expiration_date", ExpirationDate},
            {"manager_agent_password", ManagerAgentPassword},
            {"manager_agent_username", ManagerAgentUsername}
        }
        Return Dictionary
    End Function


    ' Método para converter o objeto em XML com indentação e de forma assíncrona
    Public Async Function ToXmlAsync() As Task(Of String)
        Dim Settings As New XmlWriterSettings() With {
            .Indent = True,  ' Ativar indentação
            .NewLineOnAttributes = False,
            .Async = True     ' Permitir operações assíncronas
        }

        Dim StringBuilder As New Text.StringBuilder()
        Using Writer As XmlWriter = XmlWriter.Create(StringBuilder, Settings)
            Await Writer.WriteStartDocumentAsync()
            Await Writer.WriteStartElementAsync(Nothing, "License", Nothing)

            ' Escreve cada propriedade como um elemento de forma assíncrona
            Await WriteElementAsync(Writer, "LicenseKey", LicenseKey)
            Await WriteElementAsync(Writer, "LicenseToken", LicenseToken)
            Await WriteElementAsync(Writer, "CustomerDocument", CustomerDocument)
            Await WriteElementAsync(Writer, "CustomerName", CustomerName)
            Await WriteElementAsync(Writer, "ExpirationDate", ExpirationDate)
            Await WriteElementAsync(Writer, "ManagerAgentPassword", ManagerAgentPassword)
            Await WriteElementAsync(Writer, "ManagerAgentUsername", ManagerAgentUsername)
            Await WriteElementAsync(Writer, "LastOnlineValidation", LastOnlineValidation.ToString())

            Await Writer.WriteEndElementAsync() ' Fecha o elemento "License"
            Await Writer.WriteEndDocumentAsync()
        End Using

        ' Retorna o XML formatado como string
        Return StringBuilder.ToString()
    End Function

    ' Método auxiliar para escrever elementos no XML de forma assíncrona
    Private Async Function WriteElementAsync(Writer As XmlWriter, ElementName As String, Value As String) As Task
        Await Writer.WriteStartElementAsync(Nothing, ElementName, Nothing)
        Await Writer.WriteStringAsync(If(String.IsNullOrEmpty(Value), "", Value)) ' Garante que o elemento esteja presente mesmo se vazio
        Await Writer.WriteEndElementAsync()
    End Function

    ' Método para criar um objeto LicenseModel a partir de XML
    Public Shared Function FromXml(xmlData As String) As LicenseModel
        Dim Doc As New XmlDocument()
        Doc.LoadXml(xmlData)

        Dim Model As New LicenseModel()

        ' Atribuir valores de cada elemento XML à respectiva propriedade
        Model.LicenseKey = GetElementValue(Doc, "LicenseKey")
        Model.LicenseToken = GetElementValue(Doc, "LicenseToken")
        Model.CustomerDocument = GetElementValue(Doc, "CustomerDocument")
        Model.CustomerName = GetElementValue(Doc, "CustomerName")
        Model.ExpirationDate = GetElementValue(Doc, "ExpirationDate")
        Model.ManagerAgentPassword = GetElementValue(Doc, "ManagerAgentPassword")
        Model.ManagerAgentUsername = GetElementValue(Doc, "ManagerAgentUsername")

        Dim LastValidationString As String = GetElementValue(Doc, "LastOnlineValidation")
        If Not String.IsNullOrEmpty(LastValidationString) Then
            Model.LastOnlineValidation = Date.Parse(LastValidationString)
        End If

        Return Model
    End Function

    ' Método auxiliar para buscar valor de elementos XML
    Private Shared Function GetElementValue(Doc As XmlDocument, ElementName As String) As String
        Dim Element As XmlElement = Doc.SelectSingleNode("//" & ElementName)
        If Element IsNot Nothing Then
            Return Element.InnerText
        End If
        Return String.Empty
    End Function
End Class
