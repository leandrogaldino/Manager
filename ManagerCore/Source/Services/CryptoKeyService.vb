Imports System.IO
Imports Helpers

Public Class CryptoKeyService
    Public Sub New()
        CreateCryptoKeyIfNotExists()
    End Sub
    Private Sub CreateCryptoKeyIfNotExists()
        Dim Path As String = ApplicationPaths.CryptoKeyFile
        If Not File.Exists(Path) Then
            File.WriteAllText(Path, TextHelper.GetRandomString(1, 32, Nothing, {CharFilter.Alphanumeric, CharFilter.Numeric, CharFilter.SpecialCharacters}.ToList).Replace("=", String.Empty).Replace("+", String.Empty).Replace("/", String.Empty))
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
End Class
