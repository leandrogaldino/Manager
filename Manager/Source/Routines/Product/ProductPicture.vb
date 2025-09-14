Imports ManagerCore
''' <summary>
''' Representa o caminho de uma foto de um produto.
''' </summary>
Public Class ProductPicture
    Inherits ChildModel
    Public Property Picture As New FileManager(ApplicationPaths.ProductPictureDirectory())
    Public Sub New()
        SetRoutine(Routine.ProductPicture)
    End Sub
End Class
