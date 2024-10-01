Imports System.IO
Imports System.Security.Cryptography

Public Class CryptoKeyService
    Public Sub New()
        CreateCryptoKeyIfNotExists()
    End Sub
    Private Sub CreateCryptoKeyIfNotExists()
        Dim Path As String = ApplicationPaths.CryptoKeyFile
        If Not File.Exists(Path) Then
            File.WriteAllText(Path, GenerateRandomKey())
        End If
    End Sub

    Public Function ReadCryptoKey() As String
        Dim Path As String = ApplicationPaths.CryptoKeyFile
        Dim Key As String = String.Empty
        If File.Exists(Path) Then
            Key = File.ReadAllText(Path)
        End If
        Return Key
    End Function

    Private Function GenerateRandomKey() As String
        Dim randomBytes(32 - 1) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(randomBytes)
        End Using
        Dim base64Key As String = Convert.ToBase64String(randomBytes)
        Return base64Key.Replace("=", String.Empty).Replace("+", String.Empty).Replace("/", String.Empty)
    End Function
End Class
