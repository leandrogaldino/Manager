﻿Imports System.IO
Imports System.Reflection
Imports ControlLibrary

Public Class ApplicationPaths
    Private Shared _AgentDirectory As String
    Public Shared Sub Create()
        Dim MyType As Type = GetType(ApplicationPaths)
        Dim Properties() As PropertyInfo = MyType.GetProperties(BindingFlags.Public Or BindingFlags.Static)
        Dim PropPath As String
        For Each Prop As PropertyInfo In Properties
            PropPath = Prop.GetValue(Nothing, Nothing)
            If Not Directory.Exists(PropPath) AndAlso Not Path.HasExtension(PropPath) Then
                Directory.CreateDirectory(PropPath)
            End If
        Next Prop
        Dim Key As String = New CryptoKeyService().ReadCryptoKey()
        If Not File.Exists(SettingFile) Then File.WriteAllText(SettingFile, Cryptography.Encrypt(My.Resources.Setting, Key))
        If Not File.Exists(LicenseFile) Then File.WriteAllText(LicenseFile, Cryptography.Encrypt(My.Resources.License, Key))
        If Not File.Exists(EmailDefaultHtmlFile) Then File.WriteAllText(EmailDefaultHtmlFile, My.Resources.DefaultEmail)
    End Sub
    Public Shared Property AgentDirectory As String
        Get
            If Directory.Exists(_AgentDirectory) Then
                Return _AgentDirectory
            Else
                Throw New DirectoryNotFoundException()
            End If
        End Get
        Set(value As String)
            _AgentDirectory = value
        End Set
    End Property
    Public Shared ReadOnly Property ManagerTempDirectory As String
        Get
            Return Path.Combine(Path.GetTempPath, "Manager")
        End Get
    End Property
    Public Shared ReadOnly Property AgentTempDirectory As String
        Get
            Return Path.Combine(Path.GetTempPath, "ManagerAgent")
        End Get
    End Property
    Public Shared ReadOnly Property FilesDirectory As String
        Get
            Return Path.Combine(_AgentDirectory, "Files")
        End Get
    End Property
    Public Shared ReadOnly Property ConfigDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "Config")
        End Get
    End Property

    Public Shared ReadOnly Property CryptoKeyFile As String
        Get
            Return Path.Combine(ConfigDirectory, ".CryptoKey")
        End Get
    End Property
    Public Shared ReadOnly Property LicenseFile As String
        Get
            Return Path.Combine(ConfigDirectory, ".License")
        End Get
    End Property
    Public Shared ReadOnly Property SettingFile As String
        Get
            Return Path.Combine(ConfigDirectory, ".Setting")
        End Get
    End Property
    Public Shared ReadOnly Property DeployDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "Deploy")
        End Get
    End Property
    Public Shared ReadOnly Property LogoDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "CompanyLogo")
        End Get
    End Property
    Public Shared ReadOnly Property EvaluationDocumentDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "EvaluationDocument")
        End Get
    End Property
    Public Shared ReadOnly Property EvaluationSignatureDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "EvaluationSignature")
        End Get
    End Property
    Public Shared ReadOnly Property EvaluationPhotoDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "EvaluationPhoto")
        End Get
    End Property
    Public Shared ReadOnly Property ProductPictureDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "ProductPicture")
        End Get
    End Property
    Public Shared ReadOnly Property EmailSignatureDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "EmailSignature")
        End Get
    End Property
    Public Shared ReadOnly Property RequestDocumentDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "RequestDocument")
        End Get
    End Property
    Public Shared ReadOnly Property CashDocumentDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "CashDocument")
        End Get
    End Property
    Public Shared ReadOnly Property HelpersDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "Helpers")
        End Get
    End Property
    Public Shared ReadOnly Property EmailDefaultHtmlFile As String
        Get
            Return Path.Combine(HelpersDirectory, "EmailDefault.html")
        End Get
    End Property
End Class
