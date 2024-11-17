Imports System.IO
Imports ManagerCore
''' <summary>
''' Representa o caminho de uma foto de um produto.
''' </summary>
Public Class ProductPicture
    Inherits ChildModel
    Public Property Picture As New FileManager(ApplicationPaths.ProductPictureDirectory())
    Public ReadOnly Property PictureImage As Image
        Get
            If Not String.IsNullOrEmpty(Picture.CurrentFile) AndAlso File.Exists(Picture.CurrentFile) Then
                Return Image.FromStream(New MemoryStream(File.ReadAllBytes(Picture.CurrentFile)))
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property Caption As String
    Public Sub New()
        SetRoutine(Routine.ProductPicture)
    End Sub
End Class
