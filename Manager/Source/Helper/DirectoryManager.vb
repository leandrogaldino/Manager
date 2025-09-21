Imports System.IO
Imports ChinhDo.Transactions
Public Class DirectoryManager
    Private _DestDirectory As String
    Private _OriginalDirectory As String
    Private _CurrentDirectory As String
    Public Shared Property TempDirectory As String
    Public ReadOnly Property OriginalDirectory As String
        Get
            Return _OriginalDirectory
        End Get
    End Property
    Public ReadOnly Property CurrentDirectory As String
        Get
            Return _CurrentDirectory
        End Get
    End Property
    Public Sub New(DestDirectory As String)
        TempDirectory = TempDirectory
        _DestDirectory = DestDirectory
    End Sub
    Public Sub SetCurrentDirectory(Directory As String, Optional AsOriginal As Boolean = False)
        If String.IsNullOrEmpty(Directory) Or String.IsNullOrWhiteSpace(Directory) Then
            Directory = Nothing
        End If
        _CurrentDirectory = Directory
        If AsOriginal Then
            _OriginalDirectory = Directory
        End If
    End Sub
    Public Sub Execute()
        Dim FileManager As TxFileManager
        If String.IsNullOrEmpty(TempDirectory) Then
            FileManager = New TxFileManager()
        Else
            FileManager = New TxFileManager(TempDirectory)
        End If
        If String.IsNullOrEmpty(CurrentDirectory) And Not String.IsNullOrEmpty(_OriginalDirectory) Then
            'se nao tem atual mas tem original
            'deleta o original
            FileManager.DeleteDirectory(_OriginalDirectory)
            'seta original como nada
            _OriginalDirectory = Nothing
        ElseIf Not String.IsNullOrEmpty(CurrentDirectory) And String.IsNullOrEmpty(_OriginalDirectory) Then
            'se tem atual mas nao tem original
            'copia o atual
            FileManager.CopyDirectory(CurrentDirectory, IO.Path.Combine(_DestDirectory, IO.Path.GetFileName(CurrentDirectory)))
            'seta original igual atual
            _CurrentDirectory = IO.Path.Combine(_DestDirectory, IO.Path.GetFileName(CurrentDirectory))
            _OriginalDirectory = CurrentDirectory
        ElseIf Not String.IsNullOrEmpty(CurrentDirectory) And Not String.IsNullOrEmpty(_OriginalDirectory) Then
            'se tem atual e tem original
            If CurrentDirectory <> _OriginalDirectory Then
                'se o atual e diferente do original
                'deleta o original
                FileManager.DeleteDirectory(_OriginalDirectory)
                'copia o atual
                FileManager.CopyDirectory(CurrentDirectory, IO.Path.Combine(_DestDirectory, IO.Path.GetFileName(CurrentDirectory)))
                'seta original igual atual
                _CurrentDirectory = IO.Path.Combine(_DestDirectory, IO.Path.GetFileName(CurrentDirectory))
                _OriginalDirectory = CurrentDirectory
            End If
        End If
    End Sub
    Public Function Clone() As DirectoryManager
        Dim fm As New DirectoryManager(Me._DestDirectory)
        fm.SetCurrentDirectory(Me._CurrentDirectory, False)
        fm.SetCurrentDirectory(Me._OriginalDirectory, True)
        Return fm
    End Function
End Class
