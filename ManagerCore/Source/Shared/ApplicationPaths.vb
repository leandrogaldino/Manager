Imports System.IO
Imports System.Reflection

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
    Public Shared ReadOnly Property DataDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "Data")
        End Get
    End Property
    Public Shared ReadOnly Property CryptoKeyFile As String
        Get
            Return Path.Combine(DataDirectory, ".CryptoKey")
        End Get
    End Property
    Public Shared ReadOnly Property LicenseFile As String
        Get
            Return Path.Combine(DataDirectory, ".License")
        End Get
    End Property
    Public Shared ReadOnly Property LocalDbCredentialsFile As String
        Get
            Return Path.Combine(DataDirectory, ".LocalDbCredentials")
        End Get
    End Property
    Public Shared ReadOnly Property RemoteSystemDbCredentialsFile As String
        Get
            Return Path.Combine(DataDirectory, ".RemoteSystemDbCredentials")
        End Get
    End Property
    Public Shared ReadOnly Property RemoteCustomerDbCredentialsFile As String
        Get
            Return Path.Combine(DataDirectory, ".RemoteCustomerDbCredentials")
        End Get
    End Property
    Public Shared ReadOnly Property AgentEventsFile As String
        Get
            Return Path.Combine(DataDirectory, "AgentEvents.json")
        End Get
    End Property
    Public Shared ReadOnly Property DeployDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "Deploy")
        End Get
    End Property
    Public Shared ReadOnly Property LogoDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "Logo")
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
    Public Shared ReadOnly Property EvaluationPictureDirectory As String
        Get
            Return Path.Combine(FilesDirectory, "EvaluationPicture")
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
End Class
