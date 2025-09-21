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
    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New ProductPicture With {
            .Picture = Picture.Clone()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class
